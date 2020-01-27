<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Emprestimos.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.User.Emprestimos.Emprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Reservar livro</h2>
    <asp:GridView runat="server" ID="gvEmprestar" CssClass="table" />
</asp:Content>
