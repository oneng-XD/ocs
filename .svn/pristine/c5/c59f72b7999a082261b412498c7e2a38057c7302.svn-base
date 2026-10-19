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
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
#End Region

Namespace Reference

    Public Class PSiteDetails

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Dim vwSiteDetails As Reference.ISiteDetails
#End Region

#Region "Properties"

#End Region

#Region "Constructor"
        Sub New()

        End Sub

        Sub New(ByVal pView As Reference.ISiteDetails)

            vwSysMsg = pView
            vwSiteDetails = pView

            With vwSiteDetails
                AddHandler .LoadSiteDetails, AddressOf LoadSiteDetails
            End With

        End Sub
#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"

        Private Sub LoadSiteDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBll As New bllReference.BSiteDetails
                objBll.GetSiteDetails(vwSiteDetails.SiteCode)

                With vwSiteDetails
                    '.SiteCode = objBll.Prspid
                    .SiteName = objBll.Prsnme
                    .SiteAddr = objBll.Address
                    .SiteTel = objBll.Phone
                    .SiteEmail = objBll.Email
                    .SiteTin = objBll.Tin
                    .SitePrefix = objBll.Prefix
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSiteDetails.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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

