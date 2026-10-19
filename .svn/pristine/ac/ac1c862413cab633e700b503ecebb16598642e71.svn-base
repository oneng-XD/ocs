#Region "Description"
' PAGE NAME     : STG_OPRDTL BLL
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

    Public Class BStgOPRDtl

#Region "Implements"
        Implements Staging.IStgOPRDtl
#End Region

#Region "Variables"
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mTrnxCode As Long = cDataType.fLong.Empty
        Private mActType As String = cDataType.fString.Empty
        Private mTrnxDesc As String = cDataType.fString.Empty
        Private mDueDate As Date = cDataType.fDate.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Long = cDataType.fLong.Empty
#End Region

#Region "Properties"

        Public Property OPRNmbr() As Long Implements Staging.IStgOPRDtl.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property TrnxCode() As Long Implements Staging.IStgOPRDtl.TrnxCode
            Get
                Return mTrnxCode
            End Get
            Set(value As Long)
                mTrnxCode = value
            End Set
        End Property

        Public Property ActType() As String Implements Staging.IStgOPRDtl.ActType
            Get
                Return mActType
            End Get
            Set(value As String)
                mActType = value
            End Set
        End Property

        Public Property TrnxDesc() As String Implements Staging.IStgOPRDtl.TrnxDesc
            Get
                Return mTrnxDesc
            End Get
            Set(value As String)
                mTrnxDesc = value
            End Set
        End Property

        Public Property DueDate() As Date Implements Staging.IStgOPRDtl.DueDate
            Get
                Return mDueDate
            End Get
            Set(value As Date)
                mDueDate = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgOPRDtl.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Long Implements Staging.IStgOPRDtl.LineNmbr
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

        Sub New(ByVal pOPRNmbr As Long, ByVal pTrnxCode As Long, ByVal pActType As String,
                ByVal pTrnxDesc As String, ByVal pDueDate As Date, ByVal pAmount As Decimal,
                ByVal pLineNmbr As Long)
            OPRNmbr = pOPRNmbr
            TrnxCode = pTrnxCode
            ActType = pActType
            TrnxDesc = pTrnxDesc
            DueDate = pDueDate
            Amount = pAmount
            LineNmbr = pLineNmbr
        End Sub

        Sub New(ByVal pObject As Working.BSiteOPRDtl)
            With pObject
                OPRNmbr = .OPRNmbr
                TrnxCode = .TrnxCode
                ActType = .ActType
                TrnxDesc = .TrnxDesc
                DueDate = .DueDate
                Amount = .Amount
                LineNmbr = .LineNmbr
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetStgOPRDtlDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgOPRDtl
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgOPRDtl(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgOPRDtl
                objDAL.AlterStgOPRDtl(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
