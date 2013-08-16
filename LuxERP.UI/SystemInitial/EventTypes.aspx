<%@ Page Title="事件类型初始化" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="EventTypes.aspx.cs" Inherits="LuxERP.UI.SystemInitial.EventTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlide('#systemInitial', '#eventTypes');
      });

    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">

<h2>EventTypesManage</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        <asp:Button ID="btnTypesManagement" runat="server" Text="管理类型" CssClass="button"
                onclick="btnTypesManagement_Click" />
        <asp:Button ID="btnReturn" runat="server" Text="返回创建事件类" CssClass="button"
                onclick="btnReturn_Click" />
        <div runat="server" id="createEventTypes">
        <asp:Label runat="server">类型一：</asp:Label>
        <asp:DropDownList ID="ddlTypeOne" runat="server"></asp:DropDownList>
        <asp:Label runat="server">类型二：</asp:Label>
        <asp:DropDownList ID="ddlTypeTwo" runat="server"></asp:DropDownList>
        <asp:Label runat="server">类型三：</asp:Label>
        <asp:DropDownList ID="ddlTypeThree" runat="server"></asp:DropDownList>
        <asp:Label runat="server">类型四：</asp:Label>
        <asp:DropDownList ID="ddlTypeFour" runat="server"></asp:DropDownList>
        <asp:Label runat="server">类型编号：</asp:Label>
        <asp:TextBox ID="txtTypeCode" runat="server" Width="100px"></asp:TextBox>
        <asp:Label runat="server">事件等级：</asp:Label>
        <asp:DropDownList ID="ddlEventLevel" runat="server"></asp:DropDownList>
        <asp:Button ID="btnCreateEventTypes" runat="server" Text="创建事件类" CssClass="button"
                onclick="btnCreateEventTypes_Click" />
            <asp:GridView ID="gvEventTypes" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="gvEventTypes_RowDeleting" >
                <Columns>
                            <asp:BoundField DataField="TypeCode" HeaderText="类型编号">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TypeOne" HeaderText="类型一">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TypeTwo" HeaderText="类型二">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TypeThree" HeaderText="类型三">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TypeFour" HeaderText="类型四">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EventLevel" HeaderText="事件等级">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
        <div runat="server" id="typesManagement" style="width:900px">
        <table>
        <tr><td></td><td></td><td></td><td></td></tr>
        <tr>
        <td>
            <h3>TypeOne</h3>
            <asp:TextBox ID="txtTypeOne" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnAddTypeOne" runat="server" Text="添加" CssClass="button"
                onclick="btnAddTypeOne_Click" />
            <asp:ListBox ID="lstTypeOne" runat="server" Width="154px" Height="200px"></asp:ListBox>
            <asp:Button ID="btnDelTypeOne" runat="server" Text="删除" CssClass="button"
                onclick="btnDelTypeOne_Click" />
        </td>
        <td>
            <h3>TypeTwo</h3>
            <asp:TextBox ID="txtTypeTwo" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnAddTypeTwo" runat="server" Text="添加" CssClass="button"
                onclick="btnAddTypeTwo_Click" />
            <asp:ListBox ID="lstTypeTwo" runat="server" Width="154px" Height="200px"></asp:ListBox>
            <asp:Button ID="btnDelTypeTwo" runat="server" Text="删除" CssClass="button"
                onclick="btnDelTypeTwo_Click" />
        </td>
        <td>
            <h3>TypeThree</h3>
            <asp:TextBox ID="txtTypeThree" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnAddTypeThree" runat="server" Text="添加" CssClass="button"
                onclick="btnAddTypeThree_Click" />
            <asp:ListBox ID="lstTypeThree" runat="server" Width="154px" Height="200px"></asp:ListBox>
            <asp:Button ID="btnDelTypeThree" runat="server" Text="删除" CssClass="button"
                onclick="btnDelTypeThree_Click" />
        </td>
        <td>
            <h3>TypeFour</h3>
            <asp:TextBox ID="txtTypeFour" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnAddTypeFour" runat="server" Text="添加" CssClass="button"
                onclick="btnAddTypeFour_Click" />
            <asp:ListBox ID="lstTypeFour" runat="server" Width="154px" Height="200px"></asp:ListBox>
            <asp:Button ID="btnDelTypeFour" runat="server" Text="删除" CssClass="button"
                onclick="btnDelTypeFour_Click" />
        </td>
        </tr>
        <tr><td></td><td></td><td></td><td></td></tr>
            <asp:Label ID="lblEventTypesMessage" runat="server"></asp:Label>
        </table>
</div>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
