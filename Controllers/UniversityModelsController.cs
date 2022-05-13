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
    public class UniversityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public UniversityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: UniversityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.University.Include(u => u.AccreditationModel).Include(u => u.CityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: UniversityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var universityModel = await _context.University
                .Include(u => u.AccreditationModel)
                .Include(u => u.CityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityModel == null)
            {
                return NotFound();
            }

            return View(universityModel);
        }

        // GET: UniversityModels/Create
        public IActionResult Create()
        {
            ViewData["AccreditationId"] = new SelectList(_context.Accreditation, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            return View();
        }

        // POST: UniversityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailAddress,Address,MilitaryDepartment,CityId,AccreditationId,Description,Name,Id")] UniversityModel universityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccreditationId"] = new SelectList(_context.Accreditation, "Id", "Name", universityModel.AccreditationId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", universityModel.CityId);
            return View(universityModel);
        }

        // GET: UniversityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var universityModel = await _context.University.FindAsync(id);
            if (universityModel == null)
            {
                return NotFound();
            }
            ViewData["AccreditationId"] = new SelectList(_context.Accreditation, "Id", "Name", universityModel.AccreditationId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", universityModel.CityId);
            return View(universityModel);
        }

        // POST: UniversityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmailAddress,Address,MilitaryDepartment,CityId,AccreditationId,Description,Name,Id")] UniversityModel universityModel)
        {
            if (id != universityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityModelExists(universityModel.Id))
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
            ViewData["AccreditationId"] = new SelectList(_context.Accreditation, "Id", "Name", universityModel.AccreditationId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", universityModel.CityId);
            return View(universityModel);
        }

        // GET: UniversityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var universityModel = await _context.University
                .Include(u => u.AccreditationModel)
                .Include(u => u.CityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityModel == null)
            {
                return NotFound();
            }

            return View(universityModel);
        }

        // POST: UniversityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.University == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.University'  is null.");
            }
            var universityModel = await _context.University.FindAsync(id);
            if (universityModel != null)
            {
                _context.University.Remove(universityModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityModelExists(int id)
        {
          return (_context.University?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
