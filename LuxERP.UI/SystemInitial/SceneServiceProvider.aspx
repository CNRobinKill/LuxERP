<%@ Page Title="" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="SceneServiceProvider.aspx.cs" Inherits="LuxERP.UI.SystemInitial.SceneServiceProvider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        menuSlide('#systemInitial', '#peopleManage');
    });

    function addRowStyle() {
        $('tbody tr:even').addClass('alt-row');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<h2>SceneServiceProvider</h2>
    <asp:Label runat="server" Text="上门服务商："></asp:Label>
    <asp:TextBox ID="txtServiceProvider" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="联系电话："></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="联系邮箱："></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>
    <asp:Label runat="server" Text="服务区域："></asp:Label>
    <asp:DropDownList ID="ddlServiceArea" runat="server"></asp:DropDownList>
    <asp:Label runat="server" Text="剩余Token数："></asp:Label>
    <asp:TextBox ID="txtRemainToken" runat="server" Width="100px"></asp:TextBox>


    <asp:Button ID="btnAddSceneServiceProvider" runat="server" Text="添加" 
        CssClass="button" onclick="btnAddSceneServiceProvider_Click"  />
    <asp:GridView ID="gvSceneServiceProvider" runat="server" 
        AutoGenerateColumns="False" 
        onrowcancelingedit="gvSceneServiceProvider_RowCancelingEdit" 
        onrowdatabound="gvSceneServiceProvider_RowDataBound" 
        onrowdeleting="gvSceneServiceProvider_RowDeleting" 
        onrowediting="gvSceneServiceProvider_RowEditing" 
        onrowupdating="gvSceneServiceProvider_RowUpdating">
        <Columns>
                    <asp:BoundField DataField="ServiceProvider" >
                        <ControlStyle Width="161px" />
                        <ItemStyle Width="160px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Phone" >
                        <ControlStyle Width="101px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" >
                        <ControlStyle Width="101px" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderStyle-Width="102px">
                        <ItemTemplate>
                        <%# Eval("ServiceArea")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:HiddenField ID="hdServiceArea" runat="server" Value='<%# Eval("ServiceArea") %>' />
                            <asp:DropDownList ID="ddlServiceAreaB" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        <ItemStyle Width="100px" />
                        <ControlStyle Width="71px" />
                    </asp:TemplateField>
<%--                    <asp:BoundField DataField="ServiceArea" >
                        <ItemStyle Width="100px" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="RemainToken" ReadOnly="true">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:CommandField ShowEditButton="True" EditText="修改信息" ControlStyle-Width="50px" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="删除" ControlStyle-Width="50px" />
        </Columns>
    </asp:GridView>
    <div runat="server" id="divAddToken">
    <asp:Label runat="server" Text="上门服务商:"></asp:Label>
    <asp:DropDownList ID="ddlServiceProvider" runat="server"></asp:DropDownList>
    <asp:Label runat="server" Text="增加Token数："></asp:Label>
    <asp:TextBox ID="txtToken" runat="server" Width="100px"></asp:TextBox>
    <asp:Button ID="btnAddToken" runat="server" Text="增加" CssClass="button" 
            onclick="btnAddToken_Click"  />
    </div>
 </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
