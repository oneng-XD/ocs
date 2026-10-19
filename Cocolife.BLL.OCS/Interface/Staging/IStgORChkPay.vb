#Region "Description"
' PAGE NAME     : STG_ORCHKPAY Interface  
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

    Public Interface IStgORChkPay

#Region "Variables"

#End Region

#Region "Properties"
        Property ORNmbr As Long             ' 
        Property ChkNmbr As Long            ' 
        Property Bank As String             ' 
        Property Branch As String           ' 
        Property Amount As Decimal           ' 
        Property OTCFlag As Long            ' 
        Property LineNmbr As Long           ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
