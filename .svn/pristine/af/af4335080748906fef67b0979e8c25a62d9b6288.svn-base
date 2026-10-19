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
Imports preMaintenance = Cocolife.Presenter.OCS.Maintenance
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

Partial Public Class MaintOfficialReceipt
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preMessages.IConfirmationMessage
    Implements preMaintenance.IMaintOfficialReceipt
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pMaintOfficialReceipt As preMaintenance.PMaintOfficialReceipt
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

#Region "IMaintOfficialReceipt"

#Region "Property"

    Public Property SeriesEditId As Long Implements preMaintenance.IMaintOfficialReceipt.SeriesEditId
        Get
            Return cDataType.fLong.IfNull(hdnEditId.Value)
        End Get
        Set(value As Long)
            hdnEditId.Value = value
        End Set
    End Property

    Public Property SeriesPrspid As Long Implements preMaintenance.IMaintOfficialReceipt.SeriesPrspid
        Get
            Return cDataType.fLong.IfNull(hdnSeriesPrspid.Value)
        End Get
        Set(value As Long)
            hdnSeriesPrspid.Value = value
            If value = 0 Then
                ddlSite.SelectedIndex = 0
            End If
        End Set
    End Property

    Public Property SeriesPrefix As Long Implements preMaintenance.IMaintOfficialReceipt.SeriesPrefix
        Get
            Return cDataType.fLong.IfNull(hdnCustomPrefix.Value)
        End Get
        Set(value As Long)
            hdnCustomPrefix.Value = value
        End Set
    End Property

    Public Property SeriesCount As Decimal Implements preMaintenance.IMaintOfficialReceipt.SeriesCount
        Get
            Return cDataType.fDecimal.IfNull(txtCustomCount.Text)
        End Get
        Set(value As Decimal)
            txtCustomCount.Text = value
        End Set
    End Property

    Public Property SeriesStart As Decimal Implements preMaintenance.IMaintOfficialReceipt.SeriesStart
        Get
            Return cDataType.fDecimal.IfNull(hdnCustomLower.Value)
        End Get
        Set(value As Decimal)
            hdnCustomLower.Value = value
            If value = 0 Then
                txtCustomLower.Text = String.Empty
            Else
                txtCustomLower.Text = String.Concat(SeriesPrefix, value.ToString("000000"))
            End If
        End Set
    End Property

    Public Property SeriesEnd As Decimal Implements preMaintenance.IMaintOfficialReceipt.SeriesEnd
        Get
            Return cDataType.fDecimal.IfNull(hdnCustomUpper.Value)
        End Get
        Set(value As Decimal)
            hdnCustomUpper.Value = value
            If value = 0 Then
                txtCustomUpper.Text = String.Empty
                txtCustomCount.Text = 0
            Else
                txtCustomUpper.Text = String.Concat(SeriesPrefix, value.ToString("000000"))
                txtCustomCount.Text = SeriesEnd - SeriesStart + 1
            End If
        End Set
    End Property

    Public Property SeriesStatus As Integer Implements preMaintenance.IMaintOfficialReceipt.SeriesStatus
        Get
            Return Val(ddlStatus.SelectedValue)
        End Get
        Set(value As Integer)
            ddlStatus.SelectedValue = value
        End Set
    End Property

    Public Property IsSuccessful As Boolean Implements preMaintenance.IMaintOfficialReceipt.IsSuccessful
        Get
            Return mIsSuccessful
        End Get
        Set(value As Boolean)
            mIsSuccessful = value
        End Set
    End Property

    Public ReadOnly Property SiteCode As Long Implements preMaintenance.IMaintOfficialReceipt.SiteCode
        Get
            Return Val(ddlSite.SelectedValue)
        End Get
    End Property

    Public ReadOnly Property UserID As Long Implements preMaintenance.IMaintOfficialReceipt.UserID
        Get
            Return Master.UserPrsPID
        End Get
    End Property

    Public ReadOnly Property RoleCode As String Implements preMaintenance.IMaintOfficialReceipt.RoleCode
        Get
            Return Master.RoleCode
        End Get
    End Property

    Public WriteOnly Property dtStatus As DataTable Implements preMaintenance.IMaintOfficialReceipt.dtStatus
        Set(value As DataTable)
            Call SetDropDownList(ddlStatus, value, "DESCRIPTION", "ID", "-- SELECT ITEM --", "0")
        End Set
    End Property

    Public WriteOnly Property dtSeriesList As DataTable Implements preMaintenance.IMaintOfficialReceipt.dtSeriesList
        Set(value As DataTable)

            If Not IsNothing(value) Then
                Dim dtFiltered = From c In value.AsEnumerable
                                 Where CInt(c.Item("status_id")) <> 4 _
                                 And CLng(c.Item("start_opr_series")) > 0
                                 Select c

                For Each dr In value.AsEnumerable
                    SeriesPrefix = dr.Item("prefix")
                    Exit For
                Next

                If dtFiltered.Any() Then
                    value = dtFiltered.CopyToDataTable
                Else
                    value.Clear()
                End If
            End If

            gvwOrSeries.DataSource = value
            gvwOrSeries.DataBind()
        End Set
    End Property

    Public WriteOnly Property dtSiteList As DataTable Implements preMaintenance.IMaintOfficialReceipt.dtSiteList
        Set(value As DataTable)
            Call SetDropDownList(ddlSite, value, "PRSNME", "PRSPID", "-- SELECT ITEM --", "0")
        End Set
    End Property

