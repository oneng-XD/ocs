#Region "Description"
' PAGE NAME     : DMCM BLL
' CREATED BY    : Junie
' CREATED DATE  : 04/10/2025
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports Cocolife.Utility.OCS.Classes
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
Imports dalStaging = Cocolife.DAL.OCS.Staging
Imports System.Configuration
#End Region


Namespace Staging
    Public Class BDebitCredit
#Region "Implements"
        Implements IDebitCredit
#End Region

#Region "Variables"
        Private mDMCMTransNo As String = cDataType.fString.Empty
        Private mDebitCreditID As Long = cDataType.fLong.Empty
        Private mDMCMNumber As Long = cDataType.fLong.Empty
        Private mMemoType As String = cDataType.fString.Empty
        Private mBillingType As String = cDataType.fString.Empty
        Private mApprover As String = cDataType.fString.Empty
        Private mDMCMDate As Date = cDataType.fDate.Empty
        Private mRenewalDate As Date = cDataType.fDate.Empty
        Private mEffectivityDate As Date = cDataType.fDate.Empty
        Private mExpiryDate As Date = cDataType.fDate.Empty
        Private mBillPeriodFrom As Date = cDataType.fDate.Empty
        Private mBillPeriodTo As Date = cDataType.fDate.Empty
        Private mBillStatementDate As Date = cDataType.fDate.Empty

        Private mQuantity As Long = cDataType.fLong.Empty
        Private mUnitPrice As Decimal = cDataType.fDecimal.Empty
        Private mVatSales As Decimal = cDataType.fDecimal.Empty
        Private mVatExemptSales As Decimal = cDataType.fDecimal.Empty
        Private mVatAmount As Decimal = cDataType.fDecimal.Empty
        Private mNonVatSales As Decimal = cDataType.fDecimal.Empty
        Private mTotalSales As Decimal = cDataType.fDecimal.Empty
        Private mWTax As Decimal = cDataType.fDecimal.Empty
        Private mNetWTax As Decimal = cDataType.fDecimal.Empty
        Private mDiscount As Decimal = cDataType.fDecimal.Empty
        Private mTotalAmount As Decimal = cDataType.fDecimal.Empty
        Private mDiscountID As String = cDataType.fString.Empty
        Private mRoleCode As String = cDataType.fString.Empty
        Private mParticulars As String = cDataType.fString.Empty
        Private mSISourcetype As String = cDataType.fString.Empty

        Private mStatus As String = cDataType.fString.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mReason As String = cDataType.fString.Empty
       
        Private mSiteCode As Long = cDataType.fLong.Empty
        Private mSINumber As Long = cDataType.fLong.Empty
        Private mPostedBy As String = cDataType.fString.Empty

        Private mPolicyNumber As String = cDataType.fString.Empty
        Private mPayor As String = cDataType.fString.Empty
        Private mTin As String = cDataType.fString.Empty
        Private mAddress As String = cDataType.fString.Empty
        Private mReferenceNo As String = cDataType.fString.Empty
        Private mBillStatNo As String = cDataType.fString.Empty
        Private mPaymentTerm As String = cDataType.fString.Empty
        Private mInvoiceDate As Date = cDataType.fDate.Empty
        Private mSiteName As String = cDataType.fString.Empty
        Private mSiteTin As String = cDataType.fString.Empty
        Private mSiteAddr As String = cDataType.fString.Empty
        Private mSiteTelNo As String = cDataType.fString.Empty
        Private mPreparedBy As String = cDataType.fString.Empty
        Private mPrintCounter As Long = cDataType.fLong.Empty

        Private mIsRecordExist As Boolean = False
#End Region 'Variables

