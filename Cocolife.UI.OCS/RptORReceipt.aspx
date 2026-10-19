<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="~/RptORReceipt.aspx.vb" Inherits="Cocolife.UI.OCS.RptORReceipt" %>
<%--<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="RptORReceipt.aspx.vb" Inherits="Cocolife.UI.OCS.RptORReceipt"
    Title="Online Collection System (Report : Non-Premium Related)" %>--%>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Online Collection System - Receipt</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
</head>
<body>
    <form id="frmRpt" runat="server">
    <div id="dvReport">
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
            PrintMode="ActiveX"
            EnableDrillDown="False" 
            BestFitPage="False" />
        <CR:CrystalReportSource ID="CRSource" runat="server">
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
