using System;
using System.Collections.Generic;

namespace cunor.api.Models
{
    public partial class Curso
    {
        public int CodCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Carrera { get; set; }
    }
}
