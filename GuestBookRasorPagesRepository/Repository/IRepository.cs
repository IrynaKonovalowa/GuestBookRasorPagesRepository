using GuestBookRasorPagesRepository.Models;

namespace GuestBookRasorPagesRepository.Repository
{
    public interface IRepository
    {
        Task<List<Messages>> GetMessageList();
        Task<Messages> GetMessage(int id);
        Task Create(Messages item);
        Task<List<User>> GetUserList();
        Task<User> GetUser(string login);
        Task CreateUs(User item);
        Task Save();
    }
}
