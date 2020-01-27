<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.User.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Utilizador</h2>
    <div runat="server" id="divPerfil">
        Nome:<asp:Label CssClass="form-control" runat="server" ID="lbNome" /><br />
        Morada:<asp:Label CssClass="form-control" runat="server" ID="lbMorada" /><br />
        Nif:<asp:Label CssClass="form-control" runat="server" ID="lbNif" /><br />
        <asp:Button CssClass="btn btn-info" runat="server" ID="btEditar"
            Text="Editar" OnClick="btEditar_Click" />
    </div>
    <div runat="server" id="divEditarPerfil">
        Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tbNome" /><br />
        Morada:<asp:TextBox CssClass="form-control" runat="server" ID="tbMorada" /><br />
        Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tbNif" /><br />
        <asp:Button CssClass="btn btn-danger" runat="server" ID="btAtualizar"
            Text="Atualizar" OnClick="btAtualizar_Click" />
        <asp:Button CssClass="btn btn-info" runat="server" ID="btCancelar"
            Text="Cancelar" OnClick="btCancelar_Click" />
    </div>
</asp:Content>
