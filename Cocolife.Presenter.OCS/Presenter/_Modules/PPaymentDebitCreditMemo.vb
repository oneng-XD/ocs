#Region "Description"
' PAGE NAME     : Payment Debit Credit Memo Presenter
' CREATED BY    : Junie
' CREATED DATE  : 04/20/2025
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
Imports Cocolife.Utility.OCS.Common
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
Imports System.Configuration
#End Region


Namespace Payment
    Public Class PPaymentDebitCreditMemo

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPaymentDebitCreditMemo As Payment.IPaymentDebitCreditMemo
        Private vwConfirmMsg As preMessages.IConfirmationMessage
        Private vwReport As preReport.IReport

        Private objPaymentDebitCreditMemo As bllPayment.BPaymentDebitCreditMemo
#End Region

#Region "Constructor"
        Sub New()

        End Sub

        Sub New(ByVal pView As Payment.IPaymentDebitCreditMemo)
            vwSysMsg = pView
            vwPaymentDebitCreditMemo = pView
            vwConfirmMsg = pView
            vwReport = pView
            With vwPaymentDebitCreditMemo
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain

                AddHandler .LoadSalesInvoice, AddressOf LoadSalesInvoice
                AddHandler .LoadDebitCreditMemo, AddressOf LoadDebitCreditMemo
                AddHandler .LoadViewDMCM, AddressOf LoadViewDMCM
                AddHandler .LoadBillingType, AddressOf LoadBillingType
                AddHandler .LoadApprover, AddressOf LoadApprover
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                AddHandler .ConfirmSend, AddressOf ConfirmSend
                AddHandler .ConfirmCancel, AddressOf ConfirmCancel
                AddHandler .ProcessDebitCreditMemo, AddressOf ProcessDebitCreditMemo
                AddHandler .ClearScreenSIInfo, AddressOf ClearScreenSIInfo
                AddHandler .GenerateReport, AddressOf GenerateReport
                AddHandler .CheckUnitPrice, AddressOf CheckUnitPrice
                AddHandler .LoadViewSI, AddressOf LoadViewSI

       
            End With
        End Sub

#End Region

