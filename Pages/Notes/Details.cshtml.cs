﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly VampireMedia.Data.VampireMediaContext _context;

        public DetailsModel(VampireMedia.Data.VampireMediaContext context)
        {
            _context = context;
        }

      public ListTodoModel ListTodoModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ListTodoModel == null)
            {
                return NotFound();
            }

            var listtodomodel = await _context.ListTodoModel.FirstOrDefaultAsync(m => m.Id == id);
            if (listtodomodel == null)
            {
                return NotFound();
            }
            else 
            {
                ListTodoModel = listtodomodel;
            }
            return Page();
        }
    }
}
