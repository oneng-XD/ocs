#Region "Description"
' PAGE NAME     : ECashPayment Details Interface
' CREATED BY    : EJ
' CREATED DATE  : 04/12/2022
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Payment

    Public Interface IPaymentTypeDetails
        Inherits IChkDetails, ICcaDetails, IDcaDetails, IEPayDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property PaymentTypeTag As Boolean
        Property lstPaymentTypeDetails As List(Of cPaymentType)
        Property GrossAmount As Decimal
        Property PayCurrency As String
        Property CashPaymentTag As Boolean
        Property CashAmount As Decimal
        Property CommissionAmount As Decimal
        Property CashTotalAmount As Decimal
        Property IsPayTypeSuccessful As Boolean
        Property PaymentTypeID As String
        Property PrevPayType As String
        Property PaymentTypeAllowedArray As String
        ReadOnly Property PaymentTotalAmount As Decimal
        WriteOnly Property dtPaymentType As DataTable
        WriteOnly Property dtCancellationReason As DataTable
#End Region

#Region "Events"
        Event CheckGrossAmount As EventHandler(Of EventArgs)
        Event CheckAllowedPaytype As EventHandler(Of EventArgs)
        Event CheckPrevPayType As EventHandler(Of EventArgs)
        Event ClearScreenPaymentDetails As EventHandler(Of EventArgs)
        Event ClearScreenPaymentTypeDetails As EventHandler(Of EventArgs)
        Event ClearScreenCashDetails As EventHandler(Of EventArgs)
        Event AddCashPayment As EventHandler(Of EventArgs)
        Event AddPaymentTypeDetails As EventHandler(Of EventArgs)
        Event DeletePaymentTypeDetails As EventHandler(Of EventArgs)
        Event GetPaymentTypeDetails As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"
        Event LoadPaymentType As EventHandler(Of EventArgs)
        Event LoadAllowedPaymentType As EventHandler(Of EventArgs)
#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Sub radSelectPayTypeDetails(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    End Interface

End Namespace

