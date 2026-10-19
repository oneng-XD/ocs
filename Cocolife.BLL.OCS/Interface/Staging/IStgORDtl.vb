#Region "Description"
' PAGE NAME     : STG_ORDTL Interface  
' CREATED BY    : MPRO
' CREATED DATE  : 05/04/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Staging

    Public Interface IStgORDtl

#Region "Variables"

#End Region

#Region "Properties"
        Property ORNmbr As Long             ' 
        Property TrnxCode As Long           ' 
        Property ActType As String          ' 
        Property TrnxDesc As String         ' 
        Property Amount As Decimal           ' 
        Property LineNmbr As Long           ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
