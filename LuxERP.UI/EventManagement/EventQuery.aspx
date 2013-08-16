<%@ Page Title="事件查询" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="EventQuery.aspx.cs" Inherits="LuxERP.UI.EventManagement.eventQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            menuSlide('#eventManage', '#eventQuery');
            setDate();
//            $('#result').hide();
//            $('#myContent_btnNormalEventQuery').click(function () {
//            $('#result').show();
        });
    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };

    function check() {
        var a = $('#myContent_txtCurPage').val();
        var reg = /^\d{1,5}$/;
        if (reg.test(a)) {
            return true;
        }
        else {
            alert("0到9的数字，不超过5位");
            return false;
        }
    }

    function setDate() {
        $("#myContent_txtAEventTime").datepicker({
            onClose: function (selectedDate) {
                $("#myContent_txtBEventTime").datepicker("option", "minDate", selectedDate);
            }
        });
        $("#myContent_txtBEventTime").datepicker({
            onClose: function (selectedDate) {
                $("#myContent_txtAEventTime").datepicker("option", "maxDate", selectedDate);
            }
        });

        $('#myContent_txtAEventTime').datepicker();
        $('#myContent_txtAEventTime').datepicker("option", "dateFormat", "yy-mm-dd");
        $("#myContent_txtAEventTime").datepicker("option", $.datepicker.regional["zh-TW"]);
        $("#myContent_txtAEventTime").datepicker("option", "changeMonth", "true");
        $("#myContent_txtAEventTime").datepicker("option", "changeYear", "true");
        $('#myContent_txtBEventTime').datepicker();
        $('#myContent_txtBEventTime').datepicker("option", "dateFormat", "yy-mm-dd");
        $("#myContent_txtBEventTime").datepicker("option", $.datepicker.regional["zh-TW"]);
        $("#myContent_txtBEventTime").datepicker("option", "changeMonth", "true");
        $("#myContent_txtBEventTime").datepicker("option", "changeYear", "true");
    };

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
<h2>EventQuery</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div>
    <asp:Label runat="server" Text="事件编号："></asp:Label>
    <asp:TextBox ID="txtEventNo" runat="server" Width="100"></asp:TextBox>
    <asp:Label runat="server" Text="类型编号："></asp:Label>
    <asp:TextBox ID="txtTypeCode" runat="server" Width="100" ontextchanged="txtTypeCode_TextChanged" AutoPostBack="true"></asp:TextBox>
    <asp:Label ID="lblEventTime" runat="server" Text="创建时间："></asp:Label><asp:TextBox ID="txtAEventTime" runat="server" Width="100"></asp:TextBox>
    <asp:Label runat="server" Text="至"></asp:Label><asp:TextBox ID="txtBEventTime" runat="server" Width="100"></asp:TextBox>
    <asp:Label runat="server" Text="店号："></asp:Label><asp:TextBox ID="txtStoreNo" runat="server" Width="100"></asp:TextBox>    
    <asp:Label runat="server" Text="状态："></asp:Label><asp:DropDownList ID="ddlEventState" runat="server"></asp:DropDownList>
    <asp:Button ID="btnNormalEventQuery" runat="server" Text="事件查询" CssClass="button" 
        onclick="btnNormalEventQuery_Click" />
</div>
    <div id="result">
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
           <asp:BoundField DataField="ToResolvedTime">
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
    <div id="showpage" runat="server" visible="false">
        到<asp:TextBox ID="txtCurPage" runat="server" Width="30px"></asp:TextBox>页
        <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="button" 
            onclick="btnGo_Click" OnClientClick="check();" Width="33px" /> 
        <asp:Label ID="lblCurrent" runat="server" Text="Label"></asp:Label> / 
        <asp:Label ID="lblTotalPages" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnFirstPage" runat="server" Text="|<首页" CssClass="button" 
            onclick="btnFirstPage_Click" />  
        <asp:Button ID="btnPrvPage" runat="server" Text="<<上一页" CssClass="button" 
            onclick="btnPrvPage_Click" />
        <asp:Button ID="btnNxtPage" runat="server" Text="下一页>>" CssClass="button" 
            onclick="btnNxtPage_Click" /> 
        <asp:Button ID="btnLastPage" runat="server" Text="尾页>|" CssClass="button" 
            onclick="btnLastPage_Click" /> 
    </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
