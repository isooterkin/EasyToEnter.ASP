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
    public class SessionModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public SessionModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: SessionModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Session.Include(s => s.PersonModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: SessionModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Session == null)
            {
                return NotFound();
            }

            var sessionModel = await _context.Session
                .Include(s => s.PersonModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessionModel == null)
            {
                return NotFound();
            }

            return View(sessionModel);
        }

        // GET: SessionModels/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login");
            return View();
        }

        // POST: SessionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LifeSpan,PersonId")] SessionModel sessionModel)
        {
            if (ModelState.IsValid)
            {
                sessionModel.Id = Guid.NewGuid();
                _context.Add(sessionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", sessionModel.PersonId);
            return View(sessionModel);
        }

        // GET: SessionModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Session == null)
            {
                return NotFound();
            }

            var sessionModel = await _context.Session.FindAsync(id);
            if (sessionModel == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", sessionModel.PersonId);
            return View(sessionModel);
        }

        // POST: SessionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,LifeSpan,PersonId")] SessionModel sessionModel)
        {
            if (id != sessionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionModelExists(sessionModel.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", sessionModel.PersonId);
            return View(sessionModel);
        }

        // GET: SessionModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Session == null)
            {
                return NotFound();
            }

            var sessionModel = await _context.Session
                .Include(s => s.PersonModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessionModel == null)
            {
                return NotFound();
            }

            return View(sessionModel);
        }

        // POST: SessionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Session == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Session'  is null.");
            }
            var sessionModel = await _context.Session.FindAsync(id);
            if (sessionModel != null)
            {
                _context.Session.Remove(sessionModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionModelExists(Guid id)
        {
          return (_context.Session?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
