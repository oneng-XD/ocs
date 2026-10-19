#Region "Description"
' PAGE NAME     : STG_OPRINFO BLL
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

    Public Class BStgOPRInfo

#Region "Implements"
        Implements Staging.IStgOPRInfo
#End Region

#Region "Variables"
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mInsLName As String = cDataType.fString.Empty
        Private mInsFName As String = cDataType.fString.Empty
        Private mInsMI As String = cDataType.fString.Empty
        Private mInsBDay As Date = cDataType.fDate.Empty
        Private mOwnrLName As String = cDataType.fString.Empty
        Private mOwnrFName As String = cDataType.fString.Empty
        Private mOwnrMI As String = cDataType.fString.Empty
        Private mOwnrBDay As Date = cDataType.fDate.Empty
        Private mApplNo As String = cDataType.fString.Empty
        Private mAplNoPTag As Integer = cDataType.fInteger.Empty
        Private mPremAmt As Decimal = cDataType.fDecimal.Empty
        Private mECRNmbr As Long = cDataType.fLong.Empty
        Private mECRDate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property OPRNmbr() As Long Implements Staging.IStgOPRInfo.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property InsLName() As String Implements Staging.IStgOPRInfo.InsLName
            Get
                Return mInsLName
            End Get
            Set(value As String)
                mInsLName = value
            End Set
        End Property

        Public Property InsFName() As String Implements Staging.IStgOPRInfo.InsFName
            Get
                Return mInsFName
            End Get
            Set(value As String)
                mInsFName = value
            End Set
        End Property

        Public Property InsMI() As String Implements Staging.IStgOPRInfo.InsMI
            Get
                Return mInsMI
            End Get
            Set(value As String)
                mInsMI = value
            End Set
        End Property

        Public Property InsBDay() As Date Implements Staging.IStgOPRInfo.InsBDay
            Get
                Return mInsBDay
            End Get
            Set(value As Date)
                mInsBDay = value
            End Set
        End Property

        Public Property OwnrLName() As String Implements Staging.IStgOPRInfo.OwnrLName
            Get
                Return mOwnrLName
            End Get
            Set(value As String)
                mOwnrLName = value
            End Set
        End Property

        Public Property OwnrFName() As String Implements Staging.IStgOPRInfo.OwnrFName
            Get
                Return mOwnrFName
            End Get
            Set(value As String)
                mOwnrFName = value
            End Set
        End Property

        Public Property OwnrMI() As String Implements Staging.IStgOPRInfo.OwnrMI
            Get
                Return mOwnrMI
            End Get
            Set(value As String)
                mOwnrMI = value
            End Set
        End Property

        Public Property OwnrBDay() As Date Implements Staging.IStgOPRInfo.OwnrBDay
            Get
                Return mOwnrBDay
            End Get
            Set(value As Date)
                mOwnrBDay = value
            End Set
        End Property

        Public Property ApplNo() As String Implements Staging.IStgOPRInfo.ApplNo
            Get
                Return mApplNo
            End Get
            Set(value As String)
                mApplNo = value
            End Set
        End Property

        Public Property AplNoPTag() As Integer Implements Staging.IStgOPRInfo.AplNoPTag
            Get
                Return mAplNoPTag
            End Get
            Set(value As Integer)
                mAplNoPTag = value
            End Set
        End Property

        Public Property PremAmt() As Decimal Implements Staging.IStgOPRInfo.PremAmt
            Get
                Return mPremAmt
            End Get
            Set(value As Decimal)
                mPremAmt = value
            End Set
        End Property

        Public Property ECRNmbr() As Long Implements Staging.IStgOPRInfo.ECRNmbr
            Get
                Return mECRNmbr
            End Get
            Set(value As Long)
                mECRNmbr = value
            End Set
        End Property

        Public Property ECRDate() As Date Implements Staging.IStgOPRInfo.ECRDate
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

        Sub New(ByVal pOPRNmbr As Long, ByVal pInsLName As String, ByVal pInsFName As String,
                ByVal pInsMI As String, ByVal pInsBDay As Date, ByVal pOwnrLName As String,
                ByVal pOwnrFName As String, ByVal pOwnrMI As String, ByVal pOwnrBDay As Date,
                ByVal pApplNo As String, ByVal pAplNoPTag As Integer, ByVal pPremAmt As Decimal,
                ByVal pECRNmbr As Long, ByVal pECRDate As Date)
            OPRNmbr = pOPRNmbr
            InsLName = pInsLName
            InsFName = pInsFName
            InsMI = pInsMI
            InsBDay = pInsBDay
            OwnrLName = pOwnrLName
            OwnrFName = pOwnrFName
            OwnrMI = pOwnrMI
            OwnrBDay = pOwnrBDay
            ApplNo = pApplNo
            AplNoPTag = pAplNoPTag
            PremAmt = pPremAmt
            ECRNmbr = pECRNmbr
            ECRDate = pECRDate
        End Sub

        Sub New(ByVal pObject As Working.BSiteOPRInfo)
            With pObject
                OPRNmbr = .OPRNmbr
                InsLName = .InsLName
                InsFName = .InsFName
                InsMI = .InsMI
                InsBDay = .InsBDay
                OwnrLName = .OwnrLName
                OwnrFName = .OwnrFName
                OwnrMI = .OwnrMI
                OwnrBDay = .OwnrBDay
                ApplNo = .ApplNo
                AplNoPTag = .AplNoPTag
                PremAmt = .PremAmt
                ECRNmbr = .ECRNmbr
                ECRDate = .ECRDate
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"
        Public Function GetStgOPRInfoDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgOPRInfo
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgOPRInfo(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgOPRInfo
                objDAL.AlterStgOPRInfo(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
