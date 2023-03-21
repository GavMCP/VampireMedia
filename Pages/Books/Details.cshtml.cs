using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public DetailsModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

      public BooksModel BooksModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BooksModel == null)
            {
                return NotFound();
            }

            var booksmodel = await _context.BooksModel.FirstOrDefaultAsync(m => m.Id == id);
            if (booksmodel == null)
            {
                return NotFound();
            }
            else 
            {
                BooksModel = booksmodel;
            }
            return Page();
        }
    }
}
