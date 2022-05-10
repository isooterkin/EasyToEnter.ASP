using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using static EasyToEnter.ASP.Tools.DBSqlException;

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
        public async Task<IActionResult> Index() => View(await _context.LevelFocus.Include(l => l.FocusModel).Include(l => l.LevelModel).ToListAsync());

        // GET: LevelFocusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var levelFocusModel = await _context.LevelFocus
                .Include(l => l.FocusModel)
                .Include(l => l.LevelModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (levelFocusModel == null) return NotFound();

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevelId,FocusId,Id")] LevelFocusModel levelFocusModel)
        {
            if (ModelState.IsValid)
                try
                {
                    _context.Add(levelFocusModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exception)
                {
                    CheckedDBSqlException(exception, ModelState);
                }

            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", levelFocusModel.FocusId);
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Name", levelFocusModel.LevelId);
            return View(levelFocusModel);
        }

        // GET: LevelFocusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var levelFocusModel = await _context.LevelFocus.FindAsync(id);
            
            if (levelFocusModel == null) return NotFound();

            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", levelFocusModel.FocusId);
            ViewData["LevelId"] = new SelectList(_context.Level, "Id", "Name", levelFocusModel.LevelId);
            return View(levelFocusModel);
        }

        // POST: LevelFocusModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevelId,FocusId,Id")] LevelFocusModel levelFocusModel)
        {
            if (id != levelFocusModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levelFocusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelFocusModelExists(levelFocusModel.Id)) return NotFound();
                    else throw;
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
            if (id == null) return NotFound();

            var levelFocusModel = await _context.LevelFocus
                .Include(l => l.FocusModel)
                .Include(l => l.LevelModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (levelFocusModel == null) return NotFound();

            return View(levelFocusModel);
        }

        // POST: LevelFocusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            LevelFocusModel? levelFocusModel = await _context.LevelFocus.FindAsync(id);
            if (levelFocusModel == null) return RedirectToAction(nameof(Index));
            _context.LevelFocus.Remove(levelFocusModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelFocusModelExists(int id) => _context.LevelFocus.Any(e => e.Id == id);
    }
}