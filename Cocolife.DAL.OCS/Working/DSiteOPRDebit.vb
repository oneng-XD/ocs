#Region "Description"
' PAGE NAME     : SITE_OPRDEBIT DAL
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

    Public Class DSiteOPRDebit

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

        Public Function GetSiteOPRDebit(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteOprDca)
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
                    OraDA.Fill(ds, "dtOPRDebit")

                End With
                Return ds.Tables("dtOPRDebit")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetOPRDebitByChargeSlip(ByVal pChargeSlipCode As String, ByVal pPayorId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetCardDetails)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pType", OracleType.VarChar)).Value = "DCA"
                        .Add(New OracleParameter("pCode", OracleType.VarChar)).Value = pChargeSlipCode
                        .Add(New OracleParameter("pPayorId", OracleType.Number)).Value = pPayorId
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtOPRDebit")

                End With
                Return ds.Tables("dtOPRDebit")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterSiteOPRDebit(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteOprDca)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
                        .Add(New OracleParameter("pOPRNmbr", OracleType.Number)).Value = pObject.OPRNmbr                    ' 1
                        .Add(New OracleParameter("pBankNetwork", OracleType.VarChar)).Value = pObject.BankNetwork           ' 2
                        .Add(New OracleParameter("pBankName", OracleType.VarChar)).Value = pObject.BankName                 ' 3
                        .Add(New OracleParameter("pCASAType", OracleType.VarChar)).Value = pObject.CASAType                 ' 4
                        .Add(New OracleParameter("pAcctNo", OracleType.VarChar)).Value = pObject.AcctNo                     ' 5
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks                   ' 6
                        .Add(New OracleParameter("pAmount", OracleType.Double)).Value = pObject.Amount                      ' 7
                        .Add(New OracleParameter("pTerminalID", OracleType.VarChar)).Value = pObject.TerminalID             ' 8
                        .Add(New OracleParameter("pMerchantID", OracleType.VarChar)).Value = pObject.MerchantID             ' 9
                        .Add(New OracleParameter("pSwipeDate", OracleType.DateTime)).Value = pObject.SwipeDate              ' 10
                        .Add(New OracleParameter("pChargeSlipCode", OracleType.VarChar)).Value = pObject.ChargeSlipCode     ' 11
                        .Add(New OracleParameter("pBatchNumber", OracleType.Number)).Value = pObject.BatchNumber            ' 12
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


