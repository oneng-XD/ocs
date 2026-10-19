#Region "Description"
' PAGE NAME     : SITE_ORHEADER DAL
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

    Public Class DSiteORHeader

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

        Public Function GetSiteORHeader(ByVal pDocNumber As Long, ByVal pUserId As Long) As OracleDataReader
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteOrHdr)
            Dim OraDR As OracleDataReader = Nothing

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

                    OraDR = .ExecuteReader
                End With

                Return OraDR

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function


#End Region

#Region "Transactions"

        Public Sub AlterSiteORHeader(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteOrHdr)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
                        .Add(New OracleParameter("pORNmbr", OracleType.Number)).Value = pObject.ORNmbr                          ' 1
                        .Add(New OracleParameter("pEmplCode", OracleType.VarChar)).Value = pObject.EmplCode                     ' 2
                        .Add(New OracleParameter("pORDate", OracleType.DateTime)).Value = pObject.ORDate                        ' 3
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks                       ' 4
                        .Add(New OracleParameter("pTotalAmt", OracleType.Double)).Value = pObject.TotalAmt                      ' 5
                        .Add(New OracleParameter("pChkAmt", OracleType.Double)).Value = pObject.ChkAmt                          ' 6
                        .Add(New OracleParameter("pPayType", OracleType.VarChar)).Value = pObject.PayType                       ' 7
                        .Add(New OracleParameter("pCurrType", OracleType.VarChar)).Value = pObject.CurrType                     ' 8
                        .Add(New OracleParameter("pSrcBrnch", OracleType.Number)).Value = pObject.SrcBrnch                      ' 9
                        .Add(New OracleParameter("pPayrID", OracleType.Number)).Value = pObject.PayrID                          ' 10
                        .Add(New OracleParameter("pPayor", OracleType.VarChar)).Value = pObject.Payor                           ' 11
                        .Add(New OracleParameter("pAcct", OracleType.VarChar)).Value = pObject.Acct                             ' 12
                        .Add(New OracleParameter("pGLCode", OracleType.VarChar)).Value = pObject.GLCode                         ' 13
                        .Add(New OracleParameter("pAddr", OracleType.VarChar)).Value = pObject.Addr                             ' 14
                        .Add(New OracleParameter("pTIN", OracleType.VarChar)).Value = pObject.TIN                               ' 15
                        .Add(New OracleParameter("pCancelFlag", OracleType.Number)).Value = pObject.CancelFlag                  ' 16
                        .Add(New OracleParameter("pPrtFlag", OracleType.Number)).Value = pObject.PrtFlag                        ' 17
                        .Add(New OracleParameter("pUserID", OracleType.Number)).Value = pObject.UserId                          ' 18
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pObject.SiteCode                      ' 19
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
