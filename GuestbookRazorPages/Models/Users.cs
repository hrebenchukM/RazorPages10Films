using System.ComponentModel.DataAnnotations;

namespace GuestbookRazorPages.Models
{
    public class User
    {
        public User()
        {
            this.Messages = new HashSet<Message>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(100, ErrorMessage = "Can't be longer than 100 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(100, ErrorMessage = "Can't be longer than 100 characters.")]

        public string? LastName { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, ErrorMessage = "Can't be longer than 50 characters.")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be at least 6 characters long.")]
        public string? Password { get; set; }

        public string? Salt { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }

}