using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionManagment.Data;
using ProductionManagment.Models;

namespace ProductionManagment.Controllers
{
    public class SearchHistoriesController : Controller
    {
        private readonly ProductionManagmentContext _context;

        public SearchHistoriesController(ProductionManagmentContext context)
        {
            _context = context;
        }

        // GET: SearchHistories
        public async Task<IActionResult> Index()
        {
              return View(await _context.SearchHistory.ToListAsync());
        }

        // GET: SearchHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SearchHistory == null)
            {
                return NotFound();
            }

            var searchHistory = await _context.SearchHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (searchHistory == null)
            {
                return NotFound();
            }

            return View(searchHistory);
        }

        // GET: SearchHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SearchHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityId,ModuleName1,ModuleName2,ModuleName3,ModuleName4,ProductionCost")] SearchHistory searchHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(searchHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(searchHistory);
        }

        // GET: SearchHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SearchHistory == null)
            {
                return NotFound();
            }

            var searchHistory = await _context.SearchHistory.FindAsync(id);
            if (searchHistory == null)
            {
                return NotFound();
            }
            return View(searchHistory);
        }

        // POST: SearchHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CityId,ModuleName1,ModuleName2,ModuleName3,ModuleName4,ProductionCost")] SearchHistory searchHistory)
        {
            if (id != searchHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(searchHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchHistoryExists(searchHistory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(searchHistory);
        }

        // GET: SearchHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SearchHistory == null)
            {
                return NotFound();
            }

            var searchHistory = await _context.SearchHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (searchHistory == null)
            {
                return NotFound();
            }

            return View(searchHistory);
        }

        // POST: SearchHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SearchHistory == null)
            {
                return Problem("Entity set 'ProductionManagmentContext.SearchHistory'  is null.");
            }
            var searchHistory = await _context.SearchHistory.FindAsync(id);
            if (searchHistory != null)
            {
                _context.SearchHistory.Remove(searchHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchHistoryExists(int id)
        {
          return _context.SearchHistory.Any(e => e.Id == id);
        }
    }
}
