using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class TipoActor
    {
        public TipoActor()
        {
            Repartos = new HashSet<Reparto>();
        }

        public int CodTipoActor { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Reparto> Repartos { get; set; }
    }
}
