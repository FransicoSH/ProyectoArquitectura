using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoArquitectura_API.Models.View;
using ProyectoArquitectura_API.Models;
using System.Data.Entity.Core.Objects;

namespace ProyectoArquitectura_API.Controllers
{
    public class ClientesController : ApiController
    {

        private readonly GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        [ResponseType(typeof(void))]
        public IHttpActionResult PostClientes(Clientes clientes)
        {
            if (clientes == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ObjectParameter Result = new ObjectParameter("Mensaje", typeof(string));               
                db.Sp_InsertarPersona(
                    clientes.Nombre,
                    clientes.Identificacion,
                    clientes.PrimerApellido,
                    clientes.SegundoApellido,
                    clientes.Direccion,
                    clientes.CorreoElectronico,
                    clientes.NumeroTelefono,
                    clientes.Peso,
                    clientes.Altura,
                    clientes.PorcentajeMasaMuscular,
                    clientes.PorcentajeGrasaCorporal,
                    Result
                    );
                return Ok(Result);  
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteClientes(int id)
        { 
            try
            {
                ObjectParameter Result = new ObjectParameter("Mensaje", typeof(string));

                db.Sp_EliminarCliente(id, Result);
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



        public IHttpActionResult GetClientesSinUsuarios()
        {
            var personasSinUsuarios = db.PersonasSinUsuarios;
           
            return Ok(personasSinUsuarios);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}
