#Region "Description"
' PAGE NAME     : Common Report Factory Utility
' CREATED BY    : MPRO
' CREATED DATE  : 06/24/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.HttpResponse
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System.IO
#End Region

Namespace Common

    Public Class uReportFactory

#Region "Variables"
        Protected Shared reportQueue As New Queue
        Protected Shared iMaxCount As Integer = 75
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

#End Region

#Region "Single Point Functions"

        Protected Shared Function CreateReport(pReportDocument As Type) As ReportDocument
            Dim report As Object = Activator.CreateInstance(pReportDocument)
            reportQueue.Enqueue(report)
            Return DirectCast(report, ReportDocument)
        End Function

        Public Shared Function GetReport(pReportDocument As Type) As ReportDocument
            If reportQueue.Count > iMaxCount Then
                DirectCast(reportQueue.Dequeue(), ReportDocument).Close()
                DirectCast(reportQueue.Dequeue(), ReportDocument).Dispose()
                GC.Collect()
            End If
            Return CreateReport(pReportDocument)
        End Function

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Shared Sub CRLogOnInfo(ByVal pReport As ReportDocument,
                                      ByVal pServerName As String,
                                      ByVal pDatabase As String,
                                      ByVal pUsername As String,
                                      ByVal pPassword As String)

            Dim crConnInfo As New ConnectionInfo
            Dim crDatabase As Database
            Dim crTables As Tables
            Dim crTable As Table
            Dim crTableLogOnInfo As TableLogOnInfo

            Try
                With crConnInfo
                    .UserID = pUsername
                    .Password = pPassword
                    .ServerName = pServerName
                    .DatabaseName = pDatabase
                    .IntegratedSecurity = False
                    pReport.SetDatabaseLogon(.UserID, .Password, .ServerName, .DatabaseName)
                    crDatabase = pReport.Database
                    crTables = crDatabase.Tables
                    For Each crTable In crTables
                        crTableLogOnInfo = crTable.LogOnInfo
                        crTableLogOnInfo.ConnectionInfo.UserID = .UserID
                        crTableLogOnInfo.ConnectionInfo.Password = .Password
                        crTableLogOnInfo.ConnectionInfo.ServerName = .ServerName
                        crTableLogOnInfo.ConnectionInfo.DatabaseName = .DatabaseName

                        crTableLogOnInfo.ConnectionInfo.IntegratedSecurity = False
                        crTable.ApplyLogOnInfo(crTableLogOnInfo)
                        crTable.Location = String.Concat(crTableLogOnInfo.ConnectionInfo.DatabaseName, ".dbo.", crTable.Location)
                    Next
                End With
            Catch ex As Exception
                Throw
            End Try

        End Sub

        Public Shared Sub DocToPrint(ByVal pReport As ReportDocument)

            Dim doctoprint As New System.Drawing.Printing.PrintDocument()

            Try
                doctoprint.PrinterSettings.PrinterName = "HP LaserJet Professional M1132 MFP"
                For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                    Dim rawKind As Integer
                    If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "Letter" Then
                        rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                        pReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait
                        pReport.PrintOptions.PaperSource = DirectCast(rawKind, CrystalDecisions.Shared.PaperSource)
                        pReport.PrintOptions.PaperSize = DirectCast(rawKind, CrystalDecisions.Shared.PaperSize)
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Throw
            End Try

        End Sub

        Public Shared Sub ExportCRTo(ByVal pReport As ReportDocument,
                              ByVal pFormat As ExportFormatType,
                              Optional ByVal pFileName As String = "",
                              Optional ByVal pDispositin As String = "attachment")

            Try
                Dim oStream As Stream = pReport.ExportToStream(pFormat)

                Using ms As New MemoryStream()
                    oStream.CopyTo(ms)
                    Dim bytes As Byte() = ms.ToArray()

                    HttpContext.Current.Response.Clear()
                    HttpContext.Current.Response.ClearContent()
                    HttpContext.Current.Response.ClearHeaders()
                    HttpContext.Current.Response.Buffer = True
                    HttpContext.Current.Response.Expires = -1

                    Select Case pFormat
                        Case ExportFormatType.Excel
                            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
                        Case ExportFormatType.PortableDocFormat
                            HttpContext.Current.Response.ContentType = "application/pdf"
                    End Select

                    If pFileName <> String.Empty Then
                        HttpContext.Current.Response.AddHeader("Content-Disposition", pDispositin & "; filename=" & pFileName)
                    End If

                    HttpContext.Current.Response.BinaryWrite(bytes)
                    HttpContext.Current.Response.Flush()
                    HttpContext.Current.Response.End()
                End Using

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Shared Sub SetPageMargin(ByVal pReport As ReportDocument,
                                        ByVal pTopMargin As Double,
                                        ByVal pRightMargin As Double,
                                        ByVal pBottomMargin As Double,
                                        ByVal pLeftMargin As Double)

            Dim margin As PageMargins

            Try
                margin = pReport.PrintOptions.PageMargins
                margin.topMargin = pTopMargin
                margin.rightMargin = pRightMargin
                margin.bottomMargin = pBottomMargin
                margin.leftMargin = pLeftMargin
                pReport.PrintOptions.ApplyPageMargins(margin)
            Catch ex As Exception
                Throw
            End Try

        End Sub
        Public Shared Function GenerateDMCMReceiptPDF(
    ByVal pReportPath As String,
    ByVal pSiteCode As Long,
    ByVal pDocNumber As Long,
    ByVal pUserId As Long
) As Byte()

            If Not File.Exists(pReportPath) Then
                Throw New FileNotFoundException(
                    "The DMCM report template was not found.",
                    pReportPath
                )
            End If

            Dim report As New ReportDocument()

            Try
                report.Load(
                    pReportPath,
                    OpenReportMethod.OpenReportByTempCopy
                )

                report.SetParameterValue("pSiteCode", pSiteCode)
                report.SetParameterValue("pDocNumber", pDocNumber)
                report.SetParameterValue("pUserId", pUserId)

                CRLogOnInfo(
                    report,
                    Cocolife.Utility.OCS.Classes.cCrystalConn.CRServerName,
                    String.Empty,
                    Cocolife.Utility.OCS.Classes.cCrystalConn.CRUserID,
                    Cocolife.Utility.OCS.Classes.cCrystalConn.CRPassword
                )

                Using pdfStream As Stream =
                    report.ExportToStream(ExportFormatType.PortableDocFormat)

                    If pdfStream Is Nothing Then
                        Throw New InvalidOperationException(
                            "Crystal Reports did not return a PDF stream."
                        )
                    End If

                    If pdfStream.CanSeek Then
                        pdfStream.Position = 0
                    End If

                    Using memoryStream As New MemoryStream()
                        pdfStream.CopyTo(memoryStream)

                        Dim pdfBytes As Byte() = memoryStream.ToArray()

                        If pdfBytes.Length = 0 Then
                            Throw New InvalidOperationException(
                                "The generated PDF is empty."
                            )
                        End If

                        Return pdfBytes
                    End Using
                End Using

            Finally
                Try
                    report.Close()
                Finally
                    report.Dispose()
                End Try
            End Try

        End Function

#End Region

    End Class

End Namespace
