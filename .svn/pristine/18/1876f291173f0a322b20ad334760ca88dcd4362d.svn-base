#Region "Description"
' PAGE NAME     : METPAY BLL   
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
Imports System.Data.OracleClient

#End Region

Namespace Reference

    Public Class BMetPay

#Region "Implements"
        Implements Reference.IMetPay
#End Region

#Region "Variables"
        Private mMetCod As String = cDataType.fString.Empty
        Private mMetDes As String = cDataType.fString.Empty
        Private mMetBil As String = cDataType.fString.Empty
        Private mMetLod As Decimal = cDataType.fDecimal.Empty
        Private mTlrnce As Decimal = cDataType.fDecimal.Empty
        Private mMetAdv As Integer = cDataType.fInteger.Empty
        Private mPlnMet As String = cDataType.fString.Empty
        Private mCurCor As String = cDataType.fString.Empty
#End Region

#Region "Properties"

        Public Property MetCod() As String Implements Reference.IMetPay.MetCod
            Get
                Return mMetCod
            End Get
            Set(value As String)
                mMetCod = value
            End Set
        End Property

        Public Property MetDes() As String Implements Reference.IMetPay.MetDes
            Get
                Return mMetDes
            End Get
            Set(value As String)
                mMetDes = value
            End Set
        End Property

        Public Property MetBil() As String Implements Reference.IMetPay.MetBil
            Get
                Return mMetBil
            End Get
            Set(value As String)
                mMetBil = value
            End Set
        End Property

        Public Property MetLod() As Decimal Implements Reference.IMetPay.MetLod
            Get
                Return mMetLod
            End Get
            Set(value As Decimal)
                mMetLod = value
            End Set
        End Property

        Public Property Tlrnce() As Decimal Implements Reference.IMetPay.Tlrnce
            Get
                Return mTlrnce
            End Get
            Set(value As Decimal)
                mTlrnce = value
            End Set
        End Property

        Public Property MetAdv() As Integer Implements Reference.IMetPay.MetAdv
            Get
                Return mMetAdv
            End Get
            Set(value As Integer)
                mMetAdv = value
            End Set
        End Property

        Public Property PlnMet() As String Implements Reference.IMetPay.PlnMet
            Get
                Return mPlnMet
            End Get
            Set(value As String)
                mPlnMet = value
            End Set
        End Property

        Public Property CurCor() As String Implements Reference.IMetPay.CurCor
            Get
                Return mCurCor
            End Get
            Set(value As String)
                mCurCor = value
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

        Public Function GetRefMetPayList(ByVal pTransactionType As String, ByVal pPolTyp As String, ByVal pDocTyp As String) As DataTable Implements Reference.IMetPay.GetRefMetPayList

            Try

                Dim objDAL As New dalReference.DMetPay
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefMetPayList(pTransactionType, pPolTyp, pDocTyp)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetPolTyp(ByVal pMetCod As String, ByVal pDocTyp As String)
            Dim objDAL As New dalReference.DMetPay
            Dim strPolTyp As String

            Try
                strPolTyp = objDAL.GetPolTyp(pMetCod, pDocTyp)

                Return strPolTyp
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetPType(ByVal pMetCod As String, ByVal pDocTyp As String)
            Dim objDAL As New dalReference.DMetPay
            Dim strPType As String

            Try
                strPType = objDAL.GetPType(pMetCod, pDocTyp)

                Return strPType
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace


