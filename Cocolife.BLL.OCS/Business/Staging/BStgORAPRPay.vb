#Region "Description"
' PAGE NAME     : STG_ORAPRPAY BLL
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

    Public Class BStgORAPRPay

#Region "Implements"
        Implements Staging.IStgORAPRPay
#End Region

#Region "Variables"
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mAPRNmbr As Long = cDataType.fLong.Empty
        Private mAPRDate As Date = cDataType.fDate.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Integer = cDataType.fInteger.Empty
#End Region

#Region "Properties"

        Public Property ORNmbr() As Long Implements Staging.IStgORAPRPay.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property APRNmbr() As Long Implements Staging.IStgORAPRPay.APRNmbr
            Get
                Return mAPRNmbr
            End Get
            Set(value As Long)
                mAPRNmbr = value
            End Set
        End Property

        Public Property APRDate() As Date Implements Staging.IStgORAPRPay.APRDate
            Get
                Return mAPRDate
            End Get
            Set(value As Date)
                mAPRDate = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgORAPRPay.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Integer Implements Staging.IStgORAPRPay.LineNmbr
            Get
                Return mLineNmbr
            End Get
            Set(value As Integer)
                mLineNmbr = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pORNmbr As Long, ByVal pAPRNmbr As Long, ByVal pAPRDate As Date,
                ByVal pAmount As Decimal, ByVal pLineNmbr As Integer)
            ORNmbr = pORNmbr
            APRNmbr = pAPRNmbr
            APRDate = pAPRDate
            Amount = pAmount
            LineNmbr = pLineNmbr
        End Sub

        Sub New(ByVal pObject As Working.BSiteORAPRPay)
            With pObject
                ORNmbr = .ORNmbr
                APRNmbr = .APRNmbr
                APRDate = .APRDate
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

        Public Sub GetStgORAPRPay(ByVal pDocNumber As Long)
            Dim objDal As New dalStaging.DStgORAPRPay
            Dim drLocal As OracleDataReader

            Try
                drLocal = objDal.GetStgORAprpy(pDocNumber)

                With drLocal
                    While .Read
                        ORNmbr = cDataType.fLong.IfNull(.Item("or_nmbr"))
                        APRNmbr = cDataType.fLong.IfNull(.Item("apr_nmbr"))
                        APRDate = cDataType.fDate.IfNull(.Item("apr_date"))
                        Amount = cDataType.fDecimal.IfNull(.Item("amount"))
                        LineNmbr = cDataType.fInteger.IfNull(.Item("line_nmbr"))
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
                Dim objDAL As New dalStaging.DStgORAPRPay
                objDAL.AlterStgORAPRPay(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
