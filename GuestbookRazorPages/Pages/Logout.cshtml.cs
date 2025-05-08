using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestbookRazorPages.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete("login"); // �������� ����
            HttpContext.Session.Clear(); // ��������� ������
            return RedirectToPage("./Login");
        }
    }
}
