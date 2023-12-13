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
    public class GestionUsuariosController : Controller
    {
        private readonly RestSharp.RestClient client;
        public GestionUsuariosController()
        {
            client = new RestClient("https://localhost:44306");
        }

        [Permisos.Validacion]
        public ActionResult VistaUsuarios()
        {
            var request = new RestRequest("/api/UsuariosViews", Method.Get);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                List<UsuariosView> respuesta = JsonConvert.DeserializeObject<List<UsuariosView>>(contenido);
                ViewBag.respuesta = respuesta;
            }
            return View();
        }



        public ActionResult CreaUsuario()
        {
            var request = new RestRequest("/api/Clientes", Method.Get);
            var response = client.Execute(request);

            var requestEstado = new RestRequest($"/api/TipoEstados/", Method.Get);
            var responseEstado = client.Execute(requestEstado);

            var requestTipoRols = new RestRequest($"/api/TipoRols/", Method.Get);
            var responseTipoRols = client.Execute(requestTipoRols);

            if (response.IsSuccessful && responseEstado.IsSuccessful && responseTipoRols.IsSuccessful)
            {
                string contenido = response.Content;
                String contenidoEstado = responseEstado.Content;
                String contenidoTipoRols = responseTipoRols.Content;

                List<PersnaView> respuesta = JsonConvert.DeserializeObject<List<PersnaView>>(contenido);
                List<TipoEstados> tipoEstados = JsonConvert.DeserializeObject<List<TipoEstados>>((contenidoEstado));
                List<TipoRol> tipoRols = JsonConvert.DeserializeObject<List<TipoRol>>((contenidoTipoRols));

                ViewBag.respuesta = respuesta;
                ViewBag.Usuario = respuesta;
                ViewBag.Estados = tipoEstados;
                ViewBag.tipoRols = tipoRols;
            }
            return View();
        }

        public ActionResult EditarUsuario( String IdUsuario)
        {


            var request = new RestRequest($"/api/UsuariosViews/{IdUsuario}", Method.Get);
            var response = client.Execute(request);

    
            var requestTipoRols = new RestRequest($"/api/TipoRols/", Method.Get);
            var responseTipoRols = client.Execute(requestTipoRols);

            if (response.IsSuccessful &&  responseTipoRols.IsSuccessful)
            {
                String contenido = response.Content;
                String contenidoTipoRols = responseTipoRols.Content;
                UsuariosView respuesta = JsonConvert.DeserializeObject<UsuariosView>(contenido);
                List<TipoRol> tipoRols = JsonConvert.DeserializeObject<List<TipoRol>>((contenidoTipoRols));
                ViewBag.Usuario = respuesta;
                ViewBag.tipoRols = tipoRols;
            }
            return View();
        }


        public ActionResult EiminarUsuario(string userid)
        {
            var request = new RestRequest($"/api/UsuariosViews/{userid}", Method.Delete);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                String resultado = respuesta.Value;
                if (resultado != "Eliminación de Usuario completado con éxito")
                {
                    TempData["MensajeError"] = resultado;
                    return RedirectToAction("VistaUsuarios", "GestionUsuarios");
                }
                TempData["Mensaje"] = resultado;
            }
            return RedirectToAction("VistaUsuarios", "GestionUsuarios");


        }


        [HttpGet]
        public ActionResult ObtenerUsuario(string id)
        {
            try
            {
                var request = new RestRequest($"/api/GenerarUsuario/{id}", Method.Get);

                var response = client.Execute(request);
                String username;

                if (response.IsSuccessful)
                {
                    string contenido = response.Content;
                    dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                    username = respuesta.Value;
                    return Content(username);
                }
                else
                {                 
                    return new HttpStatusCodeResult((int)response.StatusCode, response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar o manejar cualquier excepción aquí
                return new HttpStatusCodeResult(500, "Error interno del servidor: " + ex.Message);
            }

        }

        [HttpPost]
        public ActionResult Crear_Usuario(Usuario UsuarioData)
        {
            try
            {
                var request = new RestRequest($"/api/UsuariosViews", Method.Post);
                request.AddBody(UsuarioData);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    string contenido = response.Content;
                    dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido); 
                    if(respuesta.Value != "Usuario creado")
                    {
                     TempData["MensajeError"]= respuesta.Value;
                     return RedirectToAction("CreaUsuario", "GestionUsuarios");
                    }
                    TempData["Mensaje"] = respuesta.Value;
                    return RedirectToAction("VistaUsuarios", "GestionUsuarios");
                }
                else
                {
                    return new HttpStatusCodeResult((int)response.StatusCode, response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar o manejar cualquier excepción aquí
                return new HttpStatusCodeResult(500, "Error interno del servidor: " + ex.Message);
            }

        }



        [HttpPost]
        public ActionResult Actualizar_Usuario(Usuario UsuarioData)
        {
            try
            {
                var request = new RestRequest($"/api/UsuariosViews/{UsuarioData.UsuarioID}", Method.Put);
                request.AddBody(UsuarioData);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    string contenido = response.Content;
                    dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                    if (respuesta.Value != "Informacion actualizada")
                    {
                        TempData["MensajeError"] = respuesta.Value;
                        return RedirectToAction("Usuario", "GestionUsuarios");
                    }
                    TempData["Mensaje"] = respuesta.Value;
                    return RedirectToAction("VistaUsuarios", "GestionUsuarios");
                }
                else
                {
                    return new HttpStatusCodeResult((int)response.StatusCode, response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar o manejar cualquier excepción aquí
                return new HttpStatusCodeResult(500, "Error interno del servidor: " + ex.Message);
            }

        }






    }
}