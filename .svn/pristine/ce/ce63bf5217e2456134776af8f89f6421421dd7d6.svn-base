#Region "Description"
' PAGE NAME     : Payment Posting Interface
' CREATED BY    : EJ
' CREATED DATE  : 03/19/2017
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Maintenance

    Public Interface IMaintAgentsORSeries

#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property RoleCode As String
        Property IsSuccessful As Boolean
        Property IsSeriesTemp As Boolean
        ' -------------------------------------------------------------------------------
        Property SeriesAgent As Long
        Property SeriesEditId As String
        Property SeriesRegNumber As String
        Property SeriesRegDate As Date
        Property SeriesOldRegNumber As String
        Property SeriesOldRegDate As Date
        Property SeriesStart As Decimal
        Property SeriesEnd As Decimal
        Property SeriesExpDate As Date
        ' -------------------------------------------------------------------------------
        Property AgentIDTag As Boolean
        ' -------------------------------------------------------------------------------
        WriteOnly Property dtSeriesList As DataTable

#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenSeries As EventHandler(Of EventArgs)
        Event ClearScreenAgent As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadSeriesList As EventHandler(Of EventArgs)
        Event ConfirmSave As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event AddNext As EventHandler(Of EventArgs)
        Event AddTemp As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event SaveSeries As EventHandler(Of EventArgs)

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

