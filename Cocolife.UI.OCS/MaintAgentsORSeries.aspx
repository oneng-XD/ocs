<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="MaintAgentsORSeries.aspx.vb" Inherits="Cocolife.UI.OCS.MaintAgentsORSeries"
    Title="Online Collection System (Maintenance : Agent's OR Series)" %>

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

    <asp:UpdatePanel ID="upMaintAgentsORSeries" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

             <div id="content">
                <div id="content-header-maintenanceagentsorseries" class="content-header"></div>
                <div id="content-body">

                    <asp:Panel ID="pnlDCR" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lblBold11">Agent</td>
                                    <td>
                                        <asp:Panel ID="pnlLoadAgentID" runat="server" DefaultButton="ibtnSearchAgent">
                                            <asp:TextBox ID="txtAgentID" runat="server" CssClass="txtInputShortNumber" MaxLength="15"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteAgentID" runat="server" TargetControlID="txtAgentID" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                            <asp:ImageButton ID="ibtnSearchAgent" runat="server" ImageUrl="~/Images/icons/search.gif" CssClass="ibtn ibtnSearch" ToolTip="Search Agent" />
                                            <asp:ImageButton ID="ibtnClearAgent" runat="server" ImageUrl="~/Images/icons/eraser.png" CssClass="ibtn ibtnEraser" CausesValidation="false" ToolTip="Clear Agent" />
                                        </asp:Panel>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtAgentName" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Agency</td>
                                    <td>
                                        <asp:TextBox ID="txtAgencyID" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtAgencyName" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Registration Number</td>
                                    <td>
                                        <asp:TextBox ID="txtSeriesRegNumber" runat="server" CssClass="txtInputShortNumber" MaxLength="20" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="lblBold11">Registration Date</td>
                                    <td>
                                        <asp:TextBox ID="txtSeriesRegDate" runat="server" CssClass="txtInputShort" MaxLength="10" Enabled="false"></asp:TextBox>
                                        <asp:CalendarExtender ID="calSeriesRegDate" runat="server" CssClass="cal_Theme2" Format="MM/dd/yyyy" PopupPosition="Right" TargetControlID="txtSeriesRegDate">
                                        </asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeSeriesRegDate" runat="server" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtSeriesRegDate">
                                        </asp:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">OR Range</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtSeriesStart" runat="server"
                                            CssClass="txtInputShort"
                                            MaxLength="10"
                                            Enabled="false"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteSeriesStart" runat="server" FilterType="Numbers" TargetControlID="txtSeriesStart"
                                            ></asp:FilteredTextBoxExtender>
                                        &nbsp;
                                        to
                                        &nbsp;
                                        <asp:TextBox ID="txtSeriesEnd" runat="server" 
                                            CssClass="txtInputShort" 
                                            MaxLength="10"
                                            Enabled="false"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteSeriesEnd" runat="server" FilterType="Numbers" TargetControlID="txtSeriesEnd"
                                            ></asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">Expiry Date</td>
                                    <td class="content-body-panel-td2">
                                        <asp:TextBox ID="txtSeriesExpDate" runat="server" CssClass="txtInputShort" MaxLength="10" Enabled="false"></asp:TextBox>
                                        <asp:CalendarExtender ID="calSeriesExpDate" runat="server" CssClass="cal_Theme2" Format="MM/dd/yyyy" PopupPosition="Right" TargetControlID="txtSeriesExpDate">
                                        </asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeSeriesExpDate" runat="server" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtSeriesExpDate">
                                        </asp:MaskedEditExtender>
                                    </td>
                                    <td class="content-body-panel-td3"></td>
                                    <td class="content-body-panel-td4"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 5px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="content-body-accordion-button">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" ToolTip="Add Series" CssClass="btnShort" Enabled="false" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save Series" CssClass="btnShort" Visible="false" />
                                        <asp:Button ID="btnTemp" runat="server" Text="Generate Temp" ToolTip="Generate Temp details" CssClass="btnShort" Enabled="false" />
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
                                        <div class="gvwSearchVertical">
                                            <asp:GridView ID="gvwAgentOrSeries" runat="server"
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
                                                    <asp:TemplateField HeaderStyle-Width="10px" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="radSelectSeries" runat="server"
                                                                Enabled='<%# IIf(Eval("agnend").ToString() = "", True, False)%>'
                                                                ToolTip="Edit Detail"
                                                                GroupName="SelectRecord"
                                                                AutoPostBack="true"
                                                                OnCheckedChanged="radSelectSeries_CheckedChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Row Id" DataField="row_id" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
                                                    <asp:BoundField HeaderText="Agent Code" DataField="agnprs" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Registration No" DataField="regnum"/>
                                                    <asp:BoundField HeaderText="Registration Date" DataField="regdate" DataFormatString="{0:MM/dd/yyyy}" />
                                                    <asp:BoundField HeaderText="Series Start" DataField="or_book_fr" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Series End" DataField="or_book_to" ItemStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField HeaderText="Expiry Date" DataField="regexp_date" DataFormatString="{0:MM/dd/yyyy}" />
                                                    <asp:BoundField HeaderText="Updated by" DataField="update_by" />
                                                    <asp:BoundField HeaderText="Last Update" DataField="update_date" HeaderStyle-CssClass="gvwHidden" FooterStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden" />
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
                        <asp:HiddenField ID="hdnSearchAgentTag" runat="server" />
                        <asp:HiddenField ID="hdnConfirmCaller" runat="server"/>
                        <asp:HiddenField ID="hdnClickStateTag" runat="server" />
                        <asp:HiddenField ID="hdnConfirmTag" runat="server" />
                        <asp:HiddenField ID="hdnEditId" runat="server" />
                        <asp:HiddenField ID="hdnSeriesOldRegNum" runat="server" />
                        <asp:HiddenField ID="hdnSeriesOldRegDate" runat="server" />
                        <!-- AGENT DETAILS -->
                        <asp:HiddenField ID="hdnAgentLastName" runat="server" />
                        <asp:HiddenField ID="hdnAgentFirstName" runat="server" />
                        <asp:HiddenField ID="hdnAgentMiddleName" runat="server" />
                        <asp:HiddenField ID="hdnAgentSalesForce" runat="server" />
                        <asp:HiddenField ID="hdnAgentIDTag" runat="server" />
                        <!-- AGENCY DETAILS -->
                        <asp:HiddenField ID="hdnAgencyLastName" runat="server" />
                        <asp:HiddenField ID="hdnAgencyFirstName" runat="server" />
                        <asp:HiddenField ID="hdnAgencyMiddleName" runat="server" />
                    </asp:Panel>

                </div>
                <div id="content-footer"></div>
            </div>

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
                                                                            OnCheckedChanged="radSelectAgent_CheckedChanged" />
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

