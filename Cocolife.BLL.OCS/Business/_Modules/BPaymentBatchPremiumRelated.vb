#Region "Description"
' PAGE NAME     :  Batch Premium Related Payment BLL
' CREATED BY    :  EJ
' CREATED DATE  :  1/20/2017
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
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
#End Region

Namespace Payment

    Public Class BPaymentBatchPremiumRelated


#Region "Implements"
        Implements Payment.IPaymentBatchPremiumRelated
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mReservedReceiptNumber As Long
        Private mSiteOPRHeader As Working.BSiteOPRHeader
        Private mSiteOPRDtl As IList(Of Working.BSiteOPRDtl)
        Private mSiteOPRAPRPy As IList(Of Working.BSiteOPRAPRPy)
        Private mSiteOPRChkPy As IList(Of Working.BSiteOPRChkPy)
        Private mSiteTmpTrn As IList(Of Working.BSiteTmpTrn)
        Private mSiteBatch As Working.BSiteBatch
        Private mSiteBatchDtl As IList(Of Working.BSiteBatchDtl)
        Private mSiteRcptCtr As Working.BReceiptCounter
        Private mStgOPRHeader As Staging.BStgOPRHeader
        Private mStgOPRDtl As IList(Of Staging.BStgOPRDtl)
        Private mStgOPRAPRPy As IList(Of Staging.BStgOPRAPRPy)
        Private mStgOPRChkPy As IList(Of Staging.BStgOPRChkPy)
        Private mStgTmpTrn As IList(Of Staging.BStgTmpTrn)
        Private mIsAprTag As Boolean
        Private mLstForDeletion As IList(Of Object)
#End Region

