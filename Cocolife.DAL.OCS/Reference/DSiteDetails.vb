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
#End Region

Namespace Reference

    Public Class DSiteDetails

#Region "Variables"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function GetSiteDetails(ByVal pPrspid As Long) As OracleDataReader

            Dim oraCmd As New OracleCommand(dalConstant._spOCSGetSiteDetail)
            Dim OraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPrspid", OracleType.Number)).Value = pPrspid
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

        Public Function GetLastReceipt(ByVal pSiteId As Long, ByVal pUserId As Long, ByRef pConn As OracleConnection, ByRef pTrans As OracleTransaction) As String

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetLastReceipt)
            Dim OraDR As OracleDataReader = Nothing
            Dim mLastOpr As String

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure

                    If pConn Is Nothing Then
                        .Connection = bllConn.Instance.Connection
                        If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction
                    Else
                        .Connection = pConn
                        .Transaction = pTrans
                    End If

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("pUserId", OracleType.Number)).Value = pUserId
                        .Add(New OracleParameter("LastOpr", OracleType.VarChar, 100)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    mLastOpr = .Parameters("LastOpr").Value
                    .Parameters.Clear()
                End With

                Return mLastOpr

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetLastSalesInvoice(ByVal pSiteId As Long, ByVal pUserId As Long, ByRef pConn As OracleConnection, ByRef pTrans As OracleTransaction) As String

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetLastSI)
            Dim OraDR As OracleDataReader = Nothing
            Dim mLastOpr As String

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure

                    If pConn Is Nothing Then
                        .Connection = bllConn.Instance.Connection
                        If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction
                    Else
                        .Connection = pConn
                        .Transaction = pTrans
                    End If

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("pUserId", OracleType.Number)).Value = pUserId
                        .Add(New OracleParameter("LastSI", OracleType.VarChar, 100)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    mLastOpr = .Parameters("LastSI").Value
                    .Parameters.Clear()
                End With

                Return mLastOpr

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetLastAckReceipt(ByVal pSiteId As Long, ByVal pUserId As Long, ByRef pConn As OracleConnection, ByRef pTrans As OracleTransaction) As String

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetLastAR)
            Dim OraDR As OracleDataReader = Nothing
            Dim mLastOpr As String

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure

                    If pConn Is Nothing Then
                        .Connection = bllConn.Instance.Connection
                        If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction
                    Else
                        .Connection = pConn
                        .Transaction = pTrans
                    End If

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("pUserId", OracleType.Number)).Value = pUserId
                        .Add(New OracleParameter("LastAR", OracleType.VarChar, 100)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    mLastOpr = .Parameters("LastAR").Value
                    .Parameters.Clear()
                End With

                Return mLastOpr

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetLastOR(ByVal pPrspid As Long) As String

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetLastOr)
            Dim OraDR As OracleDataReader = Nothing
            Dim strLastOr As String

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPrspid", OracleType.Number)).Value = pPrspid
                        .Add(New OracleParameter("LastOr", OracleType.VarChar, 100)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    strLastOr = .Parameters("LastOr").Value
                    .Parameters.Clear()
                End With

                Return strLastOr

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetNextReceipt(ByVal pSiteId As Long, ByVal pReceiptType As Integer, ByVal pUserId As Long) As Long

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetNextReceipt)
            Dim OraDR As OracleDataReader = Nothing
            Dim lngNextOpr As Long

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("pDocumentType", OracleType.Number)).Value = pReceiptType
                        Dim paramUserName As New OracleParameter("pUserName", OracleType.VarChar)
                        paramUserName.Size = 50 ' Match the length of the VARCHAR2 column
                        paramUserName.Value = If(pUserId = 0, "DefaultUser", pUserId.ToString()) ' Assign default if pUserId is 0
                        .Add(paramUserName)
                        '.Add(New OracleParameter("pLastOPR", OracleType.Number)).Value = pLastOPR
                        .Add(New OracleParameter("vNextOPR", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    lngNextOpr = .Parameters("vNextOPR").Value
                    .Parameters.Clear()
                End With

                Return cDataType.fLong.IfNull(lngNextOpr)

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetNextSalesInvoice(ByVal pSiteId As Long, ByVal pUserName As String) As Long

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetNextSI)
            Dim OraDR As OracleDataReader = Nothing
            Dim lngNextDocNo As Long

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("pDocumentType", OracleType.Number)).Value = 2
                        .Add(New OracleParameter("pUserName", OracleType.Number)).Value = pUserName
                        .Add(New OracleParameter("vNextDocNo", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    lngNextDocNo = .Parameters("vNextDocNo").Value
                    .Parameters.Clear()
                End With

                Return cDataType.fLong.IfNull(lngNextDocNo)

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetNextAckReceipt(ByVal pSiteId As Long, ByVal pUserName As String) As Long

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetNextAR)
            Dim OraDR As OracleDataReader = Nothing
            Dim lngNextDocNo As Long

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("pDocumentType", OracleType.Number)).Value = 3
                        .Add(New OracleParameter("pUserName", OracleType.Number)).Value = pUserName
                        .Add(New OracleParameter("vNextDocNo", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    lngNextDocNo = .Parameters("vNextDocNo").Value
                    .Parameters.Clear()
                End With

                Return cDataType.fLong.IfNull(lngNextDocNo)

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function
        Public Function GetNextMemo(ByVal pSiteId As Long, ByVal pUserName As String, ByVal pMemoType As Long) As Long

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSGetNextAR)
            Dim OraDR As OracleDataReader = Nothing
            Dim lngNextDocNo As Long

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteId", OracleType.Number)).Value = pSiteId
                        .Add(New OracleParameter("pDocumentType", OracleType.Number)).Value = pMemoType
                        .Add(New OracleParameter("pUserName", OracleType.Number)).Value = pUserName
                        .Add(New OracleParameter("vNextDocNo", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    lngNextDocNo = .Parameters("vNextDocNo").Value
                    .Parameters.Clear()
                End With

                Return cDataType.fLong.IfNull(lngNextDocNo)

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function IsOprProcessed(ByVal pDocNumber As Long, ByVal pDate? As Date) As Long

            Dim oraCmd As New OracleCommand(dalConstant._sfOCSIsProcessed)
            Dim OraDR As OracleDataReader = Nothing
            Dim lngCount As Long

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
                        .Add(New OracleParameter("pDate", OracleType.DateTime)).Value = pDate
                        .Add(New OracleParameter("vCount", OracleType.Number)).Direction = ParameterDirection.ReturnValue
                    End With

                    OraDR = .ExecuteReader
                    lngCount = .Parameters("vCount").Value
                    .Parameters.Clear()
                End With

                Return cDataType.fLong.IfNull(lngCount)

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

