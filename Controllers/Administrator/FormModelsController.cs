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
    public class FormModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public FormModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: FormModels
        public async Task<IActionResult> Index()
        {
              return _context.Form != null ? 
                          View(await _context.Form.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Form'  is null.");
        }

        // GET: FormModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Form == null)
            {
                return NotFound();
            }

            var formModel = await _context.Form
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formModel == null)
            {
                return NotFound();
            }

            return View(formModel);
        }

        // GET: FormModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] FormModel formModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formModel);
        }

        // GET: FormModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Form == null)
            {
                return NotFound();
            }

            var formModel = await _context.Form.FindAsync(id);
            if (formModel == null)
            {
                return NotFound();
            }
            return View(formModel);
        }

        // POST: FormModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] FormModel formModel)
        {
            if (id != formModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormModelExists(formModel.Id))
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
            return View(formModel);
        }

        // GET: FormModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Form == null)
            {
                return NotFound();
            }

            var formModel = await _context.Form
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formModel == null)
            {
                return NotFound();
            }

            return View(formModel);
        }

        // POST: FormModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Form == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Form'  is null.");
            }
            var formModel = await _context.Form.FindAsync(id);
            if (formModel != null)
            {
                _context.Form.Remove(formModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormModelExists(int id)
        {
          return (_context.Form?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
