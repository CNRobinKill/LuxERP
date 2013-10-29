using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace LuxERP.UI.EventManagement
{
    public partial class SceneByEnent : System.Web.UI.Page
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "2") == "0")
                        {
                            Response.Write("<script LANGUAGE=JavaScript >" +
                                " alert('没有权限，请联系管理员！');" +
                                " window.location=('/LogOn.aspx');" +
                                "</script>");
                            Response.End();
                        }
                        //try
                        //{
                            if (IsPostBack)
                            {
                                string strFunName = Request.Form["FunName"] != null ? Request.Form["FunName"] : "";
                                string strRowID = Request.Form["RowID"];
                                //根据传回来的值决定调用哪个函数
                                switch (strFunName)
                                {
                                    case "btnAddStoreFacilities()":
                                        btnAddStoreFacilities(strRowID); //调用该函数
                                        break;
                                    case "其他":
                                        //调用其他函数
                                        break;
                                    default:
                                        //调用默认函数
                                        break;
                                }
                                RegisterJS("addRowStyle");
                                RegisterJS("setDate");
                                gvFacility.Visible = false;
                                divAddStoreFacilities.Visible = false;
                                gvAppointEngineersBind();
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

                                gvFacilitiesServicesBind();
                                gvAppointEngineersBind();
                                btnState();
                                ddlMultiplyingPowerShow();
                                for (int i = 0; i < DAL.SceneServiceProviderDAL.GetServiceProvider().Tables[0].Rows.Count; i++)
                                {
                                    ddlServiceProvider.Items.Add(DAL.SceneServiceProviderDAL.GetServiceProvider().Tables[0].Rows[i][0].ToString());
                                }
                                for (int i = 0; i < DAL.SceneTypeDAL.GetTypeName().Tables[0].Rows.Count; i++)
                                {
                                    ddlSceneType.Items.Add(DAL.SceneTypeDAL.GetTypeName().Tables[0].Rows[i][0].ToString());
                                }
                                for (int i = 1; i < 25; i++)
                                {
                                    ddlTime.Items.Add(i.ToString());
                                }
                            }
                        //}
                        //catch
                        //{
                        //    Response.Redirect("~/Error.html");
                        //}
                    }
                }
            
        }


        public void ddlMultiplyingPowerShow()
        {
            ddlMultiplyingPower.DataSource = DAL.MultiplyingPowerTypeDAL.GetMultiplyingPowerType();
            ddlMultiplyingPower.DataValueField = "MultiplyingPower";
            ddlMultiplyingPower.DataTextField = "TypeName";
            ddlMultiplyingPower.DataBind();
            ddlMultiplyingPower.SelectedIndex = 0;
        }

        protected void ddlMultiplyingPower_DataBound(object sender, EventArgs e)
        {
            ddlMultiplyingPower.Items.Insert(0, "选择倍率");
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public void MsgBox(string showMsg)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + showMsg + "');", true);
        }

        protected void btnReturnEventQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("NormalEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&typeCode=" + Request.QueryString["typeCode"]);
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

        public void gvFacilityBind(string storeNo)
        {
            gvFacility.Width = 1040;
            gvFacility.DataSource = DAL.StocksDAL.GetStocks("0", storeNo, "", "", "", "", "", "", "", "", "", "", "");
            gvFacility.DataKeyNames = new string[] { "ID" };
            gvFacility.DataBind();
            if (gvFacility.HeaderRow != null)
            {
                gvFacility.HeaderRow.Cells[0].Text = "";
                gvFacility.HeaderRow.Cells[1].Text = "<b>机器名称</b>";
                gvFacility.HeaderRow.Cells[2].Text = "<b>品牌</b>";
                gvFacility.HeaderRow.Cells[3].Text = "<b>型号</b>";
                gvFacility.HeaderRow.Cells[4].Text = "<b>参数</b>";
                gvFacility.HeaderRow.Cells[5].Text = "<b>序列号</b>";
                gvFacility.HeaderRow.Cells[6].Text = "<b>标签码</b>";
                gvFacility.HeaderRow.Cells[7].Text = "<b>SAP号</b>";
                gvFacility.HeaderRow.Cells[8].Text = "<b>购买日期</b>";
                gvFacility.HeaderRow.Cells[9].Text = "<b>保修结束日期</b>";
                gvFacility.HeaderRow.Cells[10].Text = "<b>保修电话</b>";
                gvFacility.HeaderRow.Cells[11].Text = "<b>供应商</b>";
                gvFacility.HeaderRow.Cells[12].Text = "<b>出库时间</b>";
                if (DAL.StocksDAL.GetStocks("0", storeNo, "", "", "", "", "", "", "", "", "", "", "").Tables[0].Rows.Count == 0)
                {
                    divAddStoreFacilities.Visible = false;
                    divNogvFacility.Visible = true;
                }
                else
                {
                    divAddStoreFacilities.Visible = true;
                    divNogvFacility.Visible = false;
                }
            }
            else
            {
                divAddStoreFacilities.Visible = false;
                divNogvFacility.Visible = true;
            }
        }

        public void gvFacilitiesServicesBind()
        {
            gvFacilitiesServices.Width = 1050;
            gvFacilitiesServices.DataSource = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], Request.QueryString["storeNo"], "", "", "", "", "", "", "", "", "", "1", "");
            gvFacilitiesServices.DataKeyNames = new string[] { "ID" };
            gvFacilitiesServices.DataBind();
            if (gvFacilitiesServices.HeaderRow != null)
            {
                gvFacilitiesServices.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvFacilitiesServices.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvFacilitiesServices.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvFacilitiesServices.HeaderRow.Cells[3].Text = "<b>参数</b>";
                gvFacilitiesServices.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                gvFacilitiesServices.HeaderRow.Cells[5].Text = "<b>标签码</b>";
                gvFacilitiesServices.HeaderRow.Cells[6].Text = "<b>SAP号</b>";
                gvFacilitiesServices.HeaderRow.Cells[7].Text = "<b>购买日期</b>";
                gvFacilitiesServices.HeaderRow.Cells[8].Text = "<b>保修结束日期</b>";
                gvFacilitiesServices.HeaderRow.Cells[9].Text = "<b>保修电话</b>";
                gvFacilitiesServices.HeaderRow.Cells[10].Text = "<b>供应商</b>";
                gvFacilitiesServices.HeaderRow.Cells[11].Text = "<b>出库时间</b>";
                if (DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], Request.QueryString["storeNo"], "", "", "", "", "", "", "", "", "", "1", "").Tables[0].Rows.Count == 0)
                {
                    noFlittingText.Visible = true;
                    btnReSet.Visible = false;
                    divAddEngineers.Visible = false;
                    noEngineersText.Visible = true;
                }
                else
                {
                    noFlittingText.Visible = false;
                    btnReSet.Visible = true;
                    gvAppointEngineersBind();
                }
            }
            else
            {
                noFlittingText.Visible = true;
                btnReSet.Visible = false;
                divAddEngineers.Visible = false;
                noEngineersText.Visible = true;
            }
        }

        public void gvAppointEngineersBind()
        {
            gvAppointEngineers.Width = 600;
            gvAppointEngineers.DataSource = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]);
            gvAppointEngineers.DataKeyNames = new string[] { "ID" };
            gvAppointEngineers.DataBind();
            int rowCount = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
            if (gvAppointEngineers.HeaderRow != null)
            {
                gvAppointEngineers.HeaderRow.Cells[0].Text = "<b>服务商</b>";
                gvAppointEngineers.HeaderRow.Cells[1].Text = "<b>联系电话</b>";
                gvAppointEngineers.HeaderRow.Cells[2].Text = "<b>联系邮箱</b>";
                gvAppointEngineers.HeaderRow.Cells[3].Text = "<b>预约时间</b>";
                gvAppointEngineers.HeaderRow.Cells[5].Text = "";
                if (rowCount == 0)
                {
                    divAddEngineers.Visible = false;
                    noEngineersText.Visible = true;
                }
                else
                {
                    if (gvAppointEngineers.Rows[rowCount - 1].Cells[4].Text == "2")
                    {
                        divAddEngineers.Visible = false;
                        noEngineersText.Visible = false;
                        btnWorkOrder.Visible = false;
                        lblSceneTime.Visible = false;
                        lblSceneDate.Visible = false;
                        txtSceneTime.Visible = false;
                        ddlTime.Visible = false;
                    }
                    else
                    {
                        if (gvAppointEngineers.Rows[rowCount - 1].Cells[4].Text == "0")
                        {
                            noEngineersText.Visible = false;
                            divAddEngineers.Visible = true;
                            btnWorkOrder.Visible = true;
                            lblSceneTime.Visible = true;
                            lblSceneDate.Visible = true;
                            txtSceneTime.Visible = true;
                            ddlTime.Visible = true;
                        }
                        else
                        {
                            noEngineersText.Visible = false;
                            divAddEngineers.Visible = false;
                            btnWorkOrder.Visible = true;
                            lblSceneTime.Visible = true;
                            lblSceneDate.Visible = true;
                            txtSceneTime.Visible = true;
                            ddlTime.Visible = true;
                        }
                    }
                    divFacilitiesServices.Visible = false;
                    btnPreviewWorkOrder.Visible = true;
                }
            }
            else
            {
                if (gvFacilitiesServices.HeaderRow != null)
                {
                    divAddEngineers.Visible = true;
                    noEngineersText.Visible = false;
                }
                else
                {
                    divAddEngineers.Visible = false;
                    noEngineersText.Visible = true;
                }

            }
            gvAppointEngineers.Columns[4].Visible = false;
        }

        //public void gvServicesBind()
        //{
        //    gvServices.Width = 550;
        //    gvServices.DataSource = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], Request.QueryString["storeNo"], "", "", "", "", "", "", "", "", "", "1", "");
        //    gvServices.DataKeyNames = new string[] { "ID" };
        //    gvServices.DataBind();
        //    LoadStoreInformation();    
        //}

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
                gvEventSteps.HeaderRow.Cells[2].Text = "<b>执行人</b>";
                gvEventSteps.HeaderRow.Cells[3].Text = "<b>状态</b>";
            }
        }

        public void gvHistoryServiceBind()
        {
            gvHistoryService.Width = 670;
            gvHistoryService.DataSource = DAL.SceneStateDAL.GetHistoryServiceByEventNo(Request.QueryString["eventNo"]);
            gvHistoryService.DataBind();
            if (gvHistoryService.HeaderRow != null)
            {
                gvHistoryService.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvHistoryService.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvHistoryService.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvHistoryService.HeaderRow.Cells[3].Text = "<b>参数</b>";
                gvHistoryService.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                gvHistoryService.HeaderRow.Cells[5].Text = "<b>购买日期</b>";
                gvHistoryService.HeaderRow.Cells[6].Text = "<b>供应商</b>";
                gvHistoryService.HeaderRow.Cells[7].Text = "<b>服务时间</b>";
                if (DAL.SceneStateDAL.GetHistoryServiceByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count == 0)
                {
                    divUpload.Visible = false;
                }
                else
                {
                    divUpload.Visible = true;
                    if (DAL.EventLogsDAL.GetPic(Request.QueryString["eventNo"], "1") != "")
                    {
                        uploado.Visible = false;
                        uploadt.Visible = true;
                    }
                    else
                    {
                        uploado.Visible = true;
                        uploadt.Visible = false;
                    }
                }
            }
        }

        public string StoreInformationArray(int n)
        {
            SqlDataReader dr = DAL.StoresDAL.GetStoresByStoreNo(Request.QueryString["storeNo"]);
            dr.Read();
            string stores = dr[n].ToString();
            dr.Close();
            return stores;
        }

        public string SendEmailInfo(int n)
        {
            SqlDataReader dr = DAL.AppointEngineersDAL.GetEmailFromEngineers(Request.QueryString["eventNo"]);
            dr.Read();
            string emailInfo = dr[n].ToString();
            dr.Close();
            return emailInfo;
        }

        //public void LoadStoreInformation()
        //{
        //    lblStoreNo.Text = StoreInformationArray(0);
        //    lblStoreName.Text = StoreInformationArray(5);
        //    lblEventNo.Text = Request.QueryString["eventNo"];
        //    lblStoreAddress.Text = StoreInformationArray(7);
        //    lblStoreTel.Text = StoreInformationArray(8);
        //}

        protected void btnStoreFacilities_Click(object sender, EventArgs e)
        {
            divAddStoreFacilities.Visible = true;
            gvFacility.Visible = true;
            string storeNo = Request.QueryString["storeNo"];
            facility.Attributes.Remove("title");
            facility.Attributes.Add("title", storeNo + "设备信息");
            gvFacilityBind(storeNo);
            RegisterJS("showDialog");
        }

        protected void btnReSet_Click(object sender, EventArgs e)
        {
            DAL.StocksDAL.DelStocksMutualFacilityAllot(Request.QueryString["eventNo"]);
            gvFacilitiesServicesBind();
        }

        protected void btnAddStoreFacilities(string strRowID)
        {
            //string id = strRowID.Substring(1, strRowID.Length - 1);
            DAL.StocksDAL.UpdateStocksMutualFacilityAllot(Request.QueryString["eventNo"], strRowID);
            RegisterJS("clean");
            gvFacilitiesServicesBind();
        }

        protected void btnAddEngineers_Click(object sender, EventArgs e)
        {
            DAL.AppointEngineersDAL.AddAppointEngineers(Request.QueryString["eventNo"], ddlServiceProvider.SelectedValue, "1");
            DAL.TokenDAL.UpdateToken(Request.QueryString["eventNo"], "", "", ddlSceneType.SelectedValue, "", ddlServiceProvider.SelectedValue);
            //DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)正在预约工程师 " + ddlName.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            gvAppointEngineersBind();
        }

        protected void gvAppointEngineers_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string state = DAL.SceneStateDAL.GetSceneStateByEventNo(Request.QueryString["eventNo"]);
            DAL.AppointEngineersDAL.UpdateAppointState(int.Parse(gvAppointEngineers.DataKeys[e.NewSelectedIndex].Value.ToString()),"", "0");
            //DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)预约工程师 " + gvAppointEngineers.Rows[e.NewSelectedIndex].Cells[0].Text.Trim() + " 失败", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            gvAppointEngineersBind();
        }

        protected void btnWorkOrder_Click(object sender, EventArgs e)
        {
            if (txtSceneTime.Text.Trim() != "")
            {
                int rowCount = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
                DAL.AppointEngineersDAL.UpdateAppointState(int.Parse(gvAppointEngineers.DataKeys[rowCount - 1].Value.ToString()), txtSceneTime.Text.Trim() + " " + ddlTime.SelectedValue + ":00:00", "2");
                string eventNo = Request.QueryString["eventNo"];
                string sceneTime = SendEmailInfo(6);
                string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)成功预约服务商 " + gvAppointEngineers.Rows[rowCount - 1].Cells[0].Text.Trim() + " 于 " + sceneTime + " 上门", timeNow, "0", Session["userName"].ToString());
                string mailTo = SendEmailInfo(4);
                if (mailTo != "")
                {
                    string email = SendEmailInfo(0);
                    string mailServer = SendEmailInfo(1);
                    string ePassword = SendEmailInfo(2);
                    string mailToName = SendEmailInfo(3);

                    string eventName = SendEmailInfo(5);
                    string typeCode = SendEmailInfo(7);

                    string storeAddress = StoreInformationArray(7);
                    string storeTel = StoreInformationArray(8);

                    gvEventSteps.Visible = true;
                    gvEventStepsDataBind();
                    string emailBody = "&nbsp; &nbsp; 你好，" + mailToName + " 服务商：<div>&nbsp; &nbsp; 当前有一个门店需要上门服务，</div><div>&nbsp; &nbsp; &nbsp; &nbsp;门店编号：" + Request.QueryString["storeNo"] + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;门店地址：" + storeAddress + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;门店电话：" + storeTel + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件编号：" + eventNo + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件概类：(" + typeCode + ") " + eventName + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;发送时间：" + timeNow + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件详细：</div><div>" + GridViewToHtml(gvEventSteps) + "</div><div>&nbsp; &nbsp; 请在我们双方预约的大概时间（" + sceneTime + "）到达门店，我们将会对整个上门服务流程进行跟踪！</div><div><br></div><div><br></div><div><br></div><div><font color='#ff3333'>该内容由IIRIS系统发出，如有疑问请回复邮件咨询！谢谢！</font></div>";
                    gvEventSteps.Visible = false;
                    if (DAL.SendEmail.SendMail(email, mailServer, ePassword, 25, mailTo, mailToName, "IIRIS系统邮件", emailBody) == true)
                    {
                        DAL.EventStepsDAL.AddEventSteps(eventNo, "(上门服务)已成功向服务商" + mailToName + "发送邮件", timeNow, "0", Session["userName"].ToString());
                    }
                    else
                    {
                        DAL.EventStepsDAL.AddEventSteps(eventNo, "(上门服务)SMTP服务器无法接通，向" + mailToName + "发送邮件失败，请手动发送或使用其它方式联系", timeNow, "0", Session["userName"].ToString());
                    }
                }
                string state = DAL.SceneStateDAL.GetSceneStateByEventNo(Request.QueryString["eventNo"]);
                if (state == "5")
                {
                    DAL.SceneStateDAL.UpdateSceneState(Request.QueryString["eventNo"], "0");
                }
                else
                {
                    DAL.SceneStateDAL.AddSceneState(Request.QueryString["eventNo"], "0");
                }
                btnState();
            }
            else
            {
                MsgBox("请填写双方约定的上门时刻！");
            }
            gvAppointEngineersBind();
        }

        protected void gvAppointEngineers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            gvAppointEngineers.Columns[4].Visible = true;
            if (e.Row.Cells[4].Text == "0")
            {
                e.Row.Cells[5].Width = 100;
                e.Row.Cells[5].Text = "已取消";
            }
            if (e.Row.Cells[4].Text == "2")
            {
                e.Row.Cells[5].Width = 100;
                e.Row.Cells[5].Text = "已预约";
                //gvServicesBind();
            }
        }

        public void btnState()
        {
            string state = DAL.SceneStateDAL.GetSceneStateByEventNo(Request.QueryString["eventNo"]);
            if (state == "0")
            {
                ddlMultiplyingPower.Visible = true;
                divDate.Visible = true;
                divJobSchedule.Visible = true;
                btnStart.Enabled = true;
                btnStart.CssClass = "button";
                btnEndNo.Enabled = false;
                btnEndNo.CssClass = "buttonnone";
                btnEndOk.Enabled = false;
                btnEndOk.CssClass = "buttonnone";
                btnGoOn.Enabled = false;
                btnGoOn.CssClass = "buttonnone";
                btnChange.Enabled = false;
                btnChange.CssClass = "buttonnone";
            }
            if (state == "1" || state == "4")
            {
                ddlMultiplyingPower.Visible = false;
                divDate.Visible = false;
                divJobSchedule.Visible = true;
                btnStart.Enabled = false;
                btnStart.CssClass = "buttonnone";
                btnEndNo.Enabled = true;
                btnEndNo.CssClass = "button";
                btnEndOk.Enabled = true;
                btnEndOk.CssClass = "button";
                btnGoOn.Enabled = false;
                btnGoOn.CssClass = "buttonnone";
                btnChange.Enabled = false;
                btnChange.CssClass = "buttonnone";
            }
            if (state == "2")
            {
                ddlMultiplyingPower.Visible = false;
                divDate.Visible = false;
                divJobSchedule.Visible = true;
                btnStart.Enabled = false;
                btnStart.CssClass = "buttonnone";
                btnEndNo.Enabled = false;
                btnEndNo.CssClass = "buttonnone";
                btnEndOk.Enabled = false;
                btnEndOk.CssClass = "buttonnone";
                btnGoOn.Enabled = true;
                btnGoOn.CssClass = "button";
                btnChange.Enabled = true;
                btnChange.CssClass = "button";
            }
            if (state == "3")
            {
                ddlMultiplyingPower.Visible = false;
                divDate.Visible = false;
                divJobSchedule.Visible = false; 
                divHistoryService.Visible = true;
                gvHistoryServiceBind();
                //divWorkOrderH.Visible = false;
                
            }
            if (state == "5")
            {
                ddlMultiplyingPower.Visible = false;
                divDate.Visible = false;
                divAddEngineers.Visible = true;
                divJobSchedule.Visible = false;
            }

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            if (ddlMultiplyingPower.SelectedIndex != 0)
            {
                int rowCount = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
                DAL.SceneStateDAL.UpdateSceneState(Request.QueryString["eventNo"], "1");
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)服务商 " + gvAppointEngineers.Rows[rowCount - 1].Cells[0].Text + " 开始上门", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
                DAL.TokenDAL.UpdateToken(Request.QueryString["eventNo"], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "", "", ddlMultiplyingPower.SelectedValue, "");
            }
            else
            {
                MsgBox("请选择倍率！");
            }
            btnState();
        }

        protected void btnEndNo_Click(object sender, EventArgs e)
        {
            int rowCount = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
            DAL.SceneStateDAL.UpdateSceneState(Request.QueryString["eventNo"], "2");
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)服务商 " + gvAppointEngineers.Rows[rowCount - 1].Cells[0].Text + " 结束上门(未完成)", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            btnState();
        }

        protected void btnEndOk_Click(object sender, EventArgs e)
        {
            int rowCount = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
            DAL.SceneStateDAL.UpdateSceneState(Request.QueryString["eventNo"], "3");
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)服务商 " + gvAppointEngineers.Rows[rowCount - 1].Cells[0].Text + " 结束上门(完成)", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            DAL.TokenDAL.UpdateToken(Request.QueryString["eventNo"], "", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "", "", "");
            DAL.SceneStateDAL.AddHistoryServiceFromStocks(Request.QueryString["eventNo"], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            btnState();
        }

        protected void btnGoOn_Click(object sender, EventArgs e)
        {
            int rowCount = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
            DAL.SceneStateDAL.UpdateSceneState(Request.QueryString["eventNo"], "4");
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)服务商 " + gvAppointEngineers.Rows[rowCount - 1].Cells[0].Text + " 再次上门", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            btnState();
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            int rowCount = DAL.AppointEngineersDAL.GetAppointEngineersByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
            DAL.SceneStateDAL.UpdateSceneState(Request.QueryString["eventNo"], "5");
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(上门服务)服务商 " + gvAppointEngineers.Rows[rowCount - 1].Cells[0].Text + " 需要更换", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            btnState();
        }

        protected void btnPreviewWorkOrder_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "openWorkOrder", "window.open('WorkOrder.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + StoreInformationArray(0) + "','','scrollbars=yes');", true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string eventNo = Request.QueryString["eventNo"];
            if (fuFile.HasFile)//上传控件命名为fuFILE了
            {
                string path = Server.MapPath("~/Content/uploadimages/");//你要保存的目录
                //if (!Directory.Exists(path))    //判断目录是否存在
                //    Directory.CreateDirectory(path);
                string name = fuFile.FileName;  //获取上传的文件名称
                String ext = Path.GetExtension(fuFile.FileName).ToLower();  //获取上传文件的后缀名
                String[] allowedExtensions = { ".gif", ".png", ".bmp", ".jpg" };
                bool fileOK = false;
                for (int i = 0; i < allowedExtensions.Length; i++)//判断是否是图片
                {
                    if (ext == allowedExtensions[i])
                    {
                        fileOK = true;
                        break;
                    }
                }
                if (fileOK)//是图片上传
                {
                    string newName = Guid.NewGuid() + ext; //重命名，防止重名文件
                    DAL.EventLogsDAL.UpdateUpLoadPic(eventNo, "", newName);
                    fuFile.SaveAs(path + newName);        //保存到服务器上了。
                    uploado.Visible = false;
                    uploadt.Visible = true;
                }
            }
        }

        protected void btnShowPic_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "openShowPic", "window.open('ShowPic.aspx?eventNo=" + Request.QueryString["eventNo"] + "&n=1 ','','scrollbars=yes');", true);
        }

        protected void btnDelPic_Click(object sender, EventArgs e)
        {
            uploado.Visible = true;
            uploadt.Visible = false;
        }

        
    }
}