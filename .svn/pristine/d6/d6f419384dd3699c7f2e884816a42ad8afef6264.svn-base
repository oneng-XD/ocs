#Region "Description"
' PAGE NAME     :  Non-Premium Related Payment BLL
' CREATED BY    :  IBP
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
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllStaging = Cocolife.BLL.OCS.Staging
#End Region

Namespace Payment

    Public Class BPaymentNonPremiumRelated


#Region "Implements"
        Implements Payment.IPaymentNonPremiumRelated
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mReservedReceiptNumber As Long
        Private mSiteORHeader As Working.BSiteORHeader
        Private mSiteORVAT As Working.BSiteORVAT
        Private mSiteORDtl As IList(Of Working.BSiteORDtl)
        Private mSiteORAPRPay As IList(Of Working.BSiteORAPRPay)
        Private mSiteORChkPay As IList(Of Working.BSiteORChkPay)
        Private mSiteTmpTrn As IList(Of Working.BSiteTmpTrn)
        Private mSiteRcptCtr As Working.BReceiptCounter
        Private mSiteColDtl As IList(Of Working.BSiteORColDtl)
        Private mSiteORPart As IList(Of Working.BSiteORPart)
        Private mStgORHeader As Staging.BStgORHeader
        Private mStgORVAT As Staging.BStgORVAT
        Private mStgORDtl As IList(Of Staging.BStgORDtl)
        Private mStgORAPRPay As IList(Of Staging.BStgORAPRPay)
        Private mStgORChkPay As IList(Of Staging.BStgORChkPay)
        Private mStgTmpTrn As IList(Of Staging.BStgTmpTrn)
        Private mStgORPart As IList(Of Staging.BStgORPart)
        Private mIsAprTag As Boolean
        Private mIsColumbary As Boolean
        Private mLstForDeletion As IList(Of Object)
        Private mPrsmas As IList(Of BLL.OCS.Person.BPrsMas)

#End Region

