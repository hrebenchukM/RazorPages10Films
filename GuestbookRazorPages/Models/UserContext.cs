using Microsoft.EntityFrameworkCore;

namespace GuestbookRazorPages.Models
{    // Чтобы подключиться к базе данных через Entity Framework, необходим контекст данных. 
     // Контекст данных представляет собой класс, производный от класса DbContext.

    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }//тут нет DbSet  Register /Login так и понимает студия что доменная у нас лишь юзер

        public DbSet<Message> Messages { get; set; }
        
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}