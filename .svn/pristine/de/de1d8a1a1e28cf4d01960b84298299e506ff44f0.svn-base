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

Namespace Maintenance

    Public Interface IMaintAgentsORSeries

#Region "Variables"

#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SiteCode() As Long
        Property UserID() As Long
        ' ------------------------------------------------------------------------------- 
        Property SeriesEditId() As String
        Property SeriesAgent() As Long
        Property SeriesRegNum() As String
        Property SeriesOldRegNum() As String
        Property SeriesRegDate() As Date
        Property SeriesOldRegDate() As Date
        Property SeriesStart() As Decimal
        Property SeriesEnd() As Decimal
        Property SeriesExpDate() As Date
        Property LastUpdate() As Date

        Property AgentOrSeries() As Object
#End Region

#Region "Single Point Functions"
        Function LoadSeriesList(pAgentId As Long) As DataTable
#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub SaveSeries()
#End Region

    End Interface

End Namespace