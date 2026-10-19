#Region "Description"
' PAGE NAME     : AGNMAS DAL  
' CREATED BY    : MPRO
' CREATED DATE  : 04/30/2013
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
Imports System.Configuration
#End Region

Namespace Person

    Public Class DAgnMas

#Region "Variables"

#End Region

#Region "Single Point Functions"

        Public Function GetAgnMas(ByVal pAgnPrs As Long) As OracleDataReader

            Dim oraCmd As New OracleCommand(dalConstant._spCISGetAgnmas)
            Dim OraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgnPrs", OracleType.Number)).Value = pAgnPrs
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDR = .ExecuteReader
                End With

                Return OraDR

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetAgentInfo(ByVal pAgnPrs As Long, ByVal pDate As Date, ByVal pCol As Integer) As String
            Dim OraCmd As New OracleCommand(dalConstant._sfGetAgentInfoAdj)
            Dim OraDR As OracleDataReader = Nothing
            Dim strInfo As String = cDataType.fString.Empty

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("p_agt_code", OracleType.Number)).Value = pAgnPrs
                        .Add(New OracleParameter("p_date", OracleType.DateTime)).Value = pDate
                        .Add(New OracleParameter("p_col", OracleType.Number)).Value = pCol
                        .Add(New OracleParameter("p_current", OracleType.Number)).Value = 0
                        .Add(New OracleParameter("vInfo", OracleType.VarChar, 300)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    strInfo = .Parameters("vInfo").Value
                    .Parameters.Clear()
                End With

                Return strInfo

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try
        End Function

        Public Function GetAgencyFund(ByVal pAgtPrsPID As Long) As Long

            Dim OraCmd As New OracleCommand(dalConstant._sfCISGetAgencyfund)
            Dim OraDR As OracleDataReader = Nothing
            Dim lngPrsPID As Long = 0

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgtPrsPID", OracleType.Number)).Value = pAgtPrsPID
                        .Add(New OracleParameter("vPrsPID", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    lngPrsPID = .Parameters("vPrsPID").Value
                    .Parameters.Clear()
                End With

                Return lngPrsPID

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

        Public Function GetAgentOR(ByVal pAgentCode As Long) As Boolean

            Dim OraCmd As New OracleCommand(dalConstant._sfOCSGetAgentOrCount)
            Dim OraDR As OracleDataReader = Nothing
            Dim blnReturn As Boolean

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgentCode", OracleType.Number)).Value = pAgentCode
                        .Add(New OracleParameter("vCount", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    blnReturn = CBool(.Parameters("vCount").Value)
                    .Parameters.Clear()
                End With

                Return blnReturn

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

        Public Function GetAgentSalesForce(ByVal pAgentCode As Long, ByVal pDate As Date) As String

            Dim OraCmd As New OracleCommand(dalConstant._sfGetSalesForce)
            Dim OraDR As OracleDataReader = Nothing
            Dim strSalesForce As String = String.Empty

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgentCode", OracleType.Number)).Value = pAgentCode
                        .Add(New OracleParameter("pDate", OracleType.DateTime)).Value = pDate
                        .Add(New OracleParameter("vSalesForce", OracleType.VarChar, 4)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    strSalesForce = .Parameters("vSalesForce").Value
                    .Parameters.Clear()
                End With

                Return strSalesForce

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

        Public Function GetAgentGpaCommRate(ByVal pAgentCode As Long, ByVal pDate As Date) As Decimal

            Dim OraCmd As New OracleCommand(dalConstant._sfGetGpaCommRate)
            Dim OraDR As OracleDataReader = Nothing
            Dim decCommRate As Decimal

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgentCode", OracleType.Number)).Value = pAgentCode
                        .Add(New OracleParameter("pDate", OracleType.DateTime)).Value = pDate
                        .Add(New OracleParameter("vCommRate", OracleType.Double)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    decCommRate = .Parameters("vCommRate").Value
                    .Parameters.Clear()
                End With

                Return decCommRate

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

        Public Function GetAgentTaxRate(ByVal pAcctgPd As Long, ByVal pAgentCode As Long) As Decimal

            Dim OraCmd As New OracleCommand(dalConstant._sfGetTaxRate)
            Dim OraDR As OracleDataReader = Nothing
            Dim decTaxRate As Decimal

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("p_acctg_pd", OracleType.Number)).Value = pAcctgPd
                        .Add(New OracleParameter("p_agt_code", OracleType.Number)).Value = pAgentCode
                        .Add(New OracleParameter("vTaxRate", OracleType.Double)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    decTaxRate = .Parameters("vTaxRate").Value
                    .Parameters.Clear()
                End With

                Return decTaxRate

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
            End Try

        End Function

#End Region

#Region "Data Retrieval"

        Public Function SearchAgnMas(ByVal pAgnPrs As Long, ByVal pAgnNme As String, ByVal pAgnEnd As Date, ByVal pPolType As String) As DataTable
            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            If String.IsNullOrEmpty(apiUsername) OrElse String.IsNullOrEmpty(apiPassword) OrElse String.IsNullOrEmpty(apiGrantType) Then
                Throw New ConfigurationErrorsException("Required NEWGEN API settings are missing from Web.config.")
            End If

            Dim oraCmd As New OracleCommand(dalConstant._spOCSSearchAgent)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgnPrs", OracleType.Number)).Value = pAgnPrs
                        .Add(New OracleParameter("pAgnNme", OracleType.VarChar)).Value = pAgnNme
                        .Add(New OracleParameter("pAgnEnd", OracleType.DateTime)).Value = pAgnEnd
                        .Add(New OracleParameter("pPolType", OracleType.VarChar)).Value = pPolType
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value = apiUsername
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = apiPassword
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = apiGrantType
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchAGNMAS")
                End With

                Return ds.Tables("dtSearchAGNMAS")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        ' ------------------------------------------------------------------------------- 

        Public Function ValidateAgent(ByVal pAgnPrs As Long, ByVal pUwDate As Date) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spCISValidateAgent)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pAgnPrs", OracleType.Number)).Value = pAgnPrs
                        .Add(New OracleParameter("pUwDate", OracleType.DateTime)).Value = pUwDate
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtValidateAgent")
                End With

                Return ds.Tables("dtValidateAgent")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

#End Region

#Region "Transactions"

        Public Function AlterAgnMas(ByVal pList As IList, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction) As String

            Dim OraCmd As New OracleCommand(dalConstant._spCISAlterAgnmas)
            Dim OraDR As OracleDataReader = Nothing
            Dim strItem As String = String.Empty

            Try

                With OraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    For Each lstItem In pList

                        With .Parameters
                            .Add(New OracleParameter("pAgnPrs", OracleType.Number)).Value = lstItem.AgnPrs
                            .Add(New OracleParameter("pAgnCon", OracleType.VarChar)).Value = lstItem.AgnCon
                            .Add(New OracleParameter("pAgnBrn", OracleType.Number)).Value = lstItem.AgnBrn
                            .Add(New OracleParameter("pAgnOvr", OracleType.Number)).Value = lstItem.AgnOvr
                            .Add(New OracleParameter("pAgnLoc", OracleType.VarChar)).Value = lstItem.AgnLoc
                            .Add(New OracleParameter("pAgnDat", OracleType.DateTime)).Value = lstItem.AgnDat
                            .Add(New OracleParameter("pAgnEnd", OracleType.DateTime)).Value = lstItem.AgnEnd
                            .Add(New OracleParameter("pCatCod", OracleType.VarChar)).Value = lstItem.CatCod
                            .Add(New OracleParameter("pAction", OracleType.VarChar)).Value = pAction
                            .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With

                        OraDR = .ExecuteReader
                        With OraDR.Read()
                            strItem = OraDR.Item(0).ToString
                        End With

                        .Parameters.Clear()
                        If Left(strItem, 2) <> "OK" Then Throw New Exception(strItem)
                    Next

                End With

                Return strItem

            Catch ex As Exception
                Throw
            Finally
                OraCmd.Dispose()
                If Not IsNothing(OraDR) Then
                    OraDR.Dispose()
                End If
            End Try

        End Function

#End Region

    End Class

End Namespace


