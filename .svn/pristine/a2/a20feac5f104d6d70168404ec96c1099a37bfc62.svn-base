#Region "Description"
' PAGE NAME     : Payment Debit Credit Memo Approval Interface
' CREATED BY    : Junie
' CREATED DATE  : 04/10/2025
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes

#End Region
Namespace Payment
    Public Interface IPaymentDMCMApproval

#Region "Variables"

#End Region

#Region "Properties"

        WriteOnly Property dtViewDMCM As DataTable
        Property ViewDMCMFrom As Date
        Property ViewDMCMTo As Date

        Property ViewDMCMBySINo As Long
        Property ViewDMCMByTransID As String
        Property IsButtonSearch As Boolean


        ReadOnly Property SiteCode As Long
        ReadOnly Property ApproverRoleCode As String
        ReadOnly Property UserID As Long

        Property IsInvoiceNoExisting As Boolean

        Property DMCMApproverID As String
        Property ReceiptByCode As String
        Property DocSaveState As Integer
        Property DMCMTransNo As String
        Property DMCMNumber As Long
        Property MemoType As String
        Property BillingType As String
        Property ReservedDMCMID As Long
        Property DebitCreditID As Long

        Property TotalAmount As Decimal
        Property UnitPrice As Decimal
        Property Particulars As String
        Property SISourcetype As String
        Property Quantity As Long
        Property DiscountID As String
        Property Remarks As String
        Property DMCMRoleCode As String
        Property DMCMPostedBy As String




        Property IsSuccessful As Boolean
        Property IsTransIDExisting As Boolean 'can be dmcm no

        Property Status As String
        Property Mode As String

        Property Reason As String

        Property VATable As Decimal
        Property VATExempt As Decimal
        Property VATAmount As Decimal
        Property NonVAT As Decimal
        Property TotalSales As Decimal
        Property WitholdingTax As Decimal
        Property NetOfWitholdingTax As Decimal
        Property Discount As Decimal

        Property InvoiceNumber As Long
        Property InvoiceDate As Date
        Property DMCMDate As Date
        Property ReferenceNo As String
        Property BillStatNo As String
        Property PayorName As String
        Property PayorAddress As String
        Property PayorTIN As String
        Property PolicyNumber As String
        Property PreparedBy As String
        Property OfficeName As String
        Property OfficeContact As String
        Property OfficeAddr As String
        Property OfficeTin As String
        Property EffectivityFrom As Date
        Property EffectivityTo As Date
        Property RenewalDate As Date
        Property BillStatementDate As Date
        Property BillPeriodFrom As Date
        Property BillPeriodTo As Date
#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event LoadViewDMCM As EventHandler(Of EventArgs)
        Event LoadDebitCreditMemo As EventHandler(Of EventArgs)
        Event ConfirmApprove As EventHandler(Of EventArgs)
        Event ConfirmReject As EventHandler(Of EventArgs)
        Event ProcessDebitCreditMemo As EventHandler(Of EventArgs)
#End Region

#Region "Transactions"
        Sub radSelectDMCM(ByVal sender As Object, ByVal e As EventArgs)
#End Region














    End Interface
End Namespace
