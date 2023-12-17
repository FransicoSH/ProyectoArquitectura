using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoArquitectura_UI.Models;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json;

namespace ProyectoArquitectura_UI.Controllers
{
    public class inicioSesionController : Controller
    {
        private readonly RestClient client;
        public inicioSesionController()
        {
             client = new RestClient("https://localhost:44306");
        }


        // GET: inicioSesion
        public ActionResult Login()
        {      
                return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuario objUsuario)
        {
            var request = new RestRequest("/api/Login", Method.Post);
            request.AddJsonBody(objUsuario);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                int resultado = respuesta.Value;
                if (resultado == 1)
                {
                    Session["User"] = objUsuario;
                    return RedirectToAction("Home", "Dashboard");
                }  
            }

            Session["User"] = null;
            TempData["LoginFail"] = "Usuario o contraseña inválidas";
            return RedirectToAction("Login", "inicioSesion");

        }




    }
}