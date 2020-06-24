using M17AB_TrabalhoModelo_1920.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.Admin.Consultas
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0")
                Response.Redirect("/index.aspx");

        }

        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizaGrelhaConsultas();
        }

        private void atualizaGrelhaConsultas()
        {
            gvConsultas.Columns.Clear();
            int iconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (iconsulta)
            {
                case 0:
                    sql = @"select nome,count(nlivro) as [nr emprestimos] from utilizadores inner join emprestimos
                                on utilizadores.id=emprestimos.idutilizador
                                group by utilizadores.id,nome
                                order by [nr emprestimos] DESC";
                    break;
                case 1:
                    sql = @"select nome,count(*) as [nr emprestimos] from livros inner join emprestimos
                                on livros.nlivro=emprestimos.nlivro
                                group by livros.nlivro,nome
                                order by [nr emprestimos] DESC";
                    break;
                case 2:
                    sql = @"select emprestimos.*,utilizadores.nome as Leitor,utilizadores.email,livros.nome as Livro
                                from emprestimos
                                inner join utilizadores on utilizadores.id=emprestimos.idutilizador
                                inner join livros on livros.nlivro=emprestimos.nlivro
                                where emprestimos.estado=1 and data_devolve<getdate()
                                order by emprestimos.data_devolve 
                                ";
                    break;
                case 3:
                    sql = @"select nome,data_aquisicao from livros
                                where DATEDIFF(day, data_aquisicao, getdate())< 7";
                    break;
                case 4:
                    sql = @"select avg(datediff(day,data_emprestimo,data_devolve)) from emprestimos";
                    break;
                case 5:
                    sql = @"select nome from utilizadores inner join emprestimos 
                            on emprestimos.idutilizador=utilizadores.id
                            where emprestimos.nlivro=(select top 1 nlivro from livros order by preco desc)";
                    break;
            }
            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();
        }
    }
}