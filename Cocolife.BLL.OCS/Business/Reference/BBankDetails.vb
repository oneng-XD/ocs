#Region "Description"
' PAGE NAME     :  Bank Details BLL
' CREATED BY    :  IBP
' CREATED DATE  :  02/23/2017
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

    Public Class BBankDetails

#Region "Implements"
        Implements IBankDetails
#End Region

#Region "Variables"

#End Region

#Region "Properties"

#End Region

#Region "Constructor"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function LoadBankDetails(ByVal pSiteCode As Long) As DataTable Implements IBankDetails.LoadBankDetails
            Dim objDAL As New dalReference.DBankDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.LoadBankDetails(pSiteCode)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadBankList() As DataTable Implements IBankDetails.LoadBankList   'ByVal pCurrency As Long
            Dim objDAL As New dalReference.DBankDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.LoadBankList()          'pCurrency
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
