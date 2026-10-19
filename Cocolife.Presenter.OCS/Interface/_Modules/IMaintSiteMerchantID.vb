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

    Public Interface IMaintSiteMerchantID

#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property RoleCode As String
        Property IsSuccessful As Boolean
        ' -------------------------------------------------------------------------------
        Property MerchantEditID As Long
        Property MerchantID As String
        Property MerchantTerminalType As String
        Property MerchantName As String
        Property MerchantSiteCode As Long
        Property MerchantEffectiveDate As Date
        Property MerchantTermDate As Date
        Property MerchantStatus As Integer
        ' -------------------------------------------------------------------------------
        WriteOnly Property dtStatus As DataTable
        WriteOnly Property dtMerchantList As DataTable
        WriteOnly Property dtSiteList As DataTable
        WriteOnly Property dtTerminalUse As DataTable

#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenDetails As EventHandler(Of EventArgs)
        Event ClearScreenMerchantList As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadStatus As EventHandler(Of EventArgs)
        Event LoadMerchantList As EventHandler(Of EventArgs)
        Event LoadSiteList As EventHandler(Of EventArgs)
        Event LoadTerminalUse As EventHandler(Of EventArgs)
        Event ConfirmSave As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event SaveMerchantId As EventHandler(Of EventArgs)

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

