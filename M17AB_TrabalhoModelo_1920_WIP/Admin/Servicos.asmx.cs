using M17AB_TrabalhoModelo_1920_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace M17AB_TrabalhoModelo_1920_WIP.Admin
{
    /// <summary>
    /// Summary description for Servicos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Servicos : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListaLivros()
        {
            Livro livro = new Livro();
            DataTable dados = livro.ListaTodosLivros();
            List<Livro> lLivros = new List<Livro>();
            for(int i = 0; i < dados.Rows.Count; i++)
            {
                Livro novo = new Livro();
                novo.nlivro = int.Parse(dados.Rows[i]["nlivro"].ToString());
                novo.nome = dados.Rows[i]["nome"].ToString();
                novo.preco = Decimal.Parse(dados.Rows[i]["preco"].ToString());
                lLivros.Add(novo);
            }
            return new JavaScriptSerializer().Serialize(lLivros);
        }
    }
}
