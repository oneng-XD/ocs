#Region "Description"
' PAGE NAME     : Search Policy Presenter
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
Imports bllSearch = Cocolife.BLL.OCS.Search
#End Region

Namespace Search

    Public Class PPolicy

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPolicy As Search.IPolicy
#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Search.IPolicy)

            vwSysMsg = pView
            vwPolicy = pView

            With vwPolicy
                AddHandler .ClearScreenLoadPolicy, AddressOf ClearScreenLoadPolicy
                AddHandler .ClearScreenSearchPolicy, AddressOf ClearScreenSearchPolicy
                ' ------------------------------------------------------------------------------- 
                AddHandler .LoadPolicy, AddressOf LoadPolicy
                AddHandler .LoadSearchPolicy, AddressOf LoadSearchPolicy
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

        Private Function IsValid() As Boolean

            Try
                With vwPolicy
                    If .SearchPolicyNo = cDataType.fString.Empty And .SearchPolicyPayor = cDataType.fString.Empty And .SearchPolicyInsured = cDataType.fString.Empty Then
                        Call SetMessage("Please enter at least 1 search criteria.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With
                Return True
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValid : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValid.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

        Private Function IsValidPolicy() As Boolean

            Try
                With vwPolicy
                    If .LoadPolicyNo = cDataType.fString.Empty Then
                        Call SetMessage("Please enter Policy No.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With
                Return True
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPolicy : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPolicy.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function


#End Region

#Region "Transactions"

        Private Sub ClearScreenLoadPolicy(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPolicy
                    .LoadPolicyNo = cDataType.fString.Empty
                    .LoadPayorName = cDataType.fString.Empty
                    .LoadInsuredName = cDataType.fString.Empty
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenLoadPolicy.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        Private Sub ClearScreenSearchPolicy(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPolicy
                    .SearchPolicyNo = cDataType.fString.Empty
                    .SearchPolicyPayor = cDataType.fString.Empty
                    .SearchPolicyInsured = cDataType.fString.Empty
                    .dtSearchPolicy = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenSearchPolicy.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        ' ------------------------------------------------------------------------------- 

        Private Sub LoadPolicy(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllSearch.BSearch
            Dim dtLocal As DataTable

            Try
                If IsValidPolicy() Then
                    With vwPolicy
                        .IsPolicyExist = False
                        dtLocal = objBLL.SearchPolicy(.LoadPolicyNo, .LoadInsuredName, .LoadPayorName, .LoadPolicyType)
                        If dtLocal.Rows.Count <> 0 Then
                            For Each dr As DataRow In dtLocal.Rows
                                Select Case .LoadPolicyType
                                    Case "G"
                                        .LoadPolicyNo = cDataType.fString.IfNull(dr.Item("polnum"))
                                        .LoadPayorName = cDataType.fString.IfNull(dr.Item("payor_name"))
                                        .LoadMetCod = cDataType.fString.IfNull(dr.Item("metcod"))
                                        .IsPolicyExist = True
                                    Case Else
                                        .LoadPolicyNo = cDataType.fString.IfNull(dr.Item("polnum"))
                                        .LoadPayorName = cDataType.fString.IfNull(dr.Item("payor_name"))
                                        .LoadInsuredName = cDataType.fString.IfNull(dr.Item("insured_name"))
                                        .IsPolicyExist = True
                                End Select
                            Next
                        ElseIf .LoadPolicyNo.IndexOf("-") > -1 AndAlso .LoadPolicyType <> "R" AndAlso .LoadPolicyType <> "V" Then
                            .IsPolicyExist = True
                        Else
                            .LoadPolicyNo = cDataType.fString.Empty
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                        End If
                    End With
                End If
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPolicy.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub


        Private Sub LoadSearchPolicy(ByVal sender As Object, ByVal e As EventArgs)

            Dim objBLL As New bllSearch.BSearch
            Dim dtLocal As DataTable

            Try
                If IsValid() Then
                    With vwPolicy
                        dtLocal = objBLL.SearchPolicy(.SearchPolicyNo, .SearchPolicyInsured, .SearchPolicyPayor, .SearchPolicyType)
                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
                            'ElseIf dtLocal.Rows.Count > 100 Then
                            '    Call SetMessage("Please use longer search criteria.", eSystemMessage.Information, True)
                            '    dtLocal.Rows.Clear()
                        End If
                        .dtSearchPolicy = dtLocal
                    End With
                End If
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSearchPolicy.<br /><br />", ex.Message), eSystemMessage.Critical, True)
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


