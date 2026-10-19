#Region "Description"
' PAGE NAME     : Payment : Non-Premium Related 
' CREATED BY    : MPRO
' CREATED DATE  : 04/14/2015
' UPDATE LOGS [modified by | modified date | updates]
'             [IBP | 021617 | update code]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eCSS = Cocolife.Utility.OCS.Enums.eCSS
Imports ePage = Cocolife.Utility.OCS.Enums.ePage
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eSession = Cocolife.Utility.OCS.Enums.eSession
'---
Imports preMessages = Cocolife.Utility.OCS.Messages
Imports prePayment = Cocolife.Presenter.OCS.Payment
Imports preSearch = Cocolife.Presenter.OCS.Search
Imports preReport = Cocolife.Presenter.OCS.Report
Imports eDocSaveState = Cocolife.Utility.OCS.Enums.eReference.DocSaveState
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
Imports System.Linq
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports cCrystalConn = Cocolife.Utility.OCS.Classes.cCrystalConn


#End Region

Partial Public Class PaymentNonPremiumRelated
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preMessages.IConfirmationMessage
    Implements prePayment.IPaymentNonPremiumRelated
    Implements prePayment.IColumbariumDetails
    Implements preSearch.IPayor
    Implements preReport.IReport
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pConfirmationMessage As preMessages.PConfirmationMessage
    Private pPaymentNonPremiumRelated As prePayment.PPaymentNonPremiumRelated
    Private pAgent As preSearch.PAgent
    Private pPayor As preSearch.PPayor
    Private pReport As preReport.PReport
    '----------------------------------------------------------------------------------------------
    Private mIsAgentExist As Boolean
    Private mIsInsuredExist As Boolean
    Private mIsPayorExist As Boolean
    Private mIsPolicyExist As Boolean
    Private mIsSuccessful As Boolean
    Private mIsPayTypeSuccessful As Boolean
    Private mIsReceiptSuccessful As Boolean
    Private mParticularsValid As Boolean

    '----------------------------------------------------------------------------------------------
    Private mSearchAgentIDTag As Integer
    Private arrAgentIDTag(2) As Long
    Public arrTxtAgentID() As TextBox
    Public arrTxtAgentName() As TextBox
    Public arrHdnAgentFnam() As HiddenField
    Public arrHdnAgentLnam() As HiddenField
    Public arrHdnAgentMnam() As HiddenField
    Public arrHdnAgencyFnam() As HiddenField
    Public arrHdnAgencyLnam() As HiddenField
    Public arrHdnAgencyMnam() As HiddenField
    Public arrTxtUsdId() As TextBox
    Public arrTxtUsdName() As TextBox

    Private mdtBusinessType As DataTable
    Private mdtReceiptTransaction As DataTable

    '-----------------------------------------------------

    Private mVault As Long
    Private mLotListPrice As Decimal

    Private mPayorAddMidName As String
    Private mPayorAddType As String
    Private mPayorAddLastName As String
    Private mPayorAddFirstName As String
    Private mPayorAddSuffix As String
    Private mPayorAddTitle As String
    Private mPayorAddPlaceOfBirth As String
    Private mPayorAddDateOfBirth As String
    Private mPayorAddTin As String
    Private mPayorAddAddress As String
    Private mPayorTin As String
    Private mPayorAddress As String

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
                'Call SetModalSession(mpeMessage, True, btnMessageOk)
                mpeMessage.Show()
                'FOCUS Me.Page.SetFocus(btnMessageOk)
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
            End If
        End Set
    End Property

#End Region

#Region "Event"

#End Region

#End Region

#Region "IPaymentNonPremiumRelated"

#Region "Property"

