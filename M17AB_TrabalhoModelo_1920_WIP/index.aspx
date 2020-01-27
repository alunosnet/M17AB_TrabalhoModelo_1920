<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--Login-->
    <div id="divLogin" runat="server" class="float-right col-sm-3 table-bordered divLogin" style="z-index:9999">
        Email:<asp:TextBox runat="server" ID="tbEmail" TextMode="Email" CssClass="form-control" />
        Password:<asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="form-control" />
        <asp:Button runat="server" ID="Button1" Text="Login" 
            CssClass="btn btn-outline-success" OnClick="btLogin_Click" />
        <asp:Button runat="server" ID="Button2" Text="Recuperar password" 
            CssClass="btn btn-danger" OnClick="btRecuperar_Click" />
        <br /><asp:Label runat="server" ID="lbErro"></asp:Label>
    </div>
    <!--Pesquisa-->
        <div class="col-sm-8"><h1>Livros Online</h1></div>
    <div class="float-left col-sm-8 input-group">
        <asp:TextBox runat="server" ID="tbPesquisa" CssClass="form-control" />
        <span class="input-group-btn">
            <asp:Button runat="server" ID="btPesquisa" Text="Pesquisar"
                 CssClass="btn btn-info" OnClick="btPesquisa_Click"  />
        </span>
    </div>
    <!--Lista dos livros-->
    <div id="divLivros" runat="server" class="float-left col-md-8 m-1"></div>
</asp:Content>
