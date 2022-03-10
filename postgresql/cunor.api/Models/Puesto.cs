using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Puesto
    {
        public Guid CodPuesto { get; set; }
        public string Nombre { get; set; }
        public decimal? Salario { get; set; }
    }
}
