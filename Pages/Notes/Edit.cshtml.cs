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

namespace VampireMedia.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public EditModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ListTodoModel ListTodoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ListTodoModel == null)
            {
                return NotFound();
            }

            var listtodomodel =  await _context.ListTodoModel.FirstOrDefaultAsync(m => m.Id == id);
            if (listtodomodel == null)
            {
                return NotFound();
            }
            ListTodoModel = listtodomodel;
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

            _context.Attach(ListTodoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListTodoModelExists(ListTodoModel.Id))
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

        private bool ListTodoModelExists(int id)
        {
          return (_context.ListTodoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
