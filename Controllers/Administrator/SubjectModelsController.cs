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
    public class SubjectModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public SubjectModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: SubjectModels
        public async Task<IActionResult> Index()
        {
              return _context.Subject != null ? 
                          View(await _context.Subject.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Subject'  is null.");
        }

        // GET: SubjectModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.Subject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // GET: SubjectModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectModel);
        }

        // GET: SubjectModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.Subject.FindAsync(id);
            if (subjectModel == null)
            {
                return NotFound();
            }
            return View(subjectModel);
        }

        // POST: SubjectModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] SubjectModel subjectModel)
        {
            if (id != subjectModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectModelExists(subjectModel.Id))
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
            return View(subjectModel);
        }

        // GET: SubjectModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.Subject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // POST: SubjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subject == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Subject'  is null.");
            }
            var subjectModel = await _context.Subject.FindAsync(id);
            if (subjectModel != null)
            {
                _context.Subject.Remove(subjectModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectModelExists(int id)
        {
          return (_context.Subject?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
