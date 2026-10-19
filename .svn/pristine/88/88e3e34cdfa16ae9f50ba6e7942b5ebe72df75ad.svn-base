#Region "Description"
' PAGE NAME     : OCS.Master Presenter
' CREATED BY    : EJ
' CREATED DATE  : 11/10/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports bllPerson = Cocolife.BLL.OCS.Person
Imports bllWorking = Cocolife.BLL.OCS.Working
'Imports bllPolicy = Cocolife.BLL.OCS
#End Region

Namespace Master

    Public Class PMaster

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwMaster As Master.IMaster
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Master.IMaster)

            vwSysMsg = pView
            vwMaster = pView

            With vwMaster
                AddHandler .ClearScreenMain, AddressOf ClearScreenMain
                AddHandler .LoadCheckTagging, AddressOf LoadCheckTagging
                AddHandler .GetUserSecRef, AddressOf GetUserSecRef
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
                With vwMaster
                    .UserPrsPID = cDataType.fLong.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenMain.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadCheckTagging(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim objBLL As New bllWorking.BSiteOPRChkPy
                Dim dtLocal As New DataTable
                With vwMaster
                    .dtCheckTagging = objBLL.GetCheckTagging(.SiteID)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadForDeposit.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try
        End Sub

        Private Sub GetUserSecRef(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllPerson.BSecRef

            Try
                With objBLL
                    .GetSecRef(vwMaster.UserCode)
                    If .IsRecordExist Then vwMaster.UserPrsPID = cDataType.fLong.IfNull(.SecPID)
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error GetUserSecRef.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        ' ------------------------------------------------------------------------------- 
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