#Region "Properties"

        Public Property IsSuccessful As Boolean Implements IPaymentNonPremiumRelated.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentNonPremiumRelated.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As String Implements IPaymentNonPremiumRelated.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As String)
                mSiteCode = value
            End Set
        End Property

        Public Property ReservedReceiptNumber As Long Implements IPaymentNonPremiumRelated.ReservedReceiptNumber
            Get
                Return mReservedReceiptNumber
            End Get
            Set(value As Long)
                mReservedReceiptNumber = value
            End Set
        End Property

        Public Property SiteORAPRPay As IList(Of Working.BSiteORAPRPay) Implements IPaymentNonPremiumRelated.SiteORAPRPay
            Get
                Return mSiteORAPRPay
            End Get
            Set(value As IList(Of Working.BSiteORAPRPay))
                mSiteORAPRPay = value
            End Set
        End Property

        Public Property SiteORChkPay As IList(Of Working.BSiteORChkPay) Implements IPaymentNonPremiumRelated.SiteORChkPay
            Get
                Return mSiteORChkPay
            End Get
            Set(value As IList(Of Working.BSiteORChkPay))
                mSiteORChkPay = value
            End Set
        End Property

        Public Property SiteORDtl As IList(Of Working.BSiteORDtl) Implements IPaymentNonPremiumRelated.SiteORDtl
            Get
                Return mSiteORDtl
            End Get
            Set(value As IList(Of Working.BSiteORDtl))
                mSiteORDtl = value
            End Set
        End Property

        Public Property SiteORHeader As Working.BSiteORHeader Implements IPaymentNonPremiumRelated.SiteORHeader
            Get
                Return mSiteORHeader
            End Get
            Set(value As Working.BSiteORHeader)
                mSiteORHeader = value
            End Set
        End Property

        Public Property SiteColDtl As IList(Of Working.BSiteORColDtl) Implements IPaymentNonPremiumRelated.SiteORColDtl
            Get
                Return mSiteColDtl
            End Get
            Set(value As IList(Of Working.BSiteORColDtl))
                mSiteColDtl = value
            End Set
        End Property

        Public Property SiteORPart As IList(Of Working.BSiteORPart) Implements IPaymentNonPremiumRelated.SiteORPart
            Get
                Return mSiteORPart
            End Get
            Set(value As IList(Of Working.BSiteORPart))
                mSiteORPart = value
            End Set
        End Property

        Public Property SiteORVAT As Working.BSiteORVAT Implements IPaymentNonPremiumRelated.SiteORVAT
            Get
                Return mSiteORVAT
            End Get
            Set(value As Working.BSiteORVAT)
                mSiteORVAT = value
            End Set
        End Property

        Public Property SiteTmpTrn As IList(Of Working.BSiteTmpTrn) Implements IPaymentNonPremiumRelated.SiteTmpTrn
            Get
                Return mSiteTmpTrn
            End Get
            Set(value As IList(Of Working.BSiteTmpTrn))
                mSiteTmpTrn = value
            End Set
        End Property

        Public Property StgORAPRPay As IList(Of Staging.BStgORAPRPay) Implements IPaymentNonPremiumRelated.StgORAPRPay
            Get
                Return mStgORAPRPay
            End Get
            Set(value As IList(Of Staging.BStgORAPRPay))
                mStgORAPRPay = value
            End Set
        End Property

        Public Property StgORChkPay As IList(Of Staging.BStgORChkPay) Implements IPaymentNonPremiumRelated.StgORChkPay
            Get
                Return mStgORChkPay
            End Get
            Set(value As IList(Of Staging.BStgORChkPay))
                mStgORChkPay = value
            End Set
        End Property

        Public Property StgORDtl As IList(Of Staging.BStgORDtl) Implements IPaymentNonPremiumRelated.StgORDtl
            Get
                Return mStgORDtl
            End Get
            Set(value As IList(Of Staging.BStgORDtl))
                mStgORDtl = value
            End Set
        End Property

        Public Property StgORHeader As Staging.BStgORHeader Implements IPaymentNonPremiumRelated.StgORHeader
            Get
                Return mStgORHeader
            End Get
            Set(value As Staging.BStgORHeader)
                mStgORHeader = value
            End Set
        End Property

        Public Property StgORPart As IList(Of Staging.BStgORPart) Implements IPaymentNonPremiumRelated.StgORPart
            Get
                Return mStgORPart
            End Get
            Set(value As IList(Of Staging.BStgORPart))
                mStgORPart = value
            End Set
        End Property

        Public Property StgORVAT As Staging.BStgORVAT Implements IPaymentNonPremiumRelated.StgORVAT
            Get
                Return mStgORVAT
            End Get
            Set(value As Staging.BStgORVAT)
                mStgORVAT = value
            End Set
        End Property

        Public Property StgTmpTrn As IList(Of Staging.BStgTmpTrn) Implements IPaymentNonPremiumRelated.StgTmpTrn
            Get
                Return mStgTmpTrn
            End Get
            Set(value As IList(Of Staging.BStgTmpTrn))
                mStgTmpTrn = value
            End Set
        End Property

        Public Property SiteRcptCtr As Working.BReceiptCounter Implements IPaymentNonPremiumRelated.SiteRcptCtr
            Get
                Return mSiteRcptCtr
            End Get
            Set(value As Working.BReceiptCounter)
                mSiteRcptCtr = value
            End Set
        End Property

        Public Property PrsMas As IList(Of BLL.OCS.Person.BPrsMas) Implements IPaymentNonPremiumRelated.PrsMas
            Get
                Return mPrsmas
            End Get
            Set(value As IList(Of BLL.OCS.Person.BPrsMas))
                mPrsmas = value
            End Set
        End Property

        Public Property IsAprTag() As Boolean Implements IPaymentNonPremiumRelated.IsAprTag
            Get
                Return mIsAprTag
            End Get
            Set(ByVal value As Boolean)
                mIsAprTag = value
            End Set
        End Property

        Public Property IsColumbary() As Boolean Implements IPaymentNonPremiumRelated.IsColumbary
            Get
                Return mIsColumbary
            End Get
            Set(value As Boolean)
                mIsColumbary = value
            End Set
        End Property

        Public Property lstForDeletion As IList(Of Object) Implements IPaymentNonPremiumRelated.lstForDeletion
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

        Public Sub ProcessPaymentNonPremiumRelated() Implements IPaymentNonPremiumRelated.ProcessPaymentNonPremiumRelated
            Dim strItem As String = String.Empty
            Dim objSiteORHeader As New bllWorking.BSiteORHeader
            Dim objSiteORVAT As New bllWorking.BSiteORVAT
            Dim objSiteOrDetails As New BLL.OCS.Reference.BOrDetails

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If SiteORHeader.Id = 0 Then
                    objSiteOrDetails.LoadNewOR(SiteCode, eReference.ReceiptType.CI, UserID, oraConn, oraTrans)
                End If

                If lstForDeletion.Count > 0 Then
                    For Each item In lstForDeletion
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                    Next
                End If

                If Not IsNothing(SiteRcptCtr) Then
                    If SiteRcptCtr.Id = 0 Then
                        strItem = SiteRcptCtr.Alter("INSERT", oraConn, oraTrans)
                    Else
                        strItem = SiteRcptCtr.Alter("UPDATE", oraConn, oraTrans)
                    End If
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException("Receipt number already exists. Please try again.")
                    End If
                End If

                If Not IsNothing(SiteORHeader) Then
                    If ReservedReceiptNumber > 0 Then
                        SiteORHeader.ORNmbr = ReservedReceiptNumber
                    End If

                    If SiteORHeader.Id = 0 Then
                        objSiteORHeader.GetORHeader(ReservedReceiptNumber, UserID)
                        objSiteORVAT.GetSiteORVAT(ReservedReceiptNumber, UserID)

                        If objSiteORHeader.StatusId = 0 And objSiteORVAT.StatusId = 0 Then
                            strItem = SiteORHeader.Alter("INSERT", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORHeader : ", strItem))
                            End If
                        Else
                            Throw New Exception("Receipt Number already exists.")
                        End If
                    Else
                        strItem = SiteORHeader.Alter("UPDATE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORHeader : ", strItem))
                        End If
                    End If


                    If Not IsNothing(SiteORVAT) Then
                        If ReservedReceiptNumber > 0 Then
                            SiteORVAT.ORNmbr = ReservedReceiptNumber
                        End If

                        If SiteORVAT.Id = 0 Then
                            strItem = SiteORVAT.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = SiteORVAT.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORVAT : ", strItem))
                        End If
                    End If

                    For Each item In SiteORDtl
                        If ReservedReceiptNumber > 0 Then
                            item.ORNmbr = ReservedReceiptNumber
                        End If

                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORDtl : ", strItem))
                        End If
                    Next

                    If IsAprTag Then
                        For Each item In SiteORAPRPay
                            If ReservedReceiptNumber > 0 Then
                                item.ORNmbr = ReservedReceiptNumber
                            End If

                            If item.Id = 0 Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                            Else
                                strItem = item.Alter("UPDATE", oraConn, oraTrans)
                            End If
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORAPRPay : ", strItem))
                            End If
                        Next
                    End If

                    For Each item In SiteORChkPay
                        If ReservedReceiptNumber > 0 Then
                            item.ORNmbr = ReservedReceiptNumber
                        End If

                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORChkPay : ", strItem))
                        End If
                    Next

                    For Each item In SiteTmpTrn
                        If ReservedReceiptNumber > 0 Then
                            item.RcptNo = ReservedReceiptNumber
                        End If

                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteTmpTrn : ", strItem))
                        End If
                    Next

                    If IsColumbary Then
                        For Each item In SiteColDtl
                            If ReservedReceiptNumber > 0 Then
                                item.ORNmbr = ReservedReceiptNumber
                            End If

                            If item.Id = 0 Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                            Else
                                strItem = item.Alter("UPDATE", oraConn, oraTrans)
                            End If
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteColDtl : ", strItem))
                            End If
                        Next
                    End If

                    For Each item In SiteORPart
                        If ReservedReceiptNumber > 0 Then
                            item.ORNmbr = ReservedReceiptNumber
                        End If

                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORPart : ", strItem))
                        End If
                    Next
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

        Public Sub CopyToStgObjects() Implements IPaymentNonPremiumRelated.CopyToStgObjects
            Dim lstStgORDtl As New List(Of Staging.BStgORDtl)
            Dim lstStgORAPRPay As New List(Of Staging.BStgORAPRPay)
            Dim lstStgORChkPay As New List(Of Staging.BStgORChkPay)
            Dim lstStgTmpTrn As New List(Of Staging.BStgTmpTrn)
            Dim lstStgORPart As New List(Of Staging.BStgORPart)

            For Each item In SiteORDtl
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgORDtl.Add(New Staging.BStgORDtl(item))
            Next
            For Each item In SiteORAPRPay
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgORAPRPay.Add(New Staging.BStgORAPRPay(item))
            Next
            For Each item In SiteORChkPay
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgORChkPay.Add(New Staging.BStgORChkPay(item))
            Next
            For Each item In SiteTmpTrn
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgTmpTrn.Add(New Staging.BStgTmpTrn(item))
            Next
            For Each item In SiteORPart
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgORPart.Add(New Staging.BStgORPart(item))
            Next

            StgORHeader = New Staging.BStgORHeader(SiteORHeader)
            StgORVAT = New Staging.BStgORVAT(SiteORVAT)
            StgORDtl = lstStgORDtl
            StgORAPRPay = lstStgORAPRPay
            StgORChkPay = lstStgORChkPay
            StgTmpTrn = lstStgTmpTrn
            StgORPart = lstStgORPart


        End Sub

        Public Sub PostPaymentNonPremiumRelated() Implements IPaymentNonPremiumRelated.PostPaymentNonPremiumRelated
            Dim strItem As String = String.Empty
            Dim objSiteORHeader As New bllWorking.BSiteORHeader
            Dim objSiteORVAT As New bllWorking.BSiteORVAT

            Dim objStgTmptrn As New bllStaging.BStgTmpTrn
            Dim objStgORHeader As New bllStaging.BStgORHeader
            Dim objStgORDtl As New bllStaging.BStgORDtl
            Dim objStgORChkPay As New bllStaging.BStgORChkPay
            Dim objStgORAPRPay As New bllStaging.BStgORAPRPay
            Dim objStgORPart As New bllStaging.BStgORPart
            Dim objStgORVAT As New bllStaging.BStgORVAT

            Dim dtLocal As DataTable
            Dim isDuplicate As Boolean

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If Not IsNothing(SiteORHeader) Then

                    If SiteORHeader.StatusId <> eReference.Status.Posted Then

                        objSiteORHeader.GetORHeader(SiteORHeader.ORNmbr, UserID)
                        objSiteORVAT.GetSiteORVAT(SiteORHeader.ORNmbr, UserID)

                        If objSiteORHeader.StatusId = 1 And objSiteORVAT.StatusId = 1 Then
                            If SiteORHeader.StatusId <> eReference.Status.Deleted Then strItem = SiteORHeader.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORHeader : ", strItem))
                            End If
                        Else
                            Throw New Exception("Receipt Number already exists.")
                        End If

                        If Not IsNothing(SiteORVAT) Then
                            If SiteORVAT.StatusId <> eReference.Status.Deleted Then strItem = SiteORVAT.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORVAT : ", strItem))
                            End If
                        End If

                        For Each item In SiteORDtl
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORDtl : ", strItem))
                            End If
                        Next

                        If IsAprTag Then
                            For Each item In SiteORAPRPay
                                If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("SiteORAPRPay : ", strItem))
                                End If
                            Next
                        End If

                        For Each item In SiteORChkPay
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORChkPay : ", strItem))
                            End If
                        Next

                        For Each item In SiteTmpTrn
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteTmpTrn : ", strItem))
                            End If
                        Next

                        If IsColumbary Then
                            For Each item In SiteColDtl
                                If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("SiteColDtl : ", strItem))
                                End If
                            Next
                        End If

                        For Each item In SiteORPart
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORPart : ", strItem))
                            End If
                        Next
                    End If

                    Call CopyToStgObjects()

                    objStgORHeader.GetStgORHeader(StgORHeader.ORNmbr)
                    If objStgORHeader.ORNmbr = 0 Then
                        strItem = StgORHeader.Alter("INSERT", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgORHeader : ", strItem))
                        End If
                    End If

                    objStgORVAT.GetStgORVAT(StgORHeader.ORNmbr)
                    If objStgORVAT.ORNmbr = 0 Then
                        If Not IsNothing(StgORVAT) Then
                            strItem = StgORVAT.Alter("INSERT", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("StgORVAT : ", strItem))
                            End If
                        End If
                    End If

                    dtLocal = objStgORDtl.GetStgORDtlDt(StgORHeader.ORNmbr)
                    For Each item In StgORDtl
                        isDuplicate = False
                        For Each itemStg As DataRow In dtLocal.Rows
                            If itemStg.Item("or_nmbr") = item.ORNmbr _
                                AndAlso itemStg.Item("line_nmbr") = item.LineNmbr Then
                                isDuplicate = True
                            End If
                        Next

                        If Not isDuplicate Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("StgORDtl : ", strItem))
                            End If
                        End If
                    Next

                    If IsAprTag Then
                        For Each item In StgORAPRPay
                            objStgORAPRPay.GetStgORAPRPay(StgORHeader.ORNmbr)
                            If objStgORAPRPay.ORNmbr = 0 Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgORAPRPay : ", strItem))
                                End If
                            End If
                        Next
                    End If

                    dtLocal = objStgORChkPay.GetStgORChkPyDt(StgORHeader.ORNmbr)
                    For Each item In StgORChkPay
                        isDuplicate = False
                        For Each itemStg As DataRow In dtLocal.Rows
                            If itemStg.Item("or_nmbr") = item.ORNmbr _
                                AndAlso itemStg.Item("line_nmbr") = item.LineNmbr Then
                                isDuplicate = True
                            End If
                        Next

                        If Not isDuplicate Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("StgORChkPay : ", strItem))
                            End If
                        End If
                    Next

                    For Each item In StgTmpTrn
                        strItem = item.Alter("INSERT", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgTmpTrn : ", strItem))
                        End If
                    Next

                    dtLocal = objStgORPart.GetStgORPart(StgORHeader.ORNmbr)
                    For Each item In StgORPart
                        isDuplicate = False
                        For Each itemStg As DataRow In dtLocal.Rows
                            If itemStg.Item("or_nmbr") = item.ORNmbr _
                                AndAlso itemStg.Item("line_nmbr") = item.LineNmbr Then
                                isDuplicate = True
                            End If
                        Next

                        If Not isDuplicate Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("StgORPart : ", strItem))
                            End If
                        End If
                    Next

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

        Public Sub CancelPaymentNonPremiumRelated() Implements IPaymentNonPremiumRelated.CancelPaymentNonPremiumRelated
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If Not IsNothing(SiteORHeader) Then
                    If SiteORHeader.Id <> 0 Then
                        strItem = SiteORHeader.Alter("CANCEL", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORHeader : ", strItem))
                        End If
                    End If
                End If

                If Not IsNothing(SiteORVAT) Then
                    If SiteORVAT.Id <> 0 Then
                        strItem = SiteORVAT.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORVAT : ", strItem))
                        End If
                    End If
                End If

                If Not IsNothing(SiteORDtl) Then
                    For Each item In SiteORDtl
                        If item.Id <> 0 Then
                            strItem = item.Alter("DELETE", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORDtl : ", strItem))
                            End If
                        End If
                    Next
                End If

                If IsAprTag Then
                    For Each item In SiteORAPRPay
                        If item.Id <> 0 Then
                            strItem = item.Alter("DELETE", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORAPRPay : ", strItem))
                            End If
                        End If
                    Next
                End If

                If Not IsNothing(SiteORChkPay) Then
                    For Each item In SiteORChkPay
                        If item.Id <> 0 Then
                            strItem = item.Alter("DELETE", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteORChkPay : ", strItem))
                            End If
                        End If
                    Next
                End If

                For Each item In SiteTmpTrn
                    If item.Id <> 0 Then
                        strItem = item.Alter("CANCEL", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteTmpTrn : ", strItem))
                        End If
                    End If
                Next

                If IsColumbary Then
                    For Each item In SiteColDtl
                        If item.Id <> 0 Then
                            strItem = item.Alter("DELETE", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteColDtl : ", strItem))
                            End If
                        End If
                    Next
                End If

                For Each item In SiteORPart
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteORPart : ", strItem))
                        End If
                    End If
                Next

                '-------------------------------------
                Call CopyToStgObjects()
                '-------------------------------------

                If StgORHeader.ORNmbr <> 0 Then
                    strItem = StgORHeader.Alter("CANCEL", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("StgORHeader : ", strItem))
                    End If
                End If

                If StgORVAT.ORNmbr <> 0 Then
                    strItem = StgORVAT.Alter("DELETE", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("StgORVAT : ", strItem))
                    End If
                End If

                For Each item In StgORDtl
                    If item.ORNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgORDtl : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgORAPRPay
                    If item.ORNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgORAPRPay : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgORChkPay
                    If item.ORNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgORChkPay : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgORPart
                    If item.ORNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgORPart : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgTmpTrn
                    If item.RcptNo <> 0 Then
                        strItem = item.Alter("CANCEL", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgTmpTrn : ", strItem))
                        End If
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