#Region "Payment Details"

    Public Property DocPrinted As Boolean Implements prePayment.IPaymentNonPremiumRelated.DocPrinted
        Get
            Return cDataType.fBoolean.IfNull(hdnDocPrinted.value)
        End Get
        Set(value As Boolean)
            hdnDocPrinted.value = value
        End Set
    End Property

    Public Property DocSaveState As Integer Implements prePayment.IPaymentNonPremiumRelated.DocSaveState
        Get
            Return cDataType.fInteger.IfNull(hdnDocSaveState.Value)
        End Get
        Set(value As Integer)
            hdnDocSaveState.Value = value

            ManageMain(value)

            Select Case value
                Case eDocSaveState.Initial
                    ibtnViewORs.Visible = True
                    'ibtnClearOR.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Save"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False

                    RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
                Case eDocSaveState.ViewEdit
                    ibtnViewORs.Visible = True
                    'ibtnClearOR.Visible = True
                    btnReceiptAddNew.Enabled = False
                    btnReceiptSave.Enabled = True
                    btnReceiptSave.Text = "Modify"
                    btnReceiptPreview.Enabled = True
                    btnReceiptPrint.Enabled = True
                    btnReceiptCancel.Enabled = False
                Case eDocSaveState.ViewNoEdit
                    ibtnViewORs.Visible = True
                    'ibtnClearOR.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Modify"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = True
                    btnReceiptCancel.Enabled = True
                Case eDocSaveState.Edit
                    ibtnViewORs.Visible = False
                    'ibtnClearOR.Visible = False
                    btnReceiptAddNew.Enabled = False
                    btnReceiptSave.Enabled = True
                    btnReceiptSave.Text = "Update"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False

                    ManagePolicy(eReference.MgePol.Initial, True)
                    ManagePolicy(eReference.MgePol.Search, False)

                Case eDocSaveState.AddNew
                    ibtnViewORs.Visible = True
                    'ibtnClearOR.Visible = True
                    btnReceiptAddNew.Enabled = False
                    btnReceiptSave.Enabled = True
                    btnReceiptSave.Text = "Save"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False
                Case eDocSaveState.Cancel
                    ibtnViewORs.Visible = True
                    'ibtnClearOR.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Save"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = False
                    btnReceiptCancel.Enabled = False
                Case eDocSaveState.Print
                    ibtnViewORs.Visible = True
                    'ibtnClearOR.Visible = True
                    btnReceiptAddNew.Enabled = True
                    btnReceiptSave.Enabled = False
                    btnReceiptSave.Text = "Modify"
                    btnReceiptPreview.Enabled = False
                    btnReceiptPrint.Enabled = True
                    If ORDate.Date = Now.Date Then
                        btnReceiptCancel.Enabled = DocPrinted
                    Else
                        btnReceiptCancel.Enabled = False
                    End If

                    'Case Else
                    '    ibtnViewORs.Visible = True
                    '    'ibtnClearOR.Visible = True
                    '    'btnReceiptAddNew.Enabled = False
                    '    btnReceiptSave.Enabled = False
                    '    btnReceiptPreview.Enabled = False
                    '    btnReceiptPrint.Enabled = False
                    '    btnReceiptCancel.Enabled = False

            End Select
        End Set
    End Property

    Public Property IsPreview As Boolean Implements preReport.IReport.IsPreview
        Get
            'Return cDataType.fInteger.IfNull(hdnIsPreviewTag.Value)
            Return cDataType.fBoolean.IfNull(hdnIsPreviewTag.Value)
        End Get
        Set(value As Boolean)
            hdnIsPreviewTag.Value = value
        End Set
    End Property

    Public ReadOnly Property DocType As String Implements prePayment.IPaymentNonPremiumRelated.DocType
        Get
            Return eReference.DocTypeOR
        End Get
    End Property

    Public ReadOnly Property SiteCode As Long Implements prePayment.IPaymentNonPremiumRelated.SiteCode, preReport.IReport.SiteCode
        Get
            Return Master.SiteID
        End Get
    End Property

    Public ReadOnly Property SiteIpAddr As String Implements preReport.IReport.SiteIpAddr
        Get
            Return Master.SiteIpAddr
        End Get
    End Property

    Public ReadOnly Property UserID As Long Implements prePayment.IPaymentNonPremiumRelated.UserID, preReport.IReport.UserId
        Get
            Return Master.UserPrsPID
        End Get
    End Property

    Public Property ReceiptByCode As String Implements prePayment.IPaymentNonPremiumRelated.ReceiptByCode
        Get
            Return cDataType.fString.IfNull(hdnReceiptByCode.Value)
        End Get
        Set(value As String)
            hdnReceiptByCode.Value = value
        End Set
    End Property

    Public Property ReceiptById As Long Implements prePayment.IPaymentNonPremiumRelated.ReceiptById
        Get
            Return cDataType.fString.IfNull(hdnReceiptById.Value)
        End Get
        Set(value As Long)
            hdnReceiptById.Value = value
        End Set
    End Property

    Public Property IsSuccessful As Boolean Implements prePayment.IPaymentNonPremiumRelated.IsSuccessful, preReport.IReport.IsSuccessful
        Get
            Return mIsSuccessful
        End Get
        Set(value As Boolean)
            mIsSuccessful = value
        End Set
    End Property

    Public Property IsSourceSiteLocked() As Boolean Implements prePayment.IPaymentNonPremiumRelated.IsSourceSiteLocked
        Get
            Return cDataType.fBoolean.IfNull(hdnIsSourceSiteLocked.Value)
        End Get
        Set(ByVal value As Boolean)
            hdnIsSourceSiteLocked.Value = value
            ManageORPaymentDetails("SOURCESITE", value)
        End Set
    End Property

    Public Property SourceSite As String Implements prePayment.IPaymentNonPremiumRelated.SourceSite
        Get
            Return cDataType.fString.IfNull(ddlSourceSite.SelectedValue)
        End Get
        Set(value As String)
            ddlSourceSite.SelectedValue = value
        End Set
    End Property

    Public Property ORNumber As Long Implements prePayment.IPaymentNonPremiumRelated.ORNumber
        Get
            Return cDataType.fLong.IfNull(txtORNumber.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtORNumber.Text = "AUTO"
            Else
                txtORNumber.Text = value
            End If
        End Set
    End Property

    Public Property ORDate As Date Implements prePayment.IPaymentNonPremiumRelated.ORDate
        Get
            Return cDataType.fDate.IfNull(txtORDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtORDate.Text = Nothing
            Else
                txtORDate.Text = value
            End If
        End Set
    End Property

    Public Property ViewOrFrom As Date Implements prePayment.IPaymentNonPremiumRelated.ViewOrFrom
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

    Public Property ViewOrTo As Date Implements prePayment.IPaymentNonPremiumRelated.ViewOrTo
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

    Public Property ViewOrDocNumber As Long Implements prePayment.IPaymentNonPremiumRelated.ViewOrDocNumber
        Get
            Return cDataType.fLong.IfNull(txtViewORNumber.Text)
        End Get
        Set(value As Long)
            If value = cDataType.fLong.Empty Then
                txtViewORNumber.Text = Nothing
            Else
                txtViewORNumber.Text = value
            End If
        End Set
    End Property

    Public Property ViewOrPayorName As String Implements prePayment.IPaymentNonPremiumRelated.ViewOrPayorName
        Get
            Return cDataType.fString.IfNull(txtViewPayorName.Text)
        End Get
        Set(value As String)
            txtViewPayorName.Text = value
        End Set
    End Property

    Public Property TransactionType As String Implements prePayment.IPaymentNonPremiumRelated.TransactionType
        Get
            Return cDataType.fString.IfNull(ddlTransactionType.SelectedValue)
        End Get
        Set(value As String)
            ddlTransactionType.SelectedValue = value
            Call ddlTransactionType_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ORPaymentType As String Implements prePayment.IPaymentNonPremiumRelated.ORPaymentType
        Get
            Return cDataType.fString.IfNull(ddlORPaymentType.SelectedValue)
        End Get
        Set(value As String)
            ddlORPaymentType.SelectedValue = value
            Call ddlORPaymentType_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property IsGrossAmountLocked As Boolean Implements prePayment.IPaymentNonPremiumRelated.IsGrossaAmountLocked
        Get
            Return cDataType.fBoolean.IfNull(hdnIsGrossAmountLocked.Value)
        End Get
        Set(value As Boolean)
            hdnIsGrossAmountLocked.Value = value
            ManageORPaymentDetails("GROSSAMOUNT", IsGrossAmountLocked)
        End Set
    End Property

    Public Property ORGrossAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.ORGrossAmount
        Get
            Return cDataType.fDecimal.IfNull(txtORGrossAmount.Text)
        End Get
        Set(value As Decimal)
            txtORGrossAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)

        End Set
    End Property

    Public Property ORCurrency As String Implements prePayment.IPaymentNonPremiumRelated.ORCurrency
        Get
            Return cDataType.fString.IfNull(ddlORCurrency.SelectedValue)
        End Get
        Set(value As String)
            ddlORCurrency.SelectedValue = value
        End Set
    End Property

    Public Property WithAPR As Boolean Implements prePayment.IPaymentNonPremiumRelated.WithAPR
        Get
            Return cDataType.fBoolean.IfNull(chkWithAPR.Checked)
        End Get
        Set(value As Boolean)
            chkWithAPR.Checked = value
            accAPRDetails.Visible = value
            If value = False Then
                RaiseEvent ClearScreenAPRDetails(Me, EventArgs.Empty)
            Else
                APRAmount = ORGrossAmount
            End If
        End Set
    End Property

    Public Property ColPayrEmployee As Boolean Implements prePayment.IPaymentNonPremiumRelated.ColPayrEmployee
        Get
            Return cDataType.fBoolean.IfNull(radEmployee.Checked)
        End Get
        Set(value As Boolean)
            radEmployee.Checked = value
        End Set
    End Property

    Public Property ColPayrRegular As Boolean Implements prePayment.IPaymentNonPremiumRelated.ColPayrRegular
        Get
            Return cDataType.fBoolean.IfNull(radRegular.Checked)
        End Get
        Set(value As Boolean)
            radRegular.Checked = value
        End Set
    End Property

    Public Property ColumbaryInitialFee As Boolean Implements prePayment.IPaymentNonPremiumRelated.ColumbaryInitialFee
        Get
            Return cDataType.fBoolean.IfNull(chkInitialFee.Checked)
        End Get
        Set(value As Boolean)
            chkInitialFee.Checked = value

            'chkInitialFee_CheckedChanged()
            'Call chkInitialFee_CheckedChanged(Me, EventArgs.Empty)

            '--
            'ReservationAmt = String.Empty
            'DiscountRate = String.Empty
            'VaultVAT = String.Empty
        End Set
    End Property


    Public Property ORRemarks As String Implements prePayment.IPaymentNonPremiumRelated.ORRemarks
        Get
            Return cDataType.fString.IfNull(txtORRemarks.Text)
        End Get
        Set(value As String)
            txtORRemarks.Text = value
        End Set
    End Property

    Public ReadOnly Property ORFlags As String Implements prePayment.IPaymentNonPremiumRelated.ORFlags
        Get
            Dim strReturn As String = String.Empty
            strReturn += IIf(WithAPR, "1", "0")
            strReturn += IIf(CheckPaymentTag, "1", "0")
            Return strReturn
        End Get
    End Property

    Public Property GLCode As String Implements prePayment.IPaymentNonPremiumRelated.GLCode
        Get
            Return cDataType.fString.IfNull(txtGLCode.Text)
        End Get
        Set(value As String)
            txtGLCode.Text = value
            ddlDepositoryAccount.SelectedValue = value
        End Set
    End Property

    Public ReadOnly Property DepositoryAccount As String Implements prePayment.IPaymentNonPremiumRelated.DepositoryAccount
        Get
            Return cDataType.fString.IfNull(ddlDepositoryAccount.SelectedItem.Text)

        End Get
        'Set(value As String)
        '    ddlDepositoryAccount.SelectedItem.Text = value
        '    Call ddlDepositoryAccount_SelectedIndexChanged(Me, EventArgs.Empty)
        'End Set
    End Property


#End Region

#Region "Payor"

    Public Property PayorID() As Long Implements prePayment.IPaymentNonPremiumRelated.PayorID
        Get
            Return cDataType.fLong.IfNull(txtPayorID.Text)
        End Get
        Set(ByVal value As Long)
            If value = 0 Then
                txtPayorID.Text = Nothing
            Else
                txtPayorID.Text = value
            End If
        End Set
    End Property

    Public Property PayorIDTag() As Boolean Implements prePayment.IPaymentNonPremiumRelated.PayorIDTag
        Get
            Return cDataType.fBoolean.IfNull(hdnPayorIDTag.Value)
        End Get
        Set(ByVal value As Boolean)
            hdnPayorIDTag.Value = value
        End Set
    End Property

    Public Property PayorType() As String Implements prePayment.IPaymentNonPremiumRelated.PayorType
        Get
            Return cDataType.fString.IfNull(hdnPayorSex.Value)
        End Get
        Set(value As String)
            hdnPayorSex.Value = value
        End Set
    End Property

    Public Property PayorName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorName
        Get
            If (txtPayorName.Visible = True) Then
                If String.Concat(PayorLastName, PayorSuffix, PayorFirstName, PayorMiddleName).Trim() = String.Empty Then
                    If (txtPayorName.Text = String.Empty) Then
                        Return String.Empty
                    Else
                        Return txtPayorName.Text.ToUpper()
                    End If
                Else
                    If PayorSuffix = String.Empty Then
                        Return String.Concat(PayorLastName, ";", PayorFirstName, " ", PayorMiddleName)
                    Else
                        Return String.Concat(PayorLastName, ", ", PayorSuffix, ";", PayorFirstName, " ", PayorMiddleName)
                    End If
                End If
            ElseIf (txtNewPayorName.Visible = True) Then
                Return txtNewPayorName.Text.ToUpper()
            End If
            Return String.Empty
        End Get
        Set(ByVal value As String)
            txtPayorName.Text = value
            txtNewPayorName.Text = value
        End Set
    End Property

    Public Property PayorLastName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorLastName
        Get
            Return cDataType.fString.IfNull(hdnPayorLastName.Value)
        End Get
        Set(ByVal value As String)
            hdnPayorLastName.Value = value
        End Set
    End Property

    Public Property PayorFirstName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorFirstName
        Get
            Return cDataType.fString.IfNull(hdnPayorFirstName.Value)
        End Get
        Set(ByVal value As String)
            hdnPayorFirstName.Value = value
        End Set
    End Property

    Public Property PayorMiddleName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorMiddleName
        Get
            Return cDataType.fString.IfNull(hdnPayorMiddleName.Value)
        End Get
        Set(ByVal value As String)
            hdnPayorMiddleName.Value = value
        End Set
    End Property

    Public Property PayorSuffix() As String Implements prePayment.IPaymentNonPremiumRelated.PayorSuffix
        Get
            Return cDataType.fString.IfNull(hdnPayorSuffix.Value)
        End Get
        Set(ByVal value As String)
            hdnPayorSuffix.Value = value
        End Set
    End Property

    Public Property PayorTitle() As String Implements prePayment.IPaymentNonPremiumRelated.PayorTitle
        Get
            Return cDataType.fString.IfNull(hdnPayorTitle.Value)
        End Get
        Set(ByVal value As String)
            hdnPayorTitle.Value = value
        End Set

    End Property

    Public Property PayorPlaceOfBirth() As String Implements prePayment.IPaymentNonPremiumRelated.PayorPlaceOfBirth
        Get
            Return cDataType.fString.IfNull(hdnPayorPlaceOfBirth.Value)
        End Get
        Set(ByVal value As String)
            hdnPayorPlaceOfBirth.Value = value
        End Set
    End Property

    Public Property PayorDateOfBirth() As Date Implements prePayment.IPaymentNonPremiumRelated.PayorDateOfBirth
        Get
            Return cDataType.fDate.IfNull(hdnPayorDateOfBirth.Value)
        End Get
        Set(ByVal value As Date)
            If value = cDataType.fDate.Empty Then
                hdnPayorDateOfBirth.Value = Nothing
            Else
                hdnPayorDateOfBirth.Value = value
            End If
        End Set
    End Property


    Public Property PayorAddType() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddType
        Get
            Return cDataType.fString.IfNull(mPayorAddType)
        End Get
        Set(value As String)
            mPayorAddType = value
        End Set
    End Property

    Public Property PayorAddName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddName
        Get
            If (txtNewPayorName.Visible = True) Then
                Return cDataType.fString.IfNull(txtNewPayorName.Text)
            ElseIf (txtSearchPayorName.Visible = True) And (PayorID <> 0) Then
                Return cDataType.fString.IfNull(txtPayorName.Text)
            Else
                Return cDataType.fString.IfNull(txtPayorName.Text)
            End If
        End Get
        Set(ByVal value As String)
            If (txtNewPayorName.Visible = True) Then
                txtNewPayorName.Text = value
            ElseIf (txtSearchPayorName.Visible = True) And (PayorID <> 0) Then
                txtPayorName.Text = value
            Else
                txtPayorName.Text = value
            End If
        End Set
    End Property

    Public Property PayorAddLastName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddLastName
        Get
            Return cDataType.fString.IfNull(mPayorAddLastName)
        End Get
        Set(ByVal value As String)
            mPayorAddLastName = value
        End Set
    End Property

    Public Property PayorAddFirstName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddFirstName
        Get
            Return cDataType.fString.IfNull(mPayorAddFirstName)
        End Get
        Set(ByVal value As String)
            mPayorAddFirstName = value
        End Set
    End Property

    Public Property PayorAddMiddleName() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddMiddleName
        Get
            Return cDataType.fString.IfNull(mPayorAddMidName)
        End Get
        Set(ByVal value As String)
            mPayorAddMidName = value
        End Set
    End Property

    Public Property PayorAddSuffix() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddSuffix
        Get
            Return cDataType.fString.IfNull(mPayorAddSuffix)
        End Get
        Set(ByVal value As String)
            mPayorAddSuffix = value
        End Set
    End Property

    Public Property PayorAddTitle() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddTitle
        Get
            Return cDataType.fString.IfNull(mPayorAddTitle)
        End Get
        Set(ByVal value As String)
            mPayorAddTitle = value
        End Set
    End Property

    Public Property PayorAddPlaceOfBirth() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddPlaceOfBirth
        Get
            Return cDataType.fString.IfNull(mPayorAddPlaceOfBirth)
        End Get
        Set(ByVal value As String)
            mPayorAddPlaceOfBirth = value
        End Set
    End Property

    Public Property PayorAddDateOfBirth() As Date Implements prePayment.IPaymentNonPremiumRelated.PayorAddDateOfBirth
        Get
            Return cDataType.fDate.IfNull(mPayorAddDateOfBirth)
        End Get
        Set(ByVal value As Date)
            mPayorAddDateOfBirth = value
        End Set
    End Property


    Public Property PayorAddTin() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddTin
        Get
            Return cDataType.fString.IfNull(mPayorAddTin)
        End Get
        Set(ByVal value As String)
            mPayorAddTin = value
        End Set
    End Property

    Public Property PayorAddAddress() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddAddress
        Get
            Return cDataType.fString.IfNull(mPayorAddAddress)
        End Get
        Set(ByVal value As String)
            mPayorAddAddress = value
        End Set
    End Property
    Public Property PayorTin() As String Implements prePayment.IPaymentNonPremiumRelated.PayorTin
        Get
            Return cDataType.fString.IfNull(mPayorTin)
        End Get
        Set(ByVal value As String)
            mPayorTin = value
        End Set
    End Property
   
    Public Property PayorAddress() As String Implements prePayment.IPaymentNonPremiumRelated.PayorAddress
        Get
            Return cDataType.fString.IfNull(mPayorAddress)
        End Get
        Set(ByVal value As String)
            mPayorAddress = value
        End Set
    End Property
    'end

#End Region

#Region "OR Details"

    Public Property ReceiptCommissionAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.ReceiptCommissionAmount

    Public Property ReceiptIndex As Integer Implements prePayment.IPaymentNonPremiumRelated.ReceiptIndex
        Get
            Return cDataType.fInteger.IfNull(ddlTransactionType.SelectedIndex)
        End Get
        Set(value As Integer)
            If ddlORTransaction.Items.Count > 0 Then
                ddlORTransaction.SelectedIndex = value
            End If
        End Set
    End Property

    Public Property IsReceiptSuccessful As Boolean Implements prePayment.IPaymentNonPremiumRelated.isReceiptSuccessful
        Get
            Return cDataType.fBoolean.IfNull(mIsReceiptSuccessful)
        End Get
        Set(value As Boolean)
            mIsReceiptSuccessful = value
        End Set
    End Property

    Public Property ReceiptDetailID As String Implements prePayment.IPaymentNonPremiumRelated.ReceiptDetailID
        Get
            Return cDataType.fString.IfNull(hdnORDetailID.Value)
        End Get
        Set(value As String)
            hdnORDetailID.Value = value
            Call ddlORPaymentType_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ReceiptTransactionCode As String Implements prePayment.IPaymentNonPremiumRelated.ReceiptTransactionCode
        Get
            Return cDataType.fString.IfNull(hdnORTransactionCode.Value)
        End Get
        Set(value As String)
            hdnORTransactionCode.Value = value
        End Set
    End Property

    Public Property ReceiptTransactionType As String Implements prePayment.IPaymentNonPremiumRelated.ReceiptTransactionType
        Get
            Return cDataType.fString.IfNull(hdnORTransactionType.Value)
        End Get
        Set(value As String)
            hdnORTransactionType.Value = value
        End Set
    End Property

    Public Property ReceiptTransactionDesc As String Implements prePayment.IPaymentNonPremiumRelated.ReceiptTransactionDesc
        Get
            Return cDataType.fString.IfNull(hdnORTransactionDesc.Value)
        End Get
        Set(value As String)
            hdnORTransactionDesc.Value = value
        End Set
    End Property

    Public Property ReceiptTransactionVat As String Implements prePayment.IPaymentNonPremiumRelated.ReceiptTransactionVat
        Get
            Return cDataType.fString.IfNull(hdnORTransactionVat.Value)
        End Get
        Set(value As String)
            hdnORTransactionVat.Value = value
        End Set
    End Property

    Public Property ReceiptAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.ReceiptAmount
        Get
            Return cDataType.fDecimal.IfNull(txtORAmount.Text)
        End Get
        Set(value As Decimal)
            txtORAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property ReceiptTotalAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.ReceiptTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(txtORTotalAmount.Text)
        End Get
        Set(value As Decimal)
            txtORTotalAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

#End Region

#Region "Particulars"
    Public Property IsParticularsValid As Boolean Implements prePayment.IPaymentNonPremiumRelated.IsParticularsValid
        Get
            Return cDataType.fBoolean.IfNull(mParticularsValid)
        End Get
        Set(value As Boolean)
            mParticularsValid = value
        End Set
    End Property

    Public Property ParticularsID As String Implements prePayment.IPaymentNonPremiumRelated.ParticularsID
        Get
            Return cDataType.fString.IfNull(hdnParticularsID.Value)
        End Get
        Set(value As String)
            hdnParticularsID.Value = value
        End Set
    End Property

    Public Property ParticularsRemarks As String Implements prePayment.IPaymentNonPremiumRelated.ParticularsRemarks
        Get
            Return cDataType.fString.IfNull(txtParticularsRemark.Text)
        End Get
        Set(value As String)
            txtParticularsRemark.Text = value
        End Set
    End Property

    Public Property ParticularsAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.ParticularsAmount
        Get
            Return cDataType.fDecimal.IfNull(txtParticularsAmount.Text)
        End Get
        Set(value As Decimal)
            txtParticularsAmount.Text = value
        End Set
    End Property

    Public Property ParticularsTotalAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.ParticularsTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(hdnParticularsTotalAmount.Value)
        End Get
        Set(value As Decimal)
            hdnParticularsTotalAmount.Value = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
            txtParticularsTotalAmount.Text = FormatNumber(ParticularsTotalAmount, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

#End Region

#Region "APR Details"

    Public Property APRNumber As Long Implements prePayment.IPaymentNonPremiumRelated.APRNumber
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

    Public Property APRDate As Date Implements prePayment.IPaymentNonPremiumRelated.APRDate
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

    Public Property APRAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.APRAmount
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

    Public Property ORCashAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.ORCashAmount
        Get
            Return cDataType.fDecimal.IfNull(txtORCashAmount.Text)
        End Get
        Set(value As Decimal)
            txtORCashAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

#End Region

#Region "Check Details"

    Public Property CheckNumber As Long Implements prePayment.IPaymentNonPremiumRelated.CheckNumber
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

    Public Property CheckAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.CheckAmount
        Get
            Return cDataType.fDecimal.IfNull(txtCheckAmount.Text)
        End Get
        Set(value As Decimal)
            txtCheckAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property CheckBankName As String Implements prePayment.IPaymentNonPremiumRelated.CheckBankName
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

    'Public Property OtherBankName As String Implements prePayment.IPaymentNonPremiumRelated.OtherBankName
    '    Get
    '        Return cDataType.fString.IfNull(txtOtherBank.Text)
    '    End Get
    '    Set(value As String)
    '        txtOtherBank.Text = value
    '    End Set
    'End Property


    Public Property CheckBankBranch As String Implements prePayment.IPaymentNonPremiumRelated.CheckBankBranch
        Get
            Return cDataType.fString.IfNull(txtCheckBankBranch.Text)
        End Get
        Set(value As String)
            txtCheckBankBranch.Text = value
        End Set
    End Property

    Public Property CheckLineNumber As Integer Implements prePayment.IPaymentNonPremiumRelated.CheckLineNumber
    Public Property CheckOTCFlag As Integer Implements prePayment.IPaymentNonPremiumRelated.CheckOTCFlag

#End Region

#Region "Payment Totals"

    Public Property IsPayTypeSuccessful As Boolean Implements prePayment.IPaymentNonPremiumRelated.IsPayTypeSuccessful
        Get
            Return cDataType.fBoolean.IfNull(mIsPayTypeSuccessful)
        End Get
        Set(value As Boolean)
            mIsPayTypeSuccessful = value
        End Set
    End Property

    Public Property CashTotalAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.CashTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(hdnCashTotalAmount.Value)
        End Get
        Set(value As Decimal)
            hdnCashTotalAmount.Value = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
            txtPaymentTypeTotalAmount.Text = FormatNumber(PaymentTotalAmount, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property CheckTotalAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.CheckTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(hdnCheckTotalAmount.Value)
        End Get
        Set(value As Decimal)
            hdnCheckTotalAmount.Value = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
            txtPaymentTypeTotalAmount.Text = FormatNumber(PaymentTotalAmount, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public ReadOnly Property PaymentTotalAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.PaymentTotalAmount
        Get
            Return cDataType.fDecimal.IfNull(CashTotalAmount + CheckTotalAmount)
        End Get
    End Property

    Public Property PaymentTypeID As String Implements prePayment.IPaymentNonPremiumRelated.PaymentTypeID
        Get
            Return cDataType.fString.IfNull(hdnPaymentTypeID.Value)
        End Get
        Set(value As String)
            hdnPaymentTypeID.Value = value
            Call ddlORPaymentType_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property

#End Region

#End Region

#Region "VAT Computation"

    Public Property VATableCollection As Decimal Implements prePayment.IPaymentNonPremiumRelated.VATableCollection
        Get
            Return cDataType.fDecimal.IfNull(txtVATableCollection.Text)
        End Get
        Set(value As Decimal)
            txtVATableCollection.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property NonVATCollection As Decimal Implements prePayment.IPaymentNonPremiumRelated.NonVATCollection
        Get
            Return cDataType.fDecimal.IfNull(txtNonVATCollection.Text)
        End Get
        Set(value As Decimal)
            txtNonVATCollection.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property VATExemptCollection As Decimal Implements prePayment.IPaymentNonPremiumRelated.VATExemptCollection
        Get
            Return cDataType.fDecimal.IfNull(txtVATExemptCollection.Text)
        End Get
        Set(value As Decimal)
            txtVATExemptCollection.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property VATAmount As Decimal Implements prePayment.IPaymentNonPremiumRelated.VATAmount
        Get
            Return cDataType.fDecimal.IfNull(txtVATAmount.Text)
        End Get
        Set(value As Decimal)
            txtVATAmount.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property VATTotalCollection As Decimal Implements prePayment.IPaymentNonPremiumRelated.VATTotalCollection
        Get
            Return cDataType.fDecimal.IfNull(txtVATTotalCollection.Text)
        End Get
        Set(value As Decimal)
            txtVATTotalCollection.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property VATWithholdingTax As Decimal Implements prePayment.IPaymentNonPremiumRelated.VATWithholdingTax
        Get
            Return cDataType.fDecimal.IfNull(txtVATWithholdingTax.Text)
        End Get
        Set(value As Decimal)
            txtVATWithholdingTax.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

    Public Property VATAmountNetWTax As Decimal Implements prePayment.IPaymentNonPremiumRelated.VATAmountNetWTax
        Get
            Return cDataType.fDecimal.IfNull(txtVATAmountNetWTax.Text)
        End Get
        Set(value As Decimal)
            txtVATAmountNetWTax.Text = FormatNumber(value, 2, TriState.True, TriState.True, TriState.True)
        End Set
    End Property

#End Region

#Region "Tag"

    Public Property PrevPayType As String Implements prePayment.IPaymentNonPremiumRelated.PrevPayType
        Get
            Return cDataType.fString.IfNull(hdnPrevPayType.Value)
        End Get
        Set(value As String)
            hdnPrevPayType.Value = value
        End Set
    End Property

    Public Property PaymentTypeTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.PaymentTypeTag
        Get
            Return cDataType.fBoolean.IfNull(hdnPaymentTypeTag.Value)
        End Get
        Set(value As Boolean)
            hdnPaymentTypeTag.Value = value
            accPaymentTypeDetails.Visible = value

            RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
            CashTotalAmount = cDataType.fLong.Empty
            CheckTotalAmount = cDataType.fLong.Empty
            PrevPayType = cDataType.fString.Empty
            ORPaymentType = cDataType.fString.Empty
            lstPaymentTypeDetails = New List(Of cPaymentType)

            If value Then
                ManagePaymentType(String.Empty, True)
            End If
        End Set
    End Property

    Public Property OtherDetailsTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.OtherDetailsTag
        Get
            Return cDataType.fBoolean.IfNull(hdnOtherDetailsTag.Value)
        End Get
        Set(value As Boolean)
            hdnOtherDetailsTag.Value = value
            accOtherDetails.Visible = value

            RaiseEvent ClearScreenOtherDetails(Me, EventArgs.Empty)
            RaiseEvent LoadBankDetails(Me, EventArgs.Empty)

        End Set
    End Property

    Public Property ColumbariumInfoTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.ColumbariumTag
        Get
            Return cDataType.fBoolean.IfNull(hdnColumbariumTag.Value)
        End Get
        Set(value As Boolean)
            hdnColumbariumTag.Value = value
            accColumbarium.Visible = value

            RaiseEvent ClearScreenColumbarium(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ParticularsTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.ParticularsTag
        Get
            Return cDataType.fBoolean.IfNull(hdnParticularsTag.Value)
        End Get
        Set(value As Boolean)
            hdnParticularsTag.Value = value
            accParticulars.Visible = value

            RaiseEvent ClearScreenParticulars(Me, EventArgs.Empty)
            ParticularsTotalAmount = cDataType.fLong.Empty
            lstParticulars = New List(Of cParticulars)
        End Set
    End Property

    Public Property ORDetailTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.ORDetailTag
        Get
            Return cDataType.fBoolean.IfNull(hdnORDtlTag.Value)
        End Get
        Set(value As Boolean)
            hdnORDtlTag.Value = value
            accORDetails.Visible = value

            RaiseEvent ClearScreenReceiptDetails(Me, EventArgs.Empty)
            ReceiptTotalAmount = cDataType.fLong.Empty
            lstORDetails = New List(Of cORDetail)

            If value Then
                ManageReceiptDetails("ADD", True)
                RaiseEvent LoadReceiptTransaction(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property ORVatTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.ORVatTag
        Get
            Return cDataType.fBoolean.IfNull(hdnORVatTag.Value)
        End Get
        Set(value As Boolean)
            hdnORVatTag.Value = value
            accVATComputation.Visible = value

            RaiseEvent ClearScreenVATComputation(Me, EventArgs.Empty)

            If value Then
                ManageVatDetails("ADD", True)
            End If
        End Set
    End Property

    Public Property CashPaymentTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.CashPaymentTag
        Get
            Return cDataType.fBoolean.IfNull(hdnCashPaymentTag.Value)
        End Get
        Set(value As Boolean)
            hdnCashPaymentTag.Value = value
            pnlCashDetails.Visible = value

            RaiseEvent ClearScreenCashDetails(Me, EventArgs.Empty)

        End Set
    End Property

    Public Property CheckPaymentTag As Boolean Implements prePayment.IPaymentNonPremiumRelated.CheckPaymentTag
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

    Public WriteOnly Property dtViewOR As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtViewOR
        Set(value As DataTable)
            If Not IsNothing(value) Then
                Dim dtFiltered = From c In value.AsEnumerable
                                 Where c.Item("doctyp") = eReference.DocTypeOR
                                 Select c
                If dtFiltered.Any() Then
                    value = dtFiltered.CopyToDataTable
                Else
                    value = Nothing
                End If
            End If

            gvwViewOr.DataSource = value
            gvwViewOr.DataBind()
        End Set

    End Property

    Public WriteOnly Property dtBankDetails As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtBankDetails
        Set(value As DataTable)
            'DepositoryAccounts
            Call SetDropDownList(ddlDepositoryAccount, value, "ACCOUNT_TITLE", "GL_CODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtBankList As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtBankList
        Set(value As DataTable)
            'CheckBankName

            'Call SetDropDownList(ddlCheckBankName, value, "ACCOUNT_TITLE", "ACCOUNT_ID", "-- SELECT ITEM --", String.Empty)
            Call SetDropDownList(ddlCheckBankName, value, "DESCRP", "CODE", "-- SELECT ITEM --", String.Empty)

        End Set
    End Property

    Public WriteOnly Property dtActiveVaults As DataTable Implements prePayment.IColumbariumDetails.dtActiveVaults
        Set(value As DataTable)
            Call SetDropDownList(ddlVault, value, "Lot", "Lot", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtSourceSite As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtSourceSite
        Set(value As DataTable)
            Call SetDropDownList(ddlSourceSite, value, "PRSNME", "PRSPID", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtCurrency As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtCurrency
        Set(value As DataTable)
            Call SetDropDownList(ddlORCurrency, value, "CURNAM", "CURCOD", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtPaymentType As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtPaymentType
        Set(value As DataTable)
            value.DefaultView.Sort = "DESCRP ASC"
            value = value.DefaultView.ToTable
            Call SetDropDownList(ddlORPaymentType, value, "DESCRP", "CODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtTransactionType As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtTransactionType
        Set(value As DataTable)
            value.DefaultView.Sort = "DESCRP ASC"
            value = value.DefaultView.ToTable
            Call SetDropDownList(ddlTransactionType, value, "DESCRP", "CODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtReceiptTransaction As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtReceiptTransaction
        Set(value As DataTable)
            Call SetDropDownList(ddlORTransaction, value, "COLDES", "COLREF", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    Public WriteOnly Property dtPersonType As DataTable Implements prePayment.IPaymentNonPremiumRelated.dtPersonType
        Set(value As DataTable)
            Call SetDropDownList(ddlSearchPayorType, value, "PRSDES", "PRSCOD", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property


#End Region

#Region "List (Of Class)"

    Public Property lstPaymentTypeDetails As List(Of cPaymentType) Implements prePayment.IPaymentNonPremiumRelated.lstPaymentTypeDetails
        Get
            Return ConvertToList(Of cPaymentType)(gvwPaymentTypeDetails)
        End Get
        Set(ByVal value As List(Of cPaymentType))
            If value.Count > 0 _
                 AndAlso ORGrossAmount > cDataType.fDecimal.Empty _
                 AndAlso ORGrossAmount = PaymentTotalAmount Then
                ORDetailTag = True
                ParticularsTag = True
            Else
                ORDetailTag = False
                ParticularsTag = False
            End If
            gvwPaymentTypeDetails.DataSource = value
            gvwPaymentTypeDetails.DataBind()
        End Set
    End Property

    Public Property lstParticulars As List(Of cParticulars) Implements prePayment.IPaymentNonPremiumRelated.lstParticulars
        Get
            Return ConvertToList(Of cParticulars)(gvwParticulars)
        End Get
        Set(ByVal value As List(Of cParticulars))
            gvwParticulars.DataSource = value
            gvwParticulars.DataBind()
        End Set
    End Property

    Public Property lstReceiptDetails As List(Of cReceiptDetail) Implements prePayment.IPaymentNonPremiumRelated.lstReceiptDetails
        Get
            Return ConvertToList(Of cReceiptDetail)(gvwORDetails)
        End Get
        Set(ByVal value As List(Of cReceiptDetail))

            gvwORDetails.DataSource = value
            gvwORDetails.DataBind()
        End Set
    End Property

    Public Property lstORDetails As List(Of cORDetail) Implements prePayment.IPaymentNonPremiumRelated.lstORDetails
        Get
            Return ConvertToList(Of cORDetail)(gvwORDetails)
        End Get
        Set(ByVal value As List(Of cORDetail))

            If value.Count > 0 _
                AndAlso ORGrossAmount > cDataType.fDecimal.Empty _
                AndAlso ReceiptTotalAmount = ORGrossAmount Then
                ORVatTag = True
            Else
                ORVatTag = False
            End If
            gvwORDetails.DataSource = value
            gvwORDetails.DataBind()
        End Set
    End Property

#End Region

#End Region

#Region "Event"
    Public Event ClearScreenAddPayor(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenAddPayor
    Public Event ClearScreenPayor(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenPayor
    Public Event ClearScreenPayorType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenPayorType
    Public Event ClearScreenAPRDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenAPRDetails
    Public Event ClearScreenCheckDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenCheckDetails
    Public Event ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenMain
    Public Event ClearScreenReceiptDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenReceiptDetails
    Public Event ClearScreenPaymentDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenPaymentDetails
    Public Event ClearScreenOtherDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenOtherDetails
    Public Event ClearScreenVATComputation(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenVATComputation
    Public Event ClearScreenCashDetails(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenCashDetails
    Public Event ClearScreenPaymentTypeDetails(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenPaymentTypeDetails
    Public Event ClearScreenColumbarium(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenColumbarium
    Public Event ClearScreenParticulars(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenParticulars
    Public Event ClearTotals(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearTotals
    Public Event ClearScreenViewOR(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ClearScreenViewOR

    ' -------------------------------------------------------------------------------
    Public Event LoadViewOR(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadViewOR
    Public Event LoadSourceSite(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadSourceSite
    Public Event LoadCurrency(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadCurrency
    Public Event LoadPersonType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadPersonType
    Public Event LoadPersonTitle(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadPersonTitle
    Public Event LoadPaymentType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadPaymentType
    Public Event LoadTransactionType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadTransactionType
    Public Event LoadReceiptTransaction(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadReceiptTransaction
    Public Event LoadNewOr(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadNewOR
    Public Event LoadAddPayor(sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadAddPayor
    Public Event LoadOR(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadOR
    Public Event LoadBankDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadBankDetails      'LoadDepositoryAccounts
    Public Event LoadBankList(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.LoadBankList 'LoadCheckBank
    Public Event LoadActiveVaults(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IColumbariumDetails.LoadActiveVaults
    Public Event GetVaultDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IColumbariumDetails.GetVaultDetails
    Public Event GetPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.GetPaymentTypeDetails
    ' -------------------------------------------------------------------------------
    Public Event GetPayorDetails(sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.GetPayorDetails
    ' -------------------------------------------------------------------------------
    Public Event ComputeVatDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ComputeVatDetails
    ' -------------------------------------------------------------------------------
    Public Event AddCashPayment(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.AddCashPayment
    Public Event AddPaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.AddPaymentTypeDetails
    Public Event DeletePaymentTypeDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.DeletePaymentTypeDetails
    Public Event CheckPrevPayType(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.CheckPrevPayType
    ' -------------------------------------------------------------------------------
    Public Event AddParticulars(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.AddParticulars
    Public Event DeleteParticulars(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.DeleteParticulars
    Public Event CheckParticulars(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.CheckParticulars
    ' -------------------------------------------------------------------------------
    Public Event GetReceiptTransactionDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.GetReceiptTransactionDetails
    Public Event AddReceiptDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.AddReceiptDetails
    Public Event DeleteReceiptDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.DeleteReceiptDetails
    Public Event CheckReceiptTransaction(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.CheckReceiptTransaction
    'Public Event GetReceiptDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.GetReceiptDetails
    ' -------------------------------------------------------------------------------
    'Public Event SavePaymentNonPremium(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.SavePaymentNonPremium
    Public Event ProcessPaymentNonPremium(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ProcessPaymentNonPremium
    Public Event ConfirmCancel(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ConfirmCancel
    Public Event ConfirmSave(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ConfirmSave
    Public Event ConfirmPrint(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ConfirmPrint
    Public Event ConfirmDeletePaytyp(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ConfirmDeletePaytyp
    Public Event ConfirmDeleteORDetails(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ConfirmDeleteORDetails
    Public Event ConfirmDeleteParticulars(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.ConfirmDeleteParticulars

#End Region

#End Region

#Region "IColumbarium"

#Region "Property"

    Public Property VaultVAT As Decimal Implements prePayment.IColumbariumDetails.VaultVAT
        Get
            Return cDataType.fDecimal.IfNull(txtColVAT.Text)
        End Get
        Set(value As Decimal)
            txtColVAT.Text = value
        End Set
    End Property

    Public Property ReservationAmt As Decimal Implements prePayment.IColumbariumDetails.ReservationAmt
        Get

            'If ColPayrRegular Then
            '    Return 1000
            'ElseIf ColPayrEmployee Then
            '    Return cDataType.fDecimal.IfNull(txtColRsrv.Text)
            'End If

            Return cDataType.fDecimal.IfNull(txtColRsrv.Text)

        End Get
        Set(value As Decimal)
            txtColRsrv.Text = value
        End Set
    End Property

    Public Property Product As String Implements prePayment.IColumbariumDetails.Product
        Get
            Return cDataType.fString.IfNull(txtProduct.Text)
        End Get
        Set(value As String)
            txtProduct.Text = value
        End Set
    End Property

    Public Property DiscountRate As Decimal Implements prePayment.IColumbariumDetails.DiscountRate
        Get
            Return cDataType.fDecimal.IfNull(txtColDscnt.Text)
        End Get
        Set(value As Decimal)
            txtColDscnt.Text = value
        End Set
    End Property

    Public Property Vault As Integer Implements prePayment.IColumbariumDetails.Vault
        Get
            Return cDataType.fLong.IfNull(ddlVault.SelectedValue)
        End Get
        Set(value As Integer)
            mVault = value
            If value = 0 Then
                ddlVault.SelectedValue = String.Empty
            Else
                ddlVault.SelectedValue = value
            End If

            ddlVault_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Level As String Implements prePayment.IColumbariumDetails.Level
        Get
            Return cDataType.fString.IfNull(txtLevel.Text)
        End Get
        Set(value As String)
            txtLevel.Text = value
        End Set
    End Property

    Public Property Block As String Implements prePayment.IColumbariumDetails.Block
        Get
            Return cDataType.fString.IfNull(txtBlock.Text)
        End Get
        Set(value As String)
            txtBlock.Text = value
        End Set
    End Property

    Public Property Column As String Implements prePayment.IColumbariumDetails.Column
        Get
            Return cDataType.fString.IfNull(txtColumn.Text)
        End Get
        Set(value As String)
            txtColumn.Text = value
        End Set
    End Property

    Public Property LotListPrice As Decimal Implements prePayment.IColumbariumDetails.LotListPrice
        Get
            Return cDataType.fDecimal.IfNull(txtLotListPrice.Text)
        End Get
        Set(value As Decimal)
            txtLotListPrice.Text = value
        End Set
    End Property
#End Region

#End Region

#Region "IPayor"

#Region "Properties"

    Public Property IsPayorExist() As Boolean Implements preSearch.IPayor.IsPayorExist
        Get
            Return mIsPayorExist
        End Get
        Set(ByVal value As Boolean)
            mIsPayorExist = value
        End Set
    End Property

    Public Property LoadPayorID() As Long Implements preSearch.IPayor.LoadPayorID
        Get
            Return PayorID
        End Get
        Set(ByVal value As Long)
            PayorID = value
        End Set
    End Property

    Public Property LoadPayorType() As String Implements preSearch.IPayor.LoadPayorType
        Get
            Return PayorType
        End Get
        Set(ByVal value As String)
            PayorType = value
        End Set
    End Property

    Public Property LoadSearchType() As Integer Implements preSearch.IPayor.LoadSearchType
        Get
            Return 0
        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Property SearchPayorID() As Long Implements preSearch.IPayor.SearchPayorID
        Get
            Return cDataType.fLong.IfNull(txtSearchPayorID.Text)
        End Get
        Set(ByVal value As Long)
            If value = 0 Then
                txtSearchPayorID.Text = Nothing
            Else
                txtSearchPayorID.Text = value
            End If
        End Set
    End Property

    Public Property SearchPayorName() As String Implements preSearch.IPayor.SearchPayorName
        Get
            Return cDataType.fString.IfNull(String.Concat(txtSearchPayorName.Text.Replace(";", ", "), "%"))
        End Get
        Set(ByVal value As String)
            txtSearchPayorName.Text = value
        End Set
    End Property

    Public Property SearchPayorType() As String Implements preSearch.IPayor.SearchPayorType
        Get
            Return cDataType.fString.IfNull(ddlSearchPayorType.SelectedValue)
        End Get
        Set(value As String)
            ddlSearchPayorType.SelectedValue = value
        End Set
    End Property

    Public WriteOnly Property dtSearchPayor() As DataTable Implements preSearch.IPayor.dtSearchPayor
        Set(ByVal value As DataTable)
            gvwSearchPayor.DataSource = value
            gvwSearchPayor.DataBind()
        End Set
    End Property

#End Region

#Region "Events"

    Public Event ClearScreenSearchPayor(sender As Object, e As EventArgs) Implements Presenter.OCS.Search.IPayor.ClearScreenSearchPayor
    Public Event LoadPayor(sender As Object, e As EventArgs) Implements Presenter.OCS.Search.IPayor.LoadPayor
    Public Event LoadSearchPayor(sender As Object, e As EventArgs) Implements Presenter.OCS.Search.IPayor.LoadSearchPayor

#End Region

#End Region

#Region "IReport"

#Region "Properties"

    Public Property ReportType() As eReport Implements preReport.IReport.ReportType
        Get
            Return eReport.Receipt
        End Get
        Set(value As eReport)
            '
        End Set
    End Property

    Public Property RptParamString() As String Implements preReport.IReport.RptParamString
        'Get
        '    Return hdnRptParamString.Value
        'End Get
        'Set(ByVal value As String)
        '    hdnRptParamString.Value = value
        'End Set

        Get
            Return Session(eSession.ReportParam)
        End Get
        Set(ByVal value As String)
            Session(eSession.ReportParam) = value
        End Set
    End Property

#End Region

#Region "Event"

    Public Event ClearScreenEvent(sender As Object, e As EventArgs) Implements preReport.IReport.ClearScreenReport

    Public Event GenerateReport(sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.GenerateReport

#End Region

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub PaymentNonPremiumRelated_Init(sender As Object, e As EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pConfirmationMessage = New preMessages.PConfirmationMessage(Me)
        pPaymentNonPremiumRelated = New prePayment.PPaymentNonPremiumRelated(Me)
        pPayor = New preSearch.PPayor(Me)
        pReport = New preReport.PReport(Me)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Call AddAttributes()
            Call LoadReference()
            Call ClearFields()
            Call SetDefaults()
        End If

    End Sub

#End Region

#Region "Button"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call ClearSession()
        Response.Redirect(ePage.PaymentNonPremiumRelated, False)
    End Sub

    Private Sub btnMessageOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessageOk.Click
        mpeMessage.Hide()
        Select Case Session(eSession.Modal)
            Case "mpeSearchPayor"
                Call SetModalSession(mpeSearchPayor, True, txtSearchPayorName)
            Case "mpeViewORs"
                'Call SetModalSession(mpeViewORs, True, btnViewORsClose)
                Call SetModalSession(mpeViewORs, True, btnLoadViewOr)
                'Case "mpePayTypDetails"
                '    Call SetModalSession(mpePayTypDetails, True, btnConfirmYes)
        End Select

        'If imgMessage.ImageUrl = eSystemMessage.Critical Then
        '    Response.Redirect(ePage.PaymentNonPremiumRelated, False)
        'End If
        Call ClearSession()
    End Sub

    Private Sub btnPaymentTypeAdd_Click(sender As Object, e As EventArgs) Handles btnPaymentTypeAdd.Click
        Call ClearSession()
        RaiseEvent AddPaymentTypeDetails(Me, EventArgs.Empty)
        If IsPayTypeSuccessful Then
            RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
            'FOCUS Me.Page.SetFocus(ddlORPaymentType)
        End If
        upPaymentNonPremiumRelated.Update()
    End Sub

    Private Sub btnPaymentTypeClear_Click(sender As Object, e As EventArgs) Handles btnPaymentTypeClear.Click
        RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
    End Sub

    Private Sub btnParticularsAdd_Click(sender As Object, e As EventArgs) Handles btnParticularsAdd.Click
        Call ClearSession()

        RaiseEvent CheckParticulars(Me, EventArgs.Empty)
        If IsParticularsValid Then
            RaiseEvent AddParticulars(Me, EventArgs.Empty)

            If IsParticularsValid Then
                RaiseEvent ClearScreenParticulars(Me, EventArgs.Empty)
                'FOCUS Me.Page.SetFocus(txtParticularsRemark)
            End If
        End If

        upPaymentNonPremiumRelated.Update()
    End Sub

    Private Sub btnParticularsClear_Click(sender As Object, e As EventArgs) Handles btnParticularsClear.Click
        RaiseEvent ClearScreenParticulars(Me, EventArgs.Empty)
    End Sub

    Private Sub btnOrDtlAdd_Click(sender As Object, e As EventArgs) Handles btnOrDtlAdd.Click
        Call ClearSession()
        RaiseEvent AddReceiptDetails(Me, EventArgs.Empty)
        RaiseEvent ComputeVatDetails(Me, EventArgs.Empty)
        If IsReceiptSuccessful Then
            'FOCUS Me.Page.SetFocus(ddlORTransaction)
        End If
        upPaymentNonPremiumRelated.Update()
    End Sub

    Private Sub btnViewORsClose_Click(sender As Object, e As EventArgs) Handles btnViewORsClose.Click
        Call ClearSession()
        Call SetModalSession(mpeViewORs, False, ibtnViewORs)
    End Sub

    Private Sub btnSearchPayorClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchPayorClear.Click
        Call ClearSession()
        RaiseEvent ClearScreenSearchPayor(Me, EventArgs.Empty)
        Call SetModalSession(mpeSearchPayor, True, ddlSearchPayorType)
    End Sub

    Private Sub btnSearchPayorClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchPayorClose.Click
        Call ClearSession()
        Call SetModalSession(mpeSearchPayor, False, ibtnSearchPayor)
    End Sub

    Private Sub btnSearchPayorSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchPayorSearch.Click

        Call ClearSession()
        RaiseEvent LoadSearchPayor(Me, EventArgs.Empty)

        If gvwSearchPayor.Rows.Count = 0 Then
            Call SetModalSession(mpeSearchPayor, True, btnMessageOk)
            txtPayorName.Visible = False
            'txtNewPayorName.Visible = True
            ibtnAddNewPayor.Visible = True
        Else
            Call SetModalSession(mpeSearchPayor, True, gvwSearchPayor)
            txtPayorName.Visible = True
            txtNewPayorName.Visible = False
        End If

    End Sub

    Private Sub btnReceiptAddNew_Click(sender As Object, e As EventArgs) Handles btnReceiptAddNew.Click
        Call ClearSession()
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
        RaiseEvent LoadNewOr(Me, EventArgs.Empty)
        Call SetDefaults()
        If IsSuccessful Then
            DocSaveState = eDocSaveState.AddNew
            IsSourceSiteLocked = True
            IsGrossAmountLocked = False
        Else
            DocSaveState = eDocSaveState.Initial
        End If
        upPaymentNonPremiumRelated.Update()
    End Sub

    Private Sub btnReceiptSave_Click(sender As Object, e As EventArgs) Handles btnReceiptSave.Click
        Call ClearSession()

        Select Case DocSaveState
            Case eDocSaveState.ViewEdit
                DocSaveState = eReference.DocSaveState.Edit
                ManageMain(DocSaveState)
                IsSourceSiteLocked = True
                IsGrossAmountLocked = True
            Case eDocSaveState.AddNew, eDocSaveState.Edit
                RaiseEvent ConfirmSave(Me, EventArgs.Empty)
        End Select

        upPaymentNonPremiumRelated.Update()
    End Sub
#End Region

#Region "CheckBox"

    Private Sub chkWithAPR_CheckedChanged(sender As Object, e As EventArgs) Handles chkWithAPR.CheckedChanged
        Me.WithAPR = DirectCast(sender, CheckBox).Checked
    End Sub

    Private Sub chkInitialFee_CheckedChanged(sender As Object, e As EventArgs) Handles chkInitialFee.CheckedChanged
        'Me.WithAPR = DirectCast(sender, CheckBox).Checked
        Me.ColumbaryInitialFee = DirectCast(sender, CheckBox).Checked

        If ColumbaryInitialFee Then
            radEmployee.Enabled = True
            radRegular.Enabled = True
            radRegular.Checked = True
            txtColRsrv.Enabled = True
            txtColDscnt.Enabled = True
            txtColVAT.Enabled = True

            txtColRsrv.Text = String.Empty
            txtColDscnt.Text = String.Empty
            txtColVAT.Text = String.Empty

            radEmployee.Checked = False
            radRegular.Checked = True
            ReservationAmt = 1000

        Else
            radEmployee.Enabled = False
            radRegular.Enabled = False
            radRegular.Checked = False
            txtColRsrv.Enabled = False
            txtColDscnt.Enabled = False
            txtColVAT.Enabled = False

            txtColRsrv.Text = String.Empty
            txtColDscnt.Text = String.Empty
            txtColVAT.Text = String.Empty

            radEmployee.Checked = False
            radRegular.Checked = False

            ReservationAmt = 0

        End If


    End Sub

#End Region

#Region "DropDownList"

    Private Sub ddlSourceSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSourceSite.SelectedIndexChanged
        SourceSite = ddlSourceSite.SelectedValue.ToString()
        RaiseEvent LoadBankDetails(Me, EventArgs.Empty)
        GLCode = cDataType.fString.Empty
    End Sub

    Private Sub ddlORPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlORPaymentType.SelectedIndexChanged

        RaiseEvent CheckPrevPayType(Me, EventArgs.Empty)

        If IsPayTypeSuccessful Then
            ManagePaymentType(ORPaymentType, True)
            PrevPayType = ddlORPaymentType.SelectedValue
        Else
            ORPaymentType = PrevPayType
        End If
    End Sub

    Private Sub ddlTransactionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTransactionType.SelectedIndexChanged

        Select Case TransactionType
            Case eReference.TranType.ORColumbary
                ColumbariumInfoTag = True
                OtherDetailsTag = False
                PaymentTypeTag = False
            Case eReference.TranType.ORLoan
                ColumbariumInfoTag = False
                OtherDetailsTag = False
                PaymentTypeTag = False
            Case eReference.TranType.ORRegular
                ColumbariumInfoTag = False
                OtherDetailsTag = False
                PaymentTypeTag = False
            Case String.Empty
                ORDetailTag = False
                OtherDetailsTag = False
                PaymentTypeTag = False
                ParticularsTag = False
                ColumbariumInfoTag = False

        End Select

        RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
        RaiseEvent ClearScreenOtherDetails(Me, EventArgs.Empty)
        RaiseEvent ClearScreenColumbarium(Me, EventArgs.Empty)
        RaiseEvent ClearScreenReceiptDetails(Me, EventArgs.Empty)
        RaiseEvent ClearScreenParticulars(Me, EventArgs.Empty)
        RaiseEvent ClearScreenAPRDetails(Me, EventArgs.Empty)
        RaiseEvent ClearScreenVATComputation(Me, EventArgs.Empty)
        RaiseEvent ClearTotals(Me, EventArgs.Empty)

        gvwParticulars.DataSource = Nothing

        If Not TransactionType.Equals(String.Empty) And IsGrossAmountLocked Then
            OtherDetailsTag = True
            PaymentTypeTag = True
        End If

        'FOCUS Me.Page.SetFocus(ddlTransactionType)
    End Sub

    Private Sub ddlORTransaction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlORTransaction.SelectedIndexChanged

        If Not ddlORTransaction.SelectedIndex.Equals(0) Then
            ReceiptTransactionCode = ddlORTransaction.SelectedValue
            'Get details
            RaiseEvent GetReceiptTransactionDetails(sender, e)
        End If


    End Sub

    Private Sub ddlDepositoryAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDepositoryAccount.SelectedIndexChanged
        'If Not ddlDepositoryAccount.SelectedIndex.Equals(0) Then
        GLCode = ddlDepositoryAccount.SelectedValue

        'End If

        'FOCUS Me.Page.SetFocus(ddlDepositoryAccount)
    End Sub

    Private Sub ddlVault_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlVault.SelectedIndexChanged
        If Not ddlVault.SelectedIndex.Equals(0) Then
            RaiseEvent GetVaultDetails(Me, EventArgs.Empty)
        End If

        'FOCUS Me.Page.SetFocus(ddlVault)
    End Sub

#End Region

#Region "ImageButton"

    Private Sub ibtnClearPayor_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnClearPayor.Click
        Call ManagePolicy(eReference.MgePol.Payor, True)
        Call ManagePolicy(eReference.MgePol.PayorAdd, False)
        RaiseEvent ClearScreenPayor(Me, EventArgs.Empty)
        'RaiseEvent ClearScreenAddPayor(Me, EventArgs.Empty)
        upPaymentNonPremiumRelated.Update()
    End Sub

    Private Sub ibtnSearchPayor_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnSearchPayor.Click
        Call ClearSession()
        If PayorID = 0 Or PayorIDTag Then
            RaiseEvent ClearScreenSearchPayor(Me, EventArgs.Empty)
            ddlSearchPayorType.Enabled = True
            Call SetModalSession(mpeSearchPayor, True, txtSearchPayorID)
        Else
            RaiseEvent LoadPayor(Me, EventArgs.Empty)
            Call ManagePolicy(eReference.MgePol.Payor, False)
            If IsPayorExist Then
                PayorIDTag = True
                RaiseEvent GetPayorDetails(Me, EventArgs.Empty)
                Call ManagePolicy(eReference.MgePol.PayorAdd, False)
                'FOCUS Me.Page.SetFocus(ibtnSearchPayor)
                txtPayorName.Visible = True
                txtNewPayorName.Visible = False
            Else
                Call ManagePolicy(eReference.MgePol.PayorAdd, False)
            End If
        End If
        upPaymentNonPremiumRelated.Update()
    End Sub

    Private Sub ibtnViewORs_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnViewORs.Click
        Call ClearSession()
        RaiseEvent ClearScreenViewOR(Me, EventArgs.Empty)
        RaiseEvent LoadViewOR(Me, EventArgs.Empty)

        'Call SetModalSession(mpeViewORs, True, btnViewORsClose)
        Call SetModalSession(mpeViewORs, True, btnLoadViewOr)

    End Sub

#End Region

#Region "GridView"

    Private Sub gvwPaymentTypeDetails_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvwPaymentTypeDetails.RowDeleting

        Dim index As Integer = Convert.ToInt32(e.RowIndex)
        Dim radSelect As RadioButton

        radSelect = DirectCast(gvwPaymentTypeDetails.Rows(index).FindControl("radSelectPayTypeDetails"), RadioButton)

        radSelectPayTypeDetails_CheckedChanged(radSelect, EventArgs.Empty)

        'Do not show "change of payment" prompt
        mpeMessage.Hide()
        '--------------------------------------

        'Call ClearSession()

        RaiseEvent ConfirmDeletePaytyp(Me, EventArgs.Empty)
        'SetModalSession(mpeConfirm, True, btnConfirmNo)

        'RaiseEvent DeletePaymentTypeDetails(Me, EventArgs.Empty)
        'If IsPayTypeSuccessful Then
        '    RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
        'End If
        ''FOCUS Me.Page.SetFocus(ddlORPaymentType)
        'upPaymentNonPremiumRelated.Update()

    End Sub

    Private Sub gvwORDetails_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvwORDetails.RowDeleting

        Dim index As Integer = Convert.ToInt32(e.RowIndex)
        Dim radSelect As RadioButton

        radSelect = DirectCast(gvwORDetails.Rows(index).FindControl("radSelectORDetails"), RadioButton)
        radSelect.Checked = True
        radSelectORDetails_CheckedChanged(radSelect, EventArgs.Empty)

        'Call ClearSession()
        'RaiseEvent DeleteReceiptDetails(Me, EventArgs.Empty)
        'If IsReceiptSuccessful Then
        '    RaiseEvent ClearScreenReceiptDetails(Me, EventArgs.Empty)
        'End If
        ''FOCUS Me.Page.SetFocus(ddlORTransaction)
        'upPaymentNonPremiumRelated.Update()

        RaiseEvent ConfirmDeleteORDetails(Me, EventArgs.Empty)
        'SetModalSession(mpeConfirm, True, btnConfirmNo)

    End Sub

    Private Sub gvwParticulars_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvwParticulars.RowDeleting
        Dim index As Integer = Convert.ToInt32(e.RowIndex)
        Dim radSelect As RadioButton

        radSelect = DirectCast(gvwParticulars.Rows(index).FindControl("radSelectParticulars"), RadioButton)
        radSelect.Checked = True
        radSelectParticulars_CheckedChanged(radSelect, EventArgs.Empty)

        RaiseEvent ConfirmDeleteParticulars(Me, EventArgs.Empty)
        'SetModalSession(mpeConfirm, True, btnConfirmNo)

        'Call ClearSession()
        'RaiseEvent DeleteParticulars(Me, EventArgs.Empty)
        '
        'RaiseEvent ClearScreenParticulars(Me, EventArgs.Empty)

        ''FOCUS Me.Page.SetFocus(txtParticularsRemark)
        'upPaymentNonPremiumRelated.Update()

    End Sub

#End Region

#Region "Radio Button"

    'Protected Sub radEmployee_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.

    Protected Sub radSelectViewOr_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.radSelectOr

        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
        ORNumber = cDataType.fLong.IfNull(gvrSelect.Cells(1).Text.Trim)
        ReceiptByCode = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(6).Text.Trim))
        ReceiptById = cDataType.fLong.IfNull(gvrSelect.Cells(7).Text.Trim)

        RaiseEvent LoadOR(Me, EventArgs.Empty)

        If ReceiptByCode <> Master.UserCode Then
            btnReceiptPrint.Enabled = False
            btnReceiptSave.Enabled = False
            btnReceiptCancel.Enabled = False
        End If

        Call SetModalSession(mpeViewORs, False, ibtnViewORs)
        upPaymentNonPremiumRelated.Update()

    End Sub

    Protected Sub radSelectPayor_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Implements preSearch.IPayor.radSelectPayor

        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        RaiseEvent ClearScreenPayor(Me, EventArgs.Empty)
        PayorID = cDataType.fLong.IfNull(gvrSelect.Cells(1).Text.Trim)

        RaiseEvent LoadPayor(Me, EventArgs.Empty)

        If IsPayorExist Then
            PayorIDTag = True
            RaiseEvent GetPayorDetails(Me, EventArgs.Empty)
            'FOCUS Me.Page.SetFocus(ibtnSearchPayor)
        End If

        Call SetModalSession(mpeSearchPayor, False, ibtnSearchPayor)

    End Sub

    Protected Sub radSelectPayTypeDetails_CheckedChanged(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.radSelectPayTypeDetails
        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        Call DeselectGridView(gvwPaymentTypeDetails, radSelect)
        RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)

        ORPaymentType = cDataType.fString.IfNull(gvrSelect.Cells(2).Text.Trim)
        PaymentTypeID = cDataType.fString.IfNull(gvrSelect.Cells(1).Text.Trim)


        If cDataType.fString.IfNull(gvrSelect.Cells(2).Text.Trim) = "CSH" Then

            ORCashAmount = cDataType.fString.IfNull(gvrSelect.Cells(3).Text.Trim)
        Else
            RaiseEvent GetPaymentTypeDetails(Me, EventArgs.Empty)
        End If

    End Sub

    Protected Sub radSelectORDetails_CheckedChanged(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.radSelectORDetails
        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        Call DeselectGridView(gvwORDetails, radSelect)
        RaiseEvent ClearScreenReceiptDetails(Me, EventArgs.Empty)
        ReceiptDetailID = cDataType.fString.IfNull(gvrSelect.Cells(1).Text.Trim)
    End Sub

    Protected Sub radSelectParticulars_CheckedChanged(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.radSelectParticulars
        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        Call ClearSession()
        Call DeselectGridView(gvwParticulars, radSelect)
        RaiseEvent ClearScreenParticulars(Me, EventArgs.Empty)
        ParticularsID = cDataType.fString.IfNull(gvrSelect.Cells(1).Text.Trim)

    End Sub

    Protected Sub radEmployee_CheckedChanged(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.radEmployee

        txtColRsrv.Text = String.Empty

        If radEmployee.Checked Then
            txtColRsrv.Enabled = False
        Else
            txtColRsrv.Enabled = True
        End If

    End Sub

    Protected Sub radRegular_CheckedChanged(ByVal sender As Object, e As EventArgs) Implements prePayment.IPaymentNonPremiumRelated.radRegular

        txtColRsrv.Text = String.Empty

        If radRegular.Checked Then
            txtColRsrv.Enabled = True
            txtColRsrv.Text = "1000"
        Else
            txtColRsrv.Enabled = False
            txtColRsrv.Text = String.Empty
        End If

    End Sub

    'Protected Sub radEmployee_CheckedChanged(ByVal sender As Object, e As EventArgs) Handles radEmployee.CheckedChanged

    '    txtColRsrv.Text = String.Empty

    '    If radEmployee.Checked Then
    '        txtColRsrv.Enabled = False
    '    Else
    '        txtColRsrv.Enabled = True
    '    End If

    'End Sub

    'Protected Sub radRegular_CheckedChanged(ByVal sender As Object, e As EventArgs) Handles radRegular.CheckedChanged

    '    txtColRsrv.Text = String.Empty

    '    If radRegular.Checked Then
    '        txtColRsrv.Enabled = True
    '    Else
    '        txtColRsrv.Enabled = False
    '    End If


    'End Sub

#End Region

#Region "Textbox"

    Protected Sub txtORGrossAmount_TextChanged(ByVal sender As Object, e As EventArgs) Handles txtORGrossAmount.TextChanged
        VATTotalCollection = VATAmount + VATableCollection + VATExemptCollection + NonVATCollection
        VATAmountNetWTax = VATTotalCollection - VATWithholdingTax
        APRAmount = ORGrossAmount
        upPaymentNonPremiumRelated.Update()
    End Sub

    Protected Sub txtNonVATCollection_TextChanged(ByVal sender As Object, e As EventArgs) Handles txtNonVATCollection.TextChanged
        VATTotalCollection = VATAmount + VATableCollection + VATExemptCollection + NonVATCollection
        VATAmountNetWTax = VATTotalCollection - VATWithholdingTax
        upPaymentNonPremiumRelated.Update()
    End Sub

    Protected Sub txtVATableCollection_TextChanged(ByVal sender As Object, e As EventArgs) Handles txtVATableCollection.TextChanged

        VATTotalCollection = VATAmount + VATableCollection + VATExemptCollection + NonVATCollection
        VATAmountNetWTax = VATTotalCollection - VATWithholdingTax
        upPaymentNonPremiumRelated.Update()
    End Sub

    Protected Sub txtVatAmount_TextChanged(ByVal sender As Object, e As EventArgs) Handles txtVATAmount.TextChanged

        VATTotalCollection = VATAmount + VATableCollection + VATExemptCollection + NonVATCollection
        VATAmountNetWTax = VATTotalCollection - VATWithholdingTax
        upPaymentNonPremiumRelated.Update()
    End Sub

#End Region

#End Region

#Region "Custom Method"

#Region "Sub"

    Private Sub AddAttributes()
        Call SetFocusBlur(txtORGrossAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtORRemarks, eCSS.TextBoxInputTextArea2Focus, eCSS.TextBoxInputTextArea2)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtParticularsAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtParticularsRemark, eCSS.TextBoxInputTextArea2Focus, eCSS.TextBoxInputTextArea2)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtPayorID, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtORAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtAPRNumber, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber)
        Call SetFocusBlur(txtAPRDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        Call SetFocusBlur(txtAPRAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtCheckNumber, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber)
        Call SetFocusBlur(txtCheckAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtCheckBankBranch, eCSS.TextBoxInputLongFocus, eCSS.TextBoxInputLong)
        Call SetFocusBlur(txtORCashAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtVATableCollection, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtNonVATCollection, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtVATExemptCollection, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtVATAmount, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtVATWithholdingTax, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        ' -------------------------------------------------------------------------------
        Call SetFocusBlur(txtAddPayorName, eCSS.TextBoxInputLong2Focus, eCSS.TextBoxInputLong2)
        ' -------------------------------------------------------------------------------
        Call SetCurrency(txtLotListPrice, 2)
        Call SetFocusBlur(txtColDscnt, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        Call SetFocusBlur(txtColVAT, eCSS.TextBoxInputShortNumberFocus, eCSS.TextBoxInputShortNumber, 2)
        ' -------------------------------------------------------------------------------
        Call SetButtonPostBack(btnCancel)
        'Call SetButtonPostBack(btnMessageOk)
        Call SetButtonPostBack(btnConfirmYes)
        Call SetButtonPostBack(btnOrDtlAdd)
        Call SetButtonPostBack(btnOrDtlClear)
        Call SetButtonPostBack(btnReceiptAddNew)
        Call SetButtonPostBack(btnReceiptCancel)
        Call SetButtonPostBack(btnReceiptPrint)
        Call SetButtonPostBack(btnReceiptSave)
        Call SetButtonPostBack(btnSearchAgentClose)
        Call SetButtonPostBack(btnSearchPayorClose)
        Call SetButtonPostBack(btnParticularsAdd)
        Call SetButtonPostBack(btnParticularsClear)
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
        'FOCUS Me.Page.SetFocus(ddlTransactionType)
    End Sub

    Private Sub ClearSession()
        Session(eSession.IsMessage) = Nothing
        Session(eSession.Message) = Nothing
        Session(eSession.MessageType) = Nothing
        Session(eSession.Modal) = Nothing
        'Session(eSession.ReportParam) = Nothing
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
        RaiseEvent LoadPersonType(Me, EventArgs.Empty)
        RaiseEvent LoadPersonTitle(Me, EventArgs.Empty)
        RaiseEvent LoadPaymentType(Me, EventArgs.Empty)
        RaiseEvent LoadTransactionType(Me, EventArgs.Empty)
        RaiseEvent LoadReceiptTransaction(Me, EventArgs.Empty)
        RaiseEvent LoadBankDetails(Me, EventArgs.Empty)  'LoadDepositoryAccounts
        RaiseEvent LoadBankList(Me, EventArgs.Empty)    'LoadBankList
        RaiseEvent LoadActiveVaults(Me, EventArgs.Empty)

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
        ManageMain(eDocSaveState.Initial)
        SourceSite = SiteCode

        ORCurrency = "PHP"
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
                ManageORPaymentDetails("ENABLED", False)
                ManagePolicy(eReference.MgePol.Enabled, False)
                ManagePaymentType("ENABLED", False)
                ManageReceiptDetails("ENABLED", False)
                ManageVatDetails("ENABLED", False)
                ManageAPRDetails("ENABLED", False)
                ManageColumbary("ENABLED", False)
                ManageParticulars("ENABLED", False)
                ManageOtherDetails("ENABLED", False)

            Case eDocSaveState.AddNew, eDocSaveState.Edit
                ManageORPaymentDetails("ENABLED", True)
                ManagePolicy(eReference.MgePol.Enabled, True)
                ManagePaymentType("ENABLED", True)
                ManageReceiptDetails("ENABLED", True)
                ManageAPRDetails("ENABLED", True)
                ManageVatDetails("ENABLED", True)
                ManageColumbary("ENABLED", True)
                ManageParticulars("ENABLED", True)
                ManageOtherDetails("ENABLED", True)
        End Select
    End Sub

    Private Sub ManageORPaymentDetails(ByVal pAction As String, Optional ByVal pEnabled As Boolean? = Nothing)

        Select Case pAction
            Case "ENABLED"
                pnlPaymentDetails1.Enabled = pEnabled

            Case "SOURCESITE"
                ddlSourceSite.Enabled = Not pEnabled
                ibtnVerifySourceSite.Visible = Not pEnabled
                ibtnClearSourceSite.Visible = pEnabled

            Case "GROSSAMOUNT"
                txtORGrossAmount.Enabled = Not pEnabled
                ibtnVerifyGrossAmount.Visible = Not pEnabled
                ibtnClearGrossAmount.Visible = pEnabled

            Case Else

                ddlSourceSite.Enabled = pEnabled
                ddlTransactionType.Enabled = pEnabled
                txtORGrossAmount.Enabled = pEnabled
                ddlORCurrency.Enabled = pEnabled
                chkWithAPR.Enabled = pEnabled
                txtORRemarks.Enabled = pEnabled


        End Select

    End Sub

    Private Sub ManagePolicy(ByVal pAction As eReference.MgePol, ByVal pEnabled As Boolean)

        Select Case pAction

            Case eReference.MgePol.Initial
                txtPayorID.Enabled = False
                ibtnAddNewPayor.Visible = False

            Case eReference.MgePol.Payor
                txtPayorID.Enabled = pEnabled
                ibtnSearchPayor.Visible = Not pEnabled    'original pEnabled
                ibtnClearPayor.Visible = pEnabled   'Not

            Case eReference.MgePol.PayorAdd
                ibtnAddNewPayor.Visible = Not pEnabled
                ibtnClearPayor.Visible = Not pEnabled
                ibtnSearchPayor.Visible = Not pEnabled

                '-----------

            Case eReference.MgePol.BInitial
                'txtPayorID.Enabled = pEnabled
                ibtnSearchPayor.Visible = pEnabled
                ibtnClearPayor.Visible = pEnabled
                ibtnAddNewPayor.Visible = Not pEnabled

                'Case "LInitial"
                '    txtPayorID.Enabled = pEnabled
                '    ibtnSearchPayor.Visible = pEnabled
                '    ibtnClearPayor.Visible = pEnabled
                '    ibtnAddNewPayor.Visible = pEnabled

            Case eReference.MgePol.RecordFound
                ibtnSearchPayor.Visible = pEnabled
                ibtnClearPayor.Visible = pEnabled
                ibtnAddNewPayor.Visible = pEnabled

            Case eReference.MgePol.RecordNotFound
                ibtnSearchPayor.Visible = pEnabled
                ibtnClearPayor.Visible = Not pEnabled
                ibtnAddNewPayor.Visible = pEnabled



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
                CashPaymentTag = True
                CheckPaymentTag = True

            Case Else
        End Select

    End Sub

    Private Sub ManageReceiptDetails(ByVal pAction As String, ByVal pEnabled As Boolean)
        Select Case pAction
            Case "ENABLED"
                pnlORDetails.Enabled = pEnabled

            Case Else
                ddlORPaymentType.Enabled = pEnabled
                txtORAmount.Enabled = pEnabled
                gvwORDetails.Enabled = pEnabled
                btnOrDtlAdd.Enabled = pEnabled
                btnOrDtlClear.Enabled = pEnabled

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

    Private Sub ManageParticulars(ByVal pAction As String, ByVal pEnabled As Boolean)

        Select Case pAction
            Case "ENABLED"
                pnlParticulars.Enabled = pEnabled

            Case Else
                txtParticularsAmount.Enabled = pEnabled
                txtParticularsRemark.Enabled = pEnabled
                gvwParticulars.Enabled = pEnabled
                btnParticularsAdd.Enabled = pEnabled
                btnParticularsClear.Enabled = pEnabled

        End Select

    End Sub

    Private Sub ManageColumbary(ByVal pAction As String, ByVal pEnabled As Boolean)

        Select Case pAction
            Case "ENABLED"
                pnlColumbarium.Enabled = pEnabled
                radEmployee.Enabled = Not pEnabled
                radRegular.Enabled = Not pEnabled
                txtColRsrv.Enabled = Not pEnabled
                txtColDscnt.Enabled = Not pEnabled
                txtColVAT.Enabled = Not pEnabled
                'radRegular.Checked = pEnabled

                If ColumbaryInitialFee Then
                    If pEnabled Then
                        If ColPayrRegular Then
                            txtColRsrv.Enabled = pEnabled
                        ElseIf ColPayrEmployee Then
                        End If

                        txtColDscnt.Enabled = pEnabled
                        txtColVAT.Enabled = pEnabled
                        radEmployee.Enabled = pEnabled
                        radRegular.Enabled = pEnabled

                    Else

                    End If
                End If

            Case Else
                txtLevel.Enabled = pEnabled
                txtBlock.Enabled = pEnabled
                txtColumn.Enabled = pEnabled
                ddlVault.Enabled = pEnabled

        End Select

    End Sub

    Private Sub ManageOtherDetails(ByVal pAction As String, ByVal pEnabled As Boolean)

        Select Case pAction
            Case "ENABLED"
                pnlOtherDetails.Enabled = pEnabled
                'ibtnSearchPayor.Enabled = Not pEnabled
                ibtnAddNewPayor.Visible = Not pEnabled

            Case Else
                txtPayorID.Enabled = pEnabled
                ibtnSearchPayor.Enabled = pEnabled
                ibtnAddNewPayor.Enabled = pEnabled
                ibtnClearPayor.Enabled = pEnabled
                txtPayorName.Enabled = pEnabled
                ddlDepositoryAccount.Enabled = pEnabled
                txtGLCode.Enabled = pEnabled

        End Select

    End Sub

    Private Sub ManageVatDetails(ByVal pAction As String, Optional ByVal pEnabled As Boolean? = Nothing)
        'If Not IsNothing(pEnabled) Then
        '    txtVATableCollection.Enabled = pEnabled
        '    txtVATExemptCollection.Enabled = pEnabled
        '    txtVATAmount.Enabled = pEnabled
        '    txtVATWithholdingTax.Enabled = pEnabled
        'End If

        Select Case pAction
            Case "ENABLED"
                pnlVATComputation.Enabled = pEnabled

            Case Else
                txtVATableCollection.Enabled = pEnabled
                txtNonVATCollection.Enabled = pEnabled
                txtVATExemptCollection.Enabled = pEnabled
                txtVATAmount.Enabled = pEnabled
                txtVATWithholdingTax.Enabled = pEnabled

        End Select
    End Sub

    'Private Sub ManageAgent(ByVal pAction As String, Optional ByVal pEnabled As Boolean? = True)

    '    Select Case pAction
    '        Case "EXIST"
    '            txtAgentID.Enabled = False
    '            ibtnSearchAgent.Visible = False
    '        Case "SEARCH"
    '            txtAgentID.Enabled = True
    '            ibtnSearchAgent.Visible = True
    '    End Select

    'End Sub

    'Private Sub ManagePayor(ByVal pAction As String, Optional ByVal pEnabled As Boolean? = True)

    '    Select Case pAction
    '        Case "EXIST"
    '            txtPayorID.Enabled = pEnabled
    '            txtPayorID.Enabled = pEnabled
    '            ibtnAddNewPayor.Visible = Not (pEnabled)
    '        Case "SEARCH"
    '            txtPayorID.Enabled = pEnabled
    '            txtPayorID.Enabled = pEnabled
    '            ibtnAddNewPayor.Visible = Not (pEnabled)
    '    End Select

    'End Sub

    Private Sub ManageAddPayor(ByVal pAction As String, Optional ByVal pEnabled As Boolean? = True)

        Select Case pAction
            Case "TYPE"
                'pnlPayor1.Visible = pEnabled
                'pnlAddPayor.Visible = Not (pEnabled)
                'pnlPayor1.Enabled = pEnabled
                'pnlPayor1.Enabled = Not (pEnabled)
                'txtAddPayorName.Enabled = Not (pEnabled)
                'txtAddPayorLastName.Enabled = pEnabled
                'txtAddPayorFirstName.Enabled = pEnabled
                'txtAddPayorMiddleName.Enabled = pEnabled
                'txtAddPayorDoB.Enabled = pEnabled
            Case "EXIST"
                'txtPayorID.Enabled = False
                'pnlPayor1.Visible = True
                ''pnlPayor1.Visible = IIf(PayorType = "C", False, True)
                ''ddlAddPayorType.Enabled = pEnabled
                'txtAddPayorName.Enabled = pEnabled
                'txtAddPayorLastName.Enabled = pEnabled
                'txtAddPayorFirstName.Enabled = pEnabled
                'txtAddPayorMiddleName.Enabled = pEnabled
                'txtAddPayorDoB.Enabled = pEnabled
            Case "SEARCH"
                'txtPayorID.Enabled = True
                'pnlAddPayor.Visible = False
                'pnlPayor1.Visible = True
                ''ddlAddPayorType.Enabled = pEnabled
                'txtAddPayorName.Enabled = pEnabled
                'txtAddPayorLastName.Enabled = pEnabled
                'txtAddPayorFirstName.Enabled = pEnabled
                'txtAddPayorMiddleName.Enabled = pEnabled
                'txtAddPayorDoB.Enabled = pEnabled
        End Select

    End Sub

    Private Sub SetDropDownList(ByVal pDropDownList As DropDownList, ByVal pDataSource As DataTable, ByVal pDataTextField As String, _
        ByVal pDataValueField As String, ByVal pNewDataTextField As String, ByVal pNewDataValueField As String)

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

    Private Sub SetDropDownListNewListItem(ByVal pDropDownList As DropDownList, ByVal pDataIndex As Integer, ByVal pDataTextField As String, _
                                            ByVal pDataValueField As String)
        With pDropDownList
            .Items.Insert(pDataIndex, New ListItem(pDataTextField, pDataValueField))
            .AppendDataBoundItems = True
            .DataBind()
        End With
    End Sub

    Private Sub SetFocusBlur(ByVal pTextBox As TextBox, ByVal pFocus As String, ByVal pBlur As String, Optional ByVal pDecimal As Integer? = Nothing)
        'pTextBox.Attributes.Add("onfocus", "DoFocus(this, '" & pFocus & "');")
        'pTextBox.Attributes.Add("onblur", "DoBlur(this, '" & pBlur & "');")

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
        'FOCUS Me.Page.SetFocus(pSetFocus)
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
                        .Remarks = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(7).Text))
                    End With
                Case gvwORDetails.ID
                    With TryCast(objLocal, cORDetail)
                        .IsSelected = cDataType.fBoolean.IfNull(DirectCast(dr.FindControl("radSelectORDetails"), RadioButton).Checked)
                        .ReceiptID = cDataType.fString.IfNull(dr.Cells(1).Text)
                        .TrnxCode = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(2).Text))
                        .ActType = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(3).Text))
                        .TrnxDesc = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(4).Text))
                        .Amount = cDataType.fDecimal.IfNull(dr.Cells(5).Text)
                        .ReceiptType = cDataType.fString.IfNull(dr.Cells(6).Text)
                    End With
                Case gvwParticulars.ID
                    With TryCast(objLocal, cParticulars)
                        .ParticularsID = cDataType.fString.IfNull(dr.Cells(1).Text)
                        .ParticularItem = cDataType.fString.IfNull(Server.HtmlDecode(dr.Cells(2).Text))
                        .ItemAmount = cDataType.fDecimal.IfNull(dr.Cells(3).Text)
                    End With
                Case Else



            End Select
            lstLocal.Add(objLocal)
        Next

        Return lstLocal

    End Function

#End Region

#End Region

    Protected Sub ibtnAddNewPayor_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAddNewPayor.Click
        txtNewPayorName.Visible = True
        txtPayorName.Visible = False

        RaiseEvent ClearScreenPayor(Me, EventArgs.Empty)
    End Sub

    Private Sub btnReceiptPrint_Click(sender As Object, e As EventArgs) Handles btnReceiptPrint.Click
        Call ClearSession()
        RaiseEvent ConfirmPrint(Me, EventArgs.Empty)
    End Sub

    Private Sub btnReceiptPreview_Click(sender As Object, e As EventArgs) Handles btnReceiptPreview.Click

        Call ClearSession()
        IsPreview = True
        RaiseEvent GenerateReport(Me, EventArgs.Empty)
        If IsSuccessful Then
            'Response.Redirect(ePage.RptORReceipt, False)
            SetReportSessionScript(ePage.RptORReceipt)
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
                RaiseEvent ProcessPaymentNonPremium(Me, EventArgs.Empty)
                If IsSuccessful Then
                    ReceiptById = UserID
                    RaiseEvent LoadOR(Me, EventArgs.Empty)

                    upPaymentNonPremiumRelated.Update()
                Else
                    DocSaveState = eDocSaveState.ViewNoEdit
                End If
                Call SetModalSession(mpeConfirm, False, btnReceiptCancel)

            Case "DELETEPAYTYP"
                Call ClearSession()
                RaiseEvent DeletePaymentTypeDetails(Me, EventArgs.Empty)
                If IsPayTypeSuccessful Then
                    RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
                End If
                'FOCUS Me.Page.SetFocus(ddlORPaymentType)
                upPaymentNonPremiumRelated.Update()

            Case "DELETEORDETAILS"
                Call ClearSession()
                RaiseEvent DeleteReceiptDetails(Me, EventArgs.Empty)
                If IsReceiptSuccessful Then
                    RaiseEvent ClearScreenReceiptDetails(Me, EventArgs.Empty)
                End If
                'FOCUS Me.Page.SetFocus(ddlORTransaction)
                upPaymentNonPremiumRelated.Update()

            Case "DELETEPARTICULARS"
                Call ClearSession()
                RaiseEvent DeleteParticulars(Me, EventArgs.Empty)
                RaiseEvent ClearScreenParticulars(Me, EventArgs.Empty)

                'FOCUS Me.Page.SetFocus(txtParticularsRemark)
                upPaymentNonPremiumRelated.Update()

            Case "SAVE"
                RaiseEvent ProcessPaymentNonPremium(Me, EventArgs.Empty)
                If IsSuccessful Then
                    ReceiptById = UserID
                    RaiseEvent LoadOR(Me, EventArgs.Empty)
                    DocSaveState = eDocSaveState.ViewEdit
                End If
            Case "PRINT"
                IsPreview = False
                RaiseEvent GenerateReport(Me, EventArgs.Empty)
                If IsSuccessful Then
                    DocSaveState = eDocSaveState.Print
                    RaiseEvent ProcessPaymentNonPremium(Me, EventArgs.Empty)
                    If IsSuccessful Then
                        ReceiptById = UserID
                        RaiseEvent LoadOR(Me, EventArgs.Empty)
                        upPaymentNonPremiumRelated.Update()
                    Else
                        DocSaveState = eDocSaveState.ViewEdit
                    End If
                End If

        End Select
    End Sub

    Private Sub btnOrDtlClear_Click(sender As Object, e As EventArgs) Handles btnOrDtlClear.Click
        RaiseEvent ClearScreenReceiptDetails(Me, EventArgs.Empty)
    End Sub

    Private Sub btnReceiptCancel_Click(sender As Object, e As EventArgs) Handles btnReceiptCancel.Click
        RaiseEvent ConfirmCancel(Me, EventArgs.Empty)
        'SetModalSession(mpeConfirm, True, btnConfirmNo)
    End Sub

    Private Sub ibtnAddCash_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAddCash.Click
        RaiseEvent AddCashPayment(Me, EventArgs.Empty)
        If IsPayTypeSuccessful Then
            RaiseEvent ClearScreenPaymentTypeDetails(Me, EventArgs.Empty)
            'FOCUS Me.Page.SetFocus(ddlORPaymentType)
        End If
        upPaymentNonPremiumRelated.Update()
    End Sub

    Private Sub btnLoadViewOr_Click(sender As Object, e As EventArgs) Handles btnLoadViewOr.Click
        dtViewOR = Nothing
        RaiseEvent LoadViewOR(Me, EventArgs.Empty)
        Call SetModalSession(mpeViewORs, True, btnLoadViewOr)
        upPaymentNonPremiumRelated.Update()
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

    Private Sub ibtnClearGrossAmount_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnClearGrossAmount.Click
        ORGrossAmount = 0
        IsGrossAmountLocked = False
        'PaymentTypeTag = False
    End Sub

    Private Sub ibtnVerifyGrossAmount_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnVerifyGrossAmount.Click
        IsGrossAmountLocked = True
        If Not TransactionType.Equals(String.Empty) And IsGrossAmountLocked Then
            If Not OtherDetailsTag = True Then OtherDetailsTag = True
            If Not PaymentTypeTag = True Then PaymentTypeTag = True
        End If
    End Sub

    Private Sub dummyCalculateVat_Click(sender As Object, e As EventArgs) Handles dummyCalculateVat.Click
        VATTotalCollection = VATableCollection + VATExemptCollection + NonVATCollection + VATAmount
        If NonVATCollection = ORGrossAmount / 0.98 Then
            VATWithholdingTax = NonVATCollection * 0.02
        End If
        VATAmountNetWTax = VATTotalCollection - VATWithholdingTax
    End Sub

    Protected Sub hdnClickStateTag_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class