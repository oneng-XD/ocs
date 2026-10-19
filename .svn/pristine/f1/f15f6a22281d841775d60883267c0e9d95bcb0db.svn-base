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
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
Imports cDataType = Cocolife.Utility.Common.DataType
Imports eDBAction = Cocolife.Utility.Common.Enums.eDBAction
Imports dalConstant = Cocolife.DAL.OCS.DConstant
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
#End Region

Namespace Reference

    Public Class DSalesInvoice

#Region "Variables"
        Private mReference As Object = Nothing
#End Region

#Region "Properties"
        Property Reference As Object
            Get
                Return mReference
            End Get
            Set(value As Object)
                mReference = value
            End Set
        End Property
#End Region

#Region "Single Point Functions"

#End Region

#Region "Data Retrieval"

        Public Function SearchSalesInvoice(ByVal pReferenceNo As String, ByVal pPolicyNo As String) As DataTable

            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            If String.IsNullOrEmpty(apiUsername) OrElse String.IsNullOrEmpty(apiPassword) OrElse String.IsNullOrEmpty(apiGrantType) Then
                Throw New ConfigurationErrorsException("Required NEWGEN API settings are missing from Web.config.")
            End If

            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSalesInvoice)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value = pReferenceNo
                        .Add(New OracleParameter("pPolicyNo", OracleType.VarChar)).Value = pPolicyNo
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value = apiUsername
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = apiPassword
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = apiGrantType
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchSalesInvoice")
                End With

                Return ds.Tables("dtSearchSalesInvoice")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function SearchSalesInvoiceByNo(ByVal pInvoiceNo As String) As DataTable
            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSalesInvoice)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value = ""
                        .Add(New OracleParameter("pInvoiceNo", OracleType.Number)).Value = pInvoiceNo
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value = apiUsername
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = apiPassword
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = apiGrantType
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchSalesInvoice")
                End With

                Return ds.Tables("dtSearchSalesInvoice")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function
        'added by junie search exclusive for DMCM
        Public Function SearchSalesInvoiceDMCM(ByVal pInvoiceNo As String, ByVal pRoleCode As String, pSiteCode As Long, pUserID As Long) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSalesInvoiceDMCM)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pRoleCode", OracleType.VarChar)).Value = pRoleCode
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                        .Add(New OracleParameter("pInvoiceNo", OracleType.Number)).Value = pInvoiceNo
                        .Add(New OracleParameter("pUserID", OracleType.Number)).Value = pUserID
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchSalesInvoice")
                End With

                Return ds.Tables("dtSearchSalesInvoice")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function SearchHMOSalesInvoice(
       ByVal pReferenceNo As String,
       ByVal pPolicyNo As String,
       ByVal pInvoiceNo As String
   ) As DataTable

            Dim dtResult As New DataTable()
            Dim strConnection As String =
                ConfigurationManager.ConnectionStrings(
                    "HMOConnection"
                ).ConnectionString

            Using objConnection As New System.Data.SqlClient.SqlConnection(
                strConnection
            )
                Using objCommand As New System.Data.SqlClient.SqlCommand(
                    "dbo.SP_NG_SEARCH_SSO_SI",
                    objConnection
                )
                    objCommand.CommandType = CommandType.StoredProcedure
                    objCommand.CommandTimeout = 60

                    objCommand.Parameters.Add(
                        "@pReferenceNo",
                        SqlDbType.VarChar,
                        50
                    ).Value = If(
                        pReferenceNo Is Nothing,
                        String.Empty,
                        pReferenceNo
                    )

                    objCommand.Parameters.Add(
                        "@pPolicyNo",
                        SqlDbType.VarChar,
                        50
                    ).Value = If(
                        pPolicyNo Is Nothing,
                        String.Empty,
                        pPolicyNo
                    )

                    objCommand.Parameters.Add(
                        "@pInvoiceNo",
                        SqlDbType.VarChar,
                        50
                    ).Value = If(
                        pInvoiceNo Is Nothing,
                        String.Empty,
                        pInvoiceNo
                    )

                    Using objAdapter As New System.Data.SqlClient.SqlDataAdapter(
                        objCommand
                    )
                        objAdapter.Fill(dtResult)
                    End Using
                End Using
            End Using

            Return dtResult
        End Function

        Public Function SearchHMOSIDetails(
            ByVal pReferenceNo As String
        ) As DataTable

            Dim dtResult As New DataTable()
            Dim strConnection As String =
                ConfigurationManager.ConnectionStrings(
                    "HMOConnection"
                ).ConnectionString

            Using objConnection As New System.Data.SqlClient.SqlConnection(
                strConnection
            )
                Using objCommand As New System.Data.SqlClient.SqlCommand(
                    "dbo.SP_NG_SEARCH_SSO_SI_DETAILS",
                    objConnection
                )
                    objCommand.CommandType = CommandType.StoredProcedure
                    objCommand.CommandTimeout = 60

                    objCommand.Parameters.Add(
                        "@pReferenceNo",
                        SqlDbType.VarChar,
                        50
                    ).Value = If(
                        pReferenceNo Is Nothing,
                        String.Empty,
                        pReferenceNo
                    )

                    Using objAdapter As New System.Data.SqlClient.SqlDataAdapter(
                        objCommand
                    )
                        objAdapter.Fill(dtResult)
                    End Using
                End Using
            End Using

            Return dtResult
        End Function

        'Use this inside BSalesInvoice.SearchSalesInvoiceByNo after mapping the row:
        '
        'If SISourceType = "HMO" Then
        '    dtSIDetails = objDal.SearchHMOSIDetails(ReferenceNo)
        'Else
        '    dtSIDetails = objDal.SearchSIDetails(ReferenceNo)
        'End If


        'Use this inside BSalesInvoice.SearchSalesInvoiceByNo after mapping the row:
        '
        'If SISourceType = "HMO" Then
        '    dtSIDetails = objDal.SearchHMOSIDetails(ReferenceNo)
        'Else
        '    dtSIDetails = objDal.SearchSIDetails(ReferenceNo)
        'End If

        Public Function SearchSIDetails(ByVal pReferenceNo As String) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIDetails)
            Dim oraDA As OracleDataAdapter = Nothing
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value = pReferenceNo
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtSearchSIDetails")
                End With

                Return ds.Tables("dtSearchSIDetails")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try

        End Function

        Public Function GetDocList(ByVal pSiteCode As Long, ByVal pDocNumber As Long) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIList)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.Number)).Value = pDocNumber
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = 0
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewDoc")

                End With
                Return ds.Tables("dtViewDoc")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

      

        Public Function GetDocList(ByVal pSiteCode As Long, ByVal pParam As Integer, ByVal pStartDate As Date?, ByVal pEndDate As Date?) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIList)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = pStartDate
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = pEndDate
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.VarChar)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = pParam
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewDoc")

                End With
                Return ds.Tables("dtViewDoc")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetDocList(ByVal pSiteCode As Long, ByVal pReferenceNo As String) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIList)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = Nothing
                    '.Parameters.Add(New OracleParameter("pStringParam", OracleType.Number)).Value = pReferenceNo
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.VarChar)).Value = pReferenceNo
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = 1
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewDoc")

                End With
                Return ds.Tables("dtViewDoc")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

        Public Function GetDocList(ByVal pSiteCode As Long, ByVal pInvoiceNo As Long, ByVal pType As Integer) As DataTable
            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIList)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet
            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    .Parameters.Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = Nothing
                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.Number)).Value = pInvoiceNo
                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = pType
                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewDoc")

                End With
                Return ds.Tables("dtViewDoc")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function
        '---
        Public Function GetDocListDMCM( _
    ByVal pRoleCode As String, _
    ByVal pParam As Long, _
    ByVal pReferenceNo As String, _
    ByVal pType As Integer) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIListDMCM)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection

                    If bllConn.Instance.Transaction IsNot Nothing Then
                        .Transaction = bllConn.Instance.Transaction
                    End If

                    .Parameters.Add(New OracleParameter("pRoleCode", OracleType.VarChar)).Value = pRoleCode
                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = DBNull.Value
                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = DBNull.Value

                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.VarChar)).Value =
                        pParam.ToString()

                    .Parameters.Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value =
                        If(String.IsNullOrEmpty(pReferenceNo),
                           CType(DBNull.Value, Object),
                           pReferenceNo)

                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = pType

                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction =
                        ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewDoc")
                End With

                Return ds.Tables("dtViewDoc")

            Finally
                oraCmd.Dispose()
            End Try
        End Function
        Public Function GetDocListDMCM( _
    ByVal pRoleCode As String, _
    ByVal pStartDate As Date?, _
    ByVal pEndDate As Date?) As DataTable

            Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIListDMCM)
            Dim oraDA As OracleDataAdapter
            Dim ds As New DataSet

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection

                    If bllConn.Instance.Transaction IsNot Nothing Then
                        .Transaction = bllConn.Instance.Transaction
                    End If

                    .Parameters.Add(New OracleParameter("pRoleCode", OracleType.VarChar)).Value = pRoleCode

                    .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value =
                        If(pStartDate.HasValue,
                           CType(pStartDate.Value, Object),
                           DBNull.Value)

                    .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value =
                        If(pEndDate.HasValue,
                           CType(pEndDate.Value, Object),
                           DBNull.Value)

                    .Parameters.Add(New OracleParameter("pStringParam", OracleType.VarChar)).Value =
                        DBNull.Value

                    .Parameters.Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value =
                        DBNull.Value

                    .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = 0

                    .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction =
                        ParameterDirection.Output

                    oraDA = New OracleDataAdapter(oraCmd)
                    oraDA.Fill(ds, "dtViewDoc")
                End With

                Return ds.Tables("dtViewDoc")

            Finally
                oraCmd.Dispose()
            End Try
        End Function
        'Public Function GetDocListDMCM(ByVal pRoleCode As String, ByVal pParam As Long, ByVal pReferenceNo As String, ByVal pType As Integer) As DataTable
        '    Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIListDMCM)
        '    Dim oraDA As OracleDataAdapter
        '    Dim ds As New DataSet
        '    Try
        '        With oraCmd
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = bllConn.Instance.Connection
        '            If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

        '            .Parameters.Add(New OracleParameter("pRoleCode", OracleType.VarChar)).Value = pRoleCode
        '            .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = Nothing
        '            .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = Nothing
        '            .Parameters.Add(New OracleParameter("pStringParam", OracleType.Number)).Value = pParam
        '            .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = pType
        '            .Parameters.Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value = pReferenceNo
        '            .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

        '            oraDA = New OracleDataAdapter(oraCmd)
        '            oraDA.Fill(ds, "dtViewDoc")

        '        End With
        '        Return ds.Tables("dtViewDoc")

        '    Catch ex As Exception
        '        Throw
        '    Finally
        '        oraCmd.Dispose()
        '    End Try
        'End Function
     
        'Public Function GetDocListDMCM(ByVal pRoleCode As String, ByVal pStartDate As Date?, ByVal pEndDate As Date?) As DataTable
        '    Dim oraCmd As New OracleCommand(dalConstant._spSSOGetSIListDMCM)
        '    Dim oraDA As OracleDataAdapter
        '    Dim ds As New DataSet
        '    Try
        '        With oraCmd
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = bllConn.Instance.Connection
        '            If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

        '            .Parameters.Add(New OracleParameter("pRoleCode", OracleType.VarChar)).Value = pRoleCode
        '            .Parameters.Add(New OracleParameter("pStartDate", OracleType.DateTime)).Value = pStartDate
        '            .Parameters.Add(New OracleParameter("pEndDate", OracleType.DateTime)).Value = pEndDate
        '            .Parameters.Add(New OracleParameter("pStringParam", OracleType.VarChar)).Value = Nothing
        '            .Parameters.Add(New OracleParameter("pParamType", OracleType.Number)).Value = 0
        '            .Parameters.Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output

        '            oraDA = New OracleDataAdapter(oraCmd)
        '            oraDA.Fill(ds, "dtViewDoc")

        '        End With
        '        Return ds.Tables("dtViewDoc")

        '    Catch ex As Exception
        '        Throw
        '    Finally
        '        oraCmd.Dispose()
        '    End Try
        'End Function

