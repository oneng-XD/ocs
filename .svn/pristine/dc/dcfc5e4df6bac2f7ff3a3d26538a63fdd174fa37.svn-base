Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports eCrystalConn = Cocolife.Utility.OCS.Enums.eCrystalConn

Partial Public Class RptReceiptCol
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Dim lngSiteCode As Long = Request.QueryString("sitecode")
            Dim lngDocNumber As Long = Request.QueryString("docnumber")
            Dim lngUserId As Long = Request.QueryString("userid")
            Dim oReport As New ReportDocument
            'Dim strFileName As String = String.Concat(lngSiteCode, "_", lngDocNumber, "_Receipt.pdf")

            oReport.Load(Server.MapPath("~\Reports\Receipt.rpt"))
            oReport.SetParameterValue("pSiteCode", lngSiteCode)
            oReport.SetParameterValue("pDocNumber", lngDocNumber)
            oReport.SetParameterValue("pUserId", lngUserId)

            Dim logon As New TableLogOnInfo
            Dim conn As New ConnectionInfo

            conn.ServerName = eCrystalConn.CRServerName
            conn.UserID = eCrystalConn.CRUserID
            conn.Password = eCrystalConn.CRPassword

            For Each table As CrystalDecisions.CrystalReports.Engine.Table In oReport.Database.Tables
                logon = table.LogOnInfo
                logon.ConnectionInfo = conn
                table.ApplyLogOnInfo(logon)
            Next

            CRViewer.ReportSource = oReport
            'CRViewer.DataBind()

            'export to pdf
            'Dim oStream As System.IO.MemoryStream
            'oStream = oReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            'Dim bytes As Byte() = oStream.ToArray()
            'oStream.Close()

            'Response.Clear()
            'Response.ClearContent()
            'Response.ClearHeaders()
            'Response.Buffer = True
            'Response.Expires = -1
            'Response.ContentType = "application/pdf"
            'Response.AddHeader("Content-Disposition", "attachment; filename=" & strFileName)
            'Response.BinaryWrite(bytes)
            'Response.Flush()
            'Response.Close()
            'Response.End()

        Catch ex As Exception
            Throw
        End Try

    End Sub

End Class