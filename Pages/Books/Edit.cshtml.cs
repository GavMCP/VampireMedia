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

namespace VampireMedia.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public EditModel(VampireMedia.Data.VampireMediaContext context)
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

            var booksmodel =  await _context.BooksModel.FirstOrDefaultAsync(m => m.Id == id);
            if (booksmodel == null)
            {
                return NotFound();
            }
            BooksModel = booksmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BooksModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksModelExists(BooksModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BooksModelExists(int id)
        {
          return (_context.BooksModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
