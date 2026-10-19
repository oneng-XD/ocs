#Region "Description"
' PAGE NAME     : FRQPAY BLL   
' CREATED BY    : MPRO
' CREATED DATE  : 03/27/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BFrqPay

#Region "Implements"
        Implements Reference.IFrqPay
#End Region

#Region "Variables"
        Private mFrqCod As Integer = cDataType.fInteger.Empty
        Private mFrqDes As String = cDataType.fString.Empty
        Private mFrqPre As Decimal = cDataType.fDecimal.Empty
        Private mFrqFee As Decimal = cDataType.fDecimal.Empty
        Private mFrqTol As Decimal = cDataType.fDecimal.Empty
        Private mVolDis As Decimal = cDataType.fDecimal.Empty
#End Region

#Region "Properties"

        Public Property FrqCod() As Integer Implements Reference.IFrqPay.FrqCod
            Get
                Return mFrqCod
            End Get
            Set(value As Integer)
                mFrqCod = value
            End Set
        End Property

        Public Property FrqDes() As String Implements Reference.IFrqPay.FrqDes
            Get
                Return mFrqDes
            End Get
            Set(value As String)
                mFrqDes = value
            End Set
        End Property

        Public Property FrqPre() As Decimal Implements Reference.IFrqPay.FrqPre
            Get
                Return mFrqPre
            End Get
            Set(value As Decimal)
                mFrqPre = value
            End Set
        End Property

        Public Property FrqFee() As Decimal Implements Reference.IFrqPay.FrqFee
            Get
                Return mFrqFee
            End Get
            Set(value As Decimal)
                mFrqFee = value
            End Set
        End Property

        Public Property FrqTol() As Decimal Implements Reference.IFrqPay.FrqTol
            Get
                Return mFrqTol
            End Get
            Set(value As Decimal)
                mFrqTol = value
            End Set
        End Property

        Public Property VolDis() As Decimal Implements Reference.IFrqPay.VolDis
            Get
                Return mVolDis
            End Get
            Set(value As Decimal)
                mVolDis = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetRefFrqPayList() As DataTable Implements Reference.IFrqPay.GetRefFrqPayList

            Try

                Dim objDAL As New dalReference.DFrqPay
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefFrqPayList
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace


