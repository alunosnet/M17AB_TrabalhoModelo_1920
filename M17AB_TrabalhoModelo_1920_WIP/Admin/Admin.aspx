<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="M17AB_TrabalhoModelo_1920_WIP.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Public/chartistJS/chartist.css" rel="stylesheet" />
    <script src="/Public/chartistJS/chartist.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Dashboard</h2>
    <div id="divLista"></div>
    <button id="btnLista" class="btn btn-info">Carregar dados</button>
    <button id="btnCreatePieChart" class="btn btn-info">Dados de Utilizadores</button>
    <div class="ct-chart ct-golden-section"></div>
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
            $("#btnCreatePieChart").on('click', function (e) {
                var self = $(this);
                var pData = [];
                /*pData[0] = $("#ddlyear").val();*/
                var jsonData = JSON.stringify({ pData: pData });

                $.ajax({
                    type: "POST",
                    url: "Servicos.asmx/DadosUtilizadores",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
                function OnSuccess_(response) {
                    var aData = response.d;
                    var arrLabels = [], arrSeries = [];
                    $.map(aData, function (item, index) {
                        arrLabels.push(item.perfil);
                        arrSeries.push(item.contagem);
                    });
                    var data = {
                        labels: arrLabels,
                        series: arrSeries
                    }
                    // This is themain part, where we set data and create PIE CHART
                    new Chartist.Pie('.ct-chart', data);
                }

                function OnErrorCall_(response) {
                    alert("Whoops something went wrong!");
                }
                e.preventDefault();
            });

        });
    </script>
</asp:Content>
