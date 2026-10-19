#Region "Description"
' PAGE NAME     : SITE_OPRDEBIT Interface
' CREATED BY    : EJ
' CREATED DATE  : 07/15/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Working

    Public Interface ISiteOPRDebit

#Region "Variables"

#End Region

#Region "Properties"
        Property Id As Long
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
        Property BatchNumber As Long            ' 12
        Property StatusId As Integer
        Property PostBy As Long
        Property PostDate As Date
        Property LastUpdateBy As Long
        Property LastUpdate As Date
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
