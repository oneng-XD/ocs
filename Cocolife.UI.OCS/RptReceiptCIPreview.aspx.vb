Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports cCrystalConn = Cocolife.Utility.OCS.Classes.cCrystalConn
Imports eSession = Cocolife.Utility.OCS.Enums.eSession
Imports Cocolife.Utility.OCS.Common
Imports System.IO

Partial Public Class RptReceiptCIPreview
    Inherits System.Web.UI.Page

    Private mPdfBytes As Byte()
    Private mPdfFileName As String

    Protected Sub Page_Load(
        ByVal sender As Object,
        ByVal e As System.EventArgs
    ) Handles Me.Load

        If Session(eSession.ReportParam) Is Nothing Then
            Throw New InvalidOperationException(
                "Report parameters are missing. Please reopen the DMCM report."
            )
        End If

        Dim mPara As String() =
            Session(eSession.ReportParam).ToString().Split("|"c)

        If mPara.Length < 6 Then
            Throw New InvalidOperationException(
                "DMCM report parameters are incomplete."
            )
        End If

        Dim mDocNumber As Long = CLng(mPara(0))
        Dim mSiteCode As Long = CLng(mPara(2))
        Dim mUserId As Long = CLng(mPara(3))
        Dim mFile As String = mPara(5)

        mPdfFileName =
            String.Concat(mSiteCode, "_", mDocNumber, "_ReceiptCIPreview.pdf")

        Dim strReportFileName As String =
            String.Concat("~/reports/ReceiptCIPreview", mFile, ".rpt")

        If Not File.Exists(Server.MapPath(strReportFileName)) Then
            strReportFileName = "~/reports/ReceiptCIPreview.rpt"
        End If

        If Not File.Exists(Server.MapPath(strReportFileName)) Then
            Throw New FileNotFoundException(
                "The DMCM Crystal Report template was not found."
            )
        End If

        'This page owns and disposes this report instance.
        Dim oReport As New ReportDocument()

        Try
            oReport.Load(
                Server.MapPath(strReportFileName),
                OpenReportMethod.OpenReportByTempCopy
            )

            oReport.SetParameterValue("pSiteCode", mSiteCode)
            oReport.SetParameterValue("pDocNumber", mDocNumber)
            oReport.SetParameterValue("pUserId", mUserId)

            'Use your existing working database login method.
            uReportFactory.CRLogOnInfo(
                oReport,
                cCrystalConn.CRServerName,
                String.Empty,
                cCrystalConn.CRUserID,
                cCrystalConn.CRPassword
            )

            'STEP 1: Export the report as PDF.
            Using pdfStream As Stream =
                oReport.ExportToStream(ExportFormatType.PortableDocFormat)

                If pdfStream Is Nothing Then
                    Throw New InvalidOperationException(
                        "Crystal Reports did not return a PDF stream."
                    )
                End If

                If pdfStream.CanSeek Then
                    pdfStream.Position = 0
                End If

                'STEP 2: Convert the PDF stream to Byte().
                Using memoryStream As New MemoryStream()
                    pdfStream.CopyTo(memoryStream)
                    mPdfBytes = memoryStream.ToArray()
                End Using
            End Using

            If mPdfBytes.Length = 0 Then
                Throw New InvalidOperationException(
                    "The generated PDF is empty."
                )
            End If

            'View this in Visual Studio: View > Output > Debug.
            System.Diagnostics.Debug.WriteLine(
                "DMCM PDF filename: " & mPdfFileName
            )

            System.Diagnostics.Debug.WriteLine(
                "DMCM PDF byte count: " & mPdfBytes.Length.ToString()
            )

            'DATABASE SAVE WILL GO HERE LATER.
            'Pass mPdfBytes to a BLOB / VARBINARY database parameter.
            'Example:
            'SaveDMCMReceipt(mDocNumber, mPdfFileName, mPdfBytes)

        Finally
            Try
                oReport.Close()
            Finally
                oReport.Dispose()
            End Try
        End Try

    End Sub

    Protected Overrides Sub Render(
        ByVal writer As System.Web.UI.HtmlTextWriter
    )

        If mPdfBytes Is Nothing OrElse mPdfBytes.Length = 0 Then
            MyBase.Render(writer)
            Return
        End If

        'STEP 3: Display the PDF using the converted bytes.
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/pdf"

        Response.Cache.SetCacheability(
            System.Web.HttpCacheability.NoCache
        )
        Response.Cache.SetNoStore()

        Response.AddHeader(
            "Content-Disposition",
            "inline; filename=""" & mPdfFileName & """"
        )

        Response.BinaryWrite(mPdfBytes)

        'Do not call MyBase.Render here:
        'the response must contain PDF bytes only, without page HTML.
    End Sub

End Class