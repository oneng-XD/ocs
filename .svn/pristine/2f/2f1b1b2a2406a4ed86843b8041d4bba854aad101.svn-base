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

    Public Class DSiteBatch

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

        Public Sub AlterSiteBatch(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSProcessBatch)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pBatchId", OracleType.Number)).Value = pObject.BatchId
                        .Add(New OracleParameter("pUserId", OracleType.Number)).Value = pObject.UserId
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pObject.SiteId
                        .Add(New OracleParameter("pNonPrem", OracleType.Number)).Value = pObject.NonPrem
                        .Add(New OracleParameter("pOprDate", OracleType.DateTime)).Value = pObject.OprDate
                        .Add(New OracleParameter("pCheckNo", OracleType.Number)).Value = pObject.CheckNo
                        .Add(New OracleParameter("pBank", OracleType.VarChar, 15)).Value = pObject.Bank
                        .Add(New OracleParameter("pBranch", OracleType.VarChar, 15)).Value = pObject.Branch
                        .Add(New OracleParameter("pCurrency", OracleType.VarChar, 3)).Value = pObject.Currency
                        .Add(New OracleParameter("pPayType", OracleType.VarChar, 3)).Value = pObject.PayType
                        .Add(New OracleParameter("pAprDate", OracleType.DateTime)).Value = pObject.AprDate
                        .Add(New OracleParameter("pAprNumber", OracleType.Number)).Value = pObject.AprNumber
                        .Add(New OracleParameter("pOprRemarks", OracleType.VarChar, 60)).Value = pObject.OprRemarks
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
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

