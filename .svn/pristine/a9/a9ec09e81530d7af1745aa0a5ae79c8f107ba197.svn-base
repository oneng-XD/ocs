#Region "Description"
' PAGE NAME     : Payment Type Class
' CREATED BY    : EJ
' CREATED DATE  : 09/22/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
#End Region

Namespace Classes

    Public Class cPaymentType

#Region "Implements"

#End Region

#Region "Variables"
        Private mPaymentTypeID As String = cDataType.fString.Empty
        Private mPaymentType As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mCheckNumber As Long = cDataType.fLong.Empty
        Private mBank As String = cDataType.fString.Empty
        Private mBranch As String = cDataType.fString.Empty
        Private mTerminalUse As String = cDataType.fString.Empty
        Private mMerchantID As String = cDataType.fString.Empty
        Private mSwipeDate As Date = cDataType.fDate.Empty
        Private mCardType As String = cDataType.fString.Empty
        Private mCardNumber As String = cDataType.fString.Empty
        Private mApprovalCode As String = cDataType.fString.Empty
        Private mNetwork As String = cDataType.fString.Empty
        Private mCASA As String = cDataType.fString.Empty
        Private mAccountNumber As String = cDataType.fString.Empty
        Private mBatchNumber As Long = cDataType.fLong.Empty
        Private mPaymentChannel As String = cDataType.fString.Empty
        Private mReferenceID As String = cDataType.fString.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mServiceFeeRate As Decimal = cDataType.fDecimal.Empty
#End Region

