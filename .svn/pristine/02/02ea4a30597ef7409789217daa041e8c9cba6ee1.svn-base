#Region "Description"
' PAGE NAME     : STG_OPRCRED DAL
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

    Public Class DStgOPRCred

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

        Public Function GetStgOPRCred(ByVal pDocNumber As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spCISGetStgOprCred)
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
                    OraDA.Fill(ds, "dtStgOPRCred")

                End With
                Return ds.Tables("dtStgOPRCred")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterStgOPRCred(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spAlterStgOprCca)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pOPRNmbr", OracleType.Number)).Value = pObject.OPRNmbr                    ' 1
                        .Add(New OracleParameter("pCardNo", OracleType.VarChar)).Value = pObject.CardNo                     ' 2
                        .Add(New OracleParameter("pCardType", OracleType.VarChar)).Value = pObject.CardType                 ' 3
                        .Add(New OracleParameter("pApprvCode", OracleType.VarChar)).Value = pObject.ApprvCode               ' 4
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks                   ' 5
                        .Add(New OracleParameter("pAmount", OracleType.Double)).Value = pObject.Amount                      ' 6
                        .Add(New OracleParameter("pTerminalID", OracleType.VarChar)).Value = pObject.TerminalID             ' 7
                        .Add(New OracleParameter("pMerchantID", OracleType.VarChar)).Value = pObject.MerchantID             ' 8
                        .Add(New OracleParameter("pSwipeDate", OracleType.DateTime)).Value = IIf(pObject.SwipeDate = #1/1/1900#, DBNull.Value, pObject.SwipeDate) ' 9
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                            ' 10
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output         ' 11
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

