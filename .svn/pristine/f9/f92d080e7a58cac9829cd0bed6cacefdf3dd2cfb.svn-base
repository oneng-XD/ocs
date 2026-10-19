Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports cCrystalConn = Cocolife.Utility.OCS.Classes.cCrystalConn
Imports eSession = Cocolife.Utility.OCS.Enums.eSession
Imports Cocolife.Utility.OCS.Common

Partial Public Class RptDetailNonPrem
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    Try

    '        Dim mParam = Split(Session(eSession.ReportParam), "|")
    '        Dim mSiteCode As Long = CLng(mParam(0))
    '        Dim mUserId As Long = CLng(mParam(1))
    '        Dim mStartDate As Date = CDate(mParam(2))
    '        Dim mEndDate As Date = CDate(mParam(3))
    '        Dim mIsPosted As Integer = CInt(mParam(4))
    '        Dim oReport As New ReportDocument

    '        Dim strFileName As String = String.Concat(mSiteCode, "_", mStartDate, "-", mEndDate, "_DCR_NP.pdf")

    '        oReport.Load(Server.MapPath("~\Reports\DetailNonPremium.rpt"))
    '        oReport.SetParameterValue("pSiteCode", mSiteCode)
    '        oReport.SetParameterValue("pUserId", mUserId)
    '        oReport.SetParameterValue("pStartDate", mStartDate)
    '        oReport.SetParameterValue("pEndDate", mEndDate)
    '        oReport.SetParameterValue("pIsPosted", mIsPosted)

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

    '        CRViewer.ReportSource = oReport
    '        CRViewer.DataBind()

    '        'export to pdf
    '        Dim oStream As System.IO.MemoryStream
    '        oStream = oReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
    '        Dim bytes As Byte() = oStream.ToArray()
    '        oStream.Close()

    '        Response.Clear()
    '        Response.ClearContent()
    '        Response.ClearHeaders()
    '        Response.Buffer = True
    '        Response.Expires = -1
    '        Response.ContentType = "application/pdf"
    '        Response.AddHeader("Content-Disposition", "attachment; filename=" & strFileName)
    '        Response.BinaryWrite(bytes)
    '        Response.Flush()
    '        Response.Close()
    '        Response.End()

    '    Catch ex As Exception
    '        Throw
    '    End Try

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SiteCode|UserID|DcrRecordType|DcrStartDate|DcrEndDate|RoleCode|DcrCurcod
        Dim mParam = Split(Session(eSession.ReportParam), "|")
        Dim mSiteCode As Long = CLng(mParam(0))
        Dim mUserId As Long = CLng(mParam(1))
        Dim mIsPosted As Integer = CInt(mParam(2))
        Dim mStartDate As Date = CDate(mParam(3))
        Dim mEndDate As Date = CDate(mParam(4))
        Dim mRoleCode As String = mParam(5)
        Dim oReport As New ReportDocument

        Dim strFileName As String = String.Concat(mSiteCode, "_", mStartDate.ToString("yyMMdd"), "-", mEndDate.ToString("yyMMdd"), "_DCR_NP.pdf")
        Dim strReportFileName As String = "~\reports\DetailNonPremium.rpt"

        Try
            oReport = uReportFactory.GetReport(oReport.GetType)
            CRSource.Report.FileName = strReportFileName
            oReport.Load(Server.MapPath(strReportFileName), OpenReportMethod.OpenReportByTempCopy)

            oReport.SetParameterValue("pSiteCode", mSiteCode)
            oReport.SetParameterValue("pUserId", mUserId)
            oReport.SetParameterValue("pStartDate", mStartDate)
            oReport.SetParameterValue("pEndDate", mEndDate)
            oReport.SetParameterValue("pIsPosted", mIsPosted)
            oReport.SetParameterValue("pRoleCode", mRoleCode)

            Call uReportFactory.CRLogOnInfo(oReport, cCrystalConn.CRServerName, String.Empty, cCrystalConn.CRUserID, cCrystalConn.CRPassword)
            CRViewer.ReportSource = oReport
            'CRViewer.DataBind()

            Call uReportFactory.ExportCRTo(oReport, ExportFormatType.PortableDocFormat, strFileName, "inline")
        Catch ex As Exception
            oReport.Database.Dispose()
            oReport.Close()
            oReport.Dispose()
            oReport = Nothing
        Finally
            If oReport IsNot Nothing Then
                If oReport.IsLoaded Then
                    oReport.Database.Dispose()
                    oReport.Close()
                    oReport.Dispose()
                    oReport = Nothing
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