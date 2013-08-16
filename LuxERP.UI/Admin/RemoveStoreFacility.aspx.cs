using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.Admin
{
    public partial class RemoveStoreFacility : System.Web.UI.Page
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "18") == "0")
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
                            }
                            else
                            {
                                RegisterJS("setTableColor");
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        protected void btnReturnUserManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserManage.aspx");
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public void gvFacilityBind(string storeNo)
        {
            gvFacility.Width = 1100;
            gvFacility.DataSource = DAL.StocksDAL.GetStocks("", storeNo, "", "", "", "", "", "", "", "", "", "", "");
            gvFacility.DataKeyNames = new string[] { "ID" };
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

        protected void gvFacility_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.StocksDAL.DelStocks(gvFacility.DataKeys[e.RowIndex].Value.ToString());
            gvFacilityBind(txtStoreNo.Text.Trim());
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtStoreNo.Text.Trim() != "")
            {
                gvFacilityBind(txtStoreNo.Text.Trim());
            }
            else
            {
                MsgBox("请输入门店号");
            }
        }
    }
}