#Region "Description"
' PAGE NAME     : AGNAMS BLL
' CREATED BY    : MPRO
' CREATED DATE  : 04/30/2013
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

    Public Class BAgnMas

#Region "Implements"
        Implements Person.IAgnMas
#End Region

#Region "Variables"
        Private mAgnPrs As Long = cDataType.fLong.Empty
        Private mAgnCon As String = cDataType.fString.Empty
        Private mAgnBrn As Long = cDataType.fLong.Empty
        Private mAgnOvr As Long = cDataType.fLong.Empty
        Private mAgnLoc As String = cDataType.fString.Empty
        Private mAgnDat As date = cDataType.fDate.Empty
        Private mAgnEnd As date = cDataType.fDate.Empty
        Private mCatCod As String = cDataType.fString.Empty
        ' ------------------------------------------------------------------------------- 
        Private mIsRecordExist As Boolean = False
#End Region

#Region "Properties"

        Public Property AgnPrs() As Long Implements Person.IAgnMas.AgnPrs
            Get
                Return mAgnPrs
            End Get
            Set(ByVal value As Long)
                mAgnPrs = value
            End Set
        End Property

        Public Property AgnCon() As String Implements Person.IAgnMas.AgnCon
            Get
                Return mAgnCon
            End Get
            Set(ByVal value As String)
                mAgnCon = value
            End Set
        End Property

        Public Property AgnBrn() As Long Implements Person.IAgnMas.AgnBrn
            Get
                Return mAgnBrn
            End Get
            Set(ByVal value As Long)
                mAgnBrn = value
            End Set
        End Property

        Public Property AgnOvr() As Long Implements Person.IAgnMas.AgnOvr
            Get
                Return mAgnOvr
            End Get
            Set(ByVal value As Long)
                mAgnOvr = value
            End Set
        End Property

        Public Property AgnLoc() As String Implements Person.IAgnMas.AgnLoc
            Get
                Return mAgnLoc
            End Get
            Set(ByVal value As String)
                mAgnLoc = value
            End Set
        End Property

        Public Property AgnDat() As date Implements Person.IAgnMas.AgnDat
            Get
                Return mAgnDat
            End Get
            Set(ByVal value As date)
                mAgnDat = value
            End Set
        End Property

        Public Property AgnEnd() As date Implements Person.IAgnMas.AgnEnd
            Get
                Return mAgnEnd
            End Get
            Set(ByVal value As date)
                mAgnEnd = value
            End Set
        End Property

        Public Property CatCod() As String Implements Person.IAgnMas.CatCod
            Get
                Return mCatCod
            End Get
            Set(ByVal value As String)
                mCatCod = value
            End Set
        End Property

        ' ------------------------------------------------------------------------------- 

        Public Property IsRecordExist() As Boolean Implements Person.IAgnMas.IsRecordExist
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

#End Region

