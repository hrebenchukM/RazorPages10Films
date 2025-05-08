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
            option.Expires = DateTime.Now.AddDays(10); // ���� �������� ���� - 10 ����
            Response.Cookies.Append("login", "Guest", option); // �������� ����
            return RedirectToPage("./Index");
        }
    }
}
