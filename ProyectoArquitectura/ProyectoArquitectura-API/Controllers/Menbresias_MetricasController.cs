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
    public class Menbresias_MetricasController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/Menbresias_Metricas
        public IQueryable<Menbresias_Metricas> GetMenbresias_Metricas()
        {
            return db.Menbresias_Metricas;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Menbresias_MetricasExists(string id)
        {
            return db.Menbresias_Metricas.Count(e => e.Nombre == id) > 0;
        }
    }
}