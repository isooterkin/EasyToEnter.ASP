using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization.Attributes;

namespace EasyToEnter.ASP.Controllers.Administrator
{
    [AdministratorRole]
    public class TypeProfessionModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public TypeProfessionModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: TypeProfessionModels
        public async Task<IActionResult> Index()
        {
              return _context.TypeProfession != null ? 
                          View(await _context.TypeProfession.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.TypeProfession'  is null.");
        }

        // GET: TypeProfessionModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeProfession == null)
            {
                return NotFound();
            }

            var typeProfessionModel = await _context.TypeProfession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeProfessionModel == null)
            {
                return NotFound();
            }

            return View(typeProfessionModel);
        }

        // GET: TypeProfessionModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProfessionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] TypeProfessionModel typeProfessionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeProfessionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeProfessionModel);
        }

        // GET: TypeProfessionModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeProfession == null)
            {
                return NotFound();
            }

            var typeProfessionModel = await _context.TypeProfession.FindAsync(id);
            if (typeProfessionModel == null)
            {
                return NotFound();
            }
            return View(typeProfessionModel);
        }

        // POST: TypeProfessionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] TypeProfessionModel typeProfessionModel)
        {
            if (id != typeProfessionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeProfessionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeProfessionModelExists(typeProfessionModel.Id))
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
            return View(typeProfessionModel);
        }

        // GET: TypeProfessionModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeProfession == null)
            {
                return NotFound();
            }

            var typeProfessionModel = await _context.TypeProfession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeProfessionModel == null)
            {
                return NotFound();
            }

            return View(typeProfessionModel);
        }

        // POST: TypeProfessionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeProfession == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.TypeProfession'  is null.");
            }
            var typeProfessionModel = await _context.TypeProfession.FindAsync(id);
            if (typeProfessionModel != null)
            {
                _context.TypeProfession.Remove(typeProfessionModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeProfessionModelExists(int id)
        {
          return (_context.TypeProfession?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
