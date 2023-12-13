using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoArquitectura_API.Models;
using ProyectoArquitectura_API.Models.View;

namespace ProyectoArquitectura_API.Controllers
{
    public class UsuariosViewsController : ApiController
    {
        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();

        // GET: api/UsuariosViews
        public IQueryable<UsuariosView> GetUsuariosView()
        {
            return db.UsuariosViews;
        }

        public IHttpActionResult GetUsuariosView( int id)
        {
            UsuariosView Usuario = db.UsuariosViews.SingleOrDefault(u => u.UsuarioID == id);
            if (Usuario == null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }


        // PUT: api/UsuariosViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuariosView(int id, UsuarioEnty usuariosView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != usuariosView.UsuarioID)
                {
                    return BadRequest();
                }
                ObjectParameter Result = new ObjectParameter("Mensaje", typeof(string));
                db.Sp_AcualizarUsuario( 
                    id,
                    usuariosView.TipoEstadoID,
                    usuariosView.TipoRol_ID,
                    usuariosView.Password,
                    Result
                    );

                return Ok(Result);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosViewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }       
        }

        // POST: api/UsuariosViews
        [ResponseType(typeof(UsuariosView))]
        public IHttpActionResult PostUsuariosView(UsuarioEnty  Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ObjectParameter Result = new ObjectParameter("Mensaje", typeof(string));
            db.Sp_InsertarUsuario(
                Usuario.Idpersona,
                Usuario.TipoRol_ID,
                Usuario.UserName,
                Usuario.Password,
                Result
                );

           return Ok(Result);
        }

        // DELETE: api/UsuariosViews/.
        [ResponseType(typeof(UsuariosView))]
        public IHttpActionResult DeleteUsuariosView(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ObjectParameter Result = new ObjectParameter("Mensaje", typeof(string));
            db.Sp_EliminarUsuario(id,
               Result);
            return Ok(Result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosViewExists(int id)
        {
            return db.UsuariosViews.Count(e => e.UsuarioID == id) > 0;
        }
    }
}