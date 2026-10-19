<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="PaymentDMCMApproval.aspx.vb" Inherits="Cocolife.UI.OCS.PaymentDMCMApproval"
    Title="Online Collection System (Payment : Debit Credit Memo Approval)" %>

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
        var ModalRejection = '<%=mpeRejection.ClientID%>';
        

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

        function ViewDMCMs() {
            $find(ModalViewDMCMs).show();
            return false;
        }
        function ViewSIs() {
            var today = new Date();
            var priorDate = new Date(new Date().setDate(today.getDate() - 30));
            $find(ModalViewSIs).show();
        }


        function IsViewDMCMValid() {
            var vDMCMTransNo = document.getElementById('<%=txtViewDMCMTransID.ClientID%>').value;
          var vSINo = document.getElementById('<%=txtViewDMCMSINumber.ClientID%>').value;
          var vDateFr = document.getElementById('<%=txtViewDMCMFromDate.ClientID%>').value;
          var vDateTo = document.getElementById('<%=txtViewDMCMToDate.ClientID%>').value;

          if (vDMCMTransNo == "" && vDMCMTransNo == "") {
              if (vDateFr == "" || vDateTo == "") {
                  SetMessage("Please enter dates.", "info");
                  return false;
              }
          }
      }

      function CloseModal() {
          $find(ModalViewDMCMs).hide();
          //$find(ModalViewSIs).hide();
          return false;
      }
      function RejectReason() {
          if (document.getElementById('<%=hdnConfirmCaller.ClientID%>').value == "CANCEL") {
                $find(ModalConfirm).hide();
                $find(ModalRejection).show();
                return false;
            } else {
                <%=Page.ClientScript.GetPostBackEventReference(btnConfirmYes, Nothing)%>;
            }
        }
        function IsRejectionValid() {
            var vRejectionReason = $('#<%=txtReason.ClientID%>').val()
            if (vRejectionReason == "") {
                SetMessage("You must Enter Rejects.", "info");
                        return false;
                    } else {
                        <%=Page.ClientScript.GetPostBackEventReference(btnCancelYes, Nothing)%>;
            }
                }

        function CloseRejection() {
            $('#<%=txtReason.ClientID%>').val = "";
            $find(ModalRejection).hide();
        }


        function ConfirmReject() {
            SetConfirmation("Are you sure you want to reject<br />Transaction #" + document.getElementById('<%=txtDMCMTransNo.ClientID%>').value + "?", "CANCEL");
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
 

    <asp:UpdatePanel ID="upPaymentDMCMApproval" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>

             <div id="content">
                <div id="content-header-paymentdmcmapproval" class="content-header"></div>
                <div id="content-body">
                      <asp:Panel ID="pnlSearch" runat="server" CssClass="content-body-panel" DefaultButton="btnLoadViewDMCM">
                         <div class="content-body-panel-header">Search</div>
                           <asp:Panel id="pnlSearchList" runat="server">
                            <div class="content-body-panel-detail">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                                <td class="content-body-panel-td1 lblBold11">From Date</td>
                                                <td class="content-body-panel-td2">
                                                    <asp:TextBox ID="txtViewDMCMFromDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calViewDMCMFromDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtViewDMCMFromDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeViewDMCMFromDate" runat="server" TargetControlID="txtViewDMCMFromDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                                <td class="content-body-panel-td3 lblBold11">To Date</td>
                                                <td class="content-body-panel-td4">
                                                    <asp:TextBox ID="txtViewDMCMToDate" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calViewDMCMToDate" runat="server" CssClass="cal_Theme2" TargetControlID="txtViewDMCMToDate" Format="MM/dd/yyyy" PopupPosition="Right"></asp:CalendarExtender>
                                                    <asp:MaskedEditExtender ID="meeViewDMCMToDate" runat="server" TargetControlID="txtViewDMCMToDate" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"></asp:MaskedEditExtender>
                                                </td>
                                            </tr>
                                     <tr>
                                         <td class="content-body-panel-td1 lblBold11">Transaction ID</td>
                                         <td class="content-body-panel-td2">
                                             <asp:TextBox ID="txtViewDMCMTransID" runat="server" CssClass="txtReadOnlyShort"  TabIndex="-1"></asp:TextBox>

                                         </td>
                                         <td class="content-body-panel-td3 lblBold11"></td>
                                         <td class="content-body-panel-td4"></td>
                                     </tr>
                                    <tr>
                                         <td class="content-body-panel-td1 lblBold11">Sales Invoice No.</td>
                                         <td class="content-body-panel-td2">
                                             <asp:TextBox ID="txtViewDMCMSINumber" runat="server" CssClass="txtReadOnlyShort"  TabIndex="-1"></asp:TextBox>
                                         </td>
                                         <td class="content-body-panel-td3 lblBold11"></td>
                                         <td class="content-body-panel-td4"></td>
                                     </tr>
                                        <tr>
                                                <td colspan="4" style="text-align: center;">
                                                    <asp:Button ID="btnLoadViewDMCM" runat="server" Text="Load" ToolTip="Load View Docs" CssClass="btnShort" OnClientClick="return IsViewDMCMValid();"/>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="btnShort"/>
                                                </td>
                                            </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="4">
                                            <asp:Panel ID="Panel1" runat="server" Width="800px">
                                                <div class="gvwSearch" align="left">
                                                    <asp:GridView ID="gvwViewDMCM" runat="server"
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
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="radSelectViewDMCM" runat="server"
                                                                         GroupName="SelectDoc"
                                                                         AutoPostBack="true"
                                                                        OnCheckedChanged="radSelectViewDMCM_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="ID" DataField="id" HeaderStyle-Width="10px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Transaction ID" DataField="transaction_id" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="Document Type" DataField="memo_type" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="SI Number" DataField="si_number" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="SI Amount" DataField="invoice_amount" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />        
                                                                    <asp:BoundField HeaderText="DMCM Amount" DataField="total_sales" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                                                    <asp:BoundField HeaderText="Running Amount" DataField="running_balance" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                                                    <asp:BoundField HeaderText="Status" DataField="status" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField HeaderText="DMCM Date" DataField="dmcm_date" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"  DataFormatString="{0:d}"/>
                                                                    <asp:BoundField HeaderText="Created By" DataField="user_name" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
                                                        </Columns>
                                                      </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                   
                                </table>
                            </div>
                           </asp:Panel>
                      </asp:Panel>

                    <br /><br />
                  <asp:Panel ID="pnlPaymentDetails" runat="server" CssClass="content-body-panel">
                        <div class="content-body-panel-header">Debit Credit Memo Approval Details</div>
                        <asp:Panel id="pnlPaymentDetails1" runat="server">
                            <div class="content-body-panel-detail">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="lblBold11">DMCM Number</td>
                                        <td>
                                            <asp:TextBox ID="txtDMCMNumber" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                        <td class="lblBold11">DMCM Date</td>
                                        <td>
                                            <asp:TextBox ID="txtDMCMDate" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Transaction ID</td>
                                        <td colspan="3">
                                          <asp:TextBox ID="txtDMCMTransNo" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="lblBold11">Document Type</td>
                                        <td colspan="3">
                                          <asp:TextBox ID="txtMemoType" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="lblBold11">Head / Branch Office</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtOfficeName" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Head / Branch Office Address</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtOfficeAddr" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" MaxLength="60"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Company Contact No./FAX No.</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtOfficeContact" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" MaxLength="60"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="lblBold11">VAT REG / Company TIN</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtOfficeTin" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" MaxLength="60"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Remarks</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtDMCMRemarks" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" MaxLength="60"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lblBold11">Status</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtDMCMStatus" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="lblBold11">Prepared by</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtPreparedBy" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                 
                            </div>
                        </asp:Panel>
                    </asp:Panel>

                    <br/>
                   
                    <asp:Accordion ID="accInvoiceInformation" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                         <Panes>
                             <asp:AccordionPane ID="apnInvoiceInformation" runat="server">
                                <Header>DMCM Information</Header>
                                   <Content>
                                       <asp:Panel id="pnlInvoiceInformation" runat="server">
                                           <div class="content-body-accordion">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                  <tr>
                                                      <td class="lblBold11">SI Number</td>
                                                      <td> 
                                                          <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                      </td>
                                                      <td class="lblBold11">SI Date</td>
                                                      <td>
                                                        <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td class="lblBold11">Policy Number</td>
                                                      <td colspan="3">
                                                          <asp:TextBox ID="txtPolicyNumber" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1" MaxLength="20"></asp:TextBox>
                                                      </td>
                                                  </tr>
                                                  <div id="divPayorInsured" runat="server">
                                                    <tr>
                                                        <td class="lblBold11">Payor</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtPayorName" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">TIN</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtPayorTin" runat="server" CssClass="txtReadOnlyShort"  ReadOnly="true" TabIndex="-1" MaxLength="20"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="lblBold11">Address</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtPayorAddress" runat="server" CssClass="txtReadOnlyLong3"  ReadOnly="true" TabIndex="-1" MaxLength="150"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Billing Statement No.</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBillStatNo" runat="server" CssClass="txtReadOnlyLong" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                        <td class="lblBold11">Billing Statement Date</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBillStatementDate" runat="server"  CssClass="txtReadOnlyShort"   MaxLength="10"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Effectivity Date</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEffectivityFrom" runat="server" CssClass="txtReadOnlyShort" MaxLength="10"></asp:TextBox>
                                                        </td>
                                                        <td class="lblBold11">Expiry Date</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEffectivityTo" runat="server"  CssClass="txtReadOnlyShort" MaxLength="10"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Renewal Date</td>
                                                        <td>
                                                           <asp:TextBox ID="txtRenewalDate" runat="server" CssClass="txtReadOnlyShort" MaxLength="10"></asp:TextBox>
                                                        </td>
                                                        <td class="lblBold11">Billing Type</td>
                                                    
                                                         <td>
                                                             <asp:TextBox ID="txtBillingType" runat="server"  CssClass="txtReadOnlyShort" MaxLength="10"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="lblBold11">Billing Period From</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBillPeriodFrom" runat="server"  CssClass="txtReadOnlyShort" MaxLength="10"></asp:TextBox>
                                                        
                                                        </td>
                                                        <td class="lblBold11">Billing Period To</td>
                                                        <td>
                                                            <asp:TextBox ID="txtBillPeriodTo" runat="server" CssClass="txtReadOnlyShort" MaxLength="10"></asp:TextBox>
                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Mode</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtMode" runat="server" CssClass="txtReadOnlyShort" ReadOnly="true" TabIndex="-1"></asp:TextBox>
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
             


                       <asp:Accordion ID="accParticulars" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                         <Panes>
                             <asp:AccordionPane ID="apnParticulars" runat="server">
                                <Header>DMCM Particulars</Header>
                                   <Content>
                                       <asp:Panel id="pnlParticulars" runat="server">
                                           <div class="content-body-accordion">
                                             <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="lblBold11">Particulars</td>
                                                        <td>
                                                            <asp:TextBox ID="txtParticulars" runat="server" CssClass="txtReadOnlyLong2" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Quantity</td>
                                                        <td>
                                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtReadOnlyNumber" value="1" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="lblBold11">Unit Price</td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                       </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lblBold11">Total Amount</td>
                                                        <td>
                                                            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="txtReadOnlyNumber" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                            </table>
                                        </div>
                                       </asp:Panel>
                                   </Content>
                             </asp:AccordionPane>
                         </Panes>
                     </asp:Accordion>



                      <asp:Accordion ID="accVATComputation" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                         <Panes>
                             <asp:AccordionPane ID="apnVATComputation" runat="server">
                                <Header>VAT Computation</Header>
                                   <Content>
                                       <asp:Panel id="pnlVATComputation" runat="server">
                                           <div class="content-body-accordion">
                                              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="content-body-accordion-td1 lblBold11">VATable Collection</td>
                                                    <td class="content-body-accordion-td2">
                                                        <asp:TextBox ID="txtVATable" runat="server" ReadOnly="true" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td class="content-body-accordion-td3"></td>
                                                    <td class="content-body-accordion-td4"></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">VAT-Exempt Collection</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATExempt" runat="server" ReadOnly="true" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">VAT Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtVATAmount" runat="server" ReadOnly="true" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Non VAT Amount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNonVAT" ReadOnly="true" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtTotalSales" ReadOnly="true" runat="server" CssClass="txtReadOnlyNumber" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Less: Withholding Tax</td>
                                                    <td>
                                                        <asp:TextBox ID="txtWitholdingTax" ReadOnly="true" runat="server" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Amount Net of WTax</td>
                                                    <td>
                                                        <asp:TextBox ID="txtNetOfWitholdingTax" ReadOnly="true" runat="server" CssClass="txtReadOnlyNumber" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Less: Discount</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDiscount" runat="server" ReadOnly="true" CssClass="txtReadOnlyNumber" MaxLength="14"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td class="lblBold11">Discount ID</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDiscountIdNo" ReadOnly="true" runat="server" CssClass="txtReadOnlyShort"  TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </div>
                                        </div>
                                       </asp:Panel>
                                   </Content>
                             </asp:AccordionPane>
                         </Panes>
                     </asp:Accordion>



                    <br />
                    <br />
                    
                    <!-- TRANSACTIONS -->
                    <asp:Panel ID="pnlTransactions" runat="server" CssClass="panel-button-left">
                        <asp:Button ID="btnDMCMApprove" runat="server" Text="Approve" Enabled="false" CssClass="btnShort" />
                        <asp:Button ID="btnDMCMReject" runat="server" Text="Reject" Enabled="false" CssClass="btnShort" OnClientClick="return ConfirmReject(); "/>
                    </asp:Panel>
           
            <!-- HIDDEN -->
                    <asp:Panel ID="pnlHiddenFields" runat="server" CssClass="panel-hidden">
                        <asp:UpdatePanel ID ="upHiddenFields" runat="server" RenderMode="Inline" UpdateMode="Always">
                            <ContentTemplate>
                                <!-- DOC DETAILS -->
                                <asp:HiddenField ID="hdnInvoiceNoExisting" runat="server" />
                                <asp:HiddenField ID="hdnARNoExisting" runat="server" />
                                <asp:HiddenField ID="hdnDebitCreditID" runat="server" />
                                 <asp:HiddenField ID="hdnReferenceNo" runat="server" />
                                <asp:HiddenField ID="hdnDMCMRoleCode" runat="server" />
                                <asp:HiddenField ID="hdnDMCMPostedBy" runat="server" />
                                <asp:HiddenField ID="hdnDMCMApproverID" runat="server" />
                                <asp:HiddenField ID="hdnUploadTag" runat="server" />
                                <asp:HiddenField ID="hdnDMCMNumber" runat="server" />
                                <asp:HiddenField ID="hdnARDate" runat="server" />
                                <asp:HiddenField ID="hdnSIPrintStatus" runat="server" />
                                <asp:HiddenField ID="hdnStatus" runat="server" />
                                <asp:HiddenField ID="hdnConfirmTag" runat="server"/>
                                <asp:HiddenField ID="hdnConfirmCaller" runat="server"/>
                                <asp:HiddenField ID="hdnClickStateTag" runat="server" />
                                <asp:HiddenField ID="hdnDocPrinted" runat="server" />
                                <asp:HiddenField ID="hdnDocSaveState" runat="server" />
                                <asp:HiddenField ID="hdnIsSourceSiteLocked" runat="server" />
                                <asp:HiddenField ID="hdnReportType" runat="server" />
                                <asp:HiddenField ID="hdnReceiptByCode" runat="server" />
                                <asp:HiddenField ID="hdnReceiptById" runat="server" />
                                <asp:HiddenField ID="hdnReservedDMCMID" runat="server" />
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
                                <asp:HiddenField ID="hdnIsSearchButton" runat="server" />
                                <asp:HiddenField ID="hdnSISourceType" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                   
                </div>
                <div id="content-footer"></div>
            </div>

            
           
           <!-- CANCELATION REASON MESSAGE -->
            <asp:LinkButton  id="dummyRejection" style="display: none" runat = "server" />
            <asp:Panel ID="pnlRejection" runat="server" Width="300px" 
                CssClass="panel-messagebox" DefaultButton="btnCancelNo">
                <table id="tblRejection" width="100%" runat="server">
                    <tr>
                        <td rowspan="2" align="center" valign="top" style="width: 40px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/icons/question.png" height="32px" width="32px" />
                        </td>
                        <td style="width: 260px">&nbsp;</td>
                    </tr>
                    <tr><td><asp:Label ID="Label1" runat="server" CssClass="lblMessageBox" Text="?">What is the Reason for Rejection?</asp:Label></td></tr>                    
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td colspan="2" align="center">
                         <asp:TextBox ID="txtReason" runat="server" CssClass="txtReadOnlyLong"  TabIndex="-1" MaxLength="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button ID="btnCancelYes" runat="server"  Text="Proceed"  OnClientClick="return IsRejectionValid();"
                                CssClass="btnShort" />
                            <asp:Button ID="btnCancelNo" runat="server" Text="Close" OnClientClick="return CloseRejection();"
                                CssClass="btnShort" />
                        </td>
                    </tr>                         
                </table>
            </asp:Panel>
            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server"
                DisplayModalPopupID="mpeRejection"
                TargetControlID="dummyRejection">
            </asp:ConfirmButtonExtender>
            <asp:ModalPopupExtender ID="mpeRejection" runat="server"
                TargetControlID="dummyRejection"
                PopupControlID="pnlRejection"
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
                            <asp:Button ID="btnConfirmYes" runat="server" Text="Yes" OnClientClick="return RejectReason();"
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
