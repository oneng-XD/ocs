#Region "Description"
' PAGE NAME     :  Non-Premium Related Payment BLL Interface
' CREATED BY    :  IBP
' CREATED DATE  :  1/19/2017
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface IPaymentNonPremiumRelated

#Region "Variables"

#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SiteCode() As String
        Property UserID() As Long
        Property ReservedReceiptNumber() As Long
        ' ------------------------------------------------------------------------------- 
        Property StgORHeader() As Staging.BStgORHeader
        Property StgORVAT() As Staging.BStgORVAT
        Property StgORDtl() As IList(Of Staging.BStgORDtl)
        Property StgORAPRPay() As IList(Of Staging.BStgORAPRPay)
        Property StgORChkPay() As IList(Of Staging.BStgORChkPay)
        Property StgTmpTrn() As IList(Of Staging.BStgTmpTrn)
        Property StgORPart() As IList(Of Staging.BStgORPart)
        ' ------------------------------------------------------------------------------- 
        Property SiteORHeader() As Working.BSiteORHeader
        Property SiteORVAT() As Working.BSiteORVAT
        Property SiteORDtl() As IList(Of Working.BSiteORDtl)
        Property SiteORAPRPay() As IList(Of Working.BSiteORAPRPay)
        Property SiteORChkPay() As IList(Of Working.BSiteORChkPay)
        Property SiteTmpTrn() As IList(Of Working.BSiteTmpTrn)
        Property SiteORColDtl() As IList(Of Working.BSiteORColDtl)
        Property SiteORPart() As IList(Of Working.BSiteORPart)
        Property SiteRcptCtr() As Working.BReceiptCounter
        Property PrsMas() As IList(Of BLL.OCS.Person.BPrsMas)
        ' ------------------------------------------------------------------------------- 
        Property IsAprTag() As Boolean
        Property IsColumbary() As Boolean
        Property lstForDeletion() As IList(Of Object)



#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub ProcessPaymentNonPremiumRelated()
        Sub CopyToStgObjects()
        Sub PostPaymentNonPremiumRelated()
        Sub CancelPaymentNonPremiumRelated()
#End Region

    End Interface

End Namespace

