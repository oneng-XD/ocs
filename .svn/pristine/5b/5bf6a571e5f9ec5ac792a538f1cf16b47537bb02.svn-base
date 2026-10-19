#Region "Description"
' PAGE NAME     : STG_OPRINFO DAL
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

    Public Class DStgOPRInfo

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

        Public Function GetStgOPRInfo(ByVal pDocNumber As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spCISGetStgOprinfo)
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
                    OraDA.Fill(ds, "dtStgOPRInfo")

                End With
                Return ds.Tables("dtStgOPRInfo")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterStgOPRInfo(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spAlterStgOprInfo)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pOPRNmbr", OracleType.Number)).Value = pObject.OPRNmbr                        ' 1
                        .Add(New OracleParameter("pInsLName", OracleType.VarChar)).Value = pObject.InsLName                     ' 2
                        .Add(New OracleParameter("pInsFName", OracleType.VarChar)).Value = pObject.InsFName                     ' 3
                        .Add(New OracleParameter("pInsMI", OracleType.VarChar)).Value = pObject.InsMI                           ' 4
                        .Add(New OracleParameter("pInsBDay", OracleType.DateTime)).Value = IIf(pObject.InsBDay = #1/1/1900#, DBNull.Value, pObject.InsBDay) ' 5
                        .Add(New OracleParameter("pOwnrLName", OracleType.VarChar)).Value = pObject.OwnrLName                   ' 6
                        .Add(New OracleParameter("pOwnrFName", OracleType.VarChar)).Value = pObject.OwnrFName                   ' 7
                        .Add(New OracleParameter("pOwnrMI", OracleType.VarChar)).Value = pObject.OwnrMI                         ' 8
                        .Add(New OracleParameter("pOwnrBDay", OracleType.DateTime)).Value = IIf(pObject.OwnrBDay = #1/1/1900#, DBNull.Value, pObject.OwnrBDay) ' 9
                        .Add(New OracleParameter("pApplNo", OracleType.VarChar)).Value = pObject.ApplNo                         ' 10
                        .Add(New OracleParameter("pAplNoPTag", OracleType.Number)).Value = pObject.AplNoPTag                    ' 11
                        .Add(New OracleParameter("pPremAmt", OracleType.Double)).Value = pObject.PremAmt                        ' 12
                        .Add(New OracleParameter("pECRNmbr", OracleType.Number)).Value = pObject.ECRNmbr                        ' 13
                        .Add(New OracleParameter("pECRDate", OracleType.DateTime)).Value = IIf(pObject.ECRDate = #1/1/1900#, DBNull.Value, pObject.ECRDate) ' 14
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                                ' 15
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output             ' 16
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
