#Region "Description"
' PAGE NAME     : GPA DETAILS Interface 
' CREATED BY    : EJ
' CREATED DATE  : 12/27/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Reference

    Public Interface IGpaDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property PolicyNumber() As String
        Property Plan() As String
        Property CardNo() As String
        Property CardSite() As Long
        Property CoverageTerm() As Integer
        Property CoverageAmount() As Decimal
        Property PremiumAmount() As Decimal
        Property DocNumber() As Long
        Property IsRenewable() As Boolean
        Property IsAllowComm() As Boolean
        Property IsAllowCommSharing() As Boolean
        Property IsPromoOff() As Boolean
        ' -------------------------------------------------------------------------------
        Property IsRecordExist() As Boolean
#End Region

#Region "Single Point Functions"
        Function GetGpaPlanList(ByVal pSiteCode As Long, ByVal pSalesForce As String) As DataTable
        Sub GetGpaSettings(ByVal pSalesForce As String, ByVal pCatCod As String)
        Sub GetGpaSettings(ByVal pSalesForce As String, ByVal pCatCod As String, ByVal pGpaPlan As String)
        Sub SearchPaCardId(ByVal pPlan As String, ByVal pNumber As String)
#End Region

#Region "Validations"

#End Region

#Region "Transactions"
       
#End Region

    End Interface

End Namespace


