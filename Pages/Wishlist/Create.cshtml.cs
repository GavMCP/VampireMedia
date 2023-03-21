using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Wishlist
{
    public class CreateModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public CreateModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WishlistModel WishlistModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.WishlistModel == null || WishlistModel == null)
            {
                return Page();
            }

            _context.WishlistModel.Add(WishlistModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
