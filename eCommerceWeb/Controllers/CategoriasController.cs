using BLL;
using Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWeb.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            CategoriasBLL oBLL = new CategoriasBLL();
            List<categoria> categorias = oBLL.RetrieveAll();
            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(categoria categoria)
        {
            ActionResult Result;
            try
            {
                if (ModelState.IsValid)
                {
                    CategoriasBLL oBLL = new CategoriasBLL();
                    oBLL.Create(categoria);
                    Result = RedirectToAction("Index");
                }
                else
                {
                    Result = View(categoria);
                }
                return Result;
            }
            catch (Exception e)
            {
                return View(categoria);
            }
        }

        public ActionResult Edit(int id)
        {
            CategoriasBLL oBLL = new CategoriasBLL();
            categoria categoria = oBLL.Retrieve(id);

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(categoria categoria)
        {
            ActionResult Result;
            try
            {
                if (ModelState.IsValid)
                {
                    CategoriasBLL oBLL = new CategoriasBLL();
                    oBLL.Edit(categoria);
                    Result = RedirectToAction("Index");
                }
                else
                {
                    Result = View(categoria);
                }
                return Result;
            }
            catch (Exception e)
            {
                return View(categoria);
            }
        }

        public ActionResult Details(int id) {
            CategoriasBLL oBLL = new CategoriasBLL();
            categoria cate = oBLL.Retrieve(id);
            return View(cate);
        }

        public ActionResult Delete(int id)
        {
            CategoriasBLL oBLL = new CategoriasBLL();
            oBLL.Delete(id);

            return RedirectToAction("Index");
        }



    }
}