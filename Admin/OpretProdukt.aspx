<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OpretProdukt.aspx.cs" Inherits="Admin_OpretProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">

        <asp:Panel ID="pnlOpretProdukt" runat="server" DefaultButton="btnOpret">

            <h3>Opret Produkt</h3>

            <p>
                Titel:
                <br />
                <asp:TextBox ID="txtTitel" runat="server"
                    placholder="Titel"
                    CssClass="input-style-gen"
                    ValidationGroup="valOpret">
                </asp:TextBox>

                <asp:RequiredFieldValidator ID="rfv1" runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtTitel"
                    ValidationGroup="valOpret">
                </asp:RequiredFieldValidator>

            </p>

            <p>
                Beskrivelse:
                <br />
                <asp:TextBox ID="txtBeskrivelse" runat="server"
                    placholder="Beskrivelse"
                    TextMode="MultiLine"
                    CssClass="input-style-multi"
                    ValidationGroup="valOpret">
                </asp:TextBox>

                <asp:RequiredFieldValidator ID="rfv2" runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtBeskrivelse"
                    ValidationGroup="valOpret">
                </asp:RequiredFieldValidator>

            </p>

            <p>
                Plakat størelse:
                <br />
                <asp:TextBox ID="txtStoerelse" runat="server"
                    placeholder="Plakat Størelse"
                    CssClass="input-style-gen"
                    ValidationGroup="valOpret">
                </asp:TextBox>

                <asp:RequiredFieldValidator ID="rfv3" runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtStoerelse"
                    ValidationGroup="valOpret">
                </asp:RequiredFieldValidator>

            </p>

            <p>
                Pris:
                <br />
                <asp:TextBox ID="txtPris" runat="server"
                    placeholder="Pris"
                    CssClass="input-style-gen"
                    ValidationGroup="valOpret">
                </asp:TextBox>

                <asp:RequiredFieldValidator ID="rfv4" runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtPris"
                    ValidationGroup="valOpret">
                </asp:RequiredFieldValidator>

            </p>

            <p>
                Antal:
                <br />
                <asp:TextBox ID="txtAntal" runat="server"
                    placeholder="Antal på lager"
                    CssClass="input-style-gen"
                    ValidationGroup="valOpret">
                </asp:TextBox>

                <asp:RequiredFieldValidator ID="rfv5" runat="server"
                    ErrorMessage="Feltet skal udfyldes!"
                    ControlToValidate="txtAntal"
                    ValidationGroup="valOpret">
                </asp:RequiredFieldValidator>

            </p>
            <br />

            <asp:DropDownList ID="ddlKat" runat="server">
            </asp:DropDownList><br />
            <br />

            <asp:FileUpload ID="fuImg" runat="server"
                AllowMultiple="false" /><br />
            <br />

            <asp:Button ID="btnOpret" runat="server"
                Text="Opret"
                OnClick="btnOpret_Click"
                CssClass="btn-style-gen"
                ValidationGroup="valOpret" /><br />

            <asp:Literal ID="litMsg" runat="server" />

        </asp:Panel>

    </div>
    <div class="clear"></div>

</asp:Content>

