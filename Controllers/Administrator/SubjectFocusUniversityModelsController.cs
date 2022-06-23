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
    public class SubjectFocusUniversityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public SubjectFocusUniversityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: SubjectFocusUniversityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.SubjectFocusUniversity.Include(s => s.FocusUniversityModel).Include(s => s.SubjectModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: SubjectFocusUniversityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubjectFocusUniversity == null)
            {
                return NotFound();
            }

            var subjectFocusUniversityModel = await _context.SubjectFocusUniversity
                .Include(s => s.FocusUniversityModel)
                .Include(s => s.SubjectModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectFocusUniversityModel == null)
            {
                return NotFound();
            }

            return View(subjectFocusUniversityModel);
        }

        // GET: SubjectFocusUniversityModels/Create
        public IActionResult Create()
        {
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");
            return View();
        }

        // POST: SubjectFocusUniversityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,FocusUniversityId,PassingGrade,Id")] SubjectFocusUniversityModel subjectFocusUniversityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectFocusUniversityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", subjectFocusUniversityModel.FocusUniversityId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", subjectFocusUniversityModel.SubjectId);
            return View(subjectFocusUniversityModel);
        }

        // GET: SubjectFocusUniversityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubjectFocusUniversity == null)
            {
                return NotFound();
            }

            var subjectFocusUniversityModel = await _context.SubjectFocusUniversity.FindAsync(id);
            if (subjectFocusUniversityModel == null)
            {
                return NotFound();
            }
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", subjectFocusUniversityModel.FocusUniversityId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", subjectFocusUniversityModel.SubjectId);
            return View(subjectFocusUniversityModel);
        }

        // POST: SubjectFocusUniversityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,FocusUniversityId,PassingGrade,Id")] SubjectFocusUniversityModel subjectFocusUniversityModel)
        {
            if (id != subjectFocusUniversityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectFocusUniversityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectFocusUniversityModelExists(subjectFocusUniversityModel.Id))
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
            ViewData["FocusUniversityId"] = new SelectList(_context.FocusUniversity, "Id", "Id", subjectFocusUniversityModel.FocusUniversityId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", subjectFocusUniversityModel.SubjectId);
            return View(subjectFocusUniversityModel);
        }

        // GET: SubjectFocusUniversityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubjectFocusUniversity == null)
            {
                return NotFound();
            }

            var subjectFocusUniversityModel = await _context.SubjectFocusUniversity
                .Include(s => s.FocusUniversityModel)
                .Include(s => s.SubjectModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectFocusUniversityModel == null)
            {
                return NotFound();
            }

            return View(subjectFocusUniversityModel);
        }

        // POST: SubjectFocusUniversityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubjectFocusUniversity == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.SubjectFocusUniversity'  is null.");
            }
            var subjectFocusUniversityModel = await _context.SubjectFocusUniversity.FindAsync(id);
            if (subjectFocusUniversityModel != null)
            {
                _context.SubjectFocusUniversity.Remove(subjectFocusUniversityModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectFocusUniversityModelExists(int id)
        {
            return (_context.SubjectFocusUniversity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
