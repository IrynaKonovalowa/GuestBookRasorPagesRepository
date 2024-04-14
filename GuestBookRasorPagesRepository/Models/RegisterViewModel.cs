using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GuestBookRasorPagesRepository.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Field must be set")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[{0-9])(?=.*[!@#%^&*])\S{6,}$", ErrorMessage = "The password must contain at least 6 characters including an uppercase letter, a lowercase letter, a number and a special character!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}
