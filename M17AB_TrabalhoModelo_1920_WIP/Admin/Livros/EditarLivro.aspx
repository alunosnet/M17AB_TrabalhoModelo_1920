﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarLivro.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Livros.EditarLivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Editar livro</h2>
    Nome:<asp:TextBox CssClass="form-control" ID="tbNome" runat="server"></asp:TextBox><br />
    Ano:<asp:TextBox CssClass="form-control" ID="tbAno" runat="server"></asp:TextBox><br />
    Data aquisição:<asp:TextBox CssClass="form-control" ID="tbData" runat="server" TextMode="Date" /><br />
    Preço:<asp:TextBox CssClass="form-control" ID="tbPreco" runat="server"></asp:TextBox><br />
    Autor:<asp:TextBox CssClass="form-control" ID="tbAutor" runat="server"></asp:TextBox><br />
    Tipo:<asp:TextBox CssClass="form-control" ID="tbTipo" runat="server"></asp:TextBox><br />
    Capa: <asp:Image runat="server" ID="imgCapa" Width="200px" /><br />
    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
    <asp:Label ID="lbErro" runat="server" /><br />
    <asp:Button CssClass="btn btn-lg btn-danger" ID="bt1" runat="server" Text="Atualizar" OnClick="bt1_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" ID="bt2" runat="server" Text="Voltar" PostBackUrl="~/Admin/Livros/Livros.aspx" />
</asp:Content>
