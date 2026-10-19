#Region "Description"
' PAGE NAME     : STG_TMPTRN DAL
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

    Public Class DStgTmpTrn

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

        Public Function GetStgTmpTrn(ByVal pDocNumber As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spCISGetStgTmptrn)
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
                    OraDA.Fill(ds, "dtTmpTrn")

                End With
                Return ds.Tables("dtTmpTrn")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterStgTmpTrn(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spAlterStgTmptrn)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pBatNum", OracleType.VarChar)).Value = pObject.BatNum                     ' 1
                        .Add(New OracleParameter("pAcType", OracleType.VarChar)).Value = pObject.AcType                     ' 2
                        .Add(New OracleParameter("pFundTP", OracleType.VarChar)).Value = pObject.FundTP                     ' 3
                        .Add(New OracleParameter("pPayrID", OracleType.Number)).Value = pObject.PayrID                      ' 4
                        .Add(New OracleParameter("pPolNum", OracleType.VarChar)).Value = pObject.PolNum                     ' 5
                        .Add(New OracleParameter("pTrnDat", OracleType.DateTime)).Value = pObject.TrnDat                    ' 6
                        .Add(New OracleParameter("pTrnAmt", OracleType.Double)).Value = pObject.TrnAmt                      ' 7
                        .Add(New OracleParameter("pOperID", OracleType.VarChar)).Value = pObject.OperID                     ' 8
                        .Add(New OracleParameter("pDateNT", OracleType.DateTime)).Value = pObject.DateNT                    ' 9
                        .Add(New OracleParameter("pTxNumb", OracleType.Number)).Value = pObject.TxNumb                      ' 10
                        .Add(New OracleParameter("pCredID", OracleType.Number)).Value = pObject.CredID                      ' 11
                        .Add(New OracleParameter("pSrcDoc", OracleType.VarChar)).Value = pObject.SrcDoc                     ' 12
                        .Add(New OracleParameter("pCurCod", OracleType.VarChar)).Value = pObject.CurCod                     ' 13
                        .Add(New OracleParameter("pTrnRef", OracleType.VarChar)).Value = pObject.TrnRef                     ' 14
                        .Add(New OracleParameter("pPayTyp", OracleType.VarChar)).Value = pObject.PayTyp                     ' 15
                        .Add(New OracleParameter("pServUn", OracleType.Number)).Value = pObject.ServUn                      ' 16
                        .Add(New OracleParameter("pTxNum2", OracleType.Number)).Value = pObject.TxNum2                      ' 17
                        .Add(New OracleParameter("pCollOff", OracleType.Number)).Value = pObject.CollOff                    ' 18
                        .Add(New OracleParameter("pRcptNo", OracleType.Number)).Value = pObject.RcptNo                      ' 19
                        .Add(New OracleParameter("pTrnCod", OracleType.VarChar)).Value = pObject.TrnCod                     ' 20
                        .Add(New OracleParameter("pBucket", OracleType.Number)).Value = pObject.Bucket                      ' 21
                        .Add(New OracleParameter("pProces", OracleType.Number)).Value = pObject.Proces                      ' 22
                        .Add(New OracleParameter("pRevPrc", OracleType.Number)).Value = pObject.RevPrc                      ' 23
                        .Add(New OracleParameter("pPretCB", OracleType.Double)).Value = pObject.PretCB                      ' 24
                        .Add(New OracleParameter("pPostCB", OracleType.Double)).Value = pObject.PostCB                      ' 25
                        .Add(New OracleParameter("pAniNum", OracleType.Number)).Value = pObject.AniNum                      ' 26
                        .Add(New OracleParameter("pDocTyp", OracleType.VarChar)).Value = pObject.DocTyp                     ' 27
                        .Add(New OracleParameter("pMetCod", OracleType.VarChar)).Value = pObject.MetCod                     ' 28
                        .Add(New OracleParameter("pDatDue", OracleType.DateTime)).Value = IIf(pObject.DatDue = #1/1/1900#, DBNull.Value, pObject.DatDue) ' 29
                        .Add(New OracleParameter("pCshAmt", OracleType.Double)).Value = pObject.CshAmt                      ' 30
                        .Add(New OracleParameter("pChkAmt", OracleType.Double)).Value = pObject.ChkAmt                      ' 31
                        .Add(New OracleParameter("pBankID", OracleType.Number)).Value = pObject.BankID                      ' 32
                        .Add(New OracleParameter("pPolFrq", OracleType.Number)).Value = pObject.PolFrq                      ' 33
                        .Add(New OracleParameter("pAgntID", OracleType.Number)).Value = pObject.AgntID                      ' 34
                        .Add(New OracleParameter("pCertNo", OracleType.VarChar)).Value = pObject.CertNo                     ' 35
                        .Add(New OracleParameter("pRetAmt", OracleType.Double)).Value = pObject.RetAmt                      ' 36
                        .Add(New OracleParameter("pAPRDat", OracleType.DateTime)).Value = IIf(pObject.APRDat = #1/1/1900#, DBNull.Value, pObject.APRDat) ' 37
                        .Add(New OracleParameter("pAPRNum", OracleType.VarChar)).Value = pObject.APRNum                     ' 38
                        .Add(New OracleParameter("pApplNo", OracleType.VarChar)).Value = pObject.ApplNo                     ' 39
                        .Add(New OracleParameter("pECRNmbr", OracleType.VarChar)).Value = pObject.ECRNmbr                   ' 40
                        .Add(New OracleParameter("pECRDate", OracleType.DateTime)).Value = IIf(pObject.ECRDate = #1/1/1900#, DBNull.Value, pObject.ECRDate) ' 41
                        .Add(New OracleParameter("pBalFrq", OracleType.Number)).Value = pObject.BalFrq                      ' 42
                        .Add(New OracleParameter("pTxtFile", OracleType.VarChar)).Value = pObject.TxtFile                   ' 43
                        .Add(New OracleParameter("pUploadDate", OracleType.DateTime)).Value = pObject.UploadDate ' 44
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                            ' 45
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output         ' 46
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

