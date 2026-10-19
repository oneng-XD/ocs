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

Partial Public Class MaintAgentsORSeries
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preMessages.IConfirmationMessage
    Implements preMaintenance.IMaintAgentsORSeries
    Implements preSearch.IAgent
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pAgent As preSearch.PAgent
    Private pMaintAgentsORSeries As preMaintenance.PMaintAgentsORSeries
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

#Region "IMaintAgentsORSeries"

#Region "Property"
    Public Property IsSeriesTemp As Boolean Implements preMaintenance.IMaintAgentsORSeries.IsSeriesTemp
        Get
            Return btnTemp.Enabled
        End Get
        Set(value As Boolean)
            btnTemp.Enabled = value
        End Set
    End Property

    Public Property SeriesEditId As String Implements preMaintenance.IMaintAgentsORSeries.SeriesEditId
        Get
            Return CStr(hdnEditId.Value)
        End Get
        Set(value As String)
            hdnEditId.Value = value
        End Set
    End Property

    Public Property SeriesAgent As Long Implements preMaintenance.IMaintAgentsORSeries.SeriesAgent, preSearch.IAgent.LoadAgentID
        Get
            Return cDataType.fLong.IfNull(txtAgentID.Text)
        End Get
        Set(value As Long)
            If value = 0 Then
                txtAgentID.Text = String.Empty
            Else
                txtAgentID.Text = value
            End If
        End Set
    End Property

    Public Property SeriesRegNumber As String Implements preMaintenance.IMaintAgentsORSeries.SeriesRegNumber
        Get
            Return cDataType.fString.IfNull(txtSeriesRegNumber.Text)
        End Get
        Set(value As String)
            txtSeriesRegNumber.Text = value
        End Set
    End Property

    Public Property SeriesRegDate As Date Implements preMaintenance.IMaintAgentsORSeries.SeriesRegDate
        Get
            Return cDataType.fDate.IfNull(txtSeriesRegDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtSeriesRegDate.Text = String.Empty
            Else
                txtSeriesRegDate.Text = value
            End If
        End Set
    End Property

    Public Property SeriesOldRegNumber As String Implements preMaintenance.IMaintAgentsORSeries.SeriesOldRegNumber
        Get
            Return cDataType.fString.IfNull(hdnSeriesOldRegNum.Value)
        End Get
        Set(value As String)
            hdnSeriesOldRegNum.Value = value
        End Set
    End Property

    Public Property SeriesOldRegDate As Date Implements preMaintenance.IMaintAgentsORSeries.SeriesOldRegDate
        Get
            Return cDataType.fDate.IfNull(hdnSeriesOldRegDate.value)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                hdnSeriesOldRegDate.value = String.Empty
            Else
                hdnSeriesOldRegDate.value = value
            End If
        End Set
    End Property

    Public Property SeriesStart As Decimal Implements preMaintenance.IMaintAgentsORSeries.SeriesStart
        Get
            Return cDataType.fDecimal.IfNull(txtSeriesStart.Text)
        End Get
        Set(value As Decimal)
            If value = 0 Then
                txtSeriesStart.Text = String.Empty
            Else
                txtSeriesStart.Text = value
            End If
        End Set
    End Property

    Public Property SeriesEnd As Decimal Implements preMaintenance.IMaintAgentsORSeries.SeriesEnd
        Get
            Return cDataType.fDecimal.IfNull(txtSeriesEnd.Text)
        End Get
        Set(value As Decimal)
            If value = 0 Then
                txtSeriesEnd.Text = String.Empty
            Else
                txtSeriesEnd.Text = value
            End If
        End Set
    End Property

    Public Property SeriesExpDate As Date Implements preMaintenance.IMaintAgentsORSeries.SeriesExpDate
        Get
            Return cDataType.fDate.IfNull(txtSeriesExpDate.Text)
        End Get
        Set(value As Date)
            If value = cDataType.fDate.Empty Then
                txtSeriesExpDate.Text = String.Empty
            Else
                txtSeriesExpDate.Text = value
            End If
        End Set
    End Property

    Public Property AgentIDTag() As Boolean Implements preMaintenance.IMaintAgentsORSeries.AgentIDTag
        Get
            Return cDataType.fBoolean.IfNull(hdnAgentIDTag.Value)
        End Get
        Set(ByVal value As Boolean)
            hdnAgentIDTag.Value = value
        End Set
    End Property

    Public Property IsSuccessful As Boolean Implements preMaintenance.IMaintAgentsORSeries.IsSuccessful
        Get
            Return mIsSuccessful
        End Get
        Set(value As Boolean)
            mIsSuccessful = value
        End Set
    End Property

    Public ReadOnly Property SiteCode As Long Implements preMaintenance.IMaintAgentsORSeries.SiteCode
        Get
            Return Val(Master.SiteID)
        End Get
    End Property

    Public ReadOnly Property UserID As Long Implements preMaintenance.IMaintAgentsORSeries.UserID
        Get
            Return Master.UserPrsPID
        End Get
    End Property

    Public ReadOnly Property RoleCode As String Implements preMaintenance.IMaintAgentsORSeries.RoleCode
        Get
            Return Master.RoleCode
        End Get
    End Property

    Public WriteOnly Property dtSeriesList As DataTable Implements preMaintenance.IMaintAgentsORSeries.dtSeriesList
        Set(value As DataTable)
            gvwAgentOrSeries.DataSource = value
            gvwAgentOrSeries.DataBind()
        End Set
    End Property

#End Region

#Region "Event"
    Public Event ClearScreenMain(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.ClearScreenMain
    Public Event ClearScreenSeries(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.ClearScreenSeries
    Public Event ClearScreenAgent(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.ClearScreenAgent
    ' ---------------------------------------------------------------------
    Public Event LoadSeriesList(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.LoadSeriesList
    Public Event ConfirmSave(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.ConfirmSave
    ' ---------------------------------------------------------------------
    Public Event AddNext(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.AddNext
    Public Event AddTemp(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.AddTemp
    ' ---------------------------------------------------------------------
    Public Event SaveSeries(sender As Object, e As EventArgs) Implements preMaintenance.IMaintAgentsORSeries.SaveSeries
#End Region

#End Region

#Region "IAgent"

#Region "Property"

#Region "Agent"

    Public Property LoadDocDate() As Date Implements preSearch.IAgent.LoadDocDate
        Get
            Return Now
        End Get
        Set(value As Date)

        End Set
    End Property

    Public Property AgentName() As String Implements preSearch.IAgent.LoadAgentName
        Get
            Return cDataType.fString.IfNull(txtAgentName.Text)
        End Get
        Set(ByVal value As String)
            txtAgentName.Text = value
        End Set
    End Property

    Property AgentFirstName() As String Implements preSearch.IAgent.LoadAgentFName
        Get
            Return cDataType.fString.IfNull(hdnAgentFirstName.Value)
        End Get
        Set(value As String)
            hdnAgentFirstName.Value = value
        End Set
    End Property

    Property AgentLastName() As String Implements preSearch.IAgent.LoadAgentLName
        Get
            Return cDataType.fString.IfNull(hdnAgentLastName.Value)
        End Get
        Set(value As String)
            hdnAgentLastName.Value = value
        End Set
    End Property

    Property AgentMiddleName() As String Implements preSearch.IAgent.LoadAgentMName
        Get
            Return cDataType.fString.IfNull(Left(Trim(hdnAgentMiddleName.Value), 1))
        End Get
        Set(value As String)
            hdnAgentMiddleName.Value = value
        End Set
    End Property

    Public Property AgencyID() As Long Implements preSearch.IAgent.LoadAgencyID
        Get
            Return cDataType.fLong.IfNull(txtAgencyID.Text)
        End Get
        Set(ByVal value As Long)
            If value = 0 Then
                txtAgencyID.Text = Nothing
            Else
                txtAgencyID.Text = value
            End If
        End Set
    End Property

    Public Property AgencyName() As String Implements preSearch.IAgent.LoadAgencyName
        Get
            Return cDataType.fString.IfNull(txtAgencyName.Text)
        End Get
        Set(ByVal value As String)
            txtAgencyName.Text = value
        End Set
    End Property

    Property AgencyFirstName() As String Implements preSearch.IAgent.LoadAgencyFName
        Get
            Return hdnAgencyFirstName.Value
        End Get
        Set(value As String)
            hdnAgencyFirstName.Value = value
        End Set
    End Property

    Property AgencyLastName() As String Implements preSearch.IAgent.LoadAgencyLName
        Get
            Return hdnAgencyLastName.Value
        End Get
        Set(value As String)
            hdnAgencyLastName.Value = value
        End Set
    End Property

    Property AgencyMiddleName() As String Implements preSearch.IAgent.LoadAgencyMName
        Get
            Return hdnAgencyMiddleName.Value
        End Get
        Set(value As String)
            hdnAgencyMiddleName.Value = value
        End Set
    End Property

#End Region

    Public Property IsAgentExist() As Boolean Implements preSearch.IAgent.IsAgentExist
        Get
            Return mIsAgentExist
        End Get
        Set(ByVal value As Boolean)
            mIsAgentExist = value
        End Set
    End Property

    ' ------------------------------------------------------------------------------- 

    Public Property SearchAgentTag() As Integer Implements preSearch.IAgent.SearchAgentTag
        Get
            Return cDataType.fInteger.IfNull(hdnSearchAgentTag.Value)
        End Get
        Set(ByVal value As Integer)
            hdnSearchAgentTag.Value = value
        End Set
    End Property

    ' ------------------------------------------------------------------------------- 

    Public Property SearchAgentID() As Long Implements preSearch.IAgent.SearchAgentID
        Get
            Return cDataType.fLong.IfNull(txtSearchAgentID.Text)
        End Get
        Set(ByVal value As Long)
            If value = 0 Then
                txtSearchAgentID.Text = Nothing
            Else
                txtSearchAgentID.Text = value
            End If
        End Set
    End Property

    Public Property SearchAgentName() As String Implements preSearch.IAgent.SearchAgentName
        Get
            'Return cDataType.fString.IfNull(String.Concat(txtSearchAgentName.Text.Replace(";", ", "), "%"))
            Return cDataType.fString.IfNull(txtSearchAgentName.Text.Replace(";", ", "))
        End Get
        Set(ByVal value As String)
            txtSearchAgentName.Text = value
        End Set
    End Property

    ' ------------------------------------------------------------------------------- 

    Public WriteOnly Property dtSearchAgent As DataTable Implements preSearch.IAgent.dtSearchAgent
        Set(ByVal value As DataTable)
            gvwSearchAgent.DataSource = value
            gvwSearchAgent.DataBind()
        End Set
    End Property

#End Region

#Region "Events"
    Public Event LoadAgent(sender As Object, e As EventArgs) Implements Presenter.OCS.Search.IAgent.LoadAgent
    Public Event LoadSearchAgent(sender As Object, e As EventArgs) Implements Presenter.OCS.Search.IAgent.LoadSearchAgent
    Public Event ClearScreenLoadAgent(sender As Object, e As EventArgs) Implements Presenter.OCS.Search.IAgent.ClearScreenLoadAgent
    Public Event ClearScreenSearchAgent(sender As Object, e As EventArgs) Implements Presenter.OCS.Search.IAgent.ClearScreenSearchAgent
#End Region

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub PaymentPremiumRelated_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pMaintAgentsORSeries = New preMaintenance.PMaintAgentsORSeries(Me)
        pAgent = New preSearch.PAgent(Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call AddAttributes()
            Call LoadReference()
            Call ClearFields()
            Call ManageForm("ADD", False)
            Call ManageForm("AGENT", True)
        End If

    End Sub

#End Region

#Region "Button"

    Private Sub btnMessageOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessageOk.Click
        mpeMessage.Hide()
        Select Case Session(eSession.Modal)
            Case "mpeConfirm"
                Call SetModalSession(mpeConfirm, True, btnConfirmNo)
            Case "mpeSearchAgent"
                Call SetModalSession(mpeSearchAgent, True, btnSearchAgentSearch)
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
        RaiseEvent AddNext(Me, EventArgs.Empty)
        Call ManageForm("ADD", True)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call ClearSession()
        RaiseEvent ConfirmSave(Me, EventArgs.Empty)
        'Call SetModalSession(mpeConfirm, True, btnConfirmNo)
    End Sub

    Private Sub btnTemp_Click(sender As Object, e As EventArgs) Handles btnTemp.Click
        Call ClearSession()
        RaiseEvent AddTemp(Me, EventArgs.Empty)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
        RaiseEvent ClearScreenAgent(Me, EventArgs.Empty)
        RaiseEvent LoadSeriesList(Me, EventArgs.Empty)
        Call ManageForm("AGENT", True)
        Call ManageForm("EDIT", False)
    End Sub

    Private Sub btnSearchAgentClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchAgentClear.Click
        Call ClearSession()
        RaiseEvent ClearScreenSearchAgent(Me, EventArgs.Empty)
        Call SetModalSession(mpeSearchAgent, True, txtSearchAgentID)
    End Sub

    Private Sub btnSearchAgentClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchAgentClose.Click
        Call ClearSession()
        Call SetModalSession(mpeSearchAgent, False, ibtnSearchAgent)
    End Sub

    Private Sub btnSearchAgentSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchAgentSearch.Click

        Call ClearSession()
        RaiseEvent LoadSearchAgent(Me, EventArgs.Empty)
        If gvwSearchAgent.Rows.Count = 0 Then
            Call SetModalSession(mpeSearchAgent, True, btnMessageOk)
        Else
            Call SetModalSession(mpeSearchAgent, True, gvwSearchAgent)
        End If

    End Sub

#End Region

#Region "CheckBox"

#End Region

#Region "DropDownList"

#End Region

#Region "ImageButton"

    Private Sub ibtnSearchAgent_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnSearchAgent.Click
        Call ClearSession()
        If SeriesAgent = 0 Or AgentIDTag Then
            RaiseEvent ClearScreenSearchAgent(Me, EventArgs.Empty)
            Call SetModalSession(mpeSearchAgent, True, btnSearchAgentClose)
        Else
            RaiseEvent LoadAgent(Me, EventArgs.Empty)
            If IsAgentExist Then
                AgentIDTag = True
                'RaiseEvent GetAgentDetails(Me, EventArgs.Empty)
                Call ManageForm("AGENT", False)
                RaiseEvent LoadSeriesList(Me, EventArgs.Empty)
            Else
                Call ManageForm("AGENT", True)
            End If
        End If
        upMaintAgentsORSeries.Update()
    End Sub

    Private Sub ibtnClearAgent_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnClearAgent.Click
        SearchAgentTag = eReference.AgentTagType.Agent

        RaiseEvent ClearScreenAgent(Me, EventArgs.Empty)
        Call ManageForm("AGENT", True)
        If SeriesEditId = String.Empty Then
            RaiseEvent LoadSeriesList(Me, EventArgs.Empty)
        End If

        upMaintAgentsORSeries.Update()
    End Sub

#End Region

#Region "GridView"

#End Region

#Region "Radio Button"

    Protected Sub radSelectAgent_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Implements preSearch.IAgent.radSelectAgent

        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)
        Dim CallerAgent As Integer = SearchAgentTag

        Call ClearSession()

        RaiseEvent ClearScreenAgent(Me, EventArgs.Empty)

        SeriesAgent = cDataType.fLong.IfNull(gvrSelect.Cells(1).Text.Trim)
        RaiseEvent LoadAgent(Me, EventArgs.Empty)
        If IsAgentExist Then
            AgentIDTag = True
            'RaiseEvent GetAgentDetails(Me, EventArgs.Empty)
            Call ManageForm("AGENT", False)
            RaiseEvent LoadSeriesList(Me, EventArgs.Empty)
        Else
            Call ManageForm("AGENT", True)
        End If
        Call SetModalSession(mpeSearchAgent, False, ibtnSearchAgent)

        SearchAgentTag = 0

        upMaintAgentsORSeries.Update()

    End Sub

    Protected Sub radSelectSeries_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim radSelect As RadioButton = DirectCast(sender, RadioButton)
        Dim gvrSelect As GridViewRow = DirectCast(radSelect.NamingContainer, GridViewRow)

        SeriesEditId = gvrSelect.Cells(1).Text
        SeriesAgent = cDataType.fLong.IfNull(gvrSelect.Cells(2).Text)
        SeriesRegNumber = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(3).Text))
        SeriesRegDate = cDataType.fDate.IfNull(gvrSelect.Cells(4).Text)
        SeriesOldRegNumber = cDataType.fString.IfNull(Server.HtmlDecode(gvrSelect.Cells(3).Text))
        SeriesOldRegDate = cDataType.fDate.IfNull(gvrSelect.Cells(4).Text)
        SeriesStart = cDataType.fLong.IfNull(gvrSelect.Cells(5).Text)
        SeriesEnd = cDataType.fLong.IfNull(gvrSelect.Cells(6).Text)
        SeriesExpDate = cDataType.fDate.IfNull(gvrSelect.Cells(7).Text)
        Call ManageForm("EDIT", True)

        RaiseEvent LoadAgent(Me, EventArgs.Empty)
        If IsAgentExist Then
            AgentIDTag = True
            Call ManageForm("AGENT", False)
        Else
            Call ManageForm("AGENT", True)
        End If
        Call SetModalSession(mpeSearchAgent, False, ibtnSearchAgent)

        SearchAgentTag = 0
    End Sub

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
        Call SetButtonPostBack(btnSearchAgentClear)
        'Call SetButtonPostBack(btnSearchAgentClose)
        Call SetButtonPostBack(btnSearchAgentSearch)
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
    End Sub

    Private Sub ClearSession()
        Session(eSession.IsMessage) = Nothing
        Session(eSession.Message) = Nothing
        Session(eSession.MessageType) = Nothing
        Session(eSession.Modal) = Nothing
    End Sub

    Private Sub LoadReference()
        RaiseEvent LoadSeriesList(Me, EventArgs.Empty)
        upMaintAgentsORSeries.Update()
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
                txtSeriesRegNumber.Enabled = IIf(SeriesRegNumber.Any, False, pEnabled)
                txtSeriesRegDate.Enabled = pEnabled
                txtSeriesStart.Enabled = pEnabled
                txtSeriesEnd.Enabled = pEnabled
                txtSeriesExpDate.Enabled = pEnabled
                gvwAgentOrSeries.Enabled = Not pEnabled
                btnAdd.Visible = Not pEnabled
                btnSave.Visible = pEnabled
            Case "EDIT"
                txtSeriesRegNumber.Enabled = pEnabled
                txtSeriesRegDate.Enabled = pEnabled
                txtSeriesStart.Enabled = pEnabled
                txtSeriesEnd.Enabled = pEnabled
                txtSeriesExpDate.Enabled = pEnabled
                gvwAgentOrSeries.Enabled = Not pEnabled
                btnAdd.Visible = Not pEnabled
                btnSave.Visible = pEnabled
            Case "AGENT"
                txtAgentID.Enabled = pEnabled
                ibtnSearchAgent.Visible = pEnabled
                ibtnClearAgent.Visible = Not pEnabled
                btnAdd.Enabled = Not pEnabled
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
End Class