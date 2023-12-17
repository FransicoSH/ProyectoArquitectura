using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_UI.Models
{
    public class MembresiasView
    {
       public int MenbresiaID { get; set; }
        public string Fullname { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechaAdquisicion { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
    }
}