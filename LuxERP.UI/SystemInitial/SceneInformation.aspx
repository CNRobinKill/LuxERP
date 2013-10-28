<%@ Page Title="" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="SceneInformation.aspx.cs" Inherits="LuxERP.UI.SystemInitial.SceneInformation" %>
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
<h2>IndoorServiceType</h2>
    <asp:Label runat="server" Text="上门类型："></asp:Label>
    <asp:TextBox ID="txtIndoorServiceTypeName" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="基数："></asp:Label>
    <asp:TextBox ID="txtBaseToken" runat="server" Width="60px"></asp:TextBox>
    <asp:Label runat="server" Text="计算模式:"></asp:Label>
    <asp:DropDownList ID="ddlComputingMethod" runat="server">
        <asp:ListItem Value="固定值">固定值</asp:ListItem>
        <asp:ListItem Value="按时(15min)">按时(15min)</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnAddIndoorServiceType" runat="server" Text="添加" 
        CssClass="button" onclick="btnAddIndoorServiceType_Click"  />
    <asp:GridView ID="gvSceneType" runat="server" AutoGenerateColumns="False" 
            onrowdeleting="gvSceneType_RowDeleting">
        <Columns>
                    <asp:BoundField DataField="TypeName" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BaseToken" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ComputingMethod" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="50px" />
        </Columns>
    </asp:GridView>
<hr />
<h2>MultiplyingPowerType</h2>
    <asp:Label  runat="server" Text="倍率类型："></asp:Label>
    <asp:TextBox ID="txtMultiplyingPowerType" runat="server" Width="100px"></asp:TextBox>
    <asp:Label  runat="server" Text="倍率："></asp:Label>
    <asp:TextBox ID="txtMultiplyingPower" runat="server" Width="60px"></asp:TextBox>

    <asp:Button ID="btnAddMultiplyingPowerType" runat="server" Text="添加" 
            CssClass="button" onclick="btnAddMultiplyingPowerType_Click"  />
    <asp:GridView ID="gvMultiplyingPowerType" runat="server" 
            AutoGenerateColumns="False" onrowdeleting="gvMultiplyingPowerType_RowDeleting">
        <Columns>
                    <asp:BoundField DataField="TypeName" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MultiplyingPower" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="50px" />
        </Columns>
    </asp:GridView>
 </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
