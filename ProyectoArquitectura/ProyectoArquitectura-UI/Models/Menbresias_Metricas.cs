using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoArquitectura_UI.Models
{
    public class Menbresias_Metricas
    {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public Nullable<int> CantidadAdquisiciones { get; set; }
            public Nullable<decimal> TotalVenta { get; set; }     
    }
}