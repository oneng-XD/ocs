#Region "Description"
' PAGE NAME     : SITE_OPRDTL Interface
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

    Public Interface ISiteBatchDtl

#Region "Variables"

#End Region

#Region "Properties"
        Property Id As Long
        Property BatchId As Long
        Property OprNmbr As Long
        Property OprAmt As Long
        Property PocId As Long
        Property InsuredName As String
        Property PolicyName As String
        Property GrossLife As Long
        Property GrossNonlife As Long
        Property NonlifePremium As Long
        Property DstNonlife As Long
        Property PremTaxNonlife As Long
        Property LocalTaxNonlife As Long
        Property StatusId As Long
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
