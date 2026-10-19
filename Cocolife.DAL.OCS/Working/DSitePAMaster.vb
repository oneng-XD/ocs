#Region "Description"
' PAGE NAME     : SITE_PA_MASTER DAL
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

    Public Class DSitePAMaster

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

        Public Function GetSitePAMaster(ByVal pDocNumber As Long, ByVal pUserId As Long) As OracleDataReader
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSitePaMaster)
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

        Public Sub AlterSitePAMaster(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSitePaMaster)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
                        .Add(New OracleParameter("pPolicyNumber", OracleType.VarChar)).Value = pObject.PolicyNumber                         ' 1
                        .Add(New OracleParameter("pPACardID", OracleType.VarChar)).Value = pObject.PACardID                                 ' 2
                        .Add(New OracleParameter("pTransactionID", OracleType.Number)).Value = pObject.TransactionID                        ' 3
                        .Add(New OracleParameter("pLastName", OracleType.VarChar)).Value = pObject.LastName                                 ' 4
                        .Add(New OracleParameter("pFirstName", OracleType.VarChar)).Value = pObject.FirstName                               ' 5
                        .Add(New OracleParameter("pMiddleName", OracleType.VarChar)).Value = pObject.MiddleName                             ' 6
                        .Add(New OracleParameter("pORNumber", OracleType.Number)).Value = pObject.ORNumber                                  ' 7
                        .Add(New OracleParameter("pORDate", OracleType.DateTime)).Value = pObject.ORDate                                    ' 8
                        .Add(New OracleParameter("pPremium", OracleType.Double)).Value = pObject.Premium                                    ' 9
                        .Add(New OracleParameter("pCoverageAmount", OracleType.Double)).Value = pObject.CoverageAmount                      ' 10
                        .Add(New OracleParameter("pCoverageTerm", OracleType.Number)).Value = pObject.CoverageTerm                          ' 11
                        .Add(New OracleParameter("pAgent1", OracleType.Number)).Value = pObject.Agent1                                      ' 12
                        .Add(New OracleParameter("pAgent2", OracleType.Number)).Value = pObject.Agent2                                      ' 13
                        .Add(New OracleParameter("pUSD1", OracleType.Number)).Value = pObject.USD1                                          ' 14
                        .Add(New OracleParameter("pUSD2", OracleType.Number)).Value = pObject.USD2                                          ' 15
                        .Add(New OracleParameter("pASD", OracleType.Number)).Value = pObject.ASD                                            ' 16
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks                                   ' 17
                        .Add(New OracleParameter("pStatus", OracleType.VarChar)).Value = pObject.Status                                     ' 18
                        .Add(New OracleParameter("pBirthDate", OracleType.DateTime)).Value = pObject.BirthDate                              ' 19
                        .Add(New OracleParameter("pCommissionWithdrawn", OracleType.Number)).Value = pObject.CommissionWithdrawn            ' 20
                        .Add(New OracleParameter("pPayorLastName", OracleType.VarChar)).Value = pObject.PayorLastName                       ' 21
                        .Add(New OracleParameter("pPayorFirstName", OracleType.VarChar)).Value = pObject.PayorFirstName                     ' 22
                        .Add(New OracleParameter("pPayorMiddleName", OracleType.VarChar)).Value = pObject.PayorMiddleName                   ' 23
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

