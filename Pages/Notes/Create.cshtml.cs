﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VampireMedia.Data;
using VampireMedia.Models;

namespace VampireMedia.Pages.Notes
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
        public ListTodoModel ListTodoModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ListTodoModel == null || ListTodoModel == null)
            {
                return Page();
            }

            _context.ListTodoModel.Add(ListTodoModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
