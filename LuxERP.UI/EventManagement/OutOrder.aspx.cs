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
    public partial class OutOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblStoreNo.Text = Request.QueryString["storeNo"];
                lblDate.Text = DateTime.Now.ToString("yyyy / MM / dd");
                gvMatchingResultsBind();
            }
        }

        public void gvMatchingResultsBind()
        {
            gvMatchingResults.Width = 650;
            DataView dv = new DataView();
            dv.Table = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "0", "").Tables[0];
            dv.Sort = "Maching asc";
            gvMatchingResults.DataSource = dv;
            gvMatchingResults.DataBind();
            if (gvMatchingResults.HeaderRow != null)
            {
                gvMatchingResults.HeaderRow.Cells[0].Text = "<b>调出仓</b>";
                gvMatchingResults.HeaderRow.Cells[1].Text = "<b>机器名称</b>";
                gvMatchingResults.HeaderRow.Cells[2].Text = "<b>品牌</b>";
                gvMatchingResults.HeaderRow.Cells[3].Text = "<b>型号</b>";
                gvMatchingResults.HeaderRow.Cells[4].Text = "<b>参数</b>";
                gvMatchingResults.HeaderRow.Cells[5].Text = "<b>序列号</b>";
                gvMatchingResults.HeaderRow.Cells[6].Text = "<b>保修电话</b>";
                gvMatchingResults.HeaderRow.Cells[7].Text = "<b>供应商</b>";
                gvMatchingResults.HeaderRow.Cells[8].Text = "<b>验收</b>";
                if (DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], "", "", "", "", "", "", "", "", "", "", "0", "").Tables[0].Rows.Count == 0)
                {
                    noRecordsText1.Visible = true;
                }
                else
                {
                    noRecordsText1.Visible = false;
                }
            }

        }
    }
}