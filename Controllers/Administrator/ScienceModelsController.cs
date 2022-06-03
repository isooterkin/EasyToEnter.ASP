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

namespace EasyToEnter.ASP.Controllers.Administrator
{
    public class ScienceModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public ScienceModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: ScienceModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Science.ToListAsync());
        }

        // GET: ScienceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scienceModel = await _context.Science
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scienceModel == null)
            {
                return NotFound();
            }

            return View(scienceModel);
        }

        // GET: ScienceModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScienceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id")] ScienceModel scienceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scienceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scienceModel);
        }

        // GET: ScienceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scienceModel = await _context.Science.FindAsync(id);
            if (scienceModel == null)
            {
                return NotFound();
            }
            return View(scienceModel);
        }

        // POST: ScienceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Id")] ScienceModel scienceModel)
        {
            if (id != scienceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scienceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScienceModelExists(scienceModel.Id))
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
            return View(scienceModel);
        }

        // GET: ScienceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scienceModel = await _context.Science
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scienceModel == null)
            {
                return NotFound();
            }

            return View(scienceModel);
        }

        // POST: ScienceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scienceModel = await _context.Science.FindAsync(id);
            _context.Science.Remove(scienceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScienceModelExists(int id)
        {
            return _context.Science.Any(e => e.Id == id);
        }
    }
}
