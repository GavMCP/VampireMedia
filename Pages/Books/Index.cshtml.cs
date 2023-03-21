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
    public class IndexModel : PageModel
    {
        private readonly VampireMediaContext _context;

        public IndexModel(VampireMediaContext context)
        {
            _context = context;
        }

        public IList<BooksModel> BooksModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BooksModel != null)
            {
                BooksModel = await _context.BooksModel.OrderBy(x => x.Title).ToListAsync();
            }
        }
    }
}
