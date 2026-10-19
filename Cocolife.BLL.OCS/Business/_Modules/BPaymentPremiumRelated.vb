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
Imports bllReference = Cocolife.BLL.OCS.Reference
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllStaging = Cocolife.BLL.OCS.Staging
Imports System.Configuration
#End Region

Namespace Payment

    Public Class BPaymentPremiumRelated

#Region "Implements"
        Implements Payment.IPaymentPremiumRelated
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mReservedReceiptNumber As Long
        Private mSamePayorInsured As Boolean
        '--------------------------------------------------------
        ' Working Tables
        '--------------------------------------------------------
        Private mSiteOPRHeader As Working.BSiteOPRHeader
        Private mSiteOPRInfo As IList(Of Working.BSiteOPRInfo)
        Private mSiteOPRVAT As Working.BSiteOPRVAT
        'Private mHMOPayslip As Reference.BHMOPayslip
        Private mSitePAMaster As Working.BSitePAMaster
        Private mSiteOPRDtl As IList(Of Working.BSiteOPRDtl)
        Private mSiteOPRAPRPy As IList(Of Working.BSiteOPRAPRPy)
        Private mSiteOPRChkPy As IList(Of Working.BSiteOPRChkPy)
        Private mSiteOPRCred As IList(Of Working.BSiteOPRCred)
        Private mSiteOPRDebit As IList(Of Working.BSiteOPRDebit)
        Private mSiteOPREcash As IList(Of Working.BSiteOPRECash)
        Private mSiteTmpTrn As IList(Of Working.BSiteTmpTrn)
        '--------------------------------------------------------
        ' Staging Tables
        '--------------------------------------------------------
        Private mStgOPRHeader As Staging.BStgOPRHeader
        Private mStgOPRInfo As IList(Of Staging.BStgOPRInfo)
        Private mStgOPRVAT As Staging.BStgOPRVAT
        Private mStgPAMaster As Staging.BGpaProcess
        Private mNewgenPayment As Staging.BNewgenLifePayment
        Private mStgOPRDtl As IList(Of Staging.BStgOPRDtl)
        Private mStgOPRAPRPy As IList(Of Staging.BStgOPRAPRPy)
        Private mStgOPRChkPy As IList(Of Staging.BStgOPRChkPy)
        Private mStgOPRCred As IList(Of Staging.BStgOPRCred)
        Private mStgOPRDebit As IList(Of Staging.BStgOPRDebit)
        Private mStgTmpTrn As IList(Of Staging.BStgTmpTrn)
        '--------------------------------------------------------
        Private mSiteRcptCtr As Working.BReceiptCounter
        Private mPolmod As String
        Private mIsAprTag As Boolean
        Private mIsGpaTag As Boolean
        Private mIsNewBusinessTag As Boolean
        Private mLstForDeletion As IList(Of Object)
        Private mPrsmasPayor As IList(Of BLL.OCS.Person.BPrsMas)
        Private mPrsmasInsured As IList(Of BLL.OCS.Person.BPrsMas)

        Private mNewgenOn As Boolean

#End Region

