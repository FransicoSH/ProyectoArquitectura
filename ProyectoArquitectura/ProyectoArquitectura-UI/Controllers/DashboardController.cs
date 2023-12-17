using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProyectoArquitectura_UI.Permisos;
using RestSharp;
using ProyectoArquitectura_UI.Models;

namespace ProyectoArquitectura_UI.Controllers
{
    [Validacion]
    public class DashboardController : Controller
    {
        private readonly RestClient client;
        public DashboardController()
        {
            client = new RestClient("https://localhost:44306");
        }
        public ActionResult Home()
        {
            TempData["Mensaje"] = null;
            TempData["MensajeError"] = null;

            var request = new RestRequest("/api/Metricas", Method.Get);
            var response = client.Execute(request);


            request = new RestRequest("/api/Menbresias_Metricas", Method.Get);
            var responseMenbresias = client.Execute(request);

            if (response.IsSuccessful && responseMenbresias.IsSuccessful)
            {
                string contenido = response.Content;
                List<Metricas> respuesta = JsonConvert.DeserializeObject<List<Metricas>>(contenido);
                contenido = responseMenbresias.Content;
                List<Menbresias_Metricas> respuestaMembresias = JsonConvert.DeserializeObject < List <Menbresias_Metricas>>(contenido);
                ViewBag.Usurios = respuesta[0];
                ViewBag.Clientes = respuesta[1];
                ViewBag.Membresia = respuesta[2];
                ViewBag.ListMembresia = respuestaMembresias;
            }

            return View();

        }
    }
}