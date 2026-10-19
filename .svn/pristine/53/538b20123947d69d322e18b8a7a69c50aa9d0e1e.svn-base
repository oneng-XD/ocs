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
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
Imports System.Configuration
#End Region


Namespace Payment
    Public Class PPaymentDMCMApproval

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPaymentDMCMApproval As Payment.IPaymentDMCMApproval
        Private vwConfirmMsg As preMessages.IConfirmationMessage
        Private vwReport As preReport.IReport

        Private objPaymentDMCMApproval As bllPayment.BPaymentDMCMApproval
#End Region

#Region "Constructor"
        Sub New()

        End Sub
        Sub New(ByVal pView As Payment.IPaymentDMCMApproval)
            vwSysMsg = pView
            vwPaymentDMCMApproval = pView
            vwConfirmMsg = pView
            With vwPaymentDMCMApproval
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .LoadViewDMCM, AddressOf LoadViewDMCM
                AddHandler .LoadDebitCreditMemo, AddressOf LoadDebitCreditMemo
                AddHandler .ProcessDebitCreditMemo, AddressOf ProcessDebitCreditMemo
                AddHandler .ConfirmApprove, AddressOf ConfirmApprove
                AddHandler .ConfirmReject, AddressOf ConfirmReject
            End With
        End Sub
#End Region

#Region "Validation"
        Private Function IsValidTransactionID() As Boolean

            Try

                With vwPaymentDMCMApproval

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

                With vwPaymentDMCMApproval
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
#End Region
#Region "Clear"
        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)
            Try
                'Call ClearScreenInfo(sender, e)
                Call ClearScreenViewDMCM(sender, e)
                'Call ClearScreenViewSI(sender, e)
                'Call ClearScreenPaymentDetails(sender, e)
                'Call ClearScreenPaymentTypeDetails(sender, e)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub ClearScreenViewDMCM(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwPaymentDMCMApproval
                    .ViewDMCMFrom = cDataType.fDate.Empty
                    .ViewDMCMTo = cDataType.fDate.Empty
                    .ViewDMCMBySINo = cDataType.fLong.Empty

                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenViewDMCM.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
