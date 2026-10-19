#Region "Description"
' PAGE NAME     : Print Receipt BLL
' CREATED BY    : EJ
' CREATED DATE  : 11/10/2017
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

    Public Class BPrintReceipt

#Region "Implements"
        Implements IPrintReceipt
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mIsPrinted As Boolean = cDataType.fBoolean.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements IPrintReceipt.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property IsPrinted() As Boolean Implements IPrintReceipt.IsPrinted
            Get
                Return mIsPrinted
            End Get
            Set(value As Boolean)
                mIsPrinted = value
            End Set
        End Property

        Public Property StatusId As Integer Implements IPrintReceipt.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property PostBy As Long Implements IPrintReceipt.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements IPrintReceipt.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements IPrintReceipt.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements IPrintReceipt.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property


#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pIsPrinted As Boolean, ByVal pStatusId As Integer,
                ByVal pPostBy As Long, ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            IsPrinted = pIsPrinted
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
        'dtLocal = objBLL.LoadPremReceipt(.RptParamString)
        'objBLL.WriteReceipt(dtLocal, ConnStr)

        Public Function LoadPremReceipt(ByVal Params As String) As DataTable
            Try
                Dim objDal As New dalWorking.DPrintReceipt
                Dim dtLocal As DataTable

                Dim Para = Split(Params, "|")
                Dim DocNumber As Long = CLng(Para(0))
                'Dim HasPrintButton As Boolean = CBool(Para(1)) 'UNUSED HERE
                Dim SiteCode As Long = Para(2)
                Dim UserId As Long = Para(3)

                dtLocal = objDal.LoadPremReceipt(SiteCode, DocNumber, UserId)

                Return dtLocal
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function WriteReceipt(ByVal Data As DataTable, ByVal ConnStr As String) As Long

            Try
                Dim objDAL As New dalWorking.DPrintReceipt
                objDAL.WriteReceipt(Data, ConnStr)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Sub DeleteReceipts(ByVal ConnStr As String)

            Try
                Dim objDal As New dalWorking.DPrintReceipt
                objDal.DeleteReceipts(ConnStr)
            Catch ex As Exception
                Throw
            End Try

        End Sub

#End Region

    End Class

End Namespace
