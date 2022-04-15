#nullable disable
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
    public class LevelFocusModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public LevelFocusModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: LevelFocusModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.LevelFocus.Include(l => l.FocusModel).Include(l => l.LevelModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: LevelFocusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelFocusModel = await _context.LevelFocus
                .Include(l => l.FocusModel)
                .Include(l => l.LevelModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelFocusModel == null)
            {
                return NotFound();
            }

            return View(levelFocusModel);
        }

        // GET: LevelFocusModels/Create
        public IActionResult Create()
        {
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name");
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Name");
            return View();
        }

        // POST: LevelFocusModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevelId,FocusId,Id")] LevelFocusModel levelFocusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levelFocusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", levelFocusModel.FocusId);
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Name", levelFocusModel.LevelId);
            return View(levelFocusModel);
        }

        // GET: LevelFocusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelFocusModel = await _context.LevelFocus.FindAsync(id);
            if (levelFocusModel == null)
            {
                return NotFound();
            }
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", levelFocusModel.FocusId);
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Name", levelFocusModel.LevelId);
            return View(levelFocusModel);
        }

        // POST: LevelFocusModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevelId,FocusId,Id")] LevelFocusModel levelFocusModel)
        {
            if (id != levelFocusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levelFocusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelFocusModelExists(levelFocusModel.Id))
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
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", levelFocusModel.FocusId);
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Name", levelFocusModel.LevelId);
            return View(levelFocusModel);
        }

        // GET: LevelFocusModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelFocusModel = await _context.LevelFocus
                .Include(l => l.FocusModel)
                .Include(l => l.LevelModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelFocusModel == null)
            {
                return NotFound();
            }

            return View(levelFocusModel);
        }

        // POST: LevelFocusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var levelFocusModel = await _context.LevelFocus.FindAsync(id);
            _context.LevelFocus.Remove(levelFocusModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelFocusModelExists(int id)
        {
            return _context.LevelFocus.Any(e => e.Id == id);
        }
    }
}
