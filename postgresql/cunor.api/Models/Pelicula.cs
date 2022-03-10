using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Ejemplars = new HashSet<Ejemplar>();
            Repartos = new HashSet<Reparto>();
        }

        public int CodPelicula { get; set; }
        public string Titulo { get; set; }
        public string FecEstreno { get; set; }
        public int CodDirector { get; set; }
        public int CodNacionalidad { get; set; }
        public int CodProductora { get; set; }

        public virtual Director CodDirectorNavigation { get; set; }
        public virtual Nacionalidad CodNacionalidadNavigation { get; set; }
        public virtual Productora CodProductoraNavigation { get; set; }
        public virtual ICollection<Ejemplar> Ejemplars { get; set; }
        public virtual ICollection<Reparto> Repartos { get; set; }
    }
}
