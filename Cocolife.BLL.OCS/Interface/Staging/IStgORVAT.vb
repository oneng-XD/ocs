#Region "Description"
' PAGE NAME     : STG_ORVAT Interface  
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

    Public Interface IStgORVAT

#Region "Variables"

#End Region

#Region "Properties"
        Property ORNmbr As Long                 ' 
        Property GrossAmt As Decimal             '  
        Property VatableColl As Decimal          ' 
        Property VatExemptColl As Decimal        ' 
        Property VatAmt As Decimal               ' 
        Property WTaxAmt As Decimal              ' 
        Property NetAmt As Decimal               ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
