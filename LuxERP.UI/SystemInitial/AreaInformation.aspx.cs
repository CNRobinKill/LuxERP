using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class AreaInformation : System.Web.UI.Page
    {
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
                    if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "23") == "0")
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

                            gvAreaInfoBind();
                        }
                        if (IsPostBack)
                        {
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

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public void gvAreaInfoBind()
        {
            gvAreaInfo.Width = 750;
            gvAreaInfo.DataSource = DAL.AreaInfoDAL.GetAreaInfo();
            gvAreaInfo.DataKeyNames = new string[] { "AreaName" };
            gvAreaInfo.DataBind();
            if (gvAreaInfo.HeaderRow != null)
            {
                gvAreaInfo.HeaderRow.Cells[0].Text = "<b>区域名称</b>";
                gvAreaInfo.HeaderRow.Cells[1].Text = "<b>区域别名</b>";
                gvAreaInfo.HeaderRow.Cells[2].Text = "<b>区域经理</b>";
                gvAreaInfo.HeaderRow.Cells[3].Text = "<b>经理联系电话</b>";
                gvAreaInfo.HeaderRow.Cells[4].Text = "<b>经理联系邮箱</b>";

            }
        }

        protected void btnAddAreaInfo_Click(object sender, EventArgs e)
        {
            if (txtAreaName.Text.Trim() != "" && txtAreaAliss.Text.Trim() != "" && txtAreaManager.Text.Trim() != "" && txtManagerPhone.Text.Trim() != "" && txtManagerEmail.Text.Trim() != "")
            {
                DAL.AreaInfoDAL.AddAreaInfo(txtAreaName.Text.Trim(), txtAreaAliss.Text.Trim(), txtAreaManager.Text.Trim(), txtManagerPhone.Text.Trim(), txtManagerEmail.Text.Trim());
            }
            gvAreaInfoBind();
        }

        protected void gvAreaInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.AreaInfoDAL.DelAreaInfo(gvAreaInfo.DataKeys[e.RowIndex].Value.ToString());
            gvAreaInfoBind();
        }

        protected void gvAreaInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string areaName = gvAreaInfo.DataKeys[e.RowIndex].Value.ToString();
            string areaAliss = ((TextBox)gvAreaInfo.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
            string areaManager = ((TextBox)gvAreaInfo.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
            string managerPhone = ((TextBox)gvAreaInfo.Rows[e.RowIndex].Cells[3].Controls[0]).Text.Trim();
            string managerEmail = ((TextBox)gvAreaInfo.Rows[e.RowIndex].Cells[4].Controls[0]).Text.Trim();

            if (areaAliss == ""&& areaManager == ""&& managerPhone == ""&& managerEmail == "")
            {
                MsgBox("请填写完整！");
            }
            else
            {
                DAL.AreaInfoDAL.UpdateAreaInfo(areaName, areaAliss, areaManager, managerPhone, managerEmail);
                gvAreaInfo.EditIndex = -1;
            }
            gvAreaInfoBind();
        }

        protected void gvAreaInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAreaInfo.EditIndex = e.NewEditIndex;
            gvAreaInfoBind();
        }

        protected void gvAreaInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAreaInfo.EditIndex = -1;
            gvAreaInfoBind();
        }
    }
}