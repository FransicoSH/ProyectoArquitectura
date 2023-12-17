using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_UI.Models
{
    public class Membresia
    {
        public String MenbresiaID { get; set; }
        public String TipoMembresiaID { get; set; }
        public String TipoEstadoID { get; set; }
        public String FechaAdquisicion { get; set; }
        public String FechaVencimiento { get; set; }
        public String UsuarioID { get; set; }
    }
}