using Microsoft.EntityFrameworkCore;

namespace GuestBookRasorPagesRepository.Models
{
    public class ClassContext: DbContext
    {
         public DbSet<Messages> Messages { get; set; }
         public DbSet<User> Users { get; set; }
         public ClassContext(DbContextOptions<ClassContext> options)
             : base(options)
         {
            if (Database.EnsureCreated())
            {
                User user = new User();
                user.Login = "Tom";
                Messages?.Add(new Messages { Message="Very good hotel!", MessageDate = DateTime.Now, User=user });
                SaveChanges();
            }
         }       
    }
}
