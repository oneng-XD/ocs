#Region "Description"
' PAGE NAME     : NGI BILLING DETAILS BLL
' CREATED BY    : EJ
' CREATED DATE  : 04/16/2021
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BNGIBillingDetails

#Region "Implements"
        Implements INGIBillingDetails
#End Region

#Region "Variables"
        Private mAccountName As String = cDataType.fString.Empty
        Private mSourceName As String = cDataType.fString.Empty
        Private mPolicyNo As String = cDataType.fString.Empty
        Private mBillNo As String = cDataType.fString.Empty
        Private mSubsNo As String = cDataType.fString.Empty
        Private mBillDate As String = cDataType.fString.Empty
        Private mCovFrm As String = cDataType.fString.Empty
        Private mCovTo As String = cDataType.fString.Empty
        Private mFrequencyOfPayment As String = cDataType.fString.Empty
        Private mPlanCurrency As String = cDataType.fString.Empty
        Private mPolicyStatus As String = cDataType.fString.Empty
        Private mPayorID As String = cDataType.fString.Empty
        Private mPayorName As String = cDataType.fString.Empty
        Private mAddress As String = cDataType.fString.Empty
        Private mTin As String = cDataType.fString.Empty
        Private mBillAmount As String = cDataType.fString.Empty
        Private mParticularsRaw As String = cDataType.fString.Empty
        ' -------------------------------------------------------------------------------
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"

public property AccountName As String implements INGIBillingDetails.AccountName
            Get
                Return mAccountName
            End Get
            Set(value As String)
                mAccountName = value
            End Set
        End Property

        Public Property SourceName As String Implements INGIBillingDetails.SourceName
            Get
                Return mSourceName
            End Get
            Set(value As String)
                mSourceName = value
            End Set
        End Property

        Public Property PolicyNo As String Implements INGIBillingDetails.PolicyNo
            Get
                Return mPolicyNo
            End Get
            Set(value As String)
                mPolicyNo = value
            End Set
        End Property

        Public Property BillNo As String Implements INGIBillingDetails.BillNo
            Get
                Return mBillNo
            End Get
            Set(value As String)
                mBillNo = value
            End Set
        End Property
        Public Property SubsNo As String Implements INGIBillingDetails.SubsNo
            Get
                Return mSubsNo
            End Get
            Set(value As String)
                mSubsNo = value
            End Set
        End Property

        Public Property CovFrm As String Implements INGIBillingDetails.CovFrm
            Get
                Return mCovFrm
            End Get
            Set(value As String)
                mCovFrm = value
            End Set
        End Property
        Public Property CovTo As String Implements INGIBillingDetails.CovTo
            Get
                Return mCovTo
            End Get
            Set(value As String)
                mCovTo = value
            End Set
        End Property
        Public Property BillDate As String Implements INGIBillingDetails.BillDate
            Get
                Return mBillDate
            End Get
            Set(value As String)
                mBillDate = value
            End Set
        End Property

        Public Property FrequencyOfPayment As String Implements INGIBillingDetails.FrequencyOfPayment
            Get
                Return mFrequencyOfPayment
            End Get
            Set(value As String)
                mFrequencyOfPayment = value
            End Set
        End Property

        Public Property PlanCurrency As String Implements INGIBillingDetails.PlanCurrency
            Get
                Return mPlanCurrency
            End Get
            Set(value As String)
                mPlanCurrency = value
            End Set
        End Property

        Public Property PolicyStatus As String Implements INGIBillingDetails.PolicyStatus
            Get
                Return mPolicyStatus
            End Get
            Set(value As String)
                mPolicyStatus = value
            End Set
        End Property

        Public Property PayorID As String Implements INGIBillingDetails.PayorID
            Get
                Return mPayorID
            End Get
            Set(value As String)
                mPayorID = value
            End Set
        End Property

        Public Property PayorName As String Implements INGIBillingDetails.PayorName
            Get
                Return mPayorName
            End Get
            Set(value As String)
                mPayorName = value
            End Set
        End Property
        Public Property Address As String Implements INGIBillingDetails.Address
            Get
                Return mAddress
            End Get
            Set(value As String)
                mAddress = value
            End Set
        End Property
        Public Property Tin As String Implements INGIBillingDetails.Tin
            Get
                Return mTin
            End Get
            Set(value As String)
                mTin = value
            End Set
        End Property

        Public Property BillAmount As String Implements INGIBillingDetails.BillAmount
            Get
                Return mBillAmount
            End Get
            Set(value As String)
                mBillAmount = value
            End Set
        End Property
        Public Property ParticularsRaw As String Implements INGIBillingDetails.ParticularsRaw
            Get
                Return mParticularsRaw
            End Get
            Set(value As String)
                mParticularsRaw = value
            End Set
        End Property

        ' -------------------------------------------------------------------------------

        Public Property IsRecordExist() As Boolean Implements INGIBillingDetails.IsRecordExist
            Get
                Return mIsRecordExist
            End Get
            Set(ByVal value As Boolean)
                mIsRecordExist = value
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

        Property CardSite As String

        Public Sub GetPolicyBilling(ByVal pPolicyNo As String, ByVal pBillNo As String, ByVal pSubsNo As String) Implements INGIBillingDetails.GetPolicyBilling
            Dim objDal As New dalReference.DNGIBillingDetails
            Dim dtLocal As DataTable

            Try
                ParticularsRaw = ""
                IsRecordExist = False

                dtLocal = objDal.GetPolicyBilling(pPolicyNo, pBillNo, pSubsNo)

                For Each dr As DataRow In dtLocal.Rows
                    AccountName = cDataType.fString.IfNull(dr.Item("account_name"))
                    SourceName = cDataType.fString.IfNull(dr.Item("source_name"))
                    PolicyNo = cDataType.fString.IfNull(dr.Item("policy_no"))
                    BillNo = cDataType.fString.IfNull(dr.Item("bill_No"))
                    BillDate = cDataType.fString.IfNull(dr.Item("bill_date"))
                    FrequencyOfPayment = cDataType.fString.IfNull(dr.Item("frequency_of_payment"))
                    PlanCurrency = cDataType.fString.IfNull(dr.Item("plan_currency"))
                    PolicyStatus = cDataType.fString.IfNull(dr.Item("policy_status"))
                    PayorID = cDataType.fString.IfNull(dr.Item("payor_id"))
                    PayorName = cDataType.fString.IfNull(dr.Item("payor_name"))
                    BillAmount = cDataType.fString.IfNull(dr.Item("bill_amount"))
                    Address = cDataType.fString.IfNull(dr.Item("address"))
                    Tin = cDataType.fString.IfNull(dr.Item("tin"))
                    CovFrm = cDataType.fString.IfNull(dr.Item("coverage_period_from"))
                    CovTo = cDataType.fString.IfNull(dr.Item("coverage_period_to"))
                    If dtLocal.Columns.Contains("particulars_raw") Then
                        ParticularsRaw = cDataType.fString.IfNull(dr.Item("particulars_raw"))
                    End If

                    IsRecordExist = True
                    Exit For
                Next

            Catch ex As Exception
                Throw
            End Try
        End Sub
       

#End Region

#Region "Transactions"
        Public Function Alter(ByVal pPayslipCode As String, ByVal pReceiptNo As String, ByVal pReceiptDate As String, ByRef pConn As Object, ByRef pTrans As Object) As String

            Try
                Dim objDAL As New dalReference.DHMOPayslip
                objDAL.Alter(pPayslipCode, pReceiptNo, pReceiptDate, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function
#End Region

    End Class

End Namespace


