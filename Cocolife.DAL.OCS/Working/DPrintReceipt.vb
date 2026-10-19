#Region "Description"
' PAGE NAME     : SITE_OPRDTL DAL
' CREATED BY    : EJ 
' CREATED DATE  : 07/15/2016
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
Imports dConstant = Cocolife.DAL.OCS.DConstant
Imports System.Data.SqlClient
Imports System.Data.OleDb

#End Region

Namespace Working

    Public Class DPrintReceipt

#Region "Variables"
        Private mReference As Object = Nothing
#End Region

#Region "Property"

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

        Public Function LoadPremReceipt(ByVal pSiteCode As Long, ByVal pDocNumber As Long, ByVal pUserId As Long) As DataTable
            Dim oraCmd As New OracleCommand(DConstant._spOCSRptReceipt)
            Dim OraDA As OracleDataAdapter
            Dim ds As New DataSet

            Try

                With oraCmd
                    .CommandType = CommandType.StoredProcedure
                    .Connection = bllConn.Instance.Connection
                    If bllConn.Instance.Transaction IsNot Nothing Then .Transaction = bllConn.Instance.Transaction

                    With .Parameters
                        .Add(New OracleParameter("pSiteCode", OracleType.Number)).Value = pSiteCode
                        .Add(New OracleParameter("pDocNumber", OracleType.Number)).Value = pDocNumber
                        .Add(New OracleParameter("pUserId", OracleType.Number)).Value = pUserId
                        .Add(New OracleParameter("rsOut", OracleType.Cursor)).Direction = ParameterDirection.Output
                    End With

                    OraDA = New OracleDataAdapter(oraCmd)
                    OraDA.Fill(ds, "dtRptReceipt")

                End With
                Return ds.Tables("dtRptReceipt")

            Catch ex As Exception
                Throw
            Finally
                oraCmd.Dispose()
            End Try
        End Function

#End Region

