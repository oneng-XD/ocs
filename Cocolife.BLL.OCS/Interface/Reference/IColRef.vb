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

Namespace Reference

    Public Interface IColRef

#Region "Variables"

#End Region

#Region "Properties"
        Property ColRef As String           ' 
        Property ColDes As String           ' 
        Property PctRef As String           ' 
        Property Vatable As String          '
        Property ORType As String           '
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Function GetRefColRefList(Optional ByVal pFilter As String = Nothing) As DataTable
#End Region

    End Interface

End Namespace

