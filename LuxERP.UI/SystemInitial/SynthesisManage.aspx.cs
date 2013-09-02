using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class SynthesisManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnAddExpressCo.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddExpressCo, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnAddSolver.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddSolver, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnAddSupplier.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnAddSupplier, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelExpressCo.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelExpressCo, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelSolver.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelSolver, "click") + ";this.disabled=true; this.value='处理中...';");
            this.btnDelSupplier.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(btnDelSupplier, "click") + ";this.disabled=true; this.value='处理中...';");
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "14") == "0")
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

                                InitialListBox();
                                gvSolverBind();
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

        public void InitialListBox()
        {
            for (int i = 0; i < DAL.SynthesisDAL.GetSolver().Tables[0].Rows.Count; i++)
            {
                lstSolver.Items.Add(DAL.SynthesisDAL.GetSolver().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows.Count; i++)
            {
                lstExpressCo.Items.Add(DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows[i][0].ToString());
            }
            for (int i = 0; i < DAL.SynthesisDAL.GetSupplier().Tables[0].Rows.Count; i++)
            {
                lstSupplier.Items.Add(DAL.SynthesisDAL.GetSupplier().Tables[0].Rows[i][0].ToString());
            }
        }


        public void gvSolverBind()
        {
            gvSolver.Width = 1000;
            gvSolver.DataSource = DAL.SynthesisDAL.GetAllSolver();
            gvSolver.DataKeyNames = new string[] { "Solver" };
            gvSolver.DataBind();
            if (gvSolver.HeaderRow != null)
            {
                gvSolver.HeaderRow.Cells[0].Text = "<b>解决人/组织</b>";
                gvSolver.HeaderRow.Cells[1].Text = "<b>联系邮箱</b>";
                gvSolver.HeaderRow.Cells[2].Text = "<b>SMTP地址</b>";
                gvSolver.HeaderRow.Cells[3].Text = "<b>邮箱密码</b>";
                gvSolver.HeaderRow.Cells[4].Text = "<b>发送通知</b>";
            }
        }

        protected void btnAddSolver_Click(object sender, EventArgs e)
        {
            if (txtSolver.Text.Trim() != "")
            {
                DAL.SynthesisDAL.AddSolver(txtSolver.Text.Trim());
                lstSolver.Items.Clear();
                for (int i = 0; i < DAL.SynthesisDAL.GetSolver().Tables[0].Rows.Count; i++)
                {
                    lstSolver.Items.Add(DAL.SynthesisDAL.GetSolver().Tables[0].Rows[i][0].ToString());
                }
            }
            txtSolver.Text = "";
            gvSolverBind();
        }

        protected void btnDelSolver_Click(object sender, EventArgs e)
        {
            if (lstSolver.SelectedItem.Text != "")
            {
                DAL.SynthesisDAL.DelSolver(lstSolver.SelectedValue);
                lstSolver.Items.Clear();
                for (int i = 0; i < DAL.SynthesisDAL.GetSolver().Tables[0].Rows.Count; i++)
                {
                    lstSolver.Items.Add(DAL.SynthesisDAL.GetSolver().Tables[0].Rows[i][0].ToString());
                }
            }
            gvSolverBind();
        }

        protected void btnAddExpressCo_Click(object sender, EventArgs e)
        {
            if (txtExpressCo.Text.Trim() != "")
            {
                DAL.SynthesisDAL.AddExpressCo(txtExpressCo.Text.Trim());
                lstExpressCo.Items.Clear();
                for (int i = 0; i < DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows.Count; i++)
                {
                    lstExpressCo.Items.Add(DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows[i][0].ToString());
                }
            }
            txtExpressCo.Text = "";
        }

        protected void btnDelExpressCo_Click(object sender, EventArgs e)
        {
            if (lstExpressCo.SelectedItem.Text != "")
            {
                DAL.SynthesisDAL.DelExpressCo(lstExpressCo.SelectedValue);
                lstExpressCo.Items.Clear();
                for (int i = 0; i < DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows.Count; i++)
                {
                    lstExpressCo.Items.Add(DAL.SynthesisDAL.GetExpressCo().Tables[0].Rows[i][0].ToString());
                }
            }
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (txtSupplier.Text.Trim() != "")
            {
                DAL.SynthesisDAL.AddSupplier(txtSupplier.Text.Trim());
                lstSupplier.Items.Clear();
                for (int i = 0; i < DAL.SynthesisDAL.GetSupplier().Tables[0].Rows.Count; i++)
                {
                    lstSupplier.Items.Add(DAL.SynthesisDAL.GetSupplier().Tables[0].Rows[i][0].ToString());
                }
            }
            txtSupplier.Text = "";
        }

        protected void btnDelSupplier_Click(object sender, EventArgs e)
        {
            if (lstSupplier.SelectedItem.Text != "")
            {
                DAL.SynthesisDAL.DelSupplier(lstSupplier.SelectedValue);
                lstSupplier.Items.Clear();
                for (int i = 0; i < DAL.SynthesisDAL.GetSupplier().Tables[0].Rows.Count; i++)
                {
                    lstSupplier.Items.Add(DAL.SynthesisDAL.GetSupplier().Tables[0].Rows[i][0].ToString());
                }
            }
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public void RegisterJS(string method)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), method, method + "();", true);
        }

        protected void gvSolver_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSolver.EditIndex = e.NewEditIndex;
            gvSolverBind();
        }

        protected void gvSolver_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Solver = gvSolver.Rows[e.RowIndex].Cells[0].Text.Trim();
            string Email = ((TextBox)gvSolver.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
            string SMTP = ((TextBox)gvSolver.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
            string EPassword = ((TextBox)gvSolver.Rows[e.RowIndex].Cells[3].Controls[0]).Text.Trim();
            string Note = ((DropDownList)gvSolver.Rows[e.RowIndex].Cells[4].FindControl("ddlNote")).SelectedValue;
            //if (Email == "" && SMTP == "" && EPassword == "")
            //{
            //    MsgBox("请填写完整！");
            //}
            //else
            //{
                DAL.SynthesisDAL.UpdateSolver(Solver, Email, SMTP, EPassword, Note);
                gvSolver.EditIndex = -1;
                gvSolverBind();
            //}
        }

        protected void gvSolver_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSolver.EditIndex = -1;
            gvSolverBind();
        }

        protected void gvSolver_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[2].Text == "" || e.Row.Cells[3].Text == "")
            {
                e.Row.Cells[6].Text = "";
            }
            if (((DropDownList)e.Row.FindControl("ddlNote")) != null)
            {
                DropDownList ddlNote = (DropDownList)e.Row.FindControl("ddlNote");
                //  生成 DropDownList 的值，也可以取得数据库中的数据绑定
                ddlNote.Items.Clear();
                ddlNote.Items.Add("");
                for (int i = 0; i < DAL.SynthesisDAL.GetSolver().Tables[0].Rows.Count; i++)
                {
                    ddlNote.Items.Add(DAL.SynthesisDAL.GetSolver().Tables[0].Rows[i][0].ToString());
                }
                ddlNote.SelectedValue = ((HiddenField)e.Row.FindControl("hdNote")).Value;
            }
        }

        protected void gvSolver_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
                string mailTo = gvSolver.Rows[e.NewSelectedIndex].Cells[1].Text.Trim();
                string email = gvSolver.Rows[e.NewSelectedIndex].Cells[1].Text.Trim();
                string mailServer = gvSolver.Rows[e.NewSelectedIndex].Cells[2].Text.Trim();
                string ePassword = gvSolver.Rows[e.NewSelectedIndex].Cells[3].Text.Trim();
                string mailToName = gvSolver.Rows[e.NewSelectedIndex].Cells[0].Text.Trim();
                string emailBody = "这是由IIRIS发出的一个测试邮件！";
                if (DAL.SendEmail.SendMail(email, mailServer, ePassword, 25, mailTo, mailToName, "IIRIS系统邮件", emailBody) == true)
                {
                    MsgBox("测试成功！");
                }
                else
                {
                    MsgBox("测试失败！");
                }
                gvSolverBind();
        }
    }
}