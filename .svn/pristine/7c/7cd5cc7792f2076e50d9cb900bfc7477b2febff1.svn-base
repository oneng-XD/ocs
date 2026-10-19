#Region "Description"
' PAGE NAME     : Merchant Site BLL
' CREATED BY    : EJ
' CREATED DATE  : 09/15/2016
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalReference = Cocolife.DAL.OCS.Reference
#End Region

Namespace Reference

    Public Class BMerchantSite

#Region "Implements"
        Implements Reference.IMerchantSite
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean = cDataType.fBoolean.Empty
        Private mUserId As Long = cDataType.fLong.Empty

        Private mMerchantEditId As Long = cDataType.fLong.Empty
        Private mTerminalId As String = cDataType.fString.Empty
        Private mMerchantId As String = cDataType.fString.Empty
        Private mDbaName As String = cDataType.fString.Empty
        Private mSiteCode As Long = cDataType.fLong.Empty
        Private mEffDate As Date = cDataType.fDate.Empty
        Private mTermDate As Date = cDataType.fDate.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
#End Region

#Region "Properties"

        Property IsSuccessful As Boolean Implements Reference.IMerchantSite.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Property UserId As Long Implements Reference.IMerchantSite.UserID
            Get
                Return mUserId
            End Get
            Set(value As Long)
                mUserId = value
            End Set
        End Property
        '--------------------------------------------------
        Property MerchantEditId As Long Implements Reference.IMerchantSite.MerchantEditId
            Get
                Return mMerchantEditId
            End Get
            Set(value As Long)
                mMerchantEditId = value
            End Set
        End Property

        Property TerminalId As String Implements Reference.IMerchantSite.TerminalId
            Get
                Return mTerminalId
            End Get
            Set(value As String)
                mTerminalId = value
            End Set
        End Property

        Property MerchantId As String Implements Reference.IMerchantSite.MerchantId
            Get
                Return mMerchantId
            End Get
            Set(value As String)
                mMerchantId = value
            End Set
        End Property

        Property DbaName As String Implements Reference.IMerchantSite.DbaName
            Get
                Return mDbaName
            End Get
            Set(value As String)
                mDbaName = value
            End Set
        End Property

        Property SiteCode As Long Implements Reference.IMerchantSite.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Property EffDate As Date Implements Reference.IMerchantSite.EffDate
            Get
                Return mEffDate
            End Get
            Set(value As Date)
                mEffDate = value
            End Set
        End Property

        Property TermDate As Date Implements Reference.IMerchantSite.TermDate
            Get
                Return mTermDate
            End Get
            Set(value As Date)
                mTermDate = value
            End Set
        End Property

        Property StatusId As Integer Implements Reference.IMerchantSite.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
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
        Public Function GetRefMerchantSiteList(ByVal pSiteCode As Long) As DataTable Implements Reference.IMerchantSite.GetRefMerchantSiteList

            Try

                Dim objDAL As New dalReference.DMerchantSite
                Dim dtLocal As DataTable

                dtLocal = objDAL.GetRefMerchantSiteList(pSiteCode)
                Return dtLocal

            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetMerchantId(ByVal pSiteCode As Long, ByVal pTerminaluse As String) As String Implements IMerchantSite.GetMerchantId

            Try

                Dim objDAL As New dalReference.DMerchantSite
                Dim dtLocal As DataTable
                Dim mReturn As String = String.Empty

                dtLocal = objDAL.GetRefMerchantSiteList(pSiteCode)
                Dim dtFiltered = From c In dtLocal.AsEnumerable
                                 Where c.Item("terminal_id") = pTerminaluse
                                 Select c
                                 Order By c.Item("eff_date") Descending
                If dtFiltered.Any() Then
                    dtLocal = dtFiltered.CopyToDataTable()
                    For Each item As DataRow In dtLocal.Rows
                        mReturn = item.Item("merchant_id")
                        Exit For
                    Next
                End If

                Return mReturn

            Catch ex As Exception
                Throw
            End Try

        End Function
#End Region

#Region "Transactions"
        Public Sub SaveMerchantId() Implements IMerchantSite.SaveMerchantId
            Dim strItem As String = String.Empty

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                If MerchantEditId = 0 Then
                    Alter("INSERT", oraConn, oraTrans)
                Else
                    Alter("UPDATE", oraConn, oraTrans)
                End If

                oraTrans.Commit()
                IsSuccessful = True

            Catch ex As Exception
                oraTrans.Rollback()
                IsSuccessful = False
                Throw New Exception(String.Concat("Your data may not have been saved correctly. Please review your data and try again. <br />", ex.Message))
            Finally
                OracleConnection.ClearPool(oraConn)
                oraConn.Close()
                oraConn.Dispose()
            End Try

        End Sub


        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalReference.DMerchantSite
                objDAL.AlterMerchantSite(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function
#End Region

    End Class

End Namespace

