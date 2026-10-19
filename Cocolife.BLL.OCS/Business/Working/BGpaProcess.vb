#Region "Description"
' PAGE NAME     : SITE_PA_MASTER BLL
' CREATED BY    : EJ
' CREATED DATE  : 05/04/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports eAction = Cocolife.Utility.Common.Enums.eDBAction
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalWorking = Cocolife.DAL.OCS.Working
#End Region

Namespace Working

    Public Class BSitePAMaster

#Region "Implements"
        Implements ISitePAMaster
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mPolicyNumber As String = cDataType.fString.Empty
        Private mPACardID As String = cDataType.fString.Empty
        Private mTransactionID As Long = cDataType.fLong.Empty
        Private mLastName As String = cDataType.fString.Empty
        Private mFirstName As String = cDataType.fString.Empty
        Private mMiddleName As String = cDataType.fString.Empty
        Private mORNumber As Long = cDataType.fLong.Empty
        Private mORDate As Date = cDataType.fDate.Empty
        Private mPremium As Decimal = cDataType.fDecimal.Empty
        Private mCoverageAmount As Decimal = cDataType.fDecimal.Empty
        Private mCoverageTerm As Integer = cDataType.fInteger.Empty
        Private mAgent1 As Integer = cDataType.fInteger.Empty
        Private mAgent1Nam As String = cDataType.fString.Empty
        Private mAgent2 As Integer = cDataType.fInteger.Empty
        Private mAgent2Nam As String = cDataType.fString.Empty
        Private mUSD1 As Integer = cDataType.fInteger.Empty
        Private mUSD1Nam As String = cDataType.fString.Empty
        Private mUSD2 As Integer = cDataType.fInteger.Empty
        Private mUSD2Nam As String = cDataType.fString.Empty
        Private mASD As Integer = cDataType.fInteger.Empty
        Private mASDNam As String = cDataType.fString.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mStatus As String = cDataType.fString.Empty
        Private mBirthDate As Date = cDataType.fDate.Empty
        Private mCommissionWithdrawn As Boolean = cDataType.fBoolean.Empty
        Private mPayorLastName As String = cDataType.fString.Empty
        Private mPayorFirstName As String = cDataType.fString.Empty
        Private mPayorMiddleName As String = cDataType.fString.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISitePAMaster.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISitePAMaster.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISitePAMaster.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISitePAMaster.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISitePAMaster.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISitePAMaster.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property PolicyNumber() As String Implements ISitePAMaster.PolicyNumber
            Get
                Return mPolicyNumber
            End Get
            Set(value As String)
                mPolicyNumber = value
            End Set
        End Property

        Public Property PACardID() As String Implements ISitePAMaster.PACardID
            Get
                Return mPACardID
            End Get
            Set(value As String)
                mPACardID = value
            End Set
        End Property

        Public Property TransactionID() As Long Implements ISitePAMaster.TransactionID
            Get
                Return mTransactionID
            End Get
            Set(value As Long)
                mTransactionID = value
            End Set
        End Property

        Public Property LastName() As String Implements ISitePAMaster.LastName
            Get
                Return mLastName
            End Get
            Set(value As String)
                mLastName = value
            End Set
        End Property

        Public Property FirstName() As String Implements ISitePAMaster.FirstName
            Get
                Return mFirstName
            End Get
            Set(value As String)
                mFirstName = value
            End Set
        End Property

        Public Property MiddleName() As String Implements ISitePAMaster.MiddleName
            Get
                Return mMiddleName
            End Get
            Set(value As String)
                mMiddleName = value
            End Set
        End Property

        Public Property ORNumber() As Long Implements ISitePAMaster.ORNumber
            Get
                Return mORNumber
            End Get
            Set(value As Long)
                mORNumber = value
            End Set
        End Property

        Public Property ORDate() As Date Implements ISitePAMaster.ORDate
            Get
                Return mORDate
            End Get
            Set(value As Date)
                mORDate = value
            End Set
        End Property

        Public Property Premium() As Decimal Implements ISitePAMaster.Premium
            Get
                Return mPremium
            End Get
            Set(value As Decimal)
                mPremium = value
            End Set
        End Property

        Public Property CoverageAmount() As Decimal Implements ISitePAMaster.CoverageAmount
            Get
                Return mCoverageAmount
            End Get
            Set(value As Decimal)
                mCoverageAmount = value
            End Set
        End Property

        Public Property CoverageTerm() As Integer Implements ISitePAMaster.CoverageTerm
            Get
                Return mCoverageTerm
            End Get
            Set(value As Integer)
                mCoverageTerm = value
            End Set
        End Property

        Public Property Agent1() As Integer Implements ISitePAMaster.Agent1
            Get
                Return mAgent1
            End Get
            Set(value As Integer)
                mAgent1 = value
            End Set
        End Property

        Public Property Agent1Nam() As String Implements ISitePAMaster.Agent1Nam
            Get
                Return mAgent1nam
            End Get
            Set(value As String)
                mAgent1nam = value
            End Set
        End Property

        Public Property Agent2() As Integer Implements ISitePAMaster.Agent2
            Get
                Return mAgent2
            End Get
            Set(value As Integer)
                mAgent2 = value
            End Set
        End Property

        Public Property Agent2Nam() As String Implements ISitePAMaster.Agent2Nam
            Get
                Return mAgent2nam
            End Get
            Set(value As String)
                mAgent2nam = value
            End Set
        End Property

        Public Property USD1() As Integer Implements ISitePAMaster.USD1
            Get
                Return mUSD1
            End Get
            Set(value As Integer)
                mUSD1 = value
            End Set
        End Property

        Public Property USD1Nam() As String Implements ISitePAMaster.USD1Nam
            Get
                Return mUSD1nam
            End Get
            Set(value As String)
                mUSD1nam = value
            End Set
        End Property

        Public Property USD2() As Integer Implements ISitePAMaster.USD2
            Get
                Return mUSD2
            End Get
            Set(value As Integer)
                mUSD2 = value
            End Set
        End Property

        Public Property USD2Nam() As String Implements ISitePAMaster.USD2Nam
            Get
                Return mUSD2nam
            End Get
            Set(value As String)
                mUSD2nam = value
            End Set
        End Property

        Public Property ASD() As Integer Implements ISitePAMaster.ASD
            Get
                Return mASD
            End Get
            Set(value As Integer)
                mASD = value
            End Set
        End Property

        Public Property ASDNam() As String Implements ISitePAMaster.ASDNam
            Get
                Return mASDnam
            End Get
            Set(value As String)
                mASDnam = value
            End Set
        End Property

        Public Property Remarks() As String Implements ISitePAMaster.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property Status() As String Implements ISitePAMaster.Status
            Get
                Return mStatus
            End Get
            Set(value As String)
                mStatus = value
            End Set
        End Property

        Public Property BirthDate() As Date Implements ISitePAMaster.BirthDate
            Get
                Return mBirthDate
            End Get
            Set(value As Date)
                mBirthDate = value
            End Set
        End Property

        Public Property CommissionWithdrawn() As Boolean Implements ISitePAMaster.CommissionWithdrawn
            Get
                Return mCommissionWithdrawn
            End Get
            Set(value As Boolean)
                mCommissionWithdrawn = value
            End Set
        End Property

        Public Property PayorLastName() As String Implements ISitePAMaster.PayorLastName
            Get
                Return mPayorLastName
            End Get
            Set(value As String)
                mPayorLastName = value
            End Set
        End Property

        Public Property PayorFirstName() As String Implements ISitePAMaster.PayorFirstName
            Get
                Return mPayorFirstName
            End Get
            Set(value As String)
                mPayorFirstName = value
            End Set
        End Property

        Public Property PayorMiddleName() As String Implements ISitePAMaster.PayorMiddleName
            Get
                Return mPayorMiddleName
            End Get
            Set(value As String)
                mPayorMiddleName = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pPolicyNumber As String, ByVal pPACardID As String, ByVal pTransactionID As Long,
                ByVal pLastName As String, ByVal pFirstName As String, ByVal pMiddleName As String,
                ByVal pORNumber As Long, ByVal pORDate As Date, ByVal pPremium As Decimal,
                ByVal pCoverageAmount As Decimal, ByVal pCoverageTerm As Integer, ByVal pAgent1 As Integer,
                ByVal pAgent2 As Integer, ByVal pUSD1 As Integer, ByVal pUSD2 As Integer,
                ByVal pASD As Integer, ByVal pRemarks As String, ByVal pStatus As String,
                ByVal pBirthDate As Date, ByVal pCommissionWithdrawn As Integer, ByVal pPayorLastName As String,
                ByVal pPayorFirstName As String, ByVal pPayorMiddleName As String, ByVal pStatusId As Integer, ByVal pPostBy As Long,
                ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            PolicyNumber = pPolicyNumber
            PACardID = pPACardID
            TransactionID = pTransactionID
            LastName = pLastName
            FirstName = pFirstName
            MiddleName = pMiddleName
            ORNumber = pORNumber
            ORDate = pORDate
            Premium = pPremium
            CoverageAmount = pCoverageAmount
            CoverageTerm = pCoverageTerm
            Agent1 = pAgent1
            Agent2 = pAgent2
            USD1 = pUSD1
            USD2 = pUSD2
            ASD = pASD
            Remarks = pRemarks
            Status = pStatus
            BirthDate = pBirthDate
            CommissionWithdrawn = pCommissionWithdrawn
            PayorLastName = pPayorLastName
            PayorFirstName = pPayorFirstName
            PayorMiddleName = pPayorMiddleName
            StatusId = pStatusId
            PostBy = pPostBy
            PostDate = pPostDate
            LastUpdateBy = pLastUpdateBy
            LastUpdate = pLastUpdate
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Sub GetSitePAMAster(ByVal pDocNumber As Long, ByVal pUserId As Long)

            Dim objDAL As New dalWorking.DSitePAMaster
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetSitePAMaster(pDocNumber, pUserId)
                With drLocal
                    While .Read
                        Id = cDataType.fLong.IfNull(.Item("id"))
                        PolicyNumber = cDataType.fString.IfNull(.Item("policy_number"))
                        PACardID = cDataType.fString.IfNull(.Item("pacard_id"))
                        TransactionID = cDataType.fLong.IfNull(.Item("transaction_id"))
                        LastName = cDataType.fString.IfNull(.Item("last_name"))
                        FirstName = cDataType.fString.IfNull(.Item("first_name"))
                        MiddleName = cDataType.fString.IfNull(.Item("middle_name"))
                        ORNumber = cDataType.fLong.IfNull(.Item("or_number"))
                        ORDate = cDataType.fDate.IfNull(.Item("or_date"))
                        Premium = cDataType.fDecimal.IfNull(.Item("premium"))
                        CoverageAmount = cDataType.fDecimal.IfNull(.Item("coverage_amount"))
                        CoverageTerm = cDataType.fInteger.IfNull(.Item("coverage_term"))
                        Agent1 = cDataType.fInteger.IfNull(.Item("agent1"))
                        Agent2 = cDataType.fInteger.IfNull(.Item("agent2"))
                        USD1 = cDataType.fInteger.IfNull(.Item("usd1"))
                        USD2 = cDataType.fInteger.IfNull(.Item("usd2"))
                        ASD = cDataType.fInteger.IfNull(.Item("asd"))
                        Remarks = cDataType.fString.IfNull(.Item("remarks"))
                        Status = cDataType.fString.IfNull(.Item("status"))
                        BirthDate = cDataType.fDate.IfNull(.Item("birth_date"))
                        CommissionWithdrawn = cDataType.fInteger.IfNull(.Item("commission_withdrawn"))
                        PayorLastName = cDataType.fString.IfNull(.Item("payor_last_name"))
                        PayorFirstName = cDataType.fString.IfNull(.Item("payor_first_name"))
                        PayorMiddleName = cDataType.fString.IfNull(.Item("payor_middle_name"))
                        StatusId = cDataType.fInteger.IfNull(.Item("status_id"))
                        PostBy = cDataType.fString.IfNull(.Item("post_by"))
                        PostDate = cDataType.fDate.IfNull(.Item("post_date"))
                        LastUpdateBy = cDataType.fString.IfNull(.Item("last_update_by"))
                        LastUpdate = cDataType.fDate.IfNull(.Item("last_update"))
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try
        End Sub

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSitePAMaster
                objDAL.AlterSitePAMaster(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace


