#Region "Description"
' PAGE NAME     : Payment Premium Related Interface
' CREATED BY    : MPRO 
' CREATED DATE  : 03/26/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Payment

    Public Interface IPaymentPremiumRelated
        Inherits IPolicyDetails, 
            IAgentDetails, 
            IPayorDetails, 
            IInsuredDetails, 
            IGpaDetails, 
            IHMOPayslip, 
            INGIPolicyBilling, 
            IReceiptDetails, 
            IChkDetails, 
            ICcaDetails, 
            IDcaDetails, 
            IEPayDetails, 
            IAprDetails, 
            IVatDetails


#Region "Variables"

#End Region

#Region "Properties"

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property DocType As String
        Property ReceiptByCode As String
        Property ReceiptById As Long
        Property DocPrinted As Boolean
        Property DocSaveState As Integer
        Property IsSuccessful As Boolean
        Property ECRNumber As Long
        Property ECRDate As Date
        Property OPRNumber As Long
        Property OPRDate As Date
        Property ViewOprFrom As Date
        Property ViewOprTo As Date
        Property ViewOprDocNumber As Long
        Property ViewOprPolicyNumber As String
        Property ViewOprPayorName As String
        Property ViewOprInsuredName As String
        Property IsSourceSiteLocked As Boolean
        Property SourceSite As String
        Property TransactionType As String
        Property OPRPaymentType As String
        Property IsGrossAmountLocked As Boolean
        Property OPRGrossAmount As Decimal
        Property OPRCurrency As String
        Property OPRCashAmount As Decimal
        Property WithAPR As Boolean
        Property WithCommission As Boolean
        Property BalanceToHigher As Boolean
        Property OPRRemarks As String
        ReadOnly Property OPRFlags As String
        Property GroupTag As Boolean
        Property NewBusinessTag As Boolean
        Property NewgenNewBusinessTag As Boolean
        Property WithNewBiz As Boolean
        Property AgentSearchTag As Integer
        ReadOnly Property NewPremium As Decimal
        Property NewPolFrq As Integer
        WriteOnly Property CallLoadAgent As Boolean
        ' -------------------------------------------------------------------------------
        Property NewBizID As String
        Property NewBizInsId As Long
        Property NewBizPayId As Long
        Property NewBizName As String
        'Property NewBizInsName As String
        Property NewBizApplNo As Long
        Property NewBizLastName As String
        Property NewBizFirstName As String
        Property NewBizMiddleName As String
        Property NewBizSuffix As String
        Property NewBizTitle As String
        Property NewBizSex As String
        Property NewBizPlaceOfBirth As String
        Property NewBizDoB As Date
        Property NewBizEcrNumber As Long
        Property NewBizEcrDate As Date
        Property NewBizAmount As Decimal
        Property lstNewBiz As List(Of cNewBiz)
        Property NewBizTotalAmount As Decimal
        Property IsNewBizSuccessful As Boolean
        ' -------------------------------------------------------------------------------
        Property PayslipCodeTag As Boolean
        Property BillNoTag As Boolean
        Property PaymentTypeTag As Boolean
        Property PolicyInfoTag As Boolean
        Property OPRDetailTag As Boolean
        Property OPRVatTag As Boolean

        Property CashPaymentTag As Boolean
        Property CashTotalAmount As Decimal
        Property CommissionAmount As Decimal
        Property lstPaymentTypeDetails As List(Of cPaymentType)
        Property IsPayTypeSuccessful As Boolean
        Property PaymentTypeID As String
        Property PrevPayType As String
        Property PaymentTypeAllowedArray As String
        ReadOnly Property PaymentTotalAmount As Decimal
        ' -------------------------------------------------------------------------------
        'WriteOnly Property CancelOPR As Boolean
        'WriteOnly Property PrintOPR As Boolean
        'WriteOnly Property ViewOPR As Boolean
        ' -------------------------------------------------------------------------------
        'Property dtBusinessType As DataTable
        WriteOnly Property dtViewAppNo As DataTable
        WriteOnly Property dtViewOPR As DataTable
        WriteOnly Property dtSourceSite As DataTable
        WriteOnly Property dtCurrency As DataTable
        WriteOnly Property dtFrequencyOfPayment As DataTable
        WriteOnly Property dtBusinessType As DataTable
        WriteOnly Property dtPaymentType As DataTable
        WriteOnly Property dtTransactionType As DataTable
        WriteOnly Property dtPolicyType As DataTable
        WriteOnly Property dtGpaType As DataTable
        WriteOnly Property dtInsuredType As DataTable
        WriteOnly Property dtPayorType As DataTable
        WriteOnly Property dtPersonTitle As DataTable
        'WriteOnly Property dtTerminalUseCCA As DataTable
        'WriteOnly Property dtTerminalUseDCA As DataTable
        WriteOnly Property dtBalanceToHigher As DataTable
        WriteOnly Property dtBalanceFrequency As DataTable
