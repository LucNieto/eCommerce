using BLL;
using eCommerceWeb.Models;
using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.RetunrUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login data, string returnUrl) {
            UsuariosBLL oBLL = new UsuariosBLL();
            
            ActionResult Result;
            //Autentificar al Usuario
            Usuario usuario = oBLL.Sesion(data.Email, data.Password);
           
            if (usuario != null) {

                Result = SignInUser(usuario, data.rememberMe, returnUrl);

            } else {

                Result = View(data);
            }
            return Result;
        }

        [AllowAnonymous]
        private ActionResult SignInUser(Usuario user, bool rememberMe, string returnUrl) {

            ActionResult Result;
            var Claims = new List<Claim>();///crear los claims adicionales del usuario que nos interesa almacenar
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UsuarioId));
            Claims.Add(new Claim(ClaimTypes.Email, user.email));
            Claims.Add(new Claim(ClaimTypes.Name, user.nombre));
            //Claims.Add(new Claim("Name", user.nombre));
            Claims.Add(new Claim(ClaimTypes.Role, user.Rol));
            //if(user.Roles != null  && user.Roles.Any()) {
            //    Claims.AddRange(user, Roles.Select(ref => new Claim(ClaimTypes.Role, r.Name)));
            //}
            var identity = new ClaimsIdentity(Claims, DefaultAuthenticationTypes.ApplicationCookie);
            IAuthenticationManager AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            AuthenticationManager.SignIn(new AuthenticationProperties() {
                IsPersistent = rememberMe
            }, identity);

            if (string.IsNullOrEmpty(returnUrl)) {
                returnUrl = Url.Action("Index", "Home");
            }
            Result = Redirect(returnUrl);
            return Result;
        }

        [Authorize]
        public ActionResult LogOff() {
            IAuthenticationManager Authenticationamnager =
                HttpContext.GetOwinContext().Authentication;

            Authenticationamnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");

        }
    }
}