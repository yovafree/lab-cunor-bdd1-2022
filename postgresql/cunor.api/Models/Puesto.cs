using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cunor.api.Models;

[Table("puesto", Schema="public")]
public class Puesto{
    [Key]
    public string cod_puesto {get; set;}
    public string nombre {get; set;}
    public double salario {get; set;}
}