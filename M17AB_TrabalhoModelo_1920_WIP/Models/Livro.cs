using M17AB_TrabalhoModelo_1920.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public int Adicionar()
        {
            string sql = @"INSERT INTO Livros(nome,ano,data_aquisicao,preco,autor,tipo,estado)
                    VALUES (@nome,@ano,@data_aquisicao,@preco,@autor,@tipo,@estado);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.preco
                },
                new SqlParameter()
                {
                    ParameterName="@autor",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.autor
                },
                new SqlParameter()
                {
                    ParameterName="@tipo",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.tipo
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.estado
                },
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }

        internal DataTable ListaTodosLivros()
        {
            string sql = @"SELECT nlivro,nome,ano,data_aquisicao,
                    preco, autor, tipo,
                    case
                        when estado=0 then 'Emprestado'
                        when estado=1 then 'Disponível'
                        when estado=2 then 'Reservado'
                    end as estado
                    FROM Livros";
            return bd.devolveSQL(sql);
        }
    }
}