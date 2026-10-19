#Region "Description"
' PAGE NAME     : SECREF BLL
' CREATED BY    : MPRO
' CREATED DATE  : 08/16/2013
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalPerson = Cocolife.DAL.OCS.Person
#End Region

Namespace Person

    Public Class BSecRef

#Region "Implements"
        Implements Person.ISecRef
#End Region

#Region "Variables"
        Private mSecOpr As String = cDataType.fString.Empty
        Private mSecPas As String = cDataType.fString.Empty
        Private mSecPID As Long = cDataType.fLong.Empty
        Private mSecDat As DateTime = cDataType.fDate.Empty
        Private mSecEnd As DateTime = cDataType.fDate.Empty
        Private mSecPrv As String = cDataType.fString.Empty
        ' ------------------------------------------------------------------------------- 
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"

        Public Property SecOpr() As String Implements Person.ISecRef.SecOpr
            Get
                Return mSecOpr
            End Get
            Set(ByVal value As String)
                mSecOpr = value
            End Set
        End Property

        Public Property SecPas() As String Implements Person.ISecRef.SecPas
            Get
                Return mSecPas
            End Get
            Set(ByVal value As String)
                mSecPas = value
            End Set
        End Property

        Public Property SecPID() As Long Implements Person.ISecRef.SecPID
            Get
                Return mSecPID
            End Get
            Set(ByVal value As Long)
                mSecPID = value
            End Set
        End Property

        Public Property SecDat() As DateTime Implements Person.ISecRef.SecDat
            Get
                Return mSecDat
            End Get
            Set(ByVal value As DateTime)
                mSecDat = value
            End Set
        End Property

        Public Property SecEnd() As DateTime Implements Person.ISecRef.SecEnd
            Get
                Return mSecEnd
            End Get
            Set(ByVal value As DateTime)
                mSecEnd = value
            End Set
        End Property

        Public Property SecPrv() As String Implements Person.ISecRef.SecPrv
            Get
                Return mSecPrv
            End Get
            Set(ByVal value As String)
                mSecPrv = value
            End Set
        End Property

        ' ------------------------------------------------------------------------------- 

        Public Property IsRecordExist() As Boolean Implements Person.ISecRef.IsRecordExist
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

        Public Sub GetSecRef(ByVal pSecOpr As String) Implements Person.ISecRef.GetSecRef

            Dim objDAL As New dalPerson.DSecRef
            Dim drLocal As OracleDataReader

            Try

                IsRecordExist = False
                drLocal = objDAL.GetSecRef(pSecOpr)
                With drLocal
                    While .Read
                        SecOpr = cDataType.fString.IfNull(.Item("secopr"))
                        SecPas = cDataType.fString.IfNull(.Item("secpas"))
                        SecPID = cDataType.fLong.IfNull(.Item("secpid"))
                        SecDat = cDataType.fDate.IfNull(.Item("secdat"))
                        SecEnd = cDataType.fDate.IfNull(.Item("secend"))
                        SecPrv = cDataType.fString.IfNull(.Item("secprv"))
                        IsRecordExist = True
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try

        End Sub

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace

