using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;
        public string MovieExistsMessage { get; set; }

        public CreateModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MoviesModel Movies { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Movies == null || Movies == null)
            {
                return Page();
            }

            // Is the movie already in the Db?
            if (await GetMoviesToCheck(Movies))
            {
                MovieExistsMessage = "This movie already exists in the database on this media type.";
                return RedirectToPage("./Index");
            }
               
               
            _context.Movies.Add(Movies);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }


        private async Task<bool> GetMoviesToCheck(MoviesModel movies)
        {
            var currentMoviesInDb = await _context.Movies.OrderBy(x => x.Title).ToListAsync();
            
            foreach(var movie in currentMoviesInDb)
            {
                if(movie.Title == movies.Title && movie.Director == movies.Director && 
                    movie.ReleaseDate == movies.ReleaseDate && 
                    movie.MediaType == movies.MediaType)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
