#Region "Description"
' PAGE NAME     : SITE_OPRDTL BLL
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

    Public Class BSiteBatch

#Region "Implements"
        Implements ISiteBatch
#End Region

#Region "Variables"
        Private mBatchId As Long = cDataType.fLong.Empty
        Private mUserId As Long = cDataType.fLong.Empty
        Private mSiteId As Long = cDataType.fLong.Empty
        Private mNonPrem As Long = cDataType.fLong.Empty
        Private mOprDate As Date = cDataType.fDate.Empty
        Private mCheckNo As Long = cDataType.fLong.Empty
        Private mBank As String = cDataType.fString.Empty
        Private mBranch As String = cDataType.fString.Empty
        Private mCurrency As String = cDataType.fString.Empty
        Private mPayType As String = cDataType.fString.Empty
        Private mTrnCod As String = cDataType.fString.Empty
        Private mAprDate As Date = cDataType.fDate.Empty
        Private mAprNumber As Long = cDataType.fLong.Empty
        Private mOprRemarks As String = cDataType.fString.Empty
#End Region

#Region "Properties"

     public property BatchId as long implements isitebatch.BatchId
            Get
                Return mBatchId
            End Get
            Set(value As Long)
                mBatchId = value
            End Set
        End Property

        Public Property UserId As Long Implements ISiteBatch.UserId
            Get
                Return mUserId
            End Get
            Set(value As Long)
                mUserId = value
            End Set
        End Property

        Public Property SiteId As Long Implements ISiteBatch.SiteId
            Get
                Return mSiteId
            End Get
            Set(value As Long)
                mSiteId = value
            End Set
        End Property

        Public Property NonPrem As Long Implements ISiteBatch.NonPrem
            Get
                Return mNonPrem
            End Get
            Set(value As Long)
                mNonPrem = value
            End Set
        End Property

        Public Property OprDate As Date Implements ISiteBatch.OprDate
            Get
                Return mOprDate
            End Get
            Set(value As Date)
                mOprDate = value
            End Set
        End Property

        Public Property CheckNo As Long Implements ISiteBatch.CheckNo
            Get
                Return mCheckNo
            End Get
            Set(value As Long)
                mCheckNo = value
            End Set
        End Property

        Public Property Bank As String Implements ISiteBatch.Bank
            Get
                Return mBank
            End Get
            Set(value As String)
                mBank = value
            End Set
        End Property

        Public Property Branch As String Implements ISiteBatch.Branch
            Get
                Return mBranch
            End Get
            Set(value As String)
                mBranch = value
            End Set
        End Property

        Public Property Currency As String Implements ISiteBatch.Currency
            Get
                Return mCurrency
            End Get
            Set(value As String)
                mCurrency = value
            End Set
        End Property

        Public Property PayType As String Implements ISiteBatch.PayType
            Get
                Return mPayType
            End Get
            Set(value As String)
                mPayType = value
            End Set
        End Property

        Public Property AprDate As Date Implements ISiteBatch.AprDate
            Get
                Return mAprDate
            End Get
            Set(value As Date)
                mAprDate = value
            End Set
        End Property

        Public Property AprNumber As Long Implements ISiteBatch.AprNumber
            Get
                Return mAprNumber
            End Get
            Set(value As Long)
                mAprNumber = value
            End Set
        End Property

        Public Property OprRemarks As String Implements ISiteBatch.OprRemarks
            Get
                Return mOprRemarks
            End Get
            Set(value As String)
                mOprRemarks = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pBatchId As Long, ByVal pUserId As Long, ByVal pSiteId As Long, ByVal pNonPrem As Long, ByVal pOprDate As Date,
                ByVal pCheckNo As Long, ByVal pBranch As String, ByVal pBank As String, ByVal pCurrency As String, ByVal pPayType As String,
                ByVal pAprDate As Date, ByVal pAprNumber As Long, ByVal pOprRemarks As String)
            BatchId = pBatchId
            UserId = pUserId
            SiteId = pSiteId
            NonPrem = pNonPrem
            OprDate = pOprDate
            CheckNo = pCheckNo
            Bank = pBank
            Branch = pBranch
            Currency = pCurrency
            PayType = pPayType
            AprDate = pAprDate
            AprNumber = pAprNumber
            OprRemarks = pOprRemarks
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteBatch
                objDAL.AlterSiteBatch(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
