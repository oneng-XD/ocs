#Region "Description"
' PAGE NAME     : STG_TMPTRN BLL
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

    Public Class BStgTmpTrn

#Region "Implements"
        Implements Staging.IStgTmpTrn
#End Region

#Region "Variables"
        Private mBatNum As String = cDataType.fString.Empty
        Private mAcType As String = cDataType.fString.Empty
        Private mFundTP As String = cDataType.fString.Empty
        Private mPayrID As Integer = cDataType.fInteger.Empty
        Private mPolNum As String = cDataType.fString.Empty
        Private mTrnDat As Date = cDataType.fDate.Empty
        Private mTrnAmt As Decimal = cDataType.fDecimal.Empty
        Private mOperID As String = cDataType.fString.Empty
        Private mDateNT As Date = cDataType.fDate.Empty
        Private mTxNumb As Long = cDataType.fLong.Empty
        Private mCredID As Integer = cDataType.fInteger.Empty
        Private mSrcDoc As String = cDataType.fString.Empty
        Private mCurCod As String = cDataType.fString.Empty
        Private mTrnRef As String = cDataType.fString.Empty
        Private mPayTyp As String = cDataType.fString.Empty
        Private mServUn As Integer = cDataType.fInteger.Empty
        Private mTxNum2 As Long = cDataType.fLong.Empty
        Private mCollOff As Integer = cDataType.fInteger.Empty
        Private mRcptNo As Long = cDataType.fLong.Empty
        Private mTrnCod As String = cDataType.fString.Empty
        Private mBucket As Long = cDataType.fLong.Empty
        Private mProces As Long = cDataType.fLong.Empty
        Private mRevPrc As Long = cDataType.fLong.Empty
        Private mPretCB As Decimal = cDataType.fDecimal.Empty
        Private mPostCB As Decimal = cDataType.fDecimal.Empty
        Private mAniNum As Long = cDataType.fLong.Empty
        Private mDocTyp As String = cDataType.fString.Empty
        Private mMetCod As String = cDataType.fString.Empty
        Private mDatDue As Date = cDataType.fDate.Empty
        Private mCshAmt As Decimal = cDataType.fDecimal.Empty
        Private mChkAmt As Decimal = cDataType.fDecimal.Empty
        Private mBankID As Integer = cDataType.fInteger.Empty
        Private mPolFrq As Integer = cDataType.fInteger.Empty
        Private mAgntID As Integer = cDataType.fInteger.Empty
        Private mCertNo As String = cDataType.fString.Empty
        Private mRetAmt As Decimal = cDataType.fDecimal.Empty
        Private mAPRDat As Date = cDataType.fDate.Empty
        Private mAPRNum As String = cDataType.fString.Empty
        Private mApplNo As String = cDataType.fString.Empty
        Private mECRNmbr As String = cDataType.fString.Empty
        Private mECRDate As Date = cDataType.fDate.Empty
        Private mBalFrq As Integer = cDataType.fInteger.Empty
        Private mTxtFile As String = cDataType.fString.Empty
        Private mUploadDate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property BatNum() As String Implements Staging.IStgTmpTrn.BatNum
            Get
                Return mBatNum
            End Get
            Set(value As String)
                If value = String.Empty Then
                    mBatNum = 0
                Else
                    mBatNum = value
                End If
            End Set
        End Property

        Public Property AcType() As String Implements Staging.IStgTmpTrn.AcType
            Get
                Return mAcType
            End Get
            Set(value As String)
                mAcType = value
            End Set
        End Property

        Public Property FundTP() As String Implements Staging.IStgTmpTrn.FundTP
            Get
                Return mFundTP
            End Get
            Set(value As String)
                mFundTP = value
            End Set
        End Property

        Public Property PayrID() As Integer Implements Staging.IStgTmpTrn.PayrID
            Get
                Return mPayrID
            End Get
            Set(value As Integer)
                mPayrID = value
            End Set
        End Property

        Public Property PolNum() As String Implements Staging.IStgTmpTrn.PolNum
            Get
                Return mPolNum
            End Get
            Set(value As String)
                mPolNum = value
            End Set
        End Property

        Public Property TrnDat() As Date Implements Staging.IStgTmpTrn.TrnDat
            Get
                Return mTrnDat
            End Get
            Set(value As Date)
                mTrnDat = value
            End Set
        End Property

        Public Property TrnAmt() As Decimal Implements Staging.IStgTmpTrn.TrnAmt
            Get
                Return mTrnAmt
            End Get
            Set(value As Decimal)
                mTrnAmt = value
            End Set
        End Property

        Public Property OperID() As String Implements Staging.IStgTmpTrn.OperID
            Get
                Return mOperID
            End Get
            Set(value As String)
                mOperID = value
            End Set
        End Property

        Public Property DateNT() As Date Implements Staging.IStgTmpTrn.DateNT
            Get
                Return mDateNT
            End Get
            Set(value As Date)
                mDateNT = value
            End Set
        End Property

        Public Property TxNumb() As Long Implements Staging.IStgTmpTrn.TxNumb
            Get
                Return mTxNumb
            End Get
            Set(value As Long)
                mTxNumb = value
            End Set
        End Property

        Public Property CredID() As Integer Implements Staging.IStgTmpTrn.CredID
            Get
                Return mCredID
            End Get
            Set(value As Integer)
                mCredID = value
            End Set
        End Property

        Public Property SrcDoc() As String Implements Staging.IStgTmpTrn.SrcDoc
            Get
                Return mSrcDoc
            End Get
            Set(value As String)
                mSrcDoc = value
            End Set
        End Property

        Public Property CurCod() As String Implements Staging.IStgTmpTrn.CurCod
            Get
                Return mCurCod
            End Get
            Set(value As String)
                mCurCod = value
            End Set
        End Property

        Public Property TrnRef() As String Implements Staging.IStgTmpTrn.TrnRef
            Get
                Return mTrnRef
            End Get
            Set(value As String)
                mTrnRef = value
            End Set
        End Property

        Public Property PayTyp() As String Implements Staging.IStgTmpTrn.PayTyp
            Get
                Return mPayTyp
            End Get
            Set(value As String)
                mPayTyp = value
            End Set
        End Property

        Public Property ServUn() As Integer Implements Staging.IStgTmpTrn.ServUn
            Get
                Return mServUn
            End Get
            Set(value As Integer)
                mServUn = value
            End Set
        End Property

        Public Property TxNum2() As Long Implements Staging.IStgTmpTrn.TxNum2
            Get
                Return mTxNum2
            End Get
            Set(value As Long)
                mTxNum2 = value
            End Set
        End Property

        Public Property CollOff() As Integer Implements Staging.IStgTmpTrn.CollOff
            Get
                Return mCollOff
            End Get
            Set(value As Integer)
                mCollOff = value
            End Set
        End Property

        Public Property RcptNo() As Long Implements Staging.IStgTmpTrn.RcptNo
            Get
                Return mRcptNo
            End Get
            Set(value As Long)
                mRcptNo = value
            End Set
        End Property

        Public Property TrnCod() As String Implements Staging.IStgTmpTrn.TrnCod
            Get
                Return mTrnCod
            End Get
            Set(value As String)
                mTrnCod = value
            End Set
        End Property

        Public Property Bucket() As Long Implements Staging.IStgTmpTrn.Bucket
            Get
                Return mBucket
            End Get
            Set(value As Long)
                mBucket = value
            End Set
        End Property

        Public Property Proces() As Long Implements Staging.IStgTmpTrn.Proces
            Get
                Return mProces
            End Get
            Set(value As Long)
                mProces = value
            End Set
        End Property

        Public Property RevPrc() As Long Implements Staging.IStgTmpTrn.RevPrc
            Get
                Return mRevPrc
            End Get
            Set(value As Long)
                mRevPrc = value
            End Set
        End Property

        Public Property PretCB() As Decimal Implements Staging.IStgTmpTrn.PretCB
            Get
                Return mPretCB
            End Get
            Set(value As Decimal)
                mPretCB = value
            End Set
        End Property

        Public Property PostCB() As Decimal Implements Staging.IStgTmpTrn.PostCB
            Get
                Return mPostCB
            End Get
            Set(value As Decimal)
                mPostCB = value
            End Set
        End Property

        Public Property AniNum() As Long Implements Staging.IStgTmpTrn.AniNum
            Get
                Return mAniNum
            End Get
            Set(value As Long)
                mAniNum = value
            End Set
        End Property

        Public Property DocTyp() As String Implements Staging.IStgTmpTrn.DocTyp
            Get
                Return mDocTyp
            End Get
            Set(value As String)
                mDocTyp = value
            End Set
        End Property

        Public Property MetCod() As String Implements Staging.IStgTmpTrn.MetCod
            Get
                Return mMetCod
            End Get
            Set(value As String)
                mMetCod = value
            End Set
        End Property

        Public Property DatDue() As Date Implements Staging.IStgTmpTrn.DatDue
            Get
                Return mDatDue
            End Get
            Set(value As Date)
                mDatDue = value
            End Set
        End Property

        Public Property CshAmt() As Decimal Implements Staging.IStgTmpTrn.CshAmt
            Get
                Return mCshAmt
            End Get
            Set(value As Decimal)
                mCshAmt = value
            End Set
        End Property

        Public Property ChkAmt() As Decimal Implements Staging.IStgTmpTrn.ChkAmt
            Get
                Return mChkAmt
            End Get
            Set(value As Decimal)
                mChkAmt = value
            End Set
        End Property

        Public Property BankID() As Integer Implements Staging.IStgTmpTrn.BankID
            Get
                Return mBankID
            End Get
            Set(value As Integer)
                mBankID = value
            End Set
        End Property

        Public Property PolFrq() As Integer Implements Staging.IStgTmpTrn.PolFrq
            Get
                Return mPolFrq
            End Get
            Set(value As Integer)
                mPolFrq = value
            End Set
        End Property

        Public Property AgntID() As Integer Implements Staging.IStgTmpTrn.AgntID
            Get
                Return mAgntID
            End Get
            Set(value As Integer)
                mAgntID = value
            End Set
        End Property

        Public Property CertNo() As String Implements Staging.IStgTmpTrn.CertNo
            Get
                Return mCertNo
            End Get
            Set(value As String)
                mCertNo = value
            End Set
        End Property

        Public Property RetAmt() As Decimal Implements Staging.IStgTmpTrn.RetAmt
            Get
                Return mRetAmt
            End Get
            Set(value As Decimal)
                mRetAmt = value
            End Set
        End Property

        Public Property APRDat() As Date Implements Staging.IStgTmpTrn.APRDat
            Get
                Return mAPRDat
            End Get
            Set(value As Date)
                mAPRDat = value
            End Set
        End Property

        Public Property APRNum() As String Implements Staging.IStgTmpTrn.APRNum
            Get
                Return mAPRNum
            End Get
            Set(value As String)
                mAPRNum = value
            End Set
        End Property

        Public Property ApplNo() As String Implements Staging.IStgTmpTrn.ApplNo
            Get
                Return mApplNo
            End Get
            Set(value As String)
                mApplNo = value
            End Set
        End Property

        Public Property ECRNmbr() As String Implements Staging.IStgTmpTrn.ECRNmbr
            Get
                Return mECRNmbr
            End Get
            Set(value As String)
                mECRNmbr = value
            End Set
        End Property

        Public Property ECRDate() As Date Implements Staging.IStgTmpTrn.ECRDate
            Get
                Return mECRDate
            End Get
            Set(value As Date)
                mECRDate = value
            End Set
        End Property

        Public Property BalFrq() As Integer Implements Staging.IStgTmpTrn.BalFrq
            Get
                Return mBalFrq
            End Get
            Set(value As Integer)
                mBalFrq = value
            End Set
        End Property

        Public Property TxtFile() As String Implements Staging.IStgTmpTrn.TxtFile
            Get
                Return mTxtFile
            End Get
            Set(value As String)
                mTxtFile = value
            End Set
        End Property

        Public Property UploadDate() As Date Implements Staging.IStgTmpTrn.UploadDate
            Get
                Return mUploadDate
            End Get
            Set(value As Date)
                mUploadDate = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pBatNum As String, ByVal pAcType As String, ByVal pFundTP As String,
                ByVal pPayrID As Integer, ByVal pPolNum As String, ByVal pTrnDat As Date,
                ByVal pTrnAmt As Decimal, ByVal pOperID As String, ByVal pDateNT As Date,
                ByVal pTxNumb As Long, ByVal pCredID As Integer, ByVal pSrcDoc As String,
                ByVal pCurCod As String, ByVal pTrnRef As String, ByVal pPayTyp As String,
                ByVal pServUn As Integer, ByVal pTxNum2 As Long, ByVal pCollOff As Integer,
                ByVal pRcptNo As Long, ByVal pTrnCod As String, ByVal pBucket As Long,
                ByVal pProces As Long, ByVal pRevPrc As Long, ByVal pPretCB As Decimal,
                ByVal pPostCB As Decimal, ByVal pAniNum As Long, ByVal pDocTyp As String,
                ByVal pMetCod As String, ByVal pDatDue As Date, ByVal pCshAmt As Decimal,
                ByVal pChkAmt As Decimal, ByVal pBankID As Integer, ByVal pPolFrq As Integer,
                ByVal pAgntID As Integer, ByVal pCertNo As String, ByVal pRetAmt As Decimal,
                ByVal pAPRDat As Date, ByVal pAPRNum As String, ByVal pApplNo As String,
                ByVal pECRNmbr As String, ByVal pECRDate As Date, ByVal pBalFrq As Integer,
                ByVal pTxtFile As String, ByVal pUploadDate As Date)
            BatNum = pBatNum
            AcType = pAcType
            FundTP = pFundTP
            PayrID = pPayrID
            PolNum = pPolNum
            TrnDat = pTrnDat
            TrnAmt = pTrnAmt
            OperID = pOperID
            DateNT = pDateNT
            TxNumb = pTxNumb
            CredID = pCredID
            SrcDoc = pSrcDoc
            CurCod = pCurCod
            TrnRef = pTrnRef
            PayTyp = pPayTyp
            ServUn = pServUn
            TxNum2 = pTxNum2
            CollOff = pCollOff
            RcptNo = pRcptNo
            TrnCod = pTrnCod
            Bucket = pBucket
            Proces = pProces
            RevPrc = pRevPrc
            PretCB = pPretCB
            PostCB = pPostCB
            AniNum = pAniNum
            DocTyp = pDocTyp
            MetCod = pMetCod
            DatDue = pDatDue
            CshAmt = pCshAmt
            ChkAmt = pChkAmt
            BankID = pBankID
            PolFrq = pPolFrq
            AgntID = pAgntID
            CertNo = pCertNo
            RetAmt = pRetAmt
            APRDat = pAPRDat
            APRNum = pAPRNum
            ApplNo = pApplNo
            ECRNmbr = pECRNmbr
            ECRDate = pECRDate
            BalFrq = pBalFrq
            TxtFile = pTxtFile
            UploadDate = pUploadDate
        End Sub

        Sub New(ByVal pObject As Working.BSiteTmpTrn)
            With pObject
                BatNum = .BatNum
                AcType = .AcType
                FundTP = .FundTP
                PayrID = .PayrID
                PolNum = .PolNum
                TrnDat = .TrnDat
                TrnAmt = .TrnAmt
                OperID = .OperID
                DateNT = .DateNT
                TxNumb = .TxNumb
                CredID = .CredID
                SrcDoc = .SrcDoc
                CurCod = .CurCod
                TrnRef = .TrnRef
                PayTyp = .PayTyp
                ServUn = .ServUn
                TxNum2 = .TxNum2
                CollOff = .CollOff
                RcptNo = .RcptNo
                TrnCod = .TrnCod
                Bucket = .Bucket
                Proces = .Proces
                RevPrc = .RevPrc
                PretCB = .PretCB
                PostCB = .PostCB
                AniNum = .AniNum
                DocTyp = .DocTyp
                MetCod = .MetCod
                DatDue = .DatDue
                CshAmt = .CshAmt
                ChkAmt = .ChkAmt
                BankID = .BankID
                PolFrq = .PolFrq
                AgntID = .AgntID
                CertNo = .CertNo
                RetAmt = .RetAmt
                APRDat = .APRDat
                APRNum = .APRNum
                ApplNo = .ApplNo
                ECRNmbr = .ECRNmbr
                ECRDate = .ECRDate
                BalFrq = .BalFrq
                TxtFile = .TxtFile
                UploadDate = .UploadDate
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetTmpTrnDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgTmpTrn
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgTmpTrn(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgTmpTrn
                objDAL.AlterStgTmpTrn(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
