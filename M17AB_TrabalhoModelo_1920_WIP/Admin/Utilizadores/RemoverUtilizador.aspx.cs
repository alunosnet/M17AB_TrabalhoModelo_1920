﻿using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.Admin.Utilizadores
{
    public partial class RemoverUtilizador : System.Web.UI.Page
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
                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(id);
                if (dados == null || dados.Rows.Count == 0)
                    throw new Exception("erro");
                lbNUtilizador.Text = dados.Rows[0]["id"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
            }
            catch
            {
                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.removerUtilizador(id);
                lbErro.Text = "Utilizador removido com sucesso.";
            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "bg-danger";
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                "Redirecionar", "returnMain('/Admin/Utilizadores/Utilizadores.aspx')", true);
        }
    }
}