using GuestBookRasorPagesRepository.Models;
using GuestBookRasorPagesRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestBookRasorPagesRepository.Pages
{
    public class IndexModel : PageModel
    {               
        public IList<Messages> Messages { get; set; } = default!;

        public async Task OnGetAsync([FromServices] IRepository repo)
        {
            Messages = await repo.GetMessageList();
        }
    }
}
