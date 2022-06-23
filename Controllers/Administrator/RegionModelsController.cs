using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Controllers.Administrator
{
    public class RegionModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public RegionModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: RegionModels
        public async Task<IActionResult> Index()
        {
              return _context.Region != null ? 
                          View(await _context.Region.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Region'  is null.");
        }

        // GET: RegionModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Region == null)
            {
                return NotFound();
            }

            var regionModel = await _context.Region
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regionModel == null)
            {
                return NotFound();
            }

            return View(regionModel);
        }

        // GET: RegionModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] RegionModel regionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regionModel);
        }

        // GET: RegionModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Region == null)
            {
                return NotFound();
            }

            var regionModel = await _context.Region.FindAsync(id);
            if (regionModel == null)
            {
                return NotFound();
            }
            return View(regionModel);
        }

        // POST: RegionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] RegionModel regionModel)
        {
            if (id != regionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionModelExists(regionModel.Id))
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
            return View(regionModel);
        }

        // GET: RegionModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Region == null)
            {
                return NotFound();
            }

            var regionModel = await _context.Region
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regionModel == null)
            {
                return NotFound();
            }

            return View(regionModel);
        }

        // POST: RegionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Region == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Region'  is null.");
            }
            var regionModel = await _context.Region.FindAsync(id);
            if (regionModel != null)
            {
                _context.Region.Remove(regionModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionModelExists(int id)
        {
          return (_context.Region?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
