using Microsoft.EntityFrameworkCore;
using RazorPages10Films.Models;

var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<FilmContext>(options => options.UseSqlServer(connection));

// Добавляем в приложение набор сервисов Razor Pages в DI контейнер 
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot

// Добавляем поддержку маршрутизации для Razor Pages
app.MapRazorPages();

app.Run();
