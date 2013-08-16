using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LuxERP.UI.EventManagement
{
    public partial class WorkOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    gvServicesBind();
                }
            }
            catch
            {
                Response.Redirect("~/Error.html");
            }
        }

        public void LoadStoreInformation()
        {
            lblStoreNo.Text = StoreInformationArray(0);
            lblStoreName.Text = StoreInformationArray(5);
            lblEventNo.Text = Request.QueryString["eventNo"];
            lblStoreAddress.Text = StoreInformationArray(7);
            lblStoreTel.Text = StoreInformationArray(8);
        }

        public string StoreInformationArray(int n)
        {
            SqlDataReader dr = DAL.StoresDAL.GetStoresByStoreNo(Request.QueryString["storeNo"]);
            dr.Read();
            string stores = dr[n].ToString();
            dr.Close();
            return stores;
        }

        public void gvServicesBind()
        {
            gvServices.Width = 550;
            gvServices.DataSource = DAL.StocksDAL.GetStocks(Request.QueryString["eventNo"], Request.QueryString["storeNo"], "", "", "", "", "", "", "", "", "", "1", "");
            gvServices.DataKeyNames = new string[] { "ID" };
            gvServices.DataBind();
            LoadStoreInformation();
        }
    }
}