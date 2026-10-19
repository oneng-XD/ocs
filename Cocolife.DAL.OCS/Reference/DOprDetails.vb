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
Imports dalConstant = Cocolife.DAL.OCS.DConstant
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
#End Region

Namespace Reference

    Public Class DOprDetails

#Region "Variables"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function GetOPRList(ByVal pSiteCode As Long, ByVal pParamType As Integer, ByVal pStartDate As Date?, ByVal pEndDate As Date?) As DataTable
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
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = pParamType
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewOPR")

                End With
                Return ds.Tables("dtViewOPR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetOPRList(ByVal pSiteCode As Long, ByVal pDocNumber As Long) As DataTable
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
                    oraDA.Fill(ds, "dtViewOPR")

                End With
                Return ds.Tables("dtViewOPR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetOPRList(ByVal pSiteCode As Long, ByVal pStringParam As String, ByVal pStringType As Integer) As DataTable
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
                    oraDA.Fill(ds, "dtViewOPR")

                End With
                Return ds.Tables("dtViewOPR")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetNewApplicationNo() As Long
           
            Dim oraCmd As New OracleCommand(DConstant._spCISGenerateUwpron)
            Dim oraDR As OracleDataReader = Nothing
            Dim lngReference As Long

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        lngReference = 0
                        While .Read
                            If eDBAction.isSuccessful(.Item("message")) Then
                                lngReference = cDataType.fLong.getReference(.Item("message"))
                            Else
                                Throw New Exception(.Item("message"))
                            End If
                        End While
                    End With

                End With

                Return lngReference

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetCalcODI(ByVal pPolicyNumber As String, ByVal pTrndat As Date, ByVal pPremium As Decimal) As Decimal

            Dim OraCmd As New OracleCommand(dalConstant._sfCISCalcOdi)
            Dim OraDR As OracleDataReader = Nothing
            Dim decOdiAmt As Decimal = 0

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("p_polnum", OracleType.VarChar)).Value = pPolicyNumber
                        .Add(New OracleParameter("p_trndte", OracleType.DateTime)).Value = pTrndat
                        .Add(New OracleParameter("p_amount", OracleType.Number)).Value = pPremium
                        .Add(New OracleParameter("v_odiamt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    decOdiAmt = .Parameters("v_odiamt").Value
                    .Parameters.Clear()
                End With

                Return decOdiAmt

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

        Public Function GetCalcODIVL(ByVal pPolicyNumber As String, ByVal pTrndat As Date, ByVal pPremium As Decimal) As Decimal

            Dim OraCmd As New OracleCommand(dalConstant._sfCISVLCalcOdi)
            Dim OraDR As OracleDataReader = Nothing
            Dim decOdiAmt As Decimal = 0

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("p_polnum", OracleType.VarChar)).Value = pPolicyNumber
                        .Add(New OracleParameter("p_trndte", OracleType.DateTime)).Value = pTrndat
                        .Add(New OracleParameter("p_amount", OracleType.Number)).Value = pPremium
                        .Add(New OracleParameter("v_odiamt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    decOdiAmt = .Parameters("v_odiamt").Value
                    .Parameters.Clear()
                End With

                Return decOdiAmt

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

        Public Function GetBatchOprList(ByVal pBatchId As Long) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetMwiPrintOr)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction
                    .Parameters.Add(New OracleParameter("pBatchID", OracleType.Number)).Value = pBatchId
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtOprList")

                End With
                Return ds.Tables("dtOprList")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetPremiumBreakdown(ByVal pPolicyNumber As String) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spGetPremiumBreakdown)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pPolNum", OracleType.VarChar)).Value = pPolicyNumber
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtPremiumBreakdown")

                End With
                Return ds.Tables("dtPremiumBreakdown")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"

        'Public Function GetLastOPR(pPrspid) As OracleDataReader

        '    Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetLastOPR)
        '    Dim OraDR As OracleDataReader = Nothing

        '    Try

        '        With oraCmd
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = bllConn.Instance.Connection
        '          If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

        '            With .Parameters
        '                .Add(New OracleParameter("pPrspid", OracleType.Number)).Value = pPrspid
        '                .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
        '            End With

        '            OraDR = .ExecuteReader
        '        End With

        '        Return OraDR

        '    Catch ex As Exception
        '        Throw
        '    Finally
        '        oraCmd.Dispose()
        '    End Try
        'End Function

#End Region

    End Class

End Namespace

