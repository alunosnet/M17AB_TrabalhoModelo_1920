using M17AB_TrabalhoModelo_1920.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace M17AB_TrabalhoModelo_1920_WIP.Models
{
    public class Utilizador
    {
        public int id;
        public string nome;
        public string email;
        public string morada;
        public string nif;
        public string password;
        public int perfil;

        BaseDados bd;

        public Utilizador()
        {
            bd = new BaseDados();
        }

        //adicionar
        public void Adicionar()
        {
            string sql = @"INSERT INTO utilizadores(email,nome,morada,nif,password,estado,perfil)
                            VALUES (@email,@nome,@morada,@nif,HASHBYTES('SHA2_512',@password),@estado,@perfil)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@morada",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.morada
                },
                new SqlParameter()
                {
                    ParameterName="@nif",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nif
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@estado",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=1
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
            };
            bd.executaSQL(sql, parametros);
        }
        //TODO: continuar aqui!!!
        internal object ListaTodosUtilizadores()
        {
            throw new NotImplementedException();
        }
        //remover
        //editar
        //listar_todos
    }
}