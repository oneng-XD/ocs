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

    Public Class BSiteBatchDtl

#Region "Implements"
        Implements ISiteBatchDtl
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mBatchId As Long = cDataType.fLong.Empty
        Private mOprNmbr As Long = cDataType.fLong.Empty
        Private mOprAmt As Long = cDataType.fLong.Empty
        Private mPocId As Long = cDataType.fLong.Empty
        Private mInsuredName As String = cDataType.fString.Empty
        Private mPolicyName As String = cDataType.fString.Empty
        Private mGrossLife As Long = cDataType.fLong.Empty
        Private mGrossNonlife As Long = cDataType.fLong.Empty
        Private mNonlifePremium As Long = cDataType.fLong.Empty
        Private mDstNonlife As Long = cDataType.fLong.Empty
        Private mPremTaxNonlife As Long = cDataType.fLong.Empty
        Private mLocalTaxNonlife As Long = cDataType.fLong.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteBatchDtl.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property BatchId As Long Implements ISiteBatchDtl.BatchId
            Get
                Return mBatchId
            End Get
            Set(value As Long)
                mBatchId = value
            End Set
        End Property

        Public Property OprNmbr As Long Implements ISiteBatchDtl.OprNmbr
            Get
                Return mOprNmbr
            End Get
            Set(value As Long)
                mOprNmbr = value
            End Set
        End Property

        Public Property OprAmt As Long Implements ISiteBatchDtl.OprAmt
            Get
                Return mOprAmt
            End Get
            Set(value As Long)
                mOprAmt = value
            End Set
        End Property

        Public Property PocId As Long Implements ISiteBatchDtl.PocId
            Get
                Return mPocId
            End Get
            Set(value As Long)
                mPocId = value
            End Set
        End Property

        Public Property InsuredName As String Implements ISiteBatchDtl.InsuredName
            Get
                Return mInsuredName
            End Get
            Set(value As String)
                mInsuredName = value
            End Set
        End Property

        Public Property PolicyName As String Implements ISiteBatchDtl.PolicyName
            Get
                Return mPolicyName
            End Get
            Set(value As String)
                mPolicyName = value
            End Set
        End Property

        Public Property GrossLife As Long Implements ISiteBatchDtl.GrossLife
            Get
                Return mGrossLife
            End Get
            Set(value As Long)
                mGrossLife = value
            End Set
        End Property

        Public Property GrossNonlife As Long Implements ISiteBatchDtl.GrossNonlife
            Get
                Return mGrossNonlife
            End Get
            Set(value As Long)
                mGrossNonlife = value
            End Set
        End Property

        Public Property NonlifePremium As Long Implements ISiteBatchDtl.NonlifePremium
            Get
                Return mNonlifePremium
            End Get
            Set(value As Long)
                mNonlifePremium = value
            End Set
        End Property

        Public Property DstNonlife As Long Implements ISiteBatchDtl.DstNonlife
            Get
                Return mDstNonlife
            End Get
            Set(value As Long)
                mDstNonlife = value
            End Set
        End Property

        Public Property PremTaxNonlife As Long Implements ISiteBatchDtl.PremTaxNonlife
            Get
                Return mPremTaxNonlife
            End Get
            Set(value As Long)
                mPremTaxNonlife = value
            End Set
        End Property

        Public Property LocalTaxNonlife As Long Implements ISiteBatchDtl.LocalTaxNonlife
            Get
                Return mLocalTaxNonlife
            End Get
            Set(value As Long)
                mLocalTaxNonlife = value
            End Set
        End Property

        Public Property StatusId As Long Implements ISiteBatchDtl.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Long)
                mStatusId = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteBatchDtl.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteBatchDtl.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteBatchDtl.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteBatchDtl.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pBatchId As Long, ByVal pOprNmbr As Long, ByVal pOprAmt As Long,
                ByVal pPocId As Long, ByVal pInsuredName As String, ByVal pPolicyName As String, ByVal pGrossLife As Long, ByVal pGrossNonlife As Long,
                ByVal pNonlifePremium As Long, ByVal pDstNonlife As Long, ByVal pPremTaxNonlife As Long, ByVal pLocalTaxNonlife As Long, ByVal pStatusId As Long,
                ByVal pPostBy As Long, ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            BatchId = pBatchId
            OprNmbr = pOprNmbr
            OprAmt = pOprAmt
            PocId = pPocId
            InsuredName = pInsuredName
            PolicyName = pPolicyName
            GrossLife = pGrossLife
            GrossNonlife = pGrossNonlife
            NonlifePremium = pNonlifePremium
            DstNonlife = pDstNonlife
            PremTaxNonlife = pPremTaxNonlife
            LocalTaxNonlife = pLocalTaxNonlife
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

        Public Function GetBatchDtlDt(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteBatchDtl
                Dim dtLocal As DataTable

                dtLocal = objDal.GetSiteBatchDtl(pDocNumber, pUserId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteBatchDtl
                objDAL.AlterSiteBatchDtl(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
