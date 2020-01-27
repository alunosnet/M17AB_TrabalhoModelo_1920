using M17AB_TrabalhoModelo_1920_WIP.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M17AB_TrabalhoModelo_1920_WIP.Models;

namespace M17AB_TrabalhoModelo_1920_WIP
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //testar se tem login
            if (Session["perfil"] != null)
                divLogin.Visible = false;

        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string password = tbPassword.Text;
                UserLogin userLogin = new UserLogin();
                DataTable dados = userLogin.verificaLogin(email, password);
                if (dados == null || dados.Rows.Count == 0)
                    throw new Exception("O login falhou.");
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["id"] = dados.Rows[0]["id"].ToString();
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/Admin/Admin.aspx");
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/User/user.aspx");
            }
            catch
            {
                lbErro.Text = "Login falhou. Tente novamente.";
                lbErro.CssClass = "bg-danger";
            }
        }

        protected void btRecuperar_Click(object sender, EventArgs e)
        {

        }

        private void atualizaGrelhaLivros(string pesquisa = null, int? ordena = null)
        {
            Livro livro = new Livro();
            DataTable dados;
            //listar todos os livros disponiveis
            if (pesquisa == null)
            {
                //se existir o cookie ultimolivro listar os livros do mesmo autor
                HttpCookie cookieAutor = Request.Cookies["ultimolivro"];
                if (cookieAutor == null)
                    dados = livro.listaLivrosDisponiveis(ordena);
                else
                    dados = livro.listaLivrosDoAutor(Server.UrlDecode(cookieAutor.Value));
            }
            else
                dados = livro.listaLivrosDisponiveis(pesquisa, ordena);

            GerarIndex(dados);
        }
        private void GerarIndex(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divLivros.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow livro in dados.Rows)
            {
                grelha += "<div class='col'>";
                grelha += "<img src='/Public/Images/" + livro[0].ToString() +
                    ".jpg' class='img-fluid'/>";
                grelha += "<p/><span class='stat-title'>" + livro[1].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'>" +
                    String.Format(" | {0:C}", Decimal.Parse(livro["preco"].ToString()))
                    + "</span>";
                grelha += "<br/><a href='detalheslivro.aspx?id=" + livro[0].ToString()
                    + "'>Detalhes</a>";
                grelha += "</div>";
            }

            grelha += "</div></div>";
            divLivros.InnerHtml = grelha;
        }

    }
}