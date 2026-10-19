#Region "Description"
' PAGE NAME     : SITE_ORCOLDTL BLL
' CREATED BY    : IBP
' CREATED DATE  : 03/13/2017
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

    Public Class BSiteORColDtl

#Region "Implements"
        Implements ISiteORColDtl
#End Region

#Region "Variables"

        Private mId As Long = cDataType.fLong.Empty
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mLot As Long = cDataType.fLong.Empty
        Private mProduct As String = cDataType.fString.Empty
        Private mSectionId As String = cDataType.fString.Empty
        Private mSector As String = cDataType.fString.Empty
        Private mBlockNo As String = cDataType.fString.Empty
        Private mLotListPrice As Decimal = cDataType.fDecimal.Empty
        Private mDiscountRate As Decimal = cDataType.fDecimal.Empty
        Private mVAT As Decimal = cDataType.fDecimal.Empty
        Private mReservationAmt As Decimal = cDataType.fDecimal.Empty
        Private mStatusId As Integer = cDataType.fInteger.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty

#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteORColDtl.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteORColDtl.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteORColDtl.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteORColDtl.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteORColDtl.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteORColDtl.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property ORNmbr As Long Implements ISiteORColDtl.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property Lot As Long Implements ISiteORColDtl.Lot
            Get
                Return mLot
            End Get
            Set(value As Long)
                mLot = value
            End Set
        End Property

        Public Property Product As String Implements ISiteORColDtl.Product
            Get
                Return mProduct
            End Get
            Set(value As String)
                mProduct = value
            End Set
        End Property

        Public Property SectionId As String Implements ISiteORColDtl.SectionId
            Get
                Return mSectionId
            End Get
            Set(value As String)
                mSectionId = value
            End Set
        End Property

        Public Property Sector As String Implements ISiteORColDtl.Sector
            Get
                Return mSector
            End Get
            Set(value As String)
                mSector = value
            End Set
        End Property

        Public Property BlockNo As String Implements ISiteORColDtl.BlockNo
            Get
                Return mBlockNo
            End Get
            Set(value As String)
                mBlockNo = value
            End Set
        End Property

        Public Property LotListPrice As Decimal Implements ISiteORColDtl.LotListPrice
            Get
                Return mLotListPrice
            End Get
            Set(value As Decimal)
                mLotListPrice = value
            End Set
        End Property

        Public Property DiscountRate As Decimal Implements ISiteORColDtl.DiscountRate
            Get
                Return mDiscountRate
            End Get
            Set(value As Decimal)
                mDiscountRate = value
            End Set
        End Property

        Public Property VAT As Decimal Implements ISiteORColDtl.VAT
            Get
                Return mVAT
            End Get
            Set(value As Decimal)
                mVAT = value
            End Set
        End Property

        Public Property ReservationAmt As Decimal Implements ISiteORColDtl.ReservationAmt
            Get
                Return mReservationAmt
            End Get
            Set(value As Decimal)
                mReservationAmt = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pORNmbr As Long, ByVal pLot As Long, ByVal pProduct As String, _
                ByVal pSectionId As String, ByVal pSector As String, ByVal pBlockNo As String, _
                ByVal pLotListPrice As Decimal, ByVal pDiscountRate As Decimal, ByVal pVAT As Decimal, ByVal pReservationAmt As Decimal, _
                ByVal pStatusId As Integer, ByVal pPostBy As String, ByVal pPostDate As Date, _
                ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            ORNmbr = pORNmbr
            Lot = pLot
            Product = pProduct
            SectionId = pSectionId
            Sector = pSector
            BlockNo = pBlockNo
            LotListPrice = pLotListPrice
            DiscountRate = pDiscountRate
            VAT = pVAT
            ReservationAmt = pReservationAmt
            StatusId = pStatusId
            PostBy = pPostBy
            PostDate = pPostDate
            LastUpdateBy = pLastUpdateBy
            LastUpdate = pLastUpdate
        End Sub

#End Region

#Region "Single Point Function"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"
        Public Function GetORColDtl(ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Try
                Dim objDal As New dalWorking.DSiteORColDtl
                Dim dtLocal As DataTable

                dtLocal = objDal.GetSiteORColDtl(pDocNumber, pUserId)

                Return dtLocal

            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteORColDtl
                objDAL.AlterSiteORColDtl(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
