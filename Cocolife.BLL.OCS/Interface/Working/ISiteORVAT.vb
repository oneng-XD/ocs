#Region "Description"
' PAGE NAME     : SITE_ORVAT Interface  
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

    Public Interface ISiteORVAT

#Region "Variables"

#End Region

#Region "Properties"
        Property Id As Long
        Property ORNmbr As Long                 ' 
        Property GrossAmt As Decimal             '  
        Property VatableColl As Decimal          ' 
        Property NonVatColl As Decimal
        Property VatExemptColl As Decimal        ' 
        Property VatAmt As Decimal               ' 
        Property WTaxAmt As Decimal              ' 
        Property NetAmt As Decimal               ' 
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
