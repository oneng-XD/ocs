#Region "Description"
' PAGE NAME     : SITE_OPR_SERIES DAL
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

Namespace Maintenance

    Public Class DSiteOprSeries

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
        Public Function CheckOprSeries(ByVal pId As Long, ByVal pStart As Decimal, ByVal pEnd As Decimal) As Boolean
            Dim OraCmd As New OracleCommand(DConstant._sfOCSCheckExistingOPR)
            Dim OraDR As OracleDataReader = Nothing
            Dim mInfo As Byte = 1

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pId
                        .Add(New OracleParameter("pStart", OracleType.Number)).Value = pStart
                        .Add(New OracleParameter("pEnd", OracleType.Number)).Value = pEnd
                        .Add(New OracleParameter("vCount", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    mInfo = .Parameters("vCount").Value
                    .Parameters.Clear()
                End With

                Return CBool(mInfo)

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try
        End Function
#End Region

#Region "Data Retrieval"

        Public Function GetSeriesList(ByVal pSiteId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSGetOrSeries)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtSeriesList")

                End With
                Return ds.Tables("dtSeriesList")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Sub AlterSiteOprSeries(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterSiteOprSeries)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pId", OracleType.Number)).Value = pObject.Id
                        .Add(New OracleParameter("pPrspid", OracleType.Number)).Value = pObject.Prspid                             ' 1
                        .Add(New OracleParameter("pStartOprSeries", OracleType.Number)).Value = pObject.StartOprSeries             ' 2
                        .Add(New OracleParameter("pEndOprSeries", OracleType.VarChar)).Value = pObject.EndOprSeries                ' 3
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

