<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkOrder.aspx.cs" Inherits="LuxERP.UI.EventManagement.WorkOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上门服务-工单预览打印</title>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
<meta name="Generator" content="Microsoft Word 15 (filtered)"/>
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:宋体;
	panose-1:2 1 6 0 3 1 1 1 1 1;}
@font-face
	{font-family:黑体;
	panose-1:2 1 6 9 6 1 1 1 1 1;}
@font-face
	{font-family:"Cambria Math";
	panose-1:2 4 5 3 5 4 6 3 2 4;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;}
@font-face
	{font-family:幼圆;
	panose-1:2 1 5 9 6 1 1 1 1 1;}
@font-face
	{font-family:"\@宋体";
	panose-1:2 1 6 0 3 1 1 1 1 1;}
@font-face
	{font-family:"\@黑体";
	panose-1:2 1 6 9 6 1 1 1 1 1;}
@font-face
	{font-family:"\@幼圆";
	panose-1:2 1 5 9 6 1 1 1 1 1;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	font-size:10.5pt;
	font-family:"Calibri","sans-serif";}
p.MsoHeader, li.MsoHeader, div.MsoHeader
	{mso-style-link:"页眉 Char";
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	layout-grid-mode:char;
	border:none;
	padding:0cm;
	font-size:9.0pt;
	font-family:"Calibri","sans-serif";}
p.MsoFooter, li.MsoFooter, div.MsoFooter
	{mso-style-link:"页脚 Char";
	margin:0cm;
	margin-bottom:.0001pt;
	layout-grid-mode:char;
	font-size:9.0pt;
	font-family:"Calibri","sans-serif";}
p.MsoAcetate, li.MsoAcetate, div.MsoAcetate
	{mso-style-link:"批注框文本 Char";
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	font-size:9.0pt;
	font-family:"Calibri","sans-serif";}
span.Char
	{mso-style-name:"批注框文本 Char";
	mso-style-link:批注框文本;}
span.Char0
	{mso-style-name:"页眉 Char";
	mso-style-link:页眉;}
span.Char1
	{mso-style-name:"页脚 Char";
	mso-style-link:页脚;}
.MsoChpDefault
	{font-family:"Calibri","sans-serif";}
 /* Page Definitions */
 @page WordSection1
	{size:595.3pt 841.9pt;
	margin:72.0pt 85.0pt 72.0pt 90.0pt;
	layout-grid:15.6pt;}
div.WordSection1
	{page:WordSection1;}
-->
</style>  
</head>
<body lang="ZH-CN" style="text-justify-trim:punctuation">
    <form id="form1" runat="server">
    <div class="WordSection1" style="layout-grid:15.6pt;width:600px">

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-size:9.0pt;color:#0054A3"><img width="152" height="34" alt="" src="../Content/images/workorderLogo.png"/></span></b></p>

<p class="MsoNormal" align="center" style="text-align:center"><b><span style="font-size:26.0pt;font-family:黑体">亮视点<span lang="EN-US">IT</span>部上门服务报告</span></b></p>

<table class="MsoTableGrid" border="1" cellspacing="0" cellpadding="0" style="border-collapse:collapse;border:none">
 <tbody><tr>
  <td width="568" valign="top" style="width:426.1pt;border:solid black 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt">
  <p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体;color:red">特别注意：店铺如需更换笔记本 请提示店铺备份笔记本数据，如笔记本已经无法开机，且是硬盘造成的，就请店铺员工和区经理商议是否需要数据恢复，<span lang="EN-US">IT</span>部取回会保管一段时间。</span></b></p>
  </td>
 </tr>
