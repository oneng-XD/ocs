#Region "Description"
' PAGE NAME     : STG_ORCHKPAY BLL
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

    Public Class BStgORChkPay

#Region "Implements"
        Implements Staging.IStgORChkPay
#End Region

#Region "Variables"
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mChkNmbr As Long = cDataType.fLong.Empty
        Private mBank As String = cDataType.fString.Empty
        Private mBranch As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mOTCFlag As Long = cDataType.fLong.Empty
        Private mLineNmbr As Long = cDataType.fLong.Empty
#End Region

#Region "Properties"

        Public Property ORNmbr() As Long Implements Staging.IStgORChkPay.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property ChkNmbr() As Long Implements Staging.IStgORChkPay.ChkNmbr
            Get
                Return mChkNmbr
            End Get
            Set(value As Long)
                mChkNmbr = value
            End Set
        End Property

        Public Property Bank() As String Implements Staging.IStgORChkPay.Bank
            Get
                Return mBank
            End Get
            Set(value As String)
                mBank = value
            End Set
        End Property

        Public Property Branch() As String Implements Staging.IStgORChkPay.Branch
            Get
                Return mBranch
            End Get
            Set(value As String)
                mBranch = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgORChkPay.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property OTCFlag() As Long Implements Staging.IStgORChkPay.OTCFlag
            Get
                Return mOTCFlag
            End Get
            Set(value As Long)
                mOTCFlag = value
            End Set
        End Property

        Public Property LineNmbr() As Long Implements Staging.IStgORChkPay.LineNmbr
            Get
                Return mLineNmbr
            End Get
            Set(value As Long)
                mLineNmbr = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pORNmbr As Long, ByVal pChkNmbr As Long, ByVal pBank As String,
                ByVal pBranch As String, ByVal pAmount As Decimal, ByVal pOTCFlag As Long,
                ByVal pLineNmbr As Long)
            ORNmbr = pORNmbr
            ChkNmbr = pChkNmbr
            Bank = pBank
            Branch = pBranch
            Amount = pAmount
            OTCFlag = pOTCFlag
            LineNmbr = pLineNmbr
        End Sub

        Sub New(ByVal pObject As Working.BSiteORChkPay)
            With pObject
                ORNmbr = .ORNmbr
                ChkNmbr = .ChkNmbr
                Bank = .Bank
                Branch = .Branch
                Amount = .Amount
                OTCFlag = .OTCFlag
                LineNmbr = .LineNmbr
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetStgORChkPyDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgORChkPay
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgORChkpay(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgORChkPay
                objDAL.AlterStgORChkPay(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
