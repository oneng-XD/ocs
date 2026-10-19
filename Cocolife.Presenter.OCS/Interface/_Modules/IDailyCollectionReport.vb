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

Namespace Payment

    Public Interface IDailyCollectionReport

#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property RoleCode As String
        Property IsSuccessful As Boolean
        ' -------------------------------------------------------------------------------
        Property DcrStartDate As Date
        Property DcrEndDate As Date
        Property DcrDocType As String
        'Property DcrRecordType As String
        Property DcrCurcod As String
        ' -------------------------------------------------------------------------------
        'Property PostDate As Date
        WriteOnly Property dtDcrType As DataTable
        'WriteOnly Property dtRecordType As DataTable
        WriteOnly Property dtCurcod As DataTable

#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenDCR As EventHandler(Of EventArgs)
        'Event ClearScreenPosting As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        'Event ConfirmPosting As EventHandler(Of EventArgs)
        Event LoadDcrType As EventHandler(Of EventArgs)
        'Event LoadRecordType As EventHandler(Of EventArgs)
        Event LoadCurcod As EventHandler(Of EventArgs)
        'Event LoadPostDate As EventHandler(Of EventArgs)
        Event GenerateReport As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

