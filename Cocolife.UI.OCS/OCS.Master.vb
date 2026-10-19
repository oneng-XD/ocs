#Region "Description"
' PAGE NAME     : OCS Master 
' CREATED BY    : MPRO
' CREATED DATE  : 11/05/2014
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports cDataType = Cocolife.Utility.Common.DataType
Imports ePage = Cocolife.Utility.OCS.Enums.ePage
Imports eAccess = Cocolife.Utility.OCS.Enums.eAccess
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports System.Net.NetworkInformation
Imports System.Management
Imports System.IO

Imports preSecurity = Cocolife.Presenter.Common.Security
Imports preReference = Cocolife.Presenter.OCS.Reference
Imports preMaster = Cocolife.Presenter.OCS.Master
#End Region

Partial Public Class OCS
    Inherits System.Web.UI.MasterPage

#Region "Implements"
    Implements preMaster.IMaster
    Implements preReference.ISiteDetails
    Implements preSecurity.ISystemMessage
    Implements preSecurity.ISessionValidator
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pSiteDetails As preReference.PSiteDetails
    Private pSessionValidator As preSecurity.PSessionValidator
    Private pMaster As preMaster.PMaster
    ' ------------------------------------------------------------------------------- 
    Private mUserCode As String = String.Empty
    Private mUserName As String = String.Empty
    Private mSupervisorCode As String = String.Empty
    Private mRoleCode As String = String.Empty
    Private mSiteID As Long = 0
    ' ------------------------------------------------------------------------------- 
    Private mUserPrsPID As Long = 0
#End Region

#Region "Interface"

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

#Region "ISiteDetails"

#Region "Properties"

    Public Property SiteAddr As String Implements Presenter.OCS.Reference.ISiteDetails.SiteAddr
        Get
            Return cDataType.fString.IfNull(hdnSiteAddr.Value)
        End Get
        Set(value As String)
            hdnSiteAddr.Value = value
        End Set
    End Property

    Public Property SiteIpAddr As String Implements Presenter.OCS.Reference.ISiteDetails.SiteIpAddr
        Get
            Return cDataType.fString.IfNull(hdnSiteIpAddr.Value)
        End Get
        Set(value As String)
            hdnSiteIpAddr.Value = value
        End Set
    End Property

    'Public Property SiteCode As Long Implements Presenter.OCS.Reference.ISiteDetails.SiteCode
    '    Get
    '        Return cDataType.fLong.IfNull(hdnSiteCode.Value)
    '    End Get
    '    Set(value As Long)
    '        hdnSiteCode.Value = value
    '    End Set
    'End Property

    Public Property SiteEmail As String Implements Presenter.OCS.Reference.ISiteDetails.SiteEmail
        Get
            Return cDataType.fString.IfNull(hdnSiteEmail.Value)
        End Get
        Set(value As String)
            hdnSiteEmail.Value = value
        End Set
    End Property

    Public Property SiteName As String Implements Presenter.OCS.Reference.ISiteDetails.SiteName
        Get
            Return cDataType.fString.IfNull(hdnSiteName.Value)
        End Get
        Set(value As String)
            hdnSiteName.Value = value
            lblSiteHeader.Text = value
            lblSiteFooter.Text = value
        End Set
    End Property

    Public Property SitePrefix As Integer Implements Presenter.OCS.Reference.ISiteDetails.SitePrefix
        Get
            Return cDataType.fInteger.IfNull(hdnSitePrefix.Value)
        End Get
        Set(value As Integer)
            hdnSitePrefix.Value = value
        End Set
    End Property

    Public Property SiteTel As String Implements Presenter.OCS.Reference.ISiteDetails.SiteTel
        Get
            Return cDataType.fString.IfNull(hdnSiteTel.Value)
        End Get
        Set(value As String)
            hdnSiteTel.Value = value
        End Set
    End Property

    Public Property SiteTin As String Implements Presenter.OCS.Reference.ISiteDetails.SiteTin
        Get
            Return cDataType.fString.IfNull(hdnSiteTin.Value)
        End Get
        Set(value As String)
            hdnSiteTin.Value = value
        End Set
    End Property

    'Public Property UserId As Long Implements Presenter.OCS.Reference.ISiteDetails.SiteUserId
    '    Get
    '        Return cDataType.fLong.IfNull(hdnSiteUserId.Value)
    '    End Get
    '    Set(value As Long)
    '        hdnSiteUserId.value = value
    '    End Set
    'End Property

#End Region

#Region "Events"
    Public Event LoadSiteDetails(sender As Object, e As EventArgs) Implements Presenter.OCS.Reference.ISiteDetails.LoadSiteDetails
#End Region

#End Region

#Region "IMaster"

#Region "Property"

    Public ReadOnly Property UserCode() As String Implements preMaster.IMaster.UserCode
        Get
            Return mUserCode
        End Get
    End Property

    Public ReadOnly Property UserName() As String Implements preMaster.IMaster.UserName
        Get
            Return mUserName
        End Get
    End Property

    Public ReadOnly Property RoleCode() As String Implements preMaster.IMaster.RoleCode
        Get
            Return mRoleCode
        End Get
    End Property

    Public ReadOnly Property SupervisorCode() As String Implements preMaster.IMaster.SupervisorCode
        Get
            Return mSupervisorCode
        End Get
    End Property

    Public ReadOnly Property SiteID() As Long Implements preMaster.IMaster.SiteID, Presenter.OCS.Reference.ISiteDetails.SiteCode
        Get
            Return mSiteID
        End Get
    End Property

    ' ------------------------------------------------------------------------------- 

    Public Property UserPrsPID() As Long Implements preMaster.IMaster.UserPrsPID, preReference.ISiteDetails.SiteUserId
        Get
            Return mUserPrsPID
        End Get
        Set(ByVal value As Long)
            mUserPrsPID = value
        End Set
    End Property

    Public WriteOnly Property dtCheckTagging As DataTable Implements preMaster.IMaster.dtCheckTagging
        Set(value As DataTable)
            Dim dtFiltered = From c In value.AsEnumerable
                             Where CDate(c.Item("deposit_date")) = #1/1/1900# Or CDate(c.Item("clearing_date")) = #1/1/1900#
                             Select c

            If dtFiltered.Count() Then
                lnkToDosHeader.Text = String.Concat("ToDo's (", dtFiltered.Count, ")")
                lnkToDosFooter.Text = String.Concat("ToDo's (", dtFiltered.Count, ")")
                lnkToDosHeader.ForeColor = Drawing.Color.Red
                lnkToDosFooter.ForeColor = Drawing.Color.Red

                value = dtFiltered.CopyToDataTable
            Else
                lnkToDosHeader.Text = "ToDo's"
                lnkToDosFooter.Text = "ToDo's"
                lnkToDosHeader.ForeColor = Drawing.Color.Gray
                lnkToDosFooter.ForeColor = Drawing.Color.Gray

                value = New DataTable
            End If

            gvwTagging.DataSource = value
            gvwTagging.DataBind()

            upMaster.Update()
        End Set
    End Property

#End Region

#Region "Event"
    Public Event ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs) Implements preMaster.IMaster.ClearScreenMain
    ' ------------------------------------------------------------------------------- 
    Public Event LoadCheckTagging(ByVal sender As Object, ByVal e As EventArgs) Implements preMaster.IMaster.LoadCheckTagging
    Public Event GetUserSecRef(ByVal sender As Object, ByVal e As EventArgs) Implements preMaster.IMaster.GetUserSecRef
    ' ------------------------------------------------------------------------------- 
#End Region

#End Region

#Region "ISessionValidator"

#Region "Property"

    Public ReadOnly Property MyAccessList() As System.Collections.Generic.List(Of BLL.Common.Security.BGrants) Implements preSecurity.ISessionValidator.MyAccessList
        Get
            Return Session("acc")
        End Get
    End Property

    Public ReadOnly Property MyUserDetails() As System.Collections.Generic.List(Of BLL.Common.Security.BUser) Implements preSecurity.ISessionValidator.myUserDetails
        Get
            Return Session("udt")
        End Get
    End Property

    Public WriteOnly Property IsActive() As Boolean Implements preSecurity.ISessionValidator.IsActive
        Set(ByVal value As Boolean)
            If Not value Then
                Response.Redirect(ePage.Login, True)
            End If
        End Set
    End Property

