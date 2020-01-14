<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Utilizadores.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Utilizadores</h2>
    <asp:GridView runat="server" ID="GvUtilizadores" />
    <h2>Adicionar Utilizador</h2>
    Email:<asp:TextBox CssClass="form-control" ID="tbEmail" runat="server"></asp:TextBox><br />
    Nome:<asp:TextBox CssClass="form-control" ID="tbNome" runat="server"></asp:TextBox><br />
    Morada:<asp:TextBox CssClass="form-control" ID="tbMorada" runat="server"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control" ID="tbNif" runat="server"></asp:TextBox><br />
    Password:<asp:TextBox CssClass="form-control" ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox><br />
    Perfil:<asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
        <asp:ListItem Value="0">Administrador</asp:ListItem>
        <asp:ListItem Value="1">Utilizador</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <asp:Button ID="Button1" CssClass="btn btn-lg btn-danger" runat="server" Text="Adicionar" OnClick="Button1_Click" />

</asp:Content>
