#Region "Description"
' PAGE NAME     : SP_GPA_PROCESS_OPR BLL
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
Imports dalStaging = Cocolife.DAL.OCS.Staging
#End Region

Namespace Staging

    Public Class BGpaProcess

#Region "Implements"
        Implements Staging.IGpaProcess
#End Region

#Region "Variables"
        Private mPolicyNumber As String = cDataType.fString.Empty
        Private mPACardID As String = cDataType.fString.Empty
        Private mBirthDate As Date = cDataType.fDate.Empty
        Private mPremium As Decimal = cDataType.fDecimal.Empty
        Private mCoverageAmount As Decimal = cDataType.fDecimal.Empty
        Private mCoverageTerm As Integer = cDataType.fInteger.Empty
        Private mAgent1ID As Integer = cDataType.fInteger.Empty
        Private mAgent2ID As Integer = cDataType.fInteger.Empty
        Private mUsdID As Integer = cDataType.fInteger.Empty
        Private mUsd2ID As Integer = cDataType.fInteger.Empty
        Private mAsdID As Integer = cDataType.fInteger.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mStatus As String = cDataType.fString.Empty
        Private mCommWithdrawn As Integer = cDataType.fInteger.Empty
        Private mCommwithAmt As Decimal = cDataType.fDecimal.Empty
        Private mDocType As String = cDataType.fString.Empty
        Private mDocNumber As Long = cDataType.fLong.Empty
        Private mDocDate As Date = cDataType.fDate.Empty
        Private mInsuredId As Long = cDataType.fLong.Empty
        Private mPayorId As Long = cDataType.fLong.Empty
        Private mTransCode As Long = cDataType.fLong.Empty
        Private mUserId As Long = cDataType.fLong.Empty
#End Region