#End Region

#Region "Event"
    Public Event CheckSessionID(ByVal sender As Object, ByVal e As System.EventArgs) Implements preSecurity.ISessionValidator.CheckSessionID
    Public Event CheckDefaultTag(ByVal sender As Object, ByVal e As System.EventArgs) Implements preSecurity.ISessionValidator.CheckDefaultTag
#End Region

#End Region

#End Region

#Region "Event Handlers"

#Region "Page"


    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Dim currentPage As String = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
        Dim mAllowAccess As Boolean = False

        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pSiteDetails = New preReference.PSiteDetails(Me)
        pSessionValidator = New preSecurity.PSessionValidator(Me)
        pMaster = New preMaster.PMaster(Me)

        RaiseEvent CheckSessionID(Me, EventArgs.Empty)
        RaiseEvent ClearScreenMain(Me, EventArgs.Empty)
        'RaiseEvent LoadSiteDetails(Me, EventArgs.Empty)

        ' Session("uid") | Session("ste")
        For Each lstItem In MyUserDetails
            mUserCode = lstItem.UserCode
            mUserName = lstItem.UserName
            mSupervisorCode = lstItem.SupervisorCode
            mRoleCode = lstItem.RoleCode
            mSiteID = lstItem.SiteID
        Next

        Session("role_code") = RoleCode

        For Each lstItem In MyAccessList
            Select Case lstItem.AccessCode
                Case eAccess.AccessMtnAPR
                    sub1MaintenanceAPR.Visible = True
                    If currentPage = ePage.MaintAssignAprSeries Then mAllowAccess = True
                Case eAccess.AccessMtnORseries
                    sub1MaintenanceORSeries.Visible = True
                    If currentPage = ePage.MaintOfficialReceipt Then mAllowAccess = True
                Case eAccess.AccessMtnAgentORseries
                    sub1MaintenanceAgentORSeries.Visible = True
                    If currentPage = ePage.MaintAgentsORSeries Then mAllowAccess = True
                Case eAccess.AccessMtnTransactionSetup
                    sub1MaintenanceTransactionSetup.Visible = True
                    If currentPage = ePage.MaintTransSetup Then mAllowAccess = True
                Case eAccess.AccessMtnSiteMerchantID
                    sub1MaintenanceSiteMerchantID.Visible = True
                    If currentPage = ePage.MaintSiteMerchantID Then mAllowAccess = True
                Case eAccess.AccessRptPosting
                    sub1Payments.Visible = True
                    If currentPage = ePage.DailyCollectionReport Then mAllowAccess = True
                Case eAccess.AccessTrnPremium
                    sub2PremiumPayments.Visible = True
                    If currentPage = ePage.PaymentPremiumRelated Then mAllowAccess = True
                Case eAccess.AccessTrnNonPremium
                    sub2NonPremiumPayments.Visible = True
                    If currentPage = ePage.PaymentNonPremiumRelated Then mAllowAccess = True
                Case eAccess.AccessTrnBatchPremium
                    sub2BatchPremiumPayments.Visible = True
                    If currentPage = ePage.PaymentBatchPremiumRelated Then mAllowAccess = True
                Case eAccess.AccessTrnCheckTagging
                    sub1CheckTagging.Visible = True
                    If currentPage = ePage.PaymentCheckTagging Then mAllowAccess = True
                Case eAccess.AccessTrnSalesInvoice
                    sub2SalesInvoice.Visible = True
                    If currentPage = ePage.PaymentSalesInvoice Then mAllowAccess = True
                Case eAccess.AccessAckReceipt
                    sub2AckReceipts.Visible = True
                    If currentPage = ePage.PaymentAckReceipt Then mAllowAccess = True
                Case eAccess.AccessDebitCreditMemo
                    sub2DebitCreditMemo.Visible = True
                    If currentPage = ePage.PaymentDebitCreditMemo Then mAllowAccess = True 'end
                Case eAccess.AccessDMCMApproval
                    sub2DMCMApproval.Visible = True
                    If currentPage = ePage.PaymentDMCMApproval Then mAllowAccess = True 'end
            End Select

        Next

        If currentPage = ePage.Home OrElse currentPage = ePage.ChangePassword Then mAllowAccess = True
        If Not mAllowAccess Then Response.Redirect(ePage.Home)

        If sub2PremiumPayments.Visible OrElse sub2NonPremiumPayments.Visible OrElse sub2BatchPremiumPayments.Visible Then
            menuReports.Visible = True
        End If

        SiteIpAddr = Request.ServerVariables("REMOTE_ADDR")
        'SiteIpAddr = Request.ServerVariables("REMOTE_HOST")

        RaiseEvent GetUserSecRef(Me, EventArgs.Empty)
        RaiseEvent LoadSiteDetails(Me, EventArgs.Empty)
        RaiseEvent LoadCheckTagging(Me, EventArgs.Empty)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblUserHeader.Text = CType(Session.Item("userid"), String)
        lblUserHeader.Text = UserCode 'Request.ServerVariables("REMOTE_ADDR") ' GetMACAddress2()
        'lblSiteHeader.Text = Request.ServerVariables("REMOTE_HOST") ' GetMACAddress2()
        'SiteCode = GetUUID()
        'SiteCode = Site
        'lblSiteHeader.Text = String.Concat(Request.UserHostAddress, " ", System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName)

        lblUserFooter.Text = UserCode

        lblToday.Text = cDataType.fDate.Current.ToString("dddd, dd MMMM yyyy")
        lblLastUpdated.Text = String.Concat("Last Updated : ", cDataType.fDate.Current.ToString("dd MMM yyyy"))
        If Not IsPostBack Then
            If Session("ini") = "Y" Then
                Session("ini") = "N"
                RaiseEvent CheckDefaultTag(Me, EventArgs.Empty)
            End If
        End If

        If Session("script") IsNot Nothing Then
            Dim script As String = Session("script")
            Session("script") = Nothing
            Page.ClientScript.RegisterStartupScript(Me.GetType, "", script, True)
        End If

    End Sub

