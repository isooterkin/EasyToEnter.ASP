using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Controllers
{
    public class PhoneNumberUniversityModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public PhoneNumberUniversityModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: PhoneNumberUniversityModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.PhoneNumberUniversity.Include(p => p.UniversityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: PhoneNumberUniversityModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhoneNumberUniversity == null)
            {
                return NotFound();
            }

            var phoneNumberUniversityModel = await _context.PhoneNumberUniversity
                .Include(p => p.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneNumberUniversityModel == null)
            {
                return NotFound();
            }

            return View(phoneNumberUniversityModel);
        }

        // GET: PhoneNumberUniversityModels/Create
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation");
            return View();
        }

        // POST: PhoneNumberUniversityModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversityId,PhoneNumber,Appointment,Id")] PhoneNumberUniversityModel phoneNumberUniversityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneNumberUniversityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", phoneNumberUniversityModel.UniversityId);
            return View(phoneNumberUniversityModel);
        }

        // GET: PhoneNumberUniversityModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhoneNumberUniversity == null)
            {
                return NotFound();
            }

            var phoneNumberUniversityModel = await _context.PhoneNumberUniversity.FindAsync(id);
            if (phoneNumberUniversityModel == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", phoneNumberUniversityModel.UniversityId);
            return View(phoneNumberUniversityModel);
        }

        // POST: PhoneNumberUniversityModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniversityId,PhoneNumber,Appointment,Id")] PhoneNumberUniversityModel phoneNumberUniversityModel)
        {
            if (id != phoneNumberUniversityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneNumberUniversityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneNumberUniversityModelExists(phoneNumberUniversityModel.Id))
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
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", phoneNumberUniversityModel.UniversityId);
            return View(phoneNumberUniversityModel);
        }

        // GET: PhoneNumberUniversityModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhoneNumberUniversity == null)
            {
                return NotFound();
            }

            var phoneNumberUniversityModel = await _context.PhoneNumberUniversity
                .Include(p => p.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneNumberUniversityModel == null)
            {
                return NotFound();
            }

            return View(phoneNumberUniversityModel);
        }

        // POST: PhoneNumberUniversityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhoneNumberUniversity == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.PhoneNumberUniversity'  is null.");
            }
            var phoneNumberUniversityModel = await _context.PhoneNumberUniversity.FindAsync(id);
            if (phoneNumberUniversityModel != null)
            {
                _context.PhoneNumberUniversity.Remove(phoneNumberUniversityModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneNumberUniversityModelExists(int id)
        {
          return (_context.PhoneNumberUniversity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
