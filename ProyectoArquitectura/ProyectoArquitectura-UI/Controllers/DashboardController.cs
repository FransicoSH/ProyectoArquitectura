using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoArquitectura_UI.Permisos;

namespace ProyectoArquitectura_UI.Controllers
{
    [Validacion]
    public class DashboardController : Controller
    {
        public ActionResult Home()
        {
            TempData["Mensaje"] = null;
            TempData["MensajeError"] = null;

            return View();
        }
    }
}