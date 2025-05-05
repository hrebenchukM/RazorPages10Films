using System.ComponentModel.DataAnnotations;

namespace RazorPages10Films.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Name { get; set; }
        public Genre? Genre { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Maker { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(1900, 2025, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }
        public string? Poster { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int GenreId { get; set; }
    }
}