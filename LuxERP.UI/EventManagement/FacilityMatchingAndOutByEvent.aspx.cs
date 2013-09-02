using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace LuxERP.UI.EventManagement
{
    public partial class FacilityMatchingAndOutByEvent : System.Web.UI.Page
    {
        public static int intDemandNo;
        public static string stMaching;
        public static string stBrand; 
        public static string stModel;
        public static string stParameter;
        public static string stRow;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddAllOutStock.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddAllOutStock, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnAddExpress.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddExpress, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnAddOutStockDemands.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddOutStockDemands, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelPic.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelPic, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnSendStockIn.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnSendStockIn, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnUpload.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnUpload, "click") + ";this.disabled=true; this.value='处理中...';");

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

                                gvExpressBind();
                                if (gvExpress.HeaderRow == null)
                                {
                                    //DdlShow();
                                    InitialDll();
                                    gvOutStockDemandsBind();
                                    if (gvOutStockDemands.HeaderRow == null)
                                    {
                                        noRecordsText2.Visible = true;
                                        noCheckFacilityText.Visible = true;
                                    }
                                }
                                else
                                {
                                    divFacilityList.Visible = false;
                                }
                                gvMatchingResultsBind();
                                if (gvMatchingResults.HeaderRow == null)
                                {
                                    noRecordsText1.Visible = true;
                                    noExpressText.Visible = true;
                                    noCheckFacilityText.Visible = true;
                                }
                                gvNoMatchingBind();
                                if (gvNoMatching.HeaderRow != null)
                                {
                                    noExpressText.Visible = true;
                                    noCheckFacilityText.Visible = true;
                                }
                                gvExpressBind();
                                for (int i = 0; i < DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows.Count; i++)
                                {
                                    ddlExpressCo.Items.Add(DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows[i][0].ToString());
                                }
                                //if (divAddExpress.Visible == true)
                                //{
                                //    noCheckFacilityText.Visible = true;
                                //}
                            }
                            if (IsPostBack)
                            {
                                RegisterJS("addRowStyle");
                                //RegisterJS("setDivStyle");
                                RegisterJS("setDate");
                                gvFacility.Visible = false;
                                if (gvMatchingResults.HeaderRow != null)
                                {
                                    gvMatchingResults.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                                    gvMatchingResults.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                                    gvMatchingResults.HeaderRow.Cells[2].Text = "<b>型号</b>";
                                    gvMatchingResults.HeaderRow.Cells[3].Text = "<b>参数</b>";
                                    gvMatchingResults.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                                    gvMatchingResults.HeaderRow.Cells[5].Text = "<b>购买日期</b>";
                                    gvMatchingResults.HeaderRow.Cells[6].Text = "<b>保修结束日期</b>";
                                    gvMatchingResults.HeaderRow.Cells[7].Text = "<b>保修电话</b>";
                                    gvMatchingResults.HeaderRow.Cells[8].Text = "<b>供应商</b>";
                                    gvMatchingResults.HeaderRow.Cells[9].Text = "<b>入库时间</b>";
                                }
                                divChkOld.Style.Value = "width:100px; height:20px; padding: 10px; font-size: 13px; visibility:hidden";
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        protected void btnReturnEventQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("NormalEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&typeCode=" + Request.QueryString["typeCode"]);
        }

        public void MsgBox(string showMsg)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + showMsg + "');", true);
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        protected void btnAddOutStockDemands_Click(object sender, EventArgs e)
        {
            string eventNo = Request.QueryString["eventNo"];
            string maching = ddlMaching.SelectedValue;
            string brand = ddlBrand.SelectedValue;
            string model = ddlModel.SelectedValue;
            string parameter = ddlParameter.SelectedValue;
            if (maching == "" || brand == "" || model == "" || parameter == "")
            { 
                MsgBox("请选择所需要的设备！"); 
            }
            else
            {
                DAL.OutStockDemandsDAL.AddOutStockDemands(eventNo, maching, brand, model, parameter);
            }
            gvOutStockDemandsBind();
        }

        public string SendEmailInfo(int n)
        {
            SqlDataReader dr = DAL.SynthesisDAL.GetStockIn("库存管理员");
            dr.Read();
            string emailInfo = dr[n].ToString();
            dr.Close();
            return emailInfo;
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

        public void gvOutStockDemandsBind()
        {
            gvOutStockDemands.Width = 650;
            gvOutStockDemands.DataSource = DAL.OutStockDemandsDAL.GetOutStockDemandsByEventNo(Request.QueryString["eventNo"]);
            int rowCount = DAL.OutStockDemandsDAL.GetOutStockDemandsByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count;
            gvOutStockDemands.DataKeyNames = new string[] { "DemandNo" };
            gvOutStockDemands.DataBind();
            if (gvOutStockDemands.HeaderRow != null)
            {
                gvOutStockDemands.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvOutStockDemands.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvOutStockDemands.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvOutStockDemands.HeaderRow.Cells[3].Text = "<b>参数</b>";
                if (rowCount == 0)
                {
                    noRecordsText2.Visible = true;
                    divbtnMatching.Visible = false; 
                }
                else
                {                   
                    noRecordsText2.Visible = false;
                    divbtnMatching.Visible = true;
                }
            }
            
        }

        public void gvNoMatchingBind()
        {
            gvNoMatching.Width = 500;
            gvNoMatching.DataSource = DAL.OutStockDemandsDAL.GetNoMatchingByEventNo(Request.QueryString["eventNo"]);
            gvNoMatching.DataKeyNames = new string[] { "DemandNo" };
            gvNoMatching.DataBind();
            if (gvNoMatching.HeaderRow != null)
            {
                gvNoMatching.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvNoMatching.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvNoMatching.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvNoMatching.HeaderRow.Cells[3].Text = "<b>参数</b>";
                if (DAL.OutStockDemandsDAL.GetNoMatchingByEventNo(Request.QueryString["eventNo"]).Tables[0].Rows.Count == 0)
                {
                    imgMatchingNo.Visible = false;
                    btnSendStockIn.Visible = false;
                    noExpressText.Visible = false;
                    divAddExpress.Visible = true;
                }
                else
                {
                    imgMatchingNo.Visible = true;
                    btnSendStockIn.Visible = true;
                    noExpressText.Visible = true;
                    noCheckFacilityText.Visible = true;
                    divAddExpress.Visible = false;
                }
            }

        }

        public void gvMatchingResultsBind()
        {
            gvMatchingResults.Width = 980;
            DataView dv = new DataView();
            dv.Table = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "0", "").Tables[0];
            dv.Sort = "Maching asc";
            gvMatchingResults.DataSource = dv;
            gvMatchingResults.DataBind();
            if (gvMatchingResults.HeaderRow != null)
            {
                gvMatchingResults.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvMatchingResults.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvMatchingResults.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvMatchingResults.HeaderRow.Cells[3].Text = "<b>参数</b>";
                gvMatchingResults.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                gvMatchingResults.HeaderRow.Cells[5].Text = "<b>购买日期</b>";
                gvMatchingResults.HeaderRow.Cells[6].Text = "<b>保修结束日期</b>";
                gvMatchingResults.HeaderRow.Cells[7].Text = "<b>保修电话</b>";
                gvMatchingResults.HeaderRow.Cells[8].Text = "<b>供应商</b>";
                gvMatchingResults.HeaderRow.Cells[9].Text = "<b>入库时间</b>";
                if (DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "0", "").Tables[0].Rows.Count == 0)
                {
                    imgMatchingOk.Visible = false;
                    divPrint.Visible = false;
                    noRecordsText1.Visible = true;
                    divAddExpress.Visible = false;
                    noExpressText.Visible = true;
                }
                else
                {
                    noRecordsText1.Visible = false;
                    imgMatchingOk.Visible = true;
                    divPrint.Visible = true;
                    divAddExpress.Visible = true;
                    noExpressText.Visible = false;
                }
            }

        }

        public void gvCheckFacilityBind()
        {
            gvCheckFacility.Width = 580;
            DataView dv = new DataView();
            dv.Table = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "0", "").Tables[0];
            gvCheckFacility.DataKeyNames = new string[] { "ID" };
            dv.Sort = "Maching asc";
            gvCheckFacility.DataSource = dv;
            gvCheckFacility.DataBind();
            if (gvCheckFacility.HeaderRow != null)
            {
                gvCheckFacility.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvCheckFacility.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvCheckFacility.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvCheckFacility.HeaderRow.Cells[3].Text = "<b>参数</b>";
                gvCheckFacility.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                if (DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "0", "").Tables[0].Rows.Count == 0)
                {
                    divCheckFacility.Visible = false;
                    divHistory.Visible = true;
                    gvHistoryBind();
                } 
            }
            else
            {
                divCheckFacility.Visible = false;
                divHistory.Visible = true;
                gvHistoryBind();
            }

        }

        protected void gvOutStockDemands_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.OutStockDemandsDAL.DelOutStockDemands(gvOutStockDemands.DataKeys[e.RowIndex].Value.ToString());
            gvOutStockDemandsBind();
            gvMatchingResultsBind();
            gvNoMatchingBind();
            gvExpressBind();
        }

        protected void btnMatching_Click(object sender, EventArgs e)
        {
            if (chkOldMatching.Checked == true)
            {
                DAL.StocksDAL.UpdateStocksMutualOutStockDemands(Request.QueryString["eventNo"], "1");
            }
            else
            {
                DAL.StocksDAL.UpdateStocksMutualOutStockDemands(Request.QueryString["eventNo"], "0");
            }
            gvMatchingResultsBind();
            gvNoMatchingBind();         
            if (gvMatchingResults.HeaderRow != null)
            {
                imgMatchingOk.Visible = true;
            }
        }
        
        public void gvExpressBind()
        {
            gvExpress.Width = 400;
            gvExpress.DataSource = DAL.ExpressDAL.GetExpressByEventNo(Request.QueryString["eventNo"], 0);
            gvExpress.DataKeyNames = new string[] { "ID" };
            gvExpress.DataBind();
            int rowCount = DAL.ExpressDAL.GetExpressByEventNo(Request.QueryString["eventNo"], 0).Tables[0].Rows.Count;
            if (gvExpress.HeaderRow != null)
            {
                gvExpress.HeaderRow.Cells[0].Text = "<b>快递公司</b>";
                gvExpress.HeaderRow.Cells[1].Text = "<b>快递单号</b>";
                gvExpress.HeaderRow.Cells[3].Text = "";
                if (rowCount == 0)
                {
                    noCheckFacilityText.Visible = true;
                    divAddExpress.Visible = false;
                    noExpressText.Visible = true;
                    gvCheckFacility.CssClass = "stylevisibilityh";
                    btnAddAllOutStock.Visible = false;
                }
                else
                {
                    if (gvExpress.Rows[rowCount - 1].Cells[2].Text == "0")
                    {
                        divAddExpress.Visible = true;
                        noCheckFacilityText.Visible = true;
                        btnAddAllOutStock.Visible = false;
                        gvCheckFacility.CssClass = "stylevisibilityh";
                        divMatchingResults.Visible = true;
                    }
                    else
                    {

                        divAddExpress.Visible = false;
                        noExpressText.Visible = false;
                        noCheckFacilityText.Visible = false;
                        gvCheckFacility.CssClass = "stylevisibilityv";
                        btnAddAllOutStock.Visible = true;
                        divMatchingResults.Visible = false;
                        btnAddAllOutStock.Visible = true;
                        gvCheckFacilityBind(); 
                    }

                }
            }
            if (rowCount == 0)
            {
                noCheckFacilityText.Visible = true;
                divAddExpress.Visible = false;
                noExpressText.Visible = true;
                gvCheckFacility.CssClass = "stylevisibilityh";
                btnAddAllOutStock.Visible = false;
            }
            gvExpress.Columns[2].Visible = false;
        }

        public void gvHistoryBind()
        {
            gvHistory.Width = 1000;
            gvHistory.DataSource = DAL.OutStocksDAL.GetOutStocks(Request.QueryString["eventNo"]);
            gvHistory.DataBind();
            if (gvHistory.HeaderRow != null)
            {
                gvHistory.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvHistory.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvHistory.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvHistory.HeaderRow.Cells[3].Text = "<b>参数</b>";
                gvHistory.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                gvHistory.HeaderRow.Cells[5].Text = "<b>购买日期</b>";
                gvHistory.HeaderRow.Cells[6].Text = "<b>保修结束日期</b>";
                gvHistory.HeaderRow.Cells[7].Text = "<b>保修电话</b>";
                gvHistory.HeaderRow.Cells[8].Text = "<b>供应商</b>";
                gvHistory.HeaderRow.Cells[9].Text = "<b>出库时间</b>";
                gvHistory.HeaderRow.Cells[10].Text = "<b>出库情况</b>";
                if (DAL.OutStocksDAL.GetOutStocks(Request.QueryString["eventNo"]).Tables[0].Rows.Count == 0)
                {
                    divUpload.Visible = false;
                }
                else
                {
                    divUpload.Visible = true;
                    if (DAL.EventLogsDAL.GetPic(Request.QueryString["eventNo"], "0") != "")
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

        protected void btnAddExpress_Click(object sender, EventArgs e)
        {
            if (txtExpressNo.Text.Trim() != "")
            {
                DAL.ExpressDAL.AddExpress(Request.QueryString["eventNo"], ddlExpressCo.SelectedValue, txtExpressNo.Text.Trim(), 0, 1);
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(匹配出库)设备使用 " + ddlExpressCo.SelectedValue + "/单号" + txtExpressNo.Text.Trim() + " 寄出", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
                gvExpressBind();
                divFacilityList.Visible = false;
            }
        }

        protected void gvExpress_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            gvExpress.Columns[2].Visible = true;
            if (e.Row.Cells[2].Text == "0")
            {
                e.Row.Cells[3].Width = 100;
                e.Row.Cells[3].Text = "已失效";
            }
            if (e.Row.Cells[2].Text != "0" && DAL.OutStocksDAL.GetOutStocks(Request.QueryString["eventNo"]).Tables[0].Rows.Count != 0)
            {
                e.Row.Cells[3].Width = 100;
                e.Row.Cells[3].Text = "已签收";
            }
        }

        protected void gvExpress_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        { 
            DAL.ExpressDAL.UpdateExpressState(int.Parse(gvExpress.DataKeys[e.NewSelectedIndex].Value.ToString()), 0);
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(匹配出库)特殊原因 " + gvExpress.Rows[e.NewSelectedIndex].Cells[0].Text.Trim() + "/单号" + gvExpress.Rows[e.NewSelectedIndex].Cells[1].Text.Trim() + " 失效", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            gvExpressBind();
        }

        public void gvFacilityBind()
        {
            divChkOld.Visible = true;
            gvFacility.Width = 980;
            if (chkOld.Checked == false)
            {
                gvFacility.DataSource = DAL.StocksDAL.GetStocks("0", "", stMaching, stBrand, stModel, stParameter, "", "", "", "", "", "0", "0");
            }
            else
            {
                gvFacility.DataSource = DAL.StocksDAL.GetStocks("0", "", stMaching, stBrand, stModel, stParameter, "", "", "", "", "", "0", "1");
            }
            gvFacility.DataKeyNames = new string[] { "ID" };
            gvFacility.DataBind();
            if (gvFacility.HeaderRow != null)
            {
                gvFacility.HeaderRow.Cells[1].Text = "<b>机器名称</b>";
                gvFacility.HeaderRow.Cells[2].Text = "<b>品牌</b>";
                gvFacility.HeaderRow.Cells[3].Text = "<b>型号</b>";
                gvFacility.HeaderRow.Cells[4].Text = "<b>参数</b>";
                gvFacility.HeaderRow.Cells[5].Text = "<b>序列号</b>";
                gvFacility.HeaderRow.Cells[6].Text = "<b>购买日期</b>";
                gvFacility.HeaderRow.Cells[7].Text = "<b>保修结束日期</b>";
                gvFacility.HeaderRow.Cells[8].Text = "<b>保修电话</b>";
                gvFacility.HeaderRow.Cells[9].Text = "<b>供应商</b>";
                gvFacility.HeaderRow.Cells[10].Text = "<b>入库时间</b>";
            }
        }

        protected void gvOutStockDemands_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvFacility.Visible = true;
            int idx = e.NewSelectedIndex;
            intDemandNo = int.Parse(gvOutStockDemands.DataKeys[idx].Value.ToString());
            stRow = idx.ToString();
            labRow.Text = stRow;
            stMaching = gvOutStockDemands.Rows[idx].Cells[0].Text.Trim();
            stBrand = gvOutStockDemands.Rows[idx].Cells[1].Text.Trim();
            stModel = gvOutStockDemands.Rows[idx].Cells[2].Text.Trim();
            stParameter = gvOutStockDemands.Rows[idx].Cells[3].Text.Trim();
            gvFacilityBind();
            divChkOld.Style.Value = "width:100px; height:20px; padding: 10px; font-size: 13px;";
            RegisterJS("showDialog");
        }

        protected void gvFacility_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int idx = e.NewSelectedIndex;
            DAL.OutStockDemandsDAL.UptateOutStockDemands(int.Parse(gvFacility.DataKeys[idx].Value.ToString()), Request.QueryString["eventNo"], intDemandNo);
            gvMatchingResultsBind();
            gvNoMatchingBind();
        }

        protected void btnAddAllOutStock_Click(object sender, EventArgs e)
        {
            DAL.OutStocksDAL.AddAllOutStocksFromStocks(Request.QueryString["eventNo"], Request.QueryString["storeNo"], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session["userName"].ToString(), "0");
            if (DAL.OutStocksDAL.GetCountOutStocksState(Request.QueryString["eventNo"]) == 0)
            {
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(匹配出库)门店已签收全部设备", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            }
            gvExpressBind();
            gvCheckFacilityBind();
        }

        protected void gvCheckFacility_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (DAL.OutStocksDAL.GetCountOutStocksState(Request.QueryString["eventNo"]) == 0)
            {
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(匹配出库)已完毕，有设备在寄送中出现异常", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            }
            DAL.OutStocksDAL.AddOutStocksFromStocks(gvCheckFacility.DataKeys[e.NewSelectedIndex].Value.ToString(), Request.QueryString["storeNo"], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session["userName"].ToString(), "1", "设备出库寄运中出现事故 相关事件号：" + Request.QueryString["eventNo"]);
            gvExpressBind();
            gvCheckFacilityBind();
            
        }

        protected void gvHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[10].Text == "0")
            {
                e.Row.Cells[10].Text = "已签收";
            }
            if (e.Row.Cells[10].Text == "1")
            {
                e.Row.Cells[10].Text = "寄运异常";
                e.Row.Cells[10].CssClass = "outstocks";
            }
        }

        public void InitialDll()
        {
            ddlMaching.Items.Clear();
            ddlMaching.Items.Add("");
            for (int i = 0; i < DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows.Count; i++)
            {
                ddlMaching.Items.Add(DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows[i][0].ToString());
            }
            //ddlSupplier.Items.Clear();
            //ddlSupplier.Items.Add("");
            //for (int i = 0; i < DAL.SynthesisDAL.GetSupplier().Tables[0].Rows.Count; i++)
            //{
            //    ddlSupplier.Items.Add(DAL.SynthesisDAL.GetSupplier().Tables[0].Rows[i][0].ToString());
            //}
            ddlBrand.Items.Add("");
            ddlModel.Items.Add("");
            ddlParameter.Items.Add("");
        }


        protected void ddlMaching_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMaching.SelectedValue == "")
            {
                ddlBrand.Items.Clear();
                ddlModel.Items.Clear();
                ddlParameter.Items.Clear();
                ddlBrand.Items.Add("");
                ddlModel.Items.Add("");
                ddlParameter.Items.Add("");
            }
            else
            {
                ddlBrand.Items.Clear();
                ddlBrand.Items.Add("");
                for (int i = 0; i < DAL.FacilityDAL.GetBrandFromFacility(ddlMaching.SelectedValue).Tables[0].Rows.Count; i++)
                {
                    ddlBrand.Items.Add(DAL.FacilityDAL.GetBrandFromFacility(ddlMaching.SelectedValue).Tables[0].Rows[i][0].ToString());
                }
                ddlModel.Items.Clear();
                ddlParameter.Items.Clear();
                ddlModel.Items.Add("");
                ddlParameter.Items.Add("");
            }
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedValue == "")
            {
                ddlModel.Items.Clear();
                ddlParameter.Items.Clear();
                ddlModel.Items.Add("");
                ddlParameter.Items.Add("");
            }
            else
            {
                ddlModel.Items.Clear();
                ddlModel.Items.Add("");
                for (int i = 0; i < DAL.FacilityDAL.GetModelFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue).Tables[0].Rows.Count; i++)
                {
                    ddlModel.Items.Add(DAL.FacilityDAL.GetModelFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue).Tables[0].Rows[i][0].ToString());
                }
                ddlParameter.Items.Clear();
                ddlParameter.Items.Add("");
            }
        }

        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModel.SelectedValue == "")
            {
                ddlParameter.Items.Clear();
                ddlParameter.Items.Add("");
            }
            else
            {
                ddlParameter.Items.Clear();
                ddlParameter.Items.Add("");
                for (int i = 0; i < DAL.FacilityDAL.GetParameterFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue, ddlModel.SelectedValue).Tables[0].Rows.Count; i++)
                {
                    ddlParameter.Items.Add(DAL.FacilityDAL.GetParameterFromFacility(ddlMaching.SelectedValue, ddlBrand.SelectedValue, ddlModel.SelectedValue).Tables[0].Rows[i][0].ToString());
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "openWorkOrder", "window.open('OutOrder.aspx?eventNo=" + Request.QueryString["eventNo"] + "&storeNo=" + Request.QueryString["storeNo"] + "','','scrollbars=yes');", true);
        }

        protected void btnSendStockIn_Click(object sender, EventArgs e)
        {
            string eventNo = Request.QueryString["eventNo"];
            string typeCode= Request.QueryString["typeCode"];
            string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string mailTo = SendEmailInfo(3);
            if (mailTo != "")
            {
                string email = SendEmailInfo(0);
                string mailServer = SendEmailInfo(1);
                string ePassword = SendEmailInfo(2);
                string mailToName = SendEmailInfo(4);


                string emailBody = "&nbsp; &nbsp; 你好，" + mailToName + "：<div>&nbsp; &nbsp; 当前有一个门店需要寄送设备，但由于库存不足，需要入库。</div><div>&nbsp; &nbsp; &nbsp; &nbsp;门店编号：" + Request.QueryString["storeNo"] + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;事件编号：" + eventNo + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;发送时间：" + timeNow + "</div><div>&nbsp; &nbsp; &nbsp; &nbsp;设备入库需求：</div><div>" + GridViewToHtml(gvNoMatching) + "</div><div>&nbsp; &nbsp; 我们将会继续进行跟踪！</div><div><br></div><div><br></div><div><br></div><div><font color='#ff3333'>该内容由IIRIS系统发出，如有疑问请回复邮件咨询！谢谢！</font></div>";
                if (DAL.SendEmail.SendMail(email, mailServer, ePassword, 25, mailTo, mailToName, "IIRIS系统邮件", emailBody) == true)
                {
                    DAL.EventStepsDAL.AddEventSteps(eventNo, "(匹配出库)已成功向" + mailToName + "发送 设备入库申请 邮件", timeNow, "0", Session["userName"].ToString());
                    MsgBox("发送成功！");
                }
                else
                {
                    DAL.EventStepsDAL.AddEventSteps(eventNo, "(匹配出库)SMTP服务器无法接通，向" + mailToName + "发送邮件失败，请手动发送或使用其它方式联系", timeNow, "0", Session["userName"].ToString());
                    MsgBox("发送失败！");
                }
            }
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
                    DAL.EventLogsDAL.UpdateUpLoadPic(eventNo, newName, "");
                    fuFile.SaveAs(path + newName);        //保存到服务器上了。
                    uploado.Visible = false;
                    uploadt.Visible = true; 
                }
            }
        }

        protected void btnShowPic_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "openShowPic", "window.open('ShowPic.aspx?eventNo=" + Request.QueryString["eventNo"] + "&n=0 ','','scrollbars=yes');", true);
        }

        protected void btnDelPic_Click(object sender, EventArgs e)
        {
            uploado.Visible = true;
            uploadt.Visible = false;         
        }

    }
}