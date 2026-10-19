#Region "Description"
' PAGE NAME     : Payment Premium Related Presenter
' CREATED BY    : MPRO 
' CREATED DATE  : 11/13/2024
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
Imports preReport = Cocolife.Presenter.OCS.Report
Imports bllReference = Cocolife.BLL.OCS.Reference
Imports bllPerson = Cocolife.BLL.OCS.Person
Imports bllSearch = Cocolife.BLL.OCS.Search
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports bllPayment = Cocolife.BLL.OCS.Payment
Imports bllStaging = Cocolife.BLL.OCS.Staging
Imports preSearch = Cocolife.Presenter.OCS.Search
Imports eReference = Cocolife.Utility.OCS.Enums.eReference
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports Cocolife.Utility.OCS.Classes
Imports System.Configuration
#End Region

Namespace Payment

    Public Class PPaymentSalesInvoice

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPaymentSalesInvoice As Payment.IPaymentSalesInvoice
        Private vwConfirmMsg As preMessages.IConfirmationMessage
        Private vwReport As preReport.IReport

        Private objPaymentSalesInvoice As bllPayment.BPaymentSalesInvoice
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Payment.IPaymentSalesInvoice)

            vwSysMsg = pView
            vwPaymentSalesInvoice = pView
            vwConfirmMsg = pView

            With vwPaymentSalesInvoice
                ' -------------------------------------------------------------------------------
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .ClearScreenInfo, AddressOf ClearScreenInfo
                AddHandler .ClearScreenViewDoc, AddressOf ClearScreenViewDoc
                ' -------------------------------------------------------------------------------
                AddHandler .LoadSourceSite, AddressOf LoadSourceSite
                AddHandler .LoadCurrency, AddressOf LoadCurrency
                AddHandler .CheckSourceSite, AddressOf CheckSourceSite
                ' -------------------------------------------------------------------------------
                AddHandler .LoadViewDoc, AddressOf LoadViewDoc
                AddHandler .LoadSalesInvoice, AddressOf LoadSalesInvoice
                AddHandler .LoadNewSalesInvoice, AddressOf LoadNewSalesInvoice
                AddHandler .ProcessSalesInvoice, AddressOf ProcessSalesInvoice
                AddHandler .ConfirmCancel, AddressOf ConfirmCancel
                AddHandler .ConfirmSave, AddressOf ConfirmSave
                ' -------------------------------------------------------------------------------
                'AddHandler .GenerateReport, AddressOf LoadSourceSite
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Private Sub ClearScreenMain(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Call ClearScreenInfo(sender, e)
                Call ClearScreenViewDoc(sender, e)
                With vwPaymentSalesInvoice
                    .InvoiceNumber = cDataType.fLong.Empty
                    .InvoiceDate = cDataType.fDate.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenViewDoc(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Call ClearScreenInfo(sender, e)
                With vwPaymentSalesInvoice
                    .ViewDocFrom = cDataType.fDate.Empty
                    .ViewDocTo = cDataType.fDate.Empty
                    .ViewDocNumber = cDataType.fLong.Empty
                    .ViewReferenceNumber = cDataType.fString.Empty
                    .dtViewDoc = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ClearScreenInfo(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentSalesInvoice
                    .SalesInvoiceID = cDataType.fLong.Empty
                    .UploadTag = cDataType.fString.Empty
                    .ReferenceNo = cDataType.fString.Empty
                    .PayorName = cDataType.fString.Empty
                    .PayorAddress = cDataType.fString.Empty
                    .PayorTIN = cDataType.fString.Empty
                    .InsuredClientName = cDataType.fString.Empty
                    .PolicyNumber = cDataType.fString.Empty
                    .CoveragePeriodFrom = cDataType.fDate.Empty
                    .CoveragePeriodTo = cDataType.fDate.Empty
                    .InvoiceCurrency = cDataType.fString.Empty
                    .InvoiceAmount = cDataType.fDecimal.Empty
                    .VATable = cDataType.fDecimal.Empty
                    .VATExempt = cDataType.fDecimal.Empty
                    .VATAmount = cDataType.fDecimal.Empty
                    .NonVAT = cDataType.fDecimal.Empty
                    .TotalSales = cDataType.fDecimal.Empty
                    .WitholdingTax = cDataType.fDecimal.Empty
                    .NetOfWitholdingTax = cDataType.fDecimal.Empty
                    .Discount = cDataType.fDecimal.Empty
                    .DiscountIdNo = cDataType.fString.Empty
                    .PaymentTerm = cDataType.fString.Empty
                    .NextDueDate = cDataType.fDate.Empty
                    .AgentName = cDataType.fString.Empty
                    .AgentCode = cDataType.fString.Empty
                    .InvoiceRemarks = cDataType.fString.Empty
                    .InvoiceOtherInfo = cDataType.fString.Empty
                    .AckReceiptNumber = cDataType.fLong.Empty
                    .UploadDate = cDataType.fDate.Empty
                    .ARDate = cDataType.fDate.Empty
                    .SIPrintStatus = cDataType.fString.Empty
                    .ARPrintStatus = cDataType.fString.Empty
                    .lstSIDetails = New List(Of cSIDetails)
                End With
                'Call ClearScreenPolicy(sender, e)

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenInfo.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub CheckSourceSite(ByVal sender As Object, ByVal e As EventArgs)

            Try

                With vwPaymentSalesInvoice
                    .IsSuccessful = False

                    If .SourceSite = String.Empty Then
                        Call SetMessage("Please select a Source Site.", eSystemMessage.Warning, True)
                        Return
                    End If

                    .IsSuccessful = True
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error CheckSourceSite.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadSourceSite(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BSiteDetails
                vwPaymentSalesInvoice.dtSourceSite = objBLL.LoadSourceSite()
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSourceSite.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadCurrency(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BCurRef
                vwPaymentSalesInvoice.dtCurrency = objBLL.GetRefCurRefList
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadCurrency.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadNewSalesInvoice(ByVal sender As Object, ByVal e As EventArgs)

            Try
                Dim objBLL As New bllReference.BSalesInvoice
                With vwPaymentSalesInvoice
                    .IsSuccessful = False

                    objBLL.LoadNewSalesInvoice(vwPaymentSalesInvoice.SiteCode, vwPaymentSalesInvoice.UserID)

                    .IsSuccessful = True
                    .ReservedDocNo = objBLL.InvoiceNumber
                    .InvoiceNumber = 0
                    .InvoiceDate = Now.ToShortDateString
                End With

            Catch ex As ArgumentException
                Call SetMessage(String.Concat("New Invoice is not Allowed!.<br /><br />", ex.Message), eSystemMessage.Information, True)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadNewSalesInvoice.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadViewDoc(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllReference.BSalesInvoice
                Dim dtLocal As New DataTable

                With vwPaymentSalesInvoice
                    If IsValidLoadViewDoc() Then
                        If .ViewDocNumber > 0 Then
                            dtLocal = objBLL.LoadViewDoc(.SiteCode, .ViewDocNumber)
                        ElseIf .ViewReferenceNumber <> String.Empty Then
                            dtLocal = objBLL.LoadViewDoc(.SiteCode, .ViewReferenceNumber)
                        Else
                            dtLocal = objBLL.LoadViewDoc(.SiteCode,0, .ViewDocFrom, .ViewDocTo)
                        End If

                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(String.Concat("View Sales Invoices.<br /><br />", "No Invoice found!"), eSystemMessage.Information, True)

                        End If

                        .dtViewDoc = dtLocal
                    End If
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadViewDoc.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ProcessSalesInvoice(ByVal sender As Object, ByVal e As EventArgs)
            'Objects
            Dim objSalesInvoice As New bllReference.BSalesInvoice
            Dim mDocSaveState As String = String.Empty

            Try


                With vwPaymentSalesInvoice
                    .IsSuccessful = False
                    mDocSaveState = .DocSaveState

                    If mDocSaveState = eReference.DocSaveState.Cancel Then
                        If .CancellationReason = "" Then
                            Call SetMessage(String.Concat("Sales Invoice.<br /><br />", "You must input a Cancellation Reason!<br /><br />"), eSystemMessage.Information, True)
                            Exit Sub
                        Else
                            .InvoiceRemarks = String.Concat(.CancellationReason, ";", Chr(13), .InvoiceRemarks)
                            .CancellationReason = String.Empty
                        End If
                    End If

                    objSalesInvoice = New bllReference.BSalesInvoice(.ReferenceNo, .InvoiceNumber, .InvoiceDate, .SiteCode, .UserID, .InvoiceRemarks, .InvoiceOtherInfo)
                    objSalesInvoice.PayorName = .PayorName
                    objSalesInvoice.PayorAddress = .PayorAddress
                    objSalesInvoice.PayorTIN = .PayorTIN
                    objSalesInvoice.InsuredClientName = .InsuredClientName
                    objSalesInvoice.PolicyNumber = .PolicyNumber
                    objSalesInvoice.CoveragePeriodFrom = .CoveragePeriodFrom
                    objSalesInvoice.CoveragePeriodTo = .CoveragePeriodTo
                    objSalesInvoice.InvoiceCurrency = .InvoiceCurrency
                    objSalesInvoice.InvoiceAmount = .InvoiceAmount
                    objSalesInvoice.VATable = .VATable
                    objSalesInvoice.VATExempt = .VATExempt
                    objSalesInvoice.VATAmount = .VATAmount
                    objSalesInvoice.NonVAT = .NonVAT
                    objSalesInvoice.TotalSales = .TotalSales
                    objSalesInvoice.WitholdingTax = .WitholdingTax
                    objSalesInvoice.NetOfWitholdingTax = .NetOfWitholdingTax
                    objSalesInvoice.Discount = .Discount
                    objSalesInvoice.DiscountIdNo = .DiscountIdNo
                    objSalesInvoice.PaymentTerm = .PaymentTerm
                    objSalesInvoice.AgentName = .AgentName
                    objSalesInvoice.AgentCode = .AgentCode
                    objSalesInvoice.SIPrintStatus = "READY"
                    objSalesInvoice.IsFromNewgenAPI = .IsFromNewgenAPI
                    objSalesInvoice.ParticularsRaw = .ParticularsRaw
                    objPaymentSalesInvoice = New bllPayment.BPaymentSalesInvoice

                    With objPaymentSalesInvoice
                        .SiteCode = vwPaymentSalesInvoice.SiteCode
                        .UserID = vwPaymentSalesInvoice.UserID
                        .SalesInvoice = objSalesInvoice

                        Select Case mDocSaveState
                            Case eReference.DocSaveState.AddNew
                                .IsSuccessful = True
                                .ProcessPaymentSalesInvoice()

                            Case eReference.DocSaveState.Cancel
                                .IsSuccessful = True
                                .CancelPaymentSalesInvoice()
                        End Select
                    End With
                    .IsSuccessful = objPaymentSalesInvoice.IsSuccessful
                End With
                If vwPaymentSalesInvoice.IsSuccessful And Not mDocSaveState = eReference.DocSaveState.Print Then
                    Call SetMessage(String.Concat("Sales Invoice.<br /><br />", "Transaction Successful!<br /><br />"), eSystemMessage.Information, True)
                End If

            Catch ex As Exception
                Call SetMessage(String.Concat("An Error has occurred.<br /><br />", ex.Message), eSystemMessage.Information, True)
            End Try

        End Sub

        Private Sub ConfirmCancel(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "CANCEL"
                    .Message = String.Concat("Are you sure you want to cancel OPR#", vwPaymentSalesInvoice.InvoiceNumber, "?")
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmCancel.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub ConfirmSave(ByVal sender As Object, ByVal e As EventArgs)
            Try
                With vwConfirmMsg
                    .ConfirmCaller = "SAVE"
                    .Message = "Are you sure you want to save this Sales Invoice?"
                    .isMessage = True
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ConfirmSave.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Function GetIdFromList(ByVal pList As Object, ByVal pCounter As Integer) As Long
            If pList.Count > pCounter Then
                Return pList(pCounter)
            Else
                Return 0
            End If
        End Function

        Private Sub LoadSalesInvoice(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllReference.BSalesInvoice
            Dim lstLocal As New List(Of cSIDetails)

            Try
                If IsValidReferenceNo() Then
                    With vwPaymentSalesInvoice
                        .IsReferenceNoExisting = False
                        objBLL.SearchSalesInvoice(.ReferenceNo, .PolicyNumber)

                        .IsReferenceNoExisting = objBLL.IsRecordExist
                        If .IsReferenceNoExisting Then
                            .IsSourceSiteLocked = True
                            If .DocSaveState = eReference.DocSaveState.AddNew Then
                                If objBLL.InvoiceNumber > 0 AndAlso objBLL.SIPrintStatus <> "CANCELLED" Then
                                    .IsReferenceNoExisting = False
                                    Throw New ArgumentException("Invoice No : " & objBLL.InvoiceNumber)
                                End If
                            Else
                                .InvoiceNumber = objBLL.InvoiceNumber
                            End If

                            .SalesInvoiceID = objBLL.SalesInvoiceID
                            .UploadTag = objBLL.UploadTag
                            .ReferenceNo = objBLL.ReferenceNo
                            .PayorName = objBLL.PayorName
                            .PayorAddress = objBLL.PayorAddress
                            .PayorTIN = objBLL.PayorTIN
                            .InsuredClientName = objBLL.InsuredClientName
                            .PolicyNumber = objBLL.PolicyNumber
                            .CoveragePeriodFrom = objBLL.CoveragePeriodFrom
                            .CoveragePeriodTo = objBLL.CoveragePeriodTo
                            .InvoiceCurrency = objBLL.InvoiceCurrency
                            .InvoiceAmount = objBLL.InvoiceAmount
                            .VATable = objBLL.VATable
                            .VATExempt = objBLL.VATExempt
                            .VATAmount = objBLL.VATAmount
                            .NonVAT = objBLL.NonVAT
                            .TotalSales = objBLL.TotalSales
                            .WitholdingTax = objBLL.WitholdingTax
                            .NetOfWitholdingTax = objBLL.NetOfWitholdingTax
                            .Discount = objBLL.Discount
                            .DiscountIdNo = objBLL.DiscountIdNo
                            .PaymentTerm = objBLL.PaymentTerm
                            .NextDueDate = objBLL.NextDueDate
                            .AgentName = objBLL.AgentName
                            .AgentCode = objBLL.AgentCode
                            .InvoiceDate = objBLL.InvoiceDate
                            .InvoiceRemarks = objBLL.InvoiceRemarks
                            .InvoiceOtherInfo = objBLL.InvoiceOtherInfo
                            .AckReceiptNumber = objBLL.AckReceiptNumber
                            .UploadDate = objBLL.UploadDate
                            .SIPrintStatus = objBLL.SIPrintStatus
                            .IsFromNewgenAPI = objBLL.IsFromNewgenAPI
                            .ParticularsRaw = objBLL.ParticularsRaw

                            For Each dr As DataRow In objBLL.dtSIDetails.Rows

                                If dr.Table.Columns.Contains("PARTICULARS") AndAlso
                                   dr.IsNull("PARTICULARS") Then

                                    dr.Item("PARTICULARS") = String.Empty
                                End If

                                If dr.Table.Columns.Contains("QUANTITY") AndAlso
                                   dr.IsNull("QUANTITY") Then

                                    dr.Item("QUANTITY") = 0
                                End If

                                If dr.Table.Columns.Contains("UNIT_PRICE") AndAlso
                                   dr.IsNull("UNIT_PRICE") Then

                                    dr.Item("UNIT_PRICE") = 0
                                End If

                                If dr.Table.Columns.Contains("AMOUNT") AndAlso
                                   dr.IsNull("AMOUNT") Then

                                    dr.Item("AMOUNT") = 0
                                End If

                                lstLocal.Add(New cSIDetails(dr))

                            Next
                            .lstSIDetails = lstLocal
                        Else
                            .IsReferenceNoExisting = False
                            Call ClearScreenInfo(sender, e)
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    End With
                End If
            Catch ex As ArgumentException
                Call SetMessage(String.Concat("Reference No Already Used!.<br /><br />", ex.Message), eSystemMessage.Information, True)
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSalesInvoice.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub


        Private Function IsValidReferenceNo() As Boolean

            Try

                With vwPaymentSalesInvoice

                    If .ReferenceNo = String.Empty Then
                        Call SetMessage("Input Reference No.", eSystemMessage.Warning, True)
                        Return False
                    End If

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidReferenceNo : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidGpaCardID.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidLoadViewDoc() As Boolean

            Try

                With vwPaymentSalesInvoice
                    If .ViewDocFrom > .ViewDocTo Then
                        Call SetMessage("View Date From exceeds Date To.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    Select Case .ViewDocFrom
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please enter Date From.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid Date From.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("View Date From precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is > cDataType.fDate.Current
                            Call SetMessage("View Date From exceeds current date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                    Select Case .ViewDocTo
                        Case cDataType.fDate.Empty
                            Call SetMessage("Please enter Date To.", eSystemMessage.Warning, True)
                            Return False
                        Case cDataType.fDate.Invalid
                            Call SetMessage("Invalid Date To.", eSystemMessage.Warning, True)
                            Return False
                        Case Is < cDataType.fDate.Minimum
                            Call SetMessage("View Date To precedes minimum date.", eSystemMessage.Warning, True)
                            Return False
                        Case Is > cDataType.fDate.Current
                            Call SetMessage("View Date To exceeds current date.", eSystemMessage.Warning, True)
                            Return False
                    End Select

                End With

                Return True

            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidLoadViewDoc : ", ex.Message))
            End Try

        End Function

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


        Private Sub GetConfirmation(ByVal pMessage As String, ByVal pIsMessage As Boolean)

            Try
                With vwConfirmMsg
                    .ClickedState = False
                    .Message = pMessage
                    .isMessage = pIsMessage
                End With
            Catch ex As Exception
                Throw
            End Try

        End Sub
        ' -------------------------------------------------------------------------------
#End Region

    End Class

End Namespace

