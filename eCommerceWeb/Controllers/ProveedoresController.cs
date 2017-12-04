using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWeb.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public ActionResult Index() {
            ProveedoresBLL oBLL = new ProveedoresBLL();
            List<proveedor> proveedors = oBLL.RetrieveAll();
            return View(proveedors);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(proveedor proveedor) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    ProveedoresBLL oBLL = new ProveedoresBLL();
                    oBLL.Create(proveedor);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(proveedor);
                }
                return Result;
            } catch (Exception e) {
                return View(proveedor);
            }
        }

        public ActionResult Edit(int id) {
            ProveedoresBLL oBLL = new ProveedoresBLL();
            proveedor proveedor = oBLL.Retrieve(id);

            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor proveedor) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    ProveedoresBLL oBLL = new ProveedoresBLL();
                    oBLL.Update(proveedor);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(proveedor);
                }
                return Result;
            } catch (Exception e) {
                return View(proveedor);
            }
        }

        public ActionResult Details(int id) {
            ProveedoresBLL oBLL = new ProveedoresBLL();
            proveedor cate = oBLL.Retrieve(id);
            return View(cate);
        }

        public ActionResult Delete(int id) {
            ProveedoresBLL oBLL = new ProveedoresBLL();
            oBLL.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
