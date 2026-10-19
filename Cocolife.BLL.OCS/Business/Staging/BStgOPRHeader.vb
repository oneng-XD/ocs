#Region "Description"
' PAGE NAME     : STG_OPRHEADER BLL
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

    Public Class BStgOPRHeader

#Region "Implements"
        Implements Staging.IStgOPRHeader
#End Region

#Region "Variables"
        Private mOPRRcptNo As Long = cDataType.fLong.Empty
        Private mOPRDate As Date = cDataType.fDate.Empty
        Private mOPRSrcBrnc As Long = cDataType.fLong.Empty
        Private mOPRRemarks As String = cDataType.fString.Empty
        Private mOPRApplctn As String = cDataType.fString.Empty
        Private mOPRECRNo As Long = cDataType.fLong.Empty
        Private mOPRECRDate As Date = cDataType.fDate.Empty
        Private mOPRPolNum As String = cDataType.fString.Empty
        Private mOPRPyrID As Long = cDataType.fLong.Empty
        Private mOPRPyrFNam As String = cDataType.fString.Empty
        Private mOPRPyrLNam As String = cDataType.fString.Empty
        Private mOPRPyrMNam As String = cDataType.fString.Empty
        Private mOPRInsID As Long = cDataType.fLong.Empty
        Private mOPRInsFNam As String = cDataType.fString.Empty
        Private mOPRInsLNam As String = cDataType.fString.Empty
        Private mOPRInsMNam As String = cDataType.fString.Empty
        Private mOPRAgID As Long = cDataType.fLong.Empty
        Private mOPRAgFNam As String = cDataType.fString.Empty
        Private mOPRAgLNam As String = cDataType.fString.Empty
        Private mOPRAgMNam As String = cDataType.fString.Empty
        Private mOPRBrID As Long = cDataType.fLong.Empty
        Private mOPRBrFNam As String = cDataType.fString.Empty
        Private mOPRBrLNam As String = cDataType.fString.Empty
        Private mOPRBrMNam As String = cDataType.fString.Empty
        Private mOPRDocTyp As String = cDataType.fString.Empty
        Private mOPRTxNumb As Long = cDataType.fLong.Empty
        Private mOPRPlnCry As String = cDataType.fString.Empty
        Private mOPRFlags As String = cDataType.fString.Empty
        Private mOPRIssue As Date = cDataType.fDate.Empty
        Private mOPRLastBl As Date = cDataType.fDate.Empty
        Private mCancelFlag As Integer = cDataType.fInteger.Empty
        Private mPrtFlag As Integer = cDataType.fInteger.Empty
        Private mNiFlag As Integer = cDataType.fInteger.Empty
#End Region

