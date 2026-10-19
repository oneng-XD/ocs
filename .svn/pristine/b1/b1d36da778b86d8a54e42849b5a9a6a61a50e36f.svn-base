<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Cocolife.UI.OCS.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Collection System - Login</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <!-- ICON -->
    <link rel="shortcut icon" type="image/x-icon" href="Images/CocoIcon.ico" />
    <link rel="icon" type="image/x-icon" href="Images/CocoIcon.ico" />
    <!-- CSS -->
    <link href="CSS/OCSStyle.css" rel="stylesheet" type="text/css" />
    <!-- JS -->
    <script src="JS/CommonScripts.js" type="text/javascript"></script>
</head>
<body>
    <form id="frmLogin" runat="server">

        <script type="text/javascript" language="javascript">

            var ModalProgress = '<%= mpeProgress.ClientID %>';
            var Login = '<%= btnLogin.ClientID %>';

            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

            function beginReq(sender, args) {
                var postBackElementID = args.get_postBackElement().id;
                if (Login == postBackElementID) { $find(ModalProgress).show(); }
            }

            function endReq(sender, args) {
                $find(ModalProgress).hide();
            }

            document.onkeypress = DisabledEnter;
            document.onkeydown = DisabledBackSpace;

            javascript: window.history.forward(1);

        </script>

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"
            EnablePageMethods="true"
            EnableViewState="true">
        </asp:ToolkitScriptManager>

        <asp:UpdatePanel ID="upLogin" runat="server" RenderMode="Inline" UpdateMode="Conditional">
            <ContentTemplate>

                <div id="login">
                    <div id="login-header"></div>
                    <div id="login-body">
                        <div id="login-body-left"></div>
                        <div id="login-body-main">
                            <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
                                <table class="login-body-main-table" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="3" style="height: 60px;"></td>
                                    </tr>
                                    <tr style="height: 28px;">
                                        <td class="login-body-main-td1 lblBold11">Username</td>
                                        <td class="login-body-main-td2 lblBold11">:</td>
                                        <td class="login-body-main-td3">
                                            <asp:TextBox ID="txtUsername" runat="server" CssClass="txtInputShort" MaxLength="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 28px;">
                                        <td class="lblBold11">Password</td>
                                        <td class="lblBold11">:</td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="txtInputShort" TextMode="Password"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="login-body-main-tdall">
                                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btnShort" ToolTip="Login" />
                                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnShort" ToolTip="Clear" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="login-body-main-tdall">
                                            <asp:LinkButton ID="lnkFortgotPassword" runat="server" ToolTip="Forgot Password" CausesValidation="false" CssClass="lnkNormal11777777">Forgot password?</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="login-body-main-tdall">
                                            <asp:Label ID="lblVersion" Font-Size="XX-Small" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <div id="login-body-right"></div>
                    </div>
                    <div id="login-footer"></div>
                </div>

                <!-- MESSAGE BOX -->
                <input id="dummyMessage" type="button" style="display: none" runat="server" />
                <asp:Panel ID="pnlMessage" runat="server" CssClass="panel-messagebox" DefaultButton="btnMessageOk" Style="display: none">
                    <div>
                        <div class="panel-messagebox-td1">
                            <asp:Image ID="imgMessage" runat="server" ImageUrl="Images/icons/critical.png" CssClass="image-messagebox" /></div>
                        <div class="panel-messagebox-td2"></div>
                        <div class="panel-messagebox-td3">
                            <asp:Label ID="lblMessage" runat="server" CssClass="label-messagebox" Text="Error!"></asp:Label></div>
                    </div>
                    <div class="panel-messagebox-button">
                        <asp:Button ID="btnMessageOk" runat="server" Text="Ok" CssClass="btnShort" CausesValidation="false" /></div>
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
                        <asp:Image ID="imgProcessing" runat="server" ImageUrl="~/images/loading.gif" /></div>
                    <div class="panel-progress-label">Processing...</div>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpeProgress" runat="server"
                    TargetControlID="pnlProgress"
                    PopupControlID="pnlProgress"
                    BackgroundCssClass="modal">
                </asp:ModalPopupExtender>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnMessageOk" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
</body>
</html>
