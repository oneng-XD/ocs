<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="PaymentSalesInvoice.aspx.vb" Inherits="Cocolife.UI.OCS.PaymentSalesInvoice"
    Title="Online Collection System (Payment : Sales Invoice)" %>

<%@ MasterType VirtualPath="~/OCS.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <script type="text/javascript" language="javascript">

        var ModalProgress = '<%=mpeProgress.ClientID%>';
        var ModalConfirm = '<%=mpeConfirm.ClientID%>';
        var ModalMessage = '<%=mpeMessage.ClientID%>';
        var ModalViewDocs = '<%=mpeViewDocs.ClientID%>';
        var ModalCancellation = '<%=mpeCancellation.ClientID%>';
        var txtReferenceNo = '<%=txtReferenceNo.ClientID%>';
        
        var ConfirmYes = '<%=btnConfirmYes.ClientID%>';

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

        function beginReq(sender, args) {
            var postBackElementID = args.get_postBackElement().id;
            if (ConfirmYes == postBackElementID) {
                $find(ModalConfirm).hide();
            }
            $find(ModalProgress).show();
        }

        function endReq(sender, args) {
            $find(ModalProgress).hide();
        }

        function IsReferenceNoValid() {
            var vReferenceNo = document.getElementById(txtReferenceNo).value;
            if (vReferenceNo == "") {
                SetMessage("Please Input Reference No.", "info");
                return false
            }

        }

        function IsSalesInvoiceValid() {
            if (document.getElementById(txtReferenceNo).disabled == false) {
                SetMessage("Please Verify Reference No.", "info");  
            } else {
                ConfirmSave();
            }
            return false
        }

        function PrintNotice() {
            SetMessage("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!", "info");
            return false;
        }

        function ConfirmSave() {
            SetConfirmation("Are you sure you want to save this Sales Invoice?", "SAVE");
        }

        function ConfirmCancel() {
            SetConfirmation("Are you sure you want to cancel<br />Sales Invoice#" + document.getElementById('<%=txtInvoiceNumber.ClientID%>').value + "?", "CANCEL");
            return false;
        }

        function CancelReason() {
            if (document.getElementById('<%=hdnConfirmCaller.ClientID%>').value == "CANCEL") {
                        $find(ModalConfirm).hide();
                        $find(ModalCancellation).show();
                        return false;
                    } else {
                        <%=Page.ClientScript.GetPostBackEventReference(btnConfirmYes, Nothing)%>;
            }
                }

        function IsCancellationValid() {
            var vCancellationReason = $('#<%=txtCancellationReason.ClientID%>').val()
            if (vCancellationReason == "") {
                SetMessage("You must input a Cancellation Reason.", "info");
                return false;
            } else {
                <%=Page.ClientScript.GetPostBackEventReference(btnCancelYes, Nothing)%>;
            }
        }

        function CloseCancellation() {
            $('#<%=txtCancellationReason.ClientID%>').val('');
            $find(ModalCancellation).hide();
        }

        function ViewDocs() {
            $find(ModalViewDocs).show();
            return false;
        }

        function SetMessage(message, icon) {
            document.getElementById('<%=lblMessage.ClientID%>').innerHTML = message;
            document.getElementById('<%=imgMessage.ClientID%>').src = "Images/icons/" + icon + ".png";
            $find(ModalMessage).show();
        }

        function SetConfirmation(message, caller) {
            document.getElementById('<%=lblConfirm.ClientID%>').innerHTML = message;
            document.getElementById('<%=hdnConfirmCaller.ClientID%>').value = caller;
            $find(ModalConfirm).show();
        }

        function IsOkOnly() {
            $find(ModalMessage).hide();
            return false
        }

    </script>

    <asp:UpdatePanel ID="upPaymentSalesInvoice" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="content">
                <div id="content-header-paymentsalesinvoice" class="content-header"></div>
                <div id="content-body">

                    <!-- PAYMENT DETAILS -->
                    <asp:Panel ID="pnlPaymentDetails" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-header">Sales Invoice Details</div>
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">SI Number</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        <asp:ImageButton ID="ibtnViewDocs" runat="server" ImageUrl="~/Images/icons/view.png" CssClass="ibtn ibtnView" CausesValidation="false" ToolTip="View Sales Invoices" OnClientClick="return ViewDocs();"/>
                                    </td>
                                    <td class="content-body-panel-td3 lblBold11">SI Date</td>
                                    <td class="content-body-panel-td4">
                                        <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel id="pnlPaymentDetails1" runat="server">
                            <div class="content-body-panel-detail">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="lblBold11">Source Site</td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlSourceSite" runat="server" CssClass="ddlLong"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Remarks</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtInvoiceRemarks" runat="server" CssClass="txtInputTextArea2" MaxLength="60"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Other Info</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtInvoiceOtherInfo" runat="server" CssClass="txtInputTextArea2" MaxLength="60"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </asp:Panel>

                    <br/>
                    
                    <!-- POLICY INFORMATION -->
                    <asp:Accordion ID="accInvoiceInformation" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnInvoiceInformation" runat="server">
                                <Header>Invoice Information</Header>
                                <Content>
                                    <asp:Panel id="pnlInvoiceInformation" runat="server">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lblBold11">Policy Type</td>
                                                    <td colspan="3">
                                                        <asp:DropDownList ID="ddlPolicyType" runat="server" CssClass="ddlShort" AutoPostBack="true">
                                                            <asp:ListItem>Group</asp:ListItem>
                                                            <asp:ListItem>Healthcare</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Reference Number</td>
                                                    <td>
                                                        <asp:Panel ID="pnlLoadRefNo" runat="server" DefaultButton="ibtnSearchRefNo">
                                                            <asp:TextBox ID="txtReferenceNo" runat="server" CssClass="txtInputShort" MaxLength="30"></asp:TextBox>
                                                            <asp:ImageButton ID="ibtnSearchRefNo" runat="server" ImageUrl="~/Images/icons/search.gif" CssClass="ibtn ibtnSearch" CausesValidation="false" ToolTip="Search Sales Invoice" onClientClick="return IsReferenceNoValid()" />
                                                            <asp:ImageButton ID="ibtnClearRefNo" runat="server" ImageUrl="~/Images/icons/eraser.png" CssClass="ibtn ibtnEraser" CausesValidation="false" ToolTip="Clear Invoice Details" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Policy Number</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPolicyNumber" runat="server" CssClass="txtInputShort" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td class="lblBold11">Upload Date</td>
                                                    <td>
                                                        <asp:TextBox ID="txtUploadDate" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Total Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtInvoiceAmount" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td class="lblBold11">Invoice Currency</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInvoiceCurrency" runat="server" CssClass="ddlShort" Enabled="false"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <div id="divPayorInsured" runat="server">
                                                    <tr>
                                                        <td class="lblBold11">Payor</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtPayorName" runat="server" CssClass="txtReadOnlyLong3" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">TIN</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtPayorTin" runat="server" CssClass="txtReadOnlyShort" TabIndex="-1" MaxLength="20"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                   
                                                     </tr>
                                                      <tr>
                                                        <td class="lblBold11">Address</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtPayorAddress" runat="server" CssClass="txtReadOnlyLong3"  TabIndex="-1" MaxLength="150"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>    
                                                        <td class="lblBold11">Insured Client Name</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtInsuredClientName" runat="server" CssClass="txtReadOnlyLong3" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Cov. Period From</td>
                                                        <td>
                                                            <asp:TextBox ID="txtCoveragePeriodFrom" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                        <td class="lblBold11">Cov. Period To</td>
                                                        <td>
                                                            <asp:TextBox ID="txtCoveragePeriodTo" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Agent</td>
                                                        <td>
                                                            <asp:TextBox ID="txtAgentCode" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                        <td class="lblBold11" colspan="2">    
                                                            <asp:TextBox ID="txtAgentName" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="lblBold11">Payment Term</td>
                                                        <td>
                                                            <asp:TextBox ID="txtPaymentTerm" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                        <td class="lblBold11">Next Due Date</td>
                                                        <td>
                                                            <asp:TextBox ID="txtNextDueDate" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </div>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>

                    <!-- PARTICULARS -->
                    <asp:Accordion ID="accParticulars" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnParticulars" runat="server">
                                <Header>Particulars</Header>
                                <Content>
                                    <asp:Panel ID="pnlParticulars" runat="server" DefaultButton="">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0"> 
                                                <tr>
                                                    <td colspan="4">
                                                        <%-- EmptyDataRowStyle-CssClass="gvwEmptyRow" --%>
                                                        <asp:GridView ID="gvwParticulars" runat="server"
                                                            CssClass="gvwStylePlain"
                                                            RowStyle-CssClass="gvwRow"
                                                            AlternatingRowStyle-CssClass="gvwAlternationRow"
                                                            EditRowStyle-CssClass="gvwEditRow"
                                                            SelectedRowStyle-CssClass="gvwSelectedRow"
                                                            EmptyDataText="No Record(s) Found."
                                                            FooterStyle-CssClass="gvwFooter"
                                                            PagerStyle-CssClass="gvwPager"
                                                            AutoGenerateColumns="false"
                                                            GridLines="None"
                                                            Width="100%">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Particulars" DataField="Particulars" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td class="lblbold11">Total Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtParticularsTotalAmount" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
                    
                    <!-- VAT COMPUTATION -->
                    <asp:Accordion ID="accVATComputation" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnVATComputation" runat="server">
                                <Header>VAT Computation</Header>
                                <Content>
                                    <asp:Panel ID="pnlVATComputation" runat="server" DefaultButton="">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">VATable Collection</td>
                                                    <td class="content-body-accordion-td2">
                                                        <asp:TextBox ID="txtVATable" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td class="content-body-accordion-td3"></td>
                                                    <td class="content-body-accordion-td4"></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">VAT-Exempt Collection</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATExempt" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">VAT Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATAmount" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Non VAT Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNonVAT" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="100%">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Total Sales</td>
                                                    <td>
                                                        <asp:TextBox ID="txtTotalSales" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Less: Withholding Tax</td>
                                                    <td>
                                                        <asp:TextBox ID="txtWitholdingTax" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Amount Net of WTax</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNetOfWitholdingTax" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Less: Discount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Discount ID</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDiscountIdNo" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
                    <br />
                    <br />

                    <!-- TRANSACTIONS -->
                    <asp:Panel ID="pnlTransactions" runat="server" CssClass="panel-button">
                        <asp:Button ID="btnInvoiceAddNew" runat="server" Text="Add New" CssClass="btnShort" />
                        <asp:Button ID="btnInvoiceSave" runat="server" Text="Save" CssClass="btnShort" Enabled="false" OnClientClick="return IsSalesInvoiceValid();" />
                        <asp:Button ID="btnInvoicePrint" runat="server" Text="Print Invoice" CssClass="btnShort" Enabled="false" OnClientClick="return PrintNotice();" />
                        <asp:Button ID="btnInvoiceCancel" runat="server" Text="Cancel Invoice" CssClass="btnShort" Enabled="false" OnClientClick="return ConfirmCancel();"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="btnShort" />
                    </asp:Panel>

                    <!-- HIDDEN -->
                    <asp:Panel ID="pnlHiddenFields" runat="server" CssClass="panel-hidden">
                        <asp:UpdatePanel ID ="upHiddenFields" runat="server" RenderMode="Inline" UpdateMode="Always">
                            <ContentTemplate>
                                <!-- PAYMENT DETAILS -->
                                <asp:HiddenField ID="hdnReferenceNoExisting" runat="server" />
                                <asp:HiddenField ID="hdnSalesInvoiceID" runat="server" />
                                <asp:HiddenField ID="hdnUploadTag" runat="server" />
                                <asp:HiddenField ID="hdnAckReceiptNumber" runat="server" />
                                <asp:HiddenField ID="hdnARDate" runat="server" />
                                <asp:HiddenField ID="hdnSIPrintStatus" runat="server" />
                                <asp:HiddenField ID="hdnARPrintStatus" runat="server" />
                                <asp:HiddenField ID="hdnConfirmTag" runat="server"/>
                                <asp:HiddenField ID="hdnConfirmCaller" runat="server"/>
                                <asp:HiddenField ID="hdnClickStateTag" runat="server" />
                                <asp:HiddenField ID="hdnDocPrinted" runat="server" />
                                <asp:HiddenField ID="hdnDocSaveState" runat="server" />
                                <asp:HiddenField ID="hdnIsSourceSiteLocked" runat="server" />
                                <asp:HiddenField ID="hdnReportType" runat="server" />
                                <asp:HiddenField ID="hdnReceiptByCode" runat="server" />
                                <asp:HiddenField ID="hdnReceiptById" runat="server" />
                                <asp:HiddenField ID="hdnReservedDocNo" runat="server" />
                                <asp:HiddenField ID="hdnIsFromNewgenAPI" runat="server" />
                                <asp:HiddenField ID="hdnParticularsRaw" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>

                </div>
                <div id="content-footer"></div>
            </div>

            <!-- VIEW DOCs -->
            <input id="dummyViewDocs" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlViewDocs" runat="server" CssClass="panel-modal-740" DefaultButton="btnLoadViewDoc" Style="">
                <asp:UpdatePanel ID="upViewDocs" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mhViewDocs"></td>
                            </tr>
                            <tr>
                                <td style="height: 5px;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="panel-modal-740-left"></div>
                                    <div class="panel-modal-740-main">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="content-body-panel-td1 lblBold11">From Date</td>
                                                <td class="content-body-panel-td2">
                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calFromDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtFromDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeFromDate" runat="server" TargetControlID="txtFromDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                                <td class="content-body-panel-td3 lblBold11">To Date</td>
                                                <td class="content-body-panel-td4">
                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calToDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtToDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeToDate" runat="server" TargetControlID="txtToDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Sales Invoice Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewInvoiceNumber" runat="server" CssClass="txtInputShortNumber"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteViewInvoiceNumber" runat="server" TargetControlID="txtViewInvoiceNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Reference Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewReferenceNo" runat="server" CssClass="txtInputShort" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnLoadViewDoc" runat="server" Text="Load" ToolTip="Load View Docs" CssClass="btnShort" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel runat="server" Width="700px">
                                                        <div class="gvwSearch" align="center">
                                                            <asp:GridView ID="gvwViewDoc" runat="server"
                                                                CssClass="gvwStylePlain"
                                                                RowStyle-CssClass="gvwRow"
                                                                AlternatingRowStyle-CssClass="gvwAlternationRow"
                                                                EditRowStyle-CssClass="gvwEditRow"
                                                                SelectedRowStyle-CssClass="gvwSelectedRow"
                                                                EmptyDataRowStyle-CssClass="gvwEmptyRow"
                                                                EmptyDataText="No Record(s) Found."
                                                                HeaderStyle-CssClass="gvwHeader"
                                                                FooterStyle-CssClass="gvwFooter"
                                                                PagerStyle-CssClass="gvwPager"
                                                                AutoGenerateColumns="false"
                                                                GridLines="None"
                                                                Width="1060px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:RadioButton ID="radSelectViewDoc" runat="server"
                                                                                GroupName="SelectDoc"
                                                                                AutoPostBack="true"
                                                                                OnCheckedChanged="radSelectViewDoc_CheckedChanged" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Invoice No" DataField="sales_invoice_no" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Reference No" DataField="reference_no" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Payor Name" DataField="payor" HeaderStyle-Width="270px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Client Insured Name" DataField="insured_client_name" HeaderStyle-Width="270px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Amount" DataField="total_amount" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                                                    <asp:BoundField HeaderText="Status" DataField="si_print_status" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Invoice Date" DataField="sales_invoice_date" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"  DataFormatString="{0:d}"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="user_name" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="si_printed_by" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="si_site_code" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden"/>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: right;">
                                                    <asp:Button ID="btnViewDocsClose" runat="server" Text="Close" CssClass="btnShort" CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="panel-modal-740-right"></div>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;"></td>
                            </tr>
                            <tr>
                                <td class="mfSeparator"></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpeViewDocs" runat="server"
                TargetControlID="dummyViewDocs"
                PopupControlID="pnlViewDocs"
                BackgroundCssClass="modal"
                Enabled="true">
            </asp:ModalPopupExtender>

            <!-- CANCELATION REASON MESSAGE -->
            <asp:LinkButton  id="dummyCancellation" style="display: none" runat = "server" />
            <asp:Panel ID="pnlCancellation" runat="server" Width="300px" 
                CssClass="panel-messagebox" DefaultButton="btnCancelNo">
                <table id="tblCancellation" width="100%" runat="server">
                    <tr>
                        <td rowspan="2" align="center" valign="top" style="width: 40px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/icons/question.png" height="32px" width="32px" />
                        </td>
                        <td style="width: 260px">&nbsp;</td>
                    </tr>
                    <tr><td><asp:Label ID="Label1" runat="server" CssClass="lblMessageBox" Text="?">What is the Reason for Cancellation?</asp:Label></td></tr>                    
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:TextBox ID="txtCancellationReason" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button ID="btnCancelYes" runat="server" Text="Proceed" OnClientClick="return IsCancellationValid();"
                                CssClass="btnShort" />
                            <asp:Button ID="btnCancelNo" runat="server" Text="Close" OnClientClick="return CloseCancellation();"
                                CssClass="btnShort" />
                        </td>
                    </tr>                         
                </table>
            </asp:Panel>
            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server"
                DisplayModalPopupID="mpeCancellation"
                TargetControlID="dummyCancellation">
            </asp:ConfirmButtonExtender>
            <asp:ModalPopupExtender ID="mpeCancellation" runat="server"
                TargetControlID="dummyCancellation"
                PopupControlID="pnlCancellation"
                BackgroundCssClass="modal"
                OkControlID = "btnCancelYes"
                CancelControlID = "btnCancelNo" >
            </asp:ModalPopupExtender>  

            <!-- CONFIRMATION MESSAGE -->
            <asp:LinkButton  id="dummyConfirm" style="display: none" runat = "server" />
            <asp:Panel ID="pnlConfirm" runat="server" Width="300px" 
                CssClass="panel-messagebox" DefaultButton="btnConfirmNo">
                <table id="tblConfirm" width="100%" runat="server">
                    <tr>
                        <td rowspan="2" align="center" valign="top" style="width: 40px">
                            <asp:Image ID="imgConfirm" runat="server" ImageUrl="Images/icons/question.png" height="32px" width="32px" />
                        </td>
                        <td style="width: 260px">&nbsp;</td>
                    </tr>
                    <tr><td><asp:Label ID="lblConfirm" runat="server" CssClass="lblMessageBox" Text="?"></asp:Label></td></tr>                    
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button ID="btnConfirmYes" runat="server" Text="Yes"
                                CssClass="btnShort" OnClientClick="return CancelReason();"/>
                            <asp:Button ID="btnConfirmNo" runat="server" Text="No"
                                CssClass="btnShort" />
                        </td>
                    </tr>                         
                </table>
            </asp:Panel>
            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                DisplayModalPopupID="mpeConfirm"
                TargetControlID="dummyConfirm">
            </asp:ConfirmButtonExtender>
            <asp:ModalPopupExtender ID="mpeConfirm" runat="server"
                TargetControlID="dummyConfirm"
                PopupControlID="pnlConfirm"
                BackgroundCssClass="modal"
                OkControlID = "btnConfirmYes"
                CancelControlID = "btnConfirmNo" >
            </asp:ModalPopupExtender>  

            <!-- MESSAGE BOX -->
            <input id="dummyMessage" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlMessage" runat="server" CssClass="panel-messagebox" DefaultButton="btnMessageOk" >
                <asp:UpdatePanel ID="upMessage" runat="server" RenderMode="Inline" UpdateMode="Always">
                    <ContentTemplate>
                        <div>
                            <div class="panel-messagebox-td1">
                                <asp:Image ID="imgMessage" runat="server" ImageUrl="Images/icons/critical.png" CssClass="image-messagebox" />
                            </div>
                            <div class="panel-messagebox-td2"></div>
                            <div class="panel-messagebox-td3">
                                <asp:Label ID="lblMessage" runat="server" CssClass="label-messagebox" Text="Error!"></asp:Label>
                            </div>
                        </div>
                        <div class="panel-messagebox-button">
                            <asp:Button ID="btnMessageOk" runat="server" Text="Ok" CssClass="btnShort" CausesValidation="false" OnClientClick="return IsOkOnly();" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpeMessage" runat="server"
                TargetControlID="dummyMessage"
                PopupControlID="pnlMessage"
                BackgroundCssClass="modal"
                Enabled="true">
            </asp:ModalPopupExtender>

            <!-- PROGRESS -->
            <asp:Panel ID="pnlProgress" runat="server" CssClass="panel-progress" Style="display: none">
                <div class="panel-progress-image">
                    <asp:Image ID="imgProcessing" runat="server" ImageUrl="~/images/loading.gif" />
                </div>
                <div class="panel-progress-label">Processing...</div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpeProgress" runat="server"
                TargetControlID="pnlProgress"
                PopupControlID="pnlProgress"
                BackgroundCssClass="modal">
            </asp:ModalPopupExtender>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnMessageOk" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
