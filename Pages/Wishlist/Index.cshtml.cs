using System;
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
    public class IndexModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public IndexModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

        public IList<WishlistModel> WishlistModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.WishlistModel != null)
            {
                WishlistModel = await _context.WishlistModel.OrderBy(x => x.Title).ToListAsync();
            }
        }
    }
}
