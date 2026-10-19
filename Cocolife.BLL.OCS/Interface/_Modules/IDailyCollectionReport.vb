#Region "Description"
' PAGE NAME     :  
' CREATED BY    : 
' CREATED DATE  : 
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Payment

    Public Interface IDailyCollectionReport

#Region "Variables"

#End Region

#Region "Properties"
        Property IsSuccessful() As Boolean
        ' ------------------------------------------------------------------------------- 
        Property SiteCode() As Long
        Property UserID() As Long
        Property PostDate() As Date
        ' ------------------------------------------------------------------------------- 
        Property lstForPosting() As IList(Of Object)

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
#End Region

    End Interface

End Namespace