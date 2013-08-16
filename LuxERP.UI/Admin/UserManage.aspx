<%@ Page Title="管理员-系统用户管理" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="LuxERP.UI.Admin.UserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(function () {
        menuSlideTop('#admin');
    });
    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };
</script>
<style type="text/css">
#main-content table td, #main-content table th 
{
    padding: 5px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <div style=" width:900px">
<div style="margin: 10px 10px 10px 10px;"><h2>UserManage</h2></div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div style="margin: 10px 10px 10px 10px;">
    <asp:Label runat="server" Text="用户名："></asp:Label><asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="密码："></asp:Label><asp:TextBox ID="txtPassWord" runat="server" Width="100px"></asp:TextBox>
    <asp:Button ID="btnAddSystemUser" runat="server" Text="添加用户" CssClass="button" 
        onclick="btnAddSystemUser_Click" />
    <asp:GridView ID="gvSystemUser" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="gvSystemUser_RowDataBound" 
        onrowcommand="gvSystemUser_RowCommand" 
        onrowdeleting="gvSystemUser_RowDeleting" onrowediting="gvSystemUser_RowEditing" 
        onrowupdating="gvSystemUser_RowUpdating">
        <Columns>
            <asp:BoundField DataField="RowNum" ReadOnly="true">
                 <ItemStyle Width="10px" />
           </asp:BoundField>
            <asp:BoundField DataField="UserName" ReadOnly="true" >
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Password"  ControlStyle-Width="120px">
                <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="CreateTime" ReadOnly="true" >
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="LastLogOnTime" ReadOnly="true">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="UserState" ReadOnly="true">
                <ItemStyle Width="30px" />
            </asp:BoundField>
            <asp:CommandField ShowEditButton="true" EditText="修改密码" HeaderStyle-Width="35px" />
            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnUserOn" Text="启用" HeaderStyle-Width="30px" />
            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" CommandName="btnUserOff" Text="禁用" HeaderStyle-Width="30px" />
            <asp:HyperLinkField HeaderStyle-Width="35px" DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="UserPermission.aspx?userName={0}" Text="权限管理" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="删除用户" HeaderStyle-Width="35px" />
        </Columns>
    </asp:GridView>
</div>
<div style="margin: 10px 10px 10px 10px;"><h2>ChangeAdministratorPassword</h2></div>
<div style="margin: 10px 10px 10px 10px;">
<asp:Label runat="server" Text="原密码：" Width="80px"></asp:Label><asp:TextBox ID="txtOldPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox><br />
<asp:Label runat="server" Text="新密码：" Width="80px"></asp:Label><asp:TextBox ID="txtNewPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox><br />
<asp:Label runat="server" Text="确认密码：" Width="80px"></asp:Label><asp:TextBox ID="txtNewPasswordOk" runat="server" Width="150px" TextMode="Password"></asp:TextBox><br />
    <asp:Button ID="btnChangeAdministratorPassword" runat="server" Text="确认更改管理员密码" 
        CssClass="button" onclick="btnChangeAdministratorPassword_Click" />
</div>
<div style="margin: 10px 10px 10px 10px;"><h2>OthersManage</h2></div>
        <asp:Button ID="btnRemoveStockFacility" runat="server" Text="移除库存设备" 
            CssClass="button" Width="150px" Height="40px" 
            onclick="btnRemoveStockFacility_Click"/>
        <asp:Button ID="btnRemoveStoreFacility" runat="server" Text="移除门店设备" 
            CssClass="button" Width="150px" Height="40px" 
            onclick="btnRemoveStoreFacility_Click"/>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
