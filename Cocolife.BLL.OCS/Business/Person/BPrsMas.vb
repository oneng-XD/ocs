#Region "Description"
' PAGE NAME     : PRSMAS BLL
' CREATED BY    : MPRO
' CREATED DATE  : 04/29/2013
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalPerson = Cocolife.DAL.OCS.Person
#End Region

Namespace Person

    Public Class BPrsMas

#Region "Implements"
        Implements Person.IPrsMas
#End Region

#Region "Variables"
        Private mPrsPID As Long = cDataType.fLong.Empty
        Private mPrsNme As String = cDataType.fString.Empty
        Private mPrsTit As String = cDataType.fString.Empty
        Private mPrsSex As String = cDataType.fString.Empty
        Private mPrsSoc As String = cDataType.fString.Empty
        Private mPrsPlc As String = cDataType.fString.Empty
        Private mPrsDOB As date = cDataType.fDate.Empty
        Private mPrsEml As String = cDataType.fString.Empty
        Private mPrsLnm As String = cDataType.fString.Empty
        Private mPrsFnm As String = cDataType.fString.Empty
        Private mPrsMnm As String = cDataType.fString.Empty
        Private mPrsNsf As String = cDataType.fString.Empty
        Private mPrsIdx As String = cDataType.fString.Empty
        Private mPrsCel As String = cDataType.fString.Empty
        Private mPrsPag As String = cDataType.fString.Empty
        Private mDivNum As String = cDataType.fString.Empty
        Private mStaNum As String = cDataType.fString.Empty

        Private mId_Number As String = cDataType.fString.Empty
        Private mAddMas As String = cDataType.fString.Empty
        ' -------------------------------------------------------------------------------
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"

        Public Property PrsPID() As Long Implements Person.IPrsMas.PrsPID
            Get
                Return mPrsPID
            End Get
            Set(ByVal value As Long)
                mPrsPID = value
            End Set
        End Property

        Public Property PrsNme() As String Implements Person.IPrsMas.PrsNme
            Get
                Return mPrsNme
            End Get
            Set(ByVal value As String)
                mPrsNme = value
            End Set
        End Property

        Public Property PrsTit() As String Implements Person.IPrsMas.PrsTit
            Get
                Return mPrsTit
            End Get
            Set(ByVal value As String)
                mPrsTit = value
            End Set
        End Property

        Public Property PrsSex() As String Implements Person.IPrsMas.PrsSex
            Get
                Return mPrsSex
            End Get
            Set(ByVal value As String)
                mPrsSex = value
            End Set
        End Property

        Public Property PrsSoc() As String Implements Person.IPrsMas.PrsSoc
            Get
                Return mPrsSoc
            End Get
            Set(ByVal value As String)
                mPrsSoc = value
            End Set
        End Property

        Public Property PrsPlc() As String Implements Person.IPrsMas.PrsPlc
            Get
                Return mPrsPlc
            End Get
            Set(ByVal value As String)
                mPrsPlc = value
            End Set
        End Property

        Public Property PrsDOB() As date Implements Person.IPrsMas.PrsDOB
            Get
                Return mPrsDOB
            End Get
            Set(ByVal value As date)
                mPrsDOB = value
            End Set
        End Property

        Public Property PrsEml() As String Implements Person.IPrsMas.PrsEml
            Get
                Return mPrsEml
            End Get
            Set(ByVal value As String)
                mPrsEml = value
            End Set
        End Property

        Public Property PrsLnm() As String Implements Person.IPrsMas.PrsLnm
            Get
                Return mPrsLnm
            End Get
            Set(ByVal value As String)
                mPrsLnm = value
            End Set
        End Property

        Public Property PrsFnm() As String Implements Person.IPrsMas.PrsFnm
            Get
                Return mPrsFnm
            End Get
            Set(ByVal value As String)
                mPrsFnm = value
            End Set
        End Property

        Public Property PrsMnm() As String Implements Person.IPrsMas.PrsMnm
            Get
                Return mPrsMnm
            End Get
            Set(ByVal value As String)
                mPrsMnm = value
            End Set
        End Property

        Public Property PrsNsf() As String Implements Person.IPrsMas.PrsNsf
            Get
                Return mPrsNsf
            End Get
            Set(ByVal value As String)
                mPrsNsf = value
            End Set
        End Property

        Public Property PrsIdx() As String Implements Person.IPrsMas.PrsIdx
            Get
                Return mPrsIdx
            End Get
            Set(ByVal value As String)
                mPrsIdx = value
            End Set
        End Property

        Public Property PrsCel() As String Implements Person.IPrsMas.PrsCel
            Get
                Return mPrsCel
            End Get
            Set(ByVal value As String)
                mPrsCel = value
            End Set
        End Property

        Public Property PrsPag() As String Implements Person.IPrsMas.PrsPag
            Get
                Return mPrsPag
            End Get
            Set(ByVal value As String)
                mPrsPag = value
            End Set
        End Property

        Public Property DivNum() As String Implements Person.IPrsMas.DivNum
            Get
                Return mDivNum
            End Get
            Set(ByVal value As String)
                mDivNum = value
            End Set
        End Property

        Public Property StaNum() As String Implements Person.IPrsMas.StaNum
            Get
                Return mStaNum
            End Get
            Set(ByVal value As String)
                mStaNum = value
            End Set
        End Property

        Public Property Id_Number() As String Implements Person.IPrsMas.Id_Number
            Get
                Return mId_Number
            End Get
            Set(ByVal value As String)
                mId_Number = value
            End Set
        End Property
        Public Property AddMas() As String Implements Person.IPrsMas.AddMas
            Get
                Return mAddMas
            End Get
            Set(ByVal value As String)
                mAddMas = value
            End Set
        End Property

        ' -------------------------------------------------------------------------------

        Public Property IsRecordExist() As Boolean Implements Person.IPrsMas.IsRecordExist
            Get
                Return mIsRecordExist
            End Get
            Set(ByVal value As Boolean)
                mIsRecordExist = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pPrsPID As Long, ByVal pPrsNme As String, ByVal pPrsTit As String, ByVal pPrsSex As String, ByVal pPrsSoc As String, _
         ByVal pPrsPlc As String, ByVal pPrsDOB As DateTime, ByVal pPrsEml As String, ByVal pPrsLnm As String, ByVal pPrsFnm As String, _
         ByVal pPrsMnm As String, ByVal pPrsNsf As String, ByVal pPrsIdx As String, ByVal pPrsCel As String, ByVal pPrsPag As String, _
         ByVal pDivNum As String, ByVal pStaNum As String, ByVal pId_Number As String, ByVal pAddMas As String)

            PrsPID = pPrsPID       ' 1
            PrsNme = pPrsNme       ' 2
            PrsTit = pPrsTit       ' 3
            PrsSex = pPrsSex       ' 4
            PrsSoc = pPrsSoc       ' 5
            PrsPlc = pPrsPlc       ' 6
            PrsDOB = pPrsDOB       ' 7
            PrsEml = pPrsEml       ' 8
            PrsLnm = pPrsLnm       ' 9
            PrsFnm = pPrsFnm       ' 10
            PrsMnm = pPrsMnm       ' 11
            PrsNsf = pPrsNsf       ' 12
            PrsIdx = pPrsIdx       ' 13
            PrsCel = pPrsCel       ' 14
            PrsPag = pPrsPag       ' 15
            DivNum = pDivNum       ' 16
            StaNum = pStaNum       ' 17

            Id_Number = pId_Number      ' 18
            AddMas = pAddMas      ' 19

        End Sub
