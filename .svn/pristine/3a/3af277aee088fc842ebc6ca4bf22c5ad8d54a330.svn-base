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

    Public Interface IPaymentSalesInvoice

#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property DocType As String
        Property ReceiptByCode As String
        Property ReceiptById As Long
        Property ReservedDocNo As Long
        Property DocPrinted As Boolean
        Property DocSaveState As Integer
        Property IsSuccessful As Boolean
        '--------------------------------------------------------
        Property IsReferenceNoExisting As Boolean
        Property SalesInvoiceID As Long
        Property UploadTag As String
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
        Property VATable As Decimal
        Property VATExempt As Decimal
        Property VATAmount As Decimal
        Property NonVAT As Decimal
        Property TotalSales As Decimal
        Property WitholdingTax As Decimal
        Property NetOfWitholdingTax As Decimal
        Property Discount As Decimal
        Property DiscountIdNo As String
        Property PaymentTerm As String
        Property NextDueDate As Date
        Property AgentName As String
        Property AgentCode As String
        Property InvoiceRemarks As String
        Property CancellationReason As String
        Property InvoiceOtherInfo As String
        Property InvoiceNumber As Long
        Property InvoiceDate As Date
        Property SIPrintStatus As String
        Property AckReceiptNumber As Long
        Property ARDate As Date
        Property ARPrintStatus As String
        Property UploadDate As Date
        Property IsFromNewgenAPI As Boolean
        Property ParticularsRaw As String

        WriteOnly Property lstSIDetails As List(Of cSIDetails)
        '--------------------------------------------------------
        Property ViewDocFrom As Date
        Property ViewDocTo As Date
        Property ViewDocNumber As Long
        Property ViewReferenceNumber As String
        Property IsSourceSiteLocked As Boolean
        Property SourceSite As String
        Property GroupTag As Boolean
        WriteOnly Property dtViewDoc As DataTable
        WriteOnly Property dtSourceSite As DataTable
        WriteOnly Property dtCurrency As DataTable
#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenInfo As EventHandler(Of EventArgs)
        Event ClearScreenViewDoc As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadViewDoc As EventHandler(Of EventArgs)
        Event LoadSourceSite As EventHandler(Of EventArgs)
        Event LoadCurrency As EventHandler(Of EventArgs)
        Event LoadNewSalesInvoice As EventHandler(Of EventArgs)
        Event LoadSalesInvoice As EventHandler(Of EventArgs)
        Event CheckSourceSite As EventHandler(Of EventArgs)
        Event ProcessSalesInvoice As EventHandler(Of EventArgs)
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
        Sub radSelectDoc(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Interface

End Namespace