#Region "Properties"

        Public Property PaymentTypeID As String
            Get
                Return mPaymentTypeID
            End Get
            Set(value As String)
                mPaymentTypeID = value
            End Set
        End Property

        Property PaymentType As String
            Get
                Return mPaymentType
            End Get
            Set(value As String)
                mPaymentType = value
            End Set
        End Property

        Property Amount As Decimal
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Property CheckNumber As Long
            Get
                Return mCheckNumber
            End Get
            Set(value As Long)
                mCheckNumber = value
            End Set
        End Property

        Property Bank As String
            Get
                Return mBank
            End Get
            Set(value As String)
                mBank = value
            End Set
        End Property

        Property Branch As String
            Get
                Return mBranch
            End Get
            Set(value As String)
                mBranch = value
            End Set
        End Property

        Property TerminalUse() As String
            Get
                Return mTerminalUse
            End Get
            Set(ByVal value As String)
                mTerminalUse = value
            End Set
        End Property

        Property MerchantID As String
            Get
                Return mMerchantID
            End Get
            Set(value As String)
                mMerchantID = value
            End Set
        End Property

        Property SwipeDate As Date
            Get
                Return mSwipeDate
            End Get
            Set(value As Date)
                mSwipeDate = value
            End Set
        End Property

        Property CardType As String
            Get
                Return mCardType
            End Get
            Set(value As String)
                mCardType = value
            End Set
        End Property

        Property CardNumber As String
            Get
                Return mCardNumber
            End Get
            Set(value As String)
                mCardNumber = value
            End Set
        End Property

        Property ApprovalCode As String
            Get
                Return mApprovalCode
            End Get
            Set(value As String)
                mApprovalCode = value
            End Set
        End Property

        Property Network As String
            Get
                Return mNetwork
            End Get
            Set(value As String)
                mNetwork = value
            End Set
        End Property

        Property CASA As String
            Get
                Return mCASA
            End Get
            Set(value As String)
                mCASA = value
            End Set
        End Property

        Property AccountNumber As String
            Get
                Return mAccountNumber
            End Get
            Set(value As String)
                mAccountNumber = value
            End Set
        End Property

        Property BatchNumber As Long
            Get
                Return mBatchNumber
            End Get
            Set(value As Long)
                mBatchNumber = value
            End Set
        End Property

        Public Property PaymentChannel() As String
            Get
                Return mPaymentChannel
            End Get
            Set(ByVal value As String)
                mPaymentChannel = value
            End Set
        End Property


        Property ReferenceID As String
            Get
                Return mReferenceID
            End Get
            Set(value As String)
                mReferenceID = value
            End Set
        End Property

        Property Remarks As String
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Property ServiceFeeRate As Decimal
            Get
                Return mServiceFeeRate
            End Get
            Set(value As Decimal)
                mServiceFeeRate = value
            End Set
        End Property

        ReadOnly Property ReferenceNumber() As String
            Get
                Select Case PaymentType
                    Case eReference.PayTypeCSH
                        Return cDataType.fString.Empty
                    Case eReference.PayTypeCHQ
                        Return CheckNumber
                    Case eReference.PayTypeCCA
                        Return CardNumber
                    Case eReference.PayTypeDCA
                        Return AccountNumber
                    Case eReference.PayTypeECP
                        Return String.Concat(PaymentChannel, " - ", ReferenceID)
                    Case Else
                        Return cDataType.fString.Empty
                End Select
            End Get
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(pDataRow As DataRow, pPayTyp As String, Optional pPage As Integer = 0)
            mPaymentTypeID = Guid.NewGuid.ToString.ToUpper
            mPaymentType = pPayTyp
            Select Case pPage
                Case 0 'Premium Payment/Non-Premium
                    Select Case pPayTyp
                        Case eReference.PayTypeCHQ
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mCheckNumber = cDataType.fLong.IfNull(pDataRow.Item("chk_nmbr"))
                            mBank = cDataType.fString.IfNull(pDataRow.Item("bank"))
                            mBranch = cDataType.fString.IfNull(pDataRow.Item("branch"))
                            'chk_nmbr, bank, branch, amount
                        Case eReference.PayTypeCCA
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mTerminalUse = cDataType.fString.IfNull(pDataRow.Item("terminal_id"))
                            mMerchantID = cDataType.fString.IfNull(pDataRow.Item("merchant_id"))
                            mSwipeDate = cDataType.fDate.IfNull(pDataRow.Item("swipe_date"))
                            mCardType = cDataType.fString.IfNull(pDataRow.Item("card_type"))
                            mCardNumber = cDataType.fString.IfNull(pDataRow.Item("card_no"))
                            mApprovalCode = cDataType.fString.IfNull(pDataRow.Item("apprv_code"))
                            mBatchNumber = cDataType.fLong.IfNull(pDataRow.Item("batch_number"))
                            mRemarks = cDataType.fString.IfNull(pDataRow.Item("remarks"))
                            'card_no, card_type, apprv_code, remarks,Amount, terminal_id, merchant_id, swipe_date
                        Case eReference.PayTypeDCA
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mTerminalUse = cDataType.fString.IfNull(pDataRow.Item("terminal_id"))
                            mMerchantID = cDataType.fString.IfNull(pDataRow.Item("merchant_id"))
                            mSwipeDate = cDataType.fDate.IfNull(pDataRow.Item("swipe_date"))
                            mNetwork = cDataType.fString.IfNull(pDataRow.Item("bank_network"))
                            mBank = cDataType.fString.IfNull(pDataRow.Item("bank_name"))
                            mCASA = cDataType.fString.IfNull(pDataRow.Item("casa_type"))
                            mAccountNumber = cDataType.fString.IfNull(pDataRow.Item("acct_no"))
                            mApprovalCode = cDataType.fString.IfNull(pDataRow.Item("charge_slip_code"))
                            mBatchNumber = cDataType.fLong.IfNull(pDataRow.Item("batch_number"))
                            mRemarks = cDataType.fString.IfNull(pDataRow.Item("remarks"))
                            'bank_network, bank_name, casa_type, acct_no, remarks, amount, terminal_id, merchant_id, swipe_date, charge_slip_code
                        Case eReference.PayTypeECP
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mPaymentChannel = cDataType.fString.IfNull(pDataRow.Item("payment_channel"))
                            mReferenceID = cDataType.fString.IfNull(pDataRow.Item("reference_number"))
                            mRemarks = cDataType.fString.IfNull(pDataRow.Item("remarks"))
                            mServiceFeeRate = cDataType.fDecimal.IfNull(pDataRow.Item("service_fee_rate"))
                    End Select
                Case 1 'Acknowledgement Receipt
                    Select Case pPayTyp
                        Case eReference.PayTypeCSH
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                        Case eReference.PayTypeCHQ
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mCheckNumber = cDataType.fLong.IfNull(pDataRow.Item("reference_no"))
                            mBank = cDataType.fString.IfNull(pDataRow.Item("bank"))
                            mBranch = cDataType.fString.IfNull(pDataRow.Item("bank_branch"))
                            'chk_nmbr, bank, branch, amount
                        Case eReference.PayTypeCCA
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mTerminalUse = cDataType.fString.IfNull(pDataRow.Item("terminal_use"))
                            mMerchantID = cDataType.fString.IfNull(pDataRow.Item("merchant_id"))
                            mSwipeDate = cDataType.fDate.IfNull(pDataRow.Item("payment_date"))
                            mCardType = cDataType.fString.IfNull(pDataRow.Item("account_type"))
                            mCardNumber = cDataType.fString.IfNull(pDataRow.Item("account_no"))
                            mApprovalCode = cDataType.fString.IfNull(pDataRow.Item("reference_no"))
                            mBatchNumber = cDataType.fLong.IfNull(pDataRow.Item("batch_number"))
                            mRemarks = cDataType.fString.IfNull(pDataRow.Item("remarks"))
                            'card_no, card_type, apprv_code, remarks,Amount, terminal_id, merchant_id, swipe_date
                        Case eReference.PayTypeDCA
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mTerminalUse = cDataType.fString.IfNull(pDataRow.Item("terminal_use"))
                            mMerchantID = cDataType.fString.IfNull(pDataRow.Item("merchant_id"))
                            mSwipeDate = cDataType.fDate.IfNull(pDataRow.Item("payment_date"))
                            mNetwork = cDataType.fString.IfNull(pDataRow.Item("bank_network"))
                            mBank = cDataType.fString.IfNull(pDataRow.Item("bank_name"))
                            mCASA = cDataType.fString.IfNull(pDataRow.Item("account_type"))
                            mAccountNumber = cDataType.fString.IfNull(pDataRow.Item("account_no"))
                            mApprovalCode = cDataType.fString.IfNull(pDataRow.Item("reference_no"))
                            mBatchNumber = cDataType.fLong.IfNull(pDataRow.Item("batch_number"))
                            mRemarks = cDataType.fString.IfNull(pDataRow.Item("remarks"))
                            'bank_network, bank_name, casa_type, acct_no, remarks, amount, terminal_id, merchant_id, swipe_date, charge_slip_code
                        Case Else 'eReference.PayTypeECP
                            mAmount = cDataType.fDecimal.IfNull(pDataRow.Item("amount"))
                            mPaymentChannel = cDataType.fString.IfNull(pDataRow.Item("payment_type"))
                            mReferenceID = cDataType.fString.IfNull(pDataRow.Item("reference_no"))
                            mRemarks = cDataType.fString.IfNull(pDataRow.Item("remarks"))
                            mServiceFeeRate = cDataType.fDecimal.IfNull(pDataRow.Item("service_fee_rate"))
                    End Select
            End Select
          
        End Sub

        Sub New(ByVal pAmount As Decimal)
            mPaymentType = eReference.PayTypeCSH
            mAmount = pAmount
            mPaymentTypeID = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(ByVal pAmount As Decimal, ByVal pCheckNumber As Long, ByVal pBankName As String, ByVal pBankBranch As String)
            mPaymentType = eReference.PayTypeCHQ
            mAmount = pAmount
            mCheckNumber = pCheckNumber
            mBank = pBankName
            mBranch = pBankBranch
            mPaymentTypeID = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(ByVal pAmount As Decimal, ByVal pTerminalUse As String, ByVal pMerchantID As String, ByVal pSwipeDate As Date, ByVal pCardType As String, ByVal pCardNumber As String, ByVal pBatchNumber As Long, ByVal pApprovalCode As String, ByVal pRemarks As String)
            mPaymentType = eReference.PayTypeCCA
            mAmount = pAmount
            mTerminalUse = pTerminalUse
            mMerchantID = pMerchantID
            mSwipeDate = pSwipeDate
            mCardType = pCardType
            mCardNumber = pCardNumber
            mBatchNumber = pBatchNumber
            mApprovalCode = pApprovalCode
            mRemarks = pRemarks
            mPaymentTypeID = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(ByVal pAmount As Decimal, ByVal pTerminalUse As String, ByVal pMerchantID As String, ByVal pSwipeDate As Date, ByVal pNetwork As String, ByVal pBank As String, ByVal pCASA As String, ByVal pAccountNumber As String, ByVal pBatchNumber As Long, ByVal pApprovalCode As String, ByVal pRemarks As String)
            mPaymentType = eReference.PayTypeDCA
            mAmount = pAmount
            mTerminalUse = pTerminalUse
            mMerchantID = pMerchantID
            mSwipeDate = pSwipeDate
            mNetwork = pNetwork
            mBank = pBank
            mCASA = pCASA
            mAccountNumber = pAccountNumber
            mBatchNumber = pBatchNumber
            mApprovalCode = pApprovalCode
            mRemarks = pRemarks
            mPaymentTypeID = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(ByVal pAmount As Decimal, ByVal pPaymentChannel As String, ByVal pReferenceID As String, ByVal pRemarks As String, ByVal pServiceFeeRate As Decimal)
            mPaymentType = eReference.PayTypeECP
            mAmount = pAmount
            mPaymentChannel = pPaymentChannel
            mReferenceID = pReferenceID
            mRemarks = pRemarks
            mServiceFeeRate = pServiceFeeRate
            mPaymentTypeID = Guid.NewGuid.ToString.ToUpper
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace

