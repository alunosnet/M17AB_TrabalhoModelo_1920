using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.User.Emprestimos
{
    public partial class Emprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] == null)
                Response.Redirect("~/index.aspx");

            ConfigurarGrid();
            
            AtualizarGrid();

        }

        private void AtualizarGrid()
        {
            gvEmprestar.Columns.Clear();
            gvEmprestar.DataSource = null;
            gvEmprestar.DataBind();

            Livro livro = new Livro();

            gvEmprestar.DataSource = livro.listaLivrosDisponiveis();

            //botão reservar
            ButtonField btReservar = new ButtonField();
            btReservar.HeaderText = "Reservar livro";
            btReservar.Text = "Reservar";
            btReservar.ButtonType = ButtonType.Button;
            btReservar.CommandName = "reservar";
            btReservar.ControlStyle.CssClass = "btn btn-info";
            gvEmprestar.Columns.Add(btReservar);

            gvEmprestar.DataBind();
        }

        private void ConfigurarGrid()
        {
            gvEmprestar.RowCommand += GvEmprestar_RowCommand;
        }

        private void GvEmprestar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //linha
            int linha = int.Parse(e.CommandArgument as string);
            //id livro
            int idlivro = int.Parse(gvEmprestar.Rows[linha].Cells[1].Text);
            //id utilizador
            int idutilizador = int.Parse(Session["id"].ToString());
            //comando reservar
            if (e.CommandName == "reservar")
            {
                Emprestimo emprestimo = new Emprestimo();
                emprestimo.adicionarReserva(idlivro, idutilizador, DateTime.Now.AddDays(7));
                //atualizar grid
                AtualizarGrid();
            }
        }
    }
}