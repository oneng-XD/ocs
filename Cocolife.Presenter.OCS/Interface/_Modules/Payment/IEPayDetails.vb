#Region "Description"
' PAGE NAME     : ECashPayment Details Interface
' CREATED BY    : EJ
' CREATED DATE  : 04/12/2022
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface IEPayDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property ECashPaymentTag As Boolean
        Property ECashPaymentChannel As String
        Property ECashPaymentReferenceNumber As String
        Property ECashPaymentAmount As Decimal
        Property ECashPaymentRemarks As String
        Property ECashPaymentTotalAmount As Decimal
        WriteOnly Property dtECashPaymentChannel As DataTable
#End Region

#Region "Events"
        Event ClearScreenECashPaymentDetails As EventHandler(Of EventArgs)
        Event LoadECashPaymentChannel As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

