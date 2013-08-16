<%@ Page Title="报表" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="Reporting.aspx.cs" Inherits="LuxERP.UI.EventManagement.Reporting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            menuSlide('#eventManage', '#reportFormsEvent');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div style="float:left;">
        <asp:DropDownList ID="ddlReports" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="Week">周报表</asp:ListItem>
            <asp:ListItem Value="Month">月报表</asp:ListItem>
            <asp:ListItem Value="FocusPKiFocus">Focus PK iFocus</asp:ListItem>
            <asp:ListItem Value="MonthPercent">Month比例分析</asp:ListItem>
            <asp:ListItem Value="TimeSegment">时间段分析</asp:ListItem>
            <asp:ListItem Value="DataCatalog">分类分析</asp:ListItem>
        </asp:DropDownList>
    </div>
    <iframe id="frame" name="frame" src="" style="width: 100%; height:600px; float:left" runat="server" />
</asp:Content>
