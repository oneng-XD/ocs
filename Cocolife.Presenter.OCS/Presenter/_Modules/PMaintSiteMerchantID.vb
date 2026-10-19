#Region "Description"
' PAGE NAME     : Maintenance Official Receipt Series
' CREATED BY    : EJ 
' CREATED DATE  : 10/17/2017
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
Imports preMessages = Cocolife.Utility.OCS.Messages
Imports bllReference = Cocolife.BLL.OCS.Reference
Imports bllPerson = Cocolife.BLL.OCS.Person
Imports bllMaintenance = Cocolife.BLL.OCS.Maintenance
Imports bllSearch = Cocolife.BLL.OCS.Search
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllPayment = Cocolife.BLL.OCS.Payment
Imports preSearch = Cocolife.Presenter.OCS.Search
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
#End Region

Namespace Maintenance

    Public Class PMaintSiteMerchantID

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwConfirmation As preMessages.IConfirmationMessage
        Private vwMaintSiteMerchantID As Maintenance.IMaintSiteMerchantID
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Maintenance.IMaintSiteMerchantID)

            vwSysMsg = pView
            vwConfirmation = pView
            vwMaintSiteMerchantID = pView

            With vwMaintSiteMerchantID
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenDetails, AddressOf ClearScreenDetails
                AddHandler .ClearScreenMerchantList, AddressOf ClearScreenList
                ' ---------------------------------------------------------------------
                AddHandler .LoadStatus, AddressOf LoadStatus
                AddHandler .LoadMerchantList, AddressOf LoadMerchantList
                AddHandler .LoadSiteList, AddressOf LoadSiteList
                AddHandler .LoadTerminalUse, AddressOf LoadTerminalUse
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                ' ---------------------------------------------------------------------
                AddHandler .SaveMerchantId, AddressOf SaveMerchantId
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"
        Private Function IsValidDetails() As Boolean
            Try
                With vwMaintSiteMerchantID

                    If .SiteCode = 0 Then
                        Call SetMessage("Please select a Site.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .MerchantTerminalType = String.Empty Then
                        Call SetMessage("Please select Terminal Type.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .MerchantID = String.Empty Then
                        Call SetMessage("Please complete series details.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .MerchantName = String.Empty Then
                        Call SetMessage("Lower limit exceeds the upper limit.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .MerchantEffectiveDate.Date = cDataType.fDate.Empty Then
                        Call SetMessage("Please enter effective date.", eSystemMessage.Warning, True)
                        Return False
                    ElseIf .MerchantEffectiveDate.Date = cDataType.fDate.Invalid Then
                        Call SetMessage("Invalid effective date.", eSystemMessage.Warning, True)
                        Return False
                        'ElseIf .MerchantEffectiveDate.Date > cDataType.fDate.Current Then
                        '    Call SetMessage("Swipe date exceeds OPR Date.", eSystemMessage.Warning, True)
                        '    Return False
                    End If

                    If .MerchantTermDate.Date = cDataType.fDate.Invalid Then
                        Call SetMessage("Invalid termination date.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .MerchantStatus = 0 Then
                        Call SetMessage("Please select status.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidDetails : ", ex.Message))
            End Try
        End Function
#End Region

#Region "Transactions"

        Private Sub ClearScreenDetails(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwMaintSiteMerchantID
                    .MerchantID = cDataType.fLong.Empty
                    .MerchantTerminalType = cDataType.fString.Empty
                    .MerchantName = cDataType.fString.Empty
                    .MerchantEffectiveDate = cDataType.fDate.Empty
                    .MerchantTermDate = cDataType.fDate.Empty
                    .MerchantStatus = cDataType.fInteger.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwMaintSiteMerchantID
                    .MerchantSiteCode = cDataType.fLong.Empty
                    .dtMerchantList = New DataTable
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Call ClearScreenDetails(sender, e)
                Call ClearScreenList(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        ' -------------------------------------------------------------------------------

        Private Sub LoadMerchantList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BMerchantSite
                Dim dtLocal As New DataTable
                With vwMaintSiteMerchantID
                    .IsSuccessful = False

                    dtLocal = objBLL.GetRefMerchantSiteList(.SiteCode)

                    Dim dtFiltered = From c In dtLocal.AsEnumerable
                                     Where c.Item("ctype") = "CCA"
                                     Select c

                    If dtFiltered.Any Then
                        dtLocal = dtFiltered.CopyToDataTable
                    Else
                        dtLocal = New DataTable
                    End If

                    .dtMerchantList = dtLocal

                    .IsSuccessful = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSeriesList.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadStatus(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim dtLocal As New DataTable
                ' Define columns
                dtLocal.Columns.Add("ID", GetType(System.Int32))
                dtLocal.Columns.Add("DESCRIPTION", GetType(System.String))
                ' Add a row of data
                dtLocal.Rows.Add(eReference.Status.Active, eReference.Status.Active.ToString.ToUpper)

                vwMaintSiteMerchantID.dtStatus = dtLocal
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadStatus.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadSiteList(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BSiteDetails
                vwMaintSiteMerchantID.dtSiteList = objBLL.LoadSourceSite()
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSiteSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub LoadTerminalUse(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BParamRef
                vwMaintSiteMerchantID.dtTerminalUse = objBLL.GetRefOcsTerminalUseCCA
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadTerminalUse.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmSave(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmation
                    .ConfirmCaller = "SAVE"
                    .Message = "Are you sure you want to save this Merchant ID?"
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmSave.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub SaveMerchantId(ByVal sender As Object, ByVal e As EventArgs)

            Try

                vwMaintSiteMerchantID.IsSuccessful = False

                If IsValidDetails() Then
                    With vwMaintSiteMerchantID

                        Dim objMaintSiteMerchantID = New bllReference.BMerchantSite

                        With objMaintSiteMerchantID
                            .SiteCode = vwMaintSiteMerchantID.MerchantSiteCode
                            .UserId = vwMaintSiteMerchantID.UserID

                            .MerchantEditId = vwMaintSiteMerchantID.MerchantEditID
                            .TerminalId = vwMaintSiteMerchantID.MerchantTerminalType
                            .MerchantId = vwMaintSiteMerchantID.MerchantID
                            .DbaName = vwMaintSiteMerchantID.MerchantName
                            .EffDate = vwMaintSiteMerchantID.MerchantEffectiveDate
                            .TermDate = vwMaintSiteMerchantID.MerchantTermDate
                            .StatusId = vwMaintSiteMerchantID.MerchantStatus
                            
                            .SaveMerchantId()

                            vwMaintSiteMerchantID.IsSuccessful = .IsSuccessful

                            If .IsSuccessful = True Then
                                Call SetMessage(String.Concat("Receipt Series Posting<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                            End If
                        End With
                    End With
                End If

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error SaveSeries.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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

