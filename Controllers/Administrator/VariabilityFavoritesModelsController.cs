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
    public class VariabilityFavoritesModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public VariabilityFavoritesModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: VariabilityFavoritesModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.VariabilityFavorites.Include(v => v.PersonModel).Include(v => v.VariabilityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: VariabilityFavoritesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VariabilityFavorites == null)
            {
                return NotFound();
            }

            var variabilityFavoritesModel = await _context.VariabilityFavorites
                .Include(v => v.PersonModel)
                .Include(v => v.VariabilityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variabilityFavoritesModel == null)
            {
                return NotFound();
            }

            return View(variabilityFavoritesModel);
        }

        // GET: VariabilityFavoritesModels/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login");
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id");
            return View();
        }

        // POST: VariabilityFavoritesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VariabilityId,PersonId,Id")] VariabilityFavoritesModel variabilityFavoritesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variabilityFavoritesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", variabilityFavoritesModel.PersonId);
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id", variabilityFavoritesModel.VariabilityId);
            return View(variabilityFavoritesModel);
        }

        // GET: VariabilityFavoritesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VariabilityFavorites == null)
            {
                return NotFound();
            }

            var variabilityFavoritesModel = await _context.VariabilityFavorites.FindAsync(id);
            if (variabilityFavoritesModel == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", variabilityFavoritesModel.PersonId);
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id", variabilityFavoritesModel.VariabilityId);
            return View(variabilityFavoritesModel);
        }

        // POST: VariabilityFavoritesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VariabilityId,PersonId,Id")] VariabilityFavoritesModel variabilityFavoritesModel)
        {
            if (id != variabilityFavoritesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variabilityFavoritesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariabilityFavoritesModelExists(variabilityFavoritesModel.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", variabilityFavoritesModel.PersonId);
            ViewData["VariabilityId"] = new SelectList(_context.Variability, "Id", "Id", variabilityFavoritesModel.VariabilityId);
            return View(variabilityFavoritesModel);
        }

        // GET: VariabilityFavoritesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VariabilityFavorites == null)
            {
                return NotFound();
            }

            var variabilityFavoritesModel = await _context.VariabilityFavorites
                .Include(v => v.PersonModel)
                .Include(v => v.VariabilityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variabilityFavoritesModel == null)
            {
                return NotFound();
            }

            return View(variabilityFavoritesModel);
        }

        // POST: VariabilityFavoritesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VariabilityFavorites == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.VariabilityFavorites'  is null.");
            }
            var variabilityFavoritesModel = await _context.VariabilityFavorites.FindAsync(id);
            if (variabilityFavoritesModel != null)
            {
                _context.VariabilityFavorites.Remove(variabilityFavoritesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariabilityFavoritesModelExists(int id)
        {
          return (_context.VariabilityFavorites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
