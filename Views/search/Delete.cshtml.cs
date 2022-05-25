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
    public class DeleteModel : PageModel
    {

        #pragma warning disable CS8618
        #pragma warning disable CS8601
        #pragma warning disable CS8602
        #pragma warning disable CS8604
        // Class
        #pragma warning restore CS8618
        #pragma warning restore CS8601
        #pragma warning restore CS8602
        #pragma warning restore CS8604


        private readonly ProductionManagment.Data.ProductionManagmentContext _context;

        public DeleteModel(ProductionManagment.Data.ProductionManagmentContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SearchHistory == null)
            {
                return NotFound();
            }
            var searchhistory = await _context.SearchHistory.FindAsync(id);

            if (searchhistory != null)
            {
                SearchHistory = searchhistory;
                _context.SearchHistory.Remove(SearchHistory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
