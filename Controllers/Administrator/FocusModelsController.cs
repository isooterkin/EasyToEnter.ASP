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
    public class FocusModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public FocusModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: FocusModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Focus.Include(f => f.DirectionModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: FocusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var focusModel = await _context.Focus
                .Include(f => f.DirectionModel)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (focusModel == null)
            {
                return NotFound();
            }

            return View(focusModel);
        }

        // GET: FocusModels/Create
        public IActionResult Create()
        {
            ViewData["DirectionId"] = new SelectList(_context.Direction, "Id", "Name");
            return View();
        }

        // POST: FocusModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectionId,Name,Description,Id")] FocusModel focusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(focusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectionId"] = new SelectList(_context.Direction, "Id", "Name", focusModel.DirectionId);
            return View(focusModel);
        }

        // GET: FocusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var focusModel = await _context.Focus.FindAsync(id);
            if (focusModel == null)
            {
                return NotFound();
            }
            ViewData["DirectionId"] = new SelectList(_context.Direction, "Id", "Name", focusModel.DirectionId);
            return View(focusModel);
        }

        // POST: FocusModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectionId,Name,Description,Id")] FocusModel focusModel)
        {
            if (id != focusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(focusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FocusModelExists(focusModel.Id))
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
            ViewData["DirectionId"] = new SelectList(_context.Direction, "Id", "Name", focusModel.DirectionId);
            return View(focusModel);
        }

        // GET: FocusModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var focusModel = await _context.Focus
                .Include(f => f.DirectionModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (focusModel == null)
            {
                return NotFound();
            }

            return View(focusModel);
        }

        // POST: FocusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var focusModel = await _context.Focus.FindAsync(id);
            _context.Focus.Remove(focusModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FocusModelExists(int id)
        {
            return _context.Focus.Any(e => e.Id == id);
        }
    }
}
