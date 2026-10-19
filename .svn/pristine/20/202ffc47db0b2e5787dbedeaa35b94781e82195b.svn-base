#Region "Description"
' PAGE NAME     : SITE_OPRINFO DAL
' CREATED BY    : EJ 
' CREATED DATE  : 07/15/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
Imports dConstant = Cocolife.DAL.OCS.DConstant
#End Region

Namespace Working

    Public Class DSiteOPRInfo

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

        Public Function GetSiteOPRInfo(ByVal pDocNumber As Long) As OracleDataReader
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteOprInfo)
            Dim OraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
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

        Public Function GetOprInfoDt(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteOprInfo)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
                        .Add(New OracleParameter("pPostBy", OracleType.Number)).Value = pUserId
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtOPRInfo")

                End With
                Return ds.Tables("dtOPRInfo")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterSiteOPRInfo(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteOprInfo)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
                        .Add(New OracleParameter("pOPRNmbr", OracleType.Number)).Value = pObject.OPRNmbr                        ' 1
                        .Add(New OracleParameter("pInsId", OracleType.Number)).Value = pObject.InsId                            ' 2
                        .Add(New OracleParameter("pInsLName", OracleType.VarChar)).Value = pObject.InsLName                     ' 3
                        .Add(New OracleParameter("pInsFName", OracleType.VarChar)).Value = pObject.InsFName                     ' 4
                        .Add(New OracleParameter("pInsMI", OracleType.VarChar)).Value = pObject.InsMI                           ' 5
                        .Add(New OracleParameter("pInsBDay", OracleType.DateTime)).Value = pObject.InsBDay                      ' 6
                        .Add(New OracleParameter("pInsSfx", OracleType.VarChar)).Value = pObject.InsSfx                         ' 7
                        .Add(New OracleParameter("pInsTit", OracleType.VarChar)).Value = pObject.InsTit                         ' 8
                        .Add(New OracleParameter("pInsSex", OracleType.VarChar)).Value = pObject.InsSex                         ' 9
                        .Add(New OracleParameter("pInsPlc", OracleType.VarChar)).Value = pObject.InsPlc                         ' 10
                        .Add(New OracleParameter("pOwnrId", OracleType.VarChar)).Value = pObject.OwnrId                         ' 11
                        .Add(New OracleParameter("pOwnrLName", OracleType.VarChar)).Value = pObject.OwnrLName                   ' 12
                        .Add(New OracleParameter("pOwnrFName", OracleType.VarChar)).Value = pObject.OwnrFName                   ' 13
                        .Add(New OracleParameter("pOwnrMI", OracleType.VarChar)).Value = pObject.OwnrMI                         ' 14
                        .Add(New OracleParameter("pOwnrBDay", OracleType.DateTime)).Value = pObject.OwnrBDay                    ' 15
                        .Add(New OracleParameter("pOwnrSfx", OracleType.VarChar)).Value = pObject.OwnrSfx                       ' 16
                        .Add(New OracleParameter("pOwnrTit", OracleType.VarChar)).Value = pObject.OwnrTit                       ' 17
                        .Add(New OracleParameter("pOwnrSex", OracleType.VarChar)).Value = pObject.OwnrSex                       ' 18
                        .Add(New OracleParameter("pOwnrPlc", OracleType.VarChar)).Value = pObject.OwnrPlc                       ' 19
                        .Add(New OracleParameter("pApplNo", OracleType.Number)).Value = pObject.ApplNo                          ' 20
                        .Add(New OracleParameter("pAplNoPTag", OracleType.Number)).Value = pObject.AplNoPTag                    ' 21
                        .Add(New OracleParameter("pPremAmt", OracleType.Double)).Value = pObject.PremAmt                        ' 22
                        .Add(New OracleParameter("pECRNmbr", OracleType.Number)).Value = pObject.ECRNmbr                        ' 23
                        .Add(New OracleParameter("pECRDate", OracleType.DateTime)).Value = pObject.ECRDate                      ' 24
                        .Add(New OracleParameter("pStatusId", OracleType.Number)).Value = pObject.StatusId
                        .Add(New OracleParameter("pPostBy", OracleType.Number)).Value = pObject.PostBy
                        .Add(New OracleParameter("pPostDate", OracleType.DateTime)).Value = pObject.PostDate
                        .Add(New OracleParameter("pLastUpdateBy", OracleType.Number)).Value = pObject.LastUpdateBy
                        .Add(New OracleParameter("pLastUpdate", OracleType.DateTime)).Value = pObject.LastUpdate
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
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
