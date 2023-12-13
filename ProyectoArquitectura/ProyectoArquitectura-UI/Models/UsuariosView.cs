using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_UI.Models
{
    public class UsuariosView
    {
        public int UsuarioID { get; set; }
        public string UserName { get; set; }
        public string TipoEstadoID { get; set; }
        public string Estado { get; set; }
        public string TipoRol_ID { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
        public string Password { get; set; }
    }
}