<%@ Page Title="人员信息管理" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="PeopleManage.aspx.cs" Inherits="LuxERP.UI.SystemInitial.PeopleManagement" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<h2>PeopleManagement</h2>
<div style="width:770px">
    <asp:Label runat="server" Text="职位："></asp:Label>
<%--    <asp:TextBox ID="txtPosition" runat="server" Width="100px"></asp:TextBox>--%>
    <asp:DropDownList ID="ddlPosition" runat="server">
        <asp:ListItem>工程师</asp:ListItem>
    </asp:DropDownList>
    <asp:Label runat="server" Text="姓名："></asp:Label>
    <asp:TextBox ID="txtName" runat="server" Width="60px"></asp:TextBox>
    <asp:Label runat="server" Text="性别："></asp:Label>
    <asp:DropDownList ID="ddlSex" runat="server">
        <asp:ListItem Value="男">男</asp:ListItem>
        <asp:ListItem Value="女">女</asp:ListItem>
    </asp:DropDownList>
    <asp:Label runat="server" Text="联系电话："></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server"  Width="120px"></asp:TextBox>
    <asp:Label runat="server" Text="邮箱："></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"  Width="150px"></asp:TextBox>
    <asp:Button ID="btnAddPeople" runat="server" Text="添加" CssClass="button" 
        onclick="btnAddPeople_Click" />
    <asp:GridView ID="gvPeople" runat="server" AutoGenerateColumns="False" 
        onrowdeleting="gvPeople_RowDeleting">
        <Columns>
                    <asp:BoundField DataField="Name" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Position" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sex" >
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Phone" >
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" >
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="50px" />
        </Columns>
    </asp:GridView>
 </div>
 </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
