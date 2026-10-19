#Region "Description"
' PAGE NAME     : SITE_OPRDTL BLL
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
Imports dalMaintenance = Cocolife.DAL.OCS.Maintenance
#End Region

Namespace Maintenance

    Public Class BSiteOprSeries

#Region "Implements"
        Implements ISiteOprSeries
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mPrspid As Long = cDataType.fLong.Empty
        Private mStartOprSeries As Long = cDataType.fLong.Empty
        Private mEndOprSeries As String = cDataType.fLong.Empty
        Private mStatusId As Integer = cDataType.fInteger.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteOprSeries.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteOprSeries.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteOprSeries.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteOprSeries.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteOprSeries.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteOprSeries.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property Prspid() As Long Implements ISiteOprSeries.Prspid
            Get
                Return mPrspid
            End Get
            Set(value As Long)
                mPrspid = value
            End Set
        End Property

        Public Property StartOprSeries() As Long Implements ISiteOprSeries.StartOprSeries
            Get
                Return mStartOprSeries
            End Get
            Set(value As Long)
                mStartOprSeries = value
            End Set
        End Property

        Public Property EndOprSeries() As Long Implements ISiteOprSeries.EndOprSeries
            Get
                Return mEndOprSeries
            End Get
            Set(value As Long)
                mEndOprSeries = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pPrspid As Long, ByVal pStartOprSeries As Long,
                ByVal pEndOprSeries As Long, ByVal pStatusId As Integer, ByVal pPostBy As Long, ByVal pPostDate As Date,
                ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            Prspid = pPrspid
            StartOprSeries = pStartOprSeries
            EndOprSeries = pEndOprSeries
            StatusId = pStatusId
            PostBy = pPostBy
            PostDate = pPostDate
            LastUpdateBy = pLastUpdateBy
            LastUpdate = pLastUpdate
        End Sub

#End Region

#Region "Single Point Functions"
        Public Function CheckOprSeries(ByVal pId As Long, ByVal pStart As Decimal, ByVal pEnd As Decimal) As Boolean
            Dim objDal As New dalMaintenance.DSiteOprSeries
            Dim mLocal As Boolean

            Try
                mLocal = objDal.CheckOprSeries(pId, pStart, pEnd)
                Return mLocal

            Catch ex As Exception
                Throw
            End Try

        End Function
#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function LoadSeriesList(ByVal pSiteId As Long) As DataTable Implements ISiteOprSeries.LoadSeriesList
            Dim objDal As New dalMaintenance.DSiteOprSeries
            Dim dtLocal As New DataTable

            Try
                dtLocal = objDal.GetSeriesList(pSiteId)

                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalMaintenance.DSiteOprSeries
                objDAL.AlterSiteOprSeries(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
