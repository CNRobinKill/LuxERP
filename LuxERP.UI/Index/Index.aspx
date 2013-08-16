<%@ Page Title="主页-事务提醒" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LuxERP.UI.Index.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlideTop('#index');
    });
</script>
<style type="text/css">
.right
{
  float:left;
  width: 150px;
  margin: 10px 10px 10px 10px;    
}
.left
{
  float:left;  
  width: 150px;
  margin: 10px 10px 10px 10px;   
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
<div style="clear:both;margin: 10px 10px 10px 10px;"><h2>TabulateStatistics</h2></div>
<div style="width:500px;clear:both;">
    <div class="clear left">
        <asp:Label runat="server" Text="普通事件：" Font-Size="15px"></asp:Label>
        <asp:Label ID="lblCountNormalEvents" runat="server" Width="60px"></asp:Label>
        
    </div> 
    <div class="right">
        <asp:Label runat="server" Text="开店事件：" Font-Size="15px"></asp:Label>
        <asp:Label ID="lblCountSetUpShopEvents" runat="server"  Width="60px"></asp:Label>
    </div>
    <div class="clear left">
        <asp:Label runat="server" Text="关店事件：" Font-Size="15px"></asp:Label>
        <asp:Label ID="lblCountShutUpShopEvents" runat="server" Width="60px"></asp:Label>
        
    </div> 
    <div class="right">
        <asp:Label runat="server" Text="装修事件：" Font-Size="15px"></asp:Label>
        <asp:Label ID="lblCountStoreRenovationEvents" runat="server" Width="60px"></asp:Label>
    </div>
</div>
<div style="clear:both;margin: 10px 10px 10px 10px;"><h2>AttentionEvents</h2></div>
<div style="clear:both;margin: 10px 10px 10px 10px;"><h3>NormalEvents</h3></div>
<div style="clear:both;">
    <asp:GridView ID="gvNormalEvent" runat="server" AutoGenerateColumns="False" >
    <Columns>
           <asp:BoundField DataField="EventNo">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventTime">
                 <ItemStyle Width="110px" />
           </asp:BoundField>
           <asp:BoundField DataField="StoreNo">
                 <ItemStyle Width="30px" />
           </asp:BoundField>
           <asp:BoundField DataField="TypeCode">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:BoundField DataField="StepDescribe">
                 <ItemStyle Width="400px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventState">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="LogBy">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:HyperLinkField HeaderStyle-Width="60px" DataNavigateUrlFields="EventNo,TypeCode" DataNavigateUrlFormatString="/EventManagement/NormalEvent.aspx?eventNo={0}&typeCode={1}" Text="查看详情" />
    </Columns>
    </asp:GridView>
</div>
<div id="nogvNormalEvent" runat="server" visible="false" style="clear:both;width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label ID="Label1" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">目前没有未关闭的普通事件</asp:Label>
</div>
<div style="clear:both;margin: 10px 10px 10px 10px;"><h3>SetUpShopEvents</h3></div>
<div style="clear:both;">
    <asp:GridView ID="gvSetUpShopEvent" runat="server" AutoGenerateColumns="False" >
    <Columns>
           <asp:BoundField DataField="EventNo">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventTime">
                 <ItemStyle Width="110px" />
           </asp:BoundField>
           <asp:BoundField DataField="StoreNo">
                 <ItemStyle Width="30px" />
           </asp:BoundField>
           <asp:BoundField DataField="TypeCode">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:BoundField DataField="StepDescribe">
                 <ItemStyle Width="300px" />
           </asp:BoundField>
           <asp:BoundField DataField="ToResolvedTime">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventState">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="LogBy">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:HyperLinkField HeaderStyle-Width="60px" DataNavigateUrlFields="EventNo,TypeCode" DataNavigateUrlFormatString="/EventManagement/NormalEvent.aspx?eventNo={0}&typeCode={1}" Text="查看详情" />
    </Columns>
    </asp:GridView>
</div>
<div id="nogvSetUpShopEvent" runat="server" visible="false" style="clear:both;width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label ID="Label2" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">目前没有需跟进的开店事件</asp:Label>
</div>
<div style="clear:both;margin: 10px 10px 10px 10px;"><h3>ShutUpShopEvents</h3></div>
<div style="clear:both;">
    <asp:GridView ID="gvShutUpShopEvent" runat="server" AutoGenerateColumns="False" >
    <Columns>
           <asp:BoundField DataField="EventNo">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventTime">
                 <ItemStyle Width="110px" />
           </asp:BoundField>
           <asp:BoundField DataField="StoreNo">
                 <ItemStyle Width="30px" />
           </asp:BoundField>
           <asp:BoundField DataField="TypeCode">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:BoundField DataField="StepDescribe">
                 <ItemStyle Width="300px" />
           </asp:BoundField>
           <asp:BoundField DataField="ToResolvedTime">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventState">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="LogBy">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:HyperLinkField HeaderStyle-Width="60px" DataNavigateUrlFields="EventNo,TypeCode" DataNavigateUrlFormatString="/EventManagement/NormalEvent.aspx?eventNo={0}&typeCode={1}" Text="查看详情" />
    </Columns>
    </asp:GridView>
</div>
<div id="nogvShutUpShopEvent" runat="server" visible="false" style="clear:both;width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label ID="Label3" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">目前没有需跟进的关店事件</asp:Label>
</div>
<div style="clear:both;margin: 10px 10px 10px 10px;"><h3>StoreRenovationEvents</h3></div>
<div style="clear:both;">
    <asp:GridView ID="gvStoreRenovationEvent" runat="server" AutoGenerateColumns="False" >
    <Columns>
           <asp:BoundField DataField="EventNo">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventTime">
                 <ItemStyle Width="110px" />
           </asp:BoundField>
           <asp:BoundField DataField="StoreNo">
                 <ItemStyle Width="30px" />
           </asp:BoundField>
           <asp:BoundField DataField="TypeCode">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:BoundField DataField="StepDescribe">
                 <ItemStyle Width="300px" />
           </asp:BoundField>
           <asp:BoundField DataField="ToResolvedTime">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventState">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="LogBy">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:HyperLinkField HeaderStyle-Width="60px" DataNavigateUrlFields="EventNo,TypeCode" DataNavigateUrlFormatString="/EventManagement/NormalEvent.aspx?eventNo={0}&typeCode={1}" Text="查看详情" />
    </Columns>
    </asp:GridView>
</div>
<div id="nogvStoreRenovationEvent" runat="server" visible="false" style="clear:both;width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label ID="Label4" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">目前没有需跟进的店铺装修事件</asp:Label>
</div>
</asp:Content>
