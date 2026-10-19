#Region "Description"
' PAGE NAME     : STG_ORHEADER BLL
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

    Public Class BStgORHeader

#Region "Implements"
        Implements Staging.IStgORHeader
#End Region

#Region "Variables"
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
#End Region

#Region "Properties"

        Public Property ORNmbr() As Long Implements Staging.IStgORHeader.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property EmplCode() As String Implements Staging.IStgORHeader.EmplCode
            Get
                Return mEmplCode
            End Get
            Set(value As String)
                mEmplCode = value
            End Set
        End Property

        Public Property ORDate() As Date Implements Staging.IStgORHeader.ORDate
            Get
                Return mORDate
            End Get
            Set(value As Date)
                mORDate = value
            End Set
        End Property

        Public Property Remarks() As String Implements Staging.IStgORHeader.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property TotalAmt() As Decimal Implements Staging.IStgORHeader.TotalAmt
            Get
                Return mTotalAmt
            End Get
            Set(value As Decimal)
                mTotalAmt = value
            End Set
        End Property

        Public Property ChkAmt() As Decimal Implements Staging.IStgORHeader.ChkAmt
            Get
                Return mChkAmt
            End Get
            Set(value As Decimal)
                mChkAmt = value
            End Set
        End Property

        Public Property PayType() As String Implements Staging.IStgORHeader.PayType
            Get
                Return mPayType
            End Get
            Set(value As String)
                mPayType = value
            End Set
        End Property

        Public Property CurrType() As String Implements Staging.IStgORHeader.CurrType
            Get
                Return mCurrType
            End Get
            Set(value As String)
                mCurrType = value
            End Set
        End Property

        Public Property SrcBrnch() As Long Implements Staging.IStgORHeader.SrcBrnch
            Get
                Return mSrcBrnch
            End Get
            Set(value As Long)
                mSrcBrnch = value
            End Set
        End Property

        Public Property PayrID() As Long Implements Staging.IStgORHeader.PayrID
            Get
                Return mPayrID
            End Get
            Set(value As Long)
                mPayrID = value
            End Set
        End Property

        Public Property Payor() As String Implements Staging.IStgORHeader.Payor
            Get
                Return mPayor
            End Get
            Set(value As String)
                mPayor = value
            End Set
        End Property

        Public Property Acct() As String Implements Staging.IStgORHeader.Acct
            Get
                Return mAcct
            End Get
            Set(value As String)
                mAcct = value
            End Set
        End Property

        Public Property GLCode() As String Implements Staging.IStgORHeader.GLCode
            Get
                Return mGLCode
            End Get
            Set(value As String)
                mGLCode = value
            End Set
        End Property

        Public Property Addr() As String Implements Staging.IStgORHeader.Addr
            Get
                Return mAddr
            End Get
            Set(value As String)
                mAddr = value
            End Set
        End Property

        Public Property TIN() As String Implements Staging.IStgORHeader.TIN
            Get
                Return mTIN
            End Get
            Set(value As String)
                mTIN = value
            End Set
        End Property

        Public Property CancelFlag() As Integer Implements Staging.IStgORHeader.CancelFlag
            Get
                Return mCancelFlag
            End Get
            Set(value As Integer)
                mCancelFlag = value
            End Set
        End Property

        Public Property PrtFlag() As Integer Implements Staging.IStgORHeader.PrtFlag
            Get
                Return mPrtFlag
            End Get
            Set(value As Integer)
                mPrtFlag = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pORNmbr As Long, ByVal pEmplCode As String, ByVal pORDate As Date,
                ByVal pRemarks As String, ByVal pTotalAmt As Decimal, ByVal pChkAmt As Decimal,
                ByVal pPayType As String, ByVal pCurrType As String, ByVal pSrcBrnch As Long,
                ByVal pPayrID As Long, ByVal pPayor As String, ByVal pAcct As String,
                ByVal pGLCode As String, ByVal pAddr As String, ByVal pTIN As String,
                ByVal pCancelFlag As Integer, ByVal pPrtFlag As Integer)
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
        End Sub

        Sub New(ByVal pObject As Working.BSiteORHeader)
            With pObject
                ORNmbr = .ORNmbr
                EmplCode = .EmplCode
                ORDate = .ORDate
                Remarks = .Remarks
                TotalAmt = .TotalAmt
                ChkAmt = .ChkAmt
                PayType = .PayType
                CurrType = .CurrType
                SrcBrnch = .SrcBrnch
                PayrID = .PayrID
                Payor = .Payor
                Acct = .Acct.Substring(0, .Acct.IndexOf(" ", .Acct.IndexOf(" ") + 1))
                GLCode = .GLCode
                Addr = .Addr
                TIN = .TIN
                CancelFlag = .CancelFlag
                PrtFlag = .PrtFlag
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Sub GetStgORHeader(ByVal pDocNumber As Long)

            Dim objDAL As New dalStaging.DStgORHeader
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetStgORHeader(pDocNumber)
                With drLocal
                    While .Read
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
                Dim objDAL As New dalStaging.DStgORHeader
                objDAL.AlterStgORHeader(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

