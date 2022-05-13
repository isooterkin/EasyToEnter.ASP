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
    public class FocusUniversityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public FocusUniversityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: FocusUniversityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.FocusUniversity.Include(f => f.LevelFocusModel).Include(f => f.UniversityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: FocusUniversityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FocusUniversity == null)
            {
                return NotFound();
            }

            var focusUniversityModel = await _context.FocusUniversity
                .Include(f => f.LevelFocusModel)
                .Include(f => f.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (focusUniversityModel == null)
            {
                return NotFound();
            }

            return View(focusUniversityModel);
        }

        // GET: FocusUniversityModels/Create
        public IActionResult Create()
        {
           var levelFocus = _context.LevelFocus
                .Include(f => f!.LevelModel)
                .Include(f => f!.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .ThenInclude(f => f!.GroupModel);

            ViewData["LevelFocusId"] = new SelectList(levelFocus, "Id", "CodeName");
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation");
            return View();
        }

        // POST: FocusUniversityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevelFocusId,UniversityId,Id")] FocusUniversityModel focusUniversityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(focusUniversityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LevelFocusId"] = new SelectList(_context.LevelFocus, "Id", "Id", focusUniversityModel.LevelFocusId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", focusUniversityModel.UniversityId);
            return View(focusUniversityModel);
        }

        // GET: FocusUniversityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FocusUniversity == null)
            {
                return NotFound();
            }

            var focusUniversityModel = await _context.FocusUniversity.FindAsync(id);
            if (focusUniversityModel == null)
            {
                return NotFound();
            }
            ViewData["LevelFocusId"] = new SelectList(_context.LevelFocus, "Id", "Id", focusUniversityModel.LevelFocusId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", focusUniversityModel.UniversityId);
            return View(focusUniversityModel);
        }

        // POST: FocusUniversityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevelFocusId,UniversityId,Id")] FocusUniversityModel focusUniversityModel)
        {
            if (id != focusUniversityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(focusUniversityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FocusUniversityModelExists(focusUniversityModel.Id))
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
            ViewData["LevelFocusId"] = new SelectList(_context.LevelFocus, "Id", "Id", focusUniversityModel.LevelFocusId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", focusUniversityModel.UniversityId);
            return View(focusUniversityModel);
        }

        // GET: FocusUniversityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FocusUniversity == null)
            {
                return NotFound();
            }

            var focusUniversityModel = await _context.FocusUniversity
                .Include(f => f.LevelFocusModel)
                .Include(f => f.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (focusUniversityModel == null)
            {
                return NotFound();
            }

            return View(focusUniversityModel);
        }

        // POST: FocusUniversityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FocusUniversity == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.FocusUniversity'  is null.");
            }
            var focusUniversityModel = await _context.FocusUniversity.FindAsync(id);
            if (focusUniversityModel != null)
            {
                _context.FocusUniversity.Remove(focusUniversityModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FocusUniversityModelExists(int id)
        {
          return (_context.FocusUniversity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
