#Region "Description"
' PAGE NAME     : Check Details Interface
' CREATED BY    : EJ
' CREATED DATE  : 07/19/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface IChkDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property CheckPaymentTag As Boolean
        Property CheckNumber As Long
        Property CheckAmount As Decimal
        Property CheckBankName As String
        Property CheckLineNumber As Integer
        Property CheckOTCFlag As Integer
        Property CheckBankBranch As String
        Property CheckTotalAmount As Decimal
        ' -------------------------------------------------------------------------------
        WriteOnly Property dtBankList As DataTable 'IBP 02/28/17
#End Region

#Region "Events"
        Event ClearScreenCheckDetails As EventHandler(Of EventArgs)
        Event LoadBankList As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

