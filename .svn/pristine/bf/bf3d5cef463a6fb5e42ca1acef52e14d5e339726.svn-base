#Region "Description"
' PAGE NAME     : DCA Details Interface
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

    Public Interface IDcaDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property DebitCardPaymentTag As Boolean
        Property DebitCardTerminalUse As String
        Property DebitCardSwipeDate As Date
        Property DebitCardSwipeTime As Date
        Property DebitCardMerchant As String
        Property DebitCardBankNetwork As String
        Property DebitCardBankName As String
        Property DebitCardAccountType As String
        Property DebitCardAccountNumber As String
        Property DebitCardChargeSlip As String
        Property DebitCardAmount As Decimal
        Property DebitCardBatchNumber As Long
        Property DebitCardRemarks As String
        Property DebitCardTotalAmount As Decimal
        WriteOnly Property dtMerchantId As DataTable
        WriteOnly Property dtBankNetwork As DataTable
        WriteOnly Property dtAccountType As DataTable

#End Region

#Region "Events"
        Event ClearScreenDebitCardDetails As EventHandler(Of EventArgs)
        ' -------------------------------------------------------------------------------
        Event LoadDefaultTerminal As EventHandler(Of EventArgs)
        Event LoadMerchantId As EventHandler(Of EventArgs)
        Event LoadBankNetwork As EventHandler(Of EventArgs)
        Event LoadAccountType As EventHandler(Of EventArgs)
        Event DebitCardFetchData As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

