#Region "Description"
' PAGE NAME     : Person Class
' CREATED BY    : EJC
' CREATED DATE  : 03/11/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Common

    Public Class BPerson

#Region "Variables"
        Private lngPersonID As Long
        Private strFirstName As String
        Private strMiddleName As String
        Private strLastName As String
        Private chrGender As Char

        Private Shared mInstance As BPerson
#End Region

#Region "Properties"

        Property PersonID As Long
            Get
                Return lngPersonID
            End Get
            Set(value As Long)
                lngPersonID = value
            End Set
        End Property

        Property FirstName As String
            Get
                Return strFirstName
            End Get
            Set(value As String)
                strFirstName = value
            End Set
        End Property

        Property MiddleName As String
            Get
                Return strMiddleName
            End Get
            Set(value As String)
                strMiddleName = value
            End Set
        End Property

        Property LastName As String
            Get
                Return strLastName
            End Get
            Set(value As String)
                strLastName = value
            End Set
        End Property

#End Region

#Region "Constructor"
        Sub New()
            'SearchDetails()
        End Sub

        Sub New(ByVal LastName As String, ByVal FirstName As String, ByVal MiddleName As String, Optional ByVal PersonID As Long = 0)
            Me.LastName = LastName
            Me.FirstName = FirstName
            Me.MiddleName = MiddleName
            Me.PersonID = PersonID
        End Sub

        Public Shared Function Instance() As BPerson
            If mInstance Is Nothing Then
                mInstance = New BPerson()
            End If

            Return mInstance
        End Function

#End Region

#Region "Single Point Functions"
        Public Function GetFullName() As String
            Return LastName & ";" & FirstName & " " & MiddleName
        End Function
#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"


#End Region

    End Class

End Namespace