<%@ Page Title="管理员-移除门店设备" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="RemoveStoreFacility.aspx.cs" Inherits="LuxERP.UI.Admin.RemoveStoreFacility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#myContent_gvFacility th, td {
padding: 2px !important;
line-height: 1.3em !important;
}
</style>
<script type="text/javascript">
    $(function () {
        menuSlideTop('#admin');
    });

    function setTableColor() {
        $('#myContent_gvFacility tr:odd').css('background-color', '#D5E9DF');
    }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Button ID="btnReturnUserManage" runat="server" Text="返回管理员页" 
        CssClass="button" onclick="btnReturnUserManage_Click" />
    <h2>RemoveStoreFacility</h2>
      <div>
        店号：<asp:TextBox ID="txtStoreNo" runat="server" Width="50px"></asp:TextBox>&nbsp;    
        <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="button" 
              onclick="btnQuery_Click" />  
      </div>
<asp:GridView ID="gvFacility" runat="server" AutoGenerateColumns="False" 
        onrowdeleting="gvFacility_RowDeleting">
          <Columns>
            <asp:BoundField DataField="Maching">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Brand">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="Model">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Parameter">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="SerialNo">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="EpcTags">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="SapNo">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="PurchaseDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="GuaranteeTime">
                <ItemStyle Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="RepairsNo">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplier">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="OutStockDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" HeaderStyle-Width="30px" /> 
    </Columns>
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
