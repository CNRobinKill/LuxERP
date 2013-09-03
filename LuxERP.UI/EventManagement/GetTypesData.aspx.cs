using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LuxERP.UI.EventManagement
{
    public partial class GetTypesData : System.Web.UI.Page
    {        
        Dictionary<string, string> dictTypes = new Dictionary<string, string>();        
        string hint = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (dictTypes.Count == 0)
            {
                ReadData(dictTypes);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["q"] != null)
                {
                    string q = Request.QueryString["q"];
                    if (q.Length > 0)
                    {
                        hint = "";
                        foreach (var item in dictTypes)
                        {
                            if (item.Key == q)
                            {
                                hint = item.Value;
                            }
                        }

                    }

                    if (hint == "")
                    {
                        Response.Write("没有这个类型");
                    }
                    else
                    {
                        Response.Write(hint);
                    }
                }
            }
        }

        private void ReadData(Dictionary<string, string> dict)
        {
            DataTable dt = DAL.EventTypesDAL.GetEventTypes().Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                string key = dr["TypeCode"].ToString();
                string value = dr["TypeOne"].ToString() + "/" + dr["TypeTwo"].ToString() + "/" + dr["TypeThree"].ToString() + "/" + dr["TypeFour"].ToString();

                dict.Add(key, value);
            }
        }
    }
}