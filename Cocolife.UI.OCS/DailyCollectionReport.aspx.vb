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
#End Region

Partial Public Class DailyCollectionReport
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preMessages.IConfirmationMessage
    Implements prePayment.IDailyCollectionReport
    Implements preReport.IReport
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pDailyCollectionReport As prePayment.PDailyCollectionReport
    Private pReport As preReport.PReport
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

#Region "IDailyCollectionReport"

#Region "Property"

    Public Property DcrStartDate As Date Implements Presenter.OCS.Payment.IDailyCollectionReport.DcrStartDate
        Get
            Return cDataType.fDate.IfNull(txtFromDate.Text)
        End Get
        Set(value As Date)
            txtFromDate.Text = value
        End Set
    End Property

    Public Property DcrEndDate As Date Implements Presenter.OCS.Payment.IDailyCollectionReport.DcrEndDate
        Get
            Return cDataType.fDate.IfNull(txtToDate.Text)
        End Get
        Set(value As Date)
            txtToDate.Text = value
        End Set
    End Property

    Public Property DcrDocType As String Implements Presenter.OCS.Payment.IDailyCollectionReport.DcrDocType
        Get
            Return cDataType.fString.IfNull(ddlDcrType.SelectedValue)
        End Get
        Set(value As String)
            ddlDcrType.SelectedValue = value
        End Set
    End Property

    'Public Property DcrRecordType As String Implements Presenter.OCS.Payment.IDailyCollectionReport.DcrRecordType
    '    Get
    '        Return cDataType.fString.IfNull(ddlRecordType.SelectedValue)
    '    End Get
    '    Set(value As String)
    '        ddlRecordType.SelectedValue = value
    '    End Set
    'End Property

    Public Property DcrCurcod As String Implements Presenter.OCS.Payment.IDailyCollectionReport.DcrCurcod
        Get
            Return cDataType.fString.IfNull(ddlCurcod.SelectedValue)
        End Get
        Set(value As String)
            ddlCurcod.SelectedValue = value
        End Set
    End Property

    Public Property IsSuccessful As Boolean Implements Presenter.OCS.Payment.IDailyCollectionReport.IsSuccessful, preReport.IReport.IsSuccessful
        Get
            Return mIsSuccessful
        End Get
        Set(value As Boolean)
            mIsSuccessful = value
        End Set
    End Property

    'Public Property PostDate As Date Implements Presenter.OCS.Payment.IDailyCollectionReport.PostDate
    '    Get
    '        Return cDataType.fDate.IfNull(txtPostDate.Text)
    '    End Get
    '    Set(value As Date)
    '        If value = cDataType.fDate.Empty Then
    '            txtPostDate.Text = Nothing
    '        Else
    '            txtPostDate.Text = value
    '        End If
    '    End Set
    'End Property

    Public ReadOnly Property SiteCode As Long Implements Presenter.OCS.Payment.IDailyCollectionReport.SiteCode, preReport.IReport.SiteCode
        Get
            Return Master.SiteID
        End Get
    End Property

    Public ReadOnly Property SiteIpAddr As String Implements preReport.IReport.SiteIpAddr
        Get
            Return Master.SiteIpAddr
        End Get
    End Property

    Public ReadOnly Property UserID As Long Implements Presenter.OCS.Payment.IDailyCollectionReport.UserID, preReport.IReport.UserId
        Get
            Return Master.UserPrsPID
        End Get
    End Property

    Public ReadOnly Property RoleCode As String Implements Presenter.OCS.Payment.IDailyCollectionReport.RoleCode
        Get
            Return Master.RoleCode
        End Get
    End Property

    Public WriteOnly Property dtDcrType As DataTable Implements Presenter.OCS.Payment.IDailyCollectionReport.dtDcrType
        Set(value As DataTable)
            value.DefaultView.Sort = "CODE"
            value = value.DefaultView.ToTable
            Call SetDropDownList(ddlDcrType, value, "DESCRP", "CODE", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

    'Public WriteOnly Property dtRecordType As DataTable Implements Presenter.OCS.Payment.IDailyCollectionReport.dtRecordType
    '    Set(value As DataTable)
    '        value.DefaultView.Sort = "CODE"
    '        value = value.DefaultView.ToTable
    '        Call SetDropDownList(ddlRecordType, value, "DESCRP", "CODE", "-- SELECT ITEM --", String.Empty)
    '    End Set
    'End Property

    Public WriteOnly Property dtCurcod As DataTable Implements Presenter.OCS.Payment.IDailyCollectionReport.dtCurcod
        Set(value As DataTable)
            Call SetDropDownList(ddlCurcod, value, "CURNAM", "CURCOD", "-- SELECT ITEM --", String.Empty)
        End Set
    End Property

#End Region

#Region "Event"
    Public Event ClearScreenDCR(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.ClearScreenDCR
    Public Event ClearScreenMain(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.ClearScreenMain
    'Public Event ClearScreenPosting(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.ClearScreenPosting
    'Public Event ConfirmPosting(ByVal sender As Object, ByVal e As EventArgs) Implements prePayment.IDailyCollectionReport.ConfirmPosting
    'Public Event LoadPostDate(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.LoadPostDate
    Public Event LoadDcrType(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.LoadDcrType
    'Public Event LoadRecordType(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.LoadRecordType
    Public Event LoadCurcod(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.LoadCurcod
    Public Event GenerateReport(sender As Object, e As EventArgs) Implements Presenter.OCS.Payment.IDailyCollectionReport.GenerateReport
#End Region

#End Region

#Region "IReport"

#Region "Properties"

    Public Property ReportType() As eReport Implements preReport.IReport.ReportType
        Get
            Return cDataType.fInteger.IfNull(hdnReportType.Value)
        End Get
        Set(value As eReport)
            hdnReportType.Value = cDataType.fInteger.IfNull(value)
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

    Public Property IsPreview As Boolean Implements preReport.IReport.IsPreview

#End Region

#Region "Event"

    Public Event ClearScreenReport(sender As Object, e As EventArgs) Implements preReport.IReport.ClearScreenReport

#End Region

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub PaymentPremiumRelated_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pDailyCollectionReport = New prePayment.PDailyCollectionReport(Me)
        pReport = New preReport.PReport(Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call AddAttributes()
            Call LoadReference()
            Call ClearFields()
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

    'Private Sub btnLoadPostDate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoadPostDate.Click
    '    Call ClearSession()
    '    RaiseEvent LoadPostDate(Me, EventArgs.Empty)
    'End Sub

    'Private Sub btnPost_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPost.Click
    '    Call ClearSession()
    '    RaiseEvent ConfirmPosting(Me, EventArgs.Empty)
    'End Sub

    Private Sub btnConfirmYes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmYes.Click
        Call ClearSession()
        Select Case ConfirmCaller
            Case "POST"
                'RaiseEvent ClearScreenPosting(Me, EventArgs.Empty)
                'Call SetModalSession(mpeConfirm, False, btnPost)
        End Select
    End Sub

    Private Sub btnConfirmNo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmNo.Click
        Call ClearSession()
        Call SetModalSession(mpeConfirm, False, btnConfirmNo)
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGenerate.Click
        Call ClearSession()
        ReportType = IIf(DcrDocType = eReference.DocTypeOPR, eReport.DetailPrem, eReport.DetailNonPrem)
        RaiseEvent GenerateReport(Me, EventArgs.Empty)
        If IsSuccessful Then
            SetReportSessionScript(IIf(DcrDocType = eReference.DocTypeOPR, ePage.RptDetailPrem, ePage.RptDetailNonPrem))
            'Response.Redirect(ePage.Posting, False)

            ScriptManager.RegisterStartupScript(sender, GetType(String), "OPEN_WINDOW", Session("script"), True)

            Session("script") = String.Empty

        End If
    End Sub

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        Call ClearSession()
        ReportType = IIf(DcrDocType = eReference.DocTypeOPR, eReport.SummaryPrem, eReport.SummaryNonPrem)
        RaiseEvent GenerateReport(Me, EventArgs.Empty)
        If IsSuccessful Then
            SetReportSessionScript(IIf(DcrDocType = eReference.DocTypeOPR, ePage.RptSummaryPrem, ePage.RptSummaryNonPrem))
            'Response.Redirect(ePage.Posting, False)

            ScriptManager.RegisterStartupScript(sender, GetType(String), "OPEN_WINDOW", Session("script"), True)

            Session("script") = String.Empty

        End If
    End Sub

#End Region

#Region "CheckBox"

#End Region

#Region "DropDownList"

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
        Call SetFocusBlur(txtFromDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        Call SetFocusBlur(txtToDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        'Call SetFocusBlur(txtPostDate, eCSS.TextBoxInputShortFocus, eCSS.TextBoxInputShort)
        ' -------------------------------------------------------------------------------
        'Call SetButtonPostBack(btnMessageOk)
        Call SetButtonPostBack(btnConfirmYes)
        Call SetButtonPostBack(btnConfirmNo)
        Call SetButtonPostBack(btnGenerate)
        Call SetButtonPostBack(btnSummary)
        'Call SetButtonPostBack(btnLoadPostDate)
        'Call SetButtonPostBack(btnPost)
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
        Me.Page.SetFocus(txtFromDate)
    End Sub

    Private Sub ClearSession()
        Session(eSession.IsMessage) = Nothing
        Session(eSession.Message) = Nothing
        Session(eSession.MessageType) = Nothing
        Session(eSession.Modal) = Nothing
    End Sub

    Private Sub LoadReference()
        RaiseEvent LoadDcrType(Me, EventArgs.Empty)
        'RaiseEvent LoadRecordType(Me, EventArgs.Empty)
        RaiseEvent LoadCurcod(Me, EventArgs.Empty)
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

End Class