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
    public class UniversityFavoritesModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public UniversityFavoritesModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: UniversityFavoritesModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.UniversityFavorites.Include(u => u.PersonModel).Include(u => u.UniversityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: UniversityFavoritesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniversityFavorites == null)
            {
                return NotFound();
            }

            var universityFavoritesModel = await _context.UniversityFavorites
                .Include(u => u.PersonModel)
                .Include(u => u.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityFavoritesModel == null)
            {
                return NotFound();
            }

            return View(universityFavoritesModel);
        }

        // GET: UniversityFavoritesModels/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login");
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation");
            return View();
        }

        // POST: UniversityFavoritesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversityId,PersonId,Id")] UniversityFavoritesModel universityFavoritesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universityFavoritesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", universityFavoritesModel.PersonId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", universityFavoritesModel.UniversityId);
            return View(universityFavoritesModel);
        }

        // GET: UniversityFavoritesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniversityFavorites == null)
            {
                return NotFound();
            }

            var universityFavoritesModel = await _context.UniversityFavorites.FindAsync(id);
            if (universityFavoritesModel == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", universityFavoritesModel.PersonId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", universityFavoritesModel.UniversityId);
            return View(universityFavoritesModel);
        }

        // POST: UniversityFavoritesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniversityId,PersonId,Id")] UniversityFavoritesModel universityFavoritesModel)
        {
            if (id != universityFavoritesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universityFavoritesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityFavoritesModelExists(universityFavoritesModel.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", universityFavoritesModel.PersonId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", universityFavoritesModel.UniversityId);
            return View(universityFavoritesModel);
        }

        // GET: UniversityFavoritesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniversityFavorites == null)
            {
                return NotFound();
            }

            var universityFavoritesModel = await _context.UniversityFavorites
                .Include(u => u.PersonModel)
                .Include(u => u.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universityFavoritesModel == null)
            {
                return NotFound();
            }

            return View(universityFavoritesModel);
        }

        // POST: UniversityFavoritesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniversityFavorites == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.UniversityFavorites'  is null.");
            }
            var universityFavoritesModel = await _context.UniversityFavorites.FindAsync(id);
            if (universityFavoritesModel != null)
            {
                _context.UniversityFavorites.Remove(universityFavoritesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityFavoritesModelExists(int id)
        {
          return (_context.UniversityFavorites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
