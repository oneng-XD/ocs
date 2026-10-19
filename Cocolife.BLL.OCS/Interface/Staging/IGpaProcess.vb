#Region "Description"
' PAGE NAME     : STG_PA_MASTER Interface  
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

    Public Interface IGpaProcess

#Region "Variables"

#End Region

#Region "Properties"
        Property PolicyNumber As String                 '
        Property PACardID As String                     '
        Property BirthDate As Date                      '
        Property Premium As Decimal                      '
        Property CoverageAmount As Decimal               '
        Property CoverageTerm As Integer                '
        Property Agent1ID As Integer                    '
        Property Agent2ID As Integer                    '
        Property UsdID As Integer                       '
        Property Usd2ID As Integer                      '
        Property AsdID As Integer                       '
        Property Remarks As String                      '
        Property Status As String                       '
        Property CommWithdrawn As Integer               '
        Property CommwithAmt As Decimal                  '
        Property DocType As String                      '
        Property DocNumber As Long                      '
        Property DocDate As Date                        '
        Property InsuredId As Long                      '
        Property PayorId As Long                        '
        Property TransCode As Long                      '
        Property UserId As Long                         '
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

