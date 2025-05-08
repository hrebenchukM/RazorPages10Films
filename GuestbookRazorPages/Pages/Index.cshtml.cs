using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuestbookRazorPages.Models;
using GuestbookRazorPages.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuestbookRazorPages.Services;

namespace GuestbookRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMessageRepository _msgrepo;
        private readonly IUserRepository _urepo;

        public IndexModel(IMessageRepository msgrepo, IUserRepository urepo)
        {
            _msgrepo = msgrepo;
            _urepo = urepo;
        }
        public IList<Message> Message { get; set; } = new List<Message>();

        [BindProperty]
        public string Content { get; set; } = default!;

        public async Task OnGetAsync()
        {
            string? login = HttpContext.Session.GetString("Login") ?? Request.Cookies["login"];


            if (login != null)
            {
                HttpContext.Session.SetString("Login", login);
                var msgContext = await _urepo.GetList();
                Message = await _msgrepo.GetList();
            }
            else
            {
                Page();
            }
          
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var log = HttpContext.Session.GetString("Login");
            var user = await _urepo.GetUserByLogin(log);
            if (user != null)
            {
                var message = new Message
                {
                    UserId = user.Id,
                    Content = Content,
                    Date = DateTime.Now
                };

                if (ModelState.IsValid)
                {
                    await _msgrepo.Create(message);
                    await _msgrepo.Save();

                    return RedirectToPage();
                }
            }
            return Page();
        }
    }
}
