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
    public class MenbresiasController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/Menbresias
        public IQueryable<Menbresia> GetMenbresias()
        {
            return db.Menbresias;
        }

        // GET: api/Menbresias/5
        [ResponseType(typeof(Menbresia))]
        public IHttpActionResult GetMenbresia(int id)
        {
            Menbresia menbresia = db.Menbresias.SingleOrDefault(m => m.MenbresiaID == id);
            if (menbresia == null)
            {
                return NotFound();
            }

            return Ok(menbresia);
        }

        // PUT: api/Menbresias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenbresia(int id, Menbresia menbresia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menbresia.MenbresiaID)
            {
                return BadRequest();
            }

            db.Entry(menbresia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenbresiaExists(id))
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

        // POST: api/Menbresias
        [ResponseType(typeof(Menbresia))]
        public IHttpActionResult PostMenbresia(Menbresia menbresia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menbresias.Add(menbresia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menbresia.MenbresiaID }, menbresia);
        }

        // DELETE: api/Menbresias/5
        [ResponseType(typeof(Menbresia))]
        public IHttpActionResult DeleteMenbresia(int id)
        {
            Menbresia menbresia = db.Menbresias.Find(id);
            if (menbresia == null)
            {
                return NotFound();
            }

            db.Menbresias.Remove(menbresia);
            db.SaveChanges();

            return Ok(menbresia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenbresiaExists(int id)
        {
            return db.Menbresias.Count(e => e.MenbresiaID == id) > 0;
        }
    }
}