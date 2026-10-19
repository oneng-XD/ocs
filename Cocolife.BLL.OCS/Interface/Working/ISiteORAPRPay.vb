#Region "Description"
' PAGE NAME     : SITE_ORAPRPAY Interface 
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

    Public Interface ISiteORAPRPay

#Region "Variables"

#End Region

#Region "Properties"
        Property Id As Long
        Property ORNmbr As Long             ' 
        Property APRNmbr As Long            ' 
        Property APRDate As Date            ' 
        Property Amount As Decimal           ' 
        Property LineNmbr As Integer        '
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
