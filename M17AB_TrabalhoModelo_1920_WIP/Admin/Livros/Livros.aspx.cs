using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_1920_WIP.Admin.Livros
{
    public partial class Livros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: página para admin
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            //validar form

            //criar objeto livro
            Livro livro = new Livro();
            //preencher propriedades
            livro.ano = int.Parse(tbAno.Text);
            livro.autor = tbAutor.Text;
            livro.data_aquisicao = Calendar1.SelectedDate;
            livro.estado = 1;
            livro.nome = tbNome.Text;
            livro.preco = decimal.Parse(tbPreco.Text);
            livro.tipo = tbTipo.Text;
            //TODO: guardar imagem da capa
            //guardar
            livro.Adicionar();
            //limpar
            tbAno.Text = "";
            tbAutor.Text = "";
            tbNome.Text = "";
            tbPreco.Text = "";
            tbTipo.Text = "";
        }
    }
}