#End Region

#Region "Button"

    Private Sub btnMessageOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessageOk.Click
       
    End Sub

    Private Sub btnToDoClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToDosClose.Click
        Call ClearSession()
        mpeToDos.Hide()
    End Sub

#End Region

#Region "LinkButton"

    Private Sub lnkContactUsFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkContactUsFooter.Click

    End Sub

    Private Sub lnkContactUsHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkContactUsHeader.Click

    End Sub

    Private Sub lnkHomeFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHomeFooter.Click
        Response.Redirect(ePage.Home, False)
    End Sub

    Private Sub lnkHomeHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkHomeHeader.Click
        Response.Redirect(ePage.Home, False)
    End Sub

    Private Sub lnkLogoutFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogoutFooter.Click
        Session.Abandon()
        Session.RemoveAll()
        Response.Redirect(ePage.Login, False)
    End Sub

    Private Sub lnkLogoutHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogoutHeader.Click
        Session.Abandon()
        Session.RemoveAll()
        Response.Redirect(ePage.Login, False)
    End Sub

    Private Sub lnkToDosHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkToDosHeader.Click
        Call ListToDo()
    End Sub

    Private Sub lnkToDosFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkToDosFooter.Click
        Call ListToDo()
    End Sub

    Protected Sub lnkChangePassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkChangePassword.Click
        Response.Redirect(ePage.ChangePassword, False)
    End Sub

#End Region

#End Region

#Region "Custom Method"