#Region "Properties"
        Public Property DebitCreditID As Long Implements IDebitCredit.DebitCreditID
            Get
                Return mDebitCreditID
            End Get
            Set(value As Long)
                mDebitCreditID = value
            End Set
        End Property
        Public Property DMCMTransNo As String Implements IDebitCredit.DMCMTransNo
            Get
                Return mDMCMTransNo
            End Get
            Set(value As String)
                mDMCMTransNo = value
            End Set
        End Property
        Public Property DMCMNumber As Long Implements IDebitCredit.DMCMNo
            Get
                Return mDMCMNumber
            End Get
            Set(value As Long)
                mDMCMNumber = value
            End Set
        End Property
        Public Property MemoType As String Implements IDebitCredit.MemoType
            Get
                Return mMemoType
            End Get
            Set(value As String)
                mMemoType = value
            End Set
        End Property
        Public Property BillingType As String Implements IDebitCredit.BillingType
            Get
                Return mBillingType
            End Get
            Set(value As String)
                mBillingType = value
            End Set
        End Property
        Public Property Approver As String Implements IDebitCredit.Approver
            Get
                Return mApprover
            End Get
            Set(value As String)
                mApprover = value
            End Set
        End Property
        Public Property DMCMDate As Date Implements IDebitCredit.DMCMDate
            Get
                Return mDMCMDate
            End Get
            Set(value As Date)
                mDMCMDate = value
            End Set
        End Property
        Public Property RenewalDate As Date Implements IDebitCredit.RenewalDate
            Get
                Return mRenewalDate
            End Get
            Set(value As Date)
                mRenewalDate = value
            End Set
        End Property
        Public Property EffectivityDate As Date Implements IDebitCredit.EffectivityDate
            Get
                Return mEffectivityDate
            End Get
            Set(value As Date)
                mEffectivityDate = value
            End Set
        End Property
        Public Property ExpiryDate As Date Implements IDebitCredit.ExpiryDate
            Get
                Return mExpiryDate
            End Get
            Set(value As Date)
                mExpiryDate = value
            End Set
        End Property
        Public Property BillPeriodFrom As Date Implements IDebitCredit.BillPeriodFrom
            Get
                Return mBillPeriodFrom
            End Get
            Set(value As Date)
                mBillPeriodFrom = value
            End Set
        End Property
        Public Property BillPeriodTo As Date Implements IDebitCredit.BillPeriodTo
            Get
                Return mBillPeriodTo
            End Get
            Set(value As Date)
                mBillPeriodTo = value
            End Set
        End Property
        Public Property BillStatementDate As Date Implements IDebitCredit.BillStatementDate
            Get
                Return mBillStatementDate
            End Get
            Set(value As Date)
                mBillStatementDate = value
            End Set
        End Property

        Public Property Quantity As Long Implements IDebitCredit.Quantity
            Get
                Return mQuantity
            End Get
            Set(value As Long)
                mQuantity = value
            End Set
        End Property
        Public Property UnitPrice As Decimal Implements IDebitCredit.UnitPrice
            Get
                Return mUnitPrice
            End Get
            Set(value As Decimal)
                mUnitPrice = value
            End Set
        End Property
        Public Property Status As String Implements IDebitCredit.Status
            Get
                Return mStatus
            End Get
            Set(value As String)
                mStatus = value
            End Set
        End Property
        Public Property Remarks As String Implements IDebitCredit.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property
        Public Property Reason As String Implements IDebitCredit.Reason
            Get
                Return mReason
            End Get
            Set(value As String)
                mReason = value
            End Set
        End Property
        Public Property VatSales As Decimal Implements IDebitCredit.VatSales
            Get
                Return mVatSales
            End Get
            Set(value As Decimal)
                mVatSales = value
            End Set
        End Property
        Public Property VatExemptSales As Decimal Implements IDebitCredit.VatExemptSales
            Get
                Return mVatExemptSales
            End Get
            Set(value As Decimal)
                mVatExemptSales = value
            End Set
        End Property
        Public Property VatAmount As Decimal Implements IDebitCredit.VatAmount
            Get
                Return mVatAmount
            End Get
            Set(value As Decimal)
                mVatAmount = value
            End Set
        End Property
        Public Property NonVatSales As Decimal Implements IDebitCredit.NonVatSales
            Get
                Return mNonVatSales
            End Get
            Set(value As Decimal)
                mNonVatSales = value
            End Set
        End Property
        Public Property TotalSales As Decimal Implements IDebitCredit.TotalSales
            Get
                Return mTotalSales
            End Get
            Set(value As Decimal)
                mTotalSales = value
            End Set
        End Property
        Public Property WTax As Decimal Implements IDebitCredit.WTax
            Get
                Return mWTax
            End Get
            Set(value As Decimal)
                mWTax = value
            End Set
        End Property
        Public Property NetWTax As Decimal Implements IDebitCredit.NetWTax
            Get
                Return mNetWTax
            End Get
            Set(value As Decimal)
                mNetWTax = value
            End Set
        End Property
        Public Property Discount As Decimal Implements IDebitCredit.Discount
            Get
                Return mDiscount
            End Get
            Set(value As Decimal)
                mDiscount = value
            End Set
        End Property
        Public Property TotalAmount As Decimal Implements IDebitCredit.TotalAmount
            Get
                Return mTotalAmount
            End Get
            Set(value As Decimal)
                mTotalAmount = value
            End Set
        End Property
        Public Property DiscountID As String Implements IDebitCredit.DiscountID
            Get
                Return mDiscountID
            End Get
            Set(value As String)
                mDiscountID = value
            End Set
        End Property
        Public Property RoleCode As String Implements IDebitCredit.RoleCode
            Get
                Return mRoleCode
            End Get
            Set(value As String)
                mRoleCode = value
            End Set
        End Property
        Public Property Particulars As String Implements IDebitCredit.Particulars
            Get
                Return mParticulars
            End Get
            Set(value As String)
                mParticulars = value
            End Set
        End Property
        Public Property SISourcetype As String Implements IDebitCredit.SISourcetype
            Get
                Return mSISourcetype
            End Get
            Set(value As String)
                mSISourcetype = value
            End Set
        End Property
        Public Property SiteCode As Long Implements IDebitCredit.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property
        Public Property SINumber As Long Implements IDebitCredit.SINumber
            Get
                Return mSINumber
            End Get
            Set(value As Long)
                mSINumber = value
            End Set
        End Property
        Public Property PostedBy As String Implements IDebitCredit.PostedBy
            Get
                Return mPostedBy
            End Get
            Set(value As String)
                mPostedBy = value
            End Set
        End Property
        Public Property IsRecordExist() As Boolean Implements IDebitCredit.IsRecordExist
            Get
                Return mIsRecordExist
            End Get
            Set(ByVal value As Boolean)
                mIsRecordExist = value
            End Set
        End Property

        Public Property PolicyNumber As String Implements IDebitCredit.PolicyNumber
            Get
                Return mPolicyNumber
            End Get
            Set(value As String)
                mPolicyNumber = value
            End Set
        End Property
        Public Property Payor As String Implements IDebitCredit.Payor
            Get
                Return mPayor
            End Get
            Set(value As String)
                mPayor = value
            End Set
        End Property
        Public Property Tin As String Implements IDebitCredit.Tin
            Get
                Return mTin
            End Get
            Set(value As String)
                mTin = value
            End Set
        End Property
        Public Property SiteName As String Implements IDebitCredit.SiteName
            Get
                Return mSiteName
            End Get
            Set(value As String)
                mSiteName = value
            End Set
        End Property
        Public Property SiteAddr As String Implements IDebitCredit.SiteAddr
            Get
                Return mSiteAddr
            End Get
            Set(value As String)
                mSiteAddr = value
            End Set
        End Property
        Public Property SiteTelNo As String Implements IDebitCredit.SiteTelNo
            Get
                Return mSiteTelNo
            End Get
            Set(value As String)
                mSiteTelNo = value
            End Set
        End Property
        Public Property SiteTin As String Implements IDebitCredit.SiteTin
            Get
                Return mSiteTin
            End Get
            Set(value As String)
                mSiteTin = value
            End Set
        End Property
        Public Property PreparedBy As String Implements IDebitCredit.PreparedBy
            Get
                Return mPreparedBy
            End Get
            Set(value As String)
                mPreparedBy = value
            End Set
        End Property
        Public Property Address As String Implements IDebitCredit.Address
            Get
                Return mAddress
            End Get
            Set(value As String)
                mAddress = value
            End Set
        End Property
        Public Property ReferenceNo As String Implements IDebitCredit.ReferenceNo
            Get
                Return mReferenceNo
            End Get
            Set(value As String)
                mReferenceNo = value
            End Set
        End Property
        Public Property BillStatNo As String Implements IDebitCredit.BillStatNo
            Get
                Return mBillStatNo
            End Get
            Set(value As String)
                mBillStatNo = value
            End Set
        End Property
        Public Property PaymentTerm As String Implements IDebitCredit.PaymentTerm
            Get
                Return mPaymentTerm
            End Get
            Set(value As String)
                mPaymentTerm = value
            End Set
        End Property
        Public Property InvoiceDate As Date Implements IDebitCredit.InvoiceDate
            Get
                Return mInvoiceDate
            End Get
            Set(value As Date)
                mInvoiceDate = value
            End Set
        End Property
        Public Property PrintCounter As Long Implements IDebitCredit.PrintCounter
            Get
                Return mPrintCounter
            End Get
            Set(value As Long)
                mPrintCounter = value
            End Set
        End Property
