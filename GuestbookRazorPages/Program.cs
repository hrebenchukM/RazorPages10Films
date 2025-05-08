using GuestbookRazorPages.Models;
using Microsoft.EntityFrameworkCore;
using GuestbookRazorPages.Repository;
using GuestbookRazorPages.Services;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// Все сессии работают поверх объекта IDistributedCache, и ASP.NET Core 
// предоставляет встроенную реализацию IDistributedCache
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Длительность сеанса (тайм-аут завершения сеанса)
    options.Cookie.Name = "Session"; // Каждая сессия имеет свой идентификатор, который сохраняется в куках.

});



// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));//считается сервисом StudentContext

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();


builder.Services.AddScoped<IPassword, PasswordService>();


var app = builder.Build();
app.UseSession();   // Добавляем middleware-компонент для работы с сессиями


app.UseStaticFiles();


app.MapRazorPages();

app.Run();
