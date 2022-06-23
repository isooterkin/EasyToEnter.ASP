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
    public class AreaModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public AreaModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: AreaModels
        public async Task<IActionResult> Index()
        {
              return _context.Area != null ? 
                          View(await _context.Area.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Area'  is null.");
        }

        // GET: AreaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Area == null)
            {
                return NotFound();
            }

            var areaModel = await _context.Area
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaModel == null)
            {
                return NotFound();
            }

            return View(areaModel);
        }

        // GET: AreaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] AreaModel areaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaModel);
        }

        // GET: AreaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Area == null)
            {
                return NotFound();
            }

            var areaModel = await _context.Area.FindAsync(id);
            if (areaModel == null)
            {
                return NotFound();
            }
            return View(areaModel);
        }

        // POST: AreaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] AreaModel areaModel)
        {
            if (id != areaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaModelExists(areaModel.Id))
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
            return View(areaModel);
        }

        // GET: AreaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Area == null)
            {
                return NotFound();
            }

            var areaModel = await _context.Area
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaModel == null)
            {
                return NotFound();
            }

            return View(areaModel);
        }

        // POST: AreaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Area == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Area'  is null.");
            }
            var areaModel = await _context.Area.FindAsync(id);
            if (areaModel != null)
            {
                _context.Area.Remove(areaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaModelExists(int id)
        {
          return (_context.Area?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
