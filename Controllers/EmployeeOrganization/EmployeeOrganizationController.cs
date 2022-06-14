using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.EmployeeOrganization
{
    public class EmployeeOrganizationController : Controller
    {
        private readonly EasyToEnterDbContext _context;
        public EmployeeOrganizationController(EasyToEnterDbContext context) => _context = context;



        [HttpGet]
        [Authorized]
        //[EmployeeOrganization]
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
        [Authorized]
        //[EmployeeOrganization]
        public async Task<IActionResult> EditVacancyAsync(int? vacancyId)
        {
            if (vacancyId == null || _context.Vacancy == null) return NotFound();

            VacancyModel? vacancy = await _context.EmployerOrganization
                .Where(eo => eo.PersonId == User.Id())
                .Include(eo => eo.OrganizationModel!.Vacancys!)
                .SelectMany(eo => eo.OrganizationModel!.Vacancys!)
                .SingleOrDefaultAsync(v => v.Id == vacancyId);

            if (vacancy == null) return RedirectToAction("AccessDenied", "Authentication");

            return View(vacancy);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVacancyAsync(int id, [Bind("Wages,Description,Name,Id")] VacancyModel vacancyModel)
        {
            if (id != vacancyModel.Id) return NotFound();

            OrganizationModel organization = (await _context.EmployerOrganization
                .Where(eo => eo.PersonId == User.Id())
                .Include(eo => eo.OrganizationModel)
                .SingleAsync()).OrganizationModel!;

            vacancyModel.OrganizationId = organization.Id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyModelExists(vacancyModel.Id)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(vacancyModel);
        }



        [HttpGet]
        [Authorized]
        //[EmployeeOrganization]
        public IActionResult NewVacancyAsync() => View();



        [HttpPost]
        [ValidateAntiForgeryToken]
        //[EmployeeOrganization]
        public async Task<IActionResult> NewVacancyAsync([Bind("Wages,Description,Name")] VacancyModel vacancyModel)
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

            return View(vacancyModel);
        }



        private bool VacancyModelExists(int id) => (_context.Vacancy?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}