using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoArquitectura_UI.Models;

namespace ProyectoArquitectura_UI.Controllers
{
    public class GestionMenbresiasController : Controller
    {
        private readonly RestSharp.RestClient client;
        public GestionMenbresiasController()
        {
            client = new RestClient("https://localhost:44306");
        }

        [Permisos.Validacion]
        public ActionResult VistaMenbresias()
        {
            var request = new RestRequest("/api/TipoMembresias", Method.Get);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                List<TipoMembresia> respuesta = JsonConvert.DeserializeObject<List<TipoMembresia>>(contenido);
                ViewBag.respuesta = respuesta;
            }

            return View();
        }

        [HttpPost]
        public ActionResult CrearNuevaMenbresia(TipoMembresia membresia)
        {
            var request = new RestRequest("/api/TipoMembresias", Method.Post);
            request.AddJsonBody(membresia);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {          
                TempData["Mensaje"] = "Menbresia creada con exitosamente";
                return RedirectToAction("VistaMenbresias", "GestionMenbresias");
            }
            else
            {
                TempData["MensajeError"] = $"Consulte a su proveedor de sofware";
            }
            return RedirectToAction("VistaMenbresias", "GestionMenbresias");
        }

       
        public ActionResult ObtieneMenbresia( int id)
        {
            var request = new RestRequest($"/api/TipoMembresias/{id}", Method.Get);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                TipoMembresia respuesta = JsonConvert.DeserializeObject<TipoMembresia>(contenido);
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            return Content("Error al obtener la membresía");


        }
        [HttpPost]
        public ActionResult EditarMenbresia(TipoMembresia membresia)
        {
            var request = new RestRequest($"/api/TipoMembresias/{membresia.TipoMembresiaID}", Method.Put);
            request.AddJsonBody(membresia);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                TempData["Mensaje"] = "Menbresia modificada con exitosamente";
                return RedirectToAction("VistaMenbresias", "GestionMenbresias");
            }
            else
            {
                TempData["MensajeError"] = $"Consulte a su proveedor de sofware";
            }
            return RedirectToAction("VistaMenbresias", "GestionMenbresias");
        }

        public ActionResult EliminarMenbresia(int id)
        {
            var request = new RestRequest($"/api/TipoMembresias/{id}", Method.Delete);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                TempData["Mensaje"] = "Menbresia eliminada con exitosamente";
                return RedirectToAction("VistaMenbresias", "GestionMenbresias");
            }
            else
            {
                string contenido = response.Content;
                dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                TempData["MensajeError"] = $"{respuesta.Message}";
            }
            return RedirectToAction("VistaMenbresias", "GestionMenbresias");


        }



    }

}