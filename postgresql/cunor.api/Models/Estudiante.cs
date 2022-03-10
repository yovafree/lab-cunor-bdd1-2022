using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Estudiante
    {
        public int CodEstudiante { get; set; }
        public string Carne { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string TipoVivienda { get; set; }
        public string NoCelular { get; set; }
        public string Carrera { get; set; }
    }
}
