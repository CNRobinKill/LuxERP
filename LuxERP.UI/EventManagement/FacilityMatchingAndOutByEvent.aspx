<%@ Page Title="设备出库" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="FacilityMatchingAndOutByEvent.aspx.cs" Inherits="LuxERP.UI.EventManagement.FacilityMatchingAndOutByEvent" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .ui-dialog-titlebar span
        {   
            display: inline-block;
            text-align: center;
        }
        #myContent_gvFacility td, th
        {
            padding: 5px;
        }
        #main-content table td
        {
            padding:5px
        }
</style>
<script type="text/javascript">
        $(function () {
            menuSlide('#eventManage', '#eventQuery');
        })
        function addRowStyle() {
            $('tbody tr:even').addClass('alt-row');
        }
        function setDialog() {
            $("#myContent_facility").dialog({
                autoOpen: false,
                height: 400,
                width: 1000,
                modal: true,
                close: function (event, ui) {
                    $("#myContent_facility").dialog("destroy");
                    $("#myContent_gvFacility").hide();
                    $("#myContent_divChkOld").hide();
                },
                show: {
                    effect: "slide",
                    direction: "left",
                    resizable: true,
                    duration: 200
                },
                hide: {
                    effect: "slide",
                    duration: 200
                }
            });
            }
        function showDialog() {
            setDialog();
            $('#myContent_facility').dialog('open');
            $('#myContent_gvFacility').find("tr:odd").attr("style", "background-color: #DFDFDF;");
            $('#myContent_gvFacility').find("a").addClass("button");
        }
        function chkOld() {
            var text = $("#myContent_labRow").text();
            var ahref = $("a[href='javascript:__doPostBack('ctl00$myContent$gvOutStockDemands','Select$" + text + "')']").attr('href');
            var x = ahref.indexOf("Select$");
            var y = ahref.indexOf("')");
            var z = ahref.indexOf("')")-2;
            var idstringO = ahref.substring(x, y);
            var idstringT = ahref.substring(x, z) + text;
            $("<span id = '" + idstringT + "'></span>").appendTo($("a[href='javascript:__doPostBack('ctl00$myContent$gvOutStockDemands','" + idstringO + "')']"));
            $("button[title='close']").click();
//            function show() { "$('#" + idstringT + "').click()" };
            setTimeout("$('#" + idstringT + "').click()", 210);
//            $("#" + idstringT + "").remove()
        }



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" >
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<asp:Button ID="btnReturnEventQuery" runat="server" Text="返回事件详情" 
        CssClass="button" onclick="btnReturnEventQuery_Click" />
<h2>FacilityMatching&Ex-warehouse</h2>
        <asp:Label ID="labRow" runat="server" Text="" CssClass="stylevisibilityh"></asp:Label>
<div id="divFacilityList" runat="server" style="width:670px">
<div id="divFacilityListHeader" class="content-box-header" ><h3 style="cursor: s-resize;">FacilityList</h3></div>
    <div id="divFacilityListContent" class="content-box-content">
    <asp:Label runat="server" Text="机器名称："></asp:Label>
    <asp:DropDownList ID="ddlMaching" runat="server" 
            onselectedindexchanged="ddlMaching_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>
    <asp:Label runat="server" Text="品牌："></asp:Label>
    <asp:DropDownList ID="ddlBrand" runat="server" 
            onselectedindexchanged="ddlBrand_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    <asp:Label runat="server" Text="型号："></asp:Label>
    <asp:DropDownList ID="ddlModel" runat="server" 
            onselectedindexchanged="ddlModel_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    <asp:Label runat="server" Text="参数："></asp:Label>
    <asp:DropDownList ID="ddlParameter" runat="server"></asp:DropDownList>
    <asp:Button ID="btnAddOutStockDemands" runat="server" Text="添加" 
        CssClass="button" onclick="btnAddOutStockDemands_Click" />
    <div id="noRecordsText2" runat="server" visible="false" style="width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">没有找到任何数据</asp:Label>
    </div>
    <asp:GridView ID="gvOutStockDemands" runat="server" AutoGenerateColumns="False" 
        onrowdeleting="gvOutStockDemands_RowDeleting" 
            onselectedindexchanging="gvOutStockDemands_SelectedIndexChanging" >
    <Columns>
            <asp:BoundField DataField="Maching">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Brand">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Model">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Parameter">
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:CommandField ShowSelectButton="true" SelectText="手动匹配"  ControlStyle-Width="70px" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="50px" />
    </Columns>
    </asp:GridView>
    <div id="divbtnMatching" runat="server" visible="false" style="width:650px; height:30px; padding-top:10px">
        <asp:CheckBox ID="chkOldMatching" runat="server" Width="15px" />
        <asp:Label runat="server" Text="加入旧设备匹配" Width="100px" Height="15px"></asp:Label>
        <asp:Button ID="btnMatching" runat="server" Text="一键匹配" CssClass="button" onclick="btnMatching_Click"/>
    </div>
