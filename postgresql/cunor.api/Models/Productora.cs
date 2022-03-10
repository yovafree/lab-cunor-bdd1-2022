using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Productora
    {
        public Productora()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int CodProductora { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
