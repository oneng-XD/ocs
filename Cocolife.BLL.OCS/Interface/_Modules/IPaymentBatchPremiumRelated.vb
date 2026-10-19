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

    Public Interface IPaymentBatchPremiumRelated

#Region "Variables"

#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SiteCode() As Long
        Property UserID() As Long
        Property ReservedReceiptNumber() As Long
        ' ------------------------------------------------------------------------------- 
        Property SiteOPRHeader() As Working.BSiteOPRHeader
        Property SiteOPRDtl() As IList(Of Working.BSiteOPRDtl)
        Property SiteOPRAPRPy() As IList(Of Working.BSiteOPRAPRPy)
        Property SiteOPRChkPy() As IList(Of Working.BSiteOPRChkPy)
        Property SiteTmpTrn() As IList(Of Working.BSiteTmpTrn)
        Property SiteBatch() As Working.BSiteBatch
        Property SiteBatchDtl() As IList(Of Working.BSiteBatchDtl)
        Property StgOPRHeader() As Staging.BStgOPRHeader
        Property StgOPRDtl() As IList(Of Staging.BStgOPRDtl)
        Property StgOPRAPRPy() As IList(Of Staging.BStgOPRAPRPy)
        Property StgOPRChkPy() As IList(Of Staging.BStgOPRChkPy)
        Property StgTmpTrn() As IList(Of Staging.BStgTmpTrn)
        Property SiteRcptCtr() As Working.BReceiptCounter
        ' ------------------------------------------------------------------------------- 
        Property IsAprTag() As Boolean
        Property lstForDeletion() As IList(Of Object)

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub ProcessPaymentBatchPremiumRelated()
        Sub CopyToStgObjects()
        Sub PostPaymentBatchPremiumRelated()
        Sub CancelPaymentBatchPremiumRelated()
#End Region

    End Interface

End Namespace