#Region "Description"
' PAGE NAME     : DAL FOR OR DETAILS 
' CREATED BY    : IBP
' CREATED DATE  : 03/15/2017
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
'Imports bllConn = Cocolife.BLL.Common.Database.BCisLife
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports cDataType = Cocolife.Utility.Common.DataType
Imports dalConstant = Cocolife.DAL.OCS.DConstant
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
#End Region

Namespace Reference


    Public Class DOrDetails

#Region "Variables"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        'Public Function GetORList(ByVal pSiteCode As Long, ByVal pStartDate As Date?, ByVal pEndDate As Date?) As DataTable

        '    Dim oraCmd As New OracleCommand(dalConstant._spOCSGetDocList)
        '    'Dim oraCmd As New OracleCommand(dalConstant._spOCSGetORList)
        '    Dim oraDA As OracleDataAdapter
        '    Dim ds As New DataSet

        '    Try
        '        With oraCmd

        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = bllConn.Instance.Connection
        '          If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

        '            .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
        '            .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = pStartDate
        '            .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = pEndDate
        '            .Parameters.Add(New OracleParameter("pDocNumber", OracleType.DateTime)).Value = Nothing
        '            .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

        '            oraDA = New OracleDataAdapter(oraCmd)
        '            oraDA.Fill(ds, "dtViewOR")
        '        End With
        '        Return ds.Tables("dtViewOR")

        '    Catch ex As Exception
        '        Throw
        '    Finally
        '        oraCmd.Dispose()
        '    End Try

        'End Function

        'Public Function GetORList(ByVal pSiteCode As Long, ByVal pDocNumber As Long) As DataTable
        '    Dim oraCmd As New OracleCommand(dalConstant._spOCSGetDocList)
        '    Dim oraDA As OracleDataAdapter
        '    Dim ds As New DataSet
        '    Try
        '        With oraCmd
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = bllConn.Instance.Connection
        '          If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

        '            .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
        '            .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = Nothing
        '            .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = Nothing
        '            .Parameters.Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
        '            .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

        '            oraDA = New OracleDataAdapter(oraCmd)
        '            oraDA.Fill(ds, "dtViewOPR")

        '        End With
        '        Return ds.Tables("dtViewOR")

        '    Catch ex As Exception
        '        Throw
        '    Finally
        '        oraCmd.Dispose()
        '    End Try
        'End Function

        Public Function GetORList(ByVal pSiteCode As Long, ByVal pStartDate As Date?, ByVal pEndDate As Date?) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetDocList)
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
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = Nothing
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewOR")

                End With
                Return ds.Tables("dtViewOR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetORList(ByVal pSiteCode As Long, ByVal pDocNumber As Long) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetDocList)
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
                    oraDA.Fill(ds, "dtViewOR")

                End With
                Return ds.Tables("dtViewOR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetORList(ByVal pSiteCode As Long, ByVal pStringParam As String, ByVal pStringType As Integer) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetDocList)
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
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.VarChar)).Value = pStringParam
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = pStringType
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewOR")

                End With
                Return ds.Tables("dtViewOR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function


#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace
