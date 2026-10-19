#Region "Description"
' PAGE NAME     :  
' CREATED BY    : 
' CREATED DATE  : 
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BTrnRef

#Region "Implements"
        Implements Reference.ITrnRef
#End Region

#Region "Variables"
        Private mColref As String = cDataType.fString.Empty
        Private mPctref As String = cDataType.fString.Empty
        Private mColdes As String = cDataType.fString.Empty
        Private mCash_flg As Byte = cDataType.fInteger.Empty
        Private mChk_flg As Byte = cDataType.fInteger.Empty
        Private mCca_flg As Byte = cDataType.fInteger.Empty
        Private mDca_flg As Byte = cDataType.fInteger.Empty
        Private mTrntyp_flg As Byte = cDataType.fInteger.Empty
        Private mPoltyp_flg As String = cDataType.fString.Empty
        Private mVatable As String = cDataType.fString.Empty
        Private mDoctyp As String = cDataType.fString.Empty
#End Region

#Region "Properties"

        Public Property Colref As String Implements ITrnRef.Colref
            Get
                Return mColref
            End Get
            Set(value As String)
                mColref = value
            End Set
        End Property

        Public Property Pctref As String Implements ITrnRef.Pctref
            Get
                Return mPctref
            End Get
            Set(value As String)
                mPctref = value
            End Set
        End Property

        Public Property Coldes As String Implements ITrnRef.Coldes
            Get
                Return mColdes
            End Get
            Set(value As String)
                mColdes = value
            End Set
        End Property

        Public Property Cash_flg As Byte Implements ITrnRef.Cash_flg
            Get
                Return mCash_flg
            End Get
            Set(value As Byte)
                mCash_flg = value
            End Set
        End Property

        Public Property Chk_flg As Byte Implements ITrnRef.Chk_flg
            Get
                Return mChk_flg
            End Get
            Set(value As Byte)
                mChk_flg = value
            End Set
        End Property

        Public Property Cca_flg As Byte Implements ITrnRef.Cca_flg
            Get
                Return mCca_flg
            End Get
            Set(value As Byte)
                mCca_flg = value
            End Set
        End Property

        Public Property Dca_flg As Byte Implements ITrnRef.Dca_flg
            Get
                Return mDca_flg
            End Get
            Set(value As Byte)
                mDca_flg = value
            End Set
        End Property

        Public Property Trntyp_flg As Byte Implements ITrnRef.Trntyp_flg
            Get
                Return mTrntyp_flg
            End Get
            Set(value As Byte)
                mTrntyp_flg = value
            End Set
        End Property

        Public Property Poltyp_flg As String Implements ITrnRef.Poltyp_flg
            Get
                Return mPoltyp_flg
            End Get
            Set(value As String)
                mPoltyp_flg = value
            End Set
        End Property

        Public Property Vatable As String Implements ITrnRef.Vatable
            Get
                Return mVatable
            End Get
            Set(value As String)
                mVatable = value
            End Set
        End Property

        Public Property Doctyp As String Implements ITrnRef.Doctyp
            Get
                Return mDoctyp
            End Get
            Set(value As String)
                mDoctyp = value
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

  Public Function IsValidTransactionCode(ByVal pPolNum As String, ByVal pAcType As String, Optional ByVal pAcType2 As String = Nothing, Optional ByVal pAcType3 As String = Nothing) As String Implements ITrnRef.IsValidTransactionCode

            Try

                Dim objDAL As New dalReference.DTrnRef
                Dim dtLocal As String

                dtLocal = objDAL.IsValidTransactionCode(pPolNum, pAcType, pAcType2, pAcType3)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Data Retrieval"

        Public Function GetRefTrnRefList(ByVal pPayTyp As String, ByVal pTrnTyp As Integer, ByVal pPolTyp As String, ByVal pDocTyp As String) As DataTable Implements ITrnRef.GetRefTrnRefList

            Try

                Dim objDAL As New dalReference.DTrnRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefTrnRefList(pPayTyp, pTrnTyp, pPolTyp, pDocTyp)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Sub GetReceiptTransactionDetails(ByVal pReceiptCode As String, ByVal pDocTyp As String) Implements ITrnRef.GetReceiptTransactionDetails

            Try

                Dim objDal As New dalReference.DTrnRef
                Dim drLocal As OracleDataReader

                drLocal = objDal.GetReceiptTransactionDetails(pReceiptCode) ', pDocTyp)
                With drLocal
                    While .Read
                        Pctref = cDataType.fString.IfNull(.Item("Pctref"))
                        Coldes = cDataType.fString.IfNull(.Item("Coldes"))
                        Vatable = cDataType.fString.IfNull(.Item("Vatable"))
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try

        End Sub


        Public Function GetTrnTyp(ByVal pDocTyp As String, ByVal pTrnDesc As String) As DataTable Implements ITrnRef.GetTrnTyp

            Try

                Dim objDAL As New dalReference.DTrnRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetTrnTyp(pDocTyp, pTrnDesc)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetVlTopupLimit(ByVal pPolicyNumber As String, ByVal pDate As Date) As DataTable Implements ITrnRef.GetVlTopupLimit

            Try

                Dim objDAL As New dalReference.DTrnRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetVlTopupLimit(pPolicyNumber, pDate)
                Return dtLocal

            Catch ex As Exception

            End Try
        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace

