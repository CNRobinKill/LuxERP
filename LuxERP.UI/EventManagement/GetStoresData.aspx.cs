using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LuxERP.UI.EventManagement
{
    public partial class GetStoresData : System.Web.UI.Page
    {
        Dictionary<string, string> stores = new Dictionary<string, string>();
        string hint = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (stores.Count == 0)
            {
                ReadData(stores);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["q"] != null)
                {
                    string q = Request.QueryString["q"];
                    if (q.Length > 0)
                    {
                        hint = "";
                        foreach (var item in stores)
                        {
                            if (item.Key == q)
                            {
                                hint = item.Key;
                                break;
                            }
                        }

                    }

                    if (hint == "")
                    {
                        Response.Write("没有该门店");
                    }
                    else
                    {
                        Response.Write(hint);
                    }
                }
            }
        }

        private void ReadData(Dictionary<string,string> stores)
        {
            DataTable dt = DAL.StoresDAL.GetStores("", "", "", "", "", "").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                string key = dr["StoreNo"].ToString();
                stores.Add(key,"");   
            }
        }
    }
}