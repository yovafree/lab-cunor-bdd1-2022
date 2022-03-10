using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Alquilers = new HashSet<Alquiler>();
            InverseCodClienteAvalNavigation = new HashSet<Cliente>();
        }

        public int CodCliente { get; set; }
        public int CodClienteAval { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual Cliente CodClienteAvalNavigation { get; set; }
        public virtual ICollection<Alquiler> Alquilers { get; set; }
        public virtual ICollection<Cliente> InverseCodClienteAvalNavigation { get; set; }
    }
}
