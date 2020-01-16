using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores
{
    public partial class Utilizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: página só para admins

            ConfigurarGrid();
            
            if(!IsPostBack)
                AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            //limpar gridview
            GvUtilizadores.Columns.Clear();
            GvUtilizadores.DataSource = null;
            GvUtilizadores.DataBind();

            Utilizador utilizador = new Utilizador();

            GvUtilizadores.DataSource = utilizador.ListaTodosUtilizadores();
            GvUtilizadores.DataBind();

        }

        private void ConfigurarGrid()
        {
            //paginação
            GvUtilizadores.AllowPaging = true;
            GvUtilizadores.PageSize = 5;
            GvUtilizadores.PageIndexChanging += GvUtilizadores_PageIndexChanging;
        }

        private void GvUtilizadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUtilizadores.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //validar o form
                string email = tbEmail.Text;

                if (email == String.Empty || email.Contains("@") == false)
                    throw new Exception("O email indicado não é válido.");

                string nome = tbNome.Text;
                if (nome == String.Empty || nome.Trim().Length < 2)
                    throw new Exception("O nome indicado não é válido. Deve ter pelo menos 2 letras.");

                string morada = tbMorada.Text;
                if (morada == String.Empty || morada.Trim().Length < 2)
                    throw new Exception("A morada indicado não é válido. Deve ter pelo menos 2 letras.");

                string nif = tbNif.Text;
                int inif = int.Parse(nif);
                if (nif.Length != 9)
                    throw new Exception("O nif deve ter 9 digitos.");

                int perfil = int.Parse(DropDownList1.SelectedValue);
                if (perfil != 0 && perfil != 1)
                    throw new Exception("Perfil inválido");

                string password = tbPassword.Text;
                if (password.Trim().Length < 5)
                    throw new Exception("A password tem de ter pelo menos 5 letras");

                //criar o objeto
                Utilizador utilizador = new Utilizador();
                //preencher propriedades
                utilizador.email = tbEmail.Text;
                utilizador.nome = tbNome.Text;
                utilizador.morada = tbMorada.Text;
                utilizador.nif = tbNif.Text;
                utilizador.password = tbPassword.Text;
                utilizador.perfil = int.Parse(DropDownList1.SelectedValue);

                //guardar
                utilizador.Adicionar();
            }
            catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert";
                return;
            }
            
            //limpar
            tbEmail.Text = "";
            tbNome.Text = "";
            tbMorada.Text = "";
            tbNif.Text = "";
            DropDownList1.SelectedIndex = 0;
            lbErro.Text = "";
            AtualizarGrid();
        }
    }
}