using System.ComponentModel.DataAnnotations;

namespace TutoriasGratuitas.Dtos.Tutores
{
    public class TutorDto
    {
        [Required(ErrorMessage = "El Dni es requerido")]
        [StringLength(13, ErrorMessage = "El DNI debe tener 13 dígitos.", MinimumLength = 13)]
        public string Dni { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(40, ErrorMessage = "El {0} debera tener un mínimo de {2} y máximo de {1} caracteres.", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(40, ErrorMessage = "El {0} debera tener un mínimo de {2} y máximo de {1} caracteres.", MinimumLength = 3)]
        public string Apellido { get; set; }
        public  DateTime FechaDeNacimiento { get; set; }

        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [EmailAddress(ErrorMessage = "Formato de Correo Invalido.")]
        public string CorreoElectronico { get; set; }
        public string Genero { get; set; }
        public string CodigoMateria { get; set; }
    }
}