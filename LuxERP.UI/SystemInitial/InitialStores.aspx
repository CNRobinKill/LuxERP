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
         <asp:Label ID="Label15" runat="server" Text="店铺类型：" Width="60px"></asp:Label>
          <asp:DropDownList ID="ddlStoreType" runat="server">
            <asp:ListItem Value="IFocus"  Selected="True">IFocus</asp:ListItem>
            <asp:ListItem Value="Accufit">Accufit</asp:ListItem>
            <asp:ListItem Value="Focus">Focus</asp:ListItem>
          </asp:DropDownList>
       </div>
       <div class="clear left">
         <asp:Label ID="Label16" runat="server" Text="区域：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
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
       <div class="right">
         <asp:Label ID="Label1" runat="server" Text="宽带账号：" Width="60px"></asp:Label>
          <asp:TextBox ID="txtADSLNo" runat="server"></asp:TextBox>
       </div> 
       <div class="clear left">
         
       </div>
       <div style="clear:both;">
         <asp:Button ID="btnAddStores" runat="server" CssClass="button" Text="确认" 
            onclick="btnAddStores_Click" />
       </div>
     </div>
  </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
