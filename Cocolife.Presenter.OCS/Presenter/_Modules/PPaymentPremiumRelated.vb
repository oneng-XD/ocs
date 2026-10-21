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
Imports preReport = Cocolife.Presenter.OCS.Report
Imports bllReference = Cocolife.BLL.OCS.Reference
Imports bllPerson = Cocolife.BLL.OCS.Person
Imports bllSearch = Cocolife.BLL.OCS.Search
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllPayment = Cocolife.BLL.OCS.Payment
Imports bllStaging = Cocolife.BLL.OCS.Staging
Imports preSearch = Cocolife.Presenter.OCS.Search
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
Imports System.Configuration
#End Region

Namespace Payment

    Public Class PPaymentPremiumRelated

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPaymentPremiumRelated As Payment.IPaymentPremiumRelated
        Private vwConfirmMsg As preMessages.IConfirmationMessage
        Private vwReport As preReport.IReport

        Private objPaymntPremiumRelated As bllPayment.BPaymentPremiumRelated
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Payment.IPaymentPremiumRelated)

            vwSysMsg = pView
            vwPaymentPremiumRelated = pView
            vwConfirmMsg = pView
            vwReport = pView

            With vwPaymentPremiumRelated
                ' -------------------------------------------------------------------------------
                AddHandler .ClearScreenAPRDetails, AddressOf ClearScreenAPRDetails
                AddHandler .ClearScreenBalanceToHigher, AddressOf ClearScreenBalanceToHigher
                AddHandler .ClearScreenCheckDetails, AddressOf ClearScreenCheckDetails
                AddHandler .ClearScreenCreditCardNumber, AddressOf ClearScreenCreditCardNumber
                AddHandler .ClearScreenCreditCardDetails, AddressOf ClearScreenCreditCardDetails
                AddHandler .ClearScreenDebitCardDetails, AddressOf ClearScreenDebitCardDetails
                AddHandler .ClearScreenECashPaymentDetails, AddressOf ClearScreenECashPaymentDetails
                AddHandler .ClearScreenGpaPaymentDetails, AddressOf ClearScreenGpaPaymentDetails
                AddHandler .ClearScreenGpaCardNo, AddressOf ClearScreenGpaCardNo
                AddHandler .ClearScreenGpaDetails, AddressOf ClearScreenGpaDetails
                AddHandler .ClearScreenPayslipCode, AddressOf ClearScreenPayslipCode
                AddHandler .ClearScreenBillNo, AddressOf ClearScreenBillNo
                AddHandler .ClearScreenSubsNo, AddressOf ClearScreenSubsNo
                AddHandler .ClearGpaSettings, AddressOf ClearGpaSettings
                AddHandler .ClearScreenPayorType, AddressOf ClearScreenPayorType
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenReceiptDetails, AddressOf ClearScreenReceiptDetails
                AddHandler .ClearScreenPaymentDetails, AddressOf ClearScreenPaymentDetails
                AddHandler .ClearScreenPolicy, AddressOf ClearScreenPolicy
                AddHandler .ClearScreenVATComputation, AddressOf ClearScreenVATComputation
                AddHandler .ClearScreenCashDetails, AddressOf ClearScreenCashDetails
                AddHandler .ClearScreenPaymentTypeDetails, AddressOf ClearScreenPaymentTypeDetails
                AddHandler .ClearScreenNewBusiness, AddressOf ClearScreenNewBusiness
                AddHandler .ClearScreenNewBizPayor, AddressOf ClearScreenNewBizPayor
                AddHandler .ClearScreenNewBiz, AddressOf ClearScreenNewBiz
                AddHandler .ClearScreenPayor, AddressOf ClearScreenPayor
                AddHandler .ClearScreenInsured, AddressOf ClearScreenInsured
                AddHandler .ClearScreenAddPayor, AddressOf ClearScreenAddPayor
                AddHandler .ClearScreenAddInsured, AddressOf ClearScreenAddInsured
                AddHandler .ClearScreenAgent, AddressOf ClearScreenAgent
                AddHandler .ClearScreenAgentDetails, AddressOf ClearScreenAgentDetails
                AddHandler .ClearScreenViewAppNo, AddressOf ClearScreenViewAppNo
                AddHandler .ClearScreenViewOPR, AddressOf ClearScreenViewOPR
                ' -------------------------------------------------------------------------------
                AddHandler .LoadViewAppNo, AddressOf LoadViewAppNo
                AddHandler .LoadViewOPR, AddressOf LoadViewOPR
                AddHandler .LoadSourceSite, AddressOf LoadSourceSite
                AddHandler .LoadCurrency, AddressOf LoadCurrency
                AddHandler .LoadPersonType, AddressOf LoadPersonType
                AddHandler .LoadPersonTitle, AddressOf LoadPersonTitle
                AddHandler .LoadFrequencyOfPayment, AddressOf LoadFrequencyOfPayment
                AddHandler .LoadBusinessType, AddressOf LoadBusinessType
                AddHandler .LoadPaymentType, AddressOf LoadPaymentType
                AddHandler .LoadAllowedPaymentType, AddressOf LoadAllowedPaymentType
                AddHandler .LoadTransactionType, AddressOf LoadTransactionType
                AddHandler .LoadPolicyType, AddressOf LoadPolicyType
                AddHandler .LoadPayslipCode, AddressOf LoadPayslipCode
                AddHandler .LoadPolicyBilling, AddressOf LoadPolicyBilling
                AddHandler .LoadGpaType, AddressOf LoadGpaType
                AddHandler .LoadGpaCardNo, AddressOf LoadGpaCardNo
                AddHandler .LoadGpaPolicy, AddressOf LoadGpaPolicy
                AddHandler .LoadGpaSettings, AddressOf LoadGpaSettings
                AddHandler .LoadGpaRenewalAsd, AddressOf LoadGpaRenewalAsd
                AddHandler .LoadReceiptTransaction, AddressOf LoadReceiptTransaction
                AddHandler .GetReceiptTransactionDetails, AddressOf GetReceiptTransactionDetails
                AddHandler .CheckReceiptTransaction, AddressOf CheckReceiptTransaction
                'AddHandler .LoadTerminalUseCCA, AddressOf LoadTerminalUseCCA
                'AddHandler .LoadTerminalUseDCA, AddressOf LoadTerminalUseDCA
                AddHandler .LoadGpaPlan, AddressOf LoadGpaPlan
                AddHandler .LoadMerchantId, AddressOf LoadMerchantId
                AddHandler .LoadBankNetwork, AddressOf LoadBankNetwork
                AddHandler .LoadAccountType, AddressOf LoadAccountType
                AddHandler .LoadNewOPR, AddressOf LoadNewOPR
                AddHandler .LoadApplicationNo, AddressOf LoadApplicationNo
                AddHandler .CheckPrevPayType, AddressOf CheckPrevPaytype
                AddHandler .CheckAllowedPaytype, AddressOf CheckAllowedPaytype
                AddHandler .SetSamePayorInsured, AddressOf SetSamePayorInsured
                AddHandler .LoadAddPayor, AddressOf LoadAddPayor
                AddHandler .LoadAddInsured, AddressOf LoadAddInsured
                AddHandler .LoadBankList, AddressOf LoadBankList
                AddHandler .LoadECashPaymentChannel, AddressOf LoadECashPaymentChannel
                AddHandler .LoadDefaultTerminal, AddressOf LoadDefaultTerminal
                AddHandler .LoadPolModDetails, AddressOf LoadPolModDetails
                AddHandler .LoadPremiumBreakdown, AddressOf LoadPremiumBreakdown
                AddHandler .LoadNewFrequency, AddressOf LoadNewFrequency
                ' -------------------------------------------------------------------------------
                AddHandler .CheckModalPremium, AddressOf CheckModalPremium
                AddHandler .CheckGrossAmount, AddressOf CheckGrossAmount
                AddHandler .CheckSourceSite, AddressOf CheckSourceSite
                ' -------------------------------------------------------------------------------
                AddHandler .CreditCardFetchData, AddressOf CreditCardFetchData
                AddHandler .DebitCardFetchData, AddressOf DebitCardFetchData
                AddHandler .ValidateCreditCardNo, AddressOf ValidateCreditCardNo
                ' -------------------------------------------------------------------------------
                AddHandler .GetAgentDetails, AddressOf GetAgentDetails
                AddHandler .GetPayorDetails, AddressOf GetPayorDetails
                AddHandler .GetPolicyDetails, AddressOf GetPolicyDetails
                AddHandler .GetInsuredDetails, AddressOf GetInsuredDetails
                ' -------------------------------------------------------------------------------
                AddHandler .AddCashPayment, AddressOf AddCashPayment
                AddHandler .AddPaymentTypeDetails, AddressOf AddPaymentTypeDetails
                AddHandler .DeletePaymentTypeDetails, AddressOf DeletePaymentTypeDetails
                'AddHandler .FilterPayTypeList, AddressOf FilterPayTypeList
                ' -------------------------------------------------------------------------------
                AddHandler .GetPaymentTypeDetails, AddressOf GetPaymentTypeDetails
                AddHandler .AddReceiptDetails, AddressOf AddReceiptDetails
                AddHandler .DeleteReceiptDetails, AddressOf DeleteReceiptDetails
                ' -------------------------------------------------------------------------------
                AddHandler .ComputeVatDetails, AddressOf ComputeVatDetails
                ' -------------------------------------------------------------------------------
                AddHandler .AddNewBizPayor, AddressOf AddNewBizPayor
                AddHandler .AddNewBiz, AddressOf AddNewBiz
                AddHandler .DeleteNewBiz, AddressOf DeleteNewBiz
                AddHandler .GetNewBiz, AddressOf GetNewBiz
                ' -------------------------------------------------------------------------------
                AddHandler .LoadOPR, AddressOf LoadOPR
                AddHandler .ProcessPaymentPremium, AddressOf ProcessPaymentPremium
                AddHandler .ConfirmCancel, AddressOf ConfirmCancel
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                AddHandler .ConfirmPrint, AddressOf ConfirmPrint
                'AddHandler .SavePaymentPremium, AddressOf SavePaymentPremium
                'AddHandler .UpdatePaymentPremium, AddressOf UpdatePaymentPremium
                'AddHandler .PrintPaymentPremium, AddressOf PrintPaymentPremium
                'AddHandler .CancelPaymentPremium, AddressOf CancelPaymentPremium
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

                With vwPaymentPremiumRelated

                    If .WithAPR Then

                        'If .APRNumber = cDataType.fLong.Empty Then
                        '    Call SetMessage("Please enter valid APR number.", eSystemMessage.Warning, True)
                        '    Return False
                        'End If

                        If .APRDate = cDataType.fDate.Empty Then
                            Call SetMessage("Please enter APR date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .APRDate = cDataType.fDate.Invalid Then
                            Call SetMessage("Invalid APR date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .APRNumber <> cDataType.fLong.Empty AndAlso ((.APRDate < DateAdd(DateInterval.Month, -1, .OPRDate)) _
                            Or .APRDate > .OPRDate) Then
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
                Throw New exception(String.Concat("IsValidAPRDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidAPRDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidBalanceToHigher() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .BalanceToHigher Then

                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New exception(String.Concat("IsValidBalanceToHigher : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidBalanceToHigher.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidCashDetails() As Boolean
            Try
                With vwPaymentPremiumRelated
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
                Throw New exception(String.Concat("IsValidCashDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidCashDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function

        Private Function IsValidCheckDetails() As Boolean

            Try

                With vwPaymentPremiumRelated

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

                        If .CheckBankName = cDataType.fString.Empty Then
                            Call SetMessage("Please enter bank name.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CheckBankBranch = cDataType.fString.Empty Then
                            Call SetMessage("Please enter bank branch.", eSystemMessage.Warning, True)
                            Return False
                        End If
                    Else
                        Call SetMessage("Incorrect Payment Type tagging!", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New exception(String.Concat("IsValidCheckDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidCheckDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidCreditCardDetails() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .CreditCardPaymentTag = True Then

                        If .CreditCardTerminalUse = cDataType.fString.Empty Then
                            Call SetMessage("Please select terminal use.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CreditCardSwipeDate.Date = cDataType.fDate.Empty Then
                            Call SetMessage("Please enter swipe date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .CreditCardSwipeDate.Date = cDataType.fDate.Invalid Then
                            Call SetMessage("Invalid swipe date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .CreditCardSwipeDate > CDate(String.Concat(.OPRDate.ToShortDateString, " ", Now.TimeOfDay)) Then
                            Call SetMessage("Swipe date exceeds OPR Date.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CreditCardMerchant = cDataType.fString.Empty Then
                            Call SetMessage("Please select merchant.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CreditCardNumber = cDataType.fString.Empty Then
                            Call SetMessage("Please enter credit card number.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .CreditCardNumber <> cDataType.fString.Empty _
                            And Not .CreditCardNumberTag Then
                            Call SetMessage("Invalid credit card number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CreditCardTypeDesc = cDataType.fString.Empty Then
                            Call SetMessage("Invalid card type. Please validate credit card number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CreditCardAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter amount.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .CreditCardAmount > .OPRGrossAmount Then
                            Call SetMessage("Amount exceeds gross amount.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CreditCardApprovalCode = cDataType.fString.Empty Then
                            Call SetMessage("Please enter approval code.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .CreditCardBatchNumber = cDataType.fLong.Empty Then
                            Call SetMessage("Please enter batch number.", eSystemMessage.Warning, True)
                            Return False
                        End If
                    Else
                        Call SetMessage("Incorrect Payment Type tagging!", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New exception(String.Concat("IsValidCreditCardDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidCreditCardDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidCreditCardNumber() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .CreditCardNumber = cDataType.fString.Empty Then
                        Call SetMessage("Please enter credit card number.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New exception(String.Concat("IsValidCreditCardNumber : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidCreditCardNumber.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidDebitCardDetails() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .DebitCardPaymentTag = True Then

                        If .DebitCardTerminalUse = cDataType.fString.Empty Then
                            Call SetMessage("Please select terminal use.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardSwipeDate.Date = cDataType.fDate.Empty Then
                            Call SetMessage("Please enter swipe date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .DebitCardSwipeDate.Date = cDataType.fDate.Invalid Then
                            Call SetMessage("Invalid swipe date.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .DebitCardSwipeDate > CDate(String.Concat(.OPRDate.ToShortDateString, " ", Now.TimeOfDay)) Then
                            Call SetMessage("Swipe date exceeds OPR Date.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardMerchant = cDataType.fString.Empty Then
                            Call SetMessage("Please select merchant.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardBankNetwork = cDataType.fString.Empty Then
                            Call SetMessage("Please select bank network.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardBankName = cDataType.fString.Empty Then
                            Call SetMessage("Please enter bank name.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardAccountType = cDataType.fString.Empty Then
                            Call SetMessage("Please select account type.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardAccountNumber = cDataType.fString.Empty Then
                            Call SetMessage("Please enter account number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardChargeSlip = cDataType.fString.Empty Then
                            Call SetMessage("Please enter charge slip number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter amount.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .DebitCardAmount > .OPRGrossAmount Then
                            Call SetMessage("Amount exceeds gross amount.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .DebitCardBatchNumber = cDataType.fLong.Empty Then
                            Call SetMessage("Please enter batch number.", eSystemMessage.Warning, True)
                            Return False
                        End If
                    Else
                        Call SetMessage("Incorrect Payment Type tagging!", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidDebitCardDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidDebitCardDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidECashPaymentDetails() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .ECashPaymentTag = True Then

                        If .ECashPaymentChannel = cDataType.fString.Empty Then
                            Call SetMessage("Please select payment channel.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .ECashPaymentReferenceNumber = cDataType.fString.Empty Then
                            Call SetMessage("Please enter reference number.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .ECashPaymentAmount = cDataType.fDecimal.Empty Then
                            Call SetMessage("Please enter amount.", eSystemMessage.Warning, True)
                            Return False
                        ElseIf .ECashPaymentAmount > .OPRGrossAmount Then
                            Call SetMessage("Amount exceeds gross amount.", eSystemMessage.Warning, True)
                            Return False
                        End If

                    Else
                        Call SetMessage("Incorrect Payment Type tagging!", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidECashPaymentDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidDebitCardDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        'Private Function IsValidGpaForm() As Boolean
        '    Try
        '        With vwPaymentPremiumRelated
        '            Select Case .GpaType
        '                Case eReference.ColrefGPA, eReference.ColrefGpaRefund




        '                    If Not .GpaCardNoTag Then
        '                        Call SetMessage("Invalid card no.", eSystemMessage.Warning, True)
        '                        Return False
        '                    End If

        '                    If Not IsValidInsured() Then
        '                        Return False
        '                    End If

        '                    If Not IsValidPayor() Then
        '                        Return False
        '                    End If

        '                Case eReference.ColrefGpaRenewal
        '                    If Not .GpaSettingsAllowRenewal Then
        '                        Call SetMessage("Renewal is not allowed for this agent.", eSystemMessage.Warning, True)
        '                        Return False
        '                    End If

        '            End Select

        '            If .PolicyNumber = String.Empty Then
        '                Call SetMessage("Invalid GPA Card details.", eSystemMessage.Warning, True)
        '                Return False
        '            End If

        '            If Not .GpaCardNoTag Then
        '                Call SetMessage("Invalid Card No.", eSystemMessage.Warning, True)
        '                Return False
        '            End If
        '        End With

        '        Return True
        '    Catch ex As Exception
        '        Throw new exception SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaForm.<br /><br />", ex.Message      ))
        ''        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaForm.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try
        'End Function

        Private Function IsValidOPRDetails() As Boolean

            Try

                With vwPaymentPremiumRelated
                    If Not .OPRGrossAmount = .ReceiptTotalAmount Then
                        Call SetMessage("Invoice Details Amount must be equal to Gross Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .lstReceiptDetails.Count > 5 Then
                        Call SetMessage("Limit Invoice Details to five(5) lines.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidOPRDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidOPRDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function


        Private Function IsValidPaymentDetailsSummary() As Boolean

            Try

                With vwPaymentPremiumRelated
                    If Not .OPRGrossAmount = .PaymentTotalAmount Then
                        Call SetMessage("Payment Type Details Amount must be equal to Gross Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPaymentDetailsSummary : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidOPRDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentTypeDetails(ByVal pPaymentType As String) As Boolean

            Try
                With vwPaymentPremiumRelated

                    If .OPRPaymentType = String.Empty Then
                        Call SetMessage("Please select Payment Type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .PaymentTotalAmount = .OPRGrossAmount Then
                        Call SetMessage("Payment Type Details Amount already reached Gross Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .PaymentTotalAmount + .OPRCashAmount + .CheckAmount + .CreditCardAmount + .DebitCardAmount + .ECashPaymentTotalAmount > .OPRGrossAmount Then
                        Call SetMessage("Payment Type Details amount will exceed gross amount..", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case pPaymentType
                        Case eReference.PayTypeCSH
                            Return IsValidCashDetails()
                        Case eReference.PayTypeCHQ
                            Return IsValidCheckDetails()
                        Case eReference.PayTypeCCA
                            Return IsValidCreditCardDetails()
                        Case eReference.PayTypeDCA
                            Return IsValidDebitCardDetails()
                        Case eReference.PayTypeECP
                            Return IsValidECashPaymentDetails()
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
                With vwPaymentPremiumRelated
                    If .ReceiptTransactionCode = cDataType.fString.Empty Then
                        Call SetMessage("Please select OPR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptTransactionDesc = cDataType.fString.Empty Then
                        Call SetMessage("Please select OPR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptTransactionType = cDataType.fString.Empty Then
                        Call SetMessage("Please select OPR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptTransactionVat = cDataType.fString.Empty Then
                        Call SetMessage("Please select OPR Transaction.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptAmount = cDataType.fDecimal.Empty Then
                        Call SetMessage("Input amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptAmount + .ReceiptTotalAmount > .OPRGrossAmount Then
                        Call SetMessage("Amount exceeds gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .ReceiptTransactionCode = eReference.ColrefAgentsAccount Then
                        If .PolType = "V" AndAlso Not CheckVlCommission(.PolicyNumber) Then
                            Call SetMessage("Net Remittance is not Allowed for this VL Plan.", eSystemMessage.Warning, True)
                            Exit Function
                        End If

                        If .GpaPaymentTag OrElse .CovSta <> String.Empty Then
                            .AgentSearchTag = IIf(.GpaPaymentTag, eReference.AgentTagType.SalesOfficer, eReference.AgentTagType.Agent)
                            Dim mAgentOR = CheckForAgentOr(.AgentID)

                            If Not (mAgentOR OrElse (.GpaPaymentTag AndAlso (.AgentSalesForce = "HOFF" OrElse .AgentSalesForce = "MMKT" OrElse .AgentSalesForce = "BANC"))) Then
                                Call SetMessage("Agent must have Registerd OR.", eSystemMessage.Warning, True)
                                Exit Function
                            End If

                            If .ReceiptAmount > 0 Then
                                If .ReceiptAmount >= .ModalPremium Then
                                    Call SetMessage("Commission must be less than Premium Amount!", eSystemMessage.Warning, True)
                                    Exit Function
                                End If

                                If .GpaPaymentTag AndAlso .ReceiptAmount >= (.ModalPremium * 0.5) Then
                                    Call SetMessage("Commission must be less than Premium Amount!", eSystemMessage.Warning, True)
                                    Exit Function
                                End If

                                If .GpaPaymentTag AndAlso Left(.GpaPlan, 1) = "B" Then
                                    If .ReceiptAmount > (.OPRGrossAmount * .AgentCommRate * (1 - .AgentTaxRate)) Then
                                        Call SetMessage("Amount exceeds maximum allowed Commission!", eSystemMessage.Warning, True)
                                        Exit Function
                                    End If
                                End If
                                If .ReceiptAmount > .CashTotalAmount Then
                                    Call SetMessage("Amount exceeds Cash Amount!", eSystemMessage.Warning, True)
                                    Exit Function
                                End If
                            End If
                        End If
                    Else
                        Dim objBll As New BLL.OCS.Reference.BTrnRef
                        Dim mReturn As String = "|0"
                        Dim mActype As String
                        Dim mPolBalSign As Integer
                        Dim dtLocal As DataTable

                        mReturn = objBll.IsValidTransactionCode(.PolicyNumber, .ReceiptTransactionType)
                        mActype = mReturn.Split("|")(0)
                        mPolBalSign = CInt(mReturn.Split("|")(1))
                        Select Case .ReceiptTransactionType
                            Case "SLON" To "SLONZ"
                                If .CovSta = String.Empty OrElse mActype = .ReceiptTransactionType And mPolBalSign = 1 Then
                                    mReturn = Nothing
                                Else
                                    mReturn = "Transaction code not applicable to this policy! Please select correct transaction."
                                End If
                            Case "PLOAN"
                                If .CovSta = "ETI" Or .CovSta = "RPU" Or .CovSta = "NTU" Or .CovSta = "CVE" Or .CovSta = String.Empty Then
                                    mReturn = Nothing
                                Else
                                    If mActype = .ReceiptTransactionType And mPolBalSign = 1 Then
                                        mReturn = Nothing
                                    Else
                                        mReturn = "Transaction code not applicable to this policy! Please select correct transaction."
                                    End If
                                End If
                            Case "FBRAC", "NPDFC", "PDFAC"
                                mReturn = objBll.IsValidTransactionCode(.PolicyNumber, "FBRAC", "NPDFC", "PDFAC")
                                mActype = mReturn.Split("|")(0)
                                mPolBalSign = CInt(mReturn.Split("|")(1))
                                If mPolBalSign >= 0 Then
                                    Call SetMessage("Policy does not have attached PDF/FBR rider/account.<br />Transaction is changed to NEW PDF(NPDFC).</br>Please delete OPR Detail if you do not wish to add NEW PDF(NPDFC).", eSystemMessage.Information, True)
                                    .ReceiptTransactionCode = "20591"
                                    GetReceiptTransactionDetails(vwPaymentPremiumRelated, EventArgs.Empty)
                                    mReturn = Nothing
                                Else
                                    Select Case mActype
                                        Case "NPDFC"
                                            .ReceiptTransactionCode = "20591"
                                        Case "PDFAC"
                                            .ReceiptTransactionCode = "20589"
                                        Case Else
                                            .ReceiptTransactionCode = "20590"
                                    End Select
                                    GetReceiptTransactionDetails(vwPaymentPremiumRelated, EventArgs.Empty)
                                    mReturn = Nothing
                                End If
                            Case "TPREM"
                                mReturn = Nothing
                                dtLocal = objBll.GetVlTopupLimit(.PolicyNumber, .OPRDate)

                                For Each dr As DataRow In dtLocal.Rows
                                    If dr.Item("CHK_SCHED_TOPUP") > 0 Then
                                        If .ReceiptAmount > dr.Item("MAX_TOT_UP_AMOUNT") Then
                                            mReturn = "Payment for scheduled Top-Up exceeded in whole or in part. Please enter another amount."
                                        End If
                                    End If
                                Next
                            Case Else
                                mReturn = Nothing
                        End Select

                        If Not IsNothing(mReturn) Then
                            Call SetMessage(mReturn, eSystemMessage.Warning, True)
                            Exit Function
                        End If
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidReceiptDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidReceiptDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidNewBizPayor() As Boolean

            Try
                With vwPaymentPremiumRelated
                    If .NewBizName = cDataType.fString.Empty Then
                        Call SetMessage("Input payor name.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidNewBizPayor : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidNewBizPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidNewBiz() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If Not (.NewBizInsId = 0) _
                          And Not .InsuredIDTag Then
                        Call ClearScreenInsured(Me, EventArgs.Empty)
                        Call SetMessage("Invalid insured id.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .NewBizInsId = 0 Then

                        Select Case .NewBizSex
                            Case String.Empty
                                Call SetMessage("Please select insured type.", eSystemMessage.Warning, True)
                                Return False
                            Case "C"
                                Call SetMessage("Insured must be a person.", eSystemMessage.Warning, True)
                                Return False
                            Case Else
                                If .NewBizLastName = String.Empty _
                                OrElse .NewBizFirstName = String.Empty Then
                                    Call SetMessage("Please enter insured name.", eSystemMessage.Warning, True)
                                    Return False
                                End If

                                If .NewBizTitle = String.Empty Then
                                    Call SetMessage("Please select insured title.", eSystemMessage.Warning, True)
                                    Return False
                                Else
                                    Select Case .NewBizTitle
                                        Case "MRS.", "MS."
                                            If .NewBizSex = "M" Then
                                                Call SetMessage("Invalid insured title. insured type is male.", eSystemMessage.Warning, True)
                                                Return False
                                            End If
                                        Case "MR."
                                            If .NewBizSex = "F" Then
                                                Call SetMessage("Invalid insured title. insured type is female.", eSystemMessage.Warning, True)
                                                Return False
                                            End If
                                    End Select
                                End If

                                Select Case .NewBizDoB
                                    Case cDataType.fDate.Empty
                                        Call SetMessage("Please enter insured date of birth.", eSystemMessage.Warning, True)
                                        Return False
                                    Case cDataType.fDate.Invalid
                                        Call SetMessage("Invalid insured date of birth.", eSystemMessage.Warning, True)
                                        Return False
                                    Case Is < cDataType.fDate.Minimum
                                        Call SetMessage("Insured date of birth precedes minimum date.", eSystemMessage.Warning, True)
                                        Return False
                                    Case Is > cDataType.fDate.Current
                                        Call SetMessage("Insured date of birth exceeds current date.", eSystemMessage.Warning, True)
                                        Return False
                                End Select

                                If .NewBizPlaceOfBirth = String.Empty Then
                                    Call SetMessage("Please enter insured place of birth.", eSystemMessage.Warning, True)
                                    Return False
                                End If
                        End Select
                    End If

                    If .NewBizAmount = cDataType.fDecimal.Empty Then
                        Call SetMessage("Input amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .NewBizAmount + .NewBizTotalAmount = .OPRGrossAmount Then
                        Call SetMessage("Amount exceeds gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Not .NewBizEcrNumber = cDataType.fLong.Empty OrElse Not .NewBizEcrDate = cDataType.fDate.Empty Then
                        If .NewBizEcrNumber = cDataType.fLong.Empty OrElse .NewBizEcrDate = cDataType.fDate.Empty Then
                            Call SetMessage("Please input proper ECR Details.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .NewBizEcrDate > cDataType.fDate.Current Then
                            Call SetMessage("Please input proper ECR Date.", eSystemMessage.Warning, True)
                            Return False
                        End If
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidNewBiz : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidNewBiz.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidInsured() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .SamePayorInsured = "N" Then

                        If Not (.InsuredID = 0) _
                        And Not .InsuredIDTag Then
                            Call ClearScreenInsured(Me, EventArgs.Empty)
                            Call SetMessage("Invalid insured id.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .InsuredID = 0 Then

                            If .InsuredType = String.Empty Then
                                Call SetMessage("Please select insured type.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            If .InsuredLastName = String.Empty _
                            OrElse .InsuredFirstName = String.Empty Then
                                Call SetMessage("Please enter insured name.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            If .InsuredTitle = String.Empty Then
                                Call SetMessage("Please select insured title.", eSystemMessage.Warning, True)
                                Return False
                            Else
                                Select Case .InsuredTitle
                                    Case "MRS.", "MS."
                                        If .InsuredType = "M" Then
                                            Call SetMessage("Invalid insured title. insured type is male.", eSystemMessage.Warning, True)
                                            Return False
                                        End If
                                    Case "MR."
                                        If .InsuredType = "F" Then
                                            Call SetMessage("Invalid insured title. insured type is female.", eSystemMessage.Warning, True)
                                            Return False
                                        End If
                                End Select
                            End If

                            If Not .TransactionType = eReference.TranType.Regular Then
                                Select Case .InsuredDateOfBirth
                                    Case cDataType.fDate.Empty
                                        Call SetMessage("Please enter insured date of birth.", eSystemMessage.Warning, True)
                                        Return False
                                    Case cDataType.fDate.Invalid
                                        Call SetMessage("Invalid insured date of birth.", eSystemMessage.Warning, True)
                                        Return False
                                    Case Is < cDataType.fDate.Minimum
                                        Call SetMessage("Insured date of birth precedes minimum date.", eSystemMessage.Warning, True)
                                        Return False
                                    Case Is > cDataType.fDate.Current
                                        Call SetMessage("Insured date of birth exceeds current date.", eSystemMessage.Warning, True)
                                        Return False
                                End Select

                                If .InsuredPlaceOfBirth = String.Empty And Not .GpaPaymentTag And .PolMod = "TEL" Then
                                    Call SetMessage("Please enter insured place of birth.", eSystemMessage.Warning, True)
                                    Return False
                                End If
                            End If
                        End If

                    End If

                    If .GpaPaymentTag Then

                        If .GpaTerm = 0 And .GpaType <> eReference.ColrefGpaRenewal Then
                            Call SetMessage("Input valid PA Card No. before insured details.", eSystemMessage.Warning, True)
                            Return False
                        End If
                        Dim mInsuredAge = .InsuredDateOfBirth.AddMonths(-6)
                        If AgeYears(mInsuredAge) < 5 OrElse (AgeYears(mInsuredAge) + .GpaTerm) > 65 Then
                            Call SetMessage("Age must be from 5 to 65 during the coverage term!" & vbCrLf & "Try GPA with lower insurance coverage", eSystemMessage.Warning, True)
                            Return False
                        End If

                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidInsured : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidAddInsured() As Boolean

            Try
                With vwPaymentPremiumRelated

                    If .InsuredAddType = String.Empty Then
                        Call SetMessage("Please select insured type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .InsuredAddLastName = String.Empty _
                    OrElse .InsuredAddFirstName = String.Empty Then
                        Call SetMessage("Please enter insured name.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .InsuredAddTitle = String.Empty Then
                        Call SetMessage("Please select insured title.", eSystemMessage.Warning, True)
                        Return False
                    Else
                        Select Case .InsuredAddTitle
                            Case "MRS.", "MS."
                                If .InsuredAddType = "M" Then
                                    Call SetMessage("Invalid insured title. insured type is male.", eSystemMessage.Warning, True)
                                    Return False
                                End If
                            Case "MR."
                                If .InsuredAddType = "F" Then
                                    Call SetMessage("Invalid insured title. insured type is female.", eSystemMessage.Warning, True)
                                    Return False
                                End If
                        End Select
                    End If
                    If Not .TransactionType = eReference.TranType.Regular Then
                        Select Case .InsuredAddDateOfBirth
                            Case cDataType.fDate.Empty
                                Call SetMessage("Please enter insured date of birth.", eSystemMessage.Warning, True)
                                Return False
                            Case cDataType.fDate.Invalid
                                Call SetMessage("Invalid insured date of birth.", eSystemMessage.Warning, True)
                                Return False
                            Case Is < cDataType.fDate.Minimum
                                Call SetMessage("Insured date of birth precedes minimum date.", eSystemMessage.Warning, True)
                                Return False
                            Case Is > cDataType.fDate.Current
                                Call SetMessage("Insured date of birth exceeds current date.", eSystemMessage.Warning, True)
                                Return False
                        End Select

                        If .InsuredAddPlaceOfBirth = String.Empty And Not .GpaPaymentTag And .PolMod = "TEL" Then
                            Call SetMessage("Please enter insured place of birth.", eSystemMessage.Warning, True)
                            Return False
                        End If
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidAddInsured : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidNewBiz.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPayor() As Boolean

            Try

                With vwPaymentPremiumRelated

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
                                    'Call SetMessage("Please select payor title.", eSystemMessage.Warning, True)
                                    'Return False
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

                                If Not .TransactionType = eReference.TranType.Regular Then
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

                                    If .PayorPlaceOfBirth = String.Empty And Not .GpaPaymentTag And .PolMod = "TEL" Then
                                        Call SetMessage("Please enter payor place of birth.", eSystemMessage.Warning, True)
                                        Return False
                                    End If
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

                With vwPaymentPremiumRelated

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
                                'Call SetMessage("Please select payor title.", eSystemMessage.Warning, True)
                                'Return False
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

                            If Not .TransactionType = eReference.TranType.Regular Then
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

                                If .PayorAddPlaceOfBirth = String.Empty And Not .GpaPaymentTag And .PolMod = "TEL" Then
                                    Call SetMessage("Please enter payor place of birth.", eSystemMessage.Warning, True)
                                    Return False
                                End If
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

                With vwPaymentPremiumRelated

                    'If .OPRNumber = cDataType.fLong.Empty Then
                    '    Call SetMessage("Error in generating OPR Number.", eSystemMessage.Warning, True)
                    '    Return False
                    'End If

                    If .OPRDate = cDataType.fDate.Empty Then
                        Call SetMessage("Error in generating OPR Date.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SourceSite = cDataType.fString.Empty Then
                        Call SetMessage("Please select a Source Site.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Not .IsSourceSiteLocked Then
                        Call SetMessage("Please verify Source Site.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Not .IsGrossAmountLocked Then
                        Call SetMessage("Please verify Gross Amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .TransactionType = cDataType.fString.Empty Then
                        Call SetMessage("Please select transaction type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .OPRGrossAmount = cDataType.fDecimal.Empty Then
                        Call SetMessage("Please enter gross amount.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Not .GpaPaymentTag AndAlso .OPRPaymentType = cDataType.fString.Empty Then
                        Call SetMessage("Please select payment type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .OPRCurrency = cDataType.fString.Empty Then
                        Call SetMessage("Please select currency of payment.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If Not .ECRNumber = cDataType.fLong.Empty OrElse Not .ECRDate = cDataType.fDate.Empty Then
                        If .ECRNumber = cDataType.fLong.Empty OrElse .ECRDate = cDataType.fDate.Empty Then
                            Call SetMessage("Please input proper ECR Details.", eSystemMessage.Warning, True)
                            Return False
                        End If

                        If .ECRDate > cDataType.fDate.Current Then
                            Call SetMessage("Please input proper ECR Date.", eSystemMessage.Warning, True)
                            Return False
                        End If
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPaymentDetails : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPaymentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPayslipCode() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .PayslipCode = String.Empty Then
                        Call SetMessage("Input Payslip Code.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPayslipCode : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaCardID.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidBillNo() As Boolean

            Try

                With vwPaymentPremiumRelated

                    'If .BillNo = String.Empty Then
                    '    Call SetMessage("Input Bill No.", eSystemMessage.Warning, True)
                    '    Return False
                    'End If

                    'If .PolicyNumber = String.Empty Or .NoPolicy Then
                    '    Call SetMessage("Input Policy No.", eSystemMessage.Warning, True)
                    '    Return False
                    'End If
                    If String.IsNullOrWhiteSpace(.PolicyNumber) Then
                        Call SetMessage("Input Policy No.", _
                                        eSystemMessage.Information, True)
                        Return False
                    End If

                    If String.IsNullOrWhiteSpace(.BillNo) AndAlso _
                       String.IsNullOrWhiteSpace(.SubsNo) Then

                        Call SetMessage("Input Bill No. or Subscriber No.", _
                                        eSystemMessage.Information, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidBillNo : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaCardID.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function


        Private Function IsValidGpaCardID() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .GpaPlan = String.Empty Then
                        Call SetMessage("Select Gpa Plan.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .GpaNumber = String.Empty Or Val(.GpaNumber) = 0 Then
                        Call SetMessage("Input card id.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .GpaType = eReference.ColrefGpaRenewal AndAlso Not .GpaSettingsAllowRenewal Then
                        Call SetMessage("Renewal is not Allowed for this GPA Plan", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidGpaCardID : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaCardID.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPaymentPremiumRelated() As Boolean

            Try

                If IsValidForProcessing() AndAlso _
                    IsValidTotals() AndAlso _
                    IsValidPaymentDetails() AndAlso _
                    IsValidPolicyInformation() AndAlso _
                    IsValidOPRDetails() AndAlso _
                    IsValidBalanceToHigher() AndAlso _
                    IsValidAPRDetails() AndAlso _
                    IsValidPaymentDetailsSummary() AndAlso _
                    IsValidVATComputation() _
                Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPaymentPremiumRelated : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPaymentPremiumRelated.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidForProcessing() As Boolean
            Try
                With vwPaymentPremiumRelated
                    Dim objBll As New BLL.OCS.Reference.BOprDetails

                    If Not .DocSaveState = eReference.DocSaveState.Cancel OrElse Not objBll.IsOprProcessed(.OPRNumber, .OPRDate) Then
                        Return True
                    Else
                        Call SetMessage(String.Concat("Premium Payment.<br /><br />", "Cancellation not allowed!<br />Payment was already processed, please reverse via Debit/Credit Memo.<br /><br />"), eSystemMessage.Information, True)
                        Return False
                    End If
                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidForProcessing : ", ex.Message))
            End Try
        End Function

        Private Function IsValidTotals() As Boolean
            Try
                With vwPaymentPremiumRelated
                    If .PaymentTotalAmount = .OPRGrossAmount AndAlso _
                        .ReceiptTotalAmount = .OPRGrossAmount AndAlso _
                        .VATAmountNetWTax = .OPRGrossAmount Then
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


        Private Function IsValidPolicyInformation() As Boolean

            Try

                With vwPaymentPremiumRelated
                    Select Case .TransactionType
                        Case eReference.TranType.GPA

                            If Not IsValidInsured() Then
                                Return False
                            End If

                            If Not IsValidPayor() Then
                                Return False
                            End If

                            If .PolicyNumber = String.Empty Then
                                Call SetMessage("Invalid GPA Card details.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            If Not .GpaCardNoTag Then
                                Call SetMessage("Invalid Card No.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            Select Case .GpaType
                                Case eReference.ColrefGPA, eReference.ColrefGpaRefund
                                    If Not .GpaPremium = .OPRGrossAmount Then
                                        Call SetMessage("Premium amount must be equal to gross amount.", eSystemMessage.Warning, True)
                                        Return False
                                    End If

                                    .AgentSearchTag = eReference.AgentTagType.SalesOfficer
                                    If Not .AgentIDTag Then
                                        Call SetMessage("Please confirm Sales Officer code through Search Button.", eSystemMessage.Warning, True)
                                        Return False
                                    End If

                                    .AgentSearchTag = eReference.AgentTagType.PromoOfficer
                                    If Not .GpaPromoOff = cDataType.fLong.Empty AndAlso Not .AgentIDTag Then
                                        Call SetMessage("Please confirm Promo Officer code through Search Button.", eSystemMessage.Warning, True)
                                        Return False
                                    End If
                                Case eReference.ColrefGpaRenewal
                                    .AgentSearchTag = eReference.AgentTagType.Usd1
                                    If Not .AgentIDTag Then
                                        Call SetMessage("Please confirm USD code through Search Button.", eSystemMessage.Warning, True)
                                        Return False
                                    End If

                                    .AgentSearchTag = eReference.AgentTagType.Asd
                                    If Not .AgentIDTag Then
                                        Call SetMessage("Please confirm ASD code through Search Button.", eSystemMessage.Warning, True)
                                        Return False
                                    End If

                                    If Not .GpaSettingsAllowRenewal Then
                                        Call SetMessage("Renewal is not allowed for this agent.", eSystemMessage.Warning, True)
                                        Return False
                                    End If
                            End Select

                        Case eReference.TranType.NewBusiness

                            .AgentSearchTag = eReference.AgentTagType.Agent
                            If Not (.AgentIDTag Or .NewgenNewBusinessTag) Then
                                Call SetMessage("Please confirm Agent code through Search Button.", eSystemMessage.Warning, True)
                                Return False
                            End If

                            If Not IsValidPayor() Then
                                Return False
                            End If

                            If .WithNewBiz Then
                                If Not .OPRGrossAmount = .NewBizTotalAmount Then
                                    Call SetMessage("Insured premium total must be equal to gross amount.", eSystemMessage.Warning, True)
                                    Return False
                                End If
                            Else
                                If Not IsValidInsured() Then
                                    Return False
                                End If
                            End If

                        Case eReference.TranType.Regular
                            If .PayorName = String.Empty Then
                                Call SetMessage("Please enter payor name.", eSystemMessage.Warning, True)
                                Return False
                            End If

                    End Select
                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPolicyInformation : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPolicyInformation.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidLoadViewOPR() As Boolean

            Try

                With vwPaymentPremiumRelated
                    If .ViewOprFrom > .ViewOprTo Then
                        Call SetMessage("View Date From exceeds Date To.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case .ViewOprFrom
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

                    Select Case .ViewOprTo
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
                Throw New Exception(String.Concat("IsValidLoadViewOPR : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidLoadViewOPR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidVATComputation() As Boolean

            Try

                With vwPaymentPremiumRelated

                    If .VATAmountNetWTax = cDataType.fDecimal.Empty Then
                        Call SetMessage("Invalid VAT computation.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .VATAmountNetWTax > .OPRGrossAmount Then
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

        Private Function CheckIfExisting(ByVal pAction As String, ByVal pCode As String, ByVal pReference As String, ByVal pAmount As Decimal) As Boolean

            Dim intRecCnt As Integer = 0

            Try
                With vwPaymentPremiumRelated
                    Select Case pAction
                        Case "PAYTYPE"
                            For Each item As cPaymentType In .lstPaymentTypeDetails
                                Select Case pCode
                                    Case eReference.PayTypeCCA, eReference.PayTypeDCA
                                        If Not .GpaPaymentTag Then
                                            intRecCnt += 1
                                        End If
                                End Select

                                If item.PaymentType = pCode _
                                And (String.Concat(item.ReferenceNumber, "|", IIf(item.PaymentType = eReference.PayTypeCHQ, item.Bank, item.ApprovalCode)) = pReference) Then
                                    intRecCnt += 1
                                End If
                            Next
                        Case "RECEIPT"
                            For Each item As cReceiptDetail In .lstReceiptDetails
                                If item.TrnxCode = pReference _
                                And item.ActType = pCode Then
                                    intRecCnt += 1
                                End If
                            Next
                    End Select

                    If intRecCnt >= 1 Then Return True
                End With
                Return False
            Catch ex As Exception
                Throw New Exception(String.Concat("CheckIfExisting : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckIfExisting.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

#End Region

#Region "Transactions"

        Private Sub ClearScreenAgent(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .AgentID = cDataType.fLong.Empty
                    .AgentIDTag = False
                    .AgentName = cDataType.fString.Empty
                    .AgentFirstName = cDataType.fString.Empty
                    .AgentMiddleName = cDataType.fString.Empty
                    .AgentLastName = cDataType.fString.Empty
                    .AgencyID = cDataType.fLong.Empty
                    .AgencyName = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAgent.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenAgentDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .AgentSalesForce = cDataType.fString.Empty
                    Select Case .AgentSearchTag
                        Case eReference.AgentTagType.SalesOfficer, eReference.AgentTagType.PromoOfficer
                            .Usd = cDataType.fLong.Empty
                            .UsdName = cDataType.fString.Empty

                            If .GpaSalesOff = cDataType.fLong.Empty AndAlso .GpaUsd1 = cDataType.fLong.Empty _
                            AndAlso .GpaPromoOff = cDataType.fLong.Empty AndAlso .GpaUsd2 = cDataType.fLong.Empty Then
                                .Asd = cDataType.fLong.Empty
                                .AsdName = cDataType.fString.Empty
                            End If
                    End Select
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAgentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenInsured(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .SamePayorInsured = Nothing
                    .InsuredID = cDataType.fLong.Empty
                    '.InsuredIDTag = False
                    .InsuredType = cDataType.fString.Empty
                    .InsuredName = cDataType.fString.Empty
                    .InsuredLastName = cDataType.fString.Empty
                    .InsuredFirstName = cDataType.fString.Empty
                    .InsuredMiddleName = cDataType.fString.Empty
                    .InsuredSuffix = cDataType.fString.Empty
                    .InsuredDateOfBirth = cDataType.fDate.Empty
                    .InsuredTitle = cDataType.fString.Empty
                    .InsuredPlaceOfBirth = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenAddInsured(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .InsuredAddType = cDataType.fString.Empty
                    .InsuredAddLastName = cDataType.fString.Empty
                    .InsuredAddFirstName = cDataType.fString.Empty
                    .InsuredAddMiddleName = cDataType.fString.Empty
                    .InsuredAddSuffix = cDataType.fString.Empty
                    .InsuredAddDateOfBirth = cDataType.fDate.Empty
                    .InsuredAddTitle = cDataType.fString.Empty
                    .InsuredAddPlaceOfBirth = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAddInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    '.SamePayorInsured = Nothing
                    .PayorID = cDataType.fLong.Empty
                    '.PayorIDTag = False
                    .PayorType = cDataType.fString.Empty
                    .PayorName = cDataType.fString.Empty
                    .PayorLastName = cDataType.fString.Empty
                    .PayorFirstName = cDataType.fString.Empty
                    .PayorMiddleName = cDataType.fString.Empty
                    .PayorSuffix = cDataType.fString.Empty
                    .PayorDateOfBirth = cDataType.fDate.Empty
                    .PayorTitle = cDataType.fString.Empty
                    .PayorPlaceOfBirth = cDataType.fString.Empty
                    .PayorTin = cDataType.fString.Empty
                    .PayorAddress = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenAddPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
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
                With vwPaymentPremiumRelated
                    .PayorAddName = IIf(.PayorType = "C", .PayorName, cDataType.fString.Empty)
                    .PayorAddLastName = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorLastName)
                    .PayorAddFirstName = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorFirstName)
                    .PayorAddMiddleName = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorMiddleName)
                    .PayorAddSuffix = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorSuffix)
                    .PayorAddDateOfBirth = IIf(.PayorType = "C", cDataType.fDate.Empty, .PayorDateOfBirth)
                    .PayorAddTitle = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorTitle)
                    .PayorAddPlaceOfBirth = IIf(.PayorType = "C", cDataType.fString.Empty, .PayorPlaceOfBirth)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPayorType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenAPRDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .APRNumber = cDataType.fLong.Empty
                    .APRDate = cDataType.fDate.Empty
                    .APRAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAPRDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenBalanceToHigher(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentPremiumRelated
                    .dtBalanceToHigher = New DataTable
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenBalanceToHigher.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenCheckDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .CheckNumber = cDataType.fLong.Empty
                    .CheckAmount = cDataType.fDecimal.Empty
                    .CheckBankName = cDataType.fString.Empty
                    .CheckBankBranch = cDataType.fString.Empty
                    '.CheckTotalAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenCheckDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenCreditCardDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .CreditCardTerminalUse = cDataType.fString.Empty
                    .CreditCardSwipeDate = cDataType.fDate.Empty
                    .CreditCardMerchant = cDataType.fString.Empty
                    .CreditCardNumberTag = cDataType.fBoolean.Empty
                    .CreditCardNumber = cDataType.fString.Empty
                    .CreditCardType = cDataType.fString.Empty
                    .CreditCardTypeDesc = cDataType.fString.Empty
                    .CreditCardBatchNumber = cDataType.fLong.Empty
                    .CreditCardApprovalCode = cDataType.fString.Empty
                    .CreditCardAmount = cDataType.fDecimal.Empty
                    .CreditCardRemarks = cDataType.fString.Empty
                    '.CreditCardTotalAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenCreditCardDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenCreditCardNumber(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .CreditCardNumberTag = False
                    .CreditCardType = cDataType.fString.Empty
                    .CreditCardTypeDesc = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenCreditCardNumber.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenDebitCardDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .DebitCardTerminalUse = cDataType.fString.Empty
                    .DebitCardSwipeDate = cDataType.fDate.Empty
                    .DebitCardMerchant = cDataType.fString.Empty
                    .DebitCardBankNetwork = cDataType.fString.Empty
                    .DebitCardBankName = cDataType.fString.Empty
                    .DebitCardAccountType = cDataType.fString.Empty
                    .DebitCardAccountNumber = cDataType.fString.Empty
                    .DebitCardBatchNumber = cDataType.fLong.Empty
                    .DebitCardChargeSlip = cDataType.fString.Empty
                    .DebitCardAmount = cDataType.fDecimal.Empty
                    .DebitCardRemarks = cDataType.fString.Empty
                    '.DebitCardTotalAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenDebitCardDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenECashPaymentDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .ECashPaymentChannel = cDataType.fString.Empty
                    .ECashPaymentReferenceNumber = cDataType.fString.Empty
                    .ECashPaymentAmount = cDataType.fDecimal.Empty
                    .ECashPaymentRemarks = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenECashPaymentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub


        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentPremiumRelated
                    .lstReceiptDetails = New List(Of cReceiptDetail)
                    .lstPaymentTypeDetails = New List(Of cPaymentType)
                    .lstNewBiz = New List(Of cNewBiz)

                    .PaymentTypeTag = cDataType.fBoolean.Empty
                    .CashPaymentTag = cDataType.fBoolean.Empty
                    .CheckPaymentTag = cDataType.fBoolean.Empty
                    .CreditCardPaymentTag = cDataType.fBoolean.Empty
                    .DebitCardPaymentTag = cDataType.fBoolean.Empty
                    .GpaPaymentTag = cDataType.fBoolean.Empty
                    .PolicyInfoTag = cDataType.fBoolean.Empty
                    .OPRDetailTag = cDataType.fBoolean.Empty
                    .OPRVatTag = cDataType.fBoolean.Empty
                    .WithNewBiz = cDataType.fBoolean.Empty
                End With

                Call ClearScreenPaymentDetails(sender, e)
                'Call ClearScreenPolicy(sender, e)
                Call ClearScreenGpaPaymentDetails(sender, e)
                Call ClearScreenReceiptDetails(sender, e)
                Call ClearScreenAPRDetails(sender, e)
                Call ClearScreenPaymentTypeDetails(sender, e)
                Call ClearScreenVATComputation(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenPayslipCode(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentPremiumRelated
                    Call ClearScreenPolicy(sender, e)
                    '.PayslipCode = cDataType.fString.Empty
                    .OPRRemarks = cDataType.fString.Empty
                    .WithAPR = False
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPayslipCode.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenBillNo(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentPremiumRelated
                    Call ClearScreenPolicy(sender, e)
                    '.PayslipCode = cDataType.fString.Empty
                    .OPRRemarks = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPayslipCode.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub ClearScreenSubsNo(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentPremiumRelated
                    Call ClearScreenPolicy(sender, e)
                    '.PayslipCode = cDataType.fString.Empty
                    .OPRRemarks = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPayslipCode.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenGpaPaymentDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    Call ClearGpaSettings(sender, e)
                    '.GpaType = cDataType.fInteger.Empty
                    .PolicyNumber = cDataType.fString.Empty
                    .GpaSalesOff = cDataType.fLong.Empty
                    .GpaUsd1 = cDataType.fLong.Empty
                    .GpaUsdName1 = cDataType.fString.Empty
                    .GpaAsd1 = cDataType.fLong.Empty
                    .GpaAsdName2 = cDataType.fString.Empty
                    .GpaPromoOff = cDataType.fLong.Empty
                    .GpaUsd2 = cDataType.fLong.Empty
                    .GpaUsdName2 = cDataType.fString.Empty
                    .GpaAsd2 = cDataType.fLong.Empty
                    .GpaAsdName2 = cDataType.fString.Empty
                    Call ClearScreenGpaCardNo(sender, e)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error h= cdatatype.foccurred.<br /><br />", "Error ClearScreenGpaPaymentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenGpaCardNo(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .GpaCardNo = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error h= cdatatype.foccurred.<br /><br />", "Error ClearScreenGpaCardNo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenGpaDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    Call ClearScreenGpaCardNo(sender, e)
                    .GpaPremium = cDataType.fDecimal.Empty
                    .GpaCoverage = cDataType.fDecimal.Empty
                    .GpaTerm = cDataType.fInteger.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error h= cdatatype.foccurred.<br /><br />", "Error ClearScreenGpaDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearGpaSettings(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .GpaSettingsPolnum = cDataType.fString.Empty
                    .GpaSettingsPlanType = cDataType.fString.Empty
                    .GpaSettingsAllowCom = cDataType.fBoolean.Empty
                    .GpaSettingsAllowPO = cDataType.fBoolean.Empty
                    .GpaSettingsAllowRenewal = cDataType.fBoolean.Empty
                    .GpaSettingsAllowCommSharing = cDataType.fBoolean.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error h= cdatatype.foccurred.<br /><br />", "Error ClearGpaSettings.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenNewBusiness(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .ApplicationNumber = cDataType.fLong.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenNewBusiness.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenNewBizPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .NewBizPayId = cDataType.fLong.Empty
                    .NewBizName = cDataType.fString.Empty
                    .NewBizTotalAmount = cDataType.fDecimal.Empty
                    .lstNewBiz = New List(Of cNewBiz)
                    .PayorIDTag = False

                    Call ClearScreenNewBiz(sender, e)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenNewBizPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenNewBiz(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    '.InsuredIDTag = False
                    .NewBizInsId = cDataType.fLong.Empty
                    .NewBizAmount = cDataType.fDecimal.Empty
                    .NewBizApplNo = cDataType.fLong.Empty
                    .NewBizDoB = cDataType.fDate.Empty
                    .NewBizEcrDate = cDataType.fDate.Empty
                    .NewBizEcrNumber = cDataType.fLong.Empty
                    .NewBizFirstName = cDataType.fString.Empty
                    .NewBizID = cDataType.fString.Empty
                    .NewBizLastName = cDataType.fString.Empty
                    .NewBizMiddleName = cDataType.fString.Empty
                    .NewBizSuffix = cDataType.fString.Empty
                    .NewBizPlaceOfBirth = cDataType.fString.Empty
                    .NewBizSex = cDataType.fString.Empty
                    .NewBizTitle = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenNewBiz.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenReceiptDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .ReceiptIndex = cDataType.fInteger.Empty
                    .ReceiptDetailID = cDataType.fString.Empty
                    .ReceiptTransactionCode = cDataType.fLong.Empty
                    .ReceiptTransactionType = cDataType.fString.Empty
                    .ReceiptTransactionDesc = cDataType.fString.Empty
                    .ReceiptAmount = cDataType.fDecimal.Empty
                    .ReceiptCommissionAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenReceiptDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenPaymentDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .OPRNumber = cDataType.fLong.Empty
                    .OPRDate = cDataType.fDate.Empty
                    .TransactionType = cDataType.fString.Empty
                    .PrevPayType = cDataType.fString.Empty
                    .OPRPaymentType = cDataType.fString.Empty
                    .OPRGrossAmount = cDataType.fDecimal.Empty
                    .OPRCurrency = cDataType.fString.Empty
                    .WithAPR = cDataType.fBoolean.Empty
                    .BalanceToHigher = cDataType.fBoolean.Empty
                    .OPRRemarks = cDataType.fString.Empty
                    .CommissionAmount = cDataType.fDecimal.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPaymentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenCashDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
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
                Call ClearScreenCreditCardDetails(sender, e)
                Call ClearScreenDebitCardDetails(sender, e)
                Call ClearScreenECashPaymentDetails(sender, e)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPaymentTypeDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenPolicy(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .PolicyNumber = cDataType.fString.Empty
                    '.PolicyNumberTag = False
                    .NoPolicy = cDataType.fBoolean.Empty
                    .ModalPremium = cDataType.fDecimal.Empty
                    .CovDue = cDataType.fDate.Empty
                    .CovEff = cDataType.fDate.Empty
                    .CovSta = cDataType.fString.Empty
                    .CovStaDes = cDataType.fString.Empty
                    .PolType = cDataType.fString.Empty
                    .PType = cDataType.fString.Empty
                    .PolCur = "PHP"
                    .PolMod = cDataType.fString.Empty
                    .PolFrq = 1
                    .LastBill = cDataType.fDate.Empty
                    .ServUn = cDataType.fLong.Empty
                    .ECRNumber = cDataType.fLong.Empty
                    .ECRDate = cDataType.fDate.Empty
                    .BalanceToHigher = cDataType.fBoolean.Empty
                    .PayslipCode = cDataType.fString.Empty
                    .BillNo = cDataType.fString.Empty
                    .SubsNo = cDataType.fString.Empty
                    '--------------------------------------------------------------
                    .AgentSearchTag = eReference.AgentTagType.SalesOfficer
                    ClearScreenAgent(sender, e)
                    .AgentSearchTag = eReference.AgentTagType.PromoOfficer
                    ClearScreenAgent(sender, e)
                    .AgentSearchTag = eReference.AgentTagType.Agent
                    ClearScreenAgent(sender, e)
                    ClearScreenInsured(sender, e)
                    ClearScreenPayor(sender, e)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenPolicy.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenVATComputation(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
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

        Private Sub ClearScreenViewAppNo(ByVal sender As Object, ByVal e As EventArgs)

            Try
                vwPaymentPremiumRelated.dtViewAppNo = Nothing
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenViewAppNo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenViewOPR(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .ViewOprFrom = cDataType.fDate.Empty
                    .ViewOprTo = cDataType.fDate.Empty
                    .ViewOprDocNumber = cDataType.fLong.Empty
                    .ViewOprPolicyNumber = cDataType.fString.Empty
                    .ViewOprPayorName = cDataType.fString.Empty
                    .ViewOprInsuredName = cDataType.fString.Empty
                    .dtViewOPR = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenViewOPR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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
                'Throw
            End Try

        End Function

        Private Function GetTrnCod(ByVal pActType As String, ByVal pPayType As String) As String
            Try

                If pPayType = "ECP" Then
                    pPayType = "CSH"
                End If

                Select Case pActType
                    Case "TPREM"
                        Return "RTOPD"
                    Case "MUFND"
                        Return "MUFND"
                End Select

                Select Case pPayType
                    Case eReference.PayTypeCCA
                        Return "CCAPD"
                    Case eReference.PayTypeDCA
                        Return "DCAPD"
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
                'Throw
            End Try
        End Function

        Private Function GetServiceFeeRate(ByVal pPaymentChannel As String) As Decimal
            Try
                Dim objBLL As New bllReference.BParamRef
                Dim dtParam As DataTable
                Dim mReturn As Decimal

                dtParam = objBLL.GetRefECASH

                Dim dtFiltered = From c In dtParam.AsEnumerable
                 Where c.Item("code") = pPaymentChannel _
                 And cDataType.fDate.IfNull(c.Item("sdate")) <= Date.Now.Date _
                 And IIf(IsDBNull(c.Item("edate")), Date.Now.Date, c.Item("edate")) <= Date.Now.Date
                 Select c

                If dtFiltered.Any() Then
                    dtParam = dtFiltered.CopyToDataTable()
                    mReturn = dtParam.Rows(0).Item("numcode")
                Else
                    mReturn = 0
                End If

                Return mReturn
            Catch ex As Exception
                Throw New Exception(String.Concat("GetServiceFeeRate : ", ex.Message))
            End Try
        End Function

        Private Function GetCalcODI(ByVal pPolicyNumber As String, ByVal pTrndat As Date, ByVal pPremium As Decimal, ByVal pPolType As String) As String
            Try
                Dim objBll As New bllReference.BOprDetails
                Dim mReturn As Decimal

                mReturn = objBll.GetCalcODI(pPolicyNumber, pTrndat, pPremium, pPolType)
                Return mReturn
            Catch ex As Exception
                Throw New Exception(String.Concat("GetCalcODI : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function

        Private Function LoadPremiumBreakdown(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBll As New bllReference.BOprDetails
                Dim dtLocal As DataTable
                With vwPaymentPremiumRelated
                    dtLocal = objBll.GetPremiumBreakdown(.PolicyNumber)

                    .dtBalanceToHigher = dtLocal
                End With

            Catch ex As Exception
                Throw New Exception(String.Concat("GetPremiumBreakdown : ", ex.Message))
            End Try
        End Function

        Private Sub GetAgentDetails(ByVal sender As Object, ByVal e As EventArgs) 'FOR USDASD

            Dim objBLLAGNMAS As New bllPerson.BAgnMas
            Dim dtLocal As DataTable

            Try
                With objBLLAGNMAS
                    With vwPaymentPremiumRelated
                        objBLLAGNMAS.GetAgnMas(.AgentID)
                        .AgentCatCod = objBLLAGNMAS.CatCod
                        .AgentSalesForce = objBLLAGNMAS.GetAgentSalesForce(.AgentID, .OPRDate)
                        .AgentTaxRate = objBLLAGNMAS.GetAgentTaxRate(.AgentID, CLng(.OPRDate.ToString("yyyyMM")))
                        If .GpaPaymentTag Then
                            .AgentCommRate = objBLLAGNMAS.GetAgentGpaCommRate(.AgentID, .OPRDate)
                        End If
                        Select Case .AgentSearchTag
                            Case eReference.AgentTagType.SalesOfficer
                                .Usd = objBLLAGNMAS.GetAgentInfo(.AgentID, .OPRDate, 4)
                                .Asd = objBLLAGNMAS.GetAgentInfo(.AgentID, .OPRDate, 6)
                            Case eReference.AgentTagType.PromoOfficer
                                Dim mAsd As Long = objBLLAGNMAS.GetAgentInfo(.AgentID, .OPRDate, 6)
                                If .Asd <> mAsd Then
                                    Call SetMessage("Sales Officer and Promo Officer must be under the same ASD.", eSystemMessage.Information, True)
                                    Call ClearScreenAgent(sender, e)
                                Else
                                    .Usd = objBLLAGNMAS.GetAgentInfo(.AgentID, .OPRDate, 4)
                                End If
                        End Select
                    End With

                    Select Case vwPaymentPremiumRelated.AgentSearchTag
                        Case eReference.AgentTagType.SalesOfficer, eReference.AgentTagType.PromoOfficer
                            If vwPaymentPremiumRelated.Usd <> 0 Then
                                dtLocal = .SearchAgnMas(vwPaymentPremiumRelated.Usd, "", vwPaymentPremiumRelated.OPRDate, vwPaymentPremiumRelated.PolType)
                                If dtLocal.Rows.Count <> 0 Then
                                    For Each dr As DataRow In dtLocal.Rows
                                        vwPaymentPremiumRelated.UsdName = cDataType.fString.IfNull(dr.Item("agnnme"))
                                    Next
                                Else
                                    vwPaymentPremiumRelated.Usd = cDataType.fLong.Empty
                                    vwPaymentPremiumRelated.UsdName = cDataType.fString.Empty
                                    'Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                                End If
                            End If
                            If vwPaymentPremiumRelated.Asd <> 0 Then
                                dtLocal = .SearchAgnMas(vwPaymentPremiumRelated.Asd, "", vwPaymentPremiumRelated.OPRDate, vwPaymentPremiumRelated.PolType)
                                If dtLocal.Rows.Count <> 0 Then
                                    For Each dr As DataRow In dtLocal.Rows
                                        vwPaymentPremiumRelated.AsdName = cDataType.fString.IfNull(dr.Item("agnnme"))
                                    Next
                                Else
                                    vwPaymentPremiumRelated.Asd = cDataType.fLong.Empty
                                    vwPaymentPremiumRelated.AsdName = cDataType.fString.Empty
                                    'Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                                End If
                            End If

                    End Select

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetAgentDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub GetPayorDetails(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLLPRSMAS As New bllPerson.BPrsMas

            Try
                With objBLLPRSMAS
                    .GetPrsMas(IIf(vwPaymentPremiumRelated.WithNewBiz, vwPaymentPremiumRelated.NewBizPayId, vwPaymentPremiumRelated.PayorID))
                    If .IsRecordExist Then
                        If vwPaymentPremiumRelated.WithNewBiz Then
                            vwPaymentPremiumRelated.PayorIDTag = True
                            vwPaymentPremiumRelated.NewBizName = cDataType.fString.IfNull(.PrsNme)
                        Else
                            vwPaymentPremiumRelated.PayorIDTag = True
                            vwPaymentPremiumRelated.PayorType = cDataType.fString.IfNull(.PrsSex)
                            vwPaymentPremiumRelated.PayorName = cDataType.fString.IfNull(.PrsNme)
                            vwPaymentPremiumRelated.PayorLastName = cDataType.fString.IfNull(.PrsLnm)
                            vwPaymentPremiumRelated.PayorFirstName = cDataType.fString.IfNull(.PrsFnm)
                            vwPaymentPremiumRelated.PayorMiddleName = cDataType.fString.IfNull(.PrsMnm)
                            vwPaymentPremiumRelated.PayorSuffix = cDataType.fString.IfNull(.PrsNsf)
                            vwPaymentPremiumRelated.PayorDateOfBirth = cDataType.fDate.IfNull(.PrsDOB)
                            vwPaymentPremiumRelated.PayorTitle = cDataType.fString.IfNull(.PrsTit)
                            vwPaymentPremiumRelated.PayorPlaceOfBirth = cDataType.fString.IfNull(.PrsPlc)
                            vwPaymentPremiumRelated.PayorTin = cDataType.fString.IfNull(.Id_Number)
                            vwPaymentPremiumRelated.PayorAddress = cDataType.fString.IfNull(.AddMas)
                        End If
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPayorDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GetInsuredDetails(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLLPRSMAS As New bllPerson.BPrsMas

            Try
                With objBLLPRSMAS
                    .GetPrsMas(IIf(vwPaymentPremiumRelated.WithNewBiz, vwPaymentPremiumRelated.NewBizInsId, vwPaymentPremiumRelated.InsuredID))
                    If .IsRecordExist Then
                        If vwPaymentPremiumRelated.WithNewBiz Then
                            vwPaymentPremiumRelated.InsuredIDTag = True
                            vwPaymentPremiumRelated.NewBizSex = cDataType.fString.IfNull(.PrsSex)
                            'vwPaymentPremiumRelated.NewBizInsName = cDataType.fString.IfNull(.PrsNme)
                            vwPaymentPremiumRelated.NewBizLastName = cDataType.fString.IfNull(.PrsLnm)
                            vwPaymentPremiumRelated.NewBizFirstName = cDataType.fString.IfNull(.PrsFnm)
                            vwPaymentPremiumRelated.NewBizMiddleName = cDataType.fString.IfNull(.PrsMnm)
                            vwPaymentPremiumRelated.NewBizSuffix = cDataType.fString.IfNull(.PrsNsf)
                            vwPaymentPremiumRelated.NewBizDoB = cDataType.fDate.IfNull(.PrsDOB)
                            vwPaymentPremiumRelated.NewBizTitle = cDataType.fString.IfNull(.PrsTit)
                            vwPaymentPremiumRelated.NewBizPlaceOfBirth = cDataType.fString.IfNull(.PrsPlc)
                        Else
                            vwPaymentPremiumRelated.InsuredIDTag = True
                            vwPaymentPremiumRelated.InsuredType = cDataType.fString.IfNull(.PrsSex)
                            vwPaymentPremiumRelated.InsuredName = cDataType.fString.IfNull(.PrsNme)
                            vwPaymentPremiumRelated.InsuredLastName = cDataType.fString.IfNull(.PrsLnm)
                            vwPaymentPremiumRelated.InsuredFirstName = cDataType.fString.IfNull(.PrsFnm)
                            vwPaymentPremiumRelated.InsuredMiddleName = cDataType.fString.IfNull(.PrsMnm)
                            vwPaymentPremiumRelated.InsuredSuffix = cDataType.fString.IfNull(.PrsNsf)
                            vwPaymentPremiumRelated.InsuredDateOfBirth = cDataType.fDate.IfNull(.PrsDOB)
                            vwPaymentPremiumRelated.InsuredTitle = cDataType.fString.IfNull(.PrsTit)
                            vwPaymentPremiumRelated.InsuredPlaceOfBirth = cDataType.fString.IfNull(.PrsPlc)
                        End If
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetInsuredDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub GetPolicyDetails(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBllSearch As New bllSearch.BSearch
            Dim objBLLAGNMAS As New bllPerson.BAgnMas
            Dim dtLocal As DataTable

            Try
                With vwPaymentPremiumRelated
                    If .NewBusinessTag And Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Life"), "false")) Then
                        .NewgenNewBusinessTag = True
                        dtLocal = objBllSearch.GetNBPolicyNewgen(.PolicyNumber, .ApplicationNumber)
                        If dtLocal.Rows.Count <> 0 Then
                            For Each dr As DataRow In dtLocal.Rows
                                .PolicyNumber = cDataType.fString.IfNull(dr.Item("policy_no"))
                                .PayorIDTag = True
                                .PayorID = cDataType.fLong.IfNull(dr.Item("payor_id"))
                                .PayorName = cDataType.fString.IfNull(dr.Item("payor_name"))
                                .InsuredID = cDataType.fLong.IfNull(dr.Item("insured_id"))
                                .InsuredName = cDataType.fString.IfNull(dr.Item("insured_name"))
                                If .PayorID = .InsuredID And .PayorID > 0 Then .SamePayorInsured = "Y"
                                .AgentID = cDataType.fLong.IfNull(dr.Item("agent_id"))
                                .AgentSalesForce = objBLLAGNMAS.GetAgentSalesForce(.AgentID, .OPRDate)
                                .AgentName = cDataType.fString.IfNull(dr.Item("agent_name"))
                                .AgencyID = cDataType.fLong.IfNull(dr.Item("agency_id"))
                                .AgencyName = cDataType.fString.IfNull(dr.Item("agency_name"))
                                .CovDue = cDataType.fDate.IfNull(dr.Item("current_due_date"))
                                .CovEff = cDataType.fDate.IfNull(dr.Item("issue_date"))
                                .CovSta = cDataType.fString.IfNull(dr.Item("policy_status"))
                                .CovStaDes = cDataType.fString.IfNull(dr.Item("policy_status"))
                                .PolCur = cDataType.fString.IfNull(dr.Item("plan_currency"))
                                .PolType = "R" 'GetPolTyp(dr.Item("business_type"))
                                .PType = "R" 'GetPType(dr.Item("business_type"))
                                .PolMod = "PNO" 'cDataType.fString.IfNull(dr.Item("business_type"))
                                .PolFrq = GetPolicyFrequency(dr.Item("frequency_of_payment"))

                                .PayorAddress = cDataType.fLong.IfNull(dr.Item("address"))
                                .PayorTin = cDataType.fLong.IfNull(dr.Item("tin_no"))

                            Next
                        Else
                            .PolicyNumber = cDataType.fLong.Empty
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    Else
                        dtLocal = objBllSearch.GetPolicy(.PolicyNumber, .PolType)
                        If dtLocal.Rows.Count <> 0 Or .PolicyNumber.IndexOf("-") > -1 Then
                            For Each dr As DataRow In dtLocal.Rows
                                .PolicyNumber = cDataType.fString.IfNull(dr.Item("polnum"))
                                .ModalPremium = cDataType.fDecimal.IfNull(dr.Item("modal_premium"))
                                .PayorIDTag = True
                                .PayorID = cDataType.fLong.IfNull(dr.Item("payor_id"))
                                .PayorType = cDataType.fString.IfNull(dr.Item("payor_sex"))
                                .PayorName = cDataType.fString.IfNull(dr.Item("payor_name"))
                                .PayorFirstName = cDataType.fString.IfNull(dr.Item("payor_fnam"))
                                .PayorLastName = cDataType.fString.IfNull(dr.Item("payor_lnam"))
                                .PayorMiddleName = cDataType.fString.IfNull(dr.Item("payor_mnam"))
                                .InsuredID = cDataType.fLong.IfNull(dr.Item("insured_id"))
                                .InsuredName = cDataType.fString.IfNull(dr.Item("insured_name"))
                                .InsuredFirstName = cDataType.fString.IfNull(dr.Item("insured_fnam"))
                                .InsuredLastName = cDataType.fString.IfNull(dr.Item("insured_lnam"))
                                .InsuredMiddleName = cDataType.fString.IfNull(dr.Item("insured_mnam"))
                                If .PayorID = .InsuredID And .PayorID > 0 Then .SamePayorInsured = "Y"
                                .AgentID = cDataType.fLong.IfNull(dr.Item("agent_id"))
                                .AgentSalesForce = objBLLAGNMAS.GetAgentSalesForce(.AgentID, .OPRDate)
                                .AgentFirstName = cDataType.fString.IfNull(dr.Item("agent_fnam"))
                                .AgentLastName = cDataType.fString.IfNull(dr.Item("agent_lnam"))
                                .AgentMiddleName = cDataType.fString.IfNull(dr.Item("agent_mnam"))
                                .AgentName = cDataType.fString.IfNull(dr.Item("agent_name"))
                                .AgencyID = cDataType.fLong.IfNull(dr.Item("agency_id"))
                                .AgencyName = cDataType.fString.IfNull(dr.Item("agency_name"))
                                .AgencyFirstName = cDataType.fString.IfNull(dr.Item("agency_fnam"))
                                .AgencyLastName = cDataType.fString.IfNull(dr.Item("agency_lnam"))
                                .AgencyMiddleName = cDataType.fString.IfNull(dr.Item("agency_mnam"))
                                .CovDue = cDataType.fDate.IfNull(dr.Item("covdue"))
                                .CovEff = cDataType.fDate.IfNull(dr.Item("coveff"))
                                .CovSta = cDataType.fString.IfNull(dr.Item("covsta"))
                                .CovStaDes = cDataType.fString.IfNull(dr.Item("stades"))
                                .PolCur = cDataType.fString.IfNull(dr.Item("polcur"))
                                .PolType = GetPolTyp(dr.Item("polmod"))
                                .PType = GetPType(dr.Item("polmod"))
                                .PolMod = cDataType.fString.IfNull(dr.Item("polmod"))
                                .PolFrq = cDataType.fInteger.IfNull(dr.Item("polfrq"))
                                .LastBill = cDataType.fDate.IfNull(dr.Item("lastbl"))
                                .ServUn = cDataType.fLong.IfNull(dr.Item("servun"))

                                .PayorAddress = cDataType.fString.IfNull(dr.Item("address"))
                                .PayorTin = cDataType.fString.IfNull(dr.Item("tin_no"))
                            Next
                        Else
                            .PolicyNumber = cDataType.fLong.Empty
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPolicyDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GetPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim cptLocal As New cPaymentType

            Try
                With vwPaymentPremiumRelated
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
                            Case eReference.PayTypeCCA
                                .CreditCardAmount = cptLocal.Amount
                                .CreditCardTerminalUse = cptLocal.TerminalUse
                                .CreditCardSwipeDate = cptLocal.SwipeDate
                                .CreditCardSwipeTime = cptLocal.SwipeDate
                                .CreditCardMerchant = cptLocal.MerchantID
                                .CreditCardNumber = cptLocal.CardNumber
                                Call ValidateCreditCardNo(sender, e)
                                .CreditCardBatchNumber = cptLocal.BatchNumber
                                .CreditCardApprovalCode = cptLocal.ApprovalCode
                                .CreditCardRemarks = cptLocal.Remarks
                            Case eReference.PayTypeDCA
                                .DebitCardAmount = cptLocal.Amount
                                .DebitCardTerminalUse = cptLocal.TerminalUse
                                .DebitCardSwipeDate = cptLocal.SwipeDate
                                .DebitCardSwipeTime = cptLocal.SwipeDate
                                .DebitCardMerchant = cptLocal.MerchantID
                                .DebitCardBankNetwork = cptLocal.Network
                                .DebitCardBankName = cptLocal.Bank
                                .DebitCardAccountType = cptLocal.CASA
                                .DebitCardAccountNumber = cptLocal.AccountNumber
                                .DebitCardBatchNumber = cptLocal.BatchNumber
                                .DebitCardChargeSlip = cptLocal.ApprovalCode
                                .DebitCardRemarks = cptLocal.Remarks
                            Case eReference.PayTypeECP
                                .ECashPaymentAmount = cptLocal.Amount
                                .ECashPaymentChannel = cptLocal.PaymentChannel
                                .ECashPaymentRemarks = cptLocal.Remarks
                                .ECashPaymentReferenceNumber = cptLocal.ReferenceID
                            Case Else
                        End Select
                    Next
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPaymentTypeDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        ' -------------------------------------------------------------------------------

        Private Sub LoadFrequencyOfPayment(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BFrqPay
                vwPaymentPremiumRelated.dtFrequencyOfPayment = objBLL.GetRefFrqPayList
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadFrequencyOfPayment.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadNewFrequency(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BFrqPay
                vwPaymentPremiumRelated.dtBalanceFrequency = objBLL.GetRefFrqPayList
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadFrequencyOfPayment.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadBusinessType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BMetPay
                With vwPaymentPremiumRelated
                    .dtBusinessType = objBLL.GetRefMetPayList(.TransactionType, .PolType, eReference.DocTypeOPR)
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBusinessType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadAllowedPaymentType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBll As New bllReference.BMetPay
                Dim dtLocal As DataTable


                With vwPaymentPremiumRelated
                    dtLocal = objBll.GetRefMetPayList(.TransactionType, .PolType, eReference.DocTypeOPR)
                    Dim dtFiltered = From c In dtLocal.AsEnumerable
                                     Where c.Item("metcod") = .PolMod
                                     Select c

                    For Each dr In dtFiltered
                        .PaymentTypeAllowedArray = String.Concat(dr.Item("cash_flg"), "|", dr.Item("chk_flg"), "|", dr.Item("cca_flg"), "|", dr.Item("dca_flg"))
                    Next

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadAllowedPaymentType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Function GetPolTyp(ByVal pMetCod As String) As String
            Try
                Dim objBll As New bllReference.BMetPay
                Dim mReturn As String

                mReturn = objBll.GetPolTyp(pMetCod, eReference.DocTypeOPR)
                Return mReturn
            Catch ex As Exception
                Throw New Exception(String.Concat("GetPolTyp : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPolTyp.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function

        Private Function GetPolicyFrequency(ByVal pPolFrq As String) As Integer
            Try
                Select Case UCase(pPolFrq)
                    Case "ANNUALLY", "ANNUAL" : Return 1
                    Case "SEMI-ANNUALLY", "SEMI-ANNUAL" : Return 2
                    Case "QUARTERLY", "QUARTER" : Return 4
                    Case "MONTHLY", "MONTH" : Return 12
                    Case Else : Return 1
                End Select
            Catch ex As Exception
                Throw New Exception(String.Concat("GetPolicyFrequency: ", ex.Message))
            End Try
        End Function

        Private Function GetPType(ByVal pMetCod As String) As String
            Try
                Dim objBll As New bllReference.BMetPay
                Dim mReturn As String

                mReturn = objBll.GetPType(pMetCod, eReference.DocTypeOPR)
                Return mReturn
            Catch ex As Exception
                Throw New Exception(String.Concat("GetPType : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetPType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Function

        Private Sub LoadPaymentType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentPremiumRelated.dtPaymentType = objBLL.GetRefPAYTYP
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPaymentType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPersonType(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BPrsRef

            Try
                vwPaymentPremiumRelated.dtPayorType = objBLL.GetRefPrsRefPrsTyp
                vwPaymentPremiumRelated.dtInsuredType = objBLL.GetRefPrsRefSexTyp
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPersonType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPersonTitle(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BParamRef

            Try
                vwPaymentPremiumRelated.dtPersonTitle = objBLL.GetRefPRSTIT
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPersonTitle.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Function CheckAllowedPaytype(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentPremiumRelated

                    Dim arrAllowdPayType = Split(.PaymentTypeAllowedArray, "|")
                    Dim blnReturn As Boolean

                    .IsPayTypeSuccessful = False

                    Select Case .OPRPaymentType
                        Case eReference.PayTypeCSH
                            blnReturn = arrAllowdPayType(0)

                        Case eReference.PayTypeCHQ
                            blnReturn = arrAllowdPayType(1)

                        Case eReference.PayTypeCCA
                            blnReturn = arrAllowdPayType(2)

                        Case eReference.PayTypeDCA
                            blnReturn = arrAllowdPayType(3)

                        Case Else
                            blnReturn = True

                    End Select

                    .IsPayTypeSuccessful = blnReturn

                    If .IsPayTypeSuccessful = False Then
                        Call SetMessage("Payment Type not allowed for this Business Type.", eSystemMessage.Warning, True)
                    End If

                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckAllowedPaytype.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Sub CheckPrevPaytype(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentPremiumRelated

                    Select Case .lstPaymentTypeDetails.Count
                        Case Is > 0
                            If .PrevPayType = .OPRPaymentType Or .GpaPaymentTag Then 'Or .NewBusinessTag Then
                                .IsPayTypeSuccessful = True
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

        Private Function CheckForAgentOr(ByVal pAgentCode As Long) As Boolean

            Dim objBLL As New bllPerson.BAgnMas

            Try

                With vwPaymentPremiumRelated
                    Return objBLL.GetAgentOR(pAgentCode)
                End With

            Catch ex As Exception
                Throw New Exception(String.Concat("CheckForAgentOr : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckForAgentOr.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function CheckVlCommission(ByVal pPolicy As String) As Boolean

            Dim objBLL As New bllSearch.BSearch

            Try

                With vwPaymentPremiumRelated
                    Return objBLL.IsVlPlanRegular(pPolicy)
                End With

            Catch ex As Exception
                Throw New Exception(String.Concat("CheckVlCommission : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckVlCommission.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Sub CheckModalPremium(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentPremiumRelated

                    Select Case .ModalPremium
                        Case Is > .OPRGrossAmount
                            Call SetMessage("Payment is less than modal premium. Make sure to select correct transaction!", eSystemMessage.Warning, True)
                        Case Is < .OPRGrossAmount
                            Call SetMessage("Payment is greater than modal premium. Make sure to distribute to correct transactions!", eSystemMessage.Warning, True)
                        Case Is = .OPRGrossAmount
                    End Select

                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckModalPremium.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub CheckGrossAmount(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentPremiumRelated
                    .IsSuccessful = False

                    If .OPRGrossAmount <= 0 Then
                        Call SetMessage("Gross Amount should be greater than zero(0).", eSystemMessage.Warning, True)
                        Return
                    End If

                    .IsSuccessful = True
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckGrossAmount.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub CheckSourceSite(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentPremiumRelated
                    .IsSuccessful = False

                    If .SourceSite = String.Empty Then
                        Call SetMessage("Please select a Source Site.", eSystemMessage.Warning, True)
                        Return
                    End If

                    .IsSuccessful = True
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckSourceSite.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadGpaPolicy(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BGpaDetails

                With vwPaymentPremiumRelated

                    objBLL.GetGpaSettings(.AgentSalesForce, .AgentCatCod)
                    .GpaSettingsPolnum = objBLL.PolicyNumber
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadGpaPolicy.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadGpaSettings(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BGpaDetails

                With vwPaymentPremiumRelated

                    objBLL.GetGpaSettings(.AgentSalesForce, .AgentCatCod, .GpaPlan)

                    .GpaSettingsPlanType = objBLL.Plan
                    .GpaSettingsAllowCom = objBLL.IsAllowComm
                    .GpaSettingsAllowPO = objBLL.IsPromoOff
                    .GpaSettingsAllowRenewal = objBLL.IsRenewable
                    .GpaSettingsAllowCommSharing = objBLL.IsAllowCommSharing

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadGpaSettings.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadGpaRenewalAsd(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BParamRef
                Dim dtLocal As New DataTable

                With vwPaymentPremiumRelated
                    dtLocal = objBLL.GetRefGpaAsd
                    For Each dr As DataRow In dtLocal.Rows
                        .Asd = cDataType.fLong.IfNull(dr.Item("CODE"))
                        Exit For
                    Next
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadGpaRenewalAsd.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadSourceSite(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BSiteDetails
                vwPaymentPremiumRelated.dtSourceSite = objBLL.LoadSourceSite()
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSourceSite.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadCurrency(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BCurRef
                vwPaymentPremiumRelated.dtCurrency = objBLL.GetRefCurRefList
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadCurrency.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadTransactionType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentPremiumRelated.dtTransactionType = objBLL.GetRefTRNTYP
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadTransactionType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPolicyType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentPremiumRelated.dtPolicyType = objBLL.GetRefPOLTYP
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPolicyType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadGpaType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentPremiumRelated.dtGpaType = objBLL.GetRefGPATYPE
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadGpaType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadReceiptTransaction(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BTrnRef
                Dim dtLocal As New DataTable
                Dim mPaymentType As String

                With vwPaymentPremiumRelated
                    .PType = GetPType(.PolMod)

                    If .OPRPaymentType = "ECP" Then
                        mPaymentType = "CSH"
                    Else
                        mPaymentType = .OPRPaymentType
                    End If

                    dtLocal = objBLL.GetRefTrnRefList(mPaymentType, .TransactionType, .PType, eReference.DocTypeOPR)
                    If .GpaPaymentTag Then
                        Dim dtFiltered = dtLocal.AsEnumerable.Where(Function(x) x.Item("colref") = .GpaType)
                        'Dim dtFiltered = From c In dtLocal.AsEnumerable
                        'Where c.Item("colref") = .GpaType
                        'Select c
                        If dtFiltered.Any() Then
                            .dtReceiptTransaction = dtFiltered.CopyToDataTable()
                        Else
                            .dtReceiptTransaction = New DataTable
                        End If
                    Else
                        'Dim objBLLParamRef As New bllReference.BParamRef
                        'Dim dtParamRef As New DataTable

                        'dtParamRef = objBLLParamRef.GetRefOcsDtl()
                        'If dtParamRef.AsEnumerable.Where(Function(x) x.Item("code") = .PolMod).Any() Then
                        '    Dim dtFiltered = From c In dtLocal.AsEnumerable
                        '                     Join p In dtParamRef.AsEnumerable On CLng(c.Item("colref")) Equals CLng(p.Item("numcode"))
                        '                     Select c
                        '    If dtFiltered.Any() Then
                        '        .dtReceiptTransaction = dtFiltered.CopyToDataTable()
                        '    Else
                        '        .dtReceiptTransaction = New DataTable
                        '    End If
                        'Else
                        .dtReceiptTransaction = dtLocal
                        'End If

                    End If

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadReceiptTransaction.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GetReceiptTransactionDetails(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBll As New bllReference.BTrnRef
                With vwPaymentPremiumRelated
                    objBll.GetReceiptTransactionDetails(.ReceiptTransactionCode, eReference.DocTypeOPR)
                    .ReceiptTransactionDesc = objBll.Coldes
                    .ReceiptTransactionType = objBll.Pctref
                    .ReceiptTransactionVat = objBll.Vatable
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetReceiptTransactionDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub CheckReceiptTransaction(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBll As New bllReference.BParamRef
                With vwPaymentPremiumRelated
                    .IsSuccessful = True
                    Select Case .ReceiptTransactionType
                        Case "ODINT"
                            Dim today = .OPRDate
                            ' Calculate the age.
                            Dim age = today.Year - .CovDue.Year
                            ' Go back to the year the person was born in case of a leap year
                            If .CovDue > today.AddYears(-age) Then
                                age -= 1
                            End If
                            If age < 3 Then
                                '.ReceiptAmount = GetCalcODI(.PolicyNumber, .OPRDate, .ModalPremium, .PolType)
                            Else
                                SetMessage(String.Concat("Invalid Transaction.<br /><br />", "Policy is not within Reinstatable Period<br />"), eSystemMessage.Information, True)
                                .IsSuccessful = False
                            End If
                        Case "REINF"
                            Dim today = .OPRDate
                            ' Calculate the age.
                            Dim age = today.Year - .CovDue.Year
                            ' Go back to the year the person was born in case of a leap year
                            If .CovDue > today.AddYears(-age) Then
                                age -= 1
                            End If
                            If age < 3 Then
                                '.ReceiptAmount = .ModalPremium
                            Else
                                SetMessage(String.Concat("Invalid Transaction.<br /><br />", "Policy is not within Reinstatable Period<br />"), eSystemMessage.Information, True)
                                .IsSuccessful = False
                            End If
                            'End If
                        Case "PREMM"
                            Select Case .ReceiptTransactionCode
                                Case eReference.ColrefAgentsAccount

                                Case Else
                                    If .BalanceToHigher Then
                                        .ReceiptAmount = .NewPremium
                                    Else
                                        .ReceiptAmount = .ModalPremium
                                    End If
                            End Select
                    End Select
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckReceiptTransaction.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadGpaPlan(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBll As New bllReference.BGpaDetails
                With vwPaymentPremiumRelated
                    .AgentSearchTag = IIf(.GpaType = eReference.ColrefGpaRenewal, eReference.AgentTagType.Usd1, eReference.AgentTagType.SalesOfficer)
                    .dtGpaPlan = objBll.GetGpaPlanList(.SourceSite, .AgentSalesForce)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadGpaPlan.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadGpaCardNo(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BGpaDetails
            Dim mIsRenewal As Boolean

            Try
                If IsValidGpaCardID() Then
                    With vwPaymentPremiumRelated
                        .IsGpaCardNoExist = False
                        objBLL.SearchPaCardId(.GpaPlan, .GpaNumber)

                        If .GpaType = eReference.ColrefGpaRenewal AndAlso .GpaSettingsAllowRenewal Then
                            mIsRenewal = True
                        End If

                        .IsGpaCardNoExist = objBLL.IsRecordExist
                        If .IsGpaCardNoExist Then
                            If Not (.DocSaveState = eReference.DocSaveState.AddNew Or .DocSaveState = eReference.DocSaveState.Edit) OrElse (objBLL.DocNumber = 0 OrElse objBLL.DocNumber = .OPRNumber OrElse mIsRenewal) Then
                                If objBLL.CardSite = .SourceSite OrElse mIsRenewal Then
                                    .GpaPlan = objBLL.Plan
                                    .GpaNumber = objBLL.CardNo
                                    .GpaPremium = objBLL.PremiumAmount
                                    .GpaCoverage = objBLL.CoverageAmount
                                    .GpaTerm = objBLL.CoverageTerm
                                Else
                                    .IsGpaCardNoExist = False
                                    Call ClearScreenGpaDetails(sender, e)
                                    Call SetMessage("Card does not belong to your site.", eSystemMessage.Information, True)
                                End If
                            Else
                                .IsGpaCardNoExist = False
                                Call ClearScreenGpaDetails(sender, e)
                                Call SetMessage("Card Number already used.", eSystemMessage.Information, True)
                            End If

                        Else
                            .IsGpaCardNoExist = False
                            Call ClearScreenGpaDetails(sender, e)
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    End With
                End If
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadGpaCardNo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPayslipCode(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BHMOPayslip

            Try
                If IsValidPayslipCode() Then
                    With vwPaymentPremiumRelated
                        .IsPayslipCodeExist = False
                        objBLL.SearchPayslipCode(.PayslipCode)

                        .IsPayslipCodeExist = objBLL.IsRecordExist
                        If .IsPayslipCodeExist Then
                            If IsNumeric(objBLL.AprNumber) Then
                                .WithAPR = True
                                .APRNumber = objBLL.AprNumber
                                .APRDate = objBLL.AprDate
                                .APRAmount = objBLL.RemitAmount
                            End If
                            .CheckNumber = objBLL.CheckNumber
                            .PayorName = objBLL.PayorName
                            .PayorFirstName = objBLL.PayorName
                            .OPRGrossAmount = objBLL.RemitAmount
                            .OPRRemarks = String.Concat(objBLL.PolicyNumber, " - ", objBLL.PayslipCode)
                            '.TotDeductibles = objBLL.TotDeductibles
                            '.NetPayment = objBLL.NetPayment
                            '.Particulars = objBLL.Particulars
                            '.ChargeTo = objBLL.ChargeTo
                            '.PolFrq = objBLL.PaymentMode
                            '.UserName = objBLL.UserName
                            '.Ewt = objBLL.Ewt
                            .PolicyNumber = objBLL.PolicyNumber
                            .PayslipCode = objBLL.PayslipCode
                            .PolMod = "HMO"

                            .PayorTin = objBLL.PayorTin
                            .PayorAddress = objBLL.PayorAddress

                            If objBLL.CheckNumber Then
                                .OPRPaymentType = eReference.PayTypeCHQ
                                .CheckNumber = objBLL.CheckNumber
                                .CheckBankName = objBLL.IssuingBank
                                .CheckBankBranch = objBLL.IssuingBranch
                                .CheckAmount = objBLL.RemitAmount
                            End If
                            '.OrNumber = objBLL.OrNumber
                            '.PaymentType = objBLL.PaymentType
                            '.CheckDate = objBLL.CheckDate
                            '.CheckBankName = objBLL.IssuingBank
                            '.Income = objBLL.Income
                            '.VATableCollection = objBLL.VatableAmt
                            '.VATExemptCollection = objBLL.VatExempt
                            '.VATAmount = objBLL.VatAmount
                            '.IssuedBy = objBLL.IssuedBy
                        Else
                            .IsPayslipCodeExist = False
                            Call ClearScreenPayslipCode(sender, e)
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                            .PolType = "G"
                        End If
                    End With
                End If
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPayslipCode.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadPolicyBilling(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BNGIBillingDetails
            Dim dateValue As DateTime


            Try
                If IsValidBillNo() Then
                    With vwPaymentPremiumRelated
                        .IsBillNoExist = False
                        objBLL.GetPolicyBilling(.PolicyNumber, .BillNo, .SubsNo)

                        .IsBillNoExist = objBLL.IsRecordExist

                        If .IsBillNoExist Then
                            If Left(objBLL.PolicyNo, 1) = "M" Then
                                .PolMod = "MWI"
                            Else
                                .PolMod = "GLF"
                            End If
                            .PolicyNumber = objBLL.PolicyNo
                            .BillNo = objBLL.BillNo

                            '/*I#A1: Handle Null values returned from API (for Dates)

                            'Coverage From
                            If DateTime.TryParse(Convert.ToString(objBLL.CovFrm), dateValue) Then
                                .CovEff = dateValue
                            End If

                            'Coverage To
                            If DateTime.TryParse(Convert.ToString(objBLL.CovTo), dateValue) Then
                                .CovDue = dateValue
                            End If
                            '*/I#A1
                            .CovStaDes = objBLL.PolicyStatus
                            '/*C#A1: Uncomment to reflect the particulars from NG Group API
                            'If .DocSaveState = eReference.DocSaveState.AddNew _
                            'Or .DocSaveState = eReference.DocSaveState.Edit Then
                            '    .OPRGrossAmount = objBLL.BillAmount
                            '    Dim mCptDtlList As New List(Of cPaymentType)
                            '    Dim mCashAmount As Decimal = cDataType.fDecimal.IfNull(objBLL.BillAmount)

                            '    If mCashAmount > 0 Then
                            '        mCptDtlList.Add(New cPaymentType(mCashAmount))
                            '        AddToTotalAmount(eReference.PayTypeCSH, mCashAmount)
                            '    End If

                            '    .OPRPaymentType = eReference.PayTypeCSH
                            '    .PrevPayType = eReference.PayTypeCSH
                            '    .lstPaymentTypeDetails = mCptDtlList
                            'End If
                            '/*C#A1
                            .InsuredName = objBLL.AccountName
                            .AgentName = objBLL.SourceName
                            .PolFrq = GetPolicyFrequency(objBLL.FrequencyOfPayment)
                            .PolCur = objBLL.PlanCurrency
                            .PayorName = objBLL.PayorName
                            .PayorFirstName = objBLL.PayorName
                            .PayorAddress = objBLL.Address
                            .PayorTin = objBLL.Tin




                            '/*C#A2: Uncomment to reflect the Remarks from NG Group API
                            '.OPRRemarks = String.Concat(.PolicyNumber, " - ", .BillNo)
                            '*/C#A2
                            '/*C#A1
                            'If Not String.IsNullOrWhiteSpace(objBLL.ParticularsRaw) Then
                            '    Dim mRptDtl As New List(Of cReceiptDetail)
                            '    Dim dtParticulars As DataTable

                            '    dtParticulars = BuildReceiptDetailsFromParticulars(objBLL.ParticularsRaw, .OPRDate)

                            '    For Each dr As DataRow In dtParticulars.Rows
                            '        mRptDtl.Add(New cReceiptDetail(dr, eReference.DocTypeOPR))
                            '        AddToTotalAmount(eReference.DocTypeOPR, cDataType.fDecimal.IfNull(dr.Item("amount")))
                            '    Next

                            '    .lstReceiptDetails = mRptDtl
                            'End If
                            '*/C#A1
                        Else
                            .IsBillNoExist = False
                            Call ClearScreenBillNo(sender, e)
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                            .PolType = "G"
                        End If
                    End With
                End If
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPolicyBilling.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Function BuildReceiptDetailsFromParticulars(ByVal particularsRaw As String,
                                                     ByVal dueDate As Date) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("trnx_code", GetType(Long))
            dt.Columns.Add("act_type", GetType(String))
            dt.Columns.Add("trnx_desc", GetType(String))
            dt.Columns.Add("due_date", GetType(Date))
            dt.Columns.Add("amount", GetType(Decimal))
            dt.Columns.Add("line_nmbr", GetType(Integer))

            If String.IsNullOrWhiteSpace(particularsRaw) Then Return dt

            Dim rows() As String = particularsRaw.Split(New String() {"},{"}, StringSplitOptions.None)
            Dim lineNo As Integer = 1

            For Each rawItem As String In rows
                Dim item As String = rawItem.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "")

                Dim dr As DataRow = dt.NewRow()

                dr("trnx_code") = lineNo
                dr("act_type") = GetJsonValue(item, "PARTICULARS")
                dr("trnx_desc") = GetJsonValue(item, "SUB_TYPE")
                dr("due_date") = dueDate
                dr("amount") = CDec(Val(GetJsonValue(item, "AMOUNT")))
                dr("line_nmbr") = lineNo

                dt.Rows.Add(dr)
                lineNo += 1
            Next

            Return dt
        End Function
        Private Function GetJsonValue(ByVal item As String, ByVal key As String) As String
            Dim search As String = """" & key & """:"
            Dim startIndex As Integer = item.IndexOf(search)

            If startIndex < 0 Then Return ""

            startIndex += search.Length

            Dim value As String = item.Substring(startIndex)

            If value.StartsWith("""") Then
                value = value.Substring(1)
                Dim endIndex As Integer = value.IndexOf("""")
                If endIndex >= 0 Then Return value.Substring(0, endIndex)
            Else
                Dim endIndex As Integer = value.IndexOf(",")
                If endIndex >= 0 Then
                    Return value.Substring(0, endIndex).Trim()
                Else
                    Return value.Trim()
                End If
            End If

            Return ""
        End Function

        'Private Sub LoadTerminalUseCCA(ByVal sender As Object, ByVal e As EventArgs)

        '    Try
        '        Dim objBLL As New bllReference.BParamRef
        '        vwPaymentPremiumRelated.dtTerminalUseCCA = objBLL.GetRefOcsTerminalUseCCA
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadTerminalUseCCA.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        'Private Sub LoadTerminalUseDCA(ByVal sender As Object, ByVal e As EventArgs)

        '    Try
        '        Dim objBLL As New bllReference.BParamRef
        '        vwPaymentPremiumRelated.dtTerminalUseDCA = objBLL.GetRefOcsTerminalUseDCA
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadTerminalUseDCA.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        Private Sub LoadMerchantId(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BMerchantSite
                With vwPaymentPremiumRelated
                    .dtMerchantId = objBLL.GetRefMerchantSiteList(.SourceSite)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadMerchantId.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadBankNetwork(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentPremiumRelated.dtBankNetwork = objBLL.GetRefOcsBankNetwork
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBankNetwork.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadAccountType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentPremiumRelated.dtAccountType = objBLL.GetRefOcsAccountType
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadAccountType.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadApplicationNo(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BOprDetails

                With vwPaymentPremiumRelated
                    If .WithNewBiz Then
                        If .NewBizApplNo = 0 Then
                            If .ApplicationNumber = 0 Then
                                .NewBizApplNo = objBLL.GetNewApplicationNo
                            Else
                                .NewBizApplNo = .ApplicationNumber
                            End If
                            .ApplicationNumber = 0
                        End If
                    Else
                        If .ApplicationNumber = 0 Then
                            If .NewBizApplNo = 0 Then
                                .ApplicationNumber = objBLL.GetNewApplicationNo
                            Else
                                .ApplicationNumber = .NewBizApplNo
                            End If
                            .NewBizApplNo = 0
                        End If
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadApplicationNo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadNewOPR(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BOprDetails
                With vwPaymentPremiumRelated
                    .IsSuccessful = False

                    objBLL.LoadNewOPR(vwPaymentPremiumRelated.SiteCode, eReference.ReceiptType.CI, vwPaymentPremiumRelated.UserID)

                    .IsSuccessful = True
                    .OPRNumber = 0 'objBLL.OPRNumber
                    .OPRDate = objBLL.OPRDate.ToShortDateString
                End With

            Catch ex As ArgumentException
                Call SetMessage(String.Concat("New OPR is not Allowed!.<br /><br />", ex.Message), eSystemMessage.Information, True)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadNewOPR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadViewAppNo(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BOprDetails
                Dim dtLocal As New DataTable

                With vwPaymentPremiumRelated
                    dtLocal = objBLL.LoadViewOPR(.SiteCode, False, Now.AddMonths(-1), Now)
                    If dtLocal.Rows.Count = 0 Then
                        Call SetMessage(String.Concat("Load View AppNo.<br /><br />", "No OPR found!"), eSystemMessage.Information, True)
                    End If

                    .dtViewAppNo = dtLocal
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewAppNo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadViewOPR(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BOprDetails
                Dim dtLocal As New DataTable

                With vwPaymentPremiumRelated
                    If IsValidLoadViewOPR() Then
                        If .ViewOprDocNumber > 0 Then
                            dtLocal = objBLL.LoadViewOPR(.SiteCode, .ViewOprDocNumber)
                        ElseIf .ViewOprPolicyNumber <> String.Empty Then
                            dtLocal = objBLL.LoadViewOPR(.SiteCode, .ViewOprPolicyNumber, 1)
                        ElseIf .ViewOprPayorName <> String.Empty Then
                            dtLocal = objBLL.LoadViewOPR(.SiteCode, .ViewOprPayorName, 2)
                        ElseIf .ViewOprInsuredName <> String.Empty Then
                            dtLocal = objBLL.LoadViewOPR(.SiteCode, .ViewOprInsuredName, 3)
                        Else
                            dtLocal = objBLL.LoadViewOPR(.SiteCode, False, .ViewOprFrom, .ViewOprTo)
                        End If

                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(String.Concat("Load View OPRs.<br /><br />", "No OPR found!"), eSystemMessage.Information, True)

                        End If

                        .dtViewOPR = dtLocal
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewOPR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadPolModDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentPremiumRelated
                    .PolType = GetPolTyp(.LoadPolMod)
                    .PolMod = .LoadPolMod
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPolModDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub SetSamePayorInsured(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentPremiumRelated
                    .SamePayorInsured = "Y"
                    .InsuredID = .PayorID
                    .InsuredIDTag = .PayorIDTag
                    .InsuredType = .PayorType
                    .InsuredName = .PayorName
                    .InsuredLastName = .PayorLastName
                    .InsuredFirstName = .PayorFirstName
                    .InsuredMiddleName = .PayorMiddleName
                    .InsuredSuffix = .PayorSuffix
                    .InsuredDateOfBirth = .PayorDateOfBirth
                    .InsuredSuffix = .PayorSuffix
                    .InsuredTitle = .PayorTitle
                    .InsuredPlaceOfBirth = .PayorPlaceOfBirth
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error SetSamePayorInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadAddPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated

                    .IsSuccessful = False
                    If IsValidAddPayor() Then

                        .PayorType = .PayorAddType
                        .PayorLastName = IIf(.PayorAddType = "C", .PayorAddName, .PayorAddLastName)
                        .PayorFirstName = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddFirstName)
                        .PayorMiddleName = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddMiddleName)
                        .PayorDateOfBirth = IIf(.PayorAddType = "C", cDataType.fDate.Empty, .PayorAddDateOfBirth)
                        .PayorSuffix = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddSuffix)
                        .PayorTitle = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddTitle)
                        .PayorPlaceOfBirth = IIf(.PayorAddType = "C", cDataType.fString.Empty, .PayorAddPlaceOfBirth)
                        .PayorName = IIf(.PayorAddType = "C", .PayorAddName, .PayorName)
                        .PayorTin = IIf(.PayorAddType = "C", .PayorTin, .PayorAddTin)
                        .PayorAddress = IIf(.PayorAddType = "C", .PayorAddress, .PayorAddAddress)

                        .IsSuccessful = True
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadAddPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadAddInsured(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .IsSuccessful = False
                    If IsValidAddInsured() Then

                        .InsuredType = .InsuredAddType
                        .InsuredLastName = .InsuredAddLastName
                        .InsuredFirstName = .InsuredAddFirstName
                        .InsuredMiddleName = .InsuredAddMiddleName
                        .InsuredDateOfBirth = .InsuredAddDateOfBirth
                        .InsuredSuffix = IIf(.InsuredAddType = "C", cDataType.fString.Empty, .InsuredAddSuffix)
                        .InsuredTitle = IIf(.InsuredAddType = "C", cDataType.fString.Empty, .InsuredAddTitle)
                        .InsuredPlaceOfBirth = IIf(.InsuredAddType = "C", cDataType.fString.Empty, .InsuredAddPlaceOfBirth)
                        .InsuredName = .InsuredName

                        .IsSuccessful = True
                    End If
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadAddInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadBankList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BBankDetails

                vwPaymentPremiumRelated.dtBankList = objBLL.LoadBankList() 'SiteCode      'LoadCheckBank

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadBankList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadDefaultTerminal(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BMerchantSite
                Dim mTerminaluse As String
                With vwPaymentPremiumRelated
                    Select Case .OPRPaymentType
                        Case eReference.PayTypeCCA
                            mTerminaluse = .CreditCardTerminalUse
                            .CreditCardMerchant = objBLL.GetMerchantId(.SourceSite, mTerminaluse)
                        Case eReference.PayTypeDCA
                            mTerminaluse = .DebitCardTerminalUse
                            .DebitCardMerchant = objBLL.GetMerchantId(.SourceSite, mTerminaluse)
                    End Select


                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadDefaultTerminal.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadECashPaymentChannel(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentPremiumRelated.dtECashPaymentChannel = objBLL.GetRefECASH
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadECashPaymentChannel.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        ' -------------------------------------------------------------------------------
        'Private Sub SavePaymentPremium(ByVal sender As Object, ByVal e As EventArgs)
        '    Dim objSiteOPRHeader As bllWorking.BSiteOPRHeader
        '    Dim objSiteOPRVAT As bllWorking.BSiteOPRVAT
        '    Dim objSitePAMaster As bllWorking.BSitePAMaster
        '    Dim lstSiteOPRInfo As New List(Of bllWorking.BSiteOPRInfo)
        '    Dim lstSiteOPRDtl As New List(Of bllWorking.BSiteOPRDtl)
        '    Dim lstSiteOPRAPRPy As New List(Of bllWorking.BSiteOPRAPRPy)
        '    Dim lstSiteOPRChkPy As New List(Of bllWorking.BSiteOPRChkPy)
        '    Dim lstSiteOPRCred As New List(Of bllWorking.BSiteOPRCred)
        '    Dim lstSiteOPRDebit As New List(Of bllWorking.BSiteOPRDebit)
        '    Dim lstSiteTmpTrn As New List(Of bllWorking.BSiteTmpTrn)

        '    Try

        '        vwPaymentPremiumRelated.IsSuccessful = False

        '        If IsValidPaymentPremiumRelated() Then
        '            With vwPaymentPremiumRelated
        '                Debug.Print(vwAgent.SearchAgentID)
        '                Select Case .TransactionType
        '                    Case eReference.TranType.Regular
        '                        objSiteOPRHeader = New bllWorking.BSiteOPRHeader(0, .OPRNumber, .OPRDate, .SourceSite, .OPRRemarks, .ApplicationNumber, .ECRNumber, .ECRDate, .PolicyNumber, .PayorID, .PayorFirstName, .PayorLastName, .PayorMiddleName, .InsuredID, .InsuredFirstName, .InsuredLastName, .InsuredMiddleName, .AgentID, .AgentFirstName, .AgentLastName, .AgentMiddleName, .AgencyID, .AgencyFirstName, .AgencyLastName, .AgencyMiddleName, eReference.DocTypeOPR, 0, .OPRCurrency, .OPRFlags, .CovEff, .LastBill, 0, 0, IIf(.GroupTag, 1, 0), .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now)
        '                    Case eReference.TranType.NewBusiness
        '                        objSiteOPRHeader = New bllWorking.BSiteOPRHeader(0, .OPRNumber, .OPRDate, .SourceSite, .OPRRemarks, .ApplicationNumber, .ECRNumber, .ECRDate, .PolicyNumber, .PayorID, .PayorFirstName, .PayorLastName, .PayorMiddleName, .InsuredID, .InsuredFirstName, .InsuredLastName, .InsuredMiddleName, .AgentID, .AgentFirstName, .AgentLastName, .AgentMiddleName, .AgencyID, .AgencyFirstName, .AgencyLastName, .AgencyMiddleName, eReference.DocTypeOPR, 0, .OPRCurrency, .OPRFlags, .CovEff, .LastBill, 0, 0, IIf(.GroupTag, 1, 0), .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now)
        '                    Case eReference.TranType.GPA
        '                        .AgentSearchTag = eReference.AgentTagType.SalesOfficer
        '                        objSiteOPRHeader = New bllWorking.BSiteOPRHeader(0, .OPRNumber, .OPRDate, .SourceSite, .OPRRemarks, .ApplicationNumber, .ECRNumber, .ECRDate, .PolicyNumber, .PayorID, .PayorFirstName, .PayorLastName, .PayorMiddleName, .InsuredID, .InsuredFirstName, .InsuredLastName, .InsuredMiddleName, .AgentID, .AgentFirstName, .AgentLastName, .AgentMiddleName, .AgencyID, .AgencyFirstName, .AgencyLastName, .AgencyMiddleName, eReference.DocTypeOPR, 0, .OPRCurrency, .OPRFlags, .CovEff, .LastBill, 0, 0, IIf(.GroupTag, 1, 0), .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now)
        '                    Case Else
        '                        objSiteOPRHeader = New bllWorking.BSiteOPRHeader(0, .OPRNumber, .OPRDate, .SourceSite, .OPRRemarks, .ApplicationNumber, .ECRNumber, .ECRDate, .PolicyNumber, .PayorID, .PayorFirstName, .PayorLastName, .PayorMiddleName, .InsuredID, .InsuredFirstName, .InsuredLastName, .InsuredMiddleName, .AgentID, .AgentFirstName, .AgentLastName, .AgentMiddleName, .AgencyID, .AgencyFirstName, .AgencyLastName, .AgencyMiddleName, eReference.DocTypeOPR, 0, .OPRCurrency, .OPRFlags, .CovEff, .LastBill, 0, 0, IIf(.GroupTag, 1, 0), .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now)
        '                End Select

        '                'objSiteOPRHeader = New bllWorking.BSiteOPRHeader(0, .OPRNumber, .OPRDate, .SourceSite, .OPRRemarks, .ApplicationNumber, .ECRNumber, .ECRDate, .PolicyNumber, .PayorID, .PayorFirstName, .PayorLastName, .PayorMiddleName, .InsuredID, .InsuredFirstName, .InsuredLastName, .InsuredMiddleName, .AgentID, .AgentFirstName, .AgentLastName, .AgentMiddleName, .AgencyID, .AgencyFirstName, .AgencyLastName, .AgencyMiddleName, eReference.DocTypeOPR, 0, .OPRCurrency, .OPRFlags, .CovEff, .LastBill, 0, 0, IIf(.GroupTag, 1, 0), .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now)
        '                If .NewBusinessTag Then
        '                    If Not .WithNewBiz Then
        '                        lstSiteOPRInfo.Add(New bllWorking.BSiteOPRInfo(0, .OPRNumber, .InsuredLastName, .InsuredFirstName, .InsuredMiddleName, .InsuredDateOfBirth, .PayorLastName, .PayorFirstName, .PayorMiddleName, .PayorDateOfBirth, .ApplicationNumber, 0, .OPRGrossAmount, .ECRNumber, .ECRDate, eReference.Status.Active, .UserID, Now, .UserID, Now))
        '                    Else
        '                        For Each item In .lstNewBiz
        '                            lstSiteOPRInfo.Add(New bllWorking.BSiteOPRInfo(0, .OPRNumber, item.LastName, item.FirstName, item.MiddleName, item.DoB, String.Empty, item.Name, String.Empty, cDataType.fDate.Empty, item.ApplNo, 0, item.Amount, item.EcrNumber, item.EcrDate, eReference.Status.Active, .UserID, Now, .UserID, Now))
        '                        Next
        '                    End If
        '                End If
        '                objSiteOPRVAT = New bllWorking.BSiteOPRVAT(0, .OPRNumber, .OPRGrossAmount, .VATableCollection, .VATExemptCollection, .VATAmount, .VATWithholdingTax, .VATAmountNetWTax, eReference.Status.Active, .UserID, Now, .UserID, Now)
        '                objSitePAMaster = New bllWorking.BSitePAMaster(0, .PolicyNumber, .GpaCardNo, 0, .InsuredLastName, .InsuredFirstName, .InsuredMiddleName, .OPRNumber, .OPRDate, .GpaPremium, .GpaCoverage, .GpaTerm, .GpaSalesOff, .GpaPromoOff, .GpaUsd1, .GpaUsd2, .GpaAsd1, String.Empty, String.Empty, .InsuredDateOfBirth, .WithCommission, .PayorLastName, .PayorFirstName, .PayorMiddleName, eReference.Status.Active, .UserID, Now, .UserID, Now)

        '                For Each item In .lstReceiptDetails
        '                    lstSiteOPRDtl.Add(New bllWorking.BSiteOPRDtl(0, .OPRNumber, item.TrnxCode, item.ActType, item.TrnxDesc, item.DueDate, item.Amount, item.LineNumber, eReference.Status.Active, .UserID, Now, .UserID, Now))
        '                Next

        '                For Each item In .lstPaymentTypeDetails
        '                    Select Case item.PaymentType
        '                        Case eReference.PayTypeCSH

        '                        Case eReference.PayTypeCHQ
        '                            lstSiteOPRChkPy.Add(New bllWorking.BSiteOPRChkPy(0, .OPRNumber, item.CheckNumber, item.Bank, item.Branch, item.Amount, lstSiteOPRChkPy.Count + 1, 0, eReference.Status.Active, .UserID, Now, .UserID, Now))
        '                        Case eReference.PayTypeDCA
        '                            lstSiteOPRDebit.Add(New bllWorking.BSiteOPRDebit(0, .OPRNumber, item.Network, item.Bank, item.CASA, item.AccountNumber, item.Remarks, item.Amount, item.TerminalUse, item.MerchantID, item.SwipeDate, eReference.Status.Active, .UserID, Now, .UserID, Now))
        '                        Case eReference.PayTypeCCA
        '                            lstSiteOPRCred.Add(New bllWorking.BSiteOPRCred(0, .OPRNumber, item.CardNumber, item.CardType, item.ApprovalCode, item.Remarks, item.Amount, item.TerminalUse, item.MerchantID, item.SwipeDate, eReference.Status.Active, .UserID, Now, .UserID, Now))
        '                    End Select
        '                Next
        '                lstSiteOPRAPRPy.Add(New bllWorking.BSiteOPRAPRPy(0, .OPRNumber, .APRNumber, .APRDate, .APRAmount, 1, eReference.Status.Active, .UserID, Now, .UserID, Now))
        '                'lstReceiptDetails
        '                Dim lstSumRcptDtl = (From c In .lstReceiptDetails
        '                                    Where (c.ActType = "PREMM" Or c.ActType = "TPREM")
        '                                    Group By c.ActType, c.ReceiptType
        '                                    Into Amount = Sum(c.Amount)
        '                                    Select ActType, Amount, ReceiptType
        '                                    Order By ActType) _
        '                                    .Union _
        '                                    (From c In .lstReceiptDetails
        '                                    Where Not (c.ActType = "PREMM" Or c.ActType = "TPREM")
        '                                    Group By c.ActType, c.ReceiptType
        '                                    Into Amount = Sum(c.Amount)
        '                                    Select ActType, Amount, ReceiptType)

        '                Dim mTempCsh as decimal
        '                Dim mTempChq as decimal
        '                Dim mTempCshRem as decimal = .CashTotalAmount
        '                Dim mTempChqRem as decimal = .CheckTotalAmount

        '                For Each item In lstSumRcptDtl
        '                    'Compute Cash/Check breakdown
        '                    Select Case .OPRPaymentType
        '                        Case eReference.PayTypeCSH, eReference.PayTypeCCA, eReference.PayTypeDCA
        '                            mTempCsh = item.Amount
        '                        Case eReference.PayTypeCHQ
        '                            mTempChq = mTempChqRem
        '                            mTempCsh = mTempCshRem

        '                            If mTempCsh = 0 Then
        '                                mTempChq = item.Amount
        '                            Else
        '                                If mTempChqRem >= item.Amount Then
        '                                    mTempChq = item.Amount
        '                                    mTempCsh = 0
        '                                    mTempChqRem = mTempChqRem - mTempChq
        '                                Else
        '                                    mTempCsh = item.Amount - mTempChqRem
        '                                    mTempChq = mTempChqRem
        '                                    mTempChqRem = 0
        '                                    mTempCshRem = mTempCshRem - mTempCsh
        '                                End If
        '                            End If
        '                    End Select

        '                    lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn(0, 0, item.ActType, String.Empty, .PayorID, .PolicyNumber, .OPRDate, item.Amount, .UserID, Now, 0, .InsuredID, _
        '                                                                 .CheckNumber, .OPRCurrency, String.Empty, .OPRPaymentType, .AgencyID, 0, .SourceSite, .OPRNumber, GetTrnCod(item.ActType, .OPRPaymentType), 0, 0, 0, 0, _
        '                                                                 0, 0, item.ReceiptType, .PolMod, .CovDue, mTempCsh, mTempChq, 0, .PolFrq, IIf(.TransactionType = eReference.TranType.GPA, .GpaSalesOff, .AgentID), String.Empty, IIf(item.ActType = "PREMM", .CommissionAmount, 0), .APRDate, .APRNumber, _
        '                                                                 .ApplicationNumber, .ECRNumber, .ECRDate, .BalanceToHigher, String.Empty, Now, .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now))

        '                    'End If

        '                Next


        '                objPaymntPremiumRelated = New bllPayment.BPaymentPremiumfRelated

        '                With objPaymntPremiumRelated


        '                    .SiteCode = vwPaymentPremiumRelated.SiteCode
        '                    .UserID = vwPaymentPremiumRelated.UserID
        '                    .IsAprTag = vwPaymentPremiumRelated.WithAPR
        '                    .IsGpaTag = vwPaymentPremiumRelated.GpaPaymentTag
        '                    .IsNewBusinessTag = IIf(vwPaymentPremiumRelated.ApplicationNumber > 0, True, False)
        '                    .SiteOPRHeader = objSiteOPRHeader
        '                    .SiteOPRInfo = lstSiteOPRInfo
        '                    .SiteOPRVAT = objSiteOPRVAT
        '                    .SitePAMaster = objSitePAMaster
        '                    .SiteOPRDtl = lstSiteOPRDtl
        '                    .SiteOPRAPRPy = lstSiteOPRAPRPy
        '                    .SiteOPRChkPy = lstSiteOPRChkPy
        '                    .SiteOPRCred = lstSiteOPRCred
        '                    .SiteOPRDebit = lstSiteOPRDebit
        '                    .SiteTmpTrn = lstSiteTmpTrn

        '                    .SavePaymentPremiumRelated()

        '                    vwPaymentPremiumRelated.IsSuccessful = .IsSuccessful
        '                    If .IsSuccessful = True Then
        '                        Call SetMessage(String.Concat("Premium Payment.<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
        '                    End If
        '                End With
        '            End With
        '        End If

        '    Catch ex As Exception
        '         Throw new exception SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error SavePaymentPremium.<br /><br />", ex.Message      ))
        ''        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error SavePaymentPremium.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        Private Sub ProcessPaymentPremium(ByVal sender As Object, ByVal e As EventArgs)
            'Objects
            Dim objSiteOPRHeader As New bllWorking.BSiteOPRHeader
            Dim objSiteOPRVAT As New bllWorking.BSiteOPRVAT
            Dim objSitePAMaster As New bllWorking.BSitePAMaster
            Dim objSiteOPRInfo As New bllWorking.BSiteOPRInfo
            Dim objSiteOPRDtl As New bllWorking.BSiteOPRDtl
            Dim objSiteOPRAPRPy As New bllWorking.BSiteOPRAPRPy
            Dim objSiteOPRChkPy As New bllWorking.BSiteOPRChkPy
            Dim objSiteOPRCred As New bllWorking.BSiteOPRCred
            Dim objSiteOPRDebit As New bllWorking.BSiteOPRDebit
            Dim objSiteOPRECash As New bllWorking.BSiteOPRECash
            Dim objSiteTmpTrn As New bllWorking.BSiteTmpTrn
            Dim objSiteRcptCtr As New bllWorking.BReceiptCounter
            Dim objPrsmas As New bllPerson.BPrsMas
            Dim objNewgenPayment As New bllStaging.BNewgenLifePayment
            'Lists
            Dim lstSiteOPRInfo As New List(Of bllWorking.BSiteOPRInfo)
            Dim lstSiteOPRDtl As New List(Of bllWorking.BSiteOPRDtl)
            Dim lstSiteOPRAPRPy As New List(Of bllWorking.BSiteOPRAPRPy)
            Dim lstSiteOPRChkPy As New List(Of bllWorking.BSiteOPRChkPy)
            Dim lstSiteOPRCred As New List(Of bllWorking.BSiteOPRCred)
            Dim lstSiteOPRDebit As New List(Of bllWorking.BSiteOPRDebit)
            Dim lstSiteOPRECash As New List(Of bllWorking.BSiteOPRECash)
            Dim lstSiteTmpTrn As New List(Of bllWorking.BSiteTmpTrn)
            Dim lstPrsmasPayor As New List(Of bllPerson.BPrsMas)
            Dim lstPrsmasInsured As New List(Of bllPerson.BPrsMas)
            Dim lstIdSiteOPRInfo As New List(Of Long)
            Dim lstIdSiteOPRDtl As New List(Of Long)
            Dim lstIdSiteOPRAPRPy As New List(Of Long)
            Dim lstIdSiteOPRChkPy As New List(Of Long)
            Dim lstIdSiteOPRCred As New List(Of Long)
            Dim lstIdSiteOPRDebit As New List(Of Long)
            Dim lstIdSiteOPRECash As New List(Of Long)
            Dim lstIdSiteTmpTrn As New List(Of Long)
            Dim lstForDeletion As New List(Of Object)
            Dim mParticularsJSON As String = String.Empty
            Dim mPaymentModeJSON As String = String.Empty

            Dim mDocSaveState As String = String.Empty

            Try

                vwPaymentPremiumRelated.IsSuccessful = False

                If IsValidPaymentPremiumRelated() Then
                    With vwPaymentPremiumRelated
                        mDocSaveState = .DocSaveState
                        Select Case mDocSaveState
                            Case eReference.DocSaveState.Edit, eReference.DocSaveState.Cancel, eReference.DocSaveState.Print
                                Dim dtSiteTmpTrn = objSiteTmpTrn.GetTmpTrnDt(.OPRNumber, eReference.DocTypeOPR, .UserID)
                                Dim dtSiteOPRInfo = objSiteOPRInfo.GetOPRInfoDt(.OPRNumber, .UserID)
                                Dim dtSiteOPRDtl = objSiteOPRDtl.GetOPRDtlDt(.OPRNumber, .UserID)
                                Dim dtSiteOPRChkPy = objSiteOPRChkPy.GetOPRChkPyDt(.OPRNumber, .UserID)
                                Dim dtSiteOPRCred = objSiteOPRCred.GetOPRCredDt(.OPRNumber, .UserID)
                                Dim dtSiteOPRDebit = objSiteOPRDebit.GetOPRDebitDt(.OPRNumber, .UserID)
                                Dim dtSiteOPRECash = objSiteOPRECash.GetOPRECashDt(.OPRNumber, .UserID)
                                objSiteOPRVAT.GetSiteOPRVAT(.OPRNumber, .UserID)
                                objSiteOPRHeader.GetOPRHeader(.OPRNumber, .UserID)
                                objSitePAMaster.GetSitePAMAster(.OPRNumber, .UserID)
                                objSiteOPRAPRPy.GetOPRAPRPy(.OPRNumber, .UserID)

                                If objSitePAMaster.Id > 0 Then
                                    lstForDeletion.Add(New bllWorking.BSitePAMaster() With {.Id = objSitePAMaster.Id, .ORNumber = objSitePAMaster.ORNumber, .StatusId = objSitePAMaster.StatusId, .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                End If

                                If objSiteOPRAPRPy.Id > 0 Then
                                    lstForDeletion.Add(New bllWorking.BSiteOPRAPRPy() With {.Id = objSiteOPRAPRPy.Id, .OPRNmbr = objSiteOPRAPRPy.OPRNmbr, .StatusId = objSiteOPRAPRPy.StatusId, .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                End If

                                For Each dr As DataRow In dtSiteTmpTrn.Rows
                                    If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                        lstIdSiteTmpTrn.Add(dr.Item("id"))
                                        lstForDeletion.Add(New bllWorking.BSiteTmpTrn() With {.Id = dr.Item("id"), .RcptNo = dr.Item("rcptno"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    Else
                                        lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn() With {.Id = dr.Item("id"), .RcptNo = dr.Item("rcptno"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    End If
                                Next
                                For Each dr As DataRow In dtSiteOPRInfo.Rows
                                    If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                        lstIdSiteOPRInfo.Add(dr.Item("id"))
                                        lstForDeletion.Add(New bllWorking.BSiteOPRInfo() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    Else
                                        lstSiteOPRInfo.Add(New bllWorking.BSiteOPRInfo() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    End If
                                Next
                                For Each dr As DataRow In dtSiteOPRDtl.Rows
                                    If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                        lstIdSiteOPRDtl.Add(dr.Item("id"))
                                        lstForDeletion.Add(New bllWorking.BSiteOPRDtl() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    Else
                                        lstSiteOPRDtl.Add(New bllWorking.BSiteOPRDtl() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    End If
                                Next
                                For Each dr As DataRow In dtSiteOPRChkPy.Rows
                                    If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                        lstIdSiteOPRChkPy.Add(dr.Item("id"))
                                        lstForDeletion.Add(New bllWorking.BSiteOPRChkPy() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    Else
                                        lstSiteOPRChkPy.Add(New bllWorking.BSiteOPRChkPy() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    End If
                                Next
                                For Each dr As DataRow In dtSiteOPRCred.Rows
                                    If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                        lstIdSiteOPRCred.Add(dr.Item("id"))
                                        lstForDeletion.Add(New bllWorking.BSiteOPRCred() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    Else
                                        lstSiteOPRCred.Add(New bllWorking.BSiteOPRCred() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    End If
                                Next
                                For Each dr As DataRow In dtSiteOPRDebit.Rows
                                    If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                        lstIdSiteOPRDebit.Add(dr.Item("id"))
                                        lstForDeletion.Add(New bllWorking.BSiteOPRDebit() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    Else
                                        lstSiteOPRDebit.Add(New bllWorking.BSiteOPRDebit() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    End If
                                Next
                                For Each dr As DataRow In dtSiteOPRECash.Rows
                                    If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                                        lstIdSiteOPRECash.Add(dr.Item("id"))
                                        lstForDeletion.Add(New bllWorking.BSiteOPRECash() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    Else
                                        lstSiteOPRECash.Add(New bllWorking.BSiteOPRECash() With {.Id = dr.Item("id"), .OPRNmbr = dr.Item("opr_nmbr"), .StatusId = dr.Item("status_id"), .LastUpdateBy = vwPaymentPremiumRelated.UserID})
                                    End If
                                Next
                        End Select

                        Select Case mDocSaveState

                            Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit, eReference.DocSaveState.Print
                                If .NewBusinessTag AndAlso Not .WithNewBiz AndAlso .ApplicationNumber = 0 Then
                                    If Not .NewgenNewBusinessTag Then
                                        LoadApplicationNo(Me, EventArgs.Empty)
                                    End If
                                End If

                                Select Case .TransactionType
                                    Case eReference.TranType.GPA
                                        .AgentSearchTag = eReference.AgentTagType.SalesOfficer
                                        objSiteOPRHeader = New bllWorking.BSiteOPRHeader(objSiteOPRHeader.Id, .OPRNumber, .OPRDate, .SourceSite, .GpaCardNo, .ApplicationNumber, .ECRNumber, .ECRDate, .PolicyNumber, .PayorID, .PayorFirstName, .PayorLastName, .PayorMiddleName, .InsuredID, .InsuredFirstName, .InsuredLastName, .InsuredMiddleName, .AgentID, .AgentFirstName, .AgentLastName, .AgentMiddleName, .AgencyID, .AgencyFirstName, .AgencyLastName, .AgencyMiddleName, eReference.DocTypeOPR, 0, .OPRCurrency, .OPRFlags, .CovEff, .LastBill, objSiteOPRHeader.CancelFlag, objSiteOPRHeader.PrtFlag, IIf(.GroupTag, 1, 0), .UserID, .SiteCode, .PayorAddress, .PayorTin, IIf(objSiteOPRHeader.StatusId > 0, objSiteOPRHeader.StatusId, eReference.Status.Active), .UserID, Now, .UserID, Now, .BillNo, .SubsNo)
                                    Case Else 'dito
                                        objSiteOPRHeader = New bllWorking.BSiteOPRHeader(objSiteOPRHeader.Id, .OPRNumber, .OPRDate, .SourceSite, .OPRRemarks, .ApplicationNumber, .ECRNumber, .ECRDate, .PolicyNumber, .PayorID, IIf(.PayorType = "C", .PayorName, .PayorFirstName), IIf(.PayorType = "C", String.Empty, .PayorLastName), .PayorMiddleName, .InsuredID, .InsuredFirstName, .InsuredLastName, .InsuredMiddleName, .AgentID, .AgentFirstName, .AgentLastName, .AgentMiddleName, .AgencyID, .AgencyFirstName, .AgencyLastName, .AgencyMiddleName, eReference.DocTypeOPR, 0, .OPRCurrency, .OPRFlags, .CovEff, .LastBill, objSiteOPRHeader.CancelFlag, objSiteOPRHeader.PrtFlag, IIf(.GroupTag, 1, 0), .UserID, .SiteCode, .PayorAddress, .PayorTin, IIf(objSiteOPRHeader.StatusId > 0, objSiteOPRHeader.StatusId, eReference.Status.Active), .UserID, Now, .UserID, Now, .BillNo, .SubsNo)
                                End Select

                                If .NewBusinessTag OrElse .GpaPaymentTag Then
                                    If Not .WithNewBiz Then
                                        If Not .NewgenNewBusinessTag Then
                                            lstSiteOPRInfo.Add(New bllWorking.BSiteOPRInfo(GetIdFromList(lstIdSiteOPRInfo, 0), .OPRNumber, .InsuredID, .InsuredLastName, .InsuredFirstName, .InsuredMiddleName, .InsuredDateOfBirth, .InsuredSuffix, .InsuredTitle, .InsuredType, .InsuredPlaceOfBirth, .PayorID, IIf(.PayorType = "C", .PayorName, .PayorLastName), .PayorFirstName, .PayorMiddleName, .PayorDateOfBirth, .PayorSuffix, .PayorTitle, .PayorType, .PayorPlaceOfBirth, .ApplicationNumber, 0, .OPRGrossAmount, .ECRNumber, .ECRDate, eReference.Status.Active, .UserID, Now, .UserID, Now))

                                            If .PayorID = 0 Then
                                                lstPrsmasPayor.Add(New bllPerson.BPrsMas(0, .PayorName, .PayorTitle, .PayorType, String.Empty, .PayorPlaceOfBirth, .PayorDateOfBirth, String.Empty, IIf(.PayorType = "C", String.Empty, .PayorLastName), .PayorFirstName, .PayorMiddleName, .PayorSuffix, Mid(.PayorName, 1, 5), String.Empty, String.Empty, String.Empty, String.Empty, .PayorTin, .PayorAddress)) 'new 2 , String.Empty added by junie
                                            End If

                                            If .SamePayorInsured = "N" AndAlso .InsuredID = 0 Then
                                                lstPrsmasInsured.Add(New bllPerson.BPrsMas(0, .InsuredName, .InsuredTitle, .InsuredType, String.Empty, .InsuredPlaceOfBirth, .InsuredDateOfBirth, String.Empty, .InsuredLastName, .InsuredFirstName, .InsuredMiddleName, .InsuredSuffix, Mid(.InsuredName, 1, 5), String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)) 'new 2 , String.Empty added by junie
                                            End If
                                        End If
                                    Else
                                        Dim mInsName As String
                                        For Each item In .lstNewBiz
                                            lstSiteOPRInfo.Add(New bllWorking.BSiteOPRInfo(GetIdFromList(lstIdSiteOPRInfo, lstSiteOPRInfo.Count), .OPRNumber, item.PrsPid, item.LastName, item.FirstName, item.MiddleName, item.DoB, item.Suffix, item.Title, item.Sex, item.PlaceOfBirth, item.PayPrsPid, item.Name, String.Empty, String.Empty, cDataType.fDate.Empty, String.Empty, String.Empty, .PayorType, String.Empty, item.ApplNo, 0, item.Amount, item.EcrNumber, item.EcrDate, eReference.Status.Active, .UserID, Now, .UserID, Now))

                                            If item.Suffix = String.Empty Then
                                                mInsName = String.Concat(item.LastName, ";", item.FirstName, " ", item.MiddleName)
                                            Else
                                                mInsName = String.Concat(item.LastName, ", ", item.Suffix, ";", item.FirstName, " ", item.MiddleName)
                                            End If

                                            If item.PrsPid = 0 Then
                                                lstPrsmasInsured.Add(New bllPerson.BPrsMas(item.PrsPid, mInsName, item.Title, item.Sex, String.Empty, item.PlaceOfBirth, item.DoB, String.Empty, item.LastName, item.FirstName, item.MiddleName, item.Suffix, Mid(item.Name, 1, 5), String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)) 'new 2 , String.Empty added by junie
                                            End If
                                            If item.PayPrsPid = 0 AndAlso lstSiteOPRInfo.Count = 1 Then
                                                lstPrsmasPayor.Add(New bllPerson.BPrsMas(item.PayPrsPid, item.Name, String.Empty, .PayorType, String.Empty, String.Empty, String.Empty, String.Empty, item.Name, String.Empty, String.Empty, String.Empty, Mid(item.Name, 1, 5), String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)) 'new 2 , String.Empty added by junie
                                            End If
                                        Next
                                    End If
                                End If
                                objSiteOPRVAT = New bllWorking.BSiteOPRVAT(objSiteOPRVAT.Id, .OPRNumber, .OPRGrossAmount, .VATableCollection, .VATExemptCollection, .VATAmount, .VATWithholdingTax, .VATAmountNetWTax, eReference.Status.Active, .UserID, Now, .UserID, Now, .NonVATCollection)
                                Dim mGpaPromoOff As Long = IIf(.GpaPromoOff = 0, .GpaSalesOff, .GpaPromoOff)
                                Dim mGpaUsd2 As Long
                                If .GpaType = eReference.ColrefGpaRenewal Then
                                    mGpaUsd2 = 0
                                Else
                                    mGpaUsd2 = IIf(.GpaPromoOff = 0, .GpaUsd1, .GpaUsd2)
                                End If
                                Dim mStatus As String = IIf(.GpaType = eReference.ColrefGpaRefund, "R", String.Empty)
                                Dim mGpaPremium As Decimal = IIf(.GpaType = eReference.ColrefGpaRenewal, .OPRGrossAmount, .GpaPremium)
                                Dim mGpaCoverage As Decimal = 0
                                If .GpaType = eReference.ColrefGpaRenewal AndAlso .GpaPremium <> .OPRGrossAmount Then
                                    mGpaCoverage = 0
                                Else
                                    mGpaCoverage = .GpaCoverage
                                End If
                                Dim mGpaTerm As Integer = 0
                                If .GpaType = eReference.ColrefGpaRenewal AndAlso .GpaPremium <> .OPRGrossAmount Then
                                    mGpaTerm = 0
                                Else
                                    mGpaTerm = .GpaTerm
                                End If
                                objSitePAMaster = New bllWorking.BSitePAMaster(objSitePAMaster.Id, .PolicyNumber, .GpaCardNo, 0, .InsuredLastName, .InsuredFirstName, .InsuredMiddleName, .OPRNumber, .OPRDate, mGpaPremium, mGpaCoverage, mGpaTerm, .GpaSalesOff, mGpaPromoOff, .GpaUsd1, mGpaUsd2, .GpaAsd1, String.Empty, mStatus, .InsuredDateOfBirth, IIf(.WithCommission, 1, 0), .PayorLastName, .PayorFirstName, .PayorMiddleName, eReference.Status.Active, .UserID, Now, .UserID, Now)

                                For Each item In .lstReceiptDetails
                                    If mParticularsJSON <> String.Empty Then
                                        mParticularsJSON += ","
                                    End If

                                    mParticularsJSON += "{""Payment_Type"":""" + item.ActType + """," +
                                            """Payment_SubType"":""" + item.TrnxDesc + """," +
                                            """Amount"":""" + CStr(item.Amount) + """}"

                                    lstSiteOPRDtl.Add(New bllWorking.BSiteOPRDtl(GetIdFromList(lstIdSiteOPRDtl, lstSiteOPRDtl.Count), .OPRNumber, item.TrnxCode, item.ActType, item.TrnxDesc, item.DueDate, item.Amount, lstSiteOPRDtl.Count + 1, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                Next

                                For Each item In .lstPaymentTypeDetails
                                    If mPaymentModeJSON <> String.Empty Then
                                        mPaymentModeJSON += ","
                                    End If

                                    mPaymentModeJSON += "{""Mode"": """ + item.PaymentType + """," +
                                          """Amount"": """ + CStr(item.Amount) + """," +
                                          """Card_No"": """ + item.CardNumber + """," +
                                          """Terminal"": """ + item.TerminalUse + """," +
                                          """Merchant_Id"": """ + item.MerchantID + """," +
                                          """Cheque_No"": """ + CStr(IIf(item.CheckNumber = 0, "", item.CheckNumber)) + """," +
                                          """Cheque_Clearnace_Status"": """ + IIf(item.PaymentType = "CHQ", "1", "") + """," +
                                          """Branch"": """ + Trim(item.Branch) + """," +
                                          """Card_Transaction_No"": """ + item.AccountNumber + """," +
                                          """Batch_No"":""" + CStr(IIf(item.BatchNumber = 0, "", item.BatchNumber)) + """}"

                                    Select Case item.PaymentType
                                        Case eReference.PayTypeCSH
                                        Case eReference.PayTypeCHQ
                                            lstSiteOPRChkPy.Add(New bllWorking.BSiteOPRChkPy(GetIdFromList(lstIdSiteOPRChkPy, lstSiteOPRChkPy.Count), .OPRNumber, cDataType.fDate.Empty, item.CheckNumber, item.Bank, item.Branch, item.Amount, lstSiteOPRChkPy.Count + 1, 0, cDataType.fDate.Empty, cDataType.fDate.Empty, 1, String.Empty, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                            'lstSiteOPRChkPy.Add(New bllWorking.BSiteOPRChkPy(GetIdFromList(lstIdSiteOPRChkPy, lstSiteOPRChkPy.Count), .OPRNumber, item.CheckNumber, item.Bank, item.Branch, item.Amount, lstSiteOPRChkPy.Count + 1, 0, cDataType.fDate.Empty, cDataType.fDate.Empty, 1, String.Empty, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        Case eReference.PayTypeDCA
                                            lstSiteOPRDebit.Add(New bllWorking.BSiteOPRDebit(GetIdFromList(lstIdSiteOPRDebit, lstSiteOPRDebit.Count), .OPRNumber, item.Network, item.Bank, item.CASA, item.AccountNumber, item.Remarks, item.Amount, item.TerminalUse, item.MerchantID, item.SwipeDate, item.ApprovalCode, item.BatchNumber, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        Case eReference.PayTypeCCA
                                            lstSiteOPRCred.Add(New bllWorking.BSiteOPRCred(GetIdFromList(lstIdSiteOPRCred, lstSiteOPRCred.Count), .OPRNumber, item.CardNumber, item.CardType, item.ApprovalCode, item.Remarks, item.Amount, item.TerminalUse, item.MerchantID, item.SwipeDate, item.BatchNumber, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        Case eReference.PayTypeECP
                                            lstSiteOPRECash.Add(New bllWorking.BSiteOPRECash(GetIdFromList(lstIdSiteOPRECash, lstSiteOPRECash.Count), .OPRNumber, item.PaymentChannel, item.ReferenceID, item.Amount, item.Remarks, item.ServiceFeeRate, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                    End Select
                                Next
                                lstSiteOPRAPRPy.Add(New bllWorking.BSiteOPRAPRPy(objSiteOPRAPRPy.Id, .OPRNumber, .APRNumber, .APRDate, .APRAmount, 1, eReference.Status.Active, .UserID, Now, .UserID, Now))

                                Dim lstSumRcptDtl = (From c In .lstReceiptDetails
                                                    Where (c.ActType = "PREMM" Or c.ActType = "TPREM")
                                                    Group By c.ActType, c.ReceiptType
                                                    Into Amount = Sum(c.Amount)
                                                    Select ActType, Amount, ReceiptType
                                                    Order By ActType) _
                                                    .Union _
                                                    (From c In .lstReceiptDetails
                                                    Where Not (c.ActType = "PREMM" Or c.ActType = "TPREM")
                                                    Group By c.ActType, c.ReceiptType
                                                    Into Amount = Sum(c.Amount)
                                                    Select ActType, Amount, ReceiptType).AsEnumerable

                                Dim mTempCsh As Decimal
                                Dim mTempChq As Decimal
                                Dim mTempCshRem As Decimal = .CashTotalAmount
                                Dim mTempChqRem As Decimal = .CheckTotalAmount
                                Dim mTempCcaRem As Decimal = .CreditCardTotalAmount
                                Dim mTempDcaRem As Decimal = .DebitCardTotalAmount
                                Dim mTempEcpRem As Decimal = .ECashPaymentTotalAmount

                                For Each item In lstSumRcptDtl
                                    'Compute Cash/Check breakdown
                                    If Not .GpaPaymentTag Then
                                        Dim mPaymentType As String = .OPRPaymentType

                                        Select Case .OPRPaymentType
                                            Case eReference.PayTypeCSH
                                                mTempCsh = item.Amount
                                            Case eReference.PayTypeCCA, eReference.PayTypeDCA, eReference.PayTypeECP
                                                mTempCsh = item.Amount

                                                For Each cpt As bllWorking.BSiteOPRCred In lstSiteOPRCred
                                                    mPaymentType = cpt.TerminalID
                                                Next
                                                For Each cpt As bllWorking.BSiteOPRDebit In lstSiteOPRDebit
                                                    mPaymentType = cpt.TerminalID
                                                Next
                                                For Each cpt As bllWorking.BSiteOPRECash In lstSiteOPRECash
                                                    mPaymentType = "CSH"
                                                Next
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

                                        Dim mCommission As Decimal = IIf(item.ActType = "PREMM" Or item.ActType = eReference.TrnxGPA, .CommissionAmount, 0)

                                        lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn(GetIdFromList(lstIdSiteTmpTrn, lstSiteTmpTrn.Count), 0, item.ActType, String.Empty, .PayorID, .PolicyNumber, .OPRDate, item.Amount, .UserID, Now, 0, .InsuredID, _
                                                                                    .CheckNumber, .OPRCurrency, String.Empty, mPaymentType, .ServUn, 0, .SourceSite, .OPRNumber, GetTrnCod(item.ActType, .OPRPaymentType), 0, 0, 0, 0, _
                                                                                    0, 0, item.ReceiptType, .PolMod, .CovDue, mTempCsh, mTempChq, 0, .PolFrq, .AgentID, String.Empty, mCommission, .APRDate, .APRNumber, _
                                                                                    .ApplicationNumber, .ECRNumber, .ECRDate, .BalanceToHigher, String.Empty, Now, .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now))

                                    Else
                                        Dim mCommission As Decimal = IIf(item.ActType = "PREMM" Or item.ActType = eReference.TrnxGPA, .CommissionAmount, 0)
                                        Dim mPaymentType As String

                                        mTempCsh = mTempCshRem
                                        mTempChq = mTempChqRem
                                        If mTempCsh + mTempChq > 0 Then
                                            Dim mCheckNo As String = String.Empty
                                            If mTempChqRem > 0 Then
                                                mPaymentType = eReference.PayTypeCHQ
                                                For Each cpt As bllWorking.BSiteOPRChkPy In lstSiteOPRChkPy
                                                    mCheckNo = cpt.ChkNmbr
                                                    Exit For
                                                Next
                                            Else
                                                mPaymentType = eReference.PayTypeCSH
                                            End If
                                            lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn(GetIdFromList(lstIdSiteTmpTrn, lstSiteTmpTrn.Count), 0, item.ActType, String.Empty, .PayorID, .PolicyNumber, .OPRDate, mTempCsh + mTempChq, .UserID, Now, 0, .InsuredID, _
                                                                                        mCheckNo, .OPRCurrency, String.Empty, mPaymentType, .ServUn, 0, .SourceSite, .OPRNumber, GetTrnCod(item.ActType, mPaymentType), 0, 0, 0, 0, _
                                                                                        0, 0, item.ReceiptType, .PolMod, .CovDue, mTempCsh, mTempChq, 0, .PolFrq, .GpaSalesOff, String.Empty, mCommission, .APRDate, .APRNumber, _
                                                                                        .ApplicationNumber, .ECRNumber, .ECRDate, .BalanceToHigher, String.Empty, Now, .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        End If

                                        mPaymentType = eReference.PayTypeCCA
                                        For Each cpt As bllWorking.BSiteOPRCred In lstSiteOPRCred
                                            lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn(GetIdFromList(lstIdSiteTmpTrn, lstSiteTmpTrn.Count), 0, item.ActType, String.Empty, .PayorID, .PolicyNumber, .OPRDate, cpt.Amount, .UserID, Now, 0, .InsuredID, _
                                                                                        String.Empty, .OPRCurrency, String.Empty, cpt.TerminalID, .ServUn, 0, .SourceSite, .OPRNumber, GetTrnCod(item.ActType, mPaymentType), 0, 0, 0, 0, _
                                                                                        0, 0, item.ReceiptType, .PolMod, .CovDue, cpt.Amount, 0, 0, .PolFrq, .GpaSalesOff, String.Empty, 0, .APRDate, .APRNumber, _
                                                                                        .ApplicationNumber, .ECRNumber, .ECRDate, .BalanceToHigher, String.Empty, Now, .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        Next
                                        mPaymentType = eReference.PayTypeDCA
                                        For Each cpt As bllWorking.BSiteOPRDebit In lstSiteOPRDebit
                                            lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn(GetIdFromList(lstIdSiteTmpTrn, lstSiteTmpTrn.Count), 0, item.ActType, String.Empty, .PayorID, .PolicyNumber, .OPRDate, cpt.Amount, .UserID, Now, 0, .InsuredID, _
                                                                                        String.Empty, .OPRCurrency, String.Empty, cpt.TerminalID, .ServUn, 0, .SourceSite, .OPRNumber, GetTrnCod(item.ActType, mPaymentType), 0, 0, 0, 0, _
                                                                                        0, 0, item.ReceiptType, .PolMod, .CovDue, cpt.Amount, 0, 0, .PolFrq, .GpaSalesOff, String.Empty, 0, .APRDate, .APRNumber, _
                                                                                        .ApplicationNumber, .ECRNumber, .ECRDate, .BalanceToHigher, String.Empty, Now, .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        Next
                                        mPaymentType = "CSH"
                                        For Each cpt As bllWorking.BSiteOPRECash In lstSiteOPRECash
                                            lstSiteTmpTrn.Add(New bllWorking.BSiteTmpTrn(GetIdFromList(lstIdSiteTmpTrn, lstSiteTmpTrn.Count), 0, item.ActType, String.Empty, .PayorID, .PolicyNumber, .OPRDate, cpt.Amount, .UserID, Now, 0, .InsuredID, _
                                                                                        String.Empty, .OPRCurrency, String.Empty, mPaymentType, .ServUn, 0, .SourceSite, .OPRNumber, GetTrnCod(item.ActType, mPaymentType), 0, 0, 0, 0, _
                                                                                        0, 0, item.ReceiptType, .PolMod, .CovDue, cpt.Amount, 0, 0, .PolFrq, .GpaSalesOff, String.Empty, 0, .APRDate, .APRNumber, _
                                                                                        .ApplicationNumber, .ECRNumber, .ECRDate, .BalanceToHigher, String.Empty, Now, .UserID, .SiteCode, eReference.Status.Active, .UserID, Now, .UserID, Now))
                                        Next

                                    End If

                                Next

                                objNewgenPayment = New bllStaging.BNewgenLifePayment(.OPRNumber, .OPRDate, .ApplicationNumber, .PolicyNumber, .PayorName, .APRNumber, .APRDate, .PolCur, .OPRGrossAmount,
                                                                                .VATableCollection, .NonVATCollection, .VATExemptCollection, .VATAmount, .VATTotalCollection, .VATWithholdingTax, .VATAmountNetWTax,
                                                                                "Reg", .BillNo, .SubsNo, .PayorTin, .PayorAddress, .CommissionAmount, "Active", .OPRRemarks, mParticularsJSON,
                                                                                mPaymentModeJSON)
                        End Select

                        objPaymntPremiumRelated = New bllPayment.BPaymentPremiumRelated

                        With objPaymntPremiumRelated
                            .SiteCode = vwPaymentPremiumRelated.SiteCode
                            .UserID = vwPaymentPremiumRelated.UserID
                            .SamePayorInsured = IIf(vwPaymentPremiumRelated.SamePayorInsured = "Y", True, False)
                            .Polmod = vwPaymentPremiumRelated.PolMod
                            .IsAprTag = vwPaymentPremiumRelated.WithAPR
                            .IsGpaTag = vwPaymentPremiumRelated.GpaPaymentTag
                            .IsNewBusinessTag = vwPaymentPremiumRelated.NewBusinessTag
                            .SiteOPRHeader = objSiteOPRHeader
                            .SiteOPRInfo = lstSiteOPRInfo
                            .SiteOPRVAT = objSiteOPRVAT
                            .SitePAMaster = objSitePAMaster
                            .SiteOPRDtl = lstSiteOPRDtl
                            .SiteOPRAPRPy = lstSiteOPRAPRPy
                            .SiteOPRChkPy = lstSiteOPRChkPy
                            .SiteOPRCred = lstSiteOPRCred
                            .SiteOPRDebit = lstSiteOPRDebit
                            .SiteOPRECash = lstSiteOPRECash
                            .SiteTmpTrn = lstSiteTmpTrn
                            .PrsMasPayor = lstPrsmasPayor
                            .PrsMasInsured = lstPrsmasInsured
                            .NewgenPayment = objNewgenPayment
                            .lstForDeletion = lstForDeletion

                            Select Case mDocSaveState
                                Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit

                                    If .SiteOPRHeader.OPRRcptNo = 0 Then
                                        Dim objDetails As New BLL.OCS.Reference.BOprDetails
                                        .ReservedReceiptNumber = objDetails.LoadNextOPR(.SiteCode, eReference.ReceiptType.CI, .UserID)
                                        objSiteRcptCtr.GetSiteReceiptCounter(.SiteCode)
                                        objSiteRcptCtr.ReceiptNumber = .ReservedReceiptNumber
                                        objSiteRcptCtr.SiteId = .SiteCode
                                        objSiteRcptCtr.UserId = .UserID
                                        objSiteRcptCtr.StatusId = eReference.Status.Active
                                        objSiteRcptCtr.PostBy = .UserID
                                        objSiteRcptCtr.LastUpdateBy = .UserID

                                        .SiteRcptCtr = objSiteRcptCtr
                                        '.ReserveReceiptNumber()
                                    End If
                                    .IsSuccessful = True
                                    If objSiteOPRHeader.StatusId <> eReference.Status.Posted Then
                                        .ProcessPaymentPremiumRelated()
                                    End If

                                    If vwPaymentPremiumRelated.OPRNumber = 0 Then vwPaymentPremiumRelated.OPRNumber = .ReservedReceiptNumber

                                Case eReference.DocSaveState.Print
                                    '.PrintPaymentPremiumRelated()
                                    .IsSuccessful = True
                                    If objSiteOPRHeader.StatusId <> eReference.Status.Posted Then
                                        '.CopyToStgObjects()
                                        .PostPaymentPremiumRelated()
                                    End If
                                    'If vwPaymentPremiumRelated.ApplicationNumber <> 0 Then
                                    '    Call SetMessage(String.Concat("Premium Payment.<br /><br />", "Please don't forget to print the application number<br />in the application form.!<br /><br />"), eSystemMessage.Information, True)
                                    'End If

                                Case eReference.DocSaveState.Cancel
                                    If objSiteOPRHeader.StatusId = eReference.Status.Posted Then
                                        .CancelPaymentPremiumRelated()
                                    End If
                            End Select

                            vwPaymentPremiumRelated.IsSuccessful = .IsSuccessful

                            If .IsSuccessful And Not mDocSaveState = eReference.DocSaveState.Print Then
                                Call SetMessage(String.Concat("Premium Payment.<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                            End If

                        End With
                    End With
                End If

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ProcessPaymentPremium.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ConfirmCancel(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "CANCEL"
                    .Message = String.Concat("Are you sure you want to cancel Invoice#", vwPaymentPremiumRelated.OPRNumber, "?")
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
                    .Message = "Are you sure you want to save this Invoice?"
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
                    .Message = String.Concat("Are you sure you want to print Invoice#", vwPaymentPremiumRelated.OPRNumber, "?")
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
            Dim objSitePAMaster As New bllWorking.BSitePAMaster
            Dim objSiteOPRInfo As New bllWorking.BSiteOPRInfo
            Dim objSiteOPRDtl As New bllWorking.BSiteOPRDtl
            Dim objSiteOPRAPRPy As New bllWorking.BSiteOPRAPRPy
            Dim objSiteOPRChkPy As New bllWorking.BSiteOPRChkPy
            Dim objSiteOPRCred As New bllWorking.BSiteOPRCred
            Dim objSiteOPRDebit As New bllWorking.BSiteOPRDebit
            Dim OBJSiteOPRECash As New bllWorking.BSiteOPRECash

            Dim objSiteOPRVAT As New bllWorking.BSiteOPRVAT

            Try
                With vwPaymentPremiumRelated
                    Dim dtSiteTmpTrn = objSiteTmpTrn.GetTmpTrnDt(.OPRNumber, eReference.DocTypeOPR, .ReceiptById)
                    Dim dtSiteOPRInfo = objSiteOPRInfo.GetOPRInfoDt(.OPRNumber, .ReceiptById)
                    Dim dtSiteOPRDtl = objSiteOPRDtl.GetOPRDtlDt(.OPRNumber, .ReceiptById)
                    Dim dtSiteOPRChkPy = objSiteOPRChkPy.GetOPRChkPyDt(.OPRNumber, .ReceiptById)
                    Dim dtSiteOPRCred = objSiteOPRCred.GetOPRCredDt(.OPRNumber, .ReceiptById)
                    Dim dtSiteOPRDebit = objSiteOPRDebit.GetOPRDebitDt(.OPRNumber, .ReceiptById)
                    Dim dtSiteOPRECash = OBJSiteOPRECash.GetOPRECashDt(.OPRNumber, .ReceiptById)
                    objSiteOPRVAT.GetSiteOPRVAT(.OPRNumber, .ReceiptById)
                    objSiteOPRHeader.GetOPRHeader(.OPRNumber, .ReceiptById)
                    objSitePAMaster.GetSitePAMAster(.OPRNumber, .ReceiptById)
                    objSiteOPRAPRPy.GetOPRAPRPy(.OPRNumber, .ReceiptById)
                    'Fill transaction type
                    Dim mIsNewBiz As Boolean
                    Dim mIsNewgenNewBiz As Boolean
                    Dim mIsAPR As Boolean
                    Dim mPolmod As String = String.Empty
                    Dim mPayTyp As String = String.Empty
                    Dim mCashAmount As Decimal = 0
                    Dim mBalFrq As Boolean

                    '---------------------------------------------------------------------
                    If objSiteOPRHeader.CancelFlag = 1 Then
                        .DocSaveState = eReference.DocSaveState.Cancel
                    ElseIf objSiteOPRHeader.PrtFlag = 1 Then
                        .DocSaveState = eReference.DocSaveState.Print
                    Else
                        .DocSaveState = eReference.DocSaveState.ViewEdit
                    End If
                    '---------------------------------------------------------------------

                    If dtSiteTmpTrn.Rows.Count <> 0 Then
                        For Each dr As DataRow In dtSiteTmpTrn.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                .OPRNumber = cDataType.fLong.IfNull(dr.Item("rcptno"))
                                .SourceSite = cDataType.fString.IfNull(dr.Item("colloff"))

                                .OPRCurrency = cDataType.fString.IfNull(dr.Item("curcod"))
                                .OPRDate = cDataType.fDate.IfNull(dr.Item("trndat"))
                                .ECRNumber = cDataType.fLong.IfNull(dr.Item("ecrnmbr"))
                                .ECRDate = cDataType.fDate.IfNull(dr.Item("ecrdate"))
                                .PolFrq = cDataType.fInteger.IfNull(dr.Item("polfrq"))
                                mBalFrq = cDataType.fBoolean.IfNull(dr.Item("balfrq"))

                                Select Case Mid(Trim(cDataType.fString.IfNull(dr.Item("trncod"))), 1, 3)
                                    Case eReference.PayTypeCCA, eReference.PayTypeDCA
                                        mPayTyp = Mid(cDataType.fString.IfNull(dr.Item("trncod")), 1, 3)
                                    Case Else
                                        mPayTyp = cDataType.fString.IfNull(dr.Item("paytyp"))
                                        mCashAmount += cDataType.fDecimal.IfNull(dr.Item("cshamt"))
                                End Select
                                If dtSiteOPRECash.Rows.Count > 0 Then
                                    mPayTyp = eReference.PayTypeECP
                                End If
                                mPolmod = cDataType.fString.IfNull(dr.Item("metcod"))

                                'Exit For
                            End If
                        Next
                    End If
                    'Set Policy Number
                    .PolicyNumber = objSiteOPRHeader.OPRPolNum

                    If Mid(objSiteOPRHeader.OPRFlags, 3, 1) = 1 Then
                        mIsNewBiz = True
                        If .PolicyNumber <> String.Empty Then
                            mIsNewgenNewBiz = True
                        End If
                    End If
                    If Mid(objSiteOPRHeader.OPRFlags, 1, 1) = 1 Then mIsAPR = True
                    If mIsNewBiz Then
                        .TransactionType = eReference.TranType.NewBusiness
                        .NewgenNewBusinessTag = mIsNewgenNewBiz
                    Else
                        .TransactionType = IIf(mPolmod = "GPA", eReference.TranType.GPA, eReference.TranType.Regular)
                    End If
                    .PolicyNumber = objSiteOPRHeader.OPRPolNum
                    .PolType = GetPolTyp(mPolmod)
                    .PType = GetPType(mPolmod)
                    .IsGrossAmountLocked = True
                    .IsSourceSiteLocked = True
                    .PolMod = mPolmod
                    .PayslipCodeTag = IIf(mPolmod = "HMO", True, False)
                    .BillNoTag = IIf(mPolmod = "GLF", True, False)
                    .OPRRemarks = objSiteOPRHeader.OPRRemarks

                    'POLICY DETAILS
                    If Not .GpaPaymentTag Then
                        If (.PolicyNumber <> String.Empty AndAlso .PolicyNumber.IndexOf("-") = -1) Or .NewgenNewBusinessTag Then
                            Call GetPolicyDetails(sender, e)
                            .BalanceToHigher = mBalFrq
                            .NewPolFrq = 0
                        Else
                            If .PolicyNumber = String.Empty Then .NoPolicy = True
                            .ApplicationNumber = objSiteOPRHeader.OPRApplctn
                            .InsuredIDTag = True
                            .InsuredID = objSiteOPRHeader.OPRInsID
                            .InsuredLastName = objSiteOPRHeader.OPRInsLNam
                            .InsuredFirstName = objSiteOPRHeader.OPRInsFNam
                            .InsuredMiddleName = objSiteOPRHeader.OPRInsMNam
                            .InsuredName = Trim(String.Concat(.InsuredLastName, IIf(.InsuredFirstName.Equals(String.Empty), String.Empty, ", " & .InsuredFirstName), " ", .InsuredMiddleName))
                            .PayorIDTag = True
                            .PayorID = objSiteOPRHeader.OPRPyrID
                            .PayorLastName = objSiteOPRHeader.OPRPyrLNam
                            .PayorFirstName = objSiteOPRHeader.OPRPyrFNam

                            .PayorAddress = objSiteOPRHeader.OPRPyrAdr
                            .PayorTin = objSiteOPRHeader.OPRPyrTin
                            .BillNo = objSiteOPRHeader.BillNo
                            .SubsNo = objSiteOPRHeader.SubsNo

                            .PayorName = Trim(String.Concat(.PayorLastName, IIf(.PayorFirstName.Equals(String.Empty), String.Empty, IIf(.PayorLastName.Equals(String.Empty), String.Empty, ", ") & .PayorFirstName), " ", .PayorMiddleName))
                            .PayorType = IIf(.PayorLastName = String.Empty, "C", "M")
                            .PolCur = objSiteOPRHeader.OPRPlnCry
                            .AgentIDTag = True
                            .AgentID = objSiteOPRHeader.OPRAgID
                            .AgentSearchTag = eReference.AgentTagType.Agent
                            If .AgentID > 0 Then .CallLoadAgent = True
                            If .PolMod = "HMO" Then
                                Try
                                    .PayslipCode = Split(objSiteOPRHeader.OPRRemarks, " - ")(1)
                                Catch ex As Exception
                                    .PayslipCode = String.Empty
                                End Try
                            End If
                            'ocsuat error
                            'If .PolMod = "GLF" Then
                            '    Try
                            '        .BillNo = Split(objSiteOPRHeader.OPRRemarks, " - ")(1)
                            '        If .BillNo <> "" Then
                            '            If Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Group"), "false")) Then
                            '                Call LoadPolicyBilling(sender, e)
                            '            End If
                            '        End If
                            '    Catch ex As Exception
                            '        .BillNo = String.Empty
                            '    End Try
                            'End If
                        End If
                    Else
                        'OPR Header
                        For Each dr As DataRow In dtSiteOPRDtl.Rows
                            Select Case cDataType.fString.IfNull(dr.Item("trnx_code"))
                                Case eReference.ColrefGPA, eReference.ColrefGpaRenewal, eReference.ColrefGpaRefund
                                    .GpaType = cDataType.fInteger.IfNull(dr.Item("trnx_code"))
                                    Exit For
                            End Select
                        Next
                        Select Case .GpaType
                            Case eReference.ColrefGPA, eReference.ColrefGpaRefund
                                .PolicyNumber = objSitePAMaster.PolicyNumber
                                .AgentSearchTag = eReference.AgentTagType.SalesOfficer
                                .AgentIDTag = True
                                .GpaSalesOff = objSitePAMaster.Agent1
                                Call GetAgentDetails(sender, e)
                                Call LoadGpaPolicy(sender, e)
                                Call LoadGpaSettings(sender, e)
                                .AgentSearchTag = eReference.AgentTagType.PromoOfficer
                                .GpaPromoOff = objSitePAMaster.Agent2
                                .AgentIDTag = True
                                Call GetAgentDetails(sender, e)
                            Case eReference.ColrefGpaRenewal
                                .PolicyNumber = objSitePAMaster.PolicyNumber
                                .AgentSearchTag = eReference.AgentTagType.Usd1
                                .AgentIDTag = True
                                .GpaUsd1 = objSitePAMaster.USD1
                                Call GetAgentDetails(sender, e)
                                Call LoadGpaPolicy(sender, e)
                                Call LoadGpaSettings(sender, e)
                                .AgentSearchTag = eReference.AgentTagType.Asd
                                .AgentIDTag = True
                                .GpaAsd1 = objSitePAMaster.ASD
                                Call GetAgentDetails(sender, e)
                        End Select
                        .GpaCardNo = objSitePAMaster.PACardID
                        If objSiteOPRHeader.CancelFlag = 0 Then
                            Call LoadGpaCardNo(sender, e)
                        End If
                        .GpaCardNoTag = True
                        .PayorID = objSiteOPRHeader.OPRPyrID
                        Call GetPayorDetails(sender, e)
                        .PayorIDTag = True
                        .InsuredID = objSiteOPRHeader.OPRInsID
                        Call GetInsuredDetails(sender, e)
                        .InsuredIDTag = True

                    End If

                    'Payment Type Details
                    If Not .TransactionType = eReference.TranType.GPA Then
                        .PrevPayType = mPayTyp
                        .OPRPaymentType = mPayTyp
                        mPayTyp = IIf(mPayTyp = eReference.PayTypeECP, eReference.PayTypeCSH, mPayTyp)
                    End If

                    Dim dtPaymentTypeList As New DataTable
                    Dim mCptDtlList As New List(Of cPaymentType)

                    dtPaymentTypeList = OBJSiteOPRECash.GetOPRECashDt(.OPRNumber, .ReceiptById)
                    If dtPaymentTypeList.Rows.Count > 0 Then
                        For Each dr As DataRow In dtPaymentTypeList.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                mCptDtlList.Add(New cPaymentType(dr, eReference.PayTypeECP))
                                AddToTotalAmount(eReference.PayTypeECP, cDataType.fDecimal.IfNull(dr.Item("amount")))
                                mCashAmount -= cDataType.fDecimal.IfNull(dr.Item("amount"))
                            End If
                        Next
                    End If
                    If mCashAmount > 0 Then
                        mCptDtlList.Add(New cPaymentType(mCashAmount))
                        AddToTotalAmount(eReference.PayTypeCSH, mCashAmount)
                    End If
                    dtPaymentTypeList = objSiteOPRChkPy.GetOPRChkPyDt(.OPRNumber, .ReceiptById)
                    If dtPaymentTypeList.Rows.Count > 0 Then
                        For Each dr As DataRow In dtPaymentTypeList.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                mCptDtlList.Add(New cPaymentType(dr, eReference.PayTypeCHQ))
                                AddToTotalAmount(eReference.PayTypeCHQ, cDataType.fDecimal.IfNull(dr.Item("amount")))
                            End If
                        Next
                    End If
                    dtPaymentTypeList = objSiteOPRCred.GetOPRCredDt(.OPRNumber, .ReceiptById)
                    If dtPaymentTypeList.Rows.Count > 0 Then
                        For Each dr As DataRow In dtPaymentTypeList.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                mCptDtlList.Add(New cPaymentType(dr, eReference.PayTypeCCA))
                                AddToTotalAmount(eReference.PayTypeCCA, cDataType.fDecimal.IfNull(dr.Item("amount")))
                            End If
                        Next
                    End If
                    dtPaymentTypeList = objSiteOPRDebit.GetOPRDebitDt(.OPRNumber, .ReceiptById)
                    If dtPaymentTypeList.Rows.Count > 0 Then
                        For Each dr As DataRow In dtPaymentTypeList.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                mCptDtlList.Add(New cPaymentType(dr, eReference.PayTypeDCA))
                                AddToTotalAmount(eReference.PayTypeDCA, cDataType.fDecimal.IfNull(dr.Item("amount")))
                            End If
                        Next
                    End If

                    .OPRGrossAmount = .PaymentTotalAmount
                    .lstPaymentTypeDetails = mCptDtlList

                    Dim mNewBizList As New List(Of cNewBiz)
                    If dtSiteOPRInfo.Rows.Count > 0 Then
                        If Not mIsNewBiz OrElse dtSiteOPRInfo.Rows.Count = 1 Then
                            .PayorID = objSiteOPRHeader.OPRPyrID
                            .InsuredID = objSiteOPRHeader.OPRInsID
                            For Each dr As DataRow In dtSiteOPRInfo.Rows
                                If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                    .PayorLastName = cDataType.fString.IfNull(dr.Item("ownr_lname"))
                                    .PayorFirstName = cDataType.fString.IfNull(dr.Item("ownr_fname"))
                                    .PayorMiddleName = cDataType.fString.IfNull(dr.Item("ownr_mi"))
                                    .PayorDateOfBirth = cDataType.fDate.IfNull(dr.Item("ownr_bday"))
                                    .PayorTitle = cDataType.fString.IfNull(dr.Item("ownr_tit"))
                                    .PayorSuffix = cDataType.fString.IfNull(dr.Item("ownr_sfx"))
                                    .PayorType = cDataType.fString.IfNull(dr.Item("ownr_sex"))
                                    .PayorPlaceOfBirth = cDataType.fString.IfNull(dr.Item("ownr_plc"))
                                    .PayorName = .PayorName
                                    .PayorIDTag = True
                                    'mApplNo = pDataRow.Item("appl_no")
                                    .InsuredLastName = cDataType.fString.IfNull(dr.Item("ins_lname"))
                                    .InsuredFirstName = cDataType.fString.IfNull(dr.Item("ins_fname"))
                                    .InsuredMiddleName = cDataType.fString.IfNull(dr.Item("ins_mi"))
                                    .InsuredDateOfBirth = cDataType.fDate.IfNull(dr.Item("ins_bday"))
                                    .InsuredTitle = cDataType.fString.IfNull(dr.Item("ins_tit"))
                                    .InsuredSuffix = cDataType.fString.IfNull(dr.Item("ins_sfx"))
                                    .InsuredType = cDataType.fString.IfNull(dr.Item("ins_sex"))
                                    .InsuredPlaceOfBirth = cDataType.fString.IfNull(dr.Item("ins_plc"))
                                    .InsuredName = .InsuredName
                                    .InsuredIDTag = True
                                End If
                                Exit For
                            Next
                            If .PayorID = .InsuredID And .InsuredID <> 0 Then
                                .SamePayorInsured = "Y"
                            Else
                                If .InsuredID = 0 OrElse .PayorID = 0 Then
                                    If .InsuredType = .PayorType AndAlso .InsuredName = .PayorName AndAlso .InsuredDateOfBirth = .PayorDateOfBirth Then
                                        .SamePayorInsured = "Y"
                                    Else
                                        .SamePayorInsured = "N"
                                    End If
                                Else
                                    .SamePayorInsured = "N"
                                End If
                            End If
                        Else
                            .WithNewBiz = True
                            For Each dr As DataRow In dtSiteOPRInfo.Rows
                                If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                    mNewBizList.Add(New cNewBiz(dr, eReference.DocTypeOPR))
                                    If .NewBizName.Equals(String.Empty) Then
                                        .NewBizName = cDataType.fString.IfNull(dr.Item("ownr_lname"))
                                        .PayorType = "C"
                                    End If
                                End If
                            Next
                            .lstNewBiz = mNewBizList
                        End If

                    End If

                    Dim mRptDtl As New List(Of cReceiptDetail)
                    Dim mIsGPA As Boolean
                    If dtSiteOPRDtl.Rows.Count > 0 Then
                        For Each dr As DataRow In dtSiteOPRDtl.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) = objSiteOPRHeader.StatusId Then
                                Select Case dr.Item("act_type")
                                    Case eReference.TrnxGPA, eReference.TrnxGpaRefund, eReference.TrnxGpaRenewal
                                        mIsGPA = True
                                End Select

                                If cDataType.fString.IfNull(dr.Item("trnx_code")) = eReference.ColrefAgentsAccount Then
                                    .CommissionAmount = cDataType.fDecimal.IfNull(dr.Item("amount"))
                                End If

                                mRptDtl.Add(New cReceiptDetail(dr, eReference.DocTypeOPR))
                                AddToTotalAmount(eReference.DocTypeOPR, cDataType.fDecimal.IfNull(dr.Item("amount")))
                            End If
                        Next
                        .lstReceiptDetails = mRptDtl
                    End If

                    If mIsAPR Then
                        .WithAPR = mIsAPR
                        If objSiteOPRAPRPy.StatusId = objSiteOPRHeader.StatusId Then
                            .APRNumber = objSiteOPRAPRPy.APRNmbr
                            .APRDate = objSiteOPRAPRPy.APRDate
                            .APRAmount = objSiteOPRAPRPy.Amount
                        End If
                    End If

                    'VAT DETAILS
                    If objSiteOPRVAT.StatusId = objSiteOPRHeader.StatusId Then
                        .VATWithholdingTax = objSiteOPRVAT.WTaxAmt
                        .VATTotalCollection = objSiteOPRVAT.GrossAmt
                        .NonVATCollection = objSiteOPRVAT.NonVatColl
                        .VATExemptCollection = objSiteOPRVAT.VatExemptColl
                        .VATAmountNetWTax = objSiteOPRVAT.NetAmt
                        .VATAmount = objSiteOPRVAT.VatAmt
                        .VATableCollection = objSiteOPRVAT.VatableColl
                    End If

                    'Hide Payments if CANCELLED
                    If objSiteOPRHeader.CancelFlag = 1 Then
                        .DocSaveState = eReference.DocSaveState.Cancel
                        .PaymentTypeTag = False
                    ElseIf objSiteOPRHeader.StatusId = eReference.Status.Posted Then
                        .DocPrinted = IIf(objSiteOPRHeader.PrtFlag = 1, True, False)
                        .DocSaveState = eReference.DocSaveState.Print 'ALLOW REPRINT AND CANCEL OF PRINTED/POSTED RECIPTS
                    Else
                        .DocSaveState = eReference.DocSaveState.ViewEdit
                    End If

                End With
            Catch ex As Exception
                vwPaymentPremiumRelated.DocSaveState = eReference.DocSaveState.Initial
                Call ClearScreenMain(sender, e)
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadOPR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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
        Private Sub CreditCardFetchData(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim dtLocal As DataTable
                Dim objLocal As New bllWorking.BSiteOPRCred
                Dim cptLocalList As New List(Of cPaymentType)
                Dim strRemark As String = Nothing

                With vwPaymentPremiumRelated

                    dtLocal = objLocal.GetOPRCredByApprvCodeDt(.CreditCardApprovalCode, .PayorID)
                    If dtLocal.Rows.Count > 0 Then
                        For Each dr As DataRow In dtLocal.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) <> 4 Then
                                strRemark = String.Concat("Card payment Linked from OPR#", dr.Item("opr_nmbr"))
                                cptLocalList.Add(New cPaymentType(dr, eReference.PayTypeCCA))
                            End If
                        Next
                    End If

                    For Each cptLocal As cPaymentType In cptLocalList
                        .CreditCardTerminalUse = cptLocal.TerminalUse
                        LoadMerchantId(Me, EventArgs.Empty)
                        LoadDefaultTerminal(Me, EventArgs.Empty)
                        .CreditCardSwipeDate = cptLocal.SwipeDate
                        .CreditCardSwipeTime = cptLocal.SwipeDate
                        .CreditCardMerchant = cptLocal.MerchantID
                        .CreditCardNumber = cptLocal.CardNumber
                        Call ValidateCreditCardNo(sender, e)
                        .CreditCardApprovalCode = cptLocal.ApprovalCode
                        .CreditCardBatchNumber = cptLocal.BatchNumber
                        .CreditCardRemarks = strRemark
                    Next cptLocal

                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CreditCardFetchData.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub DebitCardFetchData(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim dtLocal As DataTable
                Dim objLocal As New bllWorking.BSiteOPRDebit
                Dim cptLocalList As New List(Of cPaymentType)
                Dim strRemark As String = Nothing

                With vwPaymentPremiumRelated

                    dtLocal = objLocal.GetOPRDebitByChargeSlipDt(.DebitCardChargeSlip, .PayorID)
                    If dtLocal.Rows.Count > 0 Then
                        For Each dr As DataRow In dtLocal.Rows
                            If cDataType.fInteger.IfNull(dr.Item("status_id")) <> 4 Then
                                strRemark = String.Concat("Card payment Linked from OPR#", dr.Item("opr_nmbr"))
                                cptLocalList.Add(New cPaymentType(dr, eReference.PayTypeDCA))
                            End If
                        Next
                    End If

                    For Each cptLocal As cPaymentType In cptLocalList
                        .DebitCardTerminalUse = cptLocal.TerminalUse
                        LoadMerchantId(Me, EventArgs.Empty)
                        LoadDefaultTerminal(Me, EventArgs.Empty)
                        .DebitCardSwipeDate = cptLocal.SwipeDate
                        .DebitCardSwipeTime = cptLocal.SwipeDate
                        .DebitCardMerchant = cptLocal.MerchantID
                        .DebitCardBankNetwork = cptLocal.Network
                        .DebitCardBankName = cptLocal.Bank
                        .DebitCardAccountType = cptLocal.CASA
                        .DebitCardAccountNumber = cptLocal.AccountNumber
                        .DebitCardChargeSlip = cptLocal.ApprovalCode
                        .DebitCardBatchNumber = cptLocal.BatchNumber
                        .DebitCardRemarks = strRemark
                    Next cptLocal

                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error DebitCardFetchData.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ValidateCreditCardNo(ByVal sender As Object, ByVal e As EventArgs)

            Try

                Dim objLocal As New bllWorking.BSiteOPRCred
                Dim strItem As String = String.Empty

                With vwPaymentPremiumRelated
                    .CreditCardNumberTag = False
                    If IsValidCreditCardNumber() Then
                        strItem = objLocal.ValidateCreditCardNumber(.CreditCardNumber).ToString
                        .CreditCardNumberTag = GetItemValue(strItem, "|", 0)
                        If .CreditCardNumberTag Then
                            .CreditCardType = GetItemValue(strItem, "|", 1)
                            .CreditCardTypeDesc = GetItemValue(strItem, "|", 2)
                        Else
                            Call SetMessage(GetItemValue(strItem, "|", 3), eSystemMessage.Warning, True)
                        End If
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ValidateCreditCardNo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Function AgeYears(ByVal datBirthDate As Date) As Integer
            '-- source: http://www.fmsinc.com/microsoftaccess/modules/examples/AgeCalculation.asp
            ' Comments: Returns the age in years
            ' Params  : datBirthDate    Date to check
            ' Returns : Number of years
            ' Source  : Total Visual SourceBook

            Dim intYears As Integer

            Try
                intYears = Year(Now) - Year(datBirthDate)

                If DateSerial(Year(Now), Month(datBirthDate), Day(datBirthDate)) > Now Then
                    ' Subtract a year if birthday hasn't arrived this year
                    intYears = intYears - 1
                End If

                Return intYears
            Catch ex As Exception
                Throw New Exception(String.Concat("AgeYears : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AgeYears.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Sub AddCashPayment(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cPaymentType)
            Dim cptLocal As New cPaymentType()

            Dim mIsPaymentExists As Boolean = True

            Try
                With vwPaymentPremiumRelated
                    .IsPayTypeSuccessful = False
                    'Check & Cash
                    If IsValidPaymentTypeDetails(eReference.PayTypeCSH) Then
                        If .OPRPaymentType = eReference.PayTypeCHQ And .OPRCashAmount > 0 Then

                            mIsPaymentExists = CheckIfExisting("PAYTYPE", eReference.PayTypeCSH, String.Empty, cptLocal.Amount)
                            If mIsPaymentExists Then
                                Call SetMessage("Payment details or mode already exists.", eSystemMessage.Warning, True)
                                Exit Sub
                            Else
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
                With vwPaymentPremiumRelated
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
                            Case eReference.PayTypeCCA
                                cptLocal = New cPaymentType(
                                    .CreditCardAmount,
                                    .CreditCardTerminalUse,
                                    .CreditCardMerchant,
                                    .CreditCardSwipeDate,
                                    .CreditCardType,
                                    .CreditCardNumber,
                                    .CreditCardBatchNumber,
                                    .CreditCardApprovalCode,
                                    .CreditCardRemarks)
                            Case eReference.PayTypeDCA
                                cptLocal = New cPaymentType(
                                    .DebitCardAmount,
                                    .DebitCardTerminalUse,
                                    .DebitCardMerchant,
                                    .DebitCardSwipeDate,
                                    .DebitCardBankNetwork,
                                    .DebitCardBankName,
                                    .DebitCardAccountType,
                                    .DebitCardAccountNumber,
                                    .DebitCardBatchNumber,
                                    .DebitCardChargeSlip,
                                    .DebitCardRemarks)
                            Case eReference.PayTypeECP
                                cptLocal = New cPaymentType(
                                    .ECashPaymentAmount,
                                    .ECashPaymentChannel,
                                    .ECashPaymentReferenceNumber,
                                    .ECashPaymentRemarks,
                                    GetServiceFeeRate(.ECashPaymentChannel))
                        End Select

                        mIsPaymentExists = CheckIfExisting("PAYTYPE", cptLocal.PaymentType, String.Concat(cptLocal.ReferenceNumber, "|", IIf(cptLocal.PaymentType = eReference.PayTypeCHQ, cptLocal.Bank, cptLocal.ApprovalCode)), cptLocal.Amount)
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
                With vwPaymentPremiumRelated
                    Select Case pPayType
                        Case eReference.PayTypeCSH
                            .CashTotalAmount += pAmount
                        Case eReference.PayTypeCHQ
                            .CheckTotalAmount += pAmount
                        Case eReference.PayTypeCCA
                            .CreditCardTotalAmount += pAmount
                        Case eReference.PayTypeDCA
                            .DebitCardTotalAmount += pAmount
                        Case eReference.PayTypeECP
                            .ECashPaymentTotalAmount += pAmount
                        Case eReference.DocTypeOPR
                            .ReceiptTotalAmount += pAmount
                        Case "NewBiz"
                            .NewBizTotalAmount += pAmount
                    End Select
                End With
            Catch ex As Exception
                Throw New Exception(String.Concat("AddToTotalAmount : ", ex.Message))
            End Try

        End Sub

        Private Sub DeletePaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cPaymentType)

            Try
                With vwPaymentPremiumRelated
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

        Private Sub AddReceiptDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cReceiptDetail)
            Dim rptLocal As New cReceiptDetail()

            Try
                With vwPaymentPremiumRelated
                    .isReceiptSuccessful = False
                    If IsValidReceiptDetails() Then
                        rptLocal = New cReceiptDetail()
                        rptLocal.TrnxCode = .ReceiptTransactionCode
                        rptLocal.ActType = .ReceiptTransactionType
                        rptLocal.TrnxDesc = .ReceiptTransactionDesc
                        rptLocal.DueDate = cDataType.fDate.Empty
                        rptLocal.Amount = .ReceiptAmount
                        rptLocal.ReceiptType = eReference.DocTypeOPR

                        Dim mIsExists = CheckIfExisting("RECEIPT", rptLocal.ActType, rptLocal.TrnxCode, 0)
                        If mIsExists Then
                            Call SetMessage("Transaction code exists.", eSystemMessage.Warning, True)
                            Exit Sub
                        Else
                            lstLocal = .lstReceiptDetails
                            lstLocal.Add(rptLocal)
                            Call AddToTotalAmount(eReference.DocTypeOPR, rptLocal.Amount)
                            If .ReceiptTransactionCode = eReference.ColrefAgentsAccount Then
                                '.WithCommission = True
                                .CommissionAmount += .ReceiptAmount
                            End If

                            .lstReceiptDetails = lstLocal
                            .isReceiptSuccessful = True
                        End If
                    Else
                        Call ClearScreenReceiptDetails(sender, e)
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddReceiptDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub DeleteReceiptDetails(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cReceiptDetail)

            Try
                With vwPaymentPremiumRelated
                    .isReceiptSuccessful = False

                    For Each rptLocal As cReceiptDetail In .lstReceiptDetails '.PaymentTypeListSession
                        'If rptLocal.ReceiptID <> .ReceiptDetailID Then
                        If rptLocal.IsSelected = False And .GpaPaymentTag = False Then
                            lstLocal.Add(rptLocal)
                        Else
                            Call AddToTotalAmount(eReference.DocTypeOPR, -rptLocal.Amount)
                            If rptLocal.TrnxCode = eReference.ColrefAgentsAccount Then
                                .WithCommission = False
                                .CommissionAmount -= rptLocal.Amount
                            End If
                        End If
                    Next
                    .lstReceiptDetails = lstLocal
                    .isReceiptSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error DeleteReceiptDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Public Sub ComputeVatDetails(ByVal sender As Object, ByVale As EventArgs)
            Dim objBll As New bllReference.BTrnRef
            Dim vatable_coll As Decimal = 0
            Dim non_vat_coll As Decimal = 0
            Dim vatexempt_coll As Decimal = 0
            Dim vat_amt As Decimal = 0
            Dim net_amt As Decimal = 0
            Dim wtax_amt As Decimal = 0
            Dim gross_amt As Decimal = 0

            Try
                With vwPaymentPremiumRelated
                    For Each rptLocal As cReceiptDetail In .lstReceiptDetails
                        objBll.GetReceiptTransactionDetails(rptLocal.TrnxCode, eReference.DocTypeOPR)
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
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ComputeVatDetails.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub AddNewBizPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPaymentPremiumRelated
                    .IsNewBizSuccessful = False
                    If IsValidNewBizPayor() Then
                        .IsNewBizSuccessful = True
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddNewBizPayor.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub AddNewBiz(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cNewBiz)
            Dim cnbLocal As New cNewBiz()

            Try
                With vwPaymentPremiumRelated
                    .IsNewBizSuccessful = False
                    If IsValidNewBiz() Then
                        cnbLocal = New cNewBiz()
                        cnbLocal.Name = .NewBizName
                        cnbLocal.LastName = .NewBizLastName
                        cnbLocal.FirstName = .NewBizFirstName
                        cnbLocal.MiddleName = .NewBizMiddleName
                        cnbLocal.DoB = .NewBizDoB
                        cnbLocal.ApplNo = .NewBizApplNo
                        cnbLocal.EcrNumber = .NewBizEcrNumber
                        cnbLocal.EcrDate = .NewBizEcrDate
                        cnbLocal.Amount = .NewBizAmount
                        cnbLocal.Suffix = .NewBizSuffix
                        cnbLocal.Title = .NewBizTitle
                        cnbLocal.Sex = .NewBizSex
                        cnbLocal.PlaceOfBirth = .NewBizPlaceOfBirth
                        cnbLocal.PrsPid = .NewBizInsId
                        cnbLocal.PayPrsPid = .NewBizPayId

                        lstLocal = .lstNewBiz
                        lstLocal.Add(cnbLocal)
                        Call AddToTotalAmount("NewBiz", cnbLocal.Amount)

                        .lstNewBiz = lstLocal
                        .IsNewBizSuccessful = True
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error AddNewBiz.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub DeleteNewBiz(ByVal sender As Object, ByVal e As EventArgs)
            Dim lstLocal As New List(Of cNewBiz)

            Try
                With vwPaymentPremiumRelated
                    .IsNewBizSuccessful = False

                    For Each cnbLocal As cNewBiz In .lstNewBiz '.PaymentTypeListSession
                        If cnbLocal.Id <> .NewBizID Then
                            lstLocal.Add(cnbLocal)
                        Else
                            Call AddToTotalAmount("NewBiz", -cnbLocal.Amount)
                        End If
                    Next
                    .lstNewBiz = lstLocal
                    .IsNewBizSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error DeleteNewBiz.<br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GenerateReport(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwReport
                    .IsSuccessful = False
                    Select Case .ReportType
                        Case eReport.Receipt, eReport.ReceiptAppno
                            .RptParamString = String.Concat(vwPaymentPremiumRelated.OPRNumber, "|", Not .IsPreview, "|", .SiteCode, "|", .UserId, "|", vwPaymentPremiumRelated.ApplicationNumber, "|", vwPaymentPremiumRelated.AgentSalesForce)
                            If Not .IsPreview Then SetMessage(String.Concat("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!"), eSystemMessage.Information, True)
                    End Select
                    .IsSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GenerateReport.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GetNewBiz(ByVal sender As Object, ByVal e As EventArgs)
            Dim cptLocal As New cPaymentType

            Try
                With vwPaymentPremiumRelated
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
                            Case eReference.PayTypeCCA
                                .CreditCardAmount = cptLocal.Amount
                                .CreditCardTerminalUse = cptLocal.TerminalUse
                                .CreditCardSwipeDate = cptLocal.SwipeDate
                                .CreditCardSwipeTime = cptLocal.SwipeDate
                                .CreditCardMerchant = cptLocal.MerchantID
                                .CreditCardNumber = cptLocal.CardNumber
                                .CreditCardType = cptLocal.CardType
                                .CreditCardApprovalCode = cptLocal.ApprovalCode
                                .CreditCardRemarks = cptLocal.Remarks
                            Case eReference.PayTypeDCA
                                .DebitCardAmount = cptLocal.Amount
                                .DebitCardTerminalUse = cptLocal.TerminalUse
                                .DebitCardSwipeDate = cptLocal.SwipeDate
                                .DebitCardSwipeTime = cptLocal.SwipeDate
                                .DebitCardMerchant = cptLocal.MerchantID
                                .DebitCardBankNetwork = cptLocal.Network
                                .DebitCardBankName = cptLocal.Bank
                                .DebitCardAccountType = cptLocal.CASA
                                .DebitCardAccountNumber = cptLocal.AccountNumber
                                .DebitCardRemarks = cptLocal.Remarks
                            Case Else
                        End Select
                    Next
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetNewBiz.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

#End Region

    End Class

End Namespace

