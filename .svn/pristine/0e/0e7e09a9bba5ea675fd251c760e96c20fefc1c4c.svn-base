#Region "Description"
' PAGE NAME     :  Columbary BLL
' CREATED BY    :  IBP
' CREATED DATE  :  03/01/2017
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BColumbary

#Region "Implements"
        Implements IColumbary
#End Region

#Region "Variables"

#End Region

#Region "Properties"

#End Region

#Region "Contructor"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetVaultDetails(ByVal pVault As Integer) As DataTable Implements IColumbary.GetVaultDetails
            Dim objDAL As New dalReference.DColumbary
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetVaultDetails(pVault)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadActiveVaults() As DataTable Implements IColumbary.LoadActiveVaults
            Dim objDAL As New dalReference.DColumbary
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetActiveVaults()
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

#End Region


    End Class

End Namespace
