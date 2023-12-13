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
using ProyectoArquitectura_API.Models;

namespace ProyectoArquitectura_API.Controllers
{
    public class PersonaViewsController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/PersonaViews
        public IQueryable<PersonaView> GetPersonaView()
        {
            return db.PersonaViews;

        }

        // GET: api/PersonaViews/5
        [ResponseType(typeof(PersonaView))]
        public IHttpActionResult GetPersonaView(int id)
        {
            PersonaView personaView = db.PersonaViews.SingleOrDefault(p => p.IdPersona == id);
            if (personaView == null)
            {
                return NotFound();
            }

            return Ok(personaView);
        }
    
        // POST: api/PersonaViews
        [ResponseType(typeof(PersonaView))]
        public IHttpActionResult PostPersonaView(PersonaView personaView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonaViews.Add(personaView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonaViewExists(personaView.IdPersona))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personaView.IdPersona }, personaView);
        }

        // DELETE: api/PersonaViews/5
        [ResponseType(typeof(PersonaView))]
        public IHttpActionResult DeletePersonaView(int id)
        {
            PersonaView personaView = db.PersonaViews.Find(id);
            if (personaView == null)
            {
                return NotFound();
            }

            db.PersonaViews.Remove(personaView);
            db.SaveChanges();

            return Ok(personaView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaViewExists(int id)
        {
            return db.PersonaViews.Count(e => e.IdPersona == id) > 0;
        }
    }
}