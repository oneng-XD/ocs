#Region "Description"
' PAGE NAME     : SITE_OPRHEADER DAL
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
Imports System.Configuration
#End Region

Namespace Working

    Public Class DSiteOPRHeader

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
        Public Function GetSiteOPRHeader(ByVal pDocNumber As Long, ByVal pUserId As Long) As OracleDataReader

            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteOprHdr)
            Dim OraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
                        '.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
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

        Public Sub AlterSiteOPRHeader(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)
            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")


            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteOprHdr)
            Dim oraDR As OracleDataReader = Nothing


            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
                        .Add(New OracleParameter("pOPRRcptNo", OracleType.Number)).Value = pObject.OPRRcptNo                    ' 1
                        .Add(New OracleParameter("pOPRDate", OracleType.DateTime)).Value = pObject.OPRDate                      ' 2
                        .Add(New OracleParameter("pOPRSrcBrnc", OracleType.Number)).Value = pObject.OPRSrcBrnc                  ' 3
                        .Add(New OracleParameter("pOPRRemarks", OracleType.VarChar)).Value = pObject.OPRRemarks                 ' 4
                        .Add(New OracleParameter("pOPRApplctn", OracleType.VarChar)).Value = pObject.OPRApplctn                 ' 5
                        .Add(New OracleParameter("pOPRECRNo", OracleType.Number)).Value = pObject.OPRECRNo                      ' 6
                        .Add(New OracleParameter("pOPRECRDate", OracleType.DateTime)).Value = pObject.OPRECRDate                ' 7
                        .Add(New OracleParameter("pOPRPolNum", OracleType.VarChar)).Value = pObject.OPRPolNum                   ' 8
                        .Add(New OracleParameter("pOPRPyrID", OracleType.Number)).Value = pObject.OPRPyrID                      ' 9
                        .Add(New OracleParameter("pOPRPyrFNam", OracleType.VarChar)).Value = pObject.OPRPyrFNam                 ' 10
                        .Add(New OracleParameter("pOPRPyrLNam", OracleType.VarChar)).Value = pObject.OPRPyrLNam                 ' 11
                        .Add(New OracleParameter("pOPRPyrMNam", OracleType.VarChar)).Value = pObject.OPRPyrMNam                 ' 12
                        .Add(New OracleParameter("pOPRInsID", OracleType.Number)).Value = pObject.OPRInsID                      ' 13
                        .Add(New OracleParameter("pOPRInsFNam", OracleType.VarChar)).Value = pObject.OPRInsFNam                 ' 14
                        .Add(New OracleParameter("pOPRInsLNam", OracleType.VarChar)).Value = pObject.OPRInsLNam                 ' 15
                        .Add(New OracleParameter("pOPRInsMNam", OracleType.VarChar)).Value = pObject.OPRInsMNam                 ' 16
                        .Add(New OracleParameter("pOPRAgID", OracleType.Number)).Value = pObject.OPRAgID                        ' 17
                        .Add(New OracleParameter("pOPRAgFNam", OracleType.VarChar)).Value = pObject.OPRAgFNam                   ' 18
                        .Add(New OracleParameter("pOPRAgLNam", OracleType.VarChar)).Value = pObject.OPRAgLNam                   ' 19
                        .Add(New OracleParameter("pOPRAgMNam", OracleType.VarChar)).Value = pObject.OPRAgMNam                   ' 20
                        .Add(New OracleParameter("pOPRBrID", OracleType.Number)).Value = pObject.OPRBrID                        ' 21
                        .Add(New OracleParameter("pOPRBrFNam", OracleType.VarChar)).Value = pObject.OPRBrFNam                   ' 22
                        .Add(New OracleParameter("pOPRBrLNam", OracleType.VarChar)).Value = pObject.OPRBrLNam                   ' 23
                        .Add(New OracleParameter("pOPRBrMNam", OracleType.VarChar)).Value = pObject.OPRBrMNam                   ' 24
                        .Add(New OracleParameter("pOPRDocTyp", OracleType.VarChar)).Value = pObject.OPRDocTyp                   ' 25
                        .Add(New OracleParameter("pOPRTxNumb", OracleType.Number)).Value = pObject.OPRTxNumb                    ' 26
                        .Add(New OracleParameter("pOPRPlnCry", OracleType.VarChar)).Value = pObject.OPRPlnCry                   ' 27
                        .Add(New OracleParameter("pOPRFlags", OracleType.VarChar)).Value = pObject.OPRFlags                     ' 28
                        .Add(New OracleParameter("pOPRIssue", OracleType.DateTime)).Value = pObject.OPRIssue                    ' 29
                        .Add(New OracleParameter("pOPRLastBl", OracleType.DateTime)).Value = pObject.OPRLastBl                  ' 30
                        .Add(New OracleParameter("pCancelFlag", OracleType.Number)).Value = pObject.CancelFlag                  ' 31
                        .Add(New OracleParameter("pPrtFlag", OracleType.Number)).Value = pObject.PrtFlag                        ' 32
                        .Add(New OracleParameter("pNiFlag", OracleType.Number)).Value = pObject.NiFlag                          ' 33
                        .Add(New OracleParameter("pUserID", OracleType.Number)).Value = pObject.UserId                          ' 34
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pObject.SiteCode                      ' 35

                        .Add(New OracleParameter("pOPRPyrAdr", OracleType.VarChar)).Value = pObject.OPRPyrAdr
                        .Add(New OracleParameter("pOPRPyrTin", OracleType.VarChar)).Value = pObject.OPRPyrTin

                        .Add(New OracleParameter("pStatusId", OracleType.Number)).Value = pObject.StatusId
                        .Add(New OracleParameter("pPostBy", OracleType.Number)).Value = pObject.PostBy
                        .Add(New OracleParameter("pPostDate", OracleType.DateTime)).Value = pObject.PostDate
                        .Add(New OracleParameter("pLastUpdateBy", OracleType.Number)).Value = pObject.LastUpdateBy
                        .Add(New OracleParameter("pLastUpdate", OracleType.DateTime)).Value = pObject.LastUpdate
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pBillNo", OracleType.VarChar)).Value = pObject.BillNo
                        .Add(New OracleParameter("pSubsNo", OracleType.VarChar)).Value = pObject.SubsNo
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value =If(String.IsNullOrEmpty(apiUsername),CType(DBNull.Value, Object),apiUsername)
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = If(String.IsNullOrEmpty(apiPassword), CType(DBNull.Value, Object), apiPassword)
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value =If(String.IsNullOrEmpty(apiGrantType),CType(DBNull.Value, Object),apiGrantType)

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

