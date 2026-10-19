#Region "Description"
' PAGE NAME     : Change Password
' CREATED BY    : MPRO
' CREATED DATE  : 11/26/2013
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports eAppType = Cocolife.Utility.Common.Enums.SystemType.ApplicationType
Imports ePage = Cocolife.Utility.OCS.Enums.ePage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports bllSecurity = Cocolife.BLL.Common.Security
#End Region

Partial Public Class ChangePassword
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
    Implements preSecurity.IChangePassword
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
    Private pChangePassword As preSecurity.PChangePassword
    ' ------------------------------------------------------------------------------- 
    Private mIsChangeSuccess As Boolean
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
            End If
        End Set
    End Property

#End Region

#Region "Event"

#End Region

#End Region

#Region "IChangePassword"

#Region "Property"

    Public Property UserID() As String Implements preSecurity.IChangePassword.UserID
        Get
            Return Master.UserCode
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public ReadOnly Property ApplicationType() As eAppType Implements preSecurity.IChangePassword.ApplicationType
        Get
            Return eAppType.WebCollection
        End Get
    End Property

    Public Property OldPassword() As String Implements preSecurity.IChangePassword.OldPassword
        Get
            Return txtOldPassword.Text.Trim
        End Get
        Set(ByVal value As String)
            txtOldPassword.Text = value
        End Set
    End Property

    Public Property NewPassword() As String Implements preSecurity.IChangePassword.NewPassword
        Get
            Return txtNewPassword.Text.Trim
        End Get
        Set(ByVal value As String)
            txtNewPassword.Text = value
        End Set
    End Property

    Public Property ConfirmNewPassword() As String Implements preSecurity.IChangePassword.ReTypeNewPassword
        Get
            Return txtConfirmNewPassword.Text.Trim
        End Get
        Set(ByVal value As String)
            txtConfirmNewPassword.Text = value
        End Set
    End Property

    Public WriteOnly Property Disclaimer() As String Implements preSecurity.IChangePassword.Disclaimer
        Set(ByVal value As String)
            lblPasswordCondition.Text = value
        End Set
    End Property

    Public WriteOnly Property IsNewPasswordValid() As Boolean Implements preSecurity.IChangePassword.isNewPasswordValid
        Set(ByVal value As Boolean)
            If Not value Then
                Call ShowMessageBox("Invalid new password.", eSystemMessage.Warning)
            End If
        End Set
    End Property

    Public WriteOnly Property IsOldPasswordValid() As Boolean Implements preSecurity.IChangePassword.isOldPasswordValid
        Set(ByVal value As Boolean)
            If Not value Then
                Call ShowMessageBox("Invalid old password.", eSystemMessage.Warning)
            End If
        End Set
    End Property

    Public WriteOnly Property IsChangeSuccess() As Boolean Implements preSecurity.IChangePassword.isChangeSuccess
        Set(ByVal value As Boolean)
            mIsChangeSuccess = value
        End Set
    End Property

#End Region

#Region "Event"
    Public Event ChangePassword(ByVal sender As Object, ByVal e As System.EventArgs) Implements preSecurity.IChangePassword.ChangePassword
    Public Event Clear(ByVal sender As Object, ByVal e As System.EventArgs) Implements preSecurity.IChangePassword.Clear
#End Region

#End Region

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub ChangePassword_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
        pChangePassword = New preSecurity.PChangePassword(Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call AddAttributes()
            Call ClearFields()
        End If

    End Sub

#End Region

#Region "Function"

#End Region

#Region "Sub"

    Private Sub AddAttributes()
        Call SetFocusBlur(txtOldPassword, "txtInputShortFocus", "txtInputShort")
        Call SetFocusBlur(txtNewPassword, "txtInputShortFocus", "txtInputShort")
        Call SetFocusBlur(txtConfirmNewPassword, "txtInputShortFocus", "txtInputShort")
        ' ------------------------------------------------------------------------------- 
        Call SetButtonPostBack(btnCancel)
        'Call SetButtonPostBack(btnMessageOk)
        Call SetButtonPostBack(btnSave)
    End Sub

    Private Sub ClearFields()
        RaiseEvent Clear(Me, EventArgs.Empty)
        Call ClearSession()
        txtUserFullname.Text = Master.UserName
        Me.Page.SetFocus(txtOldPassword)
    End Sub

    Private Sub ClearSession()
        Session("ism") = Nothing
        Session("msg") = Nothing
        Session("sgn") = Nothing
        Session("mdl") = Nothing
    End Sub

    Private Sub SetButtonPostBack(ByVal pButton As Button)
        pButton.Attributes.Add("OnClick", "if(this.value === 'Processing...') { return false; } else { this.value = 'Processing...';  this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(pButton, Nothing) + ";}")
    End Sub

    Private Sub SetFocusBlur(ByVal pTextBox As TextBox, ByVal pFocus As String, ByVal pBlur As String)
        pTextBox.Attributes.Add("onfocus", "DoFocus(this, '" & pFocus & "');")
        pTextBox.Attributes.Add("onblur", "DoBlur(this, '" & pBlur & "');")
    End Sub

    Private Sub ShowMessageBox(ByVal pMessage As String, ByVal pMessageType As String)
        lblMessage.Text = pMessage
        imgMessage.ImageUrl = pMessageType
        mpeMessage.Show()
        Me.Page.SetFocus(btnMessageOk)
    End Sub

#End Region

#Region "Button"

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call ClearFields()
    End Sub

    Private Sub btnMessageOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessageOk.Click
        mpeMessage.Hide()
        Select Case Session("mdl")
            Case "LOGOUT"
                Session.Abandon()
                Session.RemoveAll()
                Response.Redirect(ePage.Login, False)
            Case Else
                Me.Page.SetFocus(txtOldPassword)
        End Select
        Call ClearSession()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        RaiseEvent ChangePassword(Me, EventArgs.Empty)
        If mIsChangeSuccess Then
            Call ClearSession()
            Session("mdl") = "LOGOUT"
            Call ShowMessageBox("Your password has been changed!<br /><br />You will be logged out to verify your new password.", eSystemMessage.Information)
        Else
            Me.Page.SetFocus(btnMessageOk)
        End If
    End Sub

#End Region

#End Region

End Class