using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class InitialStores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddStores.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddStores, "click") + ";this.disabled=true; this.value='处理中...';");
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "16") == "0")
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

                            }
                            if (IsPostBack)
                            {
                                RegisterJS("setDate");
                                RegisterJS("addRowStyle");
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        protected void btnAddStores_Click(object sender, EventArgs e)
        {
            string storeNo = txtStoreNo.Text.Trim();
            string topStore = ddlTopStore.SelectedValue;
            string storeType = ddlStoreType.SelectedValue;
            string region = txtRegion.Text.Trim();
            string rating = ddlRating.Text.Trim();
            string storeName = txtStoreName.Text.Trim();
            string city = txtCity.Text.Trim();
            string storeAddress = txtStoreAddress.Text.Trim();
            string storeTel = txtStoreTel.Text.Trim();
            //string contractArea = txtContractArea.Text.Trim();
            //string openingDate = txtOpeningDate.Text.Trim();
            //string storeState = ddlStoreState.SelectedValue;

            if (storeNo == "" || region == "")
            {
                MsgBox("店号和区域不能为空！");              
            }
            else
            {
                if (DAL.StoresDAL.AddStores(storeNo, topStore, storeType, region, rating, storeName, city, storeAddress, storeTel, "", "", "900") > 0)
                {   
                    MsgBox("添加店铺成功！");
                    RegisterJS("clearPage");
                }
                else
                {
                    MsgBox("添加店铺失败！");
                }
            }
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);  
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method+"();", true);
        }
        
    }
}