using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace LuxERP.UI.EventManagement
{
    public partial class eventQuery : System.Web.UI.Page
    {
        public static int pageSize = 30; // 每页行数
        public static int totalPage = 1; // 总页数
        public static int currentPage = 1; // 当前页
        public static EventParameters paras;

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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "2") == "0")
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

                                ddlEventStateShow();
                            }
                            if (IsPostBack)
                            {
                                RegisterJS("addRowStyle");
                                RegisterJS("setDate");
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }
        public void GvEventDataBind(int pageidx)
        {
            string aEventTime =paras.EventTimeA;
            string bEventTime =paras.EventTimeB;
            string storeNo =paras.StoreNo;
            string typeCode =paras.TypeCode;
            string eventState = paras.EventState;
            string eventNo = paras.EventNo;
            //string aEventTime = txtAEventTime.Text + " 00:00:00";
            //string bEventTime = txtBEventTime.Text + " 23:59:59";
            //if (txtAEventTime.Text == "")
            //{
            //    aEventTime = txtAEventTime.Text;
            //}
            //else
            //{
            //    aEventTime = txtAEventTime.Text + " 00:00:00";
            //}
            //if (txtBEventTime.Text == "")
            //{
            //    bEventTime = txtBEventTime.Text;
            //}
            //else
            //{
            //    bEventTime = txtBEventTime.Text + " 23:59:59";
            //}
            DataSet source = DAL.EventLogsDAL.GetEventLogsPaged(aEventTime, bEventTime, txtStoreNo.Text, txtTypeCode.Text, eventState, eventNo, pageSize, pageidx);

            currentPage = pageidx;
            lblCurrent.Text = "第 " + currentPage.ToString() + " 页";
            lblTotalPages.Text = "共 " + totalPage.ToString() + " 页";

            gvEvent.Width = 960;
            gvEvent.DataSource = source;
            gvEvent.DataBind();
            if (gvEvent.HeaderRow != null)
            {
                gvEvent.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
                gvEvent.HeaderRow.Cells[1].Text = "<b>创建时间</b>";
                gvEvent.HeaderRow.Cells[2].Text = "<b>店号</b>";
                gvEvent.HeaderRow.Cells[3].Text = "<b>类型编号</b>";
                gvEvent.HeaderRow.Cells[4].Text = "<b>事件简述</b>";
                if (txtTypeCode.Text.Trim() == "" || txtTypeCode.Text.Trim() != "9999" || txtTypeCode.Text.Trim() != "9000" || txtTypeCode.Text.Trim() != "8888")
                {
                    gvEvent.Columns[6].Visible = false;
                    gvEvent.Columns[5].Visible = true;
                    gvEvent.HeaderRow.Cells[5].Text = "<b>解决人/组织</b>";
                }
                if (txtTypeCode.Text.Trim() == "9999" || txtTypeCode.Text.Trim() == "9000" || txtTypeCode.Text.Trim() == "8888")
                {
                    gvEvent.Columns[6].Visible = true;
                    gvEvent.Columns[5].Visible = false;
                    if (txtTypeCode.Text.Trim() == "9999")
                    {
                        gvEvent.HeaderRow.Cells[6].Text = "<b>开店日期</b>";
                    }
                    if (txtTypeCode.Text.Trim() == "9000")
                    {
                        gvEvent.HeaderRow.Cells[6].Text = "<b>关店日期</b>";
                    }
                    if (txtTypeCode.Text.Trim() == "8888")
                    {
                        gvEvent.HeaderRow.Cells[6].Text = "<b>结束日期</b>";
                    }
                }
                gvEvent.HeaderRow.Cells[7].Text = "<b>状态</b>";
                gvEvent.HeaderRow.Cells[8].Text = "<b>创建人</b>";
                showpage.Visible = true;
            }
            else
            { showpage.Visible = true; }
        }
        //public void GvEventDataBind(string eventState)
        //{
        //    string aEventTime;
        //    string bEventTime;
        //    if (txtAEventTime.Text == "")
        //    {
        //        aEventTime = txtAEventTime.Text;
        //    }
        //    else
        //    {
        //        aEventTime = txtAEventTime.Text + " 00:00:00";
        //    }
        //    if (txtBEventTime.Text == "")
        //    {
        //        bEventTime = txtBEventTime.Text;
        //    }
        //    else
        //    {
        //        bEventTime = txtBEventTime.Text + " 23:59:59";
        //    }

        //    gvEvent.Width = 950;
        //    gvEvent.DataSource = DAL.EventLogsDAL.GetEventLogsInNormalEvent(aEventTime, bEventTime, txtStoreNo.Text, txtTypeCode.Text, eventState);
        //    gvEvent.DataKeyNames = new string[] { "EventNo" };
        //    gvEvent.DataBind();
        //    if (gvEvent.HeaderRow != null)
        //    {
        //        gvEvent.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
        //        gvEvent.HeaderRow.Cells[1].Text = "<b>创建时间</b>";
        //        gvEvent.HeaderRow.Cells[2].Text = "<b>店号</b>";
        //        gvEvent.HeaderRow.Cells[3].Text = "<b>类型编号</b>";
        //        gvEvent.HeaderRow.Cells[4].Text = "<b>事件简述</b>";
        //        if (txtTypeCode.Text.Trim() == "" || txtTypeCode.Text.Trim() != "9999" || txtTypeCode.Text.Trim() != "9000" || txtTypeCode.Text.Trim() != "8888")
        //        {
        //            gvEvent.Columns[6].Visible = false;
        //            gvEvent.Columns[5].Visible = true;
        //            gvEvent.HeaderRow.Cells[5].Text = "<b>解决人/组织</b>";
        //        }
        //        if (txtTypeCode.Text.Trim() == "9999" || txtTypeCode.Text.Trim() == "9000" || txtTypeCode.Text.Trim() == "8888")
        //        {
        //            gvEvent.Columns[6].Visible = true;
        //            gvEvent.Columns[5].Visible = false;
        //            if (txtTypeCode.Text.Trim() == "9999")
        //            {
        //                gvEvent.HeaderRow.Cells[6].Text = "<b>开店日期</b>";
        //            }
        //            if (txtTypeCode.Text.Trim() == "9000")
        //            {
        //                gvEvent.HeaderRow.Cells[6].Text = "<b>关店日期</b>";
        //            }
        //            if (txtTypeCode.Text.Trim() == "8888")
        //            {
        //                gvEvent.HeaderRow.Cells[6].Text = "<b>结束日期</b>";
        //            }                  
        //        }
        //        gvEvent.HeaderRow.Cells[7].Text = "<b>状态</b>";
        //        gvEvent.HeaderRow.Cells[8].Text = "<b>创建人</b>";
        //    }
        //}

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public void ddlEventStateShow()
        {
            ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(99, "0");
            ddlEventState.DataValueField = "StateID";
            ddlEventState.DataTextField = "StateName";
            ddlEventState.DataBind();
            ddlEventState.Items.Add("");
            ddlEventState.SelectedValue = "";
        }

        protected void btnNormalEventQuery_Click(object sender, EventArgs e)
        {
            paras = new EventParameters();
            paras.EventNo = txtEventNo.Text.Trim();
            paras.TypeCode = txtTypeCode.Text.Trim();
            if (txtAEventTime.Text.Trim() == "")
            { paras.EventTimeA = txtAEventTime.Text.Trim(); }
            else
            { paras.EventTimeA = txtAEventTime.Text.Trim() + " 00:00:00"; }
            if (txtBEventTime.Text.Trim() == "")
            { paras.EventTimeB = txtAEventTime.Text.Trim(); }
            else
            { paras.EventTimeB = txtBEventTime.Text.Trim() + " 23:59:59"; }
            paras.StoreNo = txtStoreNo.Text.Trim();
            paras.EventState = ddlEventState.SelectedValue;

            DataSet ds = DAL.EventLogsDAL.GetEventLogsTotal(paras.EventTimeA, paras.EventTimeB, paras.StoreNo, paras.TypeCode, paras.EventState, paras.EventNo);
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > pageSize)
            {
                totalPage = (int)Math.Ceiling((double)rowsCount / (double)pageSize);
            }
            else
            {
                totalPage = 1;
            }
            GvEventDataBind(1);
        }

        protected void txtTypeCode_TextChanged(object sender, EventArgs e)
        {
            if (txtTypeCode.Text.Trim() == "9999" || txtTypeCode.Text.Trim() == "9000" || txtTypeCode.Text.Trim() == "8888")
            {
                if (txtTypeCode.Text.Trim() == "9999")
                {
                    ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(199, "1");
                    ddlEventState.DataValueField = "StateID";
                    ddlEventState.DataTextField = "StateName";
                    ddlEventState.DataBind();
                    ddlEventState.Items.Add("");
                    ddlEventState.SelectedValue = "";
                }
                if (txtTypeCode.Text.Trim() == "9000")
                {
                    ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(299, "2");
                    ddlEventState.DataValueField = "StateID";
                    ddlEventState.DataTextField = "StateName";
                    ddlEventState.DataBind();
                    ddlEventState.Items.Add("");
                    ddlEventState.SelectedValue = "";
                }
                if (txtTypeCode.Text.Trim() == "8888")
                {
                    ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(399, "3");
                    ddlEventState.DataValueField = "StateID";
                    ddlEventState.DataTextField = "StateName";
                    ddlEventState.DataBind();
                    ddlEventState.Items.Add("");
                    ddlEventState.SelectedValue = "";
                }
            }
            else
            {
                ddlEventStateShow();
            }
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            GvEventDataBind(1);
        }

        protected void btnPrvPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                GvEventDataBind(currentPage - 1);
            }
        }

        protected void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                GvEventDataBind(currentPage + 1);
            }
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            GvEventDataBind(totalPage);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(txtCurPage.Text);
            if (n >= 1 && n <= totalPage)
            {
                GvEventDataBind(n);
            }
        }
    }

    public class EventParameters
    {
        public string EventNo { get; set; }
        public string TypeCode { get; set; }
        public string EventTimeA { get; set; }
        public string EventTimeB { get; set; }
        public string StoreNo { get; set; }
        public string EventState { get; set; }
    }


}
