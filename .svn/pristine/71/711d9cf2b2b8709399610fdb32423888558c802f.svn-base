#Region "Description"
' PAGE NAME     : STG_ORDTL DAL
' CREATED BY    : MPRO 
' CREATED DATE  : 04/27/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
'Imports bllConn = Cocolife.BLL.Common.Database.BCisLife
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
Imports dConstant = Cocolife.DAL.OCS.DConstant
#End Region

Namespace Staging

    Public Class DStgORDtl

#Region "Variables"
        Private mReference As Object = Nothing
#End Region

#Region "Property"

        Property Reference As Object
            Get
                Return mReference
            End Get
            Set(value As Object)
                mReference = value
            End Set
        End Property

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function GetStgORDtl(ByVal pDocNumber As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spCISGetStgOrDtl)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtStgORDtl")

                End With
                Return ds.Tables("dtStgORDtl")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterStgORDtl(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spAlterStgOrDtl)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pORNmbr", OracleType.Number)).Value = pObject.ORNmbr                          ' 1
                        .Add(New OracleParameter("pTrnxCode", OracleType.Number)).Value = pObject.TrnxCode                      ' 2
                        .Add(New OracleParameter("pActType", OracleType.VarChar)).Value = pObject.ActType                       ' 3
                        .Add(New OracleParameter("pTrnxDesc", OracleType.VarChar)).Value = pObject.TrnxDesc                     ' 4
                        .Add(New OracleParameter("pAmount", OracleType.Double)).Value = pObject.Amount                          ' 5
                        .Add(New OracleParameter("pLineNmbr", OracleType.Number)).Value = pObject.LineNmbr                      ' 6
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                                ' 7
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output             ' 8
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
                        While .Read
                            If eDBAction.isSuccessful(.Item("message")) Then
                                Reference = cDataType.fLong.getReference(.Item("message"))
                            Else
                                Throw New Exception(.Item("message"))
                            End If
                        End While
                    End With

                End With

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
                If Not IsNothing(oraDR) Then
                    oraDR.Dispose()
                End If
            End Try

        End Sub

#End Region

    End Class

End Namespace
