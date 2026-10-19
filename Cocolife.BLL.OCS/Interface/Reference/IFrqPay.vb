#Region "Description"
' PAGE NAME     : FRQPAY BLL Interface
' CREATED BY    : MPRO
' CREATED DATE  : 11/20/2014
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Reference

    Public Interface IFrqPay

#Region "Variables"

#End Region

#Region "Properties"
        Property FrqCod As Integer          ' 
        Property FrqDes As String           ' 
        Property FrqPre As Decimal           ' 
        Property FrqFee As Decimal           ' 
        Property FrqTol As Decimal           ' 
        Property VolDis As Decimal           ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Function GetRefFrqPayList() As DataTable
#End Region

    End Interface

End Namespace
