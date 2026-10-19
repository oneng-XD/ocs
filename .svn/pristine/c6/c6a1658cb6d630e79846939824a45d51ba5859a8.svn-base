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

    Public Class BMaintOfficialReceipt

#Region "Implements"
        Implements Maintenance.IMaintOfficialReceipt
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mPostDate As Date
        Private mSeriesEditId As Long
        Private mSeriesPrefix As Long
        Private mSeriesStart As Long
        Private mSeriesEnd As Long
        Private mSeriesStatus As Integer
        Private mOprSeries As Object
#End Region

#Region "Properties"

        Public Property IsSuccessful As Boolean Implements IMaintOfficialReceipt.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IMaintOfficialReceipt.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IMaintOfficialReceipt.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property SeriesEditId As Long Implements IMaintOfficialReceipt.SeriesEditId
            Get
                Return mSeriesEditId
            End Get
            Set(value As Long)
                mSeriesEditId = value
            End Set
        End Property

        Public Property SeriesPrspid As Long Implements IMaintOfficialReceipt.SeriesPrspid
            Get

            End Get
            Set(value As Long)

            End Set
        End Property

        Public Property SeriesPrefix As Long Implements IMaintOfficialReceipt.SeriesPrefix
            Get
                Return mSeriesPrefix
            End Get
            Set(value As Long)
                mSeriesPrefix = value
            End Set
        End Property

        Public Property SeriesStart As Long Implements IMaintOfficialReceipt.SeriesStart
            Get
                Return mSeriesStart
            End Get
            Set(value As Long)
                mSeriesStart = value
            End Set
        End Property

        Public Property SeriesEnd As Long Implements IMaintOfficialReceipt.SeriesEnd
            Get
                Return mSeriesEnd
            End Get
            Set(value As Long)
                mSeriesEnd = value
            End Set
        End Property

        Public Property SeriesStatus As Integer Implements IMaintOfficialReceipt.SeriesStatus
            Get
                Return mSeriesStatus
            End Get
            Set(value As Integer)
                mSeriesStatus = value
            End Set
        End Property

        Public Property OprSeries As Object Implements IMaintOfficialReceipt.OprSeries
            Get
                Return mOprSeries
            End Get
            Set(value As Object)
                mOprSeries = value
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

        Public Sub SaveSeries() Implements IMaintOfficialReceipt.SaveSeries
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If SeriesEditId = 0 Then
                    OprSeries.Alter("INSERT", oraConn, oraTrans)
                Else
                    OprSeries.Alter("UPDATE", oraConn, oraTrans)
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

#End Region

    End Class

End Namespace

