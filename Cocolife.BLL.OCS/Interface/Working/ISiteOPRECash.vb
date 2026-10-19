#Region "Description"
' PAGE NAME     : SITE_OPRECASH Interface
' CREATED BY    : EJ
' CREATED DATE  : 04/13/2022
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Working

    Public Interface ISiteOPRECash

#Region "Variables"

#End Region

#Region "Properties"
        Property Id As Long
        Property OPRNmbr As Long                ' 1
        Property PaymentChannel As String       ' 2
        Property ReferenceNumber As String      ' 3
        Property Amount As Decimal              ' 4
        Property Remarks As String              ' 5
        Property ServiceFeeRate As Decimal      ' 6
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
