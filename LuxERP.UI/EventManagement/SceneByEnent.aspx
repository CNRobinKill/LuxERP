<%@ Page Title="上门服务" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="SceneByEnent.aspx.cs" Inherits="LuxERP.UI.EventManagement.SceneByEnent" %>
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

.right
{
  float:left;
  width: 280px;
  padding:5px 0px 5px 0px; 
}
.left
{
  float:left;  
  width: 280px;
  padding:5px 0px 5px 0px;
}
.clear
{
    clear: left;
}

</style>
<script type="text/javascript">
    $(function () {
        menuSlide('#eventManage', '#eventQuery');
        setDate();
    });

    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };

    function setDate() {
        $('#myContent_txtSceneTime').datepicker();
        $('#myContent_txtSceneTime').datepicker("option", "dateFormat", "yy-mm-dd");
        $("#myContent_txtSceneTime").datepicker("option", $.datepicker.regional["zh-TW"]);
        $("#myContent_txtSceneTime").datepicker("option", "changeMonth", "true");
        $("#myContent_txtSceneTime").datepicker("option", "changeYear", "true");
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

    function printHtml(html) {
        var bodyHtml = document.body.innerHTML;
        document.body.innerHTML = html;
        window.print();
        document.body.innerHTML = bodyHtml;
    }
    function onprint() {
        var html = $("#divWorkOrder").html();
        printHtml(html);
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
    <h2>StoreFacilitiesServices</h2>
<div id="divFacilitiesServices" runat="server" style="width:1060px">
<div id="divFacilitiesServicesHeader" class="content-box-header" ><h3 style="cursor: s-resize;">Facilities</h3></div>
<div id="divFacilitiesServicesContent" class="content-box-content">
<asp:Button ID="btnStoreFacilities" runat="server" Text="查看门店设备" CssClass="button" 
        onclick="btnStoreFacilities_Click" />
<div id="noFlittingText" runat="server" visible="false" style=" width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label ID="Label1" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">未添加需上门服务设备</asp:Label>
</div>
<asp:GridView ID="gvFacilitiesServices" runat="server" AutoGenerateColumns="False" >
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

<div id="divJobSchedule" visible="false" runat="server" style="width:800px">
<div id="divSceneStateHeader" class="content-box-header" ><h3 style="cursor: s-resize;">JobSchedule</h3></div>
<div id="divSceneStateContent" class="content-box-content">
<div style=" padding:15px 15px 15px 0px">
    <asp:Button ID="btnStart" runat="server" Text="开始上门" CssClass="button" 
        Width="100px" Height="50px" Font-Size="XX-Large" Font-Bold="true" 
        onclick="btnStart_Click" />
    <asp:Button ID="btnEndNo" runat="server" Text="结束上门(未完成)" Enabled="false" CssClass="button" 
        Width="150px" Height="50px" Font-Size="XX-Large" Font-Bold="true" 
        onclick="btnEndNo_Click"/>
    <asp:Button ID="btnEndOk" runat="server" Text="结束上门(完成)" Enabled="false" CssClass="button" 
        Width="130px" Height="50px" Font-Size="XX-Large" Font-Bold="true" 
        onclick="btnEndOk_Click"/>
    <asp:Button ID="btnGoOn" runat="server" Text="继续上门" Enabled="false" CssClass="button" 
        Width="100px" Height="50px" Font-Size="XX-Large" Font-Bold="true" 
        onclick="btnGoOn_Click"/>
    <asp:Button ID="btnChange" runat="server" Text="更换工程师" Enabled="false" CssClass="button" 
        Width="130px" Height="50px" Font-Size="XX-Large" Font-Bold="true" 
        onclick="btnChange_Click"/>
</div>
    
</div>
</div>

<div style="width:600px">
<div id="divEngineersHeader" class="content-box-header" ><h3 style="cursor: s-resize;">AppointEngineers</h3></div>
<div id="divEngineersContent" class="content-box-content">
    <div id="noEngineersText" runat="server" visible="false" style="width:600px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
        <asp:Label runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">添加需上门服务设备后操作</asp:Label>
    </div>
    <div id="divAddEngineers" runat="server" visible="false">
        <asp:Label runat="server" Text="选择工程师："></asp:Label>
        <asp:DropDownList ID="ddlName" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnAddEngineers" runat="server" Text="确认" CssClass="button" 
            onclick="btnAddEngineers_Click" />
    </div>
    <asp:GridView ID="gvAppointEngineers" runat="server" 
        AutoGenerateColumns="False" onrowdatabound="gvAppointEngineers_RowDataBound" 
        onselectedindexchanging="gvAppointEngineers_SelectedIndexChanging">
    <Columns>
            <asp:BoundField DataField="Name">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Phone">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Email">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="SceneTime">
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="AppointState">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:CommandField  ShowSelectButton="true" SelectText="取消更换"  ControlStyle-Width="100px"/>
    </Columns>
    </asp:GridView>
    <div>
    <asp:Label ID="lblSceneDate" runat="server" Text="上门时间：" Visible="false"></asp:Label>
    <asp:TextBox ID="txtSceneTime" Visible="false" runat="server" Width="80px"></asp:TextBox>
        <asp:DropDownList ID="ddlTime" runat="server" Visible="false">
        </asp:DropDownList>
    <asp:Label ID="lblSceneTime" runat="server" Text="时" Visible="false"></asp:Label>
    <asp:Button ID="btnWorkOrder" runat="server" Text="确认预约" Visible="false" CssClass="button" onclick="btnWorkOrder_Click" />
    <asp:Button ID="btnPreviewWorkOrder" runat="server" Text="预览工单" Visible="false" 
            CssClass="button" onclick="btnPreviewWorkOrder_Click" />
    </div>
</div>
</div>

<div id="divHistoryService" visible="false" runat="server" style="width:700px">
<div id="divHistoryServiceHeader" class="content-box-header" ><h3 style="cursor: s-resize;">HistoryService</h3></div>
<div id="divHistoryServiceContent" class="content-box-content">
<asp:GridView ID="gvHistoryService" runat="server" AutoGenerateColumns="False" >
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
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="SerialNo">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="PurchaseDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplier">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="ServiceDate">
                <ItemStyle Width="60px" />
            </asp:BoundField>
    </Columns>
 </asp:GridView>
</div>
</div>

<asp:GridView ID="gvEventSteps" runat="server" AutoGenerateColumns="False" Visible="false">
        <Columns>
                    <asp:BoundField DataField="StepTime" ReadOnly="True">
                        <ItemStyle Width="180px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StepDescribe"  ControlStyle-Width="420px">
                        <ItemStyle Width="450px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StepBy" ReadOnly="True">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StepState" ReadOnly="True">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
        </Columns>
</asp:GridView>


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
    <asp:Label runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">门店设备已全部进入服务状态</asp:Label>
    </div>
    </div>
        <input type="hidden" name="FunName">
        <input type="hidden" name="RowID">
</ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
