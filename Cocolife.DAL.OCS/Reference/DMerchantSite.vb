#Region "Description"
' PAGE NAME     : Merchant Site DLL 
' CREATED BY    : EJ 
' CREATED DATE  : 09/15/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports cDataType = Cocolife.Utility.Common.DataType
Imports dalConstant = Cocolife.DAL.OCS.DConstant
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
#End Region

Namespace Reference

    Public Class DMerchantSite

#Region "Variables"
        Private mReference As Object
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

        Public Function GetRefMerchantSiteList(ByVal pSiteCode As Long) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetMerchantSite)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtRefMerchantSiteList")

                End With
                Return ds.Tables("dtRefMerchantSiteList")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterMerchantSite(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spAlterMerchantSite)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.MerchantEditId
                        .Add(New OracleParameter("pTerminalId", OracleType.VarChar)).Value = pObject.TerminalId             ' 1
                        .Add(New OracleParameter("pMerchantId", OracleType.VarChar)).Value = pObject.MerchantId             ' 2
                        .Add(New OracleParameter("pDbaName", OracleType.VarChar)).Value = pObject.DbaName                  ' 3
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pObject.SiteCode                ' 4
                        .Add(New OracleParameter("pEffDate", OracleType.DateTime)).Value = pObject.EffDate                  ' 5
                        .Add(New OracleParameter("pTermDate", OracleType.DateTime)).Value = pObject.TermDate                ' 6
                        .Add(New OracleParameter("pStatusId", OracleType.Number)).Value = pObject.StatusId
                        .Add(New OracleParameter("pPostBy", OracleType.Number)).Value = pObject.UserId
                        .Add(New OracleParameter("pPostDate", OracleType.DateTime)).Value = Now
                        .Add(New OracleParameter("pLastUpdateBy", OracleType.Number)).Value = pObject.UserId
                        .Add(New OracleParameter("pLastUpdate", OracleType.DateTime)).Value = Now
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

