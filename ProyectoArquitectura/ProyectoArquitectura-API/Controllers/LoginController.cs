using ProyectoArquitectura_API.Models;
using ProyectoArquitectura_API.Models.View;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoArquitectura_API.Controllers
{
    public class LoginController : ApiController
    {

        private GimnasioOlympusEntities db = new GimnasioOlympusEntities();
        public IHttpActionResult Posautenticar(Autenticacion Usuario)
        {

            if (Usuario == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ObjectParameter Result = new ObjectParameter("Autenticacion", typeof(string));              
                db.sp_AutenticarUsuario(
                    Usuario.UserName,
                    Usuario.Password,
                    Result
                    );
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
