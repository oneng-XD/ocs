

#Region "Description"
' PAGE NAME     : GPA Transaction Interface
' CREATED BY    : EJC
' CREATED DATE  : 03/11/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Common
#End Region

Namespace Payment

    Public Interface IGPATransaction

#Region "Variables"

#End Region

#Region "Properties"
        Property GPAtransactionTag As Boolean
        Property CommissionWithdrawn As Double
        ' -------------------------------------------------------------------------------
        Property SalesOffID As Long
        Property SalesOff As BPerson
        Property PromoOffID As Long
        Property PromoOff As BPerson
        ' -------------------------------------------------------------------------------
        Property PayorID As Long
        Property PayorName As BPerson
        Property InsuredID As Long
        Property InsuredName As BPerson
        ' -------------------------------------------------------------------------------
        Property PAcardID As String

#End Region

#Region "Events"
        Event SetGPAForm As EventHandler(Of EventArgs)
        Event ClearScreenGPA As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

