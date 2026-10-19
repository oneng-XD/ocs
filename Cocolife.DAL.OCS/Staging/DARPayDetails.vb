#Region "Description"
' PAGE NAME     :  
' CREATED BY    : 
' CREATED DATE  : 
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
Imports dalConstant = Cocolife.DAL.OCS.DConstant
#End Region

Namespace Staging

    Public Class DARPayDetails

#Region "Variables"
        Private mReference As Object = Nothing
#End Region

#Region "Properties"
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
        Public Function GetARPayDetails(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetARPayDetails)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pARNo", OracleType.Number)).Value = pDocNumber
                        .Add(New OracleParameter("pPostedBy", OracleType.Number)).Value = pUserId
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtARPayDetails")

                End With
                Return ds.Tables("dtARPayDetails")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetDocList(ByVal pSiteCode As Long, ByVal pDocNumber As Long) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIList)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.Number)).Value = pDocNumber
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = 0
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewAR")

                End With
                Return ds.Tables("dtViewAR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetDocList(ByVal pSiteCode As Long, ByVal pReferenceNo As String) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIList)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.Number)).Value = pReferenceNo
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = 1
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewAR")

                End With
                Return ds.Tables("dtViewAR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetDocList(ByVal pSiteCode As Long, ByVal pStartDate As Date?, ByVal pEndDate As Date?) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIList)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = pStartDate
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = pEndDate
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.VarChar)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = 0
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewAR")

                End With
                Return ds.Tables("dtViewAR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"
        Public Sub AlterARPayDetails(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spAlterARPayDetails)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pID", OracleType.Number)).Value = pObject.ARPayDetailsID                   '1
                        .Add(New OracleParameter("pARNo", OracleType.Number)).Value = pObject.ARNo                           '2
                        .Add(New OracleParameter("pPaymentType", OracleType.VarChar)).Value = pObject.PaymentType            '3
                        .Add(New OracleParameter("pAmount", OracleType.Double)).Value = pObject.Amount                       '4
                        .Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value = pObject.ReferenceNo            '5
                        .Add(New OracleParameter("pBatchNumber", OracleType.Number)).Value = pObject.BatchNumber             '6
                        .Add(New OracleParameter("pBank", OracleType.VarChar)).Value = pObject.Bank                          '7
                        .Add(New OracleParameter("pBankBranch", OracleType.VarChar)).Value = pObject.BankBranch              '8
                        .Add(New OracleParameter("pBankNetwork", OracleType.VarChar)).Value = pObject.BankNetwork            '9
                        .Add(New OracleParameter("pTerminalUse", OracleType.VarChar)).Value = pObject.TerminalUse            '10
                        .Add(New OracleParameter("pMerchantID", OracleType.VarChar)).Value = pObject.MerchantID              '11
                        .Add(New OracleParameter("pPaymentDate", OracleType.DateTime)).Value = pObject.PaymentDate           '12
                        .Add(New OracleParameter("pAccountType", OracleType.VarChar)).Value = pObject.AccountType            '13
                        .Add(New OracleParameter("pAccountNo", OracleType.VarChar)).Value = pObject.AccountNo                '14
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks                    '15
                        .Add(New OracleParameter("pServiceFeeRate", OracleType.Double)).Value = pObject.ServiceFeeRate       '16
                        .Add(New OracleParameter("pServiceFeeAmt", OracleType.Double)).Value = pObject.ServiceFeeAmt         '17
                        .Add(New OracleParameter("pStatus", OracleType.VarChar)).Value = pObject.Status                      '18
                        .Add(New OracleParameter("pUser", OracleType.VarChar)).Value = pObject.LastUpdateBy                  '19
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                             '20
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output          '21
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
                        While .Read
                            If eDBAction.isSuccessful(.Item("message")) Then
                                Reference = cDataType.fString.getReference(.Item("message"))
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

