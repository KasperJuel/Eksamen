<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OpretKategori.aspx.cs" Inherits="Admin_OpretKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!-- DataTables CSS -->
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.4/css/jquery.dataTables.css">

    <!-- jQuery -->
    <script type="text/javascript" charset="utf8" src="//code.jquery.com/jquery-1.10.2.min.js"></script>

    <!-- DataTables -->
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.4/js/jquery.dataTables.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            $('#oversigt').dataTable({
            });
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">

        <asp:Panel ID="pnlOpretKat" runat="server" DefaultButton="btnOpret">

            <h3>Opret en Kategori</h3>

            <asp:TextBox ID="txtKategorinavn" runat="server"
                placeholder="Indtast kategorinavn"
                CssClass="input-style-gen"
                ValidationGroup="valOpret">
            </asp:TextBox>

            <asp:Button ID="btnOpret" runat="server"
                Text="Opret"
                OnClick="btnOpret_Click"
                CssClass="btn-style-gen" 
                ValidationGroup="valOpret" /><br />

            <asp:Literal ID="litMsg" runat="server" />

            <asp:RequiredFieldValidator ID="rfvKat" runat="server"
                ErrorMessage="Feltet skal udfyldes!"
                ControlToValidate="txtKategorinavn"
                ValidationGroup="valOpret">
            </asp:RequiredFieldValidator>

        </asp:Panel>

        <table id="oversigt" class="display" cellspacing="0">
            <thead>
                <tr>
                    <th>Kategorier</th>
                    <th>Rediger</th>
                    <th>Slet</th>
                </tr>
            </thead>

            <tbody>
                <asp:Literal ID="litResult" runat="server" />
            </tbody>
        </table>

    </div>

    <div class="clear"></div>

</asp:Content>

