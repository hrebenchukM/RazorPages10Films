namespace GuestbookRazorPages.Services
{
    public interface IPassword
    {
        string GenerateSalt();
        string HashPassword(string salt, string password);
    }
}