#End Region 'Properties

#Region "Constructor"
        Sub New()

        End Sub
        Sub New(ByVal pDebitCreditID As Long, ByVal pDMCMNumber As Long, ByVal pDMCMTransNo As String, ByVal pSalesInvoiceNumber As Long, ByVal pMemoType As String, ByVal pDMCMDate As Date,
                ByVal pRenewalDate As Date, ByVal pEffectivityDate As Date, ByVal pExpiryDate As Date, ByVal pBillPeriodFrom As Date, ByVal pBillPeriodTo As Date, ByVal pBillStatementDate As Date,
                ByVal pPostedBy As String, ByVal pSiteCode As Long, ByVal pPayor As String, ByVal pAddress As String, ByVal pTin As String, ByVal pPolicyNumber As String, ByVal pSIDate As Date,
                ByVal pRemarks As String, ByVal pReason As String, ByVal pMode As String, ByVal pReferenceNo As String, ByVal pBillStatNo As String, ByVal pSiteName As String, ByVal pSiteAddr As String, ByVal pSiteTelNo As String,
                ByVal pSiteTin As String, ByVal pPreparedBy As String, ByVal pBillingType As String, ByVal pParticulars As String, ByVal pUnitPrice As Decimal, ByVal pQuantity As Long,
                ByVal pTotalAmount As Decimal, ByVal pVatSales As Decimal, ByVal pVatExemptSales As Decimal, ByVal pVatAmount As Decimal, ByVal pNonVatSales As Decimal, ByVal pTotalSales As Decimal,
                ByVal pWTax As Decimal, ByVal pNetWTax As Decimal, ByVal pDiscount As Decimal, ByVal pDiscountID As String, ByVal pRoleCode As String, ByVal pApprover As String, ByVal pSISourcetype As String)
            DebitCreditID = pDebitCreditID
            DMCMNumber = pDMCMNumber
            DMCMTransNo = pDMCMTransNo
            SINumber = pSalesInvoiceNumber
            MemoType = pMemoType
            DMCMDate = pDMCMDate
            RenewalDate = pRenewalDate
            EffectivityDate = pEffectivityDate
            ExpiryDate = pExpiryDate
            BillPeriodFrom = pBillPeriodFrom
            BillPeriodTo = pBillPeriodTo
            BillStatementDate = pBillStatementDate
            PostedBy = pPostedBy
            SiteCode = pSiteCode
            Payor = pPayor
            Address = pAddress
            Tin = pTin
            PolicyNumber = pPolicyNumber
            InvoiceDate = pSIDate
            Remarks = pRemarks
            Reason = pReason
            PaymentTerm = pMode
            ReferenceNo = pReferenceNo
            BillStatNo = pBillStatNo
            SiteName = pSiteName
            SiteAddr = pSiteAddr
            SiteTelNo = pSiteTelNo
            SiteTin = pSiteTin
            PreparedBy = pPreparedBy
            BillingType = pBillingType
            Particulars = pParticulars
            UnitPrice = pUnitPrice
            Quantity = pQuantity
            TotalAmount = pTotalAmount
            VatSales = pVatSales
            VatExemptSales = pVatExemptSales
            VatAmount = pVatAmount
            NonVatSales = pNonVatSales
            TotalSales = pTotalSales
            WTax = pWTax
            NetWTax = pNetWTax
            Discount = pDiscount
            DiscountID = pDiscountID
            RoleCode = pRoleCode
            Approver = pApprover
            SISourcetype = pSISourcetype

        End Sub

