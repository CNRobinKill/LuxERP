<%@ Page Title="开关店与装修事件状态流程设置" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="EventState.aspx.cs" Inherits="LuxERP.UI.SystemInitial.EventState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#main-content table td, #main-content table th 
{
    padding: 5px;
}
.right
{
  float:left;
  width: 450px; 
  border:1px solid gray;
  padding: 5px;
}
.left
{
  float:left;  
  width: 450px;
  border:1px solid gray;
  padding: 5px;
}
.clear
{
    clear: left;
}
</style>
<script type="text/javascript">
    $(function () {
        menuSlide('#systemInitial', '#eventState');
    });

    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
<h2>EventState</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <div  class="clear left">
    <h3>SetUpShopState</h3>
        <asp:Label runat="server" Text="状态："></asp:Label><asp:TextBox ID="txtSetUpShopState" runat="server" Width="80px"></asp:TextBox>
        <asp:Label runat="server" Text="提醒天数："></asp:Label><asp:TextBox ID="txtSetUpShopStateDay" runat="server" Width="30px"></asp:TextBox>
        <asp:Button ID="btnAddSetUpShopState" runat="server" Text="添加状态" 
            CssClass="button" onclick="btnAddSetUpShopState_Click" />
        <asp:GridView ID="gvSetUpShopState" runat="server" AutoGenerateColumns="False" 
            onrowcommand="gvSetUpShopState_RowCommand" 
            onrowdeleting="gvSetUpShopState_RowDeleting" 
            onrowediting="gvSetUpShopState_RowEditing" 
            onrowupdating="gvSetUpShopState_RowUpdating" 
            onrowcancelingedit="gvSetUpShopState_RowCancelingEdit" >
    <Columns>
           <asp:BoundField DataField="RowNum" ReadOnly="true">
                 <ItemStyle Width="20px" />
           </asp:BoundField>
           <asp:BoundField DataField="StateName" ControlStyle-Width="100px">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="StateDay" ControlStyle-Width="30px">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnChangUp" Text="上移" HeaderStyle-Width="50px" />
           <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnChangDown" Text="下移" HeaderStyle-Width="50px" />
           <asp:CommandField ShowEditButton="true" EditText="修改" HeaderStyle-Width="70px" />
           <asp:CommandField ShowDeleteButton="true" DeleteText="删除" HeaderStyle-Width="50px" />
    </Columns>
    </asp:GridView>
    </div>

    <div  class="right">
    <h3>ShutUpShopState</h3>
        <asp:Label ID="Label1" runat="server" Text="状态："></asp:Label><asp:TextBox ID="txtShutUpShopState" runat="server" Width="80px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="提醒天数："></asp:Label><asp:TextBox ID="txtShutUpShopStateDay" runat="server" Width="30px"></asp:TextBox>
        <asp:Button ID="btnAddShutUpShopState" runat="server" Text="添加状态" 
            CssClass="button" onclick="btnAddShutUpShopState_Click" />
        <asp:GridView ID="gvShutUpShopState" runat="server" AutoGenerateColumns="False" 
            onrowcommand="gvShutUpShopState_RowCommand" 
            onrowdeleting="gvShutUpShopState_RowDeleting" 
            onrowediting="gvShutUpShopState_RowEditing" 
            onrowupdating="gvShutUpShopState_RowUpdating" 
            onrowcancelingedit="gvShutUpShopState_RowCancelingEdit" >
    <Columns>
           <asp:BoundField DataField="RowNum" ReadOnly="true">
                 <ItemStyle Width="20px" />
           </asp:BoundField>
           <asp:BoundField DataField="StateName" ControlStyle-Width="100px">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="StateDay" ControlStyle-Width="30px">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnChangUp" Text="上移" HeaderStyle-Width="50px" />
           <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnChangDown" Text="下移" HeaderStyle-Width="50px" />
           <asp:CommandField ShowEditButton="true" EditText="修改" HeaderStyle-Width="70px" />
           <asp:CommandField ShowDeleteButton="true" DeleteText="删除" HeaderStyle-Width="50px" />
    </Columns>
    </asp:GridView>
    </div>

    <div  class="clear left">
    <h3>StoreRenovationState</h3>
        <asp:Label ID="Label3" runat="server" Text="状态："></asp:Label><asp:TextBox ID="txtStoreRenovationState" runat="server" Width="80px"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="提醒天数："></asp:Label><asp:TextBox ID="txtStoreRenovationStateDay" runat="server" Width="30px"></asp:TextBox>
        <asp:Button ID="btnAddStoreRenovationState" runat="server" Text="添加状态" 
            CssClass="button" onclick="btnAddStoreRenovationState_Click" />
        <asp:GridView ID="gvStoreRenovationState" runat="server" AutoGenerateColumns="False" 
            onrowcommand="gvStoreRenovationState_RowCommand" 
            onrowdeleting="gvStoreRenovationState_RowDeleting" 
            onrowediting="gvStoreRenovationState_RowEditing" 
            onrowupdating="gvStoreRenovationState_RowUpdating" 
            onrowcancelingedit="gvStoreRenovationState_RowCancelingEdit" >
    <Columns>
           <asp:BoundField DataField="RowNum" ReadOnly="true">
                 <ItemStyle Width="20px" />
           </asp:BoundField>
           <asp:BoundField DataField="StateName" ControlStyle-Width="100px">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="StateDay" ControlStyle-Width="30px">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnChangUp" Text="上移" HeaderStyle-Width="50px" />
           <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnChangDown" Text="下移" HeaderStyle-Width="50px" />
           <asp:CommandField ShowEditButton="true" EditText="修改" HeaderStyle-Width="70px" />
           <asp:CommandField ShowDeleteButton="true" DeleteText="删除" HeaderStyle-Width="50px" />
    </Columns>
    </asp:GridView>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
