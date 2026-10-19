#Region "Description"
' PAGE NAME     : METPAY Interface 
' CREATED BY    : MPRO
' CREATED DATE  : 03/27/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Reference

    Public Interface IMetPay

#Region "Variables"

#End Region

#Region "Properties"
        Property MetCod As String           ' 
        Property MetDes As String           ' 
        Property MetBil As String           ' 
        Property MetLod As Decimal           ' 
        Property Tlrnce As Decimal           ' 
        Property MetAdv As Integer          ' 
        Property PlnMet As String           ' 
        Property CurCor As String           ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

        Function GetRefMetPayList(ByVal pFilter As String, ByVal pPolTyp As String, ByVal pDocTyp As String) As DataTable
#End Region

    End Interface

End Namespace


