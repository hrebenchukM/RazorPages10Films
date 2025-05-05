using Microsoft.EntityFrameworkCore;
using RazorPages10Films.Models;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<FilmContext>(options => options.UseSqlServer(connection));

// ��������� � ���������� ����� �������� Razor Pages � DI ��������� 
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot

// ��������� ��������� ������������� ��� Razor Pages
app.MapRazorPages();

app.Run();
