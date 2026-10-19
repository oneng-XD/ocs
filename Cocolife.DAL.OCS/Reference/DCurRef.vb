#Region "Description"
' PAGE NAME     : CURREF Reference
' CREATED BY    : MPRO
' CREATED DATE  : 03/27/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports cDataType = Cocolife.Utility.Common.DataType
Imports dalConstant = Cocolife.DAL.OCS.DConstant
#End Region

Namespace Reference

    Public Class DCurRef

#Region "Variables"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function GetRefCurRefList() As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetRefCurrefList)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtRefCURREFList")
                End With

                Return ds.Tables("dtRefCURREFList")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace

