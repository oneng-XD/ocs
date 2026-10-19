<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="DailyCollectionReport.aspx.vb" Inherits="Cocolife.UI.OCS.DailyCollectionReport"
    Title="Online Collection System (Payment : Posting)" %>

<%@ MasterType VirtualPath="~/OCS.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <script type="text/javascript" language="javascript">

        var ModalProgress = '<%=mpeProgress.ClientID%>';
        var Generate = '<%=btnGenerate.ClientID%>';
        var Summary = '<%=btnSummary.ClientID%>';

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

        function beginReq(sender, args) {
            var postBackElementID = args.get_postBackElement().id;
            /*$find(ModalProgress).show();*/
            if (Generate == postBackElementID) {
                $find(ModalProgress).show();
            } else if (Summary == postBackElementID) {
                $find(ModalProgress).show();
            }
        }

        function endReq(sender, args) {
            $find(ModalProgress).hide();
        }
    </script>

    <asp:UpdatePanel ID="upPaymentPosting" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

             <div id="content">
                <div id="content-header-reportsdailycollectionreport" class="content-header"></div>
                <div id="content-body">

                    <asp:Panel ID="pnlDCR" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-header">Daily Collection Report</div>
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="lblBold11">Date Range</td>
                                    <td class="content-body-panel-td234 lblBold11" colspan="3">
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                        <asp:CalendarExtender ID="calFromDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtFromDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeFromDate" runat="server" TargetControlID="txtFromDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                        &nbsp;to&nbsp;
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                        <asp:CalendarExtender ID="calToDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtToDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="meeToDate" runat="server" TargetControlID="txtToDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">DCR Type</td>
                                    <td class="content-body-panel-td2">
                                        <asp:DropDownList ID="ddlDcrType" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td class="content-body-panel-td3"></td>
                                    <td class="content-body-panel-td4"></td>
                                </tr>
                                <%--<tr>
                                    <td class="lblBold11">Record Type</td>
                                    <td>
                                        <asp:DropDownList ID="ddlRecordType" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>--%>
                                <tr>
                                    <td class="lblBold11">Summary Currency</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCurcod" runat="server" CssClass="ddlLong" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="content-body-accordion-button">
                                        <asp:Button ID="btnGenerate" runat="server" Text="Generate" ToolTip="Generate DCR" CssClass="btnShort" />
                                        <asp:Button ID="btnSummary" runat="server" Text="Summary" ToolTip="Generate Summary" CssClass="btnShort" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    <br />
                    <%--<asp:Panel ID="pnlPosting" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-header">Daily Transaction Posting</div>
                        <div class="content-body-panel-detail">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content-body-panel-td1 lblBold11">Post Date</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtPostDate" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="content-body-accordion-button">
                                        <asp:Button ID="btnLoadPostDate" runat="server" Text="Load" ToolTip="Load Post Date" CssClass="btnShort" />
                                        <asp:Button ID="btnPost" runat="server" Text="Post" ToolTip="Post Collections" CssClass="btnShort" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>--%>

                    <br />
                    <br />

                    <!-- HIDDEN -->
                    <asp:Panel ID="pnlHiddenFields" runat="server" CssClass="panel-hidden">
                        <asp:HiddenField ID="hdnConfirmCaller" runat="server"/>
                        <asp:HiddenField ID="hdnClickStateTag" runat="server" />
                        <asp:HiddenField ID="hdnConfirmTag" runat="server" />
                        <asp:HiddenField ID="hdnReportType" runat="server" />
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
