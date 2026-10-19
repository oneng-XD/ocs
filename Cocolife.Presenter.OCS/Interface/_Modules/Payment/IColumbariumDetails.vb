#Region "Description"
' PAGE NAME     : Columbarium Details Interface
' CREATED BY    : IBP
' CREATED DATE  : 01/20/2017
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Payment

    Public Interface IColumbariumDetails

#Region "Variables"

#End Region

#Region "Properties"
        'Property LastBill As Date

        Property Vault As Integer
        Property Level As String
        Property Block As String
        Property Column As String
        Property LotListPrice As Decimal
        Property Product As String 'IBP 04/05/17
        Property ReservationAmt As Decimal 'IBP 04/05/17
        Property VaultVAT As Decimal 'IBP 04/05/17
        Property DiscountRate As Decimal 'IBP 04/05/17

        WriteOnly Property dtActiveVaults As DataTable 'IBP 03/01/17
        'WriteOnly Property dtVaultDetails As DataTable 'IBP 03/01/17


#End Region

#Region "Events"
        'Event ClearScreenColumbarium(ByVal sender As Object, ByVal e As EventArgs)
        'Event GetColumbariumDetails(ByVal sender As Object, ByVal e As EventArgs)
        'Event LoadVaults(ByVal sender As Object, ByVal e As EventArgs)
        Event LoadActiveVaults As EventHandler(Of EventArgs)
        Event GetVaultDetails As EventHandler(Of EventArgs)

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

#Region "Establish HARSERV Connection"

#Region "Properties"
        'Property strUserID As String
        'Property strPassword As String
        'Property sqlConnString As String
#End Region

#Region "Events"
        'Event GetConnectionString As EventHandler(Of EventArgs)
#End Region

#End Region


    End Interface

End Namespace