</div>
</div>
<div id="divMatchingResults" runat="server" style="width:1000px">
<div id="divMatchingResultsHeader" class="content-box-header" ><h3 style="cursor: s-resize;">MatchingResults</h3></div>
    <div id="divMatchingResultsContent" class="content-box-content">
    <div id="noRecordsText1" runat="server" visible="false" style=" width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">未进行匹配/所有设备没库存</asp:Label>
    </div>
    <asp:Image ID="imgMatchingOk" runat="server" ImageUrl="~/Content/images/Matching_Ok.png" Visible="false" />
    <div id="divPrint" runat="server" visible="false" style="width:900px; text-align:right">
        <asp:Button ID="btnPrint" runat="server" Text="打印调拨单" CssClass="button" 
            onclick="btnPrint_Click"/>
    </div>
    <asp:GridView ID="gvMatchingResults" runat="server" AutoGenerateColumns="False" >
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
            <asp:BoundField DataField="PurchaseDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="GuaranteeTime">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="RepairsNo">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplier">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="AddStockDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
    </Columns>
    </asp:GridView>
    <asp:Image ID="imgMatchingNo" runat="server" ImageUrl="~/Content/images/Matching_No.png" Visible="false" />
    <asp:GridView ID="gvNoMatching" runat="server" AutoGenerateColumns="False" >
    <Columns>
            <asp:BoundField DataField="Maching">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Brand">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Model">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Parameter">
                <ItemStyle Width="150px" />
            </asp:BoundField>
    </Columns>
    </asp:GridView>
    <asp:Button ID="btnSendStockIn" runat="server" Text="发送入库需求" CssClass="button" 
            Visible="false" onclick="btnSendStockIn_Click" />
    </div>
</div>
<div style="width:600px">
<div id="divExpressHeader" class="content-box-header" ><h3 style="cursor: s-resize;">Express</h3></div>
<div id="divExpressContent" class="content-box-content">
    <div id="noExpressText" runat="server" visible="false" style="width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
        <asp:Label runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">完成匹配后操作</asp:Label>
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
<%--        <asp:TextBox ID="txtExpressCo" runat="server"></asp:TextBox>--%>
        <asp:DropDownList ID="ddlExpressCo" runat="server">
        </asp:DropDownList>
        <asp:Label runat="server" Text="快递单号："></asp:Label>
        <asp:TextBox ID="txtExpressNo" runat="server"></asp:TextBox>
        <asp:Button ID="btnAddExpress" runat="server" Text="确认" CssClass="button" 
            onclick="btnAddExpress_Click" />
    </div>
</div>
</div>

<div id="divHistory" runat="server" style="width:1020px" visible="false">
<div id="divHistoryHeader" class="content-box-header" ><h3 style="cursor: s-resize;">Ex-warehouseHistory</h3></div>
<div id="divHistoryContent" class="content-box-content">
    <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="gvHistory_RowDataBound" >
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
            <asp:BoundField DataField="PurchaseDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="GuaranteeTime">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="RepairsNo">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplier">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="OutStockDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="OutStocksState">
                <ItemStyle Width="60px" />
            </asp:BoundField>
    </Columns>
    </asp:GridView>
</div>
</div>


<div id="divCheckFacility" runat="server" style="width:600px">
<div id="divCheckFacilityHeader" class="content-box-header" ><h3 style="cursor: s-resize;">CheckFacility</h3></div>
<div id="divCheckFacilityContent" class="content-box-content">
    <div id="noCheckFacilityText" runat="server" visible="false" style="width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
        <asp:Label ID="Label1" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">发货后操作</asp:Label>
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
    <asp:Button ID="btnAddAllOutStock" runat="server" Text="已到货" CssClass="button" 
        onclick="btnAddAllOutStock_Click" Visible="false"/>
</div>
</div>

<div id="divUpload" runat="server" visible="false" style="width:500px" >
<div id="divUploadHeader" class="content-box-header" ><h3 style="cursor: s-resize;">Upload</h3></div>
<div id="divUploadContent" class="content-box-content">
    <div id="uploado"  runat="server" visible="false" style=" text-align:center">调拨单：<asp:FileUpload ID="fuFile" runat="server" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpload"  runat="server" CssClass="button" Text="确定上传" onclick="btnUpload_Click" /></div>
    <div id="uploadt"  runat="server" visible="false" style=" text-align:center">
        <asp:Button ID="btnShowPic"  runat="server" CssClass="button" Text="查看调拨单" 
            onclick="btnShowPic_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDelPic"  runat="server" CssClass="button" Text="重置" 
            onclick="btnDelPic_Click" /></div>
</div>
</div>

<div id="facility" runat="server" title="手动匹配"> 
<div id="divChkOld" runat="server" style="width:100px; height:20px; padding: 10px; font-size: 13px; visibility:hidden" >
    <%--<asp:CheckBox ID="chkOld" runat="server" Text="使用旧设备" />--%>
    <input id="chkOld" runat="server" type="checkbox" onclick="chkOld()" /><label>使用旧设备</label>
</div>
     <asp:GridView ID="gvFacility" runat="server" AutoGenerateColumns="False" 
         onselectedindexchanging="gvFacility_SelectedIndexChanging">
          <Columns>
            <asp:CommandField  ShowSelectButton="true" SelectText="更换匹配"  ControlStyle-Width="60px" HeaderStyle-Width="70px"/>
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
            <asp:BoundField DataField="PurchaseDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="GuaranteeTime">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="RepairsNo">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplier">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="AddStockDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
    </Columns>
    </asp:GridView>
</div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
