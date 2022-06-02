using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authorization;

namespace EasyToEnter.ASP.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DisciplineController : ControllerBase
    {
        private readonly EasyToEnterDbContext _context;

        public DisciplineController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // GET: api/Discipline
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DisciplineModel>>> GetDiscipline()
        {
          if (_context.Discipline == null)
          {
              return NotFound();
          }
            return await _context.Discipline.ToListAsync();
        }

        // GET: api/Discipline/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DisciplineModel>> GetDisciplineModel(int id)
        {
          if (_context.Discipline == null)
          {
              return NotFound();
          }
            var disciplineModel = await _context.Discipline.FindAsync(id);

            if (disciplineModel == null)
            {
                return NotFound();
            }

            return disciplineModel;
        }

        // PUT: api/Discipline/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutDisciplineModel(int id, DisciplineModel disciplineModel)
        {
            if (id != disciplineModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(disciplineModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Discipline
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<DisciplineModel>> PostDisciplineModel(DisciplineModel disciplineModel)
        {
          if (_context.Discipline == null)
          {
              return Problem("Entity set 'EasyToEnterDbContext.Discipline'  is null.");
          }
            _context.Discipline.Add(disciplineModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisciplineModel", new { id = disciplineModel.Id }, disciplineModel);
        }

        // DELETE: api/Discipline/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteDisciplineModel(int id)
        {
            if (_context.Discipline == null)
            {
                return NotFound();
            }
            var disciplineModel = await _context.Discipline.FindAsync(id);
            if (disciplineModel == null)
            {
                return NotFound();
            }

            _context.Discipline.Remove(disciplineModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplineModelExists(int id)
        {
            return (_context.Discipline?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
