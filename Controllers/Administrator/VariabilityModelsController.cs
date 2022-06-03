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
    public class VariabilityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public VariabilityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: VariabilityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Variability.Include(v => v.FocusUniversityModel).Include(v => v.FormModel).Include(v => v.FormatModel).Include(v => v.PaymentModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: VariabilityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Variability == null)
            {
                return NotFound();
            }

            var variabilityModel = await _context.Variability
                .Include(v => v.FocusUniversityModel)
                .Include(v => v.FormModel)
                .Include(v => v.FormatModel)
                .Include(v => v.PaymentModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variabilityModel == null)
            {
                return NotFound();
            }

            return View(variabilityModel);
        }

        // GET: VariabilityModels/Create
        public IActionResult Create()
        {
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id");
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Name");
            ViewData["FormatId"] = new SelectList(_context.Format, "Id", "Name");
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Name");
            return View();
        }

        // POST: VariabilityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntranceExams,FormId,PaymentId,FormatId,FocusUniversityId,Id")] VariabilityModel variabilityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variabilityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", variabilityModel.FocusUniversityId);
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Name", variabilityModel.FormId);
            ViewData["FormatId"] = new SelectList(_context.Format, "Id", "Name", variabilityModel.FormatId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Name", variabilityModel.PaymentId);
            return View(variabilityModel);
        }

        // GET: VariabilityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Variability == null)
            {
                return NotFound();
            }

            var variabilityModel = await _context.Variability.FindAsync(id);
            if (variabilityModel == null)
            {
                return NotFound();
            }
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", variabilityModel.FocusUniversityId);
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Name", variabilityModel.FormId);
            ViewData["FormatId"] = new SelectList(_context.Format, "Id", "Name", variabilityModel.FormatId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Name", variabilityModel.PaymentId);
            return View(variabilityModel);
        }

        // POST: VariabilityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntranceExams,FormId,PaymentId,FormatId,FocusUniversityId,Id")] VariabilityModel variabilityModel)
        {
            if (id != variabilityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variabilityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariabilityModelExists(variabilityModel.Id))
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
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", variabilityModel.FocusUniversityId);
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Name", variabilityModel.FormId);
            ViewData["FormatId"] = new SelectList(_context.Format, "Id", "Name", variabilityModel.FormatId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "Id", "Name", variabilityModel.PaymentId);
            return View(variabilityModel);
        }

        // GET: VariabilityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Variability == null)
            {
                return NotFound();
            }

            var variabilityModel = await _context.Variability
                .Include(v => v.FocusUniversityModel)
                .Include(v => v.FormModel)
                .Include(v => v.FormatModel)
                .Include(v => v.PaymentModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variabilityModel == null)
            {
                return NotFound();
            }

            return View(variabilityModel);
        }

        // POST: VariabilityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Variability == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Variability'  is null.");
            }
            var variabilityModel = await _context.Variability.FindAsync(id);
            if (variabilityModel != null)
            {
                _context.Variability.Remove(variabilityModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariabilityModelExists(int id)
        {
            return (_context.Variability?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
