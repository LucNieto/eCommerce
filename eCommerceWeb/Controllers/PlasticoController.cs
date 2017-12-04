using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace eCommerceWeb.Controllers
{
    public class PlasticoController : Controller
    {
        // GET: Tarjeta
        public ActionResult Index() {
            PlasticoBLL oBLL = new PlasticoBLL();
            List<plastico> tarjetas = oBLL.RetrieveAll();
            return View(tarjetas);
        }


        // GET: plastico/Create
        public ActionResult Create() {
            return View();
        }

        // POST: plastico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(plastico tarjeta) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    PlasticoBLL oBLL = new PlasticoBLL();
                    oBLL.Create(tarjeta);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(tarjeta);
                }
                return Result;
            } catch (Exception e) {
                return View(tarjeta);
            }
        }

        // GET: plastico/Edit/5
        public ActionResult Edit(int id) {
            PlasticoBLL oBLL = new PlasticoBLL();
            plastico tarjeta = oBLL.Retrieve(id);

            return View(tarjeta);
        }

        // POST: plastico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(plastico tarjeta) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    PlasticoBLL oBLL = new PlasticoBLL();
                    oBLL.Edit(tarjeta);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(tarjeta);
                }
                return Result;
            } catch (Exception e) {
                return View(tarjeta);
            }
        }

        // GET: plastico/Delete/5


        public ActionResult Details(int id) {
            PlasticoBLL oBLL = new PlasticoBLL();
            plastico tarjeta = oBLL.Retrieve(id);
            return View(tarjeta);
        }

        public ActionResult Delete(int id) {
            PlasticoBLL oBLL = new PlasticoBLL();
            oBLL.Delete(id);

            return RedirectToAction("Index");
        }
    }
}