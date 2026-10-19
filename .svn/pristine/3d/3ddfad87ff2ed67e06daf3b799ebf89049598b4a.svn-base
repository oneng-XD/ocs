#Region "Description"
' PAGE NAME     : TBL_AGT_OR_REG DAL
' CREATED BY    : EJ 
' CREATED DATE  : 04/20/2018
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

    Public Class DAgtOrReg

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

        Public Function GetSeriesList(ByVal pAgentId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spGetAgtOrReg)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgentId", OracleType.Number)).Value = pAgentId
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

        Public Sub AlterAgtOrReg(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spOCSAlterAgtOrReg)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pRowId", OracleType.VarChar)).Value = pObject.SeriesEditId
                        .Add(New OracleParameter("pAgnPrs", OracleType.Number)).Value = pObject.SeriesAgent
                        .Add(New OracleParameter("pRegNum", OracleType.VarChar)).Value = pObject.SeriesRegNum
                        .Add(New OracleParameter("pRegDate", OracleType.DateTime)).Value = pObject.SeriesRegDate
                        .Add(New OracleParameter("pOrBookFr", OracleType.Number)).Value = pObject.SeriesStart
                        .Add(New OracleParameter("pOrBookTo", OracleType.Number)).Value = pObject.SeriesEnd
                        .Add(New OracleParameter("pRegExpDate", OracleType.DateTime)).Value = pObject.SeriesExpDate
                        .Add(New OracleParameter("pUpdateBy", OracleType.VarChar)).Value = pObject.UserID
                        .Add(New OracleParameter("pUpdateDate", OracleType.DateTime)).Value = pObject.LastUpdate
                        .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = String.Empty
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

