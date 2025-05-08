using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuestbookRazorPages.Models;
using GuestbookRazorPages.Repository;
using NuGet.Protocol.Core.Types;
using GuestbookRazorPages.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace GuestbookRazorPages.Pages
{
    public class LoginModel : PageModel
    {
 
        private readonly IUserRepository repo;

        public LoginModel(IUserRepository r)
        {
            repo = r;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        [Required]
        public string Login { get; set; } = default!;

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;


        [BindProperty]
        public bool RememberMe { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!await repo.AnyUsers())
            {
                ModelState.AddModelError("", "Wrong login or password!");
                return Page();
            }
            var user = await repo.GetUserByLogin(Login);
            if (user == null)
            {
                ModelState.AddModelError("", "Wrong login or password!");
                return Page();
            }



            var passwordService = HttpContext.RequestServices.GetService<IPassword>();

            string hash = passwordService.HashPassword(user.Salt, Password);
            if (user.Password != hash.ToString())
            {
                ModelState.AddModelError("", "Wrong login or password!");
                return Page();
            }

            HttpContext.Session.SetString("Login", user.Login);
            HttpContext.Session.SetString("FirstName", user.FirstName);


            if (RememberMe)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(10); // срок хранения куки - 10 дней
                Response.Cookies.Append("login", user.Login, option); // создание куки
            }


            return RedirectToPage("./Index");
        }
    }
}
