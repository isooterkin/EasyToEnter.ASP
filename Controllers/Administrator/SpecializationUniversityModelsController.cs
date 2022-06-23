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
    public class SpecializationUniversityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public SpecializationUniversityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: SpecializationUniversityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.SpecializationUniversity.Include(s => s.SpecializationModel).Include(s => s.UniversityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: SpecializationUniversityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SpecializationUniversity == null)
            {
                return NotFound();
            }

            var specializationUniversityModel = await _context.SpecializationUniversity
                .Include(s => s.SpecializationModel)
                .Include(s => s.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specializationUniversityModel == null)
            {
                return NotFound();
            }

            return View(specializationUniversityModel);
        }

        // GET: SpecializationUniversityModels/Create
        public IActionResult Create()
        {
            ViewData["SpecializationId"] = new SelectList(_context.Specialization, "Id", "Name");
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation");
            return View();
        }

        // POST: SpecializationUniversityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecializationId,UniversityId,Id")] SpecializationUniversityModel specializationUniversityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specializationUniversityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecializationId"] = new SelectList(_context.Specialization, "Id", "Name", specializationUniversityModel.SpecializationId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", specializationUniversityModel.UniversityId);
            return View(specializationUniversityModel);
        }

        // GET: SpecializationUniversityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SpecializationUniversity == null)
            {
                return NotFound();
            }

            var specializationUniversityModel = await _context.SpecializationUniversity.FindAsync(id);
            if (specializationUniversityModel == null)
            {
                return NotFound();
            }
            ViewData["SpecializationId"] = new SelectList(_context.Specialization, "Id", "Name", specializationUniversityModel.SpecializationId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", specializationUniversityModel.UniversityId);
            return View(specializationUniversityModel);
        }

        // POST: SpecializationUniversityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecializationId,UniversityId,Id")] SpecializationUniversityModel specializationUniversityModel)
        {
            if (id != specializationUniversityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specializationUniversityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecializationUniversityModelExists(specializationUniversityModel.Id))
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
            ViewData["SpecializationId"] = new SelectList(_context.Specialization, "Id", "Name", specializationUniversityModel.SpecializationId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", specializationUniversityModel.UniversityId);
            return View(specializationUniversityModel);
        }

        // GET: SpecializationUniversityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SpecializationUniversity == null)
            {
                return NotFound();
            }

            var specializationUniversityModel = await _context.SpecializationUniversity
                .Include(s => s.SpecializationModel)
                .Include(s => s.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specializationUniversityModel == null)
            {
                return NotFound();
            }

            return View(specializationUniversityModel);
        }

        // POST: SpecializationUniversityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SpecializationUniversity == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.SpecializationUniversity'  is null.");
            }
            var specializationUniversityModel = await _context.SpecializationUniversity.FindAsync(id);
            if (specializationUniversityModel != null)
            {
                _context.SpecializationUniversity.Remove(specializationUniversityModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecializationUniversityModelExists(int id)
        {
          return (_context.SpecializationUniversity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
