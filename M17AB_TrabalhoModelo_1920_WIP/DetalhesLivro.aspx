<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalhesLivro.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.DetalhesLivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image id="imgCapa" runat="server" /><br />
    <asp:Label ID="lbNome" runat="server" /><br />
    <asp:Label ID="lbAutor" runat="server" /><br />
    <asp:Label ID="lbAno" runat="server" /><br />
    <%if (Session["perfil"] != null && Session["perfil"].Equals("1"))
        {%>
    <asp:Button CssClass="btn btn-danger" ID="btReservar" Text="Reservar"
        runat="server" OnClick="btReservar_Click" />
    <asp:Label CssClass="form-control" ID="lbMensagem" runat="server" /><br />
    <%} %>
    <a href="/index.aspx">Voltar</a>
</asp:Content>
