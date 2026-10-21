#Region "Description"
' PAGE NAME     : SP_NGI_POST_NEW_OCS_PAYMENT BLL
' CREATED BY    : EJ
' CREATED DATE  : 04/15/2021
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

    Public Class BNewgenLifePayment

#Region "Implements"
        Implements Staging.INewgenLifePayment
#End Region

#Region "Variables"
        Private mORNo As String = String.Empty
        Private mDateOfReceipt As String = String.Empty
        Private mApplicationNo As String = String.Empty
        Private mPolicyNo As String = String.Empty
        Private mPayorName As String = String.Empty
        Private mAPR As String = String.Empty
        Private mAPRDate As String = String.Empty
        Private mCurrency As String = String.Empty
        Private mTotalAmount As String = String.Empty
        Private mVATableCollection As String = String.Empty
        Private mNonVATCollection As String = String.Empty
        Private mVATExemptCollection As String = String.Empty
        Private mVATAmount As String = String.Empty
        Private mVATTotalCollection As String = String.Empty
        Private mVATWithholdingTax As String = String.Empty
        Private mVATAmountNetWTax As String = String.Empty
        Private mBusinessType As String = String.Empty
        Private mBillNo As String = String.Empty
        Private mSubsNo As String = String.Empty
        Private mPayorTin As String = String.Empty
        Private mPayorAddress As String = String.Empty
        Private mRetainedAmount As String = String.Empty
        Private mPaymentStatus As String = String.Empty
        Private mRemarks As String = String.Empty
        Private mParticularsJSON As String = String.Empty
        Private mPaymentModeJSON As String = String.Empty
#End Region

#Region "Properties"

        Public Property ORNo As String Implements Staging.INewgenLifePayment.ORNo
            Get
                Return mORNo
            End Get
            Set(value As String)
                mORNo = value
            End Set
        End Property

        Public Property DateOfReceipt As String Implements Staging.INewgenLifePayment.DateOfReceipt
            Get
                Return mDateOfReceipt
            End Get
            Set(value As String)
                mDateOfReceipt = value
            End Set
        End Property

        Public Property ApplicationNo As String Implements Staging.INewgenLifePayment.ApplicationNo
            Get
                Return mApplicationNo
            End Get
            Set(value As String)
                mApplicationNo = value
            End Set
        End Property

        Public Property PolicyNo As String Implements Staging.INewgenLifePayment.PolicyNo
            Get
                Return mPolicyNo
            End Get
            Set(value As String)
                mPolicyNo = value
            End Set
        End Property

        Public Property PayorName As String Implements Staging.INewgenLifePayment.PayorName
            Get
                Return mPayorName
            End Get
            Set(value As String)
                mPayorName = value
            End Set
        End Property

        Public Property APR As String Implements Staging.INewgenLifePayment.APR
            Get
                Return mAPR
            End Get
            Set(value As String)
                mAPR = value
            End Set
        End Property

        Public Property APRDate As String Implements Staging.INewgenLifePayment.APRDate
            Get
                Return mAPRDate
            End Get
            Set(value As String)
                mAPRDate = value
            End Set
        End Property

        Public Property Currency As String Implements Staging.INewgenLifePayment.Currency
            Get
                Return mCurrency
            End Get
            Set(value As String)
                mCurrency = value
            End Set
        End Property

        Public Property TotalAmount As String Implements Staging.INewgenLifePayment.TotalAmount
            Get
                Return mTotalAmount
            End Get
            Set(value As String)
                mTotalAmount = value
            End Set
        End Property
        Public Property VATableCollection As String Implements Staging.INewgenLifePayment.VATableCollection
            Get
                Return mVATableCollection
            End Get
            Set(value As String)
                mVATableCollection = value
            End Set
        End Property
        Public Property NonVatCollection As String Implements Staging.INewgenLifePayment.NonVatCollection
            Get
                Return mNonVATCollection
            End Get
            Set(value As String)
                mNonVATCollection = value
            End Set
        End Property
        Public Property VATExemptCollection As String Implements Staging.INewgenLifePayment.VATExemptCollection
            Get
                Return mVATExemptCollection
            End Get
            Set(value As String)
                mVATExemptCollection = value
            End Set
        End Property
        Public Property VATAmount As String Implements Staging.INewgenLifePayment.VATAmount
            Get
                Return mVATAmount
            End Get
            Set(value As String)
                mVATAmount = value
            End Set
        End Property
        Public Property VATTotalCollection As String Implements Staging.INewgenLifePayment.VATTotalCollection
            Get
                Return mVATTotalCollection
            End Get
            Set(value As String)
                mVATTotalCollection = value
            End Set
        End Property
        Public Property VATWithholdingTax As String Implements Staging.INewgenLifePayment.VATWithholdingTax
            Get
                Return mVATWithholdingTax
            End Get
            Set(value As String)
                mVATWithholdingTax = value
            End Set
        End Property
        Public Property VATAmountNetWTax As String Implements Staging.INewgenLifePayment.VATAmountNetWTax
            Get
                Return mVATAmountNetWTax
            End Get
            Set(value As String)
                mVATAmountNetWTax = value
            End Set
        End Property

        Public Property BusinessType As String Implements Staging.INewgenLifePayment.BusinessType
            Get
                Return mBusinessType
            End Get
            Set(value As String)
                mBusinessType = value
            End Set
        End Property

        Public Property BillNo As String Implements Staging.INewgenLifePayment.BillNo
            Get
                Return mBillNo
            End Get
            Set(value As String)
                mBillNo = value
            End Set
        End Property
        Public Property SubsNo As String Implements Staging.INewgenLifePayment.SubsNo
            Get
                Return mSubsNo
            End Get
            Set(value As String)
                mSubsNo = value
            End Set
        End Property
        Public Property PayorTin As String Implements Staging.INewgenLifePayment.PayorTin
            Get
                Return mPayorTin
            End Get
            Set(value As String)
                mPayorTin = value
            End Set
        End Property
        Public Property PayorAddress As String Implements Staging.INewgenLifePayment.PayorAddress
            Get
                Return mPayorAddress
            End Get
            Set(value As String)
                mPayorAddress = value
            End Set
        End Property

        Public Property RetainedAmount As String Implements Staging.INewgenLifePayment.RetainedAmount
            Get
                Return mRetainedAmount
            End Get
            Set(value As String)
                mRetainedAmount = value
            End Set
        End Property

        Public Property PaymentStatus As String Implements Staging.INewgenLifePayment.PaymentStatus
            Get
                Return mPaymentStatus
            End Get
            Set(value As String)
                mPaymentStatus = value
            End Set
        End Property

        Public Property Remarks As String Implements Staging.INewgenLifePayment.Remarks
            Get
                Return mRemarks
            End Get
            Set(value As String)
                mRemarks = value
            End Set
        End Property

        Public Property ParticularsJSON As String Implements Staging.INewgenLifePayment.ParticularsJSON
            Get
                Return mParticularsJSON
            End Get
            Set(value As String)
                mParticularsJSON = value
            End Set
        End Property

        Public Property PaymentModeJSON As String Implements Staging.INewgenLifePayment.PaymentModeJSON
            Get
                Return mPaymentModeJSON
            End Get
            Set(value As String)
                mPaymentModeJSON = value
            End Set
        End Property


