using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LuxERP.UI.EventManagement
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        private static int n = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.btnNormalEvent.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnNormalEvent, "click") + ";this.disabled=true; this.value='处理中...';");
            //this.btnSetUpShop.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnSetUpShop, "click") + ";this.disabled=true; this.value='处理中...';");
            //this.btnShutUpShop.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnShutUpShop, "click") + ";this.disabled=true; this.value='处理中...';");
            //this.btnStoreRenovation.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnStoreRenovation, "click") + ";this.disabled=true; this.value='处理中...';");
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
                        Response.Redirect("/LogOn.aspx");
                        Response.End();
                    }
                    else
                    {
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "3") == "0")
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
                                n = 0;
                                basicInformation.Visible = false;
                            }
                            if (IsPostBack)
                            {
                                RegisterJS("ready");
                                RegisterJS("setDate");
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

        public void textBoxClean()
        {
            txtTypeCode.Text = "";
            txtEventDescribe.Text = "";
            txtRegion.Text = "";
            txtStoreNo.Text = "";
            txtToResolvedTime.Text = "";
        }

        protected void imgBtnNormalEvent_Click(object sender, ImageClickEventArgs e)
        {
            textBoxClean();
            imgBtnNormalEvent.CssClass = "imgSelected";
            imgBtnSetUpShop.CssClass = "";
            imgBtnShutUpShop.CssClass = "";
            imgBtnStoreRenovation.CssClass = "";

            basicInformation.Visible = true;
            btnNormalEvent.Visible = true;
            trTypeCode.Visible = true;
            trStoreNo1.Visible = true;
            trStoreNo2.Visible = false;
            trRegion.Visible = false;
            btnSetUpShop.Visible = false;
            btnShutUpShop.Visible = false;
            btnStoreRenovation.Visible = false;
            trToResolvedTime.Visible = false;
            storeInformation.Visible = false;
            btnStoreInfo.Style["Display"] = "none";
            //lblTypeCodeText.Visible = false;
            //lblStoreInfoText.Visible = false;
            //lblStoreTextNo.Visible = false;
            //lblStoreTextOk.Visible = false;

        }

        protected void imgBtnSetUpShop_Click(object sender, ImageClickEventArgs e)
        {
            textBoxClean();
            imgBtnNormalEvent.CssClass = "";
            imgBtnSetUpShop.CssClass = "imgSelected";
            imgBtnShutUpShop.CssClass = "";
            imgBtnStoreRenovation.CssClass = "";

            basicInformation.Visible = true;
            btnNormalEvent.Visible = false;
            trTypeCode.Visible = false;
            trStoreNo1.Visible = false;
            trStoreNo2.Visible = true;
            trRegion.Visible = true;
            btnSetUpShop.Visible = true;
            btnShutUpShop.Visible = false;
            btnStoreRenovation.Visible = false;
            trToResolvedTime.Visible = true;
            lblSetUp.Visible = true;
            lblShutUp.Visible = false;
            lblEnd.Visible = false;
            storeInformation.Visible = false;
            btnStoreInfo.Style["Display"] = "none";
            //lblTypeCodeText.Visible = false;
            //lblStoreInfoText.Visible = false;
            //lblStoreTextNo.Visible = false;
            //lblStoreTextOk.Visible = false;
        }

        protected void imgBtnShutUpShop_Click(object sender, ImageClickEventArgs e)
        {
            textBoxClean();
            imgBtnNormalEvent.CssClass = "";
            imgBtnSetUpShop.CssClass = "";
            imgBtnShutUpShop.CssClass = "imgSelected";
            imgBtnStoreRenovation.CssClass = "";

            basicInformation.Visible = true;
            btnNormalEvent.Visible = false;
            trTypeCode.Visible = false;
            trStoreNo1.Visible = true;
            trStoreNo2.Visible = false;
            trRegion.Visible = false;
            btnSetUpShop.Visible = false;
            btnShutUpShop.Visible = true;
            btnStoreRenovation.Visible = false;
            trToResolvedTime.Visible = true;
            lblSetUp.Visible = false;
            lblShutUp.Visible = true;
            lblEnd.Visible = false;
            storeInformation.Visible = false;
            btnStoreInfo.Style["Display"] = "none";
            //lblTypeCodeText.Visible = false;
            //lblStoreInfoText.Visible = false;
            //lblStoreTextNo.Visible = false;
            //lblStoreTextOk.Visible = false;
        }

        protected void imgBtnStoreRenovation_Click(object sender, ImageClickEventArgs e)
        {
            textBoxClean();
            imgBtnNormalEvent.CssClass = "";
            imgBtnSetUpShop.CssClass = "";
            imgBtnShutUpShop.CssClass = "";
            imgBtnStoreRenovation.CssClass = "imgSelected";

            basicInformation.Visible = true;
            btnNormalEvent.Visible = false;
            trTypeCode.Visible = false;
            trStoreNo1.Visible = true;
            trStoreNo2.Visible = false;
            trRegion.Visible = false;
            btnSetUpShop.Visible = false;
            btnShutUpShop.Visible = false;
            btnStoreRenovation.Visible = true;
            trToResolvedTime.Visible = true;
            lblSetUp.Visible = false;
            lblShutUp.Visible = false;
            lblEnd.Visible = true;
            storeInformation.Visible = false;
            btnStoreInfo.Style["Display"] = "none";
            //lblTypeCodeText.Visible = false;
            //lblStoreInfoText.Visible = false;
            //lblStoreTextNo.Visible = false;
            //lblStoreTextOk.Visible = false;
        }

        public string SendEmailInfo(int n,string typeCode)
        {
            SqlDataReader dr = DAL.SynthesisDAL.GetSolverByEventType(typeCode);
            dr.Read();
            string emailInfo = dr[n].ToString();
            dr.Close();
            return emailInfo;
        }

        protected void btnNormalEvent_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                n++;
                string eventNoNow = EventNo();
                string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string typeCode = txtTypeCode.Text.Trim();
                if (typeCode == "" || typeCode == null)
                {
                    typeCode = "0000";
                }
                if (DAL.EventLogsDAL.AddEventLogs(eventNoNow, timeNow, txtStoreNo.Text.Trim(), typeCode, txtEventDescribe.Text.Trim(), "", "99", Session["userName"].ToString()) > 0)
                {
                    DAL.EventStepsDAL.AddEventSteps(eventNoNow, "(创建事件)事件由 " + DAL.EventTypesDAL.GetEventLevelByTypeCode(typeCode) + " 处理", timeNow, "0", Session["userName"].ToString());
                    string mailTo = SendEmailInfo(3, typeCode);
                    if (mailTo != "")
                    {
                        string email = SendEmailInfo(0, typeCode);
                        string mailServer = SendEmailInfo(1, typeCode);
                        string ePassword = SendEmailInfo(2, typeCode);

                        string mailToName = SendEmailInfo(4, typeCode);
                        string eventLevel = SendEmailInfo(5, typeCode);
                        string eventName = SendEmailInfo(6, typeCode);
                        string emailBody = "&nbsp; &nbsp; 你好，" + mailToName + "：<div>&nbsp; &nbsp; 当前有一个事件需要由" + eventLevel + "处理，</div><div>&nbsp; &nbsp; &nbsp; &nbsp;门店编号：" + txtStoreNo.Text.Trim() + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件编号：" + typeCode + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件概类：" + eventName + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;发送时间：" + timeNow + "</div><div>&nbsp; &nbsp; 请及时通知相关人员处理，我们将会对事件进行跟踪！</div><div><br></div><div><br></div><div><br></div><div><font color='#ff3333'>该内容由IIRIS系统发出，如有疑问请回复邮件咨询！谢谢！</font></div>";
                        if (DAL.SendEmail.SendMail(email, mailServer, ePassword, 25, mailTo, mailToName, "IIRIS系统邮件", emailBody) == true)
                        {
                            DAL.EventStepsDAL.AddEventSteps(eventNoNow, "(创建事件)已成功向" + mailToName + "发送邮件", timeNow, "0", Session["userName"].ToString());
                        }
                        else
                        {
                            DAL.EventStepsDAL.AddEventSteps(eventNoNow, "(创建事件)SMTP服务器无法接通，向" + mailToName + "发送邮件失败，请手动发送或使用其它方式联系", timeNow, "0", Session["userName"].ToString());
                        }
                    }
                    string url = "NormalEvent.aspx?eventNo=" + eventNoNow + "&typeCode=" + typeCode + "";
                    Response.Redirect(url);
                }
                else
                {
                    MsgBox("基础信息必须填写完整且正确!");
                }
            }
            
        }
        public static bool readerExists(SqlDataReader dr, string columnName)
        {

            dr.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" +

            columnName + "'";

            return (dr.GetSchemaTable().DefaultView.Count > 0);

        }
        public string EventTypes(string typeCode)
        {
            if (txtTypeCode.Text.Trim() != "")
            {
                SqlDataReader dr = DAL.EventTypesDAL.GetEventTypesByTypeCode(typeCode);
                if (dr.Read())
                {
                    try
                    {
                        string stores = "";
                        if (readerExists(dr, "TypeOne"))
                        {
                            stores = dr[0].ToString();
                        }
                        if (readerExists(dr, "TypeTwo"))
                        {
                            stores = stores + " / " + dr[1].ToString();
                        }
                        if (readerExists(dr, "TypeThree"))
                        {
                            stores = stores + " / " + dr[2].ToString();
                        }
                        if (readerExists(dr, "TypeFour"))
                        {
                            stores = stores + " / " + dr[3].ToString();
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
                else
                {
                    dr.Close();
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        protected void btnSetUpShop_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                n++;
                string eventNoNow = EventNo2();
                string region = txtRegion.Text.ToUpper().Trim();
                string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                if (txtStoreNo2.Text.Trim() != "" && txtRegion.Text.Trim() != "")
                {
                    if (DAL.StoresDAL.AddStores(txtStoreNo2.Text.Trim(), "", "IFocus", region, "", "", "", "", "", "", "", "999") > 0)
                    {
                        if (DAL.EventLogsDAL.AddEventLogs(region + nowTime, timeNow, txtStoreNo2.Text.Trim(), "9999", txtEventDescribe.Text.Trim(), txtToResolvedTime.Text.Trim(), "199", Session["userName"].ToString()) > 0)
                        {
                            DAL.EventStepsDAL.AddEventSteps(region + nowTime, "(创建事件)事件由 " + DAL.EventTypesDAL.GetEventLevelByTypeCode(txtTypeCode.Text.Trim()) + " 处理", timeNow, "0", Session["userName"].ToString());
                            DAL.EventStepsDAL.AddEventSteps(region + nowTime, "OS安装,Cisco配置,网络配置", timeNow, "99", Session["userName"].ToString());
                            string url = "NormalEvent.aspx?eventNo=" + region + nowTime + "&typeCode=9999";
                            Response.Redirect(url);
                        }
                        else
                        {
                            MsgBox("基础信息必须填写完整且正确!");
                        }
                    }
                    else
                    {
                        MsgBox("该门店已存在!");
                    }
                }
                else
                { MsgBox("请填写店号!"); }
            }
        }

        protected void btnShutUpShop_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                n++;
                string eventNoNow = EventNo();
                string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (DAL.StoresDAL.UpdateStores(txtStoreNo.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "997") > 0)
                {
                    if (DAL.EventLogsDAL.AddEventLogs(eventNoNow, timeNow, txtStoreNo.Text.Trim(), "9000", txtEventDescribe.Text.Trim(), txtToResolvedTime.Text.Trim(), "299", Session["userName"].ToString()) > 0)
                    {
                        DAL.EventStepsDAL.AddEventSteps(eventNoNow, "(创建事件)事件由 " + DAL.EventTypesDAL.GetEventLevelByTypeCode(txtTypeCode.Text.Trim()) + " 处理", timeNow, "0", Session["userName"].ToString());
                        string url = "NormalEvent.aspx?eventNo=" + eventNoNow + "&typeCode=9000";
                        Response.Redirect(url);
                    }
                    else
                    {
                        MsgBox("基础信息必须填写完整且正确!");
                    }
                }
                else
                {
                    MsgBox("该门店不该有关店事件或不存在!");
                }
            }
        }

        protected void btnStoreRenovation_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                n++;
                string eventNoNow = EventNo();
                string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (DAL.StoresDAL.UpdateStores(txtStoreNo.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "998") > 0)
                {
                    if (DAL.EventLogsDAL.AddEventLogs(eventNoNow, timeNow, txtStoreNo.Text.Trim(), "8888", txtEventDescribe.Text.Trim(), txtToResolvedTime.Text.Trim(), "399", Session["userName"].ToString()) > 0)
                    {
                        DAL.EventStepsDAL.AddEventSteps(eventNoNow, "(创建事件)事件由 " + DAL.EventTypesDAL.GetEventLevelByTypeCode(txtTypeCode.Text.Trim()) + " 处理", timeNow, "0", Session["userName"].ToString());
                        string url = "NormalEvent.aspx?eventNo=" + eventNoNow + "&typeCode=8888";
                        Response.Redirect(url);
                    }
                    else
                    {
                        MsgBox("基础信息必须填写完整且正确!");
                    }
                }
                else
                {
                    MsgBox("该门店已在装修状态或不存在!");
                }
            }
        }

        public string EventNo()
        {
            //string nowTime = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()+DateTime.Now.Second.ToString();
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string eventNo = DAL.StoresDAL.GetRegionByStoreNo(txtStoreNo.Text.Trim()) + nowTime;
            return eventNo;
        }

        public string EventNo2()
        {
            //string nowTime = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()+DateTime.Now.Second.ToString();
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string eventNo = DAL.StoresDAL.GetRegionByStoreNo(txtStoreNo2.Text.Trim()) + nowTime;
            return eventNo;
        }

        public void MsgBox(string showMsg)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + showMsg + "');", true);
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        //protected void txtTypeCode_TextChanged(object sender, EventArgs e)
        //{
        //    lblTypeCodeText.Text = EventTypes(txtTypeCode.Text.Trim());
        //}

        //protected void txtStoreNo_TextChanged(object sender, EventArgs e)
        //{
        //    SqlDataReader reader = DAL.StoresDAL.GetStoresByStoreNo(txtStoreNo.Text.Trim());
        //    if (txtStoreNo.Text.Trim() != "")
        //    {
        //        if (!reader.Read())
        //        {
        //            lblStoreInfoText.Visible = true;
        //            btnStoreInfo.Visible = false;
        //        }
        //        else
        //        {
        //            lblStoreInfoText.Visible = false;
        //            btnStoreInfo.Visible = true;
        //        }
        //        reader.Close();
        //    }
        //    else
        //    {
        //        lblStoreInfoText.Visible = false;
        //        btnStoreInfo.Visible = false;
        //    }
        //    storeInformation.Visible = false;
        //}

        protected void txtStoreNo2_TextChanged(object sender, EventArgs e)
        {
            SqlDataReader reader = DAL.StoresDAL.GetStoresByStoreNo(txtStoreNo2.Text.Trim());
            if (txtStoreNo2.Text.Trim() != "")
            {
                if (!reader.Read())
                {
                    lblStoreTextOk.Visible = true;
                    lblStoreTextNo.Visible = false;
                }
                else
                {
                    lblStoreTextOk.Visible = false;
                    lblStoreTextNo.Visible = true;
                }
                reader.Close();
            }
            else
            {
                lblStoreTextOk.Visible = false;
                lblStoreTextNo.Visible = false;
            }
        }

        public string StoreInformationArray(int n)
        {
            try
            {
                SqlDataReader dr = DAL.StoresDAL.GetStoresByStoreNo(txtStoreNo.Text.Trim());
                dr.Read();
                string stores = dr[n].ToString();
                dr.Close();
                return stores;
            }
            catch
            {
                return "门店已关闭";
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

        public void gvEventDataBind()
        {
            gvEvent.Width = 990;
            gvEvent.DataSource = DAL.EventLogsDAL.GetTopTenEventLogsByStoreNo(txtStoreNo.Text.Trim());
            gvEvent.DataKeyNames = new string[] { "EventNo" };
            gvEvent.DataBind();
            if (gvEvent.HeaderRow != null)
            {
                gvEvent.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
                gvEvent.HeaderRow.Cells[1].Text = "<b>创建时间</b>";
                gvEvent.HeaderRow.Cells[2].Text = "<b>店号</b>";
                gvEvent.HeaderRow.Cells[3].Text = "<b>类型编号</b>";
                gvEvent.HeaderRow.Cells[4].Text = "<b>事件简述</b>";
                gvEvent.HeaderRow.Cells[5].Text = "<b>解决人/组织</b>";
                gvEvent.HeaderRow.Cells[6].Text = "<b>状态</b>";
                gvEvent.HeaderRow.Cells[7].Text = "<b>创建人</b>";
            }
        }

        public void gvFacilityBind()
        {
            gvFacility.Width = 1150;
            gvFacility.DataSource = DAL.StocksDAL.GetStocks("", txtStoreNo.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "");
            gvFacility.DataBind();
            if (gvFacility.HeaderRow != null)
            {
                gvFacility.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvFacility.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvFacility.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvFacility.HeaderRow.Cells[3].Text = "<b>参数</b>";
                gvFacility.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                gvFacility.HeaderRow.Cells[5].Text = "<b>标签码</b>";
                gvFacility.HeaderRow.Cells[6].Text = "<b>SAP号</b>";
                gvFacility.HeaderRow.Cells[7].Text = "<b>购买日期</b>";
                gvFacility.HeaderRow.Cells[8].Text = "<b>保修结束日期</b>";
                gvFacility.HeaderRow.Cells[9].Text = "<b>保修电话</b>";
                gvFacility.HeaderRow.Cells[10].Text = "<b>供应商</b>";
                gvFacility.HeaderRow.Cells[11].Text = "<b>入库时间</b>";
            }
        }

        protected void btnStoreInfo_Click(object sender, EventArgs e)
        {
            divStoreInformation.Visible = false;
            divgvEvent.Visible = false;
            divFacility.Visible = false;
            storeInformation.Visible = true;
            btnStoreInfo.Style["Display"] = "inline-block";
        }

        protected void btnStoreInformation_Click(object sender, EventArgs e)
        {
            divStoreInformation.Visible = true;
            divgvEvent.Visible = false;
            divFacility.Visible = false;
            LoadStoreInformation();
        }

        protected void btnStoreEvents_Click(object sender, EventArgs e)
        {
            divStoreInformation.Visible = false;
            divgvEvent.Visible = true;
            divFacility.Visible = false;
            gvEventDataBind();
        }

        protected void btnStoreFacility_Click(object sender, EventArgs e)
        {
            divStoreInformation.Visible = false;
            divgvEvent.Visible = false;
            divFacility.Visible = true;
            gvFacilityBind();
        }


        //public void MsgBox(string showMsg)
        //{
        //    Response.Write(" <script language=javascript> window.alert('" + showMsg + "'); </script>");
        //}
    }
}