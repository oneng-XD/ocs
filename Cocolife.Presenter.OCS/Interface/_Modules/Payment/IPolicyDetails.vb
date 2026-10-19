#Region "Description"
' PAGE NAME     : Policy Details Interface
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

    Public Interface IPolicyDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property ApplicationNumber As Long
        Property PolType As String
        Property PType As String
        Property PolicyNumber As String
        Property NoPolicy As Boolean
        Property PolicyNumberTag As Boolean
        Property ModalPremium As Decimal
        Property CovDue As Date
        Property CovEff As Date
        Property CovSta As String
        Property CovStaDes As String
        Property PolCur As String
        Property PolMod As String
        Property PolFrq As Integer
        Property LastBill As Date
        Property ServUn As Long
        Property LoadPolMod As String
#End Region

#Region "Events"
        Event ClearScreenPolicy(ByVal sender As Object, ByVal e As EventArgs)
        Event GetPolicyDetails(ByVal sender As Object, ByVal e As EventArgs)
        Event LoadPolModDetails(ByVal sender As Object, ByVal e As EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region


    End Interface

End Namespace

