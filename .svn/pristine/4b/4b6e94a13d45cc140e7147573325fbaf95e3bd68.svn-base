Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports cCrystalConn = Cocolife.Utility.OCS.Classes.cCrystalConn
Imports eSession = Cocolife.Utility.OCS.Enums.eSession
Imports Cocolife.Utility.OCS.Common

Partial Public Class RptReceiptBatch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mPara = Split(Session(eSession.ReportParam), "|")
        Dim mBatchId As Long = CLng(mPara(0))
        Dim mHasPrintButton As Boolean = CBool(mPara(1))
        Dim mSiteCode As Long = mPara(2)
        Dim mUserId As Long = mPara(3)
        Dim oReport As New ReportDocument

        Dim strFileName As String = String.Concat(mSiteCode, "_", mBatchId, "_ReceiptBatch.pdf")
        Dim strReportFileName As String = "~\reports\ReceiptBatch.rpt"

        Try
            oReport = uReportFactory.GetReport(oReport.GetType)
            CRSource.Report.FileName = strReportFileName
            oReport.Load(Server.MapPath(strReportFileName), OpenReportMethod.OpenReportByTempCopy)

            oReport.SetParameterValue("pSiteCode", mSiteCode)
            oReport.SetParameterValue("pBatchId", mBatchId)
            oReport.SetParameterValue("pUserId", mUserId)
            CRViewer.HasPrintButton = mHasPrintButton
            'btnPrint.Visible = False 'mHasPrintButton

            Call uReportFactory.CRLogOnInfo(oReport, cCrystalConn.CRServerName, String.Empty, cCrystalConn.CRUserID, cCrystalConn.CRPassword)
            CRViewer.ReportSource = oReport
            'If mHasPrintButton Then
            '    CRViewer.DataBind()

            '    Call uReportFactory.ExportCRTo(oReport, ExportFormatType.PortableDocFormat, strFileName, "inline")
            'End If
        Catch ex As Exception
            oReport.Database.Dispose()
            oReport.Close()
            oReport.Dispose()
            oReport = Nothing
        Finally
            'If mHasPrintButton Then
            If oReport IsNot Nothing Then
                If oReport.IsLoaded Then
                    oReport.Database.Dispose()
                    '            oReport.Close()
                    '            oReport.Dispose()
                    '            oReport = Nothing
                End If
            End If
            'End If
        End Try

    End Sub

    Private Sub CRViewer_Unload(sender As Object, e As EventArgs) Handles CRViewer.Unload
        CRViewer.ReportSource = Nothing
        CRViewer.Dispose()
        CRViewer = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub

End Class