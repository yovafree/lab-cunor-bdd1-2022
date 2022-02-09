using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cunor.api.Models;

[Table("curso", Schema="public")]
public class Curso{
    [Key]
    public int cod_curso {get; set;}
    public string nombre {get; set;}
    public string descripcion {get; set;}
    public string carrera {get; set;}
}