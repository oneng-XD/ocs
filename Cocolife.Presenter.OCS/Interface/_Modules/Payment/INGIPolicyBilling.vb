#Region "Description"
' PAGE NAME     : NGI Policy Billing Interface 
' CREATED BY    : EJ
' CREATED DATE  : 
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface INGIPolicyBilling

#Region "Variables"

#End Region

#Region "Properties"
        Property IsBillNoExist() As Boolean
        Property BillNo() As String
        Property SubsNo() As String
#End Region

#Region "Events"
        Event ClearScreenBillNo As EventHandler(Of EventArgs)
        Event ClearScreenSubsNo As EventHandler(Of EventArgs)
        Event LoadPolicyBilling As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

