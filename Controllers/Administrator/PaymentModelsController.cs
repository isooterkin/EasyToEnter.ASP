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
    public class PaymentModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public PaymentModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: PaymentModels
        public async Task<IActionResult> Index()
        {
              return _context.Payment != null ? 
                          View(await _context.Payment.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Payment'  is null.");
        }

        // GET: PaymentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var paymentModel = await _context.Payment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentModel == null)
            {
                return NotFound();
            }

            return View(paymentModel);
        }

        // GET: PaymentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentModel);
        }

        // GET: PaymentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var paymentModel = await _context.Payment.FindAsync(id);
            if (paymentModel == null)
            {
                return NotFound();
            }
            return View(paymentModel);
        }

        // POST: PaymentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] PaymentModel paymentModel)
        {
            if (id != paymentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentModelExists(paymentModel.Id))
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
            return View(paymentModel);
        }

        // GET: PaymentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var paymentModel = await _context.Payment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentModel == null)
            {
                return NotFound();
            }

            return View(paymentModel);
        }

        // POST: PaymentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Payment == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Payment'  is null.");
            }
            var paymentModel = await _context.Payment.FindAsync(id);
            if (paymentModel != null)
            {
                _context.Payment.Remove(paymentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentModelExists(int id)
        {
          return (_context.Payment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
