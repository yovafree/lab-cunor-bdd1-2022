using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Alquiler
    {
        public int CodAlquiler { get; set; }
        public string FecAlquiler { get; set; }
        public string FecDevolucion { get; set; }
        public int CodEjemplar { get; set; }
        public int CodCliente { get; set; }
        public int CodPelicula { get; set; }

        public virtual Ejemplar Cod { get; set; }
        public virtual Cliente CodClienteNavigation { get; set; }
    }
}
