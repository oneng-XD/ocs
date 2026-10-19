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

    Public Interface IPaymentAckReceipt

#Region "Variables"

#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        Property SiteCode() As Long
        Property UserID() As Long
        Property AckReceipt() As Staging.BAckReceipt
        Property ARPayDetails() As IList(Of Staging.BARPayDetails)
        Property ReservedDocNo() As Long
        Property lstForDeletion As IList(Of Object)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub ProcessPaymentAckReceipt()
        Sub PrintPaymentAckReceipt()
        Sub CancelPaymentAckReceipt()
#End Region

    End Interface

End Namespace