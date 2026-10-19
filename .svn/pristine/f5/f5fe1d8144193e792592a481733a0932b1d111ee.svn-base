#Region "Description"
' PAGE NAME     : SITE_ORINFO BLL
' CREATED BY    : IBP
' CREATED DATE  : 02/16/2017
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

    Public Class BSiteORInfo

#Region "Implements"
        Implements ISiteORInfo
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mOwnrId As Long = cDataType.fLong.Empty
        Private mOwnrLName As String = cDataType.fString.Empty
        Private mOwnrFName As String = cDataType.fString.Empty
        Private mOwnrMI As String = cDataType.fString.Empty
        Private mOwnrBDay As Date = cDataType.fDate.Empty
        Private mOwnrSfx As String = cDataType.fString.Empty
        Private mOwnrTit As String = cDataType.fString.Empty
        Private mOwnrSex As String = cDataType.fString.Empty
        Private mOwnrPlc As String = cDataType.fString.Empty
        'Private mApplNo As Long = cDataType.fLong.Empty
        'Private mAplNoPTag As Integer = cDataType.fInteger.Empty
        'Private mPremAmt As Double = cDataType.fDouble.Empty
        'Private mECRNmbr As Long = cDataType.fLong.Empty
        ''''''''''''''''''''''''''''''''''''''''''''''Private mECRDate As Date = cDataType.fDate.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteORInfo.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteORInfo.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteORInfo.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteORInfo.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteORInfo.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteORInfo.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property ORNmbr() As Long Implements ISiteORInfo.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
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


        Public Property OwnrLName() As String Implements ISiteORInfo.OwnrLName
            Get
                Return mOwnrLName
            End Get
            Set(value As String)
                mOwnrLName = value
            End Set
        End Property

        Public Property OwnrFName() As String Implements ISiteORInfo.OwnrFName
            Get
                Return mOwnrFName
            End Get
            Set(value As String)
                mOwnrFName = value
            End Set
        End Property

        Public Property OwnrMI() As String Implements ISiteORInfo.OwnrMI
            Get
                Return mOwnrMI
            End Get
            Set(value As String)
                mOwnrMI = value
            End Set
        End Property

        Public Property OwnrBDay() As Date Implements ISiteORInfo.OwnrBDay
            Get
                Return mOwnrBDay
            End Get
            Set(value As Date)
                mOwnrBDay = value
            End Set
        End Property

        Public Property OwnrSfx() As String Implements ISiteORInfo.OwnrSfx
            Get
                Return mOwnrSfx
            End Get
            Set(value As String)
                mOwnrSfx = value
            End Set
        End Property

        Public Property OwnrTit() As String Implements ISiteORInfo.OwnrTit
            Get
                Return mOwnrTit
            End Get
            Set(value As String)
                mOwnrTit = value
            End Set
        End Property

        Public Property OwnrSex() As String Implements ISiteORInfo.OwnrSex
            Get
                Return mOwnrSex
            End Get
            Set(value As String)
                mOwnrSex = value
            End Set
        End Property

        Public Property OwnrPlc() As String Implements ISiteORInfo.OwnrPlc
            Get
                Return mOwnrPlc
            End Get
            Set(value As String)
                mOwnrPlc = value
            End Set
        End Property


#End Region

#Region "Constructor"

        Sub New()

        End Sub

        'Sub New(ByVal pId As Long, ByVal pORNmbr As Long, ByVal pInsId As Long, ByVal pInsLName As String, ByVal pInsFName As String,
        '       ByVal pInsMI As String, ByVal pInsBDay As Date, ByVal pInsSfx As String, ByVal pInsTit As String, ByVal pInsSex As String,
        '       ByVal pInsPlc As String, ByVal pOwnrId As Long, ByVal pOwnrLName As String, ByVal pOwnrFName As String, ByVal pOwnrMI As String,
        '       ByVal pOwnrBDay As Date, ByVal pOwnrSfx As String, ByVal pOwnrTit As String, ByVal pOwnrSex As String, ByVal pOwnrPlc As String,
        '       ByVal pApplNo As String, ByVal pAplNoPTag As Integer, ByVal pPremAmt As Double,
        '       ByVal pECRNmbr As Long, ByVal pECRDate As Date, ByVal pStatusId As Integer, ByVal pPostBy As Long,
        '       ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
        '    Id = pId
        '    ORNmbr = pORNmbr
        '    InsId = pInsId
        '    InsLName = pInsLName
        '    InsFName = pInsFName
        '    InsMI = pInsMI
        '    InsBDay = pInsBDay
        '    InsSfx = pInsSfx
        '    InsTit = pInsTit
        '    InsSex = pInsSex
        '    InsPlc = pInsPlc
        '    OwnrId = pOwnrId
        '    OwnrLName = pOwnrLName
        '    OwnrFName = pOwnrFName
        '    OwnrMI = pOwnrMI
        '    OwnrBDay = pOwnrBDay
        '    OwnrSfx = pOwnrSfx
        '    OwnrTit = pOwnrTit
        '    OwnrSex = pOwnrSex
        '    OwnrPlc = pOwnrPlc
        '    ApplNo = pApplNo
        '    AplNoPTag = pAplNoPTag
        '    PremAmt = pPremAmt
        '    ECRNmbr = pECRNmbr
        '    ECRDate = pECRDate
        '    StatusId = pStatusId
        '    PostBy = pPostBy
        '    PostDate = pPostDate
        '    LastUpdateBy = pLastUpdateBy
        '    LastUpdate = pLastUpdate
        'End Sub


#End Region

#Region "Single Point Functions"
#End Region

#Region "Validations"
#End Region

#Region "Data Retrieval"
        'Public Function GetORInfoDt(ByVal pDocNumber As Long) As DataTable
        '    Try
        '        Dim objDal As New dalWorking.DSiteORInfo
        '        Dim dtLocal As DataTable

        '        dtLocal = objDal.GetORInfoDt(pDocNumber)

        '        Return dtLocal
        '    Catch ex As Exception
        '        Throw
        '    End Try
        'End Function
#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String) As Long

            Try
                Dim objDAL As New dalWorking.DSiteORInfo
                objDAL.AlterSiteORInfo(Me, pAction)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function


#End Region


    End Class

End Namespace

