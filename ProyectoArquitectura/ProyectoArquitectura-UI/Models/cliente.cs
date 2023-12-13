using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_UI.Models
{
    public class cliente
    {
        public string IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string PorcentajeMasaMuscular { get; set; }
        public string PorcentajeGrasaCorporal { get; set; }
    }
}