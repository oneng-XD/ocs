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

    Public Interface IMaintOfficialReceipt

#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property RoleCode As String
        Property IsSuccessful As Boolean
        ' -------------------------------------------------------------------------------
        Property SeriesPrspid As Long
        Property SeriesEditId As Long
        Property SeriesCount As Decimal
        Property SeriesPrefix As Long
        Property SeriesStart As Decimal
        Property SeriesEnd As Decimal
        Property SeriesStatus As Integer
        ' -------------------------------------------------------------------------------
        WriteOnly Property dtStatus As DataTable
        WriteOnly Property dtSeriesList As DataTable
        WriteOnly Property dtSiteList As DataTable

#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenSeries As EventHandler(Of EventArgs)
        Event ClearScreenList As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadStatus As EventHandler(Of EventArgs)
        Event LoadSeriesList As EventHandler(Of EventArgs)
        Event LoadSiteList As EventHandler(Of EventArgs)
        Event ConfirmSave As EventHandler(Of EventArgs)
        Event Add1000 As EventHandler(Of EventArgs)
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

