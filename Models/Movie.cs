using System.ComponentModel.DataAnnotations;

namespace Tarea_2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string? Category { get; set; }

        [Range(1900, 2100, ErrorMessage = "Año inválido")]
        public int Year { get; set; }

        [Url(ErrorMessage = "Debe ser una URL válida")]
        public string? PosterUrl { get; set; }  // ← Para la imagen de la película
    }
}
