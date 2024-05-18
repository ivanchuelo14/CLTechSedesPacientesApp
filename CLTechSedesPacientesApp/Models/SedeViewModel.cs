using System.ComponentModel.DataAnnotations;

namespace CLTechSedesPacientesApp.Models
{
    public class SedeViewModel
    {
        public int Id { get; set; }
        public string IdEnterprise { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpression(@"^[a-zA-Z ÑÁÉÍÓÚñáéíóú0123456789\s\p{P}\n]+$", ErrorMessage = "El campo {0} contiene caracteres inválidos.")]
        [StringLength(3500, MinimumLength = 1, ErrorMessage = "El campo {0} debe con tener al menos {2} y máximo {1} caracteres.")]
        public string Codigo { get; set; }

        [RegularExpression(@"^[a-zA-Z ÑÁÉÍÓÚñáéíóú0123456789\s\p{P}\n]+$", ErrorMessage = "El campo {0} contiene caracteres inválidos.")]
        [StringLength(3500, MinimumLength = 1, ErrorMessage = "El campo {0} debe con tener al menos {2} y máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre { get; set; }

        [RegularExpression(@"^[a-zA-Z ÑÁÉÍÓÚñáéíóú0123456789\s\p{P}\n]+$", ErrorMessage = "El campo {0} contiene caracteres inválidos.")]
        [StringLength(3500, MinimumLength = 1, ErrorMessage = "El campo {0} debe con tener al menos {2} y máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Longitud { get; set; }

        [RegularExpression(@"^[a-zA-Z ÑÁÉÍÓÚñáéíóú0123456789\s\p{P}\n]+$", ErrorMessage = "El campo {0} contiene caracteres inválidos.")]
        [StringLength(3500, MinimumLength = 1, ErrorMessage = "El campo {0} debe con tener al menos {2} y máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Latitud { get; set; }

    }
}
