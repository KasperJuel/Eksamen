<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProduktKategori.aspx.cs" Inherits="ProduktKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">

        <div id="rbl">
            <p>
                SORTER EFTER PRIS:&nbsp;
            <asp:RadioButton ID="RadioButton2" Text="FALENDE" runat="server" Checked="true" />&nbsp;

                <asp:RadioButton ID="RadioButton1" Text="STIGENDE" runat="server" Checked="false" />
            </p>
        </div>

        <asp:Literal ID="litResult" runat="server" />

    </div>

    <div class="clear"></div>

</asp:Content>

