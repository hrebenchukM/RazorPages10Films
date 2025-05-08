using GuestbookRazorPages.Models;
using Microsoft.EntityFrameworkCore;
using GuestbookRazorPages.Repository;
using GuestbookRazorPages.Services;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// ��� ������ �������� ������ ������� IDistributedCache, � ASP.NET Core 
// ������������� ���������� ���������� IDistributedCache
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // ������������ ������ (����-��� ���������� ������)
    options.Cookie.Name = "Session"; // ������ ������ ����� ���� �������������, ������� ����������� � �����.

});



// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));//��������� �������� StudentContext

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();


builder.Services.AddScoped<IPassword, PasswordService>();


var app = builder.Build();
app.UseSession();   // ��������� middleware-��������� ��� ������ � ��������


app.UseStaticFiles();


app.MapRazorPages();

app.Run();
