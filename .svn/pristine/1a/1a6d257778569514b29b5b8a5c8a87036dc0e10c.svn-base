#Region "Description"
' PAGE NAME     : PAYSLIP BLL
' CREATED BY    : EJ
' CREATED DATE  : 11/13/2024
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
Imports System.Configuration

#End Region

Namespace Reference

    Public Class BSalesInvoice

#Region "Implements"
        Implements ISalesInvoice
#End Region

#Region "Variables"
        Private mSalesInvoiceID As Long = cDataType.fLong.Empty
        Private mUploadTag As Char = cDataType.fString.Empty
        Private mReferenceNo As String = cDataType.fString.Empty
        Private mPayorName As String = cDataType.fString.Empty
        Private mPayorAddress As String = cDataType.fString.Empty
        Private mPayorTIN As String = cDataType.fString.Empty
        Private mInsuredClientName As String = cDataType.fString.Empty
        Private mPolicyNumber As String = cDataType.fString.Empty
        Private mCoveragePeriodFrom As Date = cDataType.fDate.Empty
        Private mCoveragePeriodTo As Date = cDataType.fDate.Empty
        Private mInvoiceCurrency As String = cDataType.fString.Empty
        Private mInvoiceAmount As Decimal = cDataType.fDecimal.Empty
        Private mVATable As Decimal = cDataType.fDecimal.Empty
        Private mVATExempt As Decimal = cDataType.fDecimal.Empty
        Private mVATAmount As Decimal = cDataType.fDecimal.Empty
        Private mNonVAT As Decimal = cDataType.fDecimal.Empty
        Private mTotalSales As Decimal = cDataType.fDecimal.Empty
        Private mWitholdingTax As Decimal = cDataType.fDecimal.Empty
        Private mNetOfWitholdingTax As Decimal = cDataType.fDecimal.Empty
        Private mDiscount As Decimal = cDataType.fDecimal.Empty
        Private mDiscountIdNo As String = cDataType.fString.Empty
        Private mPaymentTerm As String = cDataType.fString.Empty
        Private mNextDueDate As Date = cDataType.fDate.Empty
        Private mAgentName As String = cDataType.fString.Empty
        Private mAgentCode As String = cDataType.fString.Empty
        Private mInvoiceRemarks As String = cDataType.fString.Empty
        Private mInvoiceOtherInfo As String = cDataType.fString.Empty
        Private mSalesInvoiceNumber As Long = cDataType.fLong.Empty
        Private mAckReceiptNumber As Long = cDataType.fLong.Empty
        Private mInvoiceDate As Date = cDataType.fDate.Empty
        Private mSIPrintStatus As String = cDataType.fString.Empty
        Private mUploadDate As Date = cDataType.fDate.Empty
        Private mSIPrintedBy As String = cDataType.fString.Empty
        Private mSiteCode As Long = cDataType.fLong.Empty
        Private mSIDetails As DataTable = New DataTable
        Private mParticularsRaw As String = cDataType.fString.Empty
        Private mIsFromNewgenAPI As Boolean = False
        Private mSISourceType As String = cDataType.fString.Empty



        Private mPreparedBy As String = cDataType.fString.Empty
        Private mQuantity As Long = cDataType.fLong.Empty
        Private mUnitPrice As Decimal = cDataType.fDecimal.Empty
        Private mParticulars As String = cDataType.fString.Empty
        Private mSiteName As String = cDataType.fString.Empty
        Private mSiteAddr As String = cDataType.fString.Empty
        Private mSiteTin As String = cDataType.fString.Empty
        Private mSiteContact As String = cDataType.fString.Empty
        Private mBillStatDate As Date = cDataType.fDate.Empty
        Private mBillStatNo As String = cDataType.fString.Empty
        ' -------------------------------------------------------------------------------
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"

        Public Property SalesInvoiceID As Long Implements ISalesInvoice.SalesInvoiceID
            Get
                Return mSalesInvoiceID
            End Get
            Set(value As Long)
                mSalesInvoiceID = value
            End Set
        End Property

        Public Property UploadTag As Char Implements ISalesInvoice.Tag
            Get
                Return mUploadTag
            End Get
            Set(value As Char)
                mUploadTag = value
            End Set
        End Property

        Public Property ReferenceNo As String Implements ISalesInvoice.ReferenceNo
            Get
                Return mReferenceNo
            End Get
            Set(value As String)
                mReferenceNo = value
            End Set
        End Property


        Public Property PayorName As String Implements ISalesInvoice.PayorName
            Get
                Return mPayorName
            End Get
            Set(value As String)
                mPayorName = value
            End Set
        End Property

        Public Property PayorAddress As String Implements ISalesInvoice.PayorAddress
            Get
                Return mPayorAddress
            End Get
            Set(value As String)
                mPayorAddress = value
            End Set
        End Property

        Public Property PayorTIN As String Implements ISalesInvoice.PayorTIN
            Get
                Return mPayorTIN
            End Get
            Set(value As String)
                mPayorTIN = value
            End Set
        End Property

        Public Property InsuredClientName As String Implements ISalesInvoice.InsuredClientName
            Get
                Return mInsuredClientName
            End Get
            Set(value As String)
                mInsuredClientName = value
            End Set
        End Property

        Public Property PolicyNumber As String Implements ISalesInvoice.PolicyNumber
            Get
                Return mPolicyNumber
            End Get
            Set(value As String)
                mPolicyNumber = value
            End Set
        End Property

        Public Property CoveragePeriodFrom As Date Implements ISalesInvoice.CoveragePeriodFrom
            Get
                Return mCoveragePeriodFrom
            End Get
            Set(value As Date)
                mCoveragePeriodFrom = value
            End Set
        End Property

        Public Property CoveragePeriodTo As Date Implements ISalesInvoice.CoveragePeriodTo
            Get
                Return mCoveragePeriodTo
            End Get
            Set(value As Date)
                mCoveragePeriodTo = value
            End Set
        End Property

        Public Property InvoiceCurrency As String Implements ISalesInvoice.InvoiceCurrency
            Get
                Return mInvoiceCurrency
            End Get
            Set(value As String)
                mInvoiceCurrency = value
            End Set
        End Property

        Public Property InvoiceAmount As Decimal Implements ISalesInvoice.InvoiceAmount
            Get
                Return mInvoiceAmount
            End Get
            Set(value As Decimal)
                mInvoiceAmount = value
            End Set
        End Property

        Public Property VATable As Decimal Implements ISalesInvoice.VATable
            Get
                Return mVATable
            End Get
            Set(value As Decimal)
                mVATable = value
            End Set
        End Property

        Public Property VATExempt As Decimal Implements ISalesInvoice.VATExempt
            Get
                Return mVATExempt
            End Get
            Set(value As Decimal)
                mVATExempt = value
            End Set
        End Property

        Public Property VATAmount As Decimal Implements ISalesInvoice.VATAmount
            Get
                Return mVATAmount
            End Get
            Set(value As Decimal)
                mVATAmount = value
            End Set
        End Property

        Public Property NonVAT As Decimal Implements ISalesInvoice.NonVAT
            Get
                Return mNonVAT
            End Get
            Set(value As Decimal)
                mNonVAT = value
            End Set
        End Property

        Public Property TotalSales As Decimal Implements ISalesInvoice.TotalSales
            Get
                Return mTotalSales
            End Get
            Set(value As Decimal)
                mTotalSales = value
            End Set
        End Property

        Public Property WitholdingTax As Decimal Implements ISalesInvoice.WitholdingTax
            Get
                Return mWitholdingTax
            End Get
            Set(value As Decimal)
                mWitholdingTax = value
            End Set
        End Property

        Public Property NetOfWitholdingTax As Decimal Implements ISalesInvoice.NetOfWitholdingTax
            Get
                Return mNetOfWitholdingTax
            End Get
            Set(value As Decimal)
                mNetOfWitholdingTax = value
            End Set
        End Property

        Public Property Discount As Decimal Implements ISalesInvoice.Discount
            Get
                Return mDiscount
            End Get
            Set(value As Decimal)
                mDiscount = value
            End Set
        End Property

        Public Property DiscountIdNo As String Implements ISalesInvoice.DiscountIdNo
            Get
                Return mDiscountIdNo
            End Get
            Set(value As String)
                mDiscountIdNo = value
            End Set
        End Property

        Public Property PaymentTerm As String Implements ISalesInvoice.PaymentTerm
            Get
                Return mPaymentTerm
            End Get
            Set(value As String)
                mPaymentTerm = value
            End Set
        End Property

        Public Property NextDueDate As Date Implements ISalesInvoice.NextDueDate
            Get
                Return mNextDueDate
            End Get
            Set(value As Date)
                mNextDueDate = value
            End Set
        End Property

        Public Property AgentName As String Implements ISalesInvoice.AgentName
            Get
                Return mAgentName
            End Get
            Set(value As String)
                mAgentName = value
            End Set
        End Property

        Public Property AgentCode As String Implements ISalesInvoice.AgentCode
            Get
                Return mAgentCode
            End Get
            Set(value As String)
                mAgentCode = value
            End Set
        End Property

        Public Property InvoiceRemarks As String Implements ISalesInvoice.InvoiceRemarks
            Get
                Return mInvoiceRemarks
            End Get
            Set(value As String)
                mInvoiceRemarks = value
            End Set
        End Property

        Public Property InvoiceOtherInfo As String Implements ISalesInvoice.InvoiceOtherInfo
            Get
                Return mInvoiceOtherInfo
            End Get
            Set(value As String)
                mInvoiceOtherInfo = value
            End Set
        End Property

        Public Property InvoiceNumber As Long Implements ISalesInvoice.InvoiceNumber
            Get
                Return mSalesInvoiceNumber
            End Get
            Set(value As Long)
                mSalesInvoiceNumber = value
            End Set
        End Property

        Public Property AckReceiptNumber As Long Implements ISalesInvoice.AckReceiptNumber
            Get
                Return mAckReceiptNumber
            End Get
            Set(value As Long)
                mAckReceiptNumber = value
            End Set
        End Property

        Public Property InvoiceDate As Date Implements ISalesInvoice.InvoiceDate
            Get
                Return mInvoiceDate
            End Get
            Set(value As Date)
                mInvoiceDate = value
            End Set
        End Property

        Public Property SIPrintStatus As String Implements ISalesInvoice.SIPrintStatus
            Get
                Return mSIPrintStatus
            End Get
            Set(value As String)
                mSIPrintStatus = value
            End Set
        End Property

        Public Property UploadDate As Date Implements ISalesInvoice.UploadDate
            Get
                Return mUploadDate
            End Get
            Set(value As Date)
                mUploadDate = value
            End Set
        End Property

        Public Property SiteCode As Long Implements ISalesInvoice.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property SIPrintedBy() As String Implements ISalesInvoice.SIPrintedBy
            Get
                Return mSIPrintedBy
            End Get
            Set(ByVal value As String)
                mSIPrintedBy = value
            End Set
        End Property

        Public Property Particulars() As String Implements ISalesInvoice.Particulars
            Get
                Return mParticulars
            End Get
            Set(ByVal value As String)
                mParticulars = value
            End Set
        End Property
        Public Property IsFromNewgenAPI As Boolean
            Get
                Return mIsFromNewgenAPI
            End Get
            Set(value As Boolean)
                mIsFromNewgenAPI = value
            End Set
        End Property
        Public Property SISourceType As String Implements ISalesInvoice.SISourceType
            Get
                Return mSISourceType
            End Get
            Set(ByVal value As String)
                mSISourceType = value
            End Set
        End Property
        Public Property Quantity() As Long Implements ISalesInvoice.Quantity
            Get
                Return mQuantity
            End Get
            Set(ByVal value As Long)
                mQuantity = value
            End Set
        End Property
        Public Property UnitPrice() As Decimal Implements ISalesInvoice.UnitPrice
            Get
                Return mUnitPrice
            End Get
            Set(ByVal value As Decimal)
                mUnitPrice = value
            End Set
        End Property
        Public Property PreparedBy() As String Implements ISalesInvoice.PreparedBy
            Get
                Return mPreparedBy
            End Get
            Set(ByVal value As String)
                mPreparedBy = value
            End Set
        End Property
        Public Property SiteName() As String Implements ISalesInvoice.SiteName
            Get
                Return mSiteName
            End Get
            Set(ByVal value As String)
                mSiteName = value
            End Set
        End Property
        Public Property SiteAddr() As String Implements ISalesInvoice.SiteAddr
            Get
                Return mSiteAddr
            End Get
            Set(ByVal value As String)
                mSiteAddr = value
            End Set
        End Property
        Public Property SiteTin() As String Implements ISalesInvoice.SiteTin
            Get
                Return mSiteTin
            End Get
            Set(ByVal value As String)
                mSiteTin = value
            End Set
        End Property
        Public Property SiteContact() As String Implements ISalesInvoice.SiteContact
            Get
                Return mSiteContact
            End Get
            Set(ByVal value As String)
                mSiteContact = value
            End Set
        End Property
        Public Property BillStatDate As Date Implements ISalesInvoice.BillStatDate
            Get
                Return mBillStatDate
            End Get
            Set(value As Date)
                mBillStatDate = value
            End Set
        End Property
        Public Property BillStatNo As String Implements ISalesInvoice.BillStatNo
            Get
                Return mBillStatNo
            End Get
            Set(value As String)
                mBillStatNo = value
            End Set
        End Property
        Public Property ParticularsRaw As String Implements ISalesInvoice.ParticularsRaw 'new coll
            Get
                Return mParticularsRaw
            End Get
            Set(value As String)
                mParticularsRaw = value
            End Set
        End Property
        'end

        ' -------------------------------------------------------------------------------

        Public Property IsRecordExist() As Boolean Implements ISalesInvoice.IsRecordExist
            Get
                Return mIsRecordExist
            End Get
            Set(ByVal value As Boolean)
                mIsRecordExist = value
            End Set
        End Property

        Public Property dtSIDetails() As DataTable Implements ISalesInvoice.lstSIDetails
            Get
                Return mSIDetails
            End Get
            Set(ByVal value As DataTable)
                mSIDetails = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pReferenceNo As String, ByVal pInvoiceNumber As Long, ByVal pInvoiceDate As Date, ByVal pSiteCode As Long, ByVal pSIPrintedBy As String, ByVal pRemarks As String, ByVal pOtherInfo As String)
            ReferenceNo = pReferenceNo
            InvoiceNumber = pInvoiceNumber
            InvoiceDate = pInvoiceDate
            SiteCode = pSiteCode
            SIPrintedBy = pSIPrintedBy
            InvoiceRemarks = pRemarks
            InvoiceOtherInfo = pOtherInfo
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Sub LoadNewSalesInvoice(ByVal pSiteId As Long, ByVal pUserId As Long, Optional ByRef pConn As Object = Nothing, Optional ByRef pTrans As Object = Nothing) Implements ISalesInvoice.LoadNewSalesInvoice
            Dim objDal As New dalReference.DSiteDetails
            Dim mLastDocNo As String

            Try
                mLastDocNo = objDal.GetLastSalesInvoice(pSiteId, pUserId, pConn, pTrans)

                If IsNewSalesInvoiceAllowed(mLastDocNo) Then
                    InvoiceDate = Now
                End If

            Catch ex As Exception
                Throw
            End Try

        End Sub

        Public Function LoadViewDoc(ByVal pPrspid As Long, ByVal pDocNumber As Long, Optional ByVal pType As Integer = 0) As DataTable Implements ISalesInvoice.LoadViewDoc

            Dim objDAL As New dalReference.DSalesInvoice
            Dim dtLocal As DataTable

            Try
                If pType = 0 Then
                    dtLocal = objDAL.GetDocList(pPrspid, pDocNumber)
                Else
                    dtLocal = objDAL.GetDocList(pPrspid, pDocNumber, pType)
                End If

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewDoc(ByVal pPrspid As Long, ByVal pReferenceNo As String) As DataTable Implements ISalesInvoice.LoadViewDoc

            Dim objDAL As New dalReference.DSalesInvoice
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetDocList(pPrspid, pReferenceNo)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewDoc(ByVal pPrspid As Long, ByVal pParamType As Integer, Optional ByVal pStartDate As Date? = Nothing, Optional ByVal pEndDate As Date? = Nothing) As DataTable Implements ISalesInvoice.LoadViewDoc

            Dim objDAL As New dalReference.DSalesInvoice
            Dim dtLocal As DataTable

            Try

                dtLocal = objDAL.GetDocList(pPrspid, pParamType, pStartDate, pEndDate)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function
        '---
        Public Function LoadViewDocDMCM(ByVal pRoleCode As String, ByVal pDocNumber As Long, ByVal pReferenceNo As String, ByVal pType As Integer) As DataTable Implements ISalesInvoice.LoadViewDocDMCM

            Dim objDAL As New dalReference.DSalesInvoice
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetDocListDMCM(pRoleCode, pDocNumber, pReferenceNo, pType)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewDocDMCM(ByVal pRoleCode As String, Optional ByVal pStartDate As Date? = Nothing, Optional ByVal pEndDate As Date? = Nothing) As DataTable Implements ISalesInvoice.LoadViewDocDMCM

            Dim objDAL As New dalReference.DSalesInvoice
            Dim dtLocal As DataTable

            Try

                dtLocal = objDAL.GetDocListDMCM(pRoleCode, pStartDate, pEndDate)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function
      
     








        Public Function IsNewSalesInvoiceAllowed(ByVal pNextDocNumber As String) As Boolean Implements ISalesInvoice.IsNewSalesInvoiceAllowed
            Dim mDocumentDetails() As String
            Try
                mDocumentDetails = Split(pNextDocNumber, "|")

                If mDocumentDetails(0) = String.Empty Then
                    Return True
                End If

                If mDocumentDetails(1) = "READY" Then
                    Throw New ArgumentException("Please print previous Invoice.")
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw
            End Try

            Return False
        End Function
        Private Function BuildSIDetailsFromParticulars(ByVal referenceNo As String,
                                               ByVal particularsRaw As String) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("id", GetType(String))
            dt.Columns.Add("reference_no", GetType(String))
            dt.Columns.Add("particulars", GetType(String))
            dt.Columns.Add("quantity", GetType(Integer))
            dt.Columns.Add("unit_price", GetType(Decimal))
            dt.Columns.Add("amount", GetType(Decimal))

            If String.IsNullOrWhiteSpace(particularsRaw) Then
                Return dt
            End If

            Dim rows() As String = particularsRaw.Split(New String() {"},{"}, StringSplitOptions.None)

            For Each rawItem As String In rows
                Dim item As String = rawItem.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "")

                Dim dr As DataRow = dt.NewRow()
                dr("id") = Guid.NewGuid().ToString().ToUpper()
                dr("reference_no") = referenceNo
                dr("particulars") = GetJsonValue(item, "PARTICULARS")
                dr("quantity") = CInt(Val(GetJsonValue(item, "QUANTITY")))
                dr("unit_price") = CDec(Val(GetJsonValue(item, "UNIT_PRICE")))
                dr("amount") = CDec(Val(GetJsonValue(item, "AMOUNT")))

                dt.Rows.Add(dr)
            Next

            Return dt
        End Function

        Private Function GetJsonValue(ByVal item As String, ByVal key As String) As String
            Dim search As String = """" & key & """:"
            Dim startIndex As Integer = item.IndexOf(search)

            If startIndex < 0 Then
                Return ""
            End If

            startIndex += search.Length

            Dim value As String = item.Substring(startIndex)

            If value.StartsWith("""") Then
                value = value.Substring(1)
                Dim endIndex As Integer = value.IndexOf("""")
                If endIndex >= 0 Then
                    Return value.Substring(0, endIndex)
                End If
            Else
                Dim endIndex As Integer = value.IndexOf(",")
                If endIndex >= 0 Then
                    Return value.Substring(0, endIndex).Trim()
                Else
                    Return value.Trim()
                End If
            End If

            Return ""
        End Function
        Public Sub SearchSalesInvoice(ByVal pReferenceNo As String, ByVal pPolicyNo As String) Implements ISalesInvoice.SearchSalesInvoice
            Dim objDal As New dalReference.DSalesInvoice

            Dim dtSalesInvoice As DataTable

            Try
                ParticularsRaw = ""
                IsRecordExist = False

                dtSalesInvoice = objDal.SearchSalesInvoice(pReferenceNo, pPolicyNo)

                dtSIDetails = objDal.SearchSIDetails(pReferenceNo)
                For Each dr As DataRow In dtSalesInvoice.Rows
                    SalesInvoiceID = cDataType.fLong.IfNull(dr.Item("ID"))
                    UploadTag = cDataType.fString.IfNull(dr.Item("TAG"))
                    ReferenceNo = cDataType.fString.IfNull(dr.Item("REFERENCE_NO"))
                    PayorName = cDataType.fString.IfNull(dr.Item("PAYOR"))
                    PayorAddress = cDataType.fString.IfNull(dr.Item("ADDRESS"))
                    PayorTIN = cDataType.fString.IfNull(dr.Item("TIN"))
                    InsuredClientName = cDataType.fString.IfNull(dr.Item("INSURED_CLIENT_NAME"))
                    PolicyNumber = cDataType.fString.IfNull(dr.Item("POLICY_NUMBER"))
                    CoveragePeriodFrom = cDataType.fDate.IfNull(dr.Item("COVERAGE_PERIOD_FROM"))
                    CoveragePeriodTo = cDataType.fDate.IfNull(dr.Item("COVERAGE_PERIOD_TO"))
                    InvoiceCurrency = cDataType.fString.IfNull(dr.Item("CURRENCY"))
                    InvoiceAmount = cDataType.fDecimal.IfNull(dr.Item("TOTAL_AMOUNT"))
                    VATable = cDataType.fDecimal.IfNull(dr.Item("VATABLE"))
                    VATExempt = cDataType.fDecimal.IfNull(dr.Item("VAT_EXEMPT"))
                    VATAmount = cDataType.fDecimal.IfNull(dr.Item("VAT_AMOUNT"))
                    NonVAT = cDataType.fDecimal.IfNull(dr.Item("NON_VAT"))
                    TotalSales = cDataType.fDecimal.IfNull(dr.Item("TOTAL_SALES"))
                    WitholdingTax = cDataType.fDecimal.IfNull(dr.Item("WITHOLDING_TAX"))
                    NetOfWitholdingTax = cDataType.fDecimal.IfNull(dr.Item("NET_WITHHOLDING_TAX"))
                    Discount = cDataType.fDecimal.IfNull(dr.Item("DISCOUNT"))
                    DiscountIdNo = cDataType.fString.IfNull(dr.Item("DISCOUNT_ID_NO"))
                    PaymentTerm = cDataType.fString.IfNull(dr.Item("PAYMENT_TERM"))
                    NextDueDate = cDataType.fDate.IfNull(dr.Item("NEXT_DUE_DATE"))
                    AgentName = cDataType.fString.IfNull(dr.Item("AGENT_NAME"))
                    AgentCode = cDataType.fString.IfNull(dr.Item("AGENT_CODE"))
                    InvoiceRemarks = cDataType.fString.IfNull(dr.Item("REMARKS"))
                    InvoiceOtherInfo = cDataType.fString.IfNull(dr.Item("OTHER_INFO"))
                    InvoiceNumber = cDataType.fLong.IfNull(dr.Item("SALES_INVOICE_NO"))
                    InvoiceDate = cDataType.fDate.IfNull(dr.Item("SALES_INVOICE_DATE"))
                    AckReceiptNumber = cDataType.fLong.IfNull(dr.Item("AR_NO"))
                    SIPrintStatus = cDataType.fString.IfNull(dr.Item("SI_PRINT_STATUS"))
                    UploadDate = cDataType.fDate.IfNull(dr.Item("POSTED_DATE"))
                    SiteCode = cDataType.fLong.IfNull(dr.Item("SI_SITE_CODE"))
                    SIPrintedBy = cDataType.fLong.IfNull(dr.Item("SI_PRINTED_BY"))
                    If dtSalesInvoice.Columns.Contains("PARTICULARS_RAW") Then
                        ParticularsRaw = cDataType.fString.IfNull(dr.Item("PARTICULARS_RAW"))
                    End If
                    If dtSalesInvoice.Columns.Contains("IS_NEWGEN_API") Then
                        IsFromNewgenAPI =
                            (cDataType.fString.IfNull(dr.Item("IS_NEWGEN_API")) = "Y")
                    End If
                    SISourceType = cDataType.fString.IfNull(dr.Item("SI_SOURCE_TYPE"))
                    IsRecordExist = True
                    Exit For

                Next
                If IsRecordExist Then
                    If (dtSIDetails Is Nothing OrElse dtSIDetails.Rows.Count = 0) _
                        AndAlso Not String.IsNullOrWhiteSpace(ParticularsRaw) Then

                        dtSIDetails = BuildSIDetailsFromParticulars(ReferenceNo, ParticularsRaw)
                        'MsgBox("Details Count = " & dtSIDetails.Rows.Count)
                    End If
                End If

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Function SaveNewgenSalesInvoice(ByVal pUserID As String, ByVal pSiteCode As Long, ByRef pConn As Object, ByRef pTrans As Object) As String
            Dim objDAL As New dalReference.DSalesInvoice

            objDAL.SaveNewgenSalesInvoice(Me, pUserID, pSiteCode, pConn, pTrans)

            Return objDAL.Reference
        End Function

       Public Sub SearchSalesInvoiceByNo(ByVal pInvoiceNumber As String) Implements ISalesInvoice.SearchSalesInvoiceByNo

            Dim objDal As New dalReference.DSalesInvoice
            Dim dtSalesInvoice As DataTable

            IsRecordExist = False
            IsFromNewgenAPI = False
            SISourceType = String.Empty
            dtSIDetails = New DataTable()

            'Retrieve the invoice header from Oracle.
            dtSalesInvoice = objDal.SearchSalesInvoiceByNo(pInvoiceNumber)

            If dtSalesInvoice Is Nothing OrElse
               dtSalesInvoice.Rows.Count = 0 Then
                Return
            End If

            For Each dr As DataRow In dtSalesInvoice.Rows

                SalesInvoiceID = cDataType.fLong.IfNull(dr.Item("ID"))
                UploadTag = cDataType.fString.IfNull(dr.Item("TAG"))
                ReferenceNo = cDataType.fString.IfNull(dr.Item("REFERENCE_NO"))
                PayorName = cDataType.fString.IfNull(dr.Item("PAYOR"))
                PayorAddress = cDataType.fString.IfNull(dr.Item("ADDRESS"))
                PayorTIN = cDataType.fString.IfNull(dr.Item("TIN"))

                InsuredClientName =
                    cDataType.fString.IfNull(dr.Item("INSURED_CLIENT_NAME"))

                PolicyNumber = cDataType.fString.IfNull(dr.Item("POLICY_NUMBER"))

                CoveragePeriodFrom =
                    cDataType.fDate.IfNull(dr.Item("COVERAGE_PERIOD_FROM"))

                CoveragePeriodTo =
                    cDataType.fDate.IfNull(dr.Item("COVERAGE_PERIOD_TO"))

                InvoiceCurrency = cDataType.fString.IfNull(dr.Item("CURRENCY"))
                InvoiceAmount = cDataType.fDecimal.IfNull(dr.Item("TOTAL_AMOUNT"))
                VATable = cDataType.fDecimal.IfNull(dr.Item("VATABLE"))
                VATExempt = cDataType.fDecimal.IfNull(dr.Item("VAT_EXEMPT"))
                VATAmount = cDataType.fDecimal.IfNull(dr.Item("VAT_AMOUNT"))
                NonVAT = cDataType.fDecimal.IfNull(dr.Item("NON_VAT"))
                TotalSales = cDataType.fDecimal.IfNull(dr.Item("TOTAL_SALES"))

                'Support either column spelling returned by Oracle.
                If dtSalesInvoice.Columns.Contains("WITHOLDING_TAX") Then

                    WitholdingTax =
                        cDataType.fDecimal.IfNull(dr.Item("WITHOLDING_TAX"))

                ElseIf dtSalesInvoice.Columns.Contains("WITHHOLDING_TAX") Then

                    WitholdingTax =
                        cDataType.fDecimal.IfNull(dr.Item("WITHHOLDING_TAX"))

                Else
                    WitholdingTax = 0D
                End If

                NetOfWitholdingTax =
                    cDataType.fDecimal.IfNull(dr.Item("NET_WITHHOLDING_TAX"))

                Discount = cDataType.fDecimal.IfNull(dr.Item("DISCOUNT"))
                DiscountIdNo = cDataType.fString.IfNull(dr.Item("DISCOUNT_ID_NO"))
                PaymentTerm = cDataType.fString.IfNull(dr.Item("PAYMENT_TERM"))
                NextDueDate = cDataType.fDate.IfNull(dr.Item("NEXT_DUE_DATE"))
                AgentName = cDataType.fString.IfNull(dr.Item("AGENT_NAME"))
                AgentCode = cDataType.fString.IfNull(dr.Item("AGENT_CODE"))
                InvoiceRemarks = cDataType.fString.IfNull(dr.Item("REMARKS"))
                InvoiceOtherInfo = cDataType.fString.IfNull(dr.Item("OTHER_INFO"))
                InvoiceNumber = cDataType.fLong.IfNull(dr.Item("SALES_INVOICE_NO"))
                InvoiceDate = cDataType.fDate.IfNull(dr.Item("SALES_INVOICE_DATE"))
                AckReceiptNumber = cDataType.fLong.IfNull(dr.Item("AR_NO"))

                SIPrintStatus =
                    cDataType.fString.IfNull(dr.Item("SI_PRINT_STATUS"))

                UploadDate = cDataType.fDate.IfNull(dr.Item("POSTED_DATE"))
                SiteCode = cDataType.fLong.IfNull(dr.Item("SI_SITE_CODE"))
                SIPrintedBy = cDataType.fLong.IfNull(dr.Item("SI_PRINTED_BY"))

                If dtSalesInvoice.Columns.Contains("IS_NEWGEN_API") Then
                    IsFromNewgenAPI =
                        String.Equals(
                            cDataType.fString.IfNull(dr.Item("IS_NEWGEN_API")),
                            "Y",
                            StringComparison.OrdinalIgnoreCase
                        )
                End If

                'Oracle must identify whether the invoice is GROUP or HMO.
                If Not dtSalesInvoice.Columns.Contains("SI_SOURCE_TYPE") Then
                    Throw New ArgumentException(
                        "The Oracle sales invoice result is missing SI_SOURCE_TYPE."
                    )
                End If

                SISourceType =
                    cDataType.fString.IfNull(
                        dr.Item("SI_SOURCE_TYPE")
                    ).Trim().ToUpperInvariant()

                If SISourceType <> "GROUP" AndAlso SISourceType <> "HMO" Then
                    Throw New ArgumentException(
                        "The Oracle sales invoice result has an invalid SI_SOURCE_TYPE: " &
                        SISourceType
                    )
                End If

                'Retrieve all invoice particulars from Oracle.
                dtSIDetails = objDal.SearchSIDetails(ReferenceNo)

                If dtSIDetails Is Nothing Then
                    dtSIDetails = New DataTable()
                End If

                IsRecordExist = True
                Exit For
            Next

        End Sub

        Public Sub SearchSalesInvoiceDMCM(
     ByVal pInvoiceNumber As String,
     ByVal pRoleCode As String,
     ByVal pSiteCode As Long,
     ByVal pUserID As Long
 ) Implements ISalesInvoice.SearchSalesInvoiceDMCM

            Dim objDal As New dalReference.DSalesInvoice
            Dim dtSalesInvoice As DataTable = Nothing
            Dim dtDetails As DataTable = Nothing
            Dim isHMO As Boolean = False

            Try
                IsRecordExist = False
                SISourceType = String.Empty

                '1. Search HMO from SQL Server first
                dtSalesInvoice = objDal.SearchHMOSalesInvoice(
                    String.Empty,
                    String.Empty,
                    pInvoiceNumber
                )

                If dtSalesInvoice IsNot Nothing AndAlso
                   dtSalesInvoice.Rows.Count > 0 Then

                    isHMO = True

                Else
                    '2. If not found in HMO, search Group from Oracle
                    dtSalesInvoice = objDal.SearchSalesInvoiceDMCM(
                        pInvoiceNumber,
                        pRoleCode,
                        pSiteCode,
                        pUserID
                    )
                End If

                If dtSalesInvoice Is Nothing OrElse
                   dtSalesInvoice.Rows.Count = 0 Then
                    Return
                End If

                Dim dr As DataRow = dtSalesInvoice.Rows(0)

                SalesInvoiceID =
                    cDataType.fLong.IfNull(dr.Item("ID"))

                ReferenceNo =
                    cDataType.fString.IfNull(dr.Item("REFERENCE_NO"))

                If dtSalesInvoice.Columns.Contains("BILLING_STATEMENT_NO") Then
                    BillStatNo =
                        cDataType.fString.IfNull(
                            dr.Item("BILLING_STATEMENT_NO")
                        )
                Else
                    'HMO SQL returns BILL_NO as REFERENCE_NO
                    BillStatNo = ReferenceNo
                End If

                PayorName =
                    cDataType.fString.IfNull(dr.Item("PAYOR"))

                PayorAddress =
                    cDataType.fString.IfNull(dr.Item("ADDRESS"))

                PayorTIN =
                    cDataType.fString.IfNull(dr.Item("TIN"))

                PolicyNumber =
                    cDataType.fString.IfNull(dr.Item("POLICY_NUMBER"))

                CoveragePeriodFrom =
                    cDataType.fDate.IfNull(dr.Item("COVERAGE_PERIOD_FROM"))

                CoveragePeriodTo =
                    cDataType.fDate.IfNull(dr.Item("COVERAGE_PERIOD_TO"))

                InvoiceAmount =
                    cDataType.fDecimal.IfNull(dr.Item("TOTAL_AMOUNT"))

                PaymentTerm =
                    cDataType.fString.IfNull(dr.Item("PAYMENT_TERM"))

                InvoiceRemarks =
                    cDataType.fString.IfNull(dr.Item("REMARKS"))

                InvoiceNumber =
                    cDataType.fLong.IfNull(dr.Item("SALES_INVOICE_NO"))

                InvoiceDate =
                    cDataType.fDate.IfNull(
                        dr.Item("SALES_INVOICE_DATE")
                    ).Date

                SIPrintStatus =
                    cDataType.fString.IfNull(dr.Item("SI_PRINT_STATUS"))

                UploadDate =
                    cDataType.fDate.IfNull(dr.Item("POSTED_DATE"))

                '3. Source-specific values
                If isHMO Then
                    SISourceType = "HMO"

                    'Retrieve HMO particulars from SQL Server
                    dtDetails =
                        objDal.SearchHMOSIDetails(ReferenceNo)

                    If dtDetails IsNot Nothing AndAlso
                       dtDetails.Rows.Count > 0 Then

                        Dim drDetail As DataRow = dtDetails.Rows(0)

                        Particulars =
                            cDataType.fString.IfNull(
                                drDetail.Item("PARTICULARS")
                            )

                        Quantity =
                            cDataType.fDecimal.IfNull(
                                drDetail.Item("QUANTITY")
                            )

                        UnitPrice =
                            cDataType.fDecimal.IfNull(
                                drDetail.Item("UNIT_PRICE")
                            )
                    End If

                Else
                    SISourceType =
                        cDataType.fString.IfNull(
                            dr.Item("SI_SOURCE_TYPE")
                        )

                    If SISourceType = String.Empty Then
                        SISourceType = "GROUP"
                    End If

                    Particulars =
                        cDataType.fString.IfNull(
                            dr.Item("PARTICULARS")
                        )

                    Quantity =
                        cDataType.fDecimal.IfNull(
                            dr.Item("QUANTITY")
                        )

                    UnitPrice =
                        cDataType.fDecimal.IfNull(
                            dr.Item("UNIT_PRICE")
                        )
                End If



                '4. Map optional DMCM columns
                If dtSalesInvoice.Columns.Contains(
                    "BILL_STATEMENT_DATE"
                ) Then
                    BillStatDate =
                        cDataType.fDate.IfNull(
                            dr.Item("BILL_STATEMENT_DATE")
                        )
                End If

                If dtSalesInvoice.Columns.Contains("TEL_NOS") Then
                    SiteContact =
                        cDataType.fString.IfNull(dr.Item("TEL_NOS"))
                End If

                If dtSalesInvoice.Columns.Contains("TIN_NO") Then
                    SiteTin =
                        cDataType.fString.IfNull(dr.Item("TIN_NO"))
                End If

                If dtSalesInvoice.Columns.Contains("SITE_ADDR") Then
                    SiteAddr =
                        cDataType.fString.IfNull(dr.Item("SITE_ADDR"))
                End If

                If dtSalesInvoice.Columns.Contains("SITE_NAME") Then
                    SiteName =
                        cDataType.fString.IfNull(dr.Item("SITE_NAME"))
                End If

                If dtSalesInvoice.Columns.Contains("PREPARED_BY") Then
                    PreparedBy =
                        cDataType.fString.IfNull(dr.Item("PREPARED_BY"))
                End If

                IsRecordExist = True

            Catch ex As Exception
                IsRecordExist = False
                Throw
            End Try
        End Sub

#End Region

#Region "Transactions"
        Public Function Alter(ByVal pPrintStatus As String, ByVal pReferenceNo As String, ByVal pDocumentNo As Long, ByVal pDocumentDate As Date, ByVal pRemarks As String, ByVal pOtherInfo As String, ByVal pUserID As String, ByVal pSiteCode As Long, ByRef pConn As Object, ByRef pTrans As Object) As String

            Try
                Dim objDAL As New dalReference.DSalesInvoice
                objDAL.Alter(pPrintStatus, pReferenceNo, pDocumentNo, pDocumentDate, pRemarks, pOtherInfo, pUserID, pSiteCode, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function
#End Region

    End Class

End Namespace


