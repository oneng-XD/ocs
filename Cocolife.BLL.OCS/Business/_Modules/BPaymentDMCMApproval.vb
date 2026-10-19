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
    Public Class BPaymentDMCMApproval


#Region "Implements"
        Implements Payment.IPaymentDMCMApproval
#End Region 'Implements

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mReservedDMCMID As Long

        Private mDebitCreditMemo As Staging.BDebitCredit
#End Region 'Variables


#Region "Properties"
        Public Property IsSuccessful As Boolean Implements IPaymentDMCMApproval.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentDMCMApproval.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IPaymentDMCMApproval.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property
        Public Property ReservedDMCMID As Long Implements IPaymentDMCMApproval.ReservedDMCMID
            Get
                Return mReservedDMCMID
            End Get
            Set(value As Long)
                mReservedDMCMID = value
            End Set
        End Property

        Public Property DebitCreditMemo As Staging.BDebitCredit Implements IPaymentDMCMApproval.DebitCreditMemo
            Get
                Return mDebitCreditMemo
            End Get
            Set(value As Staging.BDebitCredit)
                mDebitCreditMemo = value
            End Set
        End Property
#End Region 'Properties



#Region "Transactions"
        Public Sub ApprovePaymentDebitCreditMemo() Implements IPaymentDMCMApproval.ApprovePaymentDebitCreditMemo
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
                        If .DMCMNumber = 0 Then
                            If .MemoType = "DEBIT MEMO" Then
                                .DMCMNumber = objDal.GetNextMemo(.SiteCode, .PostedBy, 5)
                            Else
                                .DMCMNumber = objDal.GetNextMemo(.SiteCode, .PostedBy, 6)
                            End If
                            .DMCMDate = Now.ToShortDateString()
                            strItem = .Alter("APPROVED", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("DMCM : ", strItem))
                            End If
                            ReservedDMCMID = strItem
                        End If
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
        Public Sub RejectPaymentDebitCreditMemo() Implements IPaymentDMCMApproval.RejectPaymentDebitCreditMemo
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
                        strItem = .Alter("REJECTED", oraConn, oraTrans)
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
#End Region

















    End Class
End Namespace
