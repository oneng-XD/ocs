#Region "Description"
' PAGE NAME     : SITE_OPRCHKPY DAL
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

    Public Class DSiteOPRChkPy

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

        Public Function GetSiteOPRChkPy(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteOprCheck)
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
                    OraDA.Fill(ds, "dtOPRChkPy")

                End With
                Return ds.Tables("dtOPRChkPy")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetCheckTagging(ByVal pSiteCode As Long, ByVal pReceiptNo As Long, ByVal pCheckNo As Long, ByVal pFromDate As Date, ByVal pToDate As Date) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetCheckTagging)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                        .Add(New OracleParameter("pReceiptNo", OracleType.Number)).Value = pReceiptNo
                        .Add(New OracleParameter("pCheckNo", OracleType.Number)).Value = pCheckNo
                        .Add(New OracleParameter("pFromDate", OracleType.DateTime)).Value = pFromDate
                        .Add(New OracleParameter("pToDate", OracleType.DateTime)).Value = pToDate
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtOPRChkPy")

                End With
                Return ds.Tables("dtOPRChkPy")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterSiteOPRChkPy(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteOprCheck)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id                                  ' 1
                        .Add(New OracleParameter("pOPRNmbr", OracleType.Number)).Value = pObject.OPRNmbr                        ' 2
                        .Add(New OracleParameter("pChkNmbr", OracleType.Number)).Value = pObject.ChkNmbr                        ' 3
                        .Add(New OracleParameter("pBank", OracleType.VarChar)).Value = pObject.Bank                             ' 4
                        .Add(New OracleParameter("pBranch", OracleType.VarChar)).Value = pObject.Branch                         ' 5
                        .Add(New OracleParameter("pAmount", OracleType.Double)).Value = pObject.Amount                          ' 6
                        .Add(New OracleParameter("pLineNmbr", OracleType.Number)).Value = pObject.LineNmbr                      ' 7
                        .Add(New OracleParameter("pOTCFlag", OracleType.Number)).Value = pObject.OTCFlag                        ' 8
                        .Add(New OracleParameter("pDepositDate", OracleType.DateTime)).Value = pObject.DepositDate              ' 9
                        .Add(New OracleParameter("pClearingDate", OracleType.DateTime)).Value = pObject.ClearingDate            ' 10
                        .Add(New OracleParameter("pClearingStatusId", OracleType.Number)).Value = pObject.ClearingStatusId      ' 11
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks                       ' 12
                        .Add(New OracleParameter("pStatusId", OracleType.Number)).Value = pObject.StatusId                      ' 13
                        .Add(New OracleParameter("pPostBy", OracleType.Number)).Value = pObject.PostBy                          ' 14
                        .Add(New OracleParameter("pPostDate", OracleType.DateTime)).Value = pObject.PostDate                    ' 15
                        .Add(New OracleParameter("pLastUpdateBy", OracleType.Number)).Value = pObject.LastUpdateBy              ' 16
                        .Add(New OracleParameter("pLastUpdate", OracleType.DateTime)).Value = pObject.LastUpdate                ' 17
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                                ' 18
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output             ' 19
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

