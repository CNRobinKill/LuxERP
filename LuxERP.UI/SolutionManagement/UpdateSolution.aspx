<%@ Page Title="事件解决资源方案修改与查询" ValidateRequest="false" Language="C#" MasterPageFile="~/LuxERP.Master" AutoEventWireup="true" CodeBehind="UpdateSolution.aspx.cs" Inherits="LuxERP.UI.SolutionManagement.UpdateSolution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/jquery.sceditor.default.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.sceditor.xhtml.min.js" type="text/javascript"></script>
<style type="text/css">
.label
{
  color: Blue;
  font-size: 15px;
  height: 20px;
  width: auto;
  text-align: center;
  display: block;  
}

.ok
{
  color: Green;
  font-size: 10px;
  font-weight: bold;    
}
.fail
{
  color: Red;
  font-size: 10px;
  font-weight: bold; 
}
</style>
<script type="text/javascript">
  $(function () {
    menuSlide('#solution', '#updateSolution');    
  });

  function getContent() {
    var a = $($('iframe').contents().contents()[1]).find('body').html();    
    $('#myContent_hid').val(a);
  };

  function check() {
    var a = $('#myContent_txtTypeNo').val();
    var reg = /^\d{1,10}$/;
    if (reg.test(a)) {
      return true;
    } 
    else {
      alert("请输入正确的类型码！(0到9的数字，不能超过10位)");
      return false;
    }
  }

  function setEditor(content) {
    $('textarea').sceditor({
      plugins: "xhtml",
      toolbar: "bold,italic,underline,strike|left,center,right,justify|size,color,removeformat|bulletlist,orderedlist|horizontalrule,image,email,link,unlink|youtube,date,time|ltr,rtl|print",
      style: "/Content/jquery.sceditor.default.min.css"
    });
    $('.sceditor-container').width('1055px').height('355px');
    $('iframe').width('1050px').height('313px');    
    $($('iframe').contents().contents()[1]).find('body').html(content);                 
    }; 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myContent" runat="server">     
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <div>
      <h2>Solutions</h2>
        <asp:Label ID="lblTypeNo" runat="server" Text="类型代码："></asp:Label>
        <asp:TextBox ID="txtTypeNo" runat="server"></asp:TextBox>        
        <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="button" OnClientClick="return check();" onclick="btnQuery_Click" />
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        <input id="hid" type="hidden" name="hid" runat="server" />        
      </div>
      <div id="result" runat="server">        
        <asp:Label ID="lblTitle" runat="server" CssClass="label"></asp:Label>                   
        <textarea id="updateInfo"></textarea>  
        <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="button" OnClientClick="getContent();" onclick="btnUpdate_Click" />             
      </div>     
    </ContentTemplate>
  </asp:UpdatePanel>           
</asp:Content>