#Region "Single Point Functions"
        Public Function GetAgentInfo(ByVal pAgnPrs As Long, ByVal pDate As Date, ByVal pCol As Integer) As String Implements Person.IAgnMas.GetAgentInfo

            Dim objDal As New dalPerson.DAgnMas
            Dim strInfo As String = cDataType.fString.Empty

            Try
                strInfo = objDal.GetAgentInfo(pAgnPrs, pDate, pCol)
                Return strInfo
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetAgentSalesForce(ByVal pAgentCode As Long, ByVal pDate As Date) As String Implements Person.IAgnMas.GetAgentSalesForce

            Dim objDal As New dalPerson.DAgnMas
            Dim strSalesForce As String = cDataType.fString.Empty

            Try
                strSalesForce = objDal.GetAgentSalesForce(pAgentCode, pDate)
                Return strSalesForce
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetAgentGpaCommRate(ByVal pAgentCode As Long, ByVal pDate As Date) As Decimal Implements Person.IAgnMas.GetAgentCommRate

            Dim objDal As New dalPerson.DAgnMas
            Dim decCommRate As Decimal

            Try
                decCommRate = objDal.GetAgentGpaCommRate(pAgentCode, pDate)
                Return decCommRate
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetAgentTaxRate(ByVal pAcctgPd As Long, ByVal pAgentCode As Long) As Decimal Implements Person.IAgnMas.GetAgentTaxRate

            Dim objDal As New dalPerson.DAgnMas
            Dim decTaxRate As Decimal

            Try
                decTaxRate = objDal.GetAgentTaxRate(pAcctgPd, pAgentCode)
                Return decTaxRate
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetAgencyFund(ByVal pAgtPrsPID As Long) As Long Implements Person.IAgnMas.GetAgencyFund

            Dim objDAL As New dalPerson.DAgnMas
            Dim lngPrsPID As Long = 0

            Try
                lngPrsPID = objDAL.GetAgencyFund(pAgtPrsPID)
                Return lngPrsPID
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Function GetAgentOR(ByVal pAgentCode As Long) As Boolean Implements Person.IAgnMas.GetAgentOR

            Dim objDAL As New dalPerson.DAgnMas
            Dim blnReturn As Boolean

            Try
                blnReturn = objDAL.GetAgentOR(pAgentCode)
                Return blnReturn
            Catch ex As Exception
                Throw
            End Try

        End Function

        Public Sub GetAgnMas(ByVal pAgnPrs As Long) Implements Person.IAgnMas.GetAgnMas

            Dim objDAL As New dalPerson.DAgnMas
            Dim drLocal As OracleDataReader

            Try

                IsRecordExist = False
                drLocal = objDAL.GetAgnMas(pAgnPrs)
                With drLocal
                    While .Read
                        AgnPrs = cDataType.fLong.IfNull(.Item("agnprs"))
                        AgnCon = cDataType.fString.IfNull(.Item("agncon"))
                        AgnBrn = cDataType.fLong.IfNull(.Item("agnbrn"))
                        AgnOvr = cDataType.fLong.IfNull(.Item("agnovr"))
                        AgnLoc = cDataType.fString.IfNull(.Item("agnloc"))
                        AgnDat = cDataType.fDate.IfNull(.Item("agndat"))
                        AgnEnd = cDataType.fDate.IfNull(.Item("agnend"))
                        CatCod = cDataType.fString.IfNull(.Item("catcod"))
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

        Public Function SearchAgnMas(ByVal pAgnPrs As Long, ByVal pAgnNme As String, ByVal pAgnEnd As Date, ByVal pPolType As String) As DataTable Implements Person.IAgnMas.SearchAgnMas

            Dim objDAL As New dalPerson.DAgnMas
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.SearchAgnMas(pAgnPrs, pAgnNme, pAgnEnd, pPolType)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try

        End Function

        ' ------------------------------------------------------------------------------- 

        Public Function ValidateAgent(ByVal pAgnPrs As Long, ByVal pUwDate As Date) As DataTable Implements Person.IAgnMas.ValidateAgent

            Dim objDAL As New dalPerson.DAgnMas
            Dim dtLocal As DataTable

            Try
                dtLocal = objDAL.ValidateAgent(pAgnPrs, pUwDate)
                Return dtLocal
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

#Region "Transactions"

        Public Function InsertAgnMas(ByVal pList As IList(Of Person.BAgnMas), ByRef pConn As Object, ByRef pTrans As Object) As String Implements Person.IAgnMas.InsertAgnMas

            Dim objDal As New dalPerson.DAgnMas
            Dim strItem As String = String.Empty

            Try
                strItem = objDal.AlterAgnMas(pList, "INSERT", pConn, pTrans)
                Return strItem
            Catch ex As Exception
                Throw
            End Try

        End Function

        ' ------------------------------------------------------------------------------- 

        Public Function UpdateAgnMas(ByVal pList As IList(Of Person.BAgnMas), ByRef pConn As Object, ByRef pTrans As Object) As String Implements Person.IAgnMas.UpdateAgnMas

            Dim objDal As New dalPerson.DAgnMas
            Dim strItem As String = String.Empty

            Try
                strItem = objDal.AlterAgnMas(pList, "UPDATE", pConn, pTrans)
                Return strItem
            Catch ex As Exception
                Throw
            End Try

        End Function

#End Region

    End Class

End Namespace


