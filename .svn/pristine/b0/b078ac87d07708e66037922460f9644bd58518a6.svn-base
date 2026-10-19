#Region "Description"
' PAGE NAME     : SITE_OPRCRED BLL
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

    Public Class BSiteOPRCred
        
#Region "Implements"
        Implements ISiteOPRCred
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mCardNo As String = cDataType.fString.Empty
        Private mCardType As String = cDataType.fString.Empty
        Private mApprvCode As String = cDataType.fString.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mTerminalID As String = cDataType.fString.Empty
        Private mMerchantID As String = cDataType.fString.Empty
        Private mSwipeDate As Date = cDataType.fDate.Empty
        Private mBatchNumber As Long = cDataType.fLong.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteOPRCred.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteOPRCred.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteOPRCred.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteOPRCred.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteOPRCred.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteOPRCred.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property OPRNmbr() As Long Implements ISiteOPRCred.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property CardNo() As String Implements ISiteOPRCred.CardNo
            Get
                Return mCardNo
            End Get
            Set(value As String)
                mCardNo = value
            End Set
        End Property

        Public Property CardType() As String Implements ISiteOPRCred.CardType
            Get
                Return mCardType
            End Get
            Set(value As String)
                mCardType = value
            End Set
        End Property

        Public Property ApprvCode() As String Implements ISiteOPRCred.ApprvCode
            Get
                Return mApprvCode
            End Get
            Set(value As String)
                mApprvCode = value
            End Set
        End Property

        Public Property Remarks() As String Implements ISiteOPRCred.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements ISiteOPRCred.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property TerminalID() As String Implements ISiteOPRCred.TerminalID
            Get
                Return mTerminalID
            End Get
            Set(value As String)
                mTerminalID = value
            End Set
        End Property

        Public Property MerchantID() As String Implements ISiteOPRCred.MerchantID
            Get
                Return mMerchantID
            End Get
            Set(value As String)
                mMerchantID = value
            End Set
        End Property

        Public Property SwipeDate() As Date Implements ISiteOPRCred.SwipeDate
            Get
                Return mSwipeDate
            End Get
            Set(value As Date)
                mSwipeDate = value
            End Set
        End Property

        Public Property BatchNumber() As Long Implements ISiteOPRCred.BatchNumber
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

        Sub New(ByVal pId As Long, ByVal pOPRNmbr As Long, ByVal pCardNo As String, ByVal pCardType As String,
                ByVal pApprvCode As String, ByVal pRemarks As String, ByVal pAmount As Decimal,
                ByVal pTerminalID As String, ByVal pMerchantID As String, ByVal pSwipeDate As Date, ByVal pBatchNumber As Long, ByVal pStatusId As Integer,
                ByVal pPostBy As Long, ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            OPRNmbr = pOPRNmbr
            CardNo = pCardNo
            CardType = pCardType
            ApprvCode = pApprvCode
            Remarks = pRemarks
            Amount = pAmount
            TerminalID = pTerminalID
            MerchantID = pMerchantID
            SwipeDate = pSwipeDate
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

        Public Function GetOPRCredDt(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteOPRCred
                Dim dtLocal As DataTable

                dtLocal = objDal.GetSiteOPRCred(pDocNumber, pUserId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GetOPRCredByApprvCodeDt(ByVal pApprovalCode As String, ByVal pPayorId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteOPRCred
                Dim dtLocal As DataTable

                dtLocal = objDal.GetSiteOPRCredByApprovalCode(pApprovalCode, pPayorId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function ValidateCreditCardNumber(ByVal pCreditCardNumber As String) As String
            Dim objDAL As New dalWorking.DSiteOPRCred

            Try
                Return objDAL.ValidateCreditCardNumber(pCreditCardNumber)
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteOPRCred
                objDAL.AlterSiteOPRCred(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

