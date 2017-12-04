using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWeb.Controllers
{
    public class DepositoController : Controller
    {
        // GET: Deposito
        public ActionResult Index() {
            DepositoBLL oBLL = new DepositoBLL();
            List<deposito> depositos = oBLL.RetrieveAll();
            return View(depositos);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(deposito deposito) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    DepositoBLL oBLL = new DepositoBLL();
                    oBLL.Create(deposito);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(deposito);
                }
                return Result;
            } catch (Exception e) {
                return View(deposito);
            }
        }

        public ActionResult Edit(int id) {
            DepositoBLL oBLL = new DepositoBLL();
            deposito deposito = oBLL.Retrieve(id);

            return View(deposito);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(deposito deposito) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    DepositoBLL oBLL = new DepositoBLL();
                    oBLL.Edit(deposito);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(deposito);
                }
                return Result;
            } catch (Exception e) {
                return View(deposito);
            }
        }

        public ActionResult Details(int id) {
            DepositoBLL oBLL = new DepositoBLL();
            deposito cate = oBLL.Retrieve(id);
            return View(cate);
        }

        public ActionResult Delete(int id) {
            DepositoBLL oBLL = new DepositoBLL();
            oBLL.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
