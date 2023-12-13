using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_API.Models.View
{
    public class Clientes
    {   
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal PorcentajeMasaMuscular { get; set; }
        public decimal PorcentajeGrasaCorporal { get; set; }

    }
}