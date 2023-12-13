using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoArquitectura_API.Models;

namespace ProyectoArquitectura_API.Controllers
{
    public class PersonaDetalleCuerpoViewsController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/PersonaDetalleCuerpoViews
        public IQueryable<PersonaDetalleCuerpoView> GetPersonaDetalleCuerpoView()
        {
            return db.PersonaDetalleCuerpoViews;
        }

      
        [ResponseType(typeof(PersonaDetalleCuerpoView))]
        public IHttpActionResult GetPersonaDetalleCuerpoView(int id)
        {
            PersonaDetalleCuerpoView personaDetalleCuerpoView = db.PersonaDetalleCuerpoViews.SingleOrDefault(p => p.IdPersona == id);
            if (personaDetalleCuerpoView == null)
            {
                return Ok(personaDetalleCuerpoView);
            }

            return Ok(personaDetalleCuerpoView);
        }

      
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonaDetalleCuerpoView(int id, PersonaDetalleCuerpoView personaDetalleCuerpoView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personaDetalleCuerpoView.IdPersona )
            {
                return BadRequest();
            }

            try
            {
                ObjectParameter Result = new ObjectParameter("Mensaje", typeof(string));
                db.Sp_ActualizarCliente(
                    personaDetalleCuerpoView.IdPersona,
                    personaDetalleCuerpoView.NumeroTelefono,
                    personaDetalleCuerpoView.Direccion,
                    personaDetalleCuerpoView.Peso,
                    personaDetalleCuerpoView.Altura,
                    personaDetalleCuerpoView.PorcentajeMasaMuscular,
                    personaDetalleCuerpoView.PorcentajeGrasaCorporal,
                    Result
                    );

                return Ok(Result);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaDetalleCuerpoViewExists(id))
                {
                    return NotFound();
                }
            }    
           return StatusCode(HttpStatusCode.NoContent);
        }

 
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaDetalleCuerpoViewExists(int id)
        {
            return db.PersonaDetalleCuerpoViews.Count(e => e.IdPersona == id) > 0;
        }
    }
}