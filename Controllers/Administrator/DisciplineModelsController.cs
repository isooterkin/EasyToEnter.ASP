using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization.Attributes;

namespace EasyToEnter.ASP.Controllers.Administrator
{
    [AdministratorRole]
    public class DisciplineModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public DisciplineModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: DisciplineModels
        public async Task<IActionResult> Index()
        {
            return _context.Discipline != null ?
                        View(await _context.Discipline.ToListAsync()) :
                        Problem("Entity set 'EasyToEnterDbContext.Discipline'  is null.");
        }

        // GET: DisciplineModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }

            var disciplineModel = await _context.Discipline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplineModel == null)
            {
                return NotFound();
            }

            return View(disciplineModel);
        }

        // GET: DisciplineModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisciplineModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] DisciplineModel disciplineModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplineModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disciplineModel);
        }

        // GET: DisciplineModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }

            var disciplineModel = await _context.Discipline.FindAsync(id);
            if (disciplineModel == null)
            {
                return NotFound();
            }
            return View(disciplineModel);
        }

        // POST: DisciplineModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] DisciplineModel disciplineModel)
        {
            if (id != disciplineModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplineModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineModelExists(disciplineModel.Id))
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
            return View(disciplineModel);
        }

        // GET: DisciplineModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Discipline == null)
            {
                return NotFound();
            }

            var disciplineModel = await _context.Discipline
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplineModel == null)
            {
                return NotFound();
            }

            return View(disciplineModel);
        }

        // POST: DisciplineModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Discipline == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Discipline'  is null.");
            }
            var disciplineModel = await _context.Discipline.FindAsync(id);
            if (disciplineModel != null)
            {
                _context.Discipline.Remove(disciplineModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineModelExists(int id)
        {
            return (_context.Discipline?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
