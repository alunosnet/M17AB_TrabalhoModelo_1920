using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP
{
    public partial class recuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btNovaPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string guid = Server.UrlDecode(Request["id"].ToString());
                string novaPassword = tbPassword.Text;
                if (novaPassword == String.Empty)
                    throw new Exception("");
                Utilizador utilizador = new Utilizador();
                utilizador.atualizarPassword(guid, novaPassword);
                Response.Redirect("~/index.aspx");
            }
            catch
            {
                Response.Redirect("~/index.aspx");

            }
        }
    }
}