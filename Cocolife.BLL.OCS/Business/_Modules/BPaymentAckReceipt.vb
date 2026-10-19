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

    Public Class BPaymentAckReceipt

#Region "Implements"
        Implements Payment.IPaymentAckReceipt
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mReservedDocNo As Long
        '--------------------------------------------------------
        ' Working Tables
        '--------------------------------------------------------
        Private mAckReceipt As Staging.BAckReceipt
        Private mARPayDetails As IList(Of Staging.BARPayDetails)
        Private mLstForDeletion As IList(Of Object)

#End Region

#Region "Properties"
        Public Property IsSuccessful As Boolean Implements IPaymentAckReceipt.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentAckReceipt.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IPaymentAckReceipt.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property AckReceipt As Staging.BAckReceipt Implements IPaymentAckReceipt.AckReceipt
            Get
                Return mAckReceipt
            End Get
            Set(value As Staging.BAckReceipt)
                mAckReceipt = value
            End Set
        End Property

        Public Property ARPayDetails As IList(Of bllStaging.BARPayDetails) Implements IPaymentAckReceipt.ARPayDetails
            Get
                Return mARPayDetails
            End Get
            Set(value As IList(Of bllStaging.BARPayDetails))
                mARPayDetails = value
            End Set
        End Property

        Public Property ReservedDocNo As Long Implements IPaymentAckReceipt.ReservedDocNo
            Get
                Return mReservedDocNo
            End Get
            Set(value As Long)
                mReservedDocNo = value
            End Set
        End Property

        Public Property lstForDeletion As IList(Of Object) Implements IPaymentAckReceipt.lstForDeletion
            Get
                Return mLstForDeletion
            End Get
            Set(value As IList(Of Object))
                mLstForDeletion = value
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

        Public Sub ProcessPaymentAckReceipt() Implements IPaymentAckReceipt.ProcessPaymentAckReceipt
            Dim strItem As String = String.Empty
            Dim objARPayDetails As New bllStaging.BAckReceipt
            Dim objDal As New dalReference.DSiteDetails

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False


                If Not IsNothing(AckReceipt) Then
                    With AckReceipt
                        If .AckReceiptNumber = 0 Then
                            .AckReceiptNumber = objDal.GetNextAckReceipt(.SiteCode, .ARPrintedBy)
                            ReservedDocNo = .AckReceiptNumber
                            .ARDate = Now.ToShortDateString()
                            If .AckReceiptNumber = 0 Then Throw New ArgumentException("No available Receipt series.")
                        Else
                            ReservedDocNo = .AckReceiptNumber
                        End If

                        strItem = .Alter("READY", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("AckReceipt : ", strItem))
                        End If
                    End With
                End If

                If lstForDeletion.Count > 0 Then
                    For Each item In lstForDeletion
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                    Next
                End If

                

                If Not IsNothing(ARPayDetails) Then
                    For Each item In ARPayDetails
                        If AckReceipt.AckReceiptNumber > 0 Then
                            item.ARNo = AckReceipt.AckReceiptNumber
                        End If
                        If item.ARPayDetailsID = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("ARPayDetails : ", strItem))
                        End If
                    Next
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

        Public Sub PrintPaymentAckReceipt() Implements IPaymentAckReceipt.PrintPaymentAckReceipt
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False


                If Not IsNothing(AckReceipt) Then
                    With AckReceipt
                        strItem = .Alter("POSTED", oraConn, oraTrans)
                    End With
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("AckReceipt : ", strItem))
                    End If
                End If

                If ARPayDetails.Count > 0 Then
                    For Each item In ARPayDetails
                        If item.Status <> "DELETED" Then strItem = item.Alter("POST", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("AckReceipt : ", strItem))
                        End If
                    Next
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

        Public Sub CancelPaymentAckReceipt() Implements IPaymentAckReceipt.CancelPaymentAckReceipt
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try
                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction

                IsSuccessful = False
                With AckReceipt
                    strItem = .Alter("CANCELLED", oraConn, oraTrans)
                End With
                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                    Throw New ArgumentException(String.Concat("AckReceipt : ", strItem))
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