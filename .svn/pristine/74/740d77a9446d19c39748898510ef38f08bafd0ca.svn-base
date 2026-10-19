#Region "Description"
' PAGE NAME     : SECREF DAL  
' CREATED BY    : MPRO
' CREATED DATE  : 08/16/2013
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports dalConstant = Cocolife.DAL.OCS.DConstant
#End Region

Namespace Person

    Public Class DSecRef

#Region "Variables"

#End Region

#Region "Single Point Functions"

        Public Function GetSecRef(ByVal pSecOpr As String) As OracleDataReader

            Dim oraCmd As New OracleCommand(dalConstant._spCISGetSecref)
            Dim OraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSecOpr", OracleType.VarChar)).Value = pSecOpr
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDR = .ExecuteReader
                End With

                Return OraDR

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace

