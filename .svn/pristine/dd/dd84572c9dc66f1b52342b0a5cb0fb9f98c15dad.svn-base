#Region "Description"
' PAGE NAME     : Home 
' CREATED BY    : MPRO
' CREATED DATE  : 11/07/2014
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports ePage = Cocolife.Utility.OCS.Enums.ePage

Imports System.Net.NetworkInformation
#End Region

Partial Public Class Home
    Inherits System.Web.UI.Page

#Region "Implements"
    Implements preSecurity.ISystemMessage
#End Region

#Region "Variables"
    Private pSystemMessage As preSecurity.PSystemMessage
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
                Call SetModalSession(mpeMessage, True, btnMessageOk)
            End If
        End Set
    End Property

#End Region

#Region "Event"

#End Region

#End Region

#Region "Event Handlers"

#Region "Page"

    Private Sub Home_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        pSystemMessage = New preSecurity.PSystemMessage(Me)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call AddAttributes()
            Call ClearFields()
            'RaiseEvent LoadViewOPR(Me, EventArgs.Empty)
        End If

    End Sub

#End Region

#Region "Button"

    Private Sub btnMessageOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessageOk.Click
        mpeMessage.Hide()
        Select Case Session("mdl")

        End Select
        Call ClearSession()
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

    Private Sub ClearFields()
        Call ClearSession()
        accORList.SelectedIndex = 0
    End Sub

    Private Sub ClearSession()
        Session("ism") = Nothing
        Session("msg") = Nothing
        Session("sgn") = Nothing
        Session("mdl") = Nothing
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

#End Region

#Region "Function"

#End Region

#End Region

End Class