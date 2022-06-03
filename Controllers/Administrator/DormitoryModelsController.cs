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
    public class DormitoryModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public DormitoryModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: DormitoryModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Dormitory.Include(d => d.AddressModel).Include(d => d.UniversityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: DormitoryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dormitory == null)
            {
                return NotFound();
            }

            var dormitoryModel = await _context.Dormitory
                .Include(d => d.AddressModel)
                .Include(d => d.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dormitoryModel == null)
            {
                return NotFound();
            }

            return View(dormitoryModel);
        }

        // GET: DormitoryModels/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "House");
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation");
            return View();
        }

        // POST: DormitoryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,UniversityId,PhoneNumber,Amount,Name,Id")] DormitoryModel dormitoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dormitoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "House", dormitoryModel.AddressId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", dormitoryModel.UniversityId);
            return View(dormitoryModel);
        }

        // GET: DormitoryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dormitory == null)
            {
                return NotFound();
            }

            var dormitoryModel = await _context.Dormitory.FindAsync(id);
            if (dormitoryModel == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "House", dormitoryModel.AddressId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", dormitoryModel.UniversityId);
            return View(dormitoryModel);
        }

        // POST: DormitoryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,UniversityId,PhoneNumber,Amount,Name,Id")] DormitoryModel dormitoryModel)
        {
            if (id != dormitoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dormitoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DormitoryModelExists(dormitoryModel.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "House", dormitoryModel.AddressId);
            ViewData["UniversityId"] = new SelectList(_context.University, "Id", "Abbreviation", dormitoryModel.UniversityId);
            return View(dormitoryModel);
        }

        // GET: DormitoryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dormitory == null)
            {
                return NotFound();
            }

            var dormitoryModel = await _context.Dormitory
                .Include(d => d.AddressModel)
                .Include(d => d.UniversityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dormitoryModel == null)
            {
                return NotFound();
            }

            return View(dormitoryModel);
        }

        // POST: DormitoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dormitory == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Dormitory'  is null.");
            }
            var dormitoryModel = await _context.Dormitory.FindAsync(id);
            if (dormitoryModel != null)
            {
                _context.Dormitory.Remove(dormitoryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DormitoryModelExists(int id)
        {
            return (_context.Dormitory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
