<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptReceiptCIPreview.aspx.vb" Inherits="Cocolife.UI.OCS.RptReceiptCIPreview" %>
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
    <script type="text/javascript">
        function printDiv(divName) {
            var printContents = document.getElementById(divName);
            var originalContents = document.body.innerHTML;
            document.getElementById('header').style.display = 'none';
            document.getElementById('footer').style.display = 'none';
            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function Print() {
            var dvReport = document.getElementById("dvReport");
            var frame1 = dvReport.getElementsByTagName("iframe")[0];
            if (navigator.appName.indexOf("Internet Explorer") != -1 || navigator.appVersion.indexOf("Trident") != -1) {
                frame1.name = frame1.id;
                window.frames[frame1.id].focus();
                window.frames[frame1.id].print();
            } else {
                var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
                frameDoc.print();
            }
        }
    </script>  

    <form id="frmRpt" runat="server">
    <%--<button id="btnPrint" runat="server" onclick="Print()">Print</button>--%>
    <div id="dvReport">
        <CR:CrystalReportViewer ID="CRViewer" runat="server" 
            ReportSourceID="CRSource" 
            EnableDatabaseLogonPrompt="False"
            EnableParameterPrompt="False"
            ToolPanelView="None"
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
         <%--HasExportButton="False"--%>
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
