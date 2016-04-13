<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="EditKat.aspx.cs" Inherits="Admin_EditKat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div id="content">

        <asp:Panel ID="pnlEditKat" runat="server" DefaultButton="btnEdit">

            <h3>Rediger en Kategori</h3>

            <asp:TextBox ID="txtKategorinavn" runat="server"
                placeholder="Indtast kategorinavn"
                CssClass="input-style-gen">
            </asp:TextBox>

            <asp:Button ID="btnEdit" runat="server"
                Text="Rediger"
                OnClick="btnEdit_Click"
                CssClass="btn-style-gen" /><br />

            <asp:Literal ID="litMsg" runat="server" />

            <asp:RequiredFieldValidator ID="rfvKat" runat="server"
                ErrorMessage="Feltet skal udfyldes!"
                ControlToValidate="txtKategorinavn">
            </asp:RequiredFieldValidator>

        </asp:Panel>

    </div>

    <div class="clear"></div>


</asp:Content>

