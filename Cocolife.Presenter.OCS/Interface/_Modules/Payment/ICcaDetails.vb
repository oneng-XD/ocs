#Region "Description"
' PAGE NAME     : CCA Details Interface
' CREATED BY    : EJ
' CREATED DATE  : 07/19/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface ICcaDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property CreditCardPaymentTag As Boolean
        Property CreditCardTerminalUse As String
        Property CreditCardSwipeDate As Date
        Property CreditCardSwipeTime As Date
        Property CreditCardMerchant As String
        Property CreditCardNumberTag As Boolean
        Property CreditCardNumber As String
        Property CreditCardType As String
        Property CreditCardTypeDesc As String
        Property CreditCardAmount As Decimal
        Property CreditCardApprovalCode As String
        Property CreditCardBatchNumber As Long
        Property CreditCardRemarks As String
        Property CreditCardTotalAmount As Decimal
#End Region

#Region "Events"
        Event ClearScreenCreditCardDetails As EventHandler(Of EventArgs)
        Event ClearScreenCreditCardNumber As EventHandler(Of EventArgs)
        ' -------------------------------------------------------------------------------
        Event CreditCardFetchData As EventHandler(Of EventArgs)
        Event ValidateCreditCardNo As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

