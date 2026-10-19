#Region "Description"
' PAGE NAME     : OPR Details Interface
' CREATED BY    : EJ
' CREATED DATE  : 07/19/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Payment

    Public Interface IReceiptDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property ReceiptDetailID As String
        Property ReceiptIndex As Integer
        Property ReceiptTransactionCode As String
        Property ReceiptTransactionType As String
        Property ReceiptTransactionDesc As String
        Property ReceiptTransactionVat As String
        Property ReceiptAmount As Decimal
        Property ReceiptTotalAmount As Decimal
        Property ReceiptCommissionAmount As Decimal
        Property isReceiptSuccessful As Boolean
        Property lstReceiptDetails As List(Of cReceiptDetail)
        'Property dtReceiptTransaction As DataTable
        WriteOnly Property dtReceiptTransaction As DataTable
#End Region

#Region "Events"
        Event LoadReceiptTransaction As EventHandler(Of EventArgs)
        Event GetReceiptTransactionDetails As EventHandler(Of EventArgs)
        Event ClearScreenReceiptDetails As EventHandler(Of EventArgs)
        Event AddReceiptDetails As EventHandler(Of EventArgs)
        Event DeleteReceiptDetails As EventHandler(Of EventArgs)
        Event CheckReceiptTransaction As EventHandler(Of EventArgs)
        'Event GetReceiptDetails As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

