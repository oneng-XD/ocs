<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="PaymentAckReceipt.aspx.vb" Inherits="Cocolife.UI.OCS.PaymentAckReceipt"
    Title="Online Collection System (Payment : Acknowledgement Receipt)" %>

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
        var ModalViewARs = '<%=mpeViewARs.ClientID%>';
        var ModalViewSIs = '<%=mpeViewSIs.ClientID%>';
        var ModalCancellation = '<%=mpeCancellation.ClientID%>';
        var txtInvoiceNumber = '<%=txtInvoiceNumber.ClientID%>';
        
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

        function ClearCreditCardDetails() {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode >= 48 && evt.keyCode <= 57) || (evt.keyCode >= 96 && evt.keyCode <= 105) || evt.keyCode == 8 || evt.keyCode == 46) {
                document.getElementById('<%= txtCreditCardType.ClientID%>').value = "";
                document.getElementById('<%= hdnCreditCardNumberTag.ClientID%>').value = "false";
                document.getElementById('<%= hdnCreditCardType.ClientID %>').value = "";
            }
        }

        function SelectDebitCardBankName() {
            if ($('#<%=ddlDebitCardBankName.ClientID%>').children("option:selected").val() == "OTHER") {
                $('#<%=txtDebitCardOtherBank.ClientID%>').show();
                $('#<%=lblDebitCardOtherBank.ClientID%>').html("Others:");
            } else {
                $('#<%=txtDebitCardOtherBank.ClientID%>').val('');
                $('#<%=txtDebitCardOtherBank.ClientID%>').hide();
                $('#<%=lblDebitCardOtherBank.ClientID%>').html("");
            }
        }

        function clickVerifyGrossAmount() {
            //$('#<%=ibtnVerifyGrossAmount.ClientID%>').trigger('click');
            document.getElementById("<%=ibtnVerifyGrossAmount.ClientID%>").click();
        }

        function enforceLimits(textbox, maxLines, maxChars) {
            // Check character limit
            if (textbox.value.length > maxChars) {
                textbox.value = textbox.value.substring(0, maxChars); // Trim to max allowed characters
                SetMessage("You can only enter up to " + maxChars + " characters.", "info");
            }

            // Check line limit
            var lines = textbox.value.split(/\r?\n/); // Split the text by lines
            if (lines.length > maxLines) {
                textbox.value = lines.slice(0, maxLines).join("\n"); // Limit to max allowed lines
                SetMessage("You can only enter up to " + maxLines + " lines.", "info");

            }
        }

        function IsGrossAmountValid() {
            if (document.getElementById("<%=txtGrossAmount.ClientID%>").value <= 0) {
                SetMessage("Gross Amount should be greater than zero(0).", "warning")
                return false
            }
        }

        function IsInvoiceNoValid() {
            var vReferenceNo = document.getElementById(txtInvoiceNumber).value;
            if (vReferenceNo == "") {
                SetMessage("Please Input Sales Invoice No.", "info");
                return false;
            }

        }

        function IsViewARValid() {
            var vARNo= document.getElementById('<%=txtViewARNumber.ClientID%>').value;
            var vSINo= document.getElementById('<%=txtViewARBySINo.ClientID%>').value;
            var vDateFr = document.getElementById('<%=txtViewARFromDate.ClientID%>').value;
            var vDateTo = document.getElementById('<%=txtViewARToDate.ClientID%>').value;
            
            if (vARNo == "" && vSINo == "") {
                if (vDateFr == "" || vDateTo == "") {
                    SetMessage("Please enter dates.", "info");
                    return false;
                }
            }
        }
        
        function IsViewSIValid() {
            var vReferenceNo = $('#<%=txtViewSINumber.ClientID%>').val();
            var vSourceType = $('#<%=ddlSourceType.ClientID%>').children("option:selected").val()
            if (vSourceType == "HMO" && vReferenceNo == "") {
                SetMessage("Use exact Sales Invoice No. for HMO accounts", "info");
                return false;
            }
        }

        function IsCancellationValid() {
            var vCancellationReason = $('#<%=ddlCancellationReason.ClientID%>').children("option:selected").val()
            if (vCancellationReason == "") {
                SetMessage("You must Select a Cancellation Reason.", "info");
                return false;
            } else {
                <%=Page.ClientScript.GetPostBackEventReference(btnCancelYes, Nothing)%>;
            }
        }

        function CloseCancellation() {
            $('#<%=ddlCancellationReason.ClientID%>').prop('selectedIndex', -1);
            $find(ModalCancellation).hide();
        }

        function SelectCheckBankName() {
            if ($('#<%=ddlCheckBankName.ClientID%>').children("option:selected").val() == "OTHER") {
                $('#<%=txtOtherBank.ClientID%>').show();
                $('#<%=lblOtherBank.ClientID%>').html("Others:");
            } else {
                $('#<%=txtOtherBank.ClientID%>').val('');
                $('#<%=txtOtherBank.ClientID%>').hide();
                $('#<%=lblOtherBank.ClientID%>').html("");
            }
        }

        function IsSaveValid() {
            if ($("#<%=ddlSourceSite.ClientID%>").children("option:selected").val()== "") {
                SetMessage("Please select a Source Site.", "warning");
                return false
            }
            if ($('#<%=hdnIsSourceSiteLocked.ClientID%>').val() == false) {
                SetMessage("Please verify Source Site.", "warning");
                return false
            }
            if ($("#<%=ddlPayCurrency.ClientID%>").children("option:selected").val() == "") {
                SetMessage("Please select currency of payment.", "warning");
                return false
            }
            if ($('#<%=hdnIsGrossAmountLocked.ClientID%>').val() == false) {
                SetMessage("Please verify Gross Amount.", "warning");
                return false
            }
            if ($('#<%=txtARParticulars.ClientID%>').val().trim() == "") {
                SetMessage("Please input AR Particulars.", "warning");
                return false;
            }
            return ConfirmSave();
        }

        function ConfirmSave() {
            if ($('#<%=hdnIsGrossAmountLocked.ClientID%>').val() == "Save" || $('#<%=hdnIsGrossAmountLocked.ClientID%>').val() == "Update") {
                SetConfirmation("Are you sure you want to save this AR?", "SAVE");
                return false;
            }
        }

        function ConfirmCancel() {
            SetConfirmation("Are you sure you want to cancel<br />AR#" + document.getElementById('<%=txtARNumber.ClientID%>').value + "?", "CANCEL");
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

        function ConfirmPrint() {
            if (document.getElementById("<%=hdnARPrintStatus.ClientID%>").value == "PRINTED") {
                SetMessage("<strong><h2>REMINDER:</h2></strong><br />Please print receipt using OCS - Printer!", "info")
                return false;
            }
            SetConfirmation("Are you sure you want to print<br />AR#" + document.getElementById('<%=txtARNumber.ClientID%>').value + "?", "PRINT");
            return false;
        }

        function ViewARs() {
            $find(ModalViewARs).show();
            return false;
        }

        function ViewSIs() {
            var today = new Date();
            var priorDate = new Date(new Date().setDate(today.getDate() - 30));

            if (document.getElementById('<%=txtInvoiceNumber.ClientID%>').value == "") {
                document.getElementById('<%=txtViewSINumber.ClientID%>').value = document.getElementById('<%=txtInvoiceNumber.ClientID%>').value
               
                //document.getElementById("<%=btnLoadViewSI.ClientID%>").click();
                $find(ModalViewSIs).show();
                //$find(ModalProgress).show();
                return false;                
            }
        }

        function CloseModal() {
            $find(ModalViewARs).hide();
            $find(ModalViewSIs).hide();
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

    <asp:UpdatePanel ID="upPaymentAckReceipt" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="content">
                <div id="content-header-paymentackreceipt" class="content-header"></div>
                <div id="content-body">

                    <!-- PAYMENT DETAILS -->
                    <asp:Panel ID="pnlPaymentDetails" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-header">Acknowledgement Receipt Details</div>
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">AR Number</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtARNumber" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        <asp:ImageButton ID="ibtnViewARs" runat="server" ImageUrl="~/Images/icons/view.png" CssClass="ibtn ibtnView" CausesValidation="false" ToolTip="View ARs" OnClientClick="return ViewARs();"/>
                                    </td>
                                    <td class="content-body-panel-td3 lblBold11">AR Date</td>
                                    <td class="content-body-panel-td4">
                                        <asp:TextBox ID="txtARDate" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
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
                                            <asp:ImageButton ID="ibtnVerifySourceSite" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Source Site" Visible="False" />
                                            <asp:ImageButton ID="ibtnClearSourceSite" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Source Site" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Remarks</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtARRemarks" runat="server" CssClass="txtInputTextArea2" MaxLength="60"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Other Info</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAROtherInfo" runat="server" CssClass="txtInputTextArea2" MaxLength="60"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Gross Amount (Total Sales)</td>
                                        <td class="content-body-panel-td2">
                                            <asp:Panel ID="pnlGrossAmount" runat="server" DefaultButton="ibtnVerifyGrossAmount" >
                                                <asp:TextBox ID="txtGrossAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14" OnBlur="clickVerifyGrossAmount();"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="fteGrossAmount" runat="server" TargetControlID="txtGrossAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                <asp:ImageButton ID="ibtnVerifyGrossAmount" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Gross Amount" Visible="False" OnClientClick="return IsGrossAmountValid();" />
                                                <asp:ImageButton ID="ibtnClearGrossAmount" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Gross Amount" Visible="False" />
                                            </asp:Panel>
                                        </td>
                                        <td class="lblBold11">Payment Currency</td>
                                        <td>
                                            <asp:DropDownList ID="ddlPayCurrency" runat="server" CssClass="ddlShort" Enabled="false"></asp:DropDownList>
                                        </td>
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
                                                    <td class="lblBold11">Invoice Number</td>
                                                    <td>
                                                        <asp:Panel ID="pnlLoadSalesInvoice" runat="server" DefaultButton="ibtnSearchSalesInvoice">
                                                            <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="txtInputShort" MaxLength="30"></asp:TextBox>
                                                             <asp:FilteredTextBoxExtender ID="fteInvoiceNumber" runat="server" TargetControlID="txtInvoiceNumber" FilterType="Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                            <%--<asp:ImageButton ID="ibtnSearchSalesInvoice" runat="server" ImageUrl="~/Images/icons/search.gif" CssClass="ibtn ibtnSearch" CausesValidation="false" ToolTip="Search Sales Invoice" onClientClick="return IsInvoiceNoValid()" />--%>
                                                            <asp:ImageButton ID="ibtnSearchSalesInvoice" runat="server" ImageUrl="~/Images/icons/view.png" CssClass="ibtn ibtnView" CausesValidation="false" ToolTip="View SIs" OnClientClick="return ViewSIs();"/>
                                                            <asp:ImageButton ID="ibtnClearRefNo" runat="server" ImageUrl="~/Images/icons/eraser.png" CssClass="ibtn ibtnEraser" CausesValidation="false" ToolTip="Clear Invoice Details" />
                                                        </asp:Panel>
                                                    </td>
                                                    <td class="lblBold11">Invoice Date</td>
                                                    <td>
                                                        <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Policy Number</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPolicyNumber" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td class="lblBold11">Reference Number</td>
                                                    <td>
                                                        <asp:TextBox ID="txtReferenceNo" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
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

                    <!--SALES INVOICE PARTICULARS -->
                    <asp:Accordion ID="accParticulars" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnParticulars" runat="server">
                                <Header>Sales Invoice Particulars</Header>
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

                    <!-- AR PARTICULARS -->
                    <asp:Accordion ID="accARParticulars" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnARParticulars" runat="server">
                                <Header>Acknowledgement Receipt Particulars</Header>
                                <Content>
                                    <asp:Panel ID="pnlARParticulars" runat="server" DefaultButton="">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0"> 
                                                <tr>
                                                    <td colspan="4">
                                                       <asp:TextBox ID="txtARParticulars" runat="server" TextMode="MultiLine" 
                                                           Rows="5" style="resize: none; width: 100%; height: 100px;" 
                                                           onkeyup="enforceLimits(this, 5, 2000);" 
                                                           oninput="enforceLimits(this, 5, 2000);">
                                                       </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>

                    <!-- SALES COMPUTATION -->
                    <asp:Accordion ID="accVATComputation" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnVATComputation" runat="server">
                                <Header>Sales Computation</Header>
                                <Content>
                                    <asp:Panel ID="pnlVATComputation" runat="server" DefaultButton="">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lblBold11">Less: Withholding Tax</td>
                                                    <td>
                                                        <asp:Panel ID="pnlWitholdingTax" runat="server" DefaultButton="ibtnVerifyWTax" >
                                                            <asp:TextBox ID="txtWitholdingTax" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="fteWitholdingTax" runat="server" TargetControlID="txtWitholdingTax" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                            <asp:ImageButton ID="ibtnVerifyWTax" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Witholding Tax Amount" Visible="False" />
                                                            <asp:ImageButton ID="ibtnClearWTax" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Witholding Tax Amount" Visible="False"   />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Amount Net of WTax</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNetOfWitholdingTax" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="content-body-accordion-td3 lblBold11">Commission Amount</td>
                                                    <td class="content-body-accordion-td4">
                                                        <asp:Panel ID="pnlCommissionAmount" runat="server" DefaultButton="ibtnVerifyComm" >
                                                            <asp:TextBox ID="txtCommissionAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="fteCommissionAmount" runat="server" TargetControlID="txtCommissionAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                            <asp:ImageButton ID="ibtnVerifyComm" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Commission Amount" Visible="true" />
                                                            <asp:ImageButton ID="ibtnClearComm" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Commission Amount" Visible="true"   />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Less: Discount</td>
                                                    <td>
                                                        <asp:Panel ID="pnlDiscount" runat="server" DefaultButton="ibtnVerifyDiscount" >
                                                            <asp:TextBox ID="txtDiscount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtWitholdingTax" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                            <asp:ImageButton ID="ibtnVerifyDiscount" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Discount Amount" Visible="true" />
                                                            <asp:ImageButton ID="ibtnClearDiscount" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Discount Amount" Visible="true"   />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Discount ID</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDiscountIdNo" runat="server" CssClass="txtInputShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Total Amount Received</td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtTotalSales" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
                    
                    <!-- PAYMENT DETAILS -->
                    <asp:Accordion ID="accPaymentTypeDetails" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnPaymentTypeDetails" runat="server">
                                <Header>Payment Type Details</Header>
                                <Content>
                                    <asp:Panel ID="pnlPaymentTypeDetails" runat="server" DefaultButton="btnPaymentTypeAdd">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">Payment Type</td>
                                                    <td colspan="3">
                                                        <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="4">
                                                        <!-- Cash Details -->
                                                        <asp:Panel ID="pnlCashDetails" runat="server" Visible="False">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="content-body-accordion-td1 lblBold11">Cash Amount</td>
                                                                    <td class="content-body-accordion-td2">
                                                                        <asp:Panel runat="server" DefaultButton="ibtnAddCash">
                                                                            <asp:TextBox ID="txtCashAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                                            <asp:FilteredTextBoxExtender ID="fteCashAmount" runat="server" TargetControlID="txtCashAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                                            <asp:ImageButton ID="ibtnAddCash" runat="server" ImageUrl="~/Images/icons/add.png" CssClass="ibtn ibtnAdd" ToolTip="Add Cash Amount" />
                                                                        </asp:Panel>
                                                                    </td>
                                                                    <td class="content-body-accordion-td3"></td>
                                                                    <td class="content-body-accordion-td4"></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <!-- Check Details -->
                                                        <asp:Panel ID="pnlCheckDetails" runat="server" Visible="False">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="content-body-accordion-td1 lblBold11">Check Number</td>
                                                                    <td class="content-body-accordion-td2">
                                                                        <asp:TextBox ID="txtCheckNumber" runat="server" CssClass="txtInputShortNumber" MaxLength="10"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteCheckNumber" runat="server" TargetControlID="txtCheckNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="content-body-accordion-td3 lblBold11">Check Amount</td>
                                                                    <td class="content-body-accordion-td4">
                                                                        <asp:TextBox ID="txtCheckAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteCheckAmount" runat="server" TargetControlID="txtCheckAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Bank Name</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCheckBankName" runat="server" CssClass="ddlLong" OnChange="SelectCheckBankName();" ></asp:DropDownList>
                                                                    </td>
                                                                         <td ID="lblOtherBank" runat="server" class="lblBold11" ></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOtherBank" runat="server" CssClass="txtInputLong" MaxLength="20" style="display: none;"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="lblBold11">Bank Branch</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCheckBankBranch" runat="server" CssClass="txtInputLong" MaxLength="15"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lblBold11"></td>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>

                                                        <!-- Credit Card Details -->
                                                        <asp:Panel ID="pnlCreditCardDetails" runat="server" Visible="False">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="content-body-accordion-td1 lblBold11">Terminal Use</td>
                                                                    <td class="content-body-accordion-td2">
                                                                        <asp:DropDownList ID="ddlCreditCardTerminalUse" runat="server" CssClass="ddlShort" AutoPostBack="true"></asp:DropDownList>
                                                                    </td>
                                                                    <td class="content-body-accordion-td3 lblBold11">Swipe Date</td>
                                                                    <td class="content-body-accordion-td4">
                                                                        <asp:TextBox ID="txtCreditCardSwipeDate" runat="server" CssClass="txtInputDate" MaxLength="10"></asp:TextBox>
                                                                        <asp:CalendarExtender ID="calCreditCardSwipeDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtCreditCardSwipeDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                                        <asp:MaskedEditExtender ID="meeCreditCardSwipeDate" runat="server" TargetControlID="txtCreditCardSwipeDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                                        <asp:DropDownList ID="ddlCreditSwipeHour" runat="server" CssClass="ddlTime"></asp:DropDownList>
                                                                        :
                                                                        <asp:DropDownList ID="ddlCreditSwipeMinute" runat="server" CssClass="ddlTime"></asp:DropDownList>
                                                                        &nbsp;
                                                                        <asp:DropDownList ID="ddlCreditSwipeAmPm" runat="server" CssClass="ddlTime"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Merchant</td>
                                                                    <td colspan="2">
                                                                        <asp:DropDownList ID="ddlCreditCardMerchant" runat="server" CssClass="ddlLong2"></asp:DropDownList>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Card Number</td>
                                                                    <td>
                                                                        <asp:Panel ID="pnlCreditCardNo" runat="server" DefaultButton="btnValidateCreditCardNo">
                                                                            <asp:TextBox ID="txtCreditCardNumber" runat="server" CssClass="txtInputShortNumber" MaxLength="19" OnKeyDown="ClearCreditCardDetails();" OnBlur="clickBtnValidateCreditCardNo();"></asp:TextBox>
                                                                            <asp:FilteredTextBoxExtender ID="fteCreditCardNumber" runat="server" TargetControlID="txtCreditCardNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                                            <asp:Button ID="btnValidateCreditCardNo" runat="server" Text="" CssClass="btnHidden" /> 
                                                                        </asp:Panel>
                                                                    </td>
                                                                    <td class="lblBold11">Card Type</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCreditCardType" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Batch Number</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCreditCardBatchNumber" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteCreditCardBatchNumber" runat="server" TargetControlID="txtCreditCardBatchNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="lblBold11">Approval Code</td>
                                                                    <td>
                                                                        <asp:Panel ID="pnlCreditCardApprovalCode" runat="server" DefaultButton="btnCreditCardApprovalCode">
                                                                            <asp:TextBox ID="txtCreditCardApprovalCode" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                                            <asp:FilteredTextBoxExtender ID="fteCreditCardApprovalCode" runat="server" TargetControlID="txtCreditCardApprovalCode" FilterType="Custom, UppercaseLetters, LowercaseLetters, Numbers"></asp:FilteredTextBoxExtender>
                                                                            <asp:Button ID="btnCreditCardApprovalCode" runat="server" Text="" CssClass="btnHidden" /> 
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Amount</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCreditCardAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteCreditCardAmount" runat="server" TargetControlID="txtCreditCardAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Remarks</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtCreditCardRemarks" runat="server" CssClass="txtInputLong2" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <!-- Debit Card Details -->
                                                        <asp:Panel ID="pnlDebitCardDetails" runat="server" Visible="False">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="content-body-accordion-td1 lblBold11">Terminal Use</td>
                                                                    <td class="content-body-accordion-td2">
                                                                        <asp:DropDownList ID="ddlDebitCardTerminalUse" runat="server" CssClass="ddlShort" AutoPostBack="true"></asp:DropDownList>
                                                                    </td>
                                                                    <td class="content-body-accordion-td3 lblBold11">Swipe Date</td>
                                                                    <td class="content-body-accordion-td4">
                                                                        <asp:TextBox ID="txtDebitCardSwipeDate" runat="server" CssClass="txtInputDate" MaxLength="10"></asp:TextBox>
                                                                        <asp:CalendarExtender ID="calDebitCardSwipeDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtDebitCardSwipeDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                                        <asp:MaskedEditExtender ID="meeDebitCardSwipeDate" runat="server" TargetControlID="txtDebitCardSwipeDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                                        <asp:DropDownList ID="ddlDebitSwipeHour" runat="server" CssClass="ddlTime"></asp:DropDownList>
                                                                        :
                                                                        <asp:DropDownList ID="ddlDebitSwipeMinute" runat="server" CssClass="ddlTime"></asp:DropDownList>
                                                                        &nbsp;
                                                                        <asp:DropDownList ID="ddlDebitSwipeAmPm" runat="server" CssClass="ddlTime"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Merchant</td>
                                                                    <td colspan="2">
                                                                        <asp:DropDownList ID="ddlDebitCardMerchant" runat="server" CssClass="ddlLong2"></asp:DropDownList>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Bank Network</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDebitCardBankNetwork" runat="server" CssClass="ddlShort"></asp:DropDownList>
                                                                    </td>
                                                                    <td class="lblBold11"></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Bank Name</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDebitCardBankName" runat="server" CssClass="ddlLong" OnChange="SelectDebitCardBankName();"></asp:DropDownList>
                                                                    </td>
                                                                    <td ID="lblDebitCardOtherBank" runat="server" class="lblBold11" ></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDebitCardOtherBank" runat="server" CssClass="txtInputLong" MaxLength="20" style="display: none;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Account Type</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDebitCardAccountType" runat="server" CssClass="ddlShort"></asp:DropDownList>
                                                                    </td>
                                                                    <td class="lblBold11">Account Number</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDebitCardAccountNumber" runat="server" CssClass="txtInputLong" MaxLength="20"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteDebitCardAccountNumber" runat="server" TargetControlID="txtDebitCardAccountNumber" FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Batch Number</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDebitCardBatchNumber" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteDebitCardBatchNumber" runat="server" TargetControlID="txtDebitCardBatchNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td class="lblBold11">Charge Slip Number</td>
                                                                    <td>
                                                                        <asp:Panel ID="pnlDebitCardChargeSlip" runat="server" DefaultButton="btnDebitCardChargeSlip">
                                                                            <asp:TextBox ID="txtDebitCardChargeSlip" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                                            <asp:FilteredTextBoxExtender ID="fteDebitCardChargeSlip" runat="server" TargetControlID="txtDebitCardChargeSlip" FilterType="Custom, UppercaseLetters, LowercaseLetters, Numbers"></asp:FilteredTextBoxExtender>
                                                                            <asp:Button ID="btnDebitCardChargeSlip" runat="server" Text="" CssClass="btnHidden" /> 
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Amount</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDebitCardAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteDebitCardAmount" runat="server" TargetControlID="txtDebitCardAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Remarks</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtDebitCardRemarks" runat="server" CssClass="txtInputTextArea2" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <!-- E-Payment Details -->
                                                        <asp:Panel ID="pnlECashPaymentDetails" runat="server" Visible="False">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="content-body-accordion-td1 lblBold11">Payment Channel</td>
                                                                    <td colspan="2">
                                                                        <asp:DropDownList ID="ddlECashPaymentChannel" runat="server" CssClass="ddlLong2"></asp:DropDownList>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Reference Number</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtECashPaymentReferenceNumber" runat="server" CssClass="txtInputShort" MaxLength="30"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Amount</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtECashPaymentAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                                        <asp:FilteredTextBoxExtender ID="fteECashPaymentAmount" runat="server" TargetControlID="txtECashPaymentAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lblBold11">Remarks</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtECashPaymentRemarks" runat="server" CssClass="txtInputTextArea2" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="content-body-accordion-button">
                                                        <asp:Button ID="btnPaymentTypeAdd" runat="server" Text="Add" CssClass="btnShort" />
                                                        <asp:Button ID="btnPaymentTypeClear" runat="server" Text="Clear" CssClass="btnShort" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="gvwPaymentTypeDetails" runat="server"
                                                            CssClass="gvwStylePlain"
                                                            RowStyle-CssClass="gvwRow"
                                                            AlternatingRowStyle-CssClass="gvwAlternationRow"
                                                            EditRowStyle-CssClass="gvwEditRow"
                                                            SelectedRowStyle-CssClass="gvwSelectedRow"
                                                            EmptyDataRowStyle-CssClass="gvwEmptyRow"
                                                            EmptyDataText="No Record(s) Found."
                                                            FooterStyle-CssClass="gvwFooter"
                                                            PagerStyle-CssClass="gvwPager"
                                                            AutoGenerateColumns="false"
                                                            GridLines="None"
                                                            Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButton ID="radSelectPayTypeDetails" runat="server"
                                                                            GroupName="SelectPaymentType"
                                                                            AutoPostBack="true"
                                                                            OnCheckedChanged="radSelectPayTypeDetails_CheckedChanged" 
                                                                            />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="ID" DataField="PaymentTypeId" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Payment Type" DataField="PaymentType" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Check Number" DataField="CHECKNUMBER" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Terminal Use" DataField="TERMINALUSE" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Merchant ID" DataField="MERCHANTID" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Swipe Date" DataField="SWIPEDATE" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Network" DataField="NETWORK" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Bank" DataField="BANK" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Branch" DataField="BRANCH" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="CASA" DataField="CASA" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Account Number" DataField="ACCOUNTNUMBER" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Card Type" DataField="CARDTYPE" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Card Number" DataField="CARDNUMBER" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Approval Code" DataField="APPROVALCODE" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Remarks" DataField="REMARKS" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Reference Number" DataField="ReferenceNumber" HeaderStyle-Width="570px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N}" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Batch Number" DataField="BATCHNUMBER" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Reference ID" DataField="REFERENCEID" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Payment Channel" DataField="PAYMENTCHANNEL" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Service Fee Rate" DataField="SERVICEFEERATE" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:TemplateField HeaderStyle-Width="10px" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibtnPaymentTypeDetailsDelete" runat="server"
                                                                            ImageUrl="images/icons/delete.png"
                                                                            CommandName="DELETE"
                                                                            ToolTip="Delete Payment Type Detail" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="content-body-accordion-td1"></td>
                                                    <td class="content-body-accordion-td2"></td>
                                                    <td class="content-body-accordion-td3 lblBold11">Total Amount</td>
                                                    <td class="content-body-accordion-td4">
                                                        <asp:TextBox ID="txtPaymentTypeTotalAmount" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
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
                        <asp:Button ID="btnAckReceiptAddNew" runat="server" Text="Add New" CssClass="btnShort" />
                        <asp:Button ID="btnAckReceiptSave" runat="server" Text="Save" CssClass="btnShort" Enabled="false" OnClientClick="return IsSaveValid();" />
                        <asp:Button ID="btnAckReceiptPrint" runat="server" Text="Print Receipt" CssClass="btnShort" Enabled="false" OnClientClick="return ConfirmPrint();" />
                        <asp:Button ID="btnAckReceiptCancel" runat="server" Text="Cancel Receipt" CssClass="btnShort" Enabled="false" OnClientClick="return ConfirmCancel();"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="btnShort" />
                    </asp:Panel>

                    <!-- HIDDEN -->
                    <asp:Panel ID="pnlHiddenFields" runat="server" CssClass="panel-hidden">
                        <asp:UpdatePanel ID ="upHiddenFields" runat="server" RenderMode="Inline" UpdateMode="Always">
                            <ContentTemplate>
                                <!-- DOC DETAILS -->
                                <asp:HiddenField ID="hdnInvoiceNoExisting" runat="server" />
                                <asp:HiddenField ID="hdnARNoExisting" runat="server" />
                                <asp:HiddenField ID="hdnAckReceiptID" runat="server" />
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
                                <!-- PAYMENT DETAILS -->
                                <asp:HiddenField ID="hdnPrevPayType" runat="server" />
                                <asp:HiddenField ID="hdnAllowedPaymentType" runat="server" />
                                <asp:HiddenField ID="hdnPaymentTypeID" runat="server" />
                                <asp:HiddenField ID="hdnPaymentTypeTag" runat="server" />
                                <asp:HiddenField ID="hdnCashPaymentTag" runat="server" />
                                <asp:HiddenField ID="hdnCheckPaymentTag" runat="server" />
                                <asp:HiddenField ID="hdnCreditCardPaymentTag" runat="server" />
                                <asp:HiddenField ID="hdnDebitCardPaymentTag" runat="server" />
                                <asp:HiddenField ID="hdnECashPaymentTag" runat="server" />
                                <asp:HiddenField ID="hdnCashTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnCheckTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnCreditCardTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnDebitCardTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnECashPaymentTotalAmount" runat="server" />
                                <asp:HiddenField ID="hdnCreditCardNumberTag" runat="server" />
                                <asp:HiddenField ID="hdnCreditCardType" runat="server" />
                                <asp:HiddenField ID="hdnIsGrossAmountLocked" runat="server" />
                                <asp:HiddenField ID="hdnIsWTaxAmountLocked" runat="server" />
                                <asp:HiddenField ID="hdnIsDiscountLocked" runat="server" />
                                <asp:HiddenField ID="hdnIsCommLocked" runat="server" />
                                <asp:HiddenField ID="hdnSISourceType" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>

                </div>
                <div id="content-footer"></div>
            </div>

            <!-- VIEW DOCs -->
            <input id="dummyViewARs" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlViewARs" runat="server" CssClass="panel-modal-740" DefaultButton="btnLoadViewAR" Style="">
                <asp:UpdatePanel ID="upViewARs" runat="server" RenderMode="Inline" UpdateMode="Conditional">
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
                                            <tr><td class="lblBoldRed12" colspan="4">Search Acknowldegement Receipts</td></tr>
                                            <tr>
                                                <td class="content-body-panel-td1 lblBold11">From Date</td>
                                                <td class="content-body-panel-td2">
                                                    <asp:TextBox ID="txtViewARFromDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calViewARFromDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtViewARFromDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeViewARFromDate" runat="server" TargetControlID="txtViewARFromDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                                <td class="content-body-panel-td3 lblBold11">To Date</td>
                                                <td class="content-body-panel-td4">
                                                    <asp:TextBox ID="txtViewARToDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calViewARToDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtViewARToDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeViewARToDate" runat="server" TargetControlID="txtViewARToDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Ack. Receipt No.</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewARNumber" runat="server" CssClass="txtInputShortNumber"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteViewARNumber" runat="server" TargetControlID="txtViewARNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Sales Invoice Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewARBySINo" runat="server" CssClass="txtInputShort" MaxLength="15"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteViewARBySINo" runat="server" TargetControlID="txtViewARBySINo" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnLoadViewAR" runat="server" Text="Load" ToolTip="Load View Docs" CssClass="btnShort" OnClientClick="return IsViewARValid();"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel runat="server" Width="700px">
                                                        <div class="gvwSearch" align="center">
                                                            <asp:GridView ID="gvwViewAR" runat="server"
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
                                                                            <asp:RadioButton ID="radSelectViewAR" runat="server"
                                                                                GroupName="SelectDoc"
                                                                                AutoPostBack="true"
                                                                                OnCheckedChanged="radSelectViewAR_CheckedChanged" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Ack Receipt No" DataField="ar_no" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Sales Invoice No" DataField="sales_invoice_no" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Payor Name" DataField="payor" HeaderStyle-Width="270px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Amount" DataField="total_amount" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                                                    <asp:BoundField HeaderText="Status" DataField="status" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="AR Date" DataField="ar_date" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"  DataFormatString="{0:d}"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="user_name" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="ar_printed_by" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="site_code" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden"/>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: right;">
                                                    <asp:Button ID="btnViewARsClose" runat="server" Text="Close" CssClass="btnShort" CausesValidation="false" OnClientClick="return CloseModal();"/>
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
            <asp:ModalPopupExtender ID="mpeViewARs" runat="server"
                TargetControlID="dummyViewARs"
                PopupControlID="pnlViewARs"
                BackgroundCssClass="modal"
                Enabled="true">
            </asp:ModalPopupExtender>
             
            <!-- VIEW SIs -->
            <input id="dummyViewSIs" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlViewSIs" runat="server" CssClass="panel-modal-740" DefaultButton="btnLoadViewSI" Style="">
                <asp:UpdatePanel ID="upViewSIs" runat="server" RenderMode="Inline" UpdateMode="Conditional">
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
                                            <tr><td class="lblBoldRed12" colspan="4">Search Sales Invoice</td></tr>
                                            <tr>
                                                <td class="lblBold11">Source</td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlSourceType" runat="server" CssClass="ddlShort" >
                                                        <asp:ListItem>SSO</asp:ListItem>
                                                        <asp:ListItem>HMO</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="content-body-panel-td1 lblBold11">From Date</td>
                                                <td class="content-body-panel-td2">
                                                    <asp:TextBox ID="txtViewSIFromDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calViewSIFromDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtViewSIFromDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeViewSIFromDate" runat="server" TargetControlID="txtViewSIFromDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                                <td class="content-body-panel-td3 lblBold11">To Date</td>
                                                <td class="content-body-panel-td4">
                                                    <asp:TextBox ID="txtViewSIToDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calViewSIToDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtViewSIToDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeViewSIToDate" runat="server" TargetControlID="txtViewSIToDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Sales Invoice Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewSINumber" runat="server" CssClass="txtInputShortNumber"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteViewSINumber" runat="server" TargetControlID="txtViewSINumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Reference Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewSIReferenceNo" runat="server" CssClass="txtInputShort" MaxLength="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnLoadViewSI" runat="server" Text="Load" ToolTip="Load View Docs" CssClass="btnShort" OnClientClick="return IsViewSIValid();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="Panel2" runat="server" Width="700px">
                                                        <div class="gvwSearch" align="center">
                                                            <asp:GridView ID="gvwViewSI" runat="server"
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
                                                                    <asp:TemplateField HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="Center" >
                                                                        <ItemTemplate>
                                                                            <asp:RadioButton ID="radSelectViewSI" runat="server"
                                                                                Enabled='<%# IIf(Eval("si_print_status").ToString() = "CANCELLED", False, True)%>'
                                                                                GroupName="SelectDoc"
                                                                                AutoPostBack="true"
                                                                                OnCheckedChanged="radSelectViewSI_CheckedChanged" />
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
                                                    <asp:Button ID="btnViewSIsClose" runat="server" Text="Close" CssClass="btnShort" CausesValidation="false" OnClientClick="return CloseModal();" />
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
            <asp:ModalPopupExtender ID="mpeViewSIs" runat="server"
                TargetControlID="dummyViewSIs"
                PopupControlID="pnlViewSIs"
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
                            <asp:DropDownList ID="ddlCancellationReason" runat="server" CssClass="ddlLong" Enabled="true"></asp:DropDownList>
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
                            <asp:Button ID="btnConfirmYes" runat="server" Text="Yes" OnClientClick="return CancelReason();"
                                CssClass="btnShort" />
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
