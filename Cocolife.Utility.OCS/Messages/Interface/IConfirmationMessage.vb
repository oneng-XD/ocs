#Region "Description"
' PAGE NAME     :  
' CREATED BY    : 
' CREATED DATE  : 
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Messages

    Public Interface IConfirmationMessage

#Region "Variables"

#End Region

#Region "Properties"
        Property ConfirmCaller As String
        Property ClickedState As Boolean
        Property UserResponse As Boolean
        WriteOnly Property Message As String
        WriteOnly Property isMessage As Boolean
#End Region

#Region "Events"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

