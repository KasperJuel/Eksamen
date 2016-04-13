<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OpretBruger.aspx.cs" Inherits="Admin_OpretBruger" %>

<%@ Register Src="~/Admin/CreateUser.ascx" TagPrefix="uc1" TagName="CreateUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="content">

        <uc1:CreateUser runat="server" ID="CreateUser" />

    </div>

    <div class="clear"></div>

</asp:Content>