#End Region
#Region "Processing"
        Private Sub LoadViewDMCM(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllStaging.BDebitCredit
                Dim dtLocal As New DataTable

                With vwPaymentDMCMApproval
                    If .IsButtonSearch = False Then
                        dtLocal = objBLL.LoadViewDMCM(.SiteCode, .UserID, 0, String.Empty, 3)
                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(String.Concat("View DMCM.<br /><br />", "No DMCM found!"), eSystemMessage.Information, True)
                        End If
                        .dtViewDMCM = dtLocal
                    Else
                        If IsValidLoadViewDMCM() Then
                            If Not String.IsNullOrEmpty(.ViewDMCMByTransID) Then
                                dtLocal = objBLL.LoadViewDMCM(.SiteCode, .UserID, 0, .ViewDMCMByTransID, 3)
                            ElseIf .ViewDMCMBySINo > 0 Then
                                dtLocal = objBLL.LoadViewDMCM(.SiteCode, .UserID, .ViewDMCMBySINo, String.Empty, 3)
                            Else
                                dtLocal = objBLL.LoadViewDMCM(.SiteCode, .UserID, 3, 0, .ViewDMCMFrom, .ViewDMCMTo)
                            End If

                            If dtLocal.Rows.Count = 0 Then
                                Call SetMessage(String.Concat("View DMCM.<br /><br />", "No DMCM found!"), eSystemMessage.Information, True)

                            End If

                            .dtViewDMCM = dtLocal
                        End If
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewAR.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub LoadDebitCreditMemo(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllStaging.BDebitCredit
            Dim lstLocalSI As New List(Of cSIDetails)
            'Dim lstLocalARPay As New List(Of cPaymentType)
            Try
                If IsValidTransactionID() Then
                    With vwPaymentDMCMApproval
                        .IsTransIDExisting = False
                        objBLL.LoadDebitCreditMemo(.DebitCreditID, .UserID)
                        .IsTransIDExisting = objBLL.IsRecordExist
                        If .IsTransIDExisting Then
                            'DMCM Details
                            .DMCMTransNo = objBLL.DMCMTransNo
                            .DMCMNumber = objBLL.DMCMNumber
                            .MemoType = objBLL.MemoType
                            .DMCMDate = objBLL.DMCMDate
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
                            .DMCMRoleCode = objBLL.RoleCode
                            .DMCMPostedBy = objBLL.PostedBy
                            Select Case .Status
                                Case "CANCELLED"
                                    .DocSaveState = eReference.DocSaveState.Cancel
                                Case "ACTIVE", "FOR APPROVAL"
                                    .DocSaveState = eReference.DocSaveState.ViewEdit
                                Case "PRINTED"
                                    .DocSaveState = eReference.DocSaveState.Print
                                Case Else
                                    .DocSaveState = eReference.DocSaveState.ViewNoEdit
                            End Select
                        Else
                            .IsTransIDExisting = False
                            'Call ClearScreenInfo(sender, e)
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
        Private Sub ConfirmApprove(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "APPROVED"
                    .Message = "Are you sure you want to Approve this Record?"
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmApprove.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub
        Private Sub ConfirmReject(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "REJECTED"
                    .Message = String.Concat("Are you sure you want to reject Transaction # ", vwPaymentDMCMApproval.DMCMTransNo, "?")
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


                With vwPaymentDMCMApproval
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
                        Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit, eReference.DocSaveState.Cancel, eReference.DocSaveState.ViewEdit, eReference.DocSaveState.Cancel

                            objDebitCredit = New bllStaging.BDebitCredit(.DebitCreditID, .DMCMNumber, .DMCMTransNo, .InvoiceNumber,
                                                                         .MemoType, .DMCMDate, .RenewalDate, .EffectivityFrom, .EffectivityTo,
                                                                         .BillPeriodFrom, .BillPeriodTo, .BillStatementDate, .DMCMPostedBy, .SiteCode,
                                                                         .PayorName, .PayorAddress, .PayorTIN, .PolicyNumber, .InvoiceDate,
                                                                         .Remarks, .Reason, .Mode, .ReferenceNo, .BillStatNo, .OfficeName, .OfficeAddr,
                                                                         .OfficeContact, .OfficeTin, .PreparedBy, .BillingType, .Particulars, .UnitPrice, .Quantity,
                                                                         .TotalAmount, .VATable, .VATExempt, .VATAmount, .NonVAT, .TotalSales, .WitholdingTax,
                                                                         .NetOfWitholdingTax, .Discount, .DiscountID, .DMCMRoleCode, .DMCMApproverID, .SISourcetype)

                    End Select


                    'End Select

                    objPaymentDMCMApproval = New bllPayment.BPaymentDMCMApproval

                    With objPaymentDMCMApproval
                        .SiteCode = vwPaymentDMCMApproval.SiteCode
                        .UserID = vwPaymentDMCMApproval.UserID
                        .DebitCreditMemo = objDebitCredit


                        Select Case mDocSaveState
                            Case eReference.DocSaveState.AddNew, eReference.DocSaveState.Edit

                            Case eReference.DocSaveState.ViewEdit
                                .IsSuccessful = True
                                .ApprovePaymentDebitCreditMemo()
                            Case eReference.DocSaveState.Print


                            Case eReference.DocSaveState.Cancel
                                .IsSuccessful = True
                                .RejectPaymentDebitCreditMemo()
                        End Select
                    End With
                    .IsSuccessful = objPaymentDMCMApproval.IsSuccessful
                    'End If
                End With
                If vwPaymentDMCMApproval.IsSuccessful Then
                    If mDocSaveState = eReference.DocSaveState.Print Then
                        SetMessage(String.Concat("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!"), eSystemMessage.Information, True)
                    Else
                        Call SetMessage(String.Concat("DMCM.<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                    End If
                End If

            Catch ex As Exception
                Call SetMessage(String.Concat("An Error has occurred.<br /><br />", ex.Message), eSystemMessage.Information, True)
            End Try
        End Sub
#End Region 'Processing




    End Class
End Namespace
