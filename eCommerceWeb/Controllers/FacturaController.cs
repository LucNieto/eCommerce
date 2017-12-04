using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWeb.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index() {
            FacturaBLL oBLL = new FacturaBLL();
            List<factura> facturas = oBLL.RetrieveAll();
            return View(facturas);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(factura factura) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    FacturaBLL oBLL = new FacturaBLL();
                    oBLL.Create(factura);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(factura);
                }
                return Result;
            } catch (Exception e) {
                return View(factura);
            }
        }

        public ActionResult Edit(int id) {
            FacturaBLL oBLL = new FacturaBLL();
            factura factura = oBLL.Retrieve(id);

            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(factura factura) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    FacturaBLL oBLL = new FacturaBLL();
                    oBLL.Edit(factura);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(factura);
                }
                return Result;
            } catch (Exception e) {
                return View(factura);
            }
        }

        public ActionResult Details(int id) {
            FacturaBLL oBLL = new FacturaBLL();
            factura cate = oBLL.Retrieve(id);
            return View(cate);
        }

        public ActionResult Delete(int id) {
            FacturaBLL oBLL = new FacturaBLL();
            oBLL.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
