<%@ Page Title="设备入库" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="AddStocks.aspx.cs" Inherits="LuxERP.UI.FacilityManagement.AddStocks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.right
{
  float:left;
  width: 300px;
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
<script type="text/javascript">
  $(function () {
      menuSlide('#stockManage', '#addStock');
    setDate();    
  });  

  function clearPage() {
    $('#wrap input[type=text]').val("");
    $('#wrap select').val("");
  };

  function setDate() {
    $("#myContent_txtPurchaseDate").datepicker({
      onClose: function (selectedDate) {
        $("#myContent_txtStockDate").datepicker("option", "minDate", selectedDate);
      }
    });
//    $("#myContent_txtStockDate").datepicker({
//      onClose: function (selectedDate) {
//        $("#myContent_txtPurchaseDate").datepicker("option", "maxDate", selectedDate);
//      }
//    });
    set("#myContent_txtPurchaseDate");
    set("#myContent_txtGuaranteeDate");
  };

  function set(id) {
    $(id).datepicker();
    $(id).datepicker("option", "dateFormat", "yy-mm-dd");
    $(id).datepicker("option", $.datepicker.regional["zh-TW"]);
    $(id).datepicker("option", "changeMonth", "true");
    $(id).datepicker("option", "changeYear", "true");
  };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <h2>InitialStocks</h2>
     <div id="wrap" style=" width:800px">
       <div class="left">
         <asp:Label ID="Label1" runat="server" Text="仓库号：" Width="100px"></asp:Label>         
         <asp:TextBox ID="txtWStoreNo" runat="server"></asp:TextBox>
           <asp:Label ID="Label20" runat="server" ForeColor="Red" Text="*"></asp:Label>
       </div>
<%--       <div class="right">
         <asp:Label ID="Label2" runat="server" Text="库存类型：" Width="100px"></asp:Label>
         <asp:DropDownList ID="ddlStockType" runat="server">
           <asp:ListItem Value="1">门店</asp:ListItem>
           <asp:ListItem Value="0">仓库</asp:ListItem>
         </asp:DropDownList>
       </div>--%>
       <div class="right">
         <asp:Label ID="Label3" runat="server" Text="机器名称：" Width="100px"></asp:Label>
         <asp:DropDownList ID="ddlMaching" runat="server" 
               onselectedindexchanged="ddlMaching_SelectedIndexChanged" 
               AutoPostBack="True">
         </asp:DropDownList>
           <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*"></asp:Label>
       </div>
       <div class="clear left">
         <asp:Label ID="Label4" runat="server" Text="品牌：" Width="100px"></asp:Label>
         <asp:DropDownList ID="ddlBrand" runat="server" 
               onselectedindexchanged="ddlBrand_SelectedIndexChanged" AutoPostBack="True">
         </asp:DropDownList>
           <asp:Label ID="Label19" runat="server" ForeColor="Red" Text="*"></asp:Label>
       </div>     
       <div class="right">
         <asp:Label ID="Label5" runat="server" Text="型号：" Width="100px"></asp:Label>
         <asp:DropDownList ID="ddlModel" runat="server" 
               onselectedindexchanged="ddlModel_SelectedIndexChanged" AutoPostBack="True">
         </asp:DropDownList>
           <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
       </div>
       <div class="clear left">
         <asp:Label ID="Label6" runat="server" Text="序列号：" Width="100px"></asp:Label>
         <asp:TextBox ID="txtSerialNo" runat="server"></asp:TextBox>
           <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="*"></asp:Label>
       </div> 
       <div class="right">
         <asp:Label ID="Label7" runat="server" Text="配置参数：" Width="100px"></asp:Label>
         <asp:DropDownList ID="ddlParameter" runat="server">
         </asp:DropDownList>
           <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
       </div>
       <div class="clear left">
         <asp:Label ID="Label8" runat="server" Text="标签码：" Width="100px"></asp:Label>
         <asp:TextBox ID="txtEpcTags" runat="server"></asp:TextBox>
       </div> 
       <div class="right">
         <asp:Label ID="Label9" runat="server" Text="SAP码：" Width="100px"></asp:Label>
         <asp:TextBox ID="txtSapNo" runat="server"></asp:TextBox>
       </div>
       <div class="clear left">
         <asp:Label ID="Label10" runat="server" Text="购买日期：" Width="100px"></asp:Label>
         <asp:TextBox ID="txtPurchaseDate" runat="server"></asp:TextBox>
       </div> 
       <div class="right">
         <asp:Label ID="Label11" runat="server" Text="保修结束日期：" Width="100px"></asp:Label>
         <asp:TextBox ID="txtGuaranteeDate" runat="server"></asp:TextBox>
       </div>
       <div class="clear left">
         <asp:Label ID="Label12" runat="server" Text="保修电话：" Width="100px"></asp:Label>
         <asp:TextBox ID="txtRepairNo" runat="server"></asp:TextBox>
       </div> 
       <div class="right">
         <asp:Label ID="Label13" runat="server" Text="供应商：" Width="100px"></asp:Label>
         <asp:DropDownList ID="ddlSupplier" runat="server">
         </asp:DropDownList>
         <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
       </div>
<%--       <div class="right">
         <asp:Label ID="Label14" runat="server" Text="入库或出库时间：" Width="100px"></asp:Label>
         <asp:TextBox ID="txtStockDate" runat="server"></asp:TextBox>
       </div> --%>
<%--       <div class="clear left">
         <asp:Label runat="server" Text="设备状态：" Width="100px"></asp:Label>
         <asp:DropDownList ID="ddlMachingState" runat="server">
           <asp:ListItem Value="1">Old</asp:ListItem>
           <asp:ListItem Value="0">New</asp:ListItem>
         </asp:DropDownList>
       </div> --%>      
       <div style="clear:both;">
         <asp:Button ID="btnSubmit" runat="server" Text="确定" CssClass="button" onclick="btnSubmit_Click" />
       </div> 
     </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
