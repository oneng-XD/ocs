#Region "Description"
' PAGE NAME     : DB Constant
' CREATED BY    : MPRO
' CREATED DATE  : 11/14/2014
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' EJAC|07/15/2016|Add SPs for Working tables
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Public Class DConstant

#Region "Variables"

#Region "GET, SEARCH"

    '-------------------------------------------------------------------------------
    'SEARCH
    Public Const _spOCSSearchPolicy = "SP_OCS_SEARCH_POLICY"
    Public Const _spOCSGetPolicyDetail = "SP_OCS_GET_POLICY_DETAIL"
    Public Const _spOCSGetNBPolicyNewgen = "SP_NGI_GET_NB_POLICY_DETAILS"
    Public Const _spOCSGetGpaPlanList = "SP_OCS_GET_GPA_PLAN_LIST"
    Public Const _spOCSGetGpaFlags = "SP_OCS_GET_GPA_FLAGS"
    Public Const _spOCSGetGpaCardIdDtl = "SP_OCS_GET_GPA_CARD_ID_DTL"
    Public Const _sfOCSCheckExistingOPR = "SF_OCS_CHECK_EXISTING_OPR"
    Public Const _spCCGetPayslipDtlNGI = "SP_CC_GET_PAYSLIP_DTL"
    Public Const _spCCGetPayslipDtl = "SP_GET_PAYSLIP_DETAILS"
    Public Const _spNGIGetPolicyBilling = "SP_NGI_GET_POLICY_BILLING"
    Public Const _spSSOGetSalesInvoice = "SP_SEARCH_SSO_SI"
    Public Const _spSSOGetAckReceipt = "SP_SEARCH_SITE_AR"
    Public Const _spSSOGetSalesInvoiceDMCM = "CISLIFE.SP_SEARCH_SSO_SI_DMCM"
    Public Const _spSSOGetDebitCreditMemo = "CISLIFE.SP_SEARCH_SITE_DMCM"
    Public Const _spSSOGetDMCMTaxAmount = "CISLIFE.SP_SEARCH_DMCM_TAX_AMOUNT"
    Public Const _spGetDMCMApprover = "SP_GET_DMCM_APPROVER"
    Public Const _spSSOGetSIDetails = "SP_SEARCH_SSO_SI_DETAILS"
    Public Const _spOCSGetARPayDetails = "SP_GET_SITE_AR_PAY"
    'SITE TABLES
    Public Const _spOCSGetSiteOprApr = "SP_OCS_GET_SITE_OPR_APR"
    Public Const _spOCSGetSiteOprCheck = "SP_OCS_GET_SITE_OPR_CHECK"
    Public Const _spOCSGetSiteOprCca = "SP_OCS_GET_SITE_OPR_CCA"
    Public Const _spOCSGetSiteOprDca = "SP_OCS_GET_SITE_OPR_DCA"
    Public Const _spOCSGetSiteOprECash = "SP_OCS_GET_SITE_OPR_ECASH"
    Public Const _spOCSGetSiteOprDtl = "SP_OCS_GET_SITE_OPR_DTL"
    Public Const _spOCSGetSiteOprHdr = "SP_OCS_GET_SITE_OPR_HDR"
    Public Const _spOCSGetSiteOprInfo = "SP_OCS_GET_SITE_OPR_INFO"
    Public Const _spOCSGetSiteOprVat = "SP_OCS_GET_SITE_OPR_VAT"
    Public Const _spOCSGetSiteBatchDtl = "SP_OCS_GET_SITE_BATCH_DTL"

    Public Const _spOCSGetSiteOrApr = "SP_OCS_GET_SITE_OR_APR"
    Public Const _spOCSGetSiteOrCheck = "SP_OCS_GET_SITE_OR_CHECK"
    Public Const _spOCSGetSiteOrDtl = "SP_OCS_GET_SITE_OR_DTL"
    Public Const _spOCSGetSiteOrHdr = "SP_OCS_GET_SITE_OR_HDR"
    Public Const _spOCSGetSiteOrPart = "SP_OCS_GET_SITE_OR_PART"
    Public Const _spOCSGetSiteOrVat = "SP_OCS_GET_SITE_OR_VAT"
    Public Const _spOCSGetSitePaMaster = "SP_OCS_GET_SITE_PA_MASTER"
    Public Const _spOCSGetSiteTmptrn = "SP_OCS_GET_SITE_TMPTRN"
    Public Const _spOCSGetSiteRcptCtr = "SP_OCS_GET_SITE_RCPT_CTR"

    Public Const _spOCSGetCardDetails = "SP_OCS_GET_CARD_DETAILS"
    'Staging TABLES
    Public Const _spCISGetStgOprAprpy = "SP_GET_STG_OPRAPRPY"
    Public Const _spCISGetStgOprChkpy = "SP_GET_STG_OPRCHKPY"
    Public Const _spCISGetStgOprCred = "SP_GET_STG_OPRCRED"
    Public Const _spCISGetStgOprDebit = "SP_GET_STG_OPRDEBIT"
    Public Const _spCISGetStgOprDtl = "SP_GET_STG_OPRDTL"
    Public Const _spCISGetStgOprHeader = "SP_GET_STG_OPRHEADER"
    Public Const _spCISGetStgOprInfo = "SP_GET_STG_OPRINFO"
    Public Const _spCISGetStgOprVat = "SP_GET_STG_OPRVAT"

    Public Const _spCISGetStgOrAprpay = "SP_GET_STG_ORAPRPAY"
    Public Const _spCISGetStgOrChkpay = "SP_GET_STG_ORCHKPAY"
    Public Const _spCISGetStgOrDtl = "SP_GET_STG_ORDTL"
    Public Const _spCISGetStgOrHeader = "SP_GET_STG_ORHEADER"
    Public Const _spCISGetStgOrPart = "SP_GET_STG_ORPART"
    Public Const _spCISGetStgOrVat = "SP_GET_STG_ORVAT"
    Public Const _spCISGetStgPaMaster = "SP_GET_STG_PA_MASTER"
    Public Const _spCISGetStgTmptrn = "SP_GET_STG_TMPTRN"
    Public Const _spGPAProcessOpr = "SP_GPA_PROCESS_OPR"
    Public Const _spGPACancelOpr = "SP_GPA_CANCEL_OPR"
    Public Const _spNewgenPayment = "SP_NGI_POST_NEW_OCS_PAYMENT" 'for CI
    Public Const _spNewgenUpdatePayment = "SP_NGI_POST_OCS_PAYMENT_UPDATE" 'for check tagging
    '-------------------------------------------------------------------------------
    Public Const _spOCSGetDocList = "SP_OCS_GET_DOC_LIST"
    Public Const _spSSOGetSIList = "SP_SSO_GET_SI_LIST"
    Public Const _spSSOGetSIListDMCM = "CISLIFE.SP_SSO_GET_SI_LIST_DMCM"
    Public Const _spSiteGetARList = "SP_SITE_GET_AR_LIST"
    Public Const _spSiteGetDMCMList = "CISLIFE.SP_SITE_GET_DMCM_LIST"
    Public Const _spSaveNGSI = "CISLIFE.SP_NGI_SAVE_SALES_INVOICE"
    Public Const _spCISGetRefPrsrefList = "SP_CIS_GET_REF_PRSREF_LIST"
    Public Const _spCISGetRefPrsrefPrstyp = "SP_CIS_GET_REF_PRSREF_PRSTYP"
    Public Const _spCISGetRefPrsrefSextyp = "SP_CIS_GET_REF_PRSREF_SEXTYP"
    Public Const _spOCSGetRefCurrefList = "SP_OCS_GET_REF_CURREF_LIST"
    Public Const _spCISGetRefFrqpayList = "SP_CIS_GET_REF_FRQPAY_LIST"
    Public Const _spOCSGetRefMetpayList = "SP_OCS_GET_REF_METPAY_LIST"
    Public Const _spOCSGetPolicyType = "SP_OCS_GET_POLICY_TYPE"
    Public Const _spOCSGetRefTranList = "SP_OCS_GET_REF_TRAN_LIST"
    Public Const _spOCSGetRefTranDtl = "SP_OCS_GET_REF_TRAN_DTL"
    Public Const _spCISGetRefParamrefList = "SP_CIS_GET_REF_PARAMREF_LIST"
    Public Const _spOCSGetMerchantSite = "SP_OCS_GET_MERCHANT_SITE"
    Public Const _spOCSGetSiteDetail = "SP_OCS_GET_SITE_DETAIL"
    Public Const _sfOCSGetLastReceipt = "SF_OCS_GET_LAST_RECEIPT"
    Public Const _sfOCSGetNextReceipt = "SF_BIR_GET_NEXT_DOC_NO"
    Public Const _sfOCSGetLastSI = "SF_OCS_GET_LAST_SI"
    Public Const _sfOCSGetNextSI = "SF_BIR_GET_NEXT_DOC_NO"
    Public Const _sfOCSGetLastAR = "SF_OCS_GET_LAST_AR"
    Public Const _sfOCSGetNextAR = "SF_BIR_GET_NEXT_DOC_NO"
    Public Const _sfOCSGetAgentOrCount = "SF_OCS_GET_AGENT_OR_COUNT"
    Public Const _sfOCSGetPolicyBalance = "SF_OCS_GET_POLICY_BALANCE"
    Public Const _sfOCSGetLastOr = "SF_OCS_GET_LAST_OR"
    Public Const _spOCSGetMwiPrintOr = "SP_OCS_GET_MWI_PRINT_OR"
    Public Const _spOCSGetOrSeries = "SP_OCS_GET_OR_SERIES"
    Public Const _spGetAgtOrReg = "SP_OCS_GET_AGT_OR_REG"
    Public Const _spOCSGetVlTopupLimit = "SP_OCS_GET_VL_TOPUP_LIMIT"
    Public Const _spGetPremiumBreakdown = "SP_GET_PREMIUM_BREAKDOWN"
    '-------------------------------------------------------------------------------
    Public Const _spOCSSearchAgent = "SP_OCS_SEARCH_AGENT"
    Public Const _spCISGetPrsmas = "SP_CIS_GET_PRSMAS"
    Public Const _spCISGetAgnmas = "SP_CIS_GET_AGNMAS"
    Public Const _sfCISGetAgencyfund = "SF_CIS_GET_AGENCYFUND"
    Public Const _sfGetSalesForce = "SF_GET_SALES_FORCE"
    Public Const _sfGetGpaCommRate = "SF_OCS_GPA_COMM_RATE"
    Public Const _sfGetTaxRate = "SF_GET_TAX_RATE"
    Public Const _spCISValidateAgent = "SP_CIS_VALIDATE_AGENT"

    Public Const _spOCSSearchPrsmas = "SP_OCS_SEARCH_PRSMAS"
    Public Const _sfGetAgentInfoAdj = "SF_GET_AGENT_INFO_ADJ"
    Public Const _spCISGetSecref = "SP_CIS_GET_SECREF"
    Public Const _spCISGenerateUwpron = "SP_CIS_GENERATE_UWPRON"
    Public Const _spOCSGetBankDetails = "SP_OCS_GET_BANK_DETAILS"
    Public Const _spOCSGetOrTrnrefList = "SP_OCS_GET_OR_TRNREF_LIST"
    Public Const _spOCSGetBankList = "SP_OCS_GET_BANK_LIST"
    Public Const _spOCSGetSiteOrCollDtl = "SP_OCS_GET_SITE_OR_COLL_DTL"

    Public Const _spOCSListActivevault = "SP_OCS_List_ActiveVault"
    Public Const _spOCSGetvaultdetail = "SP_OCS_GetVaultDetail"
    Public Const _spOCSGetTransactionType = "SP_OCS_GET_TRANSACTION_TYPE"

    Public Const _spCISAlterAgnmas = "SP_CIS_ALTER_AGNMAS"
    Public Const _spOCSAlterSiteOrCollDtl = "SP_OCS_ALTER_SITE_OR_COLL_DTL"
    Public Const _spCISAlterPrsmas = "SP_CIS_ALTER_PRSMAS"

    Public Const _sfCISGetPrspid = "SF_CIS_GET_PRSPID"

    Public Const _sfCISCalcOdi = "CALC_ODI"
    Public Const _sfCISVLCalcOdi = "CALC_ODI"
    Public Const _sfCheckVlRegPlan = "SF_CHECK_VL_REG_PLAN"
    Public Const _sfValidateCC = "SF_VALIDATE_CC"

    Public Const _spOCSGetCheckTagging = "SP_OCS_GET_CHECK_TAGGING"
    Public Const _sfOCSIsProcessed = "SF_OCS_IS_PROCESSED"

