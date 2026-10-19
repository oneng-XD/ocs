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
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
Imports dalConstant = Cocolife.DAL.OCS.DConstant
#End Region

Namespace Reference

    Public Class DHMOPayslip

#Region "Variables"
        Private mReference As Object = Nothing
#End Region

#Region "Properties"
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

        Public Function SearchPayslipCode(ByVal pPayslipCode As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spCCGetPayslipDtl)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPayslipCode", OracleType.VarChar)).Value = pPayslipCode
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchPayslipCode")
                End With

                Return ds.Tables("dtSearchPayslipCode")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function SearchPayslipCodeNGI(ByVal pPayslipCode As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spCCGetPayslipDtlNGI)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pPayslipCode", OracleType.VarChar)).Value = pPayslipCode
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchPayslipCode")
                End With

                Return ds.Tables("dtSearchPayslipCode")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

#End Region

#Region "Transactions"
        Public Sub Alter(ByVal pPayslipCode As String, ByVal pReceiptNumber As String, ByVal pReceiptDate As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim oraCmd As New OracleCommand(DConstant._spAlterPayslipDetails)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pPayslipCode", OracleType.VarChar)).Value = pPayslipCode                       ' 1
                        .Add(New OracleParameter("pReceiptNumber", OracleType.VarChar)).Value = pReceiptNumber                   ' 2
                        .Add(New OracleParameter("pReceiptDate", OracleType.VarChar)).Value = pReceiptDate                       ' 3
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output             ' 4
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
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

