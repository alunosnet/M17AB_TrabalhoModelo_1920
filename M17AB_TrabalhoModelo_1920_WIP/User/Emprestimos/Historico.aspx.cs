using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.User.Emprestimos
{
    public partial class Historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null)
                Response.Redirect("~/index.aspx");

            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int id = int.Parse(Session["id"].ToString());
            Emprestimo emprestimo = new Emprestimo();

            gvHistorico.DataSource = emprestimo.listaTodosEmprestimosComNomes(id);
            gvHistorico.DataBind();
        }
    }
}