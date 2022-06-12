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
    public class FormatModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public FormatModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: FormatModels
        public async Task<IActionResult> Index()
        {
              return _context.Format != null ? 
                          View(await _context.Format.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Format'  is null.");
        }

        // GET: FormatModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Format == null)
            {
                return NotFound();
            }

            var formatModel = await _context.Format
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formatModel == null)
            {
                return NotFound();
            }

            return View(formatModel);
        }

        // GET: FormatModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormatModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] FormatModel formatModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formatModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formatModel);
        }

        // GET: FormatModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Format == null)
            {
                return NotFound();
            }

            var formatModel = await _context.Format.FindAsync(id);
            if (formatModel == null)
            {
                return NotFound();
            }
            return View(formatModel);
        }

        // POST: FormatModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] FormatModel formatModel)
        {
            if (id != formatModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formatModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormatModelExists(formatModel.Id))
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
            return View(formatModel);
        }

        // GET: FormatModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Format == null)
            {
                return NotFound();
            }

            var formatModel = await _context.Format
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formatModel == null)
            {
                return NotFound();
            }

            return View(formatModel);
        }

        // POST: FormatModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Format == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Format'  is null.");
            }
            var formatModel = await _context.Format.FindAsync(id);
            if (formatModel != null)
            {
                _context.Format.Remove(formatModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormatModelExists(int id)
        {
          return (_context.Format?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
