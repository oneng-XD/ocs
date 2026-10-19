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
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
'Imports bllConn = Cocolife.BLL.Common.Database.BCisLife
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports dalReference = Cocolife.DAL.OCS.Reference
Imports bllReference = Cocolife.BLL.OCS.Reference
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllStaging = Cocolife.BLL.OCS.Staging
Imports System.Configuration
#End Region

Namespace Payment

    Public Class BPaymentSalesInvoice

#Region "Implements"
        Implements Payment.IPaymentSalesInvoice
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mRoleCode As String
        '--------------------------------------------------------
        ' Working Tables
        '--------------------------------------------------------
        Private mSalesInvoice As Reference.BSalesInvoice

#End Region

#Region "Properties"
        Public Property IsSuccessful As Boolean Implements IPaymentSalesInvoice.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentSalesInvoice.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IPaymentSalesInvoice.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property
        Public Property RoleCode As String Implements IPaymentSalesInvoice.RoleCode
            Get
                Return mRoleCode
            End Get
            Set(value As String)
                mRoleCode = value
            End Set
        End Property


        Public Property SalesInvoice As Reference.BSalesInvoice Implements IPaymentSalesInvoice.SalesInvoice
            Get
                Return mSalesInvoice
            End Get
            Set(value As Reference.BSalesInvoice)
                mSalesInvoice = value
            End Set
        End Property
#End Region

#Region "Constructor"

        Sub New()

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Sub ProcessPaymentSalesInvoice() Implements IPaymentSalesInvoice.ProcessPaymentSalesInvoice
            Dim strItem As String = String.Empty
            Dim objDal As New dalReference.DSiteDetails
            Dim objSalesInvoice As New bllReference.BSalesInvoice

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False


                If Not IsNothing(SalesInvoice) Then

                    If SalesInvoice.InvoiceNumber = 0 Then
                        SalesInvoice.InvoiceNumber = objDal.GetNextSalesInvoice(SalesInvoice.SiteCode, SalesInvoice.SIPrintedBy)
                        SalesInvoice.InvoiceDate = Now.ToShortDateString()
                        If SalesInvoice.InvoiceNumber = 0 Then Throw New ArgumentException("No available document series.")
                    End If

                    'strItem = SalesInvoice.Alter("READY", SalesInvoice.ReferenceNo, SalesInvoice.InvoiceNumber, SalesInvoice.InvoiceDate, SalesInvoice.InvoiceRemarks, SalesInvoice.InvoiceOtherInfo, UserID, SiteCode, oraConn, oraTrans)
                    If SalesInvoice.IsFromNewgenAPI Then
                        strItem = SalesInvoice.SaveNewgenSalesInvoice(UserID, SiteCode, oraConn, oraTrans)

                    Else
                        strItem = SalesInvoice.Alter("READY", SalesInvoice.ReferenceNo, SalesInvoice.InvoiceNumber, SalesInvoice.InvoiceDate, SalesInvoice.InvoiceRemarks, SalesInvoice.InvoiceOtherInfo, UserID, SiteCode, oraConn, oraTrans)
                    End If
                   
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("SalesInvoice : ", strItem))
                    End If
                End If

                oraTrans.Commit()
                IsSuccessful = True

            Catch ex As Exception
                oraTrans.Rollback()
                IsSuccessful = False
                Throw
            Finally
                OracleConnection.ClearPool(oraConn)
                oraConn.Close()
                oraConn.Dispose()
            End Try


        End Sub

        Public Sub CancelPaymentSalesInvoice() Implements IPaymentSalesInvoice.CancelPaymentSalesInvoice
            Dim strItem As String = String.Empty

            Dim objSalesInvoice As New bllReference.BSalesInvoice

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try
                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction

                IsSuccessful = False

                strItem = SalesInvoice.Alter("CANCELLED", SalesInvoice.ReferenceNo, SalesInvoice.InvoiceNumber, SalesInvoice.InvoiceDate, SalesInvoice.InvoiceRemarks, SalesInvoice.InvoiceOtherInfo, UserID, SiteCode, oraConn, oraTrans)
                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                    Throw New ArgumentException(String.Concat("SalesInvoice : ", strItem))
                End If
                '-------------------------------------

                oraTrans.Commit()
                IsSuccessful = True

            Catch ex As Exception
                oraTrans.Rollback()
                IsSuccessful = False
                Throw New Exception(String.Concat(ex.Message, "<br /> <br />Make sure the Invoice is Already Printed!"))
            Finally
                OracleConnection.ClearPool(oraConn)
                oraConn.Close()
                oraConn.Dispose()
            End Try

        End Sub

#End Region

    End Class

End Namespace