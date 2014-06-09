using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.StoreInformation
{
    public partial class StoreInformation : System.Web.UI.Page
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "10") == "0")
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
                            if (IsPostBack)
                            {
                                RegisterJS("addRowStyle");
                                RegisterJS("setDate");
                                gvFacility.Visible = false;
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

        public void SetDDLValue(string ddlID, string hiddenID, GridViewRowEventArgs e)
        {
            DropDownList ddl;
            if (((DropDownList)e.Row.FindControl(ddlID)) != null)
            {
                ddl = (DropDownList)e.Row.FindControl(ddlID);
                ddl.SelectedValue = ((HiddenField)e.Row.FindControl(hiddenID)).Value;
            }
        }

        public void GVDataBind()
        {
            string storeNo = txtStoreNo.Text.Trim();
            //string topStore = ddlTopStore.SelectedValue;
            string storeType = ddlStoreType.SelectedValue;
            string region = txtRegion.Text.Trim();
            string storeTel = txtStoreTel.Text.Trim();
            string storeName = txtStoreName.Text.Trim();
            //string rating = ddlRating.SelectedValue;
            //string opeingDateF = txtOpeingDateF.Text.Trim();
            //string opeingDateT = txtOpeingDateT.Text.Trim();
            string storeState = ddlStoreState.SelectedValue;

            gvStores.DataSource = DAL.StoresDAL.GetStores(storeNo, storeType, region, storeTel, storeName, storeState);
            gvStores.DataKeyNames = new string[] { "StoreNo" };
            gvStores.DataBind();
            gvStores.Width = 1120;
            if (gvStores.HeaderRow != null)
            {
                gvStores.HeaderRow.Cells[1].Text = "<b>店号</b>";
                gvStores.HeaderRow.Cells[2].Text = "<b>店铺类型</b>";
                gvStores.HeaderRow.Cells[3].Text = "<b>区域</b>";
                gvStores.HeaderRow.Cells[4].Text = "<b>店铺名称</b>";
                gvStores.HeaderRow.Cells[5].Text = "<b>城市</b>";
                gvStores.HeaderRow.Cells[6].Text = "<b>电话</b>";
                gvStores.HeaderRow.Cells[7].Text = "<b>宽带账号</b>";
                gvStores.HeaderRow.Cells[8].Text = "<b>地址</b>";
                gvStores.HeaderRow.Cells[9].Text = "<b>店铺状态</b>";
            }
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        protected void txtQuery_Click(object sender, EventArgs e)
        {
            GVDataBind();
        }

        protected void gvStores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStores.EditIndex = e.NewEditIndex;            
            GVDataBind();            
        }

        protected void gvStores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SetDDLValue("ddlTopStoreE", "hdTopStore", e);
            SetDDLValue("ddlStoreTypeE", "hdStoreType", e);
            SetDDLValue("ddlRatingE", "hdRating", e);
            //SetDDLValue("ddlStoreStateE", "hdStoreState", e);
            if (e.Row.Cells[8].Text == "已关店")
            {
                e.Row.Cells[9].Text = "";
                e.Row.Cells[10].Text = "";
            }
        }

        protected void gvStores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string storeNo = ((TextBox)gvStores.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string storeType = ((DropDownList)gvStores.Rows[e.RowIndex].Cells[2].FindControl("ddlStoreTypeE")).SelectedValue;
            string region = ((TextBox)gvStores.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string storeName = ((TextBox)gvStores.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string city = ((TextBox)gvStores.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string storeTel = ((TextBox)gvStores.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            string aDSLNo = ((TextBox)gvStores.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
            string storeAddress = ((TextBox)gvStores.Rows[e.RowIndex].Cells[8].Controls[0]).Text;

            if (storeNo == "" || region == "")
            {
                MsgBox("店号，区域，开店日期不能为空！");
            }
            else
            {
                DAL.StoresDAL.UpdateStores(storeNo, storeType, region, storeName, city, storeAddress, storeTel, aDSLNo, "", "", "");
                gvStores.EditIndex = -1;
                GVDataBind();
            }         
        }

        protected void gvStores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStores.EditIndex = -1;
            GVDataBind();            
        }

        public void gvFacilityBind(string storeNo)
        {
            gvFacility.Width = 1165;
            gvFacility.DataSource = DAL.StocksDAL.GetStocks("", storeNo, "", "", "", "", "", "", "", "", "", "", "");          
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
                gvFacility.HeaderRow.Cells[12].Text = "<b>相关事件</b>";
            }
        }

        protected void gvStores_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
            gvFacility.Visible = true;
            int idx =  e.NewSelectedIndex;
            string storeNo = gvStores.Rows[idx].Cells[1].Text;
            facility.Attributes.Remove("title");
            facility.Attributes.Add("title", storeNo+"设备信息");
            
            gvFacilityBind(storeNo);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.Page.GetType(), "showDialog", "showDialog();", true);            
        }        
    }
}