#Region "Description"
' PAGE NAME     : PARAMREF BLL 
' CREATED BY    : MPRO
' CREATED DATE  : 03/26/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BParamRef

#Region "Implements"
        Implements Reference.IParamRef
#End Region

#Region "Variables"
        Private mPara As String = cDataType.fString.Empty
        Private mCode As String = cDataType.fString.Empty
        Private mNumCode As Decimal = cDataType.fDecimal.Empty
        Private mDescrp As String = cDataType.fString.Empty
        Private mSDate As Date = cDataType.fDate.Empty
        Private mEDate As Date = cDataType.fDate.Empty
        Private mCrtDt As Date = cDataType.fDate.Empty
        Private mUsrID As String = cDataType.fString.Empty
#End Region

#Region "Properties"

        Public Property Para() As String Implements Reference.IParamRef.Para
            Get
                Return mPara
            End Get
            Set(value As String)
                mPara = value
            End Set
        End Property

        Public Property Code() As String Implements Reference.IParamRef.Code
            Get
                Return mCode
            End Get
            Set(value As String)
                mCode = value
            End Set
        End Property

        Public Property NumCode() As Decimal Implements Reference.IParamRef.NumCode
            Get
                Return mNumCode
            End Get
            Set(value As Decimal)
                mNumCode = value
            End Set
        End Property

        Public Property Descrp() As String Implements Reference.IParamRef.Descrp
            Get
                Return mDescrp
            End Get
            Set(value As String)
                mDescrp = value
            End Set
        End Property

        Public Property SDate() As Date Implements Reference.IParamRef.Sdate
            Get
                Return mSDate
            End Get
            Set(value As Date)
                mSDate = value
            End Set
        End Property

        Public Property EDate() As Date Implements Reference.IParamRef.Edate
            Get
                Return mEDate
            End Get
            Set(value As Date)
                mEDate = value
            End Set
        End Property

        Public Property CrtDt() As Date Implements Reference.IParamRef.CrtDt
            Get
                Return mCrtDt
            End Get
            Set(value As Date)
                mCrtDt = value
            End Set
        End Property

        Public Property UsrID() As String Implements Reference.IParamRef.UsrID
            Get
                Return mUsrID
            End Get
            Set(value As String)
                mUsrID = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function GetRefOcsDtl() As DataTable Implements Reference.IParamRef.GetRefOcsDtl

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_DTL")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefGpaAsd() As DataTable Implements Reference.IParamRef.GetRefGpaAsd

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_ADCPR_ASD")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefADVDEF() As DataTable Implements Reference.IParamRef.GetRefADVDEF

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("ADVDEF")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefPAYTYP() As DataTable Implements Reference.IParamRef.GetRefPAYTYP

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_PAYTYP")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefECASH() As DataTable Implements Reference.IParamRef.GetRefECASH

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_ECASH")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefDcrType() As DataTable Implements Reference.IParamRef.GetRefDcrType

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_DOCTYPE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefRecordType() As DataTable Implements Reference.IParamRef.GetRefRecordType

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_RECORDTYPE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefPAYTYP_ROP() As DataTable Implements Reference.IParamRef.GetRefPAYTYP_ROP

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_PAYTYP_ROP")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function


        Public Function GetRefBatchNonPrem() As DataTable Implements Reference.IParamRef.GetRefBatchNonPrem

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_BATCH_NP")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefBatchDetails() As DataTable Implements Reference.IParamRef.GetRefBatchDetails

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_BATCH")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefGPATYPE() As DataTable Implements Reference.IParamRef.GetRefGPATYPE

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_GPATYPE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefPRSTIT() As DataTable Implements Reference.IParamRef.GetRefPRSTIT

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("PRSTIT")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefRATIND() As DataTable Implements Reference.IParamRef.GetRefRATIND

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("RATIND")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefRECURRINGTYPE() As DataTable Implements Reference.IParamRef.GetRefRECURRINGTYPE

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("RECURRING_TYPE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefSETTLE() As DataTable Implements Reference.IParamRef.GetRefSETTLE

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("SETTLE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefTERMINALUSE() As DataTable Implements Reference.IParamRef.GetRefTERMINALUSE

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("TERMINAL_USE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefTRNTYP() As DataTable Implements Reference.IParamRef.GetRefTRNTYP

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_TRNTYP_ORP")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefTRNTYP_TAGGING() As DataTable Implements Reference.IParamRef.GetRefTRNTYP_TAGGING

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_TRNTYP_TAGGING")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefTAGGING_STATUS() As DataTable Implements Reference.IParamRef.GetRefTAGGING_STATUS

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_TAGGING_STATUS")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefTRNTYP_ROP() As DataTable Implements Reference.IParamRef.GetRefTRNTYP_ROP

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_TRNTYP_ROP")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefPOLTYP() As DataTable Implements Reference.IParamRef.GetRefPOLTYP

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_POLTYP")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefOcsTerminalUseCCA() As DataTable Implements Reference.IParamRef.GetRefOcsTerminalUseCCA

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_TERMINAL_USE_CCA")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefOcsTerminalUseDCA() As DataTable Implements Reference.IParamRef.GetRefOcsTerminalUseDCA

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_TERMINAL_USE_DCA")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefOcsBankNetwork() As DataTable Implements Reference.IParamRef.GetRefOcsBankNetwork

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_BANK_NETWORK")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefARCANCEL() As DataTable Implements Reference.IParamRef.GetRefARCANCEL

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("AR_CANCEL")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefBillType() As DataTable Implements Reference.IParamRef.GetRefBillType

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("BILL_TYPE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetRefOcsAccountType() As DataTable Implements Reference.IParamRef.GetRefOcsAccountType

            Try

                Dim objDAL As New dalReference.DParamRef
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefParamRefList("OCS_ACCOUNT_TYPE")
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace


