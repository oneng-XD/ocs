#Region "Description"
' PAGE NAME     : SITE_ORPART BLL
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

    Public Class BSiteORPart

#Region "Implements"
        Implements ISiteORPart
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mParticular As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Integer = cDataType.fInteger.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteORPart.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteORPart.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteORPart.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteORPart.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteORPart.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteORPart.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property ORNmbr() As Long Implements ISiteORPart.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property Particular() As String Implements ISiteORPart.Particular
            Get
                Return mParticular
            End Get
            Set(value As String)
                mParticular = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements ISiteORPart.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Integer Implements ISiteORPart.LineNmbr
            Get
                Return mLineNmbr
            End Get
            Set(value As Integer)
                mLineNmbr = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pORNmbr As Long, ByVal pParticular As String, ByVal pAmount As Decimal,
                ByVal pLineNmbr As Integer, ByVal pStatusId As Integer, ByVal pPostBy As Long, ByVal pPostDate As Date,
                ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            ORNmbr = pORNmbr
            Particular = pParticular
            Amount = pAmount
            LineNmbr = pLineNmbr
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

        Public Function GetSiteORPart(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable

            Dim objDAL As New dalWorking.DSiteORPart
            Dim dtLocal As DataTable

            Try

                dtLocal = objDAL.GetSiteORPart(pDocNumber, pUserId)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try
        End Function


#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteORPart
                objDAL.AlterSiteORPart(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
