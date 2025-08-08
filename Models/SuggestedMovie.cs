using System.ComponentModel.DataAnnotations;

namespace Tarea_2.Models
{
    public class SuggestedMovie
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string? Genre { get; set; }

        [Range(1900, 2100, ErrorMessage = "Año inválido")]
        public int Year { get; set; }

        [Required(ErrorMessage = "La razón es obligatoria")]
        public string? Reason { get; set; }
    }
}
