#Region "Description"
' PAGE NAME     : OR Payment Type Class
' CREATED BY    : Ej
' CREATED DATE  : 11/14/2024
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

    Public Class cSIDetails

#Region "Variables"
        Private mSIDetailID As String
        Private mReferenceNo As String
        Private mParticulars As String
        Private mQuantity As Integer
        Private mUnitPrice As Decimal
        Private mAmount As Decimal
#End Region

#Region "Properties"

        Public Property SIDetailID() As String
            Get
                Return mSIDetailID
            End Get
            Set(ByVal value As String)
                mSIDetailID = value
            End Set
        End Property

        Public Property ReferenceNo() As String
            Get
                Return mReferenceNo
            End Get
            Set(ByVal value As String)
                mReferenceNo = value
            End Set
        End Property

        Public Property Particulars() As String
            Get
                Return mParticulars
            End Get
            Set(ByVal value As String)
                mParticulars = value
            End Set
        End Property

        Public Property Quantity() As Integer
            Get
                Return mQuantity
            End Get
            Set(value As Integer)
                mQuantity = value
            End Set
        End Property

        Public Property UnitPrice() As Decimal
            Get
                Return mUnitPrice
            End Get
            Set(value As Decimal)
                mUnitPrice = value
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

#End Region

#Region "Constructor"

        Sub New()
            mSIDetailID = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(pDataRow As DataRow)
            mSIDetailID = pDataRow.Item("id")
            mReferenceNo = pDataRow.Item("reference_no")
            'I#A2:handle null particulars
            mParticulars =
                If(
                    pDataRow.IsNull("particulars"),
                    String.Empty,
                    Convert.ToString(pDataRow.Item("particulars"))
                )
            '/I#A2
            mQuantity = pDataRow.Item("quantity")
            mUnitPrice = pDataRow.Item("unit_price")
            mAmount = pDataRow.Item("amount")
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
