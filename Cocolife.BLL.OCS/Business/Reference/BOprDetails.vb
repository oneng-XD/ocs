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
Imports dalReference = Cocolife.DAL.OCS.Reference
Imports dalMaintenance = Cocolife.DAL.OCS.Maintenance
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
#End Region

Namespace Reference

    Public Class BOprDetails

#Region "Implements"
        Implements IOprDetails
#End Region

#Region "Variables"
        Private mOPRDate As Date
        Private mOPRNumber As Long
        Private mOPRPosted As Boolean
        Private mOPRPrinted As Boolean
#End Region

#Region "Properties"

        Public Property OPRDate As Date Implements IOprDetails.OPRDate
            Get
                Return mOPRDate
            End Get
            Set(value As Date)
                mOPRDate = value
            End Set
        End Property

        Public Property OPRNumber As Long Implements IOprDetails.OPRNumber
            Get
                Return mOPRNumber
            End Get
            Set(value As Long)
                mOPRNumber = value
            End Set
        End Property

        Public Property OPRPosted As Boolean Implements IOprDetails.OPRPosted
            Get
                Return mOPRPosted
            End Get
            Set(value As Boolean)
                mOPRPosted = value
            End Set
        End Property

        Public Property OPRPrinted As Boolean Implements IOprDetails.OPRPrinted
            Get
                Return mOPRPrinted
            End Get
            Set(value As Boolean)
                mOPRPrinted = value
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

        Public Function IsNewOPRAllowed(ByVal pNextDocNumber As String) As Boolean Implements IOprDetails.IsNewOPRAllowed
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

        Public Function IsOprProcessed(ByVal pDocNumber As Long, Optional ByVal pDate As Date = Nothing) As Boolean Implements IOprDetails.IsOprProcessed
            Dim objDal As New dalReference.DSiteDetails
            Dim mCount As String

            Try
                mCount = objDal.IsOprProcessed(pDocNumber, pDate)

                If CLng(mCount) > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Data Retrieval"

        Public Sub LoadNewOPR(ByVal pSiteId As Long, ByVal pReceiptType As Integer, ByVal pUserId As Long, Optional ByRef pConn As Object = Nothing, Optional ByRef pTrans As Object = Nothing) Implements IOprDetails.LoadNewOPR
            Dim objDal As New dalReference.DSiteDetails
            Dim mLastOpr As String

            Try
                mLastOpr = objDal.GetLastReceipt(pSiteId, pUserId, pConn, pTrans)

                If IsNewOPRAllowed(mLastOpr) Then
                    OPRDate = Now
                End If

            Catch ex As Exception
                Throw
            End Try

        End Sub

        Public Function LoadNextOPR(ByVal pSiteId As Long, ByVal pReceiptType As Integer, ByVal pUserId As Long) As Long Implements IOprDetails.LoadNextOPR
            Dim objDal As New dalReference.DSiteDetails
            Dim mNextOpr As Long

            Try
                mNextOpr = objDal.GetNextReceipt(pSiteId, pReceiptType, pUserId)

                Return mNextOpr

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function LoadViewOPR(ByVal pPrspid As Long, ByVal pIsBatch As Boolean, Optional ByVal pStartDate As Date? = Nothing, Optional ByVal pEndDate As Date? = Nothing) As DataTable Implements IOprDetails.LoadViewOPR

            Dim objDAL As New dalReference.DOprDetails
            Dim dtLocal As DataTable
            Dim mParamType As Integer


            Try
                If pIsBatch Then mParamType = 4

                dtLocal = objDAL.GetOPRList(pPrspid, mParamType, pStartDate, pEndDate)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewOPR(ByVal pPrspid As Long, ByVal pDocNumber As Long) As DataTable Implements IOprDetails.LoadViewOPR

            Dim objDAL As New dalReference.DOprDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetOPRList(pPrspid, pDocNumber)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function LoadViewOPR(ByVal pPrspid As Long, ByVal pStringParam As String, ByVal pStringType As Integer) As DataTable Implements IOprDetails.LoadViewOPR

            Dim objDAL As New dalReference.DOprDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.GetOPRList(pPrspid, pStringParam, pStringType)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GetNewApplicationNo() As Long Implements IOprDetails.GetNewApplicationNo

            Dim objDAL As New dalReference.DOprDetails
            Dim lngLocal As Long

            Try
                lngLocal = objDAL.GetNewApplicationNo
                Return lngLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GetCalcODI(ByVal pPolicyNumber As String, ByVal pTrndat As Date, ByVal pPremium As Decimal, ByVal pPolType As String) As Decimal Implements IOprDetails.GetCalcODI
            Dim objDAL As New dalReference.DOprDetails
            Dim decLocal As Decimal

            Try
                Select Case pPolType
                    Case "V"
                        decLocal = objDAL.GetCalcODIVL(pPolicyNumber, pTrndat, pPremium)
                    Case Else
                        decLocal = objDAL.GetCalcODI(pPolicyNumber, pTrndat, pPremium)
                End Select

                Return decLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function GetPremiumBreakdown(ByVal pPolicyNumber As String) As DataTable Implements IOprDetails.GetPremiumBreakdown
            Dim objDal As New dalReference.DOprDetails
            Dim dtLocal As DataTable

            Try
                dtLocal = objDal.GetPremiumBreakdown(pPolicyNumber)

                Return dtLocal

            Catch ex As Exception
                Throw New ArgumentException("Exception Occured")
            End Try
        End Function

        Public Function GetBatchOprList(ByVal pBatchId As Long) As DataTable Implements IOprDetails.GetBatchOprList
            Dim objDAL As New dalReference.DOprDetails

            Try
                Return objDAL.GetBatchOprList(pBatchId)
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace

