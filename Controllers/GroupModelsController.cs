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
    public class GroupModelsController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public GroupModelsController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: GroupModels
        public async Task<IActionResult> Index()
        {
            var easyToEnterDbContext = _context.Group.Include(g => g.ScienceModel);
            return View(await easyToEnterDbContext.ToListAsync());
        }

        // GET: GroupModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var groupModel = await _context.Group
                .Include(g => g.ScienceModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupModel == null)
            {
                return NotFound();
            }

            return View(groupModel);
        }

        // GET: GroupModels/Create
        public IActionResult Create()
        {
            ViewData["ScienceId"] = new SelectList(_context.Science, "Id", "Name");
            return View();
        }

        // POST: GroupModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScienceId,Code,Name,Description,Id")] GroupModel groupModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScienceId"] = new SelectList(_context.Science, "Id", "Name", groupModel.ScienceId);
            return View(groupModel);
        }

        // GET: GroupModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupModel = await _context.Group.FindAsync(id);
            if (groupModel == null)
            {
                return NotFound();
            }
            ViewData["ScienceId"] = new SelectList(_context.Science, "Id", "Name", groupModel.ScienceId);
            return View(groupModel);
        }

        // POST: GroupModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScienceId,Code,Name,Description,Id")] GroupModel groupModel)
        {
            if (id != groupModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupModelExists(groupModel.Id))
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
            ViewData["ScienceId"] = new SelectList(_context.Science, "Id", "Name", groupModel.ScienceId);
            return View(groupModel);
        }

        // GET: GroupModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupModel = await _context.Group
                .Include(g => g.ScienceModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupModel == null)
            {
                return NotFound();
            }

            return View(groupModel);
        }

        // POST: GroupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupModel = await _context.Group.FindAsync(id);
            _context.Group.Remove(groupModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupModelExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }
    }
}