#Region "Properties"

        Public Property IsSuccessful As Boolean Implements IPaymentBatchPremiumRelated.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentBatchPremiumRelated.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IPaymentBatchPremiumRelated.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property ReservedReceiptNumber As Long Implements IPaymentBatchPremiumRelated.ReservedReceiptNumber
            Get
                Return mReservedReceiptNumber
            End Get
            Set(value As Long)
                mReservedReceiptNumber = value
            End Set
        End Property

        Public Property SiteOPRAPRPy As IList(Of Working.BSiteOPRAPRPy) Implements IPaymentBatchPremiumRelated.SiteOPRAPRPy
            Get
                Return mSiteOPRAPRPy
            End Get
            Set(value As IList(Of Working.BSiteOPRAPRPy))
                mSiteOPRAPRPy = value
            End Set
        End Property

        Public Property SiteOPRChkPy As IList(Of Working.BSiteOPRChkPy) Implements IPaymentBatchPremiumRelated.SiteOPRChkPy
            Get
                Return mSiteOPRChkPy
            End Get
            Set(value As IList(Of Working.BSiteOPRChkPy))
                mSiteOPRChkPy = value
            End Set
        End Property

        Public Property SiteOPRDtl As IList(Of Working.BSiteOPRDtl) Implements IPaymentBatchPremiumRelated.SiteOPRDtl
            Get
                Return mSiteOPRDtl
            End Get
            Set(value As IList(Of Working.BSiteOPRDtl))
                mSiteOPRDtl = value
            End Set
        End Property

        Public Property SiteOPRHeader As Working.BSiteOPRHeader Implements IPaymentBatchPremiumRelated.SiteOPRHeader
            Get
                Return mSiteOPRHeader
            End Get
            Set(value As Working.BSiteOPRHeader)
                mSiteOPRHeader = value
            End Set
        End Property

        Public Property SiteBatch As Working.BSiteBatch Implements IPaymentBatchPremiumRelated.SiteBatch
            Get
                Return mSiteBatch
            End Get
            Set(value As Working.BSiteBatch)
                mSiteBatch = value
            End Set
        End Property

        Public Property SiteBatchDtl As IList(Of Working.BSiteBatchDtl) Implements IPaymentBatchPremiumRelated.SiteBatchDtl
            Get
                Return mSiteBatchDtl
            End Get
            Set(value As IList(Of Working.BSiteBatchDtl))
                mSiteBatchDtl = value
            End Set
        End Property

        Public Property SiteTmpTrn As IList(Of Working.BSiteTmpTrn) Implements IPaymentBatchPremiumRelated.SiteTmpTrn
            Get
                Return mSiteTmpTrn
            End Get
            Set(value As IList(Of Working.BSiteTmpTrn))
                mSiteTmpTrn = value
            End Set
        End Property

        Public Property StgOPRAPRPy As IList(Of Staging.BStgOPRAPRPy) Implements IPaymentBatchPremiumRelated.StgOPRAPRPy
            Get
                Return mStgOPRAPRPy
            End Get
            Set(value As IList(Of Staging.BStgOPRAPRPy))
                mStgOPRAPRPy = value
            End Set
        End Property

        Public Property StgOPRChkPy As IList(Of Staging.BStgOPRChkPy) Implements IPaymentBatchPremiumRelated.StgOPRChkPy
            Get
                Return mStgOPRChkPy
            End Get
            Set(value As IList(Of Staging.BStgOPRChkPy))
                mStgOPRChkPy = value
            End Set
        End Property

        Public Property StgOPRDtl As IList(Of Staging.BStgOPRDtl) Implements IPaymentBatchPremiumRelated.StgOPRDtl
            Get
                Return mStgOPRDtl
            End Get
            Set(value As IList(Of Staging.BStgOPRDtl))
                mStgOPRDtl = value
            End Set
        End Property

        Public Property StgOPRHeader As Staging.BStgOPRHeader Implements IPaymentBatchPremiumRelated.StgOPRHeader
            Get
                Return mStgOPRHeader
            End Get
            Set(value As Staging.BStgOPRHeader)
                mStgOPRHeader = value
            End Set
        End Property

        Public Property StgTmpTrn As IList(Of Staging.BStgTmpTrn) Implements IPaymentBatchPremiumRelated.StgTmpTrn
            Get
                Return mStgTmpTrn
            End Get
            Set(value As IList(Of Staging.BStgTmpTrn))
                mStgTmpTrn = value
            End Set
        End Property

        Public Property SiteRcptCtr As Working.BReceiptCounter Implements IPaymentBatchPremiumRelated.SiteRcptCtr
            Get
                Return mSiteRcptCtr
            End Get
            Set(value As Working.BReceiptCounter)
                mSiteRcptCtr = value
            End Set
        End Property

        Public Property IsAprTag() As Boolean Implements IPaymentBatchPremiumRelated.IsAprTag
            Get
                Return mIsAprTag
            End Get
            Set(ByVal value As Boolean)
                mIsAprTag = value
            End Set
        End Property

        Public Property lstForDeletion As IList(Of Object) Implements IPaymentBatchPremiumRelated.lstForDeletion
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

        Public Sub ProcessPaymentBatchPremiumRelated() Implements IPaymentBatchPremiumRelated.ProcessPaymentBatchPremiumRelated
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If Not SiteBatch.BatchId = 0 Then
                    strItem = SiteBatch.Alter("INSERT", oraConn, oraTrans)
                End If

                oraTrans.Commit()
                IsSuccessful = True

            Catch ex As Exception
                oraTrans.Rollback()
                IsSuccessful = False
                Throw New Exception(String.Concat("Your data may not have been saved correctly. Please review your data and try again. <br />", ex.Message))
            Finally
                OracleConnection.ClearPool(oraConn)
                oraConn.Close()
                oraConn.Dispose()
            End Try

        End Sub

        Public Sub CopyToStgObjects() Implements IPaymentBatchPremiumRelated.CopyToStgObjects
            Dim lstStgOPRDtl As New List(Of Staging.BStgOPRDtl)
            Dim lstStgOPRAPRPy As New List(Of Staging.BStgOPRAPRPy)
            Dim lstStgOPRChkPy As New List(Of Staging.BStgOPRChkPy)
            Dim lstStgTmpTrn As New List(Of Staging.BStgTmpTrn)
            Dim lstStgORPart As New List(Of Staging.BStgORPart)

            For Each item In SiteOPRDtl
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRDtl.Add(New Staging.BStgOPRDtl(item))
            Next
            For Each item In SiteOPRAPRPy
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRAPRPy.Add(New Staging.BStgOPRAPRPy(item))
            Next
            For Each item In SiteOPRChkPy
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRChkPy.Add(New Staging.BStgOPRChkPy(item))
            Next
            For Each item In SiteTmpTrn
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgTmpTrn.Add(New Staging.BStgTmpTrn(item))
            Next

            StgOPRHeader = New Staging.BStgOPRHeader(SiteOPRHeader)
            StgOPRDtl = lstStgOPRDtl
            StgOPRAPRPy = lstStgOPRAPRPy
            StgOPRChkPy = lstStgOPRChkPy
            StgTmpTrn = lstStgTmpTrn


        End Sub

        Public Sub PostPaymentBatchPremiumRelated() Implements IPaymentBatchPremiumRelated.PostPaymentBatchPremiumRelated
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If Not IsNothing(SiteBatch) Then
                    SiteBatch.Alter("POST", oraConn, oraTrans)
                End If

                oraTrans.Commit()
                IsSuccessful = True

            Catch ex As Exception
                oraTrans.Rollback()
                IsSuccessful = False
                Throw New Exception(String.Concat("Your data may not have been saved correctly. Please review your data and try again. <br />", ex.Message))
            Finally
                OracleConnection.ClearPool(oraConn)
                oraConn.Close()
                oraConn.Dispose()
            End Try

        End Sub

        Public Sub CancelPaymentBatchPremiumRelated() Implements IPaymentBatchPremiumRelated.CancelPaymentBatchPremiumRelated
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If Not IsNothing(SiteOPRHeader) Then
                    If SiteOPRHeader.Id <> 0 Then
                        strItem = SiteOPRHeader.Alter("CANCEL", oraConn, oraTrans)
                    End If
                End If

                If Not IsNothing(SiteOPRDtl) Then
                    For Each item In SiteOPRDtl
                        If item.Id <> 0 Then
                            strItem = item.Alter("DELETE", oraConn, oraTrans)
                        End If
                    Next
                End If

                If IsAprTag Then
                    For Each item In SiteOPRAPRPy
                        If item.Id <> 0 Then
                            strItem = item.Alter("DELETE", oraConn, oraTrans)
                        End If
                    Next
                End If

                If Not IsNothing(SiteOPRChkPy) Then
                    For Each item In SiteOPRChkPy
                        If item.Id <> 0 Then
                            strItem = item.Alter("DELETE", oraConn, oraTrans)
                        End If
                    Next
                End If

                For Each item In SiteTmpTrn
                    If item.Id <> 0 Then
                        strItem = item.Alter("CANCEL", oraConn, oraTrans)
                    End If
                Next

                '-------------------------------------
                Call CopyToStgObjects()
                '-------------------------------------

                If StgOPRHeader.OPRRcptNo <> 0 Then
                    strItem = StgOPRHeader.Alter("CANCEL", oraConn, oraTrans)
                End If

                For Each item In StgOPRDtl
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                    End If
                Next

                For Each item In StgOPRAPRPy
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                    End If
                Next

                For Each item In StgOPRChkPy
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                    End If
                Next

                For Each item In StgTmpTrn
                    If item.RcptNo <> 0 Then
                        strItem = item.Alter("CANCEL", oraConn, oraTrans)
                    End If
                Next

                oraTrans.Commit()
                IsSuccessful = True

            Catch ex As Exception
                oraTrans.Rollback()
                IsSuccessful = False
                Throw New Exception(String.Concat("Your data may not have been saved correctly. Please review your data and try again. <br />", ex.Message))
            Finally
                OracleConnection.ClearPool(oraConn)
                oraConn.Close()
                oraConn.Dispose()
            End Try

        End Sub

#End Region

    End Class

End Namespace

