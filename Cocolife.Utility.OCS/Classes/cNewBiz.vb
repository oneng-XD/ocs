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

    Public Class cNewBiz

#Region "Variables"
        Private mId As String
        Private mPrsPid As Long
        Private mPayPrsPid As Long
        Private mName As String
        Private mApplNo As Long
        Private mLastName As String
        Private mFirstName As String
        Private mMiddleName As String
        Private mDoB As Date
        Private mSuffix As String
        Private mTitle As String
        Private mSex As String
        Private mPlaceOfBirth As String
        Private mEcrNumber As Long
        Private mEcrDate As Date
        Private mAmount As Decimal
#End Region

#Region "Properties"

        Property Id As String
            Get
                Return mId
            End Get
            Set(value As String)
                mId = value
            End Set
        End Property

        Property PrsPid As Long
            Get
                Return mPrsPid
            End Get
            Set(value As Long)
                mPrsPid = value
            End Set
        End Property

        Property PayPrsPid() As Long
            Get
                Return mPayPrsPid
            End Get
            Set(ByVal value As Long)
                mPayPrsPid = value
            End Set
        End Property


        Property Name As String
            Get
                Return mName
            End Get
            Set(value As String)
                mName = value
            End Set
        End Property

        Property ApplNo As Long
            Get
                Return mApplNo
            End Get
            Set(value As Long)
                mApplNo = value
            End Set
        End Property

        Property LastName As String
            Get
                Return mLastName
            End Get
            Set(value As String)
                mLastName = value
            End Set
        End Property

        Property FirstName As String
            Get
                Return mFirstName
            End Get
            Set(value As String)
                mFirstName = value
            End Set
        End Property

        Property MiddleName As String
            Get
                Return mMiddleName
            End Get
            Set(value As String)
                mMiddleName = value
            End Set
        End Property

        Property DoB As Date
            Get
                Return mDoB
            End Get
            Set(value As Date)
                mDoB = value
            End Set
        End Property

        Property Suffix As String
            Get
                Return mSuffix
            End Get
            Set(value As String)
                mSuffix = value
            End Set
        End Property

        Property Title As String
            Get
                Return mTitle
            End Get
            Set(value As String)
                mTitle = value
            End Set
        End Property

        Property Sex As String
            Get
                Return mSex
            End Get
            Set(value As String)
                mSex = value
            End Set
        End Property

        Property PlaceOfBirth As String
            Get
                Return mPlaceOfBirth
            End Get
            Set(value As String)
                mPlaceOfBirth = value
            End Set
        End Property

        Property EcrNumber As Long
            Get
                Return mEcrNumber
            End Get
            Set(value As Long)
                mEcrNumber = value
            End Set
        End Property

        Property EcrDate As Date
            Get
                Return mEcrDate
            End Get
            Set(value As Date)
                mEcrDate = value
            End Set
        End Property

        Property Amount As Decimal
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()
            mId = Guid.NewGuid.ToString.ToUpper
        End Sub

        Sub New(pDataRow As DataRow, pDocType As String)

            mId = Guid.NewGuid.ToString.ToUpper
            mName = pDataRow.Item("ownr_lname")
            mPrsPid = pDataRow.Item("ins_id")
            mPayPrsPid = pDataRow.Item("ownr_id")
            mApplNo = pDataRow.Item("appl_no")
            mLastName = pDataRow.Item("ins_lname")
            mFirstName = pDataRow.Item("ins_fname")
            mMiddleName = pDataRow.Item("ins_mi")
            mDoB = pDataRow.Item("ins_bday")
            mSuffix = pDataRow.Item("ins_sfx")
            mTitle = pDataRow.Item("ins_tit")
            mPlaceOfBirth = pDataRow.Item("ins_plc")
            mEcrNumber = pDataRow.Item("ecr_nmbr")
            mEcrDate = pDataRow.Item("ecr_date")
            mAmount = pDataRow.Item("prem_amt")

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
