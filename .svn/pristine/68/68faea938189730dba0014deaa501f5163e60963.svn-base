#Region "Description"
' PAGE NAME     : STG_ORDTL BLL
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

    Public Class BStgORDtl

#Region "Implements"
        Implements Staging.IStgORDtl
#End Region

#Region "Variables"
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mTrnxCode As Long = cDataType.fLong.Empty
        Private mActType As String = cDataType.fString.Empty
        Private mTrnxDesc As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Long = cDataType.fLong.Empty
#End Region

#Region "Properties"

        Public Property ORNmbr() As Long Implements Staging.IStgORDtl.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property TrnxCode() As Long Implements Staging.IStgORDtl.TrnxCode
            Get
                Return mTrnxCode
            End Get
            Set(value As Long)
                mTrnxCode = value
            End Set
        End Property

        Public Property ActType() As String Implements Staging.IStgORDtl.ActType
            Get
                Return mActType
            End Get
            Set(value As String)
                mActType = value
            End Set
        End Property

        Public Property TrnxDesc() As String Implements Staging.IStgORDtl.TrnxDesc
            Get
                Return mTrnxDesc
            End Get
            Set(value As String)
                mTrnxDesc = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgORDtl.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Long Implements Staging.IStgORDtl.LineNmbr
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

        Sub New(ByVal pORNmbr As Long, ByVal pTrnxCode As Long, ByVal pActType As String,
                ByVal pTrnxDesc As String, ByVal pAmount As Decimal, ByVal pLineNmbr As Long)
            ORNmbr = pORNmbr
            TrnxCode = pTrnxCode
            ActType = pActType
            TrnxDesc = pTrnxDesc
            Amount = pAmount
            LineNmbr = pLineNmbr
        End Sub

        Sub New(ByVal pObject As Working.BSiteORDtl)
            With pObject
                ORNmbr = .ORNmbr
                TrnxCode = .TrnxCode
                ActType = .ActType
                TrnxDesc = .TrnxDesc
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

        Public Function GetStgORDtlDt(ByVal pDocNumber As Long) As DataTable
            Try
                Dim objDal As New dalStaging.DStgORDtl
                Dim dtLocal As DataTable

                dtLocal = objDal.GetStgORDtl(pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgORDtl
                objDAL.AlterStgORDtl(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
