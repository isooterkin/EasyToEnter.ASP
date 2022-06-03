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
    public class SubjectReplacementModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public SubjectReplacementModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: SubjectReplacementModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.SubjectReplacement.Include(s => s.SubjectFocusUniversityModel).Include(s => s.SubjectModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: SubjectReplacementModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubjectReplacement == null)
            {
                return NotFound();
            }

            var subjectReplacementModel = await _context.SubjectReplacement
                .Include(s => s.SubjectFocusUniversityModel)
                .Include(s => s.SubjectModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectReplacementModel == null)
            {
                return NotFound();
            }

            return View(subjectReplacementModel);
        }

        // GET: SubjectReplacementModels/Create
        public IActionResult Create()
        {
            ViewData["SubjectFocusUniversityId"] = new SelectList(_context.SubjectFocusUniversity, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");
            return View();
        }

        // POST: SubjectReplacementModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectFocusUniversityId,PassingGrade,Id")] SubjectReplacementModel subjectReplacementModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectReplacementModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectFocusUniversityId"] = new SelectList(_context.SubjectFocusUniversity, "Id", "Id", subjectReplacementModel.SubjectFocusUniversityId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", subjectReplacementModel.SubjectId);
            return View(subjectReplacementModel);
        }

        // GET: SubjectReplacementModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubjectReplacement == null)
            {
                return NotFound();
            }

            var subjectReplacementModel = await _context.SubjectReplacement.FindAsync(id);
            if (subjectReplacementModel == null)
            {
                return NotFound();
            }
            ViewData["SubjectFocusUniversityId"] = new SelectList(_context.SubjectFocusUniversity, "Id", "Id", subjectReplacementModel.SubjectFocusUniversityId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", subjectReplacementModel.SubjectId);
            return View(subjectReplacementModel);
        }

        // POST: SubjectReplacementModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectFocusUniversityId,PassingGrade,Id")] SubjectReplacementModel subjectReplacementModel)
        {
            if (id != subjectReplacementModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectReplacementModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectReplacementModelExists(subjectReplacementModel.Id))
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
            ViewData["SubjectFocusUniversityId"] = new SelectList(_context.SubjectFocusUniversity, "Id", "Id", subjectReplacementModel.SubjectFocusUniversityId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", subjectReplacementModel.SubjectId);
            return View(subjectReplacementModel);
        }

        // GET: SubjectReplacementModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubjectReplacement == null)
            {
                return NotFound();
            }

            var subjectReplacementModel = await _context.SubjectReplacement
                .Include(s => s.SubjectFocusUniversityModel)
                .Include(s => s.SubjectModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectReplacementModel == null)
            {
                return NotFound();
            }

            return View(subjectReplacementModel);
        }

        // POST: SubjectReplacementModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubjectReplacement == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.SubjectReplacement'  is null.");
            }
            var subjectReplacementModel = await _context.SubjectReplacement.FindAsync(id);
            if (subjectReplacementModel != null)
            {
                _context.SubjectReplacement.Remove(subjectReplacementModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectReplacementModelExists(int id)
        {
            return (_context.SubjectReplacement?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
