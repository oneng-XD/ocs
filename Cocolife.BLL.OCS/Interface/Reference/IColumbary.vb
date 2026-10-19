#Region "Description"
' PAGE NAME     :   Columbary BLL Interface 
' CREATED BY    :   IBP
' CREATED DATE  :   03/01/17
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Reference

    Public Interface IColumbary

#Region "Variables"

#End Region

#Region "Properties"

#End Region

#Region "Single Point Functions"
        Function LoadActiveVaults() As DataTable
        Function GetVaultDetails(ByVal pVault As Integer) As DataTable
#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
