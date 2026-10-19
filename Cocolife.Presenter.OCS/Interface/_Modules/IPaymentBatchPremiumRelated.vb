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

    Public Interface IPaymentBatchPremiumRelated
        Inherits IChkDetails, 
            IAprDetails


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
        Property BatchID As Long
        Property OPRDate As Date
        Property ViewBatchFrom As Date
        Property ViewBatchTo As Date
        Property ViewBatchID As Long
        Property IsSourceSiteLocked As Boolean
        Property SourceSite As String
        Property OPRPaymentType As String
        Property OPRCurrency As String
        Property OPRCashAmount As Decimal
        Property OPRGrossAmount As Decimal
        Property BatchNonPrem As String
        Property lstOprList As List(Of cBatchOpr)
        Property WithAPR As Boolean
        Property OPRRemarks As String
        ReadOnly Property OPRFlags As String
        ' -------------------------------------------------------------------------------
        Property PaymentTypeTag As Boolean
        
        Property CashPaymentTag As Boolean
        Property CashTotalAmount As Decimal
        Property lstPaymentTypeDetails As List(Of cPaymentType)
        Property IsPayTypeSuccessful As Boolean
        Property PaymentTypeID As String
        Property PrevPayType As String
        ReadOnly Property PaymentTotalAmount As Decimal
        ' -------------------------------------------------------------------------------
        WriteOnly Property dtViewBatch As DataTable
        WriteOnly Property dtSourceSite As DataTable
        WriteOnly Property dtCurrency As DataTable
        WriteOnly Property dtPaymentType As DataTable
        WriteOnly Property dtBatchDetails As DataTable
        WriteOnly Property dtBatchNonPrem As DataTable

#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenPaymentDetails As EventHandler(Of EventArgs)
        Event ClearScreenCashDetails As EventHandler(Of EventArgs)
        Event ClearScreenPaymentTypeDetails As EventHandler(Of EventArgs)
        Event ClearScreenViewBatch As EventHandler(Of EventArgs)
        Event ClearScreenBatch As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event LoadViewBatch As EventHandler(Of EventArgs)
        Event LoadSourceSite As EventHandler(Of EventArgs)
        Event LoadCurrency As EventHandler(Of EventArgs)
        Event LoadAllowedPaymentType As EventHandler(Of EventArgs)
        Event LoadPaymentType As EventHandler(Of EventArgs)
        Event LoadBatchNonPrem As EventHandler(Of EventArgs)
        ' ---------------------------------------------------------------------
        Event AddCashPayment As EventHandler(Of EventArgs)
        Event AddPaymentTypeDetails As EventHandler(Of EventArgs)
        Event DeletePaymentTypeDetails As EventHandler(Of EventArgs)
        Event GetPaymentTypeDetails As EventHandler(Of EventArgs)
        ' -------------------------------------------------------------------------------
        Event LoadNewOPR As EventHandler(Of EventArgs)
        Event LoadOPR As EventHandler(Of EventArgs)
        Event LoadBatch As EventHandler(Of EventArgs)
        Event LoadBatchDetails As EventHandler(Of EventArgs)
        Event CheckPrevPayType As EventHandler(Of EventArgs)
        Event CheckSourceSite As EventHandler(Of EventArgs)
        Event ProcessPaymentBatchPremium As EventHandler(Of EventArgs)
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
        Sub radSelectPayTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectViewBatch(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Interface

End Namespace

