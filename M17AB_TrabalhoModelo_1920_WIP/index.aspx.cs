using M17AB_TrabalhoModelo_1920_WIP.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //testar se tem login
            if (Session["perfil"] != null)
                divLogin.Visible = false;

        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string password = tbPassword.Text;
                UserLogin userLogin = new UserLogin();
                DataTable dados = userLogin.verificaLogin(email, password);
                if (dados == null || dados.Rows.Count == 0)
                    throw new Exception("O login falhou.");
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["id"] = dados.Rows[0]["id"].ToString();
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/Admin/Admin.aspx");
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/User/user.aspx");
            }
            catch
            {
                lbErro.Text = "Login falhou. Tente novamente.";
                lbErro.CssClass = "bg-danger";
            }
        }

        protected void btRecuperar_Click(object sender, EventArgs e)
        {

        }
    }
}