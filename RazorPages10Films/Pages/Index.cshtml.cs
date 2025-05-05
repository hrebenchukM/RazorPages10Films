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
    public class IndexModel : PageModel
    {
        private readonly RazorPages10Films.Models.FilmContext _context;

        public IndexModel(RazorPages10Films.Models.FilmContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Films != null)
            {
                Film = await _context.Films
                .Include(f => f.Genre).ToListAsync();
            }
        }
        public async Task OnGetByYear()
        {
            if (_context.Films != null)
            {
                Film = await _context.Films.OrderBy(f => f.Year).ToListAsync();
            }
        }
    }
}
