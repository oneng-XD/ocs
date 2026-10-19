#Region "Description"
' PAGE NAME     : STG_OPRCRED BLL
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

    Public Class BStgOPRCred

#Region "Implements"
        Implements Staging.IStgOPRCred
#End Region

#Region "Variables"
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mCardNo As String = cDataType.fString.Empty
        Private mCardType As String = cDataType.fString.Empty
        Private mApprvCode As String = cDataType.fString.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mTerminalID As String = cDataType.fString.Empty
        Private mMerchantID As String = cDataType.fString.Empty
        Private mSwipeDate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property OPRNmbr() As Long Implements Staging.IStgOPRCred.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property CardNo() As String Implements Staging.IStgOPRCred.CardNo
            Get
                Return mCardNo
            End Get
            Set(value As String)
                mCardNo = value
            End Set
        End Property

        Public Property CardType() As String Implements Staging.IStgOPRCred.CardType
            Get
                Return mCardType
            End Get
            Set(value As String)
                mCardType = value
            End Set
        End Property

        Public Property ApprvCode() As String Implements Staging.IStgOPRCred.ApprvCode
            Get
                Return mApprvCode
            End Get
            Set(value As String)
                mApprvCode = value
            End Set
        End Property

        Public Property Remarks() As String Implements Staging.IStgOPRCred.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgOPRCred.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property TerminalID() As String Implements Staging.IStgOPRCred.TerminalID
            Get
                Return mTerminalID
            End Get
            Set(value As String)
                mTerminalID = value
            End Set
        End Property

        Public Property MerchantID() As String Implements Staging.IStgOPRCred.MerchantID
            Get
                Return mMerchantID
            End Get
            Set(value As String)
                mMerchantID = value
            End Set
        End Property

        Public Property SwipeDate() As Date Implements Staging.IStgOPRCred.SwipeDate
            Get
                Return mSwipeDate
            End Get
            Set(value As Date)
                mSwipeDate = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pOPRNmbr As Long, ByVal pCardNo As String, ByVal pCardType As String,
                ByVal pApprvCode As String, ByVal pRemarks As String, ByVal pAmount As Decimal,
                ByVal pTerminalID As String, ByVal pMerchantID As String, ByVal pSwipeDate As Date)
            OPRNmbr = pOPRNmbr
            CardNo = pCardNo
            CardType = pCardType
            ApprvCode = pApprvCode
            Remarks = pRemarks
            Amount = pAmount
            TerminalID = pTerminalID
            MerchantID = pMerchantID
            SwipeDate = pSwipeDate
        End Sub

        Sub New(ByVal pObject As Working.BSiteOPRCred)
            With pObject
                OPRNmbr = .OPRNmbr
                CardNo = .CardNo
                CardType = .CardType
                ApprvCode = .ApprvCode
                Remarks = .Remarks
                Amount = .Amount
                TerminalID = .TerminalID
                MerchantID = .MerchantID
                SwipeDate = .SwipeDate
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetStgOPRCredDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgOPRCred
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgOPRCred(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgOPRCred
                objDAL.AlterStgOPRCred(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

