#Region "Description"
' PAGE NAME     : SEARCH BLL
' CREATED BY    : EJ
' CREATED DATE  : 08/26/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalSearch = Cocolife.DAL.OCS.Search
#End Region

Namespace Search

    Public Class BSearch

#Region "Implements"
        Implements Search.ISearch
#End Region

#Region "Variables"
        Private mPolNum As String = cDataType.fString.Empty
        Private mInsNme As String = cDataType.fString.Empty
        Private mPayNme As String = cDataType.fString.Empty
        ' ------------------------------------------------------------------------------- 
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"

        Public Property PolNum() As String Implements Search.ISearch.PolNum
            Get
                Return mPolNum
            End Get
            Set(ByVal value As String)
                mPolNum = value
            End Set
        End Property

        Public Property InsNme() As String Implements Search.ISearch.InsNme
            Get
                Return mPolNum
            End Get
            Set(ByVal value As String)
                mPolNum = value
            End Set
        End Property

        Public Property PayNme() As String Implements Search.ISearch.PayNme
            Get
                Return mPolNum
            End Get
            Set(ByVal value As String)
                mPolNum = value
            End Set
        End Property

        ' ------------------------------------------------------------------------------- 

        Public Property IsRecordExist() As Boolean Implements Search.ISearch.IsRecordExist
            Get
                Return mIsRecordExist
            End Get
            Set(ByVal value As Boolean)
                mIsRecordExist = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

#End Region

#Region "Single Point Functions"
        Public Function GetPolicy(ByVal pPolNum As String, ByVal pPolType As String) As DataTable Implements Search.ISearch.GetPolicyDetails
            Dim objDAL As New dalSearch.DSearch
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetPolicyDetail(pPolNum, pPolType)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GetNBPolicyNewgen(ByVal pPolNo As String, ByVal pApplicationNo As String) As DataTable Implements Search.ISearch.GetNBPolicyNewgen
            Dim objDAL As New dalSearch.DSearch
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetNBPolicyNewgen(pPolNo, pApplicationNo)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function IsVlPlanRegular(ByVal pPolNum As String) As Boolean
            Dim objDal As New dalSearch.DSearch

            Try
                Return objDal.IsVlPlanRegular(pPolNum)
            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function SearchPolicy(ByVal pPolNum As String, ByVal pInsNme As String, ByVal pPayNme As String, ByVal pPolTyp As String) As DataTable Implements Search.ISearch.SearchPolicy

            Dim objDAL As New dalSearch.DSearch
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.SearchPolicy(pPolNum, pInsNme, pPayNme, pPolTyp)
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


