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

            try
            {
                //capa
                if (FileUpload1.HasFile == false)
                    throw new Exception("Tem de indicar o ficheiro da capa");
                if (FileUpload1.PostedFile.ContentType != "image/jpeg" &&
                    FileUpload1.PostedFile.ContentType != "image/jpg" &&
                    FileUpload1.PostedFile.ContentType != "image/png")
                    throw new Exception("O formato do ficheiro da capa não é suportado.");
                if (FileUpload1.PostedFile.ContentLength == 0 ||
                    FileUpload1.PostedFile.ContentLength > 5000000)
                    throw new Exception("O tamanho do ficheiro não é válido.");

              

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
                int idlivro=livro.Adicionar();

                //copiar o ficheiro
                string ficheiro = Server.MapPath(@"~\Public\Images\");
                ficheiro += idlivro + ".jpg";
                FileUpload1.SaveAs(ficheiro);

            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert";
                return;
            }
            //limpar
            tbAno.Text = "";
            tbAutor.Text = "";
            tbNome.Text = "";
            tbPreco.Text = "";
            tbTipo.Text = "";
            lbErro.Text = "";

            //TODO: atualizar grelha
        }
    }
}