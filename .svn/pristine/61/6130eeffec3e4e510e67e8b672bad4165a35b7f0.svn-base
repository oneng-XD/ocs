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
Imports dalMaintenance = Cocolife.DAL.OCS.Maintenance
#End Region

Namespace Maintenance

    Public Class BMaintAgentsORSeries

#Region "Implements"
        Implements Maintenance.IMaintAgentsORSeries
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mPostDate As Date
        Private mSeriesEditId As String
        Private mSeriesAgent As Long
        Private mSeriesRegNum As String
        Private mSeriesOldRegNum As String
        Private mSeriesRegDate As Date
        Private mSeriesOldRegDate As Date
        Private mSeriesStart As Decimal
        Private mSeriesEnd As Decimal
        Private mSeriesExpDate As Date
        Private mLastUpdate As Date

        Private mAgentOrSeries As Object
#End Region

#Region "Properties"

        Public Property IsSuccessful As Boolean Implements IMaintAgentsORSeries.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IMaintAgentsORSeries.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IMaintAgentsORSeries.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property SeriesEditId As String Implements IMaintAgentsORSeries.SeriesEditId
            Get
                Return mSeriesEditId
            End Get
            Set(value As String)
                mSeriesEditId = value
            End Set
        End Property

        Public Property SeriesAgent As Long Implements IMaintAgentsORSeries.SeriesAgent
            Get
                Return mSeriesAgent
            End Get
            Set(value As Long)
                mSeriesAgent = value
            End Set
        End Property

        Public Property SeriesRegNum As String Implements IMaintAgentsORSeries.SeriesRegNum
            Get
                Return mSeriesRegNum
            End Get
            Set(value As String)
                mSeriesRegNum = value
            End Set
        End Property

        Public Property SeriesOldRegNum As String Implements IMaintAgentsORSeries.SeriesOldRegNum
            Get
                Return mSeriesOldRegNum
            End Get
            Set(value As String)
                mSeriesOldRegNum = value
            End Set
        End Property

        Public Property SeriesRegDate As Date Implements IMaintAgentsORSeries.SeriesRegDate
            Get
                Return mSeriesRegDate
            End Get
            Set(value As Date)
                mSeriesRegDate = value
            End Set
        End Property

        Public Property SeriesOldRegDate As Date Implements IMaintAgentsORSeries.SeriesOldRegDate
            Get
                Return mSeriesOldRegDate
            End Get
            Set(value As Date)
                mSeriesOldRegDate = value
            End Set
        End Property

        Public Property SeriesStart As Decimal Implements IMaintAgentsORSeries.SeriesStart
            Get
                Return mSeriesStart
            End Get
            Set(value As Decimal)
                mSeriesStart = value
            End Set
        End Property

        Public Property SeriesEnd As Decimal Implements IMaintAgentsORSeries.SeriesEnd
            Get
                Return mSeriesEnd
            End Get
            Set(value As Decimal)
                mSeriesEnd = value
            End Set
        End Property

        Public Property SeriesExpDate As Date Implements IMaintAgentsORSeries.SeriesExpDate
            Get
                Return mSeriesExpDate
            End Get
            Set(value As Date)
                mSeriesExpDate = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements IMaintAgentsORSeries.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property AgentOrSeries As Object Implements IMaintAgentsORSeries.AgentOrSeries
            Get
                Return mAgentOrSeries
            End Get
            Set(value As Object)
                mAgentOrSeries = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(pSeriesEditId As String, ByVal pSeriesAgent As Long, ByVal pSeriesRegNum As String, ByVal pSeriesRegDate As Date,
                ByVal pSeriesStart As Decimal, ByVal pSeriesEnd As Decimal, ByVal pSeriesExpDate As Date, ByVal pUserID As Long)
            SeriesEditId = pSeriesEditId
            SeriesAgent = pSeriesAgent
            SeriesRegNum = pSeriesRegNum
            SeriesRegDate = pSeriesRegDate
            SeriesStart = pSeriesStart
            SeriesEnd = pSeriesEnd
            SeriesExpDate = pSeriesExpDate
            UserID = pUserID
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function LoadSeriesList(ByVal pAgentId As Long) As DataTable Implements IMaintAgentsORSeries.LoadSeriesList
            Dim objDal As New dalMaintenance.DAgtOrReg
            Dim dtLocal As New DataTable

            Try
                dtLocal = objDal.GetSeriesList(pAgentId)

                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

        Public Sub SaveSeries() Implements IMaintAgentsORSeries.SaveSeries
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If SeriesEditId = String.Empty Then
                    Me.Alter("INSERT", oraConn, oraTrans)
                Else
                    Me.Alter("UPDATE", oraConn, oraTrans)

                    If SeriesOldRegNum <> SeriesRegNum OrElse SeriesOldRegDate <> SeriesRegDate Then
                        Me.Alter("ALL_AGENT_REGNUM", oraConn, oraTrans)
                    End If

                End If

                oraTrans.Commit()
                IsSuccessful = True

            Catch ex As Exception
                oraTrans.Rollback()
                IsSuccessful = False
                Throw New Exception(String.Concat("Your data may not have been saved correctly. Please review your data and try again. <br />", ex.Message))
            Finally
                OracleConnection.ClearPool(oraConn)
                oraConn.Close()
                oraConn.Dispose()
            End Try

        End Sub

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As String

            Try
                Dim objDAL As New dalMaintenance.DAgtOrReg
                objDAL.AlterAgtOrReg(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

