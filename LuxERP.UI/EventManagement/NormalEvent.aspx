<%@ Page Title="事件详情" Language="C#" EnableEventValidation = "false" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="NormalEvent.aspx.cs" Inherits="LuxERP.UI.EventManagement.NormalEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(function () {
        menuSlide('#eventManage', '#eventQuery');
        setTop();
        showDialog();
        setDate();
    });
    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };
    function setTop() {
        $(window).scroll(function () {
            var offsetTop = $(window).scrollTop() + 20 + "px";
            $("#float").animate({ top: offsetTop }, { duration: 300, queue: false });
        });
    }
    function showDialog() {
        $("#solutions").dialog({
            autoOpen: false,
            height: 400,
            width: 900,
            show: {
                effect: "slide",
                direction: "right",
                resizable: true,
                duration: 100
            },
            hide: {
                effect: "slide",
                duration: 100
            }         
        });
        $("#myContent_btnOpener").click(function () {
            $("#solutions").dialog("open");
        });
    }
    function setSolutions(content) {
        $("#solutions").html(content)
    };
    function setDate() {
        $('#myContent_txtToResolvedTime').datepicker();
        $('#myContent_txtToResolvedTime').datepicker("option", "dateFormat", "yy-mm-dd");
        $("#myContent_txtToResolvedTime").datepicker("option", $.datepicker.regional["zh-TW"]);
        $("#myContent_txtToResolvedTime").datepicker("option", "changeMonth", "true");
        $("#myContent_txtToResolvedTime").datepicker("option", "changeYear", "true");

    };