#Region "Transactions"


        Public Sub WriteReceipt(ByVal pData As DataTable, ByVal pConnStr As String)

            For Each dr In pData.Rows

                Dim query As String = String.Empty
                query &= "INSERT INTO tmporprt4 (site_addr, site_addr1, tel_nos, tin_no, bir_permitno, doc_nmbr, chk_digit, doc_date, payor, insured, pol_nmbr, issue_date, pmode_desc, due_date, agt_code, agt_name, total_amt, cash_amt, chk_amt, apr_nmbr, apr_date, agt_acct, acct_code, detail1, dtl_amt1, detail2, dtl_amt2, detail3, dtl_amt3, detail4, dtl_amt4, detail5, dtl_amt5, curr_type, cashier, gl_acct, remarks, appl_no, chkno1, bank1, branch1, chkno2, bank2, branch2, card_no, card_type, vatable_coll, vateexempt_coll, vat_amount, wtax_amt, net_amt)"
                query &= "VALUES (@site_addr, @site_addr1, @tel_nos, @tin_no, @bir_permitno, @doc_nmbr, @chk_digit, @doc_date, @payor, @insured, @pol_nmbr, @issue_date, @pmode_desc, @due_date, @agt_code, @agt_name, @total_amt, @cash_amt, @chk_amt, @apr_nmbr, @apr_date, @agt_acct, @acct_code, @detail1, @dtl_amt1, @detail2, @dtl_amt2, @detail3, @dtl_amt3, @detail4, @dtl_amt4, @detail5, @dtl_amt5, @curr_type, @cashier, @gl_acct, @remarks, @appl_no, @chkno1, @bank1, @branch1, @chkno2, @bank2, @branch2, @card_no, @card_type, @vatable_coll, @vateexempt_coll, @vat_amount, @wtax_amt, @net_amt)"

                Using conn As New OleDbConnection(pConnStr)
                    Using comm As New OleDbCommand()
                        With comm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = query
                            .Parameters.AddWithValue("@site_addr", cDataType.fString.IfNull(dr.item("site_addr")))
                            .Parameters.AddWithValue("@site_addr1", cDataType.fString.IfNull(dr.item("site_addr1")))
                            .Parameters.AddWithValue("@tel_nos", cDataType.fString.IfNull(dr.item("tel_nos")))
                            .Parameters.AddWithValue("@tin_no", cDataType.fString.IfNull(dr.item("tin_no")))
                            .Parameters.AddWithValue("@bir_permitno", cDataType.fString.IfNull(dr.item("bir_permitno")))
                            .Parameters.AddWithValue("@doc_nmbr", cDataType.fLong.IfNull(dr.item("doc_nmbr")))
                            .Parameters.AddWithValue("@chk_digit", cDataType.fLong.IfNull(dr.item("chk_digit")))
                            .Parameters.AddWithValue("@doc_date", cDataType.fDate.IfNull(dr.item("doc_date")))
                            .Parameters.AddWithValue("@payor", cDataType.fString.IfNull(dr.item("payor")))
                            .Parameters.AddWithValue("@insured", cDataType.fString.IfNull(dr.item("insured")))
                            .Parameters.AddWithValue("@pol_nmbr", cDataType.fString.IfNull(dr.item("pol_nmbr")))
                            .Parameters.AddWithValue("@issue_date", cDataType.fString.IfNull(dr.item("issue_date")))
                            .Parameters.AddWithValue("@pmode_desc", cDataType.fString.IfNull(dr.item("pmode_desc")))
                            .Parameters.AddWithValue("@due_date", cDataType.fString.IfNull(dr.item("due_date")))
                            .Parameters.AddWithValue("@agt_code", cDataType.fLong.IfNull(dr.item("agt_code")))
                            .Parameters.AddWithValue("@agt_name", cDataType.fString.IfNull(dr.item("agt_name")))
                            .Parameters.AddWithValue("@total_amt", cDataType.fDecimal.IfNull(dr.item("total_amt")))
                            .Parameters.AddWithValue("@cash_amt", cDataType.fDecimal.IfNull(dr.item("cash_amt")))
                            .Parameters.AddWithValue("@chk_amt", cDataType.fDecimal.IfNull(dr.item("chk_amt")))
                            .Parameters.AddWithValue("@apr_nmbr", cDataType.fLong.IfNull(dr.item("apr_nmbr")))
                            .Parameters.AddWithValue("@apr_date", cDataType.fString.IfNull(dr.item("apr_date")))
                            .Parameters.AddWithValue("@agt_acct", cDataType.fDecimal.IfNull(dr.item("agt_acct")))
                            .Parameters.AddWithValue("@acct_code", cDataType.fLong.IfNull(dr.item("acct_code")))
                            .Parameters.AddWithValue("@detail1", cDataType.fString.IfNull(dr.item("detail1")))
                            .Parameters.AddWithValue("@dtl_amt1", cDataType.fDecimal.IfNull(dr.item("dtl_amt1")))
                            .Parameters.AddWithValue("@detail2", cDataType.fString.IfNull(dr.item("detail2")))
                            .Parameters.AddWithValue("@dtl_amt2", cDataType.fDecimal.IfNull(dr.item("dtl_amt2")))
                            .Parameters.AddWithValue("@detail3", cDataType.fString.IfNull(dr.item("detail3")))
                            .Parameters.AddWithValue("@dtl_amt3", cDataType.fDecimal.IfNull(dr.item("dtl_amt3")))
                            .Parameters.AddWithValue("@detail4", cDataType.fString.IfNull(dr.item("detail4")))
                            .Parameters.AddWithValue("@dtl_amt4", cDataType.fDecimal.IfNull(dr.item("dtl_amt4")))
                            .Parameters.AddWithValue("@detail5", cDataType.fString.IfNull(dr.item("detail5")))
                            .Parameters.AddWithValue("@dtl_amt5", cDataType.fDecimal.IfNull(dr.item("dtl_amt5")))
                            .Parameters.AddWithValue("@curr_type", cDataType.fString.IfNull(dr.item("curr_type")))
                            .Parameters.AddWithValue("@cashier", cDataType.fString.IfNull(dr.item("cashier")))
                            .Parameters.AddWithValue("@gl_acct", cDataType.fString.IfNull(dr.item("gl_acct")))
                            .Parameters.AddWithValue("@remarks", cDataType.fString.IfNull(dr.item("remarks")))
                            .Parameters.AddWithValue("@appl_no", cDataType.fString.IfNull(dr.item("appl_no")))
                            .Parameters.AddWithValue("@chkno1", cDataType.fString.IfNull(dr.item("chkno1")))
                            .Parameters.AddWithValue("@bank1", cDataType.fString.IfNull(dr.item("bank1")))
                            .Parameters.AddWithValue("@branch1", cDataType.fString.IfNull(dr.item("branch1")))
                            .Parameters.AddWithValue("@chkno2", cDataType.fString.IfNull(dr.item("chkno2")))
                            .Parameters.AddWithValue("@bank2", cDataType.fString.IfNull(dr.item("bank2")))
                            .Parameters.AddWithValue("@branch2", cDataType.fString.IfNull(dr.item("branch2")))
                            .Parameters.AddWithValue("@card_no", cDataType.fString.IfNull(dr.item("card_no")))
                            .Parameters.AddWithValue("@card_type", cDataType.fString.IfNull(dr.item("card_type")))
                            .Parameters.AddWithValue("@vatable_coll", cDataType.fDecimal.IfNull(dr.item("vatable_coll")))
                            .Parameters.AddWithValue("@vateexempt_coll", cDataType.fDecimal.IfNull(dr.item("vateexempt_coll")))
                            .Parameters.AddWithValue("@vat_amount", cDataType.fDecimal.IfNull(dr.item("vat_amount")))
                            .Parameters.AddWithValue("@wtax_amt", cDataType.fDecimal.IfNull(dr.item("wtax_amt")))
                            .Parameters.AddWithValue("@net_amt", cDataType.fDecimal.IfNull(dr.item("net_amt")))

                        End With
                        Try
                            conn.Open()
                            comm.ExecuteNonQuery()
                        Catch ex As OleDbException
                            Throw
                        End Try
                    End Using
                End Using

                'Using conn As New SqlConnection(pConnStr)
                '    Using comm As New SqlCommand()
                '        With comm
                '            .Connection = conn
                '            .CommandType = CommandType.Text
                '            .CommandText = query
                '            .Parameters.AddWithValue("@site_addr", dr.item("site_addr"))
                '            .Parameters.AddWithValue("@site_addr1", dr.item("site_addr1"))
                '            .Parameters.AddWithValue("@tel_nos", dr.item("tel_nos"))
                '            .Parameters.AddWithValue("@tin_no", dr.item("tin_no"))
                '            .Parameters.AddWithValue("@bir_permitno", dr.item("bir_permitno"))
                '            .Parameters.AddWithValue("@doc_nmbr", dr.item("doc_nmbr"))
                '            .Parameters.AddWithValue("@chk_digit", dr.item("chk_digit"))
                '            .Parameters.AddWithValue("@doc_date", dr.item("doc_date"))
                '            .Parameters.AddWithValue("@payor", dr.item("payor"))
                '            .Parameters.AddWithValue("@insured", dr.item("insured"))
                '            .Parameters.AddWithValue("@pol_nmbr", dr.item("pol_nmbr"))
                '            .Parameters.AddWithValue("@issue_date", dr.item("issue_date"))
                '            .Parameters.AddWithValue("@pmode_desc", dr.item("pmode_desc"))
                '            .Parameters.AddWithValue("@due_date", dr.item("due_date"))
                '            .Parameters.AddWithValue("@agt_code", dr.item("agt_code"))
                '            .Parameters.AddWithValue("@agt_name", dr.item("agt_name"))
                '            .Parameters.AddWithValue("@total_amt", dr.item("total_amt"))
                '            .Parameters.AddWithValue("@cash_amt", dr.item("cash_amt"))
                '            .Parameters.AddWithValue("@chk_amt", dr.item("chk_amt"))
                '            .Parameters.AddWithValue("@apr_nmbr", dr.item("apr_nmbr"))
                '            .Parameters.AddWithValue("@apr_date", dr.item("apr_date"))
                '            .Parameters.AddWithValue("@agt_acct", dr.item("agt_acct"))
                '            .Parameters.AddWithValue("@acct_code", dr.item("acct_code"))
                '            .Parameters.AddWithValue("@detail1", dr.item("detail1"))
                '            .Parameters.AddWithValue("@dtl_amt1", dr.item("dtl_amt1"))
                '            .Parameters.AddWithValue("@detail2", dr.item("detail2"))
                '            .Parameters.AddWithValue("@dtl_amt2", dr.item("dtl_amt2"))
                '            .Parameters.AddWithValue("@detail3", dr.item("detail3"))
                '            .Parameters.AddWithValue("@dtl_amt3", dr.item("dtl_amt3"))
                '            .Parameters.AddWithValue("@detail4", dr.item("detail4"))
                '            .Parameters.AddWithValue("@dtl_amt4", dr.item("dtl_amt4"))
                '            .Parameters.AddWithValue("@detail5", dr.item("detail5"))
                '            .Parameters.AddWithValue("@dtl_amt5", dr.item("dtl_amt5"))
                '            .Parameters.AddWithValue("@curr_type", dr.item("curr_type"))
                '            .Parameters.AddWithValue("@cashier", dr.item("cashier"))
                '            .Parameters.AddWithValue("@gl_acct", dr.item("gl_acct"))
                '            .Parameters.AddWithValue("@remarks", dr.item("remarks"))
                '            .Parameters.AddWithValue("@appl_no", dr.item("appl_no"))
                '            .Parameters.AddWithValue("@chkno1", dr.item("chkno1"))
                '            .Parameters.AddWithValue("@bank1", dr.item("bank1"))
                '            .Parameters.AddWithValue("@branch1", dr.item("branch1"))
                '            .Parameters.AddWithValue("@chkno2", dr.item("chkno2"))
                '            .Parameters.AddWithValue("@bank2", dr.item("bank2"))
                '            .Parameters.AddWithValue("@branch2", dr.item("branch2"))
                '            .Parameters.AddWithValue("@card_no", dr.item("card_no"))
                '            .Parameters.AddWithValue("@card_type", dr.item("card_type"))
                '            .Parameters.AddWithValue("@vatable_coll", dr.item("vatable_coll"))
                '            .Parameters.AddWithValue("@vateexempt_coll", dr.item("vateexempt_coll"))
                '            .Parameters.AddWithValue("@vat_amount", dr.item("vat_amount"))
                '            .Parameters.AddWithValue("@wtax_amt", dr.item("wtax_amt"))
                '            .Parameters.AddWithValue("@net_amt", dr.item("net_amt"))

                '        End With
                '        Try
                '            conn.Open()
                '            comm.ExecuteNonQuery()
                '        Catch ex As SqlException
                '            Throw
                '        End Try
                '    End Using
                'End Using
            Next
        End Sub

        Public Sub DeleteReceipts(ByVal pConnStr As String)

            Dim query As String = String.Empty
            query &= "DELETE FROM tmporprt4"

            Using conn As New OleDbConnection(pConnStr)
                Using comm As New OleDbCommand()
                    With comm
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = query
                    End With
                    Try
                        conn.Open()
                        comm.ExecuteNonQuery()
                    Catch ex As OleDbException
                        Throw
                    End Try
                End Using
            End Using

        End Sub

#End Region

    End Class

End Namespace

