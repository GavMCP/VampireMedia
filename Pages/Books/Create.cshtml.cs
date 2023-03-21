using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly VampireMediaContext _context;

        public CreateModel(VampireMediaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BooksModel BooksModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BooksModel == null || BooksModel == null)
            {
                return Page();
            }

            _context.BooksModel.Add(BooksModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
