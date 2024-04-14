namespace GuestBookRasorPagesRepository.Models
{
    public class User
    {
        public User()
        {
            this.Messages = new HashSet<Messages>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public string? Salt { get; set; }

        virtual public ICollection<Messages>? Messages { get; set; }
    }
}
