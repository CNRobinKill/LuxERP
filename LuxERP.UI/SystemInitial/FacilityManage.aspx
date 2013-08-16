<%@ Page Title="设备基础信息添加与删除" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="FacilityManage.aspx.cs" Inherits="LuxERP.UI.SystemInitial.FacilityManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlide('#systemInitial', '#facilityManage');
        $('#tbShow tbody tr:even').removeClass('alt-row');
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
<h2>FacilityManage</h2>
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="width:900px; text-align:center"> 
      <table id="tbShow">
        <tr>
          <td>
            <h3>MachingName</h3>
            <asp:TextBox ID="txtMaching" runat="server" Width="150px"></asp:TextBox>
            <br />
            <asp:ListBox ID="lstMaching" runat="server" Width="180px" Height="250px" AutoPostBack="true"
                  onselectedindexchanged="lstMaching_SelectedIndexChanged"></asp:ListBox>
          </td>
          <td>
            <h3>Brand</h3>
            <asp:TextBox ID="txtBrand" runat="server" Width="150px"></asp:TextBox>
            <br />
            <asp:ListBox ID="lstBrand" runat="server" Width="180px" Height="250px" AutoPostBack="true"
                  onselectedindexchanged="lstBrand_SelectedIndexChanged"></asp:ListBox>
          </td>
          <td>
            <h3>Model</h3>
            <asp:TextBox ID="txtModel" runat="server" Width="150px"></asp:TextBox>
            <br />
            <asp:ListBox ID="lstModel" runat="server" Width="180px" Height="250px" AutoPostBack="true"
                  onselectedindexchanged="lstModel_SelectedIndexChanged"></asp:ListBox>
          </td>
          <td>
            <h3>Parameter</h3>
            <asp:TextBox ID="txtPara" runat="server" Width="150px"></asp:TextBox>
            <br />
            <asp:ListBox ID="lstPara" runat="server" Width="180px" Height="250px"></asp:ListBox>
          </td>
          <td>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnAddFacility" runat="server" Text="添加" CssClass="button" 
                  onclick="btnAddFacility_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnDelFacility" runat="server" Text="删除" CssClass="button" 
                  onclick="btnDelFacility_Click" />
          </td>
        </tr>
      </table> 
     </div>     
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
