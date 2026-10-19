#Region "Description"
' PAGE NAME     :  OR Details BLL (Non-Premium Payment)
' CREATED BY    :  IBP
' CREATED DATE  :  02/02/2017
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

    Public Class BOrDetails

#Region "Implements"
        Implements IOrDetails
#End Region

#Region "Variables"
        Private mORDate As Date
        Private mORNumber As Long
        Private mORPosted As Boolean
        Private mORPrinted As Boolean
#End Region

#Region "Properties"

        Public Property ORDate As Date Implements IOrDetails.ORDate
            Get
                Return mORDate
            End Get
            Set(value As Date)
                mORDate = value
            End Set
        End Property

        Public Property ORNumber As Long Implements IOrDetails.ORNumber
            Get
                Return mORNumber
            End Get
            Set(value As Long)
                mORNumber = value
            End Set
        End Property

        Public Property ORPosted As Boolean Implements IOrDetails.ORPosted
            Get
                Return mORPosted
            End Get
            Set(value As Boolean)
                mORPosted = value
            End Set
        End Property

        Public Property ORPrinted As Boolean Implements IOrDetails.ORPrinted
            Get
                Return mORPrinted
            End Get
            Set(value As Boolean)
                mORPrinted = value
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

        Public Function IsNewORAllowed(ByVal pNextDocNumber As String) As Boolean Implements IOrDetails.IsNewORAllowed
            Dim mReceiptDetails() As String
            Try
                mReceiptDetails = Split(pNextDocNumber, "|")

                If mReceiptDetails(0) = String.Empty Then
                    Return True
                End If

                If mReceiptDetails(1) = 0 Then
                    Throw New ArgumentException("Please print previous Receipt.")
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw
            End Try

            Return False
        End Function

#End Region

#Region "Data Retrieval"

        Public Sub LoadNewOR(ByVal pSiteId As Long, ByVal pReceiptType As Integer, ByVal pUserId As Long, Optional ByRef pConn As Object = Nothing, Optional ByRef pTrans As Object = Nothing) Implements IOrDetails.LoadNewOR
            Dim objDal As New dalReference.DSiteDetails
            Dim mLastOpr As String

            Try
                mLastOpr = objDal.GetLastReceipt(pSiteId, pUserId, pConn, pTrans)

                If IsNewORAllowed(mLastOpr) Then
                    ORDate = Now
                End If

            Catch ex As Exception
                Throw
            End Try

        End Sub

        'Public Function LoadViewOR(ByVal pPrspid As Long, Optional ByVal pStartDate As Date? = Nothing, Optional ByVal pEndDate As Date? = Nothing) As DataTable Implements IOrDetails.LoadViewOR

        '    Dim objDAL As New dalReference.DOrDetails
        '    Dim dtLocal As DataTable

        '    Try
        '        dtLocal = objDAL.GetORList(pPrspid, pStartDate, pEndDate)
        '        Return dtLocal
        '    Catch ex As Exception
        '        Throw
        '    End Try
        'End Function

        'Public Function LoadViewOR(ByVal pPrspid As Long, ByVal pDocNumber As Long) As DataTable Implements IOrDetails.LoadViewOR

        '    Dim objDAL As New dalReference.DOrDetails
        '    Dim dtLocal As DataTable

        '    Try
        '        dtLocal = objDAL.GetORList(pPrspid, pDocNumber)

        '        Return dtLocal
        '    Catch ex As Exception
        '        Throw
        '    End Try
        'End Function

        
        Public Function LoadViewOr(ByVal pPrspid As Long, Optional ByVal pStartDate As Date? = Nothing, Optional ByVal pEndDate As Date? = Nothing) As DataTable Implements IOrDetails.LoadViewOR

            Dim objDAL As New dalReference.DOrDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetORList(pPrspid, pStartDate, pEndDate)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewOr(ByVal pPrspid As Long, ByVal pDocNumber As Long) As DataTable Implements IOrDetails.LoadViewOR

            Dim objDAL As New dalReference.DOrDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetORList(pPrspid, pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewOr(ByVal pPrspid As Long, ByVal pStringParam As String, ByVal pStringType As Integer) As DataTable Implements IOrDetails.LoadViewOR

            Dim objDAL As New dalReference.DOrDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetORList(pPrspid, pStringParam, pStringType)

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
