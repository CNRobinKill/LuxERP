using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.EventManagement
{
    public partial class ShowPic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string eventNo = Request.QueryString["eventNo"];
                string n = Request.QueryString["n"];
                imgShowPic.ImageUrl = "~/Content/uploadimages/" + DAL.EventLogsDAL.GetPic(eventNo, n);
            }
        }
    }
}