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

#End Region

Namespace Reference

    Public Interface ITrnRef

#Region "Variables"

#End Region

#Region "Properties"
        Property Colref As String
        Property Pctref As String
        Property Coldes As String
        Property Cash_flg As Byte
        Property Chk_flg As Byte
        Property Cca_flg As Byte
        Property Dca_flg As Byte
        Property Trntyp_flg As Byte
        Property Poltyp_flg As String
        Property Vatable As String
        Property Doctyp As String
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"
        Function IsValidTransactionCode(ByVal pPolNum As String, ByVal pAcType As String, Optional ByVal pAcType2 As String = Nothing, Optional ByVal pAcType3 As String = Nothing) As String
#End Region

#Region "Transactions"
        Function GetRefTrnRefList(ByVal pPayTyp As String, ByVal pTrnTyp As Integer, ByVal pPolTyp As String, ByVal pDocTyp As String) As DataTable
        Sub GetReceiptTransactionDetails(ByVal pReceiptCode As String, ByVal pDocTyp As String)
        Function GetTrnTyp(ByVal pDocTyp As String, ByVal pTrnDesc As String) As DataTable
        Function GetVlTopupLimit(ByVal pPolicyNumber As String, ByVal pDate As Date) As DataTable
#End Region

    End Interface

End Namespace

