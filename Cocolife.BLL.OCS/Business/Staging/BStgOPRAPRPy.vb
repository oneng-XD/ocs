#Region "Description"
' PAGE NAME     : STG_OPRAPRPY BLL
' CREATED BY    : MPRO
' CREATED DATE  : 04/27/2015
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

    Public Class BStgOPRAPRPy

#Region "Implements"
        Implements Staging.IStgOPRAPRPy
#End Region

#Region "Variables"
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mAPRNmbr As Long = cDataType.fLong.Empty
        Private mAPRDate As DateTime = cDataType.fDate.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Integer = cDataType.fInteger.Empty
#End Region

#Region "Properties"

        Public Property OPRNmbr() As Long Implements Staging.IStgOPRAPRPy.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property APRNmbr() As Long Implements Staging.IStgOPRAPRPy.APRNmbr
            Get
                Return mAPRNmbr
            End Get
            Set(value As Long)
                mAPRNmbr = value
            End Set
        End Property

        Public Property APRDate() As DateTime Implements Staging.IStgOPRAPRPy.APRDate
            Get
                Return mAPRDate
            End Get
            Set(value As DateTime)
                mAPRDate = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgOPRAPRPy.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Integer Implements Staging.IStgOPRAPRPy.LineNmbr
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

        Sub New(ByVal pOPRNmbr As Long, ByVal pAPRNmbr As Long, ByVal pAPRDate As DateTime,
                ByVal pAmount As Decimal, ByVal pLineNmbr As Integer)
            OPRNmbr = pOPRNmbr
            APRNmbr = pAPRNmbr
            APRDate = pAPRDate
            Amount = pAmount
            LineNmbr = pLineNmbr
        End Sub

        Sub New(ByVal pObject As Working.BSiteOPRAPRPy)
            With pObject
                OPRNmbr = .OPRNmbr
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

        Public Sub GetStgOPRAPRPy(ByVal pDocNumber As Long)
            Dim objDal As New dalStaging.DStgOPRAPRPy
            Dim drLocal As OracleDataReader

            Try
                drLocal = objDal.GetStgOPRAprpy(pDocNumber)

                With drLocal
                    While .Read
                        OPRNmbr = cDataType.fLong.IfNull(.Item("opr_nmbr"))
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
                Dim objDAL As New dalStaging.DStgOPRAPRPy
                objDAL.AlterStgOPRAPRPy(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
