#Region "Description"
' PAGE NAME     : SERARCH Interface 
' CREATED BY    : EJ
' CREATED DATE  : 08/26/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Search
    Public Interface ISearch
#Region "Variables"

#End Region

#Region "Properties"
        Property PolNum() As String             ' Policy Number
        Property InsNme() As String             ' Insured Name
        Property PayNme() As String             ' Payor Name
        ' -------------------------------------------------------------------------------
        Property IsRecordExist() As Boolean
#End Region

#Region "Single Point Functions"
        Function GetPolicyDetails(ByVal pPolNum As String, ByVal pPolType As String) As DataTable
        Function GetNBPolicyNewgen(ByVal pPolNo As String, ByVal pApplicationNo As String) As DataTable
#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Function SearchPolicy(ByVal pPolNum As String, ByVal pInsNme As String, ByVal pPayNme As String, ByVal pPolTyp As String) As DataTable
#End Region

    End Interface

End Namespace
