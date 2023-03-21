﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Wishlist
{
    public class DeleteModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public DeleteModel(VampireMedia.Data.VampireMediaContext context)
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

            var wishlistmodel = await _context.WishlistModel.FirstOrDefaultAsync(m => m.Id == id);

            if (wishlistmodel == null)
            {
                return NotFound();
            }
            else 
            {
                WishlistModel = wishlistmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.WishlistModel == null)
            {
                return NotFound();
            }
            var wishlistmodel = await _context.WishlistModel.FindAsync(id);

            if (wishlistmodel != null)
            {
                WishlistModel = wishlistmodel;
                _context.WishlistModel.Remove(WishlistModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
