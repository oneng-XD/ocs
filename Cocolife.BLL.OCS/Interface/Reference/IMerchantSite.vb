#Region "Description"
' PAGE NAME     : MerchantSite BLL Interface
' CREATED BY    : EJ
' CREATED DATE  : 09/15/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Reference

    Public Interface IMerchantSite

#Region "Variables"

#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SiteCode() As Long
        Property UserID() As Long
        ' ------------------------------------------------------------------------------- 
        Property MerchantEditId() As Long
        Property TerminalId() As String
        Property MerchantId() As String
        Property DbaName() As String
        Property EffDate() As Date
        Property TermDate() As Date
        Property StatusId() As Integer
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Function GetRefMerchantSiteList(ByVal pSiteCode As Long) As DataTable
        Function GetMerchantId(ByVal pSiteCode As Long, ByVal pTerminaluse As String) As String
        Sub SaveMerchantId()
#End Region

    End Interface

End Namespace
