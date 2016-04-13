<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bestilling.aspx.cs" Inherits="Bestilling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script>
        function goBack() {
            window.history.back()
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">
            <h2 class="h2">Bestilling</h2>

            <div id="bestilling-left">

                <asp:TextBox ID="txtNavn" runat="server"
                    placeholder="Navn"
                    CssClass="input-bestilling"
                    ValidationGroup="vgBestil"></asp:TextBox><br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtNavn"
                    ValidationGroup="vgBestil">
                </asp:RequiredFieldValidator><br />

                <asp:TextBox ID="txtAdresse" runat="server"
                    placeholder="Adresse"
                    CssClass="input-bestilling"
                    ValidationGroup="vgBestil"></asp:TextBox><br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtAdresse"
                    ValidationGroup="vgBestil">
                </asp:RequiredFieldValidator>

                <asp:TextBox ID="txtPostnr" runat="server"
                    placeholder="Postnummer"
                    CssClass="input-bestilling"
                    TextMode="Number"
                    ValidationGroup="vgBestil"></asp:TextBox><br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtPostnr"
                    ValidationGroup="vgBestil">
                </asp:RequiredFieldValidator>

                <asp:TextBox ID="txtBy" runat="server"
                    placeholder="By"
                    CssClass="input-bestilling"></asp:TextBox><br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtBy"
                    ValidationGroup="vgBestil">
                </asp:RequiredFieldValidator>

                <asp:TextBox ID="txtMail" runat="server"
                    placeholder="E-Mail"
                    TextMode="Email"
                    CssClass="input-bestilling"
                    ValidationGroup="vgBestil"></asp:TextBox><br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                    runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtMail"
                    ValidationGroup="vgBestil">
                </asp:RequiredFieldValidator>

                <asp:TextBox ID="txtAntal" runat="server"
                    placeholder="Antal Plakater"
                    CssClass="input-bestilling"
                    TextMode="Number"
                    ValidationGroup="vgBestil"></asp:TextBox><br />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                    runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtAntal"
                    ValidationGroup="vgBestil">
                </asp:RequiredFieldValidator><br />

                <asp:Button ID="btnBestil" runat="server"
                    Text="Bestil"
                    OnClick="btnBestil_Click"
                    CssClass="btn-bestilling" 
                    ValidationGroup="vgBestil" /><br />
                <br />

                <asp:Literal ID="litMsg" runat="server" />

            </div>

            <div id="bestilling-right">

                <asp:Literal ID="litResult" runat="server" />

            </div>

    </div>

    <div class="clear"></div>

</asp:Content>

