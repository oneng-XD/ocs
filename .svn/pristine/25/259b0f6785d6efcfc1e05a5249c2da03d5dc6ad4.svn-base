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
Imports System.Data.OracleClient
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BSiteDetails

#Region "Implements"
        Implements BLL.OCS.Reference.ISiteDetails
#End Region

#Region "Variables"
        Private mSiteCode As String
        Private mPrspid As Long
        Private mPrsnme As String
        Private mAddress As String
        Private mAddr2 As String
        Private mAddr3 As String
        Private mPhone As String
        Private mEmail As String
        Private mTin As String
        Private mPrefix As Integer
#End Region

#Region "Properties"
        Public Property SiteCode As String Implements ISiteDetails.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As String)
                mSiteCode = value
            End Set
        End Property

        Public Property Prspid As Long Implements ISiteDetails.Prspid
            Get
                Return mPrspid
            End Get
            Set(value As Long)
                mPrspid = value
            End Set
        End Property

        Public Property Prsnme As String Implements ISiteDetails.Prsnme
            Get
                Return mPrsnme
            End Get
            Set(value As String)
                mPrsnme = value
            End Set
        End Property

        Public Property Address As String Implements ISiteDetails.Address
            Get
                Return mAddress
            End Get
            Set(value As String)
                mAddress = value
            End Set
        End Property

        Public Property Phone As String Implements ISiteDetails.Phone
            Get
                Return mPhone
            End Get
            Set(value As String)
                mPhone = value
            End Set
        End Property

        Public Property Email As String Implements ISiteDetails.Email
            Get
                Return mEmail
            End Get
            Set(value As String)
                mEmail = value
            End Set
        End Property

        Public Property Tin As String Implements ISiteDetails.Tin
            Get
                Return mTin
            End Get
            Set(value As String)
                mTin = value
            End Set
        End Property

        Public Property Prefix As Integer Implements ISiteDetails.Prefix
            Get
                Return mPrefix
            End Get
            Set(value As Integer)
                mPrefix = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Function LoadSourceSite() As DataTable Implements ISiteDetails.LoadSourceSite

            Try

                Dim objDAL As New dalReference.DSiteDetails
                Dim dtLocal As New DataTable

                dtLocal.Load(objDAL.GetSiteDetails(0))
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try


        End Function

        Public Sub GetSiteDetails(ByVal pPrspid As Long) Implements ISiteDetails.GetSiteDetails
            Dim objDal As New dalReference.DSiteDetails
            Dim drLocal As OracleDataReader

            Try
                drLocal = objDal.GetSiteDetails(pPrspid)
                With drLocal
                    While .Read
                        SiteCode = cDataType.fString.IfNull(.Item("SiteCode"))
                        Prspid = cDataType.fLong.IfNull(.Item("Prspid"))
                        Prsnme = cDataType.fString.IfNull(.Item("Prsnme"))
                        Address = cDataType.fString.IfNull(.Item("Address"))
                        Phone = cDataType.fString.IfNull(.Item("Phone"))
                        Email = cDataType.fString.IfNull(.Item("Email"))
                        Tin = cDataType.fString.IfNull(.Item("Tin"))
                        Prefix = cDataType.fInteger.IfNull(.Item("Prefix"))
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try
        End Sub

#End Region

#Region "Transactions"

#End Region

    End Class

End Namespace

