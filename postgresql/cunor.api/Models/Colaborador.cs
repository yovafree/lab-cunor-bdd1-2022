using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cunor.api.Models;

[Table("colaborador", Schema="public")]
public class Colaborador{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid cod_colaborador {get; set;}
    public string nombres {get; set;}
    public string apellidos {get; set;}
    public string direccion {get; set;}
    public string telefono {get; set;}
    public string correo {get; set;}


}