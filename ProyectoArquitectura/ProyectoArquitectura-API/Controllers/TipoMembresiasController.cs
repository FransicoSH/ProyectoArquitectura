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
    public class TipoMembresiasController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/TipoMembresias
        public IQueryable<TipoMembresia> GetTipoMembresias()
        {
            return db.TipoMembresias;
        }

        // GET: api/TipoMembresias/5
        [ResponseType(typeof(TipoMembresia))]
        public IHttpActionResult GetTipoMembresia(int id)
        {
            TipoMembresia tipoMembresia = db.TipoMembresias.Find(id);
            if (tipoMembresia == null)
            {
                return NotFound();
            }

            return Ok(tipoMembresia);
        }

        // PUT: api/TipoMembresias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoMembresia(int id, TipoMembresia tipoMembresia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoMembresia.TipoMembresiaID)
            {
                return BadRequest();
            }

            db.Entry(tipoMembresia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMembresiaExists(id))
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

        // POST: api/TipoMembresias
        [ResponseType(typeof(TipoMembresia))]
        public IHttpActionResult PostTipoMembresia(TipoMembresia tipoMembresia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoMembresias.Add(tipoMembresia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoMembresia.TipoMembresiaID }, tipoMembresia);
        }

        // DELETE: api/TipoMembresias/5
        [ResponseType(typeof(TipoMembresia))]
        public IHttpActionResult DeleteTipoMembresia(int id)
        {
            TipoMembresia tipoMembresia = db.TipoMembresias.Find(id);
            if (tipoMembresia == null)
            {
                return NotFound();
            }
            int registrosRelacionados = db.Menbresias.Count(M => M.TipoMembresiaID == id);
            if (registrosRelacionados > 0)
            {
                return BadRequest(message: $"No se puede eliminar, existen {registrosRelacionados} registros relacionados." );
            }

            db.TipoMembresias.Remove(tipoMembresia);
            db.SaveChanges();

            return Ok(tipoMembresia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoMembresiaExists(int id)
        {
            return db.TipoMembresias.Count(e => e.TipoMembresiaID == id) > 0;
        }
    }
}