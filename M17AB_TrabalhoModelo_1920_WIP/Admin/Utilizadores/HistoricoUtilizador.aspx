<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistoricoUtilizador.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores.HistoricoUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Histórico de empréstimos</h2>
    <a href="/Admin/Utilizadores/Utilizadores.aspx">Voltar</a>
    <asp:GridView runat="server" ID="gvHistorico" CssClass="table"></asp:GridView>
</asp:Content>
