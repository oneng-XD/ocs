<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="PaymentNonPremiumRelated.aspx.vb" Inherits="Cocolife.UI.OCS.PaymentNonPremiumRelated"
    Title="Online Collection System (Payment : Non-Premium Related)" %>

<%@ MasterType VirtualPath="~/OCS.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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

        function clickVerifyGrossAmount() {
            $('#<%=ibtnVerifyGrossAmount.ClientID%>').trigger('click');
        }

    </script>

    <asp:UpdatePanel ID="upPaymentNonPremiumRelated" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="content">
                <div id="content-header-paymentnonpremiumrelated" class="content-header"></div>
                <div id="content-body">

                    <!-- PAYMENT DETAILS -->
                    <asp:Panel ID="pnlPaymentDetails" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-header">Payment Details</div>
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">Invoice Number</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtORNumber" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        <asp:ImageButton ID="ibtnViewORs" runat="server" ImageUrl="~/Images/icons/view.png" CssClass="ibtn ibtnView" CausesValidation="false" ToolTip="View ORs" />
                                    </td>
                                    <td class="content-body-panel-td3 lblBold11">Invoice Date</td>
                                    <td class="content-body-panel-td4">
                                        <asp:TextBox ID="txtORDate" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <asp:Panel ID="pnlPaymentDetails1" runat="server">
                            <div class="content-body-panel-detail">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="content-body-panel-td1 lblBold11">Source Site</td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlSourceSite" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                            <asp:ImageButton ID="ibtnVerifySourceSite" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Source Site" Visible="False" />
                                            <asp:ImageButton ID="ibtnClearSourceSite" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Source Site" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Transaction Type</td>
                                        <td>
                                            <asp:DropDownList ID="ddlTransactionType" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Gross Amount</td>
                                        <td>
                                            <asp:Panel ID="pnlGrossAmount" runat="server" DefaultButton="ibtnVerifyGrossAmount">
                                                <asp:TextBox ID="txtORGrossAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14" OnTextChanged="txtORGrossAmount_TextChanged" OnBlur="clickVerifyGrossAmount();"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="fteORGrossAmount" runat="server" TargetControlID="txtORGrossAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                <asp:ImageButton ID="ibtnVerifyGrossAmount" runat="server" CausesValidation="false" CssClass="ibtn ibtnAccept" ImageUrl="~/Images/icons/accept.png" ToolTip="Verify Gross Amount" Visible="False" />
                                                <asp:ImageButton ID="ibtnClearGrossAmount" runat="server" CausesValidation="false" CssClass="ibtn ibtnEraser" ImageUrl="~/Images/icons/eraser.png" ToolTip="Clear Gross Amount" Visible="False" />
                                            </asp:Panel>
                                        </td>
                                        <td class="content-body-panel-td3 lblBold11">Currency Of Payment</td>
                                        <td class="content-body-panel-td4">
                                            <asp:DropDownList ID="ddlORCurrency" runat="server" CssClass="ddlShort"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkWithAPR" runat="server" CssClass="chkBold11" Text="with APR" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Remarks</td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtORRemarks" runat="server" CssClass="txtInputTextArea2" MaxLength="60"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </asp:Panel>

                    <br />

                    <!-- PAYMENT TYPE DETAILS -->
                    <asp:Accordion ID="accPaymentTypeDetails" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnPaymentTypeDetails" runat="server">
                                <Header>Payment Type Details</Header>
                                <Content>
                                    <asp:Panel ID="pnlPaymentTypeDetails" runat="server" DefaultButton ="btnPaymentTypeAdd">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">Payment Type</td>
                                                    <td class="content-body-accordion-td2">
                                                        <asp:DropDownList ID="ddlORPaymentType" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
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
                                                                            <asp:TextBox ID="txtORCashAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                                            <asp:FilteredTextBoxExtender ID="fteOPRCashAmount" runat="server" TargetControlID="txtORCashAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
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
                                                                        <asp:DropDownList ID="ddlCheckBankName" runat="server" CssClass="ddlLong" AutoPostBack="False"></asp:DropDownList>
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
                                                        <asp:Button ID="btnPaymentTypeAdd" runat="server" Text="Add" AutoPostBack="true" CssClass="btnShort" />
                                                        <asp:Button ID="btnPaymentTypeClear" runat="server" Text="Clear" AutoPostBack="true" CssClass="btnShort" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
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
                                                                            Visible="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="ID" DataField="PaymentTypeId" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Payment Type" DataField="PaymentType" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Check Number" DataField="CHECKNUMBER" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Bank" DataField="BANK" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Branch" DataField="BRANCH" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Remarks" DataField="REMARKS" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Reference Number" DataField="ReferenceNumber" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:TemplateField HeaderStyle-Width="10px" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibtnPaymentTypeDetailsDelete" runat="server"
                                                                            ImageUrl="images/icons/delete.png"
                                                                            CommandName="DELETE"
                                                                            ToolTip="Delete Payment Type Detail" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="5px" ItemStyle-Width="5px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>&nbsp;</ItemTemplate>
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

                    <!-- OTHER DETAILS -->
                    <asp:Accordion ID="accOtherDetails" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnOtherDetails" runat="server">
                                <Header>Other Details</Header>
                                <Content>
                                    <asp:Panel ID="pnlOtherDetails" runat="server">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <!-- NON-GPA -->
                                                <%-- <div id="divOtherDetails" runat="server" ></div>--%>
                                                <tr>
                                                    <td class="lblBold11">Payor</td>
                                                    <td>
                                                        <asp:Panel ID="pnlLoadPayorID" runat="server" DefaultButton="ibtnSearchPayor">
                                                            <asp:TextBox ID="txtPayorID" runat="server" CssClass="txtInputShortNumber" MaxLength="15"></asp:TextBox>
                                                            <%--CssClass="txtReadOnlyShort" ReadOnly="true" --%>
                                                            <asp:FilteredTextBoxExtender ID="ftePayorID" runat="server" TargetControlID="txtPayorID" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                            <asp:ImageButton ID="ibtnSearchPayor" runat="server" ImageUrl="~/Images/icons/search.gif" CssClass="ibtn ibtnSearch" ToolTip="Search Payor" />
                                                            <asp:ImageButton ID="ibtnAddNewPayor" runat="server" ImageUrl="~/Images/icons/add_person.png" CssClass="ibtn ibtnAddPerson" ToolTip="Add New Payor" />
                                                            <asp:ImageButton ID="ibtnClearPayor" runat="server" ImageUrl="~/Images/icons/eraser.png" CssClass="ibtn ibtnEraser" CausesValidation="false" ToolTip="Clear Payor" />
                                                        </asp:Panel>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPayorName" runat="server" CssClass="txtReadOnlyLong" ReadOnly="true" TabIndex="-1" Visible="true"></asp:TextBox>
                                                        <asp:TextBox ID="txtNewPayorName" runat="server" CssClass="txtInputLong" TabIndex="-1" Visible="false"></asp:TextBox>

                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr></tr>
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">Depository Account</td>
                                                    <td class="content-body-accordion-td2">
                                                        <asp:DropDownList ID="ddlDepositoryAccount" runat="server" CssClass="ddlLong" AutoPostBack="True"></asp:DropDownList>
                                                        <!--OnSelectedIndexChanged="ddlDepositoryAccount_SelectedIndexChanged" -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">GL Code</td>
                                                    <td>
                                                        <asp:TextBox ID="txtGLCode" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>

                    <!-- COLUMBARIUM PAYMENT DETAILS -->
                    <asp:Accordion ID="accColumbarium" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnColumbarium" runat="server">
                                <Header>Columbary Payment Details</Header>
                                <Content>
                                    <asp:Panel ID="pnlColumbarium" runat="server">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lblBold11">Vault</td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlVault" runat="server" CssClass="ddlShort" AutoPostBack="True"></asp:DropDownList>
                                                    </td>

                                                    <%--<td></td>--%>
                                                    <%--<td colspan="2"></td>--%>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="chkInitialFee" runat="server" CssClass="chkBold11" Text="Initial Payment?" AutoPostBack="true" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Level</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtLevel" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td class="lblBold11">Payor Type</td>
                                                    <td colspan="2">
                                                        <asp:RadioButton ID="radRegular" runat="server"
                                                            Text="Regular" GroupName="SelectPayorType"
                                                            OnCheckedChanged="radRegular_CheckedChanged"
                                                            AutoPostBack="true" />
                                                        <asp:RadioButton ID="radEmployee" runat="server"
                                                            Text="Employee" GroupName="SelectPayorType"
                                                            OnCheckedChanged="radEmployee_CheckedChanged"
                                                            AutoPostBack="true" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Block</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtBlock" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>

                                                    <td class="lblBold11">Reservation Fee</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtColRsrv" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        <%--<asp:FilteredTextBoxExtender ID="fteColRsrv" runat="server" TargetControlID="txtColRsrv" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>--%>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Column</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtColumn" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td class="lblBold11">Discount</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtColDscnt" runat="server" CssClass="txtInputShortNumber" MaxLength="14" TabIndex="-1"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteColDscnt" runat="server" TargetControlID="txtColDscnt" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Product/Floor</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtProduct" runat="server" CssClass="txtReadOnlyLong" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>

                                                    <td class="lblBold11">VAT</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtColVAT" runat="server" CssClass="txtInputShortNumber" MaxLength="14" TabIndex="-1"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteColVAT" runat="server" TargetControlID="txtColVAT" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Lot List Price</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtLotListPrice" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>

                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <!-- ------------------------------------------------------------------------------------------ -->
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>

                    <!-- Invoice DETAILS -->
                    <asp:Accordion ID="accORDetails" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnORDetails" runat="server">
                                <Header>Invoice Details</Header>
                                <Content>
                                    <asp:Panel ID="pnlORDetails" runat="server" DefaultButton="btnOrDtlAdd">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lblBold11">Transaction</td>
                                                    <td colspan="3">
                                                        <asp:DropDownList ID="ddlORTransaction" runat="server" CssClass="ddlLong2"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">Amount</td>
                                                    <td class="content-body-accordion-td2">
                                                        <asp:TextBox ID="txtORAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteORAmount" runat="server" TargetControlID="txtORAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td class="content-body-accordion-td3"></td>
                                                    <td class="content-body-accordion-td4"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="content-body-accordion-button">
                                                        <asp:Button ID="btnOrDtlAdd" runat="server" Text="Add" CssClass="btnShort" />
                                                        <asp:Button ID="btnOrDtlClear" runat="server" Text="Clear" CssClass="btnShort" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="gvwORDetails" runat="server"
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
                                                                        <asp:RadioButton ID="radSelectORDetails" runat="server"
                                                                            GroupName="SelectPaymentType"
                                                                            AutoPostBack="true" OnCheckedChanged="radSelectORDetails_CheckedChanged" Visible="false" />
                                                                        <%--OnCheckedChanged="radSelectORDetails_CheckedChanged"--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="ID" DataField="ReceiptID" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Transaction Code" DataField="TrnxCode" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField HeaderText="Code" DataField="ActType" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Description" DataField="TrnxDesc" ItemStyle-HorizontalAlign="Left" />
                                                                <%--<asp:BoundField HeaderText="Due Date" DataField="DueDate" DataFormatString="{0:MM/dd/yyyy}" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />--%>
                                                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="right" />
                                                                <asp:BoundField HeaderText="Receipt Type" DataField="ReceiptType" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibtnORDetailsDelete" runat="server"
                                                                            ImageUrl="images/icons/delete.png"
                                                                            CommandName="DELETE"
                                                                            ToolTip="Delete Invoice Detail" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="5px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>&nbsp;</ItemTemplate>
                                                                </asp:TemplateField>
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
                                                    <td class="lblBold11">Total Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtORTotalAmount" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                </tr>
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
                                    <asp:Panel ID="pnlParticulars" runat="server" DefaultButton="btnParticularsAdd">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="lblBold11">Particular</td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtParticularsRemark" runat="server" CssClass="txtInputLong2" MaxLength="150"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">Amount</td>
                                                    <td class="content-body-accordion-td2">
                                                        <%--<asp:TextBox ID="txtParticularsAmount" runat="server" CssClass="txtInputLong2" MaxLength="60"></asp:TextBox>--%>
                                                        <asp:TextBox ID="txtParticularsAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteParticularsAmount" runat="server" TargetControlID="txtParticularsAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>

                                                    </td>
                                                    <td class="content-body-accordion-td3"></td>
                                                    <td class="content-body-accordion-td4"></td>

                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="content-body-accordion-button">
                                                        <asp:Button ID="btnParticularsAdd" runat="server" Text="Add" AutoPostBack="true" CssClass="btnShort" />
                                                        <asp:Button ID="btnParticularsClear" runat="server" Text="Clear" AutoPostBack="true" CssClass="btnShort" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 5px;"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="gvwParticulars" runat="server"
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
                                                                        <asp:RadioButton ID="radSelectParticulars" runat="server"
                                                                            GroupName="SelectParticulars"
                                                                            AutoPostBack="true" OnCheckedChanged="radSelectParticulars_CheckedChanged" Visible="false" />
                                                                        <%--OnCheckedChanged="radSelectORDetails_CheckedChanged"--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:BoundField HeaderText="ID" DataField="ReceiptID" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                            <asp:BoundField HeaderText="Trnx Code" DataField="TrnxCode" ItemStyle-HorizontalAlign="Right" />
                                                            <asp:BoundField HeaderText="Code" DataField="ActType" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />--%>
                                                                <asp:BoundField HeaderText="ID" DataField="ParticularsID" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Particulars" DataField="ParticularItem" ItemStyle-HorizontalAlign="Left" />
                                                                <%--<asp:BoundField HeaderText="Due Date" DataField="DueDate" DataFormatString="{0:MM/dd/yyyy}" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />--%>
                                                                <asp:BoundField HeaderText="Amount" DataField="ItemAmount" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="right" />
                                                                <%--<asp:BoundField HeaderText="Receipt Type" DataField="ReceiptType" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />--%>
                                                                <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibtnParticularsDelete" runat="server"
                                                                            ImageUrl="images/icons/delete.png"
                                                                            CommandName="DELETE"
                                                                            ToolTip="Delete Particulars" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="5px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>&nbsp;</ItemTemplate>
                                                                </asp:TemplateField>
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

                    <!-- APR DETAILS -->
                    <asp:Accordion ID="accAPRDetails" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue" Visible="false">
                        <Panes>
                            <asp:AccordionPane ID="apnAPRDetails" runat="server">
                                <Header>APR Details</Header>
                                <Content>
                                    <asp:Panel ID="pnlAPRDetails" runat="server">
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

                    <!-- VAT COMPUTATION -->
                    <asp:Accordion ID="accVATComputation" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnVATComputation" runat="server">
                                <Header>VAT Computation</Header>
                                <Content>
                                    <asp:Panel ID="pnlVATComputation" runat="server" DefaultButton="dummyCalculateVat">
                                        <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">VATable Collection</td>
                                                    <td class="content-body-accordion-td2">
                                                        <asp:TextBox ID="txtVATableCollection" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteVATableCollection" runat="server" TargetControlID="txtVATableCollection" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td class="content-body-accordion-td3"></td>
                                                    <td class="content-body-accordion-td4"></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Non-VAT Collection</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNonVATCollection" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteNonVATCollection" runat="server" TargetControlID="txtNonVATCollection" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">VAT-Exempt Collection</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATExemptCollection" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteVATExemptCollection" runat="server" TargetControlID="txtVATExemptCollection" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">VAT Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATAmount" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteVATAmount" runat="server" TargetControlID="txtVATAmount" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
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
                                                    <td class="lblBold11">Total Collection</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATTotalCollection" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Less: Withholding Tax</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATWithholdingTax" runat="server" CssClass="txtInputShortNumber" MaxLength="14"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="fteVATWithholdingTax" runat="server" TargetControlID="txtVATWithholdingTax" FilterType="Custom, Numbers" ValidChars=".,"></asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Amount Net of WTax</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATAmountNetWTax" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td><asp:Button ID="dummyCalculateVat" runat="server" style="display: none;"/></td>
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
                        <asp:Button ID="btnReceiptPrint" runat="server" Text="Print OR" CssClass="btnShort" Enabled="false" />
                        <asp:Button ID="btnReceiptCancel" runat="server" Text="Cancel OR" CssClass="btnShort" Enabled="false" />
                        <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="btnShort" />
                        <%--<asp:Label ID="lblButtonDivider" runat="server">&nbsp;&nbsp;&nbsp;</asp:Label>--%>
                    </asp:Panel>

                    <!-- HIDDEN -->
                    <asp:Panel ID="pnlHiddenFields" runat="server" CssClass="panel-hidden">
                        <!-- PAYMENT DETAILS -->
                        <asp:HiddenField ID="hdnCashTotalAmount" runat="server" />
                        <asp:HiddenField ID="hdnCheckTotalAmount" runat="server" />
                        <asp:HiddenField ID="hdnPaymentTypeID" runat="server" />
                        <asp:HiddenField ID="hdnPrevPayType" runat="server" />
                        <!-- POLICY DETAILS -->
                        <asp:HiddenField ID="hdnStatus" runat="server" />
                        <asp:HiddenField ID="hdnLstDueBill" runat="server" />
                        <!-- Invoice DETAILS -->
                        <asp:HiddenField ID="hdnORDetailID" runat="server" />
                        <asp:HiddenField ID="hdnORTransactionCode" runat="server" />
                        <asp:HiddenField ID="hdnORTransactionType" runat="server" />
                        <asp:HiddenField ID="hdnORTransactionDesc" runat="server" />
                        <asp:HiddenField ID="hdnORTransactionVat" runat="server" />
                        <!-- TAG -->
                        <asp:HiddenField ID="hdnIsPreviewTag" runat="server" />
                        <asp:HiddenField ID="hdnPaymentTypeTag" runat="server" />
                        <asp:HiddenField ID="hdnCashPaymentTag" runat="server" />
                        <asp:HiddenField ID="hdnCheckPaymentTag" runat="server" />
                        <asp:HiddenField ID="hdnAllowedPaymentType" runat="server" />
                        <asp:HiddenField ID="hdnWithAPRTag" runat="server" />
                        <asp:HiddenField ID="hdnOtherDetailsTag" runat="server" />
                        <!--<asp:HiddenField ID="hdnGpaPaymentTag" runat="server" />-->
                        <asp:HiddenField ID="hdnORDtlTag" runat="server" />
                        <asp:HiddenField ID="hdnORVatTag" runat="server" />
                        <asp:HiddenField ID="hdnSearchAgentTag" runat="server" />
                        <%--<asp:HiddenField ID="hdnPolicyNumberTag" runat="server" />--%>
                        <asp:HiddenField ID="hdnAgentIDTag" runat="server" />
                        <asp:HiddenField ID="hdnPayorIDTag" runat="server" />
                        <asp:HiddenField ID="hdnConfirmCaller" runat="server" />
                        <asp:HiddenField ID="hdnConfirmTag" runat="server" />
                        <asp:HiddenField ID="hdnClickStateTag" runat="server" />
                        <asp:HiddenField ID="hdnDocPrinted" runat="server" />
                        <asp:HiddenField ID="hdnDocSaveState" runat="server" />
                        <asp:HiddenField ID="hdnColumbariumTag" runat="server" />
                        <asp:HiddenField ID="hdnParticularsTag" runat="server" />
                        <asp:HiddenField ID="hdnIsSourceSiteLocked" runat="server" />
                        <asp:HiddenField ID="hdnIsGrossAmountLocked" runat="server" />
                        <asp:HiddenField ID="hdnReceiptByCode" runat="server" />
                        <asp:HiddenField ID="hdnReceiptById" runat="server" />
                        <!-- AGENT DETAILS -->
                        <asp:HiddenField ID="hdnAgentLastName" runat="server" />
                        <asp:HiddenField ID="hdnAgentFirstName" runat="server" />
                        <asp:HiddenField ID="hdnAgentMiddleName" runat="server" />
                        <!-- AGENCY DETAILS -->
                        <!--<asp:HiddenField ID="hdnAgencyLastName" runat="server" />
                        <asp:HiddenField ID="hdnAgencyFirstName" runat="server" />
                        <asp:HiddenField ID="hdnAgencyMiddleName" runat="server" /> -->
                        <!-- PAYOR DETAILS -->
                        <asp:HiddenField ID="hdnPayorName" runat="server" />
                        <asp:HiddenField ID="hdnPayorLastName" runat="server" />
                        <asp:HiddenField ID="hdnPayorFirstName" runat="server" />
                        <asp:HiddenField ID="hdnPayorMiddleName" runat="server" />
                        <asp:HiddenField ID="hdnPayorSuffix" runat="server" />
                        <asp:HiddenField ID="hdnPayorTitle" runat="server" />
                        <asp:HiddenField ID="hdnPayorPlaceOfBirth" runat="server" />
                        <asp:HiddenField ID="hdnPayorSex" runat="server" />
                        <asp:HiddenField ID="hdnPayorDateOfBirth" runat="server" />
                        <!-- ADD PAYOR DETAILS -->
                        <asp:HiddenField ID="hdnPayorAddName" runat="server" />
                        <!-- REPORT DETAILS -->
                        <asp:HiddenField ID="hdnRptParamString" runat="server" />
                        <!-- PARTICULARS -->
                        <asp:HiddenField ID="hdnParticularsID" runat="server" />
                        <!-- IBP 2/23 -->
                        <asp:HiddenField ID="hdnParticularsTotalAmount" runat="server" />
                        <!-- IBP 2/22 -->
                        <!-- OTHER DETAILS -->
                        <asp:HiddenField ID="hdnDepositoryAccount" runat="server" />
                        <!-- IBP 3/02 -->
                        <!-- COLUMBARIUM -->
                        <!--<asp:HiddenField ID="hdnVault" runat="server" /> -->
                    </asp:Panel>


                </div>
                <div id="content-footer"></div>
            </div>

            <!-- VIEW ORs -->
            <input id="dummyViewORs" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlViewORs" runat="server" CssClass="panel-modal-740" DefaultButton="btnLoadViewOr" Style="">
                <asp:UpdatePanel ID="upViewORs" runat="server" RenderMode="Inline" UpdateMode="Conditional">
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
                                                <td class="lblBold11">OR Number</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewORNumber" runat="server" CssClass="txtInputShortNumber"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteViewORNumber" runat="server" TargetControlID="txtViewORNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Payor Name</td>
                                                <td>
                                                    <asp:TextBox ID="txtViewPayorName" runat="server" CssClass="txtInputLong"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnLoadViewOr" runat="server" Text="Load" ToolTip="Load View ORs" CssClass="btnShort" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div class="gvwSearch">
                                                        <asp:GridView ID="gvwViewOr" runat="server"
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
                                                            Width="740px">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButton ID="radSelectViewOr" runat="server"
                                                                            GroupName="SelectOr"
                                                                            AutoPostBack="true"
                                                                            OnCheckedChanged="radSelectViewOr_CheckedChanged" />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="OR#" DataField="DOCNUMBER" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Payor Name" DataField="payor_name" ItemStyle-Width="35%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Status" DataField="STATUS" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Amount" DataField="AMOUNT" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Date" DataField="TRNDAT" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"  DataFormatString="{0:d}"/>
                                                                <asp:BoundField HeaderText="Created By" DataField="secopr" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"/>
                                                                <asp:BoundField HeaderText="Created By ID" DataField="secpid" HeaderStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden"/>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: right;">
                                                    <asp:Button ID="btnViewORsClose" runat="server" Text="Close" CssClass="btnShort" CausesValidation="false" />
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
            <asp:ModalPopupExtender ID="mpeViewORs" runat="server"
                TargetControlID="dummyViewORs"
                PopupControlID="pnlViewORs"
                BackgroundCssClass="modal"
                Enabled="true">
            </asp:ModalPopupExtender>

            <!-- SEARCH PERSON [PAYOR | INSURED | BENEFICIARIES] -->
            <input id="dummySearchPerson" type="button" style="display: none" runat="server" />

            <!-- ADD PERSON [PAYOR | INSURED | BENEFICIARIES] -->
            <input id="dummyAddPerson" type="button" style="display: none" runat="server" />

            <!-- SEARCH PAYOR -->
            <input id="dummySearchPayor" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlSearchPayor" runat="server" CssClass="panel-modal-740" DefaultButton="btnSearchPayorSearch" Style="">
                <asp:UpdatePanel ID="upSearchPayor" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mhSearchPayor"></td>
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
                                                <td style="width: 23%;" class="lblBold11">Payor Type</td>
                                                <td style="width: 27%;">
                                                    <asp:DropDownList ID="ddlSearchPayorType" runat="server"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 23%;" class="lblBold11">Payor ID</td>
                                                <td style="width: 27%;">
                                                    <asp:TextBox ID="txtSearchPayorID" runat="server"
                                                        CssClass="txtInputShortNumber"
                                                        MaxLength="15"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteSearchPayorID" runat="server"
                                                        TargetControlID="txtSearchPayorID"
                                                        FilterType="Numbers">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td style="width: 23%;"></td>
                                                <td style="width: 27%;"></td>
                                            </tr>
                                            <tr>
                                                <%--<asp:Panel id="pnlPayor1" runat="server" >--%>
                                                <td class="lblBold11">Payor Name</td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtSearchPayorName" runat="server"
                                                        CssClass="txtInputLong2"
                                                        MaxLength="60" Visible="true"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <%--<asp:Panel id="pnlPayor1" runat="server" >--%>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtAddPayorName" runat="server"
                                                        CssClass="txtInputTextArea2"
                                                        MaxLength="60" Visible="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnSearchPayorSearch" runat="server" Text="Search"
                                                        CssClass="btnShort"
                                                        CausesValidation="false" />
                                                    <asp:Button ID="btnSearchPayorClear" runat="server" Text="Clear"
                                                        CssClass="btnShort"
                                                        CausesValidation="false" />
                                                    <asp:Button ID="btnSearchPayorClose" runat="server" Text="Close"
                                                        CssClass="btnShort"
                                                        CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div class="gvwSearch">
                                                        <asp:GridView ID="gvwSearchPayor" runat="server"
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
                                                            Width="740px">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButton ID="radSelectPayor" runat="server"
                                                                            GroupName="SelectPayor"
                                                                            AutoPostBack="true" OnCheckedChanged="radSelectPayor_CheckedChanged" />

                                                                        <!-- OnCheckedChanged="radSelectPayor_CheckedChanged" -->
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="ID" DataField="PRSPID" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Name" DataField="PRSNME" ItemStyle-Width="55%" />
                                                                <asp:BoundField HeaderText="Type" DataField="PRSSEX" ItemStyle-Width="10%" />
                                                                <asp:BoundField HeaderText="Date of Birth" DataField="PRSDOB" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:MM/dd/yyyy}" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
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
            <asp:ModalPopupExtender ID="mpeSearchPayor" runat="server"
                TargetControlID="dummySearchPayor"
                PopupControlID="pnlSearchPayor"
                BackgroundCssClass="modal">
            </asp:ModalPopupExtender>

            <!-- SEARCH AGENT/SALES OFF/PROMO OFF -->
            <input id="dummySearchAgent" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlSearchAgent" runat="server" CssClass="panel-modal-740" DefaultButton="btnSearchAgentSearch" Style="">
                <asp:UpdatePanel ID="upSearchAgent" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mhSearchAgent"></td>
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
                                                <td style="width: 23%;" class="lblBold11">Agent ID</td>
                                                <td style="width: 27%;">
                                                    <asp:TextBox ID="txtSearchAgentID" runat="server"
                                                        CssClass="txtInputShortNumber"
                                                        MaxLength="15"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="ftxSearchAgentID" runat="server"
                                                        TargetControlID="txtSearchAgentID"
                                                        FilterType="Numbers">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td style="width: 23%;"></td>
                                                <td style="width: 27%;"></td>
                                            </tr>
                                            <tr>
                                                <td class="lblBold11">Agent Name</td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtSearchAgentName" runat="server"
                                                        CssClass="txtInputLong2"
                                                        MaxLength="60"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnSearchAgentSearch" runat="server" Text="Search"
                                                        CssClass="btnShort"
                                                        CausesValidation="false" />
                                                    <asp:Button ID="btnSearchAgentClear" runat="server" Text="Clear"
                                                        CssClass="btnShort"
                                                        CausesValidation="false" />
                                                    <asp:Button ID="btnSearchAgentClose" runat="server" Text="Close"
                                                        CssClass="btnShort"
                                                        CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="100%" style="height: 10px;"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div class="gvwSearch">
                                                        <asp:GridView ID="gvwSearchAgent" runat="server"
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
                                                            Width="740px">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButton ID="radSelectAgent" runat="server"
                                                                            GroupName="SelectAgent"
                                                                            AutoPostBack="true"
                                                                            Visible="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Agent ID" DataField="AGNPRS" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Agent Name" DataField="AGNNME" ItemStyle-Width="75%" />
                                                                <asp:BoundField HeaderText="Agency ID" DataField="AGNBRN" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" ControlStyle-CssClass="gvwHidden" />
                                                                <asp:BoundField HeaderText="Agency Name" DataField="BRNNME" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" ControlStyle-CssClass="gvwHidden" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
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
            <asp:ModalPopupExtender ID="mpeSearchAgent" runat="server"
                TargetControlID="dummySearchAgent"
                PopupControlID="pnlSearchAgent"
                BackgroundCssClass="modal"
                Enabled="true">
            </asp:ModalPopupExtender>

            <!-- CONFIRMATION MESSAGE -->
            <asp:LinkButton ID="dummyConfirm" Style="display: none" runat="server" />
            <asp:Panel ID="pnlConfirm" runat="server" Width="300px"
                CssClass="panel-messagebox" DefaultButton="btnConfirmNo">
                <table id="tblConfirm" width="100%" runat="server">
                    <tr>
                        <td rowspan="2" align="center" valign="top" style="width: 40px">
                            <asp:Image ID="imgConfirm" runat="server" ImageUrl="Images/icons/question.png" Height="32px" Width="32px" />
                        </td>
                        <td style="width: 260px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblConfirm" runat="server" CssClass="lblMessageBox" Text="?"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
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
                OkControlID="btnConfirmYes"
                CancelControlID="btnConfirmNo">
            </asp:ModalPopupExtender>

            <!-- MESSAGE BOX -->
            <input id="dummyMessage" type="button" style="display: none" runat="server" />
            <asp:Panel ID="pnlMessage" runat="server" CssClass="panel-messagebox" DefaultButton="btnMessageOk" >
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

            <asp:AsyncPostBackTrigger ControlID="btnMessageOk" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="chkWithAPR" EventName="CheckedChanged" />

            <asp:AsyncPostBackTrigger ControlID="btnSearchAgentSearch" EventName="Click" />

            <asp:AsyncPostBackTrigger ControlID="btnSearchPayorSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvwSearchPayor" />

        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
