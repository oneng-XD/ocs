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
Imports System.Configuration
#End Region

Namespace Reference

    Public Class DNGIBillingDetails

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

        Public Function GetPolicyBilling(ByVal pPolicyNo As String, ByVal pBillNo As String, Optional ByVal pSubsNo As String = Nothing) As DataTable

            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            If String.IsNullOrEmpty(apiUsername) OrElse
               String.IsNullOrEmpty(apiPassword) OrElse
               String.IsNullOrEmpty(apiGrantType) Then

                Throw New ConfigurationErrorsException(
                    "Required NEWGEN API settings are missing from Web.config.")
            End If

            Using oraCmd As New OracleCommand(dalConstant._spNGIGetPolicyBilling)

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection

                    If bllConn.Instance.Transaction IsNot Nothing Then
                        .Transaction = bllConn.Instance.Transaction
                    End If

                    With .Parameters

                        .Add(New OracleParameter("pPolicyNo",OracleType.VarChar)).Value = pPolicyNo
                        .Add(New OracleParameter("pBillNo", OracleType.VarChar)).Value = If(String.IsNullOrWhiteSpace(pBillNo), CType(DBNull.Value, Object),CType(pBillNo, Object))
                        .Add(New OracleParameter("pSubscriberNo", OracleType.VarChar)).Value = If(String.IsNullOrWhiteSpace(pSubsNo), CType(DBNull.Value, Object),CType(pSubsNo, Object))
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pAPIUsername",  OracleType.VarChar)).Value = apiUsername
                        .Add(New OracleParameter("pAPIPassword",OracleType.VarChar)).Value = apiPassword
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = apiGrantType
                    End With
                End With

                Using oraDA As New OracleDataAdapter(oraCmd)
                    Dim dt As New DataTable("dtGetPolicyBilling")
                    oraDA.Fill(dt)
                    Return dt
                End Using

            End Using

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

