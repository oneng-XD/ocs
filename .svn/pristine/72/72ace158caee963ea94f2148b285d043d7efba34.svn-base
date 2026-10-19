#Region "Description"
' PAGE NAME     : STG_OPRVAT BLL
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

    Public Class BStgOPRVAT

#Region "Implements"
        Implements Staging.IStgOPRVAT
#End Region

#Region "Variables"
        Private mOPRNmbr As Long = cDataType.fLong.Empty
        Private mGrossAmt As Decimal = cDataType.fDecimal.Empty
        Private mVatableColl As Decimal = cDataType.fDecimal.Empty
        Private mVatExemptColl As Decimal = cDataType.fDecimal.Empty
        Private mVatAmt As Decimal = cDataType.fDecimal.Empty
        Private mWTaxAmt As Decimal = cDataType.fDecimal.Empty
        Private mNetAmt As Decimal = cDataType.fDecimal.Empty
#End Region

#Region "Properties"

        Public Property OPRNmbr() As Long Implements Staging.IStgOPRVAT.OPRNmbr
            Get
                Return mOPRNmbr
            End Get
            Set(value As Long)
                mOPRNmbr = value
            End Set
        End Property

        Public Property GrossAmt() As Decimal Implements Staging.IStgOPRVAT.GrossAmt
            Get
                Return mGrossAmt
            End Get
            Set(value As Decimal)
                mGrossAmt = value
            End Set
        End Property

        Public Property VatableColl() As Decimal Implements Staging.IStgOPRVAT.VatableColl
            Get
                Return mVatableColl
            End Get
            Set(value As Decimal)
                mVatableColl = value
            End Set
        End Property

        Public Property VatExemptColl() As Decimal Implements Staging.IStgOPRVAT.VatExemptColl
            Get
                Return mVatExemptColl
            End Get
            Set(value As Decimal)
                mVatExemptColl = value
            End Set
        End Property

        Public Property VatAmt() As Decimal Implements Staging.IStgOPRVAT.VatAmt
            Get
                Return mVatAmt
            End Get
            Set(value As Decimal)
                mVatAmt = value
            End Set
        End Property

        Public Property WTaxAmt() As Decimal Implements Staging.IStgOPRVAT.WTaxAmt
            Get
                Return mWTaxAmt
            End Get
            Set(value As Decimal)
                mWTaxAmt = value
            End Set
        End Property

        Public Property NetAmt() As Decimal Implements Staging.IStgOPRVAT.NetAmt
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

        Sub New(ByVal pObject As Working.BSiteOPRVAT)
            With pObject
                OPRNmbr = .OPRNmbr
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

        Public Sub GetStgOPRVAT(ByVal pDocNumber As Long)

            Dim objDAL As New dalStaging.DStgOPRVAT
            Dim drLocal As OracleDataReader

            Try

                drLocal = objDAL.GetStgOPRVat(pDocNumber)
                With drLocal
                    While .Read
                        OPRNmbr = cDataType.fLong.IfNull(.Item("opr_nmbr"))
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
                Dim objDAL As New dalStaging.DStgOPRVAT
                objDAL.AlterStgOPRVAT(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
