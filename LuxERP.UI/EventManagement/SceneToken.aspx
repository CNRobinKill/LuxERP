<%@ Page Title="" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="SceneToken.aspx.cs" Inherits="LuxERP.UI.EventManagement.SceneToken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlide('#eventManage', '#eventQuery');
        setDate();
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
    };

    function setDate() {
        $("#myContent_txtAServiceTime").datepicker({
            onClose: function (selectedDate) {
                $("#myContent_txtBServiceTime").datepicker("option", "minDate", selectedDate);
            }
        });
        $("#myContent_txtBServiceTime").datepicker({
            onClose: function (selectedDate) {
                $("#myContent_txtAServiceTime").datepicker("option", "maxDate", selectedDate);
            }
        });

        $('#myContent_txtAServiceTime').datepicker();
        $('#myContent_txtAServiceTime').datepicker("option", "dateFormat", "yy-mm-dd");
        $("#myContent_txtAServiceTime").datepicker("option", $.datepicker.regional["zh-TW"]);
        $("#myContent_txtAServiceTime").datepicker("option", "changeMonth", "true");
        $("#myContent_txtAServiceTime").datepicker("option", "changeYear", "true");
        $('#myContent_txtBServiceTime').datepicker();
        $('#myContent_txtBServiceTime').datepicker("option", "dateFormat", "yy-mm-dd");
        $("#myContent_txtBServiceTime").datepicker("option", $.datepicker.regional["zh-TW"]);
        $("#myContent_txtBServiceTime").datepicker("option", "changeMonth", "true");
        $("#myContent_txtBServiceTime").datepicker("option", "changeYear", "true");
    };

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
<h2>TokenStatistics</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div>
    <asp:Label runat="server" Text="事件编号："></asp:Label><asp:TextBox ID="txtEventNo" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="上门类型："></asp:Label>
    <asp:DropDownList ID="ddlSceneType" runat="server" 
        ondatabound="ddlSceneType_DataBound"></asp:DropDownList>
    <asp:Label runat="server" Text="服务时间："></asp:Label><asp:TextBox ID="txtAServiceTime" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="至"></asp:Label><asp:TextBox ID="txtBServiceTime" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="服务商："></asp:Label>
    <asp:DropDownList ID="ddlServiceProvider" runat="server" 
        ondatabound="ddlServiceProvider_DataBound"></asp:DropDownList>
    <asp:Button ID="btnTokenQuery" runat="server" Text="Token查询" CssClass="button" 
        onclick="btnTokenQuery_Click" />
</div>
    <div id="result">
    <asp:GridView ID="gvToken" runat="server" AutoGenerateColumns="False" 
            onrowdatabound="gvToken_RowDataBound" >
    <Columns>
           <asp:BoundField DataField="N">
                 <ItemStyle Width="20px" />
           </asp:BoundField>
           <asp:BoundField DataField="EventNo">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="TimeStart">
                 <ItemStyle Width="150px" />
           </asp:BoundField>
           <asp:BoundField DataField="TimeEnd">
                 <ItemStyle Width="150px" />
           </asp:BoundField>
           <asp:BoundField DataField="SceneType">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:BoundField DataField="BaseToken">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="MultiplyingPower">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="Total">
                 <ItemStyle Width="50px" />
           </asp:BoundField>
           <asp:BoundField DataField="ServiceProvider">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
           <asp:HyperLinkField HeaderStyle-Width="60px" 
               DataNavigateUrlFields="EventNo,TypeCode" 
               DataNavigateUrlFormatString="NormalEvent.aspx?eventNo={0}&typeCode={1}" 
               Text="查看事件" Target="_blank" >
           <HeaderStyle Width="60px" />
           </asp:HyperLinkField>
           <asp:BoundField DataField="ScenePic">
                 <ItemStyle Width="100px" />
           </asp:BoundField>
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
