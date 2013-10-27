using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// add references
using LuxERP.DAL;

namespace LuxERP.UI.SolutionManagement
{
    public partial class UpdateSolution : System.Web.UI.Page
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "1") == "0")
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

                                this.result.Visible = false;
                                lblResult.Visible = false;
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            lblResult.Visible = false;

            // 查询解决方案
            string typeCode = txtTypeNo.Text;
            if (typeCode.Length >= 10)
            {
                typeCode = typeCode.Substring(0, 10);
            }

            lblTitle.Text = "解决方案： " + typeCode;
            string content = SolutionsDAL.GetSolutionByID(typeCode);
            content = content.Replace("\n", "");            
            this.result.Visible = true;
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "setContent", "setEditor('" + content + "');", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string typeCode = lblTitle.Text.Substring(6);            
            
            string content = Convert.ToString(Request.Form["ctl00$myContent$hid"]);            

            // 后期加入 操作写入log
            if (SolutionsDAL.UpdateSolution(typeCode, content) != 0)
            {
                lblResult.Text = "修改成功！";
                lblResult.CssClass = "ok";
            }
            else
            {
                lblResult.Text = "修改失败！";
                lblResult.CssClass = "fail";
            }
            this.result.Visible = false;            
            lblResult.Visible = true;
        }        
    }
}