<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutOrder.aspx.cs" Inherits="LuxERP.UI.EventManagement.OutOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/nopicstyle.css" rel="stylesheet" type="text/css" />
    <title>调拨单打印</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:650px">
    <div id="noRecordsText1" runat="server" visible="false" style=" width:650px;height:45px; line-height:45px; text-align:center; border:1px solid gray">
    <asp:Label ID="Label1" runat="server" Font-Bold="false" Font-Size="Medium" ForeColor="Red">未进行匹配/所有设备没库存</asp:Label>
    </div>
    <div style="width:650px; text-align:center"><label style=" font-size:25px">设备调拨出库单</label></div>
    <label>调入单位：<asp:Label ID="lblStoreNo" runat="server"></asp:Label></label>
    <label>出单日期：<asp:Label ID="lblDate" runat="server"></asp:Label></label>
    <asp:GridView ID="gvMatchingResults" runat="server" AutoGenerateColumns="False" >
    <Columns>
            <asp:BoundField DataField="WarehouseStoreNo">
                <ItemStyle Width="45px" />
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
            <asp:BoundField DataField="RepairsNo">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="Supplier">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:TemplateField>
            <ItemStyle Width="45px" />
            </asp:TemplateField>
    </Columns>
    </asp:GridView>
    <br />
    <label>调出负责人(签字)：                </label>
    <br />
    <label>调入单位负责人(签字)：                </label>
    </div>
    </form>
</body>
</html>
