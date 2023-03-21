using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public IndexModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

        public IList<ListTodoModel> ListTodoModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ListTodoModel != null)
            {
                ListTodoModel = await _context.ListTodoModel.ToListAsync();
            }
        }
    }
}
