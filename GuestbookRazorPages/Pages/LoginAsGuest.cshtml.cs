using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestbookRazorPages.Pages
{
    public class LoginAsGuestModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.SetString("login", "Guest");
            HttpContext.Session.SetString("FirstName", "Guest");
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(10); // срок хранения куки - 10 дней
            Response.Cookies.Append("login", "Guest", option); // создание куки
            return RedirectToPage("./Index");
        }
    }
}
