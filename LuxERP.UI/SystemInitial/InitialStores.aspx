<%@ Page Title="门店初始化" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="InitialStores.aspx.cs" Inherits="LuxERP.UI.SystemInitial.InitialStores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript">
    $(function () {
      menuSlide('#systemInitial', '#initialStores');
      setDate();
    });

//    function setDate() {
//      $('#myContent_txtOpeningDate').datepicker();
//      $('#myContent_txtOpeningDate').datepicker("option", "dateFormat", "yy-mm-dd");
//      $("#myContent_txtOpeningDate").datepicker("option", $.datepicker.regional["zh-TW"]);
//      $("#myContent_txtOpeningDate").datepicker("option", "changeMonth", "true");
//      $("#myContent_txtOpeningDate").datepicker("option", "changeYear", "true");
//    };

    function addRowStyle() {
      $('tbody tr:even').addClass('alt-row');
    };

    function clearPage() {
      $('#tbShow input[type=text]').val("");
      $('#tbShow select').val("");
    };
    
</script>
<style type="text/css">
.right
{
  float:left;
  width: 450px;
  margin: 10px 10px 10px 50px;    
}
.left
{
  float:left;  
  width: 300px;
  margin: 10px 50px 10px 10px;   
}
.clear
{
    clear: left;
}
.label
{
  width: 90px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
  <h2>InitialStores</h2>
  <asp:ScriptManager ID="ScriptManager1" runat="server">
  </asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <div id="tbShow" style=" width:900px">
       <div class="left">
         <asp:Label ID="Label13" runat="server" Text="店号：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtStoreNo" runat="server"></asp:TextBox>
       </div>
       <div class="right">
         <asp:Label ID="Label14" runat="server" Text="重点店铺：" Width="60px"></asp:Label>
          <asp:DropDownList ID="ddlTopStore" runat="server">
            <asp:ListItem Selected="True" Value="Yes">Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
          </asp:DropDownList>
       </div>
       <div class="clear left">
         <asp:Label ID="Label15" runat="server" Text="店铺类型：" Width="60px"></asp:Label>
          <asp:DropDownList ID="ddlStoreType" runat="server">
            <asp:ListItem Selected="True">Focus</asp:ListItem>
            <asp:ListItem Value="IFocus">IFocus</asp:ListItem>
          </asp:DropDownList>
       </div>
       <div class="right">
         <asp:Label ID="Label16" runat="server" Text="区域：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
       </div>     
       <div class="clear left">
         <asp:Label ID="Label17" runat="server" Text="等级：" Width="60px"></asp:Label>
          <asp:DropDownList ID="ddlRating" runat="server">
            <asp:ListItem Selected="True">Energy</asp:ListItem>
            <asp:ListItem Value="FO">FO</asp:ListItem>
            <asp:ListItem>Gold</asp:ListItem>
            <asp:ListItem>Platinum</asp:ListItem>
            <asp:ListItem>Silver 1</asp:ListItem>
            <asp:ListItem>Silver 2</asp:ListItem>
          </asp:DropDownList>
       </div>
       <div class="right">
         <asp:Label ID="Label18" runat="server" Text="店铺名称：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtStoreName" runat="server"></asp:TextBox>
       </div> 
       <div class="clear left">
         <asp:Label ID="Label19" runat="server" Text="城市：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
       </div>
       <div class="right">
         <asp:Label ID="Label20" runat="server" Text="地址：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtStoreAddress" runat="server" Width="350px"></asp:TextBox>
       </div> 
       <div class="clear left">
         <asp:Label ID="Label21" runat="server" Text="电话：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtStoreTel" runat="server"></asp:TextBox>
       </div>
<%--       <div class="right">
         <asp:Label ID="Label22" runat="server" Text="合同面积：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtContractArea" runat="server"></asp:TextBox>
       </div> 
       <div class="clear left">
         <asp:Label ID="Label23" runat="server" Text="开业时间：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtOpeningDate" runat="server"></asp:TextBox>
       </div>--%>
       <%--<div class="right">
         <asp:Label ID="Label24" runat="server" Text="店铺状态：" Width="60px"></asp:Label>
          <asp:DropDownList ID="ddlStoreState" runat="server">
            <asp:ListItem Value="900">营业中</asp:ListItem>
            <asp:ListItem Value="998">装修中</asp:ListItem>
          </asp:DropDownList>
       </div>--%> 
       <div style="clear:both;">
         <asp:Button ID="btnAddStores" runat="server" CssClass="button" Text="确认" 
            onclick="btnAddStores_Click" />
       </div>
     </div>
  </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
