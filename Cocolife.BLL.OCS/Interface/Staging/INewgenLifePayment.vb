#Region "Description"
' PAGE NAME     : Newgen Payment Interface  
' CREATED BY    : EJ
' CREATED DATE  : 04/15/2021
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Staging

    Public Interface INewgenLifePayment

#Region "Variables"

#End Region

#Region "Properties"
        Property ORNo As String
        Property DateOfReceipt As String
        Property ApplicationNo As String
        Property PolicyNo As String
        Property PayorName As String
        Property APR As String
        Property APRDate As String
        Property Currency As String
        Property TotalAmount As String
        Property BusinessType As String
        Property BillNo As String
        Property RetainedAmount As String
        Property PaymentStatus As String
        Property Remarks As String
        Property ParticularsJSON As String
        Property PaymentModeJSON As String
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

