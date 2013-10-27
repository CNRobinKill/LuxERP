<%@ Page Title="" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="AreaInformation.aspx.cs" Inherits="LuxERP.UI.SystemInitial.AreaInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlide('#systemInitial', '#peopleManage');
    });

    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
<h2>AreaInformation</h2>
    <asp:Label runat="server" Text="区域名称："></asp:Label>
    <asp:TextBox ID="txtAreaName" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="区域别名："></asp:Label>
    <asp:TextBox ID="txtAreaAliss" runat="server" Width="50px"></asp:TextBox>
    <asp:Label runat="server" Text="区域经理:"></asp:Label>
    <asp:TextBox ID="txtAreaManager" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="经理联系电话:"></asp:Label>
    <asp:TextBox ID="txtManagerPhone" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="经理联系邮箱:"></asp:Label>
    <asp:TextBox ID="txtManagerEmail" runat="server" Width="150px"></asp:TextBox>

    <asp:Button ID="btnAddAreaInfo" runat="server" Text="添加" CssClass="button"  />
    <asp:GridView ID="gvAreaInfo" runat="server" AutoGenerateColumns="False">
        <Columns>
                    <asp:BoundField DataField="AreaName" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AreaAliss" >
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AreaManager" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ManagerPhone" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ManagerEmail" >
                        <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="50px" />
        </Columns>
    </asp:GridView>
</asp:Content>
