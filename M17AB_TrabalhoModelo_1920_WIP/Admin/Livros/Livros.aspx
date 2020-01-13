<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Livros.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Livros.Livros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Nome:<asp:TextBox ID="tbNome" runat="server"></asp:TextBox><br />
    Ano:<asp:TextBox ID="tbAno" runat="server"></asp:TextBox><br />
    Data aquisição:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar><br />
    Preço:<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox><br />
    Autor:<asp:TextBox ID="tbAutor" runat="server"></asp:TextBox><br />
    Tipo:<asp:TextBox ID="tbTipo" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbErro" runat="server" /><br />
    <asp:Button ID="bt1" runat="server" Text="Adicionar" OnClick="bt1_Click" />
</asp:Content>
