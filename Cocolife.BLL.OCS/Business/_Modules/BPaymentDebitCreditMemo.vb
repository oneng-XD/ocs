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
Imports dalReference = Cocolife.DAL.OCS.Reference
'Imports bllConn = Cocolife.BLL.Common.Database.BCisLife
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports bllCommon = Cocolife.BLL.Common
Imports bllReference = Cocolife.BLL.OCS.Reference
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllStaging = Cocolife.BLL.OCS.Staging
Imports System.Configuration
#End Region

Namespace Payment
    Public Class BPaymentDebitCreditMemo


#Region "Implements"
        Implements Payment.IPaymentDebitCreditMemo
#End Region 'Implements

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mReservedDMCMID As Long

        Private mDebitCreditMemo As Staging.BDebitCredit
#End Region 'Variables

#Region "Properties"
        Public Property IsSuccessful As Boolean Implements IPaymentDebitCreditMemo.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentDebitCreditMemo.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IPaymentDebitCreditMemo.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property
        Public Property ReservedDMCMID As Long Implements IPaymentDebitCreditMemo.ReservedDMCMID
            Get
                Return mReservedDMCMID
            End Get
            Set(value As Long)
                mReservedDMCMID = value
            End Set
        End Property

        Public Property DebitCreditMemo As Staging.BDebitCredit Implements IPaymentDebitCreditMemo.DebitCreditMemo
            Get
                Return mDebitCreditMemo
            End Get
            Set(value As Staging.BDebitCredit)
                mDebitCreditMemo = value
            End Set
        End Property
#End Region 'Properties


#Region "Transactions"
        Public Sub ProcessPaymentDebitCreditMemo() Implements IPaymentDebitCreditMemo.ProcessPaymentDebitCreditMemo
            Dim strItem As String = String.Empty
            'Dim objARPayDetails As New bllStaging.BAckReceipt
            Dim objDal As New dalReference.DSiteDetails

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False


                If Not IsNothing(DebitCreditMemo) Then
                    With DebitCreditMemo
                        .DMCMDate = Now.ToShortDateString()
                        strItem = .Alter("ACTIVE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("DMCM : ", strItem))
                        End If
                        ReservedDMCMID = strItem
                    End With
                End If

                'If lstForDeletion.Count > 0 Then
                'For Each item In lstForDeletion
                'strItem = item.Alter("DELETE", oraConn, oraTrans)
                'Next
                'End If



                'If Not IsNothing(ARPayDetails) Then
                'For Each item In ARPayDetails
                'If AckReceipt.AckReceiptNumber > 0 Then
                'item.ARNo = AckReceipt.AckReceiptNumber
                'End If
                'If item.ARPayDetailsID = 0 Then
                'strItem = item.Alter("INSERT", oraConn, oraTrans)
                'Else
                'strItem = item.Alter("UPDATE", oraConn, oraTrans)
                'End If
                'If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                'Throw New ArgumentException(String.Concat("ARPayDetails : ", strItem))
                'End If
                'Next
                'End If

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
        Public Sub SendPaymentDebitCreditMemo() Implements IPaymentDebitCreditMemo.SendPaymentDebitCreditMemo
            Dim strItem As String = String.Empty
            'Dim objARPayDetails As New bllStaging.BAckReceipt
            Dim objDal As New dalReference.DSiteDetails

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False


                If Not IsNothing(DebitCreditMemo) Then
                    With DebitCreditMemo
                        .DMCMDate = Now.ToShortDateString()
                        strItem = .Alter("FOR APPROVAL", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("DMCM : ", strItem))
                        End If
                        ReservedDMCMID = strItem
                    End With
                End If

                'If lstForDeletion.Count > 0 Then
                'For Each item In lstForDeletion
                'strItem = item.Alter("DELETE", oraConn, oraTrans)
                'Next
                'End If



                'If Not IsNothing(ARPayDetails) Then
                'For Each item In ARPayDetails
                'If AckReceipt.AckReceiptNumber > 0 Then
                'item.ARNo = AckReceipt.AckReceiptNumber
                'End If
                'If item.ARPayDetailsID = 0 Then
                'strItem = item.Alter("INSERT", oraConn, oraTrans)
                'Else
                'strItem = item.Alter("UPDATE", oraConn, oraTrans)
                'End If
                'If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                'Throw New ArgumentException(String.Concat("ARPayDetails : ", strItem))
                'End If
                'Next
                'End If

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
        Public Sub PrintPaymentDebitCreditMemo(ByVal pPdfBytes As Byte()) Implements IPaymentDebitCreditMemo.PrintPaymentDebitCreditMemo
            Dim strItem As String = String.Empty
            'Dim objARPayDetails As New bllStaging.BAckReceipt
            Dim objDal As New dalReference.DSiteDetails

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False


                If Not IsNothing(DebitCreditMemo) Then
                    With DebitCreditMemo
                        .DMCMDate = Now.ToShortDateString()
                        strItem = .Alter("PRINTED", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("DMCM : ", strItem))
                        End If
                        ReservedDMCMID = strItem
                    End With
                End If

                'If lstForDeletion.Count > 0 Then
                'For Each item In lstForDeletion
                'strItem = item.Alter("DELETE", oraConn, oraTrans)
                'Next
                'End If



                'If Not IsNothing(ARPayDetails) Then
                'For Each item In ARPayDetails
                'If AckReceipt.AckReceiptNumber > 0 Then
                'item.ARNo = AckReceipt.AckReceiptNumber
                'End If
                'If item.ARPayDetailsID = 0 Then
                'strItem = item.Alter("INSERT", oraConn, oraTrans)
                'Else
                'strItem = item.Alter("UPDATE", oraConn, oraTrans)
                'End If
                'If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                'Throw New ArgumentException(String.Concat("ARPayDetails : ", strItem))
                'End If
                'Next
                'End If

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
        Public Sub CancelPaymentDebitCreditMemo() Implements IPaymentDebitCreditMemo.CancelPaymentDebitCreditMemo
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try
                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction

                IsSuccessful = False


                With DebitCreditMemo
                    strItem = .Alter("CANCELLED", oraConn, oraTrans)
                End With

                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                    Throw New ArgumentException(String.Concat("DMCM : ", strItem))
                End If
                ReservedDMCMID = strItem
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
#End Region 'Transactions

    End Class
End Namespace
