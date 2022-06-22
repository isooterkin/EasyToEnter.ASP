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
    public class SpecializationModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public SpecializationModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: SpecializationModels
        public async Task<IActionResult> Index()
        {
              return _context.Specialization != null ? 
                          View(await _context.Specialization.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Specialization'  is null.");
        }

        // GET: SpecializationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Specialization == null)
            {
                return NotFound();
            }

            var specializationModel = await _context.Specialization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specializationModel == null)
            {
                return NotFound();
            }

            return View(specializationModel);
        }

        // GET: SpecializationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecializationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] SpecializationModel specializationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specializationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specializationModel);
        }

        // GET: SpecializationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Specialization == null)
            {
                return NotFound();
            }

            var specializationModel = await _context.Specialization.FindAsync(id);
            if (specializationModel == null)
            {
                return NotFound();
            }
            return View(specializationModel);
        }

        // POST: SpecializationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] SpecializationModel specializationModel)
        {
            if (id != specializationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specializationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecializationModelExists(specializationModel.Id))
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
            return View(specializationModel);
        }

        // GET: SpecializationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Specialization == null)
            {
                return NotFound();
            }

            var specializationModel = await _context.Specialization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specializationModel == null)
            {
                return NotFound();
            }

            return View(specializationModel);
        }

        // POST: SpecializationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Specialization == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Specialization'  is null.");
            }
            var specializationModel = await _context.Specialization.FindAsync(id);
            if (specializationModel != null)
            {
                _context.Specialization.Remove(specializationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecializationModelExists(int id)
        {
          return (_context.Specialization?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
