using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

            DataTable dados= utilizador.ListaTodosUtilizadores();

            GvUtilizadores.DataSource = dados;
            GvUtilizadores.AutoGenerateColumns = false;

            //remover
            DataColumn dcRemover = new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);
            //editar
            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            //bloquear
            DataColumn dcBloquear = new DataColumn();
            dcBloquear.ColumnName = "Bloquear";
            dcBloquear.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcBloquear);
            //histórico
            DataColumn dcHistorico = new DataColumn();
            dcHistorico.ColumnName = "Historico";
            dcHistorico.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcHistorico);

            //gridview
            HyperLinkField hlRemover = new HyperLinkField();
            hlRemover.HeaderText = "Remover";
            hlRemover.DataTextField = "Remover";
            hlRemover.Text = "Remover";
            hlRemover.DataNavigateUrlFormatString = "RemoverUtilizador.aspx?id={0}";
            hlRemover.DataNavigateUrlFields = new string[] { "id" };
            GvUtilizadores.Columns.Add(hlRemover);

            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar";
            hlEditar.DataNavigateUrlFormatString = "EditarUtilizador.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            GvUtilizadores.Columns.Add(hlEditar);

            HyperLinkField hlBloquear = new HyperLinkField();
            hlBloquear.HeaderText = "Bloquear";
            hlBloquear.DataTextField = "Bloquear";
            hlBloquear.Text = "Bloquear";
            hlBloquear.DataNavigateUrlFormatString = "BloquearUtilizador.aspx?id={0}";
            hlBloquear.DataNavigateUrlFields = new string[] { "id" };
            GvUtilizadores.Columns.Add(hlBloquear);

            HyperLinkField hlHistorico = new HyperLinkField();
            hlHistorico.HeaderText = "Histórico";
            hlHistorico.DataTextField = "Historico";
            hlHistorico.Text = "Histórico";
            hlHistorico.DataNavigateUrlFormatString = "HistoricoUtilizador.aspx?id={0}";
            hlHistorico.DataNavigateUrlFields = new string[] { "id" };
            GvUtilizadores.Columns.Add(hlHistorico);
            //id
            BoundField bfId = new BoundField();
            bfId.HeaderText = "Id";
            bfId.DataField = "id";
            bfId.Visible = false;
            GvUtilizadores.Columns.Add(bfId);
            //email
            BoundField bfEmail = new BoundField();
            bfEmail.HeaderText = "Email";
            bfEmail.DataField = "email";
            GvUtilizadores.Columns.Add(bfEmail);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            GvUtilizadores.Columns.Add(bfNome);
            //morada
            BoundField bfMorada = new BoundField();
            bfMorada.HeaderText = "Morada";
            bfMorada.DataField = "morada";
            GvUtilizadores.Columns.Add(bfMorada);
            //nif
            BoundField bfNif = new BoundField();
            bfNif.HeaderText = "Nif";
            bfNif.DataField = "nif";
            GvUtilizadores.Columns.Add(bfNif);
            //estado
            BoundField bfEstado = new BoundField();
            bfEstado.HeaderText = "Estado";
            bfEstado.DataField = "estado";
            GvUtilizadores.Columns.Add(bfEstado);
            //perfil
            BoundField bfPerfil = new BoundField();
            bfPerfil.HeaderText = "Perfil";
            bfPerfil.DataField = "perfil";
            GvUtilizadores.Columns.Add(bfPerfil);
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