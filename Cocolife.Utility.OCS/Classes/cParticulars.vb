#Region "Description"
' PAGE NAME     : Particulars Class
' CREATED BY    : IBP
' CREATED DATE  : 02/22/2017
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

    Public Class cParticulars

#Region "Variables"
        Private mParticularsID As String = cDataType.fLong.Empty
        Private mParticularItem As String
        Private mItemAmount As Decimal
#End Region

#Region "Properties"

        Public Property ParticularsID As String
            Get
                Return mParticularsID
            End Get
            Set(ByVal value As String)
                mParticularsID = value
            End Set
        End Property

        Public Property ParticularItem() As String
            Get
                Return mParticularItem
            End Get
            Set(ByVal value As String)
                mParticularItem = value
            End Set
        End Property

        Public Property ItemAmount() As Decimal
            Get
                Return mItemAmount
            End Get
            Set(value As Decimal)
                mItemAmount = value
            End Set
        End Property

#End Region

#Region "Constructor"
        Sub New()

        End Sub

        Sub New(pDataRow As DataRow, pDocType As String)
            mParticularsID = Guid.NewGuid.ToString.ToUpper
            mParticularItem = pDataRow.Item("Particular")
            mItemAmount = pDataRow.Item("Amount")
        End Sub

        Sub New(ByVal pAmount As Decimal, ByVal pParticular As String)
            mParticularsID = Guid.NewGuid.ToString.ToUpper
            mItemAmount = pAmount
            mParticularItem = pParticular
        End Sub
#End Region

#Region "Single Point Function"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

#End Region

    End Class
End Namespace