#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenBalanceToHigher As EventHandler(Of EventArgs)
        Event ClearScreenNewBusiness As EventHandler(Of EventArgs)
        Event ClearScreenNewBiz As EventHandler(Of EventArgs)
        Event ClearScreenNewBizPayor As EventHandler(Of EventArgs)
        Event ClearScreenPaymentDetails As EventHandler(Of EventArgs)
        Event ClearScreenCashDetails As EventHandler(Of EventArgs)
        Event ClearScreenPaymentTypeDetails As EventHandler(Of EventArgs)
        Event ClearScreenViewAppNo As EventHandler(Of EventArgs)
        Event ClearScreenViewOPR As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadViewAppNo As EventHandler(Of EventArgs)
        Event LoadViewOPR As EventHandler(Of EventArgs)
        Event LoadSourceSite As EventHandler(Of EventArgs)
        Event LoadCurrency As EventHandler(Of EventArgs)
        Event LoadPersonType As EventHandler(Of EventArgs)
        Event LoadPersonTitle As EventHandler(Of EventArgs)
        Event LoadFrequencyOfPayment As EventHandler(Of EventArgs)
        Event LoadBusinessType As EventHandler(Of EventArgs)
        Event LoadAllowedPaymentType As EventHandler(Of EventArgs)
        Event LoadPaymentType As EventHandler(Of EventArgs)
        Event LoadTransactionType As EventHandler(Of EventArgs)
        Event LoadPolicyType As EventHandler(Of EventArgs)
        Event LoadGpaType As EventHandler(Of EventArgs)
        Event LoadGpaPolicy As EventHandler(Of EventArgs)
        Event LoadGpaSettings As EventHandler(Of EventArgs)
        Event LoadGpaRenewalAsd As EventHandler(Of EventArgs)
        Event LoadPremiumBreakdown As EventHandler(Of EventArgs)
        Event LoadNewFrequency As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event SetSamePayorInsured As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event AddCashPayment As EventHandler(Of EventArgs)
        Event AddPaymentTypeDetails As EventHandler(Of EventArgs)
        Event DeletePaymentTypeDetails As EventHandler(Of EventArgs)
        Event GetPaymentTypeDetails As EventHandler(Of EventArgs)
        ' -------------------------------------------------------------------------------
        Event AddNewBizPayor As EventHandler(Of EventArgs)
        Event AddNewBiz As EventHandler(Of EventArgs)
        Event DeleteNewBiz As EventHandler(Of EventArgs)
        Event GetNewBiz As EventHandler(Of EventArgs)
        ' -------------------------------------------------------------------------------
        Event LoadApplicationNo As EventHandler(Of EventArgs)
        Event LoadNewOPR As EventHandler(Of EventArgs)
        Event LoadOPR As EventHandler(Of EventArgs)
        Event CheckPrevPayType As EventHandler(Of EventArgs)
        Event CheckAllowedPaytype As EventHandler(Of EventArgs)
        Event CheckModalPremium As EventHandler(Of EventArgs)
        Event CheckGrossAmount As EventHandler(Of EventArgs)
        Event CheckSourceSite As EventHandler(Of EventArgs)
        Event ProcessPaymentPremium As EventHandler(Of EventArgs)
        Event ConfirmCancel As EventHandler(Of EventArgs)
        Event ConfirmSave As EventHandler(Of EventArgs)
        Event ConfirmPrint As EventHandler(Of EventArgs)
        Event GenerateReport As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub radSelectAppNo(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectOpr(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectPayTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectOPRDetails(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectNewBiz(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Interface

End Namespace

