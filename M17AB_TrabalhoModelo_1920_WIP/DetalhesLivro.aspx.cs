using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP
{
    public partial class DetalhesLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Livro livro = new Livro();
                DataTable dados = livro.devolveDadosLivro(id);
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbAno.Text = dados.Rows[0]["ano"].ToString();
                lbAutor.Text = dados.Rows[0]["autor"].ToString();
                string ficheiro = @"~\Public\Images\" + dados.Rows[0]["nlivro"].ToString() + ".jpg";
                imgCapa.ImageUrl = ficheiro;
                imgCapa.Width = 200;
                //criar cookie
                HttpCookie cookie = new HttpCookie("ultimolivro", Server.UrlEncode(lbAutor.Text));
                cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cookie);
            }
            catch
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void btReservar_Click(object sender, EventArgs e)
        {
            try
            {
                int idlivro = int.Parse(Request["id"].ToString());
                //id utilizador
                int idutilizador = int.Parse(Session["id"].ToString());
                Emprestimo emprestimo = new Emprestimo();
                emprestimo.adicionarReserva(idlivro, idutilizador, DateTime.Now.AddDays(7));
                lbMensagem.Text = "Reserva realizada com sucesso.";
                //redirecionar
                ScriptManager.RegisterStartupScript(this,
                    typeof(Page), "Redirecionar", "returnMain('/index.aspx');", true);
            }
            catch (Exception err)
            {
                lbMensagem.Text = "Ocorreu o seguinte erro: " + err.Message;
            }
        }
    }
}