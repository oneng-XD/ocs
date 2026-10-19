#Region "Description"
' PAGE NAME     : Payment : Batch Premium Related 
' CREATED BY    : MPRO
' CREATED DATE  : 11/11/2014
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

Partial Public Class PaymentBatchPremiumRelated
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preMessages.IConfirmationMessage
    Implements prePayment.IPaymentBatchPremiumRelated
    Implements preReport.IReport
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pConfirmationMessage As preMessages.PConfirmationMessage
    Private pPaymentBatchPremiumRelated As prePayment.PPaymentBatchPremiumRelated
    Private pAgent As preSearch.PAgent
    Private pInsured As preSearch.PInsured
    Private pPayor As preSearch.PPayor
    Private pPolicy As preSearch.PPolicy
    Private pReport As preReport.PReport
    '----------------------------------------------------------------------------------------------
    Private mIsAgentExist As Boolean
    Private mIsInsuredExist As Boolean
    Private mIsPayorExist As Boolean
    Private mIsPolicyExist As Boolean
    Private mIsGpaCardNoExist As Boolean
    Private mIsSuccessful As Boolean
    Private mIsPayTypeSuccessful As Boolean
    Private mIsReceiptSuccessful As Boolean
    Private mIsNewBizSuccessful As Boolean
    '----------------------------------------------------------------------------------------------
    Private mSearchAgentIDTag As Integer
    Private arrAgentIDTag() As HiddenField
    'Private mSalesOffIDTag As Boolean
    'Private mPromoOffIDTag As Boolean
    Public arrTxtAgentID() As TextBox
    Public arrTxtAgentName() As TextBox
    Public arrHdnAgentFnam() As HiddenField
    Public arrHdnAgentLnam() As HiddenField
    Public arrHdnAgentMnam() As HiddenField
    Public arrHdnAgencyFnam() As HiddenField
    Public arrHdnAgencyLnam() As HiddenField
    Public arrHdnAgencyMnam() As HiddenField
    Public arrHdnAgentSalesForce() As HiddenField
    Public arrHdnAgentCatCod() As HiddenField
    Public arrTxtUsdId() As TextBox
    Public arrTxtUsdName() As TextBox

    Private mdtBusinessType As DataTable
    Private mdtReceiptTransaction As DataTable
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
                Me.Page.SetFocus(btnMessageOk)
                'Call SetModalSession(mpeMessage, True, btnMessageOk)
            End If
        End Set
    End Property

#End Region

#Region "Event"

#End Region

#End Region

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
                'Me.Page.SetFocus(btnMessageOk)
                'Call SetModalSession(mpeMessage, True, btnMessageOk)
            End If
        End Set
    End Property

#End Region

#Region "Event"

#End Region

#End Region

#Region "IPaymentBatchPremiumRelated"

#Region "Property"

