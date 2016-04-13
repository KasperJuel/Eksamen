<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="EditProdukt.aspx.cs" Inherits="Admin_EditProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">

        <asp:Panel ID="pnlEditProdukt" runat="server" DefaultButton="btnEdit">

            <div style="float: left; width: 400px;">
                <h3>Rediger Produkt</h3>
                <p>
                    Titel:
                <br />
                    <asp:TextBox ID="txtTitel" runat="server"
                        placholder="Titel"
                        CssClass="input-style-gen">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfv1" runat="server"
                        ErrorMessage="Feltet skal udfyldes!"
                        ControlToValidate="txtTitel">
                    </asp:RequiredFieldValidator>

                </p>

                <p>
                    Beskrivelse:
                <br />
                    <asp:TextBox ID="txtBeskrivelse" runat="server"
                        placholder="Beskrivelse"
                        TextMode="MultiLine"
                        CssClass="input-style-multi">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfv2" runat="server"
                        ErrorMessage="Feltet skal udfyldes!"
                        ControlToValidate="txtBeskrivelse">
                    </asp:RequiredFieldValidator>

                </p>

                <p>
                    Plakat Størelse:
                <br />
                    <asp:TextBox ID="txtStoerelse" runat="server"
                        placeholder="Plakat Størelse"
                        CssClass="input-style-gen">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfv3" runat="server"
                        ErrorMessage="Feltet skal udfyldes!"
                        ControlToValidate="txtStoerelse">
                    </asp:RequiredFieldValidator>

                </p>

                <p>
                    Pris:
                <br />
                    <asp:TextBox ID="txtPris" runat="server"
                        placeholder="Pris"
                        CssClass="input-style-gen">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfv4" runat="server"
                        ErrorMessage="Feltet skal udfyldes!"
                        ControlToValidate="txtPris">
                    </asp:RequiredFieldValidator>

                </p>

                <p>
                    Antal:
                <br />
                    <asp:TextBox ID="txtAntal" runat="server"
                        placeholder="Antal på lager"
                        CssClass="input-style-gen">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfv5" runat="server"
                        ErrorMessage="Feltet skal udfyldes!"
                        ControlToValidate="txtAntal">
                    </asp:RequiredFieldValidator>


                </p>
                <br />

                <asp:DropDownList ID="ddlKat" runat="server">
                </asp:DropDownList><br />
                <br />

                <asp:FileUpload ID="fuImg" runat="server"
                    AllowMultiple="false" /><br />
                <br />

                <asp:Button ID="btnEdit" runat="server"
                    Text="Rediger"
                    OnClick="btnEdit_Click"
                    CssClass="btn-style-gen" /><br />

                <asp:Literal ID="litMsg" runat="server" />
            </div>

            <div class="img-box">

                <asp:Image ID="imgShow" runat="server" style="width: 300px;" />

            </div>

        </asp:Panel>

    </div>
    <div class="clear"></div>


</asp:Content>

