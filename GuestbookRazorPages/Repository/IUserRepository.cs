using GuestbookRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestbookRazorPages.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        Task<bool> AnyUsers();


        Task<User?> GetUserByLogin(string login);
    }
}
