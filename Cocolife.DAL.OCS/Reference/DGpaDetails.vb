#Region "Description"
' PAGE NAME     :  
' CREATED BY    : 
' CREATED DATE  : 
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

    Public Class DGpaDetails

#Region "Variables"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function GetGpaCard(ByRef pSiteCode As Long, ByVal pPlan As String, ByVal pCardId As Long) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetGpaPlanList)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                        .Add(New OracleParameter("pPlan", OracleType.VarChar)).Value = pPlan
                        .Add(New OracleParameter("pCardId", OracleType.Number)).Value = pCardId
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtGpaCard")
                End With

                Return ds.Tables("dtGpaCard")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetGpaPlanList(ByVal pSiteCode As Long, ByVal pSalesForce As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetGpaPlanList)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                        .Add(New OracleParameter("pSalesForce", OracleType.VarChar)).Value = pSalesForce
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtGpaPlanList")
                End With

                Return ds.Tables("dtGpaPlanList")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetGpaSettings(ByVal pSalesForce As String, ByVal pCatCod As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetGpaFlags)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSalesForce", OracleType.VarChar)).Value = pSalesForce
                        .Add(New OracleParameter("pCatCod", OracleType.VarChar)).Value = pCatCod
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtGpaSettings")
                End With

                Return ds.Tables("dtGpaSettings")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function SearchPaCardId(ByVal pPlan As String, ByVal pNumber As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetGpaCardIdDtl)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPlan", OracleType.VarChar)).Value = pPlan
                        .Add(New OracleParameter("pNumber", OracleType.VarChar)).Value = pNumber
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchPaCardId")
                End With

                Return ds.Tables("dtSearchPaCardId")

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

