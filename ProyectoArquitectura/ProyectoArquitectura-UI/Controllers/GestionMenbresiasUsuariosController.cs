using Newtonsoft.Json;
using ProyectoArquitectura_UI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoArquitectura_UI.Controllers
{
    public class GestionMenbresiasUsuariosController : Controller
    {
        private readonly RestClient client;
        public GestionMenbresiasUsuariosController()
        {
            client = new RestClient("https://localhost:44306");
        }
        [Permisos.Validacion]
        public ActionResult VistaMenbresiasUsuarios()
        {
            var request = new RestRequest("/api/membresiaviews", Method.Get);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                List<MembresiasView> respuesta = JsonConvert.DeserializeObject<List<MembresiasView>>(contenido);
                ViewBag.respuesta = respuesta;
            }
            else
            {
                TempData["MensajeError"] = $"Hubo un error al procesar la solicitud : {response.ErrorMessage}";
            }
            return View();
        }
        [Permisos.Validacion]
        public ActionResult CrearMembresiaUsuario()
        {
            var request = new RestRequest("/api/MembresiasUsuariosUtils", Method.Get);
            var response = client.Execute(request);
            request = new RestRequest("/api/TipoMembresias", Method.Get);
            var responseTipoMembresia = client.Execute(request);

            if (response.IsSuccessful && responseTipoMembresia.IsSuccessful)
            {
                string contenido = response.Content;
                List<UsuariosView> respuesta = JsonConvert.DeserializeObject<List<UsuariosView>>(contenido);
                contenido = responseTipoMembresia.Content;
                List<TipoMembresia> TipoMembresia = JsonConvert.DeserializeObject<List<TipoMembresia>>(contenido);
                ViewBag.respuesta = respuesta;
                ViewBag.TipoMembresia = TipoMembresia;
            }
            else
            {
                TempData["MensajeError"] = $"Hubo un error al procesar la solicitud : {response.ErrorMessage}";
            }
            return View();
        }

        [Permisos.Validacion]
        public ActionResult EditarMembresiaUsuario( int id)
        {
            var request = new RestRequest($"/api/Menbresias/{id}", Method.Get);
            var response = client.Execute(request);

            request = new RestRequest("/api/TipoMembresias", Method.Get);
            var responseTipoMembresia = client.Execute(request);

            request = new RestRequest($"/api/membresiaviews/{id}", Method.Get);
            var responseNombreDetalles = client.Execute(request);

            var requestTipoRols = new RestRequest($"/api/TipoEstados/", Method.Get);
            var responseTipoEstadoes = client.Execute(requestTipoRols);

            if (response.IsSuccessful && responseTipoMembresia.IsSuccessful && responseNombreDetalles.IsSuccessful && responseTipoEstadoes.IsSuccessful)
            {
                string contenido = response.Content;
                Membresia respuesta = JsonConvert.DeserializeObject<Membresia>(contenido);
                
                contenido = responseNombreDetalles.Content;
                MembresiasView Nombre = JsonConvert.DeserializeObject<MembresiasView>(contenido);


                contenido = responseTipoMembresia.Content;
                List<TipoMembresia> TipoMembresia = JsonConvert.DeserializeObject<List<TipoMembresia>>(contenido);

                contenido = responseTipoEstadoes.Content;
                List<TipoEstados> tipoEstados = JsonConvert.DeserializeObject<List<TipoEstados>>((contenido));


                ViewBag.Estados = tipoEstados;
                ViewBag.Membresia = respuesta;
                ViewBag.TipoMembresia = TipoMembresia;
                ViewBag.Nombre = Nombre.Fullname;
            }
            else
            {
                TempData["MensajeError"] = $"Hubo un error al procesar la solicitud : {response.ErrorMessage}";
            }
            return View();
        }







        [HttpPost]
        public ActionResult Crear_MembresiaUsuario(Membresia Membresia)
        {
            try
            {
                Membresia.MenbresiaID = "0";
                Membresia.TipoEstadoID = "1";
                var request = new RestRequest($"/api/Menbresias", Method.Post);
                request.AddBody(Membresia);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    TempData["Mensaje"] =  "Membresia asignada con exito";
                    return RedirectToAction("VistaMenbresiasUsuarios", "GestionMenbresiasUsuarios");
                }
                else
                {
                    TempData["MensajeError"] = $"Consulte con su proveedor de sofware";
                    return RedirectToAction("VistaMenbresiasUsuarios", "GestionMenbresiasUsuarios");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Editar_MembresiaUsuario(Membresia Membresia)
        {
            try
            {
                var request = new RestRequest($"/api/Menbresias/{Membresia.MenbresiaID}", Method.Put);
                request.AddBody(Membresia);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    TempData["Mensaje"] = "Membresia modificada con exito";
                    return RedirectToAction("VistaMenbresiasUsuarios", "GestionMenbresiasUsuarios");
                }
                else
                {
                    TempData["MensajeError"] = $"Consulte con su proveedor de sofware";
                    return RedirectToAction("VistaMenbresiasUsuarios", "GestionMenbresiasUsuarios");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, "Error interno del servidor: " + ex.Message);
            }


        }

   
    }
}