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
    public class EmployerOrganizationModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public EmployerOrganizationModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: EmployerOrganizationModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.EmployerOrganization.Include(e => e.OrganizationModel).Include(e => e.PersonModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: EmployerOrganizationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployerOrganization == null)
            {
                return NotFound();
            }

            var employerOrganizationModel = await _context.EmployerOrganization
                .Include(e => e.OrganizationModel)
                .Include(e => e.PersonModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employerOrganizationModel == null)
            {
                return NotFound();
            }

            return View(employerOrganizationModel);
        }

        // GET: EmployerOrganizationModels/Create
        public IActionResult Create()
        {
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login");
            return View();
        }

        // POST: EmployerOrganizationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizationId,PersonId,Id")] EmployerOrganizationModel employerOrganizationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employerOrganizationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress", employerOrganizationModel.OrganizationId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", employerOrganizationModel.PersonId);
            return View(employerOrganizationModel);
        }

        // GET: EmployerOrganizationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployerOrganization == null)
            {
                return NotFound();
            }

            var employerOrganizationModel = await _context.EmployerOrganization.FindAsync(id);
            if (employerOrganizationModel == null)
            {
                return NotFound();
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress", employerOrganizationModel.OrganizationId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", employerOrganizationModel.PersonId);
            return View(employerOrganizationModel);
        }

        // POST: EmployerOrganizationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizationId,PersonId,Id")] EmployerOrganizationModel employerOrganizationModel)
        {
            if (id != employerOrganizationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employerOrganizationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployerOrganizationModelExists(employerOrganizationModel.Id))
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
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "Id", "EmailAddress", employerOrganizationModel.OrganizationId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Login", employerOrganizationModel.PersonId);
            return View(employerOrganizationModel);
        }

        // GET: EmployerOrganizationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployerOrganization == null)
            {
                return NotFound();
            }

            var employerOrganizationModel = await _context.EmployerOrganization
                .Include(e => e.OrganizationModel)
                .Include(e => e.PersonModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employerOrganizationModel == null)
            {
                return NotFound();
            }

            return View(employerOrganizationModel);
        }

        // POST: EmployerOrganizationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployerOrganization == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.EmployerOrganization'  is null.");
            }
            var employerOrganizationModel = await _context.EmployerOrganization.FindAsync(id);
            if (employerOrganizationModel != null)
            {
                _context.EmployerOrganization.Remove(employerOrganizationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployerOrganizationModelExists(int id)
        {
          return (_context.EmployerOrganization?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
