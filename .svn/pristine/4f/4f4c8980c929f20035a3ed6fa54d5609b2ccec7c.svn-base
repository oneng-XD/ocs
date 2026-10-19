<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="PaymentCheckTagging.aspx.vb" Inherits="Cocolife.UI.OCS.PaymentCheckTagging"
    Title="Online Collection System (Payment : Check Tagging)" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ MasterType VirtualPath="~/OCS.Master" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <%-- <script type="text/javascript" language="javascript">

        var ModalProgress = '<%=mpeProgress.ClientID%>';
        var ModalConfirm = '<%=mpeConfirm.ClientID%>';

        var TaggingType = '<%=ddlTransactionType.ClientID%>'

        var Confirm = '<%=btnConfirmYes.ClientID%>';
        var Add = '<%=btnAdd.ClientID%>';
        var Save = '<%=btnSave.ClientID%>';
        var Cancel = '<%=btnCancel.ClientID%>';

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

        function beginReq(sender, args) {
            var postBackElementID = args.get_postBackElement().id;
            if (Confirm == postBackElementID) {
                $find(ModalConfirm).hide();
                $find(ModalProgress).show();
            } else if (Add == postBackElementID || Save == postBackElementID || Cancel == postBackElementID) {
                $find(ModalProgress).show();
            } else if (TaggingType == postBackElementID) {
                $find(ModalProgress).show();
            }
        }

        function endReq(sender, args) {
            $find(ModalProgress).hide();
        }

    </script>--%>

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

    <asp:UpdatePanel ID="upPaymentCheckTagging" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

             <div id="content">
                <div id="content-header-paymentchecktagging" class="content-header"></div>
                <div id="content-body">

                    <asp:Panel ID="pnlPaymentCheckTagging" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lblBold11">Transaction Type</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTransactionType" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">From Date</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtSearchFromDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                        <asp:CalendarExtender ID="calSearchFromDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtSearchFromDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeSearchFromDate" runat="server" TargetControlID="txtSearchFromDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                    </td>
                                    <td class="content-body-panel-td3 lblBold11">To Date</td>
                                    <td class="content-body-panel-td4">
                                        <asp:TextBox ID="txtSearchToDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                        <asp:CalendarExtender ID="calSearchToDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtSearchToDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeSearchToDate" runat="server" TargetControlID="txtSearchToDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Receipt Number</td>
                                    <td>
                                        <asp:TextBox ID="txtSearchReceiptNumber" runat="server" CssClass="txtInputShortNumber"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteSearchReceiptNumber" runat="server" TargetControlID="txtSearchReceiptNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                    </td>
                                    <td></td><td></td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Check Number</td>
                                    <td>
                                        <asp:TextBox ID="txtSearchCheckNumber" runat="server" CssClass="txtInputShortNumber"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteSearchCheckNumber" runat="server" TargetControlID="txtSearchCheckNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                    </td>
                                    <td></td><td></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="content-body-accordion-button">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" ToolTip="Search" CssClass="btnShort" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="mfSeparator"></td>
                                </tr>
                                <div id="divForDeposit" runat="server">
                                    <tr>
                                        <td class="lblBold11">Deposit Date</td>
                                        <td>
                                            <asp:TextBox ID="txtTaggingDepositDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                            <asp:CalendarExtender ID="calTaggingDepositDate" runat="server" CssClass="cal_Theme2" Format="MM/dd/yyyy" PopupPosition="Right" TargetControlID="txtTaggingDepositDate">
                                            </asp:CalendarExtender>
                                            <asp:MaskedEditExtender ID="meeTaggingDepositDate" runat="server" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtTaggingDepositDate">
                                            </asp:MaskedEditExtender>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </div>
                                <div id="divForClearing" runat="server">
                                    <tr>
                                        <td class="lblBold11">Clearing Date</td>
                                        <td>
                                            <asp:TextBox ID="txtTaggingClearingDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                            <asp:CalendarExtender ID="calTaggingClearingDate" runat="server" CssClass="cal_Theme2" Format="MM/dd/yyyy" PopupPosition="Right" TargetControlID="txtTaggingClearingDate">
                                            </asp:CalendarExtender>
                                            <asp:MaskedEditExtender ID="meeTaggingClearingDate" runat="server" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtTaggingClearingDate">
                                            </asp:MaskedEditExtender>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Clearing Status</td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlTaggingClearingStatus" runat="server" AutoPostBack="true" CssClass="ddlShort">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </div>
                                <%--<tr>
                                    <td class="content-body-panel-td1 lblBold11">Remarks</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtTaggingRemarks" runat="server" CssClass="txtReadOnlyLong" ReadOnly="true" MaxLength="250"></asp:TextBox>
                                    </td>
                                    <td class="content-body-panel-td3"></td>
                                    <td class="content-body-panel-td4"></td>
                                </tr>--%>
                                <tr>
                                    <td colspan="4" style="height: 5px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="content-body-accordion-button">
                                        <asp:Button ID="btnCheckAll" runat="server" Text="Check All" ToolTip="Check All" CssClass="btnShort" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnShort" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnShort" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 5px;"></td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="4">
                                        <div class="gvwSearch">
                                            <asp:GridView ID="gvwTagging" runat="server"
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
                                                Width="100%" >
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelectTagging" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Id" DataField="id" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Receipt Number" DataField="opr_nmbr" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Receipt Date" DataField="oprdate" DataFormatString="{0:MM/dd/yyyy}" />
                                                    <asp:BoundField HeaderText="Check Number" DataField="chk_nmbr" ItemStyle-HorizontalAlign="Right"/>
                                                    <asp:BoundField HeaderText="Bank Name" DataField="bank" />
                                                    <asp:BoundField HeaderText="Branch Name" DataField="branch" />
                                                    <asp:BoundField HeaderText="Amount" DataField="amount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                                    <asp:BoundField HeaderText="Line Number" DataField="line_nmbr" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="OTC Flag" DataField="otc_flag" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <%--<asp:BoundField HeaderText="Deposit Date" DataField="deposit_date" DataFormatString="{0:MM/dd/yyyy}" />
                                                    <asp:BoundField HeaderText="Clearing Date" DataField="clearing_date" DataFormatString="{0:MM/dd/yyyy}" />--%>
                                                    <asp:TemplateField HeaderText="Deposit Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="deposit_date" runat="server" Text='<%#IIf(Convert.ToDateTime(Eval("deposit_date")) = #1/1/1900#, "", Convert.ToDateTime(Eval("deposit_date")).ToShortDateString)%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Clearing Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="clearing_date" runat="server" Text='<%#IIf(Convert.ToDateTime(Eval("clearing_date")) = #1/1/1900#, "", Convert.ToDateTime(Eval("clearing_date")).ToShortDateString)%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Clearing Status ID" DataField="clearing_status_id" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Remarks" DataField="remarks" />
                                                    <asp:BoundField HeaderText="Status Id" DataField="status_id" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Clearing Status" DataField="clearing_status" />
                                                    <asp:BoundField HeaderText="Deposit Date" DataField="deposit_date" HeaderStyle-CssClass="gvwHidden" FooterStyle-cssclass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Clearing Date" DataField="clearing_date" HeaderStyle-CssClass="gvwHidden" FooterStyle-cssclass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Last Update" DataField="last_update" HeaderStyle-CssClass="gvwHidden" FooterStyle-cssclass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Redeposit Code" DataField="code" HeaderStyle-CssClass="gvwHidden" FooterStyle-cssclass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <%--<asp:TemplateField HeaderStyle-Width="10px" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtnTaggingEdit" runat="server"
                                                                ImageUrl="images/icons/list.png"
                                                                CommandName="Recall"
                                                                CommandArgument="<%# Container.DataItemIndex %>"
                                                                ToolTip="Edit Detail" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />

                    <!-- HIDDEN -->
                    <asp:Panel ID="pnlHiddenFields" runat="server" CssClass="panel-hidden">
                        <asp:HiddenField ID="hdnConfirmCaller" runat="server"/>
                        <asp:HiddenField ID="hdnClickStateTag" runat="server" />
                        <asp:HiddenField ID="hdnConfirmTag" runat="server" />
                        <asp:HiddenField ID="hdnEditId" runat="server" />
                        <asp:HiddenField ID="hdnReceiptNo" runat="server" />
                        <!-- CHECK -->
                        <asp:HiddenField ID="hdnCheckAmount" runat="server" />
                        <asp:HiddenField ID="hdnCheckBankBranch" runat="server" />
                        <asp:HiddenField ID="hdnCheckBankName" runat="server" />
                        <asp:HiddenField ID="hdnCheckNumber" runat="server" />
                        <asp:HiddenField ID="hdnCheckLineNumber" runat="server" />
                        <asp:HiddenField ID="hdnCheckOTCFlag" runat="server" />

                    </asp:Panel>

                </div>
                <div id="content-footer"></div>
            </div>

            <!-- CONFIRMATION MESSAGE -->
            <asp:LinkButton  id="dummyConfirm" style="display: none" runat = "server" />
            <asp:Panel ID="pnlConfirm" runat="server" Width="300px" 
                CssClass="panel-messagebox" Style="" DefaultButton="btnConfirmNo">
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
                            <asp:Button ID="btnMessageOk" runat="server" Text="Ok" CssClass="btnShort" CausesValidation="false" />
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
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

