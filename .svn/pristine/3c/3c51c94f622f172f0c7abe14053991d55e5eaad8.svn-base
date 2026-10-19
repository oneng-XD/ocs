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
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports bllWorking = Cocolife.BLL.OCS.Working
Imports dalMaintenance = Cocolife.DAL.OCS.Maintenance
Imports System.Configuration
#End Region

Namespace Payment

    Public Class BPaymentCheckTagging

#Region "Implements"
        Implements Payment.IPaymentCheckTagging
#End Region

#Region "Variables"
        Private mIsSuccessful As Boolean
        Private mUserID As Long
        Private mSiteCode As Long
        Private mSiteOprCheck As New List(Of Object)
#End Region

#Region "Properties"

        Public Property IsSuccessful As Boolean Implements IPaymentCheckTagging.IsSuccessful
            Get
                Return mIsSuccessful
            End Get
            Set(value As Boolean)
                mIsSuccessful = value
            End Set
        End Property

        Public Property UserID As Long Implements IPaymentCheckTagging.UserID
            Get
                Return mUserID
            End Get
            Set(value As Long)
                mUserID = value
            End Set
        End Property

        Public Property SiteCode As Long Implements IPaymentCheckTagging.SiteCode
            Get
                Return mSiteCode
            End Get
            Set(value As Long)
                mSiteCode = value
            End Set
        End Property

        Public Property SiteOprCheck As List(Of Object) Implements IPaymentCheckTagging.SiteOprCheck
            Get
                Return mSiteOprCheck
            End Get
            Set(value As List(Of Object))
                mSiteOprCheck = value
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

#End Region

#Region "Transactions"

        Public Sub TagCheck() Implements IPaymentCheckTagging.TagCheck
            Dim strItem As String = String.Empty

            Dim NewgenPaymentUpd As New BLL.OCS.Staging.BNewgenLifePayment

            Dim oraConn As New OracleConnection
            Dim oraTrans As OracleTransaction = Nothing

            Try

                oraConn = bllConn.Instance.OpenNew()
                oraTrans = oraConn.BeginTransaction()

                IsSuccessful = False

                For Each item In SiteOprCheck
                    strItem = item.Alter("UPDATE", oraConn, oraTrans)
                    If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                        Throw New ArgumentException(String.Concat("SiteOPRChkPy : ", strItem))
                    End If
                    ' NG POSTING OF CHECK CLEARANCE
                    If Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Life"), "false")) Or Boolean.Parse(If(ConfigurationManager.AppSettings("Newgen-Group"), "false")) Then
                        If item.ClearingStatusId = 2 Then
                            strItem = NewgenPaymentUpd.UpdateStatus(item.OPRNmbr, item.ChkNmbr, item.Amount, "10", "2", item.ReceiptDate, oraConn, oraTrans)
                            If Not IsNumeric(strItem) OrElse CLng(strItem) = 0 Then
                                Throw New ArgumentException(String.Concat("Newgen Update Payment : ", strItem))
                            End If
                        End If
                    End If
                Next

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

#End Region

    End Class

End Namespace