#Region "Properties"

        Public Property OPRRcptNo() As Long Implements Staging.IStgOPRHeader.OPRRcptNo
            Get
                Return mOPRRcptNo
            End Get
            Set(value As Long)
                mOPRRcptNo = value
            End Set
        End Property

        Public Property OPRDate() As Date Implements Staging.IStgOPRHeader.OPRDate
            Get
                Return mOPRDate
            End Get
            Set(value As Date)
                mOPRDate = value
            End Set
        End Property

        Public Property OPRSrcBrnc() As Long Implements Staging.IStgOPRHeader.OPRSrcBrnc
            Get
                Return mOPRSrcBrnc
            End Get
            Set(value As Long)
                mOPRSrcBrnc = value
            End Set
        End Property

        Public Property OPRRemarks() As String Implements Staging.IStgOPRHeader.OPRRemarks
            Get
                Return mOPRRemarks
            End Get
            Set(value As String)
                mOPRRemarks = value
            End Set
        End Property

        Public Property OPRApplctn() As String Implements Staging.IStgOPRHeader.OPRApplctn
            Get
                Return mOPRApplctn
            End Get
            Set(value As String)
                mOPRApplctn = value
            End Set
        End Property

        Public Property OPRECRNo() As Long Implements Staging.IStgOPRHeader.OPRECRNo
            Get
                Return mOPRECRNo
            End Get
            Set(value As Long)
                mOPRECRNo = value
            End Set
        End Property

        Public Property OPRECRDate() As Date Implements Staging.IStgOPRHeader.OPRECRDate
            Get
                Return mOPRECRDate
            End Get
            Set(value As Date)
                mOPRECRDate = value
            End Set
        End Property

        Public Property OPRPolNum() As String Implements Staging.IStgOPRHeader.OPRPolNum
            Get
                Return mOPRPolNum
            End Get
            Set(value As String)
                mOPRPolNum = value
            End Set
        End Property

        Public Property OPRPyrID() As Long Implements Staging.IStgOPRHeader.OPRPyrID
            Get
                Return mOPRPyrID
            End Get
            Set(value As Long)
                mOPRPyrID = value
            End Set
        End Property

        Public Property OPRPyrFNam() As String Implements Staging.IStgOPRHeader.OPRPyrFNam
            Get
                Return mOPRPyrFNam
            End Get
            Set(value As String)
                mOPRPyrFNam = value
            End Set
        End Property

        Public Property OPRPyrLNam() As String Implements Staging.IStgOPRHeader.OPRPyrLNam
            Get
                Return mOPRPyrLNam
            End Get
            Set(value As String)
                mOPRPyrLNam = value
            End Set
        End Property

        Public Property OPRPyrMNam() As String Implements Staging.IStgOPRHeader.OPRPyrMNam
            Get
                Return mOPRPyrMNam
            End Get
            Set(value As String)
                mOPRPyrMNam = value
            End Set
        End Property

        Public Property OPRInsID() As Long Implements Staging.IStgOPRHeader.OPRInsID
            Get
                Return mOPRInsID
            End Get
            Set(value As Long)
                mOPRInsID = value
            End Set
        End Property

        Public Property OPRInsFNam() As String Implements Staging.IStgOPRHeader.OPRInsFNam
            Get
                Return mOPRInsFNam
            End Get
            Set(value As String)
                mOPRInsFNam = value
            End Set
        End Property

        Public Property OPRInsLNam() As String Implements Staging.IStgOPRHeader.OPRInsLNam
            Get
                Return mOPRInsLNam
            End Get
            Set(value As String)
                mOPRInsLNam = value
            End Set
        End Property

        Public Property OPRInsMNam() As String Implements Staging.IStgOPRHeader.OPRInsMNam
            Get
                Return mOPRInsMNam
            End Get
            Set(value As String)
                mOPRInsMNam = value
            End Set
        End Property

        Public Property OPRAgID() As Long Implements Staging.IStgOPRHeader.OPRAgID
            Get
                Return mOPRAgID
            End Get
            Set(value As Long)
                mOPRAgID = value
            End Set
        End Property

        Public Property OPRAgFNam() As String Implements Staging.IStgOPRHeader.OPRAgFNam
            Get
                Return mOPRAgFNam
            End Get
            Set(value As String)
                mOPRAgFNam = value
            End Set
        End Property

        Public Property OPRAgLNam() As String Implements Staging.IStgOPRHeader.OPRAgLNam
            Get
                Return mOPRAgLNam
            End Get
            Set(value As String)
                mOPRAgLNam = value
            End Set
        End Property

        Public Property OPRAgMNam() As String Implements Staging.IStgOPRHeader.OPRAgMNam
            Get
                Return mOPRAgMNam
            End Get
            Set(value As String)
                mOPRAgMNam = value
            End Set
        End Property

        Public Property OPRBrID() As Long Implements Staging.IStgOPRHeader.OPRBrID
            Get
                Return mOPRBrID
            End Get
            Set(value As Long)
                mOPRBrID = value
            End Set
        End Property

        Public Property OPRBrFNam() As String Implements Staging.IStgOPRHeader.OPRBrFNam
            Get
                Return mOPRBrFNam
            End Get
            Set(value As String)
                mOPRBrFNam = value
            End Set
        End Property

        Public Property OPRBrLNam() As String Implements Staging.IStgOPRHeader.OPRBrLNam
            Get
                Return mOPRBrLNam
            End Get
            Set(value As String)
                mOPRBrLNam = value
            End Set
        End Property

        Public Property OPRBrMNam() As String Implements Staging.IStgOPRHeader.OPRBrMNam
            Get
                Return mOPRBrMNam
            End Get
            Set(value As String)
                mOPRBrMNam = value
            End Set
        End Property

        Public Property OPRDocTyp() As String Implements Staging.IStgOPRHeader.OPRDocTyp
            Get
                Return mOPRDocTyp
            End Get
            Set(value As String)
                mOPRDocTyp = value
            End Set
        End Property

        Public Property OPRTxNumb() As Long Implements Staging.IStgOPRHeader.OPRTxNumb
            Get
                Return mOPRTxNumb
            End Get
            Set(value As Long)
                mOPRTxNumb = value
            End Set
        End Property

        Public Property OPRPlnCry() As String Implements Staging.IStgOPRHeader.OPRPlnCry
            Get
                Return mOPRPlnCry
            End Get
            Set(value As String)
                mOPRPlnCry = value
            End Set
        End Property

        Public Property OPRFlags() As String Implements Staging.IStgOPRHeader.OPRFlags
            Get
                Return mOPRFlags
            End Get
            Set(value As String)
                mOPRFlags = value
            End Set
        End Property

        Public Property OPRIssue() As Date Implements Staging.IStgOPRHeader.OPRIssue
            Get
                Return mOPRIssue
            End Get
            Set(value As Date)
                mOPRIssue = value
            End Set
        End Property

        Public Property OPRLastBl() As Date Implements Staging.IStgOPRHeader.OPRLastBl
            Get
                Return mOPRLastBl
            End Get
            Set(value As Date)
                mOPRLastBl = value
            End Set
        End Property

        Public Property CancelFlag() As Integer Implements Staging.IStgOPRHeader.CancelFlag
            Get
                Return mCancelFlag
            End Get
            Set(value As Integer)
                mCancelFlag = value
            End Set
        End Property

        Public Property PrtFlag() As Integer Implements Staging.IStgOPRHeader.PrtFlag
            Get
                Return mPrtFlag
            End Get
            Set(value As Integer)
                mPrtFlag = value
            End Set
        End Property

        Public Property NiFlag() As Integer Implements Staging.IStgOPRHeader.NiFlag
            Get
                Return mNiFlag
            End Get
            Set(value As Integer)
                mNiFlag = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pOPRRcptNo As Long, ByVal pOPRDate As Date, ByVal pOPRSrcBrnc As Long,
                ByVal pOPRRemarks As String, ByVal pOPRApplctn As String, ByVal pOPRECRNo As Long,
                ByVal pOPRECRDate As Date, ByVal pOPRPolNum As String, ByVal pOPRPyrID As Long,
                ByVal pOPRPyrFNam As String, ByVal pOPRPyrLNam As String, ByVal pOPRPyrMNam As String,
                ByVal pOPRInsID As Long, ByVal pOPRInsFNam As String, ByVal pOPRInsLNam As String,
                ByVal pOPRInsMNam As String, ByVal pOPRAgID As Long, ByVal pOPRAgFNam As String,
                ByVal pOPRAgLNam As String, ByVal pOPRAgMNam As String, ByVal pOPRBrID As Long,
                ByVal pOPRBrFNam As String, ByVal pOPRBrLNam As String, ByVal pOPRBrMNam As String,
                ByVal pOPRDocTyp As String, ByVal pOPRTxNumb As Long, ByVal pOPRPlnCry As String,
                ByVal pOPRFlags As String, ByVal pOPRIssue As Date, ByVal pOPRLastBl As Date,
                ByVal pCancelFlag As Integer, ByVal pPrtFlag As Integer, ByVal pNiFlag As Integer)
            OPRRcptNo = pOPRRcptNo
            OPRDate = pOPRDate
            OPRSrcBrnc = pOPRSrcBrnc
            OPRRemarks = pOPRRemarks
            OPRApplctn = pOPRApplctn
            OPRECRNo = pOPRECRNo
            OPRECRDate = pOPRECRDate
            OPRPolNum = pOPRPolNum
            OPRPyrID = pOPRPyrID
            OPRPyrFNam = pOPRPyrFNam
            OPRPyrLNam = pOPRPyrLNam
            OPRPyrMNam = pOPRPyrMNam
            OPRInsID = pOPRInsID
            OPRInsFNam = pOPRInsFNam
            OPRInsLNam = pOPRInsLNam
            OPRInsMNam = pOPRInsMNam
            OPRAgID = pOPRAgID
            OPRAgFNam = pOPRAgFNam
            OPRAgLNam = pOPRAgLNam
            OPRAgMNam = pOPRAgMNam
            OPRBrID = pOPRBrID
            OPRBrFNam = pOPRBrFNam
            OPRBrLNam = pOPRBrLNam
            OPRBrMNam = pOPRBrMNam
            OPRDocTyp = pOPRDocTyp
            OPRTxNumb = pOPRTxNumb
            OPRPlnCry = pOPRPlnCry
            OPRFlags = pOPRFlags
            OPRIssue = pOPRIssue
            OPRLastBl = pOPRLastBl
            CancelFlag = pCancelFlag
            PrtFlag = pPrtFlag
            NiFlag = pNiFlag
        End Sub

        Sub New(ByVal pObject As Working.BSiteOPRHeader)
            With pObject
                OPRRcptNo = .OPRRcptNo
                OPRDate = .OPRDate
                OPRSrcBrnc = .OPRSrcBrnc
                OPRRemarks = .OPRRemarks
                OPRApplctn = .OPRApplctn
                OPRECRNo = .OPRECRNo
                OPRECRDate = .OPRECRDate
                OPRPolNum = .OPRPolNum
                OPRPyrID = .OPRPyrID
                OPRPyrFNam = .OPRPyrFNam
                OPRPyrLNam = .OPRPyrLNam
                OPRPyrMNam = .OPRPyrMNam
                OPRInsID = .OPRInsID
                OPRInsFNam = .OPRInsFNam
                OPRInsLNam = .OPRInsLNam
                OPRInsMNam = .OPRInsMNam
                OPRAgID = .OPRAgID
                OPRAgFNam = .OPRAgFNam
                OPRAgLNam = .OPRAgLNam
                OPRAgMNam = .OPRAgMNam
                OPRBrID = .OPRBrID
                OPRBrFNam = .OPRBrFNam
                OPRBrLNam = .OPRBrLNam
                OPRBrMNam = .OPRBrMNam
                OPRDocTyp = .OPRDocTyp
                OPRTxNumb = .OPRTxNumb
                OPRPlnCry = .OPRPlnCry
                OPRFlags = .OPRFlags
                OPRIssue = .OPRIssue
                OPRLastBl = .OPRLastBl
                CancelFlag = .CancelFlag
                PrtFlag = .PrtFlag
                NiFlag = .NiFlag
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"
        Public Sub GetStgOPRHeader(ByVal pDocNumber As Long)

            Dim objDAL As New dalStaging.DStgOPRHeader
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetStgOPRHeader(pDocNumber)
                With drLocal
                    While .Read
                        OPRRcptNo = cDataType.fLong.IfNull(.Item("oprrcptno"))
                        OPRDate = cDataType.fDate.IfNull(.Item("oprdate"))
                        OPRSrcBrnc = cDataType.fLong.IfNull(.Item("oprsrcbrnc"))
                        OPRRemarks = cDataType.fString.IfNull(.Item("oprremarks"))
                        OPRApplctn = cDataType.fString.IfNull(.Item("oprapplctn"))
                        OPRECRNo = cDataType.fLong.IfNull(.Item("oprecrno"))
                        OPRECRDate = cDataType.fDate.IfNull(.Item("oprecrdate"))
                        OPRPolNum = cDataType.fString.IfNull(.Item("oprpolnum"))
                        OPRPyrID = cDataType.fLong.IfNull(.Item("oprpyrid"))
                        OPRPyrFNam = cDataType.fString.IfNull(.Item("oprpyrfnam"))
                        OPRPyrLNam = cDataType.fString.IfNull(.Item("oprpyrlnam"))
                        OPRPyrMNam = cDataType.fString.IfNull(.Item("oprpyrmnam"))
                        OPRInsID = cDataType.fLong.IfNull(.Item("oprinsid"))
                        OPRInsFNam = cDataType.fString.IfNull(.Item("oprinsfnam"))
                        OPRInsLNam = cDataType.fString.IfNull(.Item("oprinslnam"))
                        OPRInsMNam = cDataType.fString.IfNull(.Item("oprinsmnam"))
                        OPRAgID = cDataType.fLong.IfNull(.Item("opragid"))
                        OPRAgFNam = cDataType.fString.IfNull(.Item("opragfnam"))
                        OPRAgLNam = cDataType.fString.IfNull(.Item("opraglnam"))
                        OPRAgMNam = cDataType.fString.IfNull(.Item("opragmnam"))
                        OPRBrID = cDataType.fLong.IfNull(.Item("oprbrid"))
                        OPRBrFNam = cDataType.fString.IfNull(.Item("oprbrfnam"))
                        OPRBrLNam = cDataType.fString.IfNull(.Item("oprbrlnam"))
                        OPRBrMNam = cDataType.fString.IfNull(.Item("oprbrmnam"))
                        OPRDocTyp = cDataType.fString.IfNull(.Item("oprdoctyp"))
                        OPRTxNumb = cDataType.fLong.IfNull(.Item("oprtxnumb"))
                        OPRPlnCry = cDataType.fString.IfNull(.Item("oprplncry"))
                        OPRFlags = cDataType.fString.IfNull(.Item("oprflags"))
                        OPRIssue = cDataType.fDate.IfNull(.Item("oprissue"))
                        OPRLastBl = cDataType.fDate.IfNull(.Item("oprlastbl"))
                        CancelFlag = cDataType.fInteger.IfNull(.Item("cancel_flag"))
                        PrtFlag = cDataType.fInteger.IfNull(.Item("prt_flag"))
                        NiFlag = cDataType.fInteger.IfNull(.Item("ni_flag"))
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try
        End Sub

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgOPRHeader
                objDAL.AlterStgOPRHeader(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
