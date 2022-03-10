using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int CodProveedor { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
