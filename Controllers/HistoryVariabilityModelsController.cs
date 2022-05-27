using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Controllers
{
    public class HistoryVariabilityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public HistoryVariabilityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: HistoryVariabilityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.HistoryVariability.Include(h => h.VariabilityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: HistoryVariabilityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoryVariability == null)
            {
                return NotFound();
            }

            var historyVariabilityModel = await _context.HistoryVariability
                .Include(h => h.VariabilityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historyVariabilityModel == null)
            {
                return NotFound();
            }

            return View(historyVariabilityModel);
        }

        // GET: HistoryVariabilityModels/Create
        public IActionResult Create()
        {
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id");
            return View();
        }

        // POST: HistoryVariabilityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Year,PassingGrade,Tuition,NumberSeats,VariabilityId,Id")] HistoryVariabilityModel historyVariabilityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historyVariabilityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id", historyVariabilityModel.VariabilityId);
            return View(historyVariabilityModel);
        }

        // GET: HistoryVariabilityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistoryVariability == null)
            {
                return NotFound();
            }

            var historyVariabilityModel = await _context.HistoryVariability.FindAsync(id);
            if (historyVariabilityModel == null)
            {
                return NotFound();
            }
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id", historyVariabilityModel.VariabilityId);
            return View(historyVariabilityModel);
        }

        // POST: HistoryVariabilityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Year,PassingGrade,Tuition,NumberSeats,VariabilityId,Id")] HistoryVariabilityModel historyVariabilityModel)
        {
            if (id != historyVariabilityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historyVariabilityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryVariabilityModelExists(historyVariabilityModel.Id))
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
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id", historyVariabilityModel.VariabilityId);
            return View(historyVariabilityModel);
        }

        // GET: HistoryVariabilityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoryVariability == null)
            {
                return NotFound();
            }

            var historyVariabilityModel = await _context.HistoryVariability
                .Include(h => h.VariabilityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historyVariabilityModel == null)
            {
                return NotFound();
            }

            return View(historyVariabilityModel);
        }

        // POST: HistoryVariabilityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoryVariability == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.HistoryVariability'  is null.");
            }
            var historyVariabilityModel = await _context.HistoryVariability.FindAsync(id);
            if (historyVariabilityModel != null)
            {
                _context.HistoryVariability.Remove(historyVariabilityModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryVariabilityModelExists(int id)
        {
          return (_context.HistoryVariability?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