#Region "Properties"

        Public Property PolicyNumber As String Implements Staging.IGpaProcess.PolicyNumber
            Get
                Return mPolicyNumber
            End Get
            Set(value As String)
                mPolicyNumber = value
            End Set
        End Property
        Public Property PACardID As String Implements Staging.IGpaProcess.PACardID
            Get
                Return mPACardID
            End Get
            Set(value As String)
                mPACardID = value
            End Set
        End Property
        Public Property BirthDate As Date Implements Staging.IGpaProcess.BirthDate
            Get
                Return mBirthDate
            End Get
            Set(value As Date)
                mBirthDate = value
            End Set
        End Property
        Public Property Premium As Decimal Implements Staging.IGpaProcess.Premium
            Get
                Return mPremium
            End Get
            Set(value As Decimal)
                mPremium = value
            End Set
        End Property
        Public Property CoverageAmount As Decimal Implements Staging.IGpaProcess.CoverageAmount
            Get
                Return mCoverageAmount
            End Get
            Set(value As Decimal)
                mCoverageAmount = value
            End Set
        End Property
        Public Property CoverageTerm As Integer Implements Staging.IGpaProcess.CoverageTerm
            Get
                Return mCoverageTerm
            End Get
            Set(value As Integer)
                mCoverageTerm = value
            End Set
        End Property
        Public Property Agent1ID As Integer Implements Staging.IGpaProcess.Agent1ID
            Get
                Return mAgent1ID
            End Get
            Set(value As Integer)
                mAgent1ID = value
            End Set
        End Property
        Public Property Agent2ID As Integer Implements Staging.IGpaProcess.Agent2ID
            Get
                Return mAgent2ID
            End Get
            Set(value As Integer)
                mAgent2ID = value
            End Set
        End Property
        Public Property UsdID As Integer Implements Staging.IGpaProcess.UsdID
            Get
                Return mUsdID
            End Get
            Set(value As Integer)
                mUsdID = value
            End Set
        End Property
        Public Property Usd2ID As Integer Implements Staging.IGpaProcess.Usd2ID
            Get
                Return mUsd2ID
            End Get
            Set(value As Integer)
                mUsd2ID = value
            End Set
        End Property
        Public Property AsdID As Integer Implements Staging.IGpaProcess.AsdID
            Get
                Return mAsdID
            End Get
            Set(value As Integer)
                mAsdID = value
            End Set
        End Property
        Public Property Remarks As String Implements Staging.IGpaProcess.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property
        Public Property Status As String Implements Staging.IGpaProcess.Status
            Get
                Return mStatus
            End Get
            Set(value As String)
                mStatus = value
            End Set
        End Property
        Public Property CommWithdrawn As Integer Implements Staging.IGpaProcess.CommWithdrawn
            Get
                Return mCommWithdrawn
            End Get
            Set(value As Integer)
                mCommWithdrawn = value
            End Set
        End Property
        Public Property CommwithAmt As Decimal Implements Staging.IGpaProcess.CommwithAmt
            Get
                Return mCommwithAmt
            End Get
            Set(value As Decimal)
                mCommwithAmt = value
            End Set
        End Property
        Public Property DocType As String Implements Staging.IGpaProcess.DocType
            Get
                Return mDocType
            End Get
            Set(value As String)
                mDocType = value
            End Set
        End Property
        Public Property DocNumber As Long Implements Staging.IGpaProcess.DocNumber
            Get
                Return mDocNumber
            End Get
            Set(value As Long)
                mDocNumber = value
            End Set
        End Property
        Public Property DocDate As Date Implements Staging.IGpaProcess.DocDate
            Get
                Return mDocDate
            End Get
            Set(value As Date)
                mDocDate = value
            End Set
        End Property
        Public Property InsuredId As Long Implements Staging.IGpaProcess.InsuredId
            Get
                Return mInsuredId
            End Get
            Set(value As Long)
                mInsuredId = value
            End Set
        End Property
        Public Property PayorId As Long Implements Staging.IGpaProcess.PayorId
            Get
                Return mPayorId
            End Get
            Set(value As Long)
                mPayorId = value
            End Set
        End Property
        Public Property TransCode As Long Implements Staging.IGpaProcess.TransCode
            Get
                Return mTransCode
            End Get
            Set(value As Long)
                mTransCode = value
            End Set
        End Property
        Public Property UserId As Long Implements Staging.IGpaProcess.UserId
            Get
                Return mUserId
            End Get
            Set(value As Long)
                mUserId = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pPolicyNumber As String, ByVal pPACardID As String, ByVal pBirthDate As Date, ByVal pPremium As Decimal,
                ByVal pCoverageAmount As Decimal, ByVal pCoverageTerm As Integer, ByVal pAgent1ID As Integer, ByVal pAgent2ID As Integer,
                ByVal pUsdID As Integer, ByVal pUsd2ID As Integer, ByVal pAsdID As Integer, ByVal pRemarks As String,
                ByVal pStatus As String, ByVal pCommWithdrawn As Integer, ByVal pCommwithAmt As Decimal, ByVal pDocType As String,
                ByVal pDocNumber As Long, ByVal pDocDate As Date, ByVal pInsuredId As Long, ByVal pPayorId As Long,
                ByVal pTransCode As Long, ByVal pUserId As Long)
            PolicyNumber = pPolicyNumber
            PACardID = pPACardID
            BirthDate = pBirthDate
            Premium = pPremium
            CoverageAmount = pCoverageAmount
            CoverageTerm = pCoverageTerm
            Agent1ID = pAgent1ID
            Agent2ID = pAgent2ID
            UsdID = pUsdID
            Usd2ID = pUsd2ID
            AsdID = pAsdID
            Remarks = pRemarks
            Status = pStatus
            CommWithdrawn = pCommWithdrawn
            CommwithAmt = pCommwithAmt
            DocType = "OR"
            DocNumber = pDocNumber
            DocDate = pDocDate
            InsuredId = pInsuredId
            PayorId = pPayorId
            TransCode = pTransCode
            UserId = pUserId
        End Sub

        Sub New(ByVal pObject As Working.BSitePAMaster)
            With pObject
                PolicyNumber = .PolicyNumber
                PACardID = .PACardID
                BirthDate = .BirthDate
                Premium = .Premium
                CoverageAmount = .CoverageAmount
                CoverageTerm = .CoverageTerm
                Agent1ID = .Agent1
                Agent2ID = .Agent2
                UsdID = .USD1
                Usd2ID = .USD2
                AsdID = .ASD
                Remarks = .Remarks
                Status = .Status
                CommWithdrawn = IIf(.CommissionWithdrawn, 1, 0)
                'CommwithAmt = .CommwithAmt
                DocType = "OR"
                DocNumber = .ORNumber
                DocDate = .ORDate
                'InsuredId = .InsuredId
                'PayorId = .PayorId
                TransCode = .TransactionID
                'UserId = .UserId
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DStgPAMaster
                If pAction = "CANCEL" Then

                    If Agent1ID = 0 _
                    AndAlso Agent2ID > 0 Then
                        Agent1ID = Agent2ID
                    ElseIf UsdID > 0 Then
                        Agent1ID = UsdID
                    ElseIf Usd2ID Then
                        Agent1ID = Usd2ID
                    Else
                        Agent1ID = AsdID
                    End If

                    objDAL.CancelGpa(Me, pAction, pConn, pTrans)
                Else
                    objDAL.ProcessGpa(Me, pAction, pConn, pTrans)
                End If

                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace


