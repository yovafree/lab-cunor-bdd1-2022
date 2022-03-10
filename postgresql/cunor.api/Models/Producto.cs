using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Producto
    {
        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public int CodProveedor { get; set; }

        public virtual Proveedor CodProveedorNavigation { get; set; }
    }
}