</tbody></table>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:黑体">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体;color:white;background:black">服务信息</span></b><b><span style="font-family:黑体">：</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体">Call&nbsp; No：<asp:Label ID="lblEventNo" runat="server"></asp:Label> 店铺电话：</span><asp:Label ID="lblStoreTel" runat="server"></asp:Label></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:黑体">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体">店铺名称：<asp:Label ID="lblStoreName" runat="server"></asp:Label> 店铺编号：</span><asp:Label ID="lblStoreNo" runat="server"></asp:Label> </b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:黑体;color:red">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体">店铺地址：</span><asp:Label 
        ID="lblStoreAddress" runat="server"></asp:Label>
    </b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:黑体">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体">故障内容：<a name="OLE_LINK2"></a></span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:黑体">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体;color:white;background:black">服务时间</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体">开始时间：＿＿＿＿＿＿＿<span lang="EN-US">_&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>结束时间： <a name="OLE_LINK4"></a><a name="OLE_LINK3">＿＿＿＿＿＿＿</a></span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:黑体">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体;color:white;background:black">是否解决</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left;text-indent:164.0pt"><b><span style="font-family:黑体">是<span lang="EN-US">&nbsp; </span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
</span>否 □</span></b></p>

<p class="MsoNormal"><b><span style="font-family:黑体;color:white;background:black">其他设备状态</span></b></p>

<p class="MsoNormal"><b><span style="font-family:黑体">正常 □ &nbsp;<span lang="EN-US">&nbsp;&nbsp;</span>异常□
&nbsp;问题设备＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体;color:white;background:black">是否还需上门</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体;color:black">否<span lang="EN-US">&nbsp; &nbsp;</span>□ <span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>是</span></b><b><span style="font-family:黑体">□ &nbsp;上门原因 ＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-size:11.0pt;font-family:黑体;color:white;background:black">店铺满意度调查</span></b></p>

<table class="MsoTableGrid" border="1" cellspacing="0" cellpadding="0" style="border-collapse:collapse;border:none">
 <tbody><tr style="height:66.45pt">
  <td width="555" valign="top" style="width:416.5pt;border:solid black 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:66.45pt">
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:幼圆">1 </span><span style="font-size:11.0pt;
  font-family:幼圆">服务响应速度<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  1 </span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp; 2</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
  3</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 4</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;
  5</span>□<span lang="EN-US">&nbsp; </span></span></p>
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:幼圆">2 </span><span style="font-size:11.0pt;
  font-family:幼圆">故障排除速度<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  1 </span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp; 2</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
  3</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 4</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;
  5</span>□<span lang="EN-US">&nbsp; </span></span></p>
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:幼圆">3 </span><span style="font-size:11.0pt;
  font-family:幼圆">上门工程师态度<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  1 </span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp; 2</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
  3</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 4</span>□<span lang="EN-US">&nbsp;&nbsp;&nbsp;
  5</span>□<span lang="EN-US">&nbsp; </span></span></p>
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:幼圆">4 </span><span style="font-size:11.0pt;
  font-family:幼圆">其他意见及建议＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿＿</span></p>
  </td>
 </tr>
</tbody>
</table>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:黑体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></b><b><span style="font-size:9.0pt;font-family:黑体;color:red">注！分数越高越满意</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:黑体;color:white;background:black">需服务设备</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-size:12.0pt;font-family:黑体">&nbsp;</span></b></p>

<div>
<asp:GridView ID="gvServices" runat="server"  AutoGenerateColumns="False" >
    <Columns>
    <asp:BoundField DataField="Maching" HeaderText="设备名称" HeaderStyle-Font-Bold="true">
        <ItemStyle Width="250px" />
    </asp:BoundField>
    <asp:BoundField DataField="SerialNo" HeaderText="设备序列号"  HeaderStyle-Font-Bold="true">
        <ItemStyle Width="250px" />
    </asp:BoundField>
    </Columns>
</asp:GridView>
</div>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-size:12.0pt;font-family:黑体">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-size:12.0pt;font-family:黑体">工程师签字及日期：＿＿＿＿＿＿＿＿＿ 店铺签字及日期：＿＿＿＿＿＿＿＿</span></b></p>

</div>
    </form>
</body>
</html>
