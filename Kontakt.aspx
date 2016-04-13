<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kontakt.aspx.cs" Inherits="Kontakt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">

        <h2 class="h2">Kontakt</h2>

        <asp:TextBox ID="txtNavn" runat="server"
            placeholder="Navn"
            CssClass="input-bestilling"
            ValidationGroup="vgKontakt"></asp:TextBox><br />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            runat="server"
            ErrorMessage="Feltet skal udfyldes!"
            ControlToValidate="txtNavn"
            ValidationGroup="vgKontakt">
        </asp:RequiredFieldValidator><br />

        <asp:TextBox ID="txtMail" runat="server"
            placeholder="E-Mail"
            CssClass="input-bestilling"
            ValidationGroup="vgKontakt"
            TextMode="Email"></asp:TextBox><br />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
            runat="server"
            ErrorMessage="Feltet skal udfyldes!"
            ControlToValidate="txtMail"
            ValidationGroup="vgKontakt">
        </asp:RequiredFieldValidator><br />

        <asp:TextBox ID="txtKommentar" runat="server"
            placeholder="Kommentar ..."
            CssClass="input-multi-bestilling"
            ValidationGroup="vgKontakt"
            TextMode="MultiLine"></asp:TextBox><br />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
            runat="server"
            ErrorMessage="Feltet skal udfyldes!"
            ControlToValidate="txtKommentar"
            ValidationGroup="vgKontakt">
        </asp:RequiredFieldValidator><br />

        <asp:Button ID="btnSend" runat="server"
            Text="Send"
            OnClick="btnSend_Click"
            CssClass="btn-bestilling"
            ValidationGroup="vgKontakt" /><br />
        <br />

        <asp:Literal ID="litMsg" runat="server" />

    </div>

    <div class="clear"></div>

</asp:Content>

