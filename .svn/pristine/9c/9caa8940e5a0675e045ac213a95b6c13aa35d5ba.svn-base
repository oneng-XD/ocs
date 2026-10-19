#Region "Description"
' PAGE NAME     : Payment Non-Premium Related Presenter
' CREATED BY    : IBP 
' CREATED DATE  : 01/17/2017
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
    Public Class PPaymentNonPremiumRelated

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPaymentNonPremiumRelated As Payment.IPaymentNonPremiumRelated
        Private vwAgent As Search.IAgent
        Private vwConfirmMsg As preMessages.IConfirmationMessage
        Private vwColumbarium As Payment.IColumbariumDetails
        Private vwReport As Report.IReport

        Private objPaymntNonPremiumRelated As bllPayment.BPaymentNonPremiumRelated
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Payment.IPaymentNonPremiumRelated)

            vwSysMsg = pView
            vwPaymentNonPremiumRelated = pView
            vwConfirmMsg = pView
            vwColumbarium = pView
            vwReport = pView

            With vwPaymentNonPremiumRelated
                ' -------------------------------------------------------------------------------
                AddHandler .ClearScreenAPRDetails, AddressOf ClearScreenAPRDetails
                AddHandler .ClearScreenCheckDetails, AddressOf ClearScreenCheckDetails
                AddHandler .ClearScreenPayorType, AddressOf ClearScreenPayorType
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenReceiptDetails, AddressOf ClearScreenReceiptDetails
                AddHandler .ClearScreenPaymentDetails, AddressOf ClearScreenPaymentDetails
                AddHandler .ClearScreenVATComputation, AddressOf ClearScreenVATComputation
                AddHandler .ClearScreenCashDetails, AddressOf ClearScreenCashDetails
                AddHandler .ClearScreenPaymentTypeDetails, AddressOf ClearScreenPaymentTypeDetails
                AddHandler .ClearScreenPayor, AddressOf ClearScreenPayor
                AddHandler .ClearScreenAddPayor, AddressOf ClearScreenAddPayor
                AddHandler .ClearScreenViewOR, AddressOf ClearScreenViewOR
                AddHandler .ClearScreenColumbarium, AddressOf ClearScreenColumbarium 'IBP 1/20
                AddHandler .ClearScreenParticulars, AddressOf ClearScreenParticulars 'IBP 2/02
                AddHandler .ClearScreenOtherDetails, AddressOf ClearScreenOtherDetails 'IBP 2/25
                AddHandler .ClearTotals, AddressOf ClearTotals 'IBP 2/25

                ' -------------------------------------------------------------------------------
                AddHandler .LoadViewOR, AddressOf LoadViewOR
                AddHandler .LoadSourceSite, AddressOf LoadSourceSite
                AddHandler .LoadCurrency, AddressOf LoadCurrency
                AddHandler .LoadPersonType, AddressOf LoadPersonType
                AddHandler .LoadPersonTitle, AddressOf LoadPersonTitle
                AddHandler .LoadPaymentType, AddressOf LoadPaymentType
                AddHandler .LoadTransactionType, AddressOf LoadTransactionType
                AddHandler .LoadReceiptTransaction, AddressOf LoadReceiptTransaction
                AddHandler .GetReceiptTransactionDetails, AddressOf GetReceiptTransactionDetails
                AddHandler .LoadNewOR, AddressOf LoadNewOR
                AddHandler .LoadAddPayor, AddressOf LoadAddPayor
                AddHandler .LoadOR, AddressOf LoadOR
                ' -------------------------------------------------------------------------------
                AddHandler .CheckPrevPayType, AddressOf CheckPrevPaytype
                ' ------------------------------------------------------------------------------
                AddHandler .GetPayorDetails, AddressOf GetPayorDetails
                ' -------------------------------------------------------------------------------
                AddHandler .AddCashPayment, AddressOf AddCashPayment
                AddHandler .AddPaymentTypeDetails, AddressOf AddPaymentTypeDetails
                AddHandler .DeletePaymentTypeDetails, AddressOf DeletePaymentTypeDetails
                ' -------------------------------------------------------------------------------
                AddHandler .AddParticulars, AddressOf AddParticulars
                AddHandler .DeleteParticulars, AddressOf DeleteParticulars
                ' -------------------------------------------------------------------------------
                AddHandler .GetPaymentTypeDetails, AddressOf GetPaymentTypeDetails
                AddHandler .AddReceiptDetails, AddressOf AddReceiptDetails
                AddHandler .DeleteReceiptDetails, AddressOf DeleteReceiptDetails
                ' -------------------------------------------------------------------------------
                AddHandler .ComputeVatDetails, AddressOf ComputeVatDetails
                ' -------------------------------------------------------------------------------
                AddHandler .ProcessPaymentNonPremium, AddressOf ProcessPaymentNonPremium
                'AddHandler .SavePaymentNonPremium, AddressOf SavePaymentNonPremium
                AddHandler .ConfirmCancel, AddressOf ConfirmCancel
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                AddHandler .ConfirmPrint, AddressOf ConfirmPrint
                AddHandler .ConfirmDeletePaytyp, AddressOf ConfirmDeletePaytyp
                AddHandler .ConfirmDeleteORDetails, AddressOf ConfirmDeleteORDetails
                AddHandler .ConfirmDeleteParticulars, AddressOf ConfirmDeleteParticulars
                ' -------------------------------------------------------------------------------

                AddHandler .LoadBankDetails, AddressOf LoadBankDetails
                AddHandler .CheckParticulars, AddressOf CheckParticulars
                AddHandler .LoadBankList, AddressOf LoadBankList     'LoadCheckBank

                ' -------------------------------------------------------------------------------

                AddHandler .LoadActiveVaults, AddressOf LoadActiveVaults
                AddHandler .GetVaultDetails, AddressOf GetVaultDetails

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

                With vwPaymentNonPremiumRelated

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
                        ElseIf (.APRDate < DateAdd(DateInterval.Month, -1, .ORDate)) _
                            Or .APRDate > .ORDate Then
                            Call SetMessage(String.Concat("APR date should be within ", DateAdd(DateInterval.Month, -1, .ORDate).ToString("MM/dd/yyyy"), " to ", .ORDate.ToString("MM/dd/yyyy")), eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .APRAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter APR amount.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .APRAmount <> .ORGrossAmount Then
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
                With vwPaymentNonPremiumRelated
                    If .CashPaymentTag = True Then
                        If .ORCashAmount = cDataType.fDecimal.Empty Then
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

                With vwPaymentNonPremiumRelated

                    If .CheckPaymentTag = True Then

                        If .CheckNumber = cDataType.fLong.Empty Then
                            Call SetMessage("Please enter valid check number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CheckAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter valid check amount.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .CheckAmount > .ORGrossAmount Then
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

                With vwPaymentNonPremiumRelated

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidORDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidORDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidParticulars() As Boolean

            Try

                With vwPaymentNonPremiumRelated

                    If .ParticularsRemarks = cDataType.fString.Empty Then
                        Call SetMessage("Error in generating Particulars.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ParticularsAmount = cDataType.fDecimal.Empty Then
                        Call SetMessage("Error in generating Particulars Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ParticularsAmount + .ParticularsTotalAmount > .ORGrossAmount Then
                        Call SetMessage("Amount exceeds gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .lstParticulars.Count > 4 Then
                        Call SetMessage("Limit OR Particulars to five(5) lines.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ParticularsTotalAmount > .ORGrossAmount Then
                        Call SetMessage("Particulars amount will exceed gross amount..", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidParticulars : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidParticulars.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentTypeDetails(ByVal pPaymentType As String) As Boolean

            Try
                With vwPaymentNonPremiumRelated

                    If .PaymentTotalAmount = .ORGrossAmount Then
                        Call SetMessage("OR Details Amount already reached Gross Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .PaymentTotalAmount + .ORCashAmount + .CheckAmount > .ORGrossAmount Then
                        Call SetMessage("OR Details amount will exceed gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case pPaymentType
                        Case eReference.PayTypeCSH
                            Return IsValidCashDetails()
                        Case eReference.PayTypeCHQ
                            If .ORCashAmount > 0 Then
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

        Private Function IsValidReceiptDetails() As Boolean

            Try
                With vwPaymentNonPremiumRelated
                    If .ReceiptTransactionCode = cDataType.fString.Empty Then
                        Call SetMessage("Error in generating OR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptTransactionDesc = cDataType.fString.Empty Then
                        Call SetMessage("Error in generating OR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptTransactionType = cDataType.fString.Empty Then
                        Call SetMessage("Error in generating OR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptTransactionVat = cDataType.fString.Empty Then
                        Call SetMessage("Error in generating OR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptAmount = cDataType.fDecimal.Empty Then
                        Call SetMessage("Error in generating OR Detail Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .lstORDetails.Count > 4 Then
                        Call SetMessage("Limit OR Details to five(5) lines.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptAmount + .ReceiptTotalAmount > .ORGrossAmount Then
                        Call SetMessage("Amount exceeds gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidReceiptDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidReceiptDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPayor() As Boolean

            Try

                With vwPaymentNonPremiumRelated

                    If Not (.PayorID = 0) _
                    AndAlso Not .PayorIDTag Then
                        Call ClearScreenPayor(Me, EventArgs.Empty)
                        Call SetMessage("Invalid payor id.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .PayorID = 0 Then

                        Select Case .PayorType

                            Case String.Empty
                                Call SetMessage("Please select payor type.", eSystemMessage.Warning, True)
                                Return False

                            Case "C"

                                If .PayorName = String.Empty Then
                                    Call SetMessage("Please enter payor name.", eSystemMessage.Warning, True)
                                    Return False
                                End If

                            Case "F", "M"

                                If .PayorLastName = String.Empty _
                                OrElse .PayorFirstName = String.Empty Then
                                    Call SetMessage("Please enter payor name.", eSystemMessage.Warning, True)
                                    Return False
                                End If

                                If .PayorTitle = String.Empty Then
                                    Call SetMessage("Please select payor title.", eSystemMessage.Warning, True)
                                    Return False
                                Else
                                    Select Case .PayorTitle
                                        Case "MRS.", "MS."
                                            If .PayorType = "M" Then
                                                Call SetMessage("Invalid payor title. Payor type is male.", eSystemMessage.Warning, True)
                                                Return False
                                            End If
                                        Case "MR."
                                            If .PayorType = "F" Then
                                                Call SetMessage("Invalid payor title. Payor type is female.", eSystemMessage.Warning, True)
                                                Return False
                                            End If
                                    End Select
                                End If

                                Select Case .PayorDateOfBirth
                                    Case cDataType.fDate.Empty
                                        Call SetMessage("Please enter payor date of birth.", eSystemMessage.Warning, True)
                                        Return False
                                    Case cDataType.fDate.Invalid
                                        Call SetMessage("Invalid payor date of birth.", eSystemMessage.Warning, True)
                                        Return False
                                    Case Is < cDataType.fDate.Minimum
                                        Call SetMessage("Payor date of birth precedes minimum date.", eSystemMessage.Warning, True)
                                        Return False
                                    Case Is >= cDataType.fDate.Current
                                        Call SetMessage("Payor date of birth exceeds current date.", eSystemMessage.Warning, True)
                                        Return False
                                End Select

                                If .PayorPlaceOfBirth = String.Empty Then
                                    Call SetMessage("Please enter payor place of birth.", eSystemMessage.Warning, True)
                                    Return False
                                End If

                        End Select

                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPayor : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidAddPayor() As Boolean

            Try

                With vwPaymentNonPremiumRelated

                    Select Case .PayorAddType

                        Case String.Empty
                            Call SetMessage("Please select payor type.", eSystemMessage.Warning, True)
                            Return False

                        Case "C"

                            If .PayorAddName = String.Empty Then
                                Call SetMessage("Please enter payor name.", eSystemMessage.Warning, True)
                                Return False
                            End If

                        Case "F", "M"

                            If .PayorAddLastName = String.Empty _
                            OrElse .PayorAddFirstName = String.Empty Then
                                Call SetMessage("Please enter payor name.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            If .PayorAddTitle = String.Empty Then
                                Call SetMessage("Please select payor title.", eSystemMessage.Warning, True)
                                Return False
                            Else
                                Select Case .PayorAddTitle
                                    Case "MRS.", "MS."
                                        If .PayorAddType = "M" Then
                                            Call SetMessage("Invalid payor title. Payor type is male.", eSystemMessage.Warning, True)
                                            Return False
                                        End If
                                    Case "MR."
                                        If .PayorAddType = "F" Then
                                            Call SetMessage("Invalid payor title. Payor type is female.", eSystemMessage.Warning, True)
                                            Return False
                                        End If
                                End Select
                            End If

                            Select Case .PayorAddDateOfBirth
                                Case cDataType.fDate.Empty
                                    Call SetMessage("Please enter payor date of birth.", eSystemMessage.Warning, True)
                                    Return False
                                Case cDataType.fDate.Invalid
                                    Call SetMessage("Invalid payor date of birth.", eSystemMessage.Warning, True)
                                    Return False
                                Case Is < cDataType.fDate.Minimum
                                    Call SetMessage("Payor date of birth precedes minimum date.", eSystemMessage.Warning, True)
                                    Return False
                                Case Is >= cDataType.fDate.Current
                                    Call SetMessage("Payor date of birth exceeds current date.", eSystemMessage.Warning, True)
                                    Return False
                            End Select

                            If .PayorAddPlaceOfBirth = String.Empty Then
                                Call SetMessage("Please enter payor place of birth.", eSystemMessage.Warning, True)
                                Return False
                            End If

                    End Select

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidAddPayor : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidAddPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentDetails() As Boolean

            Try

                With vwPaymentNonPremiumRelated

                    'If .ORNumber = cDataType.fLong.Empty Then
                    '    Call SetMessage("Error in generating OR Number.", eSystemMessage.Warning, True)
                    '    Return False
                    'End If

                    If .ORDate = cDataType.fDate.Empty Then
                        Call SetMessage("Error in generating OR Date.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .TransactionType = cDataType.fString.Empty Then
                        Call SetMessage("Please select transaction type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ORGrossAmount = cDataType.fDecimal.Empty Then
                        Call SetMessage("Please enter gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ORPaymentType = cDataType.fString.Empty Then
                        Call SetMessage("Please select payment type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ORCurrency = cDataType.fString.Empty Then
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

        Private Function IsValidColumbary() As Boolean

            Try

                With vwPaymentNonPremiumRelated

                    If .ColumbariumTag Then

                        If .Vault = cDataType.fInteger.Empty Then
                            Call SetMessage("Please select Columbary Vault.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .Level = cDataType.fString.Empty Then
                            Call SetMessage("Invalid Columbary Details.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .Block = cDataType.fString.Empty Then
                            Call SetMessage("Invalid Columbary Details.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .Column = cDataType.fString.Empty Then
                            Call SetMessage("Invalid Columbary Details.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .ColumbaryInitialFee Then
                            If (.ColPayrEmployee = False) And (.ColPayrRegular = False) Then
                                Call SetMessage("Please Select Columbary Payor Type.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            If .ColPayrRegular And .ReservationAmt <> 1000 Then
                                Call SetMessage("Reservation Amount is P1000.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            If .ColPayrEmployee And .ReservationAmt <> 0 Then
                                Call SetMessage("Reservation Amount is waived for employees.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            'If .VaultVAT <= 0 Then
                            '    Call SetMessage("Please input VAT.", eSystemMessage.Warning, True)
                            '    Return False
                            'End If

                        Else
                            If (.ColPayrEmployee Or .ColPayrRegular) And (.ReservationAmt > 0 Or .VaultVAT > 0) Then
                                Call SetMessage("Invalid Columbary Details.", eSystemMessage.Warning, True)
                                Return False
                            End If
                        End If

                        'If .ColumbaryInitialFee Then
                        '    If .ColPayrEmployee Then

                        '    ElseIf .ColPayrRegular Then

                        '    End If
                        'Else
                        '    If .ColPayrEmployee Then

                        '    End If
                        '    .ColPayrRegular = False
                        '    .ReservationAmt = 0

                        'End If

                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidColumbary : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidColumbary.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidOtherDetails() As Boolean

            Try

                With vwPaymentNonPremiumRelated

                    If .PayorName = cDataType.fString.Empty Then
                        Call SetMessage("Please input Payor Name.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .DepositoryAccount = cDataType.fString.Empty Or .DepositoryAccount = "-- SELECT ITEM --" Then
                        Call SetMessage("Please input Depository Account.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .GLCode = cDataType.fString.Empty Then
                        Call SetMessage("Please input GL Code.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidOtherDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidORDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentNonPremiumRelated() As Boolean

            Try

                If IsValidForProcessing() AndAlso _
                    IsValidTotals() AndAlso _
                    IsValidPaymentDetails() AndAlso _
                    IsValidAPRDetails() AndAlso _
                    IsValidVATComputation() AndAlso _
                    IsValidColumbary() AndAlso _
                    IsValidOtherDetails() _
                Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPaymentNonPremiumRelated : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPaymentNonPremiumRelated.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidForProcessing() As Boolean
            Try
                With vwPaymentNonPremiumRelated
                    Dim objBll As New BLL.OCS.Reference.BOprDetails

                    If Not .DocSaveState = eReference.DocSaveState.Cancel OrElse Not objBll.IsOprProcessed(.ORNumber, .ORDate) Then
                        Return True
                    Else
                        Call SetMessage(String.Concat("Non-Premium Payment.<br /><br />", "Cancellation not allowed!<br />Payment was already processed, please reverse via Debit/Credit Memo.<br /><br />"), eSystemMessage.Information, True)
                        Return False
                    End If
                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidForProcessing : ", ex.Message))
            End Try
        End Function

        Private Function IsValidTotals() As Boolean
            Try
                With vwPaymentNonPremiumRelated
                    If .ParticularsTotalAmount = .ORGrossAmount AndAlso _
                        .PaymentTotalAmount = .ORGrossAmount AndAlso _
                        .ReceiptTotalAmount = .ORGrossAmount AndAlso _
                        .VATAmountNetWTax = .ORGrossAmount Then

                        If .ColumbaryInitialFee Then
                            If (.DiscountRate > .ORGrossAmount Or _
                           .VaultVAT > .ORGrossAmount Or _
                           (.DiscountRate + .VaultVAT >= .ORGrossAmount)) Then
                                'Call SetMessage(String.Concat("Columbary Discount Rate or VAT must be a portion of Gross Amount.<br /><br />", "Cannot Save Transaction.<br /><br />"), eSystemMessage.Critical, True)
                                Call SetMessage(String.Concat("Non-Premium Payment.<br /><br />", "Some payment totals do not match Gross Amount!<br /><br />"), eSystemMessage.Information, True)
                                Return False
                            Else
                                Return True
                            End If
                        Else
                            Return True
                        End If

                    Else
                        'Call SetMessage(String.Concat("Payment Totals must match Gross Amount.<br /><br />", "Cannot Save Transaction.<br /><br />"), eSystemMessage.Critical, True)
                        Call SetMessage(String.Concat("Non-Premium Payment.<br /><br />", "Some payment totals do not match Gross Amount!<br /><br />"), eSystemMessage.Information, True)
                        Return False
                    End If

                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidTotals : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidTotals.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function

        Private Function IsValidLoadViewOR() As Boolean

            Try

                With vwPaymentNonPremiumRelated
                    If .ViewOrFrom > .ViewOrTo Then
                        Call SetMessage("View Date From exceeds Date To.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case .ViewOrFrom
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

                    Select Case .ViewOrTo
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
                Throw New Exception(String.Concat("IsValidLoadViewOR : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidLoadViewOR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function



        Private Function IsValidVATComputation() As Boolean

            Try

                With vwPaymentNonPremiumRelated

                    If .VATAmountNetWTax = cDataType.fDecimal.Empty Then
                        Call SetMessage("Invalid VAT computation.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .VATAmountNetWTax > .ORGrossAmount Then
                        Call SetMessage("VAT Net Amount exceeds gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidVATComputation : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidVATComputation.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function CheckReceiptDetails(ByVal pAction As String, ByVal pTrnxCode As String, ByVal pTrnxTyp As String, ByVal pTrnxDesc As String) As Boolean

            Dim intRecCnt As Integer = 0

            Try
                With vwPaymentNonPremiumRelated
                    For Each item As cORDetail In .lstORDetails
                        If item.TrnxCode = pTrnxCode _
                            And item.TrnxDesc = pTrnxDesc _
                            And item.ActType = pTrnxTyp Then
                            intRecCnt = intRecCnt + 1
                        End If
                    Next
                    If pAction = "ADD" And intRecCnt >= 1 Then Return True
                    If pAction = "EDIT" And intRecCnt >= 2 Then Return True
                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("CheckReceiptDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckReceiptDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function CheckPaymentIfExisting(ByVal pAction As String, ByVal pPayType As String, ByVal pReference As String, ByVal pAmount As Decimal) As Boolean

            Dim intRecCnt As Integer = 0

            Try
                With vwPaymentNonPremiumRelated
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

        Private Sub ClearScreenPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .PayorID = cDataType.fLong.Empty
                    .PayorIDTag = False
                    .PayorType = cDataType.fString.Empty
                    .PayorName = cDataType.fString.Empty
                    .PayorLastName = cDataType.fString.Empty
                    .PayorFirstName = cDataType.fString.Empty
                    .PayorMiddleName = cDataType.fString.Empty
                    .PayorSuffix = cDataType.fString.Empty
                    .PayorDateOfBirth = cDataType.fDate.Empty
                End With
            Catch ex As Exception
              Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenAddPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .PayorAddType = cDataType.fString.Empty
                    .PayorAddName = cDataType.fString.Empty
                    .PayorAddLastName = cDataType.fString.Empty
                    .PayorAddFirstName = cDataType.fString.Empty
                    .PayorAddMiddleName = cDataType.fString.Empty
                    .PayorAddSuffix = cDataType.fString.Empty
                    .PayorAddDateOfBirth = cDataType.fDate.Empty
                    .PayorAddTitle = cDataType.fString.Empty
                    .PayorAddPlaceOfBirth = cDataType.fString.Empty
                End With
            Catch ex As Exception
              Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAddPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenPayorType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .PayorName = IIf(.PayorType = "C", .PayorName, cDataType.fString.Empty)
                    .PayorLastName = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorLastName)
                    .PayorFirstName = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorFirstName)
                    .PayorMiddleName = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorMiddleName)
                    .PayorSuffix = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorSuffix)
                    .PayorDateOfBirth = IIf(.PayorType = "C", cDataType.fDate.Empty, .PayorDateOfBirth)
                    .PayorAddTitle = IIf(.PayorType = "C", cDataType.fDate.Empty, .PayorTitle)
                    .PayorAddPlaceOfBirth = IIf(.PayorType = "C", cDataType.fDate.Empty, .PayorPlaceOfBirth)

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPayorType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenAPRDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
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
                With vwPaymentNonPremiumRelated
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

                Call ClearScreenPaymentDetails(sender, e)
                Call ClearScreenOtherDetails(sender, e)
                Call ClearScreenReceiptDetails(sender, e)
                Call ClearScreenAPRDetails(sender, e)
                Call ClearScreenPaymentTypeDetails(sender, e)
                Call ClearScreenVATComputation(sender, e)
                Call ClearScreenColumbarium(sender, e)
                Call ClearScreenParticulars(sender, e)
                Call ClearScreenAPRDetails(sender, e)

                With vwPaymentNonPremiumRelated
                    .lstORDetails = New List(Of cORDetail)
                    .lstPaymentTypeDetails = New List(Of cPaymentType)

                    .PaymentTypeTag = cDataType.fBoolean.Empty
                    .CashPaymentTag = cDataType.fBoolean.Empty
                    .CheckPaymentTag = cDataType.fBoolean.Empty
                    .ORDetailTag = cDataType.fBoolean.Empty
                    .ORVatTag = cDataType.fBoolean.Empty
                    .OtherDetailsTag = cDataType.fBoolean.Empty ' IBP 1/20
                    .ColumbariumTag = cDataType.fBoolean.Empty ' IBP 1/20
                    .ParticularsTag = cDataType.fBoolean.Empty ' IBP 2/02
                    '---------------'
                    .CashTotalAmount = cDataType.fDecimal.Empty
                    .CheckTotalAmount = cDataType.fDecimal.Empty

                End With

            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenOtherDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentNonPremiumRelated
                    .PayorID = cDataType.fLong.Empty
                    '.DepositoryAccount = cDataType.fString.Empty
                    .GLCode = cDataType.fString.Empty
                    .PayorName = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenOtherDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenReceiptDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .ReceiptIndex = cDataType.fInteger.Empty
                    .ReceiptDetailID = cDataType.fString.Empty
                    .ReceiptTransactionCode = cDataType.fLong.Empty
                    .ReceiptTransactionType = cDataType.fString.Empty
                    .ReceiptTransactionDesc = cDataType.fString.Empty
                    .ReceiptAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenReceiptDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenPaymentDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .ORNumber = cDataType.fLong.Empty
                    .ORDate = cDataType.fDate.Empty
                    .TransactionType = cDataType.fString.Empty
                    .ORPaymentType = cDataType.fString.Empty
                    .ORGrossAmount = cDataType.fDecimal.Empty
                    .ORCurrency = cDataType.fString.Empty
                    .WithAPR = cDataType.fBoolean.Empty
                    .ORRemarks = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPaymentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenCashDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .ORCashAmount = cDataType.fDecimal.Empty

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

        Private Sub ClearScreenVATComputation(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .VATableCollection = cDataType.fDecimal.Empty
                    .NonVATCollection = cDataType.fDecimal.Empty
                    .VATExemptCollection = cDataType.fDecimal.Empty
                    .VATAmount = cDataType.fDecimal.Empty
                    .VATTotalCollection = cDataType.fDecimal.Empty
                    .VATWithholdingTax = cDataType.fDecimal.Empty
                    .VATAmountNetWTax = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
              Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenVATComputation.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenViewOR(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated
                    .ViewOrFrom = cDataType.fDate.Empty
                    .ViewOrTo = cDataType.fDate.Empty
                    .ViewOrDocNumber = cDataType.fLong.Empty
                    .ViewOrPayorName = cDataType.fString.Empty
                    .dtViewOR = Nothing
                End With
            Catch ex As Exception
             Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenViewOPR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenColumbarium(ByVal sender As Object, ByVal e As EventArgs)
            Try

                With vwColumbarium
                    .Vault = cDataType.fInteger.Empty
                    .Level = cDataType.fString.Empty
                    .Block = cDataType.fString.Empty
                    .Column = cDataType.fString.Empty
                    .Product = cDataType.fString.Empty
                    .LotListPrice = cDataType.fDecimal.Empty
                    .ReservationAmt = cDataType.fDecimal.Empty
                    .DiscountRate = cDataType.fDecimal.Empty
                    .VaultVAT = cDataType.fDecimal.Empty
                    With vwPaymentNonPremiumRelated
                        .ColumbaryInitialFee = False
                        .ColPayrRegular = False
                        .ColPayrEmployee = False
                    End With
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenColumbarium.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenParticulars(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentNonPremiumRelated
                    .ParticularsAmount = cDataType.fDecimal.Empty
                    .ParticularsRemarks = cDataType.fString.Empty
                End With
            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenParticulars.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearTotals(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentNonPremiumRelated
                    .CashTotalAmount = cDataType.fDecimal.Empty
                    .CheckTotalAmount = cDataType.fDecimal.Empty
                    .ParticularsTotalAmount = cDataType.fDecimal.Empty
                    .ReceiptTotalAmount = cDataType.fDecimal.Empty
                    .VATTotalCollection = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearTotals.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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

        Private Sub GenerateReport(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwReport
                    .IsSuccessful = False
                    Select Case .ReportType
                        Case eReport.Receipt
                            .RptParamString = String.Concat(vwPaymentNonPremiumRelated.ORNumber, "|", Not .IsPreview, "|", .SiteCode, "|", .UserId)
                            If Not .IsPreview Then SetMessage(String.Concat("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!"), eSystemMessage.Information, True)
                    End Select
                    .IsSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GenerateReport.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

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
                Throw New Exception(String.Concat("GetTrnCod : ", ex.Message))
            End Try
        End Function

        Private Sub GetPayorDetails(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLLPRSMAS As New bllPerson.BPrsMas

            Try
                With objBLLPRSMAS
                    .GetPrsMas(vwPaymentNonPremiumRelated.PayorID)
                    If .IsRecordExist Then
                        vwPaymentNonPremiumRelated.PayorIDTag = True
                        vwPaymentNonPremiumRelated.PayorType = cDataType.fString.IfNull(.PrsSex)
                        vwPaymentNonPremiumRelated.PayorName = cDataType.fString.IfNull(.PrsNme)
                        vwPaymentNonPremiumRelated.PayorLastName = cDataType.fString.IfNull(.PrsLnm)
                        vwPaymentNonPremiumRelated.PayorFirstName = cDataType.fString.IfNull(.PrsFnm)
                        vwPaymentNonPremiumRelated.PayorMiddleName = cDataType.fString.IfNull(.PrsMnm)
                        vwPaymentNonPremiumRelated.PayorSuffix = cDataType.fString.IfNull(.PrsNsf)
                        vwPaymentNonPremiumRelated.PayorDateOfBirth = cDataType.fDate.IfNull(.PrsDOB)
                        vwPaymentNonPremiumRelated.PayorTitle = cDataType.fString.IfNull(.PrsTit)
                        vwPaymentNonPremiumRelated.PayorPlaceOfBirth = cDataType.fString.IfNull(.PrsPlc)
                    End If
                End With
            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPayorDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GetPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim cptLocal As New cPaymentType

            Try
                With vwPaymentNonPremiumRelated
                    Dim lstRowLocal As List(Of cPaymentType) = (From l In .lstPaymentTypeDetails
                               Where l.PaymentType = .ORPaymentType
                               Select l).ToList


                    For Each cptLocal In lstRowLocal
                        Select Case .ORPaymentType
                            Case eReference.PayTypeCSH
                                .ORCashAmount = cptLocal.Amount
                            Case eReference.PayTypeCHQ
                                .CheckAmount = cptLocal.Amount
                                .CheckNumber = cptLocal.CheckNumber
                                .CheckBankName = cptLocal.Bank
                                .CheckBankBranch = cptLocal.Branch
                        End Select
                    Next
                End With
            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPaymentTypeDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadPaymentType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentNonPremiumRelated.dtPaymentType = objBLL.GetRefPAYTYP_ROP
            Catch ex As Exception
             Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPaymentType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPersonType(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BPrsRef

            Try
                vwPaymentNonPremiumRelated.dtPersonType = objBLL.GetRefPrsRefPrsTyp
            Catch ex As Exception
              Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPersonType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPersonTitle(ByVal sender As Object, ByVal e As EventArgs)

            'Dim objBLL As New bllReference.BParamRef

            'Try
            '    vwPaymentNonPremiumRelated.dtPersonTitle = objBLL.GetRefPRSTIT
            'Catch ex As Exception
            '    Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPersonTitle.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            'End Try

        End Sub

        Private Sub CheckPrevPaytype(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentNonPremiumRelated

                    Select Case .lstPaymentTypeDetails.Count
                        Case Is > 0
                            If .PrevPayType = .ORPaymentType Then
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

        Private Sub CheckParticulars(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentNonPremiumRelated
                    If Not IsValidParticulars() Then
                        .IsParticularsValid = False
                    Else
                        .IsParticularsValid = True
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckParticulars.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadSourceSite(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BSiteDetails
                vwPaymentNonPremiumRelated.dtSourceSite = objBLL.LoadSourceSite()
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSourceSite.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadCurrency(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BCurRef
                vwPaymentNonPremiumRelated.dtCurrency = objBLL.GetRefCurRefList
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadCurrency.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadTransactionType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentNonPremiumRelated.dtTransactionType = objBLL.GetRefTRNTYP_ROP()
            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadTransactionType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadReceiptTransaction(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BTrnRef
                With vwPaymentNonPremiumRelated
                    Dim trantyp As Long = 0

                    If (.TransactionType <> String.Empty) Then
                        trantyp = Convert.ToInt64(.TransactionType)
                    End If

                    .dtReceiptTransaction = objBLL.GetRefTrnRefList(.ORPaymentType, trantyp, 0, .DocType)

                End With
            Catch ex As Exception
              Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadReceiptTransaction.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GetReceiptTransactionDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBll As New bllReference.BTrnRef
                With vwPaymentNonPremiumRelated
                    objBll.GetReceiptTransactionDetails(.ReceiptTransactionCode, eReference.DocTypeOR)
                    .ReceiptTransactionDesc = objBll.Coldes
                    .ReceiptTransactionType = objBll.Pctref
                    .ReceiptTransactionVat = objBll.Vatable
                End With
            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetReceiptTransactionDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadNewOR(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BOrDetails
                With vwPaymentNonPremiumRelated
                    .IsSuccessful = False

                    objBLL.LoadNewOR(vwPaymentNonPremiumRelated.SiteCode, eReference.ReceiptType.CI, vwPaymentNonPremiumRelated.UserID)

                    .IsSuccessful = True
                    .ORNumber = 0 'objBLL.ORNumber
                    .ORDate = objBLL.ORDate.ToShortDateString
                End With

            Catch ex As ArgumentException
                Call SetMessage(String.Concat("New OR is not Allowed!<br /><br />", ex.Message), eSystemMessage.Information, True)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadNewOR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadViewOR(ByVal sender As Object, ByVal e As EventArgs)
            Try
                'Dim objBLL As New bllReference.BOrDetails
                'With vwPaymentNonPremiumRelated
                '    vwPaymentNonPremiumRelated.dtViewOR = objBLL.LoadViewOR(.SiteCode, .ViewOrFrom, .ViewOrTo)
                'End With

                Dim objBLL As New bllReference.BOrDetails
                Dim dtLocal As New DataTable

                With vwPaymentNonPremiumRelated
                    If IsValidLoadViewOR() Then
                        'If .ViewOrDocNumber = 0 Then
                        '    dtLocal = objBLL.LoadViewor(.SiteCode, .ViewOrFrom, .ViewOrTo)
                        'Else
                        '    dtLocal = objBLL.LoadViewOr(.SiteCode, .ViewOrDocNumber, 0)
                        'End If

                        If .ViewOrDocNumber > 0 Then
                            dtLocal = objBLL.LoadViewOr(.SiteCode, .ViewOrDocNumber)
                        ElseIf .ViewOrPayorName <> String.Empty Then
                            dtLocal = objBLL.LoadViewOr(.SiteCode, .ViewOrPayorName, 2)
                        Else
                            dtLocal = objBLL.LoadViewOr(.SiteCode, .ViewOrFrom, .ViewOrTo)
                        End If

                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(String.Concat("Load View ORs.<br /><br />", "No OR found!"), eSystemMessage.Information, True)
                        End If

                        .dtViewOR = dtLocal
                    End If
                End With

            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewOR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadAddPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentNonPremiumRelated

                    .IsSuccessful = False
                    If IsValidAddPayor() Then

                        .PayorType = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddType)
                        .PayorLastName = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddLastName)
                        .PayorFirstName = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddFirstName)
                        .PayorMiddleName = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddMiddleName)
                        .PayorDateOfBirth = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddDateOfBirth)
                        .PayorSuffix = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddSuffix)
                        .PayorTitle = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddTitle)
                        .PayorPlaceOfBirth = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddPlaceOfBirth)
                        .PayorName = IIf(.PayorAddType = "C", .PayorAddName, .PayorName)
                        .PayorTin = IIf(.PayorAddType = "C", .PayorAddTin, .PayorTin)
                        .PayorAddress = IIf(.PayorAddType = "C", .PayorAddAddress, .PayorAddress)

                        .PayorIDTag = True

                        .IsSuccessful = True
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadAddPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadBankDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BBankDetails

                With vwPaymentNonPremiumRelated

                    If (.SourceSite = cDataType.fString.Empty) Then
                        .dtBankDetails = objBLL.LoadBankDetails(.SiteCode) 'SiteCode
                    Else
                        .dtBankDetails = objBLL.LoadBankDetails(.SourceSite) 'SiteCode
                    End If

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBankDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadBankList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BBankDetails

                vwPaymentNonPremiumRelated.dtBankList = objBLL.LoadBankList() 'SiteCode      'LoadCheckBank      'vwPaymentNonPremiumRelated.ORCurrency

            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBankList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadActiveVaults(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBll As New bllReference.BColumbary

                vwColumbarium.dtActiveVaults = objBll.LoadActiveVaults
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadActiveVaults.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub GetVaultDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBll As New bllReference.BColumbary
                Dim dtLocal As DataTable

                With vwPaymentNonPremiumRelated

                    dtLocal = objBll.GetVaultDetails(.Vault)


                    For Each dr As DataRow In dtLocal.Rows

                        dtLocal.Columns(0).ColumnName.ToString()    '"ContractNo"
                        dtLocal.Columns(1).ColumnName.ToString()    '"Buyer"
                        dtLocal.Columns(2).ColumnName.ToString()    '"Product"
                        dtLocal.Columns(3).ColumnName.ToString()    '"EffDate"
                        dtLocal.Columns(4).ColumnName.ToString()    '"DueDate"
                        dtLocal.Columns(5).ColumnName.ToString()    '"PayYear"
                        dtLocal.Columns(6).ColumnName.ToString()    '"Block"
                        dtLocal.Columns(7).ColumnName.ToString()    '"Level"
                        dtLocal.Columns(8).ColumnName.ToString()    '"Column"
                        dtLocal.Columns(9).ColumnName.ToString()    '"VaultNumber"
                        dtLocal.Columns(10).ColumnName.ToString()   '"VaultStatus"
                        dtLocal.Columns(11).ColumnName.ToString()   '"MonthyInst"
                        dtLocal.Columns(12).ColumnName.ToString()   '"Balance"
                        dtLocal.Columns(13).ColumnName.ToString()   'LotListPrice


                        '.Vault = cDataType.fInteger.IfNull(dr.Item(9))
                        .Product = cDataType.fString.IfNull(dr.Item(2))
                        .Level = cDataType.fString.IfNull(dr.Item(7))
                        .Block = cDataType.fString.IfNull(dr.Item(6))
                        .Column = cDataType.fString.IfNull(dr.Item(8))
                        .LotListPrice = cDataType.fDecimal.IfNull(dr.Item(13))


                    Next
                End With


            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetVaultDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub


        ' -------------------------------------------------------------------------------

        'Private Sub SavePaymentNonPremium(ByVal sender As Object, ByVal e As EventArgs)
        '    Dim objSiteORHeader As bllWorking.BSiteORHeader
        '    Dim objSiteORVAT As bllWorking.BSiteORVAT
        '    Dim objSitePAMaster As bllWorking.BSitePAMaster
        '    Dim lstSiteORDtl As New List(Of bllWorking.BSiteORDtl)
        '    Dim lstSiteORAPRPay As New List(Of bllWorking.BSiteORAPRPay)
        '    Dim lstSiteORChkPay As New List(Of bllWorking.BSiteORChkPay)
        '    Dim lstSiteTmpTrn As New List(Of bllWorking.BSiteTmpTrn)


        'End Sub

        Private Sub ProcessPaymentNonPremium(ByVal sender As Object, ByVal e As EventArgs)

            '---Source Site Rule: If source site is not equal to default site --> messagebox

            ''Objects
            Dim objSiteORHeader As New bllWorking.BSiteORHeader     'Save Header'
            Dim objSiteORVAT As New bllWorking.BSiteORVAT           'Save VAT'
            Dim objSiteORPart As New bllWorking.BSiteORPart         'Save Particulars'
            Dim objSiteORDtl As New bllWorking.BSiteORDtl           'Save OR Detail'
            Dim objSiteORAPRPy As New bllWorking.BSiteORAPRPay      'Save APR'
            Dim objSiteORChkPy As New bllWorking.BSiteORChkPay      ''''Save CheckPayment''''
            Dim objSiteTmpTrn As New bllWorking.BSiteTmpTrn         'Save TmpTrn'
            Dim objSiteColDtl As New bllWorking.BSiteORColDtl       'Save Columbary - imee 03/13/17'
            Dim objSiteRcptCtr As New bllWorking.BReceiptCounter
            'Dim objPrsmas As New bllPerson.BPrsMas


            ''Lists
            Dim lstSiteORDtl As New List(Of bllWorking.BSiteORDtl)
            Dim lstSiteORAPRPy As New List(Of bllWorking.BSiteORAPRPay)
            Dim lstSiteORChkPy As New List(Of bllWorking.BSiteORChkPay)
            Dim lstSiteORPart As New List(Of bllWorking.BSiteORPart)
            Dim lstSiteTmpTrn As New List(Of bllWorking.BSiteTmpTrn)
            Dim lstSiteORColDtl As New List(Of bllWorking.BSiteORColDtl) 'imee 03/13/17 - columbary saving
            'Dim lstPrsmas As New List(Of bllPerson.BPrsMas)
            '----
            Dim lstIdSiteORDtl As New List(Of Long)
            Dim lstIdSiteORAPRPy As New List(Of Long)
            Dim lstIdSiteORChkPy As New List(Of Long)
            Dim lstIdSiteTmpTrn As New List(Of Long)
            Dim lstIdSiteORColDtl As New List(Of Long)
            Dim lstIdSiteORPart As New List(Of Long)

            Dim lstForDeletion As New List(Of Object)

            Dim lstIdCounter As Integer = 0
            Dim mDocSaveState As String = String.Empty


            Try

                vwPaymentNonPremiumRelated.IsSuccessful = False

                'If IsValidPaymentNonPremiumRelated() Then

                'Region Validation:
                With vwPaymentNonPremiumRelated

                    If IsValidPaymentNonPremiumRelated() Then
                        With vwPaymentNonPremiumRelated
                            mDocSaveState = .DocSaveState
                            Select Case mDocSaveState
                                Case eReference.DocSaveState.Edit, eReference.DocSaveState.Cancel, eReference.DocSaveState.Print
                                    Dim dtSiteTmpTrn = objSiteTmpTrn.GetTmpTrnDt(.ORNumber, eReference.DocTypeOR, .UserID)
                                    Dim dtSiteORDtl = objSiteORDtl.GetORDtlDt(.ORNumber, .UserID)
                                    Dim dtSiteORChkPy = objSiteORChkPy.GetORChkPyDt(.ORNumber, .UserID)
                                    'Dim dtSiteORAPRPay = objSiteORAPRPy.GetORAPRPay(.ORNumber)
                                    Dim dtSiteORPart = objSiteORPart.GetSiteORPart(.ORNumber, .UserID)
                                    Dim dtSiteORCol = objSiteColDtl.GetORColDtl(.ORNumber, .UserID)

                                    objSiteORVAT.GetSiteORVAT(.ORNumber, .UserID)
                                    objSiteORHeader.GetORHeader(.ORNumber, .UserID)
                                    objSiteORAPRPy.GetORAPRPay(.ORNumber, .UserID)
                                    'objSitePAMaster.GetSitePAMAster(.ORNumber)

                                    If objSiteORAPRPy.Id > 0 Then
                                        lstForDeletion.Add(New bllWorking.BSiteORAPRPay() With {.Id = objSiteORAPRPy.Id, .ORNmbr = objSiteORAPRPy.ORNmbr, .StatusId = objSiteORAPRPy.StatusId, .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                    End If

                                    'For Each dr As DataRow In dtSiteORAPRPay.Rows
                                    '    If mDocSaveState = eReference.DocSaveState.Edit or mDocSaveState = eReference.DocSaveState.print Then
                                    '        lstIdSiteORAPRPy.Add(dr.Item("id"))
                                    '        lstForDeletion.Add(New bllWorking.BSiteORAPRPay() With {.Id = dr.Item("id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                    '    Else
                                    '        lstSiteORAPRPy.Add(New bllWorking.BSiteORAPRPay() With {.Id = dr.Item("id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                    '    End If
                                    'Next

                                    For Each dr As DataRow In dtSiteTmpTrn.Rows
                                        If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                            lstIdSiteTmpTrn.Add(dr.Item("id"))
                                            lstForDeletion.Add(New bllWorking.BSiteTmpTrn() With {.Id = dr.Item("id"), .RcptNo = dr.Item("rcptno"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        Else
                                            lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn() With {.Id = dr.Item("id"), .RcptNo = dr.Item("rcptno"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        End If
                                    Next

                                    For Each dr As DataRow In dtSiteORDtl.Rows
                                        If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                            lstIdSiteORDtl.Add(dr.Item("id"))
                                            lstForDeletion.Add(New bllWorking.BSiteORDtl() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        Else
                                            lstSiteORDtl.Add(New bllWorking.BSiteORDtl() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        End If
                                    Next

                                    For Each dr As DataRow In dtSiteORCol.Rows
                                        If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                            lstIdSiteORColDtl.Add(dr.Item("id"))
                                            lstForDeletion.Add(New bllWorking.BSiteORColDtl() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        Else
                                            lstSiteORColDtl.Add(New bllWorking.BSiteORColDtl() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        End If
                                    Next

                                    For Each dr As DataRow In dtSiteORPart.Rows
                                        If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                            lstIdSiteORPart.Add(dr.Item("id"))
                                            lstForDeletion.Add(New bllWorking.BSiteORPart() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        Else
                                            lstSiteORPart.Add(New bllWorking.BSiteORPart() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        End If
                                    Next

                                    For Each dr As DataRow In dtSiteORChkPy.Rows
                                        If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                            lstIdSiteORChkPy.Add(dr.Item("id"))
                                            lstForDeletion.Add(New bllWorking.BSiteORChkPay() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        Else
                                            lstSiteORChkPy.Add(New bllWorking.BSiteORChkPay() With {.Id = dr.Item("id"), .ORNmbr = dr.Item("or_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentNonPremiumRelated.UserID})
                                        End If
                                    Next

                            End Select

                            Select Case mDocSaveState

                                Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit, eReference.DocSaveState.Print

                                    objSiteORHeader = New bllWorking.BSiteORHeader(objSiteORHeader.Id, .ORNumber, String.Empty, .ORDate, .ORRemarks, .ORGrossAmount, .CheckTotalAmount, .ORPaymentType, .ORCurrency, .SiteCode, .PayorID, .PayorName, .DepositoryAccount, .GLCode, "", "", objSiteORHeader.CancelFlag, objSiteORHeader.PrtFlag, .UserID, .SiteCode, IIf(objSiteORHeader.StatusId > 0, objSiteORHeader.StatusId, eReference.Status.Active), .UserID, Now, .UserID, Now)

                                    objSiteORVAT = New bllWorking.BSiteORVAT(objSiteORVAT.Id, .ORNumber, .ORGrossAmount, .VATableCollection, .VATExemptCollection, .VATAmount, .VATWithholdingTax, .VATAmountNetWTax, eReference.Status.Active, .UserID, Now, .UserID, Now, .NonVATCollection)

                                    For Each item In .lstORDetails
                                        lstSiteORDtl.Add(New bllWorking.BSiteORDtl(GetIdFromList(lstIdSiteORDtl, lstSiteORDtl.Count), .ORNumber, item.TrnxCode, item.ActType, item.TrnxDesc, item.Amount, lstSiteORDtl.Count + 1, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                    Next

                                    For Each item In .lstPaymentTypeDetails
                                        Select Case item.PaymentType
                                            Case eReference.PayTypeCSH
                                                lstIdCounter -= 1
                                            Case eReference.PayTypeCHQ
                                                lstSiteORChkPy.Add(New bllWorking.BSiteORChkPay(GetIdFromList(lstIdSiteORChkPy, lstSiteORChkPy.Count), .ORNumber, item.CheckNumber, item.Bank, item.Branch, item.Amount, lstSiteORChkPy.Count + 1, 0, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        End Select
                                    Next
                                    lstSiteORAPRPy.Add(New bllWorking.BSiteORAPRPay(objSiteORAPRPy.Id, .ORNumber, .APRNumber, .APRDate, .APRAmount, 1, eReference.Status.Active, .UserID, Now, .UserID, Now))


                                    Dim mTempCsh As Decimal
                                    Dim mTempChq As Decimal
                                    Dim mTempCshRem As Decimal = .CashTotalAmount
                                    Dim mTempChqRem As Decimal = .CheckTotalAmount

                                    For Each item In .lstORDetails

                                        Select Case .ORPaymentType
                                            Case eReference.PayTypeCSH
                                                mTempCsh = item.Amount
                                            Case eReference.PayTypeCHQ
                                                mTempChq = mTempChqRem
                                                mTempCsh = mTempCshRem

                                                If mTempCsh = 0 Then
                                                    mTempChq = item.Amount
                                                Else
                                                    If mTempChqRem >= item.Amount Then
                                                        mTempChq = item.Amount
                                                        mTempCsh = 0
                                                        mTempChqRem = mTempChqRem - mTempChq
                                                    Else
                                                        mTempCsh = item.Amount - mTempChqRem
                                                        mTempChq = mTempChqRem
                                                        mTempChqRem = 0
                                                        mTempCshRem = mTempCshRem - mTempCsh
                                                    End If
                                                End If
                                        End Select

                                        lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn(GetIdFromList(lstIdSiteTmpTrn, lstSiteTmpTrn.Count), 0, item.ActType, String.Empty, .PayorID, _
                                                                                    String.Empty, .ORDate, item.Amount, .UserID, Now, 0, 0, .CheckNumber, .ORCurrency, String.Empty, _
                                                                                    .ORPaymentType, 0, 0, .SourceSite, .ORNumber, GetTrnCod(item.ActType, .ORPaymentType), 0, 0, 0, 0, 0, 0, item.ReceiptType, _
                                                                                    String.Empty, cDataType.fDate.Empty, mTempCsh, mTempChq, 0, 0, 0, String.Empty, 0, .APRDate, .APRNumber, _
                                                                                    0, 0, cDataType.fDate.Empty, 0, String.Empty, Now, .UserID, .SiteCode, _
                                                                                    eReference.Status.Active, .UserID, Now, .UserID, Now))
                                    Next

                                    'Particulars

                                    For Each item In .lstParticulars
                                        lstSiteORPart.Add(New bllWorking.BSiteORPart(GetIdFromList(lstIdSiteORPart, lstSiteORPart.Count), .ORNumber, item.ParticularItem, item.ItemAmount, lstSiteORPart.Count + 1, 1, .UserID, Now, .UserID, Now))
                                    Next

                                    Dim strSectionId As String = .Block
                                    If .ColumbariumTag Then
                                        lstSiteORColDtl.Add(New bllWorking.BSiteORColDtl(GetIdFromList(lstIdSiteORColDtl, lstSiteORColDtl.Count), .ORNumber, .Vault, .Product, .Block, .Level, .Column, .LotListPrice, .DiscountRate, .VaultVAT, .ReservationAmt, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        '                                                                                           pId, pORNmbr, pLot, pProduct, pSectionId, pSector, pBlockNo, pLotListPrice, pDiscountRate, pVAT, pReservationAmt, pStatusId, pPostBy, pPostDate, pLastUpdateBy, pLastUpdate
                                    End If

                            End Select

                            objPaymntNonPremiumRelated = New bllPayment.BPaymentNonPremiumRelated

                            With objPaymntNonPremiumRelated
                                .SiteCode = vwPaymentNonPremiumRelated.SiteCode
                                .UserID = vwPaymentNonPremiumRelated.UserID
                                .IsAprTag = vwPaymentNonPremiumRelated.WithAPR
                                .IsColumbary = vwPaymentNonPremiumRelated.ColumbariumTag
                                .SiteORHeader = objSiteORHeader
                                .SiteORVAT = objSiteORVAT
                                .SiteORDtl = lstSiteORDtl
                                .SiteORAPRPay = lstSiteORAPRPy
                                .SiteORChkPay = lstSiteORChkPy
                                .SiteTmpTrn = lstSiteTmpTrn
                                '.PrsMas = lstPrsmas
                                .SiteORPart = lstSiteORPart
                                .lstForDeletion = lstForDeletion
                                If vwPaymentNonPremiumRelated.ColumbariumTag Then
                                    .SiteColDtl = lstSiteORColDtl
                                End If

                                Select Case mDocSaveState
                                    Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit

                                        If .SiteORHeader.ORNmbr = 0 Then
                                            Dim objDetails As New BLL.OCS.Reference.BOprDetails
                                            .ReservedReceiptNumber = objDetails.LoadNextOPR(.SiteCode, eReference.ReceiptType.CI, .UserID)
                                            objSiteRcptCtr.GetSiteReceiptCounter(.SiteCode)
                                            objSiteRcptCtr.ReceiptNumber = .ReservedReceiptNumber
                                            objSiteRcptCtr.SiteId = .SiteCode
                                            objSiteRcptCtr.UserId = .UserID
                                            objSiteRcptCtr.StatusId = 1
                                            objSiteRcptCtr.PostBy = .UserID
                                            objSiteRcptCtr.LastUpdateBy = .UserID

                                            .SiteRcptCtr = objSiteRcptCtr
                                            '.ReserveReceiptNumber()
                                        End If

                                        If objSiteORHeader.StatusId <> eReference.Status.Posted Then
                                            .ProcessPaymentNonPremiumRelated()
                                        End If
                                        If vwPaymentNonPremiumRelated.ORNumber = 0 Then vwPaymentNonPremiumRelated.ORNumber = .ReservedReceiptNumber

                                    Case eReference.DocSaveState.Print
                                        '.PrintPaymentNonPremiumRelated()
                                        .IsSuccessful = True
                                        If objSiteORHeader.StatusId <> eReference.Status.Posted Then
                                            '.CopyToStgObjects()
                                            .PostPaymentNonPremiumRelated()
                                        End If

                                    Case eReference.DocSaveState.Cancel
                                        If objSiteORHeader.StatusId = eReference.Status.Posted Then
                                            .CancelPaymentNonPremiumRelated()
                                        End If
                                End Select

                                vwPaymentNonPremiumRelated.IsSuccessful = .IsSuccessful

                                If .IsSuccessful And Not mDocSaveState = eReference.DocSaveState.Print Then
                                    Call SetMessage(String.Concat("Non-Premium Payment.<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                                End If
                            End With
                        End With
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ProcessPaymentNonPremium.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ConfirmCancel(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "CANCEL"
                    .Message = String.Concat("Are you sure you want to cancel OR#", vwPaymentNonPremiumRelated.ORNumber, "?")
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
                    .Message = String.Concat("Are you sure you want to save this OR?")
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
                    .Message = String.Concat("Are you sure you want to print OR#", vwPaymentNonPremiumRelated.ORNumber, "?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmPrint.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmDeletePaytyp(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "DELETEPAYTYP"
                    .Message = String.Concat("Are you sure you want to delete item?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmDeletePaytyp.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmDeleteORDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "DELETEORDETAILS"
                    .Message = String.Concat("Are you sure you want to delete item?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmDeleteORDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmDeleteParticulars(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "DELETEPARTICULARS"
                    .Message = String.Concat("Are you sure you want to delete item?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmDeleteParticulars.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub


        Private Function GetIdFromList(ByVal pList As Object, ByVal pCounter As Integer) As Long
            If pList.Count > pCounter Then
                Return pList(pCounter)
            Else
                Return 0
            End If
        End Function

        Private Sub LoadOR(ByVal sender As Object, ByVal e As EventArgs)

            Dim objSiteTmpTrn As New bllWorking.BSiteTmpTrn
            Dim objSiteORHeader As New bllWorking.BSiteORHeader
            Dim objSiteORDtl As New bllWorking.BSiteORDtl
            Dim objSiteORAPRPy As New bllWorking.BSiteORAPRPay
            Dim objSiteORChkPy As New bllWorking.BSiteORChkPay
            Dim objSiteORVAT As New bllWorking.BSiteORVAT
            Dim objSiteORPart As New bllWorking.BSiteORPart
            Dim objSiteORColDtl As New bllWorking.BSiteORColDtl
            Dim objTrnref As New bllReference.BTrnRef

            Try
                With vwPaymentNonPremiumRelated
                    Dim dtSiteTmpTrn = objSiteTmpTrn.GetTmpTrnDt(.ORNumber, eReference.DocTypeOR, .ReceiptById)
                    Dim dtSiteORDtl = objSiteORDtl.GetORDtlDt(.ORNumber, .ReceiptById)
                    Dim dtSiteORChkPy = objSiteORChkPy.GetORChkPyDt(.ORNumber, .ReceiptById)
                    Dim dtSiteORPart = objSiteORPart.GetSiteORPart(.ORNumber, .ReceiptById)
                    Dim dtSiteORColDtl = objSiteORColDtl.GetORColDtl(.ORNumber, .ReceiptById)
                    'Dim dtSiteORAPRPy = objSiteORAPRPy.GetORAPRPay(.ORNumber)

                    objSiteORVAT.GetSiteORVAT(.ORNumber, .ReceiptById)
                    objSiteORHeader.GetORHeader(.ORNumber, .ReceiptById)
                    objSiteORAPRPy.GetORAPRPay(.ORNumber, .ReceiptById)

                    Dim dtTrnref As DataTable
                    Dim mIsAPR As Boolean
                    Dim mPayTyp As String = String.Empty
                    Dim mCashAmount As Decimal = 0
                    Dim mIsColumbary As Boolean
                    'Dim mTmptrnStat as decimal = 0

                    'If objSiteORHeader.StatusId <> 10 Then

                    '------ Payment Details



                    If dtSiteTmpTrn.Rows.Count <> 0 Then
                        For Each dr As DataRow In dtSiteTmpTrn.Rows
                            If dr.Item("status_id") = objSiteORHeader.StatusId Then
                                .ORNumber = dr.Item("rcptno")
                                .SourceSite = dr.Item("colloff")

                                .ORCurrency = dr.Item("curcod")
                                .ORDate = dr.Item("trndat")

                                mPayTyp = dr.Item("paytyp")
                                mCashAmount += dr.Item("cshamt")
                                'mTmptrnStat = dr.Item("status_id")
                            End If
                        Next
                    End If

                    .ORRemarks = objSiteORHeader.Remarks

                    '------ End

                    '------ Columbarium
                    Dim TrnDesc = dtSiteORDtl.Rows(0)(4).ToString() 'trnx_desc
                    dtTrnref = objTrnref.GetTrnTyp(.DocType, TrnDesc)

                    Dim TrnTyp = dtTrnref.Rows(0)(4).ToString() 'trntyp_flag
                    .IsGrossaAmountLocked = True
                    .IsSourceSiteLocked = True
                    If TrnTyp = 1 Then
                        .TransactionType = eReference.TranType.ORRegular
                    ElseIf TrnTyp = 2 Then
                        .TransactionType = eReference.TranType.ORLoan
                    ElseIf TrnTyp = 3 Then
                        .TransactionType = eReference.TranType.ORColumbary
                    End If


                    If (.TransactionType = eReference.TranType.ORColumbary) Then
                        mIsColumbary = True

                        If dtSiteORColDtl.Rows.Count > 0 Then
                            mIsColumbary = True
                            For Each dr As DataRow In dtSiteORColDtl.Rows
                                If dr.Item("status_id") = objSiteORHeader.StatusId Then
                                    .Level = dr.Item("SECTOR").ToString()
                                    .Block = dr.Item("SECTION_ID").ToString()
                                    .Column = dr.Item("BLOCK_NO").ToString()
                                    .Vault = dr.Item("LOT")
                                    .LotListPrice = dr.Item("LOTLISTPRICE")
                                    .Product = dr.Item("PRODUCT")
                                    '----
                                    .ReservationAmt = dr.Item("RESERVATION_AMT")
                                    .DiscountRate = dr.Item("DISCOUNTRATE")
                                    .VaultVAT = dr.Item("VAT")
                                End If
                            Next
                        End If

                        '--------------------
                        'If .ReservationAmt > 0 Then
                        '    .ColumbaryInitialFee = True
                        '    .ColPayrRegular = True
                        'ElseIf (.ReservationAmt <= 0 Or .ReservationAmt = cDataType.fDecimal.Empty) Then 'And (.VaultVAT > 0)
                        '    .ColumbaryInitialFee = True
                        '    .ColPayrRegular = False
                        'ElseIf (.ReservationAmt = cDataType.fDecimal.Empty) And (.DiscountRate = cDataType.fDecimal.Empty) And (.VaultVAT = cDataType.fDecimal.Empty) Then
                        '    .ColumbaryInitialFee = False
                        '    .ColPayrRegular = False
                        '    .ColPayrEmployee = False                           
                        'End If

                        If (.ReservationAmt <> cDataType.fDecimal.Empty Or .ReservationAmt <> 0) Or _
                            (.DiscountRate <> cDataType.fDecimal.Empty Or .DiscountRate <> 0) Or _
                            (.VaultVAT <> cDataType.fDecimal.Empty Or .VaultVAT <> 0) Then

                            .ColumbaryInitialFee = True

                            If .ReservationAmt = 0 Then
                                .ColPayrEmployee = True
                                .ColPayrRegular = False
                            ElseIf .ReservationAmt = 1000 Then
                                .ColPayrRegular = True
                                .ColPayrEmployee = False
                            End If
                        Else
                            .ColumbaryInitialFee = False
                        End If

                        '-------------------

                    End If
                    '------ End

                    '------ Other Details
                    .PayorID = objSiteORHeader.PayrID
                    .PayorName = objSiteORHeader.Payor
                    '.DepositoryAccount = objSiteORHeader.Acct
                    .GLCode = objSiteORHeader.GLCode
                    '------ End

                    '------ APR

                    If dtSiteTmpTrn.Rows(0)(38) <> 0 Then   'APR
                        mIsAPR = True
                    Else
                        mIsAPR = False
                    End If

                    If mIsAPR Then
                        .WithAPR = mIsAPR

                        'If objSiteORAPRPy.StatusId = 1 Then

                        If objSiteORAPRPy.StatusId = objSiteORHeader.StatusId Then 'mTmptrnStat Then
                            .APRNumber = objSiteORAPRPy.APRNmbr
                            .APRDate = objSiteORAPRPy.APRDate
                            .APRAmount = objSiteORAPRPy.Amount
                        End If

                        'For Each dr As DataRow In dtSiteORAPRPy.Rows
                        '    'If dr.Item("status_id") = 1 Then
                        '    If dr.Item("status_id") = objSiteORHeader.StatusId Then
                        '        '.Level = dr.Item("SECTOR").ToString()
                        '        '.Block = dr.Item("SECTION_ID").ToString()
                        '        '.Column = dr.Item("BLOCK_NO").ToString()
                        '        '.Vault = dr.Item("LOT")
                        '        '.LotListPrice = dr.Item("LOTLISTPRICE")
                        '        '.Product = dr.Item("PRODUCT")
                        '        ''----
                        '        '.ReservationAmt = dr.Item("RESERVATION_AMT")
                        '        '.DiscountRate = dr.Item("DISCOUNTRATE")
                        '        '.VaultVAT = dr.Item("VAT")
                        '        .APRNumber = dr.Item("APR_NMBR").ToString()
                        '        .APRDate = dr.Item("APR_DATE").ToString()
                        '        .APRAmount = dr.Item("AMOUNT").ToString()
                        '    End If
                        'Next


                    End If

                    '------ End

                    '------ Payment Type Details / OR Details
                    .PrevPayType = mPayTyp
                    .ORPaymentType = mPayTyp

                    Dim dtPaymentTypeList As New DataTable
                    Dim mCptDtlList As New List(Of cPaymentType)

                    Select Case mPayTyp
                        Case eReference.PayTypeCSH
                            mCptDtlList.Add(New cPaymentType(mCashAmount))
                            AddToTotalAmount(mPayTyp, mCashAmount)
                        Case eReference.PayTypeCHQ
                            If mCashAmount > 0 Then
                                mCptDtlList.Add(New cPaymentType(mCashAmount))
                                AddToTotalAmount(eReference.PayTypeCSH, mCashAmount)
                            End If
                            dtPaymentTypeList = objSiteORChkPy.GetORChkPyDt(.ORNumber, .ReceiptById)
                    End Select

                    If dtPaymentTypeList.Rows.Count > 0 Then
                        For Each dr As DataRow In dtPaymentTypeList.Rows
                            'If dr.Item("status_id") = 1 Then
                            If dr.Item("status_id") = objSiteORHeader.StatusId Then
                                mCptDtlList.Add(New cPaymentType(dr, mPayTyp))
                                AddToTotalAmount(mPayTyp, dr.Item("amount"))
                            End If
                        Next
                    End If

                    .ORGrossAmount = .PaymentTotalAmount
                    .lstPaymentTypeDetails = mCptDtlList

                    '------ End

                    '------ OR Details

                    Dim mRptDtl As New List(Of cORDetail)

                    If dtSiteORDtl.Rows.Count > 0 Then
                        For Each dr As DataRow In dtSiteORDtl.Rows
                            'If dr.Item("status_id") = 1 Then
                            If dr.Item("status_id") = objSiteORHeader.StatusId Then

                                mRptDtl.Add(New cORDetail(dr, eReference.DocTypeOR))
                                AddToTotalAmount(eReference.DocTypeOR, dr.Item("amount"))
                            End If
                        Next
                        .lstORDetails = mRptDtl
                    End If

                    '------ End

                    '------ Particulars
                    Dim mPartDtl As New List(Of cParticulars)

                    If dtSiteORPart.Rows.Count <> 0 Then
                        For Each dr As DataRow In dtSiteORPart.Rows
                            If dr.Item("status_id") = objSiteORHeader.StatusId Then

                                mPartDtl.Add(New cParticulars(dr, eReference.DocTypeOR))
                                AddToTotalAmount(String.Empty, dr.Item("amount"))
                            End If
                        Next
                        .lstParticulars = mPartDtl
                    End If

                    '------ End

                    '------ VAT DETAILS
                    'If objSiteORVAT.StatusId = 1 Then
                    .VATWithholdingTax = objSiteORVAT.WTaxAmt
                    .VATTotalCollection = objSiteORVAT.GrossAmt
                    .NonVATCollection = objSiteORVAT.NonVatColl
                    .VATExemptCollection = objSiteORVAT.VatExemptColl
                    .VATAmountNetWTax = objSiteORVAT.NetAmt
                    .VATAmount = objSiteORVAT.VatAmt
                    .VATableCollection = objSiteORVAT.VatableColl
                    'End If
                    '------ End

                    '---------------------------------------------------------------------
                    If objSiteORHeader.CancelFlag = 1 Then
                        .DocSaveState = eReference.DocSaveState.Cancel
                        .PaymentTypeTag = False
                    ElseIf objSiteORHeader.StatusId = 10 Or objSiteORHeader.StatusId = 11 Then
                        .DocPrinted = IIf(objSiteORHeader.PrtFlag = 1, True, False)
                        .DocSaveState = eReference.DocSaveState.Print 'ALLOW REPRINT AND CANCEL OF PRINTED/POSTED RECEIPTS
                    Else
                        .DocSaveState = eReference.DocSaveState.ViewEdit
                    End If

                    'End If
                End With
            Catch ex As Exception
                vwPaymentNonPremiumRelated.DocSaveState = eReference.DocSaveState.Initial
                Call ClearScreenMain(sender, e)
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadOR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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

                Throw
            End Try

        End Sub
        ' -------------------------------------------------------------------------------
        Private Sub AddCashPayment(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cPaymentType)
            Dim cptLocal As New cPaymentType()

            Dim mIsPaymentExists As Boolean = True

            Try
                With vwPaymentNonPremiumRelated
                    .IsPayTypeSuccessful = False
                    'Check & Cash
                    If IsValidPaymentTypeDetails(eReference.PayTypeCSH) Then
                        If .ORPaymentType = eReference.PayTypeCHQ And .ORCashAmount > 0 Then

                            mIsPaymentExists = CheckPaymentIfExisting("ADD", eReference.PayTypeCSH, String.Empty, cptLocal.Amount)
                            If mIsPaymentExists Then
                                Call SetMessage("Payment already exists.", eSystemMessage.Warning, True)
                                Exit Sub
                            Else
                                If .ORPaymentType = eReference.PayTypeCHQ And _
                                .ORCashAmount = .ORGrossAmount Then
                                    Call SetMessage("Cash and Check amount allocation invalid.", eSystemMessage.Warning, True)
                                    Exit Sub
                                End If

                                cptLocal = New cPaymentType(
                                    .ORCashAmount)

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
                With vwPaymentNonPremiumRelated
                    .IsPayTypeSuccessful = False
                    If IsValidPaymentTypeDetails(.ORPaymentType) Then

                        lstLocal = .lstPaymentTypeDetails

                        Select Case .ORPaymentType
                            Case eReference.PayTypeCSH
                                cptLocal = New cPaymentType(
                                    .ORCashAmount)
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

        Private Sub AddParticulars(ByVal sender As Object, ByVal e As EventArgs)

            Dim lstLocal As New List(Of cParticulars)
            Dim cptLocal As New cParticulars()

            Try
                With vwPaymentNonPremiumRelated
                    .IsParticularsValid = False
                    If IsValidParticulars() Then
                        lstLocal = .lstParticulars

                        cptLocal = New cParticulars(.ParticularsAmount, .ParticularsRemarks)
                        lstLocal.Add(cptLocal)

                        Call AddToTotalAmount(String.Empty, cptLocal.ItemAmount)
                        .lstParticulars = lstLocal
                        .IsParticularsValid = True
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddParticulars.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub AddToTotalAmount(ByVal pPayType As String, ByVal pAmount As Decimal)
            Try
                With vwPaymentNonPremiumRelated
                    Select Case pPayType
                        Case eReference.PayTypeCSH
                            .CashTotalAmount += pAmount
                        Case eReference.PayTypeCHQ
                            .CheckTotalAmount += pAmount
                        Case eReference.DocTypeOR
                            .ReceiptTotalAmount += pAmount
                        Case String.Empty
                            .ParticularsTotalAmount += pAmount
                    End Select
                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("AddToTotalAmount : ", ex.Message))
            End Try
        End Sub

        Private Sub DeletePaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cPaymentType)

            Try
                With vwPaymentNonPremiumRelated
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

        Private Sub DeleteParticulars(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cParticulars)

            Try
                With vwPaymentNonPremiumRelated
                    .IsParticularsValid = False

                    For Each cptLocal As cParticulars In .lstParticulars
                        If cptLocal.ParticularsID <> .ParticularsID Then
                            lstLocal.Add(cptLocal)
                        Else
                            Call AddToTotalAmount(String.Empty, -cptLocal.ItemAmount)
                        End If
                    Next
                    .lstParticulars = lstLocal
                    .IsParticularsValid = True
                End With
            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error DeleteParticulars.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub AddReceiptDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cORDetail)
            Dim rptLocal As New cORDetail()

            Dim mIsReceiptExisting As Boolean = True

            Try
                With vwPaymentNonPremiumRelated
                    .isReceiptSuccessful = False
                    If IsValidReceiptDetails() Then
                        rptLocal = New cORDetail()
                        rptLocal.TrnxCode = .ReceiptTransactionCode
                        rptLocal.ActType = .ReceiptTransactionType
                        rptLocal.TrnxDesc = .ReceiptTransactionDesc
                        'rptLocal.DueDate = .CovDue
                        rptLocal.Amount = .ReceiptAmount
                        rptLocal.ReceiptType = eReference.DocTypeOR

                        lstLocal = .lstORDetails
                        lstLocal.Add(rptLocal)


                        mIsReceiptExisting = CheckReceiptDetails("ADD", rptLocal.TrnxCode, rptLocal.ActType, rptLocal.TrnxDesc)
                        If mIsReceiptExisting Then
                            Call SetMessage("Receipt already exists.", eSystemMessage.Warning, True)
                            Exit Sub
                        Else
                            Call AddToTotalAmount(eReference.DocTypeOR, rptLocal.Amount)

                            .lstORDetails = lstLocal
                            .isReceiptSuccessful = True
                        End If

                    End If
                End With

            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddReceiptDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub DeleteReceiptDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cORDetail)

            Try
                With vwPaymentNonPremiumRelated
                    .isReceiptSuccessful = False

                    For Each rptLocal As cORDetail In .lstORDetails '.PaymentTypeListSession

                        If rptLocal.IsSelected = False Then
                            lstLocal.Add(rptLocal)
                        Else
                            Call AddToTotalAmount(eReference.DocTypeOR, -rptLocal.Amount)

                        End If
                    Next
                    .lstORDetails = lstLocal
                    .isReceiptSuccessful = True
                End With
            Catch ex As Exception
               Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error DeleteReceiptDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Public Sub ComputeVatDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim objBll As New bllReference.BTrnRef
            Dim vatable_coll As Decimal = 0
            Dim vatexempt_coll As Decimal = 0
            Dim non_vat_coll As Decimal = 0
            Dim vat_amt As Decimal = 0
            Dim net_amt As Decimal = 0
            Dim wtax_amt As Decimal = 0
            Dim gross_amt As Decimal = 0

            Try
                With vwPaymentNonPremiumRelated
                    For Each rptLocal As cORDetail In .lstORDetails
                        objBll.GetReceiptTransactionDetails(rptLocal.TrnxCode, eReference.DocTypeOR)
                        If objBll.Vatable = "Y" Then
                            vatable_coll = vatable_coll + rptLocal.Amount
                        Else
                            non_vat_coll = non_vat_coll + rptLocal.Amount
                        End If

                        gross_amt = gross_amt + rptLocal.Amount
                    Next

                    If vatable_coll = 0 Then
                        net_amt = gross_amt - wtax_amt
                    End If

                    .VATableCollection = vatable_coll
                    .VATAmount = vat_amt
                    .VATAmountNetWTax = net_amt
                    .NonVATCollection = non_vat_coll
                    .VATExemptCollection = vatexempt_coll
                    .VATTotalCollection = gross_amt
                    .VATWithholdingTax = wtax_amt

                    .VATTotalCollection = .VATAmount + .VATableCollection + .VATExemptCollection + .NonVATCollection
                    .VATAmountNetWTax = .VATTotalCollection - .VATWithholdingTax
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ComputeVatDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub


#End Region

    End Class
End Namespace

