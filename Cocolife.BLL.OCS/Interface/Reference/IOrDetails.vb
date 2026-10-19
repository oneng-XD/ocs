#Region "Description"
' PAGE NAME     :  OR Details Interface (Non-Premium Payments)
' CREATED BY    :  IBP
' CREATED DATE  :  02/13/1997
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region


Namespace Reference

    Public Interface IOrDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property ORNumber As Long
        Property ORDate As Date
        Property ORPosted As Boolean
        Property ORPrinted As Boolean
#End Region

#Region "Single Point Functions"
        Function LoadViewOR(pPrspid As Long, Optional pStartDate As Date? = Nothing, Optional pEndDate As Date? = Nothing) As DataTable
        Function LoadViewOR(pPrspid As Long, pDocNumber As Long) As DataTable
        Function LoadViewOR(pPrspid As Long, pStringParam As String, pParamType As Integer) As DataTable
#End Region

#Region "Validations"
        Function IsNewORAllowed(pNextDocNumber As String) As Boolean
#End Region

#Region "Transactions"
        Sub LoadNewOR(pSiteId As Long, pReceiptType As Integer, pUserId As Long, Optional ByRef pConn As Object = Nothing, Optional ByRef pTrans As Object = Nothing)
#End Region

    End Interface

End Namespace

