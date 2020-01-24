<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Login-->
    <div id="divLogin" runat="server">
        Email:<asp:TextBox runat="server" ID="tbEmail" TextMode="Email" CssClass="form-control" />
        Password:<asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="form-control" />
        <asp:Button runat="server" ID="btLogin" Text="Login" OnClick="btLogin_Click" />
        <asp:Button runat="server" ID="btRecuperar" Text="Recuperar password" OnClick="btRecuperar_Click" />
        <asp:Label runat="server" ID="lbErro" />
    </div>
    <!--Pesquisas-->
    <!--Livros-->
</asp:Content>
