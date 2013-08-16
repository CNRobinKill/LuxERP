using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class EventState : System.Web.UI.Page
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "15") == "0")
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

                                PostBackBind();
                            }
                            if (IsPostBack)
                            {
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

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public void PostBackBind()
        {
            gvSetUpShopStateBind();
            gvShutUpShopStateBind();
            gvStoreRenovationStateBind();
        }

        protected void btnAddSetUpShopState_Click(object sender, EventArgs e)
        {
            if (txtSetUpShopState.Text.Trim() != "" && txtSetUpShopStateDay.Text.Trim() != "")
            {
                DAL.EventStateDAL.AddEventState(txtSetUpShopState.Text.Trim(), int.Parse(txtSetUpShopStateDay.Text.Trim()), "1");
                txtSetUpShopState.Text = "";
                txtSetUpShopStateDay.Text = "";
            }
            else
            {
                MsgBox("请填写完整信息！");                
            }
            PostBackBind();
        }

        public void gvSetUpShopStateBind()
        {
            gvSetUpShopState.Width = 440;
            gvSetUpShopState.DataSource = DAL.EventStateDAL.GetEventState("1");
            gvSetUpShopState.DataKeyNames = new string[] { "StateID" };
            gvSetUpShopState.DataBind();
            if (gvSetUpShopState.HeaderRow != null)
            {
                gvSetUpShopState.HeaderRow.Cells[1].Text = "<b>状态</b>";
                gvSetUpShopState.HeaderRow.Cells[2].Text = "<b>提醒天数</b>";
                if (DAL.EventStateDAL.GetEventState("1").Tables[0].Rows.Count > 1)
                {
                    int row = gvSetUpShopState.Rows.Count - 1;
                    gvSetUpShopState.Rows[0].Cells[3].Text = "";
                    gvSetUpShopState.Rows[row - 1].Cells[4].Text = "";
                    gvSetUpShopState.Rows[row].Cells[3].Text = "";
                    gvSetUpShopState.Rows[row].Cells[4].Text = "";
                    gvSetUpShopState.Rows[row].Cells[5].Text = "";
                    gvSetUpShopState.Rows[row].Cells[6].Text = "";
                }
                else
                {
                    int row = gvSetUpShopState.Rows.Count - 1;
                    gvSetUpShopState.Rows[row].Cells[3].Text = "";
                    gvSetUpShopState.Rows[row].Cells[4].Text = "";
                    gvSetUpShopState.Rows[row].Cells[5].Text = "";
                    gvSetUpShopState.Rows[row].Cells[6].Text = "";
                }
            }
            
        }

        protected void gvSetUpShopState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == ("btnChangUp"))
            {
                DAL.EventStateDAL.ChangeUpEventState(int.Parse(gvSetUpShopState.DataKeys[int.Parse((string)e.CommandArgument)].Value.ToString()));
                PostBackBind();
            }
            if (e.CommandName.ToString() == ("btnChangDown"))
            {
                DAL.EventStateDAL.ChangeDownEventState(int.Parse(gvSetUpShopState.DataKeys[int.Parse((string)e.CommandArgument)].Value.ToString()));
                PostBackBind();
            }
        }

        protected void gvSetUpShopState_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSetUpShopState.EditIndex = e.NewEditIndex;
            PostBackBind();
        }

        protected void gvSetUpShopState_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {            
            try
            {
                string stateName = ((TextBox)gvSetUpShopState.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                int stateDay = int.Parse(((TextBox)gvSetUpShopState.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim());
                if (stateName == "")
                {
                    MsgBox("请填写完整！");
                }
                else
                {
                    DAL.EventStateDAL.UpdateEventStateByStateID(int.Parse(gvSetUpShopState.DataKeys[e.RowIndex].Value.ToString()), stateName, stateDay);
                    gvSetUpShopState.EditIndex = -1;
                    PostBackBind();
                }
            }
            catch
            {
                MsgBox("请填写正确数据！");
            }
        }

        protected void gvSetUpShopState_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSetUpShopState.EditIndex = -1;
            PostBackBind();
        }

        protected void gvSetUpShopState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.EventStateDAL.DelEventState("1", int.Parse(gvSetUpShopState.DataKeys[e.RowIndex].Value.ToString()));
            PostBackBind();
        }




        protected void btnAddShutUpShopState_Click(object sender, EventArgs e)
        {
            if (txtShutUpShopState.Text.Trim() != "" && txtShutUpShopStateDay.Text.Trim() != "")
            {
                DAL.EventStateDAL.AddEventState(txtShutUpShopState.Text.Trim(), int.Parse(txtShutUpShopStateDay.Text.Trim()), "2");
                txtShutUpShopState.Text = "";
                txtShutUpShopStateDay.Text = "";
            }
            else
            {
                MsgBox("请填写完整信息！");          
            }
            PostBackBind();
        }

        public void gvShutUpShopStateBind()
        {
            gvShutUpShopState.Width = 440;
            gvShutUpShopState.DataSource = DAL.EventStateDAL.GetEventState("2");
            gvShutUpShopState.DataKeyNames = new string[] { "StateID" };
            gvShutUpShopState.DataBind();
            if (gvShutUpShopState.HeaderRow != null)
            {
                gvShutUpShopState.HeaderRow.Cells[1].Text = "<b>状态</b>";
                gvShutUpShopState.HeaderRow.Cells[2].Text = "<b>提醒天数</b>";
                if (DAL.EventStateDAL.GetEventState("2").Tables[0].Rows.Count > 1)
                {
                    int row = gvShutUpShopState.Rows.Count - 1;
                    gvShutUpShopState.Rows[0].Cells[3].Text = "";
                    gvShutUpShopState.Rows[row - 1].Cells[4].Text = "";
                    gvShutUpShopState.Rows[row].Cells[3].Text = "";
                    gvShutUpShopState.Rows[row].Cells[4].Text = "";
                    gvShutUpShopState.Rows[row].Cells[5].Text = "";
                    gvShutUpShopState.Rows[row].Cells[6].Text = "";
                }
                else
                {
                    int row = gvShutUpShopState.Rows.Count - 1;
                    gvShutUpShopState.Rows[row].Cells[3].Text = "";
                    gvShutUpShopState.Rows[row].Cells[4].Text = "";
                    gvShutUpShopState.Rows[row].Cells[5].Text = "";
                    gvShutUpShopState.Rows[row].Cells[6].Text = "";
                }
            }
            
        }

        protected void gvShutUpShopState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == ("btnChangUp"))
            {
                DAL.EventStateDAL.ChangeUpEventState(int.Parse(gvShutUpShopState.DataKeys[int.Parse((string)e.CommandArgument)].Value.ToString()));
                PostBackBind();
            }
            if (e.CommandName.ToString() == ("btnChangDown"))
            {
                DAL.EventStateDAL.ChangeDownEventState(int.Parse(gvShutUpShopState.DataKeys[int.Parse((string)e.CommandArgument)].Value.ToString()));
                PostBackBind();
            }
        }

        protected void gvShutUpShopState_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShutUpShopState.EditIndex = e.NewEditIndex;
            PostBackBind();
        }

        protected void gvShutUpShopState_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {            
            try
            {
                string stateName = ((TextBox)gvShutUpShopState.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                int stateDay = int.Parse(((TextBox)gvShutUpShopState.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim());
                if (stateName == "")
                {
                    MsgBox("请填写完整！");
                }
                else
                {
                    DAL.EventStateDAL.UpdateEventStateByStateID(int.Parse(gvShutUpShopState.DataKeys[e.RowIndex].Value.ToString()), stateName, stateDay);
                    gvShutUpShopState.EditIndex = -1;
                    PostBackBind();
                }
            }
            catch
            {
                MsgBox("请填写正确数据！");
            }
        }

        protected void gvShutUpShopState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.EventStateDAL.DelEventState("2", int.Parse(gvShutUpShopState.DataKeys[e.RowIndex].Value.ToString()));
            PostBackBind();
        }

        protected void gvShutUpShopState_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShutUpShopState.EditIndex = -1;
            PostBackBind();
        }

        


        protected void btnAddStoreRenovationState_Click(object sender, EventArgs e)
        {
            if (txtStoreRenovationState.Text.Trim() != "" && txtStoreRenovationStateDay.Text.Trim() != "")
            {
                DAL.EventStateDAL.AddEventState(txtStoreRenovationState.Text.Trim(), int.Parse(txtStoreRenovationStateDay.Text.Trim()), "3");
                txtStoreRenovationState.Text = "";
                txtStoreRenovationStateDay.Text = "";
            }
            else
            {
                MsgBox("请填写完整信息！");                
            }
            PostBackBind();
        }

        public void gvStoreRenovationStateBind()
        {
            gvStoreRenovationState.Width = 440;
            gvStoreRenovationState.DataSource = DAL.EventStateDAL.GetEventState("3");
            gvStoreRenovationState.DataKeyNames = new string[] { "StateID" };
            gvStoreRenovationState.DataBind();
            if (gvStoreRenovationState.HeaderRow != null)
            {
                gvStoreRenovationState.HeaderRow.Cells[1].Text = "<b>状态</b>";
                gvStoreRenovationState.HeaderRow.Cells[2].Text = "<b>提醒天数</b>";
                if (DAL.EventStateDAL.GetEventState("3").Tables[0].Rows.Count > 1)
                {
                    int row = gvStoreRenovationState.Rows.Count - 1;
                    gvStoreRenovationState.Rows[0].Cells[3].Text = "";
                    gvStoreRenovationState.Rows[row - 1].Cells[4].Text = "";
                    gvStoreRenovationState.Rows[row].Cells[3].Text = "";
                    gvStoreRenovationState.Rows[row].Cells[4].Text = "";
                    gvStoreRenovationState.Rows[row].Cells[5].Text = "";
                    gvStoreRenovationState.Rows[row].Cells[6].Text = "";
                }
                else
                {
                    int row = gvStoreRenovationState.Rows.Count - 1;
                    gvStoreRenovationState.Rows[row].Cells[3].Text = "";
                    gvStoreRenovationState.Rows[row].Cells[4].Text = "";
                    gvStoreRenovationState.Rows[row].Cells[5].Text = "";
                    gvStoreRenovationState.Rows[row].Cells[6].Text = "";
                }
            }
            
        }

        protected void gvStoreRenovationState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == ("btnChangUp"))
            {
                DAL.EventStateDAL.ChangeUpEventState(int.Parse(gvStoreRenovationState.DataKeys[int.Parse((string)e.CommandArgument)].Value.ToString()));
                PostBackBind();
            }
            if (e.CommandName.ToString() == ("btnChangDown"))
            {
                DAL.EventStateDAL.ChangeDownEventState(int.Parse(gvStoreRenovationState.DataKeys[int.Parse((string)e.CommandArgument)].Value.ToString()));
                PostBackBind();
            }
        }

        protected void gvStoreRenovationState_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStoreRenovationState.EditIndex = e.NewEditIndex;
            PostBackBind();
        }

        protected void gvStoreRenovationState_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {            
            try
            {
                string stateName = ((TextBox)gvStoreRenovationState.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                int stateDay = int.Parse(((TextBox)gvStoreRenovationState.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim());
                if (stateName == "")
                {
                    MsgBox("请填写完整！");
                }
                else
                {
                    DAL.EventStateDAL.UpdateEventStateByStateID(int.Parse(gvStoreRenovationState.DataKeys[e.RowIndex].Value.ToString()), stateName, stateDay);
                    gvStoreRenovationState.EditIndex = -1;
                    PostBackBind();
                }
            }
            catch
            {
                MsgBox("请填写正确数据！");
            }
        }

        protected void gvStoreRenovationState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.EventStateDAL.DelEventState("3", int.Parse(gvStoreRenovationState.DataKeys[e.RowIndex].Value.ToString()));
            PostBackBind();
        }

        protected void gvStoreRenovationState_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStoreRenovationState.EditIndex = -1;
            PostBackBind();
        }


    }
}