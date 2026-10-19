#Region "Description"
' PAGE NAME     : Payment : Debit Credit Memo Approval
' CREATED BY    : Junie
' CREATED DATE  : 04/10/2025
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports preMessages = Cocolife.Utility.OCS.Messages
Imports prePayment = Cocolife.Presenter.OCS.Payment
Imports preSearch = Cocolife.Presenter.OCS.Search
Imports preReport = Cocolife.Presenter.OCS.Report
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eCSS = Cocolife.Utility.OCS.Enums.eCSS
Imports ePage = Cocolife.Utility.OCS.Enums.ePage
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eDocSaveState = Cocolife.Utility.OCS.Enums.eReference.DocSaveState
Imports eSession = Cocolife.Utility.OCS.Enums.eSession
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
Imports System.Linq
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports cCrystalConn = Cocolife.Utility.OCS.Classes.cCrystalConn
Imports System.Globalization
#End Region



Partial Public Class PaymentDMCMApproval
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preMessages.IConfirmationMessage
    Implements prePayment.IPaymentDMCMApproval
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pConfirmationMessage As preMessages.PConfirmationMessage
    Private pPaymentDMCMApproval As prePayment.PPaymentDMCMApproval
    'Private mIsPayTypeSuccessful As Boolean
    Private mIsSuccessful As Boolean
#End Region

#Region "ISystemMessage"
#Region "Property"
    Public WriteOnly Property Message() As String Implements preSecurity.ISystemMessage.Message
        Set(ByVal value As String)
            lblMessage.Text = value
        End Set
    End Property

    Public WriteOnly Property MessageType() As String Implements preSecurity.ISystemMessage.MessageType
        Set(ByVal value As String)
            imgMessage.ImageUrl = value
        End Set
    End Property

    Public WriteOnly Property IsMessage() As Boolean Implements preSecurity.ISystemMessage.isMessage
        Set(ByVal value As Boolean)
            If value Then
                mpeMessage.Show()
            End If
        End Set
    End Property
#End Region

#Region "Event"

#End Region

#End Region 'ISystem

#Region "IConfirmationMessage"

#Region "Property"

    Public Property ConfirmCaller() As String Implements preMessages.IConfirmationMessage.ConfirmCaller
        Get
            Return cDataType.fString.IfNull(hdnConfirmCaller.Value)
        End Get
        Set(value As String)
            hdnConfirmCaller.Value = value
        End Set
    End Property

    Public Property ConfirmClickState() As Boolean Implements preMessages.IConfirmationMessage.ClickedState
        Get
            Return cDataType.fBoolean.IfNull(hdnClickStateTag.Value)
        End Get
        Set(value As Boolean)
            hdnClickStateTag.Value = value
        End Set
    End Property

    Public Property UserResponse() As Boolean Implements preMessages.IConfirmationMessage.UserResponse
        Get
            Return cDataType.fBoolean.IfNull(hdnConfirmTag.Value)
        End Get
        Set(value As Boolean)
            hdnConfirmTag.Value = value
        End Set
    End Property

    Public WriteOnly Property ConfirmMessage() As String Implements preMessages.IConfirmationMessage.Message
        Set(ByVal value As String)
            lblConfirm.Text = value
        End Set
    End Property

    Public WriteOnly Property IsConfirmMessage() As Boolean Implements preMessages.IConfirmationMessage.isMessage
        Set(ByVal value As Boolean)
            If value Then
                mpeConfirm.Show()
            End If
        End Set
    End Property

#End Region

#Region "Event"

#End Region

#End Region 'IConfirmationMessage


