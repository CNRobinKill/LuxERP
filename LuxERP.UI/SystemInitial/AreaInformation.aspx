<%@ Page Title="区域信息管理" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="AreaInformation.aspx.cs" Inherits="LuxERP.UI.SystemInitial.AreaInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlide('#systemInitial', '#areaInformation');
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

    <asp:Button ID="btnAddAreaInfo" runat="server" Text="添加" CssClass="button" 
        onclick="btnAddAreaInfo_Click"  />
    <asp:GridView ID="gvAreaInfo" runat="server" AutoGenerateColumns="False" 
            onrowcancelingedit="gvAreaInfo_RowCancelingEdit" 
            onrowdeleting="gvAreaInfo_RowDeleting" onrowediting="gvAreaInfo_RowEditing" 
            onrowupdating="gvAreaInfo_RowUpdating">
        <Columns>
                    <asp:BoundField DataField="AreaName" ReadOnly="true">
                        <ControlStyle Width="101px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AreaAliss" >
                        <ControlStyle Width="51px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AreaManager" >
                        <ControlStyle Width="71px" />
                        <ItemStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ManagerPhone" >
                        <ControlStyle Width="101px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ManagerEmail" >
                        <ControlStyle Width="201px" />
                        <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:CommandField ShowEditButton="True" EditText="修改信息" ControlStyle-Width="50px" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="删除" ControlStyle-Width="50px" />
        </Columns>
    </asp:GridView>
 </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
