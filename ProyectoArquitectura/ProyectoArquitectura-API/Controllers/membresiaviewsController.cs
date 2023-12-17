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
    public class membresiaviewsController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/membresiaviews
        public IQueryable<membresiaview> Getmembresiaview()
        {
            return db.membresiaview;
        }



        // GET: api/Menbresias/5
        [ResponseType(typeof(membresiaview))]
        public IHttpActionResult Getmembresiaview(int id)
        {
            membresiaview menbresia = db.membresiaview.FirstOrDefault(m => m.MenbresiaID == id);
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

        private bool membresiaviewExists(int id)
        {
            return db.membresiaview.Count(e => e.MenbresiaID == id) > 0;
        }
    }
}