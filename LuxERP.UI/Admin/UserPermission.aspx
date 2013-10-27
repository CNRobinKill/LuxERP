<%@ Page Title="管理员-系统用户权限" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="UserPermission.aspx.cs" Inherits="LuxERP.UI.Admin.UserPermission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(function () {
        menuSlideTop('#admin');
    });
    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Button ID="btnReturnUserManage" runat="server" Text="返回管理员页" 
        CssClass="button" onclick="btnReturnUserManage_Click" />
<div style="margin: 10px 10px 10px 10px;"><h2>Permission</h2></div>
<div>
<div style=" width:600px; text-align:right"><asp:Button ID="btnPermission" runat="server" Text="更新权限" CssClass="button" onclick="btnPermission_Click" /></div>
    <asp:Table ID="table" runat="server" Width="600px">
    <asp:TableRow>
    <asp:TableCell><asp:CheckBox ID="chkIndex" runat="server" /><asp:Label runat="server" Text="主页"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkUpdateSolution" runat="server" /><asp:Label runat="server" Text="查询修改解决资源方案"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkEventQuery" runat="server" /><asp:Label runat="server" Text="事件查询"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkCreateEvent" runat="server" /><asp:Label runat="server" Text="创建事件"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell><asp:CheckBox ID="chkReportFormsEvent" runat="server" /><asp:Label runat="server" Text="事件报表"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkAddStock" runat="server" /><asp:Label runat="server" Text="添加库存"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkStockQuery" runat="server" /><asp:Label runat="server" Text="库存查询"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkOutStockQuery" runat="server" /><asp:Label runat="server" Text="出库查询"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell><asp:CheckBox ID="chkAllotStockQuery" runat="server" /><asp:Label runat="server" Text="历史调库"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkAddStockQuery" runat="server" /><asp:Label runat="server" Text="入库历史"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkAlterStore" runat="server" /><asp:Label runat="server" Text="查询修改店铺"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkEventTypes" runat="server" /><asp:Label runat="server" Text="事件类管理"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell><asp:CheckBox ID="chkFacilityManage" runat="server" /><asp:Label runat="server" Text="设备信息管理"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkPeopleManage" runat="server" /><asp:Label runat="server" Text="人员管理"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkSynthesisManage" runat="server" /><asp:Label runat="server" Text="综合信息管理"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkEventState" runat="server" /><asp:Label runat="server" Text="事件状态管理"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell><asp:CheckBox ID="chkInitialStores" runat="server" /><asp:Label runat="server" Text="店铺信息初始化"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkInitialStocks" runat="server" /><asp:Label runat="server" Text="设备初始化"></asp:Label></asp:TableCell>
    <asp:TableCell><asp:CheckBox ID="chkScrapStocks" runat="server" /><asp:Label runat="server" Text="废损设备"></asp:Label></asp:TableCell>
    <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    </asp:Table>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
