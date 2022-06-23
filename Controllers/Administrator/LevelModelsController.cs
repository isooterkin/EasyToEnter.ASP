#nullable disable
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
    public class LevelModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public LevelModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: LevelModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Level.ToListAsync());
        }

        // GET: LevelModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelModel = await _context.Level
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelModel == null)
            {
                return NotFound();
            }

            return View(levelModel);
        }

        // GET: LevelModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LevelModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Description,Id")] LevelModel levelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(levelModel);
        }

        // GET: LevelModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelModel = await _context.Level.FindAsync(id);
            if (levelModel == null)
            {
                return NotFound();
            }
            return View(levelModel);
        }

        // POST: LevelModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Name,Description,Id")] LevelModel levelModel)
        {
            if (id != levelModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelModelExists(levelModel.Id))
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
            return View(levelModel);
        }

        // GET: LevelModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelModel = await _context.Level
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levelModel == null)
            {
                return NotFound();
            }

            return View(levelModel);
        }

        // POST: LevelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var levelModel = await _context.Level.FindAsync(id);
            _context.Level.Remove(levelModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelModelExists(int id)
        {
            return _context.Level.Any(e => e.Id == id);
        }
    }
}
