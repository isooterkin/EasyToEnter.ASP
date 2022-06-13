using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Controllers.EmployeeOrganization
{
    public class OrganizationModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public OrganizationModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: OrganizationModels
        public async Task<IActionResult> Index()
        {
              return _context.Organization != null ? 
                          View(await _context.Organization.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Organization'  is null.");
        }

        // GET: OrganizationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }

            var organizationModel = await _context.Organization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationModel == null)
            {
                return NotFound();
            }

            return View(organizationModel);
        }

        // GET: OrganizationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhoneNumber,EmailAddress,Description,Name,Id")] OrganizationModel organizationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizationModel);
        }

        // GET: OrganizationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }

            var organizationModel = await _context.Organization.FindAsync(id);
            if (organizationModel == null)
            {
                return NotFound();
            }
            return View(organizationModel);
        }

        // POST: OrganizationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhoneNumber,EmailAddress,Description,Name,Id")] OrganizationModel organizationModel)
        {
            if (id != organizationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationModelExists(organizationModel.Id))
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
            return View(organizationModel);
        }

        // GET: OrganizationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }

            var organizationModel = await _context.Organization
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationModel == null)
            {
                return NotFound();
            }

            return View(organizationModel);
        }

        // POST: OrganizationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Organization == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Organization'  is null.");
            }
            var organizationModel = await _context.Organization.FindAsync(id);
            if (organizationModel != null)
            {
                _context.Organization.Remove(organizationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationModelExists(int id)
        {
          return (_context.Organization?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
