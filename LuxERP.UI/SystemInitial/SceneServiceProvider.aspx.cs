using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class SceneServiceProvider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userName"] == null)
            //{
            //    Response.Write("<script LANGUAGE=JavaScript >" +
            //           " alert('未登陆或已超时，请重新登录！');" +
            //           " window.location=('/LogOn.aspx');" +
            //           "</script>");
            //    Response.End();
            //}
            //else
            //{
            //    if (DAL.SystemUserDAL.GetUserIP(Session["userName"].ToString(), DAL.IPNetworking.GetIP4Address()) == "")
            //    {
            //        Response.Write("<script LANGUAGE=JavaScript >" +
            //            " alert('用户已在另外一台机器上登录！');" +
            //            " window.location=('/LogOn.aspx');" +
            //            "</script>");
            //        Response.End();
            //    }
            //    else
            //    {
            //        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "13") == "0")
            //        {
            //            Response.Write("<script LANGUAGE=JavaScript >" +
            //                " alert('没有权限，请联系管理员！');" +
            //                " window.location=('/LogOn.aspx');" +
            //                "</script>");
            //            Response.End();
            //        }
            //        try
            //        {
                        if (!IsPostBack)
                        {
            //                //try
            //                //{

            //                //}
            //                //catch
            //                //{
            //                //    Response.Write("<script LANGUAGE=JavaScript >" +
            //                //            " alert('还没登录吧？');" +
            //                //            " window.location=('/LogOn.aspx');" +
            //                //            "</script>");
            //                //}
                            ddlServiceAreaShow();
                            ddlServiceProviderShow();
            //                gvSceneServiceProviderBind();
                        }
            //            if (IsPostBack)
            //            {
            //                RegisterJS("addRowStyle");
            //            }
            //        }
            //        catch
            //        {
            //            Response.Redirect("~/Error.html");
            //        }
            //    }
            //}
        }

        public void ddlServiceAreaShow()
        {
            ddlServiceArea.DataSource = DAL.AreaInfoDAL.GetAreaAliss();
            ddlServiceArea.DataValueField = "AreaAliss";
            ddlServiceArea.DataTextField = "AreaAliss";
            ddlServiceArea.DataBind();
            ddlServiceArea.SelectedValue = "";
        }

        public void ddlServiceProviderShow()
        {
            ddlServiceProvider.DataSource = DAL.SceneServiceProviderDAL.GetServiceProvider();
            ddlServiceProvider.DataValueField = "ServiceProvider";
            ddlServiceProvider.DataTextField = "ServiceProvider";
            ddlServiceProvider.DataBind();
            ddlServiceProvider.SelectedValue = "";
        }


        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public Boolean returnbool(string f)
        {
            try
            {
                float i = float.Parse(f);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void gvSceneServiceProviderBind()
        {
            gvSceneServiceProvider.Width = 750;
            gvSceneServiceProvider.DataSource = DAL.SceneServiceProviderDAL.GetSceneServiceProvider();
            gvSceneServiceProvider.DataKeyNames = new string[] { "ServiceProvider" };
            gvSceneServiceProvider.DataBind();
            if (gvSceneServiceProvider.HeaderRow != null)
            {
                gvSceneServiceProvider.HeaderRow.Cells[0].Text = "<b>上门服务商</b>";
                gvSceneServiceProvider.HeaderRow.Cells[1].Text = "<b>联系电话</b>";
                gvSceneServiceProvider.HeaderRow.Cells[2].Text = "<b>服务区域</b>";
                gvSceneServiceProvider.HeaderRow.Cells[3].Text = "<b>剩余Token数</b>";
                divAddToken.Visible = true;
            }
            else
            {
                divAddToken.Visible = false;
            }
        }

        protected void btnAddSceneServiceProvider_Click(object sender, EventArgs e)
        {
            if (txtServiceProvider.Text.Trim() != "" && txtPhone.Text.Trim() != "" && txtRemainToken.Text.Trim() != "")
            {
                string remainToken = txtRemainToken.Text.Trim();
                if (returnbool(remainToken))
                {
                    DAL.SceneServiceProviderDAL.AddSceneServiceProvider(txtServiceProvider.Text.Trim(), txtPhone.Text.Trim(), ddlServiceArea.SelectedValue, txtRemainToken.Text.Trim());
                }
            }
            gvSceneServiceProviderBind();
        }

        protected void gvSceneServiceProvider_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string serviceProvider = gvSceneServiceProvider.DataKeys[e.RowIndex].Value.ToString(); ;
            string phone = ((TextBox)gvSceneServiceProvider.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string serviceArea = ((DropDownList)gvSceneServiceProvider.Rows[e.RowIndex].Cells[2].FindControl("ddlServiceAreaB")).SelectedValue;

            if (phone == "")
            {
                MsgBox("不能为空！");
            }
            else
            {
                DAL.SceneServiceProviderDAL.UpdateSceneServiceProvider(serviceProvider, phone, serviceArea);
                gvSceneServiceProvider.EditIndex = -1;
                gvSceneServiceProviderBind();
            }
        }

        protected void gvSceneServiceProvider_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSceneServiceProvider.EditIndex = e.NewEditIndex;
            gvSceneServiceProviderBind();
        }

        protected void gvSceneServiceProvider_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSceneServiceProvider.EditIndex = -1;
            gvSceneServiceProviderBind();
        }

        protected void gvSceneServiceProvider_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.SceneServiceProviderDAL.DelSceneServiceProvider(gvSceneServiceProvider.DataKeys[e.RowIndex].Value.ToString());
            gvSceneServiceProviderBind();
        }

        protected void gvSceneServiceProvider_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddl;
            if (((DropDownList)e.Row.FindControl("ddlServiceAreaB")) != null)
            {
                ddl = (DropDownList)e.Row.FindControl("ddlServiceAreaB");
                ddl.DataSource = DAL.AreaInfoDAL.GetAreaAliss();
                ddl.DataValueField = "AreaAliss";
                ddl.DataTextField = "AreaAliss";
                ddl.DataBind();
                ddl.SelectedValue = ((HiddenField)e.Row.FindControl("hdServiceArea")).Value;
            }
        }

        protected void btnAddToken_Click(object sender, EventArgs e)
        {
            if (txtToken.Text.Trim()!="")
            {
                string token = txtToken.Text.Trim();
                if (returnbool(token))
                {
                    DAL.SceneServiceProviderDAL.UpdateAddToken(ddlServiceProvider.SelectedValue, token);
                }
            }
            txtToken.Text = "";
            gvSceneServiceProviderBind();
        }

    }
}