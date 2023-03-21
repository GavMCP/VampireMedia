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
    public class DeleteModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public DeleteModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BooksModel == null)
            {
                return NotFound();
            }
            var booksmodel = await _context.BooksModel.FindAsync(id);

            if (booksmodel != null)
            {
                BooksModel = booksmodel;
                _context.BooksModel.Remove(BooksModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
