#Region "Description"
' PAGE NAME     : Payment Premium Related Interface
' CREATED BY    : EJ 
' CREATED DATE  : 11/13/2024
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Payment

    Public Interface IPaymentAckReceipt
        Inherits IPaymentTypeDetails

#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        Property ReceiptByCode As String
        Property ReceiptById As Long
        Property ReservedDocNo As Long
        Property DocPrinted As Boolean
        Property DocSaveState As Integer
        Property IsSuccessful As Boolean
        '--------------------------------------------------------
        Property IsInvoiceNoExisting As Boolean
        Property IsARNoExisting As Boolean
        Property AckReceiptID As Long
        Property ReferenceNo As String
        Property PayorName As String
        Property PayorAddress As String
        Property PayorTIN As String
        Property InsuredClientName As String
        Property PolicyNumber As String
        Property CoveragePeriodFrom As Date
        Property CoveragePeriodTo As Date
        Property InvoiceCurrency As String
        Property InvoiceAmount As Decimal
        Property TotalSales As Decimal
        Property WitholdingTax As Decimal
        Property NetOfWitholdingTax As Decimal
        Property Discount As Decimal
        Property DiscountIdNo As String
        Property PaymentTerm As String
        Property NextDueDate As Date
        Property AgentName As String
        Property AgentCode As String
        Property AckReceiptRemarks As String
        Property CancellationReason As String
        Property AckReceiptOtherInfo As String
        Property SourceType As String
        Property InvoiceNumber As Long
        Property InvoiceDate As Date
        Property SIPrintStatus As String
        Property SISourcetype As String
        '--------------------------------------------------------
        Property AckReceiptNumber As Long
        Property ARDate As Date
        Property IsGrossAmountLocked As Boolean
        Property IsWTaxLocked As Boolean
        Property IsDiscountLocked As Boolean
        Property IsCommLocked As Boolean
        Property ARPrintStatus As String
        Property PaymentType As String
        Property Particulars As String
        Property lstSIDetails As List(Of cSIDetails)
        '--------------------------------------------------------
        Property ViewARFrom As Date
        Property ViewARTo As Date
        Property ViewARNumber As Long
        Property ViewARBySINo As Long
        Property ViewSIFrom As Date
        Property ViewSITo As Date
        Property ViewSINumber As Long
        Property ViewSIReferenceNumber As String
        Property IsSourceSiteLocked As Boolean
        Property SourceSite As String
        Property GroupTag As Boolean
        WriteOnly Property dtViewAR As DataTable
        WriteOnly Property dtViewSI As DataTable
        WriteOnly Property dtSourceSite As DataTable
        WriteOnly Property dtCurrency As DataTable
#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenInfo As EventHandler(Of EventArgs)
        Event ClearScreenViewAR As EventHandler(Of EventArgs)
        Event ClearScreenViewSI As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadViewAR As EventHandler(Of EventArgs)
        Event LoadViewSI As EventHandler(Of EventArgs)
        Event LoadSourceSite As EventHandler(Of EventArgs)
        Event LoadCurrency As EventHandler(Of EventArgs)
        Event LoadNewAckReceipt As EventHandler(Of EventArgs)
        Event LoadAckReceipt As EventHandler(Of EventArgs)
        Event LoadSalesInvoice As EventHandler(Of EventArgs)
        Event LoadCancellationReason As EventHandler(Of EventArgs)
        Event CheckSourceSite As EventHandler(Of EventArgs)
        Event ProcessAcKReceipt As EventHandler(Of EventArgs)
        Event ConfirmCancel As EventHandler(Of EventArgs)
        Event ConfirmSave As EventHandler(Of EventArgs)
        Event ConfirmPrint As EventHandler(Of EventArgs)
        Event GenerateReport As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub radSelectAR(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectSI(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Interface

End Namespace