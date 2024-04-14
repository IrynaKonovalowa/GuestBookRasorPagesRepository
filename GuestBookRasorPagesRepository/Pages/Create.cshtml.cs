using GuestBookRasorPagesRepository.Models;
using GuestBookRasorPagesRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestBookRasorPagesRepository.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IRepository repo;

        public CreateModel(IRepository r)
        {
            repo = r;
        }

        [BindProperty]
        public Messages Message { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string login = HttpContext.Session.GetString("Login");
                var us = await repo.GetUser(login);
                User user = us;
                Message.User = user;
                Message.MessageDate = DateTime.Now;
                await repo.Create(Message);
                await repo.Save();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
