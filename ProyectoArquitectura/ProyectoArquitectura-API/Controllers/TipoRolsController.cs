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
    public class TipoRolsController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/TipoRols
        public IQueryable<TipoRol> GetTipoRols()
        {
            return db.TipoRols;
        }

        // GET: api/TipoRols/5
        [ResponseType(typeof(TipoRol))]
        public IHttpActionResult GetTipoRol(int id)
        {
            TipoRol tipoRol = db.TipoRols.Find(id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return Ok(tipoRol);
        }

        // PUT: api/TipoRols/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoRol(int id, TipoRol tipoRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoRol.TipoRol_ID)
            {
                return BadRequest();
            }

            db.Entry(tipoRol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoRolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TipoRols
        [ResponseType(typeof(TipoRol))]
        public IHttpActionResult PostTipoRol(TipoRol tipoRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoRols.Add(tipoRol);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoRol.TipoRol_ID }, tipoRol);
        }

        // DELETE: api/TipoRols/5
        [ResponseType(typeof(TipoRol))]
        public IHttpActionResult DeleteTipoRol(int id)
        {
            TipoRol tipoRol = db.TipoRols.Find(id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            db.TipoRols.Remove(tipoRol);
            db.SaveChanges();

            return Ok(tipoRol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoRolExists(int id)
        {
            return db.TipoRols.Count(e => e.TipoRol_ID == id) > 0;
        }
    }
}