using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Reparto
    {
        public int CodReparto { get; set; }
        public int CodPelicula { get; set; }
        public int CodActor { get; set; }
        public int CodTipoActor { get; set; }

        public virtual Actor CodActorNavigation { get; set; }
        public virtual Pelicula CodPeliculaNavigation { get; set; }
        public virtual TipoActor CodTipoActorNavigation { get; set; }
    }
}
