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
    public class TipoEstadosController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/TipoEstadoes
        public IQueryable<TipoEstado> GetTipoEstado()
        {
            return db.TipoEstadoes;
        }

        // GET: api/TipoEstadoes/5
        [ResponseType(typeof(TipoEstado))]
        public IHttpActionResult GetTipoEstado(int id)
        {
            TipoEstado tipoEstado = db.TipoEstadoes.Find(id);
            if (tipoEstado == null)
            {
                return NotFound();
            }

            return Ok(tipoEstado);
        }

        // PUT: api/TipoEstadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoEstado(int id, TipoEstado tipoEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoEstado.TipoEstadoID)
            {
                return BadRequest();
            }

            db.Entry(tipoEstado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEstadoExists(id))
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

        // POST: api/TipoEstadoes
        [ResponseType(typeof(TipoEstado))]
        public IHttpActionResult PostTipoEstado(TipoEstado tipoEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoEstadoes.Add(tipoEstado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoEstado.TipoEstadoID }, tipoEstado);
        }

        // DELETE: api/TipoEstadoes/5
        [ResponseType(typeof(TipoEstado))]
        public IHttpActionResult DeleteTipoEstado(int id)
        {
            TipoEstado tipoEstado = db.TipoEstadoes.Find(id);
            if (tipoEstado == null)
            {
                return NotFound();
            }

            db.TipoEstadoes.Remove(tipoEstado);
            db.SaveChanges();

            return Ok(tipoEstado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoEstadoExists(int id)
        {
            return db.TipoEstadoes.Count(e => e.TipoEstadoID == id) > 0;
        }
    }
}