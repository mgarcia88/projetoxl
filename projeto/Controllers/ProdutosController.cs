using projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index(int? id)
        {
           
            string teste = Request.RawUrl;
            List<Models.Produtos> produtos = new List<Models.Produtos>();
            int totalPorPagina = 15;
            int totalPaginas = 0;
            int pagina = 0;

            if (id == null)
                pagina = 1;
            else
                pagina = Convert.ToInt32(id);

            if (Request.Form.Count > 0)
            {

                string parametroBusca = Request.Form["tbPesquisa"].ToString();

                if (!string.IsNullOrEmpty(parametroBusca))
                {
                    Produtos prod = new Produtos();
                    produtos = prod.SelecionarProdutos(parametroBusca);
                }

            }
            else {

                Produtos prod = new Produtos();
                produtos = prod.SelecionarProdutos("");
            }


            int resto = produtos.Count % totalPorPagina;
            totalPaginas = produtos.Count / totalPorPagina;

            if (resto > 0)
                totalPaginas++;

            ViewBag.TotalPaginas = totalPaginas;

            

            return View(produtos.Skip((pagina - 1) * 15).Take(15).ToList());
        }

      
   }
}