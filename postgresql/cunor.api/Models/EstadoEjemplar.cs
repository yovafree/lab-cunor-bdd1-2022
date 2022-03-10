using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class EstadoEjemplar
    {
        public EstadoEjemplar()
        {
            Ejemplars = new HashSet<Ejemplar>();
        }

        public int CodEstadoEjemplar { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ejemplar> Ejemplars { get; set; }
    }
}
