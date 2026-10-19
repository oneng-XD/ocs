#Region "Description"
' PAGE NAME     : Payment Type Class
' CREATED BY    : EJ
' CREATED DATE  : 09/30/2016
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

    Public Class cReceiptDetail
#Region "Variables"
        Private mIsSelected As Boolean
        Private mReceiptID As String
        Private mTrnxCode As Long
        Private mActType As String
        Private mTrnxDesc As String
        Private mDueDate As Date
        Private mAmount As Decimal
        Private mLineNumber As Integer
        Private mReceiptType As String
#End Region

#Region "Properties"

        Public Property IsSelected() As String
            Get
                Return mIsSelected
            End Get
            Set(ByVal value As String)
                mIsSelected = value
            End Set
        End Property

        Public Property ReceiptID() As String
            Get
                Return mReceiptID
            End Get
            Set(ByVal value As String)
                mReceiptID = value
            End Set
        End Property

        Public Property TrnxCode() As Long
            Get
                Return mTrnxCode
            End Get
            Set(ByVal value As Long)
                mTrnxCode = value
            End Set
        End Property

        Public Property ActType() As String
            Get
                Return mActType
            End Get
            Set(ByVal value As String)
                mActType = value
            End Set
        End Property

        Public Property TrnxDesc() As String
            Get
                Return mTrnxDesc
            End Get
            Set(value As String)
                mTrnxDesc = value
            End Set
        End Property

        Public Property DueDate() As Date
            Get
                Return mDueDate
            End Get
            Set(value As Date)
                mDueDate = value
            End Set
        End Property

        Public Property Amount() As Decimal
            Get
                Return mAmount
            End Get
            Set(ByVal value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNumber() As Integer
            Get
                Return mLineNumber
            End Get
            Set(ByVal value As Integer)
                mLineNumber = value
            End Set
        End Property

        Public Property ReceiptType() As String
            Get
                Return mReceiptType
            End Get
            Set(value As String)
                mReceiptType = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()
            mReceiptID = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(pDataRow As DataRow, pDocType As String)
            mReceiptID = Guid.NewGuid.ToString.ToUpper
            mTrnxCode = pDataRow.Item("trnx_code")
            mActType = pDataRow.Item("act_type")
            mTrnxDesc = pDataRow.Item("trnx_desc")
            mDueDate = pDataRow.Item("due_date")
            mAmount = pDataRow.Item("amount")
            mLineNumber = pDataRow.Item("line_nmbr")
            mReceiptType = pDocType
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
