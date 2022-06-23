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
    public class AccreditationModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public AccreditationModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: AccreditationModels
        public async Task<IActionResult> Index()
        {
              return _context.Accreditation != null ? 
                          View(await _context.Accreditation.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Accreditation'  is null.");
        }

        // GET: AccreditationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accreditation == null)
            {
                return NotFound();
            }

            var accreditationModel = await _context.Accreditation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accreditationModel == null)
            {
                return NotFound();
            }

            return View(accreditationModel);
        }

        // GET: AccreditationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccreditationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] AccreditationModel accreditationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accreditationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accreditationModel);
        }

        // GET: AccreditationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accreditation == null)
            {
                return NotFound();
            }

            var accreditationModel = await _context.Accreditation.FindAsync(id);
            if (accreditationModel == null)
            {
                return NotFound();
            }
            return View(accreditationModel);
        }

        // POST: AccreditationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] AccreditationModel accreditationModel)
        {
            if (id != accreditationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accreditationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccreditationModelExists(accreditationModel.Id))
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
            return View(accreditationModel);
        }

        // GET: AccreditationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accreditation == null)
            {
                return NotFound();
            }

            var accreditationModel = await _context.Accreditation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accreditationModel == null)
            {
                return NotFound();
            }

            return View(accreditationModel);
        }

        // POST: AccreditationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accreditation == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Accreditation'  is null.");
            }
            var accreditationModel = await _context.Accreditation.FindAsync(id);
            if (accreditationModel != null)
            {
                _context.Accreditation.Remove(accreditationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccreditationModelExists(int id)
        {
          return (_context.Accreditation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
