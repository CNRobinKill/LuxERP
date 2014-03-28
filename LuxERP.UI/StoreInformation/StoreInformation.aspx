<%@ Page Title="店铺信息查询修改与设备查询" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="StoreInformation.aspx.cs" Inherits="LuxERP.UI.StoreInformation.StoreInformation" %>
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
    menuSlide('#storeInformation', '#alterStore');
//    setDate();    
  });

  function addRowStyle() {
    $('#myContent_gvStores tbody tr:even').addClass('alt-row');
  };

//  function setDate() {
//    $("#myContent_txtOpeingDateF").datepicker({
//      onClose: function (selectedDate) {
//        $("#myContent_txtOpeingDateT").datepicker("option", "minDate", selectedDate);
//      }
//    });
//    $("#myContent_txtOpeingDateT").datepicker({
//      onClose: function (selectedDate) {
//        $("#myContent_txtOpeingDateF").datepicker("option", "maxDate", selectedDate);
//      }
//    });

//    set('#myContent_txtOpeingDateF');
//    set('#myContent_txtOpeingDateT');

//    var input = $('#myContent_gvStores tr:gt(0)').find("td:eq(10)").find('input[type=text]');
//    var t = input.val();
//    var a = "input[name='" + input.attr('name') + "']";
//    set(a);
//    input.val(t);
//  };

