#Region "Description"
' PAGE NAME     : STG_ORVAT BLL
' CREATED BY    : MPRO
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
Imports dalStaging = Cocolife.DAL.OCS.Staging
#End Region

Namespace Staging

    Public Class BStgORVAT

#Region "Implements"
        Implements Staging.IStgORVAT
#End Region

#Region "Variables"
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mGrossAmt As Decimal = cDataType.fDecimal.Empty
        Private mVatableColl As Decimal = cDataType.fDecimal.Empty
        Private mVatExemptColl As Decimal = cDataType.fDecimal.Empty
        Private mVatAmt As Decimal = cDataType.fDecimal.Empty
        Private mWTaxAmt As Decimal = cDataType.fDecimal.Empty
        Private mNetAmt As Decimal = cDataType.fDecimal.Empty
#End Region

#Region "Properties"

        Public Property ORNmbr() As Long Implements Staging.IStgORVAT.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property GrossAmt() As Decimal Implements Staging.IStgORVAT.GrossAmt
            Get
                Return mGrossAmt
            End Get
            Set(value As Decimal)
                mGrossAmt = value
            End Set
        End Property

        Public Property VatableColl() As Decimal Implements Staging.IStgORVAT.VatableColl
            Get
                Return mVatableColl
            End Get
            Set(value As Decimal)
                mVatableColl = value
            End Set
        End Property

        Public Property VatExemptColl() As Decimal Implements Staging.IStgORVAT.VatExemptColl
            Get
                Return mVatExemptColl
            End Get
            Set(value As Decimal)
                mVatExemptColl = value
            End Set
        End Property

        Public Property VatAmt() As Decimal Implements Staging.IStgORVAT.VatAmt
            Get
                Return mVatAmt
            End Get
            Set(value As Decimal)
                mVatAmt = value
            End Set
        End Property

        Public Property WTaxAmt() As Decimal Implements Staging.IStgORVAT.WTaxAmt
            Get
                Return mWTaxAmt
            End Get
            Set(value As Decimal)
                mWTaxAmt = value
            End Set
        End Property

        Public Property NetAmt() As Decimal Implements Staging.IStgORVAT.NetAmt
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

        Sub New(ByVal pORNmbr As Long, ByVal pGrossAmt As Decimal, ByVal pVatableColl As Decimal,
                ByVal pVatExemptColl As Decimal, ByVal pVatAmt As Decimal, ByVal pWTaxAmt As Decimal,
                ByVal pNetAmt As Decimal)
            ORNmbr = pORNmbr
            GrossAmt = pGrossAmt
            VatableColl = pVatableColl
            VatExemptColl = pVatExemptColl
            VatAmt = pVatAmt
            WTaxAmt = pWTaxAmt
            NetAmt = pNetAmt
        End Sub

        Sub New(ByVal pObject As Working.BSiteORVAT)
            With pObject
                ORNmbr = .ORNmbr
                GrossAmt = .GrossAmt
                VatableColl = .VatableColl
                VatExemptColl = .VatExemptColl
                VatAmt = .VatAmt
                WTaxAmt = .WTaxAmt
                NetAmt = .NetAmt
            End With
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Sub GetStgORVAT(ByVal pDocNumber As Long)

            Dim objDAL As New dalStaging.DStgORVAT
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetStgORVAT(pDocNumber)
                With drLocal
                    While .Read
                        ORNmbr = cDataType.fLong.IfNull(.Item("or_nmbr"))
                        GrossAmt = cDataType.fDecimal.IfNull(.Item("gross_amt"))
                        VatableColl = cDataType.fDecimal.IfNull(.Item("vatable_coll"))
                        VatExemptColl = cDataType.fDecimal.IfNull(.Item("vatexempt_coll"))
                        VatAmt = cDataType.fDecimal.IfNull(.Item("vat_amt"))
                        WTaxAmt = cDataType.fDecimal.IfNull(.Item("wtax_amt"))
                        NetAmt = cDataType.fDecimal.IfNull(.Item("net_amt"))
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
                Dim objDAL As New dalStaging.DStgORVAT
                objDAL.AlterStgORVAT(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
