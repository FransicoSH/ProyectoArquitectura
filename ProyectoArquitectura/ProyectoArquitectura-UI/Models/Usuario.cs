using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_UI.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public int TipoEstadoID { get; set; }
        public int TipoRol_ID { get; set; }
        public int Idpersona { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NombreRol { get; set; }
    }
}