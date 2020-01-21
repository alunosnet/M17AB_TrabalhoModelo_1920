<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarUtilizador.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores.EditarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar Utilizador</h2>
    Nome:<asp:TextBox CssClass="form-control" ID="tbNome" runat="server"></asp:TextBox><br />
    Morada:<asp:TextBox CssClass="form-control" ID="tbMorada" runat="server"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control" ID="tbNif" runat="server"></asp:TextBox><br />

    <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <asp:Button ID="Button1" CssClass="btn btn-lg btn-danger" runat="server" Text="Atualizar" OnClick="Button1_Click" />

</asp:Content>
