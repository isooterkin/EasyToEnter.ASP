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
    public class AddressModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public AddressModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: AddressModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Address.Include(a => a.CityModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: AddressModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var addressModel = await _context.Address
                .Include(a => a.CityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressModel == null)
            {
                return NotFound();
            }

            return View(addressModel);
        }

        // GET: AddressModels/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            return View();
        }

        // POST: AddressModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,Street,House,Housing,Building,Latitude,Longitude,Id")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", addressModel.CityId);
            return View(addressModel);
        }

        // GET: AddressModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var addressModel = await _context.Address.FindAsync(id);
            if (addressModel == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", addressModel.CityId);
            return View(addressModel);
        }

        // POST: AddressModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,Street,House,Housing,Building,Latitude,Longitude,Id")] AddressModel addressModel)
        {
            if (id != addressModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressModelExists(addressModel.Id))
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
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", addressModel.CityId);
            return View(addressModel);
        }

        // GET: AddressModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Address == null)
            {
                return NotFound();
            }

            var addressModel = await _context.Address
                .Include(a => a.CityModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressModel == null)
            {
                return NotFound();
            }

            return View(addressModel);
        }

        // POST: AddressModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Address'  is null.");
            }
            var addressModel = await _context.Address.FindAsync(id);
            if (addressModel != null)
            {
                _context.Address.Remove(addressModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressModelExists(int id)
        {
          return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
