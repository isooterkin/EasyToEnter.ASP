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
    public class ProfessionFocusModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public ProfessionFocusModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: ProfessionFocusModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.ProfessionFocus.Include(p => p.FocusModel).Include(p => p.ProfessionModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: ProfessionFocusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfessionFocus == null)
            {
                return NotFound();
            }

            var professionFocusModel = await _context.ProfessionFocus
                .Include(p => p.FocusModel)
                .Include(p => p.ProfessionModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionFocusModel == null)
            {
                return NotFound();
            }

            return View(professionFocusModel);
        }

        // GET: ProfessionFocusModels/Create
        public IActionResult Create()
        {
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name");
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name");
            return View();
        }

        // POST: ProfessionFocusModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FocusId,ProfessionId,Id")] ProfessionFocusModel professionFocusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionFocusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", professionFocusModel.FocusId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", professionFocusModel.ProfessionId);
            return View(professionFocusModel);
        }

        // GET: ProfessionFocusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfessionFocus == null)
            {
                return NotFound();
            }

            var professionFocusModel = await _context.ProfessionFocus.FindAsync(id);
            if (professionFocusModel == null)
            {
                return NotFound();
            }
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", professionFocusModel.FocusId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", professionFocusModel.ProfessionId);
            return View(professionFocusModel);
        }

        // POST: ProfessionFocusModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FocusId,ProfessionId,Id")] ProfessionFocusModel professionFocusModel)
        {
            if (id != professionFocusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionFocusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionFocusModelExists(professionFocusModel.Id))
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
            ViewData["FocusId"] = new SelectList(_context.Focus, "Id", "Name", professionFocusModel.FocusId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", professionFocusModel.ProfessionId);
            return View(professionFocusModel);
        }

        // GET: ProfessionFocusModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfessionFocus == null)
            {
                return NotFound();
            }

            var professionFocusModel = await _context.ProfessionFocus
                .Include(p => p.FocusModel)
                .Include(p => p.ProfessionModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionFocusModel == null)
            {
                return NotFound();
            }

            return View(professionFocusModel);
        }

        // POST: ProfessionFocusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfessionFocus == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.ProfessionFocus'  is null.");
            }
            var professionFocusModel = await _context.ProfessionFocus.FindAsync(id);
            if (professionFocusModel != null)
            {
                _context.ProfessionFocus.Remove(professionFocusModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionFocusModelExists(int id)
        {
            return (_context.ProfessionFocus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
