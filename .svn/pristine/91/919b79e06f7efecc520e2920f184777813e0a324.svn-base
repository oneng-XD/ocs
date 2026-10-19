#Region "Description"
' PAGE NAME     :   COLUMBARY (HARSERV) DAL
' CREATED BY    :   IBP
' CREATED DATE  :   02/28/17
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.SqlClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports dalConstant = Cocolife.DAL.OCS.DConstant
'Imports eColumbary = Cocolife.Utility.OCS.DBConnector
Imports System.Configuration

Imports Cocolife.BLL.Common.Database
Imports Cocolife.Utility.Common.Enums
#End Region


Namespace Reference

    Public Class DColumbary

#Region "Variables"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function GetActiveVaults() As DataTable

            Dim objServer As New BEscalante
            objServer.Open(SystemType.ConnectionType.Live, "", "")


            Dim sqlCmd As New SqlCommand(dalConstant._spOCSListActivevault, objServer.Connection)
            Dim sqlDA As SqlDataAdapter = Nothing
            Dim ds As New DataSet

            Using sqlCmd

                Try
                    With sqlCmd
                        .CommandType = CommandType.StoredProcedure

                        sqlDA = New SqlDataAdapter(sqlCmd)
                        sqlDA.Fill(ds, "dtActiveVaults")
                    End With
                Catch ex As Exception
                    Throw
                End Try

                Return ds.Tables("dtActiveVaults")
            End Using

        End Function

        Public Function GetVaultDetails(ByVal pVault As Integer) As DataTable

            Dim objServer As New BEscalante
            objServer.Open(SystemType.ConnectionType.Live, "", "")


            Dim sqlCmd As New SqlCommand(dalConstant._spOCSGetvaultdetail, objServer.Connection)
            Dim sqlDA As SqlDataAdapter = Nothing
            Dim ds As New DataSet

            Using sqlCmd
                Try
                    With sqlCmd
                        .CommandType = CommandType.StoredProcedure


                        With .Parameters
                            .Add("@VaultNo", SqlDbType.Int).Value = pVault
                        End With

                        sqlDA = New SqlDataAdapter(sqlCmd)
                        sqlDA.Fill(ds, "dtVaultDetail")
                    End With
                Catch ex As Exception
                    Throw
                End Try

                Return ds.Tables("dtVaultDetail")

            End Using

        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace
