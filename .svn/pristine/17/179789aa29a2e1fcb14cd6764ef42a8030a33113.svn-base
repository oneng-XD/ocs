#Region "Description"
' PAGE NAME     : Search Insured Presenter
' CREATED BY    : MPRO
' CREATED DATE  : 05/07/2013
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

    Public Class PInsured

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwInsured As Search.IInsured
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Search.IInsured)

            vwSysMsg = pView
            vwInsured = pView

            With vwInsured
                AddHandler .ClearScreenSearchInsured, AddressOf ClearScreenSearchInsured
                ' ------------------------------------------------------------------------------- 
                AddHandler .LoadInsured, AddressOf LoadInsured
                AddHandler .LoadSearchInsured, AddressOf LoadSearchInsured
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

        Private Function IsValid() As Boolean

            Try
                With vwInsured
                    If .SearchInsuredID = cDataType.fLong.Empty And .SearchInsuredName = cDataType.fString.Empty Then
                        Call SetMessage("Please enter at least 1 search criteria.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SearchInsuredName.Length > 0 And .SearchInsuredName.Length < 3 Then
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

        Private Function IsValidInsured() As Boolean

            Try
                With vwInsured
                    If .LoadInsuredID = cDataType.fLong.Empty Then
                        Call SetMessage("Please enter insured id.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With
                Return True
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidInsured : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

#End Region

#Region "Transactions"

        Private Sub ClearScreenSearchInsured(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwInsured
                    .SearchInsuredID = cDataType.fLong.Empty
                    .SearchInsuredName = cDataType.fString.Empty
                    .dtSearchInsured = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenSearchInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        ' ------------------------------------------------------------------------------- 

        'Private Sub LoadInsured(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim objBLL As New bllPerson.BPrsMas
        '    Dim dtLocal As DataTable

        '    Try
        '        If IsValidInsured() Then
        '            With vwInsured
        '                .IsInsuredExist = False
        '                dtLocal = objBLL.SearchPrsMas1(.LoadInsuredID, "")
        '                If dtLocal.Rows.Count <> 0 Then
        '                    For Each dr As DataRow In dtLocal.Rows
        '                        .LoadInsuredID = cDataType.fLong.IfNull(dr.Item("prspid"))
        '                        .IsInsuredExist = True
        '                    Next
        '                Else
        '                    .LoadInsuredID = cDataType.fLong.Empty
        '                    Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
        '                End If
        '            End With
        '        End If
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        'Private Sub LoadSearchInsured(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim objBLL As New bllPerson.BPrsMas
        '    Dim dtLocal As DataTable

        '    Try
        '        If IsValid() Then
        '            With vwInsured
        '                dtLocal = objBLL.SearchPrsMas1(.SearchInsuredID, .SearchInsuredName)
        '                .dtSearchInsured = dtLocal
        '                If dtLocal.Rows.Count = 0 Then Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
        '            End With
        '        End If
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSearchInsured.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        ' ------------------------------------------------------------------------------- 
        Private Sub LoadInsured(
     ByVal sender As Object,
     ByVal e As EventArgs
 )

            Const SEARCH_TYPE_GROUP_CLIENT As Integer = 3

            Dim objBLL As New bllPerson.BPrsMas
            Dim dtLocal As DataTable
            Dim strPolType As String = String.Empty
            Dim intSearchType As Integer = 0

            Try
                If IsValidInsured() Then



                    Dim vwPolicyContext As Search.IInsuredPolicyContext

                    vwPolicyContext =
                        TryCast(
                            vwInsured, 
                            Search.IInsuredPolicyContext
                        )

                    If vwPolicyContext IsNot Nothing Then
                        strPolType =
                            cDataType.fString.IfNull(
                                vwPolicyContext.SearchInsuredPolType
                            )
                    End If

                    With vwInsured

                        .IsInsuredExist = False

                        If String.Equals(
                            strPolType,
                            "G",
                            StringComparison.OrdinalIgnoreCase
                        ) Then

                            intSearchType = SEARCH_TYPE_GROUP_CLIENT

                        Else

                            intSearchType = 0

                        End If

                        dtLocal = objBLL.SearchPrsMas1(
                            .LoadInsuredID,
                            String.Empty,
                            .SearchInsuredType,
                            intSearchType
                        )

                        If dtLocal IsNot Nothing AndAlso
                           dtLocal.Rows.Count > 0 Then



                            Dim dr As DataRow = dtLocal.Rows(0)

                            .LoadInsuredID =
                                cDataType.fLong.IfNull(
                                    dr.Item("prspid")
                                )

                            If dtLocal.Columns.Contains("prssex") Then
                                .SearchInsuredType =
                                    cDataType.fString.IfNull(
                                        dr.Item("prssex")
                                    )
                            End If

                            If dtLocal.Columns.Contains("prsfnm") Then
                                .LoadInsuredFirstName =
                                    cDataType.fString.IfNull(
                                        dr.Item("prsfnm")
                                    )
                            End If

                            If dtLocal.Columns.Contains("prslnm") Then
                                .LoadInsuredLastName =
                                    cDataType.fString.IfNull(
                                        dr.Item("prslnm")
                                    )
                            End If

                            If dtLocal.Columns.Contains("prsmnm") Then
                                .LoadInsuredMiddleName =
                                    cDataType.fString.IfNull(
                                        dr.Item("prsmnm")
                                    )
                            End If

                            'Set the complete name after the individual fields.
                            If dtLocal.Columns.Contains("prsnme") Then
                                .LoadInsuredName =
                                    cDataType.fString.IfNull(
                                        dr.Item("prsnme")
                                    )
                            End If

                            .IsInsuredExist = True

                        Else

                            .LoadInsuredID =
                                cDataType.fLong.Empty

                            .LoadInsuredFirstName =
                                String.Empty

                            .LoadInsuredLastName =
                                String.Empty

                            .LoadInsuredMiddleName =
                                String.Empty

                            .LoadInsuredName =
                                String.Empty

                            .SearchInsuredType =
                                String.Empty

                            .IsInsuredExist = False

                            Call SetMessage(
                                "No Record(s) Found.",
                                eSystemMessage.Information,
                                True
                            )

                        End If

                    End With

                End If

            Catch ex As Exception

                Call SetMessage(
                    String.Concat(
                        "A runtime error has occurred.<br /><br />",
                        "Error LoadInsured.<br /><br />",
                        ex.Message
                    ),
                    eSystemMessage.Critical,
                    True
                )

            End Try

        End Sub
        Private Sub LoadSearchInsured(
    ByVal sender As Object,
    ByVal e As EventArgs
)

            Const SEARCH_TYPE_GROUP_CLIENT As Integer = 3

            Dim objBLL As New bllPerson.BPrsMas
            Dim dtLocal As DataTable
            Dim strPolType As String = String.Empty
            Dim intSearchType As Integer = 0

            Try
                If IsValid() Then

                    Dim vwPolicyContext As Search.IInsuredPolicyContext

                    vwPolicyContext =
                        TryCast(
                            vwInsured, 
                            Search.IInsuredPolicyContext
                        )

                    If vwPolicyContext IsNot Nothing Then
                        strPolType =
                            vwPolicyContext.SearchInsuredPolType
                    End If

                    With vwInsured

                        If String.Equals(
                            strPolType,
                            "G",
                            StringComparison.OrdinalIgnoreCase
                        ) Then
                            intSearchType =
                                SEARCH_TYPE_GROUP_CLIENT
                        End If

                        dtLocal = objBLL.SearchPrsMas1(
                            .SearchInsuredID,
                            .SearchInsuredName,
                            .SearchInsuredType,
                            intSearchType
                        )

                        .dtSearchInsured = dtLocal

                        If dtLocal Is Nothing OrElse
                           dtLocal.Rows.Count = 0 Then

                            Call SetMessage(
                                "No Record(s) Found.",
                                eSystemMessage.Information,
                                True
                            )
                        End If

                    End With
                End If

            Catch ex As Exception
                Call SetMessage(
                    String.Concat(
                        "A runtime error has occurred.<br /><br />",
                        "Error LoadSearchInsured.<br /><br />",
                        ex.Message
                    ),
                    eSystemMessage.Critical,
                    True
                )
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


