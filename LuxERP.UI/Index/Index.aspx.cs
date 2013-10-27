using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.Index
{
    public partial class Index : System.Web.UI.Page
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "0") == "0")
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

                                lblCountNormalEvents.Text = DAL.IndexDAL.CountNormalEventLog().ToString();
                                lblCountSetUpShopEvents.Text = DAL.IndexDAL.CountSetUpShopEventLog().ToString();
                                lblCountShutUpShopEvents.Text = DAL.IndexDAL.CountShutUpShopEventLog().ToString();
                                lblCountStoreRenovationEvents.Text = DAL.IndexDAL.CountStoreRenovationEventLog().ToString();
                                gvNormalEventDataBind("0",Session["userName"].ToString());
                                gvSetUpShopEventDataBind();
                                gvShutUpShopEventDataBind();
                                gvStoreRenovationEventDataBind();
                                ddlLogBy.Items.Add("我创建的事件");
                                ddlLogBy.Items.Add("其他人创建的事件");
                                ddlLogBy.Items.Add("已转出的事件");
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }         
        }

        public void gvNormalEventDataBind(string temp,string logBy)
        {
            gvNormalEvent.Width = 1050;
            gvNormalEvent.DataSource = DAL.IndexDAL.GetUrgentNormalEventLog(temp,logBy);
            gvNormalEvent.DataBind();
            if (gvNormalEvent.HeaderRow != null)
            {
                gvNormalEvent.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
                gvNormalEvent.HeaderRow.Cells[1].Text = "<b>创建时间</b>";
                gvNormalEvent.HeaderRow.Cells[2].Text = "<b>店号</b>";
                gvNormalEvent.HeaderRow.Cells[3].Text = "<b>类型编号</b>";
                gvNormalEvent.HeaderRow.Cells[4].Text = "<b>执行步骤</b>";
                gvNormalEvent.HeaderRow.Cells[5].Text = "<b>状态</b>";
                gvNormalEvent.HeaderRow.Cells[6].Text = "<b>创建人</b>";
                if (DAL.IndexDAL.GetUrgentNormalEventLog(temp, logBy).Tables[0].Rows.Count == 0)
                {
                    nogvNormalEvent.Visible = true;
                }
                else
                {
                    nogvNormalEvent.Visible = false;
                }
            }
            else
            {

                    nogvNormalEvent.Visible = true;

            }
        }

        public void gvSetUpShopEventDataBind()
        {
            gvSetUpShopEvent.Width = 1050;
            gvSetUpShopEvent.DataSource = DAL.IndexDAL.GetUrgentSetUpShopEventLog();
            gvSetUpShopEvent.DataBind();
            if (gvSetUpShopEvent.HeaderRow != null)
            {
                gvSetUpShopEvent.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
                gvSetUpShopEvent.HeaderRow.Cells[1].Text = "<b>创建时间</b>";
                gvSetUpShopEvent.HeaderRow.Cells[2].Text = "<b>店号</b>";
                gvSetUpShopEvent.HeaderRow.Cells[3].Text = "<b>类型编号</b>";
                gvSetUpShopEvent.HeaderRow.Cells[4].Text = "<b>执行步骤</b>";
                gvSetUpShopEvent.HeaderRow.Cells[5].Text = "<b>开店日期</b>";
                gvSetUpShopEvent.HeaderRow.Cells[6].Text = "<b>状态</b>";
                gvSetUpShopEvent.HeaderRow.Cells[7].Text = "<b>创建人</b>";
            }
            else
            {
                nogvSetUpShopEvent.Visible = true;
            }
        }

        public void gvShutUpShopEventDataBind()
        {
            gvShutUpShopEvent.Width = 1050;
            gvShutUpShopEvent.DataSource = DAL.IndexDAL.GetUrgentShutUpShopEventLog();
            gvShutUpShopEvent.DataBind();
            if (gvShutUpShopEvent.HeaderRow != null)
            {
                gvShutUpShopEvent.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
                gvShutUpShopEvent.HeaderRow.Cells[1].Text = "<b>创建时间</b>";
                gvShutUpShopEvent.HeaderRow.Cells[2].Text = "<b>店号</b>";
                gvShutUpShopEvent.HeaderRow.Cells[3].Text = "<b>类型编号</b>";
                gvShutUpShopEvent.HeaderRow.Cells[4].Text = "<b>执行步骤</b>";
                gvShutUpShopEvent.HeaderRow.Cells[5].Text = "<b>关店日期</b>";
                gvShutUpShopEvent.HeaderRow.Cells[6].Text = "<b>状态</b>";
                gvShutUpShopEvent.HeaderRow.Cells[7].Text = "<b>创建人</b>";
            }
            else
            {
                nogvShutUpShopEvent.Visible = true;
            }
        }

        public void gvStoreRenovationEventDataBind()
        {
            gvStoreRenovationEvent.Width = 1050;
            gvStoreRenovationEvent.DataSource = DAL.IndexDAL.GetUrgentStoreRenovationEventLog();
            gvStoreRenovationEvent.DataBind();
            if (gvStoreRenovationEvent.HeaderRow != null)
            {
                gvStoreRenovationEvent.HeaderRow.Cells[0].Text = "<b>事件编号</b>";
                gvStoreRenovationEvent.HeaderRow.Cells[1].Text = "<b>创建时间</b>";
                gvStoreRenovationEvent.HeaderRow.Cells[2].Text = "<b>店号</b>";
                gvStoreRenovationEvent.HeaderRow.Cells[3].Text = "<b>类型编号</b>";
                gvStoreRenovationEvent.HeaderRow.Cells[4].Text = "<b>执行步骤</b>";
                gvStoreRenovationEvent.HeaderRow.Cells[5].Text = "<b>结束日期</b>";
                gvStoreRenovationEvent.HeaderRow.Cells[6].Text = "<b>状态</b>";
                gvStoreRenovationEvent.HeaderRow.Cells[7].Text = "<b>创建人</b>";
            }
            else
            {
                nogvStoreRenovationEvent.Visible = true;
            }
        }

        protected void ddlLogBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLogBy.SelectedValue == "我创建的事件")
            {
                gvNormalEventDataBind("0", Session["userName"].ToString());
            }
            if (ddlLogBy.SelectedValue == "其他人创建的事件")
            {
                gvNormalEventDataBind("1", Session["userName"].ToString());
            }
            if (ddlLogBy.SelectedValue == "已转出的事件")
            {
                gvNormalEventDataBind("2", Session["userName"].ToString());
            }
        }
    }
}