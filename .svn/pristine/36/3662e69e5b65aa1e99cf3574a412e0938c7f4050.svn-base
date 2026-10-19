<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="PaymentBatchPremiumRelated.aspx.vb" Inherits="Cocolife.UI.OCS.PaymentBatchPremiumRelated"
    Title="Online Collection System (Payment : Premium Related)" %>

<%@ MasterType VirtualPath="~/OCS.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <script type="text/javascript" language="javascript">

        var ModalProgress = '<%=mpeProgress.ClientID%>';
        var ModalConfirm = '<%=mpeConfirm.ClientID%>';

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

    </script>

    <asp:UpdatePanel ID="upPaymentBatchPremiumRelated" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="content">
                <div id="content-header-paymentbatchpremiumrelated" class="content-header"></div>
                <div id="content-body">

                    <!-- PAYMENT DETAILS -->
                    <asp:Panel ID="pnlPaymentDetails" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-header">Payment Details</div>
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">Batch ID</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtBatchID" runat="server" CssClass="txtInputShort"></asp:TextBox>
                                        <asp:ImageButton ID="ibtnSearchBatch" runat="server" CssClass="ibtn ibtnSearch" ImageUrl="~/Images/icons/search.gif" ToolTip="Search Batch ID" Visible="False" />
                                        <asp:ImageButton ID="ibtnClearBatch" runat="server" ImageUrl="~/Images/icons/eraser.png" CssClass="ibtn ibtnEraser" CausesValidation="false" ToolTip="Clear Batch ID" Visible="False" />
                                        <asp:ImageButton ID="ibtnViewBatch" runat="server" ImageUrl="~/Images/icons/view.png" CssClass="ibtn ibtnView" CausesValidation="false" ToolTip="View Batch List" />
                                    </td>
                                    <td class="content-body-panel-td3 lblBold11">OPR Date</td>
                                    <td class="content-body-panel-td4">
                                        <asp:TextBox ID="txtOPRDate" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
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
                                            <asp:Panel ID="pnlSourceSite" runat="server" DefaultButton="ibtnVerifySourceSite" >
                                                <asp:DropDownList ID="ddlSourceSite" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                                <asp:ImageButton ID="ibtnVerifySourceSite" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Source Site" Visible="False" />
                                                <asp:ImageButton ID="ibtnClearSourceSite" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Source Site" Visible="False" />
                                            </asp:Panel>
                                        </td>
                                        <%--<td class="content-body-panel-td3"></td>
                                        <td class="content-body-panel-td4"></td>--%>
                                    </tr>
                                    <tr>
                                        <td class="content-body-panel-td1 lblBold11">Currency Of Payment</td>
                                        <td class="content-body-panel-td2">
                                            <asp:DropDownList ID="ddlOPRCurrency" runat="server" CssClass="ddlShort"></asp:DropDownList>
                                        </td>
                                        <td class="content-body-panel-td3"></td>
                                        <td class="content-body-panel-td4"></td>
                                    </tr>
                                    <tr>
                                        <td class="content-body-panel-td1 lblBold11">Non-Prem Partner</td>
                                        <td class="content-body-panel-td2">
                                            <asp:DropDownList ID="ddlNonPremium" runat="server" CssClass="ddlShort"></asp:DropDownList>
                                        </td>
                                        <td class="content-body-panel-td3"></td>
                                        <td class="content-body-panel-td4"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkWithAPR" runat="server" CssClass="chkBold11" Text="with APR" AutoPostBack="true" />
                                        </td>
                                        <td colspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Remarks</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtOPRRemarks" runat="server" CssClass="txtInputTextArea2" MaxLength="60"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Panel runat="server" ScrollBars="Auto" Width="100%">
                                                <asp:GridView ID="gvwOprList" runat="server"
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
                                                        <asp:BoundField HeaderText="BatchID" DataField="OprId" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                        <asp:BoundField HeaderText="OR Number" DataField="OprNumber" ItemStyle-HorizontalAlign="Right"/>
                                                        <asp:BoundField HeaderText="POC ID" DataField="PocId"/>
                                                        <asp:BoundField HeaderText="Name" DataField="Name"/>
                                                        <asp:BoundField HeaderText="Policy Name" DataField="PolicyName"/>
                                                        <asp:BoundField HeaderText="Gross" DataField="Gross" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"/>
                                                        <asp:BoundField HeaderText="Life" DataField="Life" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"/>
                                                        <asp:BoundField HeaderText="Non-Life" DataField="NonLife" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"/>
                                                        <asp:BoundField HeaderText="NL Premium" DataField="NLPremium" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"/>
                                                        <asp:BoundField HeaderText="DST" DataField="DST" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"/>
                                                        <asp:BoundField HeaderText="Prem Tax" DataField="PremTax" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"/>
                                                        <asp:BoundField HeaderText="LGT" DataField="LGT" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"/>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="height: 5px;"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td class="lblBold11">Total Amount</td>
                                        <td>
                                            <asp:TextBox ID="txtOprTotalAmount" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                               
                    <!-- PAYMENT TYPE DETAILS -->
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
                                                    <td class="content-body-accordion-td2">
                                                        <asp:DropDownList ID="ddlOPRPaymentType" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                    <td class="content-body-accordion-td3"></td>
                                                    <td class="content-body-accordion-td4"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <!-- Cash Details -->
                                                        <asp:Panel ID="pnlCashDetails" runat="server" Visible="False">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="content-body-accordion-td1 lblBold11">Cash Amount</td>
                                                                    <td class="content-body-accordion-td2">
                                                                        <asp:Panel runat="server" DefaultButton="ibtnAddCash">
                                                                            <asp:TextBox ID="txtOPRCashAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                                            <asp:FilteredTextBoxExtender ID="fteOPRCashAmount" runat="server" TargetControlID="txtOPRCashAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
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
                                                                        <%--<asp:TextBox ID="txtCheckBankName" runat="server" CssClass="txtInputLong" MaxLength="15"></asp:TextBox>--%>
                                                                        <asp:DropDownList ID="ddlCheckBankName" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                                                    </td>
                                                                    <div id="divOtherBank" runat="server" visible="false">
                                                                        <td class="lblBold11">Others:</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtOtherBank" runat="server" CssClass="txtInputLong" MaxLength="15"></asp:TextBox>
                                                                        </td>
                                                                    </div>
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
                                                                            OnCheckedChanged="radSelectPayTypeDetails_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="ID" DataField="PaymentTypeId" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Payment Type" DataField="PaymentType" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Check Number" DataField="CHECKNUMBER" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Bank" DataField="BANK" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Branch" DataField="BRANCH" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Reference Number" DataField="ReferenceNumber" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
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

                    <!-- APR DETAILS -->
                    <asp:Accordion ID="accAPRDetails" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue" Visible="false">
                        <Panes>
                            <asp:AccordionPane ID="apnAPRDetails" runat="server">
                                <Header>APR Details</Header>
                                <Content>
                                    <asp:Panel ID="pnlAPRDetails"  runat="server">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">APR Number</td>
                                                    <td class="content-body-accordion-td2">
                                                        <asp:TextBox ID="txtAPRNumber" runat="server" CssClass="txtInputShortNumber" MaxLength="10"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteAPRNumber" runat="server" TargetControlID="txtAPRNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td class="content-body-accordion-td3 lblBold11">APR Date</td>
                                                    <td class="content-body-accordion-td4">
                                                        <asp:TextBox ID="txtAPRDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                        <asp:CalendarExtender ID="calAPRDate" runat="server" CssClass="cal_Theme1" TargetControlID="txtAPRDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                        <asp:MaskedEditExtender ID="meeAPRDate" runat="server" TargetControlID="txtAPRDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">APR Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAPRAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteAPRAmount" runat="server" TargetControlID="txtAPRAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td></td>
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
                        <asp:Button ID="btnReceiptAddNew" runat="server" Text="Add New" CssClass="btnShort" />
                        <asp:Button ID="btnReceiptSave" runat="server" Text="Save" CssClass="btnShort" Enabled="false" />
                        <asp:Button ID="btnReceiptPreview" runat="server" Text="Preview" CssClass="btnShort" Enabled="false" />
                        <asp:Button ID="btnReceiptPrint" runat="server" Text="Print OPR" CssClass="btnShort" Enabled="false" />
                        <asp:Button ID="btnReceiptCancel" runat="server" Text="Cancel OPR" CssClass="btnShort" Enabled="false" />
                        <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="btnShort" />
                    </asp:Panel>

                    <!-- HIDDEN -->
                    <asp:Panel ID="pnlHiddenFields" runat="server" CssClass="panel-hidden">
                        <!-- PAYMENT DETAILS -->
                        <asp:HiddenField ID="hdnCashTotalAmount" runat="server" />
                        <asp:HiddenField ID="hdnCheckTotalAmount" runat="server" />
                        <asp:HiddenField ID="hdnPaymentTypeID" runat="server" />
                        <asp:HiddenField ID="hdnPrevPayType" runat="server" />
                        <!-- TAG -->
                        <asp:HiddenField ID="hdnIsPreviewTag" runat="server" />
                        <asp:HiddenField ID="hdnPaymentTypeTag" runat="server" />
                        <asp:HiddenField ID="hdnCashPaymentTag" runat="server" />
                        <asp:HiddenField ID="hdnCheckPaymentTag" runat="server" />
                        <asp:HiddenField ID="hdnWithAPRTag" runat="server" />
                        <asp:HiddenField ID="hdnConfirmTag" runat="server"/>
                        <asp:HiddenField ID="hdnConfirmCaller" runat="server"/>
                        <asp:HiddenField ID="hdnClickStateTag" runat="server" />
                        <asp:HiddenField ID="hdnDocPrinted" runat="server" />
                        <asp:HiddenField ID="hdnDocSaveState" runat="server" />
                        <asp:HiddenField ID="hdnIsSourceSiteLocked" runat="server" />
                        <asp:HiddenField ID="hdnReportType" runat="server" />
                        <asp:HiddenField ID="hdnReceiptByCode" runat="server" />
                        <asp:HiddenField ID="hdnReceiptById" runat="server" />
                        <!-- REPORT DETAILS -->
                        <asp:HiddenField ID="hdnRptParamString" runat="server" />
                    </asp:Panel>

                </div>
                <div id="content-footer"></div>
            </div>

            <!-- VIEW OPRs -->
            <input id="dummyViewBatch" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlViewBatch" runat="server" CssClass="panel-modal-740" DefaultButton="btnLoadViewBatch" Style="">
                <asp:UpdatePanel ID="upViewBatch" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mhViewBatch"></td>
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
                                                <td class="lblBold11">Batch ID</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewBatchID" runat="server" CssClass="txtInputShortNumber"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteViewBatchID" runat="server" TargetControlID="txtViewBatchID" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnLoadViewBatch" runat="server" Text="Load" ToolTip="Load View OPRs" CssClass="btnShort" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel runat="server" Width="700px">
                                                        <div class="gvwSearch" align="center">
                                                            <asp:GridView ID="gvwViewBatch" runat="server"
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
                                                                            <asp:RadioButton ID="radSelectViewBatch" runat="server"
                                                                                GroupName="SelectOpr"
                                                                                AutoPostBack="true"
                                                                                OnCheckedChanged="radSelectViewBatch_CheckedChanged" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Batch ID" DataField="batch_id" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Policy Name" DataField="policy_name" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Gross Amount" DataField="amount" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                                                    <asp:BoundField HeaderText="Status" DataField="STATUS" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Date" DataField="post_date" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"  DataFormatString="{0:d}"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="secopr" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"/>
                                                                    <asp:BoundField HeaderText="Created By ID" DataField="secpid" HeaderStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden"/>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: right;">
                                                    <asp:Button ID="btnViewBatchClose" runat="server" Text="Close" CssClass="btnShort" CausesValidation="false" />
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
            <asp:ModalPopupExtender ID="mpeViewBatch" runat="server"
                TargetControlID="dummyViewBatch"
                PopupControlID="pnlViewBatch"
                BackgroundCssClass="modal"
                Enabled="true">
            </asp:ModalPopupExtender>

            <!-- CONFIRMATION MESSAGE -->
            <asp:LinkButton  id="dummyConfirm" style="display: none" runat = "server" />
            <asp:Panel ID="pnlConfirm" runat="server" Width="300px" 
                CssClass="panel-messagebox" Style="display: none" DefaultButton="btnConfirmNo">
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
            <asp:Panel ID="pnlMessage" runat="server" CssClass="panel-messagebox" DefaultButton="btnMessageOk" Style="display: none">
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
                    <asp:Button ID="btnMessageOk" runat="server" Text="Ok" CssClass="btnShort" CausesValidation="false" />
                </div>
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
            <%--<asp:AsyncPostBackTrigger ControlID="ddlTransactionType" EventName="SelectedIndexChanged" />--%>
            <%--<asp:AsyncPostBackTrigger ControlID="ddlOPRPaymentType" EventName="SelectedIndexChanged" />--%>
            
            <asp:AsyncPostBackTrigger ControlID="chkWithAPR" EventName="CheckedChanged" />

            <asp:AsyncPostBackTrigger ControlID="btnMessageOk" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
