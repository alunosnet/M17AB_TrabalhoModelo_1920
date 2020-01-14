<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Livros.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Livros.Livros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Livros</h2>
    <asp:GridView runat="server" ID="GvLivros" CssClass="table" />
    <h2>Adicionar livro</h2>
    Nome:<asp:TextBox CssClass="form-control" ID="tbNome" runat="server"></asp:TextBox><br />
    Ano:<asp:TextBox CssClass="form-control" ID="tbAno" runat="server"></asp:TextBox><br />
    Data aquisição:<asp:Calendar Height="200px" CssClass="form-control" ID="Calendar1" runat="server"></asp:Calendar><br />
    Preço:<asp:TextBox CssClass="form-control" ID="tbPreco" runat="server"></asp:TextBox><br />
    Autor:<asp:TextBox CssClass="form-control" ID="tbAutor" runat="server"></asp:TextBox><br />
    Tipo:<asp:TextBox CssClass="form-control" ID="tbTipo" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbErro" runat="server" /><br />
    <asp:Button CssClass="btn btn-lg btn-danger" ID="bt1" runat="server" Text="Adicionar" OnClick="bt1_Click" />
</asp:Content>
