<%@ Page Title="创建事件" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="LuxERP.UI.EventManagement.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
.imgSelected
{
    border: 2px solid green;
}

#myContent_gvFacility td, th
{
    padding: 2px;
}

#myContent_gvEvent td, th
{
    padding: 2px;
}

</style>
<script type="text/javascript">
//  $(document).ready(
    $(function () {
        menuSlide('#eventManage', '#createEvent');        
        setDate();
    });

    function setDate() {
        $('#myContent_txtToResolvedTime').datepicker();
        $('#myContent_txtToResolvedTime').datepicker("option", "dateFormat", "yy-mm-dd");
        $("#myContent_txtToResolvedTime").datepicker("option", $.datepicker.regional["zh-TW"]);
        $("#myContent_txtToResolvedTime").datepicker("option", "changeMonth", "true");
        $("#myContent_txtToResolvedTime").datepicker("option", "changeYear", "true");
    };

    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };

    function showHint(str) {
        var xmlhttp;
        if (str.length == 0) {
            document.getElementById('myContent_lblTypeCodeText').innerHTML = "";
            $('#myContent_lblTypeCodeText').hide();
            return;
        }
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        } else {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                var text = xmlhttp.responseText;
                var l = text.indexOf("\r");
                text = text.substr(0, l);
                $('#myContent_lblTypeCodeText').show();
                document.getElementById('myContent_lblTypeCodeText').innerHTML = text;                
            }
        };
        xmlhttp.open("GET", 'GetTypesData.aspx?q=' + str, true);
        xmlhttp.send();
    };

    function showStores(str) {
        var xmlhttp;
        if (str.length == 0) {
            document.getElementById('myContent_lblStoreInfoText').innerHTML = "";
            $('#myContent_lblStoreInfoText').hide();
            $('#myContent_btnStoreInfo').hide();
            return;
        }
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        } else {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                var text = xmlhttp.responseText;
                var l = text.indexOf("\r");
                text = text.substr(0, l);
                if (text == str) {
                    $('#myContent_lblStoreInfoText').hide();
                    $('#myContent_btnStoreInfo').show();
                }
                else {
                    $('#myContent_btnStoreInfo').hide();
                    $('#myContent_storeInformation').hide();
                    $('#myContent_lblStoreInfoText').show();
                    document.getElementById('myContent_lblStoreInfoText').innerHTML = "没有该门店";
                }
            }
        };
        xmlhttp.open("GET", 'GetStoresData.aspx?q=' + str, true);
        xmlhttp.send();
    };       
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div>
<h2>CreateEvent</h2>

<asp:ImageButton  runat="server" ID="imgBtnNormalEvent" 
        ImageUrl="~/Content/images/noramlevents.png" 
        onclick="imgBtnNormalEvent_Click" />
<asp:ImageButton  runat="server" ID="imgBtnSetUpShop"   
        ImageUrl="~/Content/images/setupshop.png" onclick="imgBtnSetUpShop_Click" />
<asp:ImageButton  runat="server" ID="imgBtnShutUpShop"  
        ImageUrl="~/Content/images/shutupshop.png" onclick="imgBtnShutUpShop_Click" />
<asp:ImageButton  runat="server" ID="imgBtnStoreRenovation" 
        ImageUrl="~/Content/images/storerenovation.png" 
        onclick="imgBtnStoreRenovation_Click" />
</div>

