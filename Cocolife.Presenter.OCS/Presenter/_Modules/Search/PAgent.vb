#Region "Description"
' PAGE NAME     : Search Agent Presenter
' CREATED BY    : MPRO
' CREATED DATE  : 04/30/2013
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports eSystemMessage = Cocolife.Utility.Common.Enums.eSystemMessage
Imports cDataType = Cocolife.Utility.Common.DataType
Imports preSecurity = Cocolife.Presenter.Common.Security
Imports bllPerson = Cocolife.BLL.OCS.Person
#End Region

Namespace Search

    Public Class PAgent

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwAgent As Search.IAgent
#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Search.IAgent)

            vwSysMsg = pView
            vwAgent = pView

            With vwAgent
                AddHandler .ClearScreenLoadAgent, AddressOf ClearScreenLoadAgent
                AddHandler .ClearScreenSearchAgent, AddressOf ClearScreenSearchAgent
                ' ------------------------------------------------------------------------------- 
                AddHandler .LoadAgent, AddressOf LoadAgent
                AddHandler .LoadSearchAgent, AddressOf LoadSearchAgent
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

        Private Function IsValid() As Boolean

            Try
                With vwAgent
                    If .SearchAgentID = cDataType.fLong.Empty And .SearchAgentName = cDataType.fString.Empty Then
                        Call SetMessage("Please enter at least 1 search criteria.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SearchAgentName.Length > 0 And .SearchAgentName.Length < 3 Then
                        Call SetMessage("Please enter at least three(3) characters for the Search Name.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With
                Return True
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValid : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValid.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidAgent() As Boolean

            Try
                With vwAgent
                    If .LoadAgentID = cDataType.fLong.Empty Then
                        Call SetMessage("Please enter agent id.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With
                Return True
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidAgent : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidAgent.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        'Private Function IsValidAgent2() As Boolean

        '    Try
        '        With vwAgent
        '            If .LoadAgentID2 = cDataType.fLong.Empty Then
        '                Call SetMessage("Please enter agent id.", eSystemMessage.Warning, True)
        '                Return False
        '            End If
        '        End With
        '        Return True
        '    Catch ex As Exception
        '        Throw New Exception(tMessage(String, "Error IsValidAgent2 : ", ex.Message))
        '        'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidAgent2.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Function

#End Region

#Region "Transactions"

        Private Sub ClearScreenLoadAgent(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwAgent
                    .LoadAgentName = cDataType.fString.Empty
                    .LoadAgencyName = cDataType.fString.Empty
                    .LoadAgentFName = cDataType.fString.Empty
                    .LoadAgentLName = cDataType.fString.Empty
                    .LoadAgentMName = cDataType.fString.Empty
                    .LoadAgencyID = cDataType.fLong.Empty
                    .LoadAgencyName = cDataType.fString.Empty
                    .LoadAgencyFName = cDataType.fString.Empty
                    .LoadAgencyLName = cDataType.fString.Empty
                    .LoadAgencyMName = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenLoadAgent.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenSearchAgent(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwAgent
                    .SearchAgentID = cDataType.fLong.Empty
                    .SearchAgentName = cDataType.fString.Empty
                    .dtSearchAgent = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenSearchAgent.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        ' ------------------------------------------------------------------------------- 

        Public Sub LoadAgent(ByVal sender As Object, ByVal e As EventArgs) 'nfr 

            Dim objBLL As New bllPerson.BAgnMas
            Dim dtLocal As DataTable
            Dim strPolType As String = String.Empty

            Try
                If IsValidAgent() Then
                    Dim vwPolicyContext As Search.IAgentPolicyContext

                    vwPolicyContext = TryCast(vwAgent, Search.IAgentPolicyContext)

                    If vwPolicyContext IsNot Nothing Then
                        strPolType = vwPolicyContext.SearchAgentPolType
                    End If
                    With vwAgent
                        .IsAgentExist = False
                        dtLocal = objBLL.SearchAgnMas(.LoadAgentID, "", .LoadDocDate, strPolType)
                        If dtLocal.Rows.Count <> 0 Then
                            For Each dr As DataRow In dtLocal.Rows
                                .LoadAgentID = cDataType.fLong.IfNull(dr.Item("agnprs"))
                                .LoadAgentName = cDataType.fString.IfNull(dr.Item("agnnme"))
                                .LoadAgentFName = cDataType.fString.IfNull(dr.Item("agnfnam"))
                                .LoadAgentLName = cDataType.fString.IfNull(dr.Item("agnlnam"))
                                .LoadAgentMName = cDataType.fString.IfNull(dr.Item("agnmnam"))
                                .LoadAgencyID = cDataType.fLong.IfNull(dr.Item("agnbrn"))
                                .LoadAgencyName = cDataType.fString.IfNull(dr.Item("brnnme"))
                                .LoadAgencyFName = cDataType.fString.IfNull(dr.Item("brnfnam"))
                                .LoadAgencyLName = cDataType.fString.IfNull(dr.Item("brnlnam"))
                                .LoadAgencyMName = cDataType.fString.IfNull(dr.Item("brnmnam"))
                                .IsAgentExist = True
                            Next
                        Else
                            .LoadAgentID = cDataType.fLong.Empty
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    End With
                End If
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadAgent.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub LoadSearchAgent(ByVal sender As Object, ByVal e As EventArgs) 'junie here agt

            Dim objBLL As New bllPerson.BAgnMas
            Dim dtLocal As DataTable
            Dim strPolType As String = String.Empty

            Try
                If IsValid() Then
                    Dim vwPolicyContext As Search.IAgentPolicyContext

                    vwPolicyContext = TryCast(vwAgent, Search.IAgentPolicyContext)

                    If vwPolicyContext IsNot Nothing Then
                        strPolType = vwPolicyContext.SearchAgentPolType
                    End If

                    With vwAgent
                        dtLocal = objBLL.SearchAgnMas(.SearchAgentID, .SearchAgentName, .LoadDocDate, strPolType)
                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                            'ElseIf dtLocal.Rows.Count > 100 Then
                            '    Call SetMessage("Please use longer search criteria.", eSystemMessage.Information, True)
                            '    dtLocal.Rows.Clear()
                        End If
                        .dtSearchAgent = dtLocal
                    End With
                End If
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSearchAgent.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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


