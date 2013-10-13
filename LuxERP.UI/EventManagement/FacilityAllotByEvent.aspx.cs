using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.UI.EventManagement
{
    public partial class FacilityAllotByEvent : System.Web.UI.Page
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
                        try
                        {
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
                                gvFacility.Visible = false;
                                divAddStoreFacilities.Visible = false;
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

                                gvFacilitiesFlittingBind();
                                gvExpressBind();
                                for (int i = 0; i < DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows.Count; i++)
                                {
                                    ddlExpressCo.Items.Add(DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows[i][0].ToString());
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

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        protected void btnReturnEventQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("NormalEvent.aspx?eventNo=" + Request.QueryString["eventNo"] + "&typeCode=" + Request.QueryString["typeCode"]);
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

        public void gvFacilitiesFlittingBind()
        {
            gvFacilitiesFlitting.Width = 1050;
            gvFacilitiesFlitting.DataSource = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], Request.QueryString["storeNo"], "", "", "", "", "", "", "", "", "", "1", "");
            gvFacilitiesFlitting.DataKeyNames = new string[] { "ID" };
            gvFacilitiesFlitting.DataBind();
            if (gvFacilitiesFlitting.HeaderRow != null)
            {
                gvFacilitiesFlitting.HeaderRow.Cells[0].Text = "<b>机器名称</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[1].Text = "<b>品牌</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[2].Text = "<b>型号</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[3].Text = "<b>参数</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[4].Text = "<b>序列号</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[5].Text = "<b>标签码</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[6].Text = "<b>SAP号</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[7].Text = "<b>购买日期</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[8].Text = "<b>保修结束日期</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[9].Text = "<b>保修电话</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[10].Text = "<b>供应商</b>";
                gvFacilitiesFlitting.HeaderRow.Cells[11].Text = "<b>出库时间</b>"; 
                if (DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], Request.QueryString["storeNo"], "", "", "", "", "", "", "", "", "", "1", "").Tables[0].Rows.Count == 0)
                {
                    noFlittingText.Visible = true;
                    btnReSet.Visible = false;
                    divAddExpress.Visible = false;
                    noExpressText.Visible = true;
                }
                else
                { 
                    noFlittingText.Visible = false; 
                    btnReSet.Visible = true; 
                    gvExpressBind(); 
                }
            }
            else
            {
                noFlittingText.Visible = true;
                btnReSet.Visible = false;
                divAddExpress.Visible = false;
                noExpressText.Visible = true;
            }
        }

        public void gvExpressBind()
        {
            gvExpress.Width = 400;
            gvExpress.DataSource = DAL.ExpressDAL.GetExpressByEventNo(Request.QueryString["eventNo"], 1);
            gvExpress.DataKeyNames = new string[] { "ID" };
            gvExpress.DataBind();
            int rowCount = DAL.ExpressDAL.GetExpressByEventNo(Request.QueryString["eventNo"], 1).Tables[0].Rows.Count;
            if (gvExpress.HeaderRow != null)
            {
                gvExpress.HeaderRow.Cells[0].Text = "<b>快递公司</b>";
                gvExpress.HeaderRow.Cells[1].Text = "<b>快递单号</b>";
                gvExpress.HeaderRow.Cells[3].Text = "";
                if (rowCount == 0)
                {
                    divAddExpress.Visible = false;
                    divtxtStockNo.Visible = false;
                    noExpressText.Visible = true;
                    noCheckFacilityText.Visible = true;
                    gvCheckFacility.CssClass = "stylevisibilityh";
                    btnAddAllAllotStock.Visible = false;
                }
                else
                {
                    if (gvExpress.Rows[rowCount - 1].Cells[2].Text == "0")
                    {
                        divAddExpress.Visible = true;
                        noExpressText.Visible = false;
                        noCheckFacilityText.Visible = true;
                        divtxtStockNo.Visible = false;
                        gvCheckFacility.CssClass = "stylevisibilityh";
                        btnAddAllAllotStock.Visible = false;
                    }
                    else
                    {
                        noExpressText.Visible = false;
                        divAddExpress.Visible = false;
                        noCheckFacilityText.Visible = false;
                        divtxtStockNo.Visible = true;
                        gvCheckFacility.CssClass = "stylevisibilityv";
                        btnAddAllAllotStock.Visible = true;
                        gvCheckFacilityBind();
                    }
                    divFacilitiesFlitting.Visible = false;

                }
            }
            else
            {
                if (gvFacilitiesFlitting.HeaderRow != null)
                {
                    divAddExpress.Visible = true;
                    noExpressText.Visible = false;
                }
                else
                {
                    divAddExpress.Visible = false;
                    noExpressText.Visible = true;
                }
                divtxtStockNo.Visible = false;
                noCheckFacilityText.Visible = true;
                gvCheckFacility.CssClass = "stylevisibilityh";
                btnAddAllAllotStock.Visible = false;

            }
            gvExpress.Columns[2].Visible = false;
        }

        public void gvCheckFacilityBind()
        {
            gvCheckFacility.Width = 580;
            DataView dv = new DataView();
            dv.Table = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "1", "").Tables[0];
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
                if (DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "1", "").Tables[0].Rows.Count == 0)
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

        public void gvHistoryBind()
        {
            gvHistory.Width = 1000;
            gvHistory.DataSource = DAL.AllotStocksDAL.GetAllotStocks(Request.QueryString["eventNo"]);
            gvHistory.DataBind();
            if (gvHistory.HeaderRow != null)
            {
                gvHistory.HeaderRow.Cells[0].Text = "<b>发送门店</b>";
                gvHistory.HeaderRow.Cells[1].Text = "<b>接收仓库</b>";
                gvHistory.HeaderRow.Cells[2].Text = "<b>机器名称</b>";
                gvHistory.HeaderRow.Cells[3].Text = "<b>品牌</b>";
                gvHistory.HeaderRow.Cells[4].Text = "<b>型号</b>";
                gvHistory.HeaderRow.Cells[5].Text = "<b>参数</b>";
                gvHistory.HeaderRow.Cells[6].Text = "<b>序列号</b>";
                gvHistory.HeaderRow.Cells[7].Text = "<b>调拨时间</b>";
                gvHistory.HeaderRow.Cells[8].Text = "<b>调拨情况</b>";
            }

        }

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

        protected void btnAddStoreFacilities(string strRowID)
        {
            //string id = strRowID.Substring(1, strRowID.Length - 1);
            DAL.StocksDAL.UpdateStocksMutualFacilityAllot(Request.QueryString["eventNo"], strRowID);
            RegisterJS("clean");
            gvFacilitiesFlittingBind();
        }

        protected void btnReSet_Click(object sender, EventArgs e)
        {
            DAL.StocksDAL.DelStocksMutualFacilityAllot(Request.QueryString["eventNo"]);
            gvFacilitiesFlittingBind();
        }

        protected void gvExpress_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            gvExpress.Columns[2].Visible = true;
            if (e.Row.Cells[2].Text == "0")
            {
                e.Row.Cells[3].Width = 100;
                e.Row.Cells[3].Text = "已失效";
            }
            if (e.Row.Cells[2].Text != "0" && DAL.AllotStocksDAL.GetAllotStocks(Request.QueryString["eventNo"]).Tables[0].Rows.Count != 0)
            {
                e.Row.Cells[3].Width = 100;
                e.Row.Cells[3].Text = "已签收";
            }
        }

        protected void gvHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[8].Text == "0")
            {
                e.Row.Cells[8].Text = "已签收";
            }
            if (e.Row.Cells[8].Text == "1")
            {
                e.Row.Cells[8].Text = "寄运异常";
                e.Row.Cells[8].CssClass = "allotstocks";
            }
        }

        protected void btnAddExpress_Click(object sender, EventArgs e)
        {
            if (txtExpressNo.Text.Trim() != "")
            {
                DAL.ExpressDAL.AddExpress(Request.QueryString["eventNo"], ddlExpressCo.SelectedValue, txtExpressNo.Text.Trim(), 1, 1);
                DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(返库调拨)设备使用 " + ddlExpressCo.SelectedValue + "/单号" + txtExpressNo.Text.Trim() + " 寄回", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
                gvExpressBind();
                divFacilitiesFlitting.Visible = false;
            }
        }

        protected void gvExpress_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DAL.ExpressDAL.UpdateExpressState(int.Parse(gvExpress.DataKeys[e.NewSelectedIndex].Value.ToString()), 0);
            DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(返库调拨)特殊原因 " + gvExpress.Rows[e.NewSelectedIndex].Cells[0].Text.Trim() + "/单号" + gvExpress.Rows[e.NewSelectedIndex].Cells[1].Text.Trim() + " 失效", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
            gvExpressBind();
        }

        protected void btnAddAllAllotStock_Click(object sender, EventArgs e)
        {
            if (txtStockNo.Text.Trim() != "")
            {
                DAL.AllotStocksDAL.AddAllAllotStocksFromStocks(Request.QueryString["eventNo"], txtStockNo.Text.ToString().Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session["userName"].ToString(), "0");
                if (DAL.AllotStocksDAL.GetCountAllotStocksState(Request.QueryString["eventNo"]) == 0)
                {
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(返库调拨)仓库" + txtStockNo.Text.ToString().Trim() + " 已签收全部设备", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
                }
                gvExpressBind();
                gvCheckFacilityBind();
            }
        }

        protected void gvCheckFacility_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (txtStockNo.Text.Trim() != "")
            {
                if (DAL.AllotStocksDAL.GetCountAllotStocksState(Request.QueryString["eventNo"]) == 0)
                {
                    DAL.EventStepsDAL.AddEventSteps(Request.QueryString["eventNo"], "(返库调拨)已完毕，有设备在寄送 仓库" + txtStockNo.Text.ToString().Trim() + " 途中出现异常", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "0", Session["userName"].ToString());
                }
                DAL.AllotStocksDAL.AddAllotStocksFromStocks(gvCheckFacility.DataKeys[e.NewSelectedIndex].Value.ToString(), txtStockNo.Text.ToString().Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Session["userName"].ToString(), "1", "设备返库寄运中出现事故 相关事件号：" + Request.QueryString["eventNo"]);
                gvExpressBind();
                gvCheckFacilityBind();
            }
        }

    }
}