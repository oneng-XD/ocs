#Region "Description"
' PAGE NAME     : METPAY Reference
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

    Public Class DMetPay

#Region "Variables"

#End Region

#Region "Single Point Functions"

        Public Function GetPolTyp(ByVal pMetCod As String, ByVal pDocTyp As String) As String
            Dim OraCmd As New OracleCommand(dalConstant._spOCSGetPolicyType)
            Dim OraDR As OracleDataReader = Nothing
            Dim strPolTyp As String = String.Empty

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pMetCod", OracleType.VarChar)).Value = pMetCod
                        .Add(New OracleParameter("pDocTyp", OracleType.VarChar)).Value = pDocTyp
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDR = .ExecuteReader
                    With OraDR.Read()
                        strPolTyp = cDataType.fString.IfNull(OraDR.Item("mettype"))
                    End With
                End With

                Return strPolTyp
            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

        Public Function GetPType(ByVal pMetCod As String, ByVal pDocTyp As String) As String
            Dim OraCmd As New OracleCommand(dalConstant._spOCSGetPolicyType)
            Dim OraDR As OracleDataReader = Nothing
            Dim strPType As String = String.Empty

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pMetCod", OracleType.VarChar)).Value = pMetCod
                        .Add(New OracleParameter("pDocTyp", OracleType.VarChar)).Value = pDocTyp
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDR = .ExecuteReader
                    With OraDR.Read()
                        strPType = cDataType.fString.IfNull(OraDR.Item("metptype"))
                    End With
                End With

                Return strPType
            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

#End Region

#Region "Data Retrieval"

        Public Function GetRefMetPayList(ByVal pFilter As String, ByVal pPolTyp As String, ByVal pDocTyp As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetRefMetpayList)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pFilter", OracleType.VarChar)).Value = pFilter
                        .Add(New OracleParameter("pPolTyp", OracleType.VarChar)).Value = pPolTyp
                        .Add(New OracleParameter("pDocTyp", OracleType.VarChar)).Value = pDocTyp
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtRefMETPAYList")
                End With

                Return ds.Tables("dtRefMETPAYList")

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