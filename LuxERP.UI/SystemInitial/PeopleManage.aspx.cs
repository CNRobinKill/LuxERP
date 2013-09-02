using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class PeopleManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddPeople.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddPeople, "click") + ";this.disabled=true; this.value='处理中...';");
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "13") == "0")
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

                                gvPeopleBind();
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

        public void gvPeopleBind()
        {
            gvPeople.Width = 750;
            gvPeople.DataSource = DAL.PeopleDAL.GetPeople();
            gvPeople.DataKeyNames = new string[] { "Name" };
            gvPeople.DataBind();
            if (gvPeople.HeaderRow != null)
            {
                gvPeople.HeaderRow.Cells[0].Text = "<b>姓名</b>";
                gvPeople.HeaderRow.Cells[1].Text = "<b>职位</b>";
                gvPeople.HeaderRow.Cells[2].Text = "<b>性别</b>";
                gvPeople.HeaderRow.Cells[3].Text = "<b>联系电话</b>";
                gvPeople.HeaderRow.Cells[4].Text = "<b>联系邮箱</b>";
            }
        }

        protected void btnAddPeople_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "" && txtPhone.Text.Trim() != "" && txtEmail.Text.Trim() !="")
            {
                DAL.PeopleDAL.AddPeople(ddlPosition.SelectedValue, txtName.Text.Trim(), ddlSex.SelectedValue, txtPhone.Text.Trim(), txtEmail.Text.Trim());
                gvPeopleBind();
            }
        }

        protected void gvPeople_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.PeopleDAL.DelPeople(gvPeople.DataKeys[e.RowIndex].Value.ToString());
            gvPeopleBind();
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }
    }
}