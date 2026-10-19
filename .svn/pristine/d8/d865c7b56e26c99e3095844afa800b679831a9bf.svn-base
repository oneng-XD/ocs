#Region "Description"
' PAGE NAME     :  Payment Non-Premium Related Interface
' CREATED BY    : EJ 
' CREATED DATE  : 07/19/2016
' UPDATE LOGS [modified by | modified date | updates]
'             [IBP | 021617 | properties, etc.]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Payment

    Public Interface IPaymentNonPremiumRelated
        Inherits IPayorDetails, 
            IReceiptDetails, 
            IChkDetails, 
            IAprDetails, 
            IVatDetails, 
            IColumbariumDetails

#Region "Variables"

#End Region

#Region "Properties"

        Property ORNumber As Long
        Property ORDate As Date

        ReadOnly Property SiteCode As Long
        ReadOnly Property UserID As Long
        ReadOnly Property DocType As String
        Property ReceiptByCode As String
        Property ReceiptById As Long
        Property DocPrinted As Boolean
        Property DocSaveState As Integer
        Property IsSuccessful As Boolean

        Property IsSourceSiteLocked As Boolean
        Property SourceSite As String
        Property TransactionType As String
        Property ORPaymentType As String
        Property IsGrossaAmountLocked As Boolean
        Property ORGrossAmount As Decimal
        Property ORCurrency As String
        Property ORCashAmount As Decimal
        Property WithAPR As Boolean
        Property ColumbaryInitialFee As Boolean

        Property ViewOrFrom As Date
        Property ViewOrTo As Date
        Property ViewOrDocNumber As Long
        Property ViewOrPayorName As String

        Property ORRemarks As String
        ReadOnly Property ORFlags As String

        Property ParticularsRemarks As String  'IBP 2/22
        Property ParticularsAmount As Decimal   'IBP 2/22
        Property lstParticulars As List(Of cParticulars) 'IBP 2/22
        Property ParticularsTotalAmount As Decimal 'IBP 2/22
        Property ParticularsID As String
        Property GLCode As String 'IBP 2/24
        ReadOnly Property DepositoryAccount As String 'IBP 2/25
        Property IsParticularsValid As Boolean  'IBP 2/27

        Property PaymentTypeTag As Boolean
        Property OtherDetailsTag As Boolean
        Property ORDetailTag As Boolean
        Property ORVatTag As Boolean
        Property ColumbariumTag As Boolean 'IBP 1/20
        Property ParticularsTag As Boolean 'IBP 2/02

        Property CashPaymentTag As Boolean
        Property CashTotalAmount As Decimal
        Property lstPaymentTypeDetails As List(Of cPaymentType)
        Property IsPayTypeSuccessful As Boolean
        Property PaymentTypeID As String
        Property PrevPayType As String
        ReadOnly Property PaymentTotalAmount As Decimal

        Property ColPayrEmployee As Boolean 'Added by IBP 040617
        Property ColPayrRegular As Boolean 'Added by IBP 040617

        '-------------------------------------------------------------------------------
        WriteOnly Property dtViewOR As DataTable
        WriteOnly Property dtSourceSite As DataTable
        WriteOnly Property dtCurrency As DataTable
        WriteOnly Property dtPaymentType As DataTable
        WriteOnly Property dtTransactionType As DataTable
        WriteOnly Property dtPersonType As DataTable
        WriteOnly Property dtBankDetails As DataTable 'IBP 02/23/17

        Property lstORDetails As List(Of cORDetail)

#End Region

#Region "Events"
        Event ClearScreenMain As EventHandler(Of EventArgs)
        Event ClearScreenPaymentDetails As EventHandler(Of EventArgs)
        Event ClearScreenCashDetails As EventHandler(Of EventArgs)
        Event ClearScreenPaymentTypeDetails As EventHandler(Of EventArgs)
        Event ClearScreenColumbarium As EventHandler(Of EventArgs) 'IBP 1/20
        Event ClearScreenOtherDetails As EventHandler(Of EventArgs) 'IBP 2/01
        Event ClearScreenParticulars As EventHandler(Of EventArgs) 'IBP 2/02
        Event ClearTotals As EventHandler(Of EventArgs) 'IBP 2/25
        Event ClearScreenViewOR As EventHandler(Of EventArgs) 'IBP 3/29

        '---------------------------------------------------------------------
        Event LoadViewOR As EventHandler(Of EventArgs)
        Event LoadSourceSite As EventHandler(Of EventArgs)
        Event LoadCurrency As EventHandler(Of EventArgs)
        Event LoadPersonType As EventHandler(Of EventArgs)
        Event LoadPersonTitle As EventHandler(Of EventArgs)
        Event LoadPaymentType As EventHandler(Of EventArgs)
        Event LoadTransactionType As EventHandler(Of EventArgs)

        '---------------------------------------------------------------------

        Event AddParticulars As EventHandler(Of EventArgs)     'IBP
        Event DeleteParticulars As EventHandler(Of EventArgs)  'IBP
        Event CheckParticulars As EventHandler(Of EventArgs) 'IBP

        '---------------------------------------------------------------------

        Event AddCashPayment As EventHandler(Of EventArgs)
        Event AddPaymentTypeDetails As EventHandler(Of EventArgs)
        Event DeletePaymentTypeDetails As EventHandler(Of EventArgs)
        Event GetPaymentTypeDetails As EventHandler(Of EventArgs)

        ' -------------------------------------------------------------------------------

        Event LoadNewOR As EventHandler(Of EventArgs)
        Event LoadOR As EventHandler(Of EventArgs)
        Event CheckPrevPayType As EventHandler(Of EventArgs)
        'Event SavePaymentNonPremium As EventHandler(Of EventArgs)
        Event ProcessPaymentNonPremium As EventHandler(Of EventArgs)
        Event ConfirmCancel As EventHandler(Of EventArgs)
        Event ConfirmSave As EventHandler(Of EventArgs)
        Event ConfirmPrint As EventHandler(Of EventArgs)
        Event ConfirmDeletePaytyp As EventHandler(Of EventArgs)
        Event ConfirmDeleteORDetails As EventHandler(Of EventArgs)
        Event ConfirmDeleteParticulars As EventHandler(Of EventArgs)

        ' -------------------------------------------------------------------------------

        Event LoadBankDetails As EventHandler(Of EventArgs) 'IBP 02/17

        '--------------------------------------------------------------------------------

        Event GenerateReport As EventHandler(Of EventArgs) 'Ej 4/10/17


#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

        Sub radSelectOr(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectPayTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectORDetails(ByVal sender As Object, ByVal e As EventArgs)
        Sub radSelectParticulars(ByVal sender As Object, ByVal e As EventArgs)

        Sub radEmployee(ByVal sender As Object, ByVal e As EventArgs)
        Sub radRegular(ByVal sender As Object, ByVal e As EventArgs)

#End Region

    End Interface

End Namespace

