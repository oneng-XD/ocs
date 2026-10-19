#Region "Description"
' PAGE NAME     : SITE_ORVAT BLL
' CREATED BY    : EJ
' CREATED DATE  : 05/04/2015
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

    Public Class BSiteORVAT

#Region "Implements"
        Implements ISiteORVAT
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mGrossAmt As Decimal = cDataType.fDecimal.Empty
        Private mVatableColl As Decimal = cDataType.fDecimal.Empty
        Private mNonVatColl As Decimal = cDataType.fDecimal.Empty
        Private mVatExemptColl As Decimal = cDataType.fDecimal.Empty
        Private mVatAmt As Decimal = cDataType.fDecimal.Empty
        Private mWTaxAmt As Decimal = cDataType.fDecimal.Empty
        Private mNetAmt As Decimal = cDataType.fDecimal.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteORVAT.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteORVAT.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteORVAT.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteORVAT.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteORVAT.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteORVAT.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property ORNmbr() As Long Implements ISiteORVAT.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property GrossAmt() As Decimal Implements ISiteORVAT.GrossAmt
            Get
                Return mGrossAmt
            End Get
            Set(value As Decimal)
                mGrossAmt = value
            End Set
        End Property

        Public Property VatableColl() As Decimal Implements ISiteORVAT.VatableColl
            Get
                Return mVatableColl
            End Get
            Set(value As Decimal)
                mVatableColl = value
            End Set
        End Property

        Public Property NonVatColl() As Decimal Implements ISiteORVAT.NonVatColl
            Get
                Return mNonVatColl
            End Get
            Set(value As Decimal)
                mNonVatColl = value
            End Set
        End Property

        Public Property VatExemptColl() As Decimal Implements ISiteORVAT.VatExemptColl
            Get
                Return mVatExemptColl
            End Get
            Set(value As Decimal)
                mVatExemptColl = value
            End Set
        End Property

        Public Property VatAmt() As Decimal Implements ISiteORVAT.VatAmt
            Get
                Return mVatAmt
            End Get
            Set(value As Decimal)
                mVatAmt = value
            End Set
        End Property

        Public Property WTaxAmt() As Decimal Implements ISiteORVAT.WTaxAmt
            Get
                Return mWTaxAmt
            End Get
            Set(value As Decimal)
                mWTaxAmt = value
            End Set
        End Property

        Public Property NetAmt() As Decimal Implements ISiteORVAT.NetAmt
            Get
                Return mNetAmt
            End Get
            Set(value As Decimal)
                mNetAmt = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pORNmbr As Long, ByVal pGrossAmt As Decimal, ByVal pVatableColl As Decimal,
                ByVal pVatExemptColl As Decimal, ByVal pVatAmt As Decimal, ByVal pWTaxAmt As Decimal,
                ByVal pNetAmt As Decimal, ByVal pStatusId As Integer, ByVal pPostBy As Long, ByVal pPostDate As Date,
                ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date, ByVal pNonVatColl As Decimal)
            Id = pId
            ORNmbr = pORNmbr
            GrossAmt = pGrossAmt
            VatableColl = pVatableColl
            VatExemptColl = pVatExemptColl
            VatAmt = pVatAmt
            WTaxAmt = pWTaxAmt
            NetAmt = pNetAmt
            StatusId = pStatusId
            PostBy = pPostBy
            PostDate = pPostDate
            LastUpdateBy = pLastUpdateBy
            LastUpdate = pLastUpdate
            NonVatColl = pNonVatColl
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Sub GetSiteORVAT(ByVal pDocNumber As Long, ByVal pUserId As Long)

            Dim objDAL As New dalWorking.DSiteORVAT
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetSiteORVAT(pDocNumber, pUserId)
                With drLocal
                    While .Read
                        Id = cDataType.fLong.IfNull(.Item("id"))
                        ORNmbr = cDataType.fLong.IfNull(.Item("or_nmbr"))
                        GrossAmt = cDataType.fDecimal.IfNull(.Item("gross_amt"))
                        VatableColl = cDataType.fDecimal.IfNull(.Item("vatable_coll"))
                        NonVatColl = cDataType.fDecimal.IfNull(.Item("non_vat_coll"))
                        VatExemptColl = cDataType.fDecimal.IfNull(.Item("vatexempt_coll"))
                        VatAmt = cDataType.fDecimal.IfNull(.Item("vat_amt"))
                        WTaxAmt = cDataType.fDecimal.IfNull(.Item("wtax_amt"))
                        NetAmt = cDataType.fDecimal.IfNull(.Item("net_amt"))
                        StatusId = cDataType.fLong.IfNull(.Item("status_id"))
                        PostBy = cDataType.fString.IfNull(.Item("post_by"))
                        PostDate = cDataType.fDate.IfNull(.Item("post_date"))
                        LastUpdateBy = cDataType.fString.IfNull(.Item("last_update_by"))
                        LastUpdate = cDataType.fDate.IfNull(.Item("last_update"))
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try
        End Sub


#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteORVAT
                objDAL.AlterSiteORVAT(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

         End Class

End Namespace
