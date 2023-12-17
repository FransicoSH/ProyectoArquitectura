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

namespace ProyectoArquitectura_API.Content
{
    public class MetricasController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/Metricas
        public IQueryable<Metricas> GetMetricas()
        {
            return db.Metricas;
        }

  
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MetricasExists(string id)
        {
            return db.Metricas.Count(e => e.Metrica == id) > 0;
        }
    }
}