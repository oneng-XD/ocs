#Region "Description"
' PAGE NAME     : Payor Details Interface
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

    Public Interface IPayorDetails

#Region "Variables"

#End Region

#Region "Properties"
        Property PayorID As Long
        Property PayorIDTag As Boolean
        Property PayorType As String
        Property PayorName As String
        Property PayorLastName As String
        Property PayorFirstName As String
        Property PayorMiddleName As String
        Property PayorSuffix As String
        Property PayorTitle As String
        Property PayorPlaceOfBirth As String
        Property PayorDateOfBirth As Date
        '--------------------------------------------------------------------------
        Property PayorAddType As String
        Property PayorAddName As String
        Property PayorAddLastName As String
        Property PayorAddFirstName As String
        Property PayorAddMiddleName As String
        Property PayorAddSuffix As String
        Property PayorAddTitle As String
        Property PayorAddPlaceOfBirth As String
        Property PayorAddDateOfBirth As Date


        Property PayorAddTin As String
        Property PayorAddAddress As String
        Property PayorTin As String
        Property PayorAddress As String

#End Region

#Region "Events"
        Event ClearScreenPayor(ByVal sender As Object, ByVal e As EventArgs)
        Event ClearScreenAddPayor(ByVal sender As Object, ByVal e As EventArgs)
        Event ClearScreenPayorType(ByVal sender As Object, ByVal e As EventArgs)
        Event GetPayorDetails(ByVal sender As Object, ByVal e As EventArgs)
        Event LoadAddPayor(ByVal sender As Object, ByVal e As EventArgs)
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace

