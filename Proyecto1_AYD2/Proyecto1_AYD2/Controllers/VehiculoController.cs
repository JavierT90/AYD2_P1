using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto1_AYD2.Models;

namespace Proyecto1_AYD2.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Ingresar()
        {
            protoVehiculo Prototipo = new protoVehiculo();
            Prototipo.Color = "Gris";
            Prototipo.Traccion = "FWD";
            Prototipo.CantidadEjes = 2;
            Prototipo.MotorCC = 1600;
            Prototipo.Tipo = "Sedan";
            System.Web.HttpContext.Current.Session["VehiculoDefault"] = Prototipo;
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(protoVehiculo Vehiculo)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Inicio", "Inicio");
            }
            else
            {
                ModelState.AddModelError("", "Hay datos que debe ingresar");
            }
            return View(Vehiculo);
        }


        public string EstablecerPorDefecto(protoVehiculo Vehiculo)
        {
            string resultado = "";
            try
            {
                System.Web.HttpContext.Current.Session["VehiculoDefault"] = Vehiculo;
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Función que clona un objto protoVehiculo 
        /// </summary>
        /// <returns>Retorna el protoVehiculo con valores por defecto</returns>
        public JsonResult ObtenerVehiculoDefecto()
        {
            protoVehiculo resultado = null;
            try
            {
                //Se obtiene el Prototypo a traves de las variables de sesión
                protoVehiculo DefaultV = (protoVehiculo)Session["VehiculoDefault"];
                //Se hace la clonación hacia el objeto nuevo
                resultado = DefaultV.Clone() as protoVehiculo;
            }
            catch (Exception ex)
            {
                //resultado = ex.Message;
            }
            return Json(resultado);
        }
    }
}