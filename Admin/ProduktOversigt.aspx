<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ProduktOversigt.aspx.cs" Inherits="Admin_ProduktOversigt" %>

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

        <table id="oversigt" class="display" cellspacing="0">
            <thead>
                <tr>
                    <th>Titel</th>
                    <th>Størelse</th>
                    <th>Pris</th>
                    <th>Antal</th>
                    <th>Billede</th>
                    <th>Kategori</th>
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

