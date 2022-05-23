using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductionManagment.Data;
using ProductionManagment.Models;

namespace ProductionManagment.Pages.search
{
    public class CreateModel : PageModel
    {
        private readonly ProductionManagment.Data.ProductionManagmentContext _context;

        public CreateModel(ProductionManagment.Data.ProductionManagmentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SearchHistory SearchHistory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SearchHistory == null || SearchHistory == null)
            {
                return Page();
            }

            _context.SearchHistory.Add(SearchHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
