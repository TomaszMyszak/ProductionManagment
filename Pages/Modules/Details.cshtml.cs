using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductionManagment.Data;
using ProductionManagment.Models;

namespace ProductionManagment.Pages.Modules
{
    public class DetailsModel : PageModel
    {
        private readonly ProductionManagment.Data.ProductionManagmentContext _context;

        public DetailsModel(ProductionManagment.Data.ProductionManagmentContext context)
        {
            _context = context;
        }

      public Module Module { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Module == null)
            {
                return NotFound();
            }

            var module = await _context.Module.FirstOrDefaultAsync(m => m.Id == id);
            if (module == null)
            {
                return NotFound();
            }
            else 
            {
                Module = module;
            }
            return Page();
        }
    }
}
