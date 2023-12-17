using ProyectoArquitectura_API.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoArquitectura_API.Content
{
    public class MembresiasUsuariosUtilsController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();
        public IQueryable<UsuariosView> Get()
        {
            return db.UsuariosViews
              .Where(u => u.TipoRol_ID != 1 && u.TipoEstadoID == 1);
        }

    }
}
