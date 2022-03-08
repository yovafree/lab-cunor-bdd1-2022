using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cunor.api.Models;

[Table("estudiante", Schema="public")]
public class Estudiante{
    [Key]
    public int cod_estudiante {get; set;}
    public string carne {get; set;}
    public string nombres {get; set;}
    public string apellidos {get; set;}
    public string tipo_vivienda {get; set;}
    public string no_celular {get; set;}
    public string correo_electronico {get; set;}
    public string carrera {get; set;}
}