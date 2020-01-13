using M17AB_TrabalhoModelo_1920.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M17AB_TrabalhoModelo_1920_WIP.Models
{
    public class Livro
    {
        public int nlivro;
        public string nome;
        public int ano;
        public DateTime data_aquisicao;
        public decimal preco;
        public string autor;
        public string tipo;
        public int estado;

        BaseDados bd;

        public Livro()
        {
            bd = new BaseDados();
        }

        public void Adicionar()
        {
            string sql = @"INSERT INTO Livros(nome,ano,data_aquisicao,preco,autor,tipo,estado)
                    VALUES (@nome,@ano,@data_aquisicao,@preco,@autor,@tipo,@estado)";

        }
    }
}