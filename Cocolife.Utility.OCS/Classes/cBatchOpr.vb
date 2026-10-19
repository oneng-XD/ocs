#Region "Description"
' PAGE NAME     : Batch Opr Class
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

    Public Class cBatchOpr
#Region "Variables"
        Private mOprId As String
        Private mOprNumber As Long
        Private mPocId As Long
        Private mName As String
        Private mPolicyName As String
        Private mGross As Decimal
        Private mLife As Decimal
        Private mNonLife As Decimal
        Private mNLPremium As Decimal
        Private mDST As Decimal
        Private mPremTax As Decimal
        Private mLGT As Decimal
#End Region

#Region "Properties"

        Public Property OprId As String
            Get
                Return mOprId
            End Get
            Set(value As String)
                mOprId = value
            End Set
        End Property

        Public Property OprNumber As Long
            Get
                Return mOprNumber
            End Get
            Set(ByVal value As Long)
                mOprNumber = value
            End Set
        End Property

        Public Property PocId As Long
            Get
                Return mPocId
            End Get
            Set(ByVal value As Long)
                mPocId = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value
            End Set
        End Property

        Public Property PolicyName As String
            Get
                Return mPolicyName
            End Get
            Set(ByVal value As String)
                mPolicyName = value
            End Set
        End Property

        Public Property Gross As Decimal
            Get
                Return mGross
            End Get
            Set(ByVal value As Decimal)
                mGross = value
            End Set
        End Property

        Public Property Life As Decimal
            Get
                Return mLife
            End Get
            Set(ByVal value As Decimal)
                mLife = value
            End Set
        End Property

        Public Property NonLife As Decimal
            Get
                Return mNonLife
            End Get
            Set(ByVal value As Decimal)
                mNonLife = value
            End Set
        End Property

        Public Property NLPremium As Decimal
            Get
                Return mNLPremium
            End Get
            Set(ByVal value As Decimal)
                mNLPremium = value
            End Set
        End Property

        Public Property DST As Decimal
            Get
                Return mDST
            End Get
            Set(ByVal value As Decimal)
                mDST = value
            End Set
        End Property

        Public Property PremTax As Decimal
            Get
                Return mPremTax
            End Get
            Set(ByVal value As Decimal)
                mPremTax = value
            End Set
        End Property

        Public Property LGT As Decimal
            Get
                Return mLGT
            End Get
            Set(ByVal value As Decimal)
                mLGT = value
            End Set
        End Property


#End Region

#Region "Constructor"

        Sub New()
            mOprId = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(pDataRow As DataRow)
            mOprId = Guid.NewGuid.ToString.ToUpper
            mOprNumber = pDataRow.Item("opr_nmbr")
            mPocId = pDataRow.Item("poc_id")
            mName = pDataRow.Item("insured_name")
            mPolicyName = pDataRow.Item("policy_name")
            mGross = pDataRow.Item("opr_amt")
            mLife = pDataRow.Item("gross_life")
            mNonLife = pDataRow.Item("gross_nonlife")
            mNLPremium = pDataRow.Item("nonlife_premium")
            mDST = pDataRow.Item("dst_nonlife")
            mPremTax = pDataRow.Item("prem_tax_nonlife")
            mLGT = pDataRow.Item("local_tax_nonlife")
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
