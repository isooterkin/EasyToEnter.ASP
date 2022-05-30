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
    public class DisciplineFocusUniversityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public DisciplineFocusUniversityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: DisciplineFocusUniversityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.DisciplineFocusUniversity.Include(d => d.DisciplineModel).Include(d => d.FocusUniversityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: DisciplineFocusUniversityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DisciplineFocusUniversity == null)
            {
                return NotFound();
            }

            var disciplineFocusUniversityModel = await _context.DisciplineFocusUniversity
                .Include(d => d.DisciplineModel)
                .Include(d => d.FocusUniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplineFocusUniversityModel == null)
            {
                return NotFound();
            }

            return View(disciplineFocusUniversityModel);
        }

        // GET: DisciplineFocusUniversityModels/Create
        public IActionResult Create()
        {
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name");
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id");
            return View();
        }

        // POST: DisciplineFocusUniversityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FocusUniversityId,DisciplineId,DisciplineCredit,Id")] DisciplineFocusUniversityModel disciplineFocusUniversityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplineFocusUniversityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name", disciplineFocusUniversityModel.DisciplineId);
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", disciplineFocusUniversityModel.FocusUniversityId);
            return View(disciplineFocusUniversityModel);
        }

        // GET: DisciplineFocusUniversityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DisciplineFocusUniversity == null)
            {
                return NotFound();
            }

            var disciplineFocusUniversityModel = await _context.DisciplineFocusUniversity.FindAsync(id);
            if (disciplineFocusUniversityModel == null)
            {
                return NotFound();
            }
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name", disciplineFocusUniversityModel.DisciplineId);
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", disciplineFocusUniversityModel.FocusUniversityId);
            return View(disciplineFocusUniversityModel);
        }

        // POST: DisciplineFocusUniversityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FocusUniversityId,DisciplineId,DisciplineCredit,Id")] DisciplineFocusUniversityModel disciplineFocusUniversityModel)
        {
            if (id != disciplineFocusUniversityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplineFocusUniversityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineFocusUniversityModelExists(disciplineFocusUniversityModel.Id))
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
            ViewData["DisciplineId"] = new SelectList(_context.Discipline, "Id", "Name", disciplineFocusUniversityModel.DisciplineId);
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", disciplineFocusUniversityModel.FocusUniversityId);
            return View(disciplineFocusUniversityModel);
        }

        // GET: DisciplineFocusUniversityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DisciplineFocusUniversity == null)
            {
                return NotFound();
            }

            var disciplineFocusUniversityModel = await _context.DisciplineFocusUniversity
                .Include(d => d.DisciplineModel)
                .Include(d => d.FocusUniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplineFocusUniversityModel == null)
            {
                return NotFound();
            }

            return View(disciplineFocusUniversityModel);
        }

        // POST: DisciplineFocusUniversityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DisciplineFocusUniversity == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.DisciplineFocusUniversity'  is null.");
            }
            var disciplineFocusUniversityModel = await _context.DisciplineFocusUniversity.FindAsync(id);
            if (disciplineFocusUniversityModel != null)
            {
                _context.DisciplineFocusUniversity.Remove(disciplineFocusUniversityModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineFocusUniversityModelExists(int id)
        {
          return (_context.DisciplineFocusUniversity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
