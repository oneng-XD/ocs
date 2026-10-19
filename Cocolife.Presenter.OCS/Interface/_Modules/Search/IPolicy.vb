#Region "Description"
' PAGE NAME     : Search Agent Interface
' CREATED BY    : MPRO
' CREATED DATE  : 04/30/2013
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Search

    Public Interface IPolicy

#Region "Variables"

#End Region

#Region "Properties"
        Property IsPolicyExist() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SearchPolicyType() As String
        Property SearchPolicyNo() As String
        Property SearchPolicyInsured As String
        Property SearchPolicyPayor As String
        ' ------------------------------------------------------------------------------- 
        Property LoadPolicyType() As String
        Property LoadPolicyNo() As String
        Property LoadMetCod() As String
        Property LoadInsuredName() As String
        Property LoadPayorName() As String
        ' ------------------------------------------------------------------------------- 
        WriteOnly Property dtSearchPolicy() As DataTable
#End Region

#Region "Events"
        Event ClearScreenLoadPolicy(ByVal sender As Object, ByVal e As EventArgs)
        Event ClearScreenSearchPolicy(ByVal sender As Object, ByVal e As EventArgs)
        ' ------------------------------------------------------------------------------- 
        Event LoadPolicy(ByVal sender As Object, ByVal e As EventArgs)
        Event LoadSearchPolicy(ByVal sender As Object, ByVal e As EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub radSelectPolicy(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Interface

End Namespace