#Region "Properties"
        Public ReadOnly Property IsNewgenOn As Boolean
            Get
                mNewgenOn = True
            End Get
        End Property

        Public Property IsSuccessful As Boolean Implements IPaymentPremiumRelated.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentPremiumRelated.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IPaymentPremiumRelated.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property ReservedReceiptNumber As Long Implements IPaymentPremiumRelated.ReservedReceiptNumber
            Get
                Return mReservedReceiptNumber
            End Get
            Set(value As Long)
                mReservedReceiptNumber = value
            End Set
        End Property

        Public Property SamePayorInsured As Boolean Implements IPaymentPremiumRelated.SamePayorInsured
            Get
                Return mSamePayorInsured
            End Get
            Set(value As Boolean)
                mSamePayorInsured = value
            End Set
        End Property

        Public Property SiteOPRAPRPy As IList(Of Working.BSiteOPRAPRPy) Implements IPaymentPremiumRelated.SiteOPRAPRPy
            Get
                Return mSiteOPRAPRPy
            End Get
            Set(value As IList(Of Working.BSiteOPRAPRPy))
                mSiteOPRAPRPy = value
            End Set
        End Property

        Public Property SiteOPRChkPy As IList(Of Working.BSiteOPRChkPy) Implements IPaymentPremiumRelated.SiteOPRChkPy
            Get
                Return mSiteOPRChkPy
            End Get
            Set(value As IList(Of Working.BSiteOPRChkPy))
                mSiteOPRChkPy = value
            End Set
        End Property

        Public Property SiteOPRCred As IList(Of Working.BSiteOPRCred) Implements IPaymentPremiumRelated.SiteOPRCred
            Get
                Return mSiteOPRCred
            End Get
            Set(value As IList(Of Working.BSiteOPRCred))
                mSiteOPRCred = value
            End Set
        End Property

        Public Property SiteOPRDebit As IList(Of Working.BSiteOPRDebit) Implements IPaymentPremiumRelated.SiteOPRDebit
            Get
                Return mSiteOPRDebit
            End Get
            Set(value As IList(Of Working.BSiteOPRDebit))
                mSiteOPRDebit = value
            End Set
        End Property

        Public Property SiteOPRECash As IList(Of Working.BSiteOPRECash) Implements IPaymentPremiumRelated.SiteOPRECash
            Get
                Return mSiteOPREcash
            End Get
            Set(value As IList(Of Working.BSiteOPRECash))
                mSiteOPREcash = value
            End Set
        End Property

        Public Property SiteOPRDtl As IList(Of Working.BSiteOPRDtl) Implements IPaymentPremiumRelated.SiteOPRDtl
            Get
                Return mSiteOPRDtl
            End Get
            Set(value As IList(Of Working.BSiteOPRDtl))
                mSiteOPRDtl = value
            End Set
        End Property

        Public Property SiteOPRHeader As Working.BSiteOPRHeader Implements IPaymentPremiumRelated.SiteOPRHeader
            Get
                Return mSiteOPRHeader
            End Get
            Set(value As Working.BSiteOPRHeader)
                mSiteOPRHeader = value
            End Set
        End Property

        Public Property SiteOPRInfo As IList(Of Working.BSiteOPRInfo) Implements IPaymentPremiumRelated.SiteOPRInfo
            Get
                Return mSiteOPRInfo
            End Get
            Set(value As IList(Of Working.BSiteOPRInfo))
                mSiteOPRInfo = value
            End Set
        End Property

        Public Property SiteOPRVAT As Working.BSiteOPRVAT Implements IPaymentPremiumRelated.SiteOPRVAT
            Get
                Return mSiteOPRVAT
            End Get
            Set(value As Working.BSiteOPRVAT)
                mSiteOPRVAT = value
            End Set
        End Property

        Public Property SitePAMaster As Working.BSitePAMaster Implements IPaymentPremiumRelated.SitePAMaster
            Get
                Return mSitePAMaster
            End Get
            Set(value As Working.BSitePAMaster)
                mSitePAMaster = value
            End Set
        End Property

        'Public Property HMOPayslip As Reference.BHMOPayslip Implements IPaymentPremiumRelated.HMOPayslip
        '    Get
        '        Return mHMOPayslip
        '    End Get
        '    Set(value As Reference.BHMOPayslip)
        '        mHMOPayslip = value
        '    End Set
        'End Property

        Public Property SiteTmpTrn As IList(Of Working.BSiteTmpTrn) Implements IPaymentPremiumRelated.SiteTmpTrn
            Get
                Return mSiteTmpTrn
            End Get
            Set(value As IList(Of Working.BSiteTmpTrn))
                mSiteTmpTrn = value
            End Set
        End Property


        Public Property StgOPRAPRPy As IList(Of Staging.BStgOPRAPRPy) Implements IPaymentPremiumRelated.StgOPRAPRPy
            Get
                Return mStgOPRAPRPy
            End Get
            Set(value As IList(Of Staging.BStgOPRAPRPy))
                mStgOPRAPRPy = value
            End Set
        End Property

        Public Property StgOPRChkPy As IList(Of Staging.BStgOPRChkPy) Implements IPaymentPremiumRelated.StgOPRChkPy
            Get
                Return mStgOPRChkPy
            End Get
            Set(value As IList(Of Staging.BStgOPRChkPy))
                mStgOPRChkPy = value
            End Set
        End Property

        Public Property StgOPRCred As IList(Of Staging.BStgOPRCred) Implements IPaymentPremiumRelated.StgOPRCred
            Get
                Return mStgOPRCred
            End Get
            Set(value As IList(Of Staging.BStgOPRCred))
                mStgOPRCred = value
            End Set
        End Property

        Public Property StgOPRDebit As IList(Of Staging.BStgOPRDebit) Implements IPaymentPremiumRelated.StgOPRDebit
            Get
                Return mStgOPRDebit
            End Get
            Set(value As IList(Of Staging.BStgOPRDebit))
                mStgOPRDebit = value
            End Set
        End Property

        Public Property StgOPRDtl As IList(Of Staging.BStgOPRDtl) Implements IPaymentPremiumRelated.StgOPRDtl
            Get
                Return mStgOPRDtl
            End Get
            Set(value As IList(Of Staging.BStgOPRDtl))
                mStgOPRDtl = value
            End Set
        End Property

        Public Property StgOPRHeader As Staging.BStgOPRHeader Implements IPaymentPremiumRelated.StgOPRHeader
            Get
                Return mStgOPRHeader
            End Get
            Set(value As Staging.BStgOPRHeader)
                mStgOPRHeader = value
            End Set
        End Property

        Public Property StgOPRInfo As IList(Of Staging.BStgOPRInfo) Implements IPaymentPremiumRelated.StgOPRInfo
            Get
                Return mStgOPRInfo
            End Get
            Set(value As IList(Of Staging.BStgOPRInfo))
                mStgOPRInfo = value
            End Set
        End Property

        Public Property NewgenPayment As Staging.BNewgenLifePayment Implements IPaymentPremiumRelated.NewgenPayment
            Get
                Return mNewgenPayment
            End Get
            Set(value As Staging.BNewgenLifePayment)
                mNewgenPayment = value
            End Set
        End Property

        Public Property StgOPRVAT As Staging.BStgOPRVAT Implements IPaymentPremiumRelated.StgOPRVAT
            Get
                Return mStgOPRVAT
            End Get
            Set(value As Staging.BStgOPRVAT)
                mStgOPRVAT = value
            End Set
        End Property

        Public Property StgPAMaster As Staging.BGpaProcess Implements IPaymentPremiumRelated.StgPAMaster
            Get
                Return mStgPAMaster
            End Get
            Set(value As Staging.BGpaProcess)
                mStgPAMaster = value
            End Set
        End Property

        Public Property StgTmpTrn As IList(Of Staging.BStgTmpTrn) Implements IPaymentPremiumRelated.StgTmpTrn
            Get
                Return mStgTmpTrn
            End Get
            Set(value As IList(Of Staging.BStgTmpTrn))
                mStgTmpTrn = value
            End Set
        End Property

        Public Property SiteRcptCtr As Working.BReceiptCounter Implements IPaymentPremiumRelated.SiteRcptCtr
            Get
                Return mSiteRcptCtr
            End Get
            Set(value As Working.BReceiptCounter)
                mSiteRcptCtr = value
            End Set
        End Property

        Public Property PrsMasPayor As IList(Of BLL.OCS.Person.BPrsMas) Implements IPaymentPremiumRelated.PrsMasPayor
            Get
                Return mPrsmasPayor
            End Get
            Set(value As IList(Of BLL.OCS.Person.BPrsMas))
                mPrsmasPayor = value
            End Set
        End Property

        Public Property PrsMasInsured As IList(Of BLL.OCS.Person.BPrsMas) Implements IPaymentPremiumRelated.PrsMasInsured
            Get
                Return mPrsmasInsured
            End Get
            Set(value As IList(Of BLL.OCS.Person.BPrsMas))
                mPrsmasInsured = value
            End Set
        End Property

        Public Property PolMod() As String Implements IPaymentPremiumRelated.PolMod
            Get
                Return mPolmod
            End Get
            Set(ByVal value As String)
                mPolmod = value
            End Set
        End Property

        Public Property IsAprTag() As Boolean Implements IPaymentPremiumRelated.IsAprTag
            Get
                Return mIsAprTag
            End Get
            Set(ByVal value As Boolean)
                mIsAprTag = value
            End Set
        End Property

        Public Property IsGpaTag() As Boolean Implements IPaymentPremiumRelated.IsGpaTag
            Get
                Return mIsGpaTag
            End Get
            Set(ByVal value As Boolean)
                mIsGpaTag = value
            End Set
        End Property

        Public Property IsNewBusinessTag() As Boolean Implements IPaymentPremiumRelated.IsNewBusinessTag
            Get
                Return mIsNewBusinessTag
            End Get
            Set(ByVal value As Boolean)
                mIsNewBusinessTag = value
            End Set
        End Property

        Public Property lstForDeletion As IList(Of Object) Implements IPaymentPremiumRelated.lstForDeletion
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

        Public Sub ProcessPaymentPremiumRelated() Implements IPaymentPremiumRelated.ProcessPaymentPremiumRelated
            Dim strItem As String = String.Empty
            Dim objSiteOPRHeader As New bllWorking.BSiteOPRHeader
            Dim objSiteOPRVAT As New bllWorking.BSiteOPRVAT
            Dim objSiteOprDetails As New BLL.OCS.Reference.BOprDetails

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()
                IsSuccessful = False

                If SiteOPRHeader.Id = 0 Then
                    objSiteOprDetails.LoadNewOPR(SiteCode, eReference.ReceiptType.CI, UserID, oraConn, oraTrans)
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

                If Not IsNothing(SiteOPRHeader) Then
                    If ReservedReceiptNumber > 0 Then
                        SiteOPRHeader.OPRRcptNo = ReservedReceiptNumber
                    End If

                    If SiteOPRHeader.Id = 0 Then
                        objSiteOPRHeader.GetOPRHeader(ReservedReceiptNumber, UserID)
                        objSiteOPRVAT.GetSiteOPRVAT(ReservedReceiptNumber, UserID)

                        If objSiteOPRHeader.StatusId = 0 And objSiteOPRVAT.StatusId = 0 Then
                            strItem = SiteOPRHeader.Alter("INSERT", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRHeader : ", strItem))
                            End If
                        Else
                            Throw New Exception("Receipt Number already exists.")
                        End If
                    Else
                        strItem = SiteOPRHeader.Alter("UPDATE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRHeader : ", strItem))
                        End If
                    End If

                    If IsNewBusinessTag OrElse IsGpaTag Then
                        For Each item In SiteOPRInfo
                            If ReservedReceiptNumber > 0 Then
                                item.OPRNmbr = ReservedReceiptNumber
                            End If
                            If item.Id = 0 Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                            Else
                                strItem = item.Alter("UPDATE", oraConn, oraTrans)
                            End If
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRInfo : ", strItem))
                            End If
                        Next
                    End If

                    If Not IsNothing(SitePAMaster) AndAlso IsGpaTag Then
                        If ReservedReceiptNumber > 0 Then
                            SitePAMaster.ORNumber = ReservedReceiptNumber
                        End If
                        If SitePAMaster.Id = 0 Then
                            strItem = SitePAMaster.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = SitePAMaster.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SitePAMaster : ", strItem))
                        End If
                    End If

                    For Each item In SiteOPRDtl
                        If ReservedReceiptNumber > 0 Then
                            item.OPRNmbr = ReservedReceiptNumber
                        End If
                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRDtl : ", strItem))
                        End If
                    Next

                    If IsAprTag Then
                        For Each item In SiteOPRAPRPy
                            If ReservedReceiptNumber > 0 Then
                                item.OPRNmbr = ReservedReceiptNumber
                            End If
                            If item.Id = 0 Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                            Else
                                strItem = item.Alter("UPDATE", oraConn, oraTrans)
                            End If
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRAPRPy : ", strItem))
                            End If
                        Next
                    End If

                    For Each item In SiteOPRChkPy
                        If ReservedReceiptNumber > 0 Then
                            item.OPRNmbr = ReservedReceiptNumber
                        End If
                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRChkPy : ", strItem))
                        End If
                    Next

                    For Each item In SiteOPRCred
                        If ReservedReceiptNumber > 0 Then
                            item.OPRNmbr = ReservedReceiptNumber
                        End If
                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRCred : ", strItem))
                        End If
                    Next

                    For Each item In SiteOPRDebit
                        If ReservedReceiptNumber > 0 Then
                            item.OPRNmbr = ReservedReceiptNumber
                        End If
                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRDebit : ", strItem))
                        End If
                    Next

                    For Each item In SiteOPRECash
                        If ReservedReceiptNumber > 0 Then
                            item.OPRNmbr = ReservedReceiptNumber
                        End If
                        If item.Id = 0 Then
                            strItem = item.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = item.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRECash : ", strItem))
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

                    If Not IsNothing(SiteOPRVAT) Then
                        If ReservedReceiptNumber > 0 Then
                            SiteOPRVAT.OPRNmbr = ReservedReceiptNumber
                        End If
                        If SiteOPRVAT.Id = 0 Then
                            strItem = SiteOPRVAT.Alter("INSERT", oraConn, oraTrans)
                        Else
                            strItem = SiteOPRVAT.Alter("UPDATE", oraConn, oraTrans)
                        End If
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRVAT : ", strItem))
                        End If
                    End If
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

        Public Sub CopyToStgObjects() Implements IPaymentPremiumRelated.CopyToStgObjects
            Dim lstStgOPRInfo As New List(Of Staging.BStgOPRInfo)
            Dim lstStgOPRDtl As New List(Of Staging.BStgOPRDtl)
            Dim lstStgOPRAPRPy As New List(Of Staging.BStgOPRAPRPy)
            Dim lstStgOPRChkPy As New List(Of Staging.BStgOPRChkPy)
            Dim lstStgOPRCred As New List(Of Staging.BStgOPRCred)
            Dim lstStgOPRDebit As New List(Of Staging.BStgOPRDebit)
            Dim lstStgTmpTrn As New List(Of Staging.BStgTmpTrn)

            For Each item In SiteOPRInfo
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRInfo.Add(New Staging.BStgOPRInfo(item))
            Next
            For Each item In SiteOPRDtl
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRDtl.Add(New Staging.BStgOPRDtl(item))
            Next
            For Each item In SiteOPRAPRPy
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRAPRPy.Add(New Staging.BStgOPRAPRPy(item))
            Next
            For Each item In SiteOPRChkPy
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRChkPy.Add(New Staging.BStgOPRChkPy(item))
            Next
            For Each item In SiteOPRCred
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRCred.Add(New Staging.BStgOPRCred(item))
            Next
            For Each item In SiteOPRDebit
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgOPRDebit.Add(New Staging.BStgOPRDebit(item))
            Next
            For Each item In SiteTmpTrn
                If item.StatusId <> eReference.Status.None AndAlso item.StatusId <> eReference.Status.Deleted Then lstStgTmpTrn.Add(New Staging.BStgTmpTrn(item))
            Next

            StgOPRHeader = New Staging.BStgOPRHeader(SiteOPRHeader)
            StgOPRVAT = New Staging.BStgOPRVAT(SiteOPRVAT)
            StgPAMaster = New Staging.BGpaProcess(SitePAMaster)
            StgOPRInfo = lstStgOPRInfo
            StgOPRDtl = lstStgOPRDtl
            StgOPRAPRPy = lstStgOPRAPRPy
            StgOPRChkPy = lstStgOPRChkPy
            StgOPRCred = lstStgOPRCred
            StgOPRDebit = lstStgOPRDebit
            StgTmpTrn = lstStgTmpTrn
            'NewgenPayment = New Staging.BNewgenLifePayment()

        End Sub

        Public Sub PostPaymentPremiumRelated() Implements IPaymentPremiumRelated.PostPaymentPremiumRelated
            Dim strItem As String = String.Empty
            Dim lstPayId As New List(Of String)
            Dim lstInsId As New List(Of String)
            Dim objPrsmas As New BLL.OCS.Person.BPrsMas
            Dim objSiteOPRHeader As New bllWorking.BSiteOPRHeader
            Dim objSiteOPRVAT As New bllWorking.BSiteOPRVAT

            Dim HMOPayslip As New bllReference.BHMOPayslip
            Dim objNewgenPayment As New bllStaging.BNewgenLifePayment
            Dim objStgTmptrn As New bllStaging.BStgTmpTrn
            Dim objStgOPRHeader As New bllStaging.BStgOPRHeader
            Dim objStgOPRDtl As New bllStaging.BStgOPRDtl
            Dim objStgOPRChkPy As New bllStaging.BStgOPRChkPy
            Dim objStgOPRCred As New bllStaging.BStgOPRCred
            Dim objStgOPRDebit As New bllStaging.BStgOPRDebit
            Dim objStgOPRAPRPy As New bllStaging.BStgOPRAPRPy
            Dim objStgOPRInfo As New bllStaging.BStgOPRInfo
            Dim objStgOPRVAT As New bllStaging.BStgOPRVAT

            Dim dtLocal As DataTable
            Dim isDuplicate As Boolean

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If Not IsNothing(SiteOPRHeader) Then

                    If SiteOPRHeader.StatusId <> eReference.Status.Posted Then

                        If SiteOPRHeader.PrtFlag = 0 Then
                            If PrsMasPayor.Count > 0 Then
                                lstPayId = objPrsmas.InsertPrsMas(PrsMasPayor, UserID, oraConn, oraTrans)
                                For Each item In lstPayId
                                    If Not IsNumeric(item) OrElse CLng(item) = 0 Then
                                        Throw New ArgumentException(String.Concat("InsertPayId : ", item))
                                    End If
                                Next item
                            End If
                            If PrsMasInsured.Count > 0 Then
                                lstInsId = objPrsmas.InsertPrsMas(PrsMasInsured, UserID, oraConn, oraTrans)
                                For Each item In lstInsId
                                    If Not IsNumeric(item) OrElse CLng(item) = 0 Then
                                        Throw New ArgumentException(String.Concat("InsertInsId : ", item))
                                    End If
                                Next item
                            End If
                        End If

                        If SiteOPRHeader.StatusId <> eReference.Status.Deleted Then
                            Dim mOPRpyrID As Long = 0
                            Dim mOPRinsID As Long = 0

                            With SiteOPRHeader
                                If .OPRPyrID = 0 AndAlso lstPayId.Count > 0 Then
                                    .OPRPyrID = cDataType.fLong.IfNull(lstPayId.Item(0))
                                End If
                                If .OPRInsID = 0 AndAlso lstInsId.Count > 0 Then
                                    .OPRInsID = cDataType.fLong.IfNull(lstInsId.Item(0))
                                End If
                                If SamePayorInsured Then
                                    .OPRInsID = .OPRPyrID
                                End If

                                objSiteOPRHeader.GetOPRHeader(SiteOPRHeader.OPRRcptNo, UserID)
                                objSiteOPRVAT.GetSiteOPRVAT(SiteOPRHeader.OPRRcptNo, UserID)

                                If objSiteOPRHeader.StatusId = 1 And objSiteOPRVAT.StatusId = 1 Then
                                    strItem = .Alter("POST", oraConn, oraTrans)
                                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                        Throw New ArgumentException(String.Concat("SiteOPRHeader : ", strItem))
                                    End If
                                Else
                                    Throw New Exception("Receipt Number already exists.")
                                End If
                            End With
                        End If

                        ' NEWGEN HMO INTEGRATION
                        If Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-HMO"), "false")) Then
                            If PolMod = "HMO" Then
                                If Len(Trim(Split(SiteOPRHeader.OPRRemarks, " - ")(1))) > 0 Then
                                    strItem = HMOPayslip.Alter(Split(SiteOPRHeader.OPRRemarks, " - ")(1), SiteOPRHeader.OPRRcptNo, SiteOPRHeader.OPRDate, oraConn, oraTrans)
                                    If strItem <> Split(SiteOPRHeader.OPRRemarks, " - ")(1) Then
                                        Throw New ArgumentException(String.Concat("HMO Payslip : ", strItem))
                                    End If
                                End If
                            End If
                        End If

                        If IsNewBusinessTag OrElse IsGpaTag Then
                            'For Each item As Working.BSiteOPRInfo In SiteOPRInfo
                            Dim lstInsIdCtr As Long = 0
                            For count As Integer = 0 To SiteOPRInfo.Count - 1
                                Dim item = SiteOPRInfo.Item(count)
                                If item.StatusId <> eReference.Status.Deleted Then
                                    With item
                                        If .OwnrId = 0 Then .OwnrId = cDataType.fLong.IfNull(lstPayId.Item(0))
                                        If .InsId = 0 Then
                                            If SamePayorInsured Then
                                                .InsId = cDataType.fLong.IfNull(lstPayId.Item(0))
                                            Else
                                                .InsId = cDataType.fLong.IfNull(lstInsId.Item(lstInsIdCtr))
                                            End If
                                        End If
                                        strItem = .Alter("POST", oraConn, oraTrans)
                                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                            Throw New ArgumentException(String.Concat("SiteOPRInfo : ", strItem))
                                        End If
                                        lstInsIdCtr += 1
                                    End With
                                End If
                            Next
                        End If

                        If Not IsNothing(SiteOPRVAT) Then
                            If SiteOPRVAT.StatusId <> eReference.Status.Deleted Then strItem = SiteOPRVAT.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRVAT : ", strItem))
                            End If
                        End If

                        If Not IsNothing(SitePAMaster) AndAlso IsGpaTag Then
                            If SitePAMaster.StatusId <> eReference.Status.Deleted Then strItem = SitePAMaster.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SitePAMaster : ", strItem))
                            End If
                        End If

                        For Each item In SiteOPRDtl
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRDtl : ", strItem))
                            End If
                        Next

                        If IsAprTag Then
                            For Each item In SiteOPRAPRPy
                                If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("SiteOPRAPRPy : ", strItem))
                                End If
                            Next
                        End If

                        For Each item In SiteOPRChkPy
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRChkPy : ", strItem))
                            End If
                        Next

                        For Each item In SiteOPRCred
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRCred : ", strItem))
                            End If
                        Next

                        For Each item In SiteOPRDebit
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRDebit : ", strItem))
                            End If
                        Next

                        For Each item In SiteOPRECash
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteOPRECash : ", strItem))
                            End If
                        Next

                        For Each item In SiteTmpTrn
                            If item.StatusId <> eReference.Status.Deleted Then strItem = item.Alter("POST", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("SiteTmpTrn : ", strItem))
                            End If
                        Next

                        Call CopyToStgObjects()

                        objStgOPRHeader.GetStgOPRHeader(StgOPRHeader.OPRRcptNo)
                        If objStgOPRHeader.OPRRcptNo = 0 Then
                            strItem = StgOPRHeader.Alter("INSERT", oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("StgOPRHeader : ", strItem))
                            End If
                        End If

                        If IsNewBusinessTag OrElse IsGpaTag Then

                            dtLocal = objStgOPRInfo.GetStgOPRInfoDt(StgOPRHeader.OPRRcptNo)
                            For Each item In StgOPRInfo
                                isDuplicate = False
                                For Each itemStg As DataRow In dtLocal.Rows
                                    If itemStg.Item("opr_nmbr") = item.OPRNmbr _
                                        AndAlso itemStg.Item("ins_lname") = item.InsLName _
                                        AndAlso itemStg.Item("ins_fname") = item.InsFName _
                                        AndAlso itemStg.Item("ins_mi") = item.InsMI _
                                        AndAlso itemStg.Item("ins_bday") = item.InsBDay Then
                                        isDuplicate = True
                                    End If
                                Next

                                If Not isDuplicate Then
                                    strItem = item.Alter("INSERT", oraConn, oraTrans)
                                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                        Throw New ArgumentException(String.Concat("StgOPRInfo : ", strItem))
                                    End If
                                End If
                            Next
                        End If

                        If Not IsNothing(StgPAMaster) AndAlso IsGpaTag Then
                            With StgPAMaster
                                .CommwithAmt = SiteTmpTrn.Item(0).RetAmt
                                .PayorId = StgOPRHeader.OPRPyrID
                                .InsuredId = StgOPRHeader.OPRInsID
                                .UserId = SiteOPRHeader.UserID

                                strItem = StgPAMaster.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgPAMaster : ", strItem))
                                End If
                            End With
                        End If


                        dtLocal = objStgOPRDtl.GetStgOPRDtlDt(StgOPRHeader.OPRRcptNo)
                        For Each item In StgOPRDtl
                            isDuplicate = False
                            For Each itemStg As DataRow In dtLocal.Rows
                                If itemStg.Item("opr_nmbr") = item.OPRNmbr Then
                                    isDuplicate = True
                                End If
                            Next

                            If Not isDuplicate Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgOPRDtl : ", strItem))
                                End If
                            End If
                        Next

                        If IsAprTag Then
                            objStgOPRAPRPy.GetStgOPRAPRPy(StgOPRHeader.OPRRcptNo)
                            For Each item In StgOPRAPRPy
                                If objStgOPRAPRPy.OPRNmbr = 0 Then
                                    strItem = item.Alter("INSERT", oraConn, oraTrans)
                                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                        Throw New ArgumentException(String.Concat("StgOPRAPRPy : ", strItem))
                                    End If
                                End If
                            Next
                        End If

                        dtLocal = objStgOPRChkPy.GetOPRChkPyDt(StgOPRHeader.OPRRcptNo)
                        For Each item In StgOPRChkPy
                            isDuplicate = False
                            For Each itemStg As DataRow In dtLocal.Rows
                                If itemStg.Item("opr_nmbr") = item.OPRNmbr _
                                    And itemStg.Item("line_nmbr") = item.LineNmbr Then
                                    isDuplicate = True
                                End If
                            Next

                            If Not isDuplicate Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgOPRChkPy : ", strItem))
                                End If
                            End If
                        Next

                        dtLocal = objStgOPRCred.GetStgOPRCredDt(StgOPRHeader.OPRRcptNo)
                        For Each item In StgOPRCred
                            isDuplicate = False
                            For Each itemStg As DataRow In dtLocal.Rows
                                If itemStg.Item("opr_nmbr") = item.OPRNmbr _
                                    And itemStg.Item("apprv_code") = item.ApprvCode Then
                                    isDuplicate = True
                                End If
                            Next

                            If Not isDuplicate Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgOPRCred : ", strItem))
                                End If
                            End If
                        Next

                        dtLocal = objStgOPRDebit.GetStgOPRDebitlDt(StgOPRHeader.OPRRcptNo)
                        For Each item In StgOPRDebit
                            isDuplicate = False
                            For Each itemStg As DataRow In dtLocal.Rows
                                If itemStg.Item("opr_nmbr") = item.OPRNmbr _
                                    And itemStg.Item("charge_slip_code") = item.ChargeSlipCode Then
                                    isDuplicate = True
                                End If
                            Next

                            If Not isDuplicate Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgOPRDebit : ", strItem))
                                End If
                            End If
                        Next

                        dtLocal = objStgOPRDebit.GetStgOPRDebitlDt(StgOPRHeader.OPRRcptNo)
                        For Each item In StgTmpTrn
                            isDuplicate = False
                            For Each itemStg As DataRow In dtLocal.Rows
                                If itemStg.Item("rcptno") = item.RcptNo Then
                                    isDuplicate = True
                                End If
                            Next

                            If Not isDuplicate Then
                                strItem = item.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgTmpTrn : ", strItem))
                                End If
                            End If
                        Next

                        objStgOPRVAT.GetStgOPRVAT(StgOPRHeader.OPRRcptNo)
                        If Not IsNothing(StgOPRVAT) Then
                            If objStgOPRVAT.OPRNmbr = 0 Then
                                strItem = StgOPRVAT.Alter("INSERT", oraConn, oraTrans)
                                If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                    Throw New ArgumentException(String.Concat("StgOPRVAT : ", strItem))
                                End If
                            End If
                        End If

                        ' NG Posting
                        If Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Life"), "false")) OrElse
                           Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Group"), "false")) Then

                            If Not IsNothing(NewgenPayment) Then

                                strItem = NewgenPayment.Alter("INSERT", oraConn, oraTrans)

                                ' NEWGEN API failure returns 0.
                                ' The API error is already logged in TBL_OCS_NG_API_LOGS.
                                ' Do not stop the main payment transaction when NEWGEN returns 0.
                                '
                                ' Only throw when an unexpected non-numeric result is returned.
                                If Not IsNumeric(strItem) Then
                                    Throw New ArgumentException(
                                        String.Concat("NewgenPayment : ", strItem)
                                    )
                                End If

                            End If

                        End If
                    End If

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

        Public Sub CancelPaymentPremiumRelated() Implements IPaymentPremiumRelated.CancelPaymentPremiumRelated 'cancel ci newgen
            Dim strItem As String = String.Empty

            Dim HMOPayslip As New bllReference.BHMOPayslip
            Dim NewgenPaymentUpd As New bllStaging.BNewgenLifePayment

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try
                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction

                IsSuccessful = False

                If SiteOPRHeader.Id <> 0 Then
                    strItem = SiteOPRHeader.Alter("CANCEL", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("SiteOPRHeader : ", strItem))
                    End If
                End If

                For Each item In SiteOPRInfo
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRInfo : ", strItem))
                        End If
                    End If
                Next

                If SiteOPRVAT.Id <> 0 Then
                    strItem = SiteOPRVAT.Alter("DELETE", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("SiteOPRVAT : ", strItem))
                    End If
                End If

                If SitePAMaster.Id <> 0 Then
                    strItem = SitePAMaster.Alter("DELETE", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("SitePAMaster : ", strItem))
                    End If
                End If

                For Each item In SiteOPRDtl
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRDtl : ", strItem))
                        End If
                    End If
                Next

                For Each item In SiteOPRAPRPy
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRAPRPy : ", strItem))
                        End If
                    End If
                Next

                For Each item In SiteOPRChkPy
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRChkPy : ", strItem))
                        End If
                    End If
                Next

                For Each item In SiteOPRCred
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRCred : ", strItem))
                        End If
                    End If
                Next

                For Each item In SiteOPRDebit
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRDebit : ", strItem))
                        End If
                    End If
                Next

                For Each item In SiteOPRECash
                    If item.Id <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteOPRECash : ", strItem))
                        End If
                    End If
                Next
                For Each item In SiteTmpTrn
                    If item.Id <> 0 Then
                        strItem = item.Alter("CANCEL", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("SiteTmpTrn : ", strItem))
                        End If
                    End If
                Next

                ' NEWGEN HMO INTEGRATION
                If Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-HMO"), "false")) Then
                    If PolMod = "HMO" Then
                        strItem = HMOPayslip.Alter(Split(SiteOPRHeader.OPRRemarks, " - ")(1), "", SiteOPRHeader.OPRDate, oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("HMO Payslip : ", strItem))
                        End If
                    End If
                End If

                ' NG POSTING CANCELLATION
                If Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Life"), "false")) Or Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Group"), "false")) Then
                    strItem = NewgenPaymentUpd.UpdateStatus(SiteOPRHeader.OPRRcptNo, "", 0D, "4", "", Now, oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("Newgen Update : ", strItem))
                    End If
                End If
                '-------------------------------------
                Call CopyToStgObjects()
                '-------------------------------------

                If StgOPRHeader.OPRRcptNo <> 0 Then
                    strItem = StgOPRHeader.Alter("CANCEL", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("StgOPRHeader : ", strItem))
                    End If
                End If

                If StgPAMaster.DocNumber <> 0 Then
                    strItem = StgPAMaster.Alter("CANCEL", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("StgPAMaster : ", strItem))
                    End If
                End If

                For Each item In StgOPRInfo
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgOPRInfo : ", strItem))
                        End If
                    End If
                Next

                If StgOPRVAT.OPRNmbr <> 0 Then
                    strItem = StgOPRVAT.Alter("DELETE", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("StgOPRVAT : ", strItem))
                    End If
                End If

                'If StgPAMaster.Id <> 0 Then
                '    strItem = StgPAMaster.Alter("DELETE")
                'End If

                For Each item In StgOPRDtl
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgOPRDtl : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgOPRAPRPy
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgOPRAPRPy : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgOPRChkPy
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgOPRChkPy : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgOPRCred
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgOPRCred : ", strItem))
                        End If
                    End If
                Next

                For Each item In StgOPRDebit
                    If item.OPRNmbr <> 0 Then
                        strItem = item.Alter("DELETE", oraConn, oraTrans)
                        If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                            Throw New ArgumentException(String.Concat("StgOPRDebit : ", strItem))
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