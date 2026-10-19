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
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
#End Region

Namespace Payment

    Public Class BDailyCollectionReport

#Region "Implements"
        Implements Payment.IDailyCollectionReport
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mPostDate As Date
        Private mLstForPosting As IList(Of Object)
#End Region

#Region "Properties"

        Public Property IsSuccessful As Boolean Implements IDailyCollectionReport.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IDailyCollectionReport.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IDailyCollectionReport.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property PostDate As Date Implements IDailyCollectionReport.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property lstForPosting As IList(Of Object) Implements IDailyCollectionReport.lstForPosting
            Get
                Return mLstForPosting
            End Get
            Set(value As IList(Of Object))
                mLstForPosting = value
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

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Function PostHeaderSums(pDocType) As Long

            Try
                Dim objDAL As New DAL.OCS.Working.DSiteTmpTrn
                objDAL.PostHeaderSums(SiteCode, UserID, PostDate, pDocType)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

