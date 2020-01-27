using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores
{
    public partial class HistoricoUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0")
                Response.Redirect("/index.aspx");

            try
            {
                int id = int.Parse(Request["id"].ToString());
                Emprestimo emprestimo = new Emprestimo();
                gvHistorico.DataSource = emprestimo.listaTodosEmprestimosComNomes(id);
                gvHistorico.DataBind();
            }
            catch
            {
                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
            }
        }
    }
}