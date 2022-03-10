using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Nacionalidad
    {
        public Nacionalidad()
        {
            Actors = new HashSet<Actor>();
            Directors = new HashSet<Director>();
            Peliculas = new HashSet<Pelicula>();
        }

        public int CodNacionalidad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
