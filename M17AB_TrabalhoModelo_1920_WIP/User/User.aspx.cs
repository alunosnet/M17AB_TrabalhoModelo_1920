using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.User
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null)
                Response.Redirect("~/index.aspx");

            

            if (!IsPostBack)
            {
                divEditarPerfil.Visible = false;
                MostrarPerfil();
            }
        }

        private void MostrarPerfil()
        {
            Utilizador utilizador = new Utilizador();
            int id = int.Parse(Session["id"].ToString());
            DataTable dados = utilizador.devolveDadosUtilizador(id);
            if (divPerfil.Visible)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbMorada.Text = dados.Rows[0]["morada"].ToString();
                lbNif.Text = dados.Rows[0]["nif"].ToString();
            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Session["id"].ToString());
                string morada = tbMorada.Text;
                string nif = tbNif.Text;
                string nome = tbNome.Text;
                Utilizador utilizador = new Utilizador();
                utilizador.id = id;
                utilizador.nome = nome;
                utilizador.nif = nif;
                utilizador.morada = morada;
                utilizador.atualizarUtilizador();
                divEditarPerfil.Visible = false;
                divPerfil.Visible = true;
                MostrarPerfil();
            }
            catch
            {
                divEditarPerfil.Visible = false;
                divPerfil.Visible = true;
                MostrarPerfil();
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditarPerfil.Visible = false;
            MostrarPerfil();
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditarPerfil.Visible = true;
            MostrarPerfil();
        }
    }
}