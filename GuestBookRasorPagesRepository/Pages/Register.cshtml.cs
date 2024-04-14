using GuestBookRasorPagesRepository.Models;
using GuestBookRasorPagesRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace GuestBookRasorPagesRepository.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IRepository repo;

        public RegisterModel(IRepository r)
        {
            repo = r;
        }
        [BindProperty]
        public RegisterViewModel Register { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Name = Register.Name;
                user.Login = Register.Login;

                byte[] saltbuf = new byte[16];

                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(saltbuf);

                StringBuilder sb = new StringBuilder(16);
                for (int i = 0; i < 16; i++)
                    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                string salt = sb.ToString();

                //переводим пароль в байт-массив  
                byte[] password = Encoding.Unicode.GetBytes(salt + Register.Password);

                //вычисляем хеш-представление в байтах  
                byte[] byteHash = SHA256.HashData(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                user.Password = hash.ToString();
                user.Salt = salt;
                await repo.CreateUs(user);
                await repo.Save();
                return RedirectToPage("./Login");
            }
            return Page();
        }
    }

}