#Region "Description"
' PAGE NAME     : SEARCH DAL  
' CREATED BY    : EJ
' CREATED DATE  : 08/26/2016
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

Namespace Search

    Public Class DSearch

#Region "Variables"

#End Region

#Region "Single Point Functions"
        Public Function GetPolicyDetail(ByVal pPolNum As String, ByVal pPolType As String) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetPolicyDetail)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction


                    .Parameters.Add(New OracleParameter("pPolNum", OracleType.VarChar)).Value = pPolNum
                    .Parameters.Add(New OracleParameter("pPolType", OracleType.VarChar)).Value = pPolType
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtPolicyDetail")

                End With
                Return ds.Tables("dtPolicyDetail")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetNBPolicyNewgen(ByVal pPolNum As String, ByVal pApplicationNo As String) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetNBPolicyNewgen)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction


                    .Parameters.Add(New OracleParameter("pPolicyNumber", OracleType.VarChar)).Value = pPolNum
                    .Parameters.Add(New OracleParameter("pApplicationNumber", OracleType.VarChar)).Value = pApplicationNo
                    .Parameters.Add(New OracleParameter("pBusinessGroup", OracleType.VarChar)).Value = "Group"
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtPolicyDetail")

                End With
                Return ds.Tables("dtPolicyDetail")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function IsVlPlanRegular(ByVal pPolNum As String) As Boolean

            Dim OraCmd As New OracleCommand(dalConstant._sfCheckVlRegPlan)
            Dim OraDR As OracleDataReader = Nothing
            Dim mReturn As String

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPolNum", OracleType.VarChar)).Value = pPolNum
                        .Add(New OracleParameter("vReturn", OracleType.VarChar, 1)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    mReturn = .Parameters("vReturn").Value
                    .Parameters.Clear()
                End With

                Return IIf(mReturn = "Y", True, False)

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

#End Region

#Region "Data Retrieval"

        Public Function SearchPolicy(ByVal pPolNum As String, ByVal pInsNme As String, ByVal pPayNme As String, ByVal pPolTyp As String) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spOCSSearchPolicy)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction


                    .Parameters.Add(New OracleParameter("pPolNum", OracleType.VarChar)).Value = pPolNum
                    .Parameters.Add(New OracleParameter("pInsNme", OracleType.VarChar)).Value = pInsNme
                    .Parameters.Add(New OracleParameter("pPayNme", OracleType.VarChar)).Value = pPayNme
                    .Parameters.Add(New OracleParameter("pPolTyp", OracleType.VarChar)).Value = pPolTyp
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchPolicy")

                End With
                Return ds.Tables("dtSearchPolicy")

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


