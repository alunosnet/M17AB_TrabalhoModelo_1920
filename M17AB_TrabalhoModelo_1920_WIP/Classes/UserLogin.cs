using M17AB_TrabalhoModelo_1920.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace M17AB_TrabalhoModelo_1920_WIP.Classes
{
    public class UserLogin
    {
        BaseDados bd;

        public UserLogin()
        {
            this.bd = new BaseDados();
        }

        public DataTable verificaLogin(string email, string password)
        {
            string sql = $@"SELECT * FROM Utilizadores WHERE 
                     email=@email AND password=HASHBYTES('SHA2_512',@password)
                     AND estado=1";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=SqlDbType.VarChar,
                    Value=email
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=SqlDbType.VarChar,
                    Value=password
                }
            };
            DataTable utilizador = bd.devolveSQL(sql, parametros);
            if (utilizador == null || utilizador.Rows.Count == 0)
                return null;

            return utilizador;
        }
    }
}