#Region "IPaymentDMCMApproval"
#Region "Property"
#Region "DMCM Details"
    Public Property DocSaveState As Integer Implements prePayment.IPaymentDMCMApproval.DocSaveState
        Get
            Return cDataType.fInteger.IfNull(hdnDocSaveState.Value)
        End Get
        Set(value As Integer)
            hdnDocSaveState.Value = value

            ManageMain(value)

            Select Case value
                Case eDocSaveState.Initial
                    btnDMCMApprove.Enabled = False
                    btnDMCMReject.Enabled = False
                    gvwViewDMCM.Enabled = True
                    RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
                Case eDocSaveState.ViewEdit
                    btnDMCMApprove.Enabled = True
                    btnDMCMReject.Enabled = True
                    gvwViewDMCM.Enabled = True
                Case eDocSaveState.ViewNoEdit
                    btnDMCMApprove.Enabled = False
                    btnDMCMReject.Enabled = False
                    gvwViewDMCM.Enabled = False
                Case eDocSaveState.Edit

                Case eDocSaveState.AddNew

                Case eDocSaveState.Cancel

                Case eDocSaveState.Print

            End Select
        End Set
    End Property
    Private Sub ManageDetails(ByVal pAction As String, Optional ByVal pEnabled As Boolean? = Nothing)

        Select Case pAction
            Case "ENABLED"
                pnlPaymentDetails1.Enabled = pEnabled
                accInvoiceInformation.Visible = pEnabled
                accParticulars.Visible = pEnabled
                accVATComputation.Visible = pEnabled
            Case "SEARCHREFNO"
              
            Case "SOURCESITE"
               
            Case "EDITABLE"
               

            Case "CUSTOM_EDIT"

            Case "EDIT"
                'txtARRemarks.Enabled = pEnabled
                'txtAROtherInfo.Enabled = pEnabled
                'txtInvoiceNumber.Enabled = pEnabled
                'ibtnSearchSalesInvoice.Visible = pEnabled
                'ibtnClearSourceSite.Visible = pEnabled
                'ibtnClearRefNo.Visible = pEnabled
                'ibtnClearGrossAmount.Visible = pEnabled
                'ibtnClearComm.Visible = pEnabled
                'ibtnClearWTax.Visible = pEnabled
                'ibtnClearDiscount.Visible = pEnabled
                'ddlPolicyType.Enabled = pEnabled
                'accPaymentTypeDetails.Enabled = pEnabled
            Case "GROSSAMOUNT"
                'txtGrossAmount.Enabled = Not pEnabled
                'ddlPayCurrency.Enabled = Not pEnabled
                'ibtnVerifyGrossAmount.Visible = Not pEnabled
                'ibtnClearGrossAmount.Visible = pEnabled
            Case "VATAMOUNTS"
                'txtWitholdingTax.Enabled = Not pEnabled
                'txtDiscount.Enabled = Not pEnabled
                'txtDiscountIdNo.Enabled = Not pEnabled
                'txtCommissionAmount.Enabled = Not pEnabled
                'ibtnVerifyWTax.Visible = Not pEnabled
                'ibtnClearWTax.Visible = pEnabled
                'ibtnVerifyDiscount.Visible = Not pEnabled
                'ibtnClearDiscount.Visible = pEnabled
                'ibtnVerifyComm.Visible = Not pEnabled
                'ibtnClearComm.Visible = pEnabled
                'IsWTaxLocked = pEnabled
                'IsCommLocked = pEnabled
                'IsDiscountLocked = pEnabled
            Case "PARTICULARS"
                'accARParticulars.Enabled = pEnabled
            Case Else
                'ddlSourceSite.Enabled = pEnabled

        End Select

    End Sub
    Private Sub ManageMain(ByVal pAction As Integer)
        Select Case pAction
            Case eDocSaveState.Initial
                ManageDetails("ENABLED", False)
                'PaymentTypeTag = False
            Case eDocSaveState.ViewNoEdit, eDocSaveState.ViewEdit, eDocSaveState.Print, eDocSaveState.Cancel
                ManageDetails("ENABLED", True)
                'ManageDetails("PARTICULARS", False)
            Case eDocSaveState.AddNew
                'ManageDetails("ENABLED", True)
                'ManageDetails("PARTICULARS", True)
                'ManageDetails("SEARCHREFNO", True)
            Case eDocSaveState.Edit
                ' ManageDetails("ENABLED", True)
                'ManageDetails("SEARCHREFNO", False)
                ' ManageDetails("PARTICULARS", True)
        End Select
    End Sub
    Public Property InvoiceNumber As Long Implements prePayment.IPaymentDMCMApproval.InvoiceNumber
        Get
            Return cDataType.fLong.IfNull(txtInvoiceNumber.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtInvoiceNumber.Text = ""
            Else
                txtInvoiceNumber.Text = value
            End If
        End Set
    End Property
    Public Property ReferenceNo As String Implements prePayment.IPaymentDMCMApproval.ReferenceNo
        Get
            Return cDataType.fString.IfNull(hdnReferenceNo.Value)
        End Get
        Set(value As String)
            hdnReferenceNo.Value = value
        End Set
    End Property
    Public Property BillStatNo As String Implements prePayment.IPaymentDMCMApproval.BillStatNo
        Get
            Return cDataType.fString.IfNull(txtBillStatNo.Text)
        End Get
        Set(value As String)
            txtBillStatNo.Text = value
        End Set
    End Property
    
    Public Property PayorName As String Implements prePayment.IPaymentDMCMApproval.PayorName
        Get
            Return cDataType.fString.IfNull(txtPayorName.Text)
        End Get
        Set(value As String)
            txtPayorName.Text = value
        End Set
    End Property

    Public Property PayorAddress As String Implements prePayment.IPaymentDMCMApproval.PayorAddress
        Get
            Return cDataType.fString.IfNull(txtPayorAddress.Text)
        End Get
        Set(value As String)
            txtPayorAddress.Text = value
        End Set
    End Property

    Public Property PayorTIN As String Implements prePayment.IPaymentDMCMApproval.PayorTIN
        Get
            Return cDataType.fString.IfNull(txtPayorTin.Text)
        End Get
        Set(value As String)
            txtPayorTin.Text = value
        End Set
    End Property


    Public Property PolicyNumber As String Implements prePayment.IPaymentDMCMApproval.PolicyNumber
        Get
            Return cDataType.fString.IfNull(txtPolicyNumber.Text)
        End Get
        Set(value As String)
            txtPolicyNumber.Text = value
        End Set
    End Property
    Public Property PreparedBy As String Implements prePayment.IPaymentDMCMApproval.PreparedBy
        Get
            Return cDataType.fString.IfNull(txtPreparedBy.Text)
        End Get
        Set(value As String)
            txtPreparedBy.Text = value
        End Set
    End Property
    Public Property OfficeName As String Implements prePayment.IPaymentDMCMApproval.OfficeName
        Get
            Return cDataType.fString.IfNull(txtOfficeName.Text)
        End Get
        Set(value As String)
            txtOfficeName.Text = value
        End Set
    End Property
    Public Property OfficeContact As String Implements prePayment.IPaymentDMCMApproval.OfficeContact
        Get
            Return cDataType.fString.IfNull(txtOfficeContact.Text)
        End Get
        Set(value As String)
            txtOfficeContact.Text = value
        End Set
    End Property
    Public Property OfficeAddr As String Implements prePayment.IPaymentDMCMApproval.OfficeAddr
        Get
            Return cDataType.fString.IfNull(txtOfficeAddr.Text)
        End Get
        Set(value As String)
            txtOfficeAddr.Text = value
        End Set
    End Property
    Public Property OfficeTin As String Implements prePayment.IPaymentDMCMApproval.OfficeTin
        Get
            Return cDataType.fString.IfNull(txtOfficeTin.Text)
        End Get
        Set(value As String)
            txtOfficeTin.Text = value
        End Set
    End Property
    Public Property Mode As String Implements prePayment.IPaymentDMCMApproval.Mode
        Get
            Return cDataType.fString.IfNull(txtMode.Text)
        End Get
        Set(value As String)
            txtMode.Text = value
        End Set
    End Property
    Public Property InvoiceDate() As Date Implements prePayment.IPaymentDMCMApproval.InvoiceDate
        Get
            Return cDataType.fDate.IfNull(txtInvoiceDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtInvoiceDate.Text = ""
            Else
                txtInvoiceDate.Text = value
            End If
        End Set
    End Property
    Public Property DMCMDate() As Date Implements prePayment.IPaymentDMCMApproval.DMCMDate
        Get
            Return cDataType.fDate.IfNull(txtDMCMDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtDMCMDate.Text = ""
            Else
                txtDMCMDate.Text = value
            End If
        End Set
    End Property

    Public Property EffectivityFrom As Date Implements prePayment.IPaymentDMCMApproval.EffectivityFrom
        Get
            Return cDataType.fDate.IfNull(txtEffectivityFrom.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtEffectivityFrom.Text = cDataType.fDate.Current
            Else
                txtEffectivityFrom.Text = value
            End If
        End Set
    End Property

    Public Property EffectivityTo As Date Implements prePayment.IPaymentDMCMApproval.EffectivityTo
        Get
            Return cDataType.fDate.IfNull(txtEffectivityTo.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtEffectivityTo.Text = cDataType.fDate.Current
            Else
                txtEffectivityTo.Text = value
            End If
        End Set
    End Property
    Public Property RenewalDate As Date Implements prePayment.IPaymentDMCMApproval.RenewalDate
        Get
            Return cDataType.fDate.IfNull(txtRenewalDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtRenewalDate.Text = cDataType.fDate.Current
            Else
                txtRenewalDate.Text = value
            End If
        End Set
    End Property
    Public Property BillStatementDate As Date Implements prePayment.IPaymentDMCMApproval.BillStatementDate
        Get
            Return cDataType.fDate.IfNull(txtBillStatementDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtBillStatementDate.Text = cDataType.fDate.Current
            Else
                txtBillStatementDate.Text = value
            End If
        End Set
    End Property
    Public Property BillPeriodFrom As Date Implements prePayment.IPaymentDMCMApproval.BillPeriodFrom
        Get
            Return cDataType.fDate.IfNull(txtBillPeriodFrom.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtBillPeriodFrom.Text = cDataType.fDate.Current
            Else
                txtBillPeriodFrom.Text = value
            End If
        End Set
    End Property
    Public Property BillPeriodTo As Date Implements prePayment.IPaymentDMCMApproval.BillPeriodTo
        Get
            Return cDataType.fDate.IfNull(txtBillPeriodTo.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtBillPeriodTo.Text = cDataType.fDate.Current
            Else
                txtBillPeriodTo.Text = value
            End If
        End Set
    End Property
    Public Property ViewDMCMFrom As Date Implements prePayment.IPaymentDMCMApproval.ViewDMCMFrom
        Get
            Return cDataType.fDate.IfNull(txtViewDMCMFromDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtViewDMCMFromDate.Text = cDataType.fDate.Current.AddDays(-3)
            Else
                txtViewDMCMFromDate.Text = value
            End If
        End Set
    End Property
    Public Property UnitPrice As Decimal Implements prePayment.IPaymentDMCMApproval.UnitPrice
        Get
            Return cDataType.fDecimal.IfNull(txtUnitPrice.Text)
        End Get
        Set(value As Decimal)
            txtUnitPrice.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
            'If TotalSales = 0 Then
            'TotalSales = GrossAmount
            'End If
        End Set
    End Property
   

    Public Property ViewDMCMTo As Date Implements prePayment.IPaymentDMCMApproval.ViewDMCMTo
        Get
            Return cDataType.fDate.IfNull(txtViewDMCMToDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtViewDMCMToDate.Text = cDataType.fDate.Current
            Else
                txtViewDMCMToDate.Text = value
            End If
        End Set
    End Property


    Public Property ViewDMCMBySINo As Long Implements prePayment.IPaymentDMCMApproval.ViewDMCMBySINo
        Get
            Return cDataType.fLong.IfNull(txtViewDMCMSINumber.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtViewDMCMSINumber.Text = Nothing
            Else
                txtViewDMCMSINumber.Text = value
            End If
        End Set
    End Property
    Public Property ViewDMCMByTransID As String Implements prePayment.IPaymentDMCMApproval.ViewDMCMByTransID
        Get
            Return cDataType.fString.IfNull(txtViewDMCMTransID.Text)
        End Get
        Set(value As String)
            If value = cDataType.fString.Empty Then
                txtViewDMCMTransID.Text = Nothing
            Else
                txtViewDMCMTransID.Text = value
            End If
        End Set
    End Property
    Public Property IsTransIDExisting As Boolean Implements prePayment.IPaymentDMCMApproval.IsTransIDExisting
        Get
            Return cDataType.fBoolean.IfNull(hdnARNoExisting.Value)
        End Get
        Set(ByVal value As Boolean)
            hdnARNoExisting.Value = value
        End Set
    End Property
    Public Property IsInvoiceNoExisting As Boolean Implements prePayment.IPaymentDMCMApproval.IsInvoiceNoExisting
        Get
            Return cDataType.fBoolean.IfNull(hdnInvoiceNoExisting.Value)
        End Get
        Set(ByVal value As Boolean)
            hdnInvoiceNoExisting.Value = value
        End Set
    End Property
    Public Property VATable As Decimal Implements prePayment.IPaymentDMCMApproval.VATable
        Get
            Return cDataType.fDecimal.IfNull(txtVATable.Text)
        End Get
        Set(value As Decimal)
            txtVATable.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property VATExempt As Decimal Implements prePayment.IPaymentDMCMApproval.VATExempt
        Get
            Return cDataType.fDecimal.IfNull(txtVATExempt.Text)
        End Get
        Set(value As Decimal)
            txtVATExempt.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property VATAmount As Decimal Implements prePayment.IPaymentDMCMApproval.VATAmount
        Get
            Return cDataType.fDecimal.IfNull(txtVATAmount.Text)
        End Get
        Set(value As Decimal)
            txtVATAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property NonVAT As Decimal Implements prePayment.IPaymentDMCMApproval.NonVAT
        Get
            Return cDataType.fDecimal.IfNull(txtNonVAT.Text)
        End Get
        Set(value As Decimal)
            txtNonVAT.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property TotalSales As Decimal Implements prePayment.IPaymentDMCMApproval.TotalSales
        Get
            Return cDataType.fDecimal.IfNull(txtTotalSales.Text)
        End Get
        Set(value As Decimal)
            txtTotalSales.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property WitholdingTax As Decimal Implements prePayment.IPaymentDMCMApproval.WitholdingTax
        Get
            Return cDataType.fDecimal.IfNull(txtWitholdingTax.Text)
        End Get
        Set(value As Decimal)
            txtWitholdingTax.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property NetOfWitholdingTax As Decimal Implements prePayment.IPaymentDMCMApproval.NetOfWitholdingTax
        Get
            Return cDataType.fDecimal.IfNull(txtNetOfWitholdingTax.Text)
        End Get
        Set(value As Decimal)
            txtNetOfWitholdingTax.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property ReservedDMCMID As Long Implements prePayment.IPaymentDMCMApproval.ReservedDMCMID
        Get
            Return cDataType.fString.IfNull(hdnReservedDMCMID.Value)
        End Get
        Set(value As Long)
            hdnReservedDMCMID.Value = value
        End Set
    End Property
    Public ReadOnly Property ApproverRoleCode As String Implements prePayment.IPaymentDMCMApproval.ApproverRoleCode
        Get
            Return Master.RoleCode
        End Get
    End Property

    Public Property ReceiptByCode As String Implements prePayment.IPaymentDMCMApproval.ReceiptByCode
        Get
            Return cDataType.fString.IfNull(hdnReceiptByCode.Value)
        End Get
        Set(value As String)
            hdnReceiptByCode.Value = value
        End Set
    End Property

    Public Property DMCMRoleCode As String Implements prePayment.IPaymentDMCMApproval.DMCMRoleCode
        Get
            Return cDataType.fString.IfNull(hdnDMCMRoleCode.Value)
        End Get
        Set(value As String)
            hdnDMCMRoleCode.Value = value
        End Set
    End Property
    Public Property DMCMApproverID As String Implements prePayment.IPaymentDMCMApproval.DMCMApproverID
        Get
            Return cDataType.fString.IfNull(hdnDMCMApproverID.Value)
        End Get
        Set(value As String)
            hdnDMCMApproverID.Value = value
        End Set
    End Property
    Public Property DMCMPostedBy As String Implements prePayment.IPaymentDMCMApproval.DMCMPostedBy
        Get
            Return cDataType.fString.IfNull(hdnDMCMPostedBy.Value)
        End Get
        Set(value As String)
            hdnDMCMPostedBy.Value = value
        End Set
    End Property
    Public Property DMCMNumber As Long Implements prePayment.IPaymentDMCMApproval.DMCMNumber
        Get
            Return cDataType.fLong.IfNull(txtDMCMNumber.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtDMCMNumber.Text = "AUTO"
            Else
                txtDMCMNumber.Text = value
            End If
        End Set
    End Property

    Public Property DMCMTransNo As String Implements prePayment.IPaymentDMCMApproval.DMCMTransNo
        Get
            Return cDataType.fString.IfNull(txtDMCMTransNo.Text)
        End Get
        Set(value As String)
                txtDMCMTransNo.Text = value
        End Set
    End Property
    Public Property MemoType As String Implements prePayment.IPaymentDMCMApproval.MemoType
        Get
            Return cDataType.fString.IfNull(txtMemoType.Text)
        End Get
        Set(value As String)
            txtMemoType.Text = value
        End Set
    End Property
    Public Property TotalAmount As Decimal Implements prePayment.IPaymentDMCMApproval.TotalAmount
        Get
            Return cDataType.fDecimal.IfNull(txtTotalAmount.Text)
        End Get
        Set(value As Decimal)
            txtTotalAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property
    Public Property Quantity As Long Implements prePayment.IPaymentDMCMApproval.Quantity
        Get
            Return cDataType.fLong.IfNull(txtQuantity.Text)
        End Get
        Set(value As Long)
            txtQuantity.Text = value
        End Set
    End Property
    Public Property Particular As String Implements prePayment.IPaymentDMCMApproval.Particulars
        Get
            Return cDataType.fString.IfNull(txtParticulars.Text)
        End Get
        Set(value As String)
            txtParticulars.Text = value
        End Set
    End Property
    Public Property SISourceType As String Implements prePayment.IPaymentDMCMApproval.SISourcetype
        Get
            Return cDataType.fString.IfNull(hdnSISourceType.Value)
        End Get
        Set(value As String)
            hdnSISourceType.Value = value
        End Set
    End Property

    Public Property Discount As Decimal Implements prePayment.IPaymentDMCMApproval.Discount
        Get
            Return cDataType.fDecimal.IfNull(txtDiscount.Text)
        End Get
        Set(value As Decimal)
            txtDiscount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property
    Public Property DiscountID As String Implements prePayment.IPaymentDMCMApproval.DiscountID
        Get
            Return cDataType.fString.IfNull(txtDiscountIdNo.Text)
        End Get
        Set(value As String)
            txtDiscountIdNo.Text = value
        End Set
    End Property

    Public Property DebitCreditID As Long Implements prePayment.IPaymentDMCMApproval.DebitCreditID
        Get
            Return cDataType.fLong.IfNull(hdnDebitCreditID.Value)
        End Get
        Set(value As Long)
            hdnDebitCreditID.Value = value
        End Set
    End Property

    Public Property Remarks As String Implements prePayment.IPaymentDMCMApproval.Remarks
        Get
            Return cDataType.fString.IfNull(txtDMCMRemarks.Text)
        End Get
        Set(value As String)
            txtDMCMRemarks.Text = value
            If value = cDataType.fString.Empty Then
                txtDMCMRemarks.Text = ""
            Else
                txtDMCMRemarks.Text = value
            End If
        End Set
    End Property
    
    Public Property Status() As String Implements prePayment.IPaymentDMCMApproval.Status
        Get
            Return cDataType.fString.IfNull(txtDMCMStatus.Text)
        End Get
        Set(value As String)
            txtDMCMStatus.Text = value
        End Set
    End Property

   
    Public Property IsSuccessful As Boolean Implements prePayment.IPaymentDMCMApproval.IsSuccessful
        Get
            Return mIsSuccessful
        End Get
        Set(value As Boolean)
            mIsSuccessful = value
        End Set
    End Property
    Public Property IsButtonSearch() As Boolean Implements prePayment.IPaymentDMCMApproval.IsButtonSearch
        Get
            Return cDataType.fBoolean.IfNull(hdnIsSearchButton.Value)
        End Get
        Set(value As Boolean)
            hdnIsSearchButton.Value = value
        End Set
    End Property

    Public Property Reason As String Implements prePayment.IPaymentDMCMApproval.Reason
        Get
            Return cDataType.fString.IfNull(txtReason.Text)
        End Get
        Set(value As String)
            txtReason.Text = value
        End Set
    End Property
    Public Property BillingType As String Implements prePayment.IPaymentDMCMApproval.BillingType
        Get
            Return cDataType.fString.IfNull(txtBillingType.Text)
        End Get
        Set(value As String)
            txtBillingType.Text = value
        End Set
    End Property
    Public ReadOnly Property SiteCode As Long Implements prePayment.IPaymentDMCMApproval.SiteCode
        Get
            Return Master.SiteID
        End Get
    End Property
    Public ReadOnly Property UserID As Long Implements prePayment.IPaymentDMCMApproval.UserID
        Get
            Return Master.UserPrsPID
        End Get
    End Property



#End Region
#Region "DataTable"
    Public WriteOnly Property dtViewDMCM As DataTable Implements prePayment.IPaymentDMCMApproval.dtViewDMCM
        Set(value As DataTable)
            gvwViewDMCM.DataSource = value
            gvwViewDMCM.DataBind()
        End Set
    End Property
#End Region
#End Region 'Property
#Region "Event"
    Public Event ClearScreenMain(sender As Object, e As EventArgs) Implements prePayment.IPaymentDMCMApproval.ClearScreenMain
    Public Event LoadViewDMCM(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentDMCMApproval.LoadViewDMCM
    Public Event LoadDebitCreditMemo(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentDMCMApproval.LoadDebitCreditMemo
    Public Event ConfirmApprove(sender As Object, e As EventArgs) Implements prePayment.IPaymentDMCMApproval.ConfirmApprove
    Public Event ConfirmReject(sender As Object, e As EventArgs) Implements prePayment.IPaymentDMCMApproval.ConfirmReject

    Public Event ProcessDebitCreditMemo(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentDMCMApproval.ProcessDebitCreditMemo



#End Region

#End Region 'IPaymentDMCMApproval

#Region "Custom Method"
#Region "Sub"
    Private Sub AddAttributes()
        'Call SetFocusBlur(txtFromDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        'Call SetFocusBlur(txtToDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        'Call SetFocusBlur(txtPostDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        ' -------------------------------------------------------------------------------
        'Call SetButtonPostBack(btnMessageOk)
        Call SetButtonPostBack(btnCancel)
        Call SetButtonPostBack(btnConfirmYes)
        Call SetButtonPostBack(btnConfirmNo)
        Call SetButtonPostBack(btnDMCMApprove) 'save
        '--Call SetButtonPostBack(btnSearchAgentClear)
        'Call SetButtonPostBack(btnSearchAgentClose)
        '--Call SetButtonPostBack(btnSearchAgentSearch)
        'Call SetButtonPostBack(btnLoadPostDate)
        'Call SetButtonPostBack(btnPost)
    End Sub
    Private Sub SetButtonPostBack(ByVal pButton As Button)
        pButton.Attributes.Add("OnClick", "if(this.value === 'Processing...') { return false; } else { this.value = 'Processing...';  this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(pButton, Nothing) + ";}")
    End Sub
    Private Sub LoadReference()
        dtViewDMCM = Nothing
        RaiseEvent LoadViewDMCM(Me, EventArgs.Empty)
        gvwViewDMCM.Enabled = True
        upPaymentDMCMApproval.Update()
    End Sub
    Private Sub ClearFields()
        Call ClearSession()
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
    End Sub
    Private Sub ClearSession()
        Session(eSession.IsMessage) = Nothing
        Session(eSession.Message) = Nothing
        Session(eSession.MessageType) = Nothing
        Session(eSession.Modal) = Nothing
    End Sub
    Private Sub SetModalSession(ByVal pModal As AjaxControlToolkit.ModalPopupExtender, ByVal pShow As Boolean, ByVal pSetFocus As Object)
        Session(eSession.Modal) = IIf(pShow, pModal.ID, Nothing)
        If pShow Then
            pModal.Show()
        Else
            pModal.Hide()
        End If
        'FOCUS Me.Page.SetFocus(pSetFocus)
    End Sub
    Private Sub SetDefaults()
        'TODO: Put default values here!
        'SourceSite = SiteCode
    End Sub
#End Region 'Sub

#End Region 'Custom Method

#Region "Event Handlers"
#Region "Page"

    Private Sub PaymentDMCMApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pConfirmationMessage = New preMessages.PConfirmationMessage(Me)
        pPaymentDMCMApproval = New prePayment.PPaymentDMCMApproval(Me)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            Call AddAttributes()
            Call LoadReference()
            Call ClearFields()
            Call SetDefaults()
            Call ManageMain(eDocSaveState.Initial)
            'Call ManageForm("AGENT", True)
        End If
    End Sub
#End Region 'Page
#Region "Button"
    Private Sub btnConfirmYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmYes.Click
        ConfirmClickState = True
        mpeConfirm.Hide()

        Call ClearSession()
        Select Case ConfirmCaller
            Case "CANCEL"
                DocSaveState = eDocSaveState.Cancel
                RaiseEvent ProcessDebitCreditMemo(Me, EventArgs.Empty)
                If IsSuccessful Then
                    'ReceiptById = UserID
                    RaiseEvent LoadDebitCreditMemo(Me, EventArgs.Empty)
                    RaiseEvent LoadViewDMCM(Me, EventArgs.Empty)
                Else
                    DocSaveState = eDocSaveState.ViewNoEdit
                End If
                Call SetModalSession(mpeConfirm, False, btnDMCMReject)
            Case "APPROVED"
                RaiseEvent ProcessDebitCreditMemo(Me, EventArgs.Empty)
                If IsSuccessful Then
                    'ReceiptById = UserID
                    RaiseEvent LoadDebitCreditMemo(Me, EventArgs.Empty)
                    RaiseEvent LoadViewDMCM(Me, EventArgs.Empty)
                    DocSaveState = eDocSaveState.ViewNoEdit
                End If
        End Select
        upPaymentDMCMApproval.Update()
    End Sub
#End Region
#Region "Radio Button"
    Protected Sub radSelectViewDMCM_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentDMCMApproval.radSelectDMCM

        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
        DebitCreditID = cDataType.fLong.IfNull(gvrSelect.Cells(1).Text.Trim)
        'ReceiptByCode = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(7).Text.Trim))
        'SourceSite = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(9).Text.Trim))
        'txtPaymentTypeTotalAmount.Text = PaymentTotalAmount
        ' RaiseEvent LoadDebitCreditMemo(Me, EventArgs.Empty)
        RaiseEvent LoadDebitCreditMemo(Me, EventArgs.Empty)
        'If ReceiptByCode <> Master.UserCode Then
        'btnDMCMSave.Enabled = False
        'btnDMCMPrint.Enabled = False
        'btnDMCMCancel.Enabled = False
        'End If
        'Manage controls


        upPaymentDMCMApproval.Update()
        gvwViewDMCM.Enabled = False

    End Sub
#End Region 'Radio Button
#End Region 'Event Handlers

    Protected Sub btnLoadViewDMCM_Click(sender As Object, e As EventArgs) Handles btnLoadViewDMCM.Click
        IsButtonSearch = True
        RaiseEvent LoadViewDMCM(Me, EventArgs.Empty)
        upPaymentDMCMApproval.Update()
    End Sub

 
    Protected Sub btnDMCMApprove_Click(sender As Object, e As EventArgs) Handles btnDMCMApprove.Click
        RaiseEvent ConfirmApprove(Me, EventArgs.Empty)
    End Sub

    Protected Sub btnDMCMReject_Click(sender As Object, e As EventArgs) Handles btnDMCMReject.Click
        RaiseEvent ConfirmReject(Me, EventArgs.Empty)
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call ClearSession()
        Response.Redirect(ePage.PaymentDMCMApproval, False)
    End Sub
    Private Sub btnCancelYes_Click(sender As Object, e As EventArgs) Handles btnCancelYes.Click
        ConfirmClickState = True
        mpeConfirm.Hide()

        Call ClearSession()
        DocSaveState = eDocSaveState.Cancel
        RaiseEvent ProcessDebitCreditMemo(Me, EventArgs.Empty)
        If IsSuccessful Then
            'ReceiptById = UserID
            RaiseEvent LoadDebitCreditMemo(Me, EventArgs.Empty)
        Else
            DocSaveState = eDocSaveState.ViewNoEdit
        End If
        Call SetModalSession(mpeConfirm, False, btnDMCMReject)

        upPaymentDMCMApproval.Update()
    End Sub
End Class