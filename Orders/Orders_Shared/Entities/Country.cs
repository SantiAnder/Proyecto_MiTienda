using System.ComponentModel.DataAnnotations;

namespace Orders_Shared.Entities
{
    public class Country
    {
        [Key]
        public int IdPais { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "El nombre del país no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo es requerido.")]
        public string NamePais { get; set; } = null!;
    }
}