</script>
    <style type="text/css">
        #float
        {
            height:36px;
            width:140px;
            position:absolute;
            top:20px;
            right:10px;
            }
        .style3
        {
            width: 400px;
        }
        .style4
        {
            width: 420px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div id="float">
        <asp:Button ID="btnOpener" runat="server" CssClass="button" Width="130px"  Height="35px" Text="解决资源方案" onclick="btnOpener_Click" /></div>

<div style="width:800px">
<asp:Button ID="btnReturnEventQuery" runat="server" Text="返回事件查询页" CssClass="button" 
        onclick="btnReturnEventQuery_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnReturnCreateEvent" runat="server" Height="40px" Text="创建事件" 
        CssClass="button" onclick="btnReturnCreateEvent_Click" />
<h2>EventLog</h2>
<div style="width:800px; text-align:right"><asp:Button ID="btnStopEventLog" 
        runat="server" Text="关闭/作废事件" CssClass="button" 
        onclick="btnStopEventLog_Click" /></div>
<div class="content-box-header" ><h3 style="cursor: s-resize;">StoreInformation</h3></div>
<div class="content-box-content">
<table id="tbStoreInformation">
<tr>
    <td><asp:Label runat="server" Text="店号：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreNo" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="类型：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreType" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="区域：" Font-Bold="true"></asp:Label><asp:Label ID="lblRegion" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    
    <td><asp:Label runat="server" Text="联系电话：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreTel" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="宽带账号：" Font-Bold="true"></asp:Label><asp:Label ID="lblADSL" runat="server" Text=""></asp:Label></td>
    <td><asp:Label runat="server" Text="状态：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreState" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td colspan="2"><asp:Label runat="server" Text="地址：" Font-Bold="true"></asp:Label><asp:Label ID="lblStoreAddress" runat="server" Text=""></asp:Label></td>
</tr>
</table>
</div>
</div>

<div style="width:850px">
<div class="content-box-header" ><h3 style="cursor: s-resize;">EventInformation</h3></div>
<div class="content-box-content">
<table id="tbEventInformation">
<tr>
    <td class="style4"><asp:Label ID="Label1" runat="server" Text="事件编号：" Font-Bold="true"></asp:Label><asp:Label ID="lblEventNo" runat="server" Text=""></asp:Label></td>
    <td><asp:Label ID="Label2" runat="server" Text="创建时间：" Font-Bold="true"></asp:Label><asp:Label ID="lblEventTime" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td class="style4"><asp:Label ID="Label3" runat="server" Text="事件类型：" Font-Bold="true"></asp:Label><asp:Label ID="lblType" runat="server" Text=""></asp:Label><asp:TextBox ID="txtType" runat="server" Visible="false"></asp:TextBox></td>
    <td><asp:Label ID="Label4" runat="server" Text="事件简述：" Font-Bold="true"></asp:Label><asp:Label ID="lblEventDescribe" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td class="style4"><asp:Label ID="Label5" runat="server" Text="创建人：" Font-Bold="true"></asp:Label><asp:Label ID="lblLogBy" runat="server" Text=""></asp:Label></td>
    <td><asp:Label ID="Label6" runat="server" Text="当前状态：" Font-Bold="true"></asp:Label><asp:DropDownList ID="ddlEventState" runat="server" Enabled="false" AutoPostBack="true" onselectedindexchanged="ddlEventState_SelectedIndexChanged" ></asp:DropDownList></td>
</tr>
<tr><td class="style4">
                        <asp:Button ID="btnUpdateEventType" runat="server" Text="更改类型" CssClass="button" onclick="btnUpdateEventType_Click"/>
                        <asp:Button ID="btnOKUpdateType" runat="server" Text="确认类型" CssClass="button" Visible="false" onclick="btnOKUpdateType_Click"/>
                        <asp:Button ID="btnSendEventTo" runat="server" Text="移交事件" CssClass="button" onclick="btnSendEventTo_Click"/>
                        <asp:Button ID="btnOKSend" runat="server" Text="确认移交" CssClass="button" Visible="false" onclick="btnOKSend_Click"/>
                        <asp:Button ID="btnUpdateToResolvedTime" runat="server" Text="更改日期" CssClass="button" onclick="btnUpdateToResolvedTime_Click" />
                        <asp:Button ID="btnOKUpdateToResolvedTime" runat="server" Visible="false" Text="确认日期" CssClass="button" onclick="btnOKUpdateToResolvedTime_Click" />           
                        <asp:Button ID="btnUpdateEventState" runat="server" Text="更新状态" CssClass="button" onclick="btnUpdateEventState_Click" />
                        <asp:Button ID="btnOKUpdate" runat="server" Visible="false" Text="确认状态" CssClass="button" onclick="btnOKUpdate_Click" /> 
                       <asp:Label ID="lblResolvedTimeText" runat="server" Text="解决时间：" Font-Bold="true" Visible="false"></asp:Label><asp:Label ID="lblResolvedTime" runat="server" Text="" Visible="false"></asp:Label></td>
    <td>
    <asp:Label ID="lblResolvedByText" runat="server" Text="解决人/组织：" Font-Bold="true" Visible="false"></asp:Label><asp:Label ID="lblResolvedBy" runat="server" Text="" Visible="false"></asp:Label><asp:DropDownList ID="ddlResolvedBy" runat="server" Visible="false"></asp:DropDownList>
    <asp:Label ID="lblSendEventTo" runat="server" Text="移交给：" Font-Bold="true" Visible="false"></asp:Label><asp:DropDownList ID="ddlSendEventTo" runat="server" Visible="false"></asp:DropDownList>
    <asp:Label ID="lblSetUpDate" runat="server" Text="开店日期：" Font-Bold="true" Visible="false"></asp:Label><asp:Label ID="lblShutUpDate" runat="server" Text="关店日期：" Font-Bold="true" Visible="false"></asp:Label><asp:Label ID="lblEndDate" runat="server" Text="结束日期：" Font-Bold="true" Visible="false"></asp:Label><asp:Label ID="lblToResolvedTime" runat="server" Visible="false"></asp:Label><asp:TextBox ID="txtToResolvedTime" runat="server" Visible="false" Width="80px"></asp:TextBox>
    </td>
</tr>
</table>
</div>
</div>

<div style="width:870px">
<div class="content-box-header" ><h3 style="cursor: s-resize;">Event-handlingProcedure</h3></div>
<div class="content-box-content">

    <div id="divThreeBtn" runat="server">
        <asp:Button ID="btnFacilityMatchingAndOutByEvent" runat="server" 
            Text="匹配出库" CssClass="button" Width="100" 
            onclick="btnFacilityMatchingAndOutByEvent_Click"/>
        <asp:Button ID="btnFacilityAllotByEvent" runat="server" Text="返库调拨" 
            CssClass="button" Width="100" onclick="btnFacilityAllotByEvent_Click"/>
        <asp:Button ID="btnSceneByEnent" runat="server" Text="上门服务" CssClass="button" 
            Width="100" onclick="btnSceneByEnent_Click"/>
    </div>

<asp:GridView ID="gvEventSteps" runat="server" AutoGenerateColumns="False" 
        onrowediting="gvEventSteps_RowEditing" 
        onrowcancelingedit="gvEventSteps_RowCancelingEdit" 
        onrowdatabound="gvEventSteps_RowDataBound" 
        onrowupdating="gvEventSteps_RowUpdating">
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
                    <asp:TemplateField HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <%# Eval("StepState")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdStepState" runat="server" Value='<%# Eval("StepState") %>' />
                            <asp:DropDownList ID="ddlStepState" runat="server" />
                        </EditItemTemplate>
                     <ItemStyle Width="60px" />
                    </asp:TemplateField>
                    <asp:CommandField  ShowEditButton="True" EditText="修改" ControlStyle-Width="50px"/>
        </Columns>
    </asp:GridView>
    <table><tr><td style="width:240px">
        <asp:Button ID="btnReOpenEvent" runat="server" Text="事件延伸" CssClass="button" Visible="false" 
            onclick="btnReOpenEvent_Click" /></td>
    <td style="width:400px">
        <asp:TextBox ID="txtStepDescribe" runat="server" Width="300px"></asp:TextBox>
        </td><td style="width:100px"><asp:Button ID="btnAddEventSteps" runat="server" Text="添加" CssClass="button" onclick="btnAddEventSteps_Click"></asp:Button>
        </td><td style="width:100px"></td>
        <td style="width:50px">
        </td>
    </tr>
    </table>
    </div>
<div id="solutions" title="解决资源方案" style="font-size:20px">
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
