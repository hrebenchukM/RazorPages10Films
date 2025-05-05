using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages10Films.Models;

namespace RazorPages10Films.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPages10Films.Models.FilmContext _context;

        public DetailsModel(RazorPages10Films.Models.FilmContext context)
        {
            _context = context;
        }

        public Film Film { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            else
            {
                Film = film;
            }
            return Page();//надо ибо Task<IActionResult> а не Task/void
        }
    }
}
