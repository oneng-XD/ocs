#Region "Description"
' PAGE NAME     : Payment : Posting
' CREATED BY    : Ej
' CREATED DATE  : 03/17/2017
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
Imports eSession = Cocolife.Utility.OCS.Enums.eSession
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports eAccess = Cocolife.Utility.OCS.Enums.eAccess
Imports Cocolife.Utility.OCS.Classes
Imports System.Linq
Imports System.Reflection
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports cCrystalConn = Cocolife.Utility.OCS.Classes.cCrystalConn
#End Region

Partial Public Class PaymentCheckTagging
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preMessages.IConfirmationMessage
    Implements prePayment.IPaymentCheckTagging
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pAgent As preSearch.PAgent
    Private pPaymentCheckTagging As prePayment.PPaymentCheckTagging
    Private pReport As preReport.PReport
    Private mIsSuccessful As Boolean
    Private mIsAgentExist As Boolean
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

#Region "IPaymentCheckTagging"

#Region "Property"

    Public ReadOnly Property SiteCode As Long Implements prePayment.IPaymentCheckTagging.SiteCode
        Get
            Return Val(Master.SiteID)
        End Get
    End Property

    Public ReadOnly Property UserID As Long Implements prePayment.IPaymentCheckTagging.UserID
        Get
            Return Master.UserPrsPID
        End Get
    End Property

    Public ReadOnly Property RoleCode As String Implements prePayment.IPaymentCheckTagging.RoleCode
        Get
            Return Master.RoleCode
        End Get
    End Property

    Public Property IsSuccessful As Boolean Implements prePayment.IPaymentCheckTagging.IsSuccessful
        Get
            Return mIsSuccessful
        End Get
        Set(value As Boolean)
            mIsSuccessful = value
        End Set
    End Property

    Public Property TaggingType As String Implements prePayment.IPaymentCheckTagging.TaggingType
        Get
            Return cDataType.fString.IfNull(ddlTransactionType.SelectedValue)
        End Get
        Set(value As String)
            ddlTransactionType.SelectedValue = value
            Call ddlTransactionType_SelectedIndexChanged(Me, EventArgs.Empty)
        End Set
    End Property
    ' -------------------------------------------------------------------------------
    Public Property SearchFromDate As Date Implements prePayment.IPaymentCheckTagging.SearchFromDate
        Get
            Return cDataType.fDate.IfNull(txtSearchFromDate.text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtSearchFromDate.Text = String.Empty
            Else
                txtSearchFromDate.Text = value
            End If
        End Set
    End Property

    Public Property SearchToDate As Date Implements prePayment.IPaymentCheckTagging.SearchToDate
        Get
            Return cDataType.fDate.IfNull(txtSearchToDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtSearchToDate.Text = String.Empty
            Else
                txtSearchToDate.Text = value
            End If
        End Set
    End Property

    Public Property SearchReceiptNumber As Long Implements prePayment.IPaymentCheckTagging.SearchReceiptNumber
        Get
            Return cDataType.fLong.IfNull(txtSearchReceiptNumber.Text)
        End Get
        Set(value As Long)
            If value = 0 Then
                txtSearchReceiptNumber.Text = String.Empty
            Else
                txtSearchReceiptNumber.Text = value
            End If
        End Set
    End Property

    Public Property SearchCheckNumber As Long Implements prePayment.IPaymentCheckTagging.SearchCheckNumber
        Get
            Return cDataType.fLong.IfNull(txtSearchCheckNumber.Text)
        End Get
        Set(value As Long)
            If value = 0 Then
                txtSearchCheckNumber.Text = String.Empty
            Else
                txtSearchCheckNumber.Text = value
            End If
        End Set
    End Property
    ' -------------------------------------------------------------------------------
    Public Property TaggingEditId As Long Implements prePayment.IPaymentCheckTagging.TaggingEditId
        Get
            Return cDataType.fLong.IfNull(hdnEditId.Value)
        End Get
        Set(value As Long)
            hdnEditId.Value = value
        End Set
    End Property

    Public Property ReceiptNo As Long Implements prePayment.IPaymentCheckTagging.ReceiptNo
        Get
            Return cDataType.fLong.IfNull(hdnReceiptNo.Value)
        End Get
        Set(value As Long)

        End Set
    End Property

    Public Property TaggingDepositDate As Date Implements prePayment.IPaymentCheckTagging.TaggingDepositDate
        Get
            Return cDataType.fDate.IfNull(txtTaggingDepositDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtTaggingDepositDate.Text = String.Empty
            Else
                txtTaggingDepositDate.Text = value
            End If
        End Set
    End Property

    Public Property TaggingClearingDate As Date Implements prePayment.IPaymentCheckTagging.TaggingClearingDate
        Get
            Return cDataType.fDate.IfNull(txtTaggingClearingDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtTaggingClearingDate.Text = String.Empty
            Else
                txtTaggingClearingDate.Text = value
            End If
        End Set
    End Property

    Public Property TaggingClearingStatusId As Integer Implements prePayment.IPaymentCheckTagging.TaggingClearingStatusId
        Get
            Return cDataType.fString.IfNull(ddlTaggingClearingStatus.SelectedValue)
        End Get
        Set(value As Integer)
            ddlTaggingClearingStatus.SelectedValue = value
        End Set
    End Property

    'Public Property TaggingRemarks As String Implements prePayment.IPaymentCheckTagging.TaggingRemarks
    '    Get
    '        Return cDataType.fString.IfNull(txtTaggingRemarks.Text)
    '    End Get
    '    Set(value As String)
    '        txtTaggingRemarks.Text = value
    '    End Set
    'End Property
    ' -------------------------------------------------------------------------------
    Public WriteOnly Property dtTransactionType As DataTable Implements prePayment.IPaymentCheckTagging.dtTransactionType
        Set(value As DataTable)
            value.DefaultView.Sort = "CODE ASC"
            value = value.DefaultView.ToTable
            Call SetDropDownList(ddlTransactionType, value, "DESCRP", "CODE")
        End Set
    End Property

    Public WriteOnly Property dtStatus As DataTable Implements prePayment.IPaymentCheckTagging.dtStatus
        Set(value As DataTable)
            value.DefaultView.Sort = "NUMCODE ASC"
            value = value.DefaultView.ToTable
            Call SetDropDownList(ddlTaggingClearingStatus, value, "DESCRP", "NUMCODE", "-- SELECT ITEM --", "0")
        End Set
    End Property

    Public WriteOnly Property dtCheckList As DataTable Implements prePayment.IPaymentCheckTagging.dtCheckList
        Set(value As DataTable)
            gvwTagging.DataSource = value
            gvwTagging.DataBind()


            For Each row As GridViewRow In gvwTagging.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkSelectTagging"), CheckBox)

                    Select Case TaggingType
                        Case 1
                            If CDate(row.Cells(16).Text.ToString()) = #1/1/1900# Or CDate(row.Cells(18).Text.ToString()).ToShortDateString = Now.ToShortDateString Then
                                chkRow.Enabled = True
                            Else
                                chkRow.Enabled = False
                            End If
                        Case 2
                            If CDate(row.Cells(17).Text.ToString()) = #1/1/1900# Or CDate(row.Cells(18).Text.ToString()).ToShortDateString = Now.ToShortDateString Then
                                chkRow.Enabled = True
                            Else
                                chkRow.Enabled = False
                            End If
                    End Select

                End If
            Next

            ''Enabled='<%# IIf(CDate(Eval("clearing_date").ToString()) = #1/1/1900# Or CDate(Eval("last_update").ToString()).ToShortDateString = Now.ToShortDateString, True, False)%>'

        End Set
    End Property
    ' -------------------------------------------------------------------------------
    Public Property CheckAmount As Decimal Implements prePayment.IPaymentCheckTagging.CheckAmount
        Get
            Return cDataType.fDecimal.IfNull(hdnCheckAmount.Value)
        End Get
        Set(value As Decimal)
            hdnCheckAmount.Value = value
        End Set
    End Property

    Public Property CheckBankBranch As String Implements prePayment.IPaymentCheckTagging.CheckBankBranch
        Get
            Return cDataType.fString.IfNull(hdnCheckBankBranch.Value)
        End Get
        Set(value As String)
            hdnCheckBankBranch.Value = value
        End Set
    End Property

    Public Property CheckBankName As String Implements prePayment.IPaymentCheckTagging.CheckBankName
        Get
            Return cDataType.fString.IfNull(hdnCheckBankName.Value)
        End Get
        Set(value As String)
            hdnCheckBankName.Value = value
        End Set
    End Property

    Public Property CheckNumber As Long Implements prePayment.IPaymentCheckTagging.CheckNumber
        Get
            Return cDataType.fLong.IfNull(hdnCheckNumber.Value)
        End Get
        Set(value As Long)
            hdnCheckNumber.Value = value
        End Set
    End Property

    Public Property CheckLineNumber As Integer Implements prePayment.IPaymentCheckTagging.CheckLineNumber
        Get
            Return cDataType.fInteger.IfNull(hdnCheckLineNumber.Value)
        End Get
        Set(value As Integer)
            hdnCheckLineNumber.Value = value
        End Set
    End Property

    Public Property CheckOTCFlag As Integer Implements prePayment.IPaymentCheckTagging.CheckOTCFlag
        Get
            Return cDataType.fInteger.IfNull(hdnCheckOTCFlag.Value)
        End Get
        Set(value As Integer)
            hdnCheckOTCFlag.Value = value
        End Set
    End Property

    Public ReadOnly Property TaggingCheckList As List(Of cCheckTagging) Implements prePayment.IPaymentCheckTagging.TaggingCheckList
        Get
            Dim lstLocal As New List(Of cCheckTagging)

            For i = 0 To gvwTagging.Rows.Count - 1
                Dim objLocal As New cCheckTagging
                If DirectCast(gvwTagging.Rows(i).Cells(0).FindControl("chkSelectTagging"), CheckBox).Checked Then
                    With objLocal
                        .TaggingEditId = cDataType.fLong.IfNull(gvwTagging.Rows(i).Cells(1).Text)
                        .ReceiptNo = cDataType.fLong.IfNull(gvwTagging.Rows(i).Cells(2).Text)
                        .ReceiptDate = cDataType.fDate.IfNull(gvwTagging.Rows(i).Cells(3).Text)
                        .CheckNumber = cDataType.fLong.IfNull(gvwTagging.Rows(i).Cells(4).Text)
                        .CheckBankName = cDataType.fString.IfNull(Server.HtmlDecode(gvwTagging.Rows(i).Cells(5).Text))
                        .CheckBankBranch = cDataType.fString.IfNull(Server.HtmlDecode(gvwTagging.Rows(i).Cells(6).Text))
                        .CheckAmount = cDataType.fDecimal.IfNull(gvwTagging.Rows(i).Cells(7).Text)
                        .CheckLineNumber = cDataType.fInteger.IfNull(gvwTagging.Rows(i).Cells(8).Text)
                        .CheckOTCFlag = cDataType.fInteger.IfNull(gvwTagging.Rows(i).Cells(9).Text)
                        .TaggingDepositDate = cDataType.fDate.IfNull(DirectCast(gvwTagging.Rows(i).Cells(10).FindControl("deposit_date"), Label).Text)
                        .TaggingClearingDate = cDataType.fDate.IfNull(DirectCast(gvwTagging.Rows(i).Cells(11).FindControl("clearing_date"), Label).Text)
                        .TaggingClearingStatusId = cDataType.fInteger.IfNull(gvwTagging.Rows(i).Cells(12).Text)
                        .TaggingRemarks = cDataType.fString.IfNull(Server.HtmlDecode(gvwTagging.Rows(i).Cells(13).Text))
                        .StatusId = cDataType.fString.IfNull(Server.HtmlDecode(gvwTagging.Rows(i).Cells(14).Text))
                        .TaggingClearingStatus = cDataType.fString.IfNull(Server.HtmlDecode(gvwTagging.Rows(i).Cells(15).Text))
                        .LastUpdateBy = UserID
                        .LastUpdate = Now
                    End With
                    lstLocal.Add(objLocal)
                End If
            Next

            Return lstLocal

        End Get
    End Property

    Public Property CheckPaymentTag As Boolean Implements prePayment.IPaymentCheckTagging.CheckPaymentTag
    Public Property CheckTotalAmount As Decimal Implements prePayment.IPaymentCheckTagging.CheckTotalAmount

    Public WriteOnly Property dtBankList As DataTable Implements prePayment.IPaymentCheckTagging.dtBankList
        Set(value As DataTable)
            value = Nothing
        End Set
    End Property

#End Region

#End Region

#Region "Event"
    Public Event ClearScreenMain(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.ClearScreenMain
    Public Event ClearScreenTagging(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.ClearScreenTagging
    Public Event ClearScreenSearch(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.ClearScreenSearch
    Public Event ClearScreenCheckDetails(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.ClearScreenCheckDetails
    ' ---------------------------------------------------------------------
    Public Event LoadTransactionType(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.LoadTransactionType
    Public Event LoadStatus(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.LoadStatus
    Public Event LoadForDeposit(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.LoadForDeposit
    Public Event LoadForClearing(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.LoadForClearing
    Public Event LoadForReDeposit(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.LoadForReDeposit
    Public Event ConfirmSave(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.ConfirmSave
    ' ---------------------------------------------------------------------
    Public Event ProcessTagging(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.ProcessTagging
    ' ---------------------------------------------------------------------
    Public Event LoadBankList(sender As Object, e As EventArgs) Implements prePayment.IPaymentCheckTagging.LoadBankList

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub PaymentPremiumRelated_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pPaymentCheckTagging = New prePayment.PPaymentCheckTagging(Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call AddAttributes()
            Call ClearFields()
            Call LoadReference()
            Call ManageForm("DIV", True)
            'Call ManageForm("EDIT", False)
        End If

    End Sub

#End Region

#Region "Button"

    Private Sub btnMessageOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessageOk.Click
        mpeMessage.Hide()
        Select Case Session(eSession.Modal)
            Case mpeConfirm.GetType.Name
                Call SetModalSession(mpeConfirm, True, btnConfirmNo)
        End Select
        Call ClearSession()
    End Sub

    Private Sub btnConfirmYes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmYes.Click
        Call ClearSession()
        Select Case ConfirmCaller
            Case "SAVE"
                RaiseEvent ProcessTagging(Me, EventArgs.Empty)
                If IsSuccessful Then
                    RaiseEvent ClearScreenTagging(Me, EventArgs.Empty)
                    Call SelectTransaction(sender, e)
                    Call SetModalSession(mpeConfirm, False, btnSave)
                    'Call ManageForm("EDIT", False)
                End If
        End Select
    End Sub

    Private Sub btnConfirmNo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmNo.Click
        Call ClearSession()
        Select Case ConfirmCaller
            Case "SAVE"
                Call SetModalSession(mpeConfirm, False, btnConfirmNo)
        End Select
    End Sub

    Private Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click

        Call ClearSession()

        For Each row As GridViewRow In gvwTagging.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkSelectTagging"), CheckBox)
                If chkRow.Enabled Then
                    chkRow.Checked = True
                End If
            End If
        Next

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ClearSession()
        Call SelectTransaction(sender, e)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call ClearSession()
        RaiseEvent ConfirmSave(Me, EventArgs.Empty)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent ClearScreenTagging(Me, EventArgs.Empty)
        Call SelectTransaction(sender, e)
        'Call ManageForm("EDIT", False)

        upPaymentCheckTagging.Update()
    End Sub

#End Region

#Region "CheckBox"

#End Region

#Region "DropDownList"
    Private Sub ddlTransactionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTransactionType.SelectedIndexChanged
        Call ClearSession()
        RaiseEvent ClearScreenTagging(Me, EventArgs.Empty)
        RaiseEvent ClearScreenSearch(Me, EventArgs.Empty)
        Call SelectTransaction(sender, e)

        upPaymentCheckTagging.Update()
    End Sub
#End Region

#Region "ImageButton"

#End Region

#Region "GridView"

#End Region

#Region "Radio Button"

#End Region

#End Region

#Region "Custom Method"

#Region "Sub"

    Private Sub AddAttributes()
        'Call SetFocusBlur(txtFromDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        'Call SetFocusBlur(txtToDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        'Call SetFocusBlur(txtPostDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        ' -------------------------------------------------------------------------------
        'Call SetButtonPostBack(btnMessageOk)
        Call SetButtonPostBack(btnConfirmYes)
        Call SetButtonPostBack(btnConfirmNo)
        Call SetButtonPostBack(btnSave)
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
    End Sub

    Private Sub LoadReference()
        RaiseEvent LoadTransactionType(Me, EventArgs.Empty)
        RaiseEvent LoadStatus(Me, EventArgs.Empty)
        RaiseEvent LoadForDeposit(Me, EventArgs.Empty)
        upPaymentCheckTagging.Update()
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

    Private Sub ManageForm(ByVal pSource As String, ByVal pEnabled As Boolean)
        Select Case pSource
            'Case "EDIT"
            '    txtTaggingDepositDate.Enabled = pEnabled
            '    ddlTaggingClearingStatus.Enabled = pEnabled
            '    txtTaggingClearingDate.Enabled = pEnabled
            '    txtTaggingRemarks.Enabled = pEnabled
            '    'gvwTagging.Enabled = Not pEnabled
            '    btnSave.Visible = pEnabled

            Case "DIV"
                divForDeposit.Visible = pEnabled
                divForClearing.Visible = Not pEnabled

        End Select
    End Sub

    Private Sub SelectTransaction(ByVal sender As Object, ByVal e As EventArgs)
        Select Case TaggingType
            Case 1
                RaiseEvent LoadForDeposit(sender, e)
                ManageForm("DIV", True)
            Case 2
                RaiseEvent LoadForClearing(sender, e)
                ManageForm("DIV", False)
            Case 3
                RaiseEvent LoadforReDeposit(sender, e)
                ManageForm("DIV", True)
        End Select
    End Sub

    Private Sub SetButtonPostBack(ByVal pButton As Button)
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

    Private Sub SetReportSessionScript(ByVal pReport As String)
        If Session("script") = String.Empty Or Session("script") Is Nothing Then
            'Session("script") = "window.open('" + pReport + "','','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
            Session("script") = "window.open('" + pReport + "','_blank','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
        Else
            'Session("script") = Session("script") & "window.open('" + pReport + "','','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
            Session("script") = Session("script") & "window.open('" + pReport + "','_blank','toolbar=yes,location=no,menubar=no,width=900,height=500,resizable=yes,scrollbars=yes,top=0,left=0');"
        End If
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

#End Region

#End Region

    Protected Sub gvwTagging_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvwTagging.SelectedIndexChanged

    End Sub
End Class