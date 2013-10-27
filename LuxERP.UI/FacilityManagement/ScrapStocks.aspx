<%@ Page Title="废损设备查询" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="ScrapStocks.aspx.cs" Inherits="LuxERP.UI.FacilityManagement.ScrapStocks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#myContent_gvScrapStock th, td {
padding: 2px !important;
line-height: 1.3em !important;
}
</style>
<script type="text/javascript">
    $(function () {
        menuSlide('#stockManage', '#scrapStocks');
        setDate();
//        $('#result').hide();
//        $('#myContent_btnQuery').click(function () {
//        $('#result').show();
//        });
    });

    function setTableColor() {
        $('#myContent_gvScrapStock tr:odd').css('background-color', '#D5E9DF');
    }

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

    function set(id) {
        $(id).datepicker();
        $(id).datepicker("option", "dateFormat", "yy-mm-dd");
        $(id).datepicker("option", $.datepicker.regional["zh-TW"]);
        $(id).datepicker("option", "changeMonth", "true");
        $(id).datepicker("option", "changeYear", "true");
    };

    function setDate() {
        $("#myContent_txtAddScrapStockDateA").datepicker({
            onClose: function (selectedDate) {
                $("#myContent_txtAddScrapStockDateB").datepicker("option", "minDate", selectedDate);
            }
        });
        $("#myContent_txtAddScrapStockDateB").datepicker({
            onClose: function (selectedDate) {
                $("#myContent_txtAddScrapStockDateA").datepicker("option", "maxDate", selectedDate);
            }
        });

        set('#myContent_txtAddScrapStockDateA');
        set('#myContent_txtAddScrapStockDateB');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <h2>ScrapStocks</h2>
      <div>
        仓库编号：<asp:TextBox ID="txtWarehouseNo" runat="server" Width="40px"></asp:TextBox>&nbsp;
        废损日期：<asp:TextBox ID="txtAddScrapStockDateA" runat="server" Width="70px"></asp:TextBox>&nbsp;
        至<asp:TextBox ID="txtAddScrapStockDateB" runat="server" Width="70px"></asp:TextBox>&nbsp;             
        <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="button" 
          onclick="btnQuery_Click" />  
      </div>
      <div>
        机器名称：<asp:DropDownList ID="ddlMaching" runat="server" 
              onselectedindexchanged="ddlMaching_SelectedIndexChanged" 
              AutoPostBack="True"></asp:DropDownList>&nbsp;
        品牌：<asp:DropDownList ID="ddlBrand" runat="server" 
              onselectedindexchanged="ddlBrand_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;
        型号：<asp:DropDownList ID="ddlModel" runat="server" 
              onselectedindexchanged="ddlModel_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;
        配置参数：<asp:DropDownList ID="ddlParameter" runat="server"></asp:DropDownList>&nbsp;
        供应商：<asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>&nbsp;
      </div>
        <asp:GridView ID="gvScrapStock" runat="server" AutoGenerateColumns="False">
          <Columns>
            <%--<asp:BoundField DataField="ID">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>  --%>          
            <asp:BoundField DataField="WarehouseNo">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="Maching">
              <ControlStyle Width="50px" />
              <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="Brand">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="Model">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="Parameter">
              <ControlStyle Width="60px" />
              <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="SerialNo">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="EpcTags">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="RepairsNo">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplier">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="AddScrapStockDate">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="Operator">
              <ControlStyle Width="35px" />
              <ItemStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="LastWarehouseNo">
              <ControlStyle Width="50px" />
              <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="ScrapReason">
              <ControlStyle Width="260px" />
              <ItemStyle Width="260px" />
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
    </ContentTemplate>
  </asp:UpdatePanel>  
</asp:Content>
