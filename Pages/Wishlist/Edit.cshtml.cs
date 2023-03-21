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

namespace VampireMedia.Pages.Wishlist
{
    public class EditModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public EditModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WishlistModel WishlistModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WishlistModel == null)
            {
                return NotFound();
            }

            var wishlistmodel =  await _context.WishlistModel.FirstOrDefaultAsync(m => m.Id == id);
            if (wishlistmodel == null)
            {
                return NotFound();
            }
            WishlistModel = wishlistmodel;
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

            _context.Attach(WishlistModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistModelExists(WishlistModel.Id))
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

        private bool WishlistModelExists(int id)
        {
          return (_context.WishlistModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
