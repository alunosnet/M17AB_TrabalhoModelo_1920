using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.Admin.Emprestimos
{
    public partial class Emprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0")
                Response.Redirect("/index.aspx");

            ConfigurarGrid();

            atualizarGrid();

            if (IsPostBack) return;
            atualizarDDLivros();
            atualizarDDUtilizadores();

        }

        private void atualizarDDUtilizadores()
        {
            Utilizador utilizador = new Utilizador();
            ddUtilizador.Items.Clear();
            DataTable dados = utilizador.listaTodosUtilizadoresDisponiveis();
            foreach(DataRow r in dados.Rows)
            {
                ddUtilizador.Items.Add(
                    new ListItem(r["nome"].ToString(),
                    r["id"].ToString())
               );
            }
        }

        private void atualizarDDLivros()
        {
            Livro livro = new Livro();
            ddLivros.Items.Clear();
            DataTable dados = livro.listaLivrosDisponiveis();
            foreach(DataRow r in dados.Rows)
            {
                ddLivros.Items.Add(
                    new ListItem(r["nome"].ToString(),
                    r["nlivro"].ToString())
                    );
            }
        }

        private void atualizarGrid()
        {
            Emprestimo emprestimo = new Emprestimo();
            GvEmprestimos.Columns.Clear();
            GvEmprestimos.DataSource = null;
            GvEmprestimos.DataBind();

            DataTable dados;

            if (cbEmprestimos.Checked)
                dados = emprestimo.listaTodosEmprestimosPorConcluirComNomes();
            else
                dados = emprestimo.listaTodosEmprestimosComNomes();

            if (dados == null || dados.Rows.Count == 0) return;

            //botões de comando
            //alterar o estado do empréstimos
            ButtonField btEstado = new ButtonField();
            btEstado.HeaderText = "Alterar estado";
            btEstado.Text = "Alterar";
            btEstado.ButtonType = ButtonType.Button;
            btEstado.CommandName = "alterar";
            btEstado.ControlStyle.CssClass = "btn btn-info";
            GvEmprestimos.Columns.Add(btEstado);

            //enviar email
            ButtonField btEmail = new ButtonField();
            btEmail.HeaderText = "Notificar";
            btEmail.Text = "Email";
            btEmail.ButtonType = ButtonType.Button;
            btEmail.CommandName = "email";
            btEmail.ControlStyle.CssClass = "btn btn-danger";
            GvEmprestimos.Columns.Add(btEmail);

            GvEmprestimos.DataSource = dados;
            GvEmprestimos.AutoGenerateColumns = true;
            GvEmprestimos.DataBind();
        }

        private void ConfigurarGrid()
        {
            //paginação
            GvEmprestimos.AllowPaging = true;
            GvEmprestimos.PageSize = 5;
            GvEmprestimos.PageIndexChanging += GvEmprestimos_PageIndexChanging;
            //botões de comando
            GvEmprestimos.RowCommand += GvEmprestimos_RowCommand;
            GvEmprestimos.RowDataBound += GvEmprestimos_RowDataBound;
        }

        private void GvEmprestimos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //executado para cada registo da grid
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime dataDevolve = DateTime.Parse(e.Row.Cells[6].Text);
                int estado = int.Parse(e.Row.Cells[7].Text);
                if(dataDevolve<DateTime.Now && estado != 0)
                {
                    e.Row.Cells[1].Controls[0].Visible = true;
                }
                else
                {
                    e.Row.Cells[1].Controls[0].Visible = false;
                }
            }
        }

        private void GvEmprestimos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page") return;
            //executado quando o utilizador click num botão de comando
            Emprestimo emprestimo = new Emprestimo();
            Utilizador utilizador = new Utilizador();
            //linha
            int linha = int.Parse(e.CommandArgument as string);
            //id emprestimo
            int idEmprestimo = int.Parse(GvEmprestimos.Rows[linha].Cells[2].Text);
            //comando
            if (e.CommandName == "alterar")
            {
                emprestimo.alterarEstadoEmprestimo(idEmprestimo);
                atualizarGrid();
                atualizarDDLivros();
            }
            if (e.CommandName == "email")
            {
                DataTable dados = emprestimo.devolveDadosEmprestimo(idEmprestimo);
                int idUtilizador = int.Parse(dados.Rows[0]["idutilizador"].ToString());
                DataTable dadosUtilizador = utilizador.devolveDadosUtilizador(idUtilizador);
                string email = dadosUtilizador.Rows[0]["email"].ToString();
                string assunto = "Livro emprestado fora do prazo";
                string mensagem = "Caro leitor deve devolver o livro que tem emprestado.";
                string ppassword = ConfigurationManager.AppSettings["pwdEmail"].ToString();

                Helper.enviarMail("alunosnet@gmail.com", ppassword, email, assunto, mensagem);
                    
            }
        }

        private void GvEmprestimos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmprestimos.PageIndex = e.NewPageIndex;
            atualizarGrid();
        }

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Emprestimo emprestimo = new Emprestimo();

                int idLivro = int.Parse(ddLivros.SelectedValue);
                int idUtilizador = int.Parse(ddUtilizador.SelectedValue);
                DateTime dataDevolve = DateTime.Parse(tbData.Text);
                emprestimo.adicionarEmprestimo(idLivro, idUtilizador, dataDevolve);

                atualizarGrid();
                atualizarDDLivros();
                atualizarDDUtilizadores();

                lbErro.Text = "Empréstimo registado com sucesso.";

            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "bg-danger";
            }
        }

        protected void cbEmprestimos_CheckedChanged(object sender, EventArgs e)
        {
            atualizarGrid();
        }
    }
}