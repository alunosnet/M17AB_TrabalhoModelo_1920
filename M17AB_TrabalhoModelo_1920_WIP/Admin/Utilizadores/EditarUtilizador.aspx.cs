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
            //TODO:página para admin

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

        }
    }
}