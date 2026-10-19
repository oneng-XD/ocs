#Region "Description"
' PAGE NAME     : REFERENCE CLASS ENUMS
' CREATED BY    : MPRO
' CREATED DATE  : 04/07/2015
' UPDATE LOGS [modified by | modified date | updates]
' -------------------------------------------------------------------------------
' 
' -------------------------------------------------------------------------------
#End Region

#Region "Imports"

#End Region

Namespace Enums

    Public Class eReference

#Region "Constant Strings"
        Public Const ColrefAgentsAccount As String = "11479"
        Public Const ColrefAgentsAccountDesc As String = "AGENTS ACCOUNT"
#End Region

#Region "PaymentType"
        Public Const PayTypeCCA As String = "CCA"   ' CREDIT CARD ARRANGEMENT
        Public Const PayTypeCHQ As String = "CHQ"   ' CHECK
        Public Const PayTypeCSH As String = "CSH"   ' CASH
        Public Const PayTypeDCA As String = "DCA"   ' DEBIT CARD ARRANGEMENT
        Public Const PayTypeECP As String = "ECP"   ' E-CASH PAYMENT
#End Region

#Region "TransactionType"
        Public Enum TranType As Integer
            Regular = 1
            NewBusiness = 2
            GPA = 3
            '-----'
            ORRegular = 1
            ORLoan = 2
            ORColumbary = 3
        End Enum
        'Public Const TranTypeGPA As String = "GPA"  ' GROUP PERSONAL ACCIDENT
        'Public Const TranTypeREG As String = "REG"  ' REGULAR BUSINESS
        'Public Const TranTypeNEW As String = "NEW"  ' NEW BUSINESS
        'Public Const TranTypeNBG As String = "NBG"  ' NEW BUSINESS (GROUP)
        'Public Const TranTypeNBI As String = "NBI"  ' NEW BUSINESS (INDIVIDUAL)
        'Public Const TranTypeNBV As String = "NBV"  ' NEW BUSINESS (VL)
#End Region

#Region "Document Type"
        Public Const DocTypeOPR As String = "ORP"
        Public Const DocTypeOR As String = "ROP"
#End Region

#Region "GPA Trnx"
        Public Const TrnxGPA As String = "ADCPA"
        Public Const TrnxGpaRenewal As String = "ADCPR"
        Public Const TrnxGpaRefund As String = "PAREF"
#End Region

#Region "GPA Colref"
        Public Const ColrefGPA As String = "71006"
        Public Const ColrefGpaRenewal As String = "71009"
        Public Const ColrefGpaRefund As String = "71010"
#End Region

#Region "AgentTagType"
        Public Enum AgentTagType As Integer
            Agent = 0
            SalesOfficer = 1
            PromoOfficer = 2
            Usd1 = 3
            Asd = 4
        End Enum
#End Region

#Region "ManagePolicy States"
        Public Enum MgePol As Integer
            Initial = 0
            Enabled = 1
            NewBiz = 2
            Search = 3
            Policy = 4
            Payor = 5
            PayorAdd = 6
            Insured = 7
            InsuredAdd = 8
            Gpa = 9
            BInitial = 10
            lInitial = 11
            RecordFound = 12
            RecordNotFound = 13
            SamePayorInsured = 14
            Payslip = 15
            PayslipDiv = 16
            BalanceToHigher = 17
            BillNo = 18
            BillNoDiv = 19
            SubsNo = 20
            Agent = 21
            

        End Enum
#End Region

#Region "ManageNewBiz States"
        Public Enum MgeNewBiz As Integer
            Initial = 0
            Enabled = 1
            NewBiz = 2
            PayorId = 3
            PayorAdd = 4
            PayorName = 5
            Insured = 6
            InsuredAdd = 7
            Button = 8
            ButtonAdd = 9
            NewInsured = 10
        End Enum
#End Region

#Region "DocSaveState"
        Public Enum DocSaveState As Byte
            Initial = 0
            ViewNoEdit = 1
            ViewEdit = 2
            AddNew = 3
            Edit = 4
            Print = 5
            Cancel = 6
        End Enum
#End Region

#Region "Status"
        Public Enum Status As Integer
            None = 0
            Active = 1
            Inactive = 2
            Cancelled = 3
            Deleted = 4
            Locked = 5
            Requested = 6
            ForApproval = 7
            Approved = 8
            Refunded = 9
            Posted = 10
            Printed = 11
            OnHold = 12
        End Enum
#End Region

#Region "Receipt Type"
        Public Enum ReceiptType As Integer
            CI = 4
            SI = 2
            AR = 3
        End Enum
#End Region

    End Class

End Namespace



