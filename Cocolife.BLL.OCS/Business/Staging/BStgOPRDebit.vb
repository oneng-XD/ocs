#Region "Description"
' PAGE NAME     : STG_OPRDEBIT BLL
' CREATED BY    : MPRO
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
Imports dalStaging = Cocolife.DAL.OCS.Staging
#End Region

Namespace Staging

    Public Class BStgOPRDebit

#Region "Implements"
        Implements Staging.IStgOPRDebit
#End Region

#Region "Variables"
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
#End Region

#Region "Properties"

        Public Property OPRNmbr() As Long Implements Staging.IStgOPRDebit.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property BankNetwork() As String Implements Staging.IStgOPRDebit.BankNetwork
            Get
                Return mBankNetwork
            End Get
            Set(value As String)
                mBankNetwork = value
            End Set
        End Property

        Public Property BankName() As String Implements Staging.IStgOPRDebit.BankName
            Get
                Return mBankName
            End Get
            Set(value As String)
                mBankName = value
            End Set
        End Property

        Public Property CASAType() As String Implements Staging.IStgOPRDebit.CASAType
            Get
                Return mCASAType
            End Get
            Set(value As String)
                mCASAType = value
            End Set
        End Property

        Public Property AcctNo() As String Implements Staging.IStgOPRDebit.AcctNo
            Get
                Return mAcctNo
            End Get
            Set(value As String)
                mAcctNo = value
            End Set
        End Property

        Public Property Remarks() As String Implements Staging.IStgOPRDebit.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgOPRDebit.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property TerminalID() As String Implements Staging.IStgOPRDebit.TerminalID
            Get
                Return mTerminalID
            End Get
            Set(value As String)
                mTerminalID = value
            End Set
        End Property

        Public Property MerchantID() As String Implements Staging.IStgOPRDebit.MerchantID
            Get
                Return mMerchantID
            End Get
            Set(value As String)
                mMerchantID = value
            End Set
        End Property

        Public Property SwipeDate() As Date Implements Staging.IStgOPRDebit.SwipeDate
            Get
                Return mSwipeDate
            End Get
            Set(value As Date)
                mSwipeDate = value
            End Set
        End Property

        Public Property ChargeSlipCode As String Implements Staging.IStgOPRDebit.ChargeSlipCode
            Get
                Return mChargeSlipCode
            End Get
            Set(value As String)
                mChargeSlipCode = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pOPRNmbr As Long, ByVal pBankNetwork As String, ByVal pBankName As String,
                ByVal pCASAType As String, ByVal pAcctNo As String, ByVal pRemarks As String,
                ByVal pAmount As Decimal, ByVal pTerminalID As String, ByVal pMerchantID As String,
                ByVal pSwipeDate As Date, ByVal pChargeSlipCode As String)
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
        End Sub

        Sub New(ByVal pObject As Working.BSiteOPRDebit)
            With pObject
                OPRNmbr = .OPRNmbr
                BankNetwork = .BankNetwork
                BankName = .BankName
                CASAType = .CASAType
                AcctNo = .AcctNo
                Remarks = .Remarks
                Amount = .Amount
                TerminalID = .TerminalID
                MerchantID = .MerchantID
                SwipeDate = .SwipeDate
                ChargeSlipCode = .ChargeSlipCode
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetStgOPRDebitlDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgOPRDebit
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgOPRDebit(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgOPRDebit
                objDAL.AlterSTGOPRDebit(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
