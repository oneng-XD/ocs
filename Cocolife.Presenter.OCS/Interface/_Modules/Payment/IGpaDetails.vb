#Region "Description"
' PAGE NAME     : GPA Details Interface 
' CREATED BY    : EJ
' CREATED DATE  : 07/19/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface IGpaDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property IsGpaCardNoExist As Boolean
        Property GpaType As Integer
        Property GpaCardNo As String
        Property GpaPlan As String
        Property GpaNumber As String
        Property GpaPremium As Decimal
        Property GpaCoverage As Decimal
        Property GpaTerm As Integer
        'Property SalesOffIDTag As Boolean
        'Property PromoOffIDTag As Boolean
        Property GpaSalesOff As Long
        'Property GpaSoLName As String
        'Property GpaSoFName As String
        'Property GpaSoMName As String
        'Property GpaSalesOffAgy As Long
        'Property GpaSoAgyLName As String
        'Property GpaSoAgyFName As String
        'Property GpaSoAgyMName As String
        Property GpaPromoOff As Long
        'Property GpaPoLName As String
        'Property GpaPoFName As String
        'Property GpaPoMName As String
        'Property GpaPromoOffAgy As Long
        'Property GpaPoAgyLName As String
        'Property GpaPoAgyFName As String
        'Property GpaPoAgyMName As String
        Property GpaUsd1 As Long
        Property GpaUsdName1 As String
        Property GpaUsd2 As Long
        Property GpaUsdName2 As String
        Property GpaAsd1 As Long
        Property GpaAsdName1 As String
        Property GpaAsd2 As Long
        Property GpaAsdName2 As String
        Property GpaSettingsPolnum As String
        Property GpaSettingsPlanType As String
        Property GpaSettingsAllowCom As Boolean
        Property GpaSettingsAllowPO As Boolean
        Property GpaSettingsAllowRenewal As Boolean
        Property GpaSettingsAllowCommSharing As Boolean
        WriteOnly Property dtGpaPlan As DataTable
        Property GpaCardNoTag As Boolean
        Property GpaPaymentTag As Boolean
#End Region

#Region "Events"
        Event ClearScreenGpaDetails As EventHandler(Of EventArgs)
        Event ClearScreenGpaPaymentDetails As EventHandler(Of EventArgs)
        Event ClearScreenGpaCardNo As EventHandler(Of EventArgs)
        Event ClearGpaSettings As EventHandler(Of EventArgs)
        'Event CheckGpaSettings As EventHandler(Of EventArgs)
        Event LoadGpaPlan As EventHandler(Of EventArgs)
        Event LoadGpaCardNo As EventHandler(Of EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

