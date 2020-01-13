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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //validar o formulário

            //criar o objeto
            Utilizador utilizador = new Utilizador();
            //preencher propriedades
            utilizador.email = tbEmail.Text;
            utilizador.nome = tbNome.Text;
            utilizador.morada = tbMorada.Text;
            utilizador.nif = tbNif.Text;
            utilizador.password = tbPassword.Text;
            utilizador.perfil =int.Parse(DropDownList1.SelectedValue);

            //guardar
            utilizador.Adicionar();
            //limpar
            tbEmail.Text = "";
            tbNome.Text = "";
            tbMorada.Text = "";
            tbNif.Text = "";
            DropDownList1.SelectedIndex = 0;
        }
    }
}