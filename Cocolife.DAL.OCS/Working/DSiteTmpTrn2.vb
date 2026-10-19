#Region "Description"
' PAGE NAME     : SITE_TMPTRN DAL
' CREATED BY    : EJAC 
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

    Public Class DSiteTmpTrn

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

        Public Function GetSiteTmpTrn(ByVal pDocNumber As Long, ByVal pDocType As String) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSITETMPTRN)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
                        .Add(New OracleParameter("pDocType", OracleType.VarChar)).Value = pDocType
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

        Public Sub AlterSiteTmpTrn(ByVal pObject As Object, ByVal pAction As String)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSITETMPTRN)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
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
                        .Add(New OracleParameter("pDatDue", OracleType.DateTime)).Value = pObject.DatDue                    ' 29
                        .Add(New OracleParameter("pCshAmt", OracleType.Double)).Value = pObject.CshAmt                      ' 30
                        .Add(New OracleParameter("pChkAmt", OracleType.Double)).Value = pObject.ChkAmt                      ' 31
                        .Add(New OracleParameter("pBankID", OracleType.Number)).Value = pObject.BankID                      ' 32
                        .Add(New OracleParameter("pPolFrq", OracleType.Number)).Value = pObject.PolFrq                      ' 33
                        .Add(New OracleParameter("pAgntID", OracleType.Number)).Value = pObject.AgntID                      ' 34
                        .Add(New OracleParameter("pCertNo", OracleType.VarChar)).Value = pObject.CertNo                     ' 35
                        .Add(New OracleParameter("pRetAmt", OracleType.Double)).Value = pObject.RetAmt                      ' 36
                        .Add(New OracleParameter("pAPRDat", OracleType.DateTime)).Value = pObject.APRDat                    ' 37
                        .Add(New OracleParameter("pAPRNum", OracleType.VarChar)).Value = pObject.APRNum                     ' 38
                        .Add(New OracleParameter("pApplNo", OracleType.VarChar)).Value = pObject.ApplNo                     ' 39
                        .Add(New OracleParameter("pECRNmbr", OracleType.VarChar)).Value = pObject.ECRNmbr                   ' 40
                        .Add(New OracleParameter("pECRDate", OracleType.DateTime)).Value = pObject.ECRDate                  ' 41
                        .Add(New OracleParameter("pBalFrq", OracleType.Number)).Value = pObject.BalFrq                      ' 42
                        .Add(New OracleParameter("pTxtFile", OracleType.VarChar)).Value = pObject.TxtFile                   ' 43
                        .Add(New OracleParameter("pUploadDate", OracleType.DateTime)).Value = pObject.UploadDate            ' 44
                        .Add(New OracleParameter("pUserID", OracleType.Number)).Value = pObject.UserId                      ' 45
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pObject.SiteCode                  ' 46
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
            End Try

        End Sub

#End Region

    End Class

End Namespace

