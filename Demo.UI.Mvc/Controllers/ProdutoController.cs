using AutoMapper;
using Demo.Domain.Entities;
using Demo.Domain.Interface.Application;
using Demo.UI.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Demo.UI.Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoApplication _produtoApplication;

        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var produtosView = Mapper.Map<List<ProdutoView>>(_produtoApplication.GetAll());
            return View(produtosView);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var produto = new ProdutoView();
            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            _produtoApplication.Delete(id);
            return PartialView("_ListaDeProdutos", Mapper.Map<List<ProdutoView>>(_produtoApplication.GetAll()));
        }

        [HttpPost]
        public ActionResult Add(ProdutoView produtoView)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<Produto>(produtoView);

                try
                {
                    _produtoApplication.Add(produto);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Validação", ex.Message);
                    return View(produtoView);
                }
            }

            return View(produtoView);
        }
    }
}