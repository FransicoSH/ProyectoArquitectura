using Newtonsoft.Json;
using ProyectoArquitectura_UI.Models;
using ProyectoArquitectura_UI.Permisos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoArquitectura_UI.Controllers
{
    public class GestionClientesController : Controller
    {
        // GET: GestionClientes
        private readonly RestClient client;
        public GestionClientesController()
        {
            client = new RestClient("https://localhost:44306");
        }

        [Validacion]
        public ActionResult VistaClientes()
        {

            var request = new RestRequest("/api/Personas", Method.Get);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                List<PersnaView> respuesta = JsonConvert.DeserializeObject<List<PersnaView>>(contenido);
                ViewBag.respuesta = respuesta;
            }else
            {
                TempData["MensajeError"] = $"Hubo un error al procesar la solicitud : {response.ErrorMessage}";               
            }
            return View();
        }

        [Validacion]
        public ActionResult CrearCliente()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult CrearNuevoCliente(cliente objcliente)
        {
            var request = new RestRequest("/api/Clientes", Method.Post);
            request.AddJsonBody(objcliente);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                String resultado = respuesta.Value;
                if(resultado == "Se agrego cliente")
                {
                 TempData["Mensaje"] = "Cliente creado exitosamente";
                return RedirectToAction("VistaClientes", "GestionClientes");
                }
                else
                {
                  TempData["MensajeError"] = "Ya existe el registro del cliente";                
                }
                return RedirectToAction("CrearCliente", "GestionClientes");
            }
            else
                {
                TempData["MensajeError"] = $"Hubo un error al procesar la solicitud : {response.ErrorMessage}";
                }
            return RedirectToAction("VistaClientes", "GestionClientes");
        }
        //[Validacion]
        public ActionResult EditarClientes(  String IdCliente )
        {
            var request = new RestRequest($"/api/PersonaDetalleCuerpoViews/{IdCliente}", Method.Get);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                PersonaDetalleCuerpo respuesta = JsonConvert.DeserializeObject<PersonaDetalleCuerpo>(contenido);
                ViewBag.respuesta = respuesta;
            }
            return View();
        }

        [HttpPost]
        public ActionResult EnviarActualizacionCliente(PersonaDetalleCuerpo PersonaDetalleCuerpo)
        {   
            String url = $"/api/PersonaDetalleCuerpoViews/{PersonaDetalleCuerpo.IdPersona}";
            var request = new RestRequest(url, Method.Put);
            request.AddJsonBody(PersonaDetalleCuerpo);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                String resultado = respuesta.Value;
                if (resultado == "Informacion actualizada")
                {
                    TempData["Mensaje"] = "Informacion actualizada";
                    return RedirectToAction("VistaClientes", "GestionClientes");
                }
                else
                {
                    TempData["MensajeError"] = resultado;
                }
                return RedirectToAction("VistaClientes", "GestionClientes");
            }
            else
            {
                TempData["MensajeError"] = $"Hubo un error al procesar la solicitud : {response.ErrorMessage}";
            }
            return RedirectToAction("VistaClientes", "GestionClientes");
        }



        public ActionResult EiminarCliente(string IdCliente)
        {

            String Url = $"/api/Clientes/{IdCliente}";
            var request = new RestRequest(Url, Method.Delete);
            var response = client.Execute(request);          
            if (response.IsSuccessful)
            {
                string contenido = response.Content;
                dynamic respuesta = JsonConvert.DeserializeObject<dynamic>(contenido);
                String resultado = respuesta.Value;
                if(resultado != "Cliente Eliminado")
                {
                    TempData["MensajeError"] = resultado;
                    return RedirectToAction("VistaClientes", "GestionClientes");
                }
                TempData["Mensaje"] = resultado;
            }
            else
            {
                TempData["Mensaje"] ="Consulte a su proveedor de sofware";
            }

          
            return RedirectToAction("VistaClientes", "GestionClientes");


        }






    }
}