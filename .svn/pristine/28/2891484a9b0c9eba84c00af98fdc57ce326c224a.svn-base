#Region "Description"
' PAGE NAME     : PRSREF Reference
' CREATED BY    : MPRO
' CREATED DATE  : 10/14/2013
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

    Public Class DPrsRef

#Region "Variables"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function GetRefPrsRefList() As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spCISGetRefPrsrefList)
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
                    oraDA.Fill(ds, "dtRefPRSREFList")                    
                End With

                Return ds.Tables("dtRefPRSREFList")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetRefPrsRefPrsTyp() As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spCISGetRefPrsrefPrstyp)
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
                    oraDA.Fill(ds, "dtRefPRSREFPrsTyp")                    
                End With

                Return ds.Tables("dtRefPRSREFPrsTyp")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetRefPrsRefSexTyp() As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spCISGetRefPrsrefSextyp)
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
                    oraDA.Fill(ds, "dtRefPRSREFSexTyp")                    
                End With

                Return ds.Tables("dtRefPRSREFSexTyp")

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

