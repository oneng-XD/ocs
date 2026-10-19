#Region "Description"
' PAGE NAME     : SITE_OPRDTL DAL
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

    Public Class DSiteBatchDtl

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

        Public Function GetSiteBatchDtl(ByVal pBatchId As Long, ByVal pUserId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteBatchDtl)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pBatchId", OracleType.Number)).Value = pBatchId
                        .Add(New OracleParameter("pPostBy", OracleType.Number)).Value = pUserId
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtBatchDtl")

                End With
                Return ds.Tables("dtBatchDtl")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterSiteBatchDtl(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteBatchDtl)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
                        .Add(New OracleParameter("pBatchId", OracleType.Number)).Value = pObject.BatchId
                        .Add(New OracleParameter("pOprNmbr", OracleType.Number)).Value = pObject.OprNmbr
                        .Add(New OracleParameter("pOprAmt", OracleType.Number)).Value = pObject.OprAmt
                        .Add(New OracleParameter("pPocId", OracleType.Number)).Value = pObject.PocId
                        .Add(New OracleParameter("pInsuredName", OracleType.VarChar, 100)).Value = pObject.InsuredName
                        .Add(New OracleParameter("pPolicyName", OracleType.VarChar, 100)).Value = pObject.PolicyName
                        .Add(New OracleParameter("pGrossLife", OracleType.Number)).Value = pObject.GrossLife
                        .Add(New OracleParameter("pGrossNonLife", OracleType.Number)).Value = pObject.GrossNonLife
                        .Add(New OracleParameter("pNonlifePremium", OracleType.Number)).Value = pObject.NonlifePremium
                        .Add(New OracleParameter("pDstNonLife", OracleType.Number)).Value = pObject.DstNonLife
                        .Add(New OracleParameter("pPremTaxNonlife", OracleType.Number)).Value = pObject.PremTaxNonlife
                        .Add(New OracleParameter("pLocalTaxNonlife", OracleType.Number)).Value = pObject.LocalTaxNonlife
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

