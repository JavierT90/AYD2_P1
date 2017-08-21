using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto1_AYD2.Controllers
{
    public class InicioController : Controller
    {

        private Models.DBConn ConexionBD = new Models.DBConn();

        // GET: Inicio
        [Authorize]
        public ActionResult Inicio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.mdlUsuario usuario)
        {
            if (ConexionBD.LoginUsuario(usuario.NombreUsuario, usuario.Password))
            {
                FormsAuthentication.SetAuthCookie(usuario.NombreUsuario, false);
                return RedirectToAction("Inicio", "Inicio");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(usuario);
        }

        
    }
}