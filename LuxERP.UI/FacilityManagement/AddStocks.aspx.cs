using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LuxERP.UI.FacilityManagement
{
    public partial class AddStocks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnSubmit.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnSubmit, "click") + ";this.disabled=true; this.value='处理中...';");
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
                        try
                        {
                            if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "5") == "0")
                            {
                                Response.Write("<script LANGUAGE=JavaScript >" +
                                    " alert('没有权限，请联系管理员！');" +
                                    " window.location=('/LogOn.aspx');" +
                                    "</script>");
                                Response.End();
                            }
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
                                InitialDll();

                            }
                            if (IsPostBack)
                            {
                                RegisterJS("setDate");
                            }
                            //else
                            //{
                            //    DDLBind();

                            //}
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }
                
        //public delegate DataSet GetDelegate();

        //public void BindData(GetDelegate getMethod, DropDownList ddl)
        //{
        //    DataSet ds = getMethod();
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ddl.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        //    }
        //}

        //public void DDLBind()
        //{
        //    BindData(DAL.FacilityDAL.GetMaching, ddlMaching);
        //    BindData(DAL.FacilityDAL.GetBrand, ddlBrand);
        //    BindData(DAL.FacilityDAL.GetModel, ddlModel);
        //    BindData(DAL.FacilityDAL.GetParameter, ddlParameter);
        //    BindData(DAL.FacilityDAL.GetSupplier, ddlSupplier);
        //}
        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string wstoreNo = txtWStoreNo.Text.Trim();
            //string stockType = ddlStockType.SelectedValue;
            string maching = ddlMaching.SelectedValue;
            string brand = ddlBrand.SelectedValue;
            string model = ddlModel.SelectedValue;
            string serialNo = txtSerialNo.Text.Trim();
            string parameter = ddlParameter.SelectedValue;
            string epcTags = txtEpcTags.Text.Trim();
            string sapNo = txtSapNo.Text.Trim();
            string purchaseDate = txtPurchaseDate.Text.Trim();
            string guarantee = txtGuaranteeDate.Text.Trim();
            string repairNo = txtRepairNo.Text.Trim();
            string supplier = ddlSupplier.SelectedValue;
            //string stockDate = txtStockDate.Text.Trim();
            //string machingState = ddlMachingState.SelectedValue;

            //purchaseDate = purchaseDate == "" ? DateTime.Now.ToShortDateString() : purchaseDate;
            //guarantee = guarantee == "" ? DateTime.Now.ToShortDateString() : guarantee;
            //stockDate = stockDate == "" ? DateTime.Now.ToShortDateString() : stockDate;

            //if (maching == "" || brand == "" || model == "" || parameter == "" || supplier == "")
            //{
            //    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('设备信息还未录入或缺少!'); window.location.href='/SystemInitial/FacilityManage.aspx';", true);
            //    //System.Threading.Thread.Sleep(2000);
            //    //Response.Redirect("/FacilityManagement/FacilityManage.aspx");
            //}
            //else
            //{

                if (maching == "" || brand == "" || model == "" || parameter == "" || supplier == "" || wstoreNo == "" || serialNo == "")
                {
                    MsgBox("带*号的不能为空");
                }
                else
                {
                    if (DAL.StocksDAL.AddStocksCommitHistory(wstoreNo, maching, brand, model, serialNo, parameter, epcTags, sapNo, purchaseDate, guarantee, repairNo, supplier, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session["userName"].ToString(), "0", "0") > 0)
                    {
                        MsgBox("添加库存成功！");
                        RegisterJS("clearPage");
                    }
                    else
                    {
                        MsgBox("添加库存失败！");
                    }
                }
            //}

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
}