#Region "Description"
' PAGE NAME     : SITE_ORCOLDTL DAL
' CREATED BY    : IBP 
' CREATED DATE  : 03/13/2017
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

    Public Class DSiteORColDtl

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

#Region "Single Point Function"

#End Region

#Region "Data Retrieval"

        Public Function GetSiteORColDtl(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetSiteOrCollDtl)
            'Dim OraDR As OracleDataReader = Nothing

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
                    OraDA.Fill(ds, "dtORCol")

                End With

                Return ds.Tables("dtORCol")


            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function


#End Region

#Region "Transactions"
        Public Sub AlterSiteORColDtl(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteOrCollDtl)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id                              '1
                        .Add(New OracleParameter("pORNmbr", OracleType.Number)).Value = pObject.ORNmbr                      '2
                        .Add(New OracleParameter("pLot", OracleType.Number)).Value = pObject.Lot                            '3
                        .Add(New OracleParameter("pProduct", OracleType.VarChar)).Value = pObject.Product                   '4
                        .Add(New OracleParameter("pSectionId", OracleType.VarChar)).Value = pObject.SectionId                '5
                        .Add(New OracleParameter("pSector", OracleType.VarChar)).Value = pObject.Sector                     '6
                        .Add(New OracleParameter("pBlockNo", OracleType.VarChar)).Value = pObject.BlockNo                   '7
                        .Add(New OracleParameter("pLotListPrice", OracleType.Number)).Value = pObject.LotListPrice          '8
                        .Add(New OracleParameter("pDiscountRate", OracleType.Number)).Value = pObject.DiscountRate          '9
                        .Add(New OracleParameter("pVAT", OracleType.Number)).Value = pObject.VAT                            '10
                        .Add(New OracleParameter("pReservationAmt", OracleType.Number)).Value = pObject.ReservationAmt      '11
                        .Add(New OracleParameter("pStatusId", OracleType.Number)).Value = pObject.StatusId                  '12
                        .Add(New OracleParameter("pPostBy", OracleType.Number)).Value = pObject.PostBy                      '13
                        .Add(New OracleParameter("pPostDate", OracleType.DateTime)).Value = pObject.PostDate                '14
                        .Add(New OracleParameter("pLastUpdateBy", OracleType.Number)).Value = pObject.LastUpdateBy          '15
                        .Add(New OracleParameter("pLastUpdate", OracleType.DateTime)).Value = pObject.LastUpdate            '16
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction                            '17
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output         '18
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