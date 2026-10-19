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

Namespace Payment

    Public Interface IPaymentPremiumRelated

#Region "Variables"
       
#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SiteCode() As Long
        Property UserID() As Long
        Property ReservedReceiptNumber() As Long
        Property SamePayorInsured() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SiteOPRHeader() As Working.BSiteOPRHeader
        Property SiteOPRInfo() As IList(Of Working.BSiteOPRInfo)
        Property SiteOPRVAT() As Working.BSiteOPRVAT
        Property SitePAMaster() As Working.BSitePAMaster
        Property SiteOPRDtl() As IList(Of Working.BSiteOPRDtl)
        Property SiteOPRAPRPy() As IList(Of Working.BSiteOPRAPRPy)
        Property SiteOPRChkPy() As IList(Of Working.BSiteOPRChkPy)
        Property SiteOPRCred() As IList(Of Working.BSiteOPRCred)
        Property SiteOPRDebit() As IList(Of Working.BSiteOPRDebit)
        Property SiteOPRECash() As IList(Of Working.BSiteOPRECash)
        Property SiteTmpTrn() As IList(Of Working.BSiteTmpTrn)
        Property StgOPRHeader() As Staging.BStgOPRHeader
        Property StgOPRInfo() As IList(Of Staging.BStgOPRInfo)
        Property StgOPRVAT() As Staging.BStgOPRVAT
        'Property HMOPayslip() As Reference.BHMOPayslip
        Property NewgenPayment() As Staging.BNewgenLifePayment
        Property StgPAMaster() As Staging.BGpaProcess
        Property StgOPRDtl() As IList(Of Staging.BStgOPRDtl)
        Property StgOPRAPRPy() As IList(Of Staging.BStgOPRAPRPy)
        Property StgOPRChkPy() As IList(Of Staging.BStgOPRChkPy)
        Property StgOPRCred() As IList(Of Staging.BStgOPRCred)
        Property StgOPRDebit() As IList(Of Staging.BStgOPRDebit)
        Property StgTmpTrn() As IList(Of Staging.BStgTmpTrn)
        Property SiteRcptCtr() As Working.BReceiptCounter
        Property PrsMasPayor() As IList(Of BLL.OCS.Person.BPrsMas)
        Property PrsMasInsured() As IList(Of BLL.OCS.Person.BPrsMas)
        ' ------------------------------------------------------------------------------- 
        Property PolMod() As String
        Property IsAprTag() As Boolean
        Property IsGpaTag() As Boolean
        Property IsNewBusinessTag() As Boolean
        Property lstForDeletion() As IList(Of Object)

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub ProcessPaymentPremiumRelated()
        Sub CopyToStgObjects()
        Sub PostPaymentPremiumRelated()
        Sub CancelPaymentPremiumRelated()
#End Region

    End Interface

End Namespace