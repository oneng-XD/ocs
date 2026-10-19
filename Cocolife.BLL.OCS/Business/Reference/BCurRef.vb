#Region "Description"
' PAGE NAME     : CURREF BLL
' CREATED BY    : MPRO
' CREATED DATE  : 03/27/2015
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

    Public Class BCurRef

#Region "Implements"
        Implements Reference.ICurRef
#End Region

#Region "Variables"
        Private mCurCod As String = cDataType.fString.Empty
        Private mCurNam As String = cDataType.fString.Empty
        Private mCurUni As String = cDataType.fString.Empty
        Private mCurDes As String = cDataType.fString.Empty
        Private mCurSym As String = cDataType.fString.Empty
        Private mCurDsy As String = cDataType.fString.Empty
#End Region

#Region "Properties"

        Public Property CurCod() As String Implements Reference.ICurRef.CurCod
            Get
                Return mCurCod
            End Get
            Set(value As String)
                mCurCod = value
            End Set
        End Property

        Public Property CurNam() As String Implements Reference.ICurRef.CurNam
            Get
                Return mCurNam
            End Get
            Set(value As String)
                mCurNam = value
            End Set
        End Property

        Public Property CurUni() As String Implements Reference.ICurRef.CurUni
            Get
                Return mCurUni
            End Get
            Set(value As String)
                mCurUni = value
            End Set
        End Property

        Public Property CurDes() As String Implements Reference.ICurRef.CurDes
            Get
                Return mCurDes
            End Get
            Set(value As String)
                mCurDes = value
            End Set
        End Property

        Public Property CurSym() As String Implements Reference.ICurRef.CurSym
            Get
                Return mCurSym
            End Get
            Set(value As String)
                mCurSym = value
            End Set
        End Property

        Public Property CurDsy() As String Implements Reference.ICurRef.CurDsy
            Get
                Return mCurDsy
            End Get
            Set(value As String)
                mCurDsy = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pCurCod As String, ByVal pCurNam As String, ByVal pCurUni As String,
                ByVal pCurDes As String, ByVal pCurSym As String, ByVal pCurDsy As String)
            CurCod = pCurCod
            CurNam = pCurNam
            CurUni = pCurUni
            CurDes = pCurDes
            CurSym = pCurSym
            CurDsy = pCurDsy
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetRefCurRefList() As DataTable Implements Reference.ICurRef.GetRefCurRefList

            Try

                Dim objDAL As New dalReference.DCurRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefCurRefList
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
