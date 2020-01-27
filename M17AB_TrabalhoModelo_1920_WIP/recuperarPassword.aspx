<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="recuperarPassword.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.recuperarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Recuperar password</h2>
    Nova password:<asp:TextBox runat="server" ID="tbPassword" TextMode="Password" /><br />
    <asp:Button runat="server" ID="btNovaPassword" Text="Atualizar" OnClick="btNovaPassword_Click" /><br />
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
