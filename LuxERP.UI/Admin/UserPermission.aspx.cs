using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LuxERP.UI.Admin
{
    public partial class UserPermission : System.Web.UI.Page
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
                        try
                        {
                            if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "18") == "0")
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

                                LoadPermission();
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

        public string PermissionArray(int n)
        {
            SqlDataReader dr = DAL.PermissionDAL.GetPermission(Request.QueryString["userName"]);
            if (dr.Read())
            {
                string permission = dr[n].ToString();
                dr.Close();
                return permission;
            }
            dr.Close();
            return null;
        }

        public void LoadPermission()
        {
            if (PermissionArray(1) == "1")
            { chkIndex.Checked = true; }
            if (PermissionArray(2) == "1")
            { chkUpdateSolution.Checked = true; }
            if (PermissionArray(3) == "1")
            { chkEventQuery.Checked = true; }
            if (PermissionArray(4) == "1")
            { chkCreateEvent.Checked = true; }
            if (PermissionArray(5) == "1")
            { chkReportFormsEvent.Checked = true; }
            if (PermissionArray(6) == "1")
            { chkAddStock.Checked = true; }
            if (PermissionArray(7) == "1")
            { chkStockQuery.Checked = true; }
            if (PermissionArray(8) == "1")
            { chkOutStockQuery.Checked = true; }
            if (PermissionArray(9) == "1")
            { chkAllotStockQuery.Checked = true; }
            if (PermissionArray(10) == "1")
            { chkAddStockQuery.Checked = true; }
            if (PermissionArray(11) == "1")
            { chkAlterStore.Checked = true; }
            if (PermissionArray(12) == "1")
            { chkEventTypes.Checked = true; }
            if (PermissionArray(13) == "1")
            { chkFacilityManage.Checked = true; }
            if (PermissionArray(14) == "1")
            { chkPeopleManage.Checked = true; }
            if (PermissionArray(15) == "1")
            { chkSynthesisManage.Checked = true; }
            if (PermissionArray(16) == "1")
            { chkEventState.Checked = true; }
            if (PermissionArray(17) == "1")
            { chkInitialStores.Checked = true; }
            if (PermissionArray(18) == "1")
            { chkInitialStocks.Checked = true; }
            if (PermissionArray(20) == "1")
            { chkScrapStocks.Checked = true; }
            if (PermissionArray(21) == "1")
            { chkSceneToken.Checked = true; }
            if (PermissionArray(22) == "1")
            { chkSceneInformation.Checked = true; }
            if (PermissionArray(23) == "1")
            { chkSceneServiceProvider.Checked = true; }
            if (PermissionArray(24) == "1")
            { chkAreaInformation.Checked = true; }
        }

        protected void btnPermission_Click(object sender, EventArgs e)
        {
            string userName = Request.QueryString["userName"];
            int index;
	        int updateSolution;
	        int eventQuery;
	        int createEvent;
	        int reportFormsEvent;
	        int addStock;
	        int stockQuery;
	        int outStockQuery;
	        int allotStockQuery;
	        int addStockQuery;
	        int alterStore;
	        int eventTypes;
	        int facilityManage;
	        int peopleManage;
	        int synthesisManage;
	        int eventState;
	        int initialStores;
	        int initialStocks;
            int scrapStocks;
            int sceneToken;
            int sceneInformation;
            int sceneServiceProvider;
            int areaInformation;

            if (chkIndex.Checked == true)
            { index = 1; }
            else
            { index = 0; }
            if (chkUpdateSolution.Checked == true)
            { updateSolution = 1; }
            else
            { updateSolution = 0; }
            if (chkEventQuery.Checked == true)
            { eventQuery = 1; }
            else
            { eventQuery = 0; }
            if (chkCreateEvent.Checked == true)
            { createEvent = 1; }
            else
            { createEvent = 0; }
            if (chkReportFormsEvent.Checked == true)
            { reportFormsEvent = 1; }
            else
            { reportFormsEvent = 0; }
            if (chkAddStock.Checked == true)
            { addStock = 1; }
            else
            { addStock = 0; }
            if (chkStockQuery.Checked == true)
            { stockQuery = 1; }
            else
            { stockQuery = 0; }
            if (chkOutStockQuery.Checked == true)
            { outStockQuery = 1; }
            else
            { outStockQuery = 0; }
            if (chkAllotStockQuery.Checked == true)
            { allotStockQuery = 1; }
            else
            { allotStockQuery = 0; }
            if (chkAddStockQuery.Checked == true)
            { addStockQuery = 1; }
            else
            { addStockQuery = 0; }
            if (chkAlterStore.Checked == true)
            { alterStore = 1; }
            else
            { alterStore = 0; }
            if (chkEventTypes.Checked == true)
            { eventTypes = 1; }
            else
            { eventTypes = 0; }
            if (chkFacilityManage.Checked == true)
            { facilityManage = 1; }
            else
            { facilityManage = 0; }
            if (chkPeopleManage.Checked == true)
            { peopleManage = 1; }
            else
            { peopleManage = 0; }
            if (chkSynthesisManage.Checked == true)
            { synthesisManage = 1; }
            else
            { synthesisManage = 0; }
            if (chkEventState.Checked == true)
            { eventState = 1; }
            else
            { eventState = 0; }
            if (chkInitialStores.Checked == true)
            { initialStores = 1; }
            else
            { initialStores = 0; }
            if (chkInitialStocks.Checked == true)
            { initialStocks = 1; }
            else
            { initialStocks = 0; }
            if (chkScrapStocks.Checked == true)
            { scrapStocks = 1; }
            else
            { scrapStocks = 0; }
            if (chkSceneToken.Checked == true)
            { sceneToken = 1; }
            else
            { sceneToken = 0; }
            if (chkSceneInformation.Checked == true)
            { sceneInformation = 1; }
            else
            { sceneInformation = 0; }
            if (chkSceneServiceProvider.Checked == true)
            { sceneServiceProvider = 1; }
            else
            { sceneServiceProvider = 0; }
            if (chkAreaInformation.Checked == true)
            { areaInformation = 1; }
            else
            { areaInformation = 0; }

            if (DAL.PermissionDAL.UpdatePermissionByUserName(
                                                userName,
                                                index,
                                                updateSolution,
                                                eventQuery,
                                                createEvent,
                                                reportFormsEvent,
                                                addStock,
                                                stockQuery,
                                                outStockQuery,
                                                allotStockQuery,
                                                addStockQuery,
                                                alterStore,
                                                eventTypes,
                                                facilityManage,
                                                peopleManage,
                                                synthesisManage,
                                                eventState,
                                                initialStores,
                                                initialStocks,
                                                scrapStocks,
                                                sceneToken,
                                                sceneInformation,
                                                sceneServiceProvider,
                                                areaInformation) > 0)
            {
                MsgBox("更新成功");
            }
        }

        protected void btnReturnUserManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserManage.aspx");
        }

    }
}