<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="ChangePassword2.aspx.vb" Inherits="Cocolife.UI.OCS.ChangePassword2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script type="text/javascript" language="javascript">

            var ModalProgress = '<%= mpeProgress.ClientID %>';

            var Save = '<%= btnSave.ClientID %>';

            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

            function beginReq(sender, args) {
                var postBackElementID = args.get_postBackElement().id;
                if (Save == postBackElementID) { $find(ModalProgress).show(); }
            }

            function endReq(sender, args) {
                $find(ModalProgress).hide();
            }

    </script>     

    <div class="contentPage">
    
        <asp:UpdatePanel ID="upChangePassword" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            
                <!-- FORM -->
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr><td colspan="3" class="chChangePassword"></td></tr>
                    <tr><td colspan="3" style="height: 5px;"></td></tr>
                    <tr>
                        <td style="width: 20px;"></td>
                        <td style="width: 840px; vertical-align: top;">
                            <div class="contentPageTD">              
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 160px;" class="lblBold11">User Fullname</td>
                                    <td style="width: 260px;">
                                        <asp:TextBox ID="txtUserFullname" runat="server"
                                            CssClass="txtReadOnlyLong"
                                            ReadOnly="true"
                                            TabIndex="-1"></asp:TextBox>
                                    </td>
                                    <td style="width: 160px;"></td>
                                    <td style="width: 260px;"></td>
                                </tr>
                                <tr><td colspan="4" style="height: 10px;"></td></tr>
                                <tr>
                                    <td class="lblBold11">Old Password</td>
                                    <td>
                                        <asp:TextBox ID="txtOldPassword" runat="server"
                                            CssClass="txtInputShort"
                                            TextMode="Password"
                                            MaxLength="15"
                                            AutoCompleteType="None"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">New Password</td>
                                    <td>
                                        <asp:TextBox ID="txtNewPassword" runat="server"
                                            CssClass="txtInputShort"
                                            TextMode="Password"
                                            MaxLength="15"
                                            AutoCompleteType="None"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="lblBold11">Confirm New Password</td>
                                    <td>
                                        <asp:TextBox ID="txtConfirmNewPassword" runat="server"
                                            CssClass="txtInputShort"
                                            TextMode="Password"
                                            MaxLength="15"
                                            AutoCompleteType="None"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>                                
                                <tr><td colspan="4" style="height: 10px;"></td></tr>           
                                <tr>
                                    <td colspan="4" class="lblBoldRed11" style="text-align: justify;">Password Condition<br />
                                        <asp:Label ID="lblPasswordCondition" runat="server" Text="" class="lblNormalRed11"></asp:Label>
                                    </td>
                                </tr>
                                <tr><td colspan="4" style="height: 10px;"></td></tr> 
                                <!-- Transactions -->                      
                                <tr>                        
                                    <td colspan="4">                                
                                        <asp:Panel ID="pnlTransaction" runat="server"
                                            HorizontalAlign="Right"
                                            Width="99.5%">
                                            <div class="panelButton">
                                                <asp:Button ID="btnSave" runat="server" Text="Save"
                                                    CssClass="btnShort" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                                    CssClass="btnShort" />                                            
                                            </div>
                                        </asp:Panel>
                                        <asp:RoundedCornersExtender ID="rceTransaction" runat="server"
                                            TargetControlID="pnlTransaction"
                                            Enabled="true"
                                            BorderColor="#c8c8c8"
                                            Radius="5"
                                            Corners="All">
                                        </asp:RoundedCornersExtender>                                        
                                    </td>
                                </tr>      
                                <!-- Hidden -->                          
                            </table>                   
                            </div>     
                        </td>
                        <td style="width: 20px;"></td>
                    </tr>
                    <tr><td colspan="3" style="height: 5px;"></td></tr>
                    <tr><td colspan="3" class="cfSeparator"></td></tr>                    
                </table>      
                
                <!-- MESSAGE BOX -->
                <input id="dummyMessage" type="button" style="display: none" runat="server" />
                <asp:Panel ID="pnlMessage" runat="server" Width="300px" CssClass="panel-messagebox" Style="display: none" DefaultButton="btnMessageOk">
                    <table id="tableMessage" width="100%" runat="server">
                        <tr>
                            <td rowspan="2" align="center" valign="top" style="width: 40px">
                                <asp:Image ID="imgMessage" runat="server" ImageUrl="Images/icons/critical.png" height="32px" width="32px" /></td>
                            <td style="width: 260px">&nbsp;</td>
                        </tr>
                        <tr><td><asp:Label ID="lblMessage" runat="server" CssClass="lblMessageBox" Text="Error!"></asp:Label></td></tr>
                        <tr><td colspan="2">&nbsp;</td></tr>
                        <tr><td colspan="2" align="right"><asp:Button ID="btnMessageOk" runat="server" Text="Ok" CssClass="btnShort" CausesValidation="False" UseSubmitBehavior="false" /></td></tr>                        
                    </table>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpeMessage" runat="server"
                    TargetControlID="dummyMessage"
                    PopupControlID="pnlMessage"
                    BackgroundCssClass="modal"
                    Enabled="true">
                </asp:ModalPopupExtender>    

                <!-- PROGRESS -->
                <asp:Panel ID="pnlProgress" runat="server" Width="225px" CssClass="panel-messagebox" Style="display: none">
                    <table id="tblProgress" width="100%">
                        <tr><td><asp:Image ID="imgProcessing" runat="server" ImageUrl="~/images/loading.gif" /></td></tr>
                        <tr><td align="center">Processing...</td></tr>
                    </table>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpeProgress" runat="server"
                    TargetControlID="pnlProgress"
                    PopupControlID="pnlProgress"
                    BackgroundCssClass="modal">
                </asp:ModalPopupExtender>                    
            
            </ContentTemplate>
            <Triggers>

            </Triggers>
        </asp:UpdatePanel>
    
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
