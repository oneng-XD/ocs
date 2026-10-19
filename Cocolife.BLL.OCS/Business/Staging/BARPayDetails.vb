#Region "Description"
' PAGE NAME     : AR PAY DETAILS BLL
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
Imports dalStaging = Cocolife.DAL.OCS.Staging
Imports System.Configuration
#End Region

Namespace Staging

    Public Class BARPayDetails

#Region "Implements"
        Implements IARPayDetails
#End Region

#Region "Variables"
        Private mARPayDetailsID As Long = cDataType.fLong.Empty
        Private mARNo As Long = cDataType.fLong.Empty
        Private mPaymentType As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mReferenceNo As String = cDataType.fString.Empty
        Private mBatchNumber As Long = cDataType.fLong.Empty
        Private mBank As String = cDataType.fString.Empty
        Private mBankBranch As String = cDataType.fString.Empty
        Private mBankNetwork As String = cDataType.fString.Empty
        Private mTerminalUse As String = cDataType.fString.Empty
        Private mMerchantID As String = cDataType.fString.Empty
        Private mPaymentDate As Date = cDataType.fDate.Empty
        Private mAccountType As String = cDataType.fString.Empty
        Private mAccountNo As String = cDataType.fString.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mServiceFeeRate As Decimal = cDataType.fDecimal.Empty
        Private mServiceFeeAmt As Decimal = cDataType.fDecimal.Empty
        Private mStatus As String = cDataType.fString.Empty
        Private mPostedBy As String = cDataType.fString.Empty
        Private mLastUpdateBy As String = cDataType.fString.Empty
        ' -------------------------------------------------------------------------------
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"

        Public Property ARPayDetailsID As Long Implements IARPayDetails.ARPayDetailsID
            Get
                Return mARPayDetailsID
            End Get
            Set(value As Long)
                mARPayDetailsID = value
            End Set
        End Property

        Public Property ARNo As Long Implements IARPayDetails.ARNo
            Get
                Return mARNo
            End Get
            Set(value As Long)
                mARNo = value
            End Set
        End Property

        Public Property PaymentType As String Implements IARPayDetails.PaymentType
            Get
                Return mPaymentType
            End Get
            Set(value As String)
                mPaymentType = value
            End Set
        End Property

        Public Property Amount As Decimal Implements IARPayDetails.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IARPayDetails.ReferenceNo
            Get
                Return mReferenceNo
            End Get
            Set(value As String)
                mReferenceNo = value
            End Set
        End Property

        Public Property BatchNumber As Long Implements IARPayDetails.BatchNumber
            Get
                Return mBatchNumber
            End Get
            Set(value As Long)
                mBatchNumber = value
            End Set
        End Property

        Public Property Bank As String Implements IARPayDetails.Bank
            Get
                Return mBank
            End Get
            Set(value As String)
                mBank = value
            End Set
        End Property

        Public Property BankBranch As String Implements IARPayDetails.BankBranch
            Get
                Return mBankBranch
            End Get
            Set(value As String)
                mBankBranch = value
            End Set
        End Property

        Public Property BankNetwork As String Implements IARPayDetails.BankNetwork
            Get
                Return mBankNetwork
            End Get
            Set(value As String)
                mBankNetwork = value
            End Set
        End Property

        Public Property TerminalUse As String Implements IARPayDetails.TerminalUse
            Get
                Return mTerminalUse
            End Get
            Set(value As String)
                mTerminalUse = value
            End Set
        End Property

        Public Property MerchantID As String Implements IARPayDetails.MerchantID
            Get
                Return mMerchantID
            End Get
            Set(value As String)
                mMerchantID = value
            End Set
        End Property

        Public Property PaymentDate As Date Implements IARPayDetails.PaymentDate
            Get
                Return mPaymentDate
            End Get
            Set(value As Date)
                mPaymentDate = value
            End Set
        End Property

        Public Property AccountType As String Implements IARPayDetails.AccountType
            Get
                Return mAccountType
            End Get
            Set(value As String)
                mAccountType = value
            End Set
        End Property

        Public Property AccountNo As String Implements IARPayDetails.AccountNo
            Get
                Return mAccountNo
            End Get
            Set(value As String)
                mAccountNo = value
            End Set
        End Property

        Public Property Remarks As String Implements IARPayDetails.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property ServiceFeeRate As Decimal Implements IARPayDetails.ServiceFeeRate
            Get
                Return mServiceFeeRate
            End Get
            Set(value As Decimal)
                mServiceFeeRate = value
            End Set
        End Property

        Public Property ServiceFeeAmt As Decimal Implements IARPayDetails.ServiceFeeAmt
            Get
                Return mServiceFeeAmt
            End Get
            Set(value As Decimal)
                mServiceFeeAmt = value
            End Set
        End Property

        Public Property Status As String Implements IARPayDetails.Status
            Get
                Return mStatus
            End Get
            Set(value As String)
                mStatus = value
            End Set
        End Property

        Public Property LastUpdateBy As String Implements IARPayDetails.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As String)
                mLastUpdateBy = value
            End Set
        End Property

        ' -------------------------------------------------------------------------------

        Public Property IsRecordExist() As Boolean Implements IARPayDetails.IsRecordExist
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

        Sub New(ByVal pID As Long, ByVal pARNo As Long, ByVal pPaymentType As String, ByVal pAmount As Decimal, ByVal pReferenceNo As String,
                ByVal pBatchNumber As Long, ByVal pBank As String, ByVal pBankBranch As String, ByVal pBankNetwork As String, ByVal pTerminalUse As String,
                ByVal pMerchantID As String, ByVal pPaymentDate As Date, ByVal pAccountType As String, ByVal pAccountNo As String, ByVal pRemarks As String,
                ByVal pServiceFeeRate As Decimal, ByVal pServiceFeeAmt As Decimal, ByVal pStatus As String, ByVal pLastUpdateBy As String)
            ARPayDetailsID = pID
            ARNo = pARNo
            PaymentType = pPaymentType
            Amount = pAmount
            ReferenceNo = pReferenceNo
            BatchNumber = pBatchNumber
            Bank = pBank
            BankBranch = pBankBranch
            BankNetwork = pBankNetwork
            TerminalUse = pTerminalUse
            MerchantID = pMerchantID
            PaymentDate = pPaymentDate
            AccountType = pAccountType
            AccountNo = pAccountNo
            Remarks = pRemarks
            ServiceFeeRate = pServiceFeeRate
            ServiceFeeAmt = pServiceFeeAmt
            Status = pStatus
            LastUpdateBy = pLastUpdateBy
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval
        Public Function GetDt(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DARPayDetails
                Dim dtLocal As DataTable

                dtLocal = objDal.GetARPayDetails(pDocNumber, pUserId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try


        End Function
#End Region

#Region "Transactions"
        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long
            Try
                Dim objDAL As New dalStaging.DARPayDetails
                objDAL.AlterARPayDetails(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region

    End Class

End Namespace


