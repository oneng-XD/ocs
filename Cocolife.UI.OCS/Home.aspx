<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/OCS.Master" CodeBehind="Home.aspx.vb" Inherits="Cocolife.UI.OCS.Home"
    Title="Online Collection System (Home)" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script type="text/javascript" language="javascript">

        var ModalProgress = '<%= mpeProgress.ClientID %>';

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

        function beginReq(sender, args) {
            var postBackElementID = args.get_postBackElement().id;
            /*$find(ModalProgress).show();*/
        }

        function endReq(sender, args) {
            $find(ModalProgress).hide();
        }

    </script>

    <asp:UpdatePanel ID="upHome" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="content">
                <div id="content-header-home" class="content-header"></div>
                <div id="content-body">

                    <!-- OR LIST -->
                    <asp:Accordion ID="accORList" runat="server" SelectedIndex="-1" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true" CssClass="accordionBlue" HeaderCssClass="accordionHeaderBlue" HeaderSelectedCssClass="accordionHeaderBlueSelected" ContentCssClass="accordionContentBlue">
                        <Panes>
                            <asp:AccordionPane ID="apnORList" runat="server">
                                <Header>
                                    <asp:Label ID="lblORList" runat="server" Text="OR List"></asp:Label>
                                </Header>
                                <Content>
<%--                                    <div class="content-body-accordion">
                                        <asp:GridView ID="gvwViewOpr" runat="server"
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
                                                        <asp:RadioButton ID="radSelectViewOpr" runat="server"
                                                            GroupName="SelectOpr"
                                                            AutoPostBack="true"
                                                            OnCheckedChanged="radSelectViewOpr_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="OPR#" DataField="DOCNUMBER" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Policy Number" DataField="polnum" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField HeaderText="Transaction Type" DataField="METDES" HeaderStyle-Width="190px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField HeaderText="Payor Name" DataField="payor_name" HeaderStyle-Width="270px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField HeaderText="Insured Name" DataField="insured_name" HeaderStyle-Width="270px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField HeaderText="Amount" DataField="AMOUNT" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                                <asp:BoundField HeaderText="Status" DataField="STATUS" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                                                <asp:BoundField HeaderText="Date" DataField="TRNDAT" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"  DataFormatString="{0:d}"/>
                                                <asp:BoundField HeaderText="Created By" DataField="secopr" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"/>
                                                <asp:BoundField HeaderText="Created By ID" DataField="secpid" HeaderStyle-CssClass="gvwHidden" ItemStyle-CssClass="gvwHidden"/>
                                            </Columns>
                                        </asp:GridView>
                                    </div>--%>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>

                </div>
                <div id="content-footer"></div>
            </div>

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
            <asp:AsyncPostBackTrigger ControlID="btnMessageOk" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
