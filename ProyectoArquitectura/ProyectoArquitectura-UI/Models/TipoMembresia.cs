using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_UI.Models
{
    public class TipoMembresia
    {
        public int TipoMembresiaID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
    }
}