#End Region 'Constructor

#Region "Data Retrieval"

        Public Function LoadViewDMCM(ByVal pPrspid As Long, ByVal pRoleCode As String, ByVal pDocNumber As Long, ByVal pTransID As String, ByVal pType As Integer) As DataTable Implements IDebitCredit.LoadViewDMCM

            Dim objDAL As New dalStaging.DDebitCredit
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetDocList(pPrspid, pRoleCode, pDocNumber, pTransID, pType)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewDMCM(ByVal pPrspid As Long, ByVal pRoleCode As String, Optional ByVal pStartDate As Date? = Nothing, Optional ByVal pEndDate As Date? = Nothing) As DataTable Implements IDebitCredit.LoadViewDMCM

            Dim objDAL As New dalStaging.DDebitCredit
            Dim dtLocal As DataTable

            Try

                dtLocal = objDAL.GetDocList(pPrspid, pRoleCode, pStartDate, pEndDate)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function
        Public Function LoadViewDMCM(ByVal pPrspid As Long, ByVal pRoleCode As String, ByVal pType As Integer, ByVal pDocNumber As Long, ByVal pStartDate As Date, ByVal pEndDate As Date) As DataTable Implements IDebitCredit.LoadViewDMCM

            Dim objDAL As New dalStaging.DDebitCredit
            Dim dtLocal As DataTable

            Try

                dtLocal = objDAL.GetDocList(pPrspid, pRoleCode, pType, pDocNumber, pStartDate, pEndDate)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Sub LoadTaxAmount(ByVal pBillNumber As String, pAmount As Decimal, pQuantity As Long) Implements IDebitCredit.SearchTaxAmount
            Dim objDalDMCM As New dalStaging.DDebitCredit
            'Dim objDalARPay As New dalStaging.DARPayDetails
            'Dim objDalSI As New dalReference.DSalesInvoice

            Dim dtTaxAmount As DataTable

            Try
                dtTaxAmount = objDalDMCM.SearchTaxAmount(pBillNumber, pAmount, pQuantity)
                'dtARPayDetails = objDalARPay.GetARPayDetails(pTransID, pUserID)
                For Each dr As DataRow In dtTaxAmount.Rows
                    VatAmount = cDataType.fDecimal.IfNull(dr.Item("VAT_AMOUNT"))
                    VatExemptSales = cDataType.fDecimal.IfNull(dr.Item("VAT_EXEMPT"))
                    VatSales = cDataType.fDecimal.IfNull(dr.Item("VATABLE_SALES"))
                    NonVatSales = cDataType.fDecimal.IfNull(dr.Item("NON_VAT"))
                    TotalSales = cDataType.fDecimal.IfNull(dr.Item("TOTAL_SALES"))
                    WTax = cDataType.fDecimal.IfNull(dr.Item("WTAX"))
                    NetWTax = cDataType.fDecimal.IfNull(dr.Item("AMOUNTWTAX"))
                    Discount = cDataType.fDecimal.IfNull(dr.Item("DISCOUNT"))
                    TotalAmount = cDataType.fDecimal.IfNull(dr.Item("TOTAL_AMOUNT"))
                    DiscountID = cDataType.fLong.IfNull(dr.Item("DISCOUNT_ID"))
                    'IsRecordExist = True
                    Exit For
                Next
                'If IsRecordExist Then dtSIDetails = objDalSI.SearchSIDetails(BillReferenceNo)

            Catch ex As Exception
                Throw
            End Try
        End Sub
        Public Function GetApprover(ByVal pRoleCode As String) As DataTable Implements IDebitCredit.GetApprover

            Try

                Dim objDAL As New dalStaging.DDebitCredit
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetApprover(pRoleCode)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Sub LoadDebitCreditMemo(ByVal pTransID As Long, pUserID As Long) Implements IDebitCredit.SearchDebitCreditMemo
            Dim objDalDMCM As New dalStaging.DDebitCredit
            'Dim objDalARPay As New dalStaging.DARPayDetails
            'Dim objDalSI As New dalReference.DSalesInvoice

            Dim dtDebitCreditMemo As DataTable

            Try
                dtDebitCreditMemo = objDalDMCM.SearchDebitCreditMemo(pTransID)
                'dtARPayDetails = objDalARPay.GetARPayDetails(pTransID, pUserID)
                For Each dr As DataRow In dtDebitCreditMemo.Rows
                    DebitCreditID = cDataType.fLong.IfNull(dr.Item("ID"))
                    DMCMTransNo = cDataType.fString.IfNull(dr.Item("TRANSACTION_ID"))
                    DMCMNumber = cDataType.fLong.IfNull(dr.Item("DMCM_NUMBER"))
                    MemoType = cDataType.fString.IfNull(dr.Item("MEMO_TYPE"))
                    BillingType = cDataType.fString.IfNull(dr.Item("BILLING_TYPE"))
                    DMCMDate = cDataType.fDate.IfNull(dr.Item("DMCM_DATE"))
                    RenewalDate = cDataType.fDate.IfNull(dr.Item("RENEWAL_DATE"))
                    EffectivityDate = cDataType.fDate.IfNull(dr.Item("EFFECTIVITY_DATE"))
                    BillPeriodFrom = cDataType.fDate.IfNull(dr.Item("BILLING_PERIOD_FROM"))
                    BillPeriodTo = cDataType.fDate.IfNull(dr.Item("BILLING_PERIOD_To"))
                    ExpiryDate = cDataType.fDate.IfNull(dr.Item("EXPIRY_DATE"))
                    Quantity = cDataType.fLong.IfNull(dr.Item("QUANTITY"))
                    UnitPrice = cDataType.fDecimal.IfNull(dr.Item("UNIT_PRICE"))
                    Status = cDataType.fString.IfNull(dr.Item("STATUS"))
                    Remarks = cDataType.fString.IfNull(dr.Item("REMARKS"))
                    Particulars = cDataType.fString.IfNull(dr.Item("PARTICULARS"))
                    Quantity = cDataType.fLong.IfNull(dr.Item("QUANTITY"))
                    Reason = cDataType.fString.IfNull(dr.Item("REASON"))
                    VatSales = cDataType.fDecimal.IfNull(dr.Item("VATABLE_SALES"))
                    VatExemptSales = cDataType.fDecimal.IfNull(dr.Item("VAT_EXEMPT_SALES"))
                    VatAmount = cDataType.fDecimal.IfNull(dr.Item("VAT_AMOUNT"))
                    NonVatSales = cDataType.fDecimal.IfNull(dr.Item("NON_VAT_SALES"))
                    TotalAmount = cDataType.fDecimal.IfNull(dr.Item("TOTAL_AMOUNT"))
                    TotalSales = cDataType.fDecimal.IfNull(dr.Item("TOTAL_SALES"))
                    WTax = cDataType.fDecimal.IfNull(dr.Item("WITHHOLDING_tAX"))
                    NetWTax = cDataType.fDecimal.IfNull(dr.Item("NET_WITHHOLDING_TAX"))
                    Discount = cDataType.fLong.IfNull(dr.Item("DISCOUNT"))
                    DiscountID = cDataType.fString.IfNull(dr.Item("DISCOUNT_ID"))
                    SiteCode = cDataType.fLong.IfNull(dr.Item("SITE_CODE"))
                    SINumber = cDataType.fLong.IfNull(dr.Item("SI_NUMBER"))
                    PostedBy = cDataType.fString.IfNull(dr.Item("POSTED_BY"))
                    PolicyNumber = cDataType.fString.IfNull(dr.Item("POLICY_NUMBER"))
                    Payor = cDataType.fString.IfNull(dr.Item("PAYOR"))
                    Tin = cDataType.fString.IfNull(dr.Item("TIN"))
                    Address = cDataType.fString.IfNull(dr.Item("ADDRESS"))
                    ReferenceNo = cDataType.fString.IfNull(dr.Item("REFERENCE_NO"))
                    BillStatNo = cDataType.fString.IfNull(dr.Item("BILLING_STATEMENT_NO"))
                    PaymentTerm = cDataType.fString.IfNull(dr.Item("PAYMENT_TERM"))
                    InvoiceDate = cDataType.fDate.IfNull(dr.Item("SALES_INVOICE_DATE"))
                    SiteAddr = cDataType.fString.IfNull(dr.Item("SITE_ADDRESS"))
                    SiteTin = cDataType.fString.IfNull(dr.Item("SITE_TIN"))
                    SiteTelNo = cDataType.fString.IfNull(dr.Item("SITE_CONTACT"))
                    PreparedBy = cDataType.fString.IfNull(dr.Item("PREPARED_BY"))
                    SiteName = cDataType.fString.IfNull(dr.Item("SITE_NAME"))
                    PrintCounter = cDataType.fString.IfNull(dr.Item("PRINT_COUNTER"))
                    Approver = cDataType.fString.IfNull(dr.Item("APPROVER"))
                    '--si details

                    IsRecordExist = True
                    Exit For
                Next
                'If IsRecordExist Then dtSIDetails = objDalSI.SearchSIDetails(BillReferenceNo)

            Catch ex As Exception
                Throw
            End Try
        End Sub

#End Region 'Data Retrieval

#Region "Transactions"
        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DDebitCredit
                objDAL.AlterDebitCreditMemo(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region










    End Class
End Namespace
