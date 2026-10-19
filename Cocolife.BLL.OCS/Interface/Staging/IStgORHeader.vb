#Region "Description"
' PAGE NAME     : STG_ORHEADER Interface  
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

    Public Interface IStgORHeader

#Region "Variables"

#End Region

#Region "Properties"
        Property ORNmbr As Long                 ' 
        Property EmplCode As String             ' 
        Property ORDate As Date                 ' 
        Property Remarks As String              ' 
        Property TotalAmt As Decimal             ' 
        Property ChkAmt As Decimal               ' 
        Property PayType As String              ' 
        Property CurrType As String             ' 
        Property SrcBrnch As Long               ' 
        Property PayrID As Long                 ' 
        Property Payor As String                ' 
        Property Acct As String                 ' 
        Property GLCode As String               ' 
        Property Addr As String                 ' 
        Property TIN As String                  ' 
        Property CancelFlag As Integer          ' 
        Property PrtFlag As Integer             ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
