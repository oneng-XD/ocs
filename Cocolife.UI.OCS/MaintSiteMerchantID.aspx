<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="MaintSiteMerchantID.aspx.vb" Inherits="Cocolife.UI.OCS.MaintSiteMerchantID"
    Title="Online Collection System (Maintenance : Site Merchant ID)" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ MasterType VirtualPath="~/OCS.Master" %>

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

    <asp:UpdatePanel ID="upMaintOfficialReceipt" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="content">
                <div id="content-header-maintenancesitemerchantid" class="content-header"></div>
                <div id="content-body">

                    <asp:Panel ID="pnlDCR" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">Site</td>
                                    <td colspan="3" class="content-body-panel-td234">
                                        <asp:DropDownList ID="ddlSite" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                    </td>   
                                </tr>
                                <tr>
                                    <td class="lblBold11">Terminal Type</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlTerminalType" runat="server" CssClass="ddlShort" AutoPostBack="true" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Name</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMerchantName" runat="server" CssClass="txtInputLong" MaxLength="100" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Merchant ID</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtMerchantID" runat="server" CssClass="txtInputLong" MaxLength="40"  Enabled="false" />
                                        <asp:FilteredTextBoxExtender ID="fteMerchantID" runat="server" TargetControlID="txtMerchantID" FilterType="Numbers" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">Effective Date</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtMerchantEffectiveDate" runat="server" CssClass="txtInputShort" MaxLength="10" Enabled="false" />
                                        <asp:CalendarExtender ID="calMerchantEffectiveDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtMerchantEffectiveDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeMerchantEffectiveDate" runat="server" TargetControlID="txtMerchantEffectiveDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                    </td>
                                    <td class="content-body-panel-td3 lblBold11">Termination Date</td>
                                    <td class="content-body-panel-td4">
                                        <asp:TextBox ID="txtMerchantTermDate" runat="server" CssClass="txtInputShort" MaxLength="10" Enabled="false" />
                                        <asp:CalendarExtender ID="calMerchantTermDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtMerchantTermDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeMerchantTermDate" runat="server" TargetControlID="txtMerchantTermDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Status</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlMerchantStatus" runat="server" CssClass="ddlShort" AutoPostBack="true" Enabled="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 5px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="content-body-accordion-button">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" ToolTip="Add Series" CssClass="btnShort" Enabled="false" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save Series" CssClass="btnShort" Visible="false" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnShort" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 5px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="gvwSearchVertical">
                                            <asp:GridView ID="gvwMerchantIdList" runat="server"
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
                                                    <asp:BoundField HeaderText="ID" DataField="id" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Terminal Type" DataField="terminal_id"/>
                                                    <asp:BoundField HeaderText="Merchant ID" DataField="merchant_id" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Name" DataField="merchant_id_name" />
                                                    <asp:BoundField HeaderText="Site Code" DataField="site_code" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Effective Date" DataField="eff_date" />
                                                    <asp:TemplateField HeaderText="Termination Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="term_date" runat="server" Text='<%#IIf(Convert.ToDateTime(Eval("term_date")) = #1/1/1900#, "", Convert.ToDateTime(Eval("term_date")).ToShortDateString)%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Status" DataField="status" />
                                                    <asp:BoundField HeaderText="Status Id" DataField="status_id" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Created Date" DataField="post_date" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Created By" DataField="post_by" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Last Update" DataField="last_update" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Last Update By" DataField="last_update_by" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:TemplateField HeaderStyle-Width="10px" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtnSeriesEdit" runat="server"
                                                                Visible='<%# IIf(Val(Eval("status_id")) = 1, True, False)%>'
                                                                ImageUrl="images/icons/list.png"
                                                                CommandName="Recall"
                                                                CommandArgument="<%# Container.DataItemIndex %>"
                                                                ToolTip="Edit Detail" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                        <asp:HiddenField ID="hdnMerchantSiteCode" runat="server" />
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
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

