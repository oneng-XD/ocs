#Region "Description"
' PAGE NAME     : Check Tagging Class
' CREATED BY    : EJC
' CREATED DATE  : 10/30/2018
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
#End Region

Namespace Classes

    Public Class cCheckTagging

#Region "Variables"
        Private mIsSelected As Boolean

        ' -------------------------------------------------------------------------------
        Private mTaggingEditId As Long
        Private mReceiptNo As Long
        Private mReceiptDate As Date
        Private mCheckNumber As Long
        Private mCheckBankName As String
        Private mCheckBankBranch As String
        Private mCheckAmount As Decimal
        Private mCheckLineNumber As Integer
        Private mCheckOTCFlag As Integer
        Private mTaggingDepositDate As Date
        Private mTaggingClearingDate As Date
        Private mTaggingClearingStatusId As Integer
        Private mTaggingClearingStatus As String
        Private mTaggingRemarks As String
        Private mStatusId As Integer
        Private mPostBy As Long
        Private mPostDate As Date
        Private mLastUpdateBy As Long
        Private mLastUpdate As Date
#End Region

#Region "Properties"

        ' -------------------------------------------------------------------------------
        Public Property TaggingEditId As Long
            Get
                Return mTaggingEditId
            End Get
            Set(value As Long)
                mTaggingEditId = value
            End Set
        End Property

        Public Property ReceiptNo As Long
            Get
                Return mReceiptNo
            End Get
            Set(value As Long)
                mReceiptNo = value
            End Set
        End Property
        Public Property ReceiptDate As Date
            Get
                Return mReceiptDate
            End Get
            Set(value As Date)
                mReceiptDate = value
            End Set
        End Property


        Public Property CheckNumber As Long
            Get
                Return mCheckNumber
            End Get
            Set(value As Long)
                mCheckNumber = value
            End Set
        End Property

        Public Property CheckBankName As String
            Get
                Return mCheckBankName
            End Get
            Set(value As String)
                mCheckBankName = value
            End Set
        End Property

        Public Property CheckBankBranch As String
            Get
                Return mCheckBankBranch
            End Get
            Set(value As String)
                mCheckBankBranch = value
            End Set
        End Property

        Public Property CheckAmount As Decimal
            Get
                Return mCheckAmount
            End Get
            Set(value As Decimal)
                mCheckAmount = value
            End Set
        End Property

        Public Property CheckLineNumber As Integer
            Get
                Return mCheckLineNumber
            End Get
            Set(value As Integer)
                mCheckLineNumber = value
            End Set
        End Property

        Public Property CheckOTCFlag As Integer
            Get
                Return mCheckOTCFlag
            End Get
            Set(value As Integer)
                mCheckOTCFlag = value
            End Set
        End Property

        Public Property TaggingDepositDate As Date
            Get
                Return mTaggingDepositDate
            End Get
            Set(value As Date)
                mTaggingDepositDate = value
            End Set
        End Property

        Public Property TaggingClearingDate As Date
            Get
                Return mTaggingClearingDate
            End Get
            Set(value As Date)
                mTaggingClearingDate = value
            End Set
        End Property

        Public Property TaggingClearingStatusId As Integer
            Get
                Return mTaggingClearingStatusId
            End Get
            Set(value As Integer)
                mTaggingClearingStatusId = value
            End Set
        End Property

        Public Property TaggingClearingStatus As String
            Get
                Return mTaggingClearingStatus
            End Get
            Set(value As String)
                mTaggingClearingStatus = value
            End Set
        End Property

        Public Property TaggingRemarks As String
            Get
                Return mTaggingRemarks
            End Get
            Set(value As String)
                mTaggingRemarks = value
            End Set
        End Property

        Public Property StatusId As Integer
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property PostBy As Long
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property LastUpdate As Date
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

        Sub New(pDataRow As DataRow)
            mTaggingEditId = pDataRow.Item("id")
            mReceiptNo = pDataRow.Item("opr_nmbr")
            mCheckNumber = pDataRow.Item("chk_nmbr")
            mCheckBankName = pDataRow.Item("bank")
            mCheckBankBranch = pDataRow.Item("branch")
            mCheckAmount = pDataRow.Item("amount")
            mCheckLineNumber = pDataRow.Item("line_number")
            mCheckOTCFlag = pDataRow.Item("otc_flag")
            mTaggingDepositDate = pDataRow.Item("deposit_date")
            mTaggingClearingDate = pDataRow.Item("clearing_date")
            mTaggingClearingStatusId = pDataRow.Item("clearing_status_id")
            mTaggingRemarks = pDataRow.Item("remarks")
            mStatusId = pDataRow.Item("status_id")
            mPostBy = pDataRow.Item("post_by")
            mPostDate = pDataRow.Item("post_date")
            mLastUpdateBy = pDataRow.Item("last_update_by")
            mLastUpdate = pDataRow.Item("last_update")

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace
