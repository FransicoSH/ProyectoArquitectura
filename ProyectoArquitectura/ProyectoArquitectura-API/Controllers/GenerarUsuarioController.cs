using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectoArquitectura_API.Models;

namespace ProyectoArquitectura_API.Controllers
{
    public class GenerarUsuarioController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/GenerarUsuario/5  
        public IHttpActionResult GetGenerarUsuario(int id)
        {
            ObjectParameter Result = new ObjectParameter("UserName", typeof(string));
            db.Sp_GenerarUsername(id, Result);
            return Ok(Result);
        }
    }
}
