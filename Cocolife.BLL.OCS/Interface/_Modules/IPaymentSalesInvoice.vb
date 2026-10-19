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

Namespace Payment

    Public Interface IPaymentSalesInvoice

#Region "Variables"

#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        Property SiteCode() As Long
        Property RoleCode() As String
        Property UserID() As Long
        Property SalesInvoice() As Reference.BSalesInvoice

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub ProcessPaymentSalesInvoice()
        Sub CancelPaymentSalesInvoice()
#End Region

    End Interface

End Namespace