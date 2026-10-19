#Region "Description"
' PAGE NAME     : PRSREF BLL   
' CREATED BY    : MPRO
' CREATED DATE  : 10/14/2013
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

    Public Class BPrsRef

#Region "Implements"
        Implements Reference.IPrsRef
#End Region

#Region "Variables"

#End Region

#Region "Properties"

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

        Public Function GetRefPrsRefList() As DataTable Implements Reference.IPrsRef.GetRefPrsRefList

            Dim objDAL As New dalReference.DPrsRef
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetRefPrsRefList
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefPrsRefPrsTyp() As DataTable Implements Reference.IPrsRef.GetRefPrsRefPrsTyp

            Dim objDAL As New dalReference.DPrsRef
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetRefPrsRefPrsTyp
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefPrsRefSexTyp() As DataTable Implements Reference.IPrsRef.GetRefPrsRefSexTyp

            Dim objDAL As New dalReference.DPrsRef
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetRefPrsRefSexTyp
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

