#Region "Description"
' PAGE NAME     : SITE_OPRINFO BLL
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

    Public Class BSiteOPRInfo

#Region "Implements"
        Implements ISiteOPRInfo
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mInsId As Long = cDataType.fLong.Empty
        Private mInsLName As String = cDataType.fString.Empty
        Private mInsFName As String = cDataType.fString.Empty
        Private mInsMI As String = cDataType.fString.Empty
        Private mInsBDay As Date = cDataType.fDate.Empty
        Private mInsSfx As String = cDataType.fString.Empty
        Private mInsTit As String = cDataType.fString.Empty
        Private mInsSex As String = cDataType.fString.Empty
        Private mInsPlc As String = cDataType.fString.Empty
        Private mOwnrId As Long = cDataType.fLong.Empty
        Private mOwnrLName As String = cDataType.fString.Empty
        Private mOwnrFName As String = cDataType.fString.Empty
        Private mOwnrMI As String = cDataType.fString.Empty
        Private mOwnrBDay As Date = cDataType.fDate.Empty
        Private mOwnrSfx As String = cDataType.fString.Empty
        Private mOwnrTit As String = cDataType.fString.Empty
        Private mOwnrSex As String = cDataType.fString.Empty
        Private mOwnrPlc As String = cDataType.fString.Empty
        Private mApplNo As Long = cDataType.fLong.Empty
        Private mAplNoPTag As Integer = cDataType.fInteger.Empty
        Private mPremAmt As Decimal = cDataType.fDecimal.Empty
        Private mECRNmbr As Long = cDataType.fLong.Empty
        Private mECRDate As Date = cDataType.fDate.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteOPRInfo.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteOPRInfo.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteOPRInfo.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteOPRInfo.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteOPRInfo.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteOPRInfo.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property OPRNmbr() As Long Implements ISiteOPRInfo.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property InsId() As Long
            Get
                Return mInsId
            End Get
            Set(ByVal value As Long)
                mInsId = value
            End Set
        End Property


        Public Property InsLName() As String Implements ISiteOPRInfo.InsLName
            Get
                Return mInsLName
            End Get
            Set(value As String)
                mInsLName = value
            End Set
        End Property

        Public Property InsFName() As String Implements ISiteOPRInfo.InsFName
            Get
                Return mInsFName
            End Get
            Set(value As String)
                mInsFName = value
            End Set
        End Property

        Public Property InsMI() As String Implements ISiteOPRInfo.InsMI
            Get
                Return mInsMI
            End Get
            Set(value As String)
                mInsMI = value
            End Set
        End Property

        Public Property InsBDay() As Date Implements ISiteOPRInfo.InsBDay
            Get
                Return mInsBDay
            End Get
            Set(value As Date)
                mInsBDay = value
            End Set
        End Property

        Public Property InsSfx() As String Implements ISiteOPRInfo.InsSfx
            Get
                Return mInsSfx
            End Get
            Set(value As String)
                mInsSfx = value
            End Set
        End Property

        Public Property InsTit() As String Implements ISiteOPRInfo.insTit
            Get
                Return mInsTit
            End Get
            Set(value As String)
                mInsTit = value
            End Set
        End Property

        Public Property InsSex() As String Implements ISiteOPRInfo.InsSex
            Get
                Return mInsSex
            End Get
            Set(value As String)
                mInsSex = value
            End Set
        End Property

        Public Property InsPlc() As String Implements ISiteOPRInfo.InsPlc
            Get
                Return mInsPlc
            End Get
            Set(value As String)
                mInsPlc = value
            End Set
        End Property

        Public Property OwnrId() As Long
            Get
                Return mOwnrId
            End Get
            Set(ByVal value As Long)
                mOwnrId = value
            End Set
        End Property


        Public Property OwnrLName() As String Implements ISiteOPRInfo.OwnrLName
            Get
                Return mOwnrLName
            End Get
            Set(value As String)
                mOwnrLName = value
            End Set
        End Property

        Public Property OwnrFName() As String Implements ISiteOPRInfo.OwnrFName
            Get
                Return mOwnrFName
            End Get
            Set(value As String)
                mOwnrFName = value
            End Set
        End Property

        Public Property OwnrMI() As String Implements ISiteOPRInfo.OwnrMI
            Get
                Return mOwnrMI
            End Get
            Set(value As String)
                mOwnrMI = value
            End Set
        End Property

        Public Property OwnrBDay() As Date Implements ISiteOPRInfo.OwnrBDay
            Get
                Return mOwnrBDay
            End Get
            Set(value As Date)
                mOwnrBDay = value
            End Set
        End Property

        Public Property OwnrSfx() As String Implements ISiteOPRInfo.OwnrSfx
            Get
                Return mOwnrSfx
            End Get
            Set(value As String)
                mOwnrSfx = value
            End Set
        End Property

        Public Property OwnrTit() As String Implements ISiteOPRInfo.OwnrTit
            Get
                Return mOwnrTit
            End Get
            Set(value As String)
                mOwnrTit = value
            End Set
        End Property

        Public Property OwnrSex() As String Implements ISiteOPRInfo.OwnrSex
            Get
                Return mOwnrSex
            End Get
            Set(value As String)
                mOwnrSex = value
            End Set
        End Property

        Public Property OwnrPlc() As String Implements ISiteOPRInfo.OwnrPlc
            Get
                Return mOwnrPlc
            End Get
            Set(value As String)
                mOwnrPlc = value
            End Set
        End Property

        Public Property ApplNo() As Long Implements ISiteOPRInfo.ApplNo
            Get
                Return mApplNo
            End Get
            Set(value As Long)
                mApplNo = value
            End Set
        End Property

        Public Property AplNoPTag() As Integer Implements ISiteOPRInfo.AplNoPTag
            Get
                Return mAplNoPTag
            End Get
            Set(value As Integer)
                mAplNoPTag = value
            End Set
        End Property

        Public Property PremAmt() As Decimal Implements ISiteOPRInfo.PremAmt
            Get
                Return mPremAmt
            End Get
            Set(value As Decimal)
                mPremAmt = value
            End Set
        End Property

        Public Property ECRNmbr() As Long Implements ISiteOPRInfo.ECRNmbr
            Get
                Return mECRNmbr
            End Get
            Set(value As Long)
                mECRNmbr = value
            End Set
        End Property

        Public Property ECRDate() As Date Implements ISiteOPRInfo.ECRDate
            Get
                Return mECRDate
            End Get
            Set(value As Date)
                mECRDate = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pOPRNmbr As Long, ByVal pInsId As Long, ByVal pInsLName As String, ByVal pInsFName As String,
                ByVal pInsMI As String, ByVal pInsBDay As Date, ByVal pInsSfx As String, ByVal pInsTit As String, ByVal pInsSex As String,
                ByVal pInsPlc As String, ByVal pOwnrId As Long, ByVal pOwnrLName As String, ByVal pOwnrFName As String, ByVal pOwnrMI As String,
                ByVal pOwnrBDay As Date, ByVal pOwnrSfx As String, ByVal pOwnrTit As String, ByVal pOwnrSex As String, ByVal pOwnrPlc As String,
                ByVal pApplNo As String, ByVal pAplNoPTag As Integer, ByVal pPremAmt As Decimal,
                ByVal pECRNmbr As Long, ByVal pECRDate As Date, ByVal pStatusId As Integer, ByVal pPostBy As Long,
                ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            OPRNmbr = pOPRNmbr
            InsId = pInsId
            InsLName = pInsLName
            InsFName = pInsFName
            InsMI = pInsMI
            InsBDay = pInsBDay
            InsSfx = pInsSfx
            InsTit = pInsTit
            InsSex = pInsSex
            InsPlc = pInsPlc
            OwnrId = pOwnrId
            OwnrLName = pOwnrLName
            OwnrFName = pOwnrFName
            OwnrMI = pOwnrMI
            OwnrBDay = pOwnrBDay
            OwnrSfx = pOwnrSfx
            OwnrTit = pOwnrTit
            OwnrSex = pOwnrSex
            OwnrPlc = pOwnrPlc
            ApplNo = pApplNo
            AplNoPTag = pAplNoPTag
            PremAmt = pPremAmt
            ECRNmbr = pECRNmbr
            ECRDate = pECRDate
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
        Public Function GetOPRInfoDt(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteOPRInfo
                Dim dtLocal As DataTable

                dtLocal = objDal.GetOprInfoDt(pDocNumber, pUserId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteOPRInfo
                objDAL.AlterSiteOPRInfo(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
