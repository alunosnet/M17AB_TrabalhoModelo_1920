<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RemoverUtilizador.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores.RemoverUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1>Apagar utilizador</h1>
    Nº: <asp:Label runat="server" ID="lbNUtilizador" /><br />
    Nome: <asp:Label runat="server" ID="lbNome" /><br />
    
    <asp:Label runat="server" ID="lbErro" /><br />
    <asp:Button CssClass="btn btn-danger" runat="server" ID="btRemover" Text="Remover" 
        OnClick="btRemover_Click" />
    <asp:Button CssClass="btn btn-info" runat="server" ID="btCancelar" Text="Voltar" 
         PostBackUrl="~/Admin/Utilizadores/Utilizadores.aspx" />
</asp:Content>
