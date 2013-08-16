using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.SystemInitial
{
    public partial class FacilityManage : System.Web.UI.Page
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
                        if (DAL.PermissionDAL.GetOnePermission(Session["userName"].ToString(), "12") == "0")
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

                                InitialMachingListBox();
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Error.html");
                        }
                    }
                }
            
        }

        public void MsgBox(string message)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "msg", "alert('" + message + "');", true);
        }

        public void InitialMachingListBox()
        {
            lstMaching.Items.Clear();
            for (int i = 0; i < DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows.Count; i++)
            {
                lstMaching.Items.Add(DAL.FacilityDAL.GetMachingFromFacility().Tables[0].Rows[i][0].ToString());
            }
        }

        protected void btnAddFacility_Click(object sender, EventArgs e)
        {
            string maching = "";
            string brand = "";
            string model = "";
            string para = "";
            if (txtMaching.Text.Trim() == "")
            { maching = lstMaching.SelectedValue; }
            else
            { maching = txtMaching.Text.Trim(); }

            if (txtBrand.Text.Trim() == "")
            { brand = lstBrand.SelectedValue; }
            else
            { brand = txtBrand.Text.Trim(); }

            if (txtModel.Text.Trim() == "")
            { model = lstModel.SelectedValue; }
            else
            { model = txtModel.Text.Trim(); }

            //if (txtPara.Text.Trim() == "")
            //{ para = lstPara.SelectedValue; }
            //else
            para = txtPara.Text.Trim();
            if (maching == "" || brand == "" || model == "" || para == "")
            {
                MsgBox("添加数据条件不完整，请检查！");
            }
            else
            {
                if (DAL.FacilityDAL.AddFacility(maching, brand, model, para) > 0)
                { MsgBox("添加数据成功！"); }
                else
                { MsgBox("检测到已有相同的数据！"); }
            }
            InitialMachingListBox();
            lstBrand.Items.Clear();
            lstModel.Items.Clear();
            lstPara.Items.Clear();
            txtMaching.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtPara.Text = "";
        }

        protected void btnDelFacility_Click(object sender, EventArgs e)
        {
            string maching = "";
            string brand = "";
            string model = "";
            string para = "";

            if (lstMaching.SelectedValue != null)
            { maching = lstMaching.SelectedValue; }
            if (lstBrand.SelectedValue != null)
            { brand = lstBrand.SelectedValue; }
            if (lstModel.SelectedValue != null)
            { model = lstModel.SelectedValue; }
            if (lstPara.SelectedValue != null)
            { para = lstPara.SelectedValue; }

            if (maching == "" || brand == "" || model == "" || para == "")
            {
                MsgBox("选择要删除的数据！");
            }
            else
            {
                if (DAL.FacilityDAL.DelFacility(maching, brand, model, para) > 0)
                { MsgBox("删除数据成功！"); }
                else
                { MsgBox("该数据已不存在！"); }
            }
            InitialMachingListBox();
            lstBrand.Items.Clear();
            lstModel.Items.Clear();
            lstPara.Items.Clear();
        }

        protected void lstMaching_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBrand.Items.Clear();
            lstModel.Items.Clear();
            lstPara.Items.Clear();
            for (int i = 0; i < DAL.FacilityDAL.GetBrandFromFacility(lstMaching.SelectedValue).Tables[0].Rows.Count; i++)
            {
                lstBrand.Items.Add(DAL.FacilityDAL.GetBrandFromFacility(lstMaching.SelectedValue).Tables[0].Rows[i][0].ToString());
            }
        }

        protected void lstBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstModel.Items.Clear();
            lstPara.Items.Clear();
            for (int i = 0; i < DAL.FacilityDAL.GetModelFromFacility(lstMaching.SelectedValue, lstBrand.SelectedValue).Tables[0].Rows.Count; i++)
            {
                lstModel.Items.Add(DAL.FacilityDAL.GetModelFromFacility(lstMaching.SelectedValue, lstBrand.SelectedValue).Tables[0].Rows[i][0].ToString());
            }
        }

        protected void lstModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPara.Items.Clear();
            for (int i = 0; i < DAL.FacilityDAL.GetParameterFromFacility(lstMaching.SelectedValue, lstBrand.SelectedValue, lstModel.SelectedValue).Tables[0].Rows.Count; i++)
            {
                lstPara.Items.Add(DAL.FacilityDAL.GetParameterFromFacility(lstMaching.SelectedValue, lstBrand.SelectedValue, lstModel.SelectedValue).Tables[0].Rows[i][0].ToString());
            }
        }


    }
}