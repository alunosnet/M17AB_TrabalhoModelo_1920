<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Utilizadores.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Adicionar Utilizador</h2>
    Email:<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox><br />
    Nome:<asp:TextBox ID="tbNome" runat="server"></asp:TextBox><br />
    Morada:<asp:TextBox ID="tbMorada" runat="server"></asp:TextBox><br />
    Nif:<asp:TextBox ID="tbNif" runat="server"></asp:TextBox><br />
    Password:<asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox><br />
    Perfil:<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="0">Administrador</asp:ListItem>
        <asp:ListItem Value="1">Utilizador</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Adicionar" OnClick="Button1_Click" />

</asp:Content>
