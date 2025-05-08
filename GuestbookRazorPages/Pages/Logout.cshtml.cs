using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestbookRazorPages.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete("login"); // удаление куки
            HttpContext.Session.Clear(); // очищается сессия
            return RedirectToPage("./Login");
        }
    }
}
