using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.EmployeeOrganization
{
    [EmployerOrganizationRole]
    public class EmployeeOrganizationController : Controller
    {
        private readonly EasyToEnterDbContext _context;
        public EmployeeOrganizationController(EasyToEnterDbContext context) => _context = context;



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<VacancyModel> vacancyList = await _context.EmployerOrganization
                .Where(eo => eo.PersonId == User.Id())
                .Include(eo => eo.OrganizationModel!.Vacancys!)
                .SelectMany(eo => eo.OrganizationModel!.Vacancys!)
                .ToListAsync();

            return View(vacancyList);
        }



        [HttpGet]
        public async Task<IActionResult> EditVacancyAsync(int? vacancyId)
        {
            if (vacancyId == null || _context.Vacancy == null) return NotFound();

            VacancyModel? vacancy = await _context.EmployerOrganization
                .Where(eo => eo.PersonId == User.Id())
                .Include(eo => eo.OrganizationModel!.Vacancys!)
                .SelectMany(eo => eo.OrganizationModel!.Vacancys!)
                .SingleOrDefaultAsync(v => v.Id == vacancyId);

            if (vacancy == null) return RedirectToAction("AccessDenied", "Authentication");

            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", vacancy.ProfessionId);

            return View(vacancy);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVacancyAsync(int id, [Bind("Id,Name,Description,ProfessionId,Wages")] VacancyModel vacancy)
        {
            if (id != vacancy.Id) return NotFound();

            OrganizationModel organization = (await _context.EmployerOrganization
                .Where(eo => eo.PersonId == User.Id())
                .Include(eo => eo.OrganizationModel)
                .SingleAsync()).OrganizationModel!;

            vacancy.OrganizationId = organization.Id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyModelExists(vacancy.Id)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", vacancy.ProfessionId);

            return View(vacancy);
        }



        [HttpGet]
        [Authorized]
        public IActionResult NewVacancyAsync()
        {
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name");
            
            return View(); 
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewVacancyAsync([Bind("Name,Description,ProfessionId,Wages")] VacancyModel vacancyModel)
        {
            OrganizationModel organization = (await _context.EmployerOrganization
                .Where(eo => eo.PersonId == User.Id())
                .Include(eo => eo.OrganizationModel)
                .SingleAsync()).OrganizationModel!;

            vacancyModel.OrganizationId = organization.Id;

            if (ModelState.IsValid)
            {
                _context.Add(vacancyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", vacancyModel.ProfessionId);
            
            return View(vacancyModel);
        }



        private bool VacancyModelExists(int id) => (_context.Vacancy?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}