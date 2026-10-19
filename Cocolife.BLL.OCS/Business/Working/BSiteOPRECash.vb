#Region "Description"
' PAGE NAME     : SITE_OPRECASH BLL
' CREATED BY    : EJ
' CREATED DATE  : 04/13/2022
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

    Public Class BSiteOPRECash

#Region "Implements"
        Implements ISiteOPRECash
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mPaymentChannel As String = cDataType.fString.Empty
        Private mReferenceNumber As String = cDataType.fString.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mRemarks As String = cDataType.fString.Empty
        Private mServiceFeeRate As Decimal = cDataType.fDecimal.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteOPRECash.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteOPRECash.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteOPRECash.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteOPRECash.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteOPRECash.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteOPRECash.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property OPRNmbr() As Long Implements ISiteOPRECash.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property PaymentChannel() As String Implements ISiteOPRECash.PaymentChannel
            Get
                Return mPaymentChannel
            End Get
            Set(value As String)
                mPaymentChannel = value
            End Set
        End Property

        Public Property ReferenceNumber() As String Implements ISiteOPRECash.ReferenceNumber
            Get
                Return mReferenceNumber
            End Get
            Set(value As String)
                mReferenceNumber = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements ISiteOPRECash.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property Remarks() As String Implements ISiteOPRECash.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property ServiceFeeRate() As Decimal Implements ISiteOPRECash.ServiceFeeRate
            Get
                Return mServiceFeeRate
            End Get
            Set(value As Decimal)
                mServiceFeeRate = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pOPRNmbr As Long, ByVal pPaymentChannel As String, ByVal pReferenceNumber As String, ByVal pAmount As Decimal,
                ByVal pRemarks As String, ByVal pServiceFeeRate As Double, ByVal pStatusId As Integer, ByVal pPostBy As Long, ByVal pPostDate As Date, ByVal pLastUpdateBy As Long,
                ByVal pLastUpdate As Date)
            Id = pId
            OPRNmbr = pOPRNmbr
            PaymentChannel = pPaymentChannel
            ReferenceNumber = pReferenceNumber
            Amount = pAmount
            Remarks = pRemarks
            ServiceFeeRate = pServiceFeeRate
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

        Public Function GetOPRECashDt(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteOPRECash
                Dim dtLocal As DataTable

                dtLocal = objDal.GetSiteOPRECash(pDocNumber, pUserId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteOPRECash
                objDAL.AlterSiteOPRECash(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
