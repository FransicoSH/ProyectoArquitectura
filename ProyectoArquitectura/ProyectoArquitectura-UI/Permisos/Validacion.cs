using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoArquitectura_UI.Permisos
{
    public class Validacion : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if(HttpContext.Current.Session["User"]== null)
            {
                filterContext.Result = new RedirectResult("~/inicioSesion/Login");
            }

            base.OnActionExecuting(filterContext);
        }

    }
}