#Region "Payment Details"

    Public Property DocPrinted As Boolean Implements prePayment.IPaymentBatchPremiumRelated.DocPrinted
        Get
            Return cDataType.fBoolean.IfNull(hdnDocPrinted.value)
        End Get
        Set(value As Boolean)
            hdnDocPrinted.value = value
        End Set
    End Property

    Public Property DocSaveState As Integer Implements prePayment.IPaymentBatchPremiumRelated.DocSaveState
        Get
            Return cDataType.fInteger.IfNull(hdnDocSaveState.Value)
        End Get
        Set(value As Integer)
            hdnDocSaveState.Value = value

            ManageMain(value)

            Select Case value
                Case eDocSaveState.Initial
                    ibtnViewBatch.Visible = True
                    'ibtnClearOPR.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Save"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False

                    RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
                Case eDocSaveState.ViewEdit
                    ibtnViewBatch.Visible = True
                    'ibtnClearOPR.Visible = True
                    btnReceiptAddNew.Enabled = False
                    btnReceiptSave.Enabled = True
                    btnReceiptSave.Text = "Modify"
                    btnReceiptPreview.Enabled = True
                    btnReceiptPrint.Enabled = True
                    btnReceiptCancel.Enabled = False

                Case eDocSaveState.ViewNoEdit
                    ibtnViewBatch.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Modify"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = True
                    btnReceiptCancel.Enabled = True

                Case eDocSaveState.Edit
                    'Main Buttons
                    ibtnViewBatch.Visible = False
                    'ibtnClearOPR.Visible = False
                    btnReceiptAddNew.Enabled = False
                    btnReceiptSave.Enabled = True
                    btnReceiptSave.Text = "Update"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False

                Case eDocSaveState.AddNew
                    ibtnViewBatch.Visible = False
                    'ibtnClearOPR.Visible = True
                    btnReceiptAddNew.Enabled = False
                    btnReceiptSave.Enabled = True
                    btnReceiptSave.Text = "Save"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False
                Case eDocSaveState.Cancel
                    ibtnViewBatch.Visible = True
                    'ibtnClearOPR.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Save"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False
                Case eDocSaveState.Print
                    ibtnViewBatch.Visible = True
                    'ibtnClearOPR.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Modify"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = True
                    If OPRDate.Date = Now.Date Then
                        btnReceiptCancel.Enabled = DocPrinted
                    Else
                        btnReceiptCancel.Enabled = False
                    End If
            End Select
        End Set
    End Property

    Public Property IsPreview As Boolean Implements preReport.IReport.IsPreview
        Get
            Return cDataType.fBoolean.IfNull(hdnIsPreviewTag.Value)
        End Get
        Set(value As Boolean)
            hdnIsPreviewTag.Value = value
        End Set
    End Property

    Public ReadOnly Property DocType As String Implements prePayment.IPaymentBatchPremiumRelated.DocType
        Get
            Return eReference.DocTypeOPR
        End Get
    End Property

    Public ReadOnly Property SiteCode As Long Implements prePayment.IPaymentBatchPremiumRelated.SiteCode, preReport.IReport.SiteCode
        Get
            Return Master.SiteID
        End Get
    End Property

    Public ReadOnly Property SiteIpAddr As String Implements preReport.IReport.SiteIpAddr
        Get
            Return Master.SiteIpAddr
        End Get
    End Property

    Public ReadOnly Property UserID As Long Implements prePayment.IPaymentBatchPremiumRelated.UserID, preReport.IReport.UserId
        Get
            Return Master.UserPrsPID
        End Get
    End Property

    Public Property ReceiptByCode As String Implements prePayment.IPaymentBatchPremiumRelated.ReceiptByCode
        Get
            Return cDataType.fString.IfNull(hdnReceiptByCode.Value)
        End Get
        Set(value As String)
            hdnReceiptByCode.Value = value
        End Set
    End Property

    Public Property ReceiptById As Long Implements prePayment.IPaymentBatchPremiumRelated.ReceiptById
        Get
            Return cDataType.fString.IfNull(hdnReceiptById.Value)
        End Get
        Set(value As Long)
            hdnReceiptById.Value = value
        End Set
    End Property

    Public Property IsSuccessful As Boolean Implements prePayment.IPaymentBatchPremiumRelated.IsSuccessful, preReport.IReport.IsSuccessful
        Get
            Return mIsSuccessful
        End Get
        Set(value As Boolean)
            mIsSuccessful = value
        End Set
    End Property

    Public Property IsSourceSiteLocked() As Boolean Implements prePayment.IPaymentBatchPremiumRelated.IsSourceSiteLocked
        Get
            Return cDataType.fBoolean.IfNull(hdnIsSourceSiteLocked.Value)
        End Get
        Set(ByVal value As Boolean)
            If value Then
                If DocSaveState = eReference.DocSaveState.AddNew Or DocSaveState = eReference.DocSaveState.Edit Then
                    RaiseEvent CheckSourceSite(Me, EventArgs.Empty)
                    value = IsSuccessful
                End If
            End If
            hdnIsSourceSiteLocked.Value = value
            ManageOPRPaymentDetails("SOURCESITE", value)
        End Set
    End Property

    Public Property SourceSite As String Implements prePayment.IPaymentBatchPremiumRelated.SourceSite
        Get
            Return cDataType.fString.IfNull(ddlSourceSite.SelectedValue)
        End Get
        Set(value As String)
            ddlSourceSite.SelectedValue = value
        End Set
    End Property

    Public Property BatchId As Long Implements prePayment.IPaymentBatchPremiumRelated.BatchID
        Get
            Return cDataType.fLong.IfNull(txtBatchID.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtBatchID.Text = Nothing
            Else
                txtBatchID.Text = value
            End If
        End Set
    End Property

    Public Property OPRDate As Date Implements prePayment.IPaymentBatchPremiumRelated.OPRDate
        Get
            Return cDataType.fDate.IfNull(txtOPRDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtOPRDate.Text = Nothing
            Else
                txtOPRDate.Text = value
            End If
        End Set
    End Property

    Public Property ViewBatchFrom As Date Implements prePayment.IPaymentBatchPremiumRelated.ViewBatchFrom
        Get
            Return cDataType.fDate.IfNull(txtFromDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtFromDate.Text = cDataType.fDate.Current.AddDays(-3)
            Else
                txtFromDate.Text = value
            End If
        End Set
    End Property

    Public Property ViewBatchTo As Date Implements prePayment.IPaymentBatchPremiumRelated.ViewBatchTo
        Get
            Return cDataType.fDate.IfNull(txtToDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtToDate.Text = cDataType.fDate.Current
            Else
                txtToDate.Text = value
            End If
        End Set
    End Property

    Public Property ViewBatchDocNumber As Long Implements prePayment.IPaymentBatchPremiumRelated.ViewBatchID
        Get
            Return cDataType.fLong.IfNull(txtViewBatchID.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtViewBatchID.Text = Nothing
            Else
                txtViewBatchID.Text = value
            End If
        End Set
    End Property

    Public Property OPRPaymentType As String Implements prePayment.IPaymentBatchPremiumRelated.OPRPaymentType
        Get
            Return cDataType.fString.IfNull(ddlOPRPaymentType.SelectedValue)
        End Get
        Set(value As String)
            ddlOPRPaymentType.SelectedValue = value
            Call ddlOPRPaymentType_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property OPRCurrency As String Implements prePayment.IPaymentBatchPremiumRelated.OPRCurrency
        Get
            Return cDataType.fString.IfNull(ddlOPRCurrency.SelectedValue)
        End Get
        Set(value As String)
            ddlOPRCurrency.SelectedValue = value
        End Set
    End Property

    Public Property BatchNonPrem As String Implements prePayment.IPaymentBatchPremiumRelated.BatchNonPrem
        Get
            Return cDataType.fString.IfNull(ddlNonPremium.SelectedValue)
        End Get
        Set(value As String)
            ddlNonPremium.SelectedValue = value
        End Set
    End Property

    Public Property WithAPR As Boolean Implements prePayment.IPaymentBatchPremiumRelated.WithAPR
        Get
            Return cDataType.fBoolean.IfNull(chkWithAPR.Checked)
        End Get
        Set(value As Boolean)
            chkWithAPR.Checked = value
            accAPRDetails.Visible = value
            If value = False Then
                RaiseEvent ClearScreenAPRDetails(Me, EventArgs.Empty)
            Else
                APRAmount = OPRGrossAmount
            End If
        End Set
    End Property

    Public Property OPRGrossAmount As Decimal Implements prePayment.IPaymentBatchPremiumRelated.OPRGrossAmount
        Get
            Return cDataType.fDecimal.IfNull(txtOprTotalAmount.Text)
        End Get
        Set(value As Decimal)
            txtOprTotalAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
            If OPRGrossAmount > 0 AndAlso Not PaymentTypeTag Then
                PaymentTypeTag = True
            End If
        End Set
    End Property

    Public Property OPRRemarks As String Implements prePayment.IPaymentBatchPremiumRelated.OPRRemarks
        Get
            Return cDataType.fString.IfNull(txtOPRRemarks.Text)
        End Get
        Set(value As String)
            txtOPRRemarks.Text = value
        End Set
    End Property

    Public ReadOnly Property OPRFlags As String Implements prePayment.IPaymentBatchPremiumRelated.OPRFlags
        Get
            Dim strReturn As String = String.Empty
            strReturn += IIf(WithAPR, "1", "0")
            strReturn += IIf(CheckPaymentTag, "1", "0")
            strReturn += "0"
            Return strReturn
        End Get
    End Property

#End Region

#Region "APR Details"

    Public Property APRNumber As Long Implements prePayment.IPaymentBatchPremiumRelated.APRNumber
        Get
            Return cDataType.fLong.IfNull(txtAPRNumber.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtAPRNumber.Text = Nothing
            Else
                txtAPRNumber.Text = value
            End If
        End Set
    End Property

    Public Property APRDate As Date Implements prePayment.IPaymentBatchPremiumRelated.APRDate
        Get
            Return cDataType.fDate.IfNull(txtAPRDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtAPRDate.Text = Nothing
            Else
                txtAPRDate.Text = value
            End If
        End Set
    End Property

    Public Property APRAmount As Decimal Implements prePayment.IPaymentBatchPremiumRelated.APRAmount
        Get
            Return cDataType.fDecimal.IfNull(txtAPRAmount.Text)
        End Get
        Set(value As Decimal)
            txtAPRAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

#End Region

#Region "Payment Type Details"

#Region "Cash Details"

    Public Property OPRCashAmount As Decimal Implements prePayment.IPaymentBatchPremiumRelated.OPRCashAmount
        Get
            Return cDataType.fDecimal.IfNull(txtOPRCashAmount.Text)
        End Get
        Set(value As Decimal)
            txtOPRCashAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

#End Region

#Region "Check Details"

    Public Property CheckNumber As Long Implements prePayment.IPaymentBatchPremiumRelated.CheckNumber
        Get
            Return cDataType.fLong.IfNull(txtCheckNumber.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtCheckNumber.Text = Nothing
            Else
                txtCheckNumber.Text = value
            End If
        End Set
    End Property

    Public Property CheckAmount As Decimal Implements prePayment.IPaymentBatchPremiumRelated.CheckAmount
        Get
            Return cDataType.fDecimal.IfNull(txtCheckAmount.Text)
        End Get
        Set(value As Decimal)
            txtCheckAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property CheckBankName As String Implements prePayment.IPaymentBatchPremiumRelated.CheckBankName
        Get
            If ddlCheckBankName.SelectedValue = "OTHER" Then
                Return cDataType.fString.IfNull(txtOtherBank.Text)
            Else
                Return cDataType.fString.IfNull(ddlCheckBankName.SelectedValue)
            End If
        End Get
        Set(value As String)
            Try
                ddlCheckBankName.SelectedValue = value
                divOtherBank.Visible = False
            Catch
                ddlCheckBankName.SelectedValue = "OTHER"
                txtOtherBank.Text = value
                divOtherBank.Visible = True
            End Try
        End Set
    End Property

    Public Property CheckBankBranch As String Implements prePayment.IPaymentBatchPremiumRelated.CheckBankBranch
        Get
            Return cDataType.fString.IfNull(txtCheckBankBranch.Text)
        End Get
        Set(value As String)
            txtCheckBankBranch.Text = value
        End Set
    End Property

    Public Property CheckLineNumber As Integer Implements prePayment.IPaymentBatchPremiumRelated.CheckLineNumber
    Public Property CheckOTCFlag As Integer Implements prePayment.IPaymentBatchPremiumRelated.CheckOTCFlag

#End Region

#Region "Payment Totals"

    Public Property IsPayTypeSuccessful As Boolean Implements prePayment.IPaymentBatchPremiumRelated.IsPayTypeSuccessful
        Get
            Return cDataType.fBoolean.IfNull(mIsPayTypeSuccessful)
        End Get
        Set(value As Boolean)
            mIsPayTypeSuccessful = value
        End Set
    End Property

    Public Property CashTotalAmount As Decimal Implements prePayment.IPaymentBatchPremiumRelated.CashTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(hdnCashTotalAmount.Value)
        End Get
        Set(value As Decimal)
            hdnCashTotalAmount.Value = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
            txtPaymentTypeTotalAmount.Text = FormatNumber(PaymentTotalAmount, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property CheckTotalAmount As Decimal Implements prePayment.IPaymentBatchPremiumRelated.CheckTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(hdnCheckTotalAmount.Value)
        End Get
        Set(value As Decimal)
            hdnCheckTotalAmount.Value = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
            txtPaymentTypeTotalAmount.Text = FormatNumber(PaymentTotalAmount, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public ReadOnly Property PaymentTotalAmount As Decimal Implements prePayment.IPaymentBatchPremiumRelated.PaymentTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(CashTotalAmount + CheckTotalAmount)
        End Get
        'Set(value as decimal)
        '   txtPaymentTypeTotalAmount.Text = PaymentTotalAmount
        'txtPaymentTypeTotalAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        'End Set
    End Property

    Public Property PaymentTypeID As String Implements prePayment.IPaymentBatchPremiumRelated.PaymentTypeID
        Get
            Return cDataType.fString.IfNull(hdnPaymentTypeID.Value)
        End Get
        Set(value As String)
            hdnPaymentTypeID.Value = value
            Call ddlOPRPaymentType_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property

#End Region

#End Region

#Region "Tag"
    Public Property PrevPayType As String Implements prePayment.IPaymentBatchPremiumRelated.PrevPayType
        Get
            Return cDataType.fString.IfNull(hdnPrevPayType.Value)
        End Get
        Set(value As String)
            hdnPrevPayType.Value = value
        End Set
    End Property

    Public Property PaymentTypeTag As Boolean Implements prePayment.IPaymentBatchPremiumRelated.PaymentTypeTag
        Get
            Return cDataType.fBoolean.IfNull(hdnPaymentTypeTag.Value)
        End Get
        Set(value As Boolean)
            hdnPaymentTypeTag.Value = value
            accPaymentTypeDetails.Visible = value

            RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
            RaiseEvent LoadAllowedPaymentType(Me, EventArgs.Empty)
            CashTotalAmount = cDataType.fDecimal.Empty
            CheckTotalAmount = cDataType.fDecimal.Empty
            PrevPayType = cDataType.fString.Empty
            OPRPaymentType = cDataType.fString.Empty
            lstPaymentTypeDetails = New List(Of cPaymentType)

            If value Then
                'Manage Payment Type|Enable addition of Payment Type Details
                ManagePaymentType(String.Empty, True)
            End If
        End Set
    End Property

    Public Property CashPaymentTag As Boolean Implements prePayment.IPaymentBatchPremiumRelated.CashPaymentTag
        Get
            Return cDataType.fBoolean.IfNull(hdnCashPaymentTag.Value)
        End Get
        Set(value As Boolean)
            hdnCashPaymentTag.Value = value
            pnlCashDetails.Visible = value

            RaiseEvent ClearScreenCashDetails(Me, EventArgs.Empty)

        End Set
    End Property

    Public Property CheckPaymentTag As Boolean Implements prePayment.IPaymentBatchPremiumRelated.CheckPaymentTag
        Get
            Return cDataType.fBoolean.IfNull(hdnCheckPaymentTag.Value)
        End Get
        Set(value As Boolean)
            hdnCheckPaymentTag.Value = value
            pnlCheckDetails.Visible = value
            ibtnAddCash.Visible = value

            RaiseEvent ClearScreenCheckDetails(Me, EventArgs.Empty)

        End Set
    End Property

#End Region

#Region "DataTable"

    Public WriteOnly Property dtViewBatch As DataTable Implements prePayment.IPaymentBatchPremiumRelated.dtViewBatch
        Set(value As DataTable)
            If Not IsNothing(value) Then
                Dim dtFiltered = From c In value.AsEnumerable
                                 Where c.Item("doctyp") = eReference.DocTypeOPR
                                 Select c
                If dtFiltered.Any() Then
                    value = dtFiltered.CopyToDataTable
                Else
                    value.Clear()
                End If
            End If

            gvwViewBatch.DataSource = value
            gvwViewBatch.DataBind()
        End Set
    End Property

    Public WriteOnly Property dtSourceSite As DataTable Implements prePayment.IPaymentBatchPremiumRelated.dtSourceSite
        Set(value As DataTable)
            Call SetDropDownList(ddlSourceSite, value, "PRSNME", "PRSPID", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtCurrency As DataTable Implements prePayment.IPaymentBatchPremiumRelated.dtCurrency
        Set(value As DataTable)
            Call SetDropDownList(ddlOPRCurrency, value, "CURNAM", "CURCOD", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtPaymentType As DataTable Implements prePayment.IPaymentBatchPremiumRelated.dtPaymentType
        Set(value As DataTable)
            value.DefaultView.Sort = "DESCRP ASC"
            value = value.DefaultView.ToTable
            Call SetDropDownList(ddlOPRPaymentType, value, "DESCRP", "CODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtBankList As DataTable Implements prePayment.IPaymentBatchPremiumRelated.dtBankList
        Set(value As DataTable)
            Call SetDropDownList(ddlCheckBankName, value, "DESCRP", "CODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtBatchDetails As DataTable Implements prePayment.IPaymentBatchPremiumRelated.dtBatchDetails
        Set(value As DataTable)
            'Call SetDropDownList(ddlCheckBankName, value, "DESCRP", "NUMCODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtBatchNonPrem As DataTable Implements prePayment.IPaymentBatchPremiumRelated.dtBatchNonPrem
        Set(value As DataTable)
            Call SetDropDownList(ddlNonPremium, value, "DESCRP", "NUMCODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property
    
#End Region

#Region "List (Of Class)"

    Public Property lstPaymentTypeDetails As List(Of cPaymentType) Implements prePayment.IPaymentBatchPremiumRelated.lstPaymentTypeDetails
        Get
            Return ConvertToList(Of cPaymentType)(gvwPaymentTypeDetails)
        End Get
        Set(ByVal value As List(Of cPaymentType))
            gvwPaymentTypeDetails.DataSource = value
            gvwPaymentTypeDetails.DataBind()
        End Set
    End Property

    Public Property lstOprList As List(Of cBatchOpr) Implements prePayment.IPaymentBatchPremiumRelated.lstOprList
        Get
            Return ConvertToList(Of cBatchOpr)(gvwOprList)
        End Get
        Set(ByVal value As List(Of cBatchOpr))
            gvwOprList.DataSource = value
            gvwOprList.DataBind()
        End Set
    End Property

#End Region

#End Region

#Region "Event"
    Public Event ClearScreenAPRDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenAPRDetails
    Public Event ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenMain
    Public Event ClearScreenPaymentDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenPaymentDetails
    Public Event ClearScreenCashDetails(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenCashDetails
    Public Event ClearScreenCheckDetails(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenCheckDetails
    Public Event ClearScreenPaymentTypeDetails(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenPaymentTypeDetails
    Public Event ClearScreenViewBatch(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenViewBatch
    Public Event ClearScreenBatch(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ClearScreenBatch
    ' -------------------------------------------------------------------------------
    Public Event LoadViewBatch(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadViewBatch
    Public Event LoadSourceSite(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadSourceSite
    Public Event LoadCurrency(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadCurrency
    Public Event LoadAllowedPaymentType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadAllowedPaymentType
    Public Event LoadPaymentType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadPaymentType
    Public Event LoadNewOpr(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadNewOPR
    Public Event LoadBankList(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadBankList
    Public Event LoadBatch(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadBatch
    Public Event LoadBatchDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadBatchDetails
    Public Event LoadBatchNonPrem(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadBatchNonPrem
    ' -------------------------------------------------------------------------------
    Public Event CheckPrevPayType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.CheckPrevPayType
    Public Event CheckSourceSite(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.CheckSourceSite
    ' -------------------------------------------------------------------------------
    Public Event AddCashPayment(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.AddCashPayment
    Public Event AddPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.AddPaymentTypeDetails
    Public Event DeletePaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.DeletePaymentTypeDetails
    Public Event GetPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.GetPaymentTypeDetails
    ' -------------------------------------------------------------------------------
    Public Event ConfirmCancel(sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ConfirmCancel
    Public Event ConfirmSave(sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ConfirmSave
    Public Event ConfirmPrint(sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ConfirmPrint
    Public Event ProcessPaymentBatchPremium(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.ProcessPaymentBatchPremium
    Public Event LoadOPR(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.LoadOPR
    Public Event GenerateReport(sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.GenerateReport
#End Region

#End Region

#Region "IReport"

#Region "Properties"

    Public Property ReportType() As eReport Implements preReport.IReport.ReportType
        Get
            Return cDataType.fString.IfNull(hdnReportType.Value)
        End Get
        Set(value As eReport)
            hdnReportType.Value = value
        End Set
    End Property

    Public Property RptParamString() As String Implements preReport.IReport.RptParamString
        Get
            Return Session(eSession.ReportParam)
        End Get
        Set(ByVal value As String)
            Session(eSession.ReportParam) = value
        End Set
    End Property

#End Region

#Region "Event"

    Public Event ClearScreenReport(sender As Object, e As EventArgs) Implements preReport.IReport.ClearScreenReport

#End Region

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub PaymentBatchPremiumRelated_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pConfirmationMessage = New preMessages.PConfirmationMessage(Me)
        pPaymentBatchPremiumRelated = New prePayment.PPaymentBatchPremiumRelated(Me)
        pReport = New preReport.PReport(Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call AddAttributes()
            Call LoadReference()
            Call ClearFields()
            Call ManageMain(eDocSaveState.Initial)
        End If

    End Sub

#End Region

#Region "Button"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call ClearSession()
        Response.Redirect(ePage.PaymentBatchPremiumRelated, False)
    End Sub

    Private Sub btnMessageOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessageOk.Click
        mpeMessage.Hide()
        Select Case Session(eSession.Modal)
            Case "mpeViewBatch"
                Call SetModalSession(mpeViewBatch, True, btnLoadViewBatch)
                'Case "mpeReport"
                '    Call SetModalSession(mpeReport, True, btnReportClose)
        End Select

        'If imgMessage.ImageUrl = eSystemMessage.Critical Then
        '    Response.Redirect(ePage.PaymentBatchPremiumRelated, False)
        'End If
        Call ClearSession()
    End Sub

    Private Sub btnPaymentTypeAdd_Click(sender As Object, e As EventArgs) Handles btnPaymentTypeAdd.Click
        Call ClearSession()
        'PaymentTypeID = gvwPaymentTypeDetails.Rows.Count + 1
        RaiseEvent AddPaymentTypeDetails(Me, EventArgs.Empty)
        If IsPayTypeSuccessful Then
            RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
            Me.Page.SetFocus(ddlOPRPaymentType)
        End If
        upPaymentBatchPremiumRelated.Update()
    End Sub

    Private Sub btnPaymentTypeClear_Click(sender As Object, e As EventArgs) Handles btnPaymentTypeClear.Click
        RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
    End Sub

    Private Sub btnViewBatchClose_Click(sender As Object, e As EventArgs) Handles btnViewBatchClose.Click
        Call ClearSession()
        Call SetModalSession(mpeViewBatch, False, ibtnViewBatch)
    End Sub

    Private Sub btnReceiptAddNew_Click(sender As Object, e As EventArgs) Handles btnReceiptAddNew.Click
        Call ClearSession()
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
        RaiseEvent LoadNewOpr(Me, EventArgs.Empty)
        Call SetDefaults()
        If IsSuccessful Then
            DocSaveState = eDocSaveState.AddNew
            IsSourceSiteLocked = True
        Else
            DocSaveState = eDocSaveState.Initial
        End If
        upPaymentBatchPremiumRelated.Update()
    End Sub

    Private Sub btnReceiptSave_Click(sender As Object, e As EventArgs) Handles btnReceiptSave.Click
        Call ClearSession()

        Select Case DocSaveState
            Case eDocSaveState.ViewEdit
                DocSaveState = eReference.DocSaveState.Edit
                ManageMain(DocSaveState)
                IsSourceSiteLocked = True
            Case eDocSaveState.AddNew, eDocSaveState.Edit
                RaiseEvent ConfirmSave(Me, EventArgs.Empty)
                'SetModalSession(mpeConfirm, True, btnConfirmNo)
        End Select

        upPaymentBatchPremiumRelated.Update()
    End Sub
#End Region

#Region "CheckBox"

    Private Sub chkWithAPR_CheckedChanged(sender As Object, e As EventArgs) Handles chkWithAPR.CheckedChanged
        WithAPR = DirectCast(sender, CheckBox).Checked
    End Sub

#End Region

#Region "DropDownList"

    Private Sub ddlSourceSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSourceSite.SelectedIndexChanged
        ddlSourceSite.Focus()
    End Sub

    Private Sub ddlOPRPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOPRPaymentType.SelectedIndexChanged
        'If DocSaveState = eReference.DocSaveState.AddNew Or DocSaveState = eReference.DocSaveState.Edit Then
        IsPayTypeSuccessful = False
        RaiseEvent CheckPrevPayType(Me, EventArgs.Empty)
        If IsPayTypeSuccessful Then
            ManagePaymentType(OPRPaymentType, True)
            PrevPayType = ddlOPRPaymentType.SelectedValue
        Else
            OPRPaymentType = PrevPayType
        End If
        'End If
    End Sub

#End Region

#Region "ImageButton"

    Private Sub ibtnViewBatch_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnViewBatch.Click
        RaiseEvent ClearScreenViewBatch(Me, EventArgs.Empty)
        RaiseEvent LoadViewBatch(Me, EventArgs.Empty)

        Call ClearSession()
        Call SetModalSession(mpeViewBatch, True, btnLoadViewBatch)
    End Sub

#End Region

#Region "GridView"

    Private Sub gvwPaymentTypeDetails_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvwPaymentTypeDetails.RowDeleting

        Dim index As Integer = Convert.ToInt32(e.RowIndex)
        Dim radSelect As RadioButton

        radSelect = DirectCast(gvwPaymentTypeDetails.Rows(index).FindControl("radSelectPayTypeDetails"), RadioButton)
        radSelect.Checked = True
        radSelectPayTypeDetails_CheckedChanged(radSelect, EventArgs.Empty)

        'Do not show "change of payment" prompt
        mpeMessage.Hide()
        '--------------------------------------

        Call ClearSession()
        RaiseEvent DeletePaymentTypeDetails(Me, EventArgs.Empty)

        If IsPayTypeSuccessful Then
            RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
            'Call ManagePaymentTypeDetails("SEARCH")
        End If
        Me.Page.SetFocus(ddlOPRPaymentType)
        upPaymentBatchPremiumRelated.Update()

    End Sub

#End Region

#Region "Radio Button"

    Protected Sub radSelectViewBatch_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.radSelectViewBatch

        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
        BatchId = cDataType.fLong.IfNull(gvrSelect.Cells(1).Text.Trim)
        ReceiptByCode = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(6).Text.Trim))
        ReceiptById = cDataType.fLong.IfNull(gvrSelect.Cells(7).Text.Trim)

        RaiseEvent LoadOPR(Me, EventArgs.Empty)

        If ReceiptByCode <> Master.UserCode Then
            btnReceiptPrint.Enabled = False
            btnReceiptSave.Enabled = False
            btnReceiptCancel.Enabled = False
        End If
        'Manage controls

        'DocSaveState = eReference.DocSaveState.ViewEdit

        Call SetModalSession(mpeViewBatch, False, ibtnViewBatch)
        upPaymentBatchPremiumRelated.Update()

    End Sub

    Protected Sub radSelectPayTypeDetails_CheckedChanged(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentBatchPremiumRelated.radSelectPayTypeDetails
        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        Call DeselectGridView(gvwPaymentTypeDetails, radSelect)
        RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
        OPRPaymentType = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(2).Text.Trim))
        PaymentTypeID = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(1).Text.Trim))
        'Call ddlOPRPaymentType_SelectedIndexChanged(Me, EventArgs.Empty)
        RaiseEvent GetPaymentTypeDetails(Me, EventArgs.Empty)
        'Call ManagePolicy("EXIST", False)

    End Sub

#End Region

#End Region

#Region "Custom Method"

#Region "Sub"

    Private Sub AddAttributes()
        Call SetFocusBlur(txtAPRNumber, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber)
        Call SetFocusBlur(txtAPRDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        Call SetFocusBlur(txtAPRAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtCheckNumber, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber)
        Call SetFocusBlur(txtCheckAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        'Call SetFocusBlur(txtCheckBankName, eCSS.TextBoxInputLongFocus, eCSS.TextBoxInputLong)
        Call SetFocusBlur(txtCheckBankBranch, eCSS.TextBoxInputLongFocus, eCSS.TextBoxInputLong)
        ' -------------------------------------------------------------------------------
        Call SetButtonPostBack(btnCancel)
        Call SetButtonPostBack(btnLoadViewBatch)
        Call SetButtonPostBack(btnConfirmYes)
        Call SetButtonPostBack(btnReceiptAddNew)
        Call SetButtonPostBack(btnReceiptCancel)
        Call SetButtonPostBack(btnReceiptPrint)
        Call SetButtonPostBack(btnReceiptSave)
        ' -------------------------------------------------------------------------------        

        'btnReceiptOpenReport.Attributes.Add("onclick", "OpenReport(); return false;")
        'btnReceiptPrint.Attributes.Add("onclick", "OpenReport(); return false;")

    End Sub

    Private Sub ClearDropDownList(ByVal pDropDownList As DropDownList, ByVal pText As String, ByVal pValue As String)
        With pDropDownList
            .Items.Clear()
            .Items.Insert(0, New ListItem(pText, pValue))
        End With
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
        Session(eSession.ReportParam) = Nothing
    End Sub

    Private Sub DeselectGridView(ByVal pGridview As GridView, ByVal pRadButtonID As RadioButton)
        Dim radSelect As RadioButton

        For Each dr As GridViewRow In pGridview.Rows
            radSelect = DirectCast(dr.FindControl(pRadButtonID.ID), RadioButton)
            If Not radSelect.UniqueID = pRadButtonID.UniqueID Then
                radSelect.Checked = False
            End If
        Next
    End Sub

    Private Sub LoadReference()
        RaiseEvent LoadSourceSite(Me, EventArgs.Empty)
        RaiseEvent LoadCurrency(Me, EventArgs.Empty)
        RaiseEvent LoadPaymentType(Me, EventArgs.Empty)
        RaiseEvent LoadBankList(Me, EventArgs.Empty)
        'RaiseEvent LoadBatchDetails(Me, EventArgs.Empty)
        RaiseEvent LoadBatchNonPrem(Me, EventArgs.Empty)
    End Sub

    Private Sub SetButtonPostBack(ByVal pButton As Button)
        'pButton.Attributes.Add("onclick", " this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(pButton, Nothing) + ";")
        pButton.Attributes.Add("OnClick", "if(this.value === 'Processing...') { return false; } else { this.value = 'Processing...';  this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(pButton, Nothing) + ";}")
    End Sub

    Private Sub SetCurrency(ByVal pTextbox As TextBox, ByVal pDecimal As Integer)
        pTextbox.Attributes.Add("onkeypress", "return blockNonNumbers(this, event, true, false);")
        Select Case pDecimal
            Case -1 ' unlimited decimal places
                pTextbox.Attributes.Add("onblur", "extractNumber(this,-1,false); javascript:this.value=Comma(this.value);")
                pTextbox.Attributes.Add("onkeyup", "extractNumber(this,-1,false); javascript:this.value=Comma(this.value);")
            Case 0 ' no decimal places
                pTextbox.Attributes.Add("onblur", "extractNumber(this,0,false); javascript:this.value=Comma(this.value);")
                pTextbox.Attributes.Add("onkeyup", "extractNumber(this,0,false); javascript:this.value=Comma(this.value);")
            Case 2 ' 2 decimal places
                pTextbox.Attributes.Add("onblur", "extractNumber(this,2,false); javascript:this.value=Comma(this.value);")
                pTextbox.Attributes.Add("onkeyup", "extractNumber(this,2,false); javascript:this.value=Comma(this.value);")
            Case 3 ' 3 decimal places
                pTextbox.Attributes.Add("onblur", "extractNumber(this,3,false); javascript:this.value=Comma(this.value);")
                pTextbox.Attributes.Add("onkeyup", "extractNumber(this,3,false); javascript:this.value=Comma(this.value);")
            Case 4 ' 4 decimal places
                pTextbox.Attributes.Add("onblur", "extractNumber(this,4,false); javascript:this.value=Comma(this.value);")
                pTextbox.Attributes.Add("onkeyup", "extractNumber(this,4,false); javascript:this.value=Comma(this.value);")
        End Select
    End Sub

    Private Sub SetDefaults()
        'TODO: Put default values here!
        SourceSite = SiteCode

        OPRCurrency = "USD"
        BatchNonPrem = "71008"
    End Sub

    Private Sub SetReportSessionScript(ByVal pReport As String)
        If Session("script") = String.Empty Or Session("script") Is Nothing Then
            Session("script") = "window.open('" + pReport + "','','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
            'Session("script") = "window.open('" + pReport + "','_blank','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
        Else
            Session("script") = Session("script") & "window.open('" + pReport + "','','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
            'Session("script") = Session("script") & "window.open('" + pReport + "','_blank','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
        End If
    End Sub

    Private Sub ManageMain(ByVal pAction As Integer)
        Select Case pAction
            Case eDocSaveState.Initial, eDocSaveState.ViewNoEdit, eDocSaveState.ViewEdit, eDocSaveState.Print, eDocSaveState.Cancel
                ManageBatch(eReference.MgePol.Initial, False)
                ManageOPRPaymentDetails("ENABLED", False)
                ManagePaymentType("ENABLED", False)
                ManageAPRDetails("ENABLED", False)

            Case eDocSaveState.AddNew, eDocSaveState.Edit
                ManageBatch(eReference.MgePol.Search, True)
                ManageOPRPaymentDetails("ENABLED", True)
                ManagePaymentType("ENABLED", True)
                ManageAPRDetails("ENABLED", True)

        End Select
    End Sub

    Private Sub ManageBatch(ByVal pAction As eReference.MgePol, ByVal pEnabled As Boolean)

        Select Case pAction
            Case eReference.MgePol.Search
                txtBatchID.Enabled = pEnabled
                ibtnSearchBatch.Visible = pEnabled
                ibtnClearBatch.Visible = Not pEnabled
                ibtnViewBatch.Visible = False
                
            Case eReference.MgePol.Initial

                txtBatchID.Enabled = False
                ibtnSearchBatch.Visible = False
                ibtnClearBatch.Visible = False
                ibtnViewBatch.Visible = True
                
        End Select

    End Sub

    Private Sub ManageOPRPaymentDetails(ByVal pAction As String, Optional ByVal pEnabled As Boolean? = Nothing)

        Select Case pAction
            Case "ENABLED"
                pnlPaymentDetails1.Enabled = pEnabled

            Case "SOURCESITE"
                ddlSourceSite.Enabled = Not pEnabled
                ibtnVerifySourceSite.Visible = Not pEnabled
                ibtnClearSourceSite.Visible = pEnabled

            Case Else
                ddlSourceSite.Enabled = pEnabled
                ddlOPRCurrency.Enabled = pEnabled
                chkWithAPR.Enabled = pEnabled
                txtOPRRemarks.Enabled = pEnabled

        End Select

    End Sub

    Private Sub ManagePaymentType(ByVal pAction As String, ByVal pEnabled As Boolean)
        'Manage visibility 
        CashPaymentTag = False
        CheckPaymentTag = False

        Select Case pAction
            Case "ENABLED"
                pnlPaymentTypeDetails.Enabled = pEnabled

            Case eReference.PayTypeCSH
                CashPaymentTag = True

            Case eReference.PayTypeCHQ
                CheckPaymentTag = True

            Case Else 'Default State
        End Select

    End Sub

    Private Sub ManageAPRDetails(ByVal pAction As String, ByVal pEnabled As Boolean)

        Select Case pAction
            Case "ENABLED"
                pnlAPRDetails.Enabled = pEnabled

            Case Else
                txtAPRNumber.Enabled = pEnabled
                txtAPRAmount.Enabled = pEnabled
                txtAPRDate.Enabled = pEnabled

        End Select

    End Sub

    Private Sub SetDropDownList(ByVal pDropDownList As DropDownList, ByVal pDataSource As DataTable, ByVal pDataTextField As String, _
        ByVal pDataValueField As String, Optional ByVal pNewDataTextField As String = Nothing, Optional ByVal pNewDataValueField As String = Nothing)

        With pDropDownList
            .Items.Clear()
            If Not IsNothing(pNewDataTextField) AndAlso Not IsNothing(pNewDataValueField) Then
                If IsNothing(pNewDataTextField) Then pNewDataTextField = String.Empty
                If IsNothing(pNewDataValueField) Then pNewDataValueField = String.Empty

                .Items.Insert(0, New ListItem(pNewDataTextField, pNewDataValueField))
            End If
            .AppendDataBoundItems = True
            If pDataSource.Rows.Count > 0 Then
                .DataTextField = pDataTextField
                .DataValueField = pDataValueField
            End If
            .DataSource = IIf(pDataSource.Rows.Count = 0, Nothing, pDataSource)
            .DataBind()
        End With

    End Sub

    Private Sub SetRadioButtonList(ByVal pRadioButtonList As RadioButtonList, ByVal pDataSource As DataTable, ByVal pDataTextField As String, _
        ByVal pDataValueField As String)

        With pRadioButtonList
            .Items.Clear()
            .AppendDataBoundItems = True
            If pDataSource.Rows.Count > 0 Then
                .DataTextField = pDataTextField
                .DataValueField = pDataValueField
            End If
            .DataSource = IIf(pDataSource.Rows.Count = 0, Nothing, pDataSource)
            .DataBind()
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub SetDropDownListNewListItem(ByVal pDropDownList As DropDownList, ByVal pDataIndex As Integer, ByVal pDataTextField As String,
                                           ByVal pDataValueField As String)
        With pDropDownList
            .Items.Insert(pDataIndex, New ListItem(pDataTextField, pDataValueField))
            .AppendDataBoundItems = True
            .DataBind()
        End With
    End Sub

    Private Sub SetFocusBlur(ByVal pTextBox As TextBox, ByVal pFocus As String, ByVal pBlur As String, Optional ByVal pDecimal As Integer? = Nothing)

        Dim mOnBlurValue As String = pTextBox.Attributes.Item("onblur")
        Dim mOnFocusValue As String = pTextBox.Attributes.Item("onfocus")

        mOnBlurValue &= "DoBlur(this, '" & pBlur & "');"
        mOnFocusValue &= "DoFocus(this, '" & pFocus & "');"

        If Not IsNothing(pDecimal) Then
            mOnBlurValue &= String.Concat("extractNumber(this,", pDecimal, ",false); javascript:this.value=Comma(this.value);")
        End If

        pTextBox.Attributes.Add("onfocus", mOnFocusValue)
        pTextBox.Attributes.Add("onblur", mOnBlurValue)

    End Sub

    Private Sub SetFocusEnterKey(ByVal pTextbox As TextBox, ByVal pSetFocusTextBox As Object)
        pTextbox.Attributes.Add("onkeypress", "if (event.keyCode == 13){document.getElementById('" + pSetFocusTextBox.ClientID + "').focus()};")
    End Sub

    Private Sub SetModalSession(ByVal pModal As AjaxControlToolkit.ModalPopupExtender, ByVal pShow As Boolean, ByVal pSetFocus As Object)
        Session(eSession.Modal) = IIf(pShow, pModal.ID, Nothing)
        If pShow Then
            pModal.Show()
        Else
            pModal.Hide()
        End If
        Me.Page.SetFocus(pSetFocus)
    End Sub

    Private Sub ShowMessageBox(ByVal pMessage As String, ByVal pMessageType As String)
        Me.Message = pMessage
        Me.MessageType = pMessageType
        Me.IsMessage = True
    End Sub

#End Region

#Region "Function"

    Private Function ConvertToList(Of T As New)(ByVal pGridView As GridView) As List(Of T)
        Dim lstLocal As List(Of T) = New List(Of T)

        For Each dr As GridViewRow In pGridView.Rows
            Dim objLocal As New T
            Select Case pGridView.ID
                Case gvwPaymentTypeDetails.ID
                    With TryCast(objLocal, cPaymentType)
                        .PaymentTypeID = cDataType.fString.IfNull(dr.Cells(1).Text)
                        .PaymentType = cDataType.fString.IfNull(dr.Cells(2).Text)
                        .Amount = cDataType.fDecimal.IfNull(dr.Cells(3).Text)
                        .CheckNumber = cDataType.fLong.IfNull(dr.Cells(4).Text)
                        .Bank = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(5).Text))
                        .Branch = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(6).Text))

                    End With
                Case gvwOprList.ID
                    With TryCast(objLocal, cBatchOpr)
                        .OprId = cDataType.fString.IfNull(dr.Cells(0).Text)
                        .OprNumber = cDataType.fLong.IfNull(dr.Cells(1).Text)
                        .PocId = cDataType.fLong.IfNull(dr.Cells(2).Text)
                        .Name = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(3).Text))
                        .PolicyName = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(4).Text))
                        .Gross = cDataType.fDecimal.IfNull(dr.Cells(5).Text)
                        .Life = cDataType.fDecimal.IfNull(dr.Cells(6).Text)
                        .NonLife = cDataType.fDecimal.IfNull(dr.Cells(7).Text)
                        .NLPremium = cDataType.fDecimal.IfNull(dr.Cells(8).Text)
                        .DST = cDataType.fDecimal.IfNull(dr.Cells(9).Text)
                        .PremTax = cDataType.fDecimal.IfNull(dr.Cells(10).Text)
                        .LGT = cDataType.fDecimal.IfNull(dr.Cells(11).Text)
                    End With
                Case Else

            End Select
            lstLocal.Add(objLocal)
        Next

        Return lstLocal

    End Function

#End Region

#End Region

    Private Sub btnReceiptPrint_Click(sender As Object, e As EventArgs) Handles btnReceiptPrint.Click
        RaiseEvent ConfirmPrint(Me, EventArgs.Empty)
        'SetModalSession(mpeConfirm, True, btnConfirmNo)    
    End Sub

    Private Sub btnReceiptPreview_Click(sender As Object, e As EventArgs) Handles btnReceiptPreview.Click

        Call ClearSession()
        IsPreview = True
        ReportType = eReport.ReceiptBatch
        RaiseEvent GenerateReport(Me, EventArgs.Empty)
        If IsSuccessful Then
            'Response.Redirect(ePage.RptReceipt, False)
            SetReportSessionScript(ePage.RptReceiptBatch)
            ScriptManager.RegisterStartupScript(sender, GetType(String), "OPEN_WINDOW", Session("script"), True)
            Session("script") = String.Empty
        End If
    End Sub

    Private Sub btnConfirmNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmNo.Click
        ConfirmClickState = True

        Call ClearSession()
        SetModalSession(mpeConfirm, False, btnConfirmYes)
    End Sub

    Private Sub btnConfirmYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmYes.Click
        ConfirmClickState = True
        mpeConfirm.Hide()

        Call ClearSession()
        Select Case ConfirmCaller
            Case "CANCEL"
                DocSaveState = eDocSaveState.Cancel
                RaiseEvent ProcessPaymentBatchPremium(Me, EventArgs.Empty)
                If IsSuccessful Then
                    ReceiptById = UserID
                    RaiseEvent LoadOPR(Me, EventArgs.Empty)
                Else
                    DocSaveState = eDocSaveState.ViewNoEdit
                End If
                Call SetModalSession(mpeConfirm, False, btnReceiptCancel)

            Case "SAVE"
                RaiseEvent ProcessPaymentBatchPremium(Me, EventArgs.Empty)
                If IsSuccessful Then
                    ReceiptById = UserID
                    RaiseEvent LoadOPR(Me, EventArgs.Empty)
                    DocSaveState = eDocSaveState.ViewEdit
                End If
            Case "PRINT"
                IsPreview = False
                ReportType = eReport.ReceiptBatch
                RaiseEvent GenerateReport(Me, EventArgs.Empty)
                If IsSuccessful Then
                    DocSaveState = eDocSaveState.Print
                    RaiseEvent ProcessPaymentBatchPremium(Me, EventArgs.Empty)
                    If IsSuccessful Then
                        ReceiptById = UserID
                        RaiseEvent LoadOPR(Me, EventArgs.Empty)
                    Else
                        DocSaveState = eDocSaveState.ViewEdit
                    End If
                End If
        End Select
        upPaymentBatchPremiumRelated.Update()
    End Sub

    Private Sub btnReceiptCancel_Click(sender As Object, e As EventArgs) Handles btnReceiptCancel.Click
        RaiseEvent ConfirmCancel(Me, EventArgs.Empty)
    End Sub

    Private Sub ibtnAddCash_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAddCash.Click
        RaiseEvent AddCashPayment(Me, EventArgs.Empty)
        If IsPayTypeSuccessful Then
            RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
            Me.Page.SetFocus(ddlOPRPaymentType)
        End If
        upPaymentBatchPremiumRelated.Update()
    End Sub

    Private Sub btnLoadViewBatch_Click(sender As Object, e As EventArgs) Handles btnLoadViewBatch.Click
        dtViewBatch = Nothing
        RaiseEvent LoadViewBatch(Me, EventArgs.Empty)
        Call SetModalSession(mpeViewBatch, True, btnLoadViewBatch)
        upPaymentBatchPremiumRelated.Update()
    End Sub

    Private Sub ddlCheckBankName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCheckBankName.SelectedIndexChanged
        txtOtherBank.Text = String.Empty
        If ddlCheckBankName.SelectedValue = "OTHER" Then
            divOtherBank.Visible = True
        Else
            divOtherBank.Visible = False
        End If
    End Sub

    Private Sub ibtnClearSourceSite_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnClearSourceSite.Click
        SourceSite = String.Empty
        IsSourceSiteLocked = False
    End Sub

    Private Sub ibtnVerifySourceSite_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnVerifySourceSite.Click
        IsSourceSiteLocked = True
    End Sub

    Private Sub ibtnSearchBatch_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnSearchBatch.Click
        ClearSession()
        RaiseEvent LoadBatch(Me, EventArgs.Empty)
        If IsSuccessful Then
            ManageBatch(eReference.MgePol.Search, False)
        Else
            ManageBatch(eReference.MgePol.Search, True)
        End If

        upPaymentBatchPremiumRelated.Update()
    End Sub

    Private Sub ibtnClearBatch_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnClearBatch.Click
        ManageBatch(eReference.MgePol.Search, True)
        RaiseEvent ClearScreenBatch(Me, EventArgs.Empty)
        PaymentTypeTag = False

        upPaymentBatchPremiumRelated.Update()
    End Sub
End Class