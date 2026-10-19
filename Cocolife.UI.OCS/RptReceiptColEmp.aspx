<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="~/RptReceiptColEmp.aspx.vb" Inherits="Cocolife.UI.OCS.RptReceiptColEmp" %>
<%--<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="RptReceipt.aspx.vb" Inherits="Cocolife.UI.OCS.RptReceipt"
    Title="Online Collection System (Report : Premium Related)" %>--%>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Online Collection System - Receipt</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
</head>
<body>
    <form id="frmRptReceipt" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CRViewer" runat="server" 
            ReportSourceID="CRSource" 
            EnableDatabaseLogonPrompt="False"
            EnableParameterPrompt="False"
            ToolPanelView="None"
            HasExportButton="False"
            HasSearchButton="False"
            HasRefreshButton="False"
            HasToggleGroupTreeButton="False" 
            HasToggleParameterPanelButton="False" 
            HasDrillUpButton="False" 
            HasDrilldownTabs="False"
            PrintMode="ActiveX" />
        <CR:CrystalReportSource ID="CRSource" runat="server">
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
