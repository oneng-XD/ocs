#Region "Description"
' PAGE NAME     : SITE_OPRDEBIT BLL
' CREATED BY    : EJ
' CREATED DATE  : 05/04/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports eAction = Cocolife.Utility.Common.Enums.eDBAction
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalWorking = Cocolife.DAL.OCS.Working
#End Region

Namespace Working

    Public Class BSiteOPRDebit
        
#Region "Implements"
        Implements ISiteOPRDebit
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mBankNetwork As String = cDataType.fString.Empty
        Private mBankName As String = cDataType.fString.Empty
        Private mCASAType As String = cDataType.fString.Empty
        Private mAcctNo As String = cDataType.fString.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mTerminalID As String = cDataType.fString.Empty
        Private mMerchantID As String = cDataType.fString.Empty
        Private mSwipeDate As Date = cDataType.fDate.Empty
        Private mChargeSlipCode As String = cDataType.fString.Empty
        Private mBatchNumber As Long = cDataType.fLong.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteOPRDebit.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteOPRDebit.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteOPRDebit.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteOPRDebit.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteOPRDebit.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteOPRDebit.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property OPRNmbr() As Long Implements ISiteOPRDebit.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property BankNetwork() As String Implements ISiteOPRDebit.BankNetwork
            Get
                Return mBankNetwork
            End Get
            Set(value As String)
                mBankNetwork = value
            End Set
        End Property

        Public Property BankName() As String Implements ISiteOPRDebit.BankName
            Get
                Return mBankName
            End Get
            Set(value As String)
                mBankName = value
            End Set
        End Property

        Public Property CASAType() As String Implements ISiteOPRDebit.CASAType
            Get
                Return mCASAType
            End Get
            Set(value As String)
                mCASAType = value
            End Set
        End Property

        Public Property AcctNo() As String Implements ISiteOPRDebit.AcctNo
            Get
                Return mAcctNo
            End Get
            Set(value As String)
                mAcctNo = value
            End Set
        End Property

        Public Property Remarks() As String Implements ISiteOPRDebit.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements ISiteOPRDebit.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property TerminalID() As String Implements ISiteOPRDebit.TerminalID
            Get
                Return mTerminalID
            End Get
            Set(value As String)
                mTerminalID = value
            End Set
        End Property

        Public Property MerchantID() As String Implements ISiteOPRDebit.MerchantID
            Get
                Return mMerchantID
            End Get
            Set(value As String)
                mMerchantID = value
            End Set
        End Property

        Public Property SwipeDate() As Date Implements ISiteOPRDebit.SwipeDate
            Get
                Return mSwipeDate
            End Get
            Set(value As Date)
                mSwipeDate = value
            End Set
        End Property

        Public Property ChargeSlipCode() As String Implements ISiteOPRDebit.ChargeSlipCode
            Get
                Return mChargeSlipCode
            End Get
            Set(value As String)
                mChargeSlipCode = value
            End Set
        End Property

        Public Property BatchNumber() As Long Implements ISiteOPRDebit.BatchNumber
            Get
                Return mBatchNumber
            End Get
            Set(value As Long)
                mBatchNumber = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pOPRNmbr As Long, ByVal pBankNetwork As String, ByVal pBankName As String,
                ByVal pCASAType As String, ByVal pAcctNo As String, ByVal pRemarks As String,
                ByVal pAmount As Decimal, ByVal pTerminalID As String, ByVal pMerchantID As String,
                ByVal pSwipeDate As Date, ByVal pChargeSlipCode As String, ByVal pBatchNumber As Long, ByVal pStatusId As Integer, ByVal pPostBy As Long,
                ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            OPRNmbr = pOPRNmbr
            BankNetwork = pBankNetwork
            BankName = pBankName
            CASAType = pCASAType
            AcctNo = pAcctNo
            Remarks = pRemarks
            Amount = pAmount
            TerminalID = pTerminalID
            MerchantID = pMerchantID
            SwipeDate = pSwipeDate
            ChargeSlipCode = pChargeSlipCode
            BatchNumber = pBatchNumber
            StatusId = pStatusId
            PostBy = pPostBy
            PostDate = pPostDate
            LastUpdateBy = pLastUpdateBy
            LastUpdate = pLastUpdate
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetOPRDebitDt(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteOPRDebit
                Dim dtLocal As DataTable

                dtLocal = objDal.GetSiteOPRDebit(pDocNumber, pUserId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GetOPRDebitByChargeSlipDt(ByVal pChargeSlipCode As String, ByVal pPayorId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteOPRDebit
                Dim dtLocal As DataTable

                dtLocal = objDal.GetOPRDebitByChargeSlip(pChargeSlipCode, pPayorId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteOPRDebit
                objDAL.AlterSiteOPRDebit(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
