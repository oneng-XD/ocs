#Region "Description"
' PAGE NAME     : STG_OPRCHKPY BLL
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

    Public Class BStgOPRChkPy

#Region "Implements"
        Implements Staging.IStgOPRChkPy
#End Region

#Region "Variables"
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mChkNmbr As Long = cDataType.fLong.Empty
        Private mBank As String = cDataType.fString.Empty
        Private mBranch As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Integer = cDataType.fInteger.Empty
        Private mOTCFlag As Integer = cDataType.fInteger.Empty
#End Region

#Region "Properties"

        Public Property OPRNmbr() As Long Implements Staging.IStgOPRChkPy.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property ChkNmbr() As Long Implements Staging.IStgOPRChkPy.ChkNmbr
            Get
                Return mChkNmbr
            End Get
            Set(value As Long)
                mChkNmbr = value
            End Set
        End Property

        Public Property Bank() As String Implements Staging.IStgOPRChkPy.Bank
            Get
                Return mBank
            End Get
            Set(value As String)
                mBank = value
            End Set
        End Property

        Public Property Branch() As String Implements Staging.IStgOPRChkPy.Branch
            Get
                Return mBranch
            End Get
            Set(value As String)
                mBranch = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgOPRChkPy.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Integer Implements Staging.IStgOPRChkPy.LineNmbr
            Get
                Return mLineNmbr
            End Get
            Set(value As Integer)
                mLineNmbr = value
            End Set
        End Property

        Public Property OTCFlag() As Integer Implements Staging.IStgOPRChkPy.OTCFlag
            Get
                Return mOTCFlag
            End Get
            Set(value As Integer)
                mOTCFlag = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pOPRNmbr As Long, ByVal pChkNmbr As Long, ByVal pBank As String,
                ByVal pBranch As String, ByVal pAmount As Decimal, ByVal pLineNmbr As Integer,
                ByVal pOTCFlag As Integer)
            OPRNmbr = pOPRNmbr
            ChkNmbr = pChkNmbr
            Bank = pBank
            Branch = pBranch
            Amount = pAmount
            LineNmbr = pLineNmbr
            OTCFlag = pOTCFlag
        End Sub

        Sub New(ByVal pObject As Working.BSiteOPRChkPy)
            With pObject
                OPRNmbr = .OPRNmbr
                ChkNmbr = .ChkNmbr
                Bank = .Bank
                Branch = .Branch
                Amount = .Amount
                LineNmbr = .LineNmbr
                OTCFlag = .OTCFlag
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetOPRChkPyDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgOPRChkPy
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgOPRChkpy(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgOPRChkPy
                objDAL.AlterSTGOPRChkPy(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

