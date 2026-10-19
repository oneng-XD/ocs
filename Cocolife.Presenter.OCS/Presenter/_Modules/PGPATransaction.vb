#Region "Description"
' PAGE NAME     :  
' CREATED BY    : 
' CREATED DATE  : 
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports cValidation = Cocolife.Utility.OCS.Common.uValidation
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports bllReference = Cocolife.BLL.OCS.Reference
#End Region

Namespace Payment

    Public Class PGPATransaction

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwGPATransaction As Payment.IGPATransaction
#End Region

#Region "Properties"

#End Region

#Region "Constructor"
        Sub New()

        End Sub

        Sub New(ByVal pView As Payment.IPaymentPremiumRelated)

            vwSysMsg = pView
            vwGPATransaction = pView

            With vwGPATransaction
                ' -------------------------------------------------------------------------------
                AddHandler .SetGPAForm, AddressOf SetGPAForm
                AddHandler .ClearScreenGPA, AddressOf ClearScreenGPA
            End With

        End Sub
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Private Sub SetGPAForm(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwGPATransaction
                    .GPAtransactionTag = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenAPRDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenGPA(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwGPATransaction
                    .PAcardID = cDataType.fLong.Empty
                    .InsuredID = cDataType.fLong.Empty
                    .InsuredName = New Utility.OCS.Common.BPerson
                    .PayorID = cDataType.fLong.Empty
                    .PayorName = New Utility.OCS.Common.BPerson
                    .PromoOffID = cDataType.fLong.Empty
                    .PromoOff = New Utility.OCS.Common.BPerson
                    .SalesOffID = cDataType.fLong.Empty
                    .SalesOff = New Utility.OCS.Common.BPerson
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenCheckDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub SetMessage(ByVal pMessage As String, ByVal pMessageType As String, ByVal pIsMessage As Boolean)

            Try
                With vwSysMsg
                    .Message = pMessage
                    .MessageType = pMessageType
                    .isMessage = pIsMessage
                End With
            Catch ex As Exception
                Throw
            End Try

        End Sub
#End Region

    End Class

End Namespace

