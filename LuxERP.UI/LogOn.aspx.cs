using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI
{
    public partial class LogOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnLogIn.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnLogIn, "click") + ";this.disabled=true; this.value='登录中...';");
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    if (DAL.SystemUserDAL.GetUserIP(Session["userName"].ToString(), DAL.IPNetworking.GetIP4Address()) == "")
                    {  }
                    else
                    {
                        Response.Redirect("/Index/Index.aspx");
                    }
                }
                lblTechnicalSupport.Text = "Copyright & Technical Support：<a href='http://www.iwooo.com'>IWOOO</a>";
            }
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text.Length <= 30 && txtUserName.Text.Length <= 30)
            {
                if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                {
                    MsgBox("账号密码都不输就想登录？开什么玩笑！");
                }
                else
                {
                    if (DAL.SystemUserDAL.GetCheckSystemUserPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim()) > 0)
                    {
                        DAL.SystemUserDAL.UpdateLogOnByUserName(txtUserName.Text.Trim(), DAL.IPNetworking.GetIP4Address());
                        Session["userName"] = txtUserName.Text.Trim();
                        Session.Timeout = 1400;
                        //Response.Cookies["userName"].Value = txtUserName.Text.Trim();
                        //Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
                        ////產生一個Cookie
                        //HttpCookie cookie = new HttpCookie("userName");
                        ////設定單值
                        //cookie.Value = Server.UrlEncode(txtUserName.Text.Trim());
                        ////設定過期日
                        //cookie.Expires = DateTime.Now.AddDays(1);
                        ////寫到用戶端
                        //Response.Cookies.Add(cookie);
                        Response.Redirect("/Index/Index.aspx");
                    }
                    else
                    {
                        MsgBox("用户名或密码错误或为禁用用户，请联系管理员！");
                    }
                }
            }
            else
            {
                MsgBox("不存在过长的用户名或密码！");
            }
        }
    }

}