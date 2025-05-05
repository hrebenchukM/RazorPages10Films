using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages10Films.Models;

namespace RazorPages10Films.Pages
{//избавляемся от необходимости создания вьюмоделей ибо тут можем любые свойства  из разных таблиц моделей

    public class CreateModel : PageModel
    {
        private readonly RazorPages10Films.Models.FilmContext _context;

        // IWebHostEnvironment предоставляет информацию об окружении, в котором запущено приложение
        IWebHostEnvironment _appEnvironment;//чтоб получить полный путь к папке Files

        public CreateModel(RazorPages10Films.Models.FilmContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult OnGet()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        [BindProperty]//name="uploadedFile", по умолчанию пост запрос
        public IFormFile uploadedFile { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()//пришли данные
        {

            if (!ModelState.IsValid || _context.Films == null || Film == null)
            {
                return Page();
            }

            if (uploadedFile != null)
            {
                // Путь к папке Files
                string path = "/Files/" + uploadedFile.FileName; // имя файла

                // Сохраняем файл в папку Files в каталоге wwwroot
                // Для получения полного пути к каталогу wwwroot
                // применяется свойство WebRootPath объекта IWebHostEnvironment
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                }
                Film.Poster  = path ;
             
            }
            _context.Films.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