#End Region

#Region "Event"
    Public Event ClearScreenMain(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.ClearScreenMain
    Public Event ClearScreenSeries(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.ClearScreenSeries
    Public Event ClearScreenList(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.ClearScreenList
    ' ---------------------------------------------------------------------
    Public Event LoadStatus(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.LoadStatus
    Public Event LoadSiteSeries(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.LoadSiteList
    Public Event LoadSeriesList(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.LoadSeriesList
    Public Event ConfirmSave(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.ConfirmSave
    Public Event Add1000(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.Add1000
    ' ---------------------------------------------------------------------
    Public Event SaveSeries(sender As Object, e As EventArgs) Implements preMaintenance.IMaintOfficialReceipt.SaveSeries
#End Region

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub PaymentPremiumRelated_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pMaintOfficialReceipt = New preMaintenance.PMaintOfficialReceipt(Me)
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

    Private Sub btnConfirmYes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmYes.Click
        Call ClearSession()
        Select Case ConfirmCaller
            Case "SAVE"
                RaiseEvent SaveSeries(Me, EventArgs.Empty)
                If IsSuccessful Then
                    RaiseEvent ClearScreenSeries(Me, EventArgs.Empty)
                    RaiseEvent LoadSeriesList(Me, EventArgs.Empty)
                    Call SetModalSession(mpeConfirm, False, btnSave)
                    Call ManageForm("EDIT", False)
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call ClearSession()
        Call ManageForm("ADD", True)
        RaiseEvent Add1000(Me, EventArgs.Empty)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call ClearSession()
        RaiseEvent ConfirmSave(Me, EventArgs.Empty)
        'Call SetModalSession(mpeConfirm, True, btnConfirmNo)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent ClearScreenSeries(Me, EventArgs.Empty)
        RaiseEvent LoadSeriesList(Me, EventArgs.Empty)
        Call ManageForm("EDIT", False)
    End Sub

#End Region

#Region "CheckBox"

#End Region

#Region "DropDownList"

    Private Sub ddlSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSite.SelectedIndexChanged
        Call ClearSession()
        RaiseEvent LoadSeriesList(sender, e)

        btnAdd.Enabled = IIf(ddlSite.SelectedValue, True, False)
    End Sub

#End Region

#Region "ImageButton"

#End Region

#Region "GridView"

    Private Sub gvwOrSeries_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvwOrSeries.RowCommand
        If e.CommandName = "Recall" Then
            Dim index As Long = e.CommandArgument

            Dim gvrSelect As GridViewRow = gvwOrSeries.Rows(index)

            SeriesEditId = cDataType.fLong.IfNull(gvrSelect.Cells(0).Text)
            SeriesPrspid = cDataType.fLong.IfNull(gvrSelect.Cells(1).Text)
            SeriesPrefix = CLng(gvrSelect.Cells(8).Text)
            SeriesStart = CLng(Right(gvrSelect.Cells(3).Text, 6)).ToString("D6")
            SeriesEnd = CLng(Right(gvrSelect.Cells(4).Text, 6)).ToString("D6")
            SeriesStatus = CLng(gvrSelect.Cells(7).Text)
            gvrSelect.Cells(6).Text = "EDITING"
            Call ManageForm("EDIT", True)
        End If
    End Sub

#End Region

#Region "Radio Button"

#End Region

#End Region

#Region "Custom Method"

#Region "Sub"

    Private Sub AddAttributes()
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
        RaiseEvent LoadSiteSeries(Me, EventArgs.Empty)
        RaiseEvent LoadStatus(Me, EventArgs.Empty)
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
            Case "ADD"
                ddlSite.Enabled = Not pEnabled
                txtCustomCount.Enabled = pEnabled
                'txtCustomLower.Enabled = pEnabled
                'txtCustomUpper.Enabled = pEnabled
                ddlStatus.Enabled = pEnabled
                gvwOrSeries.Enabled = Not pEnabled
                btnAdd.Visible = Not pEnabled
                btnSave.Visible = pEnabled
            Case "EDIT"
                ddlSite.Enabled = Not pEnabled
                txtCustomCount.Enabled = pEnabled
                'txtCustomLower.Enabled = pEnabled
                'txtCustomUpper.Enabled = pEnabled
                ddlStatus.Enabled = pEnabled
                gvwOrSeries.Enabled = Not pEnabled
                btnAdd.Visible = Not pEnabled
                btnSave.Visible = pEnabled
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

    Private Sub btnSeriesCount_Click(sender As Object, e As EventArgs) Handles btnSeriesCount.Click
        If SeriesCount > 0 Then
            If Right(SeriesStart, 6) = 0 Then
                SeriesStart += 1
            End If
            SeriesEnd = SeriesStart + SeriesCount - 1
        Else
            SeriesStart = 0
            SeriesEnd = 0
        End If
    End Sub
End Class