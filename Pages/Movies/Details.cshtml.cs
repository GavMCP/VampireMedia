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
    public class DetailsModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public DetailsModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

      public MoviesModel Movies { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movies == null)
            {
                return NotFound();
            }
            else 
            {
                Movies = movies;
            }
            return Page();
        }
    }
}
