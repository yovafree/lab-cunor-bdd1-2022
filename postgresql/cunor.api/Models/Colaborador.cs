using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Colaborador
    {
        public Guid CodColaborador { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
