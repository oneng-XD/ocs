#Region "Description"
' PAGE NAME     : Payment Batch Premium Related Presenter
' CREATED BY    : EJ 
' CREATED DATE  : 08/24/2017
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
Imports System.Deployment
Imports Excel = Microsoft.Office.Interop.Excel

'Imports System.Configuration
#End Region

Namespace Payment
    Public Class PPaymentBatchPremiumRelated

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPaymentBatchPremiumRelated As Payment.IPaymentBatchPremiumRelated
        Private vwConfirmMsg As preMessages.IConfirmationMessage
        Private vwReport As Report.IReport

        Private objPaymntBatchPremiumRelated As bllPayment.BPaymentBatchPremiumRelated
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Payment.IPaymentBatchPremiumRelated)

            vwSysMsg = pView
            vwPaymentBatchPremiumRelated = pView
            vwConfirmMsg = pView
            vwReport = pView

            With vwPaymentBatchPremiumRelated
                ' -------------------------------------------------------------------------------
                AddHandler .ClearScreenAPRDetails, AddressOf ClearScreenAPRDetails
                AddHandler .ClearScreenCheckDetails, AddressOf ClearScreenCheckDetails
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenPaymentDetails, AddressOf ClearScreenPaymentDetails
                AddHandler .ClearScreenCashDetails, AddressOf ClearScreenCashDetails
                AddHandler .ClearScreenPaymentTypeDetails, AddressOf ClearScreenPaymentTypeDetails
                AddHandler .ClearScreenViewBatch, AddressOf ClearScreenViewBatch
                AddHandler .ClearScreenBatch, AddressOf ClearScreenBatch
                ' -------------------------------------------------------------------------------
                AddHandler .LoadViewBatch, AddressOf LoadViewBatch
                AddHandler .LoadSourceSite, AddressOf LoadSourceSite
                AddHandler .LoadCurrency, AddressOf LoadCurrency
                AddHandler .LoadPaymentType, AddressOf LoadPaymentType
                AddHandler .LoadNewOPR, AddressOf LoadNewOPR
                AddHandler .LoadOPR, AddressOf LoadOPR
                AddHandler .LoadBatch, AddressOf LoadBatch
                AddHandler .LoadBatchDetails, AddressOf LoadBatchDetails
                AddHandler .LoadBatchNonPrem, AddressOf LoadBatchNonPrem
                ' -------------------------------------------------------------------------------
                AddHandler .CheckPrevPayType, AddressOf CheckPrevPaytype
                ' ------------------------------------------------------------------------------
                AddHandler .AddCashPayment, AddressOf AddCashPayment
                AddHandler .AddPaymentTypeDetails, AddressOf AddPaymentTypeDetails
                AddHandler .DeletePaymentTypeDetails, AddressOf DeletePaymentTypeDetails
                ' -------------------------------------------------------------------------------
                AddHandler .GetPaymentTypeDetails, AddressOf GetPaymentTypeDetails
                ' -------------------------------------------------------------------------------
                AddHandler .ProcessPaymentBatchPremium, AddressOf ProcessPaymentBatchPremium
                AddHandler .ConfirmCancel, AddressOf ConfirmCancel
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                AddHandler .ConfirmPrint, AddressOf ConfirmPrint
                ' -------------------------------------------------------------------------------
                AddHandler .LoadBankList, AddressOf LoadBankList     'LoadCheckBank
                ' -------------------------------------------------------------------------------
                AddHandler .GenerateReport, AddressOf GenerateReport

            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

        Private Function IsValidAPRDetails() As Boolean

            Try

                With vwPaymentBatchPremiumRelated

                    If .WithAPR Then

                        If .APRNumber = cDataType.fLong.Empty Then
                            Call SetMessage("Please enter valid APR number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .APRDate = cDataType.fDate.Empty Then
                            Call SetMessage("Please enter APR date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .APRDate = cDataType.fDate.Invalid Then
                            Call SetMessage("Invalid APR date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf (.APRDate < DateAdd(DateInterval.Month, -1, .OPRDate)) _
                            Or .APRDate > .OPRDate Then
                            Call SetMessage(String.Concat("APR date should be within ", DateAdd(DateInterval.Month, -1, .OPRDate).ToString("MM/dd/yyyy"), " to ", .OPRDate.ToString("MM/dd/yyyy")), eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .APRAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter APR amount.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .APRAmount <> .OPRGrossAmount Then
                            Call SetMessage("APR amount and gross amount must be equal.", eSystemMessage.Warning, True)
                            Return False
                        End If

                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidAPRDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidAPRDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidCashDetails() As Boolean
            Try
                With vwPaymentBatchPremiumRelated
                    If .CashPaymentTag = True Then
                        If .OPRCashAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter valid cash amount.", eSystemMessage.Warning, True)
                            Return False
                        End If
                    Else
                        Call SetMessage("Incorrect Payment Type tagging!", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidCashDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidCashDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function

        Private Function IsValidCheckDetails() As Boolean

            Try

                With vwPaymentBatchPremiumRelated

                    If .CheckPaymentTag = True Then

                        If .CheckNumber = cDataType.fLong.Empty Then
                            Call SetMessage("Please enter valid check number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CheckAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter valid check amount.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .CheckAmount > .OPRGrossAmount Then
                            Call SetMessage("Check amount exceeds gross amount.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        'If .CheckBankName = cDataType.fString.Empty And .OtherBankName = cDataType.fString.Empty Then
                        '    Call SetMessage("Please enter bank name.", eSystemMessage.Warning, True)
                        '    Return False
                        'End If

                        If .CheckBankName = cDataType.fString.Empty Then
                            Call SetMessage("Please enter bank name.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        'If .CheckBankBranch = cDataType.fString.Empty Then
                        '    Call SetMessage("Please enter bank branch.", eSystemMessage.Warning, True)
                        '    Return False
                        'End If
                    Else
                        Call SetMessage("Incorrect Payment Type tagging!", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidCheckDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidCheckDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidORDetails() As Boolean

            Try

                With vwPaymentBatchPremiumRelated

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidORDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidORDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentTypeDetails(ByVal pPaymentType As String) As Boolean

            Try
                With vwPaymentBatchPremiumRelated

                    If .PaymentTotalAmount = .OPRGrossAmount Then
                        Call SetMessage("OR Details Amount already reached Gross Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .PaymentTotalAmount + .OPRCashAmount + .CheckAmount > .OPRGrossAmount Then
                        Call SetMessage("OR Details amount will exceed gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case pPaymentType
                        Case eReference.PayTypeCSH
                            Return IsValidCashDetails()
                        Case eReference.PayTypeCHQ
                            If .OPRCashAmount > 0 Then
                                Return (IsValidCashDetails() And IsValidCheckDetails())
                            Else
                                Return IsValidCheckDetails()
                            End If
                    End Select

                End With

                Return False

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPaymentTypeDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPaymentTypeDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentDetails() As Boolean

            Try

                With vwPaymentBatchPremiumRelated

                    If .OPRDate = cDataType.fDate.Empty Then
                        Call SetMessage("Error in generating OR Date.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .OPRGrossAmount = cDataType.fDecimal.Empty Then
                        Call SetMessage("Please enter gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .OPRPaymentType = cDataType.fString.Empty Then
                        Call SetMessage("Please select payment type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .OPRCurrency = cDataType.fString.Empty Then
                        Call SetMessage("Please select currency of payment.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPaymentDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPaymentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentBatchPremiumRelated() As Boolean

            Try

                If IsValidTotals() AndAlso _
                    IsValidPaymentDetails() AndAlso _
                    IsValidAPRDetails() _
                Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPaymentBatchPremiumRelated : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPaymentNonPremiumRelated.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidTotals() As Boolean
            Try
                With vwPaymentBatchPremiumRelated
                    If .PaymentTotalAmount = .OPRGrossAmount Then
                        Return True
                    Else
                        Call SetMessage(String.Concat("Premium Payment.<br /><br />", "Some payment totals do not match Gross Amount!<br /><br />"), eSystemMessage.Information, True)
                        Return False
                    End If

                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidTotals : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidTotals.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function


        Private Function IsValidLoadViewBatch() As Boolean

            Try

                With vwPaymentBatchPremiumRelated
                    If .ViewBatchFrom > .ViewBatchTo Then
                        Call SetMessage("View Date From exceeds Date To.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case .ViewBatchFrom
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please enter Date From.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid Date From.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("View Date From precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is > cDataType.fDate.Current
                            Call SetMessage("View Date From exceeds current date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                    Select Case .ViewBatchTo
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please enter Date To.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid Date To.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("View Date To precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is > cDataType.fDate.Current
                            Call SetMessage("View Date To exceeds current date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidLoadViewBatch : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidLoadViewBatch.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function CheckPaymentIfExisting(ByVal pAction As String, ByVal pPayType As String, ByVal pReference As String, ByVal pAmount As Decimal) As Boolean

            Dim intRecCnt As Integer = 0

            Try
                With vwPaymentBatchPremiumRelated
                    For Each item As cPaymentType In .lstPaymentTypeDetails
                        If item.PaymentType = pPayType _
                        And item.ReferenceNumber = pReference Then
                            If item.Amount = pAmount _
                            Or pPayType = eReference.PayTypeCSH _
                            Or pPayType = eReference.PayTypeCHQ Then
                                intRecCnt = intRecCnt + 1
                            End If
                        End If
                    Next
                    If pAction = "ADD" And intRecCnt >= 1 Then Return True
                    If pAction = "EDIT" And intRecCnt >= 2 Then Return True
                End With
                Return False
            Catch ex As Exception
                Throw New Exception(String.Concat("CheckPaymentIfExisting : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckPaymentIfExisting.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

#End Region

#Region "Transactions"

        Private Sub ClearScreenAPRDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentBatchPremiumRelated
                    .APRNumber = cDataType.fLong.Empty
                    .APRDate = cDataType.fDate.Empty
                    .APRAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAPRDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenCheckDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentBatchPremiumRelated
                    .CheckNumber = cDataType.fLong.Empty
                    .CheckAmount = cDataType.fDecimal.Empty
                    .CheckBankName = cDataType.fString.Empty
                    '.OtherBankName = cDataType.fString.Empty
                    .CheckBankBranch = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenCheckDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentBatchPremiumRelated
                    .lstOprList = New List(Of cBatchOpr)
                    .lstPaymentTypeDetails = New List(Of cPaymentType)

                    .PaymentTypeTag = cDataType.fBoolean.Empty
                    .CashPaymentTag = cDataType.fBoolean.Empty
                    .CheckPaymentTag = cDataType.fBoolean.Empty
                    '---------------'
                    .CashTotalAmount = cDataType.fDecimal.Empty
                    .CheckTotalAmount = cDataType.fDecimal.Empty
                    .OPRGrossAmount = cDataType.fDecimal.Empty

                End With

                Call ClearScreenPaymentDetails(sender, e)
                Call ClearScreenAPRDetails(sender, e)
                Call ClearScreenPaymentTypeDetails(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenPaymentDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentBatchPremiumRelated
                    .BatchID = cDataType.fLong.Empty
                    .OPRDate = cDataType.fDate.Empty
                    .OPRGrossAmount = cDataType.fDecimal.Empty
                    .OPRPaymentType = cDataType.fString.Empty
                    .OPRCurrency = cDataType.fString.Empty
                    .WithAPR = cDataType.fBoolean.Empty
                    .OPRRemarks = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPaymentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenCashDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentBatchPremiumRelated
                    .OPRCashAmount = cDataType.fDecimal.Empty

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenCashDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Call ClearScreenCashDetails(sender, e)
                Call ClearScreenCheckDetails(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPaymentTypeDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenViewBatch(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentBatchPremiumRelated
                    .ViewBatchFrom = cDataType.fDate.Empty
                    .ViewBatchTo = cDataType.fDate.Empty
                    .ViewBatchID = cDataType.fLong.Empty
                    .dtViewBatch = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenViewBatch.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenBatch(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentBatchPremiumRelated
                    .BatchID = 0
                    .lstOprList = New List(Of cBatchOpr)
                    .OPRGrossAmount = 0
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenBatch.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        ' -------------------------------------------------------------------------------

        Private Function GetItemValue(ByVal pItem As String, ByVal pSplit As String, ByVal pArray As Integer) As String

            Dim arrItem() As String

            Try
                arrItem = pItem.Split(pSplit)
                Return arrItem(pArray)
            Catch ex As Exception
                Throw New Exception(String.Concat("GetItemValue : ", ex.Message))
            End Try

        End Function

        Private Function GetTrnCod(ByVal pActType As String, ByVal pPayType As String) As String
            Try
                Select Case pActType
                    Case "TPREM"
                        Return "RTOPD"
                    Case "MUFND"
                        Return "MUFND"
                End Select

                Select Case pPayType
                    Case eReference.PayTypeCCA
                    Case eReference.PayTypeDCA
                    Case Else
                        Select Case pActType
                            Case "PREMM"
                                Return "PRMPD"
                            Case Else
                                Return String.Concat(pPayType, "PD")
                        End Select
                End Select
            Catch ex As Exception
                Throw New Exception(String.Concat("GeTrnCod : ", ex.Message))
            End Try
        End Function

        Private Sub GetPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim cptLocal As New cPaymentType

            Try
                With vwPaymentBatchPremiumRelated
                    Dim lstRowLocal As List(Of cPaymentType) = (From l In .lstPaymentTypeDetails
                               Where l.PaymentType = .OPRPaymentType
                               Select l).ToList


                    For Each cptLocal In lstRowLocal
                        Select Case .OPRPaymentType
                            Case eReference.PayTypeCSH
                                .OPRCashAmount = cptLocal.Amount
                            Case eReference.PayTypeCHQ
                                .CheckAmount = cptLocal.Amount
                                .CheckNumber = cptLocal.CheckNumber
                                .CheckBankName = cptLocal.Bank
                                .CheckBankBranch = cptLocal.Branch
                            Case Else
                        End Select
                    Next
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPaymentTypeDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub GenerateReport(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwReport
                    .IsSuccessful = False
                    Select Case .ReportType
                        Case eReport.ReceiptBatch
                            .RptParamString = String.Concat(vwPaymentBatchPremiumRelated.BatchID, "|", Not .IsPreview, "|", .SiteCode, "|", .UserId)
                            If Not .IsPreview Then SetMessage(String.Concat("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!"), eSystemMessage.Information, True)
                    End Select
                    .IsSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GenerateReport.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPaymentType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentBatchPremiumRelated.dtPaymentType = objBLL.GetRefPAYTYP_ROP
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPaymentType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub CheckPrevPaytype(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentBatchPremiumRelated

                    Select Case .lstPaymentTypeDetails.Count
                        Case Is > 0
                            If .PrevPayType = .OPRPaymentType Then
                                .IsPayTypeSuccessful = True
                                'ElseIf .PrevPayType = eReference.PayTypeCHQ And .ORPaymentType = eReference.PayTypeCSH Then
                                '    .IsPayTypeSuccessful = True
                            End If
                        Case Else
                            .IsPayTypeSuccessful = True
                    End Select

                    If .IsPayTypeSuccessful = False Then
                        Call SetMessage("Change of Payment type requires deletion of previously encoded data.", eSystemMessage.Warning, True)
                    End If

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckPrevPayType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadSourceSite(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BSiteDetails
                vwPaymentBatchPremiumRelated.dtSourceSite = objBLL.LoadSourceSite()
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSourceSite.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadCurrency(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BCurRef
                vwPaymentBatchPremiumRelated.dtCurrency = objBLL.GetRefCurRefList
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadCurrency.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadNewOPR(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BOrDetails
                With vwPaymentBatchPremiumRelated
                    .IsSuccessful = False

                    objBLL.LoadNewOR(vwPaymentBatchPremiumRelated.SiteCode, eReference.ReceiptType.CI, vwPaymentBatchPremiumRelated.UserID)

                    .IsSuccessful = True
                    .BatchID = 0 'objBLL.ORNumber
                    .OPRDate = objBLL.ORDate.ToShortDateString
                End With

            Catch ex As ArgumentException
                Call SetMessage(String.Concat("New OR is not Allowed!<br /><br />", ex.Message), eSystemMessage.Information, True)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadNewOR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadViewBatch(ByVal sender As Object, ByVal e As EventArgs)
            Try
                'Dim objBLL As New bllReference.BOrDetails
                'With vwPaymentBatchPremiumRelated
                '    vwPaymentBatchPremiumRelated.dtViewBatch = objBLL.LoadViewBatch(.SiteCode, .ViewBatchFrom, .ViewBatchTo)
                'End With

                Dim objBLL As New bllReference.BOprDetails
                Dim dtLocal As New DataTable

                With vwPaymentBatchPremiumRelated
                    If IsValidLoadViewBatch() Then
                        'If .ViewBatchID = 0 Then
                        '    dtLocal = objBLL.LoadViewBatch(.SiteCode, .ViewBatchFrom, .ViewBatchTo)
                        'Else
                        '    dtLocal = objBLL.LoadViewBatch(.SiteCode, .ViewBatchID, 0)
                        'End If

                        If .ViewBatchID > 0 Then
                            dtLocal = objBLL.LoadViewOPR(.SiteCode, .ViewBatchID, 4)
                        Else
                            dtLocal = objBLL.LoadViewOPR(.SiteCode, True, .ViewBatchFrom, .ViewBatchTo)
                        End If

                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(String.Concat("Load View Batch.<br /><br />", "No Batch found!"), eSystemMessage.Information, True)
                        End If

                        .dtViewBatch = dtLocal
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewBatch.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadBankList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BBankDetails

                vwPaymentBatchPremiumRelated.dtBankList = objBLL.LoadBankList() 'SiteCode      'LoadCheckBank      'vwPaymentBatchPremiumRelated.ORCurrency

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBankList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ProcessPaymentBatchPremium(ByVal sender As Object, ByVal e As EventArgs)
            'Objects
            Dim objSiteBatch As New bllWorking.BSiteBatch

            Dim mDocSaveState As String = String.Empty

            Try

                vwPaymentBatchPremiumRelated.IsSuccessful = False

                If IsValidPaymentBatchPremiumRelated() Then
                    With vwPaymentBatchPremiumRelated
                        mDocSaveState = .DocSaveState
                        objPaymntBatchPremiumRelated = New bllPayment.BPaymentBatchPremiumRelated

                        Select Case mDocSaveState

                            Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit, eReference.DocSaveState.Print
                                For Each item In .lstPaymentTypeDetails
                                    objSiteBatch = New bllWorking.BSiteBatch(.BatchID, .UserID, .SourceSite, .BatchNonPrem, .OPRDate, item.CheckNumber, item.Bank, item.Branch, .OPRCurrency, item.PaymentType, .APRDate, .APRNumber, .OPRRemarks)
                                Next
                        End Select

                        With objPaymntBatchPremiumRelated
                            .SiteCode = vwPaymentBatchPremiumRelated.SiteCode
                            .UserID = vwPaymentBatchPremiumRelated.UserID
                            .IsAprTag = vwPaymentBatchPremiumRelated.WithAPR
                            .SiteBatch = objSiteBatch

                            Select Case mDocSaveState
                                Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit

                                    .ProcessPaymentBatchPremiumRelated()

                                Case eReference.DocSaveState.Print
                                    '.PrintPaymentPremiumRelated()
                                    .IsSuccessful = True
                                    '.CopyToStgObjects()
                                    .PostPaymentBatchPremiumRelated()
                                    'If vwPaymentBatchPremiumRelated.ApplicationNumber <> 0 Then
                                    '    Call SetMessage(String.Concat("Premium Payment.<br /><br />", "Please don't forget to print the application number<br />in the application form.!<br /><br />"), eSystemMessage.Information, True)
                                    'End If

                                Case eReference.DocSaveState.Cancel
                                    .CancelPaymentBatchPremiumRelated()

                            End Select

                            vwPaymentBatchPremiumRelated.IsSuccessful = .IsSuccessful

                            If .IsSuccessful And Not mDocSaveState = eReference.DocSaveState.Print Then
                                Call SetMessage(String.Concat("Premium Payment.<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                            End If
                        End With
                    End With
                End If

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ProcessPaymentBatchPremium.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ConfirmCancel(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "CANCEL"
                    .Message = String.Concat("Are you sure you want to cancel Batch ID ", vwPaymentBatchPremiumRelated.BatchID, "?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmCancel.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmSave(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "SAVE"
                    .Message = String.Concat("Are you sure you want to Save this Batch?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmSave.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmPrint(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "PRINT"
                    .Message = String.Concat("Are you sure you want to Print Batch ID ", vwPaymentBatchPremiumRelated.BatchID, "?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmPrint.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Function GetIdFromList(ByVal pList As Object, ByVal pCounter As Integer) As Long
            If pList.Count > pCounter Then
                Return pList(pCounter)
            Else
                Return 0
            End If
        End Function

        Private Sub LoadOPR(ByVal sender As Object, ByVal e As EventArgs)

            Dim objSiteTmpTrn As New bllWorking.BSiteTmpTrn
            Dim objSiteOPRHeader As New bllWorking.BSiteOPRHeader
            Dim objSiteBatch As New bllReference.BOprDetails
            Dim objSiteOPRAPRPy As New bllWorking.BSiteOPRAPRPy
            Dim objSiteOPRChkPy As New bllWorking.BSiteOPRChkPy
            Dim objSiteOPRDtl As New bllWorking.BSiteOPRDtl
            Dim mOprNumber As Long
            ''Dim objSiteORVAT As New bllWorking.BSiteORVAT
            ''Dim objSiteORPart As New bllWorking.BSiteORPart
            ''Dim objSiteORColDtl As New bllWorking.BSiteORColDtl
            ''Dim objTrnref As New bllReference.BTrnRef

            Try
                With vwPaymentBatchPremiumRelated
                    Dim dtSiteBatch = objSiteBatch.GetBatchOprList(.BatchID)

                    Call LoadBatch(sender, e)

                    If dtSiteBatch.Rows.Count <> 0 Then
                        For Each dr As DataRow In dtSiteBatch.Rows
                            mOprNumber = dr.Item("opr_nmbr")
                            Exit For
                        Next
                    End If

                    Dim dtSiteTmpTrn = objSiteTmpTrn.GetTmpTrnDt(mOprNumber, eReference.DocTypeOPR, .ReceiptById)
                    Dim dtSiteOPRChkPy = objSiteOPRChkPy.GetOPRChkPyDt(mOprNumber, .ReceiptById)
                    Dim dtSiteOPRDtl = objSiteOPRDtl.GetOPRDtlDt(mOprNumber, .ReceiptById)
                    objSiteOPRheader.GetOPRheader(mOprNumber, .ReceiptById)
                    objSiteOPRAPRPy.GetOPRAPRPy(mOprNumber, .ReceiptById)

                    Dim mIsAPR As Boolean = False
                    Dim mPayTyp As String = String.Empty
                    '------ Payment Details

                    If dtSiteTmpTrn.Rows.Count <> 0 Then
                        For Each dr As DataRow In dtSiteTmpTrn.Rows
                            If dr.Item("status_id") = objSiteOPRHeader.StatusId Then
                                .SourceSite = dr.Item("colloff")
                                .OPRCurrency = dr.Item("curcod")
                                .OPRDate = dr.Item("trndat")
                                mPayTyp = dr.Item("paytyp")
                                If dr.Item("aprnum") > 0 Then mIsAPR = True
                            End If
                        Next
                    End If

                    .OPRRemarks = objSiteOPRHeader.OPRRemarks

                    '------ APR
                    If mIsAPR Then
                        .WithAPR = mIsAPR

                        If objSiteOPRAPRPy.StatusId = objSiteOPRHeader.StatusId Then
                            .APRNumber = objSiteOPRAPRPy.APRNmbr
                            .APRDate = objSiteOPRAPRPy.APRDate
                            .APRAmount = .OPRGrossAmount
                        End If

                    End If
                    '------ End

                    '------ Payment Type Details / OR Details
                    .PrevPayType = mPayTyp
                    .OPRPaymentType = mPayTyp

                    Dim dtPaymentTypeList As New DataTable
                    Dim mCptDtlList As New List(Of cPaymentType)
                    .CashTotalAmount = 0
                    .CheckTotalAmount = 0
                    Select Case mPayTyp
                        Case eReference.PayTypeCSH
                            mCptDtlList.Add(New cPaymentType(.OPRGrossAmount))
                            AddToTotalAmount(mPayTyp, .OPRGrossAmount)
                        Case eReference.PayTypeCHQ
                            dtPaymentTypeList = dtSiteOPRChkPy
                    End Select

                    If dtPaymentTypeList.Rows.Count > 0 Then
                        For Each dr As DataRow In dtPaymentTypeList.Rows
                            'If dr.Item("status_id") = 1 Then
                            If dr.Item("status_id") = objSiteOPRHeader.StatusId Then
                                dr.Item("amount") = .OPRGrossAmount
                                mCptDtlList.Add(New cPaymentType(dr, mPayTyp))
                                AddToTotalAmount(mPayTyp, .OPRGrossAmount)
                            End If
                        Next
                    End If

                    If dtSiteOPRDtl.Rows.Count > 0 Then
                        For Each dr As DataRow In dtSiteOPRDtl.Rows
                            If dr.Item("act_type") = "ACCPY" And dr.Item("line_nmbr") = 1 Then
                                .BatchNonPrem = dr.Item("trnx_code")
                            End If
                        Next
                    End If
                    '.OPRGrossAmount = .PaymentTotalAmount
                    .lstPaymentTypeDetails = mCptDtlList

                    '------ End

                    '---------------------------------------------------------------------
                    If objSiteOPRHeader.CancelFlag = 1 Then
                        .DocSaveState = eReference.DocSaveState.Cancel
                        .PaymentTypeTag = False
                    ElseIf objSiteOPRHeader.StatusId = 10 Or objSiteOPRHeader.StatusId = 11 Then
                        .DocPrinted = IIf(objSiteOPRHeader.PrtFlag = 1, True, False)
                        .DocSaveState = eReference.DocSaveState.Print 'ALLOW REPRINT AND CANCEL OF PRINTED/POSTED RECEIPTS
                    Else
                        .DocSaveState = eReference.DocSaveState.ViewEdit
                    End If

                    'End If
                End With
            Catch ex As Exception
                vwPaymentBatchPremiumRelated.DocSaveState = eReference.DocSaveState.Initial
                Call ClearScreenMain(sender, e)
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadOPR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadBatch(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BOprDetails
                Dim lstLocal As New List(Of cBatchOpr)
                Dim dtLocal As New DataTable

                With vwPaymentBatchPremiumRelated
                    .IsSuccessful = False

                    .OPRGrossAmount = 0
                    dtLocal = objBLL.GetBatchOprList(.BatchID)
                    For Each dr In dtLocal.Rows
                        lstLocal.Add(New cBatchOpr(dr))
                        .OPRGrossAmount += dr.item("opr_amt")
                    Next
                    .lstOprList = lstLocal

                    .IsSuccessful = True
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBatch.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadBatchNonPrem(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentBatchPremiumRelated.dtBatchNonPrem = objBLL.GetRefBatchNonPrem
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBatchNonPrem.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadBatchDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentBatchPremiumRelated.dtBatchDetails = objBLL.GetRefBatchDetails
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBatchDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        ' -------------------------------------------------------------------------------

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

        Private Sub GetConfirmation(ByVal pMessage As String, ByVal pIsMessage As Boolean)

            Try
                With vwConfirmMsg
                    .ClickedState = False
                    .Message = pMessage
                    .isMessage = pIsMessage
                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("GetConfirmation : ", ex.Message))
            End Try

        End Sub
        ' -------------------------------------------------------------------------------
        Private Sub AddCashPayment(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cPaymentType)
            Dim cptLocal As New cPaymentType()

            Dim mIsPaymentExists As Boolean = True

            Try
                With vwPaymentBatchPremiumRelated
                    .IsPayTypeSuccessful = False
                    'Check & Cash
                    If IsValidPaymentTypeDetails(eReference.PayTypeCSH) Then
                        If .OPRPaymentType = eReference.PayTypeCHQ And .OPRCashAmount > 0 Then

                            mIsPaymentExists = CheckPaymentIfExisting("ADD", eReference.PayTypeCSH, String.Empty, cptLocal.Amount)
                            If mIsPaymentExists Then
                                Call SetMessage("Payment already exists.", eSystemMessage.Warning, True)
                                Exit Sub
                            Else
                                If .OPRPaymentType = eReference.PayTypeCHQ And _
                                .OPRCashAmount = .OPRGrossAmount Then
                                    Call SetMessage("Cash and Check amount allocation invalid.", eSystemMessage.Warning, True)
                                    Exit Sub
                                End If

                                cptLocal = New cPaymentType(
                                    .OPRCashAmount)

                                lstLocal = .lstPaymentTypeDetails

                                lstLocal.Add(cptLocal)
                                Call AddToTotalAmount(cptLocal.PaymentType, cptLocal.Amount)

                                .lstPaymentTypeDetails = lstLocal
                                .IsPayTypeSuccessful = True
                            End If
                        End If
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddCashPayment.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub AddPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cPaymentType)
            Dim cptLocal As New cPaymentType()

            Dim mIsPaymentExists As Boolean = True

            Try
                With vwPaymentBatchPremiumRelated
                    .IsPayTypeSuccessful = False
                    If IsValidPaymentTypeDetails(.OPRPaymentType) Then

                        lstLocal = .lstPaymentTypeDetails

                        Select Case .OPRPaymentType
                            Case eReference.PayTypeCSH
                                cptLocal = New cPaymentType(
                                    .OPRCashAmount)
                            Case eReference.PayTypeCHQ
                                cptLocal = New cPaymentType(
                                    .CheckAmount,
                                    .CheckNumber,
                                    .CheckBankName,
                                    .CheckBankBranch)
                        End Select

                        mIsPaymentExists = CheckPaymentIfExisting("ADD", cptLocal.PaymentType, cptLocal.ReferenceNumber, cptLocal.Amount)
                        If mIsPaymentExists Then
                            Call SetMessage("Payment already exists.", eSystemMessage.Warning, True)
                            Exit Sub
                        Else
                            lstLocal.Add(cptLocal)
                            Call AddToTotalAmount(cptLocal.PaymentType, cptLocal.Amount)

                            .lstPaymentTypeDetails = lstLocal
                            .IsPayTypeSuccessful = True
                        End If
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddPaymentTypeDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub AddToTotalAmount(ByVal pPayType As String, ByVal pAmount As Decimal)

            Try
                With vwPaymentBatchPremiumRelated
                    Select Case pPayType
                        Case eReference.PayTypeCSH
                            .CashTotalAmount += pAmount
                        Case eReference.PayTypeCHQ
                            .CheckTotalAmount += pAmount
                    End Select
                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("AddToTotalAmount : ", ex.Message))
            End Try

        End Sub

        Private Sub DeletePaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cPaymentType)

            Try
                With vwPaymentBatchPremiumRelated
                    'Call SetMessage("Please enter valid APR number.", eSystemMessage.Warning, True)
                    .IsPayTypeSuccessful = False

                    For Each cptLocal As cPaymentType In .lstPaymentTypeDetails '.PaymentTypeListSession
                        If cptLocal.PaymentTypeID <> .PaymentTypeID Then
                            lstLocal.Add(cptLocal)
                        Else
                            Call AddToTotalAmount(cptLocal.PaymentType, -cptLocal.Amount)
                        End If
                    Next
                    .lstPaymentTypeDetails = lstLocal
                    .IsPayTypeSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error DeletePaymentTypeDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

#End Region

    End Class
End Namespace

