<%@ Page Title="" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="SceneServiceProvider.aspx.cs" Inherits="LuxERP.UI.SystemInitial.SceneServiceProvider" %>
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
<h2>SceneServiceProvider</h2>
    <asp:Label runat="server" Text="上门服务商："></asp:Label>
    <asp:TextBox ID="txtServiceProvider" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="联系电话："></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="服务区域:"></asp:Label>
    <asp:DropDownList ID="ddlServiceArea" runat="server"></asp:DropDownList>
    <asp:Label runat="server" Text="剩余Token数："></asp:Label>
    <asp:TextBox ID="txtRemainToken" runat="server" Width="100px"></asp:TextBox>


    <asp:Button ID="btnAddSceneServiceProvider" runat="server" Text="添加" CssClass="button"  />
    <asp:GridView ID="gvSceneServiceProvider" runat="server" AutoGenerateColumns="False">
        <Columns>
                    <asp:BoundField DataField="ServiceProvider" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Phone" >
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ServiceArea" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RemainToken" ReadOnly="true">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:CommandField ShowEditButton="True" EditText="修改信息" ControlStyle-Width="50px" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="删除" ControlStyle-Width="50px" />
        </Columns>
    </asp:GridView>
    <asp:Label runat="server" Text="上门服务商:"></asp:Label>
    <asp:DropDownList ID="ddlServiceProvider" runat="server"></asp:DropDownList>
    <asp:Label runat="server" Text="增加Token数："></asp:Label>
    <asp:TextBox ID="txtToken" runat="server" Width="100px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="增加" CssClass="button"  />

</asp:Content>
