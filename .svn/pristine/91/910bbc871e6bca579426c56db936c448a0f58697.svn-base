#Region "Description"
' PAGE NAME     : TRNREF Reference
' CREATED BY    : EJ
' CREATED DATE  : 01/31/2017
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

    Public Class DTrnRef

#Region "Variables"

#End Region

#Region "Single Point Functions"

        Public Function IsValidTransactionCode(ByVal pPolNum As String, ByVal pAcType As String, Optional ByVal pAcType2 As String = Nothing, Optional ByVal pAcType3 As String = Nothing) As String
            Dim OraCmd As New OracleCommand(dalConstant._sfOCSGetPolicyBalance)
            Dim OraDR As OracleDataReader = Nothing
            Dim strInfo As String = cDataType.fString.Empty

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPolNum", OracleType.VarChar, 15)).Value = pPolNum
                        .Add(New OracleParameter("pAcType", OracleType.VarChar, 5)).Value = pAcType
                        .Add(New OracleParameter("pAcType2", OracleType.VarChar, 5)).Value = pAcType2
                        .Add(New OracleParameter("pAcType3", OracleType.VarChar, 5)).Value = pAcType3
                        .Add(New OracleParameter("vReturn", OracleType.VarChar, 300)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    strInfo = .Parameters("vReturn").Value
                    .Parameters.Clear()
                End With

                Return strInfo

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Data Retrieval"

        Public Function GetRefTrnRefList(ByVal pPayTyp As String, ByVal pTrnTyp As Integer, ByVal pPolTyp As String, ByVal pDocTyp As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetRefTranList)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPayTyp", OracleType.VarChar)).Value = pPayTyp
                        .Add(New OracleParameter("pTrnTyp", OracleType.Number)).Value = pTrnTyp
                        .Add(New OracleParameter("pPolTyp", OracleType.VarChar)).Value = pPolTyp
                        .Add(New OracleParameter("pDocTyp", OracleType.VarChar)).Value = pDocTyp
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtRefTRNTYPList")
                End With

                Return ds.Tables("dtRefTRNTYPList")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetTrnTyp(ByVal pDocTyp As String, ByVal pTrnDesc As String)
            '_spOCSGetTransactionType

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetTransactionType)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pDocTyp", OracleType.VarChar)).Value = pDocTyp
                        .Add(New OracleParameter("pTrnDesc", OracleType.VarChar)).Value = pTrnDesc
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtTrnTyp")
                End With

                Return ds.Tables("dtTrnTyp")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetReceiptTransactionDetails(ByVal pReceiptCode As Long) As OracleDataReader ', ByVal pDocTyp As String

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetRefTranDtl)
            Dim OraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pReceiptCode", OracleType.VarChar)).Value = pReceiptCode
                        '.Add(New OracleParameter("pDocTyp", OracleType.VarChar)).Value = pDocTyp
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

        Public Function GetVlTopupLimit(ByVal pPolicyNumber As String, ByVal pDate As Date) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetVlTopupLimit)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction
                    .Parameters.Add(New OracleParameter("pPolicyNumber", OracleType.VarChar)).Value = pPolicyNumber
                    .Parameters.Add(New OracleParameter("pDate", OracleType.DateTime)).Value = pDate
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtVlTopupLimit")

                End With
                Return ds.Tables("dtVlTopupLimit")

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