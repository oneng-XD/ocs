#Region "Description"
' PAGE NAME     : SITE_OPRINFO BLL
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

    Public Class BReceiptCounter

#Region "Implements"
        Implements IReceiptCounter
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mReceiptNumber As Long = cDataType.fLong.Empty
        Private mSiteId As Long = cDataType.fLong.Empty
        Private mUserId As Long = cDataType.fLong.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements IReceiptCounter.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements IReceiptCounter.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements IReceiptCounter.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements IReceiptCounter.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements IReceiptCounter.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements IReceiptCounter.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property ReceiptNumber As Long Implements IReceiptCounter.ReceiptNumber
            Get
                Return mReceiptNumber
            End Get
            Set(value As Long)
                mReceiptNumber = value
            End Set
        End Property

        Public Property SiteId As Long Implements IReceiptCounter.SiteId
            Get
                Return mSiteId
            End Get
            Set(value As Long)
                mSiteId = value
            End Set
        End Property

        Public Property UserId As Long Implements IReceiptCounter.UserId
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

        Sub New(ByVal pId As Long, ByVal pReceiptNumber As Long, ByVal pSiteId As Long,
                ByVal pUserId As Long, ByVal pStatusId As Integer, ByVal pPostBy As Long,
                ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            ReceiptNumber = pReceiptNumber
            SiteId = pSiteId
            UserId = pUserId
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
       
#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DReceiptNumber
                objDAL.AlterReceiptCounter(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Sub GetSiteReceiptCounter(ByVal pSiteId As Long)

            Dim objDAL As New dalWorking.DReceiptNumber
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetSiteReceiptCounter(pSiteId)
                With drLocal
                    While .Read
                        Id = cDataType.fLong.IfNull(.Item("id"))
                        ReceiptNumber = cDataType.fLong.IfNull(.Item("receipt_number"))
                        SiteId = cDataType.fDecimal.IfNull(.Item("site_id"))
                        UserId = cDataType.fDecimal.IfNull(.Item("user_id"))
                        StatusId = cDataType.fLong.IfNull(.Item("status_id"))
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

    End Class

End Namespace
