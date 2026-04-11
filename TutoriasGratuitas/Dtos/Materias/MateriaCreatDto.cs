using System.ComponentModel.DataAnnotations;

namespace TutoriasGratuitas.Dtos.Materias
{
    public class MateriaCreatDto
    {
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(20, ErrorMessage = "El {0} debera tener un minimo de {2} y maximo de {1} caracteres.", MinimumLength = 5)]
        public string Codigo { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(40, ErrorMessage = "El {0} deben tener un mínimo de {2} y máximo de {1} caracteres.", MinimumLength = 3)]
        public string Nombre { get; set; }
        public string Area { get; set; }
        public int Creditos { get; set; }
    }
}