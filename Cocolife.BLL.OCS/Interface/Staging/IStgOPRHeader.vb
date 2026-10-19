#Region "Description"
' PAGE NAME     : STG_OPRHEADER Interface
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

    Public Interface IStgOPRHeader

#Region "Variables"

#End Region

#Region "Properties"
        Property OPRRcptNo As Long              ' 
        Property OPRDate As Date                ' 
        Property OPRSrcBrnc As Long             ' 
        Property OPRRemarks As String           ' 
        Property OPRApplctn As String           ' 
        Property OPRECRNo As Long               ' 
        Property OPRECRDate As Date             ' 
        Property OPRPolNum As String            ' 
        Property OPRPyrID As Long               ' 
        Property OPRPyrFNam As String           ' 
        Property OPRPyrLNam As String           ' 
        Property OPRPyrMNam As String           ' 
        Property OPRInsID As Long               ' 
        Property OPRInsFNam As String           ' 
        Property OPRInsLNam As String           ' 
        Property OPRInsMNam As String           ' 
        Property OPRAgID As Long                ' 
        Property OPRAgFNam As String            ' 
        Property OPRAgLNam As String            ' 
        Property OPRAgMNam As String            ' 
        Property OPRBrID As Long                ' 
        Property OPRBrFNam As String            ' 
        Property OPRBrLNam As String            ' 
        Property OPRBrMNam As String            ' 
        Property OPRDocTyp As String            ' 
        Property OPRTxNumb As Long              '   
        Property OPRPlnCry As String            ' 
        Property OPRFlags As String             ' 
        Property OPRIssue As Date               ' 
        Property OPRLastBl As Date              ' 
        Property CancelFlag As Integer          ' 
        Property PrtFlag As Integer             ' 
        Property NiFlag As Integer              ' 
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

#End Region

    End Interface

End Namespace
