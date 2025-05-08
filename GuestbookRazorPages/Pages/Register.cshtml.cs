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


namespace GuestbookRazorPages.Pages
{
    public class RegisterModel : PageModel
    {
 
        private readonly IUserRepository repo;

        public RegisterModel(IUserRepository r)
        {
            repo = r;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;


        [BindProperty]
        public string PasswordConfirm { get; set; }



        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Password != PasswordConfirm)
            {
                ModelState.AddModelError("PasswordConfirm", "Пароли не совпадают");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var passwordService = HttpContext.RequestServices.GetService<IPassword>();
            User.Salt = passwordService.GenerateSalt(); ;
            User.Password = passwordService.HashPassword(User.Salt, User.Password);


            await repo.Create(User);
            await repo.Save();

            return RedirectToPage("./Login");
        }
    }
}
