using System.ComponentModel.DataAnnotations;

namespace RazorPages10Films.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Films = new HashSet<Film>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Title of genre")]
        public string? Name { get; set; }
        public ICollection<Film>? Films { get; set; }
    }


}
