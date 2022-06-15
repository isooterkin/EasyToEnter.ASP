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
    public class VacancyModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public VacancyModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: VacancyModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Vacancy.Include(v => v.OrganizationModel).Include(v => v.ProfessionModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: VacancyModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vacancy == null)
            {
                return NotFound();
            }

            var vacancyModel = await _context.Vacancy
                .Include(v => v.OrganizationModel)
                .Include(v => v.ProfessionModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyModel == null)
            {
                return NotFound();
            }

            return View(vacancyModel);
        }

        // GET: VacancyModels/Create
        public IActionResult Create()
        {
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress");
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name");
            return View();
        }

        // POST: VacancyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Wages,Name,Description,OrganizationId,ProfessionId,Id")] VacancyModel vacancyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress", vacancyModel.OrganizationId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", vacancyModel.ProfessionId);
            return View(vacancyModel);
        }

        // GET: VacancyModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vacancy == null)
            {
                return NotFound();
            }

            var vacancyModel = await _context.Vacancy.FindAsync(id);
            if (vacancyModel == null)
            {
                return NotFound();
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress", vacancyModel.OrganizationId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", vacancyModel.ProfessionId);
            return View(vacancyModel);
        }

        // POST: VacancyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Wages,Name,Description,OrganizationId,ProfessionId,Id")] VacancyModel vacancyModel)
        {
            if (id != vacancyModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyModelExists(vacancyModel.Id))
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
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress", vacancyModel.OrganizationId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", vacancyModel.ProfessionId);
            return View(vacancyModel);
        }

        // GET: VacancyModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vacancy == null)
            {
                return NotFound();
            }

            var vacancyModel = await _context.Vacancy
                .Include(v => v.OrganizationModel)
                .Include(v => v.ProfessionModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyModel == null)
            {
                return NotFound();
            }

            return View(vacancyModel);
        }

        // POST: VacancyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vacancy == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Vacancy'  is null.");
            }
            var vacancyModel = await _context.Vacancy.FindAsync(id);
            if (vacancyModel != null)
            {
                _context.Vacancy.Remove(vacancyModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyModelExists(int id)
        {
          return (_context.Vacancy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
