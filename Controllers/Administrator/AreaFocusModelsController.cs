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
    public class AreaFocusModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public AreaFocusModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: AreaFocusModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.AreaFocus.Include(a => a.AreaModel).Include(a => a.FocusModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: AreaFocusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AreaFocus == null)
            {
                return NotFound();
            }

            var areaFocusModel = await _context.AreaFocus
                .Include(a => a.AreaModel)
                .Include(a => a.FocusModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaFocusModel == null)
            {
                return NotFound();
            }

            return View(areaFocusModel);
        }

        // GET: AreaFocusModels/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name");
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name");
            return View();
        }

        // POST: AreaFocusModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaId,FocusId,Id")] AreaFocusModel areaFocusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaFocusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name", areaFocusModel.AreaId);
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", areaFocusModel.FocusId);
            return View(areaFocusModel);
        }

        // GET: AreaFocusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AreaFocus == null)
            {
                return NotFound();
            }

            var areaFocusModel = await _context.AreaFocus.FindAsync(id);
            if (areaFocusModel == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name", areaFocusModel.AreaId);
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", areaFocusModel.FocusId);
            return View(areaFocusModel);
        }

        // POST: AreaFocusModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaId,FocusId,Id")] AreaFocusModel areaFocusModel)
        {
            if (id != areaFocusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaFocusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaFocusModelExists(areaFocusModel.Id))
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
            ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name", areaFocusModel.AreaId);
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", areaFocusModel.FocusId);
            return View(areaFocusModel);
        }

        // GET: AreaFocusModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AreaFocus == null)
            {
                return NotFound();
            }

            var areaFocusModel = await _context.AreaFocus
                .Include(a => a.AreaModel)
                .Include(a => a.FocusModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaFocusModel == null)
            {
                return NotFound();
            }

            return View(areaFocusModel);
        }

        // POST: AreaFocusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AreaFocus == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.AreaFocus'  is null.");
            }
            var areaFocusModel = await _context.AreaFocus.FindAsync(id);
            if (areaFocusModel != null)
            {
                _context.AreaFocus.Remove(areaFocusModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaFocusModelExists(int id)
        {
            return (_context.AreaFocus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
