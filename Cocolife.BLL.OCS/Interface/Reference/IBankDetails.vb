#Region "Description"
' PAGE NAME     :   Bank Details BLL Interface 
' CREATED BY    :   IBP
' CREATED DATE  :   02/23/17
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Reference

    Public Interface IBankDetails

#Region "Variables"

#End Region

#Region "Properties"

#End Region

#Region "Single Point Functions"
        Function LoadBankDetails(pSiteCode As Long) As DataTable
        Function LoadBankList() As DataTable
#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region


    End Interface

End Namespace