#Region "Sub"

    Private Sub AddAttributes()
        ' ------------------------------------------------------------------------------- 
        Call SetButtonPostBack(btnMessageOk)
    End Sub

    Private Sub ClearDropDownList(ByVal pDropDownList As DropDownList, ByVal pText As String, ByVal pValue As String)
        With pDropDownList
            .Items.Clear()
            .Items.Insert(0, New ListItem(pText, pValue))
        End With
    End Sub

    Private Sub ClearSession()
        Session("ism") = Nothing
        Session("msg") = Nothing
        Session("sgn") = Nothing
        Session("mdl") = Nothing
    End Sub

    Private Sub ListToDo()
        RaiseEvent LoadCheckTagging(Me, EventArgs.Empty)

        mpeToDos.Show()
        Me.Page.SetFocus(btnToDosClose)
    End Sub

    Private Sub InitializeTabIndex()

    End Sub

    Private Sub SetButtonPostBack(ByVal pButton As Button)
        pButton.Attributes.Add("onclick", " this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(pButton, Nothing) + ";")
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

    Private Sub SetDropDownList(ByVal pDropDownList As DropDownList, ByVal pDataSource As DataTable, ByVal pDataTextField As String, _
        ByVal pDataValueField As String, ByVal pNewDataTextField As String, ByVal pNewDataValueField As String)

        With pDropDownList
            .Items.Clear()
            .Items.Insert(0, New ListItem(pNewDataTextField, pNewDataValueField))
            .AppendDataBoundItems = True
            If pDataSource.Rows.Count > 0 Then
                .DataTextField = pDataTextField
                .DataValueField = pDataValueField
            End If
            .DataSource = IIf(pDataSource.Rows.Count = 0, Nothing, pDataSource)
            .DataBind()
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

    Private Sub SetFocusBlur(ByVal pTextBox As TextBox, ByVal pFocus As String, ByVal pBlur As String)
        pTextBox.Attributes.Add("onfocus", "DoFocus(this, '" & pFocus & "');")
        pTextBox.Attributes.Add("onblur", "DoBlur(this, '" & pBlur & "');")
    End Sub

    Private Sub SetFocusEnterKey(ByVal pTextbox As TextBox, ByVal pSetFocusTextBox As Object)
        pTextbox.Attributes.Add("onkeypress", "if (event.keyCode == 13){document.getElementById('" + pSetFocusTextBox.ClientID + "').focus()};")
    End Sub

    Private Sub SetModalSession(ByVal pModal As AjaxControlToolkit.ModalPopupExtender, ByVal pShow As Boolean, ByVal pSetFocus As Object)
        Session("mdl") = IIf(pShow, pModal.ID, Nothing)
        If pShow Then
            pModal.Show()
        Else
            pModal.Hide()
        End If
        Me.Page.SetFocus(pSetFocus)
    End Sub

    Private Sub ShowMessageBox(ByVal pMessage As String, ByVal pMessageType As String)
        lblMessage.Text = pMessage
        imgMessage.ImageUrl = pMessageType
        Call SetModalSession(mpeMessage, True, btnMessageOk)
    End Sub

    Public Sub ClearMessage()
        Session("ism") = Nothing
        Session("msg") = Nothing
        Session("sgn") = Nothing
    End Sub

#End Region

#Region "Function"

    Function GetMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    Public Function GetMACAddress2() As String
        Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        Dim MACAddress As String = [String].Empty
        For Each mo As ManagementObject In moc
            If MACAddress = [String].Empty Then
                If CBool(mo("IPEnabled")) = True Then
                    MACAddress = mo("MacAddress").ToString()
                End If
            End If
            mo.Dispose()
        Next

        MACAddress = MACAddress.Replace(":", "")
        Return MACAddress
    End Function

    Public Function GetUUID() As String
        Dim procStartInfo As ProcessStartInfo = New ProcessStartInfo("cmd", "/c " + "wmic csproduct get UUID") With {
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True}


        Dim proc As Process = New Process() With {.StartInfo = procStartInfo}
        proc.Start()

        Debug.Print(proc.StandardOutput.ReadToEnd().Replace("UUID", String.Empty).Trim().ToUpper())
        Return 6001879
    End Function

#End Region

#End Region

End Class