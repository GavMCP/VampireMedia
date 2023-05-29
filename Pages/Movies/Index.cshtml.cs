using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly VampireMediaContext _context;

        public IndexModel(VampireMediaContext context)
        {
            _context = context;
        }

        public IList<MoviesModel> Movies { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                Movies = await _context.Movies.OrderBy(x => x.Title).ToListAsync();
                
            }
        }

        public async Task OrderByYear()
        {
            if(_context.Movies != null)
            {
                Movies = await _context.Movies.OrderBy(x => x.ReleaseDate).ToListAsync();
            }
        }
    }
}
