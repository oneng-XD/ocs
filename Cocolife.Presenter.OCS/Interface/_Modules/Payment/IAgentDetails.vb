#Region "Description"
' PAGE NAME     : Agent Details Interface
' CREATED BY    : EJ
' CREATED DATE  : 07/19/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface IAgentDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property AgentID() As Long
        Property AgentIDTag() As Boolean
        Property AgentName() As String
        Property AgentLastName() As String
        Property AgentFirstName() As String
        Property AgentMiddleName() As String
        Property AgencyID() As Long
        Property AgencyName() As String
        Property AgencyLastName() As String
        Property AgencyFirstName() As String
        Property AgencyMiddleName() As String
        Property AgentSalesForce() As String
        Property AgentCatCod() As String
        Property AgentCommRate() As Decimal
        Property AgentTaxRate() As Decimal
        Property Usd() As Long
        Property UsdName() As String
        Property Asd() As Long
        Property AsdName() As String
#End Region

#Region "Events"
        Event ClearScreenAgent(ByVal sender As Object, ByVal e As EventArgs)
        Event ClearScreenAgentDetails(ByVal sender As Object, ByVal e As EventArgs)
        Event GetAgentDetails(ByVal sender As Object, ByVal e As EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

