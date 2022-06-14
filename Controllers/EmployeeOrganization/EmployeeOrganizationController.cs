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
        public async Task<IActionResult> EditVacancy(int vacancyId)
        {
            VacancyModel? vacancy = await _context.EmployerOrganization
                .Where(eo => eo.PersonId == User.Id())
                .Include(eo => eo.OrganizationModel!.Vacancys!)
                .SelectMany(eo => eo.OrganizationModel!.Vacancys!)
                .SingleOrDefaultAsync(v => v.Id == vacancyId);

            if (vacancy == null) return NotFound();

            return View(vacancy);
        }



        [HttpGet]
        [Authorized]
        //[EmployeeOrganization]
        public IActionResult NewVacancy()
        {
            return View();
        }
    }
}