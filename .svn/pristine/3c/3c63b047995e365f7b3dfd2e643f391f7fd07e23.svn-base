#Region "Description"
' PAGE NAME     : Common Validation Utility
' CREATED BY    : MPRO
' CREATED DATE  : 03/27/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"

#End Region

Namespace Common

    Public Class uValidation

#Region "Variables"

#End Region

#Region "Properties"

#End Region

#Region "Constructor"

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

#End Region

#Region "Transactions"

        Public Shared Function CreditCardValidation(ByVal pCreditCardNo As String)

            Dim NumberLength As Integer
            Dim CardName As String
            Dim CardType As String
            Dim ShouldLength As Integer
            Dim Missing As Integer

            Try

                ' 1) Get rid of spaces and non-numeric characters.
                pCreditCardNo = OnlyNumericSolution(pCreditCardNo)

                ' 2) Do the first four digits fit within proper ranges?
                ' If so, who's the card issuer and how long should the number be?
                NumberLength = Len(pCreditCardNo)
                Select Case Left(pCreditCardNo, 4)
                    'Case 3000 To 3059, 3600 To 3699, 3800 To 3889
                    '    CardName = "Diners Club"
                    '    ShouldLength = 14
                    Case 3400 To 3499, 3700 To 3799
                        CardType = "AM"
                        CardName = "American Express"
                        ShouldLength = 15
                    Case 3528 To 3589
                        CardType = "JC"
                        CardName = "JCB"
                        ShouldLength = 16
                        'Case 3890 To 3899
                        '    CardName = "Carte Blanche"
                        '    ShouldLength = 14
                    Case 4000 To 4999
                        CardType = "VC"
                        CardName = "Visa"
                        Select Case NumberLength
                            Case Is > 14
                                ShouldLength = 16
                            Case Is < 14
                                ShouldLength = 13
                            Case Else
                                CreditCardValidation = "FALSE" & "|" & CardType & "|" & CardName & "|" & "The Visa number you typed in is 14 digits long." & Chr(13) & "Visa cards usually have 16 digits, though some have 13." & Chr(13) & Chr(13) & "Please check the number and try again."
                                Exit Function
                        End Select
                    Case 5100 To 5599
                        CardType = "MC"
                        CardName = "MasterCard"
                        ShouldLength = 16
                        'Case 5610
                        '    CardName = "Australian BankCard"
                        '    ShouldLength = 16
                        'Case 6011
                        '    CardName = "Discover/Novus"
                        '    ShouldLength = 16
                    Case Else
                        CardType = "ERR"
                        CardName = ""
                        CreditCardValidation = "FALSE" & "|" & CardType & "|" & CardName & "|" & "The first four digits of the number entered are " & Left(pCreditCardNo, 4) & "." & Chr(13) & "If that's correct, we don't accept that type of credit card." & Chr(13) & "If it's wrong, please try again."
                        Exit Function
                End Select

                '3) Is the number the right length?
                If NumberLength <> ShouldLength Then
                    Missing = NumberLength - ShouldLength
                    If Missing < 0 Then
                        CreditCardValidation = "FALSE" & "|" & CardType & "|" & CardName & "|" & "The " & CardName & " number entered, " & pCreditCardNo & ", is missing " & Math.Abs(Missing) & " digit(s)." & Chr(13) & Chr(13) & "Please check the number and try again."
                    Else
                        CreditCardValidation = "FALSE" & "|" & CardType & "|" & CardName & "|" & "The " & CardName & " number entered, " & pCreditCardNo & ", has " & Missing & " too many digit(s)." & Chr(13) & Chr(13) & "Please check the number and try again."
                    End If
                    Exit Function
                End If

                '4) Does the number pass the Mod 10 Algorithm Checksum?
                If Mod10Solution(pCreditCardNo) = True Then
                    CreditCardValidation = "TRUE" & "|" & CardType & "|" & CardName & "|VALID"
                Else
                    CreditCardValidation = "FALSE" & "|" & CardType & "|" & CardName & "|" & "The " & CardName & " number entered, " & pCreditCardNo & ", is invalid." & Chr(13) & Chr(13) & "Please check the number and try again."
                End If

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Shared Function Mod10Solution(ByVal pCreditCardNo As String) As Boolean

            Dim NumberLength As Byte
            Dim Location As Byte
            Dim Checksum As Integer
            Dim Digit As Byte

            Try

                NumberLength = Len(pCreditCardNo)

                'Add even digits in even length strings
                'or odd digits in odd length strings.
                For Location = 2 - (NumberLength Mod 2) To NumberLength Step 2
                    Checksum = Mid(pCreditCardNo, Location, 1) + Checksum
                Next Location

                'Analyze odd digits in even length strings
                'or even digits in odd length strings.
                For Location = (NumberLength Mod 2) + 1 To NumberLength Step 2
                    Digit = Mid(pCreditCardNo, Location, 1) * 2
                    If Digit < 10 Then
                        Checksum = Digit + Checksum
                    Else
                        Checksum = Digit - 9 + Checksum
                    End If
                Next Location

                'Is the checksum divisible by ten?
                Mod10Solution = (Checksum Mod 10 = 0)

            Catch ex As Exception
                Mod10Solution = False
                Throw
            End Try

        End Function

        Public Shared Function OnlyNumericSolution(ByVal pCreditCardNo As String)

            Dim Location As Integer
            Dim NumberLength As Integer
            Dim CurrentOutput As String = ""
            'Dim CurrentCharacter As String * 1
            Dim CurrentCharacter As String = ""

            Try

                NumberLength = Len(pCreditCardNo)
                If NumberLength > 50 Then NumberLength = 50 ' Avoids system overload from hacking via super long input.

                ' Go through each number in the string.
                For Location = 1 To NumberLength
                    CurrentCharacter = Mid(pCreditCardNo, Location, 1)
                    Select Case Asc(CurrentCharacter)
                        Case 48 To 57
                            ' This character is a number,
                            ' append it to the variable we're going to output.
                            CurrentOutput = CurrentOutput & CurrentCharacter
                    End Select
                Next

                OnlyNumericSolution = CurrentOutput

            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace

