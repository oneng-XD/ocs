#Region "Description"
' PAGE NAME     : SITE_OPRINFO Interface  
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

    Public Interface ISiteOPRInfo

#Region "Variables"

#End Region

#Region "Properties"
        Property Id As Long
        Property OPRNmbr As Long            ' 
        Property InsLName As String         ' 
        Property InsFName As String         ' 
        Property InsMI As String            ' 
        Property InsBDay As Date            ' 
        Property OwnrLName As String        ' 
        Property InsSfx As String
        Property InsSex As String
        Property InsTit As String
        Property InsPlc As String
        Property OwnrFName As String        ' 
        Property OwnrMI As String           ' 
        Property OwnrBDay As Date           ' 
        Property OwnrSfx As String
        Property OwnrSex As String
        Property OwnrTit As String
        Property OwnrPlc As String
        Property ApplNo As Long             ' 
        Property AplNoPTag As Integer       ' 
        Property PremAmt As Decimal          ' 
        Property ECRNmbr As Long            ' 
        Property ECRDate As Date            ' 
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
