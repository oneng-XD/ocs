#Region "Description"
' PAGE NAME     : STG_OPRDEBIT Interface
' CREATED BY    : MPRO
' CREATED DATE  : 05/04/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Staging

    Public Interface IStgOPRDebit

#Region "Variables"

#End Region

#Region "Properties"
        Property OPRNmbr As Long                ' 1
        Property BankNetwork As String          ' 2
        Property BankName As String             ' 3
        Property CASAType As String             ' 4
        Property AcctNo As String               ' 5
        Property Remarks As String              ' 6
        Property Amount As Decimal               ' 7
        Property TerminalID As String           ' 8
        Property MerchantID As String           ' 9
        Property SwipeDate As Date              ' 10
        Property ChargeSlipCode As String       ' 11
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
