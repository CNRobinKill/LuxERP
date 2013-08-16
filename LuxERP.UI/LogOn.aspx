<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="LuxERP.UI.LogOn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统登录</title>

    <link href="Content/reset.css" rel="stylesheet" type="text/css" />
    <link href="Content/style.css" rel="stylesheet" type="text/css" />
    <link href="Content/invalid.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Scripts/simpla.jquery.configuration.js" type="text/javascript"></script>
    <script src="Scripts/facebox.js" type="text/javascript"></script>
    <script src="Scripts/jquery.wysiwyg.js" type="text/javascript"></script>

</head>
<body id="login">
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="login-wrapper" class="png_bg">
        <div id="login-top">
            <a href="#"><img style=" width:165px; height:60px" id="logo" src="../../Content/images/ris.png" alt="IIRIS logo" /></a>
        </div>
        <div id="login-content">
                <p>
                    <asp:Label ID="labUserName" runat="server">UserName</asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" class="text-input"></asp:TextBox>
                </p>
                <div class="clear"></div>
                <p>
                    <asp:Label ID="labPassword" runat="server">Password</asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" class="text-input" TextMode="Password"></asp:TextBox>
                </p>
                <div class="clear"></div>
                <p>
                    <asp:Button ID="btnLogIn" runat="server" Text="登录" class="button" onclick="btnLogIn_Click" />
                </p>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
    <div style=" height:290px"></div>
    <div style=" position:relative; margin-top:-10px; clear:both; width:100%; text-align:center"><asp:Label ID="lblTechnicalSupport" runat="server"></asp:Label></div>
</body>
</html>
