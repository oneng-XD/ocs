
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


    Public Interface IPaymentDebitCreditMemo

#Region "Properties"
        Property IsSuccessful() As Boolean
        Property SiteCode() As Long
        Property UserID() As Long
        Property ReservedDMCMID() As Long
        Property DebitCreditMemo() As Staging.BDebitCredit

    
#End Region

#Region "Transactions"
        Sub ProcessPaymentDebitCreditMemo()
        Sub SendPaymentDebitCreditMemo()
        Sub PrintPaymentDebitCreditMemo()
        'Sub PrintPaymentAckReceipt()
        Sub CancelPaymentDebitCreditMemo()
#End Region



    End Interface
End Namespace