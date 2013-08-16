<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkOrder.aspx.cs" Inherits="LuxERP.UI.EventManagement.WorkOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���ŷ���-����Ԥ����ӡ</title>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
<meta name="Generator" content="Microsoft Word 15 (filtered)"/>
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:����;
	panose-1:2 1 6 0 3 1 1 1 1 1;}
@font-face
	{font-family:����;
	panose-1:2 1 6 9 6 1 1 1 1 1;}
@font-face
	{font-family:"Cambria Math";
	panose-1:2 4 5 3 5 4 6 3 2 4;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;}
@font-face
	{font-family:��Բ;
	panose-1:2 1 5 9 6 1 1 1 1 1;}
@font-face
	{font-family:"\@����";
	panose-1:2 1 6 0 3 1 1 1 1 1;}
@font-face
	{font-family:"\@����";
	panose-1:2 1 6 9 6 1 1 1 1 1;}
@font-face
	{font-family:"\@��Բ";
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
	{mso-style-link:"ҳü Char";
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	layout-grid-mode:char;
	border:none;
	padding:0cm;
	font-size:9.0pt;
	font-family:"Calibri","sans-serif";}
p.MsoFooter, li.MsoFooter, div.MsoFooter
	{mso-style-link:"ҳ�� Char";
	margin:0cm;
	margin-bottom:.0001pt;
	layout-grid-mode:char;
	font-size:9.0pt;
	font-family:"Calibri","sans-serif";}
p.MsoAcetate, li.MsoAcetate, div.MsoAcetate
	{mso-style-link:"��ע���ı� Char";
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	font-size:9.0pt;
	font-family:"Calibri","sans-serif";}
span.Char
	{mso-style-name:"��ע���ı� Char";
	mso-style-link:��ע���ı�;}
span.Char0
	{mso-style-name:"ҳü Char";
	mso-style-link:ҳü;}
span.Char1
	{mso-style-name:"ҳ�� Char";
	mso-style-link:ҳ��;}
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

<p class="MsoNormal" align="center" style="text-align:center"><b><span style="font-size:26.0pt;font-family:����">���ӵ�<span lang="EN-US">IT</span>�����ŷ��񱨸�</span></b></p>

<table class="MsoTableGrid" border="1" cellspacing="0" cellpadding="0" style="border-collapse:collapse;border:none">
 <tbody><tr>
  <td width="568" valign="top" style="width:426.1pt;border:solid black 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt">
  <p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����;color:red">�ر�ע�⣺������������ʼǱ� ����ʾ���̱��ݱʼǱ����ݣ���ʼǱ��Ѿ��޷�����������Ӳ����ɵģ��������Ա���������������Ƿ���Ҫ���ݻָ���<span lang="EN-US">IT</span>��ȡ�ػᱣ��һ��ʱ�䡣</span></b></p>
  </td>
 </tr>
</tbody></table>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:����">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����;color:white;background:black">������Ϣ</span></b><b><span style="font-family:����">��</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����">Call&nbsp; No��<asp:Label ID="lblEventNo" runat="server"></asp:Label> ���̵绰��</span><asp:Label ID="lblStoreTel" runat="server"></asp:Label></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:����">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����">�������ƣ�<asp:Label ID="lblStoreName" runat="server"></asp:Label> ���̱�ţ�</span><asp:Label ID="lblStoreNo" runat="server"></asp:Label> </b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:����;color:red">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����">���̵�ַ��</span><asp:Label 
        ID="lblStoreAddress" runat="server"></asp:Label>
    </b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:����">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����">�������ݣ�<a name="OLE_LINK2"></a></span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:����">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����;color:white;background:black">����ʱ��</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����">��ʼʱ�䣺�ߣߣߣߣߣߣ�<span lang="EN-US">_&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>����ʱ�䣺 <a name="OLE_LINK4"></a><a name="OLE_LINK3">�ߣߣߣߣߣߣ�</a></span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:����">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����;color:white;background:black">�Ƿ���</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left;text-indent:164.0pt"><b><span style="font-family:����">��<span lang="EN-US">&nbsp; </span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
</span>�� ��</span></b></p>

<p class="MsoNormal"><b><span style="font-family:����;color:white;background:black">�����豸״̬</span></b></p>

<p class="MsoNormal"><b><span style="font-family:����">���� �� &nbsp;<span lang="EN-US">&nbsp;&nbsp;</span>�쳣��
&nbsp;�����豸�ߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣ�</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����;color:white;background:black">�Ƿ�������</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����;color:black">��<span lang="EN-US">&nbsp; &nbsp;</span>�� <span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>��</span></b><b><span style="font-family:����">�� &nbsp;����ԭ�� �ߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣ�</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-size:11.0pt;font-family:����;color:white;background:black">��������ȵ���</span></b></p>

<table class="MsoTableGrid" border="1" cellspacing="0" cellpadding="0" style="border-collapse:collapse;border:none">
 <tbody><tr style="height:66.45pt">
  <td width="555" valign="top" style="width:416.5pt;border:solid black 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:66.45pt">
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:��Բ">1 </span><span style="font-size:11.0pt;
  font-family:��Բ">������Ӧ�ٶ�<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  1 </span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp; 2</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
  3</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 4</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;
  5</span>��<span lang="EN-US">&nbsp; </span></span></p>
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:��Բ">2 </span><span style="font-size:11.0pt;
  font-family:��Բ">�����ų��ٶ�<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  1 </span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp; 2</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
  3</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 4</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;
  5</span>��<span lang="EN-US">&nbsp; </span></span></p>
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:��Բ">3 </span><span style="font-size:11.0pt;
  font-family:��Բ">���Ź���ʦ̬��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  1 </span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp; 2</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;
  3</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 4</span>��<span lang="EN-US">&nbsp;&nbsp;&nbsp;
  5</span>��<span lang="EN-US">&nbsp; </span></span></p>
  <p class="MsoNormal" align="left" style="text-align:left"><span lang="EN-US" style="font-size:11.0pt;font-family:��Բ">4 </span><span style="font-size:11.0pt;
  font-family:��Բ">�������������ߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣߣ�</span></p>
  </td>
 </tr>
</tbody>
</table>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-family:����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></b><b><span style="font-size:9.0pt;font-family:����;color:red">ע������Խ��Խ����</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-family:����;color:white;background:black">������豸</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-size:12.0pt;font-family:����">&nbsp;</span></b></p>

<div>
<asp:GridView ID="gvServices" runat="server"  AutoGenerateColumns="False" >
    <Columns>
    <asp:BoundField DataField="Maching" HeaderText="�豸����" HeaderStyle-Font-Bold="true">
        <ItemStyle Width="250px" />
    </asp:BoundField>
    <asp:BoundField DataField="SerialNo" HeaderText="�豸���к�"  HeaderStyle-Font-Bold="true">
        <ItemStyle Width="250px" />
    </asp:BoundField>
    </Columns>
</asp:GridView>
</div>

<p class="MsoNormal" align="left" style="text-align:left"><b><span lang="EN-US" style="font-size:12.0pt;font-family:����">&nbsp;</span></b></p>

<p class="MsoNormal" align="left" style="text-align:left"><b><span style="font-size:12.0pt;font-family:����">����ʦǩ�ּ����ڣ��ߣߣߣߣߣߣߣߣ� ����ǩ�ּ����ڣ��ߣߣߣߣߣߣߣ�</span></b></p>

</div>
    </form>
</body>
</html>