//  function set(id) {
//    $(id).datepicker();
//    $(id).datepicker("option", "dateFormat", "yy-mm-dd");
//    $(id).datepicker("option", $.datepicker.regional["zh-TW"]);
//    $(id).datepicker("option", "changeMonth", "true");
//    $(id).datepicker("option", "changeYear", "true");
//  };

  function setDialog() {
    $("#myContent_facility").dialog({
      autoOpen: false,
      height: 400,
      width: 1120,
      modal: true,
      close: function (event, ui) {
        $("#myContent_facility").dialog("destroy");
        $("#myContent_gvFacility").hide();
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
    $('#myContent_gvFacility').find("tr:odd").attr("style", "background-color: #f3f3f3;");
  }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h2>StoreInformation</h2>
    <div>
      店号：<asp:TextBox ID="txtStoreNo" runat="server" Width="40px"></asp:TextBox>&nbsp;
<%--      重点店铺：<asp:DropDownList ID="ddlTopStore" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
              </asp:DropDownList>&nbsp;--%>
      店铺类型：<asp:DropDownList ID="ddlStoreType" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="IFocus">IFocus</asp:ListItem>
                <asp:ListItem Value="Accufit">Accufit</asp:ListItem>
                <asp:ListItem Value="Focus">Focus</asp:ListItem>  
              </asp:DropDownList>&nbsp;
      店铺区域：<asp:TextBox ID="txtRegion" runat="server" Width="40px"></asp:TextBox>&nbsp;
      店铺名称：<asp:TextBox ID="txtStoreName" runat="server" Width="70px"></asp:TextBox>&nbsp;
      电话：<asp:TextBox ID="txtStoreTel" runat="server" Width="150px"></asp:TextBox>&nbsp;
<%--      店铺等级：<asp:DropDownList ID="ddlRating" runat="server">
            <asp:ListItem Selected="True"></asp:ListItem>
            <asp:ListItem>Energy</asp:ListItem>
            <asp:ListItem>FO</asp:ListItem>
            <asp:ListItem>Gold</asp:ListItem>
            <asp:ListItem>Platinum</asp:ListItem>
            <asp:ListItem>Silver 1</asp:ListItem>
            <asp:ListItem>Silver 2</asp:ListItem>
          </asp:DropDownList>&nbsp;--%>
<%--      开店时间：<asp:TextBox ID="txtOpeingDateF" runat="server" Width="70px"></asp:TextBox>&nbsp;
      至：<asp:TextBox ID="txtOpeingDateT" runat="server" Width="70px"></asp:TextBox>--%>
      店铺状态：<asp:DropDownList ID="ddlStoreState" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="900,997">营业中</asp:ListItem>
                <asp:ListItem Value="998">需装修</asp:ListItem>
                <asp:ListItem Value="999">预开店</asp:ListItem>
                <asp:ListItem Value="997">预关店</asp:ListItem>
                <asp:ListItem Value="996">已关店</asp:ListItem>
              </asp:DropDownList> 
      <asp:Button ID="txtQuery" runat="server" Text="查询" CssClass="button" onclick="txtQuery_Click" />       
    </div>
    <div>
      <asp:GridView ID="gvStores" runat="server" AutoGenerateColumns="false" 
        onrowediting="gvStores_RowEditing" 
        onrowcancelingedit="gvStores_RowCancelingEdit" 
        onrowdatabound="gvStores_RowDataBound" onrowupdating="gvStores_RowUpdating" 
        onselectedindexchanging="gvStores_SelectedIndexChanging">
        <Columns>
          <asp:BoundField DataField="Row" HeaderStyle-Width="27px" ReadOnly="true">
            <ControlStyle Width="25px" />
            <ItemStyle Width="25px" />
          </asp:BoundField>
          <asp:BoundField DataField="StoreNo" HeaderStyle-Width="40px">
            <ControlStyle Width="35px" />
            <ItemStyle Width="40px" />
          </asp:BoundField>
<%--          <asp:TemplateField HeaderStyle-Width="60px">
             <ItemTemplate>
                <%# Eval("TopStore")%>
             </ItemTemplate>
             <EditItemTemplate>
                <asp:HiddenField ID="hdTopStore" runat="server" Value='<%# Eval("TopStore") %>' />
                   <asp:DropDownList ID="ddlTopStoreE" runat="server">                              
                      <asp:ListItem>No</asp:ListItem>
                      <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList>
                   </EditItemTemplate>
              <ItemStyle Width="65px" />
              <ControlStyle Width="60px" />
          </asp:TemplateField>--%> 
          <asp:TemplateField HeaderStyle-Width="75px">
             <ItemTemplate>
                <%# Eval("StoreType")%>
             </ItemTemplate>
             <EditItemTemplate>
                <asp:HiddenField ID="hdStoreType" runat="server" Value='<%# Eval("StoreType") %>' />
                   <asp:DropDownList ID="ddlStoreTypeE" runat="server">
                      <asp:ListItem Value="IFocus">IFocus</asp:ListItem>
                      <asp:ListItem Value="Accufit">Accufit</asp:ListItem>                                                   
                      <asp:ListItem Value="Focus">Focus</asp:ListItem>                     
                    </asp:DropDownList>
                   </EditItemTemplate>
              <ItemStyle Width="65px" />
              <ControlStyle Width="75px" />
          </asp:TemplateField> 
          <asp:BoundField DataField="Region" HeaderStyle-Width="30px">
            <ControlStyle Width="25px" />
            <ItemStyle Width="30px" />
          </asp:BoundField>
<%--          <asp:TemplateField HeaderStyle-Width="75px">
             <ItemTemplate>
                <%# Eval("Rating")%>
             </ItemTemplate>
             <EditItemTemplate>
                <asp:HiddenField ID="hdRating" runat="server" Value='<%# Eval("Rating") %>' />
                   <asp:DropDownList ID="ddlRatingE" runat="server">                    
                    <asp:ListItem>Energy</asp:ListItem>
                    <asp:ListItem>FO</asp:ListItem>
                    <asp:ListItem>Gold</asp:ListItem>
                    <asp:ListItem>Platinum</asp:ListItem>
                    <asp:ListItem>Silver 1</asp:ListItem>
                    <asp:ListItem>Silver 2</asp:ListItem>
                  </asp:DropDownList>
             </EditItemTemplate>
              <ItemStyle Width="65px" />
              <ControlStyle Width="75px" />
          </asp:TemplateField>--%>
          <asp:BoundField DataField="StoreName" HeaderStyle-Width="105px">
            <ControlStyle Width="100px" />
            <ItemStyle Width="100px" />
          </asp:BoundField>
          <asp:BoundField DataField="City" HeaderStyle-Width="60px">
            <ControlStyle Width="50px" />
            <ItemStyle Width="55px" />
          </asp:BoundField>
          <asp:BoundField DataField="StoreTel" HeaderStyle-Width="90px">
          <ControlStyle Width="82px" />
            <ItemStyle Width="90px" />
          </asp:BoundField>
          <asp:BoundField DataField="ADSLNo" HeaderStyle-Width="90px">
          <ControlStyle Width="102px" />
            <ItemStyle Width="110px" />
          </asp:BoundField>
          <asp:BoundField DataField="StoreAddress" HeaderStyle-Width="300px">
          <ControlStyle Width="300px" />
            <ItemStyle Width="300px" />
          </asp:BoundField>          
<%--          <asp:BoundField DataField="ContractArea" HeaderStyle-Width="55px">
            <ControlStyle Width="50px" />
            <ItemStyle Width="55px" />
          </asp:BoundField>
          <asp:BoundField DataField="OpeingDate" ReadOnly="true" HeaderStyle-Width="70px">
            <ItemStyle Width="70px" />
          </asp:BoundField>--%>
          <asp:BoundField DataField="StoreState" ReadOnly="true" HeaderStyle-Width="55px">
            <ItemStyle Width="55px" />
          </asp:BoundField>
<%--          <asp:TemplateField>
             <ItemTemplate>
                <%# Eval("StoreState")%>
             </ItemTemplate>
             <EditItemTemplate>
                <asp:HiddenField ID="hdStoreState" runat="server" Value='<%# Eval("StoreState") %>' />
                <asp:DropDownList ID="ddlStoreStateE" runat="server">                
                  <asp:ListItem Value="900">营业中</asp:ListItem>
                  <asp:ListItem Value="998">装修中</asp:ListItem>
                  <asp:ListItem Value="999">开店中</asp:ListItem>
              </asp:DropDownList>
             </EditItemTemplate>
              <ItemStyle Width="65px" />
              <ControlStyle Width="60px" />
          </asp:TemplateField>--%>
          <asp:CommandField  ShowEditButton="True" EditText="修改" ControlStyle-Width="40px"/>
          <asp:CommandField  ShowSelectButton="True" SelectText="设备" ControlStyle-Width="40px"/>
          <%--<asp:HyperLinkField DataNavigateUrlFields="StoreNo" DataNavigateUrlFormatString="StoreDetail.aspx?storeNo={0}" Text="详细" HeaderStyle-Width="65px"/>  --%>        
        </Columns>
      </asp:GridView>      
    </div>    
    <div id="facility" runat="server">     
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
                <ItemStyle Width="75px" />
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
            <asp:BoundField DataField="EventNoT">
                <ItemStyle Width="60px" />
            </asp:BoundField>
    </Columns>
    </asp:GridView>
    </div>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
