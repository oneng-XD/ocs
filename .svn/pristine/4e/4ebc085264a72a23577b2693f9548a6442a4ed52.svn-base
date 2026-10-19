#Region "Description"
' PAGE NAME     : STG_ORPART BLL
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

    Public Class BStgORPart

#Region "Implements"
        Implements Staging.IStgORPart
#End Region

#Region "Variables"
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mParticular As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Integer = cDataType.fInteger.Empty
#End Region

#Region "Properties"

        Public Property ORNmbr() As Long Implements Staging.IStgORPart.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property Particular() As String Implements Staging.IStgORPart.Particular
            Get
                Return mParticular
            End Get
            Set(value As String)
                mParticular = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements Staging.IStgORPart.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Integer Implements Staging.IStgORPart.LineNmbr
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

        Sub New(ByVal pORNmbr As Long, ByVal pParticular As String, ByVal pAmount As Decimal,
                ByVal pLineNmbr As Integer)
            ORNmbr = pORNmbr
            Particular = pParticular
            Amount = pAmount
            LineNmbr = pLineNmbr
        End Sub

        Sub New(ByVal pObject As Working.BSiteORPart)
            With pObject
                ORNmbr = .ORNmbr
                Particular = .Particular
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

        Public Function GetStgORPart(ByVal pDocNumber As Long) As DataTable

            Dim objDAL As New dalStaging.DStgORPart
            Dim dtLocal As DataTable

            Try

                dtLocal = objDAL.GetStgORPart(pDocNumber)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try
        End Function


#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgORPart
                objDAL.AlterStgORPart(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
