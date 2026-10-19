#Region "Description"
' PAGE NAME     : SITE_ORAPRPAY BLL
' CREATED BY    : EJ
' CREATED DATE  : 05/04/2015
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports System.Data.OracleClient
Imports eAction = Cocolife.Utility.Common.Enums.eDBAction
Imports cDataType = Cocolife.Utility.Common.DataType
Imports bllCommon = Cocolife.BLL.Common
Imports dalWorking = Cocolife.DAL.OCS.Working
#End Region

Namespace Working

    Public Class BSiteORAPRPay

#Region "Implements"
        Implements ISiteORAPRPay
#End Region

#Region "Variables"
        Private mId As Long = cDataType.fLong.Empty
        Private mORNmbr As Long = cDataType.fLong.Empty
        Private mAPRNmbr As Long = cDataType.fLong.Empty
        Private mAPRDate As Date = cDataType.fDate.Empty
        Private mAmount As Decimal = cDataType.fDecimal.Empty
        Private mLineNmbr As Integer = cDataType.fInteger.Empty
        Private mStatusId As Long = cDataType.fLong.Empty
        Private mPostBy As Long = cDataType.fLong.Empty
        Private mPostDate As Date = cDataType.fDate.Empty
        Private mLastUpdateBy As Long = cDataType.fLong.Empty
        Private mLastUpdate As Date = cDataType.fDate.Empty
#End Region

#Region "Properties"

        Public Property Id As Long Implements ISiteORAPRPay.Id
            Get
                Return mId
            End Get
            Set(value As Long)
                mId = value
            End Set
        End Property

        Public Property LastUpdate As Date Implements ISiteORAPRPay.LastUpdate
            Get
                Return mLastUpdate
            End Get
            Set(value As Date)
                mLastUpdate = value
            End Set
        End Property

        Public Property LastUpdateBy As Long Implements ISiteORAPRPay.LastUpdateBy
            Get
                Return mLastUpdateBy
            End Get
            Set(value As Long)
                mLastUpdateBy = value
            End Set
        End Property

        Public Property PostBy As Long Implements ISiteORAPRPay.PostBy
            Get
                Return mPostBy
            End Get
            Set(value As Long)
                mPostBy = value
            End Set
        End Property

        Public Property PostDate As Date Implements ISiteORAPRPay.PostDate
            Get
                Return mPostDate
            End Get
            Set(value As Date)
                mPostDate = value
            End Set
        End Property

        Public Property StatusId As Integer Implements ISiteORAPRPay.StatusId
            Get
                Return mStatusId
            End Get
            Set(value As Integer)
                mStatusId = value
            End Set
        End Property

        Public Property ORNmbr() As Long Implements ISiteORAPRPay.ORNmbr
            Get
                Return mORNmbr
            End Get
            Set(value As Long)
                mORNmbr = value
            End Set
        End Property

        Public Property APRNmbr() As Long Implements ISiteORAPRPay.APRNmbr
            Get
                Return mAPRNmbr
            End Get
            Set(value As Long)
                mAPRNmbr = value
            End Set
        End Property

        Public Property APRDate() As Date Implements ISiteORAPRPay.APRDate
            Get
                Return mAPRDate
            End Get
            Set(value As Date)
                mAPRDate = value
            End Set
        End Property

        Public Property Amount() As Decimal Implements ISiteORAPRPay.Amount
            Get
                Return mAmount
            End Get
            Set(value As Decimal)
                mAmount = value
            End Set
        End Property

        Public Property LineNmbr() As Integer Implements ISiteORAPRPay.LineNmbr
            Get
                Return mLineNmbr
            End Get
            Set(value As Integer)
                mLineNmbr = value
            End Set
        End Property

#End Region

#Region "Constructor"

        Sub New()

        End Sub

        Sub New(ByVal pId As Long, ByVal pORNmbr As Long, ByVal pAPRNmbr As Long, ByVal pAPRDate As Date,
                ByVal pAmount As Decimal, ByVal pLineNmbr As Integer, ByVal pStatusId As Integer, ByVal pPostBy As Long,
                ByVal pPostDate As Date, ByVal pLastUpdateBy As Long, ByVal pLastUpdate As Date)
            Id = pId
            ORNmbr = pORNmbr
            APRNmbr = pAPRNmbr
            APRDate = pAPRDate
            Amount = pAmount
            LineNmbr = pLineNmbr
            StatusId = pStatusId
            LineNmbr = pLineNmbr
            PostBy = pPostBy
            PostDate = pPostDate
            LastUpdateBy = pLastUpdateBy
            LastUpdate = pLastUpdate
        End Sub

#End Region

#Region "Single Point Functions"

#End Region

#Region "Validations"

#End Region

#Region "Data Retrieval"

        Public Sub GetORAPRPay(ByVal pDocNumber As Long, ByVal pUserId As Long)
            Dim objDal As New dalWorking.DSiteORAPRPay
            Dim drLocal As OracleDataReader

            Try
                drLocal = objDal.GetSiteORAPRPay(pDocNumber, pUserId)

                With drLocal
                    While .Read
                        Id = cDataType.fLong.IfNull(.Item("id"))
                        ORNmbr = cDataType.fLong.IfNull(.Item("or_nmbr"))
                        APRNmbr = cDataType.fLong.IfNull(.Item("apr_nmbr"))
                        APRDate = cDataType.fDate.IfNull(.Item("apr_date"))
                        Amount = cDataType.fDecimal.IfNull(.Item("amount"))
                        LineNmbr = cDataType.fInteger.IfNull(.Item("line_nmbr"))
                        StatusId = cDataType.fLong.IfNull(.Item("status_id"))
                        PostBy = cDataType.fString.IfNull(.Item("post_by"))
                        PostDate = cDataType.fDate.IfNull(.Item("post_date"))
                        LastUpdateBy = cDataType.fString.IfNull(.Item("last_update_by"))
                        LastUpdate = cDataType.fDate.IfNull(.Item("last_update"))
                    End While
                End With

            Catch ex As Exception
                Throw
            End Try
        End Sub


#End Region

#Region "Transactions"

        Public Function Alter(ByVal pAction As String, ByRef pConn As Object, ByRef pTrans As Object) As Long

            Try
                Dim objDAL As New dalWorking.DSiteORAPRPay
                objDAL.AlterSiteORAPRPay(Me, pAction, pConn, pTrans)
                Return objDAL.Reference
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace
