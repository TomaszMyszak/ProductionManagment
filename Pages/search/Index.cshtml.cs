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
    #pragma warning disable CS8618
    #pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly ProductionManagment.Data.ProductionManagmentContext _context;

        public IndexModel(ProductionManagment.Data.ProductionManagmentContext context)
        {
            _context = context;
        }

        public IList<SearchHistory> SearchHistory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SearchHistory != null)
            {
                SearchHistory = await _context.SearchHistory.ToListAsync();
            }
        }
    }
}
