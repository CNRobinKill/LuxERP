using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LuxERP.UI.FacilityManagement
{
    public partial class ScrapStocks : System.Web.UI.Page
    {
        public static int pageSize = 30; // 每页行数
        public static int totalPage = 1; // 总页数
        public static int currentPage = 1; // 当前页
        public static ScrapStocksParameters paras;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["userName"] == null)
                {
                    Response.Write("<script LANGUAGE=JavaScript >" +
                           " alert('未登陆或已超时，请重新登录！');" +
                           " window.location=('/LogOn.aspx');" +
                           "</script>");
                    Response.End();
                }
                else
                {
                    if (DAL.SystemUserDAL.GetUserIP(Session["userName"].ToString(), DAL.IPNetworking.GetIP4Address()) == "")
                    {
                        Response.Write("<script LANGUAGE=JavaScript >" +
                            " alert('用户已在另外一台机器上登录！');" +
                            " window.location=('/LogOn.aspx');" +
                            "</script>");
                        Response.End();
                    }
                    else
                    {
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "19") == "0")
                        {
                            Response.Write("<script LANGUAGE=JavaScript >" +
                                " alert('没有权限，请联系管理员！');" +
                                " window.location=('/LogOn.aspx');" +
                                "</script>");
                            Response.End();
                        }
                        try
                        {
                            if (!IsPostBack)
                            {
                                //try
                                //{

                                //}
                                //catch
                                //{
                                //    Response.Write("<script LANGUAGE=JavaScript >" +
                                //            " alert('还没登录吧？');" +
                                //            " window.location=('/LogOn.aspx');" +
                                //            "</script>");
                                //}

                                //DDLDataBind();
                                InitialDll();
                            }
                            else
                            {
                                RegisterJS("setDate");
                                RegisterJS("setTableColor");
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        //public void DDLDataBind()
        //{
        //    BindDDL(DAL.FacilityDAL.GetMaching, ddlMaching);
        //    BindDDL(DAL.FacilityDAL.GetBrand, ddlBrand);
        //    BindDDL(DAL.FacilityDAL.GetModel, ddlModel);
        //    BindDDL(DAL.FacilityDAL.GetParameter, ddlParameter);
        //    BindDDL(DAL.FacilityDAL.GetSupplier, ddlSupplier);
        //}
        //public delegate DataSet GetDataDelegate();

        //public void BindDDL(GetDataDelegate getMethod, DropDownList ddl)
        //{
        //    DataSet ds = getMethod();
        //    ddl.Items.Add("");
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ddl.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        //    }
        //}

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            GVDataBind(1);
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            GVDataBind(totalPage);
        }

        protected void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                GVDataBind(currentPage + 1);
            }
        }

        protected void btnPrvPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                GVDataBind(currentPage - 1);
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(txtCurPage.Text);
            if (n >= 1 && n <= totalPage)
            {
                GVDataBind(n);
            }
        }

        public void GVDataBind(int pageidx)
        {
            string warehouseNo = paras.WarehouseNo;
            string AddScrapStockDateA = paras.AddScrapStockDateA;
            string AddScrapStockDateB = paras.AddScrapStockDateB;
            string maching = paras.Maching;
            string brand = paras.Brand;
            string model = paras.Model;
            string parameter = paras.Parameter;
            string supplier = paras.Supplier;
            DataSet source = DAL.ScrapStocksDAL.GetScrapStocksPaged(warehouseNo, maching, brand, model, parameter, supplier, AddScrapStockDateA, AddScrapStockDateB, pageSize, pageidx);

            currentPage = pageidx;
            lblCurrent.Text = "第 " + currentPage.ToString() + " 页";
            lblTotalPages.Text = "共 " + totalPage.ToString() + " 页";

            gvScrapStock.DataSource = source;
            gvScrapStock.DataKeyNames = new string[] { "ID" };
            gvScrapStock.DataBind();
            gvScrapStock.Width = 1200;
            if (gvScrapStock.HeaderRow != null)
            {
                //gvScrapStock.HeaderRow.Cells[0].Text = "<b>ID</b>"; 
                gvScrapStock.HeaderRow.Cells[0].Text = "<b>仓库编号</b>";
                gvScrapStock.HeaderRow.Cells[1].Text = "<b>机器</b>";
                gvScrapStock.HeaderRow.Cells[2].Text = "<b>品牌</b>";
                gvScrapStock.HeaderRow.Cells[3].Text = "<b>型号</b>";
                gvScrapStock.HeaderRow.Cells[4].Text = "<b>配置参数</b>";
                gvScrapStock.HeaderRow.Cells[5].Text = "<b>序列号</b>";
                gvScrapStock.HeaderRow.Cells[6].Text = "<b>标签码</b>";
                gvScrapStock.HeaderRow.Cells[7].Text = "<b>报修电话</b>";
                gvScrapStock.HeaderRow.Cells[8].Text = "<b>供应商</b>";
                gvScrapStock.HeaderRow.Cells[9].Text = "<b>废损日期</b>";
                gvScrapStock.HeaderRow.Cells[10].Text = "<b>操作人</b>";
                gvScrapStock.HeaderRow.Cells[11].Text = "<b>废损前所在</b>";
                gvScrapStock.HeaderRow.Cells[12].Text = "<b>废损原因</b>";
                showpage.Visible = true;
            }
            else
            { showpage.Visible = true; }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            paras = new ScrapStocksParameters();
            paras.WarehouseNo = txtWarehouseNo.Text.Trim();
            paras.AddScrapStockDateA = txtAddScrapStockDateA.Text.Trim();
            paras.AddScrapStockDateB = txtAddScrapStockDateB.Text.Trim();
            paras.Maching = ddlMaching.SelectedValue;
            paras.Brand = ddlBrand.SelectedValue;
            paras.Model = ddlModel.SelectedValue;
            paras.Parameter = ddlParameter.SelectedValue;
            paras.Supplier = ddlSupplier.SelectedValue;

            DataSet ds = DAL.ScrapStocksDAL.GetScrapStocksTotal(paras.WarehouseNo, paras.Maching, paras.Brand, paras.Model, paras.Parameter, paras.Supplier, paras.AddScrapStockDateA, paras.AddScrapStockDateB);
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > pageSize)
            {
                totalPage = (int)Math.Ceiling((double)rowsCount / (double)pageSize);
            }
            else
            {
                totalPage = 1;
            }

            GVDataBind(1);
        }

        public void InitialDll()
        {
            ddlMaching.Items.Clear();
            ddlMaching.Items.Add("");
            for (int i = 0; i < DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows.Count; i++)
            {
                ddlMaching.Items.Add(DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows[i][0].ToString());
            }
            ddlSupplier.Items.Clear();
            ddlSupplier.Items.Add("");
            for (int i = 0; i < DAL.SynthesisDAL.GetSupplier().Tables[0].Rows.Count; i++)
            {
                ddlSupplier.Items.Add(DAL.SynthesisDAL.GetSupplier().Tables[0].Rows[i][0].ToString());
            }
            ddlBrand.Items.Add("");
            ddlModel.Items.Add("");
            ddlParameter.Items.Add("");
        }


        protected void ddlMaching_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaching.SelectedValue == "")
            {
                ddlBrand.Items.Clear();
                ddlModel.Items.Clear();
                ddlParameter.Items.Clear();
                ddlBrand.Items.Add("");
                ddlModel.Items.Add("");
                ddlParameter.Items.Add("");
            }
            else
            {
                ddlBrand.Items.Clear();
                ddlBrand.Items.Add("");
                for (int i = 0; i < DAL.FacilityDAL.GetBrandFromFacility(ddlMaching.SelectedValue).Tables[0].Rows.Count; i++)
                {
                    ddlBrand.Items.Add(DAL.FacilityDAL.GetBrandFromFacility(ddlMaching.SelectedValue).Tables[0].Rows[i][0].ToString());
                }
                ddlModel.Items.Clear();
                ddlParameter.Items.Clear();
                ddlModel.Items.Add("");
                ddlParameter.Items.Add("");
            }
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedValue == "")
            {
                ddlModel.Items.Clear();
                ddlParameter.Items.Clear();
                ddlModel.Items.Add("");
                ddlParameter.Items.Add("");
            }
            else
            {
                ddlModel.Items.Clear();
                ddlModel.Items.Add("");
                for (int i = 0; i < DAL.FacilityDAL.GetModelFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue).Tables[0].Rows.Count; i++)
                {
                    ddlModel.Items.Add(DAL.FacilityDAL.GetModelFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue).Tables[0].Rows[i][0].ToString());
                }
                ddlParameter.Items.Clear();
                ddlParameter.Items.Add("");
            }
        }

        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModel.SelectedValue == "")
            {
                ddlParameter.Items.Clear();
                ddlParameter.Items.Add("");
            }
            else
            {
                ddlParameter.Items.Clear();
                ddlParameter.Items.Add("");
                for (int i = 0; i < DAL.FacilityDAL.GetParameterFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue, ddlModel.SelectedValue).Tables[0].Rows.Count; i++)
                {
                    ddlParameter.Items.Add(DAL.FacilityDAL.GetParameterFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue, ddlModel.SelectedValue).Tables[0].Rows[i][0].ToString());
                }
            }
        }
    }

    public class ScrapStocksParameters
    {
        public string WarehouseNo { get; set; }
        public string AddScrapStockDateA { get; set; }
        public string AddScrapStockDateB { get; set; }
        public string Maching { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Parameter { get; set; }
        public string Supplier { get; set; }
    }
}