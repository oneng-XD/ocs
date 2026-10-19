#Region "Imports"

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports cCrystalConn = Cocolife.Utility.OCS.Classes.cCrystalConn
Imports eSession = Cocolife.Utility.OCS.Enums.eSession
Imports Cocolife.Utility.OCS.Common

#End Region

Partial Public Class RptORReceipt
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    Try
    '        'Dim mParam = Split(Session(eSession.ReportParam), "|")
    '        Dim mPara = Split(Session(eSession.ReportParam), "|")
    '        Dim mDocNumber As Long = CLng(mPara(0))
    '        Dim mHasPrintButton As Boolean = CBool(mPara(1))
    '        Dim mSiteCode As Long = mPara(2)
    '        Dim mUserId As Long = mPara(3)
    '        Dim oReport As New ReportDocument
    '        'Dim strFileName As String = String.Concat(mSiteCode, "_", mDocNumber, "_Receipt.pdf")

    '        oReport.Load(Server.MapPath("~\Reports\ReceiptOR.rpt"))
    '        oReport.SetParameterValue("pSiteCode", mSiteCode)
    '        oReport.SetParameterValue("pDocNumber", mDocNumber)
    '        oReport.SetParameterValue("pUserId", mUserId)

    '        Dim logon As New TableLogOnInfo
    '        Dim conn As New ConnectionInfo

    '        conn.ServerName = cCrystalConn.CRServerName
    '        conn.UserID = cCrystalConn.CRUserID
    '        conn.Password = cCrystalConn.CRPassword

    '        For Each table As CrystalDecisions.CrystalReports.Engine.Table In oReport.Database.Tables
    '            logon = table.LogOnInfo
    '            logon.ConnectionInfo = conn
    '            table.ApplyLogOnInfo(logon)
    '        Next

    '        divButton.Visible = mHasPrintButton
    '        CRViewer.ReportSource = oReport
    '        'CRViewer.DataBind()

    '        ''export to pdf
    '        'Dim oStream As System.IO.MemoryStream
    '        'oStream = oReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
    '        'Dim bytes As Byte() = oStream.ToArray()
    '        'oStream.Close()

    '        'Response.Clear()
    '        'Response.ClearContent()
    '        'Response.ClearHeaders()
    '        'Response.Buffer = True
    '        'Response.Expires = -1
    '        'Response.ContentType = "application/pdf"
    '        'Response.AddHeader("Content-Disposition", "attachment; filename=" & strFileName)
    '        'Response.BinaryWrite(bytes)
    '        'Response.Flush()
    '        'Response.Close()
    '        'Response.End()

    '    Catch ex As Exception
    '        'Throw
    '    End Try

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mPara = Split(Session(eSession.ReportParam), "|")
        Dim mDocNumber As Long = CLng(mPara(0))
        Dim mHasPrintButton As Boolean = CBool(mPara(1))
        Dim mSiteCode As Long = mPara(2)
        Dim mUserId As Long = mPara(3)
        Dim oReport As New ReportDocument

        Dim strFileName As String = String.Concat(mSiteCode, "_", mDocNumber, "_Receipt.pdf")
        Dim strReportFileName As String = "~\reports\ReceiptOR.rpt"

        Try
            oReport = uReportFactory.GetReport(oReport.GetType)
            CRSource.Report.FileName = strReportFileName
            oReport.Load(Server.MapPath(strReportFileName), OpenReportMethod.OpenReportByTempCopy)

            oReport.SetParameterValue("pSiteCode", mSiteCode)
            oReport.SetParameterValue("pDocNumber", mDocNumber)
            oReport.SetParameterValue("pUserId", mUserId)
            CRViewer.HasPrintButton = mHasPrintButton
            'divButton.Visible = mHasPrintButton

            Call uReportFactory.CRLogOnInfo(oReport, cCrystalConn.CRServerName, String.Empty, cCrystalConn.CRUserID, cCrystalConn.CRPassword)
            CRViewer.ReportSource = oReport
            'If mHasPrintButton Then
            '    CRViewer.DataBind()

            Call uReportFactory.ExportCRTo(oReport, ExportFormatType.PortableDocFormat, strFileName, "inline")
            'End If
        Catch ex As Exception
            oReport.Database.Dispose()
            oReport.Close()
            oReport.Dispose()
            oReport = Nothing
        Finally
            If mHasPrintButton Then
                If oReport IsNot Nothing Then
                    If oReport.IsLoaded Then
                        oReport.Database.Dispose()
                        oReport.Close()
                        oReport.Dispose()
                        oReport = Nothing
                    End If
                End If
            End If
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