#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pORNo As String, ByVal pDateOfReceipt As String, ByVal pApplicationNo As String, ByVal pPolicyNo As String,
                ByVal pPayorName As String, ByVal pAPR As String, ByVal pAPRDate As String, ByVal pCurrency As String,
                ByVal pTotalAmount As String, ByVal pVATableCollection As String, ByVal pNonVatCollection As String, ByVal pVATExemptCollection As String, ByVal pVATAmount As String, ByVal pVATTotalCollection As String, ByVal pVATWithholdingTax As String, ByVal pVATAmountNetWTax As String,
                ByVal pBusinessType As String, ByVal pBillNo As String, ByVal pSubsNo As String, ByVal pPayorTin As String, ByVal pPayorAddress As String, ByVal pRetainedAmount As String,
                ByVal pPaymentStatus As String, ByVal pRemarks As String, ByVal pParticularsJSON As String,
                ByVal pPaymentModeJSON As String)
            ORNo = pORNo
            DateOfReceipt = pDateOfReceipt
            ApplicationNo = pApplicationNo
            PolicyNo = pPolicyNo
            PayorName = pPayorName
            APR = pAPR
            APRDate = pAPRDate
            Currency = pCurrency
            TotalAmount = pTotalAmount
            VATableCollection = pVATableCollection
            NonVatCollection = pNonVatCollection
            VATExemptCollection = pVATExemptCollection
            VATAmount = pVATAmount
            VATTotalCollection = pVATTotalCollection
            VATWithholdingTax = pVATWithholdingTax
            VATAmountNetWTax = pVATAmountNetWTax
            BusinessType = pBusinessType
            BillNo = pBillNo
            SubsNo = pSubsNo
            PayorTin = pPayorTin
            PayorAddress = pPayorAddress
            RetainedAmount = pRetainedAmount
            PaymentStatus = pPaymentStatus
            Remarks = pRemarks
            ParticularsJSON = pParticularsJSON
            PaymentModeJSON = pPaymentModeJSON
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalStaging.DNewgenLifePayment
                objDAL.NewgenPayment(Me, pAction, pConn, pTrans)

                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function UpdateStatus(ByVal pOPRNo As String, ByVal pChequeNo As String, ByVal pAmount As Decimal, ByVal pPaymentStatus As String, ByVal pChequeClearanceStatus As String, ByVal pDateOfReceipt As Date, ByRef pConn As Object, ByRef pTrans As Object) As Long
            'NGUPDATE
            Try
                Dim objDAL As New dalStaging.DNewgenLifePayment
                objDAL.NewgenUpdatePayment(pOPRNo, pChequeNo, pAmount, pPaymentStatus, pChequeClearanceStatus, pDateOfReceipt, pConn, pTrans)

                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

    End Class

End Namespace


