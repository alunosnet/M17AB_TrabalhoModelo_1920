<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Emprestimos.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Emprestimos.Emprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Empréstimos</h2>
    Só empréstimos por concluir:
    <asp:CheckBox AutoPostBack="true" OnCheckedChanged="cbEmprestimos_CheckedChanged" runat="server" ID="cbEmprestimos" />
    <asp:GridView ID="GvEmprestimos" runat="server" CssClass="table" />
    <h2>Adicionar empréstimos</h2>
    Data devolução:<asp:TextBox CssClass="form-control" runat="server" ID="tbData" TextMode="Date" />
    <br />Livro:<asp:DropDownList runat="server" ID="ddLivros" CssClass="form-control"/><br />
    Utilizador:<asp:DropDownList runat="server" id="ddUtilizador" CssClass="form-control" /><br />
    <asp:Label runat="server" ID="lbErro" />
    <asp:Button OnClick="btAdicionar_Click" ID="btAdicionar" runat="server" Text="Registar" CssClass="btn btn-lg btn-danger" />

</asp:Content>
