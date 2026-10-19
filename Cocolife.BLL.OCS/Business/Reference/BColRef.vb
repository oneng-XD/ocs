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

    Public Class BColRef

#Region "Implements"
        Implements Reference.IColRef
#End Region

#Region "Variables"
        Private mColRef As String = cDataType.fString.Empty
        Private mColDes As String = cDataType.fString.Empty
        Private mPctRef As String = cDataType.fString.Empty
        Private mVatable As String = cDataType.fString.Empty
        Private mORType As String = cDataType.fString.Empty
#End Region

#Region "Properties"

        Public Property ColDes As String Implements IColRef.ColDes
            Get
                Return mColDes
            End Get
            Set(value As String)
                mColDes = value
            End Set
        End Property

        Public Property ColRef As String Implements IColRef.ColRef
            Get
                Return mColRef
            End Get
            Set(value As String)
                mColRef = value
            End Set
        End Property

        Public Property PctRef As String Implements IColRef.PctRef
            Get
                Return mPctRef
            End Get
            Set(value As String)
                mPctRef = value
            End Set
        End Property

        Public Property Vatable As String Implements IColRef.Vatable
            Get
                Return mVatable
            End Get
            Set(value As String)
                mVatable = value
            End Set
        End Property

        Public Property ORType() As String Implements IColRef.ORType
            Get
                Return mORType
            End Get
            Set(ByVal value As String)
                mORType = value
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

        Public Function GetRefColRefList(Optional ByVal pPolMod As String = Nothing) As DataTable Implements IColRef.GetRefColRefList

            Try

                Dim objDAL As New dalReference.DColRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefColRefList(pPolMod)
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

