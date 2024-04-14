using GuestBookRasorPagesRepository.Models;
using GuestBookRasorPagesRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Security.Cryptography;

namespace GuestBookRasorPagesRepository.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IRepository repo;

        public LoginModel(IRepository r)
        {
            repo = r;
        }
        [BindProperty]
        public LoginViewModel Login { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (await repo.GetUserList() == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return Page();
                }

                var user = await repo.GetUser(Login.Login);

                if (user == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return Page();
                }

                string? salt = user.Salt;

                //переводим пароль в байт-массив  
                byte[] password = Encoding.Unicode.GetBytes(salt + Login.Password);

                //вычисляем хеш-представление в байтах  
                byte[] byteHash = SHA256.HashData(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                if (user.Password != hash.ToString())
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return Page();
                }
                HttpContext.Session.SetString("Login", user.Login);
                return RedirectToPage("./Index");
            }
            return Page(); 
        }
    }
}
