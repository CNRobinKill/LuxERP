using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LuxERP.UI.SystemInitial
{
    public partial class EventTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddTypeFour.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddTypeFour, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnAddTypeOne.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddTypeOne, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnAddTypeThree.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddTypeThree, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnAddTypeTwo.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddTypeTwo, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnCreateEventTypes.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnCreateEventTypes, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelTypeFour.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelTypeFour, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelTypeOne.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelTypeOne, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelTypeThree.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelTypeThree, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelTypeTwo.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelTypeTwo, "click") + ";this.disabled=true; this.value='处理中...';");

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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "11") == "0")
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

                                btnReturn.Visible = false;
                                typesManagement.Visible = false;
                                DdlTypeShow();
                                GvEventTypesDataBind();
                            }
                            lblEventTypesMessage.Text = null;

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

        protected void btnTypesManagement_Click(object sender, EventArgs e)
        {
            btnReturn.Visible = true;
            typesManagement.Visible = true;
            createEventTypes.Visible = false;

            lstTypeOne.Items.Clear();
            lstTypeTwo.Items.Clear();
            lstTypeThree.Items.Clear();
            lstTypeFour.Items.Clear();
            for (int i =0;i<DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows.Count;i++)
            {
                lstTypeOne.Items.Add(DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows.Count; i++)
            {
                lstTypeTwo.Items.Add(DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows.Count; i++)
            {
                lstTypeThree.Items.Add(DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows.Count; i++)
            {
                lstTypeFour.Items.Add(DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            btnReturn.Visible = false;
            typesManagement.Visible = false;
            createEventTypes.Visible = true;

            ddlTypeOne.Items.Clear();
            ddlTypeTwo.Items.Clear();
            ddlTypeThree.Items.Clear();
            ddlTypeFour.Items.Clear();
            ddlEventLevel.Items.Clear();
            DdlTypeShow();
        }

        protected void btnCreateEventTypes_Click(object sender, EventArgs e)
        {
            if (txtTypeCode.Text.Trim() != "" && ddlTypeOne.SelectedItem.Text != "")
            {
                if (DAL.EventTypesDAL.AddEventTypes(txtTypeCode.Text.Trim(), ddlTypeOne.SelectedValue, ddlTypeTwo.SelectedValue, ddlTypeThree.SelectedValue, ddlTypeFour.SelectedValue, ddlEventLevel.SelectedValue) > 0)
                {
                    DAL.SolutionsDAL.AddSolution(txtTypeCode.Text);
                }
            }
            else
            { lblEventTypesMessage.Text = "不能添加空值！"; }
            GvEventTypesDataBind();
        }

        protected void btnAddTypeOne_Click(object sender, EventArgs e)
        {
            if (txtTypeOne.Text.Trim() != "")
            {
                if (DAL.EventTypesDAL.AddTypeOne(txtTypeOne.Text) > 0)
                { }
                else
                { lblEventTypesMessage.Text = "该类已存在！"; }
            }
            else
            { lblEventTypesMessage.Text = "不能添加空值！"; }
            lstTypeOne.Items.Clear();
            txtTypeOne.Text = "";
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows.Count; i++)
            {
                lstTypeOne.Items.Add(DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnDelTypeOne_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.EventTypesDAL.DelTypeOne(lstTypeOne.SelectedItem.Text);
            }
            catch
            { lblEventTypesMessage.Text = "请选择要删除的项！"; }
            lstTypeOne.Items.Clear();
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows.Count; i++)
            {
                lstTypeOne.Items.Add(DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnAddTypeTwo_Click(object sender, EventArgs e)
        {
            if (txtTypeTwo.Text.Trim() != "")
            {
                if (DAL.EventTypesDAL.AddTypeTwo(txtTypeTwo.Text) > 0)
                { }
                else
                { lblEventTypesMessage.Text = "该类已存在"; }
            }
            else
            { lblEventTypesMessage.Text = "不能添加空值"; }
            lstTypeTwo.Items.Clear();
            txtTypeTwo.Text = "";
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows.Count; i++)
            {
                lstTypeTwo.Items.Add(DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnDelTypeTwo_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.EventTypesDAL.DelTypeTwo(lstTypeTwo.SelectedItem.Text);
            }
            catch
            { lblEventTypesMessage.Text = "请选择要删除的项！"; }
            lstTypeTwo.Items.Clear();
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows.Count; i++)
            {
                lstTypeTwo.Items.Add(DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnAddTypeThree_Click(object sender, EventArgs e)
        {
            if (txtTypeThree.Text.Trim() != "")
            {
                if (DAL.EventTypesDAL.AddTypeThree(txtTypeThree.Text) > 0)
                { }
                else
                { lblEventTypesMessage.Text = "该类已存在"; }
            }
            else
            { lblEventTypesMessage.Text = "不能添加空值"; }
            lstTypeThree.Items.Clear();
            txtTypeThree.Text = "";
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows.Count; i++)
            {
                lstTypeThree.Items.Add(DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnDelTypeThree_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.EventTypesDAL.DelTypeThree(lstTypeThree.SelectedItem.Text);
            }
            catch
            { lblEventTypesMessage.Text = "请选择要删除的项！"; }
            lstTypeThree.Items.Clear();
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows.Count; i++)
            {
                lstTypeThree.Items.Add(DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnAddTypeFour_Click(object sender, EventArgs e)
        {
            if (txtTypeFour.Text.Trim() != "")
            {
                if (DAL.EventTypesDAL.AddTypeFour(txtTypeFour.Text) > 0)
                { }
                else
                { lblEventTypesMessage.Text = "该类已存在"; }
            }
            else
            { lblEventTypesMessage.Text = "不能添加空值"; }
            lstTypeFour.Items.Clear();
            txtTypeFour.Text = "";
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows.Count; i++)
            {
                lstTypeFour.Items.Add(DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnDelTypeFour_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.EventTypesDAL.DelTypeFour(lstTypeFour.SelectedItem.Text);
            }
            catch
            { lblEventTypesMessage.Text = "请选择要删除的项！"; }
            lstTypeFour.Items.Clear();
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows.Count; i++)
            {
                lstTypeFour.Items.Add(DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows[i][0].ToString());
            }
        }

        public void GvEventTypesDataBind()
        {
            gvEventTypes.Width = 850;
            gvEventTypes.DataSource = DAL.EventTypesDAL.GetEventTypes();
            gvEventTypes.DataKeyNames = new string[] { "TypeCode" };
            gvEventTypes.DataBind();
            if (gvEventTypes.HeaderRow != null)
            {
                gvEventTypes.HeaderRow.Cells[0].Text = "<b>类型编号</b>";
                gvEventTypes.HeaderRow.Cells[1].Text = "<b>类型一</b>";
                gvEventTypes.HeaderRow.Cells[2].Text = "<b>类型二</b>";
                gvEventTypes.HeaderRow.Cells[3].Text = "<b>类型三</b>";
                gvEventTypes.HeaderRow.Cells[4].Text = "<b>类型四</b>";
                gvEventTypes.HeaderRow.Cells[5].Text = "<b>事件等级</b>";
            }
        }

        public void DdlTypeShow()
        {
            ddlTypeOne.Items.Add("");
            ddlTypeTwo.Items.Add("");
            ddlTypeThree.Items.Add("");
            ddlTypeFour.Items.Add("");
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows.Count; i++)
            {
                ddlTypeOne.Items.Add(DAL.EventTypesDAL.GetTypeOne().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows.Count; i++)
            {
                ddlTypeTwo.Items.Add(DAL.EventTypesDAL.GetTypeTwo().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows.Count; i++)
            {
                ddlTypeThree.Items.Add(DAL.EventTypesDAL.GetTypeThree().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows.Count; i++)
            {
                ddlTypeFour.Items.Add(DAL.EventTypesDAL.GetTypeFour().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.SynthesisDAL.GetSolver().Tables[0].Rows.Count; i++)
            {
                ddlEventLevel.Items.Add(DAL.SynthesisDAL.GetSolver().Tables[0].Rows[i][0].ToString());
            }
            
        }

        protected void gvEventTypes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DAL.SolutionsDAL.DelSolution(gvEventTypes.DataKeys[e.RowIndex].Value.ToString()) > 0)
            {
                DAL.EventTypesDAL.DelEventTypes(gvEventTypes.DataKeys[e.RowIndex].Value.ToString());
            }
            GvEventTypesDataBind();
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }
    }
}