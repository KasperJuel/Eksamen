<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">

        <img src="/gfx/logo/plakaten_logo.png" alt="Logo" style="width: 750px; margin-bottom: 20px;" />

        <div id="seneste-1">
            <asp:Literal ID="litFirst" runat="server" />
        </div>

        <div id="seneste-2">
            <asp:Literal ID="litContent" runat="server" />
        </div>

    </div>

    <div class="clear"></div>

</asp:Content>

