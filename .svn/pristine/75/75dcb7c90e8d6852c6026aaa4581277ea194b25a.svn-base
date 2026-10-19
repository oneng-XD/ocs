#Region "Description"
' PAGE NAME     : Columbary (HARSERV) Connection Class
' CREATED BY    : IBP
' CREATED DATE  : 02/28/2017
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

Imports Microsoft.VisualBasic
Imports System
Imports System.Data
'Imports System.Data.OracleClient
Imports System.Data.SqlClient

#End Region

Public Class DBConnector

    Private Shared sqlConn As New SqlConnection
    Private Shared sqlTrans As SqlTransaction
    Private Shared sqlConnString As String

    'Private Shared oraConn As New OracleConnection
    'Private Shared oraTrans As OracleTransaction
    'Private Shared oraConnString As String

    Public Shared Property SqlConnection() As SqlConnection
        Get
            Return sqlConn
        End Get
        Set(value As SqlConnection)
            sqlConn = value
        End Set
    End Property

    'Public Shared Property OraConnection() As OracleConnection
    '    Get
    '        Return oraConn
    '    End Get
    '    Set(ByVal value As OracleConnection)
    '        oraConn = value
    '    End Set
    'End Property

    Public Shared Property SqlTransaction() As SqlTransaction
        Get
            Return sqlTrans
        End Get
        Set(value As SqlTransaction)
            sqlTrans = value
        End Set
    End Property

    'Public Shared Property OraTransaction() As OracleTransaction
    '    Get
    '        Return oraTrans
    '    End Get
    '    Set(ByVal value As OracleTransaction)
    '        oraTrans = value
    '    End Set
    'End Property

    Public Shared Property SqlConnectionString() As String
        Get
            Return sqlConnString
        End Get
        Set(value As String)
            sqlConnString = value
        End Set
    End Property

    'Public Shared Property OraConnectionString() As String
    '    Get
    '        Return oraConnString
    '    End Get
    '    Set(ByVal value As String)
    '        oraConnString = value
    '    End Set
    'End Property

    Public Sub New()
        ' Default constructor
    End Sub

    Public Shared Sub InitializeConnection(ByVal connString As String)
        If Not (sqlConn.State = ConnectionState.Open) Or sqlConn.State <> Nothing Then
            sqlConnString = connString
            sqlConn = New SqlConnection(sqlConnString)
            sqlConn.Open()
        End If
    End Sub

    'Public Shared Sub InitializeConnection(ByVal connString As String)
    '    If Not (oraConn.State = ConnectionState.Open) Or oraConn.State <> Nothing Then
    '        oraConnString = connString
    '        oraConn = New OracleConnection(oraConnString)
    '        oraConn.Open()
    '    End If
    'End Sub

    Public Shared Sub DisposeConnection(ByVal connString As String)
        If (sqlConn.State = ConnectionState.Open) Then
            sqlConn.Close()
            sqlConn.Dispose()
        End If
    End Sub

    'Public Shared Sub DisposeConnection(ByVal connString As String)
    '    If (oraConn.State = ConnectionState.Open) Then
    '        oraConn.Close()
    '        oraConn.Dispose()
    '    End If
    'End Sub

End Class