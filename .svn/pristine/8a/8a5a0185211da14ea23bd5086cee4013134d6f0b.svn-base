#Region "Description"
' PAGE NAME     : STG_PA_MASTER DAL
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

    Public Class DStgPAMaster

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

#End Region

#Region "Transactions"

        Public Sub CancelGpa(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spGPACancelOpr)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pORNo", OracleType.Number)).Value = pObject.DocNumber                                 ' 1
                        .Add(New OracleParameter("pPACardID", OracleType.VarChar)).Value = pObject.PACardID                             ' 2
                        .Add(New OracleParameter("pPolNum", OracleType.VarChar)).Value = pObject.PolicyNumber                           ' 3
                        .Add(New OracleParameter("pTransID", OracleType.Number)).Value = pObject.TransCode                              ' 4
                        .Add(New OracleParameter("pAgentID", OracleType.Number)).Value = pObject.Agent1ID                               ' 5
                        .Add(New OracleParameter("pUserID", OracleType.Number)).Value = pObject.UserID                                  ' 6
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                                        ' 7
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output                     ' 8
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
                        While .Read

                            Dim strItem = oraDR.Item(0).ToString
                            If Left(strItem, 2) <> "OK" Then
                                Throw New Exception(strItem)
                            Else
                                Reference = Mid(strItem, 4)
                            End If

                            'If eDBAction.isSuccessful(.Item("message")) Then
                            '    Reference = cDataType.fLong.getReference(.Item("message"))
                            'Else
                            '    Throw New Exception(.Item("message"))
                            'End If
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

        Public Sub ProcessGpa(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spGPAProcessOpr)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pPolicyNumber", OracleType.VarChar)).Value = pObject.PolicyNumber                         ' 1
                        .Add(New OracleParameter("pPACardID", OracleType.VarChar)).Value = pObject.PACardID                                 ' 2
                        .Add(New OracleParameter("pBirthDate", OracleType.DateTime)).Value = pObject.BirthDate                              ' 3
                        .Add(New OracleParameter("pPremium", OracleType.Double)).Value = pObject.Premium                                    ' 4
                        .Add(New OracleParameter("pCoverageAmount", OracleType.Double)).Value = pObject.CoverageAmount                      ' 5
                        .Add(New OracleParameter("pCoverageTerm", OracleType.Number)).Value = pObject.CoverageTerm                          ' 6
                        .Add(New OracleParameter("pAgent1ID", OracleType.Number)).Value = pObject.Agent1ID                                    ' 7
                        .Add(New OracleParameter("pAgent2ID", OracleType.Number)).Value = pObject.Agent2ID                                    ' 8
                        .Add(New OracleParameter("pUsdID", OracleType.Number)).Value = pObject.UsdID                                         ' 9
                        .Add(New OracleParameter("pUsd2ID", OracleType.Number)).Value = pObject.Usd2ID                                        ' 10
                        .Add(New OracleParameter("pAsdID", OracleType.Number)).Value = pObject.AsdID                                          ' 11
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks                                   ' 12
                        .Add(New OracleParameter("pStatus", OracleType.VarChar)).Value = pObject.Status                                     ' 13
                        .Add(New OracleParameter("pCommWithdrawn", OracleType.Number)).Value = pObject.CommWithdrawn                        ' 14
                        .Add(New OracleParameter("pCommwithAmt", OracleType.Number)).Value = pObject.CommwithAmt                            ' 15
                        .Add(New OracleParameter("pDocType", OracleType.VarChar)).Value = pObject.DocType                                   ' 16
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pObject.DocNumber                               ' 17
                        .Add(New OracleParameter("pDocDate", OracleType.DateTime)).Value = pObject.DocDate                                  ' 18
                        .Add(New OracleParameter("pInsuredID", OracleType.Number)).Value = pObject.InsuredID                                ' 19
                        .Add(New OracleParameter("pPayorID", OracleType.Number)).Value = pObject.PayorID                                  ' 20
                        .Add(New OracleParameter("pTransCode", OracleType.Number)).Value = pObject.TransCode                               ' 21
                        .Add(New OracleParameter("pUserID", OracleType.Number)).Value = pObject.UserID                                     ' 22
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output                         ' 23
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
                        While .Read

                            Dim strItem = oraDR.Item(0).ToString
                            If Left(strItem, 2) <> "OK" Then
                                Throw New Exception(strItem)
                            Else
                                Reference = Mid(strItem, 4)
                            End If

                            'If eDBAction.isSuccessful(.Item("message")) Then
                            '    Reference = cDataType.fLong.getReference(.Item("message"))
                            'Else
                            '    Throw New Exception(.Item("message"))
                            'End If
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

