using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductionManagment.Data;
using ProductionManagment.Models;

namespace ProductionManagment.Pages.search
{
    public class DetailsModel : PageModel
    {
        private readonly ProductionManagment.Data.ProductionManagmentContext _context;

        public DetailsModel(ProductionManagment.Data.ProductionManagmentContext context)
        {
            _context = context;
        }

      public SearchHistory SearchHistory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SearchHistory == null)
            {
                return NotFound();
            }

            var searchhistory = await _context.SearchHistory.FirstOrDefaultAsync(m => m.Id == id);
            if (searchhistory == null)
            {
                return NotFound();
            }
            else 
            {
                SearchHistory = searchhistory;
            }
            return Page();
        }
    }
}
