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
    public class ProfessionModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public ProfessionModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: ProfessionModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Profession.Include(p => p.TypeProfessionModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: ProfessionModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profession == null)
            {
                return NotFound();
            }

            var professionModel = await _context.Profession
                .Include(p => p.TypeProfessionModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionModel == null)
            {
                return NotFound();
            }

            return View(professionModel);
        }

        // GET: ProfessionModels/Create
        public IActionResult Create()
        {
            ViewData["TypeProfessionId"] = new SelectList(_context.TypeProfession, "Id", "Name");
            return View();
        }

        // POST: ProfessionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeProfessionId,Description,Name,Id")] ProfessionModel professionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeProfessionId"] = new SelectList(_context.TypeProfession, "Id", "Name", professionModel.TypeProfessionId);
            return View(professionModel);
        }

        // GET: ProfessionModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profession == null)
            {
                return NotFound();
            }

            var professionModel = await _context.Profession.FindAsync(id);
            if (professionModel == null)
            {
                return NotFound();
            }
            ViewData["TypeProfessionId"] = new SelectList(_context.TypeProfession, "Id", "Name", professionModel.TypeProfessionId);
            return View(professionModel);
        }

        // POST: ProfessionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeProfessionId,Description,Name,Id")] ProfessionModel professionModel)
        {
            if (id != professionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionModelExists(professionModel.Id))
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
            ViewData["TypeProfessionId"] = new SelectList(_context.TypeProfession, "Id", "Name", professionModel.TypeProfessionId);
            return View(professionModel);
        }

        // GET: ProfessionModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profession == null)
            {
                return NotFound();
            }

            var professionModel = await _context.Profession
                .Include(p => p.TypeProfessionModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionModel == null)
            {
                return NotFound();
            }

            return View(professionModel);
        }

        // POST: ProfessionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profession == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Profession'  is null.");
            }
            var professionModel = await _context.Profession.FindAsync(id);
            if (professionModel != null)
            {
                _context.Profession.Remove(professionModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionModelExists(int id)
        {
          return (_context.Profession?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