#End Region

#Region "Single Point Functions"

        Public Function GetPrsPID(ByVal pPrsNme As String, ByVal pPrsSex As String, ByVal pPrsDOB As date) As Long Implements Person.IPrsMas.GetPrsPID

            Dim objDAL As New dalPerson.DPrsMas
            Dim lngPrsPID As Long = 0

            Try
                lngPrsPID = objDAL.GetPrsPID(pPrsNme, pPrsSex, pPrsDOB)
                Return lngPrsPID
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Sub GetPrsMas(ByVal pPrsPID As Long) Implements Person.IPrsMas.GetPrsMas

            Dim objDAL As New dalPerson.DPrsMas
            Dim drLocal As OracleDataReader

            Try

                IsRecordExist = False
                drLocal = objDAL.GetPrsMas(pPrsPID)
                With drLocal
                    While .Read
                        PrsPID = cDataType.fLong.IfNull(.Item("prspid"))
                        PrsNme = cDataType.fString.IfNull(.Item("prsnme"))
                        PrsTit = cDataType.fString.IfNull(.Item("prstit"))
                        PrsSex = cDataType.fString.IfNull(.Item("prssex"))
                        PrsSoc = cDataType.fString.IfNull(.Item("prssoc"))
                        PrsPlc = cDataType.fString.IfNull(.Item("prsplc"))
                        PrsDOB = cDataType.fDate.IfNull(.Item("prsdob"))
                        PrsEml = cDataType.fString.IfNull(.Item("prseml"))
                        PrsLnm = cDataType.fString.IfNull(.Item("prslnm"))
                        PrsFnm = cDataType.fString.IfNull(.Item("prsfnm"))
                        PrsMnm = cDataType.fString.IfNull(.Item("prsmnm"))
                        PrsNsf = cDataType.fString.IfNull(.Item("prsnsf"))
                        PrsIdx = cDataType.fString.IfNull(.Item("prsidx"))
                        PrsCel = cDataType.fString.IfNull(.Item("prscel"))
                        PrsPag = cDataType.fString.IfNull(.Item("prspag"))
                        DivNum = cDataType.fString.IfNull(.Item("divnum"))
                        StaNum = cDataType.fString.IfNull(.Item("stanum"))
                        Id_Number = cDataType.fString.IfNull(.Item("id_number"))
                        AddMas = cDataType.fString.IfNull(.Item("address"))
                        IsRecordExist = True
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try

        End Sub

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function SearchPrsMasAll(ByVal pPrsPID As Long, ByVal pPrsNme As String) As DataTable Implements Person.IPrsMas.SearchPrsMasAll

            Dim objDAL As New dalPerson.DPrsMas
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.SearchPrsMas(pPrsPID, pPrsNme, 0)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try

        End Function

        'Public Function SearchPrsMas1(ByVal pPrsPID As Long, ByVal pPrsNme As String) As DataTable Implements Person.IPrsMas.SearchPrsMasInsured

        '    Dim objDAL As New dalPerson.DPrsMas
        '    Dim dtLocal As DataTable

        '    Try
        '        dtLocal = objDAL.SearchPrsMas(pPrsPID, pPrsNme, 1)
        '        Return dtLocal
        '    Catch ex As Exception
        '        Throw
        '    End Try

        'End Function

        Public Function SearchPrsMas1(
    ByVal pPrsPID As Long,
    ByVal pPrsNme As String,
    Optional ByVal pPrsSex As String = "",
    Optional ByVal pSearchType As Integer = 0
) As DataTable _
Implements Person.IPrsMas.SearchPrsMasInsured

            Const SEARCH_TYPE_GROUP_CLIENT As Integer = 3
            Const SP_MODE_REGULAR_INSURED As Integer = 1
            Const SP_MODE_GROUP_CLIENT As Integer = 5
            Const CLIENT_TYPE_INSURED As String = "I"

            Dim objDAL As New dalPerson.DPrsMas
            Dim intSpMode As Integer
            Dim dtLocal As DataTable

            Try
                If pSearchType = SEARCH_TYPE_GROUP_CLIENT Then

                    intSpMode = SP_MODE_GROUP_CLIENT

                    If Not String.IsNullOrWhiteSpace(pPrsSex) Then

                        'Gender is already available.
                        dtLocal = objDAL.SearchPrsMas(
                            pPrsPID,
                            pPrsNme,
                            intSpMode,
                            pPrsSex.Trim().ToUpperInvariant(),
                            CLIENT_TYPE_INSURED
                        )

                    ElseIf pPrsPID > 0 Then

                        'ID search:
                        'Try each gender and stop on the first match.
                        Dim arrGender() As String = {"M", "F", "C"}

                        For Each strGender As String In arrGender

                            dtLocal = objDAL.SearchPrsMas(
                                pPrsPID,
                                pPrsNme,
                                intSpMode,
                                strGender,
                                CLIENT_TYPE_INSURED
                            )

                            If dtLocal IsNot Nothing AndAlso
                               dtLocal.Rows.Count > 0 Then

                                Exit For
                            End If

                        Next

                    ElseIf Not String.IsNullOrWhiteSpace(pPrsNme) Then

                        'Name search:
                        'Combine the gender results, but limit the result size.
                        Const MAX_SEARCH_ROWS As Integer = 500

                        Dim arrGender() As String = {"M", "F", "C"}
                        Dim dtCombined As DataTable = Nothing

                        For Each strGender As String In arrGender

                            Dim dtResult As DataTable

                            dtResult = objDAL.SearchPrsMas(
                                0,
                                pPrsNme.Trim(),
                                intSpMode,
                                strGender,
                                CLIENT_TYPE_INSURED
                            )

                            If dtResult IsNot Nothing AndAlso
                               dtResult.Rows.Count > 0 Then

                                'Do not attempt to import an extremely large result.
                                If dtResult.Rows.Count > MAX_SEARCH_ROWS Then
                                    Throw New ApplicationException(
                                        "Too many insured records were found. " &
                                        "Please enter a longer or more specific name."
                                    )
                                End If

                                If dtCombined Is Nothing Then
                                    dtCombined = dtResult.Clone()
                                End If

                                For Each dr As DataRow In dtResult.Rows

                                    Dim bolExists As Boolean = False
                                    Dim strID As String =
                                        Convert.ToString(dr.Item("prspid"))

                                    For Each existingRow As DataRow In dtCombined.Rows

                                        If Convert.ToString(
                                            existingRow.Item("prspid")
                                        ) = strID Then

                                            bolExists = True
                                            Exit For
                                        End If

                                    Next

                                    If Not bolExists Then
                                        dtCombined.ImportRow(dr)
                                    End If

                                    If dtCombined.Rows.Count > MAX_SEARCH_ROWS Then
                                        Throw New ApplicationException(
                                            "Too many insured records were found. " &
                                            "Please enter a longer or more specific name."
                                        )
                                    End If

                                Next

                            End If

                        Next

                        If dtCombined Is Nothing Then
                            dtLocal = New DataTable()
                        Else
                            dtLocal = dtCombined
                        End If

                    Else

                        dtLocal = New DataTable()

                    End If

                Else

                    intSpMode = SP_MODE_REGULAR_INSURED

                    dtLocal = objDAL.SearchPrsMas(
                        pPrsPID,
                        pPrsNme,
                        intSpMode,
                        pPrsSex,
                        CLIENT_TYPE_INSURED
                    )

                End If

                If dtLocal Is Nothing Then
                    dtLocal = New DataTable()
                End If

                Return dtLocal

            Catch
                Throw
            End Try

        End Function

        Public Function SearchPrsMas2(ByVal pPrsPID As Long,ByVal pPrsNme As String,Optional ByVal pPrsSex As String = "",Optional ByVal pSearchType As Integer = 0) As DataTable Implements Person.IPrsMas.SearchPrsMasPayor

            Const SEARCH_TYPE_GROUP_CLIENT As Integer = 3
            Const SP_MODE_REGULAR_PAYOR As Integer = 2
            Const SP_MODE_GROUP_CLIENT As Integer = 5
            Const CLIENT_TYPE_PAYOR As String = "P"

            Dim objDAL As New dalPerson.DPrsMas
            Dim intSpMode As Integer
            Dim dtLocal As DataTable

            Try
                Select Case pSearchType

                    Case SEARCH_TYPE_GROUP_CLIENT
                        intSpMode = SP_MODE_GROUP_CLIENT

                    Case 0
                        intSpMode = SP_MODE_REGULAR_PAYOR

                    Case Else
                        intSpMode = SP_MODE_REGULAR_PAYOR + pSearchType

                End Select

                dtLocal = objDAL.SearchPrsMas(
                    pPrsPID,
                    pPrsNme,
                    intSpMode,
                    pPrsSex,
                    CLIENT_TYPE_PAYOR
                )

                Return dtLocal

            Catch
                Throw
            End Try

        End Function

        'Public Function SearchPrsMas2(ByVal pPrsPID As Long, ByVal pPrsNme As String, Optional ByVal pPrsSex As String = "", Optional ByVal pSearchType As Integer = 0) As DataTable Implements Person.IPrsMas.SearchPrsMasPayor

        '    Const SEARCH_TYPE_GROUP_PAYOR As Integer = 3
        '    Const SP_MODE_REGULAR_PAYOR As Integer = 2
        '    Const SP_MODE_GROUP_PAYOR As Integer = 5

        '    Dim objDAL As New dalPerson.DPrsMas
        '    Dim dtLocal As DataTable
        '    Dim intSpMode As Integer

        '    Try
        '        Select Case pSearchType

        '            Case SEARCH_TYPE_GROUP_PAYOR
        '                intSpMode = SP_MODE_GROUP_PAYOR

        '            Case 0
        '                intSpMode = SP_MODE_REGULAR_PAYOR

        '            Case Else
        '                intSpMode = SP_MODE_REGULAR_PAYOR + pSearchType

        '        End Select

        '        dtLocal = objDAL.SearchPrsMas(
        '            pPrsPID,
        '            pPrsNme,
        '            intSpMode,
        '            pPrsSex
        '        )

        '        Return dtLocal

        '    Catch
        '        Throw
        '    End Try

        'End Function

#End Region

#Region "Transactions"

        Public Function InsertPrsMas(ByVal pList As IList(Of Person.BPrsMas), ByVal pSecoID As String, ByRef pConn As Object, ByRef pTrans As Object) As List(Of String) Implements Person.IPrsMas.InsertPrsMas

            Dim objDAL As New dalPerson.DPrsMas
            Dim lstItem As New List(Of String)

            Try
                lstItem = objDAL.AlterPrsMas(pList, pSecoID, "INSERT", pConn, pTrans)
                Return lstItem
            Catch ex As Exception
                Throw
            End Try

        End Function

        ' ------------------------------------------------------------------------------- 

        Public Function UpdatePrsMas(ByVal pList As IList(Of Person.BPrsMas), ByVal pSecoID As String, ByRef pConn As Object, ByRef pTrans As Object) As List(Of String) Implements Person.IPrsMas.UpdatePrsMas

            Dim objDAL As New dalPerson.DPrsMas
            Dim lstItem As New List(Of String)

            Try
                lstItem = objDAL.AlterPrsMas(pList, pSecoID, "UPDATE", pConn, pTrans)
                Return lstItem
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace


