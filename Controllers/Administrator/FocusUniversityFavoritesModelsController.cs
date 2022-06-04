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
    public class FocusUniversityFavoritesModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public FocusUniversityFavoritesModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: FocusUniversityFavoritesModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.FocusUniversityFavorites.Include(f => f.FocusUniversityModel).Include(f => f.PersonModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: FocusUniversityFavoritesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FocusUniversityFavorites == null)
            {
                return NotFound();
            }

            var focusUniversityFavoritesModel = await _context.FocusUniversityFavorites
                .Include(f => f.FocusUniversityModel)
                .Include(f => f.PersonModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (focusUniversityFavoritesModel == null)
            {
                return NotFound();
            }

            return View(focusUniversityFavoritesModel);
        }

        // GET: FocusUniversityFavoritesModels/Create
        public IActionResult Create()
        {
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login");
            return View();
        }

        // POST: FocusUniversityFavoritesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FocusUniversityId,PersonId,Id")] FocusUniversityFavoritesModel focusUniversityFavoritesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(focusUniversityFavoritesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", focusUniversityFavoritesModel.FocusUniversityId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", focusUniversityFavoritesModel.PersonId);
            return View(focusUniversityFavoritesModel);
        }

        // GET: FocusUniversityFavoritesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FocusUniversityFavorites == null)
            {
                return NotFound();
            }

            var focusUniversityFavoritesModel = await _context.FocusUniversityFavorites.FindAsync(id);
            if (focusUniversityFavoritesModel == null)
            {
                return NotFound();
            }
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", focusUniversityFavoritesModel.FocusUniversityId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", focusUniversityFavoritesModel.PersonId);
            return View(focusUniversityFavoritesModel);
        }

        // POST: FocusUniversityFavoritesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FocusUniversityId,PersonId,Id")] FocusUniversityFavoritesModel focusUniversityFavoritesModel)
        {
            if (id != focusUniversityFavoritesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(focusUniversityFavoritesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FocusUniversityFavoritesModelExists(focusUniversityFavoritesModel.Id))
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
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", focusUniversityFavoritesModel.FocusUniversityId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", focusUniversityFavoritesModel.PersonId);
            return View(focusUniversityFavoritesModel);
        }

        // GET: FocusUniversityFavoritesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FocusUniversityFavorites == null)
            {
                return NotFound();
            }

            var focusUniversityFavoritesModel = await _context.FocusUniversityFavorites
                .Include(f => f.FocusUniversityModel)
                .Include(f => f.PersonModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (focusUniversityFavoritesModel == null)
            {
                return NotFound();
            }

            return View(focusUniversityFavoritesModel);
        }

        // POST: FocusUniversityFavoritesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FocusUniversityFavorites == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.FocusUniversityFavorites'  is null.");
            }
            var focusUniversityFavoritesModel = await _context.FocusUniversityFavorites.FindAsync(id);
            if (focusUniversityFavoritesModel != null)
            {
                _context.FocusUniversityFavorites.Remove(focusUniversityFavoritesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FocusUniversityFavoritesModelExists(int id)
        {
          return (_context.FocusUniversityFavorites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
