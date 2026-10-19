#Region "Description"
' PAGE NAME     : Payment Premium Related Presenter
' CREATED BY    : MPRO 
' CREATED DATE  : 03/26/2015
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
Imports bllSearch = Cocolife.BLL.OCS.Search
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllPayment = Cocolife.BLL.OCS.Payment
Imports preSearch = Cocolife.Presenter.OCS.Search
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Payment

    Public Class PDailyCollectionReport

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwConfirmation As preMessages.IConfirmationMessage
        Private vwPosting As Payment.IDailyCollectionReport
        Private vwReport As Report.IReport
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Payment.IDailyCollectionReport)

            vwSysMsg = pView
            vwConfirmation = pView
            vwPosting = pView
            vwReport = pView

            With vwPosting
                ' -------------------------------------------------------------------------------
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenDCR, AddressOf ClearScreenDCR
                'AddHandler .ClearScreenPosting, AddressOf ClearScreenPosting
                ' -------------------------------------------------------------------------------
                'AddHandler .ConfirmPosting, AddressOf ConfirmPosting
                ' -------------------------------------------------------------------------------
                AddHandler .LoadDcrType, AddressOf LoadDcrType
                'AddHandler .LoadRecordType, AddressOf LoadRecordType
                AddHandler .LoadCurcod, AddressOf LoadCurcod
                'AddHandler .LoadPostDate, AddressOf LoadPostDate
                ' -------------------------------------------------------------------------------
                AddHandler .GenerateReport, AddressOf GenerateReport
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"
        'Private Function IsValidPosting() As Boolean

        '    Try

        '        With vwPosting
        '            Select Case .PostDate
        '                Case cDataType.fDate.Empty
        '                    Call SetMessage("Please load Post Date.", eSystemMessage.Warning, True)
        '                    Return False
        '                Case cDataType.fDate.Invalid
        '                    Call SetMessage("Invalid Post Date.", eSystemMessage.Warning, True)
        '                    Return False
        '                Case Is < cDataType.fDate.Minimum
        '                    Call SetMessage("View Post Date precedes minimum date.", eSystemMessage.Warning, True)
        '                    Return False
        '                Case Is > cDataType.fDate.Current
        '                    Call SetMessage("View Post Date exceeds current date.", eSystemMessage.Warning, True)
        '                    Return False
        '            End Select
        '        End With

        '        Return True

        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPosting.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Function

        Private Function IsValidDcr() As Boolean

            Try

                With vwPosting
                    Select Case .DcrStartDate
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please input Start Date.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid Start Date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("Start Date precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is > cDataType.fDate.Current
                            Call SetMessage("Start Date exceeds current date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                    Select Case .DcrEndDate
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please input End Date.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid End Date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("End Date precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is > cDataType.fDate.Current
                            Call SetMessage("End Date exceeds current date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                    If .DcrDocType = String.Empty Then
                        Call SetMessage("Please select DCR Type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    'If .DcrRecordType = String.Empty Then
                    '    Call SetMessage("Please select Record Type.", eSystemMessage.Warning, True)
                    '    Return False
                    'End If

                    If .DcrCurcod = String.Empty Then
                        Call SetMessage("Please select a Currency for Summary.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidDcr : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidDcr.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function
#End Region

#Region "Transactions"

        Private Sub ClearScreenDCR(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPosting
                    .DcrStartDate = cDataType.fDate.Current
                    .DcrEndDate = cDataType.fDate.Current
                    .DcrDocType = cDataType.fString.Empty
                    '.DcrRecordType = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenDCR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        'Private Sub ClearScreenPosting(ByVal sender As Object, ByVal e As EventArgs)

        '    Try
        '        With vwPosting
        '            .PostDate = cDataType.fDate.Empty
        '        End With
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPosting.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Call ClearScreenDCR(sender, e)
                'Call ClearScreenPosting(sender, e)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        ' -------------------------------------------------------------------------------

        'Private Sub ConfirmPosting(ByVal sender As Object, ByVal e As EventArgs)
        '    Try
        '        With vwConfirmation
        '            If IsValidPosting() Then
        '                .ConfirmCaller = "POST"
        '                .Message = String.Concat("Do you wish to proceed with posting for ", vwPosting.PostDate.ToShortDateString, "?")
        '                .isMessage = True
        '            End If
        '        End With
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmPosting.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try
        'End Sub

        Private Sub LoadDcrType(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BParamRef
                vwPosting.dtDcrType = objBLL.GetRefDcrType
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadDcrType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        'Private Sub LoadRecordType(ByVal sender As Object, ByVal e As EventArgs)
        '    Try
        '        Dim objBLL As New bllReference.BParamRef
        '        vwPosting.dtRecordType = objBLL.GetRefRecordType
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPaymentType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try
        'End Sub

        'Private Sub LoadPostDate(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim objBLL As New bllReference.BOprDetails

        '    Try
        '        With vwPosting
        '            .IsSuccessful = False
        '            objBLL.LoadLastOPR(vwPosting.SiteCode)
        '            .IsSuccessful = True
        '            .PostDate = objBLL.OPRDate.ToShortDateString
        '            'End If
        '        End With

        '    Catch ex As ArgumentException
        '        Call SetMessage(String.Concat("Posting is not Allowed!.<br /><br />", ex.Message), eSystemMessage.Information, True)
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPostDate.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        Private Sub LoadCurcod(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BCurRef
                vwPosting.dtCurcod = objBLL.GetRefCurRefList
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadCurcod.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub
        ' -------------------------------------------------------------------------------

        Private Sub GenerateReport(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPosting
                    vwReport.IsSuccessful = False
                    If IsValidDcr() Then
                        Select Case vwReport.ReportType
                            Case eReport.DetailPrem, eReport.DetailNonPrem, eReport.SummaryPrem, eReport.SummaryNonPrem
                                'vwReport.RptParamString = String.Concat(.SiteCode, "|", .UserID, "|", .DcrRecordType, "|", .DcrStartDate, "|", .DcrEndDate, "|", .RoleCode, "|", .DcrCurcod)
                                vwReport.RptParamString = String.Concat(.SiteCode, "|", .UserID, "|1|", .DcrStartDate, "|", .DcrEndDate, "|", .RoleCode, "|", .DcrCurcod)
                        End Select
                        .IsSuccessful = True
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GenerateReport.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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

