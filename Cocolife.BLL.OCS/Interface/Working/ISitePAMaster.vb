#Region "Description"
' PAGE NAME     : SITE_PA_MASTER Interface  
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

    Public Interface ISitePAMaster

#Region "Variables"

#End Region

#Region "Properties"
        Property Id As Long
        Property PolicyNumber As String
        Property PACardID As String
        Property TransactionID As Long
        Property LastName As String
        Property FirstName As String
        Property MiddleName As String
        Property ORNumber As Long
        Property ORDate As Date
        Property Premium As Decimal
        Property CoverageAmount As Decimal
        Property CoverageTerm As Integer
        Property Agent1 As Integer
        Property Agent1Nam As String
        Property Agent2 As Integer
        Property Agent2Nam As String
        Property USD1 As Integer
        Property USD1Nam As String
        Property USD2 As Integer
        Property USD2Nam As String
        Property ASD As Integer
        Property ASDNam As String
        Property Remarks As String
        Property Status As String
        Property BirthDate As Date
        Property CommissionWithdrawn As Boolean
        Property PayorLastName As String
        Property PayorFirstName As String
        Property PayorMiddleName As String
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

