using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Director
    {
        public Director()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int CodDirector { get; set; }
        public string Nombre { get; set; }
        public int CodNacionalidad { get; set; }
        public DateTime? FecCreacion { get; set; }
        public DateTime? FecActualizacion { get; set; }
        public string Usuario { get; set; }
        public int? Estado { get; set; }

        public virtual Nacionalidad CodNacionalidadNavigation { get; set; }
        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