<div runat="server" id="basicInformation">
<h2>BasicInformation</h2> 
      <table>
      <tr runat="server" id="trTypeCode"><td style=" width:100px;"><asp:Label ID="Label1" runat="server">店号：</asp:Label></td> <td>
          <asp:TextBox runat="server" ID="txtStoreNo" Width="50px" AutoCompleteType="Disabled" onkeyup="showStores(this.value)" ></asp:TextBox>&nbsp;&nbsp;
          <asp:Button ID="btnStoreInfo" runat="server" Text="门店相关信息" CssClass="button"  onclick="btnStoreInfo_Click" />
          <asp:Label ID="lblStoreInfoText" runat="server" ForeColor="Red"></asp:Label>
          </td></tr>
      <tr runat="server" id="trStoreNo1"><td style=" width:100px;"><asp:Label ID="Label2" runat="server">事件类型编号：</asp:Label></td> <td>
          <asp:TextBox runat="server" ID="txtTypeCode"  Width="100px" AutoCompleteType="Disabled" onkeyup="showHint(this.value)" ></asp:TextBox>&nbsp;&nbsp;
          <asp:Label ID="lblTypeCodeText" runat="server" ForeColor="Red"></asp:Label>
      </td></tr>
      <tr runat="server" id="trStoreNo2"><td style=" width:100px;"><asp:Label runat="server">店号：</asp:Label></td> <td>
        <asp:TextBox runat="server" ID="txtStoreNo2" Width="50px" 
            ontextchanged="txtStoreNo2_TextChanged"  AutoPostBack="true"></asp:TextBox>&nbsp;&nbsp;
        <asp:Label ID="lblStoreTextNo" runat="server" ForeColor="Red" Visible="false">门店号已被占用</asp:Label>
        <asp:Label ID="lblStoreTextOk" runat="server" ForeColor="Red" Visible="false">可以创建该门店</asp:Label>
      </td></tr>
      <tr runat="server" id="trRegion"><td><asp:Label runat="server">区域：</asp:Label></td> <td><asp:TextBox runat="server" ID="txtRegion" Width="50px"></asp:TextBox></td></tr>
      <tr runat="server" id="trToResolvedTime"><td><asp:Label ID="lblSetUp" runat="server">开店日期：</asp:Label><asp:Label ID="lblShutUp" runat="server">关店日期：</asp:Label><asp:Label ID="lblEnd" runat="server">结束日期：</asp:Label></td> <td><asp:TextBox runat="server" ID="txtToResolvedTime" Width="80px"></asp:TextBox></td></tr>
      <tr><td style=" width:100px;"><asp:Label runat="server">事件简述：</asp:Label></td> <td><asp:TextBox runat="server" ID="txtEventDescribe" Width="300px"></asp:TextBox></td></tr>
      <tr>
      <td>
      <asp:Button runat="server" ID="btnNormalEvent" Text="创建事件" CssClass="button"
              onclick="btnNormalEvent_Click" />
      <asp:Button runat="server" ID="btnSetUpShop" Text="创建事件" CssClass="button"
              onclick="btnSetUpShop_Click" />
      <asp:Button runat="server" ID="btnShutUpShop" Text="创建事件" CssClass="button"
              onclick="btnShutUpShop_Click" />
      <asp:Button runat="server" ID="btnStoreRenovation" Text="创建事件" CssClass="button"
              onclick="btnStoreRenovation_Click" />
      </td>
      <td>
      </td>
      </tr>
      </table>
</div>
<div runat="server" id="storeInformation" visible="false">
<h2>StoreInformation</h2>
    <asp:Button runat="server" ID="btnStoreInformation" Text="门店信息" 
        CssClass="button" onclick="btnStoreInformation_Click" />
    <asp:Button runat="server" ID="btnStoreEvents" Text="最近事件" CssClass="button" 
        onclick="btnStoreEvents_Click" />
    <asp:Button runat="server" ID="btnStoreFacility" Text="门店设备" CssClass="button" 
        onclick="btnStoreFacility_Click" />
<div runat="server" id="divStoreInformation" visible="false" style="width:800px">
<div class="content-box-header" ><h3 style="cursor: s-resize;">StoreInformation</h3></div>
<div class="content-box-content">
<table id="tbStoreInformation">
<tr>
    <td><asp:Label runat="server" Text="店号：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreNo" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="重点店：" Font-Bold="true"></asp:Label><asp:Label ID="lblTopStore" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="类型：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreType" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    
    <td><asp:Label runat="server" Text="区域：" Font-Bold="true"></asp:Label><asp:Label ID="lblRegion" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="等级：" Font-Bold="true"></asp:Label><asp:Label ID="lblRating" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="联系电话：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreTel" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td colspan="2"><asp:Label runat="server" Text="地址：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreAddress" runat="server" Text=""></asp:Label></td>
    <td><asp:Label  runat="server" Text="状态：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreState" runat="server" Text=""></asp:Label></td>
</tr>
</table>
</div>
</div>
<div runat="server" id="divgvEvent" visible="false" style="width:1000px">
<div class="content-box-header" ><h3 style="cursor: s-resize;">StoreEvents</h3></div>
<div class="content-box-content">
    <asp:GridView ID="gvEvent" runat="server" AutoGenerateColumns="False" >
    <Columns>
           <asp:BoundField DataField="EventNo">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventTime">
                 <ItemStyle Width="120px" />
           </asp:BoundField>
           <asp:BoundField DataField="StoreNo">
                 <ItemStyle Width="30px" />
           </asp:BoundField>
           <asp:BoundField DataField="TypeCode">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventDescribe">
                 <ItemStyle Width="200px" />
           </asp:BoundField>
           <asp:BoundField DataField="ResolvedBy">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventState">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="LogBy">
                 <ItemStyle Width="60px" />
           </asp:BoundField>
           <asp:HyperLinkField HeaderStyle-Width="60px" DataNavigateUrlFields="EventNo,TypeCode" DataNavigateUrlFormatString="NormalEvent.aspx?eventNo={0}&typeCode={1}" Text="查看详情" />
    </Columns>
    </asp:GridView>
</div>
</div>
<div runat="server" id="divFacility" visible="false" style="width:1170px">
<div class="content-box-header" ><h3 style="cursor: s-resize;">StoreFacility</h3></div>
<div class="content-box-content"> 
     <asp:GridView ID="gvFacility" runat="server" AutoGenerateColumns="False">
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
                <ItemStyle Width="80px" />
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
    </Columns>
    </asp:GridView>
</div>
</div>
</div>
      </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
