#Region "Description"
' PAGE NAME     : APR Details Interface
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

    Public Interface IAprDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property APRNumber As Long
        Property APRDate As Date
        Property APRAmount As Decimal
#End Region

#Region "Events"
        Event ClearScreenAPRDetails As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

