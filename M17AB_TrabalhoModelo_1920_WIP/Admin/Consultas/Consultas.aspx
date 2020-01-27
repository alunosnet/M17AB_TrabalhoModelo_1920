<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Consultas.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Consultas</h2>
    <asp:DropDownList runat="server" ID="ddConsultas" AutoPostBack="true"
        CssClass="form-control" OnSelectedIndexChanged="ddConsultas_SelectedIndexChanged" >
        <asp:ListItem Value="0">Top de leitores</asp:ListItem>    
        <asp:ListItem Value="1">Top de livros</asp:ListItem>    
        <asp:ListItem Value="2">Empréstimos fora do prazo</asp:ListItem>    
        <asp:ListItem Value="3">Livros da última semana</asp:ListItem>    
        <asp:ListItem Value="4">Tempo médio de empréstimo</asp:ListItem>    
        <asp:ListItem Value="5">Leitores que levaram o livro mais caro</asp:ListItem>    
    </asp:DropDownList>
        <asp:GridView runat="server" ID="gvConsultas" CssClass="table"></asp:GridView>
</asp:Content>
