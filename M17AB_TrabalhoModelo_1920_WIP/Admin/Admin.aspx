<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Dashboard</h2>
    <div id="divLista"></div>
    <button id="btnLista">Carregar dados</button>
    <script>
        $(document).ready(function () {
            $("#btnLista").on('click', function (e) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: "Servicos.asmx/ListaLivros",
                    contentType: "application/json; charset=utf-8",
                    success: OnSuccess,
                    error: OnError
                });
                function OnSuccess(response) {
                    //alert(response);
                    //console.log(response);
                    var listaLivros = JSON.parse(response.d);
                    for (var i = 0; i < listaLivros.length; i++) {
                        $("#divLista").append(listaLivros[i].nome + "<br/>");
                    }
                }
                function OnError(response) {
                    alert("Alguma coisa errada correu mal");
                }
            });
        });
    </script>
</asp:Content>
