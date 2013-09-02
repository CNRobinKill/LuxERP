using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.Admin
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddSystemUser.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddSystemUser, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnChangeAdministratorPassword.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnChangeAdministratorPassword, "click") + ";this.disabled=true; this.value='处理中...';");
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "18") == "0")
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

                                gvSystemUserBind();
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

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public void gvSystemUserBind()
        {
            gvSystemUser.Width = 850;
            gvSystemUser.DataSource = DAL.SystemUserDAL.GetSystemUser();
            gvSystemUser.DataKeyNames = new string[] { "UserName" };
            gvSystemUser.DataBind();
            if (gvSystemUser.HeaderRow != null)
            {
                gvSystemUser.HeaderRow.Cells[1].Text = "<b>用户名</b>";
                gvSystemUser.HeaderRow.Cells[2].Text = "<b>密码</b>";
                gvSystemUser.HeaderRow.Cells[3].Text = "<b>创建时间</b>";
                gvSystemUser.HeaderRow.Cells[4].Text = "<b>最近登录时间</b>";
                gvSystemUser.HeaderRow.Cells[5].Text = "<b>状态</b>";
            }

        }

        protected void btnAddSystemUser_Click(object sender, EventArgs e)
        {
            if (txtPassWord.Text.Length <= 25 && txtUserName.Text.Length <= 25)
            {
                if (txtUserName.Text.Trim() != "" && txtPassWord.Text.Trim() != "")
                {
                    DAL.SystemUserDAL.AddSystemUser(txtUserName.Text.Trim(), txtPassWord.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    MsgBox("请将信息填写完整！");
                }
            }
            else
            {
                MsgBox("设置的用户名或密码过长！请设置不大于25个字符！");
            }
            gvSystemUserBind();
        }

        protected void gvSystemUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[5].Text == "已启用")
            { 
                e.Row.Cells[7].Text ="";
                e.Row.Cells[10].Text = "";
            }
            if (e.Row.Cells[5].Text == "禁用中")
            { 
                e.Row.Cells[8].Text = "";
            }            
        }

        protected void gvSystemUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == ("btnUserOn"))
            {
                DAL.SystemUserDAL.UpdateUserStateByUserName(gvSystemUser.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString(), 1);
                gvSystemUserBind();
            }
            if (e.CommandName.ToString() == ("btnUserOff"))
            {
                DAL.SystemUserDAL.UpdateUserStateByUserName(gvSystemUser.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString(), 0);
                gvSystemUserBind();
            }
        }

        protected void gvSystemUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.SystemUserDAL.DelSystemUser(gvSystemUser.DataKeys[e.RowIndex].Value.ToString());
            gvSystemUserBind();
        }

        protected void gvSystemUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSystemUser.EditIndex = e.NewEditIndex;
            gvSystemUserBind();
        }

        protected void gvSystemUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string password = ((TextBox)gvSystemUser.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
            if (password == "")
            {
                MsgBox("请填写完整！");
            }
            else
            {
                DAL.SystemUserDAL.UpdateSystemUserByUserName(gvSystemUser.DataKeys[e.RowIndex].Value.ToString(), password);
                gvSystemUser.EditIndex = -1;
            }
            gvSystemUserBind();
        }

        protected void btnChangeAdministratorPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Length <= 25)
            {
                string newPassword = txtNewPassword.Text;
                var charCount = newPassword.ToCharArray().Where(c => c == ' ').Count();
                if (charCount > 0)
                {
                    MsgBox("新密码中不能有空格！");
                }
                else
                {
                    if (DAL.SystemUserDAL.GetCheckSystemUserPassword("SystemAdmin", txtOldPassword.Text.Trim()) > 0)
                    {
                        if (txtNewPassword.Text.Trim() == txtNewPasswordOk.Text.Trim())
                        {
                            if (DAL.SystemUserDAL.UpdateSystemUserByUserName("SystemAdmin", txtNewPasswordOk.Text.Trim()) > 0)
                            {
                                txtOldPassword.Text = "";
                                txtNewPassword.Text = "";
                                txtNewPasswordOk.Text = "";
                                MsgBox("修改成功！");
                            }
                            else
                            {
                                MsgBox("未知原因，密码修改不成功，请联系开发人员！");
                            }
                        }
                        else
                        {
                            txtNewPassword.Text = "";
                            txtNewPasswordOk.Text = "";
                            MsgBox("两次输入的新密码不相同！");
                        }
                    }
                    else
                    {
                        txtOldPassword.Text = "";
                        txtNewPassword.Text = "";
                        txtNewPasswordOk.Text = "";
                        MsgBox("原密码错误！");
                    }
                }
            }
            else
            {
                MsgBox("设置的密码过长！请设置不大于25个字符！");
            }
            gvSystemUserBind();
        }

        protected void btnRemoveStockFacility_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemoveStockFacility.aspx");
        }

        protected void btnRemoveStoreFacility_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemoveStoreFacility.aspx");
        }
    }
}