#Region "Description"
' PAGE NAME     : Search Payor Presenter
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

    Public Class PPayor

#Region "Implements"

#End Region

#Region "Variables"
        Private vwSysMsg As preSecurity.ISystemMessage
        Private vwPayor As Search.IPayor
#End Region

#Region "Properties"

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pView As Search.IPayor)

            vwSysMsg = pView
            vwPayor = pView

            With vwPayor
                AddHandler .ClearScreenSearchPayor, AddressOf ClearScreenSearchPayor
                ' ------------------------------------------------------------------------------- 
                AddHandler .LoadPayor, AddressOf LoadPayor
                AddHandler .LoadSearchPayor, AddressOf LoadSearchPayor
            End With

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

        Private Function IsValid() As Boolean

            Try
                With vwPayor
                    If .SearchPayorID = cDataType.fLong.Empty And .SearchPayorName = cDataType.fString.Empty Then
                        Call SetMessage("Please enter at least 1 search criteria.", eSystemMessage.Warning, True)
                        Return False
                    End If

                    If .SearchPayorName.Length > 0 And .SearchPayorName.Length < 3 Then
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

        Private Function IsValidPayor() As Boolean

            Try
                With vwPayor
                    If .LoadPayorID = cDataType.fLong.Empty Then
                        Call SetMessage("Please enter payor id.", eSystemMessage.Warning, True)
                        Return False
                    End If
                End With
                Return True
            Catch ex As Exception
                Throw New Exception(String.Concat("IsValidPayor : ", ex.Message))
                'Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error IsValidPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Function

#End Region

