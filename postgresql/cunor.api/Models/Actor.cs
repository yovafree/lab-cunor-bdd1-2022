using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Repartos = new HashSet<Reparto>();
        }

        public int CodActor { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int CodNacionalidad { get; set; }

        public virtual Nacionalidad CodNacionalidadNavigation { get; set; }
        public virtual ICollection<Reparto> Repartos { get; set; }
    }
}
