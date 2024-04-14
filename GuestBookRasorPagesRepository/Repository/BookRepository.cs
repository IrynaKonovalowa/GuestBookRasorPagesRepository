using GuestBookRasorPagesRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBookRasorPagesRepository.Repository
{
    public class BookRepository: IRepository
    {
        private readonly ClassContext _context;

        public BookRepository(ClassContext context)
        {
            _context = context;
        }
        public async Task<List<Messages>> GetMessageList()
        {            
            return await _context.Messages.ToListAsync();
        }

        public async Task<Messages> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task Create(Messages c)
        {
            await _context.Messages.AddAsync(c);
        }

        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(string login)
        {
            return _context.Users.Where(m => m.Login == login).First();
        }

        public async Task CreateUs(User u)
        {
            await _context.Users.AddAsync(u);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
