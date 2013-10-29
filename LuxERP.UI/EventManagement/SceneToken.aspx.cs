using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LuxERP.UI.EventManagement
{
    public partial class SceneToken : System.Web.UI.Page
    {
        public static int pageSize = 30; // 每页行数
        public static int totalPage = 1; // 总页数
        public static int currentPage = 1; // 当前页
        public static TokenParameters paras;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userName"] == null)
            //{
            //    Response.Write("<script LANGUAGE=JavaScript >" +
            //           " alert('未登陆或已超时，请重新登录！');" +
            //           " window.location=('/LogOn.aspx');" +
            //           "</script>");
            //    Response.End();
            //}
            //else
            //{
            //    if (DAL.SystemUserDAL.GetUserIP(Session["userName"].ToString(), DAL.IPNetworking.GetIP4Address()) == "")
            //    {
            //        Response.Write("<script LANGUAGE=JavaScript >" +
            //            " alert('用户已在另外一台机器上登录！');" +
            //            " window.location=('/LogOn.aspx');" +
            //            "</script>");
            //        Response.End();
            //    }
            //    else
            //    {
            //        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "2") == "0")
            //        {
            //            Response.Write("<script LANGUAGE=JavaScript >" +
            //                " alert('没有权限，请联系管理员！');" +
            //                " window.location=('/LogOn.aspx');" +
            //                "</script>");
            //            Response.End();
            //        }
            //        try
            //        {
            if (!IsPostBack)
            {
                ddlServiceProviderShow();
                ddlSceneTypeShow();
            }
            //            if (IsPostBack)
            //            {
            //                RegisterJS("addRowStyle");
            //                RegisterJS("setDate");
            //            }
            //        }
            //        catch
            //        {
            //            Response.Redirect("~/Error.html");
            //        }
            //    }
            //}
        }

        public void ddlServiceProviderShow()
        {
            ddlServiceProvider.DataSource = DAL.SceneServiceProviderDAL.GetServiceProvider();
            ddlServiceProvider.DataValueField = "ServiceProvider";
            ddlServiceProvider.DataTextField = "ServiceProvider";
            ddlServiceProvider.DataBind();
        }

        public void ddlSceneTypeShow()
        {
            ddlSceneType.DataSource = DAL.SceneTypeDAL.GetTypeName();
            ddlSceneType.DataValueField = "TypeName";
            ddlSceneType.DataTextField = "TypeName";
            ddlSceneType.DataBind();
        }

        protected void ddlSceneType_DataBound(object sender, EventArgs e)
        {
            ddlSceneType.Items.Insert(0, "");
        }

        protected void ddlServiceProvider_DataBound(object sender, EventArgs e)
        {
            ddlServiceProvider.Items.Insert(0, "");
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        protected void btnTokenQuery_Click(object sender, EventArgs e)
        {
            paras = new TokenParameters();
            paras.eventNo = txtEventNo.Text.Trim();
            paras.sceneType = ddlSceneType.SelectedValue;
            paras.timeStartA = txtAServiceTime.Text.Trim() + " 00:00:00";
            paras.timeStartB = txtBServiceTime.Text.Trim() + " 23:59:59";
            paras.serviceProvider = ddlServiceProvider.SelectedValue;

            if (txtAServiceTime.Text.Trim() == "")
            {
                paras.timeStartA = "";
            }
            if (txtBServiceTime.Text.Trim() == "")
            {
                paras.timeStartB = "";
            }

            DataSet ds = DAL.TokenDAL.GetTokenTotal(paras.eventNo, paras.sceneType, paras.timeStartA, paras.timeStartB, paras.serviceProvider);
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > pageSize)
            {
                totalPage = (int)Math.Ceiling((double)rowsCount / (double)pageSize);
            }
            else
            {
                totalPage = 1;
            }

            GVDataBind(1);
        }

        public void GVDataBind(int pageidx)
        {
            string eventNo = paras.eventNo;
            string sceneType = paras.sceneType;
            string timeStartA = paras.timeStartA;
            string timeStartB = paras.timeStartB;
            string serviceProvider = paras.serviceProvider;
            DataSet source = DAL.TokenDAL.GetTokenPaged(eventNo,sceneType,timeStartA,timeStartB,serviceProvider, pageSize, pageidx);

            currentPage = pageidx;
            lblCurrent.Text = "第 " + currentPage.ToString() + " 页";
            lblTotalPages.Text = "共 " + totalPage.ToString() + " 页";

            gvToken.DataSource = source;
            gvToken.DataBind();
            gvToken.Width = 1000;
            if (gvToken.HeaderRow != null)
            {
                gvToken.HeaderRow.Cells[0].Text = "";
                gvToken.HeaderRow.Cells[1].Text = "<b>事件编号</b>";
                gvToken.HeaderRow.Cells[2].Text = "<b>开始上门</b>";
                gvToken.HeaderRow.Cells[3].Text = "<b>结束上门</b>";
                gvToken.HeaderRow.Cells[4].Text = "<b>上门类型</b>";
                gvToken.HeaderRow.Cells[5].Text = "<b>基数</b>";
                gvToken.HeaderRow.Cells[6].Text = "<b>倍率</b>";
                gvToken.HeaderRow.Cells[7].Text = "<b>合计</b>";
                gvToken.HeaderRow.Cells[8].Text = "<b>服务商</b>";
                gvToken.HeaderRow.Cells[9].Text = "";
                gvToken.HeaderRow.Cells[10].Text = "";
                showpage.Visible = true;
            }
            else
            { showpage.Visible = true; }
        }

        protected void gvToken_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string n = e.Row.Cells[10].Text.Trim();
            if (e.Row.Cells[10].Text.Trim() != "" && e.Row.Cells[10].Text.Trim() != "&nbsp;")
            {
                e.Row.Cells[10].Width = 80;
                e.Row.Cells[10].Text = "<a href='ShowPic.aspx?eventNo=" + e.Row.Cells[1].Text + "&n=1' target='_blank'>上门单</a>";
            }
            else
            {
                e.Row.Cells[10].Text = "<span style='font-color:red'>无</span>";
            }
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            GVDataBind(1);
        }

        protected void btnPrvPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                GVDataBind(currentPage - 1);
            }
        }

        protected void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                GVDataBind(currentPage + 1);
            }
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            GVDataBind(totalPage);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(txtCurPage.Text);
            if (n >= 1 && n <= totalPage)
            {
                GVDataBind(n);
            }
        }

    }

    public class TokenParameters
    {
        public string eventNo { get; set; }
        public string sceneType { get; set; }
        public string timeStartA { get; set; }
        public string timeStartB { get; set; }
        public string serviceProvider { get; set; }
    }
}