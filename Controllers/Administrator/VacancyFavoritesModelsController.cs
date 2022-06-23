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
    public class VacancyFavoritesModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public VacancyFavoritesModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: VacancyFavoritesModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.VacancyFavorites.Include(v => v.PersonModel).Include(v => v.VacancyModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: VacancyFavoritesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VacancyFavorites == null)
            {
                return NotFound();
            }

            var vacancyFavoritesModel = await _context.VacancyFavorites
                .Include(v => v.PersonModel)
                .Include(v => v.VacancyModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyFavoritesModel == null)
            {
                return NotFound();
            }

            return View(vacancyFavoritesModel);
        }

        // GET: VacancyFavoritesModels/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login");
            ViewData["VacancyId"] = new SelectList(_context.Vacancy, "Id", "Name");
            return View();
        }

        // POST: VacancyFavoritesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacancyId,PersonId,Id")] VacancyFavoritesModel vacancyFavoritesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancyFavoritesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", vacancyFavoritesModel.PersonId);
            ViewData["VacancyId"] = new SelectList(_context.Vacancy, "Id", "Name", vacancyFavoritesModel.VacancyId);
            return View(vacancyFavoritesModel);
        }

        // GET: VacancyFavoritesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VacancyFavorites == null)
            {
                return NotFound();
            }

            var vacancyFavoritesModel = await _context.VacancyFavorites.FindAsync(id);
            if (vacancyFavoritesModel == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", vacancyFavoritesModel.PersonId);
            ViewData["VacancyId"] = new SelectList(_context.Vacancy, "Id", "Name", vacancyFavoritesModel.VacancyId);
            return View(vacancyFavoritesModel);
        }

        // POST: VacancyFavoritesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacancyId,PersonId,Id")] VacancyFavoritesModel vacancyFavoritesModel)
        {
            if (id != vacancyFavoritesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyFavoritesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyFavoritesModelExists(vacancyFavoritesModel.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", vacancyFavoritesModel.PersonId);
            ViewData["VacancyId"] = new SelectList(_context.Vacancy, "Id", "Name", vacancyFavoritesModel.VacancyId);
            return View(vacancyFavoritesModel);
        }

        // GET: VacancyFavoritesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VacancyFavorites == null)
            {
                return NotFound();
            }

            var vacancyFavoritesModel = await _context.VacancyFavorites
                .Include(v => v.PersonModel)
                .Include(v => v.VacancyModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyFavoritesModel == null)
            {
                return NotFound();
            }

            return View(vacancyFavoritesModel);
        }

        // POST: VacancyFavoritesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VacancyFavorites == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.VacancyFavorites'  is null.");
            }
            var vacancyFavoritesModel = await _context.VacancyFavorites.FindAsync(id);
            if (vacancyFavoritesModel != null)
            {
                _context.VacancyFavorites.Remove(vacancyFavoritesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyFavoritesModelExists(int id)
        {
          return (_context.VacancyFavorites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
