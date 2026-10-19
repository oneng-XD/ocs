#Region "Description"
' PAGE NAME     : HMO PAYSLIP Interface 
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

Namespace Staging

    Public Interface IDebitCredit

#Region "Properties"
        Property DMCMTransNo As String
        Property DMCMNo As Long
        Property DebitCreditID As Long
        Property MemoType As String
        Property BillingType As String
        Property Approver As String
        Property DMCMDate As Date
        Property RenewalDate As Date
        Property EffectivityDate As Date
        Property ExpiryDate As Date
        Property BillPeriodFrom As Date
        Property BillStatementDate As Date
        Property BillPeriodTo As Date
        Property Quantity As Long
        Property UnitPrice As Decimal
        Property TotalAmount As Decimal
        Property Particulars As String
        Property SISourcetype As String
        Property Status As String
        Property Remarks As String
        Property Reason As String
        Property VatSales As Decimal
        Property VatExemptSales As Decimal
        Property VatAmount As Decimal
        Property NonVatSales As Decimal
        Property TotalSales As Decimal
        Property WTax As Decimal
        Property NetWTax As Decimal
        Property Discount As Decimal
        Property DiscountID As String
        Property RoleCode As String
        Property SiteCode As Long
        Property SINumber As Long
        Property PostedBy As String
        Property IsRecordExist() As Boolean
        Property PolicyNumber As String
        Property Payor As String
        Property Tin As String
        Property Address As String
        Property ReferenceNo As String
        Property BillStatNo As String
        Property PaymentTerm As String
        Property SiteAddr As String
        Property SiteTin As String
        Property SiteTelNo As String
        Property SiteName As String
        Property PreparedBy As String
        Property InvoiceDate As Date
        Property PrintCounter As Long
#End Region

#Region "Single Point Functions"
        Function LoadViewDMCM(pPrspid As Long, pRoleCode As String, pDocNumber As Long, pTransID As String, pType As Integer) As DataTable
        Function LoadViewDMCM(pPrspid As Long, pRoleCode As String, Optional pStartDate As Date? = Nothing, Optional pEndDate As Date? = Nothing) As DataTable
        Function LoadViewDMCM(pPrspid As Long, pRoleCode As String, pType As Integer, pDocNumber As Long, pStartDate As Date, pEndDate As Date) As DataTable
        Function GetApprover(pRoleCode As String) As DataTable

#End Region

#Region "Transaction"
        Sub SearchDebitCreditMemo(ByVal pDocNo As Long, ByVal pUsedId As Long)
        Sub SearchTaxAmount(ByVal pBillNumber As String, ByVal pAmount As Decimal, ByVal pQuantity As Long)


#End Region
    End Interface
End Namespace
