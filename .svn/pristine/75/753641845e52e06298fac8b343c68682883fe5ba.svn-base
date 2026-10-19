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

    Public Class PMaintAgentsORSeries

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwConfirmation As preMessages.IConfirmationMessage
        Private vwMaintAgentsORSeries As Maintenance.IMaintAgentsORSeries
        Private vwAgent As preSearch.IAgent
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Maintenance.IMaintAgentsORSeries)

            vwSysMsg = pView
            vwConfirmation = pView
            vwMaintAgentsORSeries = pView
            vwAgent = pView

            With vwMaintAgentsORSeries
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenSeries, AddressOf ClearScreenSeries
                AddHandler .ClearScreenAgent, AddressOf ClearScreenAgent
                ' ---------------------------------------------------------------------
                AddHandler .LoadSeriesList, AddressOf LoadSeriesList
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                ' ---------------------------------------------------------------------
                AddHandler .AddNext, AddressOf AddNext
                AddHandler .AddTemp, AddressOf AddTemp
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
                Dim objBll As New bllMaintenance.BMaintAgentsORSeries
                With vwMaintAgentsORSeries

                    If .SeriesAgent = 0 Then
                        Call SetMessage("Please Input Agent ID.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesRegNumber = cDataType.fString.Empty Then
                        Call SetMessage("Please input regnum details.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Left(.SeriesRegNumber, 6) <> "CORFOR" AndAlso Mid(.SeriesRegNumber, 2, 2) <> "RC" Then
                        Call SetMessage("Invalid registration number.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case .SeriesRegDate
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please enter registration date.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid registration date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("Registration date precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is > cDataType.fDate.Current
                            Call SetMessage("Registration date exceeds current date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                    Select Case .SeriesExpDate
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please enter expiration date.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid expiration date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("Expiration date precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is <= cDataType.fDate.Current
                            Call SetMessage("Invalid expiration date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                    If .SeriesStart = 0 AndAlso (Not .IsSeriesTemp OrElse Mid(.SeriesRegNumber, 2, 2) = "RC") Then
                        Call SetMessage("Please complete series details.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesEnd = 0 AndAlso (Not .IsSeriesTemp OrElse Mid(.SeriesRegNumber, 2, 2) = "RC") Then
                        Call SetMessage("Please complete series details.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SeriesStart > .SeriesEnd Then
                        Call SetMessage("Lower limit exceeds the upper limit.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Dim mCheckSeries = objBll.LoadSeriesList(.SeriesAgent)
                    Dim dtLocal = From c In mCheckSeries.AsEnumerable
                                  Where c.Item("row_id") <> .SeriesEditId _
                                  AndAlso ((c.Item("or_book_fr") >= .SeriesStart And c.Item("or_book_fr") <= .SeriesEnd) _
                                           OrElse (c.Item("or_book_to") >= .SeriesStart And c.Item("or_book_to") <= .SeriesEnd) _
                                           OrElse (.SeriesStart >= c.Item("or_book_fr") And .SeriesStart <= c.Item("or_book_to")))
                                  Select c

                    If dtLocal.Count > 0 Then
                        Call SetMessage("Series overlaps with an existing record.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Dim mCheckRegNum = objBll.LoadSeriesList(0)
                    Dim dtRegNum = From c In mCheckRegNum.AsEnumerable
                                  Where c.Item("row_id") <> .SeriesEditId _
                                  AndAlso c.Item("agnprs") <> .SeriesAgent _
                                  AndAlso c.Item("regnum") = .SeriesRegNumber
                                  Select c

                    If dtRegNum.Count > 0 Then
                        Call SetMessage("Registration Number already used for another agent.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidSeries : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function
#End Region

#Region "Transactions"

        Private Sub ClearScreenSeries(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwMaintAgentsORSeries
                    .IsSeriesTemp = False
                    .SeriesEditId = cDataType.fString.Empty
                    .SeriesStart = cDataType.fLong.Empty
                    .SeriesEnd = cDataType.fLong.Empty
                    .SeriesRegNumber = cDataType.fString.Empty
                    .SeriesRegDate = cDataType.fDate.Empty
                    .SeriesExpDate = cDataType.fDate.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenAgent(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwAgent
                    .LoadAgentID = cDataType.fLong.Empty
                    .LoadAgentName = cDataType.fString.Empty
                    .LoadAgentFName = cDataType.fString.Empty
                    .LoadAgentMName = cDataType.fString.Empty
                    .LoadAgentLName = cDataType.fString.Empty
                    .LoadAgencyID = cDataType.fLong.Empty
                    .LoadAgencyName = cDataType.fString.Empty
                End With
                vwMaintAgentsORSeries.AgentIDTag = False
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAgent.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Call ClearScreenSeries(sender, e)
                Call ClearScreenAgent(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        ' -------------------------------------------------------------------------------

        Private Sub LoadSeriesList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllMaintenance.BMaintAgentsORSeries
                Dim dtLocal As New DataTable
                With vwMaintAgentsORSeries
                    .IsSuccessful = False

                    dtLocal = objBLL.LoadSeriesList(.SeriesAgent)
                    .dtSeriesList = dtLocal

                    .IsSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSeriesList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmSave(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmation
                    If IsValidSeries() Then
                        .ConfirmCaller = "SAVE"
                        .Message = String.Concat("Are you sure you want to save this series?")
                        .isMessage = True
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmSave.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub SaveSeries(ByVal sender As Object, ByVal e As EventArgs)
            Dim objAgentOprSeries As New bllMaintenance.BMaintAgentsORSeries

            Try

                vwMaintAgentsORSeries.IsSuccessful = False

                If IsValidSeries() Then
                    With vwMaintAgentsORSeries

                        Dim objMaintAgentsORSeries = New bllMaintenance.BMaintAgentsORSeries

                        With objMaintAgentsORSeries
                            .SiteCode = vwMaintAgentsORSeries.SiteCode
                            .UserID = vwMaintAgentsORSeries.UserID
                            .SeriesEditId = vwMaintAgentsORSeries.SeriesEditId
                            .SeriesAgent = vwMaintAgentsORSeries.SeriesAgent
                            .SeriesRegNum = vwMaintAgentsORSeries.SeriesRegNumber
                            .SeriesRegDate = vwMaintAgentsORSeries.SeriesRegDate
                            .SeriesOldRegNum = vwMaintAgentsORSeries.SeriesOldRegNumber
                            .SeriesOldRegDate = vwMaintAgentsORSeries.SeriesOldRegDate
                            .SeriesStart = vwMaintAgentsORSeries.SeriesStart
                            .SeriesEnd = vwMaintAgentsORSeries.SeriesEnd
                            .SeriesExpDate = vwMaintAgentsORSeries.SeriesExpDate
                            .LastUpdate = DateTime.Now

                            .SaveSeries()

                            vwMaintAgentsORSeries.IsSuccessful = .IsSuccessful

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

        Private Sub AddNext(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllMaintenance.BMaintAgentsORSeries
                Dim dtLocal As New DataTable
                With vwMaintAgentsORSeries
                    dtLocal = objBLL.LoadSeriesList(.SeriesAgent)
                    For Each dr As DataRow In dtLocal.Rows
                        .SeriesRegNumber = dr.Item("regnum")
                        .SeriesRegDate = dr.Item("regdate")
                        .SeriesStart = CLng(dr.Item("or_book_to")) + 1
                        .SeriesEnd = CLng(dr.Item("or_book_to")) + 50
                        .SeriesExpDate = Nothing
                        Exit For
                    Next
                    If dtLocal.AsEnumerable.Count = 0 Then
                        .IsSeriesTemp = True
                    Else
                        .IsSeriesTemp = False
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddNext.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub AddTemp(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwMaintAgentsORSeries
                    .SeriesEditId = String.Empty
                    .SeriesRegNumber = String.Concat("CORFOR", Left(vwAgent.LoadAgentFName, 1), vwAgent.LoadAgentLName)
                    .SeriesRegDate = DateTime.Now
                    .SeriesStart = 0
                    .SeriesEnd = 0
                    .SeriesExpDate = CDate(String.Concat("12/31/", Now.Year))
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddTemp.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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

