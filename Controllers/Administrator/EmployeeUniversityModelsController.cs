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
    public class EmployeeUniversityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public EmployeeUniversityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeUniversityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.EmployeeUniversity.Include(e => e.PersonModel).Include(e => e.UniversityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: EmployeeUniversityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeUniversity == null)
            {
                return NotFound();
            }

            var employeeUniversityModel = await _context.EmployeeUniversity
                .Include(e => e.PersonModel)
                .Include(e => e.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeUniversityModel == null)
            {
                return NotFound();
            }

            return View(employeeUniversityModel);
        }

        // GET: EmployeeUniversityModels/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login");
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation");
            return View();
        }

        // POST: EmployeeUniversityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversityId,PersonId,Id")] EmployeeUniversityModel employeeUniversityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeUniversityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", employeeUniversityModel.PersonId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", employeeUniversityModel.UniversityId);
            return View(employeeUniversityModel);
        }

        // GET: EmployeeUniversityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeUniversity == null)
            {
                return NotFound();
            }

            var employeeUniversityModel = await _context.EmployeeUniversity.FindAsync(id);
            if (employeeUniversityModel == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", employeeUniversityModel.PersonId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", employeeUniversityModel.UniversityId);
            return View(employeeUniversityModel);
        }

        // POST: EmployeeUniversityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniversityId,PersonId,Id")] EmployeeUniversityModel employeeUniversityModel)
        {
            if (id != employeeUniversityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeUniversityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeUniversityModelExists(employeeUniversityModel.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", employeeUniversityModel.PersonId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", employeeUniversityModel.UniversityId);
            return View(employeeUniversityModel);
        }

        // GET: EmployeeUniversityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeUniversity == null)
            {
                return NotFound();
            }

            var employeeUniversityModel = await _context.EmployeeUniversity
                .Include(e => e.PersonModel)
                .Include(e => e.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeUniversityModel == null)
            {
                return NotFound();
            }

            return View(employeeUniversityModel);
        }

        // POST: EmployeeUniversityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeUniversity == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.EmployeeUniversity'  is null.");
            }
            var employeeUniversityModel = await _context.EmployeeUniversity.FindAsync(id);
            if (employeeUniversityModel != null)
            {
                _context.EmployeeUniversity.Remove(employeeUniversityModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeUniversityModelExists(int id)
        {
          return (_context.EmployeeUniversity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
