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
    public partial class EditarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0")
                Response.Redirect("/index.aspx");

            if (IsPostBack) return;

            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador utilizador = new Utilizador();

                DataTable dados = utilizador.devolveDadosUtilizador(id);
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe.";
                //redirecionar 
                ScriptManager.RegisterStartupScript(this,
                    typeof(Page), "Redirecionar",
                "returnMain('/Admin/Utilizadores/Utilizadores.aspx');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id= int.Parse(Request["id"].ToString());

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

                Utilizador utilizador = new Utilizador();
                utilizador.id = id;
                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.nif = nif;

                utilizador.atualizarUtilizador();

                lbErro.Text = "O utilizador foi atualizado com sucesso";
                ScriptManager.RegisterStartupScript(this,
                    typeof(Page), "Redirecionar",
                "returnMain('/Admin/Utilizadores/Utilizadores.aspx');", true);
            }
            catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;

            }
        }
    }
}