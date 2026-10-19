#Region "Description"
' PAGE NAME     : SITE_ORHEADER BLL
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

    Public Class BSiteORHeader

#Region "Implements"
        Implements ISiteORHeader
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mEmplCode As String = cDataType.fString.Empty
        Private mORDate As Date = cDataType.fDate.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mTotalAmt As Decimal = cDataType.fDecimal.Empty
        Private mChkAmt As Decimal = cDataType.fDecimal.Empty
        Private mPayType As String = cDataType.fString.Empty
        Private mCurrType As String = cDataType.fString.Empty
        Private mSrcBrnch As Long = cDataType.fLong.Empty
        Private mPayrID As Long = cDataType.fLong.Empty
        Private mPayor As String = cDataType.fString.Empty
        Private mAcct As String = cDataType.fString.Empty
        Private mGLCode As String = cDataType.fString.Empty
        Private mAddr As String = cDataType.fString.Empty
        Private mTIN As String = cDataType.fString.Empty
        Private mCancelFlag As Integer = cDataType.fInteger.Empty
        Private mPrtFlag As Integer = cDataType.fInteger.Empty
        Private mUserID As String = cDataType.fLong.Empty
        Private mSiteCode As Long = cDataType.fLong.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteORHeader.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteORHeader.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteORHeader.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteORHeader.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteORHeader.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteORHeader.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property ORNmbr() As Long Implements ISiteORHeader.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property EmplCode() As String Implements ISiteORHeader.EmplCode
            Get
                Return mEmplCode
            End Get
            Set(value As String)
                mEmplCode = value
            End Set
        End Property

        Public Property ORDate() As Date Implements ISiteORHeader.ORDate
            Get
                Return mORDate
            End Get
            Set(value As Date)
                mORDate = value
            End Set
        End Property

        Public Property Remarks() As String Implements ISiteORHeader.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property TotalAmt() As Decimal Implements ISiteORHeader.TotalAmt
            Get
                Return mTotalAmt
            End Get
            Set(value As Decimal)
                mTotalAmt = value
            End Set
        End Property

        Public Property ChkAmt() As Decimal Implements ISiteORHeader.ChkAmt
            Get
                Return mChkAmt
            End Get
            Set(value As Decimal)
                mChkAmt = value
            End Set
        End Property

        Public Property PayType() As String Implements ISiteORHeader.PayType
            Get
                Return mPayType
            End Get
            Set(value As String)
                mPayType = value
            End Set
        End Property

        Public Property CurrType() As String Implements ISiteORHeader.CurrType
            Get
                Return mCurrType
            End Get
            Set(value As String)
                mCurrType = value
            End Set
        End Property

        Public Property SrcBrnch() As Long Implements ISiteORHeader.SrcBrnch
            Get
                Return mSrcBrnch
            End Get
            Set(value As Long)
                mSrcBrnch = value
            End Set
        End Property

        Public Property PayrID() As Long Implements ISiteORHeader.PayrID
            Get
                Return mPayrID
            End Get
            Set(value As Long)
                mPayrID = value
            End Set
        End Property

        Public Property Payor() As String Implements ISiteORHeader.Payor
            Get
                Return mPayor
            End Get
            Set(value As String)
                mPayor = value
            End Set
        End Property

        Public Property Acct() As String Implements ISiteORHeader.Acct
            Get
                Return mAcct
            End Get
            Set(value As String)
                mAcct = value
            End Set
        End Property

        Public Property GLCode() As String Implements ISiteORHeader.GLCode
            Get
                Return mGLCode
            End Get
            Set(value As String)
                mGLCode = value
            End Set
        End Property

        Public Property Addr() As String Implements ISiteORHeader.Addr
            Get
                Return mAddr
            End Get
            Set(value As String)
                mAddr = value
            End Set
        End Property

        Public Property TIN() As String Implements ISiteORHeader.TIN
            Get
                Return mTIN
            End Get
            Set(value As String)
                mTIN = value
            End Set
        End Property

        Public Property CancelFlag() As Integer Implements ISiteORHeader.CancelFlag
            Get
                Return mCancelFlag
            End Get
            Set(value As Integer)
                mCancelFlag = value
            End Set
        End Property

        Public Property PrtFlag() As Integer Implements ISiteORHeader.PrtFlag
            Get
                Return mPrtFlag
            End Get
            Set(value As Integer)
                mPrtFlag = value
            End Set
        End Property

        Public Property UserID() As Long Implements ISiteORHeader.UserId
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode() As Long Implements ISiteORHeader.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pORNmbr As Long, ByVal pEmplCode As String, ByVal pORDate As Date,
                ByVal pRemarks As String, ByVal pTotalAmt As Decimal, ByVal pChkAmt As Decimal,
                ByVal pPayType As String, ByVal pCurrType As String, ByVal pSrcBrnch As Long,
                ByVal pPayrID As Long, ByVal pPayor As String, ByVal pAcct As String,
                ByVal pGLCode As String, ByVal pAddr As String, ByVal pTIN As String,
                ByVal pCancelFlag As Integer, ByVal pPrtFlag As Integer, ByVal pUserId As Long,
                ByVal pSiteCode As Long, ByVal pStatusId As Integer, ByVal pPostBy As Long,
                ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            ORNmbr = pORNmbr
            EmplCode = pEmplCode
            ORDate = pORDate
            Remarks = pRemarks
            TotalAmt = pTotalAmt
            ChkAmt = pChkAmt
            PayType = pPayType
            CurrType = pCurrType
            SrcBrnch = pSrcBrnch
            PayrID = pPayrID
            Payor = pPayor
            Acct = pAcct
            GLCode = pGLCode
            Addr = pAddr
            TIN = pTIN
            CancelFlag = pCancelFlag
            PrtFlag = pPrtFlag
            UserID = pUserId
            SiteCode = pSiteCode
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

        Public Sub GetORHeader(ByVal pDocNumber As Long, ByVal pUserId As Long)

            Dim objDAL As New dalWorking.DSiteORHeader
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetSiteORHeader(pDocNumber, pUserId)
                With drLocal
                    While .Read
                        Id = cDataType.fLong.IfNull(.Item("id"))
                        ORNmbr = cDataType.fLong.IfNull(.Item("or_nmbr"))
                        EmplCode = cDataType.fString.IfNull(.Item("empl_code"))
                        ORDate = cDataType.fDate.IfNull(.Item("or_date"))
                        Remarks = cDataType.fString.IfNull(.Item("remarks"))
                        TotalAmt = cDataType.fDecimal.IfNull(.Item("total_amt"))
                        ChkAmt = cDataType.fDecimal.IfNull(.Item("chk_amt"))
                        PayType = cDataType.fString.IfNull(.Item("pay_type"))
                        CurrType = cDataType.fString.IfNull(.Item("curr_type"))
                        SrcBrnch = cDataType.fLong.IfNull(.Item("src_brnch"))
                        PayrID = cDataType.fLong.IfNull(.Item("payrid"))
                        Payor = cDataType.fString.IfNull(.Item("payor"))
                        Acct = cDataType.fString.IfNull(.Item("acct"))
                        GLCode = cDataType.fString.IfNull(.Item("gl_code"))
                        Addr = cDataType.fString.IfNull(.Item("addr"))
                        TIN = cDataType.fString.IfNull(.Item("tin"))
                        CancelFlag = cDataType.fLong.IfNull(.Item("cancel_flag"))
                        PrtFlag = cDataType.fLong.IfNull(.Item("prt_flag"))
                        UserID = cDataType.fLong.IfNull(.Item("user_id"))
                        SiteCode = cDataType.fLong.IfNull(.Item("site_code"))
                        StatusId = cDataType.fLong.IfNull(.Item("status_id"))
                        PostBy = cDataType.fLong.IfNull(.Item("post_by"))
                        PostDate = cDataType.fDate.IfNull(.Item("post_date"))
                        LastUpdateBy = cDataType.fLong.IfNull(.Item("last_update_by"))
                        LastUpdate = cDataType.fDate.IfNull(.Item("last_update"))
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
                Dim objDAL As New dalWorking.DSiteORHeader
                objDAL.AlterSiteORHeader(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

