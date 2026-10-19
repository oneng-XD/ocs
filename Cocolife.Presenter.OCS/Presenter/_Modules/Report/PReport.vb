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
Imports eReport = Cocolife.Utility.OCS.Enums.eReport
Imports ePage = Cocolife.Utility.OCS.Enums.ePage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports preSecurity = Cocolife.Presenter.Common.Security
'Imports bllPerson = Cocolife.BLL.OCS.Report
#End Region

Namespace Report

    Public Class PReport

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwReport As Report.IReport
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Report.IReport)

            vwSysMsg = pView
            vwReport = pView

            With vwReport
                AddHandler .ClearScreenReport, AddressOf ClearScreenReport
                ' ------------------------------------------------------------------------------- 
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Transactions"
        Public Sub ClearScreenReport()
            Try

                With vwReport
                    .RptParamString = cDataType.fString.Empty
                End With

            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenReport.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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