#End Region

#Region "ALTER"

    ''OPR SAVING
    Public Const _spOCSAlterSiteOprApr = "SP_OCS_ALTER_SITE_OPR_APR"
    Public Const _spOCSAlterSiteOprCheck = "SP_OCS_ALTER_SITE_OPR_CHECK"
    Public Const _spOCSAlterSiteOprCca = "SP_OCS_ALTER_SITE_OPR_CCA"
    Public Const _spOCSAlterSiteOprDca = "SP_OCS_ALTER_SITE_OPR_DCA"
    Public Const _spOCSAlterSiteOprECash = "SP_OCS_ALTER_SITE_OPR_ECASH"
    Public Const _spOCSAlterSiteOprDtl = "SP_OCS_ALTER_SITE_OPR_DTL"
    Public Const _spOCSAlterSiteOprHdr = "SP_OCS_ALTER_SITE_OPR_HDR"
    Public Const _spOCSAlterSiteOprInfo = "SP_OCS_ALTER_SITE_OPR_INFO"
    Public Const _spOCSAlterSiteOprVat = "SP_OCS_ALTER_SITE_OPR_VAT"
    Public Const _spOCSAlterSitePaMaster = "SP_OCS_ALTER_SITE_PA_MASTER"
    Public Const _spOCSProcessBatch = "SP_OCS_PROCESS_BATCH"
    Public Const _spOCSAlterSiteBatchDtl = "SP_OCS_ALTER_SITE_BATCH_DTL"
    Public Const _spAlterPayslipDetails = "SP_ALTER_PAYSLIP_DETAILS"

    ''BIR DOCS
    Public Const _spOCSProcessSI = "SP_OCS_PROCESS_SI"
    Public Const _spOCSProcessAR = "SP_OCS_PROCESS_AR"
    Public Const _spAlterARPayDetails = "SP_OCS_ALTER_AR_PAY"

    ''OR SAVING
    Public Const _spOCSProcessDMCM = "CISLIFE.SP_OCS_PROCESS_DMCM"
    Public Const _spOCSAlterSiteTmptrn = "SP_OCS_ALTER_SITE_TMPTRN"
    Public Const _spOCSAlterSiteOrApr = "SP_OCS_ALTER_SITE_OR_APR"
    Public Const _spOCSAlterSiteOrCheck = "SP_OCS_ALTER_SITE_OR_CHECK"
    Public Const _spOCSAlterSiteOrDtl = "SP_OCS_ALTER_SITE_OR_DTL"
    Public Const _spOCSAlterSiteOrHdr = "SP_OCS_ALTER_SITE_OR_HDR"
    Public Const _spOCSAlterSiteOrPart = "SP_OCS_ALTER_SITE_OR_PART"
    Public Const _spOCSAlterSiteOrVat = "SP_OCS_ALTER_SITE_OR_VAT"

    Public Const _spOCSPostSummary = "SP_OCS_POST_SUMMARY"
    Public Const _spOCSAlterSiteRcptCtr = "SP_OCS_ALTER_SITE_RCPT_CTR"

    ''MAINTENANCE
    Public Const _spOCSAlterSiteOprSeries = "SP_OCS_ALTER_SITE_OPR_SERIES"
    Public Const _spOCSAlterAgtOrReg = "SP_OCS_ALTER_AGT_OR_REG"
    Public Const _spAlterMerchantSite = "SP_ALTER_MERCHANT_SITE"


    ''OPR SAVING
    Public Const _spAlterStgOprApr = "SP_ALTER_STG_OPR_APR"
    Public Const _spAlterStgOprCheck = "SP_ALTER_STG_OPR_CHECK"
    Public Const _spAlterStgOprCca = "SP_ALTER_STG_OPR_CCA"
    Public Const _spAlterStgOprDca = "SP_ALTER_STG_OPR_DCA"
    Public Const _spAlterStgOprDtl = "SP_ALTER_STG_OPR_DTL"
    Public Const _spAlterStgOprHdr = "SP_ALTER_STG_OPR_HDR"
    Public Const _spAlterStgOprInfo = "SP_ALTER_STG_OPR_INFO"
    Public Const _spAlterStgOprVat = "SP_ALTER_STG_OPR_VAT"

    ''OR SAVING     CISAlterSTG
    Public Const _spAlterStgTmptrn = "SP_ALTER_STG_TMPTRN"
    Public Const _spAlterStgOrApr = "SP_ALTER_STG_OR_APR"
    Public Const _spAlterStgOrCheck = "SP_ALTER_STG_OR_CHECK"
    Public Const _spAlterStgOrDtl = "SP_ALTER_STG_OR_DTL"
    Public Const _spAlterStgOrHdr = "SP_ALTER_STG_OR_HDR"
    Public Const _spAlterStgOrPart = "SP_ALTER_STG_OR_PART"
    Public Const _spAlterStgOrVat = "SP_ALTER_STG_OR_VAT"

#End Region

#Region "REPORTS"

    Public Const _spOCSRptReceipt = "SP_OCS_RPT_RECEIPT"
    Public Const _spOCSRptOrReceipt = "SP_OCS_RPT_OR_RECEIPT"

#End Region

#End Region

End Class
