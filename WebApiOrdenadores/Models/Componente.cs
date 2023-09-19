using System.ComponentModel.DataAnnotations;

namespace WebApiOrdenadores.Models;

public class Componente
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo serie es obligatorio")]
    [MinLength(3, ErrorMessage = "La serie debe ser de al menos 3 caracteres")]
    [MaxLength(50, ErrorMessage = "La serie debe ser de 50 caracteres como maximo")]
    public string? Serie { get; set; }
    [MaxLength(100, ErrorMessage = "La máxima longitud de cadena es 100")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "El campo calor es obligatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "No puede introducir un numero menor a 0")]
    public int Calor { get; set; }
    [Required(ErrorMessage = "El campo precio es obligatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "No puede introducir un numero menor a 0")]
    public double Precio { get; set; }
    [Required(ErrorMessage = "El campo cores es obligatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "No puede introducir un numero menor a 0")]
    public int Cores { get; set; }
    [Required(ErrorMessage = "El campo megas es obligatorio")]
    [Range(0, long.MaxValue, ErrorMessage = "No puede introducir un numero menor a 0")]
    public long Megas { get; set; }
    public EnumTipoComponente Tipo { get; set; }
    public int? OrdenadorId { get; set; }
    public virtual Ordenador? MiOrdenador { get; set; }

}