#Region "Description"
' PAGE NAME     : SECREF Interface 
' CREATED BY    : EJ
' CREATED DATE  : 11/10/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Person

    Public Interface ISecRef

#Region "Variables"

#End Region

#Region "Properties"
        Property SecOpr() As String         ' 
        Property SecPas() As String         ' 
        Property SecPID() As Long           ' 
        Property SecDat() As DateTime       ' 
        Property SecEnd() As DateTime       ' 
        Property SecPrv() As String         ' 
        ' -------------------------------------------------------------------------------
        Property IsRecordExist() As Boolean
#End Region

#Region "Single Point Functions"
        Sub GetSecRef(ByVal pSecOpr As String)
#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace


