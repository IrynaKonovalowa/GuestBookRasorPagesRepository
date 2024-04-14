using System.ComponentModel.DataAnnotations;

namespace GuestBookRasorPagesRepository.Models
{
    public class Messages
    {
        public int Id { get; set; }

        [Display(Name = "Review")]
        [Required(ErrorMessage = "Field must be set")]
        public string? Message { get; set; }
        [Display(Name = "Date")]
        public DateTime? MessageDate { get; set; }

        virtual public User? User { get; set; }
    }
}