#Region "Validation"
        Private Function IsValidInvoiceNumber() As Boolean

            Try

                With vwPaymentDebitCreditMemo

                    If .InvoiceNumber = cDataType.fLong.Empty Then
                        Call SetMessage("Input Invoice No.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidInvoiceNumber : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaCardID.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function
        Private Sub CheckUnitPrice(ByVal sender As Object, ByVal e As EventArgs)
            Dim objBLL As New bllStaging.BDebitCredit
            Try

                With vwPaymentDebitCreditMemo
                    .IsSuccessful = False

                    If .UnitPrice <= 0 Then
                        Call SetMessage("Unit Price Amount should be greater than zero(0).", eSystemMessage.Warning, True)
                        Return
                    Else
                        .IsSuccessful = True
                        objBLL.LoadTaxAmount(.ReferenceNo, .UnitPrice, .Quantity)
                        .VATable = objBLL.VatSales
                        .VATExempt = objBLL.VatExemptSales
                        .VATAmount = objBLL.VatAmount
                        .NonVAT = objBLL.NonVatSales
                        .TotalSales = objBLL.TotalSales
                        .NetOfWitholdingTax = objBLL.NetWTax
                        .WitholdingTax = objBLL.WTax
                        .Discount = objBLL.Discount
                        .DiscountID = objBLL.DiscountID
                        .TotalAmount = objBLL.TotalAmount
                    End If

                  
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckUnitPrice.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub
        Private Function IsValidTransactionID() As Boolean

            Try

                With vwPaymentDebitCreditMemo

                    If .DebitCreditID = cDataType.fLong.Empty Then
                        Call SetMessage("Input DMCM Transaction ID.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidDMCMNumber : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaCardID.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function
        Private Function IsValidLoadViewDMCM() As Boolean

            Try

                With vwPaymentDebitCreditMemo
                    If .ViewDMCMFrom > .ViewDMCMTo Then
                        Call SetMessage("View Date From exceeds Date To.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case .ViewDMCMFrom
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

                    Select Case .ViewDMCMTo
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
                Throw New Exception(String.Concat("IsValidLoadViewAR : ", ex.Message))
            End Try

        End Function
        Private Function IsValidLoadViewSI() As Boolean

            Try

                With vwPaymentDebitCreditMemo
                    If .ViewSIFrom > .ViewSITo Then
                        Call SetMessage("View Date From exceeds Date To.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case .ViewSIFrom
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

                    Select Case .ViewSITo
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
                Throw New Exception(String.Concat("IsValidLoadViewSI : ", ex.Message))
            End Try

        End Function
#End Region 'Validation


#Region "Transactions"

#Region "Load References"
        

        Private Sub LoadBillingType(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BParamRef
                vwPaymentDebitCreditMemo.dtBillingType = objBLL.GetRefBillType
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error Load Billing Type.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub
        Private Sub LoadApprover(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllStaging.BDebitCredit
                vwPaymentDebitCreditMemo.dtApprover = objBLL.GetApprover(vwPaymentDebitCreditMemo.RoleCode)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error Load Approver.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub GenerateReport(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwReport
                    .IsSuccessful = False
                    Select Case .ReportType
                        Case eReport.ReceiptDMCM, eReport.ReceiptDMCMPreview
                            .RptParamString = String.Concat(vwPaymentDebitCreditMemo.DMCMNumber, "|", Not .IsPreview, "|", .SiteCode, "|", .UserId, "|", 0, "|", 0)
                    End Select
                    .IsSuccessful = True
                    Call ProcessDebitCreditMemo(sender, e)
                    Call LoadDebitCreditMemo(sender, e)

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GenerateReport.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

#End Region

#Region "Clear"
        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Call ClearScreenSIInfo(sender, e)
                Call ClearScreenDMCMInfo(sender, e)
                Call ClearScreenViewDMCM(sender, e)
                Call ClearScreenViewSI(sender, e)
                Call ClearScreenPaymentDetails(sender, e)
                'Call ClearScreenPaymentTypeDetails(sender, e)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub ClearScreenViewDMCM(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentDebitCreditMemo
                    .ViewDMCMFrom = cDataType.fDate.Empty
                    .ViewDMCMTo = cDataType.fDate.Empty
                    .ViewDMCMNumber = cDataType.fLong.Empty
                    .ViewDMCMBySINo = cDataType.fLong.Empty
                    .dtViewDMCM = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenViewDMCM.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub ClearScreenViewSI(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentDebitCreditMemo
                    .ViewSIFrom = cDataType.fDate.Empty
                    .ViewSITo = cDataType.fDate.Empty
                    .ViewSINumber = cDataType.fLong.Empty
                    .ViewSIReferenceNumber = cDataType.fString.Empty
                    .dtViewSI = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenViewSI.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenDMCMInfo(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentDebitCreditMemo
                    .DMCMTransNo = cDataType.fString.Empty
                    .DMCMDate = cDataType.fDate.Empty
                    .DMCMNumber = cDataType.fLong.Empty
                    .BillingType = cDataType.fString.Empty
                    .Approver = cDataType.fString.Empty
                    .Reason = cDataType.fString.Empty
                    .Status = cDataType.fString.Empty
                End With
                'Call ClearScreenPolicy(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenInfo DITO.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub
        Private Sub ClearScreenSIInfo(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentDebitCreditMemo
                    .PreparedBy = cDataType.fString.Empty
                    .OfficeName = cDataType.fString.Empty
                    .OfficeAddr = cDataType.fString.Empty
                    .OfficeContact = cDataType.fString.Empty
                    .OfficeTin = cDataType.fString.Empty

                    .InvoiceNumber = cDataType.fLong.Empty
                    .InvoiceDate = cDataType.fDate.Empty
                    .PolicyNumber = cDataType.fString.Empty
                    .PayorName = cDataType.fString.Empty
                    .PayorAddress = cDataType.fString.Empty
                    .PayorTIN = cDataType.fString.Empty
                    .ReferenceNo = cDataType.fString.Empty
                    .BillStatNo = cDataType.fString.Empty
                    .Mode = cDataType.fString.Empty
                    .EffectivityFrom = cDataType.fDate.Empty
                    .EffectivityTo = cDataType.fDate.Empty
                    .BillStatementDate = cDataType.fDate.Empty


                    .Particulars = cDataType.fString.Empty
                    .Quantity = cDataType.fLong.Empty
                    .UnitPrice = cDataType.fDecimal.Empty
                    .TotalAmount = cDataType.fDecimal.Empty

                    .VATable = cDataType.fDecimal.Empty
                    .VATExempt = cDataType.fDecimal.Empty
                    .VATAmount = cDataType.fDecimal.Empty
                    .NonVAT = cDataType.fDecimal.Empty
                    .TotalSales = cDataType.fDecimal.Empty
                    .WitholdingTax = cDataType.fDecimal.Empty
                    .NetOfWitholdingTax = cDataType.fDecimal.Empty
                    .Discount = cDataType.fDecimal.Empty
                    .DiscountID = cDataType.fString.Empty
                    .dtViewSI = Nothing
                    
                    


                End With
                'Call ClearScreenPolicy(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenInfo HERE.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub
        Private Sub ClearScreenPaymentDetails(ByVal sender As Object, ByVal e As EventArgs)


        End Sub
#End Region



#Region "Processing"
        
        Private Sub LoadViewDMCM(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllStaging.BDebitCredit
                Dim dtLocal As New DataTable

                With vwPaymentDebitCreditMemo
                    If IsValidLoadViewDMCM() Then
                        If Not String.IsNullOrEmpty(.ViewDMCMByTransID) Then
                            dtLocal = objBLL.LoadViewDMCM(.SiteCode, .RoleCode, 0, .ViewDMCMByTransID, 0)
                        ElseIf .ViewDMCMBySINo > 0 Then
                            dtLocal = objBLL.LoadViewDMCM(.SiteCode, .RoleCode, .ViewDMCMBySINo, String.Empty, 1)
                            'ElseIf .ViewDMCMByTransID > 0 Then
                        ElseIf .ViewDMCMNumber > 0 Then
                            dtLocal = objBLL.LoadViewDMCM(.SiteCode, .RoleCode, .ViewDMCMNumber, String.Empty, 2)
                        Else
                            dtLocal = objBLL.LoadViewDMCM(.SiteCode, .RoleCode, .ViewDMCMFrom, .ViewDMCMTo)
                        End If

                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(String.Concat("View DMCM.<br /><br />", "No DMCM found!"), eSystemMessage.Information, True)

                        End If

                        .dtViewDMCM = dtLocal
                        End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewAR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
       
        Private Sub LoadViewSI(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BSalesInvoice
                Dim dtLocal As New DataTable

                With vwPaymentDebitCreditMemo
                    If IsValidLoadViewSI() Then
                        If .ViewSINumber > 0 Then
                            dtLocal = objBLL.LoadViewDocDMCM(.RoleCode, .ViewSINumber, String.Empty, 0)
                        ElseIf Not String.IsNullOrEmpty(.ViewSIReferenceNumber) Then
                            dtLocal = objBLL.LoadViewDocDMCM(.RoleCode, 0, .ViewSIReferenceNumber, 1)
                        Else
                            dtLocal = objBLL.LoadViewDocDMCM(.RoleCode, .ViewSIFrom, .ViewSITo)
                        End If

                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(String.Concat("View Sales Invoices.<br /><br />", "No SI found!"), eSystemMessage.Information, True)

                        End If

                        .dtViewSI = dtLocal



                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewSI.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub LoadSalesInvoice(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BSalesInvoice
            Dim lstLocal As New List(Of cSIDetails)
            Dim objSiteDetails As New bllReference.BSiteDetails

            Try
                If IsValidInvoiceNumber() Then
                    With vwPaymentDebitCreditMemo
                        .IsInvoiceNoExisting = False
                        objBLL.SearchSalesInvoiceDMCM(.InvoiceNumber, .RoleCode, .SiteCode, .UserID)

                        .IsInvoiceNoExisting = objBLL.IsRecordExist
                        If .IsInvoiceNoExisting Then

                            If objBLL.SIPrintStatus = "CANCELLED" Then
                                .IsInvoiceNoExisting = False
                                Throw New ArgumentException("Invoice No : " & objBLL.InvoiceNumber)
                            End If
                            .InvoiceNumber = objBLL.InvoiceNumber

                            .PolicyNumber = objBLL.PolicyNumber
                            .ReferenceNo = objBLL.ReferenceNo
                            .BillStatNo = objBLL.BillStatNo
                            .PayorName = objBLL.PayorName
                            .PayorAddress = objBLL.PayorAddress
                            .PayorTIN = objBLL.PayorTIN
                            .Mode = objBLL.PaymentTerm
                            .EffectivityFrom = objBLL.CoveragePeriodFrom
                            .EffectivityTo = objBLL.CoveragePeriodTo

                            If objBLL.SISourceType = "HMO" Then

                                objSiteDetails.GetSiteDetails(.SiteCode)

                                .OfficeAddr =
                                    cDataType.fString.IfNull(
                                        objSiteDetails.Address
                                    )

                                .OfficeContact =
                                    cDataType.fString.IfNull(
                                        objSiteDetails.Phone
                                    )

                                .OfficeTin =
                                    cDataType.fString.IfNull(
                                        objSiteDetails.Tin
                                    )

                                .OfficeName =
                                    cDataType.fString.IfNull(
                                        objSiteDetails.Prsnme
                                    )

                                .InvoiceDate =
                                CDate(
                                    objBLL.InvoiceDate.ToString("M/dd/yyyy")
                                )


                            Else
                                .OfficeAddr = objBLL.SiteAddr
                                .OfficeContact = objBLL.SiteContact
                                .OfficeTin = objBLL.SiteTin
                                .OfficeName = objBLL.SiteName
                                .InvoiceDate = objBLL.InvoiceDate
                            End If

                            .PreparedBy = objBLL.PreparedBy
                            .Particulars = objBLL.Particulars
                            .UnitPrice = objBLL.UnitPrice
                            .Quantity = objBLL.Quantity
                            .BillStatementDate = objBLL.BillStatDate
                            .SISourcetype = objBLL.SISourceType

                            





                            
                        Else
                            .IsInvoiceNoExisting = False
                            Call ClearScreenSIInfo(sender, e)
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    End With
                End If
            Catch ex As ArgumentException
                Call SetMessage(String.Concat("Invoice is Cancelled!.<br /><br />", ex.Message), eSystemMessage.Information, True)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSalesInvoice.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub LoadDebitCreditMemo(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllStaging.BDebitCredit
            Dim lstLocalSI As New List(Of cSIDetails)
            'Dim lstLocalARPay As New List(Of cPaymentType)
            Try
                If IsValidTransactionID() Then
                    With vwPaymentDebitCreditMemo
                        .IsTransIDExisting = False
                        objBLL.LoadDebitCreditMemo(.DebitCreditID, .UserID)
                        .IsTransIDExisting = objBLL.IsRecordExist
                        If .IsTransIDExisting Then
                            'DMCM Details
                            .DMCMTransNo = objBLL.DMCMTransNo
                            .DMCMNumber = objBLL.DMCMNumber
                            .DMCMDate = objBLL.DMCMDate
                            .Reason = objBLL.Reason
                            .Remarks = objBLL.Remarks
                            .DMCMDate = objBLL.DMCMDate
                            .EffectivityFrom = objBLL.EffectivityDate
                            .EffectivityTo = objBLL.ExpiryDate
                            .BillPeriodFrom = objBLL.BillPeriodFrom
                            .BillPeriodTo = objBLL.BillPeriodTo
                            .BillStatementDate = objBLL.BillStatementDate
                            .RenewalDate = objBLL.RenewalDate
                            '.DMCMNumber = objBLL.DMCMNo
                            .InvoiceNumber = objBLL.SINumber
                            .InvoiceDate = objBLL.InvoiceDate
                            .PolicyNumber = objBLL.PolicyNumber
                            .PayorName = objBLL.Payor
                            .PayorTIN = objBLL.Tin
                            .PayorAddress = objBLL.Address
                            .ReferenceNo = objBLL.ReferenceNo
                            .BillStatNo = objBLL.BillStatNo
                            .Mode = objBLL.PaymentTerm
                            .Status = objBLL.Status
                            .OfficeAddr = objBLL.SiteAddr
                            .OfficeContact = objBLL.SiteTelNo
                            .OfficeTin = objBLL.SiteTin
                            .OfficeName = objBLL.SiteName
                            .PreparedBy = objBLL.PreparedBy
                            .BillingType = objBLL.BillingType
                            .PrintCounter = objBLL.PrintCounter

                            .Particulars = objBLL.Particulars
                            .Quantity = objBLL.Quantity
                            .UnitPrice = objBLL.UnitPrice
                            .TotalAmount = objBLL.TotalAmount
                            .VATable = objBLL.VatSales
                            .VATExempt = objBLL.VatExemptSales
                            .VATAmount = objBLL.VatAmount
                            .NonVAT = objBLL.NonVatSales
                            .TotalSales = objBLL.TotalSales
                            .WitholdingTax = objBLL.WTax
                            .NetOfWitholdingTax = objBLL.NetWTax
                            .Discount = objBLL.Discount
                            .DiscountID = objBLL.DiscountID
                            .Approver = objBLL.Approver
                            .MemoType = objBLL.MemoType

                            Select Case .Status
                                Case "CANCELLED"
                                    .DocSaveState = eReference.DocSaveState.Cancel
                                Case "ACTIVE", "REJECTED"
                                    '.IsUnitPriceLocked = True
                                    .DocSaveState = eReference.DocSaveState.ViewEdit

                                Case "PRINTED"
                                    .DocSaveState = eReference.DocSaveState.Print
                                Case Else
                                    .DocSaveState = eReference.DocSaveState.ViewNoEdit
                            End Select
                        Else
                            .IsTransIDExisting = False
                            Call ClearScreenSIInfo(sender, e)
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    End With
                End If
            Catch ex As ArgumentException
                Call SetMessage(String.Concat("Reference No Already Used!.<br /><br />", ex.Message), eSystemMessage.Information, True)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadDebitCreditMemo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Function IsEqualtoTotalAmount() As Boolean
            Try
                With vwPaymentDebitCreditMemo
                    If .VATAmount = 0D Then
                        Return True
                    End If
                    ' Safely retrieve all relevant values (assuming they're already non-nullable decimals)
                    Dim vatable As Decimal = .VATable
                    Dim vatExempt As Decimal = .VATExempt
                    Dim vatAmount As Decimal = .VATAmount
                    Dim nonVAT As Decimal = .NonVAT

                    Dim discount As Decimal = .Discount
                    Dim withholdingTax As Decimal = .WitholdingTax
                    Dim netOfWithholdingTax As Decimal = .NetOfWitholdingTax

                    Dim totalAmount As Decimal = .TotalAmount

                    ' Rule 1: VAT components
                    Dim vatSum As Decimal = Math.Round(vatable + vatExempt + vatAmount + nonVAT, 2)

                    ' Rule 2: Net-related components
                    Dim netSum As Decimal = Math.Round(withholdingTax + netOfWithholdingTax + discount, 2)

                    ' Round total amount to 2 decimals for fair comparison
                    Dim roundedTotalAmount As Decimal = Math.Round(totalAmount, 2)

                    ' Check Rule 1
                    If vatSum > roundedTotalAmount Then
                        SetMessage("Sum of VATable, VAT Exempt, Non-VAT, and VAT Amount must not exceed Total Amount!", eSystemMessage.Information, True)
                        Return False
                    End If

                    ' Check Rule 2
                    If netSum > roundedTotalAmount Then
                        SetMessage("Sum of Withholding Tax, Net Of Withholding Tax, and Discount must not exceed Total Amount.", eSystemMessage.Information, True)
                        Return False
                    End If
                End With

                Return True

            Catch ex As Exception
                Throw New Exception("IsEqualtoTotalAmount : " & ex.Message)
            End Try
        End Function


        Private Sub ProcessDebitCreditMemo(ByVal sender As Object, ByVal e As EventArgs)
            'Objects
            Dim objDebitCredit As New bllStaging.BDebitCredit
            'Dim objARPayDetails As New bllStaging.BARPayDetails
            'Lists
            'Dim lstARPayDetails As New List(Of bllStaging.BARPayDetails)
            'Dim lstIdARPayDetails As New List(Of Long)

            'Dim lstForDeletion As New List(Of Object)
            Dim mDocSaveState As String = String.Empty

            Try


                With vwPaymentDebitCreditMemo
                    .IsSuccessful = False

                    'If IsValidDebitCreditMemo() Then
                    mDocSaveState = .DocSaveState

                    'Select Case mDocSaveState
                    '    Case eReference.DocSaveState.Edit, eReference.DocSaveState.Cancel, eReference.DocSaveState.Print
                    'Dim dtARPayDetails = objARPayDetails.GetDt(.AckReceiptNumber, .UserID)

                    'For Each dr As DataRow In dtARPayDetails.Rows
                    'If mDocSaveState = eReference.DocSaveState.Edit Or mDocSaveState = eReference.DocSaveState.Print Then
                    'lstIdARPayDetails.Add(dr.Item("id"))
                    'lstForDeletion.Add(New bllStaging.BARPayDetails() With {.ARPayDetailsID = dr.Item("id"), .ARNo = dr.Item("ar_no"), .Status = dr.Item("status"), .LastUpdateBy = vwPaymentAckReceipt.UserID})
                    'Else
                    'lstARPayDetails.Add(New bllStaging.BARPayDetails() With {.ARPayDetailsID = dr.Item("id"), .ARNo = dr.Item("ar_no"), .Status = dr.Item("status"), .LastUpdateBy = vwPaymentAckReceipt.UserID})
                    'End If
                    'Next
                    'End Select

                    'Select Case mDocSaveState

                    'Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit, eReference.DocSaveState.Print, eReference.DocSaveState.Cancel
                    'If .DocSaveState = eReference.DocSaveState.Print AndAlso .ARPrintStatus = "POSTED" Then
                    '.IsSuccessful = True
                    'SetMessage(String.Concat("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!"), eSystemMessage.Information, True)
                    'Exit Sub
                    'End If

                    'If .DocSaveState = eReference.DocSaveState.Cancel Then
                    '.AckReceiptRemarks = String.Concat(.CancellationReason, ";", Chr(13), .AckReceiptRemarks)
                    '.CancellationReason = String.Empty
                    'End If

                    'If .CashTotalAmount > 0 Then
                    'lstARPayDetails.Clear()
                    'lstARPayDetails.Add(New bllStaging.BARPayDetails(GetIdFromList(lstIdARPayDetails, lstARPayDetails.Count), .AckReceiptNumber, eReference.PayTypeCSH, .CashTotalAmount, "", 0, "", "", "", "", "", .ARDate, "", "", "", 0, 0, "READY", .UserID))
                    'End If
                    'For Each item In .lstPaymentTypeDetails
                    'Select Case item.PaymentType
                    'Case eReference.PayTypeCHQ
                    'lstARPayDetails.Add(New bllStaging.BARPayDetails(GetIdFromList(lstIdARPayDetails, lstARPayDetails.Count), .AckReceiptNumber, item.PaymentType, item.Amount, item.CheckNumber, 0, item.Bank, item.Branch, "", "", "", .ARDate, "", "", "", 0, 0, "READY", .UserID))
                    'Case eReference.PayTypeCCA
                    'lstARPayDetails.Add(New bllStaging.BARPayDetails(GetIdFromList(lstIdARPayDetails, lstARPayDetails.Count), .AckReceiptNumber, item.PaymentType, item.Amount, item.ApprovalCode, item.BatchNumber, "", "", "", item.TerminalUse, item.MerchantID, item.SwipeDate, item.CardType, item.CardNumber, item.Remarks, 0, 0, "READY", .UserID))
                    'Case eReference.PayTypeDCA
                    'lstARPayDetails.Add(New bllStaging.BARPayDetails(GetIdFromList(lstIdARPayDetails, lstARPayDetails.Count), .AckReceiptNumber, item.PaymentType, item.Amount, item.ApprovalCode, item.BatchNumber, item.Bank, item.Branch, item.Network, item.TerminalUse, item.MerchantID, item.SwipeDate, item.CASA, item.AccountNumber, item.Remarks, 0, 0, "READY", .UserID))
                    'Case eReference.PayTypeECP
                    'lstARPayDetails.Add(New bllStaging.BARPayDetails(GetIdFromList(lstIdARPayDetails, lstARPayDetails.Count), .AckReceiptNumber, item.PaymentChannel, item.Amount, item.ReferenceID, 0, "", "", "", "", "", .ARDate, "", "", item.Remarks, item.ServiceFeeRate, 0, "READY", .UserID))
                    'End Select
                    'Next

                    Select Case mDocSaveState
                        Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit, eReference.DocSaveState.Cancel, eReference.DocSaveState.ViewEdit, eReference.DocSaveState.ViewNoEdit, eReference.DocSaveState.Print

                            objDebitCredit = New bllStaging.BDebitCredit(.DebitCreditID, .DMCMNumber, .DMCMTransNo, .InvoiceNumber,
                                                                         .MemoType, .DMCMDate, .RenewalDate, .EffectivityFrom, .EffectivityTo,
                                                                         .BillPeriodFrom, .BillPeriodTo, .BillStatementDate, .UserID, .SiteCode,
                                                                         .PayorName, .PayorAddress, .PayorTIN, .PolicyNumber, .InvoiceDate,
                                                                         .Remarks, .Reason, .Mode, .ReferenceNo, .BillStatNo, .OfficeName, .OfficeAddr,
                                                                         .OfficeContact, .OfficeTin, .PreparedBy, .BillingType,
                                                                         .Particulars, .UnitPrice, .Quantity, .TotalAmount, .VATable, .VATExempt,
                                                                         .VATAmount, .NonVAT, .TotalSales, .WitholdingTax, .NetOfWitholdingTax, .Discount, .DiscountID,
                                                                         .RoleCode, .Approver, .SISourcetype)

                    End Select


                    'End Select

                    objPaymentDebitCreditMemo = New bllPayment.BPaymentDebitCreditMemo

                    With objPaymentDebitCreditMemo
                        .SiteCode = vwPaymentDebitCreditMemo.SiteCode
                        .UserID = vwPaymentDebitCreditMemo.UserID
                        .DebitCreditMemo = objDebitCredit


                        Select Case mDocSaveState
                            Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit

                                If IsEqualtoTotalAmount() Then
                                    .IsSuccessful = True
                                    .ProcessPaymentDebitCreditMemo()
                                    'Call LoadDebitCreditMemo(sender, e)
                                    vwPaymentDebitCreditMemo.DebitCreditID = .ReservedDMCMID
                                Else
                                    .IsSuccessful = False

                                    'Call SetMessage(String.Concat("<strong><h2>VAT details not equal to total amount.:</h2></strong><br />"), eSystemMessage.Warning);
                                    'SetMessage(String.Concat("VAT details not equal to total amount!"), eSystemMessage.Information, True)

                                    Exit Sub
                                End If







                            Case eReference.DocSaveState.ViewEdit
                                .IsSuccessful = True
                                .SendPaymentDebitCreditMemo()
                            Case eReference.DocSaveState.Print
                                .IsSuccessful = True
                                Dim reportPath As String =
                                  Global.System.Web.HttpContext.Current.Server.MapPath(
                                      "~/reports/ReceiptDMCM.rpt"
                                  )


                                Dim pdfBytes As Byte() =
                                    uReportFactory.GenerateDMCMReceiptPDF(
                                        reportPath,
                                        vwPaymentDebitCreditMemo.SiteCode,
                                        vwPaymentDebitCreditMemo.DMCMNumber,
                                        vwPaymentDebitCreditMemo.UserID
                                    )

                                System.Diagnostics.Debug.WriteLine(
                                    "PDF bytes to send: " & pdfBytes.Length.ToString()
                                )

                                .PrintPaymentDebitCreditMemo(pdfBytes)

                            Case eReference.DocSaveState.Cancel
                                .IsSuccessful = True
                                .CancelPaymentDebitCreditMemo()

                        End Select
                    End With
                    .IsSuccessful = objPaymentDebitCreditMemo.IsSuccessful
                    'End If
                End With
                If vwPaymentDebitCreditMemo.IsSuccessful Then
                    If mDocSaveState = eReference.DocSaveState.Print Then
                        'SetMessage(String.Concat("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!"), eSystemMessage.Information, True)
                        SetMessage(String.Concat("<strong><h2>Printed!:</h2></strong><br />"), eSystemMessage.Information, True)

                    Else
                        Call SetMessage(String.Concat("DMCM.<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                    End If
                End If

            Catch ex As Exception
                Call SetMessage(String.Concat("An Error has occurred.<br /><br />", ex.Message), eSystemMessage.Information, True)
            End Try

        End Sub
        Private Sub ConfirmSave(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "SAVE"
                    .Message = "Are you sure you want to save this Record?"
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmSave.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub ConfirmSend(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "SEND"
                    .Message = "Are you sure you want to send this record for Approval?"
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmSend.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub ConfirmCancel(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "CANCEL"
                    .Message = String.Concat("Are you sure you want to cancel Transaction ID", vwPaymentDebitCreditMemo.DMCMTransNo, "?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmCancel.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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



#End Region 'Transactions

























    End Class
End Namespace
