<%@ Page Title="设备返库调拨" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="FacilityAllotByEvent.aspx.cs" Inherits="LuxERP.UI.EventManagement.FacilityAllotByEvent"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
#main-content table td, #main-content table th 
{
    padding: 5px;
}
#main-content 
{
  margin: 0 20px 0 240px;
  padding: 40px 0 0 0;
}
.ui-dialog-titlebar span
{   
    display: inline-block;
    text-align: center;
}
#myContent_gvFacility td, th
{
    padding: 5px;
}
</style>
<script type="text/javascript">
    $(function () {
        menuSlide('#eventManage', '#eventQuery');
    });

    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };

    function setDialog() {
        $("#myContent_facility").dialog({
            autoOpen: false,
            height: 400,
            width: 1060,
            modal: true,
            close: function (event, ui) {
                $("#myContent_facility").dialog("destroy");
                $("#myContent_gvFacility").hide();
                $("#myContent_divAddStoreFacilities").hide();
                $("#myContent_divNogvFacility").hide();             
            },
            show: {
                effect: "slide",
                direction: "left",
                resizable: true,
                duration: 250
            },
            hide: {
                effect: "slide",
                duration: 250
            }
        });
    }

    function showDialog() {
        setDialog();
        $('#myContent_facility').dialog('open');
        $('#myContent_gvFacility').find("tr:odd").attr("style", "background-color: #DFDFDF;");
    }

    function btnAddStoreFacilitieClick() {
        var rowid = getCheckString();
        $("input[name='RowID']").val(rowid);
        $("input[name='FunName']").val("btnAddStoreFacilities()");
        $("#form1").submit();
    }
    function getCheckString() {
        var row = "";
        var n = "";
        $("input[type='checkbox']").each(function () {
            if (this.checked == true) {
                n = parseInt(this.id.substring(this.id.indexOf("chkSelect_") + 10, this.id.length)) + 1;
                row += $("#myContent_gvFacility tr:eq(" + n + ") td:eq(13)").text() + ","
            }
        });
        row = row.substring(0, row.length - 1);
        return row;
    }
    function clean() {
        $("input[name='RowID']").val();
        $("input[name='FunName']").val();
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Button ID="btnReturnEventQuery" runat="server" Text="返回事件详情" 
        CssClass="button" onclick="btnReturnEventQuery_Click" />
    <h2>StoreFacilitiesFlitting</h2>
<div id="divFacilitiesFlitting" runat="server" style="width:1060px">
<div id="divFacilitiesFlittingHeader" class="content-box-header" ><h3 style="cursor: s-resize;">Facilities</h3></div>
<div id="divFacilitiesFlittingContent" class="content-box-content">
<asp:Button ID="btnStoreFacilities" runat="server" Text="查看门店设备" CssClass="button" 
        onclick="btnStoreFacilities_Click" />
<div id="noFlittingText" runat="server" visible="false" style=" width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label ID="Label1" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">未添加返库设备</asp:Label>
</div>
<asp:GridView ID="gvFacilitiesFlitting" runat="server" AutoGenerateColumns="False" >
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
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="PurchaseDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="GuaranteeTime">
                <ItemStyle Width="85px" />
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
<asp:Button ID="btnReSet" runat="server" Text="重置" CssClass="button" 
        onclick="btnReSet_Click" />
</div>
</div>

<div style="width:600px">
<div id="divExpressHeader" class="content-box-header" ><h3 style="cursor: s-resize;">Express</h3></div>
<div id="divExpressContent" class="content-box-content">
    <div id="noExpressText" runat="server" visible="false" style="width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
        <asp:Label runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">加入返库设备后操作</asp:Label>
    </div>
    <asp:GridView ID="gvExpress" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="gvExpress_RowDataBound" 
        onselectedindexchanging="gvExpress_SelectedIndexChanging">
    <Columns>
            <asp:BoundField DataField="ExpressCo">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="ExpressNo">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="ExpressState">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:CommandField  ShowSelectButton="true" SelectText="单号失效"  ControlStyle-Width="100px"/>
    </Columns>
    </asp:GridView>
    <div id="divAddExpress" runat="server" visible="false">
        <asp:Label runat="server" Text="快递公司："></asp:Label>
        <asp:DropDownList ID="ddlExpressCo" runat="server">
        </asp:DropDownList>
        <%--<asp:TextBox ID="txtExpressCo" runat="server"></asp:TextBox>--%>
        <asp:Label runat="server" Text="快递单号："></asp:Label>
        <asp:TextBox ID="txtExpressNo" runat="server"></asp:TextBox>
        <asp:Button ID="btnAddExpress" runat="server" Text="确认" CssClass="button" 
            onclick="btnAddExpress_Click" />
    </div>
</div>
</div>

<div id="divCheckFacility" runat="server" style="width:600px">
<div id="divCheckFacilityHeader" class="content-box-header" ><h3 style="cursor: s-resize;">CheckFacility</h3></div>
<div id="divCheckFacilityContent" class="content-box-content">
    <div id="noCheckFacilityText" runat="server" visible="false" style="width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
        <asp:Label ID="Label2" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">发货后操作</asp:Label>
    </div>
    <asp:GridView ID="gvCheckFacility" runat="server" AutoGenerateColumns="False"  
        CssClass="stylevisibilityh" 
        onselectedindexchanging="gvCheckFacility_SelectedIndexChanging">
    <Columns>
            <asp:BoundField DataField="Maching">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Brand">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="Model">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Parameter">
                <ItemStyle Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="SerialNo">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:CommandField  ShowSelectButton="true" SelectText="寄运异常"  ControlStyle-Width="100px"/>
    </Columns>
    </asp:GridView>
    <div id="divtxtStockNo" runat="server">
    <asp:Label runat="server" Text="仓库编号："></asp:Label>
    <asp:TextBox ID="txtStockNo" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnAddAllAllotStock" runat="server" Text="已到货" CssClass="button" 
        onclick="btnAddAllAllotStock_Click" Visible="false"/>
</div>
</div>

<div id="divHistory" runat="server" style="width:1020px" visible="false">
<div id="divHistoryHeader" class="content-box-header" ><h3 style="cursor: s-resize;">FacilitiesFlittingHistory</h3></div>
<div id="divHistoryContent" class="content-box-content">
    <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="gvHistory_RowDataBound" >
    <Columns>
            <asp:BoundField DataField="WarehouseStoreNoA">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="WarehouseStoreNoB">
                <ItemStyle Width="80px" />
            </asp:BoundField>
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
            <asp:BoundField DataField="AllotStockDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="AllotStockState">
                <ItemStyle Width="60px" />
            </asp:BoundField>
    </Columns>
    </asp:GridView>
</div>
</div>

<div id="facility" runat="server"> 
     <asp:GridView ID="gvFacility" runat="server" AutoGenerateColumns="False">
          <Columns>
            <asp:TemplateField>   
              <HeaderStyle HorizontalAlign="Center" Width="10px" />   
              <ItemTemplate>   
                 <asp:CheckBox ID="chkSelect" runat="server" />   
              </ItemTemplate>   
            </asp:TemplateField>
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
                <ItemStyle Width="85px" />
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
            <asp:BoundField DataField="ID" HeaderStyle-CssClass="stylevisibilityh">
                <ItemStyle CssClass="stylevisibilityh" Width="0px" />
            </asp:BoundField>
    </Columns>
    </asp:GridView>
    <div id="divAddStoreFacilities" runat="server" visible="false">
    <button id="btnAddStoreFacilitie" name="btnAddStoreFacilitie" class="button" runat="server" onclick="btnAddStoreFacilitieClick()">确认</button>
    </div>
    <div id="divNogvFacility" runat="server" visible="false" style=" width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">门店设备已全部进入预返库状态</asp:Label>
</div>
    </div>
        <input type="hidden" name="FunName">
        <input type="hidden" name="RowID">
</ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
