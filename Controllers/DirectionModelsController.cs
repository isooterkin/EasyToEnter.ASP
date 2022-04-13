#nullable disable
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
    public class DirectionModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public DirectionModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: DirectionModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Direction.Include(d => d.GroupModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: DirectionModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directionModel = await _context.Direction
                .Include(d => d.GroupModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directionModel == null)
            {
                return NotFound();
            }

            return View(directionModel);
        }

        // GET: DirectionModels/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Name");
            return View();
        }

        // POST: DirectionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,Code,Name,Description,Id")] DirectionModel directionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Name", directionModel.GroupId);
            return View(directionModel);
        }

        // GET: DirectionModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directionModel = await _context.Direction.FindAsync(id);
            if (directionModel == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Name", directionModel.GroupId);
            return View(directionModel);
        }

        // POST: DirectionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,Code,Name,Description,Id")] DirectionModel directionModel)
        {
            if (id != directionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectionModelExists(directionModel.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Name", directionModel.GroupId);
            return View(directionModel);
        }

        // GET: DirectionModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directionModel = await _context.Direction
                .Include(d => d.GroupModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directionModel == null)
            {
                return NotFound();
            }

            return View(directionModel);
        }

        // POST: DirectionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directionModel = await _context.Direction.FindAsync(id);
            _context.Direction.Remove(directionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectionModelExists(int id)
        {
            return _context.Direction.Any(e => e.Id == id);
        }
    }
}
