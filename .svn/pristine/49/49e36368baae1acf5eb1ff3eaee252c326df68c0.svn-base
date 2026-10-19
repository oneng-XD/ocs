#Region "Description"
' PAGE NAME     : NEWGEN POST PAYMENT DAL
' CREATED BY    : EJ 
' CREATED DATE  : 04/15/2021
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
'Imports bllConn = Cocolife.BLL.Common.Database.BCisLife
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
Imports dConstant = Cocolife.DAL.OCS.DConstant
Imports System.Configuration
#End Region

Namespace Staging

    Public Class DNewgenLifePayment

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

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Sub NewgenPayment(ByVal pObject As Object, ByVal pAction As String, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            'If String.IsNullOrEmpty(apiUsername) OrElse String.IsNullOrEmpty(apiPassword) OrElse String.IsNullOrEmpty(apiGrantType) Then
            '    Throw New ConfigurationErrorsException("Required NEWGEN API settings are missing from Web.config.")
            'End If

            Dim oraCmd As New OracleCommand(DConstant._spNewgenPayment)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pDateOfReceipt", OracleType.VarChar)).Value = pObject.DateOfReceipt
                        .Add(New OracleParameter("pApplicationNo", OracleType.VarChar)).Value = pObject.ApplicationNo
                        .Add(New OracleParameter("pPolicyNo", OracleType.VarChar)).Value = pObject.PolicyNo
                        .Add(New OracleParameter("pPayorName", OracleType.VarChar)).Value = pObject.PayorName
                        .Add(New OracleParameter("pAPR", OracleType.VarChar)).Value = pObject.APR
                        .Add(New OracleParameter("pAPRDate", OracleType.VarChar)).Value = pObject.APRDate
                        .Add(New OracleParameter("pCurrency", OracleType.VarChar)).Value = pObject.Currency
                        .Add(New OracleParameter("pTotalAmount", OracleType.VarChar)).Value = pObject.TotalAmount
                        .Add(New OracleParameter("pBusinessType", OracleType.VarChar)).Value = pObject.BusinessType
                        .Add(New OracleParameter("pBillNo", OracleType.VarChar)).Value = pObject.BillNo
                        .Add(New OracleParameter("pRetainedAmount", OracleType.VarChar)).Value = pObject.RetainedAmount
                        .Add(New OracleParameter("pPaymentStatus", OracleType.VarChar)).Value = pObject.PaymentStatus
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pObject.Remarks

                        .Add(New OracleParameter("pSourceID", OracleType.VarChar)).Value = ""
                        .Add(New OracleParameter("pEWTAMT", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pVATAMT", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pGrossAmount", OracleType.VarChar)).Value = pObject.TotalAmount
                        .Add(New OracleParameter("pVatableCollection", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pVatExemptAmount", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pVatAmount", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pWithholdingTax", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pNetAmount", OracleType.VarChar)).Value = pObject.TotalAmount
                        .Add(New OracleParameter("pSubscriberNo", OracleType.VarChar)).Value = ""
                        .Add(New OracleParameter("pInvoiceType", OracleType.VarChar)).Value = "CI"
                        .Add(New OracleParameter("pInvoiceNo", OracleType.VarChar)).Value = pObject.ORNo
                        .Add(New OracleParameter("pAddress", OracleType.VarChar)).Value = ""
                        .Add(New OracleParameter("pTIN", OracleType.VarChar)).Value = ""
                        .Add(New OracleParameter("pVATABLE", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pNONVAT", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pNETWITHHOLDINGTAX", OracleType.VarChar)).Value = "0"
                        .Add(New OracleParameter("pDISCOUNT", OracleType.VarChar)).Value = "0"

                        .Add(New OracleParameter("pParticularsJSON", OracleType.Clob)).Value = pObject.ParticularsJSON
                        .Add(New OracleParameter("pPaymentModeJSON", OracleType.Clob)).Value = pObject.PaymentModeJSON

                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value = apiUsername
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = apiPassword
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = apiGrantType
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
                        While .Read

                            Dim strItem = oraDR.Item(0).ToString
                            If Left(strItem, 2) <> "OK" Then
                                Throw New Exception(strItem)
                            Else
                                Reference = Mid(strItem, 4)
                            End If

                            'If eDBAction.isSuccessful(.Item("message")) Then
                            '    Reference = cDataType.fLong.getReference(.Item("message"))
                            'Else
                            '    Throw New Exception(.Item("message"))
                            'End If
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

        Public Sub NewgenUpdatePayment(ByVal pOPRNo As String, ByVal pChequeNo As String, ByVal pAmount As Decimal, ByVal pPaymentStatus As String, pChequeClearanceStatus As String, pDateOfReceipt As Date, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            'If String.IsNullOrEmpty(apiUsername) OrElse String.IsNullOrEmpty(apiPassword) OrElse String.IsNullOrEmpty(apiGrantType) Then
            '    Throw New ConfigurationErrorsException("Required NEWGEN API settings are missing from Web.config.")
            'End If

            Dim oraCmd As New OracleCommand(DConstant._spNewgenUpdatePayment)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pInvoiceType", OracleType.VarChar)).Value = "CI"
                        .Add(New OracleParameter("pInvoiceNo", OracleType.VarChar)).Value = pOPRNo
                        .Add(New OracleParameter("pPaymentStatus", OracleType.VarChar)).Value = pPaymentStatus
                        .Add(New OracleParameter("pChequeNo", OracleType.VarChar)).Value = pChequeNo
                        .Add(New OracleParameter("pChequeClearanceStatus", OracleType.VarChar)).Value = pChequeClearanceStatus
                        .Add(New OracleParameter("pChequeAmount", OracleType.VarChar)).Value = pAmount.ToString()
                        .Add(New OracleParameter("pDateOfReceipt", OracleType.DateTime)).Value = pDateOfReceipt.ToString("MM/dd/yyyy HH:mm:ss")
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value = apiUsername
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = apiPassword
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = apiGrantType
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
                        While .Read

                            Dim strItem = oraDR.Item(0).ToString
                            If Left(strItem, 2) <> "OK" Then
                                Throw New Exception(strItem)
                            Else
                                Reference = Mid(strItem, 4)
                            End If

                            'If eDBAction.isSuccessful(.Item("message")) Then
                            '    Reference = cDataType.fLong.getReference(.Item("message"))
                            'Else
                            '    Throw New Exception(.Item("message"))
                            'End If
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

