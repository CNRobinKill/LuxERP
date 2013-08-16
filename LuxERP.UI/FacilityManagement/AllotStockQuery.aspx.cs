using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LuxERP.UI.FacilityManagement
{
    public partial class AllotStockQuery : System.Web.UI.Page
    {
        public static int pageSize = 30; // 每页行数
        public static int totalPage = 1; // 总页数
        public static int currentPage = 1; // 当前页
        public static AllotStocksParameters paras;

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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "8") == "0")
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

        //public void DDLDataBind()
        //{
        //    BindDDL(DAL.FacilityDAL.GetMaching, ddlMaching);
        //    BindDDL(DAL.FacilityDAL.GetBrand, ddlBrand);
        //    BindDDL(DAL.FacilityDAL.GetModel, ddlModel);
        //    BindDDL(DAL.FacilityDAL.GetParameter, ddlParameter);            
        //}

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            paras = new AllotStocksParameters();
            paras.EventNo = txtEventNo.Text.Trim();
            paras.StoreNoA = txtStoreNoA.Text.Trim();
            paras.StoreNoB = txtStoreNoB.Text.Trim();
            paras.AllotStockDateF = txtAllotStockF.Text.Trim();
            paras.AllotStockDateT = txtAllotStockT.Text.Trim();            
            paras.Maching = ddlMaching.SelectedValue;
            paras.Brand = ddlBrand.SelectedValue;
            paras.Model = ddlModel.SelectedValue;
            paras.Parameter = ddlParameter.SelectedValue;
            paras.SerialNo = txtSerialNo.Text.Trim();
            paras.AllotStockState = ddlAllotState.SelectedValue;
            paras.Operator = txtOperator.Text.Trim();

            DataSet ds = DAL.AllotStocksDAL.GetAllotStocksTotal(paras.EventNo, paras.StoreNoA, paras.StoreNoB, paras.Maching, paras.Brand, paras.Model, paras.SerialNo, paras.Parameter, paras.AllotStockDateF, paras.AllotStockDateT, paras.Operator, paras.AllotStockState);
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

        public void GVDataBind(int pageidx)
        {
            string eventNo = paras.EventNo;
            string storeNoA = paras.StoreNoA;
            string storeNoB = paras.StoreNoB;
            string allotStockDateF = paras.AllotStockDateF;
            string allotStockDateT = paras.AllotStockDateT;
            string maching = paras.Maching;
            string brand = paras.Brand;
            string model = paras.Model;
            string parameter = paras.Parameter;
            string serialNo = paras.SerialNo;
            string allotStockState = paras.AllotStockState;
            string operators = paras.Operator;
            DataSet source = DAL.AllotStocksDAL.GetAllotStocksPaged(eventNo, storeNoA, storeNoB, maching, brand, model, serialNo, parameter, allotStockDateF, allotStockDateT, operators, allotStockState, pageSize, pageidx);

            currentPage = pageidx;
            lblCurrent.Text = "第 " + currentPage.ToString() + " 页";
            lblTotalPages.Text = "共 " + totalPage.ToString() + " 页";

            gvAllotStock.DataSource = source;
            gvAllotStock.DataBind();
            gvAllotStock.Width = 1150;
            if (gvAllotStock.HeaderRow != null)
            {
                //gvAllotStock.HeaderRow.Cells[0].Text = "<b>ID</b>";
                gvAllotStock.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
                gvAllotStock.HeaderRow.Cells[1].Text = "<b>仓库门店编号A</b>";
                gvAllotStock.HeaderRow.Cells[2].Text = "<b>仓库门店编号B</b>";
                gvAllotStock.HeaderRow.Cells[3].Text = "<b>机器名称</b>";
                gvAllotStock.HeaderRow.Cells[4].Text = "<b>品牌</b>";
                gvAllotStock.HeaderRow.Cells[5].Text = "<b>型号</b>";
                gvAllotStock.HeaderRow.Cells[6].Text = "<b>序列号</b>";
                gvAllotStock.HeaderRow.Cells[7].Text = "<b>配置参数</b>";
                gvAllotStock.HeaderRow.Cells[8].Text = "<b>调拨时间</b>";
                gvAllotStock.HeaderRow.Cells[9].Text = "<b>操作人</b>";
                gvAllotStock.HeaderRow.Cells[10].Text = "<b>调拨状态</b>";
                showpage.Visible = true;
            }
            else
            { showpage.Visible = true; }
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            GVDataBind(1);
        }

        protected void btnPrvPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                GVDataBind(currentPage - 1);
            }
        }

        protected void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                GVDataBind(currentPage + 1);
            }
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            GVDataBind(totalPage);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(txtCurPage.Text);
            if (n >= 1 && n <= totalPage)
            {
                GVDataBind(n);
            }
        }

        public void InitialDll()
        {
            ddlMaching.Items.Clear();
            ddlMaching.Items.Add("");
            for (int i = 0; i < DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows.Count; i++)
            {
                ddlMaching.Items.Add(DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows[i][0].ToString());
            }
            //ddlSupplier.Items.Clear();
            //ddlSupplier.Items.Add("");
            //for (int i = 0; i < DAL.SynthesisDAL.GetSupplier().Tables[0].Rows.Count; i++)
            //{
            //    ddlSupplier.Items.Add(DAL.SynthesisDAL.GetSupplier().Tables[0].Rows[i][0].ToString());
            //}
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

    public class AllotStocksParameters
    {
        public string EventNo { get; set; }
        public string StoreNoA { get; set; }
        public string StoreNoB { get; set; }
        public string AllotStockDateF { get; set; }
        public string AllotStockDateT { get; set; }  
        public string Maching { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Parameter { get; set; }
        public string SerialNo { get; set; }
        public string Operator { get; set; }
        public string AllotStockState { get; set; }
    }
}