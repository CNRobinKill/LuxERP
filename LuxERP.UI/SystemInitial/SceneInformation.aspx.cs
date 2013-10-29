using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class SceneInformation : System.Web.UI.Page
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
                    if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "21") == "0")
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

                            gvSceneTypeBind();
                            gvMultiplyingPowerTypeBind();
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

        public Boolean returnbool(string f)
        {
            try
            {
                float i = float.Parse(f);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void gvSceneTypeBind()
        {
            gvSceneType.Width = 450;
            gvSceneType.DataSource = DAL.SceneTypeDAL.GetSceneType();
            gvSceneType.DataKeyNames = new string[] { "TypeName" };
            gvSceneType.DataBind();
            if (gvSceneType.HeaderRow != null)
            {
                gvSceneType.HeaderRow.Cells[0].Text = "<b>上门类型</b>";
                gvSceneType.HeaderRow.Cells[1].Text = "<b>基数</b>";
                gvSceneType.HeaderRow.Cells[2].Text = "<b>计算模式</b>";
            }
        }

        public void gvMultiplyingPowerTypeBind()
        {
            gvMultiplyingPowerType.Width = 300;
            gvMultiplyingPowerType.DataSource = DAL.MultiplyingPowerTypeDAL.GetMultiplyingPowerType();
            gvMultiplyingPowerType.DataKeyNames = new string[] { "TypeName" };
            gvMultiplyingPowerType.DataBind();
            if (gvMultiplyingPowerType.HeaderRow != null)
            {
                gvMultiplyingPowerType.HeaderRow.Cells[0].Text = "<b>倍率类型</b>";
                gvMultiplyingPowerType.HeaderRow.Cells[1].Text = "<b>倍率</b>";
            }
        }

        protected void btnAddIndoorServiceType_Click(object sender, EventArgs e)
        {
            if (txtIndoorServiceTypeName.Text.Trim() != "" && txtBaseToken.Text.Trim() != "")
            {
                string baseToken = txtBaseToken.Text.Trim();
                if (returnbool(baseToken))
                {
                    DAL.SceneTypeDAL.AddSceneType(txtIndoorServiceTypeName.Text.Trim(), baseToken, ddlComputingMethod.SelectedValue);
                }
            }
            gvSceneTypeBind();
        }

        protected void gvSceneType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.SceneTypeDAL.DelSceneType(gvSceneType.DataKeys[e.RowIndex].Value.ToString());
            gvSceneTypeBind();
        }

        protected void btnAddMultiplyingPowerType_Click(object sender, EventArgs e)
        {
            if (txtMultiplyingPowerType.Text.Trim() != "" && txtMultiplyingPower.Text.Trim()!="")
            {
                string multiplyingPower = txtMultiplyingPower.Text.Trim();
                if (returnbool(multiplyingPower))
                {
                    DAL.MultiplyingPowerTypeDAL.AddMultiplyingPowerType(txtMultiplyingPowerType.Text.Trim(), multiplyingPower);
                }
            }
            gvMultiplyingPowerTypeBind();
        }

        protected void gvMultiplyingPowerType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DAL.MultiplyingPowerTypeDAL.DelMultiplyingPowerType(gvMultiplyingPowerType.DataKeys[e.RowIndex].Value.ToString());
            gvMultiplyingPowerTypeBind();
        }

    }
}