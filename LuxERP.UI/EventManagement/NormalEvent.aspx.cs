using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace LuxERP.UI.EventManagement
{
    public partial class NormalEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddEventSteps.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddEventSteps, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnFacilityAllotByEvent.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnFacilityAllotByEvent, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnFacilityMatchingAndOutByEvent.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnFacilityMatchingAndOutByEvent, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnOKSend.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnOKSend, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnOKUpdate.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnOKUpdate, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnOKUpdateToResolvedTime.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnOKUpdateToResolvedTime, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnOKUpdateType.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnOKUpdateType, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnOpener.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnOpener, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnReOpenEvent.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnReOpenEvent, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnReturnEventQuery.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnReturnEventQuery, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnSendEventTo.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnSendEventTo, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnStopEventLog.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnStopEventLog, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnUpdateEventState.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnUpdateEventState, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnUpdateEventType.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnUpdateEventType, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnUpdateToResolvedTime.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnUpdateToResolvedTime, "click") + ";this.disabled=true; this.value='处理中...';");
           
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

                                if (Request.QueryString["typeCode"] != "9999" && Request.QueryString["typeCode"] != "9000" && Request.QueryString["typeCode"] != "8888")
                                {
                                    ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(int.Parse(EventInformationArray(6)), "0");
                                    ddlEventState.DataValueField = "StateID";
                                    ddlEventState.DataTextField = "StateName";
                                    ddlEventState.DataBind();
                                    if (ddlEventState.SelectedValue == "0")
                                    {
                                        txtStepDescribe.Visible = false;
                                        btnAddEventSteps.Visible = false;
                                        btnUpdateEventState.Visible = false;
                                        btnReOpenEvent.Visible = true;
                                        divThreeBtn.Visible = false;
                                        btnUpdateEventType.Visible = false;
                                        btnSendEventTo.Visible = false;
                                        btnStopEventLog.Visible = false;
                                    }
                                    btnUpdateToResolvedTime.Visible = false;
                                }
                                else
                                {
                                    if (Request.QueryString["typeCode"] == "9999")
                                    {
                                        btnUpdateEventType.Visible = false;
                                        btnSendEventTo.Visible = false;
                                        btnReOpenEvent.Visible = false;
                                        lblSetUpDate.Visible = true;
                                        lblToResolvedTime.Visible = true;
                                        ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(int.Parse(EventInformationArray(6)), "1");
                                        ddlEventState.DataValueField = "StateID";
                                        ddlEventState.DataTextField = "StateName";
                                        ddlEventState.DataBind();
                                        if (ddlEventState.SelectedValue == "100")
                                        {
                                            txtStepDescribe.Visible = false;
                                            btnAddEventSteps.Visible = false;
                                            btnUpdateEventState.Visible = false;
                                            btnReOpenEvent.Visible = false;
                                            divThreeBtn.Visible = false;
                                            btnUpdateEventType.Visible = false;
                                            btnSendEventTo.Visible = false;
                                            btnStopEventLog.Visible = false;
                                            btnUpdateToResolvedTime.Visible = false;
                                        }
                                    }
                                    if (Request.QueryString["typeCode"] == "9000")
                                    {
                                        btnUpdateEventType.Visible = false;
                                        btnSendEventTo.Visible = false;
                                        btnReOpenEvent.Visible = false;
                                        btnFacilityMatchingAndOutByEvent.Visible = false;
                                        btnSceneByEnent.Visible = false;
                                        lblShutUpDate.Visible = true;
                                        lblToResolvedTime.Visible = true;
                                        ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(int.Parse(EventInformationArray(6)), "2");
                                        ddlEventState.DataValueField = "StateID";
                                        ddlEventState.DataTextField = "StateName";
                                        ddlEventState.DataBind();
                                        if (ddlEventState.SelectedValue == "200")
                                        {
                                            txtStepDescribe.Visible = false;
                                            btnAddEventSteps.Visible = false;
                                            btnUpdateEventState.Visible = false;
                                            btnReOpenEvent.Visible = false;
                                            divThreeBtn.Visible = false;
                                            btnUpdateEventType.Visible = false;
                                            btnSendEventTo.Visible = false;
                                            btnStopEventLog.Visible = false;
                                            btnUpdateToResolvedTime.Visible = false;
                                        }
                                    }
                                    if (Request.QueryString["typeCode"] == "8888")
                                    {
                                        btnUpdateEventType.Visible = false;
                                        btnSendEventTo.Visible = false;
                                        btnReOpenEvent.Visible = false;
                                        btnFacilityAllotByEvent.Visible = false;
                                        btnFacilityMatchingAndOutByEvent.Visible = false;
                                        lblEndDate.Visible = true;
                                        lblToResolvedTime.Visible = true;
                                        ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(int.Parse(EventInformationArray(6)), "3");
                                        ddlEventState.DataValueField = "StateID";
                                        ddlEventState.DataTextField = "StateName";
                                        ddlEventState.DataBind();
                                        if (ddlEventState.SelectedValue == "300")
                                        {
                                            txtStepDescribe.Visible = false;
                                            btnAddEventSteps.Visible = false;
                                            btnUpdateEventState.Visible = false;
                                            btnReOpenEvent.Visible = false;
                                            divThreeBtn.Visible = false;
                                            btnUpdateEventType.Visible = false;
                                            btnSendEventTo.Visible = false;
                                            btnStopEventLog.Visible = false;
                                            btnUpdateToResolvedTime.Visible = false;
                                        }

                                    }
                                }
                                LoadEventInformation();
                                LoadStoreInformation();
                                gvEventStepsDataBind();

                                ddlSendEventTo.Visible = true;
                                for (int i = 0; i < DAL.SynthesisDAL.GetSolver().Tables[0].Rows.Count; i++)
                                {
                                    ddlSendEventTo.Items.Add(DAL.SynthesisDAL.GetSolver().Tables[0].Rows[i][0].ToString());
                                }
                                ddlSendEventTo.Visible = false;
                                ddlResolvedBy.Visible = true;
                                for (int i = 0; i < DAL.SynthesisDAL.GetSolver().Tables[0].Rows.Count; i++)
                                {
                                    ddlResolvedBy.Items.Add(DAL.SynthesisDAL.GetSolver().Tables[0].Rows[i][0].ToString());
                                }
                                ddlResolvedBy.Visible = false;

                            }
                            if (IsPostBack)
                            {
                                RegisterJS("addRowStyle");
                                RegisterJS("setTop");
                                RegisterJS("showDialog");
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
        public string EventInformationArray(int n)
        {
            SqlDataReader dr = DAL.EventLogsDAL.GetEventLogsByEventNo(Request.QueryString["eventNo"]);
            dr.Read();
            string eventLogs = dr[n].ToString();
            dr.Close();
            return eventLogs;
        }
        public string StoreInformationArray(int n)
        {
            try
            {
                SqlDataReader dr = DAL.StoresDAL.GetStoresByStoreNo(EventInformationArray(2));
                dr.Read();
                string stores = dr[n].ToString();
                dr.Close();
                return stores;
            }
            catch
            {
                return "门店已不存在";
            }
        }

        public static bool readerExists(SqlDataReader dr, string columnName)
        {

            dr.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" +

            columnName + "'";

            return (dr.GetSchemaTable().DefaultView.Count > 0);

        }

        public string SendEmailInfo(int n, string handingBy, string typeCode)
        {
            SqlDataReader dr = DAL.SynthesisDAL.GetSolverChangeHandingBy(handingBy,typeCode);
            dr.Read();
            string emailInfo = dr[n].ToString();
            dr.Close();
            return emailInfo;
        }

        public string EventTypes(string typeCode)
        {
            SqlDataReader dr = DAL.EventTypesDAL.GetEventTypesByTypeCode(typeCode);
            dr.Read();
            try
            {
                string stores = "";
                if (readerExists(dr, "TypeOne"))
                {
                    stores = dr[0].ToString();
                }
                if (readerExists(dr, "TypeTwo"))
                {
                    stores = stores + "/" + dr[1].ToString();
                }
                if (readerExists(dr, "TypeThree"))
                {
                    stores = stores + "/" + dr[2].ToString();
                }
                if (readerExists(dr, "TypeFour"))
                {
                    stores = stores + "/" + dr[3].ToString();
                }
                dr.Close();
                return stores;
            }
            catch
            {
                dr.Close();
                return "没有该类型";
            }           

        }

        public string timeNow()
        {
           return  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void LoadEventInformation()
        {
            lblEventNo.Text = EventInformationArray(0);
            lblEventTime.Text = EventInformationArray(1);
            if (Request.QueryString["typeCode"] != "9999" && Request.QueryString["typeCode"] != "9000" && Request.QueryString["typeCode"] != "8888" && Request.QueryString["typeCode"] != "0000")
            {
                lblType.Text = Request.QueryString["typeCode"] + " " + EventTypes(Request.QueryString["typeCode"]);
            }
            else
            {
                if (Request.QueryString["typeCode"] == "9999")
                {
                    lblType.Text = Request.QueryString["typeCode"] + " 开店";
                }
                if (Request.QueryString["typeCode"] == "9000")
                {
                    lblType.Text = Request.QueryString["typeCode"] + " 关店";
                }
                if (Request.QueryString["typeCode"] == "8888")
                {
                    lblType.Text = Request.QueryString["typeCode"] + " 店铺装修";
                }
                if (Request.QueryString["typeCode"] == "0000")
                {
                    lblType.Text = Request.QueryString["typeCode"] + " 未分配";
                }
                lblToResolvedTime.Text = EventInformationArray(5);
            }            
            lblEventDescribe.Text = EventInformationArray(4);
            if (EventInformationArray(6) != "")
            {
                ddlEventState.SelectedValue = EventInformationArray(6);
            }
            lblLogBy.Text = EventInformationArray(7);
            if (EventInformationArray(8) != "")
            {
                lblResolvedByText.Visible = true;
                lblResolvedBy.Visible = true;
                lblResolvedBy.Text = EventInformationArray(8);
            }
            else
            {
                lblResolvedByText.Visible = false;
                lblResolvedBy.Visible = false;
            }
            if (EventInformationArray(9) != "")
            {

                lblResolvedTimeText.Visible = true;
                lblResolvedTime.Visible = true;
                lblResolvedTime.Text = EventInformationArray(9);
            }
            else
            {
                lblResolvedTimeText.Visible = false;
                lblResolvedTime.Visible = false;
            }
        }

        public void LoadStoreInformation()
        {
            lblStoreNo.Text = StoreInformationArray(0);
            lblTopStore.Text = StoreInformationArray(1);
            lblStoreType.Text = StoreInformationArray(2);
            lblRegion.Text = StoreInformationArray(3);
            lblRating.Text = StoreInformationArray(4);
            lblStoreAddress.Text = StoreInformationArray(7);
            lblStoreTel.Text = StoreInformationArray(8);
            lblStoreState.Text = StoreInformationArray(11);
            
        }

        public void gvEventStepsDataBind()
        {
            gvEventSteps.Width = 850;

            gvEventSteps.HeaderStyle.Font.Size = 11;
            gvEventSteps.DataSource = DAL.EventStepsDAL.GetEventStepsByEventNo(Request.QueryString["eventNo"]);
            gvEventSteps.DataKeyNames = new string[] { "ID" };
            gvEventSteps.DataBind();
            if (gvEventSteps.HeaderRow != null)
            {
                gvEventSteps.HeaderRow.Cells[0].Text = "<b>时间</b>";
                gvEventSteps.HeaderRow.Cells[1].Text = "<b>执行步骤</b>";
                gvEventSteps.HeaderRow.Cells[2].Text = "<b>记录人</b>";
                gvEventSteps.HeaderRow.Cells[3].Text = "<b>状态</b>";
            }
        }

        protected void btnAddEventSteps_Click(object sender, EventArgs e)
        {
            if (txtStepDescribe.Text.Trim() == "")
            {
                MsgBox("步骤内容不能为空！");
                //System.Threading.Thread.Sleep(1);
                //gvEventStepsDataBind();
            }
            else
            {
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], txtStepDescribe.Text, timeNow(), "0", Session["userName"].ToString());
                gvEventStepsDataBind();
                txtStepDescribe.Text = "";
            }
            gvEventStepsDataBind();
        }

        public void MsgBox(string showMsg)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + showMsg + "');", true);  
        }
        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //OverRide　为了使导出成Excel可行！
        }

        private string GridViewToHtml(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            return sb.ToString();
        } 

        protected void gvEventSteps_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEventSteps.EditIndex = e.NewEditIndex;
            gvEventStepsDataBind();
        }

        protected void gvEventSteps_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (((TextBox)(gvEventSteps.Rows[e.RowIndex].Cells[1].Controls[0])).Text == "")
            {
                MsgBox("步骤内容不能为空！");
                System.Threading.Thread.Sleep(1);
                //gvEventStepsDataBind();
            }
            else
            {
            DAL.EventStepsDAL.UpdateEventSteps(int.Parse(gvEventSteps.DataKeys[e.RowIndex].Value.ToString()),((TextBox)(
                gvEventSteps.Rows[e.RowIndex].Cells[1].Controls[0])).Text,
                ((DropDownList)gvEventSteps.Rows[e.RowIndex].Cells[3].FindControl("ddlStepState")).SelectedValue);
            gvEventSteps.EditIndex = -1; 
            }
            gvEventStepsDataBind();
        }

        protected void gvEventSteps_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEventSteps.EditIndex = -1;
            gvEventStepsDataBind();
        }

        protected void gvEventSteps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (((string)(e.Row.Cells[1].Text)).StartsWith("(创建事件)") || e.Row.Cells[1].Text == "事件已结束" || e.Row.Cells[1].Text == "事件打开延伸" || ((string)(e.Row.Cells[1].Text)).StartsWith("(更改信息)") || ((string)(e.Row.Cells[1].Text)).StartsWith("(移交事件)") || ((string)(e.Row.Cells[1].Text)).StartsWith("(特殊情况)"))
            {
                e.Row.Cells[4].Text = "";
            }
            if (((string)(e.Row.Cells[1].Text)).StartsWith("(特殊情况)"))
            {
                btnReOpenEvent.Visible = false;
                btnStopEventLog.Visible = false;
            }
            if (((string)(e.Row.Cells[1].Text)).StartsWith("(匹配出库)"))
            {
                e.Row.Cells[4].Width = 80;
                e.Row.Cells[1].CssClass = "outstocks";
                e.Row.Cells[4].Text = "<a href='FacilityMatchingAndOutByEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + StoreInformationArray(0) + "&typeCode=" + Request.QueryString["typeCode"] + "'>详细信息</a>";
                btnFacilityMatchingAndOutByEvent.Visible = false;
            }
            if (((string)(e.Row.Cells[1].Text)).StartsWith("(返库调拨)"))
            {
                e.Row.Cells[4].Width = 80;
                e.Row.Cells[1].CssClass = "allotstocks";
                e.Row.Cells[4].Text = "<a href='FacilityAllotByEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + StoreInformationArray(0) + "&typeCode=" + Request.QueryString["typeCode"] + "'>详细信息</a>";
                btnFacilityAllotByEvent.Visible = false;
            }
            if (((string)(e.Row.Cells[1].Text)).StartsWith("(上门服务)"))
            {
                e.Row.Cells[4].Width = 80;
                e.Row.Cells[1].CssClass = "scenebyenent";
                e.Row.Cells[4].Text = "<a href='SceneByEnent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + StoreInformationArray(0) + "&typeCode=" + Request.QueryString["typeCode"] + "'>详细信息</a>";
                btnSceneByEnent.Visible = false;
            }
            if (((DropDownList)e.Row.FindControl("ddlStepState")) != null)
            {
                DropDownList ddlStepState = (DropDownList)e.Row.FindControl("ddlStepState");
                //  生成 DropDownList 的值，也可以取得数据库中的数据绑定
                if (((HiddenField)e.Row.FindControl("hdStepState")).Value == "已处理")
                {
                    ddlStepState.Items.Add(new ListItem("已处理", "0")); ;
                }
                else
                {
                    ddlStepState.Items.Add(new ListItem("未处理", "99"));
                    ddlStepState.Items.Add(new ListItem("已处理", "0"));
                }
                //
                //  选中 DropDownList
                ddlStepState.SelectedValue = ((HiddenField)e.Row.FindControl("hdStepState")).Value;
                //
            }
        }

        protected void btnUpdateEventState_Click(object sender, EventArgs e)
        {
            btnUpdateEventState.Visible = false;
            ddlEventState.Enabled = true;
            btnOKUpdate.Visible = true;
            if (Request.QueryString["typeCode"] != "9999" && Request.QueryString["typeCode"] != "9000" && Request.QueryString["typeCode"] != "8888")
            {
                ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(int.Parse(EventInformationArray(6)), "0");
                ddlEventState.DataValueField = "StateID";
                ddlEventState.DataTextField = "StateName";
                ddlEventState.DataBind();
            }
            else
            {
                if (Request.QueryString["typeCode"] == "9999")
                {
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;
                    btnReOpenEvent.Visible = false;
                    ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(199, "1");
                    ddlEventState.DataValueField = "StateID";
                    ddlEventState.DataTextField = "StateName";
                    ddlEventState.DataBind();
                }
                if (Request.QueryString["typeCode"] == "9000")
                {
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;
                    btnReOpenEvent.Visible = false;
                    btnFacilityMatchingAndOutByEvent.Visible = false;
                    btnSceneByEnent.Visible = false;
                    ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(299, "2");
                    ddlEventState.DataValueField = "StateID";
                    ddlEventState.DataTextField = "StateName";
                    ddlEventState.DataBind();
                }
                if (Request.QueryString["typeCode"] == "8888")
                {
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;
                    btnReOpenEvent.Visible = false;
                    btnFacilityAllotByEvent.Visible = false;
                    btnFacilityMatchingAndOutByEvent.Visible = false;
                    ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(399, "3");
                    ddlEventState.DataValueField = "StateID";
                    ddlEventState.DataTextField = "StateName";
                    ddlEventState.DataBind();

                }
            }
            ddlEventState.SelectedValue = EventInformationArray(6);
            gvEventStepsDataBind();
            
        }

        protected void btnOKUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["typeCode"] != "9999" && Request.QueryString["typeCode"] != "9000" && Request.QueryString["typeCode"] != "8888")
            {
                if (ddlEventState.SelectedValue == "0")
                {
                    DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                    DAL.EventLogsDAL.UpdateResolvedByAndTime(Request.QueryString["eventNo"], ddlResolvedBy.SelectedValue, timeNow());
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "事件已结束", timeNow(), "0", Session["userName"].ToString());
                    txtStepDescribe.Visible = false;
                    btnAddEventSteps.Visible = false;
                    btnReOpenEvent.Visible = true;
                    divThreeBtn.Visible = false;
                    btnUpdateEventState.Visible = false;
                    btnOKUpdate.Visible = false;
                    gvEventStepsDataBind();
                    LoadEventInformation();
                    ddlResolvedBy.Visible = false;
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;
                    btnStopEventLog.Visible = false;
                }
                else
                {
                    DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                    btnUpdateEventState.Visible = true;
                    lblResolvedByText.Visible = false;
                    lblResolvedBy.Visible = false;
                }
            }
            else
            {
                if (Request.QueryString["typeCode"] == "9999")
                {
                    if (ddlEventState.SelectedValue == "100")
                    {
                        DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                        DAL.EventLogsDAL.UpdateResolvedByAndTime(Request.QueryString["eventNo"], "", timeNow());
                        DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "事件已结束", timeNow(), "0", Session["userName"].ToString());
                        DAL.StoresDAL.UpdateStores(StoreInformationArray(0), "", "", "", "", "", "", "", "", "", "", "900");
                        txtStepDescribe.Visible = false;
                        btnAddEventSteps.Visible = false;
                        btnReOpenEvent.Visible = false;
                        divThreeBtn.Visible = false;
                        btnUpdateEventState.Visible = false;
                        btnOKUpdate.Visible = false;
                        gvEventStepsDataBind();
                        LoadEventInformation();
                        ddlResolvedBy.Visible = false;
                        btnUpdateEventType.Visible = false;
                        btnSendEventTo.Visible = false;
                        btnStopEventLog.Visible = false;
                        btnUpdateToResolvedTime.Visible = false;
                    }
                    else
                    {
                        DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                        btnUpdateEventState.Visible = true;
                        lblResolvedByText.Visible = false;
                        lblResolvedBy.Visible = false;
                    }
                }
                
                if (Request.QueryString["typeCode"] == "9000")
                {
                    if (ddlEventState.SelectedValue == "200")
                    {
                        DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                        DAL.EventLogsDAL.UpdateResolvedByAndTime(Request.QueryString["eventNo"], "", timeNow());
                        DAL.StoresDAL.DelStores(StoreInformationArray(0));
                        DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "事件已结束", timeNow(), "0", Session["userName"].ToString()); 
                        txtStepDescribe.Visible = false;
                        btnAddEventSteps.Visible = false;
                        btnReOpenEvent.Visible = false;
                        divThreeBtn.Visible = false;
                        btnUpdateEventState.Visible = false;
                        btnOKUpdate.Visible = false;
                        gvEventStepsDataBind();
                        LoadEventInformation();
                        ddlResolvedBy.Visible = false;
                        btnUpdateEventType.Visible = false;
                        btnSendEventTo.Visible = false;
                        btnStopEventLog.Visible = false;
                        btnUpdateToResolvedTime.Visible = false;
                        
                    }
                    else
                    {
                        DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                        btnUpdateEventState.Visible = true;
                        lblResolvedByText.Visible = false;
                        lblResolvedBy.Visible = false;
                    }
                }
                
                if (Request.QueryString["typeCode"] == "8888")
                {
                    if (ddlEventState.SelectedValue == "300")
                    {
                        DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                        DAL.EventLogsDAL.UpdateResolvedByAndTime(Request.QueryString["eventNo"], "", timeNow());
                        DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "事件已结束", timeNow(), "0", Session["userName"].ToString());
                        DAL.StoresDAL.UpdateStores(StoreInformationArray(0), "", "", "", "", "", "", "", "", "", "", "900");
                        txtStepDescribe.Visible = false;
                        btnAddEventSteps.Visible = false;
                        btnReOpenEvent.Visible = false;
                        divThreeBtn.Visible = false;
                        btnUpdateEventState.Visible = false;
                        btnOKUpdate.Visible = false;
                        gvEventStepsDataBind();
                        LoadEventInformation();
                        ddlResolvedBy.Visible = false;
                        btnUpdateEventType.Visible = false;
                        btnSendEventTo.Visible = false;
                        btnStopEventLog.Visible = false;
                        btnUpdateToResolvedTime.Visible = false;
                    }
                    else
                    {
                        DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], ddlEventState.SelectedValue);
                        btnUpdateEventState.Visible = true;
                        lblResolvedByText.Visible = false;
                        lblResolvedBy.Visible = false;
                    }
                }
                
            }
            ddlEventState.Enabled = false;
            btnOKUpdate.Visible = false;
            ddlEventState.SelectedValue = EventInformationArray(6);
            gvEventStepsDataBind();
            
        }

        protected void btnReturnEventQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventQuery.aspx");
        }

        protected void btnReOpenEvent_Click(object sender, EventArgs e)
        {
            DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], "99");
            DAL.EventLogsDAL.UpdateResolvedByAndTime(Request.QueryString["eventNo"], "","");
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "事件打开延伸", timeNow(), "0", Session["userName"].ToString());
            txtStepDescribe.Visible = true;
            btnAddEventSteps.Visible = true;
            btnUpdateEventState.Visible = true;
            btnReOpenEvent.Visible = false;
            divThreeBtn.Visible = true;
            btnSendEventTo.Visible = true;
            btnUpdateEventType.Visible = true;
            ddlEventState.DataSource = DAL.EventStateDAL.GetEventStateByStateID(99, "0");
            ddlEventState.DataValueField = "StateID";
            ddlEventState.DataTextField = "StateName";
            ddlEventState.DataBind();
            LoadEventInformation();
            gvEventStepsDataBind();
            btnStopEventLog.Visible = true;
        }

        protected void ddlEventState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEventState.SelectedValue == "0")
            {
                lblResolvedByText.Visible = true;
                lblResolvedBy.Visible = false;
                ddlResolvedBy.Visible = true;
                if (EventInformationArray(8) != "")
                {
                    ddlResolvedBy.SelectedValue = EventInformationArray(8);
                }
            }
            else
            {
                lblResolvedByText.Visible = false;
                ddlResolvedBy.Visible = false;
                lblResolvedBy.Visible = false;
            }
            gvEventStepsDataBind();
        }
        protected void btnOpener_Click(object sender, EventArgs e)
        {
            string content = DAL.SolutionsDAL.GetSolutionByID(Request.QueryString["typeCode"]);
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "setSolutions", "setSolutions('" + content + "');", true);
            gvEventStepsDataBind();
        }
        protected void btnFacilityMatchingAndOutByEvent_Click(object sender, EventArgs e)
        {
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(匹配出库)需要调拨设备出库", timeNow(), "0", Session["userName"].ToString());
            string url = "FacilityMatchingAndOutByEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + StoreInformationArray(0) + "&typeCode=" + Request.QueryString["typeCode"];
            Response.Redirect(url);
        }

        protected void btnFacilityAllotByEvent_Click(object sender, EventArgs e)
        {
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(返库调拨)需要调拨设备返库", timeNow(), "0", Session["userName"].ToString());
            string url = "FacilityAllotByEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + StoreInformationArray(0) + "&typeCode=" + Request.QueryString["typeCode"];
            Response.Redirect(url);
        }

        protected void btnSceneByEnent_Click(object sender, EventArgs e)
        {
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)需要上门服务", timeNow(), "0", Session["userName"].ToString());
            DAL.TokenDAL.AddToken(Request.QueryString["eventNo"]);
            string url = "SceneByEnent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + StoreInformationArray(0) + "&typeCode=" + Request.QueryString["typeCode"];
            Response.Redirect(url);
        }

        protected void btnUpdateEventType_Click(object sender, EventArgs e)
        {
            txtType.Visible = true;
            txtType.Text = Request.QueryString["typeCode"];
            lblType.Visible = false;
            btnUpdateEventType.Visible = false;
            btnOKUpdateType.Visible = true;
            gvEventStepsDataBind();
        }

        protected void btnOKUpdateType_Click(object sender, EventArgs e)
        {
            if (txtType.Text.Trim() == "" || txtType.Text.Trim() == Request.QueryString["typeCode"])
            {
                txtType.Text = "";
                txtType.Visible = false;
                lblType.Visible = true;
                btnUpdateEventType.Visible = true;
                btnOKUpdateType.Visible = false;                
            }
            else 
            {
                if (DAL.EventLogsDAL.UpdateTypeCode(Request.QueryString["eventNo"], txtType.Text.Trim()) > 0)
                {
                    if (Request.QueryString["typeCode"] != "0000")
                    {
                        DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(更改信息)事件类型由 " + Request.QueryString["typeCode"] + " 更改成 " + EventInformationArray(3) + "", timeNow(), "0", Session["userName"].ToString());
                    }
                    Response.Redirect("NormalEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&typeCode=" + EventInformationArray(3) + "");
                }
                else
                {
                    MsgBox("不存在该事件类型！");
                }
            }
            gvEventStepsDataBind();
        }

        protected void btnSendEventTo_Click(object sender, EventArgs e)
        {
            btnSendEventTo.Visible = false;
            lblSendEventTo.Visible = true;
            ddlSendEventTo.Visible = true;
            if (DAL.EventLogsDAL.GetHandingByByEventNo(Request.QueryString["eventNo"]) != "")
            {
                ddlSendEventTo.SelectedValue = DAL.EventLogsDAL.GetHandingByByEventNo(Request.QueryString["eventNo"]);
            }
            btnOKSend.Visible = true;
            gvEventStepsDataBind();
        }

        protected void btnOKSend_Click(object sender, EventArgs e)
        {
            if (DAL.EventLogsDAL.UpdateHandingBy(Request.QueryString["eventNo"], ddlSendEventTo.SelectedValue) > 0)
            {
                string typeCode = Request.QueryString["typeCode"];
                string handingBy = DAL.EventLogsDAL.GetHandingByByEventNo(Request.QueryString["eventNo"]);
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(移交事件)事件移交给 " + handingBy + " 处理", timeNow(), "0", Session["userName"].ToString());

                string email = SendEmailInfo(0, handingBy, typeCode);
                string mailTo = SendEmailInfo(3, handingBy, typeCode);
                if (mailTo != "" && mailTo != email)
                {
                    
                    string mailServer = SendEmailInfo(1, handingBy, typeCode);
                    string ePassword = SendEmailInfo(2, handingBy, typeCode);

                    string mailToName = SendEmailInfo(4, handingBy, typeCode);
                    string eventName = SendEmailInfo(5, handingBy, typeCode);
                    string emailBody = "&nbsp; &nbsp; 你好，" + mailToName + "：<div>&nbsp; &nbsp; 当前有一个事件需要移交由 " + handingBy + " 处理，</div><div>&nbsp; &nbsp; &nbsp; &nbsp;门店编号：" + StoreInformationArray(0) + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件编号：" + typeCode + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件概类：" + eventName + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件简述：" + EventInformationArray(4) +"</div><div>&nbsp; &nbsp; &nbsp; &nbsp;发送时间：" + timeNow() + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件详细：</div><div>" + GridViewToHtml(gvEventSteps) + "</div><div>&nbsp; &nbsp; 请及时通知相关人员处理，我们将会对事件进行跟踪！</div><div><br></div><div><br></div><div><br></div><div><font color='#ff3333'>该内容由IIRIS系统发出，如有疑问请回复邮件咨询！谢谢！</font></div>";
                    if (DAL.SendEmail.SendMail(email, mailServer, ePassword, 25, mailTo, mailToName, "IIRIS系统邮件", emailBody) == true)
                    {
                        DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(移交事件)已成功向 " + mailToName + " 发送邮件", timeNow(), "0", Session["userName"].ToString());
                    }
                    else
                    {
                        DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(移交事件)SMTP服务器无法接通，向 " + mailToName + " 发送邮件失败，请手动发送或使用其它方式联系", timeNow(), "0", Session["userName"].ToString());
                    }
                }
                
            }
            btnSendEventTo.Visible = true;
            lblSendEventTo.Visible = false;
            ddlSendEventTo.Visible = false;
            btnOKSend.Visible = false;
            gvEventStepsDataBind();
        }

        protected void btnStopEventLog_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["typeCode"] != "9999" && Request.QueryString["typeCode"] != "9000" && Request.QueryString["typeCode"] != "8888")
            {
                    DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], "0");
                    DAL.StocksDAL.DelStocksBack(Request.QueryString["eventNo"]);
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(特殊情况)事件被强行关闭，涉及设备被强行还原", timeNow(), "0", Session["userName"].ToString());
                    txtStepDescribe.Visible = false;
                    btnAddEventSteps.Visible = false;
                    btnReOpenEvent.Visible = true;
                    divThreeBtn.Visible = false;
                    btnUpdateEventState.Visible = false;
                    btnOKUpdate.Visible = false;
                    gvEventStepsDataBind();
                    LoadEventInformation();
                    ddlResolvedBy.Visible = false;
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;
            }
            else
            {
                if (Request.QueryString["typeCode"] == "9999")
                {
                    //string minState = DAL.EventStateDAL.GetMinEventState("1").ToString();
                    DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], "100");
                    DAL.StocksDAL.DelStocksBack(Request.QueryString["eventNo"]);
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(特殊情况)事件被强行关闭，涉及设备和门店被强行还原", timeNow(), "0", Session["userName"].ToString());
                    DAL.StoresDAL.DelStores(StoreInformationArray(0));
                    //DAL.StoresDAL.UpdateStores(StoreInformationArray(0), "", "", "", "", "", "", "", "", "", "", "900");
                    txtStepDescribe.Visible = false;
                    btnAddEventSteps.Visible = false;
                    btnReOpenEvent.Visible = false;
                    divThreeBtn.Visible = false;
                    btnUpdateEventState.Visible = false;
                    btnOKUpdate.Visible = false;
                    gvEventStepsDataBind();
                    LoadEventInformation();
                    ddlResolvedBy.Visible = false;
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;
                }

                if (Request.QueryString["typeCode"] == "9000")
                {
                    //string minState = DAL.EventStateDAL.GetMinEventState("2").ToString();
                    DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], "200");
                    DAL.StocksDAL.DelStocksBack(Request.QueryString["eventNo"]);
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(特殊情况)事件被强行关闭，涉及设备和门店被强行还原", timeNow(), "0", Session["userName"].ToString());
                    DAL.StoresDAL.UpdateStores(StoreInformationArray(0), "", "", "", "", "", "", "", "", "", "", "900");
                    txtStepDescribe.Visible = false;
                    btnAddEventSteps.Visible = false;
                    btnReOpenEvent.Visible = false;
                    divThreeBtn.Visible = false;
                    btnUpdateEventState.Visible = false;
                    btnOKUpdate.Visible = false;
                    gvEventStepsDataBind();
                    LoadEventInformation();
                    ddlResolvedBy.Visible = false;
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;
                }

                if (Request.QueryString["typeCode"] == "8888")
                {
                    //string minState = DAL.EventStateDAL.GetMinEventState("3").ToString();
                    DAL.EventLogsDAL.UpdateEventState(Request.QueryString["eventNo"], "300");
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(特殊情况)事件被强行关闭", timeNow(), "0", Session["userName"].ToString());
                    DAL.StoresDAL.UpdateStores(StoreInformationArray(0), "", "", "", "", "", "", "", "", "", "", "900");
                    txtStepDescribe.Visible = false;
                    btnAddEventSteps.Visible = false;
                    btnReOpenEvent.Visible = false;
                    divThreeBtn.Visible = false;
                    btnUpdateEventState.Visible = false;
                    btnOKUpdate.Visible = false;
                    gvEventStepsDataBind();
                    LoadEventInformation();
                    ddlResolvedBy.Visible = false;
                    btnUpdateEventType.Visible = false;
                    btnSendEventTo.Visible = false;

                }

            }
            ddlEventState.Enabled = false;
            btnOKUpdate.Visible = false;
            ddlEventState.SelectedValue = EventInformationArray(6);
            gvEventStepsDataBind();
        }

        protected void btnUpdateToResolvedTime_Click(object sender, EventArgs e)
        {
            lblToResolvedTime.Visible = false;
            btnUpdateToResolvedTime.Visible = false;
            btnOKUpdateToResolvedTime.Visible = true;
            txtToResolvedTime.Visible = true;
            txtToResolvedTime.Text = EventInformationArray(5);
            gvEventStepsDataBind();
        }

        protected void btnOKUpdateToResolvedTime_Click(object sender, EventArgs e)
        {
            lblToResolvedTime.Visible = true;
            btnUpdateToResolvedTime.Visible = true;
            btnOKUpdateToResolvedTime.Visible = false;
            txtToResolvedTime.Visible = false;
            if (txtToResolvedTime.Text.Trim() != EventInformationArray(5))
            {
                if (Request.QueryString["typeCode"] == "9999")
                {
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(更改信息)开店日期由 " + EventInformationArray(5) + " 变更成" + txtToResolvedTime.Text.Trim(), timeNow(), "0", Session["userName"].ToString());
                }
                if (Request.QueryString["typeCode"] == "9000")
                {
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(更改信息)关店日期由 " + EventInformationArray(5) + " 变更成" + txtToResolvedTime.Text.Trim(), timeNow(), "0", Session["userName"].ToString());
                }
                if (Request.QueryString["typeCode"] == "8888")
                {
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(更改信息)结束日期由 " + EventInformationArray(5) + " 变更成" + txtToResolvedTime.Text.Trim(), timeNow(), "0", Session["userName"].ToString());
                }                
                DAL.EventLogsDAL.UpdateToResolvedTime(Request.QueryString["eventNo"], txtToResolvedTime.Text.Trim());
            }
            lblToResolvedTime.Text = EventInformationArray(5);
            gvEventStepsDataBind();
        }

    }
}