using System.ComponentModel.DataAnnotations;

namespace GuestBookRasorPagesRepository.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Field must be set")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