#End Region

#Region "Transactions"
        Public Sub Alter(ByVal pPrintStatus As String, ByVal pReferenceNo As String, ByVal pInvoiceNumber As Long, ByVal pInvoiceDate As Date, ByVal pRemarks As String, ByVal pOtherInfo As String, ByVal pUserID As String, ByVal pSiteCode As Long, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            'If String.IsNullOrEmpty(apiUsername) OrElse String.IsNullOrEmpty(apiPassword) OrElse String.IsNullOrEmpty(apiGrantType) Then
            '    Throw New ConfigurationErrorsException("Required NEWGEN API settings are missing from Web.config.")
            'End If

            Dim oraCmd As New OracleCommand(DConstant._spOCSProcessSI)
            Dim oraDR As OracleDataReader = Nothing

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pPrintStatus", OracleType.VarChar)).Value = pPrintStatus              ' 1
                        .Add(New OracleParameter("pReferenceNo", OracleType.VarChar)).Value = pReferenceNo              ' 2
                        .Add(New OracleParameter("pInvoiceNumber", OracleType.Number)).Value = pInvoiceNumber           ' 3
                        .Add(New OracleParameter("pInvoiceDate", OracleType.DateTime)).Value = pInvoiceDate             ' 4
                        .Add(New OracleParameter("pRemarks", OracleType.VarChar)).Value = pRemarks                      ' 5
                        .Add(New OracleParameter("pOtherInfo", OracleType.VarChar)).Value = pOtherInfo                  ' 6
                        .Add(New OracleParameter("pUserID", OracleType.VarChar)).Value = pUserID                        ' 7
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode                     ' 8
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output     ' 9
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value = If(String.IsNullOrEmpty(apiUsername), CType(DBNull.Value, Object),apiUsername)                                                          ' 10
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = If(String.IsNullOrEmpty(apiPassword), CType(DBNull.Value, Object), apiPassword)                                                          ' 11
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = If(String.IsNullOrEmpty(apiGrantType), CType(DBNull.Value, Object), apiGrantType)
                    End With

                    oraDR = .ExecuteReader
                    With oraDR
                        Reference = 0
                        While .Read
                            If eDBAction.isSuccessful(.Item("message")) Then
                                Reference = cDataType.fString.getReference(.Item("message"))
                            Else
                                Throw New Exception(.Item("message"))
                            End If
                        End While
                    End With

                End With

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
                If Not IsNothing(oraDR) Then
                    oraDR.Dispose()
                End If
            End Try

        End Sub
        Public Sub SaveNewgenSalesInvoice(ByVal pObject As Object, ByVal pUserID As String, ByVal pSiteCode As Long, ByRef pOraConn As OracleConnection, ByRef pOraTrans As OracleTransaction)

            Dim apiUsername As String = ConfigurationManager.AppSettings("NewgenApiUsername")
            Dim apiPassword As String = ConfigurationManager.AppSettings("NewgenApiPassword")
            Dim apiGrantType As String = ConfigurationManager.AppSettings("NewgenApiGrantType")

            'If String.IsNullOrEmpty(apiUsername) OrElse String.IsNullOrEmpty(apiPassword) OrElse String.IsNullOrEmpty(apiGrantType) Then
            '    Throw New ConfigurationErrorsException("Required NEWGEN API settings are missing from Web.config.")
            'End If

            Dim oraCmd As New OracleCommand(dalConstant._spSaveNGSI)
            Dim oraDR As OracleDataReader = Nothing

            Try
                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = pOraConn
                    .Transaction = pOraTrans

                    With .Parameters
                        .Add(New OracleParameter("pBILLNO", OracleType.VarChar)).Value = pObject.ReferenceNo
                        .Add(New OracleParameter("pPOLICYNUMBER", OracleType.VarChar)).Value = pObject.PolicyNumber
                        .Add(New OracleParameter("pPAYOR", OracleType.VarChar)).Value = pObject.PayorName
                        .Add(New OracleParameter("pADDRESS", OracleType.VarChar)).Value = pObject.PayorAddress
                        .Add(New OracleParameter("pTIN", OracleType.VarChar)).Value = pObject.PayorTIN
                        .Add(New OracleParameter("pINSUREDCLIENTNAME", OracleType.VarChar)).Value = pObject.InsuredClientName
                        .Add(New OracleParameter("pCOVERAGEPERIODFROM", OracleType.VarChar)).Value = Format(pObject.CoveragePeriodFrom, "yyyy-MM-dd")
                        .Add(New OracleParameter("pCOVERAGEPERIODTO", OracleType.VarChar)).Value = Format(pObject.CoveragePeriodTo, "yyyy-MM-dd")
                        .Add(New OracleParameter("pCURRENCY", OracleType.VarChar)).Value = pObject.InvoiceCurrency
                        .Add(New OracleParameter("pTOTALAMOUNT", OracleType.VarChar)).Value = pObject.InvoiceAmount
                        .Add(New OracleParameter("pTOTALSALES", OracleType.VarChar)).Value = pObject.TotalSales
                        .Add(New OracleParameter("pVATABLE", OracleType.VarChar)).Value = pObject.VATable
                        .Add(New OracleParameter("pVATEXEMPT", OracleType.VarChar)).Value = pObject.VATExempt
                        .Add(New OracleParameter("pVATAMOUNT", OracleType.VarChar)).Value = pObject.VATAmount
                        .Add(New OracleParameter("pNONVAT", OracleType.VarChar)).Value = pObject.NonVAT
                        .Add(New OracleParameter("pWITHOLDINGTAX", OracleType.VarChar)).Value = pObject.WitholdingTax
                        .Add(New OracleParameter("pNETWITHHOLDINGTAX", OracleType.VarChar)).Value = pObject.NetOfWitholdingTax
                        .Add(New OracleParameter("pDISCOUNT", OracleType.VarChar)).Value = pObject.Discount
                        .Add(New OracleParameter("pDISCOUNTIDNO", OracleType.VarChar)).Value = pObject.DiscountIdNo
                        .Add(New OracleParameter("pPAYMENTTERM", OracleType.VarChar)).Value = pObject.PaymentTerm
                        .Add(New OracleParameter("pREMARKS", OracleType.VarChar)).Value = pObject.InvoiceRemarks
                        .Add(New OracleParameter("pOTHERINFO", OracleType.VarChar)).Value = pObject.InvoiceOtherInfo
                        .Add(New OracleParameter("pSALESINVOICENO", OracleType.VarChar)).Value = pObject.InvoiceNumber
                        .Add(New OracleParameter("pSALESINVOICEDATE", OracleType.VarChar)).Value = Format(pObject.InvoiceDate, "MM/dd/yyyy")
                        .Add(New OracleParameter("pSIPRINTSTATUS", OracleType.VarChar)).Value = "READY"
                        .Add(New OracleParameter("pPARTICULARSJSON", OracleType.Clob)).Value = pObject.ParticularsRaw
                        .Add(New OracleParameter("pUSERID", OracleType.VarChar)).Value = pUserID
                        .Add(New OracleParameter("pSITECODE", OracleType.VarChar)).Value = pSiteCode
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                        .Add(New OracleParameter("pAPIUsername", OracleType.VarChar)).Value = apiUsername
                        .Add(New OracleParameter("pAPIPassword", OracleType.VarChar)).Value = apiPassword
                        .Add(New OracleParameter("pAPIGrantType", OracleType.VarChar)).Value = apiGrantType
                    End With

                    oraDR = .ExecuteReader()

                    While oraDR.Read()
                        If eDBAction.isSuccessful(oraDR.Item("message")) Then
                            Reference = cDataType.fString.getReference(oraDR.Item("message"))
                        Else
                            Throw New Exception(oraDR.Item("message").ToString())
                        End If
                    End While
                End With
            Finally
                oraCmd.Dispose()
                If oraDR IsNot Nothing Then oraDR.Dispose()
            End Try
        End Sub
#End Region

    End Class

End Namespace

