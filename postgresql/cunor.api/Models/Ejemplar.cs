using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Ejemplar
    {
        public Ejemplar()
        {
            Alquilers = new HashSet<Alquiler>();
        }

        public int CodEjemplar { get; set; }
        public int CodPelicula { get; set; }
        public int CodEstadoEjemplar { get; set; }

        public virtual EstadoEjemplar CodEstadoEjemplarNavigation { get; set; }
        public virtual Pelicula CodPeliculaNavigation { get; set; }
        public virtual ICollection<Alquiler> Alquilers { get; set; }
    }
}
