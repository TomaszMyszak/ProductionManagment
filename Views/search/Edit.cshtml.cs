using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionManagment.Data;
using ProductionManagment.Models;

namespace ProductionManagment.Pages.search
{
    public class EditModel : PageModel
    {
        private readonly ProductionManagment.Data.ProductionManagmentContext _context;

        public EditModel(ProductionManagment.Data.ProductionManagmentContext context)
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

            var searchhistory =  await _context.SearchHistory.FirstOrDefaultAsync(m => m.Id == id);
            if (searchhistory == null)
            {
                return NotFound();
            }
            SearchHistory = searchhistory;
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

            _context.Attach(SearchHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchHistoryExists(SearchHistory.Id))
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

        private bool SearchHistoryExists(int id)
        {
          return (_context.SearchHistory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
