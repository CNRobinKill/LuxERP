using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LuxERP.UI
{
    public partial class LuxERP : System.Web.UI.MasterPage
    {   
        public static string userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["userName"] == null)
                {  }
                else
                {
                    if (DAL.SystemUserDAL.GetUserIP(Session["userName"].ToString(), DAL.IPNetworking.GetIP4Address()) == "")
                    { }
                    else
                    {
                        try
                        {
                            if (!IsPostBack)
                            {
                                //try
                                //{
                                userName = Session["userName"].ToString();
                                CheckUserName();
                                lblUser.Text = userName;
                                CheckPermission();
                                MasterLoadPermission();
                                //}
                                //catch
                                //{
                                //    Response.Write("<script LANGUAGE=JavaScript >" +
                                //            " alert('未登录用户！');" +
                                //            " window.location=('/LogOn.aspx');" +
                                //            "</script>");
                                //}

                            }
                            if (IsPostBack)
                            {
                                try
                                {
                                    userName = Session["userName"].ToString();
                                    CheckUserName();
                                }
                                catch
                                {
                                    Response.Write("<script LANGUAGE=JavaScript >" +
                                            " alert('用户异常，请尝试重新登录！');" +
                                            " window.location=('/LogOn.aspx');" +
                                            "</script>");
                                    Response.End();
                                }
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        public string PermissionArray(int n)
        {
            SqlDataReader dr = DAL.PermissionDAL.GetPermission(userName);            
            if (dr.Read())
            {
                string permission = dr[n].ToString();
                dr.Close();
                return permission;
            }
            dr.Close();
            return null;
            
        }

        public void MasterLoadPermission()
        {
            if (PermissionArray(1) == "0")
            { index.Visible = false; }
            if (PermissionArray(2) == "0")
            { 
                updateSolution.Visible = false;
                solution.Visible = false;
            }
            if (PermissionArray(3) == "0" && PermissionArray(4) == "0" && PermissionArray(5) == "0" && PermissionArray(21) == "0")
            {
                eventManage.Visible = false;
            }

            if (PermissionArray(3) == "0")
            { eventQuery.Visible = false; }
            if (PermissionArray(4) == "0")
            { createEvent.Visible = false; }
            if (PermissionArray(5) == "0")
            { reportFormsEvent.Visible = false; }
            if (PermissionArray(21) == "0")
            { sceneToken.Visible = false; }

            if (PermissionArray(6) == "0" && PermissionArray(7) == "0" && PermissionArray(8) == "0" && PermissionArray(9) == "0" && PermissionArray(10) == "0" && PermissionArray(19) == "0")
            {
                stockManage.Visible = false;
            }

            if (PermissionArray(6) == "0")
            { addStock.Visible = false; }
            if (PermissionArray(7) == "0")
            { stockQuery.Visible = false; }
            if (PermissionArray(8) == "0")
            { outStockQuery.Visible = false; }
            if (PermissionArray(9) == "0")
            { allotStockQuery.Visible = false; }
            if (PermissionArray(10) == "0")
            { addStockQuery.Visible = false; }
            if (PermissionArray(20) == "0")
            { scrapStocks.Visible = false; }

            if (PermissionArray(11) == "0")
            { 
                alterStore.Visible = false;
                storeInformation.Visible = false;
            }
            if (PermissionArray(12) == "0" && PermissionArray(13) == "0" && PermissionArray(14) == "0" && PermissionArray(15) == "0" && PermissionArray(16) == "0" && PermissionArray(17) == "0" && PermissionArray(18) == "0" && PermissionArray(22) == "0" && PermissionArray(23) == "0" && PermissionArray(24) == "0")
            {
                systemInitial.Visible = false;
            }

            if (PermissionArray(12) == "0")
            { eventTypes.Visible = false; }
            if (PermissionArray(13) == "0")
            { facilityManage.Visible = false; }
            if (PermissionArray(14) == "0")
            { peopleManage.Visible = false; }
            if (PermissionArray(15) == "0")
            { synthesisManage.Visible = false; }
            if (PermissionArray(16) == "0")
            { eventState.Visible = false; }
            if (PermissionArray(17) == "0")
            { initialStores.Visible = false; }
            if (PermissionArray(18) == "0")
            { initialStocks.Visible = false; }            
            if (PermissionArray(22) == "0")
            { sceneInformation.Visible = false; }
            if (PermissionArray(23) == "0")
            { sceneServiceProvider.Visible = false; }
            if (PermissionArray(24) == "0")
            { areaInformation.Visible = false; }

            if (PermissionArray(19) == "0")
            { admin.Visible = false; }
        }

        public void CheckPermission()
        {
            if (
                PermissionArray(1) == "0"
                &&PermissionArray(2) == "0"
                && PermissionArray(3) == "0"
                && PermissionArray(4) == "0"
                && PermissionArray(5) == "0"
                && PermissionArray(6) == "0"
                && PermissionArray(7) == "0"
                && PermissionArray(8) == "0"
                && PermissionArray(9) == "0"
                && PermissionArray(10) == "0"
                && PermissionArray(11) == "0"
                && PermissionArray(12) == "0"
                && PermissionArray(13) == "0"
                && PermissionArray(14) == "0"
                && PermissionArray(15) == "0"
                && PermissionArray(16) == "0"
                && PermissionArray(17) == "0"
                && PermissionArray(18) == "0"
                && PermissionArray(19) == "0"
                && PermissionArray(20) == "0"
                && PermissionArray(21) == "0"
                && PermissionArray(22) == "0"
                && PermissionArray(23) == "0"
                && PermissionArray(24) == "0"
                )
            {
                Response.Write("<script LANGUAGE=JavaScript >" +
                            " alert('该用户没有未开通任何权限，请联系管理员！');" +
                            " window.location=('/LogOn.aspx');" +
                            "</script>");
                Response.End();
            }
        }

        public void CheckUserName()
        {
            if (userName == "" || userName == null)
            {
                //Response.Write("<script LANGUAGE=JavaScript >" +
                //            " alert('用户未登录！');" +
                //            " window.location=('/LogOn.aspx');" +
                //            "</script>");
                Response.Redirect("/LogOn.aspx",true);
            }
        }

        protected void lbtnLogOff_Click(object sender, EventArgs e)
        {
            //Response.Cookies.Remove(Response.Cookies["userName"].Value);
            //HttpCookie cookie = Request.Cookies["userName"];
            //if (cookie != null)
            //{
            //    cookie.Expires = DateTime.Now.AddDays(-1);
            //    cookie.Values.Clear();
            //    System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
            Session.Remove("userName");
            Response.Write("<script LANGUAGE=JavaScript >" +
                        " alert('注销成功！');" +
                        " window.location=('/LogOn.aspx');" +
                        "</script>");
            //Response.End();
            //}           
        }
            
    }
}