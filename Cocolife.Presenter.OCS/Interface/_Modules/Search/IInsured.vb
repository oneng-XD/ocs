#Region "Description"
' PAGE NAME     : Search Insured Interface
' CREATED BY    : MPRO
' CREATED DATE  : 05/07/2013
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Search

    Public Interface IInsured

#Region "Variables"

#End Region

#Region "Properties"
        Property IsInsuredExist() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SearchInsuredID() As Long
        Property SearchInsuredName() As String
        Property SearchInsuredType() As String
        Property LoadInsuredName As String
        Property LoadInsuredFirstName As String
        Property LoadInsuredLastName As String
        Property LoadInsuredMiddleName As String

        ' ------------------------------------------------------------------------------- 
        Property LoadInsuredID() As Long
        ' ------------------------------------------------------------------------------- 
        WriteOnly Property dtSearchInsured() As DataTable
#End Region

#Region "Events"
        Event ClearScreenSearchInsured(ByVal sender As Object, ByVal e As EventArgs)
        ' ------------------------------------------------------------------------------- 
        Event LoadInsured(ByVal sender As Object, ByVal e As EventArgs)
        Event LoadSearchInsured(ByVal sender As Object, ByVal e As EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub radSelectInsured(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Interface

    Public Interface IInsuredPolicyContext
        Property SearchInsuredPolType As String

    End Interface

End Namespace


