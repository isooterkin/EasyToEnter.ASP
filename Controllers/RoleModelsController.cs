using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Controllers
{
    public class RoleModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public RoleModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: RoleModels
        public async Task<IActionResult> Index()
        {
              return _context.Role != null ? 
                          View(await _context.Role.ToListAsync()) :
                          Problem("Entity set 'EasyToEnterDbContext.Role'  is null.");
        }

        // GET: RoleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var roleModel = await _context.Role
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            return View(roleModel);
        }

        // GET: RoleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name,Id")] RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleModel);
        }

        // GET: RoleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var roleModel = await _context.Role.FindAsync(id);
            if (roleModel == null)
            {
                return NotFound();
            }
            return View(roleModel);
        }

        // POST: RoleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Name,Id")] RoleModel roleModel)
        {
            if (id != roleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleModelExists(roleModel.Id))
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
            return View(roleModel);
        }

        // GET: RoleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var roleModel = await _context.Role
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleModel == null)
            {
                return NotFound();
            }

            return View(roleModel);
        }

        // POST: RoleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Role == null)
            {
                return Problem("Entity set 'EasyToEnterDbContext.Role'  is null.");
            }
            var roleModel = await _context.Role.FindAsync(id);
            if (roleModel != null)
            {
                _context.Role.Remove(roleModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleModelExists(int id)
        {
          return (_context.Role?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
