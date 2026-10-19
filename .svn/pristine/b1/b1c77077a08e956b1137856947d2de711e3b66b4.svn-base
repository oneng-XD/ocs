#Region "Description"
' PAGE NAME     : Maintenance Official Receipt Series
' CREATED BY    : EJ 
' CREATED DATE  : 10/17/2017
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports cValidation = Cocolife.Utility.OCS.Common.uValidation
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports preMessages = Cocolife.Utility.OCS.Messages
Imports bllReference = Cocolife.BLL.OCS.Reference
Imports bllPerson = Cocolife.BLL.OCS.Person
Imports bllMaintenance = Cocolife.BLL.OCS.Maintenance
Imports bllSearch = Cocolife.BLL.OCS.Search
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllPayment = Cocolife.BLL.OCS.Payment
Imports preSearch = Cocolife.Presenter.OCS.Search
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Maintenance

    Public Class PMaintOfficialReceipt

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwConfirmation As preMessages.IConfirmationMessage
        Private vwMaintOfficialReceipt As Maintenance.IMaintOfficialReceipt
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Maintenance.IMaintOfficialReceipt)

            vwSysMsg = pView
            vwConfirmation = pView
            vwMaintOfficialReceipt = pView

            With vwMaintOfficialReceipt
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenSeries, AddressOf ClearScreenSeries
                AddHandler .ClearScreenList, AddressOf ClearScreenList
                ' ---------------------------------------------------------------------
                AddHandler .LoadStatus, AddressOf LoadStatus
                AddHandler .LoadSiteList, AddressOf LoadSiteList
                AddHandler .LoadSeriesList, AddressOf LoadSeriesList
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                AddHandler .Add1000, AddressOf Add1000
                ' ---------------------------------------------------------------------
                AddHandler .SaveSeries, AddressOf SaveSeries
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"
        Private Function IsValidSeries() As Boolean
            Try
                Dim objBll As New bllMaintenance.BSiteOprSeries
                With vwMaintOfficialReceipt

                    If .SeriesPrspid = 0 Then
                        Call SetMessage("Please select a Site.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesCount = 0 Then
                        Call SetMessage("Count must be greater than zero.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesStatus = 0 Then
                        Call SetMessage("Please select Status.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesStart = 0 Then
                        Call SetMessage("Please complete series details.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesEnd = 0 Then
                        Call SetMessage("Please complete series details.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Right(.SeriesStart, 6) = 0 Then
                        Call SetMessage("Invalid starting value.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Right(.SeriesEnd, 6) = 0 Then
                        Call SetMessage("Invalid ending value.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesStart > .SeriesEnd Then
                        Call SetMessage("Lower limit exceeds the upper limit.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesEnd.ToString.Length > 6 Then
                        Call SetMessage("Upper limit exceeds the site's prefix.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Dim mCheckOprSeries = objBll.CheckOprSeries(.SeriesEditId,
                                                                CDec(String.Concat(.SeriesPrefix, .SeriesStart.ToString("000000"))),
                                                                CDec(String.Concat(.SeriesPrefix, .SeriesEnd.ToString("000000"))))

                    If mCheckOprSeries Then
                        Call SetMessage("Series overlaps with an existing record.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidSeries : ", ex.Message))
            End Try
        End Function
#End Region

#Region "Transactions"

        Private Sub ClearScreenSeries(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwMaintOfficialReceipt
                    .SeriesEditId = cDataType.fLong.Empty
                    .SeriesPrefix = cDataType.fLong.Empty
                    .SeriesStart = cDataType.fLong.Empty
                    .SeriesEnd = cDataType.fLong.Empty
                    .SeriesStatus = cDataType.fInteger.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwMaintOfficialReceipt
                    .SeriesPrspid = cDataType.fLong.Empty
                    .dtSeriesList = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Call ClearScreenSeries(sender, e)
                Call ClearScreenList(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        ' -------------------------------------------------------------------------------

        Private Sub LoadSeriesList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllMaintenance.BSiteOprSeries
                Dim dtLocal As New DataTable
                With vwMaintOfficialReceipt
                    .IsSuccessful = False

                    dtLocal = objBLL.LoadSeriesList(.SiteCode)
                    .dtSeriesList = dtLocal

                    .IsSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSeriesList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub Add1000(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllMaintenance.BSiteOprSeries
                Dim dtLocal As New DataTable
                Dim lngMax As Long = 0

                With vwMaintOfficialReceipt
                    dtLocal = objBLL.LoadSeriesList(.SiteCode)

                    For Each dr As DataRow In dtLocal.Rows
                        If CLng(Right(dr.Item("end_opr_series").ToString, 6)) > lngMax And dr.Item("status_id") <> 4 Then
                            lngMax = CLng(Right(dr.Item("end_opr_series").ToString, 6))

                            .SeriesPrspid = cDataType.fLong.IfNull(dr.Item("prspid"))
                            .SeriesPrefix = cDataType.fLong.IfNull(dr.Item("prefix"))
                            .SeriesStart = (CLng(Right(dr.Item("end_opr_series").ToString, 6)) + 1).ToString("D6")
                            .SeriesEnd = (CLng(Right(dr.Item("end_opr_series").ToString, 6)) + 1000).ToString("D6")
                        End If
                    Next
                    If Right(.SeriesStart, 6) = 0 And Right(.SeriesEnd, 6) = 0 Then
                        .SeriesPrspid = .SiteCode
                        .SeriesCount = 1000
                        .SeriesStart += 1
                        .SeriesEnd += 1000
                    End If
                    .SeriesStatus = 1

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error Add1000.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadStatus(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim dtLocal As New DataTable
                ' Define columns
                dtLocal.Columns.Add("ID", GetType(System.Int32))
                dtLocal.Columns.Add("DESCRIPTION", GetType(System.String))
                ' Add a row of data
                dtLocal.Rows.Add(eReference.Status.Active, eReference.Status.Active.ToString.ToUpper)
                'dtLocal.Rows.Add(eReference.Status.Inactive, eReference.Status.Inactive.ToString.ToUpper)

                vwMaintOfficialReceipt.dtStatus = dtLocal
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadStatus.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadSiteList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BSiteDetails
                vwMaintOfficialReceipt.dtSiteList = objBLL.LoadSourceSite()
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSiteSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmSave(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmation
                    If IsValidSeries() Then
                        .ConfirmCaller = "SAVE"
                        .Message = String.Concat("Are you sure you want to save this series?<br />Count: ", vwMaintOfficialReceipt.SeriesCount, "<br />OPR#", String.Concat(vwMaintOfficialReceipt.SeriesPrefix, vwMaintOfficialReceipt.SeriesStart.ToString("000000")), " to ",
                                                 String.Concat(vwMaintOfficialReceipt.SeriesPrefix, vwMaintOfficialReceipt.SeriesEnd.ToString("000000")), ".")
                        .isMessage = True
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmSave.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub SaveSeries(ByVal sender As Object, ByVal e As EventArgs)
            'Premium Related
            Dim objSiteOprSeries As New bllMaintenance.BSiteOprSeries

            Try

                vwMaintOfficialReceipt.IsSuccessful = False

                If IsValidSeries() Then
                    With vwMaintOfficialReceipt

                        Dim objMaintOfficialReceipt = New bllMaintenance.BMaintOfficialReceipt

                        With objMaintOfficialReceipt
                            .SiteCode = vwMaintOfficialReceipt.SeriesPrspid
                            .UserID = vwMaintOfficialReceipt.UserID
                            .SeriesEditId = vwMaintOfficialReceipt.SeriesEditId
                            .SeriesPrefix = vwMaintOfficialReceipt.SeriesPrefix
                            .SeriesStart = vwMaintOfficialReceipt.SeriesStart
                            .SeriesEnd = vwMaintOfficialReceipt.SeriesEnd
                            .SeriesStatus = vwMaintOfficialReceipt.SeriesStatus

                            objSiteOprSeries = New bllMaintenance.BSiteOprSeries(.SeriesEditId, .SiteCode, String.Concat(.SeriesPrefix, .SeriesStart.ToString("000000")), String.Concat(.SeriesPrefix, .SeriesEnd.ToString("000000")), .SeriesStatus, .UserID, Now, .UserID, Now)

                            .OprSeries = objSiteOprSeries

                            .SaveSeries()

                            vwMaintOfficialReceipt.IsSuccessful = .IsSuccessful

                            If .IsSuccessful = True Then
                                Call SetMessage(String.Concat("Receipt Series Posting<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                            End If
                        End With
                    End With
                End If

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error SaveSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub
    
        Private Sub SetMessage(ByVal pMessage As String, ByVal pMessageType As String, ByVal pIsMessage As Boolean)

            Try
                With vwSysMsg
                    .Message = pMessage
                    .MessageType = pMessageType
                    .isMessage = pIsMessage
                End With
            Catch ex As Exception
                Throw
            End Try

        End Sub

#End Region

    End Class

End Namespace