#Region "Transactions"

        Private Sub ClearScreenSearchPayor(ByVal sender As Object, ByVal e As EventArgs)

            Try
                With vwPayor
                    .SearchPayorType = cDataType.fString.Empty
                    .SearchPayorID = cDataType.fLong.Empty
                    .SearchPayorName = cDataType.fString.Empty
                    .dtSearchPayor = Nothing
                End With
            Catch ex As Exception
                Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error ClearScreenSearchPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
            End Try

        End Sub

        ' ------------------------------------------------------------------------------- 

        'Private Sub LoadPayor(ByVal sender As Object, ByVal e As EventArgs) 

        '    Dim objBLL As New bllPerson.BPrsMas
        '    Dim dtLocal As DataTable

        '    Try
        '        If IsValidPayor() Then
        '            With vwPayor
        '                .IsPayorExist = False

        '                dtLocal = objBLL.SearchPrsMas2(.LoadPayorID, "", .LoadPayorType, .LoadSearchType)

        '                If dtLocal.Rows.Count <> 0 Then
        '                    For Each dr As DataRow In dtLocal.Rows
        '                        .LoadPayorID = cDataType.fLong.IfNull(dr.Item("prspid"))
        '                        .LoadPayorType = cDataType.fString.IfNull(dr.Item("prssex"))
        '                        .IsPayorExist = True
        '                    Next
        '                Else
        '                    .LoadPayorID = cDataType.fLong.Empty
        '                    Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
        '                End If
        '            End With
        '        End If
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        'Private Sub LoadSearchPayor(ByVal sender As Object, ByVal e As EventArgs)

        '    Dim objBLL As New bllPerson.BPrsMas
        '    Dim dtLocal As DataTable

        '    Try
        '        If IsValid() Then
        '            With vwPayor
        '                dtLocal = objBLL.SearchPrsMas2(.SearchPayorID, .SearchPayorName, .SearchPayorType, .LoadSearchType)
        '                If dtLocal.Rows.Count = 0 Then
        '                    Call SetMessage("No Record(s) Found.", eSystemMessage.Information, True)
        '                    'ElseIf dtLocal.Rows.Count > 100 Then
        '                    '   Call SetMessage("Please use longer search criteria.", eSystemMessage.Information, True)
        '                    '   dtLocal.Rows.Clear()
        '                End If
        '                .dtSearchPayor = dtLocal
        '            End With
        '        End If
        '    Catch ex As Exception
        '        Call SetMessage(String.Concat("A runtime error has occurred.<br /><br />", "Error LoadSearchPayor.<br /><br />", ex.Message), eSystemMessage.Critical, True)
        '    End Try

        'End Sub

        Private Sub LoadPayor(
        ByVal sender As Object,
        ByVal e As EventArgs
    )

            Const SEARCH_TYPE_GROUP_PAYOR As Integer = 3

            Dim objBLL As New bllPerson.BPrsMas
            Dim dtLocal As DataTable
            Dim strPolType As String = String.Empty
            Dim intSearchType As Integer

            Try
                If IsValidPayor() Then

                    Dim vwPolicyContext As Search.IPayorPolicyContext
                    vwPolicyContext =
                        TryCast(vwPayor, Search.IPayorPolicyContext)

                    If vwPolicyContext IsNot Nothing Then
                        strPolType = vwPolicyContext.SearchPayorPolType
                    End If

                    With vwPayor

                        .IsPayorExist = False

                        intSearchType = .LoadSearchType

                        If String.Equals(
                            strPolType,
                            "G",
                            StringComparison.OrdinalIgnoreCase
                        ) Then
                            intSearchType = SEARCH_TYPE_GROUP_PAYOR
                        End If

                        dtLocal = objBLL.SearchPrsMas2(
                            .LoadPayorID,
                            String.Empty,
                            .LoadPayorType,
                            intSearchType
                        )

                        If dtLocal IsNot Nothing AndAlso
                           dtLocal.Rows.Count > 0 Then

                            Dim dr As DataRow = dtLocal.Rows(0)

                            .LoadPayorID =
                                cDataType.fLong.IfNull(
                                    dr.Item("prspid")
                                )

                            .SearchPayorName =
                                cDataType.fString.IfNull(
                                    dr.Item("prsnme")
                                )

                            .LoadPayorType =
                                cDataType.fString.IfNull(
                                    dr.Item("prssex")
                                )

                            .IsPayorExist = True

                        Else
                            .LoadPayorID = cDataType.fLong.Empty
                            .SearchPayorName = String.Empty
                            .IsPayorExist = False

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
                        "Error LoadPayor.<br /><br />",
                        ex.Message
                    ),
                    eSystemMessage.Critical,
                    True
                )
            End Try

        End Sub
        Private Sub LoadSearchPayor(
     ByVal sender As Object,
     ByVal e As EventArgs
 )

            Const SEARCH_TYPE_GROUP_PAYOR As Integer = 3

            Dim objBLL As New bllPerson.BPrsMas
            Dim dtLocal As DataTable
            Dim strPolType As String = String.Empty
            Dim intSearchType As Integer

            Try
                If IsValid() Then

                    Dim vwPolicyContext As Search.IPayorPolicyContext
                    vwPolicyContext =
                        TryCast(vwPayor, Search.IPayorPolicyContext)

                    If vwPolicyContext IsNot Nothing Then
                        strPolType = vwPolicyContext.SearchPayorPolType
                    End If

                    With vwPayor

                        intSearchType = .LoadSearchType

                        If String.Equals(
                            strPolType,
                            "G",
                            StringComparison.OrdinalIgnoreCase
                        ) Then
                            intSearchType = SEARCH_TYPE_GROUP_PAYOR
                        End If

                        dtLocal = objBLL.SearchPrsMas2(
                            .SearchPayorID,
                            .SearchPayorName,
                            .SearchPayorType,
                            intSearchType
                        )

                        If dtLocal.Rows.Count = 0 Then
                            Call SetMessage(
                                "No Record(s) Found.",
                                eSystemMessage.Information,
                                True
                            )
                        End If

                        .dtSearchPayor = dtLocal

                    End With
                End If

            Catch ex As Exception
                Call SetMessage(
                    String.Concat(
                        "A runtime error has occurred.<br /><br />",
                        "Error LoadSearchPayor.<br /><br />",
                        ex.Message
                    ),
                    eSystemMessage.Critical,
                    True
                )
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


