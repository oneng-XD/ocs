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

Namespace Reference

    Public Interface IOprDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property OPRNumber As Long
        Property OPRDate As Date
        Property OPRPosted As Boolean
        Property OPRPrinted As Boolean
#End Region

#Region "Single Point Functions"
        Function LoadViewOPR(pPrspid As Long, pIsbatch As Boolean, Optional pStartDate As Date? = Nothing, Optional pEndDate As Date? = Nothing) As DataTable
        Function LoadViewOPR(pPrspid As Long, pDocNumber As Long) As DataTable
        Function LoadViewOPR(pPrspid As Long, pStringParam As String, pParamType As Integer) As DataTable
        Function GetNewApplicationNo() As Long
        Function GetCalcODI(pPolicyNumber As String, pTrndat As Date, pPremium As Decimal, pPolType As String) As Decimal
        Function GetBatchOprList(pBatchId As Long) As DataTable
        Function GetPremiumBreakdown(pPolicyNumber As String) As DataTable
#End Region

#Region "Validations"
        Function IsNewOPRAllowed(pNextDocNumber As String) As Boolean
        Function IsOprProcessed(pDocNumber As Long, Optional pDate As Date = Nothing) As Boolean
        'Function IsPostingAllowed(pOprDetails As IOprDetails) As Boolean
#End Region

#Region "Transactions"
        Sub LoadNewOPR(pSiteId As Long, pReceiptType As Integer, pUserId As Long, Optional ByRef pConn As Object = Nothing, Optional ByRef pTrans As Object = Nothing)
        Function LoadNextOPR(pSiteId As Long, pReceiptType As Integer, pUserId As Long) As Long
        'Sub LoadLastOPR(pSiteId As Long, pUserId As Long)
#End Region

    End Interface

End Namespace

