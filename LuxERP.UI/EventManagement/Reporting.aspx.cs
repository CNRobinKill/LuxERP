using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LuxERP.UI.EventManagement
{
    public partial class Reporting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlReports.SelectedValue = "Week";
                frame.Attributes["src"] = "http://10.15.140.110/ReportServer/Pages/ReportViewer.aspx?%2fReports%2fWeek&rs:Command=Render";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = ddlReports.SelectedValue.ToString();
            switch (val)
            {
                case "Week":
                    frame.Attributes["src"] = "http://10.15.140.110/ReportServer/Pages/ReportViewer.aspx?%2fReports%2fWeek&rs:Command=Render";
                    break;
                case "Month":
                    frame.Attributes["src"] = "http://10.15.140.110/ReportServer/Pages/ReportViewer.aspx?%2fReports%2fMonth&rs:Command=Render";
                    break;
                case "FocusPKiFocus":
                    frame.Attributes["src"] = "http://10.15.140.110/ReportServer/Pages/ReportViewer.aspx?%2fReports%2fFocusIFocus&rs:Command=Render";
                    break;
                case "MonthPercent":
                    frame.Attributes["src"] = "http://10.15.140.110/ReportServer/Pages/ReportViewer.aspx?%2fReports%2fMonthPercent&rs:Command=Render";
                    break;
                case "TimeSegment":
                    frame.Attributes["src"] = "http://10.15.140.110/ReportServer/Pages/ReportViewer.aspx?%2fReports%2fTimeSegment&rs:Command=Render";
                    break;
                case "DataCatalog":
                    frame.Attributes["src"] = "http://10.15.140.110/ReportServer/Pages/ReportViewer.aspx?%2fReports%2fDataCatalog&rs:Command=Render";
                    break;                
            }
        }
    }
}