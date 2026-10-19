#Region "Description"
' PAGE NAME     : Payment Check Tagging
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

    Public Interface IPaymentCheckTagging
        Inherits IChkDetails

#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property RoleCode As String
        Property IsSuccessful As Boolean
        Property TaggingType As String
        ' -------------------------------------------------------------------------------
        Property TaggingEditId As Long
        Property ReceiptNo As Long
        Property TaggingDepositDate As Date
        Property TaggingClearingDate As Date
        Property TaggingClearingStatusId As Integer
        'Property TaggingRemarks As String
        ReadOnly Property TaggingCheckList As List(Of cCheckTagging)
        Property SearchFromDate As Date
        Property SearchToDate As Date
        Property SearchReceiptNumber As Long
        Property SearchCheckNumber As Long
        ' -------------------------------------------------------------------------------
        WriteOnly Property dtTransactionType As DataTable
        WriteOnly Property dtStatus As DataTable
        WriteOnly Property dtCheckList As DataTable

#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenTagging As EventHandler(Of EventArgs)
        Event ClearScreenSearch As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadTransactionType As EventHandler(Of EventArgs)
        Event LoadStatus As EventHandler(Of EventArgs)
        Event LoadForDeposit As EventHandler(Of EventArgs)
        Event LoadForClearing As EventHandler(Of EventArgs)
        Event LoadForReDeposit As EventHandler(Of EventArgs)
        Event ConfirmSave As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event ProcessTagging As EventHandler(Of EventArgs)

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

