#Region "Description"
' PAGE NAME     : GPA DETAILS BLL
' CREATED BY    : EJ
' CREATED DATE  : 12/27/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BGpaDetails

#Region "Implements"
        Implements IGpaDetails
#End Region

#Region "Variables"
        Private mCardNo As String = cDataType.fString.Empty
        Private mCoverageAmount As Decimal = cDataType.fDecimal.Empty
        Private mCoverageTerm As Integer = cDataType.fInteger.Empty
        Private mDocNumber As Long = cDataType.fLong.Empty
        Private mIsAllowComm As Boolean = cDataType.fBoolean.Empty
        Private mIsAllowCommSharing As Boolean = cDataType.fBoolean.Empty
        Private mIsPromoOff As Boolean = cDataType.fBoolean.Empty
        Private mIsRenewable As Boolean = cDataType.fBoolean.Empty
        Private mPlan As String = cDataType.fString.Empty
        Private mPremiumAmount As Decimal = cDataType.fDecimal.Empty
        Private mPolicyNumber As String = cDataType.fString.Empty
        Private mCardSite As Long
        ' -------------------------------------------------------------------------------
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"
        Public Property CardNo As String Implements IGpaDetails.CardNo
            Get
                Return mCardNo
            End Get
            Set(value As String)
                mCardNo = value
            End Set
        End Property

        Public Property CoverageAmount As Decimal Implements IGpaDetails.CoverageAmount
            Get
                Return mCoverageAmount
            End Get
            Set(value As Decimal)
                mCoverageAmount = value
            End Set
        End Property

        Public Property CoverageTerm As Integer Implements IGpaDetails.CoverageTerm
            Get
                Return mCoverageTerm
            End Get
            Set(value As Integer)
                mCoverageTerm = value
            End Set
        End Property

        Public Property DocNumber() As Long Implements IGpaDetails.DocNumber
            Get
                Return mDocNumber
            End Get
            Set(ByVal value As Long)
                mDocNumber = value
            End Set
        End Property

        Public Property IsAllowComm As Boolean Implements IGpaDetails.IsAllowComm
            Get
                Return mIsAllowComm
            End Get
            Set(value As Boolean)
                mIsAllowComm = value
            End Set
        End Property

        Public Property IsPromoOff As Boolean Implements IGpaDetails.IsPromoOff
            Get
                Return mIsPromoOff
            End Get
            Set(value As Boolean)
                mIsPromoOff = value
            End Set
        End Property

        Public Property IsRenewable As Boolean Implements IGpaDetails.IsRenewable
            Get
                Return mIsRenewable
            End Get
            Set(value As Boolean)
                mIsRenewable = value
            End Set
        End Property

        Public Property IsAllowCommSharing() As Boolean Implements IGpaDetails.IsAllowCommSharing
            Get
                Return mIsAllowCommSharing
            End Get
            Set(ByVal value As Boolean)
                mIsAllowCommSharing = value
            End Set
        End Property

        Public Property Plan As String Implements IGpaDetails.Plan
            Get
                Return mPlan
            End Get
            Set(value As String)
                mPlan = value
            End Set
        End Property

        Public Property PolicyNumber() As String Implements IGpaDetails.PolicyNumber
            Get
                Return mPolicyNumber
            End Get
            Set(ByVal value As String)
                mPolicyNumber = value
            End Set
        End Property

        Public Property PremiumAmount As Decimal Implements IGpaDetails.PremiumAmount
            Get
                Return mPremiumAmount
            End Get
            Set(value As Decimal)
                mPremiumAmount = value
            End Set
        End Property

        Public Property CardSite() As Long Implements IGpaDetails.CardSite
            Get
                Return mCardSite
            End Get
            Set(ByVal value As Long)
                mCardSite = value
            End Set
        End Property

        ' -------------------------------------------------------------------------------

        Public Property IsRecordExist() As Boolean Implements IGpaDetails.IsRecordExist
            Get
                Return mIsRecordExist
            End Get
            Set(ByVal value As Boolean)
                mIsRecordExist = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"
        Public Function IsGpaCardValid(ByVal pSiteCode As Long, ByVal pPlan As String, ByVal pCardId As Long) As Boolean
            Dim objDal As New dalReference.DGpaDetails
            Dim dtLocal As New DataTable
            Dim mResult As Boolean = False

            Try

                dtLocal = objDal.GetGpaCard(pSiteCode, pPlan, pCardId)
                For Each dr As DataRow In dtLocal.Rows
                    'plan, card_id, site_id, status_id, doc_number

                    Exit For
                Next

            Catch ex As Exception
                Throw
            End Try
        End Function
#End Region

#Region "Data Retrieval"

        Public Sub SearchPaCardId(ByVal pPlan As String, ByVal pNumber As String) Implements IGpaDetails.SearchPaCardId
            Dim objDal As New dalReference.DGpaDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDal.SearchPaCardId(pPlan, pNumber)
                For Each dr As DataRow In dtLocal.Rows

                    Plan = dr.Item("plan")
                    CardNo = dr.Item("card_id")
                    PremiumAmount = dr.Item("premium")
                    CoverageAmount = dr.Item("coverage")
                    CoverageTerm = dr.Item("term")
                    DocNumber = dr.Item("doc_number")
                    CardSite = dr.Item("site_id")
                    IsRecordExist = True
                    Exit For

                Next

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub GetGpaSettings(ByVal pSalesForce As String, ByVal pCatCod As String) Implements IGpaDetails.GetGpaSettings
            Dim objDal As New dalReference.DGpaDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDal.GetGpaSettings(pSalesForce, pCatCod)
                For Each dr In dtLocal.Rows

                    PolicyNumber = dr.item("polnum")
                    Plan = dr.item("plan_type")
                    IsAllowComm = CBool(dr.item("net_rem_flag"))
                    IsPromoOff = CBool(dr.item("po_flag"))
                    IsRenewable = CBool(dr.item("renewal_flag"))
                    IsAllowCommSharing = CBool(dr.item("com_share_flag"))
                    Exit For

                Next

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub GetGpaSettings(ByVal pSalesForce As String, ByVal pCatCod As String, ByVal pGpaPlan As String) Implements IGpaDetails.GetGpaSettings
            Dim objDal As New dalReference.DGpaDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDal.GetGpaSettings(pSalesForce, pCatCod)
                For Each dr In dtLocal.Rows
                    'If dr.item("plan_type") = Left(pGpaPlan, 1) Then
                    PolicyNumber = dr.item("polnum")
                    Plan = dr.item("plan_type")
                    IsAllowComm = CBool(dr.item("net_rem_flag"))
                    IsPromoOff = CBool(dr.item("po_flag"))
                    IsRenewable = CBool(dr.item("renewal_flag"))
                    IsAllowCommSharing = CBool(dr.item("com_share_flag"))
                    Exit For
                    'End If
                Next

            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Function GetGpaPlanList(ByVal pSiteCode As Long, ByVal pSalesForce As String) As DataTable Implements IGpaDetails.GetGpaPlanList

            Dim objDAL As New dalReference.DGpaDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetGpaPlanList(pSiteCode, pSalesForce)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace


