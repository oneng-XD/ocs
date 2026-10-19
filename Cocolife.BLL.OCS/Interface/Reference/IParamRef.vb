#Region "Description"
' PAGE NAME     : PARAMREF Interface 
' CREATED BY    : MPRO
' CREATED DATE  : 03/26/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Reference

    Public Interface IParamRef

#Region "Variables"

#End Region

#Region "Properties"
        Property Para As String             ' 
        Property Code As String             ' 
        Property NumCode As Decimal          ' 
        Property Descrp As String           ' 
        Property Sdate As date          ' 
        Property Edate As date          ' 
        Property CrtDt As date          ' 
        Property UsrID As String            ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Function GetRefOcsDtl() As DataTable
        Function GetRefGpaAsd() As DataTable
        Function GetRefADVDEF() As DataTable
        Function GetRefPAYTYP() As DataTable
        Function GetRefECASH() As DataTable
        Function GetRefDcrType() As DataTable
        Function GetRefRecordType() As DataTable
        Function GetRefPAYTYP_ROP() As DataTable
        Function GetRefPRSTIT() As DataTable
        Function GetRefRATIND() As DataTable
        Function GetRefRECURRINGTYPE() As DataTable
        Function GetRefSETTLE() As DataTable
        Function GetRefTERMINALUSE() As DataTable
        Function GetRefTRNTYP() As DataTable
        Function GetRefTRNTYP_TAGGING() As DataTable
        Function GetRefTAGGING_STATUS() As DataTable
        Function GetRefTRNTYP_ROP() As DataTable
        Function GetRefPOLTYP() As DataTable
        Function GetRefGPATYPE() As DataTable
        Function GetRefARCANCEL() As DataTable
        Function GetRefBillType() As DataTable
        Function GetRefBatchDetails() As DataTable
        Function GetRefBatchNonPrem() As DataTable
        Function GetRefOcsTerminalUseCCA() As DataTable
        Function GetRefOcsTerminalUseDCA() As DataTable
        Function GetRefOcsBankNetwork() As DataTable
        Function GetRefOcsAccountType() As DataTable
#End Region

    End Interface

End Namespace


