using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index() {
            ClienteBLL oBLL = new ClienteBLL();
            List<cliente> clientes = oBLL.RetrieveAll();
            return View(clientes);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cliente cliente) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    ClienteBLL oBLL = new ClienteBLL();
                    oBLL.Create(cliente);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(cliente);
                }
                return Result;
            } catch (Exception e) {
                return View(cliente);
            }
        }

        public ActionResult Edit(int id) {
            ClienteBLL oBLL = new ClienteBLL();
            cliente cliente = oBLL.Retrieve(id);

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cliente cliente) {
            ActionResult Result;
            try {
                if (ModelState.IsValid) {
                    ClienteBLL oBLL = new ClienteBLL();
                    oBLL.Edit(cliente);
                    Result = RedirectToAction("Index");
                } else {
                    Result = View(cliente);
                }
                return Result;
            } catch (Exception e) {
                return View(cliente);
            }
        }

        public ActionResult Details(int id) {
            ClienteBLL oBLL = new ClienteBLL();
            cliente cate = oBLL.Retrieve(id);
            return View(cate);
        }

        public ActionResult Delete(int id) {
            ClienteBLL oBLL = new ClienteBLL();
            oBLL.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
