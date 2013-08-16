<%@ Page Title="其它综合基础信息添加与删除" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="SynthesisManage.aspx.cs" Inherits="LuxERP.UI.SystemInitial.SynthesisManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlide('#systemInitial', '#synthesisManage');
        $('#tbShow tr:even').removeClass('alt-row');
    });
    function addRowStyle() {
        $('#myContent_gvSolver tr:even').addClass('alt-row');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">

<h2>SynthesisManage</h2>
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="width:900px"> 
      <table class="style1" id="tbShow">
        <tr>
          <td>
            <h3>ProblemSolver</h3>
            <asp:TextBox ID="txtSolver" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnAddSolver" runat="server" Text="添加" CssClass="button" 
                  onclick="btnAddSolver_Click"  />
            <br />
            <asp:ListBox ID="lstSolver" runat="server" Width="154px" Height="200px"></asp:ListBox>
            <asp:Button ID="btnDelSolver" runat="server" Text="删除" CssClass="button" 
                  onclick="btnDelSolver_Click"  />
          </td>
          <td>
            <h3>ExpressCompany</h3>
            <asp:TextBox ID="txtExpressCo" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnAddExpressCo" runat="server" Text="添加" CssClass="button" 
                  onclick="btnAddExpressCo_Click"  />
            <br />
            <asp:ListBox ID="lstExpressCo" runat="server" Width="154px" Height="200px"></asp:ListBox>
            <asp:Button ID="btnDelExpressCo" runat="server" Text="删除" CssClass="button" 
                  onclick="btnDelExpressCo_Click"  />
          </td>
          <td>
           <h3>Supplier</h3>
            <asp:TextBox ID="txtSupplier" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnAddSupplier" runat="server" Text="添加" CssClass="button" 
              onclick="btnAddSupplier_Click" />
            <br />
            <asp:ListBox ID="lstSupplier" runat="server" Width="154px" Height="200px"></asp:ListBox>
            <asp:Button ID="btnDelSupplier" runat="server" Text="删除" CssClass="button" 
              onclick="btnDelSupplier_Click" />
          </td>
        </tr>
      </table> 
      <h3>ProblemSolverEmail</h3>
      <asp:GridView ID="gvSolver" runat="server" AutoGenerateColumns="False" 
            onrowediting="gvSolver_RowEditing" 
            onrowcancelingedit="gvSolver_RowCancelingEdit" 
            onrowupdating="gvSolver_RowUpdating" 
            onrowdatabound="gvSolver_RowDataBound" 
            onselectedindexchanging="gvSolver_SelectedIndexChanging" >
        <Columns>
                    <asp:BoundField DataField="Solver" ReadOnly="true" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" >
                        <ItemStyle Width="200px" />
                        <ControlStyle Width="180px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SMTP" >
                        <ItemStyle Width="200px" />
                        <ControlStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EPassword" >
                        <ItemStyle Width="200px" />
                        <ControlStyle Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <%# Eval("Note")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="hdNote" runat="server" Value='<%# Eval("Note") %>' />
                            <asp:DropDownList ID="ddlNote" runat="server" />
                        </EditItemTemplate>
                     <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" EditText="修改编辑" HeaderStyle-Width="100px" />
                    <asp:CommandField ShowSelectButton="true" SelectText="测试校验" ControlStyle-CssClass="button" HeaderStyle-Width="100px" />
        </Columns>
    </asp:GridView>
     </div>     
    </ContentTemplate>
  </asp:UpdatePanel>

</asp:Content>
